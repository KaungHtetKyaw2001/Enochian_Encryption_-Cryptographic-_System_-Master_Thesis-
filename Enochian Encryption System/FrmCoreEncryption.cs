using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Enochian_Encryption_System
{
    public partial class FrmCoreEncryption : Form
    {
        private int[] _sBox = new int[21];
        private List<int[,]> _sBoxedResult = new List<int[,]>();
        private List<int[,]> _finalCipherResult = new List<int[,]>();

        public FrmCoreEncryption()
        {
            InitializeComponent();
        }

        private void FrmCoreEncryption_Load(object sender, EventArgs e)
        {
            if (!GlobalSession.Step10_Done)
            {
                MessageBox.Show("Please complete Step 10 (Key Validation) first.", "Access Denied");
                this.Close();
                return;
            }

            lblSeed.Text = $"{GlobalSession.LorentzInt2}";

            // Display Key Matrix
            if (GlobalSession.KeyMatrix != null)
            {
                StringBuilder sb = new StringBuilder();
                int size = GlobalSession.MatrixSize;
                sb.AppendLine("Encryption Key Matrix (K):");
                for (int r = 0; r < size; r++)
                {
                    sb.Append("  [ ");
                    for (int c = 0; c < size; c++) sb.Append($"{GlobalSession.KeyMatrix[r, c],-3} ");
                    sb.AppendLine("]");
                }
                rtbKeyStatus.Text = sb.ToString();
            }

            rtbOutputPreview.Clear();
            rtbSBoxPreview.Clear();
            btnHillCipher.Enabled = false;
        }

        private void btnSBox_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            // 1. Generate S-Box (Fisher-Yates)
            Random rng = new Random(GlobalSession.LorentzInt2);
            int[] tempBox = new int[21];
            for (int i = 0; i < 21; i++) tempBox[i] = i + 1;

            for (int i = tempBox.Length - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                int temp = tempBox[i];
                tempBox[i] = tempBox[j];
                tempBox[j] = temp;
            }
            _sBox = tempBox;

            // 2. Substitute Matrices
            _sBoxedResult.Clear();
            int N = GlobalSession.MatrixSize;

            if (GlobalSession.PlaintextMatrices != null)
            {
                foreach (int[,] mat in GlobalSession.PlaintextMatrices)
                {
                    int[,] subMat = new int[N, N];
                    for (int r = 0; r < N; r++)
                    {
                        for (int c = 0; c < N; c++)
                        {
                            int val = mat[r, c];
                            if (val >= 1 && val <= 21) subMat[r, c] = _sBox[val - 1];
                            else subMat[r, c] = val; // Padding 0
                        }
                    }
                    _sBoxedResult.Add(subMat);
                }
            }

            VisualizeSBoxMatrices(N);

            sw.Stop();
            GlobalSession.LogEncTime("Step 11a: S-Box Sub", sw.Elapsed.TotalMilliseconds);

            MessageBox.Show($"Stage 1 Complete.\nSubstituted {_sBoxedResult.Count} blocks.");
            btnHillCipher.Enabled = true;
        }

        private void btnHillCipher_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int N = GlobalSession.MatrixSize;
            int[,] K = GlobalSession.KeyMatrix;
            _finalCipherResult.Clear();

            // [FIXED] Multiplication now handles large numbers
            foreach (int[,] P in _sBoxedResult)
            {
                int[,] C = MultiplyMatrix(P, K, N);
                _finalCipherResult.Add(C);
            }

            VisualizeEncryptedMatrices(N);

            sw.Stop();
            GlobalSession.LogEncTime("Step 11b: Hill Cipher", sw.Elapsed.TotalMilliseconds);

            btnConfirm.Enabled = true;
            MessageBox.Show($"Encryption Complete!\nTotal Time: {sw.Elapsed.TotalMilliseconds:F4} ms");
        }

        // --- VISUALIZATION HELPERS ---
        private void VisualizeSBoxMatrices(int N)
        {
            rtbSBoxPreview.Clear();
            StringBuilder sb = new StringBuilder();

            // 1. Show Full S-Box Map
            sb.AppendLine("S-Box Mapping Rules (Non-Linear):");
            int count = 0;
            for (int i = 0; i < 21; i++)
            {
                sb.Append($"{i + 1}->{_sBox[i]}".PadRight(9));
                count++;
                if (count % 7 == 0) sb.AppendLine();
            }
            sb.AppendLine("\n" + new string('-', 60) + "\n");

            // 2. Show Matrices
            if (_sBoxedResult.Count > 0)
            {
                int cellWidth = 4;
                int matrixWidthChars = 4 + (N * cellWidth);
                int charPixelWidth = 8;
                int availableChars = Math.Max(10, rtbSBoxPreview.Width / charPixelWidth);

                int itemsPerRow = Math.Max(1, availableChars / (matrixWidthChars + 3));
                if (itemsPerRow > 1) itemsPerRow--;

                int total = _sBoxedResult.Count;
                for (int i = 0; i < total; i += itemsPerRow)
                {
                    int rowCount = Math.Min(itemsPerRow, total - i);

                    // Headers
                    for (int j = 0; j < rowCount; j++)
                    {
                        string header = $"Block {i + j + 1}";
                        int padding = Math.Max(0, (matrixWidthChars - header.Length) / 2);
                        sb.Append(new string(' ', padding) + header + new string(' ', Math.Max(0, matrixWidthChars - header.Length - padding)) + "   ");
                    }
                    sb.AppendLine();

                    // Rows
                    for (int r = 0; r < N; r++)
                    {
                        for (int j = 0; j < rowCount; j++)
                        {
                            int[,] mat = _sBoxedResult[i + j];
                            sb.Append("[ ");
                            for (int c = 0; c < N; c++)
                            {
                                sb.Append($"{mat[r, c],-2} ".PadRight(cellWidth));
                            }
                            sb.Append("]   ");
                        }
                        sb.AppendLine();
                    }
                    sb.AppendLine();
                }
            }
            rtbSBoxPreview.Text = sb.ToString();
        }

        private void VisualizeEncryptedMatrices(int N)
        {
            rtbOutputPreview.Clear();
            if (_finalCipherResult.Count == 0) return;

            StringBuilder sb = new StringBuilder();

            int cellWidth = 4;
            int matrixWidthChars = 4 + (N * cellWidth);
            int charPixelWidth = 8;
            int availableChars = Math.Max(10, rtbOutputPreview.Width / charPixelWidth);
            int itemsPerRow = Math.Max(1, availableChars / (matrixWidthChars + 3));
            if (itemsPerRow > 1) itemsPerRow--;

            int total = _finalCipherResult.Count;
            for (int i = 0; i < total; i += itemsPerRow)
            {
                int rowCount = Math.Min(itemsPerRow, total - i);

                for (int j = 0; j < rowCount; j++)
                {
                    string header = $"Cipher {i + j + 1}";
                    int padding = Math.Max(0, (matrixWidthChars - header.Length) / 2);
                    sb.Append(new string(' ', padding) + header + new string(' ', Math.Max(0, matrixWidthChars - header.Length - padding)) + "   ");
                }
                sb.AppendLine();

                for (int r = 0; r < N; r++)
                {
                    for (int j = 0; j < rowCount; j++)
                    {
                        int[,] mat = _finalCipherResult[i + j];
                        sb.Append("[ ");
                        for (int c = 0; c < N; c++)
                        {
                            sb.Append($"{mat[r, c],-2} ".PadRight(cellWidth));
                        }
                        sb.Append("]   ");
                    }
                    sb.AppendLine();
                }
                sb.AppendLine();
            }
            rtbOutputPreview.Text = sb.ToString();
        }

        // --- MATH (CRITICAL UPDATE) ---
        private int[,] MultiplyMatrix(int[,] A, int[,] B, int n)
        {
            int[,] C = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // [CRITICAL] Use long to prevent Integer Overflow
                    // 21 (Plain) * 50,000,000 (Key) * 40 (Size) = 42 Billion
                    // int max = 2.1 Billion. long max = 9 Quintillion.
                    long sum = 0;
                    for (int k = 0; k < n; k++)
                    {
                        sum += (long)A[i, k] * (long)B[k, j];
                    }

                    // Modulo Logic 1-21
                    int val = (int)(sum % 21);
                    if (val <= 0) val += 21;
                    C[i, j] = val;
                }
            }
            return C;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            GlobalSession.SBoxedMatrices = _sBoxedResult;
            GlobalSession.EncryptedMatrices = _finalCipherResult;

            // Allow immediate decryption testing if needed
            GlobalSession.ShuffledDeck = _finalCipherResult;

            GlobalSession.Step11_Done = true;
            this.Close();
        }
    }
}