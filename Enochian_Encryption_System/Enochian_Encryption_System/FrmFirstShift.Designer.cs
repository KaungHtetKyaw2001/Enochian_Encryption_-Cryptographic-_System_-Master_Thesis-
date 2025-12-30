namespace Enochian_Encryption_System
{
    partial class FrmFirstShift
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
            btnShift = new Button();
            txtC1 = new TextBox();
            label2 = new Label();
            txtInput = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnConfirm = new Button();
            txtOutput = new TextBox();
            label3 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnShift);
            groupBox1.Controls.Add(txtC1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtInput);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(853, 404);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input Data";
            // 
            // btnShift
            // 
            btnShift.Location = new Point(699, 366);
            btnShift.Name = "btnShift";
            btnShift.Size = new Size(133, 29);
            btnShift.TabIndex = 4;
            btnShift.Text = "Apply First Shift";
            btnShift.UseVisualStyleBackColor = true;
            btnShift.Click += btnShift_Click;
            // 
            // txtC1
            // 
            txtC1.Location = new Point(239, 367);
            txtC1.Name = "txtC1";
            txtC1.ReadOnly = true;
            txtC1.Size = new Size(50, 27);
            txtC1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 370);
            label2.Name = "label2";
            label2.Size = new Size(217, 20);
            label2.TabIndex = 2;
            label2.Text = "Shift Value (C1 from Session):";
            // 
            // txtInput
            // 
            txtInput.Location = new Point(16, 68);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ReadOnly = true;
            txtInput.Size = new Size(816, 290);
            txtInput.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 34);
            label1.Name = "label1";
            label1.Size = new Size(130, 20);
            label1.TabIndex = 0;
            label1.Text = "Cleaned Plaintext";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnConfirm);
            groupBox2.Controls.Add(txtOutput);
            groupBox2.Controls.Add(label3);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 431);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(853, 371);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Output";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(678, 328);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(154, 29);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(16, 68);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.Size = new Size(816, 248);
            txtOutput.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 36);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 0;
            label3.Text = "Shifted Text:";
            // 
            // FrmFirstShift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 814);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmFirstShift";
            Text = "First Shift";
            Load += FrmFirstShift_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtInput;
        private Label label1;
        private Button btnShift;
        private TextBox txtC1;
        private Label label2;
        private GroupBox groupBox2;
        private TextBox txtOutput;
        private Label label3;
        private Button btnConfirm;
    }
}