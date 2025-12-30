namespace Enochian_Encryption_System
{
    partial class FrmCoreDecryption
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
            lblCount = new Label();
            btnDecrypt = new Button();
            lblStatus = new Label();
            label4 = new Label();
            btnConfirm = new Button();
            label2 = new Label();
            dgvFactorMultipliedKeyMatrix = new DataGridView();
            label3 = new Label();
            label5 = new Label();
            lblModularInverseDeterminant = new Label();
            label7 = new Label();
            dgvAdjugateKeyMatrix = new DataGridView();
            label8 = new Label();
            dgvInverseMatrix = new DataGridView();
            label9 = new Label();
            rtbDecryptionOutput = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dgvFactorMultipliedKeyMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdjugateKeyMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInverseMatrix).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(131, 20);
            label1.TabIndex = 0;
            label1.Text = "Cards to Decrypt:";
            // 
            // lblCount
            // 
            lblCount.BorderStyle = BorderStyle.FixedSingle;
            lblCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCount.Location = new Point(149, 9);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(417, 31);
            lblCount.TabIndex = 1;
            // 
            // btnDecrypt
            // 
            btnDecrypt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDecrypt.Location = new Point(1132, 477);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(141, 29);
            btnDecrypt.TabIndex = 2;
            btnDecrypt.Text = "Decrypt Matrices";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(75, 807);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(297, 31);
            lblStatus.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(12, 813);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 4;
            label4.Text = "Status:";
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(1060, 809);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(213, 29);
            btnConfirm.TabIndex = 6;
            btnConfirm.Text = "Proceed to Text Conversion";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(12, 161);
            label2.Name = "label2";
            label2.Size = new Size(160, 20);
            label2.TabIndex = 7;
            label2.Text = "Multiplied Key Matrix";
            // 
            // dgvFactorMultipliedKeyMatrix
            // 
            dgvFactorMultipliedKeyMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFactorMultipliedKeyMatrix.Location = new Point(12, 184);
            dgvFactorMultipliedKeyMatrix.Name = "dgvFactorMultipliedKeyMatrix";
            dgvFactorMultipliedKeyMatrix.RowHeadersWidth = 51;
            dgvFactorMultipliedKeyMatrix.Size = new Size(554, 276);
            dgvFactorMultipliedKeyMatrix.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 116);
            label3.Name = "label3";
            label3.Size = new Size(148, 20);
            label3.TabIndex = 9;
            label3.Text = "Modulus : (Mod 21)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(12, 65);
            label5.Name = "label5";
            label5.Size = new Size(216, 20);
            label5.TabIndex = 10;
            label5.Text = "Modular Inverse Determinant";
            // 
            // lblModularInverseDeterminant
            // 
            lblModularInverseDeterminant.BorderStyle = BorderStyle.FixedSingle;
            lblModularInverseDeterminant.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblModularInverseDeterminant.Location = new Point(234, 60);
            lblModularInverseDeterminant.Name = "lblModularInverseDeterminant";
            lblModularInverseDeterminant.Size = new Size(118, 31);
            lblModularInverseDeterminant.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(12, 477);
            label7.Name = "label7";
            label7.Size = new Size(157, 20);
            label7.TabIndex = 12;
            label7.Text = "Adjugate Key Matrix:";
            // 
            // dgvAdjugateKeyMatrix
            // 
            dgvAdjugateKeyMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdjugateKeyMatrix.Location = new Point(12, 500);
            dgvAdjugateKeyMatrix.Name = "dgvAdjugateKeyMatrix";
            dgvAdjugateKeyMatrix.RowHeadersWidth = 51;
            dgvAdjugateKeyMatrix.Size = new Size(554, 288);
            dgvAdjugateKeyMatrix.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(586, 481);
            label8.Name = "label8";
            label8.Size = new Size(110, 20);
            label8.TabIndex = 14;
            label8.Text = "Inverse Matrix";
            // 
            // dgvInverseMatrix
            // 
            dgvInverseMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInverseMatrix.Location = new Point(586, 512);
            dgvInverseMatrix.Name = "dgvInverseMatrix";
            dgvInverseMatrix.RowHeadersWidth = 51;
            dgvInverseMatrix.Size = new Size(687, 276);
            dgvInverseMatrix.TabIndex = 15;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(586, 14);
            label9.Name = "label9";
            label9.Size = new Size(141, 20);
            label9.TabIndex = 16;
            label9.Text = "Decryption Output";
            // 
            // rtbDecryptionOutput
            // 
            rtbDecryptionOutput.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbDecryptionOutput.Location = new Point(586, 37);
            rtbDecryptionOutput.Name = "rtbDecryptionOutput";
            rtbDecryptionOutput.Size = new Size(687, 434);
            rtbDecryptionOutput.TabIndex = 17;
            rtbDecryptionOutput.Text = "";
            rtbDecryptionOutput.WordWrap = false;
            // 
            // FrmCoreDecryption
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1285, 850);
            Controls.Add(rtbDecryptionOutput);
            Controls.Add(label9);
            Controls.Add(dgvInverseMatrix);
            Controls.Add(label8);
            Controls.Add(dgvAdjugateKeyMatrix);
            Controls.Add(label7);
            Controls.Add(lblModularInverseDeterminant);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(dgvFactorMultipliedKeyMatrix);
            Controls.Add(label2);
            Controls.Add(btnConfirm);
            Controls.Add(lblStatus);
            Controls.Add(label4);
            Controls.Add(btnDecrypt);
            Controls.Add(lblCount);
            Controls.Add(label1);
            Name = "FrmCoreDecryption";
            Text = "Core Decryption";
            Load += FrmCoreDecryption_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFactorMultipliedKeyMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdjugateKeyMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInverseMatrix).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblCount;
        private Button btnDecrypt;
        private Label lblStatus;
        private Label label4;
        private Button btnConfirm;
        private Label label2;
        private DataGridView dgvFactorMultipliedKeyMatrix;
        private Label label3;
        private Label label5;
        private Label lblModularInverseDeterminant;
        private Label label7;
        private DataGridView dgvAdjugateKeyMatrix;
        private Label label8;
        private DataGridView dgvInverseMatrix;
        private Label label9;
        private RichTextBox rtbDecryptionOutput;
    }
}