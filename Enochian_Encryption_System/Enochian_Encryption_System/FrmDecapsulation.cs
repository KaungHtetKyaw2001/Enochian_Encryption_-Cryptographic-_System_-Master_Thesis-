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
    public partial class FrmDecapsulation : Form
    {
        public FrmDecapsulation() { InitializeComponent(); }

        private int _receiverModulo;
        private int _receiverMultiplier;
        private int[] _receiverPrivateKey;

        private void FrmDecapsulation_Load(object sender, EventArgs e)
        {
            if (!GlobalSession.DecStep2_Done) {
                MessageBox.Show("Sequence Error: Step 2 (Signature Verification) is not complete.", "Access Denied");
                this.Close();
                return;
            }

            int encryptedPackageID = 0;
            if (GlobalSession.FinalPayload != null)
                encryptedPackageID = GlobalSession.FinalPayload.TargetHashID;
            if (encryptedPackageID == 0) encryptedPackageID = 21;

            // [CRITICAL FIX] RESTORE STATE FROM PAYLOAD
            if (GlobalSession.FinalPayload != null)
            {
                // 1. Load Receiver Keys
                _receiverModulo = GlobalSession.FinalPayload.ReceiverModulus;
                _receiverMultiplier = GlobalSession.FinalPayload.ReceiverMultiplier;
                _receiverPrivateKey = GlobalSession.FinalPayload.ReceiverPrivateVector;

                // 2. [NEW] Load Lorentz Seeds (REQUIRED FOR S-BOX & SHUFFLE)
                GlobalSession.LorentzInt1 = GlobalSession.FinalPayload.LorentzInt1;
                GlobalSession.LorentzInt2 = GlobalSession.FinalPayload.LorentzInt2; // <--- The S-Box Seed
                GlobalSession.LorentzInt3 = GlobalSession.FinalPayload.LorentzInt3; // <--- The Integrity Salt

                // 3. [NEW] Load Matrix Configuration
                GlobalSession.MatrixSize = GlobalSession.FinalPayload.MatrixSize;
                GlobalSession.LorentzIterations = GlobalSession.FinalPayload.IterationCount;

                // 4. [NEW] Load Sender Keys (For Signature Verification)
                GlobalSession.SenderPublicVector = GlobalSession.FinalPayload.SenderPublicVector;
                GlobalSession.SenderModulus = GlobalSession.FinalPayload.SenderModulus;
                GlobalSession.SenderMultiplier = GlobalSession.FinalPayload.SenderMultiplier;
            }
            else
            {
                // Fallback (for same-session testing)
                _receiverModulo = GlobalSession.ReceiverModulus;
                _receiverMultiplier = GlobalSession.ReceiverMultiplier;
                _receiverPrivateKey = GlobalSession.ReceiverPrivateVector;
            }

            // Fallback to prevent crash
            if (_receiverModulo == 0) _receiverModulo = 29;
            if (_receiverPrivateKey == null) _receiverPrivateKey = new int[] { 3, 5, 10 };

            txtEncHeader.Text = encryptedPackageID.ToString();
            txtPrivKey.Text = $"n = {_receiverMultiplier}";
            txtModulo.Text = $"M = {_receiverModulo}";
            txtMultiplier.Text = _receiverMultiplier.ToString();

            int[] originalVec = null;
            if (GlobalSession.FinalPayload != null && GlobalSession.FinalPayload.SessionVector != null)
                originalVec = GlobalSession.FinalPayload.SessionVector;
            else if (GlobalSession.SessionVector != null)
                originalVec = GlobalSession.SessionVector;

            if (originalVec != null)
                lblOriginalSessionVector.Text = "[" + string.Join(", ", originalVec) + "]";
            else
                lblOriginalSessionVector.Text = "[Unknown]";

            lblStatus.Text = "Ready for Decapsulation...";
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                // 1. Inverse
                int inverseMultiplier = ModInverse(_receiverMultiplier, _receiverModulo);
                if (inverseMultiplier == -1) inverseMultiplier = 1;

                lblInverse.Text = $"Inverse (n^-1): {inverseMultiplier}";
                lblCalcs.Text = $"Calculating: Inv({_receiverMultiplier}, {_receiverModulo}) = {inverseMultiplier}";
                Application.DoEvents();

                // 2. Decrypt Scalar
                int encryptedVal = int.Parse(txtEncHeader.Text);
                long calculation = (long)encryptedVal * inverseMultiplier;
                int decryptedScalar = (int)(calculation % _receiverModulo);

                lblFormula.Text = $"({encryptedVal} * {inverseMultiplier}) % {_receiverModulo} = {decryptedScalar}";

                // 3. Solve Vector
                int[] recoveredVector = SolveKnapsackVector(decryptedScalar, _receiverPrivateKey);
                string recoveredVecStr = "[" + string.Join(", ", recoveredVector) + "]";
                lblResultVector.Text = recoveredVecStr;

                // 4. Compare
                string originalVecStr = lblOriginalSessionVector.Text;
                bool isMatch = (recoveredVecStr.Replace(" ", "") == originalVecStr.Replace(" ", ""));


                if (isMatch)
                {
                    lblComparison.Text = "VALID: MATCH FOUND";
                    lblComparison.ForeColor = Color.Green;
                    lblStatus.Text = "SESSION RESTORED";
                    lblStatus.BackColor = Color.LightGreen;

                    MessageBox.Show($"Decapsulation Successful!\n\n" +
                        $"Session Vector Restored.\n" +
                        $"Lorentz Seeds Loaded (X:{GlobalSession.LorentzInt1} Y:{GlobalSession.LorentzInt2} Z:{GlobalSession.LorentzInt3}).\n" +
                        "The S-Box can now be reversed correctly.");

                    sw.Stop();
                    GlobalSession.LogDecTime("Step 3: Decapsulation", sw.Elapsed.TotalMilliseconds);
                    GlobalSession.DecapsulatedID = decryptedScalar;
                    GlobalSession.DecStep3_Done = true;
                    btnConfirm.Enabled = true;
                }
                else
                {
                    sw.Stop();
                    lblComparison.Text = "INVALID: MISMATCH";
                    lblComparison.ForeColor = Color.Red;
                    lblStatus.Text = "FAILED";
                    lblStatus.BackColor = Color.Red;
                    MessageBox.Show($"Critical Error: Mismatch.\nKey used: [{string.Join(",", _receiverPrivateKey)}]\nModulo used: {_receiverModulo}");
                }
            }
            catch (Exception ex) { sw.Stop(); MessageBox.Show("Error: " + ex.Message); }
        }

        // --- HELPERS ---
        private int[] SolveKnapsackVector(int target, int[] privateKey)
        {
            int[] resultVector = new int[privateKey.Length];
            List<int> usedValues = FindSubsetSum(privateKey, target);
            if (usedValues != null)
            {
                for (int i = 0; i < privateKey.Length; i++)
                {
                    if (usedValues.Contains(privateKey[i])) { resultVector[i] = 1; usedValues.Remove(privateKey[i]); }
                    else resultVector[i] = 0;
                }
            }
            return resultVector;
        }

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

        private int ModInverse(int a, int m)
        {
            a = a % m;
            for (int x = 1; x < m; x++) if ((a * x) % m == 1) return x;
            return -1;
        }

        private void btnConfirm_Click(object sender, EventArgs e) { this.Close(); }
    }
}