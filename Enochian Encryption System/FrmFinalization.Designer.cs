namespace Enochian_Encryption_System
{
    partial class FrmFinalization
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
            txtCleanedInput = new TextBox();
            label2 = new Label();
            txtFinalResult = new TextBox();
            btnFinalize = new Button();
            btnSave = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(203, 20);
            label1.TabIndex = 0;
            label1.Text = "Cleaned Text (From Step 7):";
            // 
            // txtCleanedInput
            // 
            txtCleanedInput.Location = new Point(12, 32);
            txtCleanedInput.Multiline = true;
            txtCleanedInput.Name = "txtCleanedInput";
            txtCleanedInput.ReadOnly = true;
            txtCleanedInput.Size = new Size(958, 408);
            txtCleanedInput.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(12, 452);
            label2.Name = "label2";
            label2.Size = new Size(142, 20);
            label2.TabIndex = 2;
            label2.Text = "Restored Plaintext:";
            // 
            // txtFinalResult
            // 
            txtFinalResult.Location = new Point(12, 475);
            txtFinalResult.Multiline = true;
            txtFinalResult.Name = "txtFinalResult";
            txtFinalResult.ReadOnly = true;
            txtFinalResult.Size = new Size(958, 408);
            txtFinalResult.TabIndex = 3;
            // 
            // btnFinalize
            // 
            btnFinalize.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFinalize.Location = new Point(12, 889);
            btnFinalize.Name = "btnFinalize";
            btnFinalize.Size = new Size(203, 29);
            btnFinalize.TabIndex = 4;
            btnFinalize.Text = "Reconstruct and Format";
            btnFinalize.UseVisualStyleBackColor = true;
            btnFinalize.Click += btnFinalize_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.Location = new Point(869, 889);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(101, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save to .txt";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(361, 892);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(351, 41);
            lblStatus.TabIndex = 6;
            // 
            // FrmFinalization
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 953);
            Controls.Add(lblStatus);
            Controls.Add(btnSave);
            Controls.Add(btnFinalize);
            Controls.Add(txtFinalResult);
            Controls.Add(label2);
            Controls.Add(txtCleanedInput);
            Controls.Add(label1);
            Name = "FrmFinalization";
            Text = "Finalization";
            Load += FrmFinalization_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCleanedInput;
        private Label label2;
        private TextBox txtFinalResult;
        private Button btnFinalize;
        private Button btnSave;
        private Label lblStatus;
    }
}