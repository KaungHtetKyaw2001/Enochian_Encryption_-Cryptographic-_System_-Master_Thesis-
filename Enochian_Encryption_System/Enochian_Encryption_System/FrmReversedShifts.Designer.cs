namespace Enochian_Encryption_System
{
    partial class FrmReversedShifts
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
            txtAddtoArray = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtConvertingNumberMatrixtoEnochianAlphabetsMatrix = new TextBox();
            groupBox2 = new GroupBox();
            lblC2 = new Label();
            txtFirstUnshiftC2 = new TextBox();
            groupBox3 = new GroupBox();
            txtEnglishRemapping = new TextBox();
            label3 = new Label();
            groupBox4 = new GroupBox();
            lblC1 = new Label();
            txtSecondUnshiftC1 = new TextBox();
            lblStatus = new Label();
            btnProcess = new Button();
            btnConfirm = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtAddtoArray);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtConvertingNumberMatrixtoEnochianAlphabetsMatrix);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(599, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(581, 528);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mapping (Array Split)";
            // 
            // txtAddtoArray
            // 
            txtAddtoArray.Location = new Point(6, 350);
            txtAddtoArray.Multiline = true;
            txtAddtoArray.Name = "txtAddtoArray";
            txtAddtoArray.ReadOnly = true;
            txtAddtoArray.Size = new Size(569, 163);
            txtAddtoArray.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 327);
            label2.Name = "label2";
            label2.Size = new Size(115, 20);
            label2.TabIndex = 2;
            label2.Text = "Split into Array";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 29);
            label1.Name = "label1";
            label1.Size = new Size(416, 20);
            label1.TabIndex = 1;
            label1.Text = "Converting Matrix Numbers to Enochian Alphabets Matrix";
            // 
            // txtConvertingNumberMatrixtoEnochianAlphabetsMatrix
            // 
            txtConvertingNumberMatrixtoEnochianAlphabetsMatrix.Location = new Point(6, 59);
            txtConvertingNumberMatrixtoEnochianAlphabetsMatrix.Multiline = true;
            txtConvertingNumberMatrixtoEnochianAlphabetsMatrix.Name = "txtConvertingNumberMatrixtoEnochianAlphabetsMatrix";
            txtConvertingNumberMatrixtoEnochianAlphabetsMatrix.ReadOnly = true;
            txtConvertingNumberMatrixtoEnochianAlphabetsMatrix.Size = new Size(569, 265);
            txtConvertingNumberMatrixtoEnochianAlphabetsMatrix.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblC2);
            groupBox2.Controls.Add(txtFirstUnshiftC2);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(5, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(588, 482);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Reverse Shift (C2)";
            // 
            // lblC2
            // 
            lblC2.BorderStyle = BorderStyle.FixedSingle;
            lblC2.Location = new Point(6, 445);
            lblC2.Name = "lblC2";
            lblC2.Size = new Size(326, 25);
            lblC2.TabIndex = 2;
            // 
            // txtFirstUnshiftC2
            // 
            txtFirstUnshiftC2.Location = new Point(6, 26);
            txtFirstUnshiftC2.Multiline = true;
            txtFirstUnshiftC2.Name = "txtFirstUnshiftC2";
            txtFirstUnshiftC2.ReadOnly = true;
            txtFirstUnshiftC2.Size = new Size(576, 401);
            txtFirstUnshiftC2.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtEnglishRemapping);
            groupBox3.Controls.Add(label3);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(599, 541);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(581, 400);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "English Remapping";
            // 
            // txtEnglishRemapping
            // 
            txtEnglishRemapping.Location = new Point(5, 58);
            txtEnglishRemapping.Multiline = true;
            txtEnglishRemapping.Name = "txtEnglishRemapping";
            txtEnglishRemapping.ReadOnly = true;
            txtEnglishRemapping.Size = new Size(569, 322);
            txtEnglishRemapping.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 35);
            label3.Name = "label3";
            label3.Size = new Size(344, 20);
            label3.TabIndex = 4;
            label3.Text = "Remapping Enochian-to-English Alphabet Array";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lblC1);
            groupBox4.Controls.Add(txtSecondUnshiftC1);
            groupBox4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox4.Location = new Point(5, 507);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(588, 446);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "Reverse Shift (C1)";
            // 
            // lblC1
            // 
            lblC1.BorderStyle = BorderStyle.FixedSingle;
            lblC1.Location = new Point(6, 409);
            lblC1.Name = "lblC1";
            lblC1.Size = new Size(326, 25);
            lblC1.TabIndex = 4;
            // 
            // txtSecondUnshiftC1
            // 
            txtSecondUnshiftC1.Location = new Point(6, 26);
            txtSecondUnshiftC1.Multiline = true;
            txtSecondUnshiftC1.Name = "txtSecondUnshiftC1";
            txtSecondUnshiftC1.ReadOnly = true;
            txtSecondUnshiftC1.Size = new Size(576, 371);
            txtSecondUnshiftC1.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(396, 956);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(326, 25);
            lblStatus.TabIndex = 5;
            // 
            // btnProcess
            // 
            btnProcess.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnProcess.Location = new Point(12, 959);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(224, 29);
            btnProcess.TabIndex = 6;
            btnProcess.Text = "Execute Reverse Engineering";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(956, 956);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(224, 29);
            btnConfirm.TabIndex = 7;
            btnConfirm.Text = "Proceed to Finalization";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // FrmReversedShifts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1196, 1010);
            Controls.Add(btnConfirm);
            Controls.Add(btnProcess);
            Controls.Add(lblStatus);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmReversedShifts";
            Text = "Reversed Shifts";
            Load += FrmReversedShifts_Load;
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
        private TextBox txtConvertingNumberMatrixtoEnochianAlphabetsMatrix;
        private GroupBox groupBox2;
        private Label lblC2;
        private TextBox txtFirstUnshiftC2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label lblC1;
        private TextBox txtSecondUnshiftC1;
        private Label lblStatus;
        private Button btnProcess;
        private Button btnConfirm;
        private Label label1;
        private Label label2;
        private TextBox txtAddtoArray;
        private TextBox txtEnglishRemapping;
        private Label label3;
    }
}