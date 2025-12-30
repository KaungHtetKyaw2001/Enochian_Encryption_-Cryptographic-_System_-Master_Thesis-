namespace Enochian_Encryption_System
{
    partial class FrmCardTagging
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
            btnTag = new Button();
            lblCount = new Label();
            label3 = new Label();
            lblBase = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvTags = new DataGridView();
            CardID = new DataGridViewTextBoxColumn();
            MatrixContent = new DataGridViewTextBoxColumn();
            GeneratedHash = new DataGridViewTextBoxColumn();
            btnConfirm = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTags).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnTag);
            groupBox1.Controls.Add(lblCount);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblBase);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(292, 276);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hash Configuration";
            // 
            // btnTag
            // 
            btnTag.Location = new Point(6, 204);
            btnTag.Name = "btnTag";
            btnTag.Size = new Size(280, 55);
            btnTag.TabIndex = 4;
            btnTag.Text = "Generate Rolling Hashes and Tag Cards";
            btnTag.UseVisualStyleBackColor = true;
            btnTag.Click += btnTag_Click;
            // 
            // lblCount
            // 
            lblCount.BorderStyle = BorderStyle.FixedSingle;
            lblCount.Location = new Point(6, 153);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(280, 39);
            lblCount.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 121);
            label3.Name = "label3";
            label3.Size = new Size(139, 20);
            label3.TabIndex = 2;
            label3.Text = "Total Cards to Tag:";
            // 
            // lblBase
            // 
            lblBase.BorderStyle = BorderStyle.FixedSingle;
            lblBase.Location = new Point(6, 67);
            lblBase.Name = "lblBase";
            lblBase.Size = new Size(280, 39);
            lblBase.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 35);
            label1.Name = "label1";
            label1.Size = new Size(193, 20);
            label1.TabIndex = 0;
            label1.Text = "Integrity Base (Lorentz Z):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvTags);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(310, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1312, 426);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Hash Configuration";
            // 
            // dgvTags
            // 
            dgvTags.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTags.Columns.AddRange(new DataGridViewColumn[] { CardID, MatrixContent, GeneratedHash });
            dgvTags.Location = new Point(6, 26);
            dgvTags.Name = "dgvTags";
            dgvTags.RowHeadersWidth = 51;
            dgvTags.Size = new Size(1300, 394);
            dgvTags.TabIndex = 0;
            // 
            // CardID
            // 
            CardID.HeaderText = "Card ID";
            CardID.MinimumWidth = 6;
            CardID.Name = "CardID";
            CardID.Width = 125;
            // 
            // MatrixContent
            // 
            MatrixContent.HeaderText = "Matrix Content";
            MatrixContent.MinimumWidth = 6;
            MatrixContent.Name = "MatrixContent";
            MatrixContent.Width = 125;
            // 
            // GeneratedHash
            // 
            GeneratedHash.HeaderText = "Generated Hash";
            GeneratedHash.MinimumWidth = 6;
            GeneratedHash.Name = "GeneratedHash";
            GeneratedHash.Width = 125;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(12, 402);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(154, 30);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // FrmCardTagging
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1634, 451);
            Controls.Add(btnConfirm);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmCardTagging";
            Text = "Card Tagging";
            Load += FrmCardTagging_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTags).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblBase;
        private Label label1;
        private Button btnTag;
        private Label lblCount;
        private Label label3;
        private GroupBox groupBox2;
        private DataGridView dgvTags;
        private DataGridViewTextBoxColumn CardID;
        private DataGridViewTextBoxColumn MatrixContent;
        private DataGridViewTextBoxColumn GeneratedHash;
        private Button btnConfirm;
    }
}