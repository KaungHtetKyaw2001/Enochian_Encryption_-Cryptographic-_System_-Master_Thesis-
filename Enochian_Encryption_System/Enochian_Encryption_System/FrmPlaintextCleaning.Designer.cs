namespace Enochian_Encryption_System
{
    partial class FrmPlaintextCleaning
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
            btnClean = new Button();
            txtInput = new TextBox();
            groupBox2 = new GroupBox();
            gridRemoved = new DataGridView();
            Index = new DataGridViewTextBoxColumn();
            Character = new DataGridViewTextBoxColumn();
            label2 = new Label();
            label1 = new Label();
            btnConfirm = new Button();
            txtOutput = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridRemoved).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnClean);
            groupBox1.Controls.Add(txtInput);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(882, 450);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input Data";
            // 
            // btnClean
            // 
            btnClean.Location = new Point(20, 401);
            btnClean.Name = "btnClean";
            btnClean.Size = new Size(92, 29);
            btnClean.TabIndex = 1;
            btnClean.Text = "Clean";
            btnClean.UseVisualStyleBackColor = true;
            btnClean.Click += btnClean_Click;
            // 
            // txtInput
            // 
            txtInput.Location = new Point(20, 26);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ReadOnly = true;
            txtInput.Size = new Size(842, 369);
            txtInput.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridRemoved);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(btnConfirm);
            groupBox2.Controls.Add(txtOutput);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 468);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(882, 450);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Results";
            // 
            // gridRemoved
            // 
            gridRemoved.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridRemoved.Columns.AddRange(new DataGridViewColumn[] { Index, Character });
            gridRemoved.Location = new Point(572, 68);
            gridRemoved.Name = "gridRemoved";
            gridRemoved.RowHeadersWidth = 51;
            gridRemoved.Size = new Size(304, 327);
            gridRemoved.TabIndex = 4;
            // 
            // Index
            // 
            Index.HeaderText = "Index";
            Index.MinimumWidth = 6;
            Index.Name = "Index";
            Index.Width = 125;
            // 
            // Character
            // 
            Character.HeaderText = "Character";
            Character.MinimumWidth = 6;
            Character.Name = "Character";
            Character.Width = 125;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(572, 34);
            label2.Name = "label2";
            label2.Size = new Size(179, 20);
            label2.TabIndex = 3;
            label2.Text = "Removed Artifacts Map:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 34);
            label1.Name = "label1";
            label1.Size = new Size(236, 20);
            label1.TabIndex = 2;
            label1.Text = "Cleaned String (Enochian Ready)";
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(713, 401);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(149, 29);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(20, 68);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.Size = new Size(534, 327);
            txtOutput.TabIndex = 0;
            // 
            // FrmPlaintextCleaning
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(906, 934);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmPlaintextCleaning";
            Text = "Plaintext Cleaning";
            Load += FrmPlaintextCleaning_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridRemoved).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnClean;
        private TextBox txtInput;
        private GroupBox groupBox2;
        private Label label1;
        private Button btnConfirm;
        private TextBox txtOutput;
        private DataGridView gridRemoved;
        private DataGridViewTextBoxColumn Index;
        private DataGridViewTextBoxColumn Character;
        private Label label2;
    }
}