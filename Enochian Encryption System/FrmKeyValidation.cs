using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics; // [CRITICAL] Needed for accurate validation

namespace Enochian_Encryption_System
{
    public partial class FrmKeyValidation : Form
    {
        private int _matrixSize;

        public FrmKeyValidation()
        {
            InitializeComponent();
        }

        private void FrmKeyValidation_Load(object sender, EventArgs e)
        {
            if (!GlobalSession.Step9_Done)
            {
                MessageBox.Show("Step 9 (Key Factor Generation) is not finished.", "Access Denied");
                this.Close();
                return;
            }
            _matrixSize = GlobalSession.MatrixSize;
            DisplayMatrix(dgvOriginal, GlobalSession.KeyMatrix);
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            GlobalSession.ResetEncryptionMetrics(); // <--- RESET BUCKETS
            MetricProbe probe = new MetricProbe(true); // <--- START MEASURING
            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                int[,] K = GlobalSession.KeyMatrix;
                int N = _matrixSize;

                // 1. Calculate Real Determinant (Display Only)
                double realDet = CalculateRawDeterminant(K, N);

                // Update UI Textbox
                UpdateDeterminantDisplay($"{realDet:0.###E+0}");

                // 2. VALIDATE USING BIGINTEGER
                // The Generator in Step 9 is now Constructive, so this MUST be valid.
                BigInteger modDet = GaussianDeterminantBigInt(K, N, 21);
                BigInteger gcd = BigInteger.GreatestCommonDivisor(BigInteger.Abs(modDet), 21);

                sw.Stop();
                probe.StopAndAccumulate(); // <--- ADD TO TOTAL
                Control[] statusCtrls = this.Controls.Find("lblStatus", true);

                if (gcd == 1)
                {
                    if (statusCtrls.Length > 0)
                    {
                        statusCtrls[0].Text = "VALID KEY CONFIRMED";
                        statusCtrls[0].ForeColor = Color.Green;
                    }

                    GlobalSession.Step10_Done = true;
                    btnConfirm.Enabled = true;

                    MessageBox.Show($"Validation Successful!\n\nReal Det: {realDet:0.###E+0}\nModulo Check: {modDet}\n(GCD = 1)\n\nThe key matches the Seeds and is mathematically sound.");
                    GlobalSession.LogEncTime("Step 10: Validation", sw.Elapsed.TotalMilliseconds);
                }
                else
                {
                    // If this happens, the Generator in Step 9 failed.
                    // We DO NOT regenerate here because that breaks the Seed link.
                    if (statusCtrls.Length > 0)
                    {
                        statusCtrls[0].Text = "INVALID KEY";
                        statusCtrls[0].ForeColor = Color.Red;
                    }
                    MessageBox.Show("Critical Error: The generated matrix is Singular Modulo 21.\n\nDo NOT proceed.\nPlease go back to Step 9 and click 'Generate Key' again.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Validation Error: " + ex.Message);
            }
        }

        private void UpdateDeterminantDisplay(string value)
        {
            Control[] ctrls = this.Controls.Find("txtDeterminant", true);
            if (ctrls.Length > 0) { ctrls[0].Text = value; return; }
            ctrls = this.Controls.Find("lblDet", true);
            if (ctrls.Length > 0) { ctrls[0].Text = value; return; }
        }

        private BigInteger GaussianDeterminantBigInt(int[,] matrix, int n, int mod)
        {
            BigInteger[,] temp = new BigInteger[n, n];
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) temp[r, c] = matrix[r, c] % mod;

            BigInteger det = 1;
            for (int i = 0; i < n; i++)
            {
                int pivot = i;
                while (pivot < n && BigInteger.GreatestCommonDivisor(temp[pivot, i], mod) != 1) pivot++;
                if (pivot == n) return 0;

                if (pivot != i)
                {
                    for (int j = 0; j < n; j++) { BigInteger t = temp[i, j]; temp[i, j] = temp[pivot, j]; temp[pivot, j] = t; }
                    det = -det;
                }
                det = (det * temp[i, i]) % mod;
                BigInteger inv = ModInverseBigInt(temp[i, i], mod);

                for (int j = i + 1; j < n; j++)
                {
                    BigInteger factor = (temp[j, i] * inv) % mod;
                    for (int k = i; k < n; k++)
                    {
                        temp[j, k] = (temp[j, k] - (factor * temp[i, k])) % mod;
                    }
                }
            }
            return (det + mod) % mod;
        }

        private double CalculateRawDeterminant(int[,] matrix, int n)
        {
            double[,] temp = new double[n, n];
            for (int r = 0; r < n; r++) for (int c = 0; c < n; c++) temp[r, c] = (double)matrix[r, c];
            double det = 1.0;
            for (int i = 0; i < n; i++)
            {
                int pivot = i; for (int j = i + 1; j < n; j++) if (Math.Abs(temp[j, i]) > Math.Abs(temp[pivot, i])) pivot = j;
                if (Math.Abs(temp[pivot, i]) < 1e-9) return 0.0;
                if (pivot != i) { for (int j = 0; j < n; j++) { double t = temp[i, j]; temp[i, j] = temp[pivot, j]; temp[pivot, j] = t; } det = -det; }
                det *= temp[i, i];
                for (int j = i + 1; j < n; j++) { double f = temp[j, i] / temp[i, i]; for (int k = i; k < n; k++) temp[j, k] -= f * temp[i, k]; }
            }
            return det;
        }

        private BigInteger ModInverseBigInt(BigInteger a, int m)
        {
            a = a % m;
            if (a < 0) a += m;
            for (int x = 1; x < m; x++) if ((a * x) % m == 1) return x;
            return -1;
        }

        private void DisplayMatrix(DataGridView dgv, int[,] matrix)
        {
            if (dgv == null) return;
            dgv.ColumnCount = _matrixSize;
            dgv.Rows.Clear();
            for (int i = 0; i < dgv.ColumnCount; i++) dgv.Columns[i].Width = 35;
            for (int i = 0; i < _matrixSize; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgv);
                for (int j = 0; j < _matrixSize; j++) row.Cells[j].Value = matrix[i, j];
                dgv.Rows.Add(row);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            GlobalSession.Step10_Done = true;
            this.Close();
        }
    }
}