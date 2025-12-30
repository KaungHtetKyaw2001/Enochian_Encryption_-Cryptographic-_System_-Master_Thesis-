namespace Enochian_Encryption_System
{
    partial class FrmPkgDelivery
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
            btnLoad = new Button();
            groupBox1 = new GroupBox();
            lblStatus = new Label();
            label4 = new Label();
            txtChecksum = new TextBox();
            txtTimestamp = new TextBox();
            txtSenderID = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            rtbPreview = new RichTextBox();
            btnConfirm = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLoad.Location = new Point(12, 12);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(234, 29);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load Encrypted Package (.enc)";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblStatus);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtChecksum);
            groupBox1.Controls.Add(txtTimestamp);
            groupBox1.Controls.Add(txtSenderID);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 47);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(399, 267);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Package Metadata";
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(123, 201);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(270, 43);
            lblStatus.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 202);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 6;
            label4.Text = "Status";
            // 
            // txtChecksum
            // 
            txtChecksum.Location = new Point(123, 145);
            txtChecksum.Name = "txtChecksum";
            txtChecksum.ReadOnly = true;
            txtChecksum.Size = new Size(270, 27);
            txtChecksum.TabIndex = 5;
            // 
            // txtTimestamp
            // 
            txtTimestamp.Location = new Point(123, 89);
            txtTimestamp.Name = "txtTimestamp";
            txtTimestamp.ReadOnly = true;
            txtTimestamp.Size = new Size(270, 27);
            txtTimestamp.TabIndex = 4;
            // 
            // txtSenderID
            // 
            txtSenderID.Location = new Point(123, 35);
            txtSenderID.Name = "txtSenderID";
            txtSenderID.ReadOnly = true;
            txtSenderID.Size = new Size(270, 27);
            txtSenderID.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 148);
            label3.Name = "label3";
            label3.Size = new Size(80, 20);
            label3.TabIndex = 2;
            label3.Text = "Checksum";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 92);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 1;
            label2.Text = "Timestamp";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 38);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "Sender ID";
            // 
            // rtbPreview
            // 
            rtbPreview.Location = new Point(417, 12);
            rtbPreview.Name = "rtbPreview";
            rtbPreview.ReadOnly = true;
            rtbPreview.Size = new Size(529, 498);
            rtbPreview.TabIndex = 8;
            rtbPreview.Text = "";
            // 
            // btnConfirm
            // 
            btnConfirm.Enabled = false;
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(12, 320);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(130, 29);
            btnConfirm.TabIndex = 9;
            btnConfirm.Text = "Accept Package";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // FrmPkgDelivery
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 522);
            Controls.Add(btnConfirm);
            Controls.Add(rtbPreview);
            Controls.Add(groupBox1);
            Controls.Add(btnLoad);
            Name = "FrmPkgDelivery";
            Text = "Package Delivery";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoad;
        private GroupBox groupBox1;
        private Label label4;
        private TextBox txtChecksum;
        private TextBox txtTimestamp;
        private TextBox txtSenderID;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblStatus;
        private RichTextBox rtbPreview;
        private Button btnConfirm;
    }
}