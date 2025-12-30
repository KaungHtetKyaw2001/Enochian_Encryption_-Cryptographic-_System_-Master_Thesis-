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
    public partial class FrmSecondShift : Form
    {
        public FrmSecondShift()
        {
            InitializeComponent();
        }

        private void FrmSecondShift_Load(object sender, EventArgs e)
        {
            // STRICT CHECK: Is Step 6 Done?
            if (!GlobalSession.Step6_Done)
            {
                MessageBox.Show("Sequence Error: Step 6 (Alphabet Mapping) is not finished.", "Access Denied");
                this.Close();
                return;
            }

            txtInput.Text = GlobalSession.EnochianMappedOutput;
            txtC2.Text = GlobalSession.C2.ToString();
        }

        private void btnApplyShift_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text)) return;

            Stopwatch sw = Stopwatch.StartNew();

            // 1. Split the mapped output into individual units (e.g., "VEH!", "PA!")
            string[] units = txtInput.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            int shiftValue = GlobalSession.C2;

            foreach (string unit in units)
            {
                // Separate the Name (VEH) from the Marker (!)
                string marker = unit.Substring(unit.Length - 1);
                string name = unit.Substring(0, unit.Length - 1);

                // 2. Find the numerical value of the Enochian name from our Dictionary
                var mapping = EnochianDictionary.EnglishToEnochian.Values
                    .FirstOrDefault(m => m.Name == name);

                if (mapping.Name != null)
                {
                    // 3. APPLY MODULO 21 SHIFT
                    // Enochian values are 1-21. 
                    // Formula: ((CurrentValue - 1 + Shift) % 21) + 1
                    int newValue = ((mapping.Value - 1 + shiftValue) % 21) + 1;

                    // 4. Find the name associated with the NEW value
                    var newMapping = EnochianDictionary.EnglishToEnochian.Values
                        .FirstOrDefault(m => m.Value == newValue);

                    sb.Append(newMapping.Name + marker + " ");
                }
                else
                {
                    sb.Append(unit + " "); // Fallback for unknown items
                }
            }


            txtOutput.Text = sb.ToString().Trim();

            sw.Stop();
            // Log Time
            GlobalSession.LogEncTime("Step 7: Second Shift", sw.Elapsed.TotalMilliseconds);

            btnConfirm.Enabled = true;
            MessageBox.Show($"Second Shift Applied (Mod 21).\nTime: {sw.Elapsed.TotalMilliseconds:F4} ms");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            GlobalSession.SecondShiftOutput = txtOutput.Text;
            GlobalSession.Step7_Done = true;
            this.Close();
        }
    }
}
