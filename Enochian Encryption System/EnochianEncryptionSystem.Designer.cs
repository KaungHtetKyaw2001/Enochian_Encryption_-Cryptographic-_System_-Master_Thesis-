namespace Enochian_Encryption_System
{
    partial class EnochianEncryptionSystem
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnEncrypt = new Button();
            label2 = new Label();
            btnDecrypt = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLightLight;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(49, 49);
            label1.Name = "label1";
            label1.Size = new Size(472, 48);
            label1.TabIndex = 0;
            label1.Text = "Enochian Encryption System";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnEncrypt
            // 
            btnEncrypt.BackColor = Color.LightCoral;
            btnEncrypt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEncrypt.Location = new Point(76, 205);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(172, 90);
            btnEncrypt.TabIndex = 1;
            btnEncrypt.Text = "Encrypt your text";
            btnEncrypt.UseVisualStyleBackColor = false;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(35, 137);
            label2.Name = "label2";
            label2.Size = new Size(502, 32);
            label2.TabIndex = 2;
            label2.Text = "Select your method: Encryption or Decryption";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDecrypt
            // 
            btnDecrypt.BackColor = Color.PaleGreen;
            btnDecrypt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDecrypt.Location = new Point(331, 205);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(172, 90);
            btnDecrypt.TabIndex = 3;
            btnDecrypt.Text = "Decrypt your text";
            btnDecrypt.UseVisualStyleBackColor = false;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExit.Location = new Point(483, 301);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(102, 31);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // EnochianEncryptionSystem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 344);
            Controls.Add(btnExit);
            Controls.Add(btnDecrypt);
            Controls.Add(label2);
            Controls.Add(btnEncrypt);
            Controls.Add(label1);
            Name = "EnochianEncryptionSystem";
            Text = "Enochian Encryption System";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnEncrypt;
        private Label label2;
        private Button btnDecrypt;
        private Button btnExit;
    }
}
