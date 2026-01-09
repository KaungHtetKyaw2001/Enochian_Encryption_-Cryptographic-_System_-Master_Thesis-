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
    public partial class FrmSessionSetup : Form
    {
        public FrmSessionSetup()
        {
            InitializeComponent();
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            GlobalSession.ResetEncryptionMetrics(); // <--- RESET BUCKETS
            MetricProbe probe = new MetricProbe(true); // <--- START MEASURING

            Stopwatch sw = Stopwatch.StartNew();
            Random rng = new Random();

            // 1. Generate Inputs
            txtC1.Text = rng.Next(1, 21).ToString();
            txtC2.Text = rng.Next(1, 21).ToString();
            txtLx.Text = (rng.NextDouble() * 10).ToString("F2");
            txtLy.Text = (rng.NextDouble() * 10).ToString("F2");
            txtLz.Text = (rng.NextDouble() * 10).ToString("F2");

            // 2. Generate Vector (Ensure at least one '1')
            int[] vector;
            bool isValid = false;

            while (!isValid)
            {
                vector = new int[3];
                int sum = 0;
                for (int i = 0; i < 3; i++)
                {
                    vector[i] = rng.Next(0, 2); // 0 or 1
                    sum += vector[i];
                }

                // Only accept if sum > 0 (meaning at least one 1 exists)
                if (sum > 0)
                {
                    lblVector.Text = "[" + string.Join(", ", vector) + "]";
                    isValid = true;
                }
            }
            // 2. STOP TIMER
            sw.Stop();
            probe.StopAndAccumulate(); // <--- ADD TO TOTAL
            // 3. LOG TIME TO GLOBAL SESSION
            // Use TotalMilliseconds for high precision
            GlobalSession.LogEncTime("Step 1: Session Setup", sw.Elapsed.TotalMilliseconds);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate Inputs
                if (string.IsNullOrWhiteSpace(txtLx.Text) || string.IsNullOrWhiteSpace(txtC1.Text))
                {
                    MessageBox.Show("All fields are required.", "Error");
                    return;
                }

                // SAVE TO GLOBAL STATE
                GlobalSession.Lx = double.Parse(txtLx.Text);
                GlobalSession.Ly = double.Parse(txtLy.Text);
                GlobalSession.Lz = double.Parse(txtLz.Text);
                GlobalSession.C1 = int.Parse(txtC1.Text);
                GlobalSession.C2 = int.Parse(txtC2.Text);

                // Parse Vector string back to array (Simplified logic)
                string vRaw = lblVector.Text.Trim('[', ']');
                string[] parts = vRaw.Split(',');
                GlobalSession.SessionVector = new int[] {
                    int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2])
                };

                //if (GlobalSession.FinalPayload != null)
                //{
                //    GlobalSession.FinalPayload.SenderPublicVector = GlobalSession.SessionVector;
                //}

                GlobalSession.Step1_Done = true;
                MessageBox.Show("Step 1 Complete: Session Parameters Saved.", "Success");
                this.Close(); // Close this form to return to Main Dashboard
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Input: " + ex.Message);
                throw;
            }
        }
    }
}
