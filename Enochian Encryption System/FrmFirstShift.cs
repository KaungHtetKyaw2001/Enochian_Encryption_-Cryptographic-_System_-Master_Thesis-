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
    public partial class FrmFirstShift : Form
    {
        public FrmFirstShift()
        {
            InitializeComponent();
        }

        private void FrmFirstShift_Load(object sender, EventArgs e)
        {
            // STRICT CHECK: Is Step 4 Done?
            if (!GlobalSession.Step4_Done)
            {
                MessageBox.Show("Sequence Error: Step 4 (Cleaning) is not finished.",
                                "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Load Data
            txtInput.Text = GlobalSession.CleanedText;
            txtC1.Text = GlobalSession.C1.ToString();
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text)) return;

            // 1. START TIMER
            Stopwatch sw = Stopwatch.StartNew();

            string input = txtInput.Text;
            int shift = GlobalSession.C1;
            StringBuilder sb = new StringBuilder();

            // 2. APPLY SHIFT LOGIC (Caesar Cipher)
            foreach (char c in input)
            {
                // Logic: 
                // 1. Convert char to 0-25 index (c - 'A')
                // 2. Add Shift (C1)
                // 3. Modulo 26 to wrap around Z -> A
                // 4. Convert back to char (+ 'A')

                char offset = char.IsUpper(c) ? 'A' : 'a'; // Should be upper from Step 4, but safety first
                char shiftedChar = (char)(offset + ((c - offset + shift) % 26));

                sb.Append(shiftedChar);
            }

            // Display Result
            txtOutput.Text = sb.ToString();

            // 3. STOP TIMER
            sw.Stop();

            // Log Time
            GlobalSession.LogEncTime("Step 5: First Shift", sw.Elapsed.TotalMilliseconds);

            btnConfirm.Enabled = true;
            MessageBox.Show($"Shift Applied (C1={shift}).\nTime: {sw.Elapsed.TotalMilliseconds:F4} ms");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            GlobalSession.FirstShiftOutput = txtOutput.Text;
            GlobalSession.Step5_Done = true;
            this.Close();
        }
    }
}
