namespace Enochian_Encryption_System
{
    partial class FrmPlaintextPrep
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
            radFile = new RadioButton();
            radManual = new RadioButton();
            pnlManual = new Panel();
            txtManualInput = new TextBox();
            pnlFile = new Panel();
            lblFileName = new Label();
            btnUpload = new Button();
            btnProcess = new Button();
            groupBox2 = new GroupBox();
            txtPreview = new TextBox();
            btnConfirm = new Button();
            groupBox1.SuspendLayout();
            pnlManual.SuspendLayout();
            pnlFile.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radFile);
            groupBox1.Controls.Add(radManual);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(360, 77);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input Method";
            // 
            // radFile
            // 
            radFile.AutoSize = true;
            radFile.Location = new Point(180, 35);
            radFile.Name = "radFile";
            radFile.Size = new Size(108, 24);
            radFile.TabIndex = 1;
            radFile.TabStop = true;
            radFile.Text = "Upload File";
            radFile.UseVisualStyleBackColor = true;
            radFile.CheckedChanged += radFile_CheckedChanged;
            // 
            // radManual
            // 
            radManual.AutoSize = true;
            radManual.Location = new Point(19, 35);
            radManual.Name = "radManual";
            radManual.Size = new Size(131, 24);
            radManual.TabIndex = 0;
            radManual.TabStop = true;
            radManual.Text = "Type Manually";
            radManual.UseVisualStyleBackColor = true;
            radManual.CheckedChanged += radManual_CheckedChanged;
            // 
            // pnlManual
            // 
            pnlManual.Controls.Add(txtManualInput);
            pnlManual.Location = new Point(12, 95);
            pnlManual.Name = "pnlManual";
            pnlManual.Size = new Size(360, 318);
            pnlManual.TabIndex = 2;
            // 
            // txtManualInput
            // 
            txtManualInput.Location = new Point(19, 13);
            txtManualInput.Multiline = true;
            txtManualInput.Name = "txtManualInput";
            txtManualInput.Size = new Size(324, 291);
            txtManualInput.TabIndex = 0;
            // 
            // pnlFile
            // 
            pnlFile.Controls.Add(lblFileName);
            pnlFile.Controls.Add(btnUpload);
            pnlFile.Location = new Point(390, 23);
            pnlFile.Name = "pnlFile";
            pnlFile.Size = new Size(484, 66);
            pnlFile.TabIndex = 1;
            // 
            // lblFileName
            // 
            lblFileName.BorderStyle = BorderStyle.FixedSingle;
            lblFileName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFileName.Location = new Point(117, 19);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(349, 29);
            lblFileName.TabIndex = 1;
            lblFileName.Text = "No file selected";
            // 
            // btnUpload
            // 
            btnUpload.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpload.Location = new Point(12, 19);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(99, 29);
            btnUpload.TabIndex = 0;
            btnUpload.Text = "Browse File";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnProcess
            // 
            btnProcess.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnProcess.Location = new Point(390, 417);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(215, 29);
            btnProcess.TabIndex = 0;
            btnProcess.Text = "Process and Check Numbers";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtPreview);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(390, 95);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(484, 318);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Preview";
            // 
            // txtPreview
            // 
            txtPreview.Location = new Point(12, 26);
            txtPreview.Multiline = true;
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.Size = new Size(466, 286);
            txtPreview.TabIndex = 0;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(728, 417);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(146, 29);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // FrmPlaintextPrep
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 450);
            Controls.Add(btnConfirm);
            Controls.Add(groupBox2);
            Controls.Add(btnProcess);
            Controls.Add(pnlFile);
            Controls.Add(pnlManual);
            Controls.Add(groupBox1);
            Name = "FrmPlaintextPrep";
            Text = "Plaintext Preparation";
            Load += FrmPlaintextPrep_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pnlManual.ResumeLayout(false);
            pnlManual.PerformLayout();
            pnlFile.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton radManual;
        private RadioButton radFile;
        private Panel pnlManual;
        private TextBox txtManualInput;
        private Panel pnlFile;
        private Button btnProcess;
        private Label lblFileName;
        private Button btnUpload;
        private GroupBox groupBox2;
        private TextBox txtPreview;
        private Button btnConfirm;
    }
}