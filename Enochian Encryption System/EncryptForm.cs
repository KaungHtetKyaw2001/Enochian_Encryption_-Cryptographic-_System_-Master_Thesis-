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

        private void btnRunBenchmark_Click(object sender, EventArgs e)
        {
            // 1. Safety Check
            if (GlobalSession.KeyMatrix == null)
            {
                MessageBox.Show("Please generate keys in Step 9 first.");
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            // 2. Run Encryption Tests (Using the Encryption benchmark)
            var results = Benchmark.RunEncryptionTests(GlobalSession.MatrixSize);

            this.Cursor = Cursors.Default;

            // 3. Get values (Order: 0=Enochian, 1=RSA, 2=ECC)
            double mySpeed = results[0].OperationTime_ms;
            double rsaSpeed = results[1].OperationTime_ms;
            double eccSpeed = results[2].OperationTime_ms;

            // 4. Calculate Ratios (How many times faster?)
            double rsaRatio = (mySpeed > 0) ? rsaSpeed / mySpeed : 0;
            double eccRatio = (mySpeed > 0) ? eccSpeed / mySpeed : 0;

            // 5. Build Report
            string output = "--- ENCRYPTION EFFICIENCY ---\n\n" +
                            $"Enochian: {mySpeed:F4} ms\n" +
                            $"RSA-2048: {rsaSpeed:F4} ms\n" +
                            $"ECC/X25519: {eccSpeed:F4} ms\n\n" +
                            $"VICTORY STATS:\n" +
                            $"vs RSA: {rsaRatio:F0}x Faster\n" +
                            $"vs ECC: {eccRatio:F0}x Faster";

            // 6. Copy to Clipboard for Excel
            Clipboard.SetText($"Algorithm\tTime(ms)\nEnochian(Enc)\t{mySpeed}\nRSA(Enc)\t{rsaSpeed}\nECC/X25519\t{eccSpeed}");

            // 7. Show Result
            MessageBox.Show(output, "Efficiency Proof (Encryption)");
        }

        private void btnAnalyzeSecurity_Click(object sender, EventArgs e)
        {
            // [FIX] Use 'EncryptedMatrices' instead of 'CipherMatrixList'
            if (GlobalSession.EncryptedMatrices == null || GlobalSession.EncryptedMatrices.Count == 0)
            {
                MessageBox.Show("Please run 'Step 11: Core Encryption' first.\nWe need encrypted data to analyze.", "No Data");
                return;
            }

            // 2. Flatten the matrices into a single byte array for analysis
            List<byte> allEncryptedBytes = new List<byte>();
            int N = GlobalSession.MatrixSize;

            // [FIX] Iterating over the correct list
            foreach (var matrix in GlobalSession.EncryptedMatrices)
            {
                for (int r = 0; r < N; r++)
                    for (int c = 0; c < N; c++)
                        allEncryptedBytes.Add((byte)matrix[r, c]);
            }
            byte[] data = allEncryptedBytes.ToArray();

            // 3. Calculate Metrics 
            double entropy = SecurityMetrics.CalculateEntropy(data);
            double variance = SecurityMetrics.CalculateHistogramVariance(data);

            // [FIX] Adjusted Grading for Modulo 21 System
            // Theoretical Max Entropy for Mod 21 is log2(21) = ~4.39 bits
            double maxTheoreticalEntropy = Math.Log(21, 2);
            double efficiency = (entropy / maxTheoreticalEntropy) * 100;

            string quality = "";
            if (efficiency > 90.0) quality = "Excellent (Near-Perfect Randomness for Mod 21)";
            else if (efficiency > 70.0) quality = "Moderate";
            else quality = "Poor (Pattern Visible)";

            // 5. Show Report
            string report = $"--- Security Analysis (Z_21 Field) ---\n\n" +
                            $"Total Bytes Analyzed: {data.Length}\n" +
                            $"Shannon Entropy: {entropy:F4} bits/symbol\n" +
                            $"(Theoretical Max for Mod 21: {maxTheoreticalEntropy:F4})\n\n" +
                            $"Randomness Efficiency: {efficiency:F2}%\n" +
                            $"Histogram Variance: {variance:F2}\n\n" +
                            $"Conclusion: {quality}";

            MessageBox.Show(report, "CIA Triad Analysis");
        }

        private void btnCheckQuantum_Click(object sender, EventArgs e)
        {
            // 1. Get current Matrix Size (N)
            int N = GlobalSession.MatrixSize;
            if (N == 0) N = 10;

            // 2. Calculate Key Space in Bits
            double bitsPerCell = Math.Log(21, 2);
            double totalBits = (N * N) * bitsPerCell;

            // 3. Apply Quantum "Damage"
            double quantumBits = totalBits / 2;

            // --- DYNAMIC TEXT LOGIC ---

            // A. RSA Comparison
            string rsaComparison = (totalBits > 112)
                ? $"(Stronger than RSA-2048: {totalBits:F0} > 112)"
                : $"(Weaker than RSA-2048: {totalBits:F0} < 112)";

            // B. Quantum Status & Dynamic Description
            string standardCheck = "";
            string status = "";
            string groverDescription = ""; // <--- NEW DYNAMIC VARIABLE

            if (quantumBits >= 128)
            {
                standardCheck = "PASSED (Meets >128 Bit Requirement)";
                status = "SECURE";
                // Context: It drops 50%, but we don't care because we have enough.
                groverDescription = "Reduces strength by 50% (Result is still above Safety Threshold)";
            }
            else
            {
                standardCheck = "FAILED (Below >128 Bit Requirement)";
                status = "WEAK (Increase Matrix Size)";
                // Context: The 50% drop is what killed us.
                groverDescription = "CRITICAL: Reduces strength by 50% (Drops below Safety Threshold)";
            }

            // 4. Build Report
            string report = "--- POST-QUANTUM RESISTANCE PROOF ---\n\n" +
                            $"Matrix Size: {N}x{N}\n" +
                            $"Field Size: Z_21\n\n" +
                            $"1. Classical Key Strength: {totalBits:F0} Bits\n" +
                            $"   {rsaComparison}\n\n" +
                            $"2. Quantum Attack (Grover's Algo): {groverDescription}\n" + // <--- Inserted Here
                            $"   Remaining Strength: {quantumBits:F0} Bits\n\n" +
                            $"3. Standard Requirement: >128 Bits\n" +
                            $"   Result: {standardCheck}\n\n" +
                            $"CONCLUSION: System is QUANTUM {status}.";

            MessageBox.Show(report, "Quantum Analysis");
        }

        private void btnStatTime_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"--- ENCRYPTION TIME ---\n\n" +
                    $"Step: Hill Cipher Matrix Multiplication\n" +
                    $"Value: {GlobalSession.Core_Enc_TimeMs:F4} ms", "Efficiency Metric");
        }

        private void btnStatMemory_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"--- ENCRYPTION MEMORY ---\n\n" +
                    $"Step: Matrix Allocation\n" +
                    $"Value: {GlobalSession.Total_Enc_MemBytes} Bytes", "Resource Consumption");
        }

        private void btnStatCPU_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"--- ENCRYPTION CPU ---\n\n" +
                    $"Step: Integer Math Processing\n" +
                    $"Value: {GlobalSession.Total_Enc_CpuMs:F6} ms", "Power Consumption");
        }

        private void btnStatComplexity_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"--- ALGORITHMIC COMPLEXITY ---\n\n" +
                    $"Class: {GlobalSession.Enc_Complexity}\n\n" +
                    $"Comparison:\n" +
                    $"RSA: O(k^3) [Exponential]\n" +
                    $"Enochian: O(N^3) [Polynomial]",
                    "Big-O Analysis");
        }
    }
}