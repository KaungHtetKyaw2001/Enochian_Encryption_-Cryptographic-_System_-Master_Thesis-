using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Enochian_Encryption_System
{
    public partial class FrmSigVerification : Form
    {
        public FrmSigVerification()
        {
            InitializeComponent();
        }

        private int[] _senderPublicKey;
        private int _modulus;
        private int _multiplier;

        private void FrmSigVerification_Load(object sender, EventArgs e)
        {
            // 1. SEQUENCE CHECK
            if (!GlobalSession.DecStep1_Done)
            {
                MessageBox.Show("Sequence Error: Step 1 (Package Delivery) is not complete.", "Access Denied");
                this.Close();
                return;
            }

            // =========================================================
            // 2. LOAD KEY & PARAMETERS (CRITICAL FIX)
            // =========================================================
            // We must try to load from the FinalPayload (Loaded from XML) FIRST.
            // Only fallback to GlobalSession.Sender... if Payload is null (e.g. testing during encryption phase).

            var payload = GlobalSession.FinalPayload;

            // A. Load Public Key
            if (payload != null && payload.SenderPublicVector != null && payload.SenderPublicVector.Length >= 3)
            {
                _senderPublicKey = payload.SenderPublicVector;
            }
            else if (GlobalSession.SenderPublicVector != null && GlobalSession.SenderPublicVector.Length >= 3)
            {
                _senderPublicKey = GlobalSession.SenderPublicVector;
            }
            else
            {
                _senderPublicKey = new int[] { 0, 0, 0 }; // Legacy/Empty
            }

            // B. Load Modulus
            if (payload != null && payload.SenderModulus > 0)
                _modulus = payload.SenderModulus;
            else if (GlobalSession.SenderModulus > 0)
                _modulus = GlobalSession.SenderModulus;
            else
                _modulus = 29; // Safe default to prevent div/0 crash

            // C. Load Multiplier
            if (payload != null && payload.SenderMultiplier > 0)
                _multiplier = payload.SenderMultiplier;
            else if (GlobalSession.SenderMultiplier > 0)
                _multiplier = GlobalSession.SenderMultiplier;
            else
                _multiplier = 1;

            // D. Load Target Hash
            int targetHash = 21; // Default
            if (payload != null && payload.TargetHashID > 0)
                targetHash = payload.TargetHashID;
            else if (GlobalSession.SignatureTargetHash > 0)
                targetHash = GlobalSession.SignatureTargetHash;

            // 3. POPULATE UI
            txtTargetHash.Text = targetHash.ToString();

            // Get Sig String
            string sigStr = "[0,0,0]";
            if (payload != null && !string.IsNullOrEmpty(payload.DigitalSignatureString))
                sigStr = payload.DigitalSignatureString;

            txtSigVector.Text = sigStr;
            txtPublicKey.Text = "[" + string.Join(", ", _senderPublicKey) + "]";
            lblKeyParams.Text = $"Params: Mod={_modulus}, Mult={_multiplier}";

            // Reset Status
            lblFinalStatus.Text = "READY TO VERIFY";
            lblFinalStatus.BackColor = Color.LightGray;

            if (IsKeyZero(_senderPublicKey))
            {
                lblFinalStatus.Text = "WARNING: NO KEY FOUND";
                lblFinalStatus.BackColor = Color.Yellow;
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            GlobalSession.ResetEncryptionMetrics(); // <--- RESET BUCKETS
            MetricProbe probe = new MetricProbe(false); // <--- START MEASURING

            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                // STEP 1: GATHER INPUTS
                int targetHash = 0;
                int.TryParse(txtTargetHash.Text, out targetHash);

                int[] sigVector = ParseVector(txtSigVector.Text);
                int[] pubKey = _senderPublicKey;

                // STEP 2: CHECKSUM MATH (Dot Product)
                long checksum = 0;
                string formulaLog = "";

                int limit = Math.Min(sigVector.Length, pubKey.Length);
                for (int i = 0; i < limit; i++)
                {
                    int valSig = sigVector[i];
                    int valKey = pubKey[i];
                    checksum += (valSig * valKey);

                    if (valSig > 0 || valKey > 0)
                    {
                        if (formulaLog.Length > 0) formulaLog += " + ";
                        formulaLog += $"({valSig}*{valKey})";
                    }
                }

                if (string.IsNullOrEmpty(formulaLog)) formulaLog = "0 (No bits set)";

                txtChecksumFormula.Text = formulaLog;
                lblChecksum.Text = $"Checksum = {checksum}";

                // STEP 3: INVERSE MATH (Decryption Logic)
                int inverseMultiplier = ModInverse(_multiplier, _modulus);

                if (inverseMultiplier == -1) inverseMultiplier = 1;

                // The Logic: (SumPublic * n^-1) % m should equal Target
                long result = (checksum * inverseMultiplier) % _modulus;

                lblInverseParam.Text = $"Inverse (n^-1): {inverseMultiplier}";
                lblInverseResult.Text = $"({checksum} * {inverseMultiplier}) % {_modulus} = {result}";

                // STEP 4: STATUS
                bool isMatch = (result == targetHash);

                if (isMatch)
                {
                    lblFinalStatus.Text = "MATCH: SIGNATURE VALID";
                    lblFinalStatus.BackColor = Color.LightGreen;
                    lblFinalStatus.ForeColor = Color.DarkGreen;

                    GlobalSession.DecStep2_Done = true;
                    btnConfirm.Enabled = true;

                    // [CRITICAL] SAVE THE TARGET ID (HEADER) FOR DECAPSULATION (STEP 3)
                    // The Payload has the Encrypted ID. We verified it is authentic.
                    // Now Step 3 needs to know this ID to solve the trapdoor.
                    GlobalSession.FinalPayload.TargetHashID = targetHash;

                    MessageBox.Show("Verification Successful! Signature matches Header.");
                    sw.Stop();
                    probe.StopAndAccumulate(); // <--- ADD TO TOTAL
                    GlobalSession.LogDecTime("Decryption Step 2: Verification", sw.Elapsed.TotalMilliseconds);
                }
                else
                {
                    sw.Stop();
                    lblFinalStatus.Text = "INVALID: TAMPER DETECTED";
                    lblFinalStatus.BackColor = Color.Red;
                    lblFinalStatus.ForeColor = Color.White;

                    MessageBox.Show($"Verification Failed.\nCalculated: {result}\nExpected: {targetHash}\n\nParams used: Mod={_modulus}, Mult={_multiplier}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verification Error: " + ex.Message);
            }
        }

        // --- HELPERS ---
        private bool IsKeyZero(int[] key)
        {
            if (key == null || key.Length == 0) return true;
            foreach (int k in key) if (k != 0) return false;
            return true;
        }

        private int ModInverse(int a, int m)
        {
            if (m == 0) return -1;
            a = a % m;
            for (int x = 1; x < m; x++) if ((a * x) % m == 1) return x;
            return -1;
        }

        private int[] ParseVector(string raw)
        {
            string clean = raw.Replace("[", "").Replace("]", "").Replace(" ", "");
            if (string.IsNullOrEmpty(clean)) return new int[0];
            return clean.Split(',').Select(n => int.TryParse(n, out int v) ? v : 0).ToArray();
        }

        private void btnConfirm_Click(object sender, EventArgs e) { this.Close(); }
    }
}