using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Enochian_Encryption_System
{
    public partial class FrmKeyEncapsulation : Form
    {
        public FrmKeyEncapsulation()
        {
            InitializeComponent();
        }

        private void FrmKeyEncapsulation_Load(object sender, EventArgs e)
        {
            // 1. Check if Receiver Key exists
            if (GlobalSession.ReceiverPublicKey == null)
            {
                MessageBox.Show("Error: You haven't generated the Receiver Keys yet.\n" +
                                "Please use the 'Receiver Configuration' section at the top left.",
                                "Missing Public Key");
                this.Close();
                return;
            }

            // 2. Check if Session Vector exists (From Step 1)
            if (GlobalSession.SessionVector == null)
            {
                MessageBox.Show("Error: Session Vector is missing.\n" +
                                "Please complete Step 1 first.",
                                "Missing Session");
                this.Close();
                return;
            }

            // 3. Display the Data
            txtRecPubKey.Text = "[" + string.Join(", ", GlobalSession.ReceiverPublicKey) + "]";
            lblSessionVec.Text = "[" + string.Join(", ", GlobalSession.SessionVector) + "]";
        }


        private void btnEncryptHeader_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                // 4. The Math (Dot Product)
                int sum = 0;
                for (int i = 0; i < GlobalSession.SessionVector.Length; i++)
                {
                    sum += GlobalSession.SessionVector[i] * GlobalSession.ReceiverPublicKey[i];
                }

                // =========================================================
                // [CRITICAL FIX] SAVE THE ORIGINAL ID FOR VALIDATION LATER
                // =========================================================
                // We assume the SessionVector[0] holds the original ID (e.g., 10).
                // We must save this so Step 16 (Decapsulation) can say "VALID: MATCH CONFIRMED".
                if (GlobalSession.SessionVector.Length > 0)
                {
                    GlobalSession.HeaderID = GlobalSession.SessionVector[0];
                }

                // 5. Show Result
                txtHeaderResult.Text = sum.ToString(); // e.g., 14 or 170

                // 6. Save Global State
                GlobalSession.EncryptedHeader = sum;

                sw.Stop();
                GlobalSession.LogEncTime("Step 2: Key Encapsulation", sw.Elapsed.TotalMilliseconds);

                GlobalSession.SignatureTargetHash = GlobalSession.EncryptedHeader; // Set target for digital signature
                GlobalSession.Step2_Done = true; // Mark Step 2 as finished

                MessageBox.Show($"Header Encapsulated: {sum}\n\n" +
                                $"Original ID ({GlobalSession.HeaderID}) saved for verification.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}