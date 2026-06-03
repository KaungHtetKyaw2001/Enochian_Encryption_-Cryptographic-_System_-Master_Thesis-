using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Enochian_Encryption_System
{
    public partial class FrmKyber : Form
    {
        public FrmKyber()
        {
            InitializeComponent();
        }

        private void btnRunKyber_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] fileBytesToTest;

                // 1. DYNAMIC FILE UPLOAD (Prevents UI freezing on massive datasets)
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Select Dataset for ML-KEM Benchmark";
                    openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                    // If the user clicks "Cancel" on the file picker, stop the process
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    // Read the selected file directly into memory
                    fileBytesToTest = File.ReadAllBytes(openFileDialog.FileName);
                }

                // 2. INITIALIZE LOGGING
                txtProcessLog.Clear();
                txtProcessLog.AppendText(">> INITIALIZING NIST FIPS-203 ML-KEM BENCHMARK...\r\n");
                txtProcessLog.AppendText($">> [Target Payload Loaded]: {fileBytesToTest.Length} bytes.\r\n");

                // 3. GENERATE KEYS
                KyberBenchmarker kyber = new KyberBenchmarker();
                txtProcessLog.AppendText(">> [KEM]: Generating ML-KEM-768 Public/Private Key Pair...\r\n");
                kyber.GenerateKeys();

                // 4. ENCRYPT
                txtProcessLog.AppendText(">> [KEM]: Encapsulating 256-bit AES Shared Secret...\r\n");
                txtProcessLog.AppendText(">> [AES]: Encrypting payload with ML-KEM-derived Secret...\r\n");

                byte[] encryptedData;
                double encTime = kyber.BenchmarkEncryption(fileBytesToTest, out encryptedData);
                txtProcessLog.AppendText($">> ENCRYPTION COMPLETE. Latency: {encTime} ms.\r\n\r\n");

                // 5. DECRYPT
                txtProcessLog.AppendText(">> [KEM]: Decapsulating Secret using ML-KEM Private Key...\r\n");
                txtProcessLog.AppendText(">> [AES]: Decrypting payload with restored Secret...\r\n");

                double decTime = kyber.BenchmarkDecryption(encryptedData);
                txtProcessLog.AppendText($">> DECRYPTION COMPLETE. Latency: {decTime} ms.\r\n");

                // 6. Update the UI Labels
                lblKyberEncTime.Text = $"Kyber Enc: {encTime} ms";
                lblKyberDecTime.Text = $"Kyber Dec: {decTime} ms";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error running benchmark: " + ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
