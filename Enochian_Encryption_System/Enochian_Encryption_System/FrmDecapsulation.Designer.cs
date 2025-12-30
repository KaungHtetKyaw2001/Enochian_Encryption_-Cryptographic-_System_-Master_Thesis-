namespace Enochian_Encryption_System
{
    partial class FrmDecapsulation
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
            txtMultiplier = new TextBox();
            txtModulo = new TextBox();
            txtPrivKey = new TextBox();
            txtEncHeader = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            lblInverse = new Label();
            label5 = new Label();
            lblCalcs = new Label();
            label8 = new Label();
            groupBox3 = new GroupBox();
            lblFormula = new Label();
            label10 = new Label();
            groupBox4 = new GroupBox();
            lblStatus = new Label();
            label6 = new Label();
            lblComparison = new Label();
            label9 = new Label();
            lblResultVector = new Label();
            label7 = new Label();
            btnDecrypt = new Button();
            btnConfirm = new Button();
            label11 = new Label();
            lblOriginalSessionVector = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtMultiplier);
            groupBox1.Controls.Add(txtModulo);
            groupBox1.Controls.Add(txtPrivKey);
            groupBox1.Controls.Add(txtEncHeader);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(385, 337);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stage 1 - Inputs";
            // 
            // txtMultiplier
            // 
            txtMultiplier.Location = new Point(159, 252);
            txtMultiplier.Name = "txtMultiplier";
            txtMultiplier.ReadOnly = true;
            txtMultiplier.Size = new Size(211, 27);
            txtMultiplier.TabIndex = 7;
            // 
            // txtModulo
            // 
            txtModulo.Location = new Point(159, 184);
            txtModulo.Name = "txtModulo";
            txtModulo.ReadOnly = true;
            txtModulo.Size = new Size(211, 27);
            txtModulo.TabIndex = 6;
            // 
            // txtPrivKey
            // 
            txtPrivKey.Location = new Point(159, 109);
            txtPrivKey.Name = "txtPrivKey";
            txtPrivKey.ReadOnly = true;
            txtPrivKey.Size = new Size(211, 27);
            txtPrivKey.TabIndex = 5;
            // 
            // txtEncHeader
            // 
            txtEncHeader.Location = new Point(159, 44);
            txtEncHeader.Name = "txtEncHeader";
            txtEncHeader.ReadOnly = true;
            txtEncHeader.Size = new Size(211, 27);
            txtEncHeader.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 255);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 3;
            label4.Text = "Multiplier";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 187);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 2;
            label3.Text = "Modulo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 112);
            label2.Name = "label2";
            label2.Size = new Size(98, 20);
            label2.TabIndex = 1;
            label2.Text = "Receiver Key";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 47);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 0;
            label1.Text = "Encrypted Header";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblInverse);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(lblCalcs);
            groupBox2.Controls.Add(label8);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 367);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(385, 199);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Stage 2 - Inverse Calculation";
            // 
            // lblInverse
            // 
            lblInverse.BorderStyle = BorderStyle.FixedSingle;
            lblInverse.Location = new Point(159, 146);
            lblInverse.Name = "lblInverse";
            lblInverse.Size = new Size(211, 35);
            lblInverse.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 152);
            label5.Name = "label5";
            label5.Size = new Size(132, 20);
            label5.TabIndex = 2;
            label5.Text = "Inverse Multiplier";
            // 
            // lblCalcs
            // 
            lblCalcs.BorderStyle = BorderStyle.FixedSingle;
            lblCalcs.Location = new Point(19, 86);
            lblCalcs.Name = "lblCalcs";
            lblCalcs.Size = new Size(351, 49);
            lblCalcs.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(19, 47);
            label8.Name = "label8";
            label8.Size = new Size(86, 20);
            label8.TabIndex = 0;
            label8.Text = "Calculation";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblFormula);
            groupBox3.Controls.Add(label10);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(416, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(395, 171);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Stage 3 - Transformation";
            // 
            // lblFormula
            // 
            lblFormula.BorderStyle = BorderStyle.FixedSingle;
            lblFormula.Location = new Point(19, 84);
            lblFormula.Name = "lblFormula";
            lblFormula.Size = new Size(360, 48);
            lblFormula.TabIndex = 1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(19, 47);
            label10.Name = "label10";
            label10.Size = new Size(54, 20);
            label10.TabIndex = 0;
            label10.Text = "Target";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lblOriginalSessionVector);
            groupBox4.Controls.Add(label11);
            groupBox4.Controls.Add(lblStatus);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(lblComparison);
            groupBox4.Controls.Add(label9);
            groupBox4.Controls.Add(lblResultVector);
            groupBox4.Controls.Add(label7);
            groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox4.Location = new Point(416, 199);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(395, 303);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Stage 4 - Trapdoor Solution";
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(138, 237);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(251, 34);
            lblStatus.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 238);
            label6.Name = "label6";
            label6.Size = new Size(53, 20);
            label6.TabIndex = 4;
            label6.Text = "Status";
            // 
            // lblComparison
            // 
            lblComparison.BorderStyle = BorderStyle.FixedSingle;
            lblComparison.Location = new Point(138, 168);
            lblComparison.Name = "lblComparison";
            lblComparison.Size = new Size(251, 34);
            lblComparison.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(17, 174);
            label9.Name = "label9";
            label9.Size = new Size(93, 20);
            label9.TabIndex = 2;
            label9.Text = "Comparison";
            // 
            // lblResultVector
            // 
            lblResultVector.BorderStyle = BorderStyle.FixedSingle;
            lblResultVector.Location = new Point(138, 42);
            lblResultVector.Name = "lblResultVector";
            lblResultVector.Size = new Size(251, 34);
            lblResultVector.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 47);
            label7.Name = "label7";
            label7.Size = new Size(53, 20);
            label7.TabIndex = 0;
            label7.Text = "Result";
            // 
            // btnDecrypt
            // 
            btnDecrypt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDecrypt.Location = new Point(416, 519);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new Size(94, 29);
            btnDecrypt.TabIndex = 6;
            btnDecrypt.Text = "Solve";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Click += btnDecrypt_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(668, 519);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(143, 29);
            btnConfirm.TabIndex = 10;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(17, 100);
            label11.Name = "label11";
            label11.Size = new Size(110, 40);
            label11.TabIndex = 6;
            label11.Text = "Encrypted\r\nSession Vector";
            // 
            // lblOriginalSessionVector
            // 
            lblOriginalSessionVector.BorderStyle = BorderStyle.FixedSingle;
            lblOriginalSessionVector.Location = new Point(138, 106);
            lblOriginalSessionVector.Name = "lblOriginalSessionVector";
            lblOriginalSessionVector.Size = new Size(251, 34);
            lblOriginalSessionVector.TabIndex = 7;
            // 
            // FrmDecapsulation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(825, 581);
            Controls.Add(btnConfirm);
            Controls.Add(btnDecrypt);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmDecapsulation";
            Text = "Decapsulation";
            Load += FrmDecapsulation_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtMultiplier;
        private TextBox txtModulo;
        private TextBox txtPrivKey;
        private TextBox txtEncHeader;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Label label8;
        private Label lblInverse;
        private Label label5;
        private Label lblCalcs;
        private GroupBox groupBox3;
        private Label lblFormula;
        private Label label10;
        private GroupBox groupBox4;
        private Label lblResultVector;
        private Label label7;
        private Label lblComparison;
        private Label label9;
        private Label lblStatus;
        private Label label6;
        private Button btnDecrypt;
        private Button btnConfirm;
        private Label label11;
        private Label lblOriginalSessionVector;
    }
}