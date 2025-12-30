using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Numerics;

namespace Enochian_Encryption_System
{
    public partial class FrmCoreDecryption : Form
    {
        public FrmCoreDecryption() { InitializeComponent(); }

        private int[,] _inverseKey;
        private int[] _reverseSBox;
        private int _matrixSize;

        private void FrmCoreDecryption_Load(object sender, EventArgs e)
        {
            if (!GlobalSession.DecStep5_Done) { MessageBox.Show("Sequence Error: Step 5 not done."); this.Close(); return; }
            _matrixSize = GlobalSession.MatrixSize;
            lblStatus.Text = "Status: Ready to Decrypt";
            lblCount.Text = $"Cards: {GlobalSession.ShuffledDeck?.Count ?? 0}";
            rtbDecryptionOutput.Clear();
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                if (GlobalSession.KeyMatrix == null) throw new Exception("Key Matrix is missing.");
                int[,] K = GlobalSession.KeyMatrix;
                int N = _matrixSize;

                DisplayMatrix(dgvFactorMultipliedKeyMatrix, K);

                BigInteger det = GaussianDeterminantBigInt(K, N, 21);
                BigInteger detInverse = ModInverseBigInt(det, 21);
                if (detInverse == -1) throw new Exception($"Singular Matrix! Det={det}");

                lblModularInverseDeterminant.Text = detInverse.ToString();

                _inverseKey = MatrixInverseGaussianBigInt(K, N, 21);

                int[,] adjugateMatrix = new int[N, N];
                for (int r = 0; r < N; r++)
                {
                    for (int c = 0; c < N; c++)
                    {
                        BigInteger val = (new BigInteger(_inverseKey[r, c]) * det) % 21;
                        adjugateMatrix[r, c] = (int)SafeMod(val, 21);
                    }
                }

                DisplayMatrix(dgvAdjugateKeyMatrix, adjugateMatrix);
                DisplayMatrix(dgvInverseMatrix, _inverseKey);

                GenerateReverseSBox(GlobalSession.LorentzInt2);

                List<int[,]> decryptedMatrices = new List<int[,]>();
                if (GlobalSession.ShuffledDeck == null) throw new Exception("No deck loaded.");

                foreach (int[,] cipherMatrix in GlobalSession.ShuffledDeck)
                {
                    int[,] unCipheredMatrix = MultiplyMatrix(cipherMatrix, _inverseKey, 21);
                    int[,] finalPlainMatrix = new int[N, N];
                    for (int r = 0; r < N; r++)
                        for (int c = 0; c < N; c++)
                        {
                            int val = unCipheredMatrix[r, c];
                            if (val < 1) val = 1; if (val > 21) val = 21;
                            finalPlainMatrix[r, c] = _reverseSBox[val - 1];
                        }
                    decryptedMatrices.Add(finalPlainMatrix);
                }

                GlobalSession.PlaintextMatrices = decryptedMatrices;
                VisualizeDecryptedMatrices(decryptedMatrices, N);

                lblStatus.Text = "Decryption Complete";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                btnConfirm.Enabled = true;
                sw.Stop();
                MessageBox.Show($"Success!\nDecrypted {decryptedMatrices.Count} blocks.");
            }
            catch (Exception ex) { sw.Stop(); MessageBox.Show("Error: " + ex.Message); }
        }

