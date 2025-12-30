using System;
using System.Collections.Generic;
using System.Text;

namespace Enochian_Encryption_System
{
    internal class NumberConverter
    {
        private static readonly Dictionary<char, string> DigitMap = new Dictionary<char, string>
        {
            {'0', "ZERO"}, {'1', "ONE"}, {'2', "TWO"}, {'3', "THREE"}, {'4', "FOUR"},
            {'5', "FIVE"}, {'6', "SIX"}, {'7', "SEVEN"}, {'8', "EIGHT"}, {'9', "NINE"},
            {'.', "POINT"}
        };

        public static string ProcessText(string input)
        {
            if (string.IsNullOrEmpty(input)) return "";

            StringBuilder sb = new StringBuilder();

            // Scan every character
            foreach (char c in input)
            {
                // If it is a number or decimal point
                if (DigitMap.ContainsKey(c))
                {
                    // Add a space before and after to separate it from words
                    sb.Append(" " + DigitMap[c] + " ");
                }
                else
                {
                    // Keep the character as is (letters, punctuation, etc.)
                    sb.Append(c);
                }
            }

            // Clean up double spaces created by the insertion
            return System.Text.RegularExpressions.Regex.Replace(sb.ToString(), @"\s+", " ").Trim();
        }
    }
}
