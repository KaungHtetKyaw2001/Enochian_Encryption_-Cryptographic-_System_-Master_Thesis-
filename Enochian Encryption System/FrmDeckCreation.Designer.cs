namespace Enochian_Encryption_System
{
    partial class FrmDeckCreation
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
            btnShuffle = new Button();
            lblSeed = new Label();
            lblTotalCards = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dgvDeck = new DataGridView();
            Position = new DataGridViewTextBoxColumn();
            CardHashTag = new DataGridViewTextBoxColumn();
            MatrixPreview = new DataGridViewTextBoxColumn();
            btnConfirm = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDeck).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnShuffle);
            groupBox1.Controls.Add(lblSeed);
            groupBox1.Controls.Add(lblTotalCards);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(394, 180);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Deck Configuration";
            // 
            // btnShuffle
            // 
            btnShuffle.Location = new Point(16, 136);
            btnShuffle.Name = "btnShuffle";
            btnShuffle.Size = new Size(227, 29);
            btnShuffle.TabIndex = 4;
            btnShuffle.Text = "Shuffle Cards and Create Deck";
            btnShuffle.UseVisualStyleBackColor = true;
            btnShuffle.Click += btnShuffle_Click;
            // 
            // lblSeed
            // 
            lblSeed.BorderStyle = BorderStyle.FixedSingle;
            lblSeed.Location = new Point(166, 72);
            lblSeed.Name = "lblSeed";
            lblSeed.Size = new Size(218, 25);
            lblSeed.TabIndex = 3;
            // 
            // lblTotalCards
            // 
            lblTotalCards.BorderStyle = BorderStyle.FixedSingle;
            lblTotalCards.Location = new Point(166, 35);
            lblTotalCards.Name = "lblTotalCards";
            lblTotalCards.Size = new Size(218, 25);
            lblTotalCards.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 73);
            label2.Name = "label2";
            label2.Size = new Size(144, 40);
            label2.TabIndex = 1;
            label2.Text = "Shuffle Seed:\r\n(Lorentz X + Y + Z)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 35);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 0;
            label1.Text = "Total Cards:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvDeck);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(412, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1158, 426);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Deck Visualization";
            // 
            // dgvDeck
            // 
            dgvDeck.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeck.Columns.AddRange(new DataGridViewColumn[] { Position, CardHashTag, MatrixPreview });
            dgvDeck.Location = new Point(3, 23);
            dgvDeck.Name = "dgvDeck";
            dgvDeck.RowHeadersWidth = 51;
            dgvDeck.Size = new Size(1149, 397);
            dgvDeck.TabIndex = 0;
            // 
            // Position
            // 
            Position.HeaderText = "Position";
            Position.MinimumWidth = 6;
            Position.Name = "Position";
            Position.Width = 125;
            // 
            // CardHashTag
            // 
            CardHashTag.HeaderText = "Card Hash Tag";
            CardHashTag.MinimumWidth = 6;
            CardHashTag.Name = "CardHashTag";
            CardHashTag.Width = 125;
            // 
            // MatrixPreview
            // 
            MatrixPreview.HeaderText = "Matrix Preview";
            MatrixPreview.MinimumWidth = 6;
            MatrixPreview.Name = "MatrixPreview";
            MatrixPreview.Width = 125;
            // 
            // btnConfirm
            // 
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(28, 403);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(142, 29);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Confirm and Save";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // FrmDeckCreation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1582, 450);
            Controls.Add(btnConfirm);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmDeckCreation";
            Text = "Deck Creation";
            Load += FrmDeckCreation_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDeck).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnShuffle;
        private Label lblSeed;
        private Label lblTotalCards;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private DataGridView dgvDeck;
        private DataGridViewTextBoxColumn Position;
        private DataGridViewTextBoxColumn CardHashTag;
        private DataGridViewTextBoxColumn MatrixPreview;
        private Button btnConfirm;
    }
}