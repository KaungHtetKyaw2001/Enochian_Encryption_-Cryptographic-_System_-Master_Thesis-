namespace Enochian_Encryption_System
{
    partial class FrmSessionSetup
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
            label5 = new Label();
            txtC1 = new TextBox();
            txtC2 = new TextBox();
            txtLx = new TextBox();
            txtLy = new TextBox();
            txtLz = new TextBox();
            btnRandom = new Button();
            btnSave = new Button();
            label6 = new Label();
            lblVector = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(26, 28);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 0;
            label1.Text = "First Shift Value (C1)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(26, 79);
            label2.Name = "label2";
            label2.Size = new Size(172, 20);
            label2.TabIndex = 1;
            label2.Text = "Second Shift Value (C2)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(26, 133);
            label3.Name = "label3";
            label3.Size = new Size(172, 20);
            label3.TabIndex = 2;
            label3.Text = "First Lorentz Input (x0)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(26, 184);
            label4.Name = "label4";
            label4.Size = new Size(191, 20);
            label4.TabIndex = 3;
            label4.Text = "Second Lorentz Input (x1)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(26, 240);
            label5.Name = "label5";
            label5.Size = new Size(178, 20);
            label5.TabIndex = 4;
            label5.Text = "Third Lorentz Input (x3)";
            // 
            // txtC1
            // 
            txtC1.Location = new Point(254, 25);
            txtC1.Name = "txtC1";
            txtC1.ReadOnly = true;
            txtC1.Size = new Size(271, 27);
            txtC1.TabIndex = 5;
            // 
            // txtC2
            // 
            txtC2.Location = new Point(254, 76);
            txtC2.Name = "txtC2";
            txtC2.ReadOnly = true;
            txtC2.Size = new Size(271, 27);
            txtC2.TabIndex = 6;
            // 
            // txtLx
            // 
            txtLx.Location = new Point(254, 130);
            txtLx.Name = "txtLx";
            txtLx.ReadOnly = true;
            txtLx.Size = new Size(271, 27);
            txtLx.TabIndex = 7;
            // 
            // txtLy
            // 
            txtLy.Location = new Point(254, 179);
            txtLy.Name = "txtLy";
            txtLy.ReadOnly = true;
            txtLy.Size = new Size(271, 27);
            txtLy.TabIndex = 8;
            // 
            // txtLz
            // 
            txtLz.Location = new Point(254, 235);
            txtLz.Name = "txtLz";
            txtLz.ReadOnly = true;
            txtLz.Size = new Size(271, 27);
            txtLz.TabIndex = 9;
            // 
            // btnRandom
            // 
            btnRandom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRandom.Location = new Point(98, 357);
            btnRandom.Name = "btnRandom";
            btnRandom.Size = new Size(139, 29);
            btnRandom.TabIndex = 10;
            btnRandom.Text = "Auto-Generate";
            btnRandom.UseVisualStyleBackColor = true;
            btnRandom.Click += btnRandom_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.Location = new Point(322, 357);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(139, 29);
            btnSave.TabIndex = 11;
            btnSave.Text = "Save and Close";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(26, 298);
            label6.Name = "label6";
            label6.Size = new Size(110, 20);
            label6.TabIndex = 12;
            label6.Text = "Session Vector";
            // 
            // lblVector
            // 
            lblVector.BorderStyle = BorderStyle.FixedSingle;
            lblVector.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblVector.Location = new Point(254, 289);
            lblVector.Name = "lblVector";
            lblVector.Size = new Size(271, 42);
            lblVector.TabIndex = 13;
            // 
            // FrmSessionSetup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 450);
            Controls.Add(lblVector);
            Controls.Add(label6);
            Controls.Add(btnSave);
            Controls.Add(btnRandom);
            Controls.Add(txtLz);
            Controls.Add(txtLy);
            Controls.Add(txtLx);
            Controls.Add(txtC2);
            Controls.Add(txtC1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmSessionSetup";
            Text = "Session Setup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtC1;
        private TextBox txtC2;
        private TextBox txtLx;
        private TextBox txtLy;
        private TextBox txtLz;
        private Button btnRandom;
        private Button btnSave;
        private Label label6;
        private Label lblVector;
    }
}