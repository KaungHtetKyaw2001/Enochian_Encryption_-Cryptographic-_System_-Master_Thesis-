namespace Enochian_Encryption_System
{
    partial class FrmKeyEncapsulation
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
            txtRecPubKey = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtHeaderResult = new TextBox();
            label3 = new Label();
            btnEncryptHeader = new Button();
            lblSessionVec = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtRecPubKey);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(556, 86);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Receiver Info";
            // 
            // txtRecPubKey
            // 
            txtRecPubKey.Location = new Point(241, 40);
            txtRecPubKey.Name = "txtRecPubKey";
            txtRecPubKey.ReadOnly = true;
            txtRecPubKey.Size = new Size(309, 27);
            txtRecPubKey.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 43);
            label1.Name = "label1";
            label1.Size = new Size(213, 20);
            label1.TabIndex = 0;
            label1.Text = "Receiver Public Key (Locked):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtHeaderResult);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btnEncryptHeader);
            groupBox2.Controls.Add(lblSessionVec);
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 104);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(556, 214);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Encapsulation";
            // 
            // txtHeaderResult
            // 
            txtHeaderResult.Location = new Point(241, 105);
            txtHeaderResult.Name = "txtHeaderResult";
            txtHeaderResult.ReadOnly = true;
            txtHeaderResult.Size = new Size(309, 27);
            txtHeaderResult.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 108);
            label3.Name = "label3";
            label3.Size = new Size(134, 20);
            label3.TabIndex = 4;
            label3.Text = "Resulting Header:";
            // 
            // btnEncryptHeader
            // 
            btnEncryptHeader.Location = new Point(25, 167);
            btnEncryptHeader.Name = "btnEncryptHeader";
            btnEncryptHeader.Size = new Size(172, 29);
            btnEncryptHeader.TabIndex = 3;
            btnEncryptHeader.Text = "Encrypt Header";
            btnEncryptHeader.UseVisualStyleBackColor = true;
            btnEncryptHeader.Click += btnEncryptHeader_Click;
            // 
            // lblSessionVec
            // 
            lblSessionVec.BorderStyle = BorderStyle.FixedSingle;
            lblSessionVec.Location = new Point(246, 39);
            lblSessionVec.Name = "lblSessionVec";
            lblSessionVec.Size = new Size(304, 37);
            lblSessionVec.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 47);
            label2.Name = "label2";
            label2.Size = new Size(215, 20);
            label2.TabIndex = 0;
            label2.Text = "Session Vector (From Step 1):";
            // 
            // FrmKeyEncapsulation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 334);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmKeyEncapsulation";
            Text = "Key Encapsulation";
            Load += FrmKeyEncapsulation_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtRecPubKey;
        private Label label1;
        private GroupBox groupBox2;
        private Label lblSessionVec;
        private Label label2;
        private TextBox txtHeaderResult;
        private Label label3;
        private Button btnEncryptHeader;
    }
}