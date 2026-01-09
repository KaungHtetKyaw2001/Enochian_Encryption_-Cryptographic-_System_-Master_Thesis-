namespace Enochian_Encryption_System
{
    partial class FrmRSA
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            rtbPlainInput = new RichTextBox();
            rtbCipherInput = new RichTextBox();
            rtbCipherOutput = new RichTextBox();
            rtbPlainOutput = new RichTextBox();
            btnEncrypt = new Button();
            btnDecrypt = new Button();
            rtbEncStats = new RichTextBox();
            rtbDecStats = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 0;
            label1.Text = "Plaintext Input";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(877, 9);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 1;
            label2.Text = "Ciphertext Input";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 303);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 4;
            label3.Text = "Encrypt Output";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(877, 303);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 5;
            label4.Text = "Decrypt Output";
            // 
            // rtbPlainInput
            // 
            rtbPlainInput.Location = new Point(12, 32);
            rtbPlainInput.Name = "rtbPlainInput";
            rtbPlainInput.Size = new Size(838, 216);
            rtbPlainInput.TabIndex = 8;
            rtbPlainInput.Text = "";
            // 
            // rtbCipherInput
            // 
            rtbCipherInput.Location = new Point(877, 32);
            rtbCipherInput.Name = "rtbCipherInput";
            rtbCipherInput.ReadOnly = true;
            rtbCipherInput.Size = new Size(871, 216);
            rtbCipherInput.TabIndex = 9;
            rtbCipherInput.Text = "";
            // 
            // rtbCipherOutput
            // 
            rtbCipherOutput.Location = new Point(877, 326);
            rtbCipherOutput.Name = "rtbCipherOutput";
            rtbCipherOutput.ReadOnly = true;
            rtbCipherOutput.Size = new Size(871, 216);
            rtbCipherOutput.TabIndex = 10;
            rtbCipherOutput.Text = "";
            // 
            // rtbPlainOutput
            // 
            rtbPlainOutput.Location = new Point(12, 326);
            rtbPlainOutput.Name = "rtbPlainOutput";
            rtbPlainOutput.ReadOnly = true;
            rtbPlainOutput.Size = new Size(838, 216);
            rtbPlainOutput.TabIndex = 11;
            rtbPlainOutput.Text = "";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEncrypt.Location = new Point(357, 269);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(94, 29);
            btnEncrypt.TabIndex = 12;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDecrypt.Location = new Point(1294, 269);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(94, 29);
            btnDecrypt.TabIndex = 13;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // rtbEncStats
            // 
            rtbEncStats.Location = new Point(12, 557);
            rtbEncStats.Name = "rtbEncStats";
            rtbEncStats.ReadOnly = true;
            rtbEncStats.Size = new Size(838, 157);
            rtbEncStats.TabIndex = 16;
            rtbEncStats.Text = "";
            // 
            // rtbDecStats
            // 
            rtbDecStats.Location = new Point(877, 557);
            rtbDecStats.Name = "rtbDecStats";
            rtbDecStats.ReadOnly = true;
            rtbDecStats.Size = new Size(871, 157);
            rtbDecStats.TabIndex = 17;
            rtbDecStats.Text = "";
            // 
            // FrmRSA
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1760, 735);
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
            Name = "FrmRSA";
            Text = "RSA Algorithm Encryption/Decryption Process";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private RichTextBox rtbPlainInput;
        private RichTextBox rtbCipherInput;
        private RichTextBox rtbCipherOutput;
        private RichTextBox rtbPlainOutput;
        private Button btnEncrypt;
        private Button btnDecrypt;
        private RichTextBox rtbEncStats;
        private RichTextBox rtbDecStats;
    }
}