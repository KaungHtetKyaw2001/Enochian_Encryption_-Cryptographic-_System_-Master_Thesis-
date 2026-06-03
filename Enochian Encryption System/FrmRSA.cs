using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Enochian_Encryption_System
{
    public partial class FrmRSA : Form
    {
        private RSACryptoServiceProvider _rsa;
        private byte[] _lastEncryptedBytes;
        private int _currentKeySize = 2048;

        public FrmRSA()
        {
            InitializeComponent();
            _rsa = new RSACryptoServiceProvider(_currentKeySize);
        }

        // --- ENCRYPTION BUTTON ---
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rtbPlainInput.Text))
            {
                MessageBox.Show("Please enter text to encrypt.");
                return;
            }

            rtbEncStats.Text = "Benchmarking...";
            rtbPlainOutput.Clear();
            Application.DoEvents();

            // Prepare Input
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(rtbPlainInput.Text);
            double dataSizeKB = (double)dataToEncrypt.Length / 1024.0;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            long startMem = GC.GetTotalMemory(true);

            // 1. START TIMER
            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                // Block Chaining Logic
                int maxBlockSize = (_currentKeySize / 8) - 42;
                List<byte> finalEncryptedData = new List<byte>();

                for (int i = 0; i < dataToEncrypt.Length; i += maxBlockSize)
                {
                    int currentChunkSize = Math.Min(maxBlockSize, dataToEncrypt.Length - i);
                    byte[] chunk = new byte[currentChunkSize];
                    Array.Copy(dataToEncrypt, i, chunk, 0, currentChunkSize);
                    finalEncryptedData.AddRange(_rsa.Encrypt(chunk, true));
                }

                _lastEncryptedBytes = finalEncryptedData.ToArray();

                // 2. STOP TIMER
                sw.Stop();
                long endMem = GC.GetTotalMemory(false);

                // --- DYNAMIC CALCULATIONS ---
                double timeMs = sw.Elapsed.TotalMilliseconds;
                double entropy = CalculateEntropy(_lastEncryptedBytes);
                double speedKBps = (timeMs > 0) ? (dataSizeKB / (timeMs / 1000.0)) : 0;

                string quantumVerdict = GetDynamicQuantumVerdict(_currentKeySize);

                rtbPlainOutput.Text = Convert.ToBase64String(_lastEncryptedBytes);
                rtbCipherInput.Text = rtbPlainOutput.Text;

                string stats = $"--- PERFORMANCE (Payload: {dataSizeKB:F4} KB) ---\n" +
                               $"Time: {timeMs:F4} ms\n" +
                               $"Throughput: {speedKBps:F4} KB/s\n" +
                               $"Memory: {Math.Max(0, endMem - startMem)} Bytes\n" +
                               $"Complexity: O(N^3)\n\n" +
                               $"--- SECURITY & QUANTUM ---\n" +
                               $"Entropy: {entropy:F4} bits/byte\n" +
                               $"Key Size: {_currentKeySize}-bit\n" +
                               $"Quantum Status: {quantumVerdict}";

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

            long startMem = GC.GetTotalMemory(true);
            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                byte[] dataToDecrypt = _lastEncryptedBytes;
                if (rtbCipherInput.Text != Convert.ToBase64String(_lastEncryptedBytes ?? new byte[0]))
                {
                    try { dataToDecrypt = Convert.FromBase64String(rtbCipherInput.Text); }
                    catch { MessageBox.Show("Invalid Base64 Input."); return; }
                }

                int blockSize = _currentKeySize / 8;
                List<byte> finalDecryptedData = new List<byte>();

                // Measurement wraps only the decryption loop
                for (int i = 0; i < dataToDecrypt.Length; i += blockSize)
                {
                    byte[] chunk = new byte[blockSize];
                    Array.Copy(dataToDecrypt, i, chunk, 0, blockSize);
                    finalDecryptedData.AddRange(_rsa.Decrypt(chunk, true));
                }

                sw.Stop();
                long endMem = GC.GetTotalMemory(false);
                byte[] fullDecryptedBytes = finalDecryptedData.ToArray();
                rtbCipherOutput.Text = Encoding.UTF8.GetString(fullDecryptedBytes);

                double timeMs = sw.Elapsed.TotalMilliseconds;
                double dataSizeKB = (double)fullDecryptedBytes.Length / 1024.0;
                double speedKBps = (timeMs > 0) ? (dataSizeKB / (timeMs / 1000.0)) : 0;

                string stats = $"--- DECRYPTION PERFORMANCE (Payload: {dataSizeKB:F4} KB) ---\n" +
                               $"Time: {timeMs:F4} ms\n" +
                               $"Throughput: {speedKBps:F4} KB/s\n" +
                               $"Memory: {Math.Max(0, endMem - startMem)} Bytes\n\n" +
                               $"--- SECURITY ---\n" +
                               $"Restored Entropy: {CalculateEntropy(fullDecryptedBytes):F4} bits/byte";

                rtbDecStats.Text = stats;
            }
            catch (Exception ex) { MessageBox.Show("Decryption Error: " + ex.Message); }
        }

        // --- DYNAMIC HELPERS ---
        private double CalculateEntropy(byte[] data)
        {
            if (data == null || data.Length == 0) return 0;
            var map = new Dictionary<byte, int>();
            foreach (byte b in data) { if (!map.ContainsKey(b)) map.Add(b, 1); else map[b]++; }
            double result = 0.0; int len = data.Length;
            foreach (var item in map) { double f = (double)item.Value / len; result -= f * (Math.Log(f) / Math.Log(2)); }
            return result;
        }

        private string GetDynamicQuantumVerdict(int keyBits)
        {
            if (keyBits < 2048) return "CRITICALLY WEAK (Factoring Trivial)";
            else if (keyBits == 2048) return "VULNERABLE (Standard Threat)";
            else if (keyBits >= 4096) return "RESISTANT (High Qubit Cost)";
            return "UNKNOWN";
        }
    }
}