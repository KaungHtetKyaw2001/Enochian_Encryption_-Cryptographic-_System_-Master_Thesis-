namespace Enochian_Encryption_System
{
    partial class FrmAlphabetMapping
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
            btnMap = new Button();
            txtInput = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            lstLog = new ListBox();
            label3 = new Label();
            btnConfirm = new Button();
            txtOutput = new TextBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnMap);
            groupBox1.Controls.Add(txtInput);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 444);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input Data";
            // 
            // btnMap
            // 
            btnMap.Location = new Point(16, 400);
            btnMap.Name = "btnMap";
            btnMap.Size = new Size(134, 29);
            btnMap.TabIndex = 1;
            btnMap.Text = "Map to Enochian";
            btnMap.UseVisualStyleBackColor = true;
            btnMap.Click += btnMap_Click;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(10, 59);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ReadOnly = true;
            txtInput.Size = new Size(754, 335);
            txtInput.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 36);
            label1.Name = "label1";
            label1.Size = new Size(206, 20);
            label1.TabIndex = 0;
            label1.Text = "Shifted Input (From Step 5):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstLog);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(btnConfirm);
            groupBox2.Controls.Add(txtOutput);
            groupBox2.Controls.Add(label2);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 462);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(776, 444);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Results";
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.Location = new Point(377, 59);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(387, 324);
            lstLog.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(377, 36);
            label3.Name = "label3";
            label3.Size = new Size(224, 20);
            label3.TabIndex = 2;
            label3.Text = "Collision Log (For verification):";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(621, 400);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(143, 29);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(12, 59);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.Size = new Size(358, 324);
            txtOutput.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 36);
            label2.Name = "label2";
            label2.Size = new Size(235, 20);
            label2.TabIndex = 0;
            label2.Text = "Mapped Output (With Markers):";
            // 
            // FrmAlphabetMapping
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 917);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmAlphabetMapping";
            Text = "Alphabet Mapping";
            Load += FrmAlphabetMapping_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnMap;
        private TextBox txtInput;
        private Label label1;
        private GroupBox groupBox2;
        private Button btnConfirm;
        private TextBox txtOutput;
        private Label label2;
        private ListBox lstLog;
        private Label label3;
    }
}