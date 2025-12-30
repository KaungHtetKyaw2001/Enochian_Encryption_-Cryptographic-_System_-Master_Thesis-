using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Enochian_Encryption_System
{
    public partial class FrmTransmission : Form
    {
        public FrmTransmission()
        {
            InitializeComponent();
        }

        private void FrmTransmission_Load(object sender, EventArgs e)
        {
            if (!GlobalSession.Step15_Done)
            {
                MessageBox.Show("Sequence Error: Step 15 (Digital Signature) is not complete.", "Access Denied");
                this.Close();
                return;
            }

            lblHeaderStatus.Text = $"Header ID: {GlobalSession.SignatureTargetHash} (Locked)";
            lblDeckStatus.Text = $"Payload: {GlobalSession.ShuffledDeck?.Count ?? 0} Matrix Cards (Shuffled)";
            string sig = GlobalSession.FinalPayload?.DigitalSignatureString ?? "PENDING";
            lblSigStatus.Text = $"Signature: {sig} (Attached)";
            txtChecksum.Text = GlobalSession.SignatureTargetHash.ToString();
            lblFileStatus.Text = "Ready for Export";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            btnExport.Enabled = false;
            lstLog.Items.Clear();

            try
            {
                AddLog("Initializing Secure Export Protocol...");

                // 1. Prepare Deck
                List<SerializableMatrix> safeDeck = new List<SerializableMatrix>();
                if (GlobalSession.ShuffledDeck != null)
                {
                    foreach (int[,] matrix in GlobalSession.ShuffledDeck)
                    {
                        safeDeck.Add(new SerializableMatrix(matrix));
                    }
                }

                // [CRITICAL FIX] LOAD CORRECT KEYS & DATA
                var payloadSrc = GlobalSession.FinalPayload;

                // 1. Receiver Keys
                int[] recPrivKey = payloadSrc?.ReceiverPrivateVector ?? GlobalSession.ReceiverPrivateVector;
                int recMod = payloadSrc?.ReceiverModulus > 0 ? payloadSrc.ReceiverModulus : GlobalSession.ReceiverModulus;
                int recMult = payloadSrc?.ReceiverMultiplier > 0 ? payloadSrc.ReceiverMultiplier : GlobalSession.ReceiverMultiplier;

                // 2. Sender Keys
                int[] sendPubKey = payloadSrc?.SenderPublicVector ?? GlobalSession.SenderPublicVector;
                int sendMod = payloadSrc?.SenderModulus > 0 ? payloadSrc.SenderModulus : GlobalSession.SenderModulus;
                int sendMult = payloadSrc?.SenderMultiplier > 0 ? payloadSrc.SenderMultiplier : GlobalSession.SenderMultiplier;

                // 3. Shift Values
                int sC1 = payloadSrc != null && payloadSrc.ShiftC1 != 0 ? payloadSrc.ShiftC1 : GlobalSession.C1;
                int sC2 = payloadSrc != null && payloadSrc.ShiftC2 != 0 ? payloadSrc.ShiftC2 : GlobalSession.C2;

                // 4. Marker Data
                List<SerializableStringMatrix> markerData = payloadSrc?.MarkerData;
                if (markerData == null && GlobalSession.MarkerMatrices != null)
                {
                    markerData = new List<SerializableStringMatrix>();
                    foreach (var mat in GlobalSession.MarkerMatrices)
                        markerData.Add(new SerializableStringMatrix(mat));
                }

                // 5. [FIXED] Formatting Data (Spaces & Punctuation)
                // We must explicitly grab this list, or spaces will be lost!
                List<CharMarker> fmtData = payloadSrc?.FormattingData;
                if (fmtData == null)
                {
                    // Fallback to active session if fresh encryption
                    fmtData = GlobalSession.RemovedSpecialChars ?? new List<CharMarker>();
                }

                // BUILD FINAL PACKAGE
                EnochianPayload package = new EnochianPayload
                {
                    MagicNumber = "ENOCHIAN_SECURE_V1",
                    Timestamp = DateTime.Now,
                    SenderID = txtSenderName.Text,
                    FileType = "ENOCHIAN_XML",
                    SessionVector = GlobalSession.SessionVector ?? payloadSrc?.SessionVector,
                    MatrixSize = GlobalSession.MatrixSize,
                    TargetHashID = GlobalSession.SignatureTargetHash,
                    IterationCount = GlobalSession.LorentzIterations,
                    ReferenceHashList = GlobalSession.ReferenceHashList,

                    ShuffledDeck = safeDeck,
                    ShuffledTags = GlobalSession.ShuffledTags,

                    // [INCLUDED] Essential Restoration Data
                    MarkerData = markerData,
                    ShiftC1 = sC1,
                    ShiftC2 = sC2,
                    FormattingData = fmtData, // <--- This was missing!

                    DigitalSignatureString = payloadSrc?.DigitalSignatureString ?? "[UNSIGNED]",
                    PackageChecksum = GlobalSession.SignatureTargetHash.ToString(),
                    FinalPackageHash = GlobalSession.SignatureTargetHash.ToString(),

                    // KEYS
                    ReceiverPrivateVector = recPrivKey,
                    ReceiverModulus = recMod,
                    ReceiverMultiplier = recMult,

                    SenderPublicVector = sendPubKey,
                    SenderModulus = sendMod,
                    SenderMultiplier = sendMult,

                    LorentzInt1 = GlobalSession.LorentzInt1,
                    LorentzInt2 = GlobalSession.LorentzInt2,
                    LorentzInt3 = GlobalSession.LorentzInt3
                };

                AddLog($"Package ID Verified: {package.TargetHashID}");
                AddLog($"Formatting Chars Saved: {package.FormattingData?.Count ?? 0}"); // Verification Log

                if (recPrivKey == null)
                    AddLog("WARNING: Private Key is MISSING in export!");
                else
                    AddLog("Secure Key Embedded.");

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Enochian Encrypted Package (*.enc)|*.enc";
                sfd.FileName = $"SECURE_PACKAGE_{DateTime.Now:HHmm}.enc";
                sfd.Title = "Export Encrypted File";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    XmlSerializer xs = new XmlSerializer(typeof(EnochianPayload));
                    using (StreamWriter writer = new StreamWriter(sfd.FileName))
                    {
                        xs.Serialize(writer, package);
                    }

                    AddLog($"Export Successful in {sw.Elapsed.TotalMilliseconds:F4} ms");

                    txtFilePath.Text = sfd.FileName;
                    lblFileStatus.Text = "Export Complete";

                    sw.Stop();
                    GlobalSession.LogEncTime("Step 16: Secure Transmission", sw.Elapsed.TotalMilliseconds);

                    MessageBox.Show($"Secure Transmission File Generated!\n\n" +
                        $"Location: {sfd.FileName}\n\n" +
                        $"Formatting Data: {package.FormattingData.Count} items preserved.\n" +
                        "The Receiver's Private Key has been successfully embedded.",
                        "Transmission Complete");

                    GlobalSession.Step16_Done = true;
                    this.Close();
                }
                else
                {
                    sw.Stop();
                    btnExport.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                sw.Stop();
                MessageBox.Show("Export Error: " + ex.Message);
                btnExport.Enabled = true;
            }
        }

        private void AddLog(string msg)
        {
            lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] {msg}");
            lstLog.TopIndex = lstLog.Items.Count - 1;
        }
    }
}