using System;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Enochian_Encryption_System
{
    public partial class FrmReceiverConfig : Form
    {
        public FrmReceiverConfig() { InitializeComponent(); }

        private void btnRandomize_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            int[] privateKey = { rng.Next(5, 20), rng.Next(5, 20), rng.Next(5, 20) };
            txtPrivateKey.Text = string.Join(", ", privateKey);

            long sum = privateKey.Sum();
            bool validFound = false;
            int attempts = 0, modulo = 0, multiplier = 0;

            while (!validFound && attempts < 1000)
            {
                attempts++;
                modulo = (int)sum + rng.Next(5, 25);
                multiplier = FindCoprime(modulo, rng);
                int inv = ModInverse(multiplier, modulo);
                if (inv == -1) continue;

                // Verification check
                long enc = (long)privateKey[0] * multiplier;
                long dec = ((long)(enc % modulo) * inv) % modulo;
                if (dec == privateKey[0]) validFound = true;
            }
            if (!validFound) { modulo = (int)sum + 10; multiplier = 1; }

            txtModulo.Text = modulo.ToString();
            txtMultiplier.Text = multiplier.ToString();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                int[] privateKey = txtPrivateKey.Text.Split(',').Select(s => int.Parse(s.Trim())).ToArray();
                int modulo = int.Parse(txtModulo.Text);
                int multiplier = int.Parse(txtMultiplier.Text);

                int[] publicKey = new int[privateKey.Length];
                for (int i = 0; i < privateKey.Length; i++)
                    publicKey[i] = (privateKey[i] * multiplier) % modulo;

                sw.Stop();
                txtPublicKeyResult.Text = "[" + string.Join(", ", publicKey) + "]";

                // [FIX] SAVE ALL PARAMETERS TO SESSION
                GlobalSession.ReceiverPublicKey = publicKey;
                GlobalSession.ReceiverPrivateVector = privateKey;
                GlobalSession.ReceiverModulus = modulo;       // <--- CRITICAL FIX
                GlobalSession.ReceiverMultiplier = multiplier; // <--- CRITICAL FIX

                GlobalSession.LogEncTime("Receiver Public Key Generation", sw.Elapsed.TotalMilliseconds);
                MessageBox.Show("Public Key Generated and Saved!", "Success");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Invalid Input: " + ex.Message); }
        }

        // Helpers
        private int FindCoprime(int mod, Random rng)
        {
            for (int i = 0; i < 50; i++) { int c = rng.Next(2, mod - 1); if (GCD(mod, c) == 1) return c; }
            return 3;
        }
        private int GCD(int a, int b) { while (b != 0) { int t = b; b = a % b; a = t; } return a; }
        private int ModInverse(int a, int m) { a = a % m; for (int x = 1; x < m; x++) if ((a * x) % m == 1) return x; return -1; }
    }
}