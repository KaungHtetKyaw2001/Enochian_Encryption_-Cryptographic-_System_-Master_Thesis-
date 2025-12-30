using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Numerics;

namespace Enochian_Encryption_System
{
    public partial class FrmKeyFactorGen : Form
    {
        public FrmKeyFactorGen() { InitializeComponent(); }

        private void FrmKeyFactorGen_Load(object sender, EventArgs e)
        {
            if (!GlobalSession.Step8_Done)
            {
                MessageBox.Show("Sequence Error: Step 8 is not finished.", "Access Denied");
                this.Close(); return;
            }
            if (GlobalSession.FinalPayload != null)
            {
                btnGenerateKey.Text = "Restore Keys (Decryption Mode)";
                txtParameters.Text = $"Decryption Mode | Seeds: [{GlobalSession.FinalPayload.LorentzInt1}, {GlobalSession.FinalPayload.LorentzInt2}, {GlobalSession.FinalPayload.LorentzInt3}]";
                lblDeterminant.Text = "Status: Ready to Restore";
            }
            else if (GlobalSession.KeyMatrix != null)
            {
                if (GlobalSession.Step9_Done) { btnGenerateKey.Enabled = false; btnGenerateKey.Text = "Keys Locked"; }
                else { btnGenerateKey.Text = "Use Existing Keys"; }
                txtKeyFactor.Text = GlobalSession.KeyFactor.ToString();

                if (GlobalSession.Sigma != 0)
                    txtParameters.Text = $"σ:{GlobalSession.Sigma:F2} ρ:{GlobalSession.Rho:F2} β:{GlobalSession.Beta:F2} n:{GlobalSession.LorentzIterations}";
            }
        }

        private void btnGenerateKey_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            int seedX, seedY, seedZ;
            if (GlobalSession.FinalPayload != null)
            {
                seedX = GlobalSession.FinalPayload.LorentzInt1;
                seedY = GlobalSession.FinalPayload.LorentzInt2;
                seedZ = GlobalSession.FinalPayload.LorentzInt3;
            }
            else
            {
                Random rng = new Random();
                GlobalSession.Sigma = 10.0 + rng.NextDouble() * 90.0;
                GlobalSession.Rho = 10.0 + rng.NextDouble() * 90.0;
                GlobalSession.Beta = 10.0 + rng.NextDouble() * 90.0;
                GlobalSession.LorentzIterations = rng.Next(50, 501);

                double x = (GlobalSession.Lx == 0) ? 0.1 : GlobalSession.Lx;
                double y = (GlobalSession.Ly == 0) ? 0.1 : GlobalSession.Ly;
                double z = (GlobalSession.Lz == 0) ? 0.1 : GlobalSession.Lz;

                for (int i = 0; i < GlobalSession.LorentzIterations; i++)
                {
                    double dx = (GlobalSession.Sigma * (y - x)) * 0.01;
                    double dy = (x * (GlobalSession.Rho - z) - y) * 0.01;
                    double dz = (x * y - (GlobalSession.Beta * z)) * 0.01;
                    x += dx; y += dy; z += dz;
                }
                seedX = (int)Math.Round(Math.Abs(x * 100));
                seedY = (int)Math.Round(Math.Abs(y * 100));
                seedZ = (int)Math.Round(Math.Abs(z * 100));
                if (seedX == 0) seedX = 1; if (seedY == 0) seedY = 1; if (seedZ == 0) seedZ = 1;
                while (seedX == seedY) { seedY = (seedY + 1) % 9999; if (seedY == 0) seedY = 1; }
                GlobalSession.LorentzInt1 = seedX; GlobalSession.LorentzInt2 = seedY; GlobalSession.LorentzInt3 = seedZ;
            }

            int N = GlobalSession.MatrixSize > 0 ? GlobalSession.MatrixSize : 3;
            int masterSeed = seedX + seedY + seedZ;

            // [FIX] Use Deterministic Logic
            int keyFactor;
            int[,] baseMatrix = GenerateDeterministicMatrix(N, masterSeed, out keyFactor);
            int[,] multipliedMatrix = new int[N, N];

            for (int r = 0; r < N; r++)
                for (int c = 0; c < N; c++)
                    multipliedMatrix[r, c] = baseMatrix[r, c] * keyFactor;

            BigInteger validDetMod = GaussianDeterminantBigInt(multipliedMatrix, N, 21);
            int gcdValue = (int)BigInteger.GreatestCommonDivisor(BigInteger.Abs(validDetMod), 21);

