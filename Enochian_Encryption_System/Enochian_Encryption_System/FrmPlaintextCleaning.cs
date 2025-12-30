using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Enochian_Encryption_System
{
    public partial class FrmPlaintextCleaning : Form
    {
        private List<CharMarker> _tempRemovedMap = new List<CharMarker>();
        private string _tempCleanedText = "";
        public FrmPlaintextCleaning()
        {
            InitializeComponent();
        }

        private void FrmPlaintextCleaning_Load(object sender, EventArgs e)
        {
            // STRICT CHECK: Is Step 3 Done?
            if (!GlobalSession.Step3_Done)
            {
                MessageBox.Show("Sequence Error: Step 3 (Plaintext Prep) is not finished.",
                                "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Load Input from Step 3
            txtInput.Text = GlobalSession.PreProcessedText;

            // Setup Grid View columns
            gridRemoved.ColumnCount = 2;
            gridRemoved.Columns[0].Name = "Original Index";
            gridRemoved.Columns[1].Name = "Character";
            gridRemoved.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            // 1. START TIMER
            Stopwatch sw = Stopwatch.StartNew();

            string source = txtInput.Text;
            StringBuilder sbClean = new StringBuilder();
            _tempRemovedMap.Clear();
            gridRemoved.Rows.Clear();

            // 2. ITERATE AND FILTER
            for (int i = 0; i < source.Length; i++)
            {
                char c = source[i];

                // Check if it is a valid English Letter (A-Z or a-z)
                if (char.IsLetter(c))
                {
                    // Keep it (Convert to Upper case for Enochian standard)
                    sbClean.Append(char.ToUpper(c));
                }
                else
                {
                    // It is a space, symbol, or punctuation -> REMOVE & TRACK
                    // We save the 'i' (original index) so we can put it back later
                    CharMarker marker = new CharMarker { Index = i, Character = c };
                    _tempRemovedMap.Add(marker);
                }
            }

            _tempCleanedText = sbClean.ToString();

            // 3. STOP TIMER
            sw.Stop();

            // 4. UPDATE UI
            txtOutput.Text = _tempCleanedText;

            // Populate Grid (Show first 100 items only to prevent lag if text is huge)
            foreach (var item in _tempRemovedMap)
            {
                if (gridRemoved.Rows.Count < 100)
                    gridRemoved.Rows.Add(item.Index, $"'{item.Character}'");
            }
            if (_tempRemovedMap.Count > 100)
                gridRemoved.Rows.Add("...", "... more ...");

            // Log Time immediately (Requirement)
            GlobalSession.LogEncTime("Step 4: Cleaning", sw.Elapsed.TotalMilliseconds);

            btnConfirm.Enabled = true;
            MessageBox.Show($"Cleaning Complete.\nRemoved {_tempRemovedMap.Count} symbols.\nTime: {sw.Elapsed.TotalMilliseconds:F4} ms", "Success");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            GlobalSession.CleanedText = _tempCleanedText;
            GlobalSession.RemovedSpecialChars = _tempRemovedMap;
            GlobalSession.Step4_Done = true;
            
            this.Close();
        }
    }
}
