using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Kems;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace Enochian_Encryption_System
{
    internal class KyberBenchmarker
    {
        // --- Class-Level State Variables ---
        private MLKemPublicKeyParameters? _publicKey;
        private MLKemPrivateKeyParameters? _privateKey;
        private byte[]? _encapsulatedSecret;
        private byte[]? _aesIv;

        public void GenerateKeys()
        {
            var random = new SecureRandom();
            var keyGenParameters = new MLKemKeyGenerationParameters(random, MLKemParameters.ml_kem_768);
            var keyPairGenerator = new MLKemKeyPairGenerator();

            keyPairGenerator.Init(keyGenParameters);
            var keyPair = keyPairGenerator.GenerateKeyPair();

            _publicKey = (MLKemPublicKeyParameters)keyPair.Public;
            _privateKey = (MLKemPrivateKeyParameters)keyPair.Private;
        }

        public double BenchmarkEncryption(byte[] plaintextDocument, out byte[] encryptedDocument)
        {
            Stopwatch sw = Stopwatch.StartNew();

            // STEP 1: FIPS-203 ML-KEM Encapsulation
            var random = new SecureRandom();
            var encapsulator = new MLKemEncapsulator(MLKemParameters.ml_kem_768);
            encapsulator.Init(new ParametersWithRandom(_publicKey, random));

            _encapsulatedSecret = new byte[encapsulator.EncapsulationLength];
            byte[] sharedSecret = new byte[encapsulator.SecretLength];

            encapsulator.Encapsulate(_encapsulatedSecret, 0, _encapsulatedSecret.Length, sharedSecret, 0, sharedSecret.Length);

            // STEP 2: AES-256 Encryption
            using (Aes aes = Aes.Create())
            {
                aes.Key = sharedSecret;
                aes.GenerateIV();
                _aesIv = aes.IV;

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (ICryptoTransform encryptor = aes.CreateEncryptor())
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(plaintextDocument, 0, plaintextDocument.Length);
                        csEncrypt.FlushFinalBlock();
                    }
                    encryptedDocument = msEncrypt.ToArray();
                }
            }

            sw.Stop();
            // Use TotalMilliseconds to get high-precision decimals (e.g., 0.0234 ms)
            return sw.Elapsed.TotalMilliseconds;
        }

        public double BenchmarkDecryption(byte[] encryptedDocument)
        {
            Stopwatch sw = Stopwatch.StartNew();

            // STEP 1: FIPS-203 ML-KEM Decapsulation
            var decapsulator = new MLKemDecapsulator(MLKemParameters.ml_kem_768);
            decapsulator.Init(_privateKey);

            byte[] decryptedSecret = new byte[decapsulator.SecretLength];

            decapsulator.Decapsulate(_encapsulatedSecret, 0, _encapsulatedSecret!.Length, decryptedSecret, 0, decryptedSecret.Length);

            // STEP 2: AES-256 Decryption
            using (Aes aes = Aes.Create())
            {
                aes.Key = decryptedSecret;
                aes.IV = _aesIv!;

                using (MemoryStream msDecrypt = new MemoryStream(encryptedDocument))
                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (MemoryStream msPlain = new MemoryStream())
                {
                    csDecrypt.CopyTo(msPlain);
                }
            }

            sw.Stop();
            // Use TotalMilliseconds to get high-precision decimals
            return sw.Elapsed.TotalMilliseconds;
        }
    }
}