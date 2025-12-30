namespace Enochian_Encryption_System
{
    partial class FrmMatrixAllocation
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
            btnRandomSize = new Button();
            numSize = new NumericUpDown();
            label1 = new Label();
            groupBox2 = new GroupBox();
            btnAllocate = new Button();
            txtInput = new TextBox();
            groupBox3 = new GroupBox();
            rtbAllocationPreview = new RichTextBox();
            lblBlockCount = new Label();
            btnConfirm = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSize).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRandomSize);
            groupBox1.Controls.Add(numSize);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 73);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Matrix Configuration";
            // 
            // btnRandomSize
            // 
            btnRandomSize.Location = new Point(236, 33);
            btnRandomSize.Name = "btnRandomSize";
            btnRandomSize.Size = new Size(130, 29);
            btnRandomSize.TabIndex = 2;
            btnRandomSize.Text = "Randomize Size";
            btnRandomSize.UseVisualStyleBackColor = true;
            btnRandomSize.Click += btnRandomSize_Click;
            // 
            // numSize
            // 
            numSize.Location = new Point(175, 35);
            numSize.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numSize.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numSize.Name = "numSize";
            numSize.Size = new Size(55, 27);
            numSize.TabIndex = 1;
            numSize.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 35);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 0;
            label1.Text = "Select Matrix Size (N):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAllocate);
            groupBox2.Controls.Add(txtInput);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 91);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(776, 347);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Input Preview";
            // 
            // btnAllocate
            // 
            btnAllocate.Location = new Point(616, 305);
            btnAllocate.Name = "btnAllocate";
            btnAllocate.Size = new Size(154, 29);
            btnAllocate.TabIndex = 1;
            btnAllocate.Text = "Perform Allocation";
            btnAllocate.UseVisualStyleBackColor = true;
            btnAllocate.Click += btnAllocate_Click;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(6, 26);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ReadOnly = true;
            txtInput.Size = new Size(764, 269);
            txtInput.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rtbAllocationPreview);
            groupBox3.Controls.Add(lblBlockCount);
            groupBox3.Controls.Add(btnConfirm);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(12, 444);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(776, 347);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Allocation Results";
            // 
            // rtbAllocationPreview
            // 
            rtbAllocationPreview.Font = new Font("Consolas", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rtbAllocationPreview.Location = new Point(6, 59);
            rtbAllocationPreview.Name = "rtbAllocationPreview";
            rtbAllocationPreview.ReadOnly = true;
            rtbAllocationPreview.Size = new Size(764, 247);
            rtbAllocationPreview.TabIndex = 3;
            rtbAllocationPreview.Text = "";
            rtbAllocationPreview.WordWrap = false;
            // 
            // lblBlockCount
            // 
            lblBlockCount.AutoSize = true;
            lblBlockCount.Location = new Point(6, 36);
            lblBlockCount.Name = "lblBlockCount";
            lblBlockCount.Size = new Size(110, 20);
            lblBlockCount.TabIndex = 2;
            lblBlockCount.Text = "Total Blocks: 0";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(616, 312);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(154, 29);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // FrmMatrixAllocation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 801);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmMatrixAllocation";
            Text = "Matrix Allocation";
            Load += FrmMatrixAllocation_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSize).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnRandomSize;
        private NumericUpDown numSize;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnAllocate;
        private TextBox txtInput;
        private GroupBox groupBox3;
        private Label lblBlockCount;
        private Button btnConfirm;
        private RichTextBox rtbAllocationPreview;
    }
}