        private int[,] MultiplyMatrix(int[,] A, int[,] B, int mod)
        {
            int n = _matrixSize;
            int[,] C = new int[n, n];
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    long sum = 0;
                    for (int k = 0; k < n; k++) sum += (long)A[r, k] * (long)B[k, c];
                    long val = (sum - 1) % mod;
                    if (val < 0) val += mod;
                    C[r, c] = (int)(val + 1);
                }
            }
            return C;
        }

        private BigInteger SafeMod(BigInteger a, int m)
        {
            BigInteger res = a % m;
            if (res < 0) res += m;
            return (res == 0) ? m : res;
        }

        private int[,] MatrixInverseGaussianBigInt(int[,] matrix, int n, int mod)
        {
            BigInteger[,] aug = new BigInteger[n, 2 * n];
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++) aug[r, c] = matrix[r, c] % mod;
                aug[r, r + n] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                int pivot = i;
                while (pivot < n && BigInteger.GreatestCommonDivisor(aug[pivot, i], mod) != 1) pivot++;
                if (pivot == n) throw new Exception("Singular Matrix");

                if (pivot != i)
                    for (int j = 0; j < 2 * n; j++) { BigInteger t = aug[i, j]; aug[i, j] = aug[pivot, j]; aug[pivot, j] = t; }

                BigInteger inv = ModInverseBigInt(aug[i, i], mod);
                for (int j = 0; j < 2 * n; j++) aug[i, j] = SafeMod(aug[i, j] * inv, mod);

                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        BigInteger f = aug[k, i];
                        for (int j = 0; j < 2 * n; j++) aug[k, j] = SafeMod(aug[k, j] - (f * aug[i, j]), mod);
                    }
                }
            }

            int[,] invMat = new int[n, n];
            for (int r = 0; r < n; r++)
                for (int c = 0; c < n; c++)
                    invMat[r, c] = (int)SafeMod(aug[r, c + n], mod);
            return invMat;
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
                if (pivot != i) { for (int j = 0; j < n; j++) { BigInteger t = temp[i, j]; temp[i, j] = temp[pivot, j]; temp[pivot, j] = t; } det = -det; }
                det = SafeMod(det * temp[i, i], mod);
                BigInteger inv = ModInverseBigInt(temp[i, i], mod);
                for (int j = i + 1; j < n; j++)
                {
                    BigInteger f = SafeMod(temp[j, i] * inv, mod);
                    for (int k = i; k < n; k++) temp[j, k] = SafeMod(temp[j, k] - (f * temp[i, k]), mod);
                }
            }
            if (det < 0) det += mod;
            return det;
        }

        private BigInteger ModInverseBigInt(BigInteger a, int m)
        {
            a = a % m; if (a < 0) a += m;
            for (int x = 1; x < m; x++) if ((a * x) % m == 1) return x;
            return -1;
        }

        private void GenerateReverseSBox(int seed)
        {
            List<int> sbox = new List<int>(); for (int i = 1; i <= 21; i++) sbox.Add(i);
            Random rng = new Random(seed); int n = sbox.Count;
            while (n > 1) { n--; int k = rng.Next(n + 1); int value = sbox[k]; sbox[k] = sbox[n]; sbox[n] = value; }
            _reverseSBox = new int[21]; for (int i = 0; i < 21; i++) _reverseSBox[sbox[i] - 1] = i + 1;
        }

        private void VisualizeDecryptedMatrices(List<int[,]> matrices, int N)
        {
            rtbDecryptionOutput.Clear(); if (matrices.Count == 0) return;
            StringBuilder sb = new StringBuilder(); int cellWidth = 4;
            int matrixWidthChars = 4 + (N * cellWidth);
            int itemsPerRow = Math.Max(1, (rtbDecryptionOutput.Width / 8) / (matrixWidthChars + 3)); if (itemsPerRow > 1) itemsPerRow--;

            for (int i = 0; i < matrices.Count; i += itemsPerRow)
            {
                int count = Math.Min(itemsPerRow, matrices.Count - i);
                for (int j = 0; j < count; j++) { string header = $"Card {i + j + 1}"; int padding = Math.Max(0, (matrixWidthChars - header.Length) / 2); sb.Append(new string(' ', padding) + header + new string(' ', Math.Max(0, matrixWidthChars - header.Length - padding)) + "   "); }
                sb.AppendLine();
                for (int r = 0; r < N; r++) { for (int j = 0; j < count; j++) { int[,] mat = matrices[i + j]; sb.Append("[ "); for (int c = 0; c < N; c++) sb.Append($"{mat[r, c],-2} ".PadRight(cellWidth)); sb.Append("]   "); } sb.AppendLine(); }
                sb.AppendLine();
            }
            rtbDecryptionOutput.Text = sb.ToString();
        }

        private void DisplayMatrix(DataGridView dgv, int[,] matrix)
        {
            if (dgv == null) return; dgv.ColumnCount = _matrixSize; dgv.Rows.Clear();
            for (int i = 0; i < dgv.ColumnCount; i++) dgv.Columns[i].Width = 40;
            for (int i = 0; i < _matrixSize; i++) { DataGridViewRow row = new DataGridViewRow(); row.CreateCells(dgv); for (int j = 0; j < _matrixSize; j++) row.Cells[j].Value = matrix[i, j]; dgv.Rows.Add(row); }
        }
        private void btnConfirm_Click(object sender, EventArgs e) { GlobalSession.DecStep6_Done = true; this.Close(); }
    }
}