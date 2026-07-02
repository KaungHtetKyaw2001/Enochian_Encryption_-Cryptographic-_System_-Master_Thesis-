namespace Enochian_Encryption_System
{
    partial class FrmRegeneration
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
            lblStatus = new Label();
            lblZStatus = new Label();
            txtSeedY = new TextBox();
            txtSeedX = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvBaseKeyMatrix = new DataGridView();
            label10 = new Label();
            btnConfirm = new Button();
            label7 = new Label();
            btnReconstruct = new Button();
            dgvKeyFactorMultipliedMatrix = new DataGridView();
            groupBox3 = new GroupBox();
            lblMultipleFactorCheck = new Label();
            label9 = new Label();
            label8 = new Label();
            lblModuloCheck = new Label();
            lblKeyFactor = new Label();
            label6 = new Label();
            lblValidation = new Label();
            lblDeterminant = new Label();
            label5 = new Label();
            label4 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaseKeyMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvKeyFactorMultipliedMatrix).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblStatus);
            groupBox1.Controls.Add(lblZStatus);
            groupBox1.Controls.Add(txtSeedY);
            groupBox1.Controls.Add(txtSeedX);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(533, 292);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input Parameters";
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.ForeColor = SystemColors.ActiveCaptionText;
            lblStatus.Location = new Point(20, 239);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(507, 33);
            lblStatus.TabIndex = 6;
            // 
            // lblZStatus
            // 
            lblZStatus.BorderStyle = BorderStyle.FixedSingle;
            lblZStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            lblZStatus.ForeColor = SystemColors.ButtonShadow;
            lblZStatus.Location = new Point(204, 162);
            lblZStatus.Name = "lblZStatus";
            lblZStatus.Size = new Size(323, 33);
            lblZStatus.TabIndex = 5;
            // 
            // txtSeedY
            // 
            txtSeedY.Location = new Point(204, 97);
            txtSeedY.Name = "txtSeedY";
            txtSeedY.ReadOnly = true;
            txtSeedY.Size = new Size(323, 27);
            txtSeedY.TabIndex = 4;
            // 
            // txtSeedX
            // 
            txtSeedX.Location = new Point(204, 36);
            txtSeedX.Name = "txtSeedX";
            txtSeedX.ReadOnly = true;
            txtSeedX.Size = new Size(323, 27);
            txtSeedX.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            label3.ForeColor = SystemColors.ButtonShadow;
            label3.Location = new Point(20, 168);
            label3.Name = "label3";
            label3.Size = new Size(126, 20);
            label3.TabIndex = 2;
            label3.Text = "Lorenz Z Unused";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 100);
            label2.Name = "label2";
            label2.Size = new Size(162, 20);
            label2.TabIndex = 1;
            label2.Text = "Lorenz Y / S-Box Seed";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 39);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 0;
            label1.Text = "Lorenz X / Key Seed";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvBaseKeyMatrix);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(btnConfirm);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(btnReconstruct);
            groupBox2.Controls.Add(dgvKeyFactorMultipliedMatrix);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 310);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1140, 446);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Matrix Reconstruction";
            // 
            // dgvBaseKeyMatrix
            // 
            dgvBaseKeyMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaseKeyMatrix.Location = new Point(577, 67);
            dgvBaseKeyMatrix.Name = "dgvBaseKeyMatrix";
            dgvBaseKeyMatrix.RowHeadersWidth = 51;
            dgvBaseKeyMatrix.Size = new Size(547, 338);
            dgvBaseKeyMatrix.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(587, 33);
            label10.Name = "label10";
            label10.Size = new Size(122, 20);
            label10.TabIndex = 16;
            label10.Text = "Base Key Matrix";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(993, 411);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(141, 29);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 33);
            label7.Name = "label7";
            label7.Size = new Size(208, 20);
            label7.TabIndex = 15;
            label7.Text = "Key Factor Multiplied Matrix";
            // 
            // btnReconstruct
            // 
            btnReconstruct.Location = new Point(10, 411);
            btnReconstruct.Name = "btnReconstruct";
            btnReconstruct.Size = new Size(141, 29);
            btnReconstruct.TabIndex = 1;
            btnReconstruct.Text = "Regenerate Key";
            btnReconstruct.UseVisualStyleBackColor = true;
            btnReconstruct.Click += btnReconstruct_Click;
            // 
            // dgvKeyFactorMultipliedMatrix
            // 
            dgvKeyFactorMultipliedMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKeyFactorMultipliedMatrix.Location = new Point(10, 67);
            dgvKeyFactorMultipliedMatrix.Name = "dgvKeyFactorMultipliedMatrix";
            dgvKeyFactorMultipliedMatrix.RowHeadersWidth = 51;
            dgvKeyFactorMultipliedMatrix.Size = new Size(523, 338);
            dgvKeyFactorMultipliedMatrix.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblMultipleFactorCheck);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(lblModuloCheck);
            groupBox3.Controls.Add(lblKeyFactor);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(lblValidation);
            groupBox3.Controls.Add(lblDeterminant);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(label4);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(551, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(601, 292);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Validation Check";
            // 
            // lblMultipleFactorCheck
            // 
            lblMultipleFactorCheck.BorderStyle = BorderStyle.FixedSingle;
            lblMultipleFactorCheck.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            lblMultipleFactorCheck.ForeColor = SystemColors.ButtonShadow;
            lblMultipleFactorCheck.Location = new Point(171, 186);
            lblMultipleFactorCheck.Name = "lblMultipleFactorCheck";
            lblMultipleFactorCheck.Size = new Size(424, 33);
            lblMultipleFactorCheck.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(8, 186);
            label9.Name = "label9";
            label9.Size = new Size(137, 40);
            label9.TabIndex = 13;
            label9.Text = "21 Multiple Factor\r\nCheck";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(8, 138);
            label8.Name = "label8";
            label8.Size = new Size(108, 20);
            label8.TabIndex = 12;
            label8.Text = "Modulo Check";
            // 
            // lblModuloCheck
            // 
            lblModuloCheck.BorderStyle = BorderStyle.FixedSingle;
            lblModuloCheck.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            lblModuloCheck.ForeColor = SystemColors.ButtonShadow;
            lblModuloCheck.Location = new Point(171, 131);
            lblModuloCheck.Name = "lblModuloCheck";
            lblModuloCheck.Size = new Size(424, 33);
            lblModuloCheck.TabIndex = 11;
            // 
            // lblKeyFactor
            // 
            lblKeyFactor.BorderStyle = BorderStyle.FixedSingle;
            lblKeyFactor.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            lblKeyFactor.ForeColor = SystemColors.ButtonShadow;
            lblKeyFactor.Location = new Point(171, 76);
            lblKeyFactor.Name = "lblKeyFactor";
            lblKeyFactor.Size = new Size(424, 33);
            lblKeyFactor.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 86);
            label6.Name = "label6";
            label6.Size = new Size(83, 20);
            label6.TabIndex = 9;
            label6.Text = "Key Factor";
            // 
            // lblValidation
            // 
            lblValidation.BorderStyle = BorderStyle.FixedSingle;
            lblValidation.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            lblValidation.ForeColor = SystemColors.ButtonShadow;
            lblValidation.Location = new Point(171, 239);
            lblValidation.Name = "lblValidation";
            lblValidation.Size = new Size(424, 33);
            lblValidation.TabIndex = 8;
            // 
            // lblDeterminant
            // 
            lblDeterminant.BorderStyle = BorderStyle.FixedSingle;
            lblDeterminant.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            lblDeterminant.ForeColor = SystemColors.ButtonShadow;
            lblDeterminant.Location = new Point(171, 30);
            lblDeterminant.Name = "lblDeterminant";
            lblDeterminant.Size = new Size(424, 33);
            lblDeterminant.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 240);
            label5.Name = "label5";
            label5.Size = new Size(127, 20);
            label5.TabIndex = 7;
            label5.Text = "Validation Status";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 36);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 6;
            label4.Text = "Determinant";
            // 
            // FrmRegeneration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1164, 768);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmRegeneration";
            Text = "Regeneration";
            Load += FrmRegeneration_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaseKeyMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvKeyFactorMultipliedMatrix).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label lblZStatus;
        private TextBox txtSeedY;
        private TextBox txtSeedX;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dgvKeyFactorMultipliedMatrix;
        private Button btnReconstruct;
        private GroupBox groupBox3;
        private Button btnConfirm;
        private Label lblValidation;
        private Label lblDeterminant;
        private Label label5;
        private Label label4;
        private Label lblStatus;
        private Label lblModuloCheck;
        private Label lblKeyFactor;
        private Label label6;
        private Label lblMultipleFactorCheck;
        private Label label9;
        private Label label8;
        private Label label7;
        private DataGridView dgvBaseKeyMatrix;
        private Label label10;
    }
}