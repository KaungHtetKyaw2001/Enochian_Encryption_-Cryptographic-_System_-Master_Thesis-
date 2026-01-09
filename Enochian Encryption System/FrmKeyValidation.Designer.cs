namespace Enochian_Encryption_System
{
    partial class FrmKeyValidation
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
            label3 = new Label();
            lblDet = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvOriginal = new DataGridView();
            btnValidate = new Button();
            btnConfirm = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOriginal).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblStatus);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblDet);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(483, 174);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Validation Data";
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(115, 84);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(362, 32);
            lblStatus.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 89);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 4;
            label3.Text = "Status:";
            // 
            // lblDet
            // 
            lblDet.BorderStyle = BorderStyle.FixedSingle;
            lblDet.Location = new Point(115, 37);
            lblDet.Name = "lblDet";
            lblDet.Size = new Size(362, 32);
            lblDet.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 42);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 0;
            label1.Text = "Determinant:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvOriginal);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 192);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(483, 355);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Matrices";
            // 
            // dgvOriginal
            // 
            dgvOriginal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOriginal.Location = new Point(11, 26);
            dgvOriginal.Name = "dgvOriginal";
            dgvOriginal.RowHeadersWidth = 51;
            dgvOriginal.Size = new Size(466, 323);
            dgvOriginal.TabIndex = 3;
            // 
            // btnValidate
            // 
            btnValidate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnValidate.Location = new Point(23, 568);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(226, 29);
            btnValidate.TabIndex = 7;
            btnValidate.Text = "Calculate Inverse and Validate";
            btnValidate.UseVisualStyleBackColor = true;
            btnValidate.Click += btnValidate_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(346, 568);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(143, 29);
            btnConfirm.TabIndex = 8;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // FrmKeyValidation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 609);
            Controls.Add(btnConfirm);
            Controls.Add(btnValidate);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmKeyValidation";
            Text = "Key Matrix Validation";
            Load += FrmKeyValidation_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOriginal).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblStatus;
        private Label label3;
        private Label lblDet;
        private Label label1;
        private GroupBox groupBox2;
        private DataGridView dgvOriginal;
        private Button btnValidate;
        private Button btnConfirm;
    }
}