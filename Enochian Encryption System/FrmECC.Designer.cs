namespace Enochian_Encryption_System
{
    partial class FrmECC
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
            rtbDecStats = new RichTextBox();
            rtbEncStats = new RichTextBox();
            btnDecrypt = new Button();
            btnEncrypt = new Button();
            rtbPlainOutput = new RichTextBox();
            rtbCipherOutput = new RichTextBox();
            rtbCipherInput = new RichTextBox();
            rtbPlainInput = new RichTextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // rtbDecStats
            // 
            rtbDecStats.Location = new Point(877, 557);
            rtbDecStats.Name = "rtbDecStats";
            rtbDecStats.ReadOnly = true;
            rtbDecStats.Size = new Size(871, 157);
            rtbDecStats.TabIndex = 29;
            rtbDecStats.Text = "";
            // 
            // rtbEncStats
            // 
            rtbEncStats.Location = new Point(12, 557);
            rtbEncStats.Name = "rtbEncStats";
            rtbEncStats.ReadOnly = true;
            rtbEncStats.Size = new Size(838, 157);
            rtbEncStats.TabIndex = 28;
            rtbEncStats.Text = "";
            // 
            // btnDecrypt
            // 
            btnDecrypt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDecrypt.Location = new Point(1294, 269);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(94, 29);
            btnDecrypt.TabIndex = 27;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // btnEncrypt
            // 
            btnEncrypt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEncrypt.Location = new Point(357, 269);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(94, 29);
            btnEncrypt.TabIndex = 26;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // rtbPlainOutput
            // 
            rtbPlainOutput.Location = new Point(12, 326);
            rtbPlainOutput.Name = "rtbPlainOutput";
            rtbPlainOutput.ReadOnly = true;
            rtbPlainOutput.Size = new Size(838, 216);
            rtbPlainOutput.TabIndex = 25;
            rtbPlainOutput.Text = "";
            // 
            // rtbCipherOutput
            // 
            rtbCipherOutput.Location = new Point(877, 326);
            rtbCipherOutput.Name = "rtbCipherOutput";
            rtbCipherOutput.ReadOnly = true;
            rtbCipherOutput.Size = new Size(871, 216);
            rtbCipherOutput.TabIndex = 24;
            rtbCipherOutput.Text = "";
            // 
            // rtbCipherInput
            // 
            rtbCipherInput.Location = new Point(877, 32);
            rtbCipherInput.Name = "rtbCipherInput";
            rtbCipherInput.ReadOnly = true;
            rtbCipherInput.Size = new Size(871, 216);
            rtbCipherInput.TabIndex = 23;
            rtbCipherInput.Text = "";
            // 
            // rtbPlainInput
            // 
            rtbPlainInput.Location = new Point(12, 32);
            rtbPlainInput.Name = "rtbPlainInput";
            rtbPlainInput.Size = new Size(838, 216);
            rtbPlainInput.TabIndex = 22;
            rtbPlainInput.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(877, 303);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 21;
            label4.Text = "Decrypt Output";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 303);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 20;
            label3.Text = "Encrypt Output";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(877, 9);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 19;
            label2.Text = "Ciphertext Input";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 18;
            label1.Text = "Plaintext Input";
            // 
            // FrmECC
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1776, 777);
            Controls.Add(rtbDecStats);
            Controls.Add(rtbEncStats);
            Controls.Add(btnDecrypt);
            Controls.Add(btnEncrypt);
            Controls.Add(rtbPlainOutput);
            Controls.Add(rtbCipherOutput);
            Controls.Add(rtbCipherInput);
            Controls.Add(rtbPlainInput);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmECC";
            Text = "Elliptic Curve Cryptography Encryption/Decryption";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtbDecStats;
        private RichTextBox rtbEncStats;
        private Button btnDecrypt;
        private Button btnEncrypt;
        private RichTextBox rtbPlainOutput;
        private RichTextBox rtbCipherOutput;
        private RichTextBox rtbCipherInput;
        private RichTextBox rtbPlainInput;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}