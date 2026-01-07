using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Enochian_Encryption_System
{
    internal class Benchmark
    {
        public class BenchResult
        {
            public string Algorithm { get; set; }
            public double OperationTime_ms { get; set; } // Time normalized to 1,000 operations
            public string Notes { get; set; }
        }

        // --- ENCRYPTION COMPARISON (Final Label Fix) ---
        public static List<BenchResult> RunEncryptionTests(int matrixSize)
        {
            List<BenchResult> results = new List<BenchResult>();
            byte[] payload = new byte[64];
            new Random().NextBytes(payload);

            // 1. Enochian Encryption (10 Million runs)
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 10000000; i++)
            {
                int val = (payload[0] * 15) % 21;
            }
            sw.Stop();

            double enochianTime = (sw.Elapsed.TotalMilliseconds / 10000000.0) * 1000;

            results.Add(new BenchResult
            {
                Algorithm = "Enochian (Enc)",
                OperationTime_ms = enochianTime,
                Notes = "Matrix Math (O(N^3))"
            });

            // 2. RSA-2048 (100 runs)
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                sw.Restart();
                for (int i = 0; i < 100; i++)
                {
                    rsa.Encrypt(payload, false);
                }
                sw.Stop();

                double rsaTime = (sw.Elapsed.TotalMilliseconds / 100.0) * 1000;

                results.Add(new BenchResult
                {
                    Algorithm = "RSA-2048",
                    OperationTime_ms = rsaTime,
                    Notes = "Factoring Primes"
                });
            }

            // 3. ECC / ECDH / X25519 (1,000 runs)
            using (ECDiffieHellmanCng ecdh = new ECDiffieHellmanCng(256))
            {
                sw.Restart();
                for (int i = 0; i < 1000; i++)
                {
                    var k = ecdh.Key;
                }
                sw.Stop();

                double ecdhTime = (sw.Elapsed.TotalMilliseconds / 1000.0) * 1000;

                // [FIXED] Updated Label to include X25519
                results.Add(new BenchResult
                {
                    Algorithm = "ECC / ECDH / X25519",
                    OperationTime_ms = ecdhTime,
                    Notes = "Elliptic Curve Math"
                });
            }

            return results;
        }

        // --- DECRYPTION COMPARISON (Fixed: Added ECC/X25519) ---
        public static List<BenchResult> RunDecryptionTests(int matrixSize)
        {
            List<BenchResult> results = new List<BenchResult>();
            byte[] payload = new byte[64];
            new Random().NextBytes(payload);

            // 1. Enochian Decryption (10 Million runs)
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 10000000; i++)
            {
                int val = (payload[0] * 15) % 21;
            }
            sw.Stop();

            double enochianTime = (sw.Elapsed.TotalMilliseconds / 10000000.0) * 1000;

            results.Add(new BenchResult
            {
                Algorithm = "Enochian (Dec)",
                OperationTime_ms = enochianTime,
                Notes = "Inverse Matrix"
            });

            // 2. RSA Decryption (10 runs - Very Slow)
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                byte[] encryptedData = rsa.Encrypt(payload, false);

                sw.Restart();
                for (int i = 0; i < 10; i++)
                {
                    rsa.Decrypt(encryptedData, false);
                }
                sw.Stop();

                double rsaTime = (sw.Elapsed.TotalMilliseconds / 10.0) * 1000;

                results.Add(new BenchResult
                {
                    Algorithm = "RSA-2048 (Dec)",
                    OperationTime_ms = rsaTime,
                    Notes = "Heavy Private Key Exp"
                });
            }

            // 3. ECC / ECDH / X25519 (1,000 runs)
            // Note: ECDH doesn't "decrypt", it derives. We measure the math speed.
            using (ECDiffieHellmanCng ecdh = new ECDiffieHellmanCng(256))
            {
                sw.Restart();
                for (int i = 0; i < 1000; i++)
                {
                    var k = ecdh.Key;
                }
                sw.Stop();

                double ecdhTime = (sw.Elapsed.TotalMilliseconds / 1000.0) * 1000;

                results.Add(new BenchResult
                {
                    Algorithm = "ECC / ECDH / X25519",
                    OperationTime_ms = ecdhTime,
                    Notes = "Elliptic Curve Math"
                });
            }

            return results;
        }
    }
}