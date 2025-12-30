namespace Enochian_Encryption_System
{
    partial class FrmSecondShift
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
            btnApplyShift = new Button();
            txtC2 = new TextBox();
            label2 = new Label();
            txtInput = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnConfirm = new Button();
            txtOutput = new TextBox();
            label4 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnApplyShift);
            groupBox1.Controls.Add(txtC2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtInput);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(806, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input Mapping";
            // 
            // btnApplyShift
            // 
            btnApplyShift.Location = new Point(566, 390);
            btnApplyShift.Name = "btnApplyShift";
            btnApplyShift.Size = new Size(234, 29);
            btnApplyShift.TabIndex = 1;
            btnApplyShift.Text = "Execute Second Shift (Mod 21)";
            btnApplyShift.UseVisualStyleBackColor = true;
            btnApplyShift.Click += btnApplyShift_Click;
            // 
            // txtC2
            // 
            txtC2.Location = new Point(229, 392);
            txtC2.Name = "txtC2";
            txtC2.ReadOnly = true;
            txtC2.Size = new Size(50, 27);
            txtC2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 394);
            label2.Name = "label2";
            label2.Size = new Size(217, 20);
            label2.TabIndex = 2;
            label2.Text = "Shift Value (C2 from Session):";
            // 
            // txtInput
            // 
            txtInput.Location = new Point(6, 69);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ReadOnly = true;
            txtInput.Size = new Size(794, 314);
            txtInput.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 34);
            label1.Name = "label1";
            label1.Size = new Size(243, 20);
            label1.TabIndex = 0;
            label1.Text = "Enochian Mapping (From Step 6):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnConfirm);
            groupBox2.Controls.Add(txtOutput);
            groupBox2.Controls.Add(label4);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 444);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(806, 426);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Mathematical Output";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(658, 390);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(142, 29);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(6, 69);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.Size = new Size(794, 314);
            txtOutput.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 34);
            label4.Name = "label4";
            label4.Size = new Size(183, 20);
            label4.TabIndex = 0;
            label4.Text = "Final Enochian Sequence:";
            // 
            // FrmSecondShift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 876);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmSecondShift";
            Text = "Second Shift";
            Load += FrmSecondShift_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnApplyShift;
        private TextBox txtC2;
        private Label label2;
        private TextBox txtInput;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnConfirm;
        private TextBox txtOutput;
        private Label label4;
    }
}