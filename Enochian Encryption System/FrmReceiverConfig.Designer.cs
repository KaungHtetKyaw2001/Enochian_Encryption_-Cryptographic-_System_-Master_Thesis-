namespace Enochian_Encryption_System
{
    partial class FrmReceiverConfig
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
            btnRandomize = new Button();
            txtMultiplier = new TextBox();
            txtModulo = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtPrivateKey = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtPublicKeyResult = new TextBox();
            btnCalculate = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnRandomize);
            groupBox1.Controls.Add(txtMultiplier);
            groupBox1.Controls.Add(txtModulo);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtPrivateKey);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(514, 301);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Private Parameters";
            // 
            // btnRandomize
            // 
            btnRandomize.Location = new Point(65, 250);
            btnRandomize.Name = "btnRandomize";
            btnRandomize.Size = new Size(269, 29);
            btnRandomize.TabIndex = 6;
            btnRandomize.Text = "Auto-Generate Valid Keys";
            btnRandomize.UseVisualStyleBackColor = true;
            btnRandomize.Click += btnRandomize_Click;
            // 
            // txtMultiplier
            // 
            txtMultiplier.Location = new Point(127, 187);
            txtMultiplier.Name = "txtMultiplier";
            txtMultiplier.ReadOnly = true;
            txtMultiplier.Size = new Size(381, 27);
            txtMultiplier.TabIndex = 5;
            // 
            // txtModulo
            // 
            txtModulo.Location = new Point(127, 123);
            txtModulo.Name = "txtModulo";
            txtModulo.ReadOnly = true;
            txtModulo.Size = new Size(381, 27);
            txtModulo.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 190);
            label3.Name = "label3";
            label3.Size = new Size(77, 20);
            label3.TabIndex = 3;
            label3.Text = "Multiplier";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 123);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 2;
            label2.Text = "Modulo";
            // 
            // txtPrivateKey
            // 
            txtPrivateKey.Location = new Point(127, 51);
            txtPrivateKey.Name = "txtPrivateKey";
            txtPrivateKey.ReadOnly = true;
            txtPrivateKey.Size = new Size(381, 27);
            txtPrivateKey.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 51);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 0;
            label1.Text = "Private Key";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtPublicKeyResult);
            groupBox2.Controls.Add(btnCalculate);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(12, 319);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(514, 105);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Public Key Calculation";
            // 
            // txtPublicKeyResult
            // 
            txtPublicKeyResult.Location = new Point(247, 40);
            txtPublicKeyResult.Name = "txtPublicKeyResult";
            txtPublicKeyResult.Size = new Size(261, 27);
            txtPublicKeyResult.TabIndex = 7;
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(15, 40);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(226, 29);
            btnCalculate.TabIndex = 0;
            btnCalculate.Text = "Calculate and Save Public Key";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += BtnCalculate_Click;

            // 
            // FrmReceiverConfig
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(538, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmReceiverConfig";
            Text = "Receiver Configuration";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private TextBox txtPrivateKey;
        private Label label1;
        private TextBox txtMultiplier;
        private TextBox txtModulo;
        private Label label3;
        private TextBox txtPublicKeyResult;
        private Button btnRandomize;
        private GroupBox groupBox2;
        private Button btnCalculate;
    }
}