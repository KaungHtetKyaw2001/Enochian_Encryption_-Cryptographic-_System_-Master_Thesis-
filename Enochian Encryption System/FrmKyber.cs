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

                // 1. DYNAMIC FILE UPLOAD 
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "Select Dataset for ML-KEM Benchmark";
                    openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    fileBytesToTest = File.ReadAllBytes(openFileDialog.FileName);
                }

                // --- AUTOMATIC FILE SIZE CALCULATION ---
                // We get the raw bytes, then divide by 1024 to get the exact Kilobytes
                double fileSizeKB = fileBytesToTest.Length / 1024.0;

                // 2. INITIALIZE LOGGING
                txtProcessLog.Clear();
                txtProcessLog.AppendText(">> INITIALIZING NIST FIPS-203 ML-KEM BENCHMARK...\r\n");
                txtProcessLog.AppendText($">> [Target Payload Loaded]: {fileBytesToTest.Length} bytes ({fileSizeKB:F2} KB).\r\n\r\n");

                // 3. GENERATE KEYS
                KyberBenchmarker kyber = new KyberBenchmarker();
                txtProcessLog.AppendText(">> [KEM]: Generating ML-KEM-768 Public/Private Key Pair...\r\n");
                kyber.GenerateKeys();

                // 4. ENCRYPT
                txtProcessLog.AppendText(">> [KEM]: Encapsulating 256-bit AES Shared Secret...\r\n");
                txtProcessLog.AppendText(">> [AES]: Encrypting payload with ML-KEM-derived Secret...\r\n");

                byte[] encryptedData;
                double encTime = kyber.BenchmarkEncryption(fileBytesToTest, out encryptedData);

                // --- CALCULATE ENCRYPTION THROUGHPUT ---
                double encSeconds = encTime / 1000.0;
                double encSpeedKB = (encSeconds > 0) ? (fileSizeKB / encSeconds) : 0;
                double encSpeedMB = encSpeedKB / 1024.0;

                txtProcessLog.AppendText($">> ENCRYPTION COMPLETE.\r\n");
                txtProcessLog.AppendText($"   - Latency: {encTime:F4} ms\r\n");
                txtProcessLog.AppendText($"   - Speed:   {encSpeedKB:F2} KB/s ({encSpeedMB:F2} MB/s)\r\n\r\n");

                // 5. DECRYPT
                txtProcessLog.AppendText(">> [KEM]: Decapsulating Secret using ML-KEM Private Key...\r\n");
                txtProcessLog.AppendText(">> [AES]: Decrypting payload with restored Secret...\r\n");

                double decTime = kyber.BenchmarkDecryption(encryptedData);

                // --- CALCULATE DECRYPTION THROUGHPUT ---
                double decSeconds = decTime / 1000.0;
                double decSpeedKB = (decSeconds > 0) ? (fileSizeKB / decSeconds) : 0;
                double decSpeedMB = decSpeedKB / 1024.0;

                txtProcessLog.AppendText($">> DECRYPTION COMPLETE.\r\n");
                txtProcessLog.AppendText($"   - Latency: {decTime:F4} ms\r\n");
                txtProcessLog.AppendText($"   - Speed:   {decSpeedKB:F2} KB/s ({decSpeedMB:F2} MB/s)\r\n\r\n");

                // 6. Update the UI Labels
                lblKyberEncTime.Text = $"Kyber Enc: {encTime:F4} ms | {encSpeedKB:F2} KB/s";
                lblKyberDecTime.Text = $"Kyber Dec: {decTime:F4} ms | {decSpeedKB:F2} KB/s";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error running benchmark: " + ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
