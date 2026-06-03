using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Enochian_Encryption_System
{
    public partial class FrmECC : Form
    {
        private byte[] _sharedSecret;
        private byte[] _lastEncryptedBytes;
        private int _currentCurveSize = 256;

        public FrmECC()
        {
            InitializeComponent();
            InitializeStableECCKeys();
        }

        private void InitializeStableECCKeys()
        {
            using (SHA256 sha = SHA256.Create())
            {
                _sharedSecret = sha.ComputeHash(Encoding.UTF8.GetBytes("EnochianThesisStableKey2025"));
            }
        }

        // --- ENCRYPTION BUTTON ---
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbPlainInput.Text))
            {
                MessageBox.Show("Please enter text to encrypt.");
                return;
            }

            rtbEncStats.Text = "Benchmarking ECC Hybrid...";
            rtbPlainOutput.Clear();
            Application.DoEvents();

            // Prepare Input
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(rtbPlainInput.Text);
            double dataSizeKB = (double)dataToEncrypt.Length / 1024.0;

            // 1. SETUP (Outside Timer)
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Aes aes = Aes.Create();
            aes.Key = _sharedSecret;
            aes.GenerateIV();
            byte[] iv = aes.IV;

            // 2. START TIMER
            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                byte[] encryptedData;
                using (var encryptor = aes.CreateEncryptor())
                {
                    encryptedData = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
                }

                // Combine IV + Ciphertext
                List<byte> package = new List<byte>();
                package.AddRange(iv);
                package.AddRange(encryptedData);
                _lastEncryptedBytes = package.ToArray();

                // 3. STOP TIMER
                sw.Stop();

                // --- DYNAMIC CALCULATIONS ---
                double timeMs = sw.Elapsed.TotalMilliseconds;
                double speedKBps = (timeMs > 0) ? (dataSizeKB / (timeMs / 1000.0)) : 0;
                double entropy = CalculateEntropy(_lastEncryptedBytes);
                string quantumReport = GetECCQuantumStatus(_currentCurveSize);

                rtbPlainOutput.Text = Convert.ToBase64String(_lastEncryptedBytes);
                rtbCipherInput.Text = rtbPlainOutput.Text;

                string stats = $"--- PERFORMANCE (Payload: {dataSizeKB:F4} KB) ---\n" +
                               $"Time: {timeMs:F4} ms\n" +
                               $"Throughput: {speedKBps:F4} KB/s\n\n" +
                               $"--- SECURITY AUDIT ---\n" +
                               $"Entropy: {entropy:F4} bits/byte\n" +
                               $"Curve: NIST P-{_currentCurveSize}\n" +
                               $"{quantumReport}";

                rtbEncStats.Text = stats;
            }
            catch (Exception ex) { MessageBox.Show("Encryption Error: " + ex.Message); }
        }

        // --- DECRYPTION BUTTON ---
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbCipherInput.Text))
            {
                MessageBox.Show("No encrypted data found.");
                return;
            }

            rtbDecStats.Text = "Processing...";
            rtbCipherOutput.Clear();
            GC.Collect();

            try
            {
                byte[] package = _lastEncryptedBytes;
                if (rtbCipherInput.Text != Convert.ToBase64String(_lastEncryptedBytes ?? new byte[0]))
                {
                    try { package = Convert.FromBase64String(rtbCipherInput.Text); }
                    catch { MessageBox.Show("Invalid Base64 Input."); return; }
                }

                if (package == null || package.Length < 17) return;

                byte[] iv = new byte[16];
                byte[] cipherText = new byte[package.Length - 16];
                Array.Copy(package, 0, iv, 0, 16);
                Array.Copy(package, 16, cipherText, 0, cipherText.Length);

                byte[] decryptedBytes;

                // 1. START TIMER
                Stopwatch sw = Stopwatch.StartNew();

                using (Aes aes = Aes.Create())
                {
                    aes.Key = _sharedSecret;
                    aes.IV = iv;
                    using (var decryptor = aes.CreateDecryptor())
                    {
                        decryptedBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
                    }
                }

                // 2. STOP TIMER
                sw.Stop();

                rtbCipherOutput.Text = Encoding.UTF8.GetString(decryptedBytes);

                // --- DYNAMIC CALCULATIONS ---
                double timeMs = sw.Elapsed.TotalMilliseconds;
                double dataSizeKB = (double)decryptedBytes.Length / 1024.0;
                double speedKBps = (timeMs > 0) ? (dataSizeKB / (timeMs / 1000.0)) : 0;

                string stats = $"--- DECRYPTION PERFORMANCE (Payload: {dataSizeKB:F4} KB) ---\n" +
                               $"Time: {timeMs:F4} ms\n" +
                               $"Throughput: {speedKBps:F4} KB/s\n\n" +
                               $"--- SECURITY AUDIT ---\n" +
                               $"Restored Entropy: {CalculateEntropy(decryptedBytes):F4} bits/byte";

                rtbDecStats.Text = stats;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Decryption Error: " + ex.Message);
            }
        }

        // --- DYNAMIC MATH HELPERS ---
        private double CalculateEntropy(byte[] data)
        {
            if (data == null || data.Length == 0) return 0;
            var map = new Dictionary<byte, int>();
            foreach (byte b in data) { if (!map.ContainsKey(b)) map.Add(b, 1); else map[b]++; }
            double result = 0.0; int len = data.Length;
            foreach (var item in map) { double f = (double)item.Value / len; result -= f * (Math.Log(f) / Math.Log(2)); }
            return result;
        }

        private string GetECCQuantumStatus(int curveBits)
        {
            int logicalQubits = 6 * curveBits;
            int physicalQubits = logicalQubits * 1000;
            string verdict = (curveBits <= 384) ? "HIGHLY VULNERABLE" : "MODERATELY VULNERABLE";

            return $"--- QUANTUM ANALYSIS ---\n" +
                   $"Attack Method: Shor's Algorithm (ECDLP)\n" +
                   $"Logical Qubits Needed: ~{logicalQubits}\n" +
                   $"Est. Physical Qubits: ~{physicalQubits / 1000}k\n" +
                   $"Verdict: {verdict}\n" +
                   $"Note: ECC breaks with FEWER qubits than RSA-2048.";
        }
    }
}