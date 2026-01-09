using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

namespace Enochian_Encryption_System
{
    public partial class FrmDigitalSignature : Form
    {
        private int _target;
        private int[] _privateKey;
        private int[] _publicKey;
        private int[] _generatedSignature;

        // Crypto Parameters
        private int _modulusM;
        private int _multiplierN;

        public FrmDigitalSignature()
        {
            InitializeComponent();
        }

        private void FrmDigitalSignature_Load(object sender, EventArgs e)
        {
            // 1. Strict Sequence Check
            if (!GlobalSession.Step14_Done)
            {
                MessageBox.Show("Please complete Step 14 (Packaging) first.", "Access Denied");
                this.Close();
                return;
            }

            // 2. Load Target Hash
            if (GlobalSession.SignatureTargetHash != 0)
                _target = GlobalSession.SignatureTargetHash;
            else
            {
                _target = 21;
                GlobalSession.SignatureTargetHash = _target;
            }

            lblTargetHash.Text = _target.ToString();

            // =========================================================
            // 3. LOAD OR REGENERATE PRIVATE KEY
            // =========================================================
            bool needNewKey = true;

            if (GlobalSession.SenderPrivateVector != null && GlobalSession.SenderPrivateVector.Length > 0)
            {
                // Test if the existing key can mathematically solve the target
                if (FindSubsetSum(GlobalSession.SenderPrivateVector, _target) != null)
                {
                    _privateKey = GlobalSession.SenderPrivateVector;
                    needNewKey = false;
                }
            }

            if (needNewKey)
            {
                _privateKey = GenerateSolvableKey(_target);
                GlobalSession.SenderPrivateVector = _privateKey;
                lblSenderKey.ForeColor = Color.Blue;
            }

            lblSenderKey.Text = "[" + string.Join(", ", _privateKey) + "]";

            // =========================================================
            // 4. GENERATE ROBUST PUBLIC KEY (FIXED)
            // =========================================================
            GeneratePublicKeyFromPrivate();

            // 5. Setup DataGridView
            dgvSignature.Rows.Clear();
            dgvSignature.Columns.Clear();
            dgvSignature.Columns.Add("Val", "Private Key");
            dgvSignature.Columns.Add("Pub", "Public Key");
            dgvSignature.Columns.Add("Used", "Used in Sum?");
            dgvSignature.Columns.Add("Bit", "Bit Value");
            dgvSignature.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            for (int i = 0; i < _privateKey.Length; i++)
            {
                dgvSignature.Rows.Add(_privateKey[i], _publicKey[i], "?", "0");
            }
        }

