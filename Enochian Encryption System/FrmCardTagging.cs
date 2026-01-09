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
    public partial class FrmCardTagging : Form
    {
        private List<string> _generatedTags = new List<string>();

        public FrmCardTagging()
        {
            InitializeComponent();
        }

        private void FrmCardTagging_Load(object sender, EventArgs e)
        {
            if (!GlobalSession.Step11_Done)
            {
                MessageBox.Show("Please complete Step 11 (Core Encryption) first.", "Access Denied");
                this.Close();
                return;
            }

            lblBase.Text = $"Integrity Base (Lorentz Z): {GlobalSession.LorentzInt3}";
            lblCount.Text = $"Total Cards to Tag: {GlobalSession.EncryptedMatrices?.Count ?? 0}";

            // --- GRID SETUP ---
            dgvTags.Rows.Clear();
            dgvTags.ColumnCount = 3;
            dgvTags.Columns[0].Name = "Card ID";
            dgvTags.Columns[1].Name = "Matrix Content";
            dgvTags.Columns[2].Name = "Lorentz Hash Tag";

            // Enable Multi-line Text for Matrices
            dgvTags.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTags.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTags.Columns[1].DefaultCellStyle.Font = new Font("Consolas", 9); // Monospaced font aligns numbers
            dgvTags.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnTag_Click(object sender, EventArgs e)
        {
            GlobalSession.ResetEncryptionMetrics(); // <--- RESET BUCKETS
            MetricProbe probe = new MetricProbe(true); // <--- START MEASURING

            Stopwatch sw = Stopwatch.StartNew();
            _generatedTags.Clear();
            dgvTags.Rows.Clear();

            if (GlobalSession.EncryptedMatrices == null) return;

            // 1. SETUP RANDOM MODULUS
            Random rng = new Random();
            long modulus = rng.Next(1000000, 9999999);
            GlobalSession.HashModulus = modulus;

            long z = GlobalSession.LorentzInt3;
            if (z <= 1) z = 31;

            int cardIndex = 1;

            foreach (int[,] matrix in GlobalSession.EncryptedMatrices)
            {
                // [FIX] SECURITY SALT APPLIED HERE
                // Instead of starting at 0, we start with the unique Card Index.
                // This ensures Card #1 ("S") and Card #2 ("S") get DIFFERENT hashes.
                long currentHash = cardIndex;

                StringBuilder preview = new StringBuilder();
                int N = matrix.GetLength(0);

                // Build Matrix String & Calculate Hash
                for (int r = 0; r < N; r++)
                {
                    preview.Append("[ ");
                    for (int c = 0; c < N; c++)
                    {
                        int val = matrix[r, c];

                        // Display: Pad for alignment
                        preview.Append($"{val,-3} ");

                        // Hash Calculation: (Salt + Value * Z) % Modulus
                        currentHash = (currentHash * z + val) % modulus;
                    }
                    preview.Append("]");
                    if (r < N - 1) preview.AppendLine(); // New line for next row
                }

                string tag = Math.Abs(currentHash).ToString();
                _generatedTags.Add(tag);

                dgvTags.Rows.Add($"Card #{cardIndex}", preview.ToString(), tag);
                cardIndex++;
            }

            sw.Stop();
            probe.StopAndAccumulate(); // <--- ADD TO TOTAL
            GlobalSession.LogEncTime("Step 12: Card Tagging", sw.Elapsed.TotalMilliseconds);

            // 2. SAVE MANIFEST
            GlobalSession.ReferenceHashList.Clear();
            GlobalSession.ReferenceHashList.AddRange(_generatedTags);
            GlobalSession.CardTags = _generatedTags;

            btnConfirm.Enabled = true;
            MessageBox.Show($"Tagging Complete.\n" +
                            $"Dynamic Modulus: {modulus}\n" +
                            $"Unique Salt Applied: YES\n" +
                            $"Time: {sw.Elapsed.TotalMilliseconds:F4} ms");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            GlobalSession.Step12_Done = true;
            this.Close();
        }
    }
}