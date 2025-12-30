using System;
using System.IO;
using System.IO.Compression; // Required for DOCX
using System.Xml;            // Required for DOCX
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;    // For Stopwatchs


namespace Enochian_Encryption_System
{
    public partial class FrmPlaintextPrep : Form
    {
        private string _fileContent = "";
        public FrmPlaintextPrep()
        {
            InitializeComponent();
        }

        private void FrmPlaintextPrep_Load(object sender, EventArgs e)
        {
            // STRICT CHECK: Is Step 2 Done?
            if (!GlobalSession.Step2_Done)
            {
                MessageBox.Show("Sequence Error: Step 2 is not finished.", "Access Denied");
                this.Close();
                return;
            }

            // Set Default State
            radManual.Checked = true;
            UpdateUIMode();
        }

        private void radManual_CheckedChanged(object sender, EventArgs e) => UpdateUIMode();
        private void radFile_CheckedChanged(object sender, EventArgs e) => UpdateUIMode();

        private void UpdateUIMode()
        {
            if (radManual.Checked)
            {
                pnlManual.Visible = true;
                pnlFile.Visible = false;
                txtManualInput.Enabled = true; // Unlock manual input
            }
            else
            {
                pnlManual.Visible = false;
                pnlFile.Visible = true;
            }

            // Reset confirmation button to force re-processing if they switch modes
            btnConfirm.Enabled = false;
            txtPreview.Clear();
        }
        private void ToggleInputMode()
        {
            pnlManual.Visible = radManual.Checked;
            pnlFile.Visible = radFile.Checked;
            txtPreview.Clear();
            btnConfirm.Enabled = false;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Text/Word Files (*.txt;*.docx)|*.txt;*.docx";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string ext = Path.GetExtension(ofd.FileName).ToLower();
                    try
                    {
                        if (ext == ".txt")
                        {
                            _fileContent = File.ReadAllText(ofd.FileName);
                        }
                        else if (ext == ".docx")
                        {
                            _fileContent = ReadDocxFile(ofd.FileName);
                        }

                        // VISUAL CONFIRMATION
                        lblFileName.Text = $"Selected: {Path.GetFileName(ofd.FileName)}";
                        lblFileName.ForeColor = System.Drawing.Color.Green;

                        // Debug check to ensure we actually got text
                        if (string.IsNullOrWhiteSpace(_fileContent))
                        {
                            MessageBox.Show("Warning: The file appears to be empty.");
                        }
                        else
                        {
                            MessageBox.Show("File loaded successfully into memory. Click 'Process' next.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading file: " + ex.Message);
                        _fileContent = ""; // Reset on error
                        lblFileName.Text = "Error loading file";
                    }
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            string rawInput = "";

            // EXPLICIT CHECK: Which mode are we in?
            if (radManual.Checked)
            {
                // Mode A: Manual Input
                rawInput = txtManualInput.Text;

                if (string.IsNullOrWhiteSpace(rawInput))
                {
                    MessageBox.Show("Manual Text Box is empty! Please type something.", "Missing Input");
                    return;
                }
            }
            else
            {
                // Mode B: File Input
                rawInput = _fileContent;

                if (string.IsNullOrWhiteSpace(rawInput))
                {
                    MessageBox.Show("No file content loaded! Please click 'Browse File' first.", "Missing Input");
                    return;
                }
            }

            // If we get here, 'rawInput' definitely has data.

            // Convert Numbers -> Words
            string processed = NumberConverter.ProcessText(rawInput);

            // Show Result
            txtPreview.Text = processed;

            // Unlock Next Step
            btnConfirm.Enabled = true;

            sw.Stop();
            GlobalSession.LogEncTime("Step 3: Plaintext Prep", sw.Elapsed.TotalMilliseconds);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPreview.Text))
            {
                MessageBox.Show("Preview is empty. Please click 'Process' first.");
                return;
            }

            

            // Save to Global Session
            GlobalSession.RawInput = radManual.Checked ? txtManualInput.Text : _fileContent;
            GlobalSession.PreProcessedText = txtPreview.Text;

            GlobalSession.Step3_Done = true;
            MessageBox.Show("Plaintext Saved! Proceed to Step 4.");
            this.Close();
        }

        // --- REAL DOCX READER (No External Libraries Needed) ---
        private string ReadDocxFile(string filename)
        {
            try
            {
                using (ZipArchive zip = ZipFile.OpenRead(filename))
                {
                    var entry = zip.GetEntry("word/document.xml");
                    if (entry == null) return "";

                    using (Stream stream = entry.Open())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string xml = reader.ReadToEnd();
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(xml);

                        XmlNodeList textNodes = doc.GetElementsByTagName("w:t");
                        StringBuilder sb = new StringBuilder();
                        foreach (XmlNode node in textNodes) sb.Append(node.InnerText + " ");
                        return sb.ToString().Trim();
                    }
                }
            }
            catch { return ""; }
        }
    }
}