        // [FIX] Self-Verifying Key Generator
        // This ensures M and N actually work before saving them.
        private void GeneratePublicKeyFromPrivate()
        {
            Random rnd = new Random();
            long sum = 0;
            foreach (int k in _privateKey) sum += k;

            bool validKeyFound = false;
            int attempts = 0;

            while (!validKeyFound && attempts < 1000)
            {
                attempts++;

                // A. Generate Candidates
                // Modulo must be > Sum. We add random buffer.
                int candidateM = (int)sum + rnd.Next(5, 50);
                int candidateN = GetCoprime(candidateM, rnd);

                // B. Verify Mathematically (The "Test Drive")
                // We test if we can encrypt and decrypt the first element of the private key.
                // If this works, the math holds for the whole vector.

                int testValue = _privateKey[0];
                int inverseN = ModInverse(candidateN, candidateM);

                if (inverseN == -1) continue; // Invalid, try again

                // Encrypt: (Val * N) % M
                long encrypted = (long)testValue * candidateN;
                int cipher = (int)(encrypted % candidateM);

                // Decrypt: (Cipher * Inv) % M
                long decryptedCalc = (long)cipher * inverseN;
                int recovered = (int)(decryptedCalc % candidateM);

                // Check Matching
                if (recovered == testValue)
                {
                    // FOUND A WORKING KEY!
                    _modulusM = candidateM;
                    _multiplierN = candidateN;
                    validKeyFound = true;
                }
            }

            // Fallback (Should typically not be reached with loop)
            if (!validKeyFound)
            {
                _modulusM = (int)sum + 10;
                _multiplierN = 1;
            }

            // C. Generate Final Public Vector
            _publicKey = new int[_privateKey.Length];
            for (int i = 0; i < _privateKey.Length; i++)
            {
                _publicKey[i] = (_privateKey[i] * _multiplierN) % _modulusM;
            }

            // SAVE TO SESSION
            GlobalSession.SenderModulus = _modulusM;
            GlobalSession.SenderMultiplier = _multiplierN;
            GlobalSession.SenderPublicVector = _publicKey;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            GlobalSession.ResetEncryptionMetrics(); // <--- RESET BUCKETS
            MetricProbe probe = new MetricProbe(true); // <--- START MEASURING

            Stopwatch sw = Stopwatch.StartNew();
            txtCalcLog.Clear();

            // 1. Solve the Subset Sum Problem (The Trapdoor)
            List<int> solutionSet = FindSubsetSum(_privateKey, _target);

            if (solutionSet == null)
            {
                txtCalcLog.Text = "Error: Key regeneration failed. Please restart Step.";
                sw.Stop();
                return;
            }

            // 2. Generate Log
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Target Hash to Solve: {_target}");
            sb.AppendLine($"Private Key: [{string.Join(", ", _privateKey)}]");
            sb.AppendLine($"Public Key:  [{string.Join(", ", _publicKey)}] (Derived)");
            sb.AppendLine($"Params: M={_modulusM}, n={_multiplierN}");
            sb.AppendLine("-------------------------------------------------------");

            int currentTarget = _target;
            solutionSet.Sort((a, b) => b.CompareTo(a));

            foreach (int num in solutionSet)
            {
                int remainder = currentTarget - num;
                sb.AppendLine($"   {currentTarget} - {num} = {remainder} ... (Found in Key? Yes!)");
                currentTarget = remainder;
            }

            sb.AppendLine("-------------------------------------------------------");
            sb.AppendLine($"Result: {string.Join(" + ", solutionSet)} = {_target}");
            txtCalcLog.Text = sb.ToString();

            // 3. Populate Signature Vector
            _generatedSignature = new int[_privateKey.Length];
            List<int> remainingSolution = new List<int>(solutionSet);

            for (int i = 0; i < _privateKey.Length; i++)
            {
                int keyVal = _privateKey[i];
                bool isUsed = false;

                if (remainingSolution.Contains(keyVal))
                {
                    isUsed = true;
                    remainingSolution.Remove(keyVal);
                }

                _generatedSignature[i] = isUsed ? 1 : 0;

                dgvSignature.Rows[i].Cells[2].Value = isUsed ? "Yes" : "No";
                dgvSignature.Rows[i].Cells[3].Value = _generatedSignature[i];

                if (isUsed) dgvSignature.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                else dgvSignature.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }

            sw.Stop();
            probe.StopAndAccumulate(); // <--- ADD TO TOTAL
            GlobalSession.LogEncTime("Step 15: Dig. Signature", sw.Elapsed.TotalMilliseconds);
            MessageBox.Show($"Trapdoor solved and Public Key Generated!\nTime: {sw.Elapsed.TotalMilliseconds:F4} ms.");
            btnConfirm.Enabled = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            GlobalSession.FinalSignatureVector = _generatedSignature;
            GlobalSession.Step15_Done = true;

            if (GlobalSession.FinalPayload != null)
            {
                GlobalSession.FinalPayload.DigitalSignatureString = "[" + string.Join(",", _generatedSignature) + "]";
                GlobalSession.FinalPayload.TargetHashID = _target;
                GlobalSession.FinalPayload.SenderModulus = _modulusM;
                GlobalSession.FinalPayload.SenderMultiplier = _multiplierN;
                GlobalSession.FinalPayload.SenderPublicVector = _publicKey;
            }

            this.Close();
        }

        // --- MATH HELPERS ---

        private int GetCoprime(int m, Random rnd)
        {
            int n = 0;
            for (int i = 0; i < 100; i++)
            {
                n = rnd.Next(2, m - 1);
                if (GCD(n, m) == 1) return n;
            }
            return 3;
        }

        private int GCD(int a, int b)
        {
            while (b != 0) { int t = b; b = a % b; a = t; }
            return a;
        }

        private int ModInverse(int a, int m)
        {
            a = a % m;
            for (int x = 1; x < m; x++) if ((a * x) % m == 1) return x;
            return -1;
        }

        // --- SOLVER HELPERS ---

        private List<int> FindSubsetSum(int[] numbers, int target)
        {
            List<int> result = new List<int>();
            if (Solve(numbers, target, 0, result)) return result;
            return null;
        }

        private bool Solve(int[] numbers, int target, int index, List<int> current)
        {
            if (target == 0) return true;
            if (target < 0 || index >= numbers.Length) return false;

            current.Add(numbers[index]);
            if (Solve(numbers, target - numbers[index], index + 1, current)) return true;

            current.RemoveAt(current.Count - 1);
            if (Solve(numbers, target, index + 1, current)) return true;

            return false;
        }

        private int[] GenerateSolvableKey(int target)
        {
            Random rng = new Random();
            int maxLimit = (target / 2) - 1;
            if (maxLimit < 1) maxLimit = 1;

            int part1 = rng.Next(1, maxLimit);
            int part2 = target - part1;
            int noise = rng.Next(target + 1, target + 50);

            int[] key = new int[] { noise, part1, part2 };

            // Fisher-Yates Shuffle
            int n = key.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = key[k];
                key[k] = key[n];
                key[n] = value;
            }
            return key;
        }
    }
}