namespace Enochian_Encryption_System
{
    partial class FrmTransmission
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
            groupBox1 = new GroupBox();
            lblSigStatus = new Label();
            lblDeckStatus = new Label();
            lblHeaderStatus = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtSenderName = new TextBox();
            label4 = new Label();
            lblFileStatus = new Label();
            txtChecksum = new TextBox();
            label10 = new Label();
            label12 = new Label();
            btnExport = new Button();
            txtFilePath = new TextBox();
            lstLog = new ListBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblSigStatus);
            groupBox1.Controls.Add(lblDeckStatus);
            groupBox1.Controls.Add(lblHeaderStatus);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(409, 203);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Package Manifest";
            // 
            // lblSigStatus
            // 
            lblSigStatus.BorderStyle = BorderStyle.FixedSingle;
            lblSigStatus.Location = new Point(106, 146);
            lblSigStatus.Name = "lblSigStatus";
            lblSigStatus.Size = new Size(297, 33);
            lblSigStatus.TabIndex = 5;
            // 
            // lblDeckStatus
            // 
            lblDeckStatus.BorderStyle = BorderStyle.FixedSingle;
            lblDeckStatus.Location = new Point(106, 94);
            lblDeckStatus.Name = "lblDeckStatus";
            lblDeckStatus.Size = new Size(297, 33);
            lblDeckStatus.TabIndex = 4;
            // 
            // lblHeaderStatus
            // 
            lblHeaderStatus.BorderStyle = BorderStyle.FixedSingle;
            lblHeaderStatus.Location = new Point(106, 38);
            lblHeaderStatus.Name = "lblHeaderStatus";
            lblHeaderStatus.Size = new Size(297, 33);
            lblHeaderStatus.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 152);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 2;
            label3.Text = "Signature:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 98);
            label2.Name = "label2";
            label2.Size = new Size(68, 20);
            label2.TabIndex = 1;
            label2.Text = "Payload:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 39);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Header:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSenderName);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(lblFileStatus);
            groupBox2.Controls.Add(txtChecksum);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label12);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(427, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(409, 203);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Integrity Verification";
            // 
            // txtSenderName
            // 
            txtSenderName.Location = new Point(130, 80);
            txtSenderName.Name = "txtSenderName";
            txtSenderName.Size = new Size(273, 27);
            txtSenderName.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 83);
            label4.Name = "label4";
            label4.Size = new Size(107, 20);
            label4.TabIndex = 5;
            label4.Text = "Sender Name:";
            // 
            // lblFileStatus
            // 
            lblFileStatus.BorderStyle = BorderStyle.FixedSingle;
            lblFileStatus.Location = new Point(108, 129);
            lblFileStatus.Name = "lblFileStatus";
            lblFileStatus.Size = new Size(295, 43);
            lblFileStatus.TabIndex = 4;
            // 
            // txtChecksum
            // 
            txtChecksum.Location = new Point(254, 36);
            txtChecksum.Name = "txtChecksum";
            txtChecksum.ReadOnly = true;
            txtChecksum.Size = new Size(51, 27);
            txtChecksum.TabIndex = 3;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(17, 139);
            label10.Name = "label10";
            label10.Size = new Size(85, 20);
            label10.TabIndex = 2;
            label10.Text = "File Status:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(17, 39);
            label12.Name = "label12";
            label12.Size = new Size(231, 20);
            label12.TabIndex = 0;
            label12.Text = "Package Checksum (Header ID):";
            // 
            // btnExport
            // 
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExport.Location = new Point(12, 231);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(213, 29);
            btnExport.TabIndex = 5;
            btnExport.Text = "Generate Secure .ENC File";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // txtFilePath
            // 
            txtFilePath.Location = new Point(231, 231);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(605, 27);
            txtFilePath.TabIndex = 7;
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.Location = new Point(12, 275);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(824, 164);
            lstLog.TabIndex = 8;
            // 
            // FrmTransmission
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(842, 450);
            Controls.Add(lstLog);
            Controls.Add(txtFilePath);
            Controls.Add(btnExport);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmTransmission";
            Text = "FrmTransmission";
            Load += FrmTransmission_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblSigStatus;
        private Label lblDeckStatus;
        private Label lblHeaderStatus;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Label label10;
        private Label label12;
        private Label lblFileStatus;
        private TextBox txtChecksum;
        private Button btnExport;
        private TextBox txtFilePath;
        private ListBox lstLog;
        private TextBox txtSenderName;
        private Label label4;
    }
}