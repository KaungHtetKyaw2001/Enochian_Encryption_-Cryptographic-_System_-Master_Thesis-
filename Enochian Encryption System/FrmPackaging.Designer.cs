namespace Enochian_Encryption_System
{
    partial class FrmPackaging
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
            btnAssemble = new Button();
            lblTagCount = new Label();
            lblDeckCount = new Label();
            lblHeader = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtPreview = new TextBox();
            btnConfirm = new Button();
            lblSenderID = new Label();
            txtSenderID = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAssemble);
            groupBox1.Controls.Add(lblTagCount);
            groupBox1.Controls.Add(lblDeckCount);
            groupBox1.Controls.Add(lblHeader);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(556, 229);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Payload Assembly";
            // 
            // btnAssemble
            // 
            btnAssemble.Location = new Point(19, 184);
            btnAssemble.Name = "btnAssemble";
            btnAssemble.Size = new Size(237, 29);
            btnAssemble.TabIndex = 6;
            btnAssemble.Text = "Serialize and Assemble Payload";
            btnAssemble.UseVisualStyleBackColor = true;
            btnAssemble.Click += btnAssemble_Click;
            // 
            // lblTagCount
            // 
            lblTagCount.BorderStyle = BorderStyle.FixedSingle;
            lblTagCount.Location = new Point(139, 128);
            lblTagCount.Name = "lblTagCount";
            lblTagCount.Size = new Size(411, 35);
            lblTagCount.TabIndex = 5;
            // 
            // lblDeckCount
            // 
            lblDeckCount.BorderStyle = BorderStyle.FixedSingle;
            lblDeckCount.Location = new Point(139, 75);
            lblDeckCount.Name = "lblDeckCount";
            lblDeckCount.Size = new Size(411, 35);
            lblDeckCount.TabIndex = 4;
            // 
            // lblHeader
            // 
            lblHeader.BorderStyle = BorderStyle.FixedSingle;
            lblHeader.Location = new Point(139, 23);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(411, 35);
            lblHeader.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 135);
            label3.Name = "label3";
            label3.Size = new Size(98, 20);
            label3.TabIndex = 2;
            label3.Text = "Tag Content:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 83);
            label2.Name = "label2";
            label2.Size = new Size(107, 20);
            label2.TabIndex = 1;
            label2.Text = "Deck Content:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 33);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 0;
            label1.Text = "Header Source:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtPreview);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(574, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(593, 542);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Payload Assembly";
            // 
            // txtPreview
            // 
            txtPreview.Location = new Point(6, 26);
            txtPreview.Multiline = true;
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.Size = new Size(581, 510);
            txtPreview.TabIndex = 0;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(31, 519);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(141, 29);
            btnConfirm.TabIndex = 7;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblSenderID
            // 
            lblSenderID.AutoSize = true;
            lblSenderID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSenderID.Location = new Point(26, 266);
            lblSenderID.Name = "lblSenderID";
            lblSenderID.Size = new Size(130, 20);
            lblSenderID.TabIndex = 7;
            lblSenderID.Text = "Sender's Identity:";
            // 
            // txtSenderID
            // 
            txtSenderID.Location = new Point(162, 263);
            txtSenderID.Name = "txtSenderID";
            txtSenderID.Size = new Size(400, 27);
            txtSenderID.TabIndex = 8;
            // 
            // FrmPackaging
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 566);
            Controls.Add(txtSenderID);
            Controls.Add(lblSenderID);
            Controls.Add(btnConfirm);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmPackaging";
            Text = "Packaging";
            Load += FrmPackaging_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblTagCount;
        private Label lblDeckCount;
        private Label lblHeader;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnAssemble;
        private GroupBox groupBox2;
        private TextBox txtPreview;
        private Button btnConfirm;
        private Label lblSenderID;
        private TextBox txtSenderID;
    }
}