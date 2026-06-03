namespace Enochian_Encryption_System
{
    partial class FrmKyber
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
            txtProcessLog = new TextBox();
            btnRunKyber = new Button();
            lblKyberEncTime = new Label();
            lblKyberDecTime = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtProcessLog
            // 
            txtProcessLog.Location = new Point(12, 12);
            txtProcessLog.Multiline = true;
            txtProcessLog.Name = "txtProcessLog";
            txtProcessLog.ScrollBars = ScrollBars.Vertical;
            txtProcessLog.Size = new Size(614, 299);
            txtProcessLog.TabIndex = 0;
            // 
            // btnRunKyber
            // 
            btnRunKyber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRunKyber.Location = new Point(495, 409);
            btnRunKyber.Name = "btnRunKyber";
            btnRunKyber.Size = new Size(131, 29);
            btnRunKyber.TabIndex = 1;
            btnRunKyber.Text = "Run Kyber";
            btnRunKyber.UseVisualStyleBackColor = true;
            btnRunKyber.Click += btnRunKyber_Click;
            // 
            // lblKyberEncTime
            // 
            lblKyberEncTime.BorderStyle = BorderStyle.FixedSingle;
            lblKyberEncTime.Location = new Point(12, 354);
            lblKyberEncTime.Name = "lblKyberEncTime";
            lblKyberEncTime.Size = new Size(284, 34);
            lblKyberEncTime.TabIndex = 2;
            // 
            // lblKyberDecTime
            // 
            lblKyberDecTime.BorderStyle = BorderStyle.FixedSingle;
            lblKyberDecTime.Location = new Point(342, 354);
            lblKyberDecTime.Name = "lblKyberDecTime";
            lblKyberDecTime.Size = new Size(284, 34);
            lblKyberDecTime.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(12, 324);
            label2.Name = "label2";
            label2.Size = new Size(168, 20);
            label2.TabIndex = 4;
            label2.Text = "Kyber Encryption Time";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(342, 324);
            label3.Name = "label3";
            label3.Size = new Size(170, 20);
            label3.TabIndex = 5;
            label3.Text = "Kyber Decryption Time";
            // 
            // FrmKyber
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(638, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblKyberDecTime);
            Controls.Add(lblKyberEncTime);
            Controls.Add(btnRunKyber);
            Controls.Add(txtProcessLog);
            Name = "FrmKyber";
            Text = "FrmKyber";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtProcessLog;
        private Button btnRunKyber;
        private Label lblKyberEncTime;
        private Label lblKyberDecTime;
        private Label label2;
        private Label label3;
    }
}