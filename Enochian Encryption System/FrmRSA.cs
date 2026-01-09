using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

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

            GC.Collect();
            GC.WaitForPendingFinalizers();
            long startMem = GC.GetTotalMemory(true);
            TimeSpan startCpu = Process.GetCurrentProcess().TotalProcessorTime;
            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                byte[] dataToEncrypt = Encoding.UTF8.GetBytes(rtbPlainInput.Text);

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

                sw.Stop();
                long endMem = GC.GetTotalMemory(false);
                TimeSpan endCpu = Process.GetCurrentProcess().TotalProcessorTime;

                // --- DYNAMIC CALCULATIONS ---
                double timeMs = sw.Elapsed.TotalMilliseconds;
                double entropy = CalculateEntropy(_lastEncryptedBytes);
                double dataSizeKB = (double)dataToEncrypt.Length / 1024.0;
                double speedKBps = (timeMs > 0) ? (dataSizeKB / (timeMs / 1000.0)) : 0;
                double cpuMs = (endCpu - startCpu).TotalMilliseconds;

                // Dynamic Quantum Verdict
                string quantumVerdict = GetDynamicQuantumVerdict(_currentKeySize);

                rtbPlainOutput.Text = Convert.ToBase64String(_lastEncryptedBytes);
                rtbCipherInput.Text = rtbPlainOutput.Text;

                string stats = $"--- PERFORMANCE ---\n" +
                               $"Time: {timeMs:F4} ms\n" +
                               $"Throughput: {speedKBps:F4} KB/s\n" +
                               $"Memory: {Math.Max(0, endMem - startMem)} Bytes\n" +
                               $"CPU: {(cpuMs == 0 ? "< 1 ms" : $"{cpuMs:F4} ms")}\n" +
                               $"Complexity: O(N^3) [Exponential]\n\n" +
                               $"--- SECURITY & QUANTUM ---\n" +
                               $"Entropy: {entropy:F4} bits/byte\n" +
                               $"Key Size: {_currentKeySize}-bit\n" +
                               $"Qubits Needed: ~{_currentKeySize * 2} Logical\n" +
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
            TimeSpan startCpu = Process.GetCurrentProcess().TotalProcessorTime;
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

                if (dataToDecrypt.Length % blockSize != 0)
                {
                    MessageBox.Show("Corrupt Data: Length mismatch.");
                    return;
                }

                for (int i = 0; i < dataToDecrypt.Length; i += blockSize)
                {
                    byte[] chunk = new byte[blockSize];
                    Array.Copy(dataToDecrypt, i, chunk, 0, blockSize);
                    finalDecryptedData.AddRange(_rsa.Decrypt(chunk, true));
                }

                byte[] fullDecryptedBytes = finalDecryptedData.ToArray();

                sw.Stop();
                long endMem = GC.GetTotalMemory(false);
                TimeSpan endCpu = Process.GetCurrentProcess().TotalProcessorTime;

                rtbCipherOutput.Text = Encoding.UTF8.GetString(fullDecryptedBytes);

                double timeMs = sw.Elapsed.TotalMilliseconds;
                double cpuMs = (endCpu - startCpu).TotalMilliseconds;
                double entropy = CalculateEntropy(fullDecryptedBytes);
                double dataSizeKB = (double)fullDecryptedBytes.Length / 1024.0;
                double speedKBps = (timeMs > 0) ? (dataSizeKB / (timeMs / 1000.0)) : 0;

                string quantumVerdict = GetDynamicQuantumVerdict(_currentKeySize);

                string stats = $"--- DECRYPTION PERFORMANCE ---\n" +
                               $"Time: {timeMs:F4} ms\n" +
                               $"Throughput: {speedKBps:F4} KB/s\n" +
                               $"Memory: {Math.Max(0, endMem - startMem)} Bytes\n" +
                               $"CPU: {(cpuMs == 0 ? "< 1 ms" : $"{cpuMs:F4} ms")}\n\n" +
                               $"--- SECURITY & QUANTUM ---\n" +
                               $"Restored Entropy: {entropy:F4} bits/byte\n" +
                               $"Quantum Status: {quantumVerdict}";

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
            // Logic based on Shor's Algorithm (2N Qubits)
            if (keyBits < 2048)
            {
                return "CRITICALLY WEAK (Factoring Trivial)";
            }
            else if (keyBits == 2048)
            {
                return "VULNERABLE (Standard Threat)";
            }
            else if (keyBits >= 4096)
            {
                return "RESISTANT (High Qubit Cost)";
            }
            return "UNKNOWN";
        }
    }
}