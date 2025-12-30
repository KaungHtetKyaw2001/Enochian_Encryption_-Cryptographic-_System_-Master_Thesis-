namespace Enochian_Encryption_System
{
    partial class FrmDigitalSignature
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
            lblTargetHash = new Label();
            label2 = new Label();
            lblSenderKey = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtCalcLog = new TextBox();
            groupBox3 = new GroupBox();
            btnSign = new Button();
            dgvSignature = new DataGridView();
            PrivateKeyValue = new DataGridViewTextBoxColumn();
            UsedInSum = new DataGridViewTextBoxColumn();
            BitValue = new DataGridViewTextBoxColumn();
            btnConfirm = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSignature).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblTargetHash);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(lblSenderKey);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(428, 116);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "1. Inputs";
            // 
            // lblTargetHash
            // 
            lblTargetHash.BorderStyle = BorderStyle.FixedSingle;
            lblTargetHash.Location = new Point(259, 76);
            lblTargetHash.Name = "lblTargetHash";
            lblTargetHash.Size = new Size(156, 25);
            lblTargetHash.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 77);
            label2.Name = "label2";
            label2.Size = new Size(238, 20);
            label2.TabIndex = 2;
            label2.Text = "Encrypted Header (Target Hash):";
            // 
            // lblSenderKey
            // 
            lblSenderKey.BorderStyle = BorderStyle.FixedSingle;
            lblSenderKey.Location = new Point(259, 33);
            lblSenderKey.Name = "lblSenderKey";
            lblSenderKey.Size = new Size(156, 25);
            lblSenderKey.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 33);
            label1.Name = "label1";
            label1.Size = new Size(194, 20);
            label1.TabIndex = 0;
            label1.Text = "Sender Private Key Vector:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtCalcLog);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 134);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(428, 270);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "2. Solving Trapdoor (Calculation Log)";
            // 
            // txtCalcLog
            // 
            txtCalcLog.Location = new Point(16, 26);
            txtCalcLog.Multiline = true;
            txtCalcLog.Name = "txtCalcLog";
            txtCalcLog.ReadOnly = true;
            txtCalcLog.Size = new Size(399, 219);
            txtCalcLog.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnSign);
            groupBox3.Controls.Add(dgvSignature);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(455, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(451, 443);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "3. Signature Vector Generation";
            // 
            // btnSign
            // 
            btnSign.Location = new Point(144, 398);
            btnSign.Name = "btnSign";
            btnSign.Size = new Size(293, 29);
            btnSign.TabIndex = 6;
            btnSign.Text = "Solve Trapdoor and Generate Signature";
            btnSign.UseVisualStyleBackColor = true;
            btnSign.Click += btnSign_Click;
            // 
            // dgvSignature
            // 
            dgvSignature.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSignature.Columns.AddRange(new DataGridViewColumn[] { PrivateKeyValue, UsedInSum, BitValue });
            dgvSignature.Location = new Point(3, 23);
            dgvSignature.Name = "dgvSignature";
            dgvSignature.RowHeadersWidth = 51;
            dgvSignature.Size = new Size(434, 369);
            dgvSignature.TabIndex = 0;
            // 
            // PrivateKeyValue
            // 
            PrivateKeyValue.HeaderText = "Private Key Value";
            PrivateKeyValue.MinimumWidth = 6;
            PrivateKeyValue.Name = "PrivateKeyValue";
            PrivateKeyValue.Width = 125;
            // 
            // UsedInSum
            // 
            UsedInSum.HeaderText = "Used in Sum?";
            UsedInSum.MinimumWidth = 6;
            UsedInSum.Name = "UsedInSum";
            UsedInSum.Width = 125;
            // 
            // BitValue
            // 
            BitValue.HeaderText = "Bit Value";
            BitValue.MinimumWidth = 6;
            BitValue.Name = "BitValue";
            BitValue.Width = 125;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(12, 426);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(156, 29);
            btnConfirm.TabIndex = 7;
            btnConfirm.Text = "Confirm and Attach";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // FrmDigitalSignature
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 468);
            Controls.Add(btnConfirm);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmDigitalSignature";
            Text = "Digital Signature";
            Load += FrmDigitalSignature_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSignature).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label lblTargetHash;
        private Label label2;
        private Label lblSenderKey;
        private GroupBox groupBox2;
        private TextBox txtCalcLog;
        private GroupBox groupBox3;
        private DataGridView dgvSignature;
        private DataGridViewTextBoxColumn PrivateKeyValue;
        private DataGridViewTextBoxColumn UsedInSum;
        private DataGridViewTextBoxColumn BitValue;
        private Button btnSign;
        private Button btnConfirm;
    }
}