namespace Enochian_Encryption_System
{
    partial class DecryptForm
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
            groupBox1 = new GroupBox();
            btnFinalization = new Button();
            btnReverseShifts = new Button();
            btnCoreDecryption = new Button();
            btnRegeneration = new Button();
            btnSortingandSearching = new Button();
            btnDecapsulation = new Button();
            btnSignatureVerification = new Button();
            btnPackageDelivery = new Button();
            groupBox2 = new GroupBox();
            btnVerifySecurity = new Button();
            btnRunBenchmark = new Button();
            btnViewStats = new Button();
            btnBack = new Button();
            btnVerifyIntegrity = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.Location = new Point(198, 9);
            label1.Name = "label1";
            label1.Size = new Size(389, 57);
            label1.TabIndex = 1;
            label1.Text = "Decrypt Your Data";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnFinalization);
            groupBox1.Controls.Add(btnReverseShifts);
            groupBox1.Controls.Add(btnCoreDecryption);
            groupBox1.Controls.Add(btnRegeneration);
            groupBox1.Controls.Add(btnSortingandSearching);
            groupBox1.Controls.Add(btnDecapsulation);
            groupBox1.Controls.Add(btnSignatureVerification);
            groupBox1.Controls.Add(btnPackageDelivery);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 81);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(844, 253);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Decryption Steps";
            // 
            // btnFinalization
            // 
            btnFinalization.Location = new Point(630, 131);
            btnFinalization.Name = "btnFinalization";
            btnFinalization.Size = new Size(188, 93);
            btnFinalization.TabIndex = 7;
            btnFinalization.Text = "Step 8: Finalization";
            btnFinalization.UseVisualStyleBackColor = true;
            btnFinalization.Click += btnFinalization_Click;
            // 
            // btnReverseShifts
            // 
            btnReverseShifts.Location = new Point(423, 131);
            btnReverseShifts.Name = "btnReverseShifts";
            btnReverseShifts.Size = new Size(178, 93);
            btnReverseShifts.TabIndex = 6;
            btnReverseShifts.Text = "Step 7: Reversed Shifts";
            btnReverseShifts.UseVisualStyleBackColor = true;
            btnReverseShifts.Click += btnReverseShifts_Click;
            // 
            // btnCoreDecryption
            // 
            btnCoreDecryption.Location = new Point(210, 131);
            btnCoreDecryption.Name = "btnCoreDecryption";
            btnCoreDecryption.Size = new Size(182, 94);
            btnCoreDecryption.TabIndex = 5;
            btnCoreDecryption.Text = "Step 6: Core Decryption";
            btnCoreDecryption.UseVisualStyleBackColor = true;
            btnCoreDecryption.Click += btnCoreDecryption_Click;
            // 
            // btnRegeneration
            // 
            btnRegeneration.Location = new Point(19, 131);
            btnRegeneration.Name = "btnRegeneration";
            btnRegeneration.Size = new Size(171, 94);
            btnRegeneration.TabIndex = 4;
            btnRegeneration.Text = "Step 5: Regeneration (Reuse) Given by Sender's Encrypt Infomation";
            btnRegeneration.UseVisualStyleBackColor = true;
            btnRegeneration.Click += btnRegeneration_Click;
            // 
            // btnSortingandSearching
            // 
            btnSortingandSearching.Location = new Point(630, 37);
            btnSortingandSearching.Name = "btnSortingandSearching";
            btnSortingandSearching.Size = new Size(188, 62);
            btnSortingandSearching.TabIndex = 3;
            btnSortingandSearching.Text = "Step 4: Sorting and Searching";
            btnSortingandSearching.UseVisualStyleBackColor = true;
            btnSortingandSearching.Click += btnSortingandSearching_Click;
            // 
            // btnDecapsulation
            // 
            btnDecapsulation.Location = new Point(415, 37);
            btnDecapsulation.Name = "btnDecapsulation";
            btnDecapsulation.Size = new Size(186, 62);
            btnDecapsulation.TabIndex = 2;
            btnDecapsulation.Text = "Step 3: Decapsulation";
            btnDecapsulation.UseVisualStyleBackColor = true;
            btnDecapsulation.Click += btnDecapsulation_Click;
            // 
            // btnSignatureVerification
            // 
            btnSignatureVerification.Location = new Point(210, 37);
            btnSignatureVerification.Name = "btnSignatureVerification";
            btnSignatureVerification.Size = new Size(182, 62);
            btnSignatureVerification.TabIndex = 1;
            btnSignatureVerification.Text = "Step 2: Signature Verification";
            btnSignatureVerification.UseVisualStyleBackColor = true;
            btnSignatureVerification.Click += btnSignatureVerification_Click;
            // 
            // btnPackageDelivery
            // 
            btnPackageDelivery.Location = new Point(19, 37);
            btnPackageDelivery.Name = "btnPackageDelivery";
            btnPackageDelivery.Size = new Size(171, 62);
            btnPackageDelivery.TabIndex = 0;
            btnPackageDelivery.Text = "Step 1: Package Delivery";
            btnPackageDelivery.UseVisualStyleBackColor = true;
            btnPackageDelivery.Click += btnPackageDelivery_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnVerifyIntegrity);
            groupBox2.Controls.Add(btnVerifySecurity);
            groupBox2.Controls.Add(btnRunBenchmark);
            groupBox2.Controls.Add(btnViewStats);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 340);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(690, 109);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "View Decryption Stats";
            // 
            // btnVerifySecurity
            // 
            btnVerifySecurity.Location = new Point(0, 0);
            btnVerifySecurity.Name = "btnVerifySecurity";
            btnVerifySecurity.Size = new Size(75, 23);
            btnVerifySecurity.TabIndex = 0;
            // 
            // btnRunBenchmark
            // 
            btnRunBenchmark.Location = new Point(247, 41);
            btnRunBenchmark.Name = "btnRunBenchmark";
            btnRunBenchmark.Size = new Size(194, 51);
            btnRunBenchmark.TabIndex = 1;
            btnRunBenchmark.Text = "Run Speed Benchmark";
            btnRunBenchmark.UseVisualStyleBackColor = true;
            btnRunBenchmark.Click += btnRunBenchmark_Click;
            // 
            // btnViewStats
            // 
            btnViewStats.Location = new Point(19, 41);
            btnViewStats.Name = "btnViewStats";
            btnViewStats.Size = new Size(194, 51);
            btnViewStats.TabIndex = 0;
            btnViewStats.Text = "View Decryption Stats";
            btnViewStats.UseVisualStyleBackColor = true;
            btnViewStats.Click += btnViewStats_Click;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBack.Location = new Point(708, 381);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(148, 51);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnVerifyIntegrity
            // 
            btnVerifyIntegrity.Location = new Point(472, 41);
            btnVerifyIntegrity.Name = "btnVerifyIntegrity";
            btnVerifyIntegrity.Size = new Size(194, 51);
            btnVerifyIntegrity.TabIndex = 2;
            btnVerifyIntegrity.Text = "Verify Integrity (CIA)";
            btnVerifyIntegrity.UseVisualStyleBackColor = true;
            btnVerifyIntegrity.Click += btnVerifyIntegrity_Click_1;
            // 
            // DecryptForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 461);
            Controls.Add(btnBack);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "DecryptForm";
            Text = "Decrypt Form";
            Load += DecryptForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private GroupBox groupBox1;
        private Button btnFinalization;
        private Button btnReverseShifts;
        private Button btnCoreDecryption;
        private Button btnRegeneration;
        private Button btnSortingandSearching;
        private Button btnDecapsulation;
        private Button btnSignatureVerification;
        private Button btnPackageDelivery;
        private GroupBox groupBox2;
        private Button btnViewStats;
        private Button btnBack;
        private Button btnVerifySecurity;
        private Button btnRunBenchmark;
        private Button btnVerifyIntegrity;
    }
}