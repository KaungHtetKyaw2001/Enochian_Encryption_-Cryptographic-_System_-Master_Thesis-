using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Enochian_Encryption_System
{
    public partial class FrmFinalization : Form
    {
        public FrmFinalization()
        {
            InitializeComponent();
        }

        private void FrmFinalization_Load(object sender, EventArgs e)
        {
            if (!GlobalSession.DecStep7_Done)
            {
                // Optional warning
                // MessageBox.Show("Please complete Step 7 (Reversed Shifts) first.");
            }

            lblStatus.Text = "Ready to finalize...";
            txtCleanedInput.Text = GlobalSession.DecryptedText;
        }

        private void btnFinalize_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                // STAGE 1: RETRIEVE DATA
                string decryptedText = GlobalSession.DecryptedText;

                // [FIX] Priority: Load from Payload -> Fallback to Session
                List<CharMarker> specialChars = null;

                if (GlobalSession.FinalPayload != null && GlobalSession.FinalPayload.FormattingData != null)
                {
                    specialChars = GlobalSession.FinalPayload.FormattingData;
                }
                else
                {
                    specialChars = GlobalSession.RemovedSpecialChars ?? new List<CharMarker>();
                }

                if (string.IsNullOrEmpty(decryptedText))
                    throw new Exception("No decrypted text found from Step 7.");

                string finalOutputString = "";

                // STAGE 2: RESTORE SPECIAL CHARACTERS
                if (specialChars.Count > 0)
                {
                    int totalLength = decryptedText.Length + specialChars.Count;
                    char[] resultArray = new char[totalLength];

                    Queue<char> cleanQueue = new Queue<char>(decryptedText.ToCharArray());

                    Dictionary<int, char> specialMap = new Dictionary<int, char>();
                    foreach (var marker in specialChars)
                    {
                        if (!specialMap.ContainsKey(marker.Index))
                            specialMap.Add(marker.Index, marker.Character);
                    }

                    for (int i = 0; i < totalLength; i++)
                    {
                        if (specialMap.ContainsKey(i))
                        {
                            resultArray[i] = specialMap[i];
                        }
                        else
                        {
                            if (cleanQueue.Count > 0)
                                resultArray[i] = cleanQueue.Dequeue();
                            else
                                resultArray[i] = ' ';
                        }
                    }
                    finalOutputString = new string(resultArray);
                }
                else
                {
                    // Fallback
                    finalOutputString = decryptedText;
                    lblStatus.Text = "Note: No formatting data found.";
                }

                // STAGE 3: FORMATTING
                string formattedOutput = ApplySentenceCase(finalOutputString);

                sw.Stop();
                GlobalSession.LogDecTime("Step 8: Finalization", sw.Elapsed.TotalMilliseconds);

                // OUTPUT
                txtFinalResult.Text = formattedOutput;
                lblStatus.Text = "Decryption Complete";
                lblStatus.ForeColor = Color.Green;

                btnSave.Enabled = true;
                GlobalSession.DecStep8_Done = true;

                MessageBox.Show($"ORIGINAL MESSAGE RESTORED!\n\n" +
                    $"Restored {specialChars.Count} formatting characters.\n" +
                    $"Final Length: {formattedOutput.Length}");
            }
            catch (Exception ex)
            {
                sw.Stop();
                MessageBox.Show("Finalization Error: " + ex.Message);
            }
        }

        private string ApplySentenceCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            char[] chars = input.ToLower().ToCharArray();
            bool newSentence = true;

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '.' || chars[i] == '!' || chars[i] == '?')
                    newSentence = true;
                else if (char.IsLetter(chars[i]) && newSentence)
                {
                    chars[i] = char.ToUpper(chars[i]);
                    newSentence = false;
                }
            }
            return new string(chars);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text File (*.txt)|*.txt";
                sfd.FileName = $"Decrypted_Message_{DateTime.Now:yyyyMMdd_HHmm}.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, txtFinalResult.Text);
                    MessageBox.Show("File Saved Successfully.");
                    GlobalSession.DecStep8_Done = true;
                    this.Close();
                }
            }
        }
    }
}