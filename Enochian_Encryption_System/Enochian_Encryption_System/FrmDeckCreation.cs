using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Enochian_Encryption_System
{
    public partial class FrmDeckCreation : Form
    {
        private class Card
        {
            public int[,] Matrix;
            public string Tag;
            public int OriginalIndex;
        }

        private List<Card> _deck = new List<Card>();

        public FrmDeckCreation()
        {
            InitializeComponent();
        }

        private void FrmDeckCreation_Load(object sender, EventArgs e)
        {
            if (!GlobalSession.Step12_Done)
            {
                MessageBox.Show("Please complete Step 12 (Card Tagging) first.", "Access Denied");
                this.Close();
                return;
            }

            lblTotalCards.Text = $"Total Cards: {GlobalSession.EncryptedMatrices.Count}";

            int seed = GlobalSession.LorentzInt1 + GlobalSession.LorentzInt2 + GlobalSession.LorentzInt3;
            GlobalSession.ShuffleSeed = seed;
            lblSeed.Text = $"Shuffle Seed (X+Y+Z): {seed}";

            // --- GRID SETUP ---
            dgvDeck.Rows.Clear();
            dgvDeck.ColumnCount = 3;
            dgvDeck.Columns[0].Name = "Deck Pos";
            dgvDeck.Columns[1].Name = "Hash Tag";
            dgvDeck.Columns[2].Name = "Matrix Content";

            // Enable Multi-line View
            dgvDeck.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvDeck.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDeck.Columns[2].DefaultCellStyle.Font = new Font("Consolas", 9);
            dgvDeck.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            _deck.Clear();
            dgvDeck.Rows.Clear();

            var matrices = GlobalSession.EncryptedMatrices;
            var tags = GlobalSession.CardTags;

            for (int i = 0; i < matrices.Count; i++)
            {
                _deck.Add(new Card
                {
                    Matrix = matrices[i],
                    Tag = tags[i],
                    OriginalIndex = i
                });
            }

            // Fisher-Yates Shuffle
            Random rng = new Random(GlobalSession.ShuffleSeed);
            int n = _deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = _deck[k];
                _deck[k] = _deck[n];
                _deck[n] = value;
            }

            // 3. Display with Matrix Formatting
            int pos = 1;
            foreach (var card in _deck)
            {
                StringBuilder preview = new StringBuilder();
                int N = card.Matrix.GetLength(0);

                for (int r = 0; r < N; r++)
                {
                    preview.Append("[ ");
                    for (int c = 0; c < N; c++)
                    {
                        preview.Append($"{card.Matrix[r, c],-3} ");
                    }
                    preview.Append("]");
                    if (r < N - 1) preview.AppendLine();
                }

                dgvDeck.Rows.Add($"#{pos}", card.Tag, preview.ToString());
                pos++;
            }
            sw.Stop();
            GlobalSession.LogEncTime("Step 13: Deck Creation", sw.Elapsed.TotalMilliseconds);
            btnConfirm.Enabled = true;

            MessageBox.Show($"Deck Created & Shuffled!\nSeed Used: {GlobalSession.ShuffleSeed}\nTime: {sw.Elapsed.TotalMilliseconds:F4} ms");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            List<int[,]> shuffledMatrices = new List<int[,]>();
            List<string> shuffledTags = new List<string>();

            foreach (var card in _deck)
            {
                shuffledMatrices.Add(card.Matrix);
                shuffledTags.Add(card.Tag);
            }

            GlobalSession.ShuffledDeck = shuffledMatrices;
            GlobalSession.ShuffledTags = shuffledTags;
            GlobalSession.Step13_Done = true;

            this.Close();
        }
    }
}