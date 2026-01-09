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
    public partial class FrmAlphabetMapping : Form
    {
        public FrmAlphabetMapping()
        {
            InitializeComponent();
        }

        private void FrmAlphabetMapping_Load(object sender, EventArgs e)
        {
            // STRICT CHECK: Step 5 must be done
            if (!GlobalSession.Step5_Done)
            {
                MessageBox.Show("Sequence Error: Step 5 (First Shift) is not finished.", "Access Denied");
                this.Close();
                return;
            }

            txtInput.Text = GlobalSession.FirstShiftOutput;

            // Initialize ListBox columns if needed, or just clear
            lstLog.Items.Clear();
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text)) return;

            GlobalSession.ResetEncryptionMetrics(); // <--- RESET BUCKETS
            MetricProbe probe = new MetricProbe(true); // <--- START MEASURING

            Stopwatch sw = Stopwatch.StartNew();

            string input = txtInput.Text.ToUpper();
            StringBuilder sb = new StringBuilder();
            lstLog.Items.Clear();

            // ITERATE through shifted English text
            foreach (char c in input)
            {
                if (EnochianDictionary.EnglishToEnochian.ContainsKey(c))
                {
                    var result = EnochianDictionary.EnglishToEnochian[c];

                    // FORMAT: "NAME" + "MARKER" + " " (Space for readability)
                    // Example: "VEH! "
                    sb.Append(result.Name + result.Marker + " ");

                    // Log collisions for thesis verification
                    if (result.Marker == "@")
                    {
                        lstLog.Items.Add($"Collision (2nd Meaning): '{c}' -> {result.Name} (@)");
                    }
                    else if (result.Marker == "#")
                    {
                        lstLog.Items.Add($"Collision (3rd Meaning): '{c}' -> {result.Name} (#)");
                    }
                }
                else
                {
                    // If a character is not in dictionary (e.g. punctuation that slipped through), keep it.
                    sb.Append(c + " ");
                }
            }


            // Display Output
            txtOutput.Text = sb.ToString().Trim();

            sw.Stop();
            probe.StopAndAccumulate(); // <--- ADD TO TOTAL
            // Log Time
            GlobalSession.LogEncTime("Step 6: Alphabet Mapping", sw.Elapsed.TotalMilliseconds);

            btnConfirm.Enabled = true;
            MessageBox.Show($"Mapping Complete.\n\nExample Translation:\n'{input[0]}' -> '{sb.ToString().Split(' ')[0]}'", "Success");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            GlobalSession.EnochianMappedOutput = txtOutput.Text;
            GlobalSession.Step6_Done = true;
            this.Close();
        }
    }
}
