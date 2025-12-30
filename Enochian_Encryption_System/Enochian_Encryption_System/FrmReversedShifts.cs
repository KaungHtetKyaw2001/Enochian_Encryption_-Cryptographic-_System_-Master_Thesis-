using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Enochian_Encryption_System
{
    public partial class FrmReversedShifts : Form
    {
        private const string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private readonly string[] EnochianSyllables = {
            "PA",   "VEH",  "GED",  "GAL",  "OR",   "UN",   "GRAPH",
            "TAL",  "GON",  "NA",   "UR",   "MALS", "GER",  "DRUX",
            "PAL",  "MED",  "DON",  "CEPH", "VAN",  "FAM",  "GISG"
        };

        public FrmReversedShifts()
        {
            InitializeComponent();
        }

        private void FrmReversedShifts_Load(object sender, EventArgs e)
        {
            if (!GlobalSession.DecStep5_Done || GlobalSession.KeyMatrix == null)
            {
                MessageBox.Show("Please complete Step 5 (Matrix Regeneration) first.", "Pipeline Error");
            }

            // 1. RESTORE SHIFTS & MARKERS FROM PAYLOAD
            int c1 = 0;
            int c2 = 0;

            if (GlobalSession.FinalPayload != null)
            {
                c1 = GlobalSession.FinalPayload.ShiftC1;
                c2 = GlobalSession.FinalPayload.ShiftC2;

                // [FIX] Restore Markers for correct mapping (C/K, G/J, etc.)
                if (GlobalSession.FinalPayload.MarkerData != null)
                {
                    GlobalSession.MarkerMatrices = new List<string[,]>();
                    foreach (var sm in GlobalSession.FinalPayload.MarkerData)
                        GlobalSession.MarkerMatrices.Add(sm.ToMatrix());
                }
            }

            // Fallback to active session
            if (c1 == 0) c1 = GlobalSession.C1;
            if (c2 == 0) c2 = GlobalSession.C2;

            GlobalSession.C1 = c1;
            GlobalSession.C2 = c2;

            lblC1.Text = $"C1 Shift (Inner): {c1}";
            lblC2.Text = $"C2 Shift (Outer): {c2}";

            if (c1 == 0 || c2 == 0)
                lblStatus.Text = "Warning: Shifts are 0!";
            else
                lblStatus.Text = "Ready to Reverse...";
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                int c1 = GlobalSession.C1;
                int c2 = GlobalSession.C2;

                // =========================================================
                // 1. FLATTEN MATRICES & MARKERS (Step 5 Output)
                // =========================================================
                List<int> rawNumbers = new List<int>();
                List<string> rawMarkers = new List<string>(); // Store "!", "@", "#"

                if (GlobalSession.PlaintextMatrices != null)
                {
                    // Assuming PlaintextMatrices and MarkerMatrices are aligned
                    for (int i = 0; i < GlobalSession.PlaintextMatrices.Count; i++)
                    {
                        int[,] numMat = GlobalSession.PlaintextMatrices[i];
                        string[,] markMat = (GlobalSession.MarkerMatrices != null && i < GlobalSession.MarkerMatrices.Count)
                                            ? GlobalSession.MarkerMatrices[i] : null;

                        int rows = numMat.GetLength(0);
                        int cols = numMat.GetLength(1);

                        for (int r = 0; r < rows; r++)
                        {
                            for (int c = 0; c < cols; c++)
                            {
                                int val = numMat[r, c];
                                if (val < 1) val = 1; if (val > 21) val = 21;
                                rawNumbers.Add(val);

                                // Use saved marker or default to '!'
                                string m = (markMat != null) ? markMat[r, c] : "!";
                                rawMarkers.Add(m);
                            }
                        }
                    }
                }

                // =========================================================
                // 2. CONVERT TO ENOCHIAN SYLLABLES (Display)
                // =========================================================
                StringBuilder sbEnochianList = new StringBuilder();
                StringBuilder sbArrayFormat = new StringBuilder();

                for (int i = 0; i < rawNumbers.Count; i++)
                {
                    int val = rawNumbers[i];
                    string mark = rawMarkers[i];

                    // Reconstruct original syllable with correct marker (e.g. VEH@)
                    string syllable = EnochianSyllables[val - 1] + mark;

                    sbEnochianList.Append(syllable + " ");
                    sbArrayFormat.Append($"'{syllable}', ");
                }

                txtConvertingNumberMatrixtoEnochianAlphabetsMatrix.Text = sbEnochianList.ToString().Trim();
                txtAddtoArray.Text = sbArrayFormat.ToString().TrimEnd(',', ' ');

                // =========================================================
                // 3. REVERSE C2 SHIFT (Enochian Domain)
                // =========================================================
                List<int> unshiftedC2Indices = new List<int>();
                StringBuilder sbReverseC2 = new StringBuilder();

                for (int i = 0; i < rawNumbers.Count; i++)
                {
                    int val = rawNumbers[i];
                    string mark = rawMarkers[i];

                    // Formula: (Value - 1 - C2) wrap 21
                    int currentIdx = val - 1;
                    int newIdx = (currentIdx - c2) % 21;
                    if (newIdx < 0) newIdx += 21;

                    unshiftedC2Indices.Add(newIdx + 1);

                    // Markers persist through shift
                    string syb = EnochianSyllables[newIdx] + mark;
                    sbReverseC2.Append(syb + " ");
                }

                txtFirstUnshiftC2.Text = sbReverseC2.ToString().Trim();

                // =========================================================
                // 4. REMAP TO ENGLISH (Using Markers for Variants)
                // =========================================================
                StringBuilder sbEnglishMap = new StringBuilder();

                for (int i = 0; i < unshiftedC2Indices.Count; i++)
                {
                    int val = unshiftedC2Indices[i];
                    string mark = rawMarkers[i];

                    // [FIX] Use specific mapping logic
                    sbEnglishMap.Append(GetEnglishChar(val, mark));
                }

                string intermediateString = sbEnglishMap.ToString();
                txtEnglishRemapping.Text = intermediateString;

                // =========================================================
                // 5. REVERSE C1 SHIFT (English Domain)
                // =========================================================
                StringBuilder sbFinalRaw = new StringBuilder();

                foreach (char c in intermediateString)
                {
                    int oldIdx = EnglishAlphabet.IndexOf(c);
                    if (oldIdx != -1)
                    {
                        // Formula: (Index - C1) wrap 26
                        int newIdx = (oldIdx - c1) % 26;
                        if (newIdx < 0) newIdx += 26;
                        sbFinalRaw.Append(EnglishAlphabet[newIdx]);
                    }
                    else
                    {
                        sbFinalRaw.Append(c);
                    }
                }

                string rawResult = sbFinalRaw.ToString();
                txtSecondUnshiftC1.Text = rawResult;

                // =========================================================
                // 6. SYMBOL RESTORATION (Depadding)
                // =========================================================
                string finalClean = rawResult;
                if (finalClean.Length > 0)
                {
                    char lastChar = finalClean[finalClean.Length - 1];
                    finalClean = finalClean.TrimEnd(lastChar);
                }

                txtEnglishRemapping.Text = finalClean; // Update UI to show final

                GlobalSession.DecryptedText = finalClean;
                GlobalSession.DecStep7_Done = true;

                lblStatus.Text = "Success: Decrypted.";
                lblStatus.ForeColor = System.Drawing.Color.Green;
                btnConfirm.Enabled = true;

                sw.Stop();
                GlobalSession.LogDecTime("Step 7: Reverse Shifts", sw.Elapsed.TotalMilliseconds);

                MessageBox.Show($"Decryption Complete!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // [FIXED] Mapping Helper Handles ! @ #
        private char GetEnglishChar(int val, string marker)
        {
            // Primary mapping (Default / '!')
            if (marker == "!" || string.IsNullOrEmpty(marker))
            {
                switch (val)
                {
                    case 1: return 'B';
                    case 2: return 'C';
                    case 3: return 'G';
                    case 4: return 'D';
                    case 5: return 'F';
                    case 6: return 'A';
                    case 7: return 'E';
                    case 8: return 'M';
                    case 9: return 'I';
                    case 10: return 'H';
                    case 11: return 'L';
                    case 12: return 'P';
                    case 13: return 'Q';
                    case 14: return 'N';
                    case 15: return 'X';
                    case 16: return 'O';
                    case 17: return 'R';
                    case 18: return 'Z';
                    case 19: return 'U';
                    case 20: return 'S';
                    case 21: return 'T';
                    default: return '?';
                }
            }
            // Secondary mapping ('@')
            else if (marker == "@")
            {
                if (val == 2) return 'K'; // VEH@ -> K
                if (val == 3) return 'J'; // GED@ -> J
                if (val == 9) return 'Y'; // GON@ -> Y
                if (val == 19) return 'V'; // VAN@ -> V
                // Add other secondary mappings if they exist in your logic
                return GetEnglishChar(val, "!"); // Fallback
            }
            // Tertiary mapping ('#')
            else if (marker == "#")
            {
                if (val == 19) return 'W'; // VAN# -> W
                return GetEnglishChar(val, "!"); // Fallback
            }
            return '?';
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}