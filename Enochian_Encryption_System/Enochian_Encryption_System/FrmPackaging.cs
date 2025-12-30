using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Enochian_Encryption_System
{
    public partial class FrmPackaging : Form
    {
        private EnochianPayload _finalPayload;

        public FrmPackaging() { InitializeComponent(); }

        private void FrmPackaging_Load(object sender, EventArgs e)
        {
            if (!GlobalSession.Step13_Done)
            {
                MessageBox.Show("Please complete Step 13 (Deck Creation) first.", "Access Denied");
                this.Close();
                return;
            }
            int deckCount = GlobalSession.ShuffledDeck != null ? GlobalSession.ShuffledDeck.Count : 0;
            int tagCount = GlobalSession.ShuffledTags != null ? GlobalSession.ShuffledTags.Count : 0;

            lblTagCount.Text = $"Number of tags: {tagCount} Integrity Tags Generated";
            lblHeader.Text = $"Header ID: {GlobalSession.EncryptedHeader}";
            lblDeckCount.Text = $"Deck Content: {deckCount} Blocks";
            txtSenderID.Text = "Thesis_Demo_User";
        }

        private void btnAssemble_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            try
            {
                // 1. Convert Integer Matrices
                List<SerializableMatrix> safeDeck = new List<SerializableMatrix>();
                if (GlobalSession.ShuffledDeck != null)
                {
                    foreach (int[,] matrix in GlobalSession.ShuffledDeck)
                        safeDeck.Add(new SerializableMatrix(matrix));
                }

                // 2. Convert Marker Matrices (Strings)
                List<SerializableStringMatrix> safeMarkers = new List<SerializableStringMatrix>();
                if (GlobalSession.MarkerMatrices != null)
                {
                    foreach (string[,] matrix in GlobalSession.MarkerMatrices)
                        safeMarkers.Add(new SerializableStringMatrix(matrix));
                }

                _finalPayload = new EnochianPayload
                {
                    MagicNumber = "ENOCHIAN_SECURE_V1",
                    Timestamp = DateTime.Now,
                    SenderID = txtSenderID.Text,
                    FileType = "ENOCHIAN_XML",
                    SessionVector = GlobalSession.SessionVector ?? new int[0],
                    MatrixSize = GlobalSession.MatrixSize,
                    TargetHashID = GlobalSession.EncryptedHeader,

                    ShuffledDeck = safeDeck,
                    MarkerData = safeMarkers,
                    ShuffledTags = GlobalSession.ShuffledTags ?? new List<string>(),

                    ShiftC1 = GlobalSession.C1,
                    ShiftC2 = GlobalSession.C2,

                    // [FIXED] Now this field exists in the class definition above
                    FormattingData = GlobalSession.RemovedSpecialChars ?? new List<CharMarker>(),

                    ReceiverPrivateVector = GlobalSession.ReceiverPrivateVector,
                    ReceiverModulus = GlobalSession.ReceiverModulus,
                    ReceiverMultiplier = GlobalSession.ReceiverMultiplier,

                    SenderPublicVector = GlobalSession.SenderPublicVector,
                    SenderModulus = GlobalSession.SenderModulus,
                    SenderMultiplier = GlobalSession.SenderMultiplier,

                    LorentzInt1 = GlobalSession.LorentzInt1,
                    LorentzInt2 = GlobalSession.LorentzInt2,
                    LorentzInt3 = GlobalSession.LorentzInt3,
                    DigitalSignatureString = "[PENDING]",
                    PackageChecksum = "CHECKING..."
                };

                // Generate XML Preview
                XmlSerializer xs = new XmlSerializer(typeof(EnochianPayload));
                using (StringWriter writer = new StringWriter())
                {
                    xs.Serialize(writer, _finalPayload);
                    txtPreview.Text = writer.ToString();
                }

                GlobalSession.SignatureTargetHash = GlobalSession.EncryptedHeader;
                GlobalSession.FinalPayload = _finalPayload;
                GlobalSession.Step14_Done = true;

                sw.Stop();
                GlobalSession.LogEncTime("Step 14: Packaging", sw.Elapsed.TotalMilliseconds);

                // Confirm formatting data count
                int fmtCount = _finalPayload.FormattingData != null ? _finalPayload.FormattingData.Count : 0;

                MessageBox.Show($"Packaging Complete!\n\n" +
                                $"Payload: {safeDeck.Count} Matrices\n" +
                                $"Markers: {safeMarkers.Count} Maps\n" +
                                $"Formatting: {fmtCount} Chars Saved\n" +
                                $"Time: {sw.Elapsed.TotalMilliseconds:F4} ms");
            }
            catch (Exception ex)
            {
                sw.Stop();
                MessageBox.Show("Packaging Error: " + ex.Message);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e) { this.Close(); }
    }
}