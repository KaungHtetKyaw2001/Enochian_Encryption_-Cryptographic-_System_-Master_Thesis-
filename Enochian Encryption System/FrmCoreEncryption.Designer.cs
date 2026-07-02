namespace Enochian_Encryption_System
{
    partial class FrmCoreEncryption
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            rtbSBoxPreview = new RichTextBox();
            label2 = new Label();
            btnSBox = new Button();
            lblSeed = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            rtbKeyStatus = new RichTextBox();
            btnHillCipher = new Button();
            label6 = new Label();
            groupBox3 = new GroupBox();
            rtbOutputPreview = new RichTextBox();
            btnConfirm = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rtbSBoxPreview);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnSBox);
            groupBox1.Controls.Add(lblSeed);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(844, 253);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stage 1: Non-Linear Substitution";
            // 
            // rtbSBoxPreview
            // 
            rtbSBoxPreview.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rtbSBoxPreview.Location = new Point(134, 118);
            rtbSBoxPreview.Name = "rtbSBoxPreview";
            rtbSBoxPreview.ReadOnly = true;
            rtbSBoxPreview.Size = new Size(704, 120);
            rtbSBoxPreview.TabIndex = 3;
            rtbSBoxPreview.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 134);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 3;
            label2.Text = "S-Box Preview:";
            // 
            // btnSBox
            // 
            btnSBox.Location = new Point(15, 83);
            btnSBox.Name = "btnSBox";
            btnSBox.Size = new Size(232, 29);
            btnSBox.TabIndex = 2;
            btnSBox.Text = "Generate S-Box and Substitute";
            btnSBox.UseVisualStyleBackColor = true;
            btnSBox.Click += btnSBox_Click;
            // 
            // lblSeed
            // 
            lblSeed.BorderStyle = BorderStyle.FixedSingle;
            lblSeed.Location = new Point(194, 31);
            lblSeed.Name = "lblSeed";
            lblSeed.Size = new Size(204, 38);
            lblSeed.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 38);
            label1.Name = "label1";
            label1.Size = new Size(167, 20);
            label1.TabIndex = 0;
            label1.Text = "S-Box Seed (Lorenz Y):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rtbKeyStatus);
            groupBox2.Controls.Add(btnHillCipher);
            groupBox2.Controls.Add(label6);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 271);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(844, 393);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Stage 2: Linear Encryption";
            // 
            // rtbKeyStatus
            // 
            rtbKeyStatus.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rtbKeyStatus.Location = new Point(134, 26);
            rtbKeyStatus.Name = "rtbKeyStatus";
            rtbKeyStatus.ReadOnly = true;
            rtbKeyStatus.Size = new Size(704, 310);
            rtbKeyStatus.TabIndex = 4;
            rtbKeyStatus.Text = "";
            // 
            // btnHillCipher
            // 
            btnHillCipher.Location = new Point(15, 342);
            btnHillCipher.Name = "btnHillCipher";
            btnHillCipher.Size = new Size(291, 29);
            btnHillCipher.TabIndex = 2;
            btnHillCipher.Text = "Apply Hill Cipher Matrix Multiplication";
            btnHillCipher.UseVisualStyleBackColor = true;
            btnHillCipher.Click += btnHillCipher_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 38);
            label6.Name = "label6";
            label6.Size = new Size(115, 20);
            label6.TabIndex = 0;
            label6.Text = "Key Matrix (K):";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rtbOutputPreview);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(862, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(836, 652);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Final Output";
            // 
            // rtbOutputPreview
            // 
            rtbOutputPreview.Dock = DockStyle.Fill;
            rtbOutputPreview.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rtbOutputPreview.Location = new Point(3, 23);
            rtbOutputPreview.Name = "rtbOutputPreview";
            rtbOutputPreview.Size = new Size(830, 626);
            rtbOutputPreview.TabIndex = 0;
            rtbOutputPreview.Text = "";
            rtbOutputPreview.WordWrap = false;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(1552, 680);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(146, 29);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // FrmCoreEncryption
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1710, 721);
            Controls.Add(btnConfirm);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmCoreEncryption";
            Text = "Core Encryption";
            Load += FrmCoreEncryption_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private Label label2;
        private Button btnSBox;
        private Label lblSeed;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnHillCipher;
        private Label label6;
        private GroupBox groupBox3;
        private Button btnConfirm;
        private RichTextBox rtbOutputPreview;
        private RichTextBox rtbSBoxPreview;
        private RichTextBox rtbKeyStatus;
    }
}