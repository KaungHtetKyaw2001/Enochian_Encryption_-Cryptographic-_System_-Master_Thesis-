using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

namespace Enochian_Encryption_System
{
    public partial class FrmMatrixAllocation : Form
    {
        private List<int[,]> _tempValueMatrices = new List<int[,]>();
        private List<string[,]> _tempMarkerMatrices = new List<string[,]>();

        public FrmMatrixAllocation()
        {
            InitializeComponent();
        }

        private void FrmMatrixAllocation_Load(object sender, EventArgs e)
        {
            if (!GlobalSession.Step7_Done)
            {
                MessageBox.Show("Sequence Error: Step 7 (Second Shift) is not finished.", "Access Denied");
                this.Close();
                return;
            }
            txtInput.Text = GlobalSession.SecondShiftOutput;

            // [FIX] Clear the preview box initially
            rtbAllocationPreview.Clear();
        }

        private void btnRandomSize_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            numSize.Value = rng.Next(2, 10);
        }

        private void btnAllocate_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            int N = (int)numSize.Value;
            GlobalSession.MatrixSize = N;

            // 1. Parse Step 7 Output into List of (Value, Marker)
            if (string.IsNullOrWhiteSpace(txtInput.Text)) return;

            string[] units = txtInput.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var dataList = new List<(int val, string mark)>();

            foreach (string unit in units)
            {
                string mark = unit.Substring(unit.Length - 1);
                string name = unit.Substring(0, unit.Length - 1);

                var match = EnochianDictionary.EnglishToEnochian.Values
                    .FirstOrDefault(m => m.Name == name);

                if (!string.IsNullOrEmpty(match.Name))
                {
                    dataList.Add((match.Value, mark));
                }
            }

            // 2. Padding Logic
            int blockSize = N * N;
            while (dataList.Count % blockSize != 0)
            {
                dataList.Add((21, "!"));
            }

            // 3. Partition into N x N Matrices
            _tempValueMatrices.Clear();
            _tempMarkerMatrices.Clear();

            for (int k = 0; k < dataList.Count; k += blockSize)
            {
                int[,] valMat = new int[N, N];
                string[,] markMat = new string[N, N];

                for (int r = 0; r < N; r++)
                {
                    for (int c = 0; c < N; c++)
                    {
                        var item = dataList[k + (r * N) + c];
                        valMat[r, c] = item.val;
                        markMat[r, c] = item.mark;
                    }
                }
                _tempValueMatrices.Add(valMat);
                _tempMarkerMatrices.Add(markMat);
            }


            lblBlockCount.Text = $"Total Blocks: {_tempValueMatrices.Count} ({N}x{N} size)";

            // [FIX] Use Text-Based Visualization
            VisualizeMatricesText(N);

            sw.Stop();
            GlobalSession.LogEncTime("Step 8: Matrix Allocation", sw.Elapsed.TotalMilliseconds);

            btnConfirm.Enabled = true;
            MessageBox.Show($"Allocation Complete.\nSize: {N}x{N}\nBlocks: {_tempValueMatrices.Count}");
        }

        // --- NEW HELPER FOR RICHTEXTBOX ---
        private void VisualizeMatricesText(int N)
        {
            rtbAllocationPreview.Clear();
            if (_tempValueMatrices.Count == 0) return;

            StringBuilder sb = new StringBuilder();

            // 1. Calculate spacing dynamically
            // A cell looks like "21!" (approx 3-4 chars). 
            // We add padding. E.g., Cell Width = 6 chars.
            // Matrix Width = (N * CellWidth) + brackets + padding.
            int cellWidth = 5;
            int matrixWidthChars = (N * cellWidth) + 4; // "[ " + cells + " ] "

            // 2. Calculate items per row based on Textbox Width
            // Approximate char width in pixels for Consolas 10pt is roughly 8px
            // This is an estimation. You can also just hardcode 4 or 5.
            int charPixelWidth = 8;
            int availableChars = rtbAllocationPreview.Width / charPixelWidth;
            int itemsPerRow = Math.Max(1, availableChars / matrixWidthChars);

            // Safety cap to prevent horizontal overflow if calc is slightly off
            if (itemsPerRow > 1) itemsPerRow--;

            // 3. Loop through chunks
            int totalMatrices = _tempValueMatrices.Count;

            for (int i = 0; i < totalMatrices; i += itemsPerRow)
            {
                int count = Math.Min(itemsPerRow, totalMatrices - i);

                // A. DRAW HEADERS (Block 1, Block 2...)
                for (int j = 0; j < count; j++)
                {
                    int idx = i + j;
                    string header = $"Block {idx + 1}";
                    // Center the header over the matrix
                    int padding = (matrixWidthChars - header.Length) / 2;
                    sb.Append(new string(' ', padding) + header + new string(' ', matrixWidthChars - header.Length - padding));
                }
                sb.AppendLine();

                // B. DRAW ROWS
                for (int r = 0; r < N; r++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        int idx = i + j;
                        int[,] vals = _tempValueMatrices[idx];
                        string[,] marks = _tempMarkerMatrices[idx];

                        sb.Append("[ ");
                        for (int c = 0; c < N; c++)
                        {
                            string cell = $"{vals[r, c]}{marks[r, c]}"; // e.g., "16!"
                            sb.Append(cell.PadRight(cellWidth));
                        }
                        sb.Append("] ");
                    }
                    sb.AppendLine();
                }
                sb.AppendLine(); // Empty line between rows of blocks
            }

            rtbAllocationPreview.Text = sb.ToString();

            // Auto-scroll to top
            rtbAllocationPreview.SelectionStart = 0;
            rtbAllocationPreview.ScrollToCaret();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            GlobalSession.PlaintextMatrices = _tempValueMatrices;
            GlobalSession.MarkerMatrices = _tempMarkerMatrices;
            GlobalSession.Step8_Done = true;
            this.Close();
        }
    }
}