namespace Enochian_Encryption_System
{
    partial class FrmKeyFactorGen
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
            btnGenerateKey = new Button();
            groupBox2 = new GroupBox();
            txtParameters = new TextBox();
            dgvMultipliedKeyMatrix = new DataGridView();
            label5 = new Label();
            lblGCD = new Label();
            label4 = new Label();
            dgvOriginalKeyMatrix = new DataGridView();
            lblDeterminant = new Label();
            label = new Label();
            txtKeyFactor = new TextBox();
            label3 = new Label();
            label1 = new Label();
            label2 = new Label();
            btnConfirm = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMultipliedKeyMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOriginalKeyMatrix).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnGenerateKey);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1023, 69);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Key Generation";
            // 
            // btnGenerateKey
            // 
            btnGenerateKey.Location = new Point(6, 26);
            btnGenerateKey.Name = "btnGenerateKey";
            btnGenerateKey.Size = new Size(205, 29);
            btnGenerateKey.TabIndex = 0;
            btnGenerateKey.Text = "Generate Valid Key Matrix";
            btnGenerateKey.UseVisualStyleBackColor = true;
            btnGenerateKey.Click += btnGenerateKey_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtParameters);
            groupBox2.Controls.Add(dgvMultipliedKeyMatrix);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(lblGCD);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(dgvOriginalKeyMatrix);
            groupBox2.Controls.Add(lblDeterminant);
            groupBox2.Controls.Add(label);
            groupBox2.Controls.Add(txtKeyFactor);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(18, 87);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1017, 580);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Key Matrix Preview";
            // 
            // txtParameters
            // 
            txtParameters.Location = new Point(576, 532);
            txtParameters.Name = "txtParameters";
            txtParameters.ReadOnly = true;
            txtParameters.Size = new Size(424, 27);
            txtParameters.TabIndex = 9;
            // 
            // dgvMultipliedKeyMatrix
            // 
            dgvMultipliedKeyMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMultipliedKeyMatrix.Location = new Point(526, 70);
            dgvMultipliedKeyMatrix.Name = "dgvMultipliedKeyMatrix";
            dgvMultipliedKeyMatrix.RowHeadersWidth = 51;
            dgvMultipliedKeyMatrix.Size = new Size(474, 400);
            dgvMultipliedKeyMatrix.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(526, 38);
            label5.Name = "label5";
            label5.Size = new Size(160, 20);
            label5.TabIndex = 11;
            label5.Text = "Multiplied Key Matrix";
            // 
            // lblGCD
            // 
            lblGCD.BorderStyle = BorderStyle.FixedSingle;
            lblGCD.Location = new Point(576, 495);
            lblGCD.Name = "lblGCD";
            lblGCD.Size = new Size(424, 25);
            lblGCD.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 38);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 10;
            label4.Text = "Key Matrix:";
            // 
            // dgvOriginalKeyMatrix
            // 
            dgvOriginalKeyMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOriginalKeyMatrix.Location = new Point(20, 70);
            dgvOriginalKeyMatrix.Name = "dgvOriginalKeyMatrix";
            dgvOriginalKeyMatrix.RowHeadersWidth = 51;
            dgvOriginalKeyMatrix.Size = new Size(478, 400);
            dgvOriginalKeyMatrix.TabIndex = 0;
            // 
            // lblDeterminant
            // 
            lblDeterminant.BorderStyle = BorderStyle.FixedSingle;
            lblDeterminant.Location = new Point(151, 494);
            lblDeterminant.Name = "lblDeterminant";
            lblDeterminant.Size = new Size(301, 25);
            lblDeterminant.TabIndex = 7;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(44, 498);
            label.Name = "label";
            label.Size = new Size(106, 20);
            label.TabIndex = 1;
            label.Text = "Determinant: ";
            // 
            // txtKeyFactor
            // 
            txtKeyFactor.Location = new Point(147, 536);
            txtKeyFactor.Name = "txtKeyFactor";
            txtKeyFactor.ReadOnly = true;
            txtKeyFactor.Size = new Size(305, 27);
            txtKeyFactor.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(458, 496);
            label3.Name = "label3";
            label3.Size = new Size(103, 20);
            label3.TabIndex = 2;
            label3.Text = "GCD(Det,21):";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 539);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 3;
            label1.Text = "Key Factor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(458, 539);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 4;
            label2.Text = "Parameters";
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(865, 687);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(153, 29);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // FrmKeyFactorGen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1047, 728);
            Controls.Add(btnConfirm);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmKeyFactorGen";
            Text = "Key Factor Generation";
            Load += FrmKeyFactorGen_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMultipliedKeyMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOriginalKeyMatrix).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnGenerateKey;
        private GroupBox groupBox2;
        private Label label3;
        private Label label;
        private DataGridView dgvOriginalKeyMatrix;
        private Button btnConfirm;
        private Label label2;
        private Label label1;
        private TextBox txtKeyFactor;
        private Label lblDeterminant;
        private Label lblGCD;
        private TextBox txtParameters;
        private DataGridView dgvMultipliedKeyMatrix;
        private Label label5;
        private Label label4;
    }
}