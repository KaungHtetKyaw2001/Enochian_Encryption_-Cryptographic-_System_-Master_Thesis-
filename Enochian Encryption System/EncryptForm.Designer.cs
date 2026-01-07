namespace Enochian_Encryption_System
{
    partial class EncryptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnGenKeys = new Button();
            groupBox1 = new GroupBox();
            label2 = new Label();
            txtPublicKey = new TextBox();
            groupBox2 = new GroupBox();
            btnKeyValidation = new Button();
            btnTransmission = new Button();
            btnGenDigitalSign = new Button();
            btnPackaging = new Button();
            btnDeckCreation = new Button();
            btnCoreEncryption = new Button();
            btnCardTagging = new Button();
            btnKeyFactorGeneration = new Button();
            btnMatrixAllocation = new Button();
            btnSecondShift = new Button();
            btnMapping = new Button();
            btnFirstShift = new Button();
            btnTextClean = new Button();
            btnTextPrep = new Button();
            btnKeyEncapsulation = new Button();
            btnSessionSetup = new Button();
            groupBox3 = new GroupBox();
            btnFacts = new Button();
            btnEncSteps = new Button();
            groupBox4 = new GroupBox();
            btnAnalyzeSecurity = new Button();
            btnRunBenchmark = new Button();
            btnViewStats = new Button();
            btnBack = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(303, 9);
            label1.Name = "label1";
            label1.Size = new Size(390, 46);
            label1.TabIndex = 0;
            label1.Text = "Start Encrypt your data";
            // 
            // btnGenKeys
            // 
            btnGenKeys.Location = new Point(6, 49);
            btnGenKeys.Name = "btnGenKeys";
            btnGenKeys.Size = new Size(187, 63);
            btnGenKeys.TabIndex = 1;
            btnGenKeys.Text = "Generate Receiver Keys";
            btnGenKeys.UseVisualStyleBackColor = true;
            btnGenKeys.Click += btnGenKeys_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtPublicKey);
            groupBox1.Controls.Add(btnGenKeys);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 75);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(515, 125);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Step 1: Receiver Configuration";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(127, 26);
            label2.Name = "label2";
            label2.Size = new Size(241, 20);
            label2.TabIndex = 3;
            label2.Text = "Share this Public Key with Sender";
            // 
            // txtPublicKey
            // 
            txtPublicKey.Location = new Point(199, 67);
            txtPublicKey.Name = "txtPublicKey";
            txtPublicKey.ReadOnly = true;
            txtPublicKey.Size = new Size(310, 27);
            txtPublicKey.TabIndex = 4;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnKeyValidation);
            groupBox2.Controls.Add(btnTransmission);
            groupBox2.Controls.Add(btnGenDigitalSign);
            groupBox2.Controls.Add(btnPackaging);
            groupBox2.Controls.Add(btnDeckCreation);
            groupBox2.Controls.Add(btnCoreEncryption);
            groupBox2.Controls.Add(btnCardTagging);
            groupBox2.Controls.Add(btnKeyFactorGeneration);
            groupBox2.Controls.Add(btnMatrixAllocation);
            groupBox2.Controls.Add(btnSecondShift);
            groupBox2.Controls.Add(btnMapping);
            groupBox2.Controls.Add(btnFirstShift);
            groupBox2.Controls.Add(btnTextClean);
            groupBox2.Controls.Add(btnTextPrep);
            groupBox2.Controls.Add(btnKeyEncapsulation);
            groupBox2.Controls.Add(btnSessionSetup);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 206);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(985, 468);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Encryption Steps";
            // 
            // btnKeyValidation
            // 
            btnKeyValidation.Location = new Point(223, 263);
            btnKeyValidation.Name = "btnKeyValidation";
            btnKeyValidation.Size = new Size(219, 59);
            btnKeyValidation.TabIndex = 19;
            btnKeyValidation.Text = "Step 10: Key Matrix Validation";
            btnKeyValidation.UseVisualStyleBackColor = true;
            btnKeyValidation.Click += btnKeyValidation_Click;
            // 
            // btnTransmission
            // 
            btnTransmission.Location = new Point(746, 362);
            btnTransmission.Name = "btnTransmission";
            btnTransmission.Size = new Size(219, 59);
            btnTransmission.TabIndex = 18;
            btnTransmission.Text = "Step 16: Transmission";
            btnTransmission.UseVisualStyleBackColor = true;
            btnTransmission.Click += btnTransmission_Click;
            // 
            // btnGenDigitalSign
            // 
            btnGenDigitalSign.Location = new Point(488, 362);
            btnGenDigitalSign.Name = "btnGenDigitalSign";
            btnGenDigitalSign.Size = new Size(219, 59);
            btnGenDigitalSign.TabIndex = 17;
            btnGenDigitalSign.Text = "Step 15: Digital Signature Generation";
            btnGenDigitalSign.UseVisualStyleBackColor = true;
            btnGenDigitalSign.Click += btnGenDigitalSign_Click;
            // 
            // btnPackaging
            // 
            btnPackaging.Location = new Point(223, 362);
            btnPackaging.Name = "btnPackaging";
            btnPackaging.Size = new Size(219, 59);
            btnPackaging.TabIndex = 16;
            btnPackaging.Text = "Step 14: Packaging";
            btnPackaging.UseVisualStyleBackColor = true;
            btnPackaging.Click += btnPackaging_Click;
            // 
            // btnDeckCreation
            // 
            btnDeckCreation.Location = new Point(15, 362);
            btnDeckCreation.Name = "btnDeckCreation";
            btnDeckCreation.Size = new Size(178, 59);
            btnDeckCreation.TabIndex = 15;
            btnDeckCreation.Text = "Step 13: Deck Creation";
            btnDeckCreation.UseVisualStyleBackColor = true;
            btnDeckCreation.Click += btnDeckCreation_Click;
            // 
            // btnCoreEncryption
            // 
            btnCoreEncryption.Location = new Point(488, 263);
            btnCoreEncryption.Name = "btnCoreEncryption";
            btnCoreEncryption.Size = new Size(219, 59);
            btnCoreEncryption.TabIndex = 13;
            btnCoreEncryption.Text = "Step 11: Core Encryption";
            btnCoreEncryption.UseVisualStyleBackColor = true;
            btnCoreEncryption.Click += btnCoreEncryption_Click;
            // 
            // btnCardTagging
            // 
            btnCardTagging.Location = new Point(746, 263);
            btnCardTagging.Name = "btnCardTagging";
            btnCardTagging.Size = new Size(219, 59);
            btnCardTagging.TabIndex = 14;
            btnCardTagging.Text = "Step 12: Card Tagging";
            btnCardTagging.UseVisualStyleBackColor = true;
            btnCardTagging.Click += btnCardTagging_Click;
            // 
            // btnKeyFactorGeneration
            // 
            btnKeyFactorGeneration.Location = new Point(15, 263);
            btnKeyFactorGeneration.Name = "btnKeyFactorGeneration";
            btnKeyFactorGeneration.Size = new Size(178, 59);
            btnKeyFactorGeneration.TabIndex = 12;
            btnKeyFactorGeneration.Text = "Step 9: Key Factor Generation";
            btnKeyFactorGeneration.UseVisualStyleBackColor = true;
            btnKeyFactorGeneration.Click += btnKeyFactorGeneration_Click;
            // 
            // btnMatrixAllocation
            // 
            btnMatrixAllocation.Location = new Point(746, 159);
            btnMatrixAllocation.Name = "btnMatrixAllocation";
            btnMatrixAllocation.Size = new Size(219, 59);
            btnMatrixAllocation.TabIndex = 11;
            btnMatrixAllocation.Text = "Step 8: Matrix Allocation";
            btnMatrixAllocation.UseVisualStyleBackColor = true;
            btnMatrixAllocation.Click += btnMatrixAllocation_Click;
            // 
            // btnSecondShift
            // 
            btnSecondShift.Location = new Point(488, 159);
            btnSecondShift.Name = "btnSecondShift";
            btnSecondShift.Size = new Size(219, 59);
            btnSecondShift.TabIndex = 10;
            btnSecondShift.Text = "Step 7: Second Shift";
            btnSecondShift.UseVisualStyleBackColor = true;
            btnSecondShift.Click += btnSecondShift_Click;
            // 
            // btnMapping
            // 
            btnMapping.Location = new Point(223, 159);
            btnMapping.Name = "btnMapping";
            btnMapping.Size = new Size(219, 59);
            btnMapping.TabIndex = 9;
            btnMapping.Text = "Step 6: Alphabet Mapping (English to Enochian)";
            btnMapping.UseVisualStyleBackColor = true;
            btnMapping.Click += btnMapping_Click;
            // 
            // btnFirstShift
            // 
            btnFirstShift.Location = new Point(15, 159);
            btnFirstShift.Name = "btnFirstShift";
            btnFirstShift.Size = new Size(178, 59);
            btnFirstShift.TabIndex = 8;
            btnFirstShift.Text = "Step 5: First Shift";
            btnFirstShift.UseVisualStyleBackColor = true;
            btnFirstShift.Click += btnFirstShift_Click;
            // 
            // btnTextClean
            // 
            btnTextClean.Location = new Point(746, 42);
            btnTextClean.Name = "btnTextClean";
            btnTextClean.Size = new Size(219, 59);
            btnTextClean.TabIndex = 7;
            btnTextClean.Text = "Step 4: Plaintext Cleaning";
            btnTextClean.UseVisualStyleBackColor = true;
            btnTextClean.Click += btnTextClean_Click;
            // 
            // btnTextPrep
            // 
            btnTextPrep.Location = new Point(488, 42);
            btnTextPrep.Name = "btnTextPrep";
            btnTextPrep.Size = new Size(219, 59);
            btnTextPrep.TabIndex = 6;
            btnTextPrep.Text = "Step 3: Plaintext Preparation";
            btnTextPrep.UseVisualStyleBackColor = true;
            btnTextPrep.Click += btnTextPrep_Click;
            // 
            // btnKeyEncapsulation
            // 
            btnKeyEncapsulation.Location = new Point(223, 42);
            btnKeyEncapsulation.Name = "btnKeyEncapsulation";
            btnKeyEncapsulation.Size = new Size(219, 59);
            btnKeyEncapsulation.TabIndex = 5;
            btnKeyEncapsulation.Text = "Step 2: Key Encapsulation for Header";
            btnKeyEncapsulation.UseVisualStyleBackColor = true;
            btnKeyEncapsulation.Click += btnKeyEncapsulation_Click;
            // 
            // btnSessionSetup
            // 
            btnSessionSetup.Location = new Point(15, 42);
            btnSessionSetup.Name = "btnSessionSetup";
            btnSessionSetup.Size = new Size(178, 59);
            btnSessionSetup.TabIndex = 4;
            btnSessionSetup.Text = "Step 1: Session Setup";
            btnSessionSetup.UseVisualStyleBackColor = true;
            btnSessionSetup.Click += btnSessionSetup_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnFacts);
            groupBox3.Controls.Add(btnEncSteps);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(543, 75);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(454, 125);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Encryption Procedures";
            // 
            // btnFacts
            // 
            btnFacts.Location = new Point(233, 37);
            btnFacts.Name = "btnFacts";
            btnFacts.Size = new Size(201, 59);
            btnFacts.TabIndex = 20;
            btnFacts.Text = "Facts Sender Must Know";
            btnFacts.UseVisualStyleBackColor = true;
            btnFacts.Click += btnFacts_Click;
            // 
            // btnEncSteps
            // 
            btnEncSteps.Location = new Point(29, 37);
            btnEncSteps.Name = "btnEncSteps";
            btnEncSteps.Size = new Size(178, 59);
            btnEncSteps.TabIndex = 19;
            btnEncSteps.Text = "Encryption Procedures";
            btnEncSteps.UseVisualStyleBackColor = true;
            btnEncSteps.Click += btnEncSteps_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnAnalyzeSecurity);
            groupBox4.Controls.Add(btnRunBenchmark);
            groupBox4.Controls.Add(btnViewStats);
            groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox4.Location = new Point(12, 680);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(764, 88);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "View Stats";
            // 
            // btnAnalyzeSecurity
            // 
            btnAnalyzeSecurity.Location = new Point(503, 26);
            btnAnalyzeSecurity.Name = "btnAnalyzeSecurity";
            btnAnalyzeSecurity.Size = new Size(178, 48);
            btnAnalyzeSecurity.TabIndex = 22;
            btnAnalyzeSecurity.Text = "Analyze Security (Entropy)";
            btnAnalyzeSecurity.UseVisualStyleBackColor = true;
            btnAnalyzeSecurity.Click += btnAnalyzeSecurity_Click;
            // 
            // btnRunBenchmark
            // 
            btnRunBenchmark.Location = new Point(291, 26);
            btnRunBenchmark.Name = "btnRunBenchmark";
            btnRunBenchmark.Size = new Size(178, 48);
            btnRunBenchmark.TabIndex = 21;
            btnRunBenchmark.Text = "Run Speed Benchmark";
            btnRunBenchmark.UseVisualStyleBackColor = true;
            btnRunBenchmark.Click += btnRunBenchmark_Click;
            // 
            // btnViewStats
            // 
            btnViewStats.Location = new Point(80, 26);
            btnViewStats.Name = "btnViewStats";
            btnViewStats.Size = new Size(178, 48);
            btnViewStats.TabIndex = 20;
            btnViewStats.Text = "View Stats";
            btnViewStats.UseVisualStyleBackColor = true;
            btnViewStats.Click += btnViewStats_Click;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBack.Location = new Point(819, 706);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(178, 48);
            btnBack.TabIndex = 21;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // EncryptForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 783);
            Controls.Add(btnBack);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "EncryptForm";
            Text = "Encrypt Form";
            Load += EncryptForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnGenKeys;
        private GroupBox groupBox1;
        private TextBox txtPublicKey;
        private GroupBox groupBox2;
        private Button btnSessionSetup;
        private Button btnFirstShift;
        private Button btnTextClean;
        private Button btnTextPrep;
        private Button btnKeyEncapsulation;
        private Button btnKeyFactorGeneration;
        private Button btnMatrixAllocation;
        private Button btnSecondShift;
        private Button btnMapping;
        private Button btnCoreEncryption;
        private Button btnPackaging;
        private Button btnDeckCreation;
        private Button btnCardTagging;
        private Button btnTransmission;
        private Button btnGenDigitalSign;
        private GroupBox groupBox3;
        private Button btnFacts;
        private Button btnEncSteps;
        private Label label2;
        private GroupBox groupBox4;
        private Button btnViewStats;
        private Button btnKeyValidation;
        private Button btnBack;
        private Button btnAnalyzeSecurity;
        private Button btnRunBenchmark;
    }
}