using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Enochian_Encryption_System
{
    public partial class DecryptForm : Form
    {
        public DecryptForm()
        {
            InitializeComponent();
        }

        private void DecryptForm_Load(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void btnPackageDelivery_Click(object sender, EventArgs e)
        {
            FrmPkgDelivery step1 = new FrmPkgDelivery();
            step1.ShowDialog();
            RefreshUI();
        }

        private void btnSignatureVerification_Click(object sender, EventArgs e)
        {
            FrmSigVerification step2 = new FrmSigVerification();
            step2.ShowDialog();
            RefreshUI();
        }

        private void btnDecapsulation_Click(object sender, EventArgs e)
        {
            FrmDecapsulation step3 = new FrmDecapsulation();
            step3.ShowDialog();
            RefreshUI();
        }

        private void btnSortingandSearching_Click(object sender, EventArgs e)
        {
            FrmSortingSearching step4 = new FrmSortingSearching();
            step4.ShowDialog();
            RefreshUI();
        }

        private void btnRegeneration_Click(object sender, EventArgs e)
        {
            FrmRegeneration step5 = new FrmRegeneration();
            step5.ShowDialog();
            RefreshUI();
        }

        private void btnCoreDecryption_Click(object sender, EventArgs e)
        {
            FrmCoreDecryption step6 = new FrmCoreDecryption();
            step6.ShowDialog();
            RefreshUI();
        }

        private void btnReverseShifts_Click(object sender, EventArgs e)
        {
            FrmReversedShifts step7 = new FrmReversedShifts();
            step7.ShowDialog();
            RefreshUI();
        }

        private void btnFinalization_Click(object sender, EventArgs e)
        {
            FrmFinalization step8 = new FrmFinalization();
            step8.ShowDialog();
            RefreshUI();
            if (GlobalSession.DecStep8_Done) // Assuming you reuse flags or make new ones for Decryption
            {
                MessageBox.Show("Decryption Complete! Original Message Restored.");
                MessageBox.Show("CONGRATULATIONS!\nThe Decryption Process is Fully Complete.", "Decryption Milestone");
            }
        }

        private void btnViewStats_Click(object sender, EventArgs e)
        {
            string reports = " === DECRYPTION PERFORMANCE ===\n\n";

            foreach (var entry in GlobalSession.DecryptionTimes)
            {
                reports += $"{entry.Key}: {entry.Value:F4} ms\n";
            }
            reports += "\n-----------------------------\n";
            reports += $"TOTAL TIME: {GlobalSession.GetTotalDecryptionTime():F4} ms";

            MessageBox.Show(reports, "Performance Benchmarks");
        }


        // We need to define new Boolean flags for Decryption in GlobalSession later.
        // For now, I will use placeholders like 'GlobalSession.DecStep1_Done' 
        // You will need to add these to GlobalSession.cs region 6.

        private void RefreshUI()
        {
            // Helper to manage button states
            void SetState(Button btn, bool isEnabled, bool isDone)
            {
                if (isDone)
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.LightGreen;
                    if (!btn.Text.Contains("(Done)"))
                        btn.Text = btn.Text + " (Done)";
                }
                else if (isEnabled)
                {
                    btn.Enabled = true;
                    btn.BackColor = Color.LightBlue;
                }
                else
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.LightGray;
                }
            }

            // *** FIX: Button names updated to match your new naming convention ***
            // Ensure these match the actual (Name) property of your buttons in the designer 
            SetState(btnPackageDelivery, true, GlobalSession.DecStep1_Done);
            SetState(btnSignatureVerification, GlobalSession.DecStep1_Done, GlobalSession.DecStep2_Done);
            SetState(btnDecapsulation, GlobalSession.DecStep2_Done, GlobalSession.DecStep3_Done);
            SetState(btnSortingandSearching, GlobalSession.DecStep3_Done, GlobalSession.DecStep4_Done);
            SetState(btnRegeneration, GlobalSession.DecStep4_Done, GlobalSession.DecStep5_Done);
            SetState(btnCoreDecryption, GlobalSession.DecStep5_Done, GlobalSession.DecStep6_Done);
            SetState(btnReverseShifts, GlobalSession.DecStep6_Done, GlobalSession.DecStep7_Done);
            SetState(btnFinalization, GlobalSession.DecStep7_Done, GlobalSession.DecStep8_Done);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
