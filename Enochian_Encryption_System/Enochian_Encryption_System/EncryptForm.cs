using EnochianEncryptor; // Ensure this namespace matches your project structure
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Enochian_Encryption_System
{
    public partial class EncryptForm : Form
    {
        public EncryptForm()
        {
            InitializeComponent();
        }

        private void btnGenKeys_Click(object sender, EventArgs e)
        {
            // Open the Configuration Form
            FrmReceiverConfig configForm = new FrmReceiverConfig();
            configForm.ShowDialog();

            // After the form closes, check if we have a key and display it
            if (GlobalSession.ReceiverPublicKey != null)
            {
                txtPublicKey.Text = "[" + string.Join(", ", GlobalSession.ReceiverPublicKey) + "]";
                txtPublicKey.ReadOnly = true;

                // *** FIX 1: MARK THE STATE AS LOADED ***
                GlobalSession.ReceiverKeyLoaded = true;
            }
            RefreshUI();
        }

        private void btnSessionSetup_Click(object sender, EventArgs e)
        {
            FrmSessionSetup Step1 = new FrmSessionSetup();
            Step1.ShowDialog();
            RefreshUI();
        }

        private void btnKeyEncapsulation_Click(object sender, EventArgs e)
        {
            FrmKeyEncapsulation Step2 = new FrmKeyEncapsulation();
            Step2.ShowDialog();
            RefreshUI();
        }

        private void btnTextPrep_Click(object sender, EventArgs e)
        {
            FrmPlaintextPrep Step3 = new FrmPlaintextPrep();
            Step3.ShowDialog();
            RefreshUI();
        }

        private void btnTextClean_Click(object sender, EventArgs e)
        {
            FrmPlaintextCleaning Step4 = new FrmPlaintextCleaning();
            Step4.ShowDialog();
            RefreshUI();
        }

        private void btnFirstShift_Click(object sender, EventArgs e)
        {
            FrmFirstShift step5 = new FrmFirstShift();
            step5.ShowDialog();
            RefreshUI();
        }

        private void btnMapping_Click(object sender, EventArgs e)
        {
            FrmAlphabetMapping step6 = new FrmAlphabetMapping();
            step6.ShowDialog();
            RefreshUI();
        }

        private void btnSecondShift_Click(object sender, EventArgs e)
        {
            FrmSecondShift step7 = new FrmSecondShift();
            step7.ShowDialog();
            RefreshUI();
        }

        private void btnMatrixAllocation_Click(object sender, EventArgs e)
        {
            FrmMatrixAllocation step8 = new FrmMatrixAllocation();
            step8.ShowDialog();
            RefreshUI();
        }

        private void btnKeyFactorGeneration_Click(object sender, EventArgs e)
        {
            FrmKeyFactorGen step9 = new FrmKeyFactorGen();
            step9.ShowDialog();
            RefreshUI();
        }

        private void btnKeyValidation_Click(object sender, EventArgs e)
        {
            FrmKeyValidation step10 = new FrmKeyValidation();
            step10.ShowDialog();
            RefreshUI();
        }

        private void btnCoreEncryption_Click(object sender, EventArgs e)
        {
            FrmCoreEncryption step11 = new FrmCoreEncryption();
            step11.ShowDialog();
            RefreshUI();
        }

        private void btnCardTagging_Click(object sender, EventArgs e)
        {
            FrmCardTagging step12 = new FrmCardTagging();
            step12.ShowDialog();
            RefreshUI();
        }

        private void btnDeckCreation_Click(object sender, EventArgs e)
        {
            FrmDeckCreation step13 = new FrmDeckCreation();
            step13.ShowDialog();
            RefreshUI();
        }

        private void btnPackaging_Click(object sender, EventArgs e)
        {
            FrmPackaging step14 = new FrmPackaging();
            step14.ShowDialog();
            RefreshUI(); // Refresh immediately so button turns green
        }

        private void btnGenDigitalSign_Click(object sender, EventArgs e)
        {
            FrmDigitalSignature step15 = new FrmDigitalSignature();
            step15.ShowDialog();
            RefreshUI();
        }

        private void btnTransmission_Click(object sender, EventArgs e)
        {
            FrmTransmission step16 = new FrmTransmission();
            step16.ShowDialog();
            RefreshUI();

            if (GlobalSession.Step16_Done)
            {
                MessageBox.Show("CONGRATULATIONS!\nThe Encryption Process is Fully Complete.", "Encryption Milestone");
            }
        }

        private void btnEncSteps_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "ENOCHIAN ENCRYPTION PROCEDURES:\n\n" +
                "1. Session Setup: Generate keys using Lorentz Chaos Attractors (X, Y, Z).\n" +
                "2. Key Encapsulation: Encrypt Session Header using Receiver's Public Key.\n" +
                "3. Text Processing: Clean plaintext & Map to Enochian Charset.\n" +
                "4. Core Encryption: Apply Non-Linear S-Box Substitution + Hill Cipher.\n" +
                "5. Integrity Tagging: Generate Salted Rolling Hashes for every matrix.\n" +
                "6. Deck Shuffling: Randomize Matrix Deck order using Lorentz Seed.\n" +
                "7. Packaging: Serialize Header, Deck, and Tags into XML structure.\n" +
                "8. Digital Signature: Sign the Package Hash using Sender's Private Key.\n" +
                "9. Transmission: Export final secure '.enc' file.",
                "System Architecture",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnFacts_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "FACTS SENDER MUST KNOW:\n\n" +
                "- DO: Ensure Receiver Configuration is completed first.\n" +
                "- DO: Use .txt or .docx files for input.\n" +
                "- DON'T: Modify the output .XML or .ENC files manually (Integrity Check will fail).\n" +
                "- NOTE: Numbers in text will be auto-converted to words (e.g., '1' -> 'ONE').",
                "Sender Guidelines",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        private void EncryptForm_Load(object sender, EventArgs e)
        {
            RefreshUI();
        }

        public void RefreshUI()
        {
            // Local helper to handle button states consistently
            void SetState(Button btn, bool isEnabled, bool isDone)
            {
                if (isDone)
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.LightGreen;
                    if (!btn.Text.Contains("(Done)"))
                    {
                        btn.Text = btn.Text + " (Done)";
                    }
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

            // *** FIX 2: Use SetState for GenKeys logic. 
            // Since we now set ReceiverKeyLoaded=true in the click event, this will correctly disable the button.
            SetState(btnGenKeys, true, GlobalSession.ReceiverKeyLoaded);

            SetState(btnSessionSetup, true, GlobalSession.Step1_Done);
            SetState(btnKeyEncapsulation, GlobalSession.Step1_Done, GlobalSession.Step2_Done);
            SetState(btnTextPrep, GlobalSession.Step2_Done, GlobalSession.Step3_Done);
            SetState(btnTextClean, GlobalSession.Step3_Done, GlobalSession.Step4_Done);
            SetState(btnFirstShift, GlobalSession.Step4_Done, GlobalSession.Step5_Done);
            SetState(btnMapping, GlobalSession.Step5_Done, GlobalSession.Step6_Done);
            SetState(btnSecondShift, GlobalSession.Step6_Done, GlobalSession.Step7_Done);
            SetState(btnMatrixAllocation, GlobalSession.Step7_Done, GlobalSession.Step8_Done);
            SetState(btnKeyFactorGeneration, GlobalSession.Step8_Done, GlobalSession.Step9_Done);
            SetState(btnKeyValidation, GlobalSession.Step9_Done, GlobalSession.Step10_Done);
            SetState(btnCoreEncryption, GlobalSession.Step10_Done, GlobalSession.Step11_Done);
            SetState(btnCardTagging, GlobalSession.Step11_Done, GlobalSession.Step12_Done);
            SetState(btnDeckCreation, GlobalSession.Step12_Done, GlobalSession.Step13_Done);
            SetState(btnPackaging, GlobalSession.Step13_Done, GlobalSession.Step14_Done);
            SetState(btnGenDigitalSign, GlobalSession.Step14_Done, GlobalSession.Step15_Done);
            SetState(btnTransmission, GlobalSession.Step15_Done, GlobalSession.Step16_Done);
        }

        private void btnViewStats_Click(object sender, EventArgs e)
        {
            string reports = " === ENCRYPTION PERFORMANCE ===\n\n";

            foreach (var entry in GlobalSession.EncryptionTimes)
            {
                reports += $"{entry.Key}: {entry.Value:F4} ms\n";
            }
            reports += "\n-----------------------------\n";
            reports += $"TOTAL TIME: {GlobalSession.GetTotalEncryptionTime():F4} ms";

            MessageBox.Show(reports, "Performance Benchmarks");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}