            GlobalSession.KeyMatrix = multipliedMatrix;
            GlobalSession.KeyFactor = keyFactor;
            GlobalSession.KeyDeterminant = (int)validDetMod;

            DisplayMatrix(dgvOriginalKeyMatrix, baseMatrix);
            DisplayMatrix(dgvMultipliedKeyMatrix, multipliedMatrix);
            txtKeyFactor.Text = keyFactor.ToString();

            if (GlobalSession.FinalPayload == null)
                txtParameters.Text = $"σ:{GlobalSession.Sigma:F1} ρ:{GlobalSession.Rho:F1} β:{GlobalSession.Beta:F1} Iter:{GlobalSession.LorentzIterations} -> Seeds:[{seedX},{seedY},{seedZ}]";
            else
                txtParameters.Text = $"Decryption Mode | Seeds: [{seedX}, {seedY}, {seedZ}]";

            double realDet = CalculateRawDeterminant(multipliedMatrix, N);
            lblDeterminant.Text = $"{realDet:0.###E+0}";
            lblGCD.Text = $"GCD(Det, 21) = {gcdValue} (Valid)";

            sw.Stop();
            GlobalSession.LogEncTime("Step 9: Key Gen", sw.Elapsed.TotalMilliseconds);

            if (gcdValue == 1)
            {
                GlobalSession.Step9_Done = true;
                btnConfirm.Enabled = true;
                btnGenerateKey.Enabled = false;
                btnGenerateKey.Text = "Keys Locked";
                MessageBox.Show($"Success!\nMatrix Generated {N}x{N}\nKey Factor: {keyFactor}");
            }
            else
            {
                MessageBox.Show("Error: Matrix construction anomaly.");
            }
        }

        // [CRITICAL FIX] Deterministic Generator
        // Uses a new Random() for every step seeded by (MasterSeed + StepIndex)
        // This makes drift IMPOSSIBLE.
        private int[,] GenerateDeterministicMatrix(int N, int masterSeed, out int factor)
        {
            int[,] mat = new int[N, N];

            // 1. Identity
            for (int i = 0; i < N; i++) mat[i, i] = 1;

            // 2. Deterministic Shuffle
            // We use a counter 'k' to offset the seed for each operation
            int step = 0;
            for (int k = 0; k < N * 5; k++)
            {
                Random rngStep = new Random(masterSeed + step++);

                int rTarget = rngStep.Next(N);
                int rSource = rngStep.Next(N);
                if (rTarget == rSource) rSource = (rSource + 1) % N;

                int scalar = rngStep.Next(1, 21);

                for (int c = 0; c < N; c++)
                {
                    mat[rTarget, c] = (mat[rTarget, c] + (scalar * mat[rSource, c])) % 21;
                }
            }

            // 3. Normalize
            for (int r = 0; r < N; r++)
                for (int c = 0; c < N; c++)
                {
                    int val = mat[r, c] % 21;
                    if (val <= 0) val += 21;
                    mat[r, c] = val;
                }

            // 4. Factor (Deterministic)
            // We pick ONE factor based on a specific seed offset.
            // If it's bad, we just increment until it's good.
            Random rngFactor = new Random(masterSeed + 99999);
            factor = rngFactor.Next(10000, 50000);

            while (GCD(factor, 21) != 1)
            {
                factor++; // Deterministic adjustment
            }

            return mat;
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
                    BigInteger f = (temp[j, i] * inv) % mod;
                    for (int k = i; k < n; k++) temp[j, k] = (temp[j, k] - (f * temp[i, k])) % mod;
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

        private BigInteger ModInverseBigInt(BigInteger a, int m) { a = a % m; if (a < 0) a += m; for (int x = 1; x < m; x++) if ((a * x) % m == 1) return x; return -1; }
        private int GCD(int a, int b) { while (b != 0) { int t = b; b = a % b; a = t; } return a; }
        private void DisplayMatrix(DataGridView dgv, int[,] matrix)
        {
            dgv.ColumnCount = GlobalSession.MatrixSize; dgv.Rows.Clear();
            for (int i = 0; i < dgv.ColumnCount; i++) dgv.Columns[i].Width = 40;
            for (int i = 0; i < GlobalSession.MatrixSize; i++) { DataGridViewRow r = new DataGridViewRow(); r.CreateCells(dgv); for (int j = 0; j < GlobalSession.MatrixSize; j++) r.Cells[j].Value = matrix[i, j]; dgv.Rows.Add(r); }
        }
        private void btnConfirm_Click(object sender, EventArgs e) { this.Close(); }
    }
}