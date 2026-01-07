using System;
using System.Collections.Generic;
using System.Text;

namespace Enochian_Encryption_System
{
    internal class SecurityMetrics
    {
        // 1. Calculate Entropy (Ideal: ~8.0 for Encrypted, ~4.0 for English)
        public static double CalculateEntropy(byte[] data)
        {
            var map = new Dictionary<byte, int>();
            foreach (byte b in data)
            {
                if (!map.ContainsKey(b)) map.Add(b, 0);
                map[b]++;
            }

            double entropy = 0.0;
            int len = data.Length;
            foreach (var item in map)
            {
                double frequency = (double)item.Value / len;
                entropy -= frequency * Math.Log(frequency, 2);
            }
            return entropy;
        }

        // 2. Histogram Variance (Lower = Better/Flatter distribution)
        public static double CalculateHistogramVariance(byte[] data)
        {
            long[] counts = new long[256];
            foreach (byte b in data) counts[b]++;

            double average = data.Length / 256.0;
            double sum = 0;
            foreach (long count in counts)
            {
                sum += Math.Pow(count - average, 2);
            }
            return sum / 256;
        }
    }
}
