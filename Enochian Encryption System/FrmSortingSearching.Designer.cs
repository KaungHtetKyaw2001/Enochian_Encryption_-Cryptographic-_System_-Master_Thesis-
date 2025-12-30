namespace Enochian_Encryption_System
{
    partial class FrmSortingSearching
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
            label1 = new Label();
            label2 = new Label();
            lstUnsorted = new ListBox();
            lstSorted = new ListBox();
            btnSort = new Button();
            lblSortTime = new Label();
            lblStatus = new Label();
            btnBinarySearch = new Button();
            lblSearchStatus = new Label();
            btnConfirm = new Button();
            label3 = new Label();
            rtbReorderedList = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(160, 20);
            label1.TabIndex = 1;
            label1.Text = "Shuffled Deck (Input)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(1055, 9);
            label2.Name = "label2";
            label2.Size = new Size(191, 20);
            label2.TabIndex = 2;
            label2.Text = "Sorted Sequence (Output)";
            // 
            // lstUnsorted
            // 
            lstUnsorted.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstUnsorted.FormattingEnabled = true;
            lstUnsorted.Location = new Point(12, 43);
            lstUnsorted.Name = "lstUnsorted";
            lstUnsorted.Size = new Size(500, 472);
            lstUnsorted.TabIndex = 0;
            // 
            // lstSorted
            // 
            lstSorted.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstSorted.FormattingEnabled = true;
            lstSorted.Location = new Point(746, 43);
            lstSorted.Name = "lstSorted";
            lstSorted.Size = new Size(500, 472);
            lstSorted.TabIndex = 3;
            // 
            // btnSort
            // 
            btnSort.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSort.Location = new Point(577, 118);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(94, 29);
            btnSort.TabIndex = 4;
            btnSort.Text = "Sort Deck";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Click += btnSort_Click;
            // 
            // lblSortTime
            // 
            lblSortTime.BorderStyle = BorderStyle.FixedSingle;
            lblSortTime.Location = new Point(518, 186);
            lblSortTime.Name = "lblSortTime";
            lblSortTime.Size = new Size(222, 48);
            lblSortTime.TabIndex = 5;
            lblSortTime.Text = "Time: 0.0000 ms";
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(518, 289);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(222, 48);
            lblStatus.TabIndex = 6;
            // 
            // btnBinarySearch
            // 
            btnBinarySearch.Enabled = false;
            btnBinarySearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBinarySearch.Location = new Point(12, 533);
            btnBinarySearch.Name = "btnBinarySearch";
            btnBinarySearch.Size = new Size(146, 29);
            btnBinarySearch.TabIndex = 7;
            btnBinarySearch.Text = "Validate Sequence";
            btnBinarySearch.UseVisualStyleBackColor = true;
            btnBinarySearch.Click += btnBinarySearch_Click;
            // 
            // lblSearchStatus
            // 
            lblSearchStatus.BorderStyle = BorderStyle.FixedSingle;
            lblSearchStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSearchStatus.Location = new Point(164, 536);
            lblSearchStatus.Name = "lblSearchStatus";
            lblSearchStatus.Size = new Size(222, 26);
            lblSearchStatus.TabIndex = 8;
            lblSearchStatus.Text = "Waiting for Sort...";
            // 
            // btnConfirm
            // 
            btnConfirm.Enabled = false;
            btnConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnConfirm.Location = new Point(1100, 536);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(146, 29);
            btnConfirm.TabIndex = 9;
            btnConfirm.Text = "Confirm Sequence";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 570);
            label3.Name = "label3";
            label3.Size = new Size(165, 20);
            label3.TabIndex = 11;
            label3.Text = "Reordered List Output";
            // 
            // rtbReorderedList
            // 
            rtbReorderedList.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbReorderedList.Location = new Point(12, 593);
            rtbReorderedList.Name = "rtbReorderedList";
            rtbReorderedList.Size = new Size(1234, 258);
            rtbReorderedList.TabIndex = 12;
            rtbReorderedList.Text = "";
            // 
            // FrmSortingSearching
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 863);
            Controls.Add(rtbReorderedList);
            Controls.Add(label3);
            Controls.Add(btnConfirm);
            Controls.Add(lblSearchStatus);
            Controls.Add(btnBinarySearch);
            Controls.Add(lblStatus);
            Controls.Add(lblSortTime);
            Controls.Add(btnSort);
            Controls.Add(lstSorted);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lstUnsorted);
            Name = "FrmSortingSearching";
            Text = "Sorting and Searching";
            Load += FrmSortingSearching_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ListBox lstUnsorted;
        private ListBox lstSorted;
        private Button btnSort;
        private Label lblSortTime;
        private Label lblStatus;
        private Button btnBinarySearch;
        private Label lblSearchStatus;
        private Button btnConfirm;
        private Label label3;
        private RichTextBox rtbReorderedList;
    }
}