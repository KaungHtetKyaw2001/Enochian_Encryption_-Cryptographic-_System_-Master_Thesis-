using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enochian_Encryption_System
{
    public static class GlobalSession
    {
        #region 1. Session Configuration
        public static double Lx { get; set; }
        public static double Ly { get; set; }
        public static double Lz { get; set; }
        public static int C1 { get; set; }
        public static int C2 { get; set; }
        public static int[] SessionVector { get; set; }
        public static int EncryptedHeader { get; set; }
        #endregion

        #region 2. Keys
        // Receiver Keys
        public static int[] ReceiverPublicKey { get; set; }
        public static int[] ReceiverPrivateVector { get; set; }
        public static int ReceiverModulus { get; set; }
        public static int ReceiverMultiplier { get; set; }

        // Sender Keys
        public static int[] SenderPrivateVector { get; set; }
        public static int[] SenderPublicVector { get; set; }
        public static int SenderModulus { get; set; }
        public static int SenderMultiplier { get; set; }

        public static int SignatureTargetHash { get; set; }
        public static int[] FinalSignatureVector { get; set; }
        public static long HashModulus { get; set; }
        #endregion

        #region 3. Text Processing
        public static string RawInput { get; set; }
        public static string PreProcessedText { get; set; }
        public static string CleanedText { get; set; }
        public static List<CharMarker> RemovedSpecialChars { get; set; } = new List<CharMarker>();
        public static string FirstShiftOutput { get; set; }
        public static string EnochianMappedOutput { get; set; }
        public static string SecondShiftOutput { get; set; }
        #endregion

        #region 4. Encryption Core
        public static int MatrixSize { get; set; }
        public static List<int[,]> PlaintextMatrices { get; set; } = new List<int[,]>();
        public static List<string[,]> MarkerMatrices { get; set; } = new List<string[,]>();
        public static int LorentzInt1 { get; set; }
        public static int LorentzInt2 { get; set; }
        public static int LorentzInt3 { get; set; }
        public static int FinalLorentzInt { get; set; }
        public static int LorentzIterations { get; set; }
        public static double Sigma { get; set; }
        public static double Rho { get; set; }
        public static double Beta { get; set; }
        public static int IterationCount { get; set; }
        public static int[,] KeyMatrix { get; set; }
        public static double KeyFactor { get; set; }
        public static int[,] InverseKeyMatrix { get; set; }
        public static int KeyDeterminant { get; set; }
        public static List<int[,]> SBoxedMatrices { get; set; }

        // [FIX] Added the missing property here
        public static List<int[,]> CipherMatrixList { get; set; }

        public static List<int[,]> EncryptedMatrices { get; set; }
        #endregion

        #region 5. Packaging
        public static List<string> CardTags { get; set; }
        public static List<int[,]> ShuffledDeck { get; set; }
        public static List<string> ShuffledTags { get; set; }
        public static int ShuffleSeed { get; set; }
        public static EnochianPayload FinalPayload { get; set; }
        public static string FinalPackageJson { get; set; }
        public static List<string> ReferenceHashList { get; set; } = new List<string>();
        #endregion

        #region 6. Decryption State
        public static int DecapsulatedID { get; set; }
        public static int HeaderID { get; set; }
        // Store final decrypted string
        public static string DecryptedText { get; set; }
        #endregion

        #region 7. Timing Metrics (Fixed Methods)
        public static Dictionary<string, double> EncryptionTimes { get; set; } = new Dictionary<string, double>();
        public static Dictionary<string, double> DecryptionTimes { get; set; } = new Dictionary<string, double>();

        public static void LogEncTime(string stepName, double ms)
        {
            if (EncryptionTimes.ContainsKey(stepName)) EncryptionTimes[stepName] = ms;
            else EncryptionTimes.Add(stepName, ms);
        }

        public static void LogDecTime(string stepName, double ms)
        {
            if (DecryptionTimes.ContainsKey(stepName)) DecryptionTimes[stepName] = ms;
            else DecryptionTimes.Add(stepName, ms);
        }

        public static double GetTotalEncryptionTime()
        {
            return EncryptionTimes.Sum(x => x.Value);
        }

        public static double GetTotalDecryptionTime()
        {
            return DecryptionTimes.Sum(x => x.Value);
        }
        #endregion

        #region 8. Progress Flags (Fixed ReceiverKeyLoaded)
        public static bool ReceiverKeyLoaded { get; set; } = false;

        public static bool Step1_Done { get; set; } = false;
        public static bool Step2_Done { get; set; } = false;
        public static bool Step3_Done { get; set; } = false;
        public static bool Step4_Done { get; set; } = false;
        public static bool Step5_Done { get; set; } = false;
        public static bool Step6_Done { get; set; } = false;
        public static bool Step7_Done { get; set; } = false;
        public static bool Step8_Done { get; set; } = false;
        public static bool Step9_Done { get; set; } = false;
        public static bool Step10_Done { get; set; } = false;
        public static bool Step11_Done { get; set; } = false;
        public static bool Step12_Done { get; set; } = false;
        public static bool Step13_Done { get; set; } = false;
        public static bool Step14_Done { get; set; } = false;
        public static bool Step15_Done { get; set; } = false;
        public static bool Step16_Done { get; set; } = false;

        public static bool DecStep1_Done { get; set; } = false;
        public static bool DecStep2_Done { get; set; } = false;
        public static bool DecStep3_Done { get; set; } = false;
        public static bool DecStep4_Done { get; set; } = false;
        public static bool DecStep5_Done { get; set; } = false;
        public static bool DecStep6_Done { get; set; } = false;
        public static bool DecStep7_Done { get; set; } = false;
        public static bool DecStep8_Done { get; set; } = false;
        #endregion
    }

    #region Helper Classes
    [Serializable]
    public class CharMarker
    {
        public int Index { get; set; }
        public char Character { get; set; }
    }

    [Serializable]
    public class Card
    {
        public int Tag { get; set; }
        public int[,] Data { get; set; }
    }
    #endregion
}