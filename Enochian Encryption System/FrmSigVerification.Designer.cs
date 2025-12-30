namespace Enochian_Encryption_System
{
    partial class FrmSigVerification
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
            lblKeyParams = new Label();
            txtPublicKey = new TextBox();
            txtSigVector = new TextBox();
            txtTargetHash = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            lblChecksum = new Label();
            txtChecksumFormula = new TextBox();
            label8 = new Label();
            label9 = new Label();
            groupBox3 = new GroupBox();
            lblInverseResult = new Label();
            lblInverseParam = new Label();
            label10 = new Label();
            label11 = new Label();
            groupBox4 = new GroupBox();
            lblFinalStatus = new Label();
            label12 = new Label();
            btnVerify = new Button();
            btnConfirm = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblKeyParams);
            groupBox1.Controls.Add(txtPublicKey);
            groupBox1.Controls.Add(txtSigVector);
            groupBox1.Controls.Add(txtTargetHash);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(447, 259);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stage 1 Receiver Inventory";
            // 
            // lblKeyParams
            // 
            lblKeyParams.BorderStyle = BorderStyle.FixedSingle;
            lblKeyParams.Location = new Point(173, 195);
            lblKeyParams.Name = "lblKeyParams";
            lblKeyParams.Size = new Size(268, 35);
            lblKeyParams.TabIndex = 7;
            // 
            // txtPublicKey
            // 
            txtPublicKey.Location = new Point(173, 138);
            txtPublicKey.Name = "txtPublicKey";
            txtPublicKey.ReadOnly = true;
            txtPublicKey.Size = new Size(268, 27);
            txtPublicKey.TabIndex = 6;
            // 
            // txtSigVector
            // 
            txtSigVector.Location = new Point(173, 85);
            txtSigVector.Name = "txtSigVector";
            txtSigVector.ReadOnly = true;
            txtSigVector.Size = new Size(268, 27);
            txtSigVector.TabIndex = 5;
            // 
            // txtTargetHash
            // 
            txtTargetHash.Location = new Point(173, 36);
            txtTargetHash.Name = "txtTargetHash";
            txtTargetHash.ReadOnly = true;
            txtTargetHash.Size = new Size(268, 27);
            txtTargetHash.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 195);
            label4.Name = "label4";
            label4.Size = new Size(141, 20);
            label4.TabIndex = 3;
            label4.Text = "Sender Parameters";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 141);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 2;
            label3.Text = "Sender Key";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 88);
            label2.Name = "label2";
            label2.Size = new Size(142, 20);
            label2.TabIndex = 1;
            label2.Text = "Received Signature";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 39);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 0;
            label1.Text = "Received Hash";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblChecksum);
            groupBox2.Controls.Add(txtChecksumFormula);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label9);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 286);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(447, 148);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "Stage 2 Public Key Check";
            // 
            // lblChecksum
            // 
            lblChecksum.BorderStyle = BorderStyle.FixedSingle;
            lblChecksum.Location = new Point(173, 88);
            lblChecksum.Name = "lblChecksum";
            lblChecksum.Size = new Size(268, 35);
            lblChecksum.TabIndex = 7;
            // 
            // txtChecksumFormula
            // 
            txtChecksumFormula.Location = new Point(173, 36);
            txtChecksumFormula.Name = "txtChecksumFormula";
            txtChecksumFormula.ReadOnly = true;
            txtChecksumFormula.Size = new Size(268, 27);
            txtChecksumFormula.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(19, 97);
            label8.Name = "label8";
            label8.Size = new Size(70, 20);
            label8.TabIndex = 1;
            label8.Text = "The Sum";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(19, 39);
            label9.Name = "label9";
            label9.Size = new Size(142, 20);
            label9.TabIndex = 0;
            label9.Text = "Checksum Formula";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblInverseResult);
            groupBox3.Controls.Add(lblInverseParam);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label11);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(465, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(481, 146);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Stage 3 Inverse Transformation";
            // 
            // lblInverseResult
            // 
            lblInverseResult.BorderStyle = BorderStyle.FixedSingle;
            lblInverseResult.Location = new Point(173, 87);
            lblInverseResult.Name = "lblInverseResult";
            lblInverseResult.Size = new Size(302, 35);
            lblInverseResult.TabIndex = 8;
            // 
            // lblInverseParam
            // 
            lblInverseParam.BorderStyle = BorderStyle.FixedSingle;
            lblInverseParam.Location = new Point(173, 36);
            lblInverseParam.Name = "lblInverseParam";
            lblInverseParam.Size = new Size(302, 35);
            lblInverseParam.TabIndex = 7;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(19, 96);
            label10.Name = "label10";
            label10.Size = new Size(108, 20);
            label10.TabIndex = 1;
            label10.Text = "Inverse Result";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(19, 39);
            label11.Name = "label11";
            label11.Size = new Size(141, 20);
            label11.TabIndex = 0;
            label11.Text = "Inversed Multiplier";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lblFinalStatus);
            groupBox4.Controls.Add(label12);
            groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox4.Location = new Point(465, 164);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(481, 270);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "Step 4 Comparison";
            // 
            // lblFinalStatus
            // 
            lblFinalStatus.BorderStyle = BorderStyle.FixedSingle;
            lblFinalStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFinalStatus.Location = new Point(19, 72);
            lblFinalStatus.Name = "lblFinalStatus";
            lblFinalStatus.Size = new Size(456, 182);
            lblFinalStatus.TabIndex = 7;
            lblFinalStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(19, 39);
            label12.Name = "label12";
            label12.Size = new Size(53, 20);
            label12.TabIndex = 0;
            label12.Text = "Status";
            // 
            // btnVerify
            // 
            btnVerify.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnVerify.Location = new Point(12, 440);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(195, 29);
            btnVerify.TabIndex = 8;
            btnVerify.Text = "Run Verification Protocol";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += btnVerify_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(751, 440);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(195, 29);
            btnConfirm.TabIndex = 10;
            btnConfirm.Text = "Proceed to Decapsulation";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // FrmSigVerification
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 480);
            Controls.Add(btnConfirm);
            Controls.Add(btnVerify);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmSigVerification";
            Text = "Signature Verification";
            Load += FrmSigVerification_Load;
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
        private TextBox txtTargetHash;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblKeyParams;
        private TextBox txtPublicKey;
        private TextBox txtSigVector;
        private GroupBox groupBox2;
        private Label lblChecksum;
        private TextBox txtChecksumFormula;
        private Label label8;
        private Label label9;
        private GroupBox groupBox3;
        private Label lblInverseParam;
        private Label label10;
        private Label label11;
        private Label lblInverseResult;
        private GroupBox groupBox4;
        private Label lblFinalStatus;
        private Label label12;
        private Button btnVerify;
        private Button btnConfirm;
    }
}