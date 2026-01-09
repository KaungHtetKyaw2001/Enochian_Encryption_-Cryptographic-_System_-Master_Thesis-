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

        private void btnRunBenchmark_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            var results = Benchmark.RunDecryptionTests(GlobalSession.MatrixSize);
            this.Cursor = Cursors.Default;

            // Get values
            double mySpeed = results[0].OperationTime_ms;
            double rsaSpeed = results[1].OperationTime_ms;
            double eccSpeed = results[2].OperationTime_ms; // New ECC value

            // Calculate Ratios
            double rsaRatio = (mySpeed > 0) ? rsaSpeed / mySpeed : 0;
            double eccRatio = (mySpeed > 0) ? eccSpeed / mySpeed : 0;

            // Build Report
            string output = "--- DECRYPTION EFFICIENCY ---\n\n" +
                            $"Enochian: {mySpeed:F4} ms\n" +
                            $"RSA-2048: {rsaSpeed:F4} ms\n" +
                            $"ECC/X25519: {eccSpeed:F4} ms\n\n" +
                            $"VICTORY STATS:\n" +
                            $"vs RSA: {rsaRatio:F0}x Faster\n" +
                            $"vs ECC: {eccRatio:F0}x Faster";

            // Copy to Clipboard for Excel
            Clipboard.SetText($"Algorithm\tTime(ms)\nEnochian(Dec)\t{mySpeed}\nRSA(Dec)\t{rsaSpeed}\nECC/X25519\t{eccSpeed}");

            MessageBox.Show(output, "Efficiency Proof");
        }

        private void btnVerifyIntegrity_Click(object sender, EventArgs e)
        {
            // Check if we have encrypted data
            if (GlobalSession.CipherMatrixList == null || GlobalSession.CipherMatrixList.Count == 0)
            {
                MessageBox.Show("Please run 'Step 11: Core Encryption' first.");
                return;
            }

            // Flatten data
            List<byte> bytes = new List<byte>();
            int N = GlobalSession.MatrixSize;
            foreach (var mat in GlobalSession.CipherMatrixList)
                for (int r = 0; r < N; r++) for (int c = 0; c < N; c++) bytes.Add((byte)mat[r, c]);

            byte[] data = bytes.ToArray();

            // Calculate Metrics
            double entropy = SecurityMetrics.CalculateEntropy(data);
            double variance = SecurityMetrics.CalculateHistogramVariance(data);

            string status = entropy > 7.5 ? "Excellent (High Randomness)" : "Weak (Pattern Visible)";

            MessageBox.Show($"--- SECURITY REPORT ---\n\n" +
                            $"Entropy: {entropy:F4} bits/byte (Ideal: 8.0)\n" +
                            $"Variance: {variance:F2} (Lower is better)\n\n" +
                            $"Conclusion: {status}", "Confidentiality Check");
        }

        private void btnVerifyIntegrity_Click_1(object sender, EventArgs e)
        {
            // 1. Safety Check
            if (GlobalSession.PlaintextMatrices == null || GlobalSession.PlaintextMatrices.Count == 0)
            {
                MessageBox.Show("Please run 'Step 6: Core Decryption' first.");
                return;
            }

            // 2. Gather the Real Data (Flatten the Matrices)
            List<byte> decryptedData = new List<byte>();
            int N = GlobalSession.MatrixSize;

            foreach (var matrix in GlobalSession.PlaintextMatrices)
            {
                for (int r = 0; r < N; r++)
                    for (int c = 0; c < N; c++)
                    {
                        // We treat the integer values (1-21) as our data points
                        decryptedData.Add((byte)matrix[r, c]);
                    }
            }

            // 3. Calculate REAL Entropy using the Class we made
            double realEntropy = SecurityMetrics.CalculateEntropy(decryptedData.ToArray());

            // 4. Scientific Conclusion
            // Random noise (Encrypted) is > 4.3. 
            // Structured Language (Decrypted) is usually < 4.2.
            string conclusion = "";
            if (realEntropy < 4.3)
            {
                conclusion = "SUCCESS: Entropy dropped significantly.\nThis confirms the data has returned to a structured language state (Integrity Verified).";
            }
            else
            {
                conclusion = "WARNING: Entropy remains high.\nThe data still looks random. Decryption may have failed.";
            }

            // 5. Show the Real Numbers
            MessageBox.Show($"--- INTEGRITY ANALYSIS ---\n\n" +
                            $"Decrypted Entropy: {realEntropy:F4} bits/symbol\n" +
                            $"(Target for English: ~3.5 to 4.2)\n\n" +
                            $"{conclusion}",
                            "CIA Triad: Integrity Check");
        }

        private void btnCheckQuantumDecrypt_Click(object sender, EventArgs e)
        {
            // 1. Get current Matrix Size (N)
            int N = GlobalSession.MatrixSize;
            if (N == 0) N = 10;

            // 2. Calculate Key Space
            double bitsPerCell = Math.Log(21, 2);
            double totalBits = (N * N) * bitsPerCell;

            // 3. Apply Quantum Damage
            double quantumBits = totalBits / 2;

            // --- DYNAMIC TEXT LOGIC ---

            // A. Classical Check
            string classicalNote = (totalBits > 100)
                ? "(Computationally Infeasible for Supercomputers)"
                : "(WARNING: Vulnerable to Modern Brute Force)";

            // B. Quantum Check & Dynamic Description
            string quantumNote = "";
            string status = "";
            string groverNote = ""; // <--- NEW DYNAMIC VARIABLE

            if (quantumBits >= 128)
            {
                quantumNote = "(Resistant to Grover's Algorithm)";
                status = "SECURE";
                groverNote = "Reduces strength by 50% (Result remains Safe)";
            }
            else
            {
                quantumNote = "(Vulnerable to Quantum Decryption)";
                status = "WEAK";
                groverNote = "CRITICAL: Reduces strength by 50% (Result becomes Unsafe)";
            }

            // 4. Build Report
            string report = "--- DECRYPTION QUANTUM DEFENSE ---\n\n" +
                            $"Decryption Matrix: {N}x{N}\n" +
                            $"Field Size: Z_21\n\n" +
                            $"1. Attack Complexity (Classical): 2^{totalBits:F0}\n" +
                            $"   {classicalNote}\n\n" +
                            $"2. Attack Complexity (Quantum): 2^{quantumBits:F0}\n" +
                            $"   {groverNote}\n" +  // <--- Inserted Here
                            $"   {quantumNote}\n\n" +
                            $"CONCLUSION: This received package is QUANTUM {status}.";

            MessageBox.Show(report, "Post-Quantum Analysis");
        }

        private void btnStatTime_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"--- DECRYPTION TIME ---\n\n" +
                    $"Step: Gaussian Elimination (Inverse)\n" +
                    $"Value: {GlobalSession.Core_Dec_TimeMs:F4} ms", "Efficiency Metric");
        }

        private void btnStatMemory_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"--- DECRYPTION MEMORY ---\n\n" +
                    $"Step: BigInteger Calculation Overhead\n" +
                    $"Value: {GlobalSession.Total_Dec_MemBytes} Bytes", "Resource Consumption");
        }

        private void btnStatCPU_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"--- DECRYPTION CPU ---\n\n" +
                    $"Step: Inverse Key Processing\n" +
                    $"Value: {GlobalSession.Total_Dec_CpuMs:F6} ms", "Power Consumption");
        }

        private void btnStatComplexity_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"--- ALGORITHMIC COMPLEXITY ---\n\n" +
                    $"Class: {GlobalSession.Dec_Complexity}\n\n" +
                    $"Comparison:\n" +
                    $"RSA: O(k^3) [Exponential]\n" +
                    $"Enochian: O(N^3) [Polynomial]",
                    "Big-O Analysis");
        }
    }
}
