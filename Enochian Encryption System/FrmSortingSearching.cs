using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Enochian_Encryption_System
{
    public partial class FrmSortingSearching : Form
    {
        public class DecryptCard
        {
            public string Tag { get; set; }
            public int[,] Matrix { get; set; }
            public int OriginalOrderIndex { get; set; }
        }

        private List<DecryptCard> _shuffledDeck = new List<DecryptCard>();
        private List<DecryptCard> _sortedDeck = new List<DecryptCard>();
        private List<string> _referenceSequence = new List<string>();

        public FrmSortingSearching()
        {
            InitializeComponent();
        }

        private void FrmSortingSearching_Load(object sender, EventArgs e)
        {
            if (!GlobalSession.DecStep3_Done)
            {
                MessageBox.Show("Sequence Error: Step 3 (Decapsulation) is not complete.", "Access Denied");
                this.Close();
                return;
            }
            if (GlobalSession.ShuffledDeck == null || GlobalSession.ShuffledTags == null)
            {
                lblStatus.Text = "Status: No Data Found";
                return;
            }

            // Load Reference List
            if (GlobalSession.ReferenceHashList != null && GlobalSession.ReferenceHashList.Count > 0)
            {
                _referenceSequence = new List<string>(GlobalSession.ReferenceHashList);
            }
            else
            {
                MessageBox.Show("Error: Reference Hash List is missing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Load Shuffled Deck
            _shuffledDeck.Clear();
            for (int i = 0; i < GlobalSession.ShuffledDeck.Count; i++)
            {
                _shuffledDeck.Add(new DecryptCard
                {
                    Tag = GlobalSession.ShuffledTags[i],
                    Matrix = GlobalSession.ShuffledDeck[i],
                    OriginalOrderIndex = -1
                });
            }

            // Display Unsorted
            UpdateList(lstUnsorted, _shuffledDeck);
            lblStatus.Text = $"Status: Loaded {_shuffledDeck.Count} Shuffled Cards";
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();

            // 1. BUCKETING (Handle Collisions)
            Dictionary<string, Queue<DecryptCard>> cardBuckets = new Dictionary<string, Queue<DecryptCard>>();

            foreach (var card in _shuffledDeck)
            {
                if (!cardBuckets.ContainsKey(card.Tag))
                {
                    cardBuckets[card.Tag] = new Queue<DecryptCard>();
                }
                cardBuckets[card.Tag].Enqueue(card);
            }

            // 2. RECONSTRUCTION
            _sortedDeck.Clear();
            List<string> missingTags = new List<string>();
            int orderIndex = 0;

            foreach (string targetTag in _referenceSequence)
            {
                if (cardBuckets.ContainsKey(targetTag) && cardBuckets[targetTag].Count > 0)
                {
                    DecryptCard foundCard = cardBuckets[targetTag].Dequeue();
                    foundCard.OriginalOrderIndex = orderIndex++;
                    _sortedDeck.Add(foundCard);
                }
                else
                {
                    missingTags.Add(targetTag);
                    _sortedDeck.Add(new DecryptCard
                    {
                        Tag = "MISSING",
                        Matrix = new int[0, 0],
                        OriginalOrderIndex = orderIndex++
                    });
                }
            }

            sw.Stop();
            GlobalSession.LogDecTime("Decryption Step 4a: Sorting", sw.Elapsed.TotalMilliseconds);

            // 3. UI UPDATE
            UpdateList(lstSorted, _sortedDeck);

            // [FIX] Populate Detailed Text Report with SQUARE MATRIX FORMAT
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"--- Final Reordered Sequence (Total: {_sortedDeck.Count}) ---");
            sb.AppendLine("-------------------------------------------------------------");

            foreach (var c in _sortedDeck)
            {
                // Use the new helper to get the square block format
                string matrixBlock = GetSquareMatrixString(c.Matrix);

                sb.AppendLine($"Position [{c.OriginalOrderIndex + 1}] - Tag: {c.Tag}");
                sb.AppendLine(matrixBlock);
                sb.AppendLine("-------------------------------------------------------------");
            }
            rtbReorderedList.Text = sb.ToString();

            lblSortTime.Text = $"Time: {sw.Elapsed.TotalMilliseconds:F4} ms";
            lblStatus.Text = "Status: Deck Reordered Successfully";

            btnBinarySearch.Enabled = true;

            if (missingTags.Count > 0)
                MessageBox.Show($"Warning: {missingTags.Count} cards missing.", "Data Loss");
        }

        private void btnBinarySearch_Click(object sender, EventArgs e)
        {
            if (_sortedDeck.Count == 0) return;

            // Search for the middle card to demonstrate
            int targetIndex = _sortedDeck.Count / 2;
            Stopwatch sw = Stopwatch.StartNew();

            int foundIndex = BinarySearchByIndex(_sortedDeck, targetIndex, 0, _sortedDeck.Count - 1);


            if (foundIndex != -1)
            {
                DecryptCard foundCard = _sortedDeck[foundIndex];
                lblSearchStatus.Text = $"Valid: #{targetIndex} = Tag {foundCard.Tag}";
                lblSearchStatus.ForeColor = Color.Green;

                // Show formatted matrix in popup
                MessageBox.Show($"Validation Successful!\n\nMatched Card #{targetIndex}\nTag: {foundCard.Tag}\n\nData Content:\n{GetSquareMatrixString(foundCard.Matrix)}", "Integrity Check");

                sw.Stop();
                GlobalSession.LogDecTime("Decryption Step 4b: Binary Search", sw.Elapsed.TotalMilliseconds);
                GlobalSession.DecStep4_Done = true;

                // Save sorted deck back to session
                GlobalSession.ShuffledDeck.Clear();
                GlobalSession.ShuffledTags.Clear();

                foreach (var c in _sortedDeck)
                {
                    GlobalSession.ShuffledDeck.Add(c.Matrix);
                    GlobalSession.ShuffledTags.Add(c.Tag);
                }
                btnConfirm.Enabled = true;
            }
            else
            {
                sw.Stop();
                lblSearchStatus.Text = "Validation Failed";
                lblSearchStatus.ForeColor = Color.Red;
            }
        }

        // [HELPER 1] For ListBoxes (Compact Single Line)
        private string GetCompactMatrixString(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0) return "[EMPTY]";
            StringBuilder sb = new StringBuilder("[");
            int count = 0, limit = 5;
            foreach (int val in matrix)
            {
                sb.Append(val + " ");
                if (++count >= limit) break;
            }
            if (matrix.Length > limit) sb.Append("...");
            sb.Append("]");
            return sb.ToString();
        }

        // [HELPER 2] For Text Reports (Full Square Format)
        private string GetSquareMatrixString(int[,] matrix)
        {
            if (matrix == null || matrix.Length == 0) return "[EMPTY]";
            StringBuilder sb = new StringBuilder();
            int N = matrix.GetLength(0);

            for (int r = 0; r < N; r++)
            {
                sb.Append("  [ ");
                for (int c = 0; c < N; c++)
                {
                    sb.Append($"{matrix[r, c],-3} "); // Pad numbers for alignment
                }
                sb.Append("]");
                if (r < N - 1) sb.AppendLine();
            }
            return sb.ToString();
        }

        private void UpdateList(ListBox lst, List<DecryptCard> data)
        {
            lst.Items.Clear();
            lst.HorizontalScrollbar = true;
            foreach (var card in data)
            {
                string idxInfo = card.OriginalOrderIndex != -1 ? $"#{card.OriginalOrderIndex + 1}" : "[?]";
                string matrixData = GetCompactMatrixString(card.Matrix);
                lst.Items.Add($"{idxInfo} Tag: {card.Tag} | {matrixData}");
            }
        }

        private int BinarySearchByIndex(List<DecryptCard> list, int targetOrderIndex, int min, int max)
        {
            if (min > max) return -1;
            int mid = (min + max) / 2;
            int currentVal = list[mid].OriginalOrderIndex;

            if (currentVal == targetOrderIndex) return mid;
            if (currentVal > targetOrderIndex) return BinarySearchByIndex(list, targetOrderIndex, min, mid - 1);
            else return BinarySearchByIndex(list, targetOrderIndex, mid + 1, max);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}