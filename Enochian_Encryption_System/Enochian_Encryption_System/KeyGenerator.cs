using System;
using System.Linq;

namespace EnochianEncryptor
{
    public class ReceiverKeys
    {
        // Part 1: General Keys
        public int[] PrivateKey { get; set; }
        public int Modulo { get; set; }
        public int Multiplier { get; set; }
        public int[] PublicKey { get; set; }

        // Part 2: Trapdoor (Knapsack)
        public int[] TrapdoorKey { get; set; }
        public int TrapdoorModulo { get; set; }
        public int TrapdoorMultiplier { get; set; }
        public int InverseMultiplier { get; set; }
    }

    public class KeyGenerator
    {
        private Random _rng = new Random();

        // Step 1 & 2 Combined: Generate Full Receiver Identity
        public ReceiverKeys GenerateKeys()
        {
            var keys = new ReceiverKeys();

            // --- PART 1: General Private/Public Key ---
            // 1. Generate Random Private Key (Vector of 3 numbers for demo)
            keys.PrivateKey = new int[] { _rng.Next(5, 15), _rng.Next(5, 15), _rng.Next(5, 15) };

            // 2. Calculate Sum
            int sum = keys.PrivateKey.Sum();

            // 3. Choose Modulo (> Sum)
            keys.Modulo = sum + _rng.Next(5, 15); // e.g., 37

            // 4. Choose Multiplier (Coprime to Modulo)
            keys.Multiplier = FindCoprime(keys.Modulo);

            // 5. Generate Public Key: (Private * Multiplier) % Modulo
            keys.PublicKey = keys.PrivateKey.Select(x => (x * keys.Multiplier) % keys.Modulo).ToArray();

            // --- PART 2: Trapdoor (Superincreasing) ---
            // 1. Generate Superincreasing Sequence (e.g., [3, 6, 11])
            keys.TrapdoorKey = GenerateSuperIncreasing(3);

            // 2. Trapdoor Modulo (> Sum of Trapdoor)
            int trapSum = keys.TrapdoorKey.Sum();
            keys.TrapdoorModulo = trapSum + _rng.Next(2, 10);

            // 3. Trapdoor Multiplier
            keys.TrapdoorMultiplier = FindCoprime(keys.TrapdoorModulo);

            // 4. Inverse Multiplier (The Critical Step)
            keys.InverseMultiplier = ModInverse(keys.TrapdoorMultiplier, keys.TrapdoorModulo);

            return keys;
        }

        // --- Helpers ---

        private int[] GenerateSuperIncreasing(int size)
        {
            int[] arr = new int[size];
            int currentSum = 0;
            for (int i = 0; i < size; i++)
            {
                // Next number must be > sum of previous numbers
                arr[i] = currentSum + _rng.Next(1, 5);
                currentSum += arr[i];
            }
            return arr;
        }

        private int FindCoprime(int mod)
        {
            for (int i = 2; i < mod; i++)
            {
                if (GCD(i, mod) == 1) return i;
            }
            return 3; // Fallback
        }

        private int GCD(int a, int b)
        {
            while (b != 0) { int t = b; b = a % b; a = t; }
            return a;
        }

        private int ModInverse(int a, int m)
        {
            int m0 = m, y = 0, x = 1;
            if (m == 1) return 0;
            while (a > 1)
            {
                int q = a / m;
                int t = m; m = a % m; a = t;
                t = y; y = x - q * y; x = t;
            }
            if (x < 0) x += m0;
            return x;
        }
    }
}