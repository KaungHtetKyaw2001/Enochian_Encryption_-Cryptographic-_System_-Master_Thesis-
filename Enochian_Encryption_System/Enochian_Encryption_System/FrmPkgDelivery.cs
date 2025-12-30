using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Enochian_Encryption_System
{
    public partial class FrmPkgDelivery : Form
    {
        private EnochianPayload _loadedPayload;
        public FrmPkgDelivery() { InitializeComponent(); }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Enochian Encrypted Package (*.enc)|*.enc";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    try
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(EnochianPayload));
                        using (StreamReader reader = new StreamReader(ofd.FileName))
                        {
                            _loadedPayload = (EnochianPayload)xs.Deserialize(reader);
                            rtbPreview.Text = File.ReadAllText(ofd.FileName);
                        }

                        if (_loadedPayload.MagicNumber != "ENOCHIAN_SECURE_V1") throw new Exception("Invalid File.");

                        txtSenderID.Text = _loadedPayload.SenderID;
                        txtTimestamp.Text = _loadedPayload.Timestamp.ToString();
                        txtChecksum.Text = _loadedPayload.PackageChecksum;
                        lblStatus.Text = "PACKAGE VALIDATED";
                        lblStatus.ForeColor = Color.Green;

                        // 1. Load Matrix Data
                        GlobalSession.ShuffledDeck = new List<int[,]>();
                        foreach (var wrapper in _loadedPayload.ShuffledDeck)
                            GlobalSession.ShuffledDeck.Add(wrapper.ToMatrix());

                        // 2. Load Tag Data
                        GlobalSession.ShuffledTags = _loadedPayload.ShuffledTags;

                        // [CRITICAL FIX] LOAD THE REFERENCE LIST (MANIFEST)
                        // This is required for Step 4 (Sorting) to know the original order.
                        GlobalSession.ReferenceHashList = _loadedPayload.ReferenceHashList;

                        // 3. Load Metadata
                        GlobalSession.MatrixSize = _loadedPayload.MatrixSize;
                        GlobalSession.LorentzIterations = _loadedPayload.IterationCount;
                        GlobalSession.SignatureTargetHash = _loadedPayload.TargetHashID;
                        GlobalSession.FinalPayload = _loadedPayload;

                        // 4. Load Decryption Keys
                        GlobalSession.SenderModulus = _loadedPayload.SenderModulus;
                        GlobalSession.SenderMultiplier = _loadedPayload.SenderMultiplier;
                        GlobalSession.LorentzInt1 = _loadedPayload.LorentzInt1;
                        GlobalSession.LorentzInt2 = _loadedPayload.LorentzInt2;

                        if (_loadedPayload.SenderPublicVector != null && _loadedPayload.SenderPublicVector.Length == 3)
                            GlobalSession.SenderPrivateVector = _loadedPayload.SenderPublicVector;
                        else
                            GlobalSession.SenderPrivateVector = new int[] { 0, 0, 0 }; // Legacy fallback

                        sw.Stop();
                        GlobalSession.LogDecTime("Decryption Step 1: Package Delivery", sw.Elapsed.TotalMilliseconds);

                        MessageBox.Show($"Package Loaded Successfully!\nReference Tags: {GlobalSession.ReferenceHashList?.Count ?? 0}");
                        btnConfirm.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e) { GlobalSession.DecStep1_Done = true; this.Close(); }
    }
}