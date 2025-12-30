using System;
using System.Collections.Generic;

namespace Enochian_Encryption_System
{
    // [NOTE] CharMarker is NOT defined here because it already exists in GlobalSession.cs
    // Do not uncomment it or you will get Error CS0101 (Duplicate definition).

    [Serializable]
    public class SerializableStringMatrix
    {
        public int Rows;
        public int Cols;
        public string[] FlatData;

        public SerializableStringMatrix() { }

        public SerializableStringMatrix(string[,] matrix)
        {
            Rows = matrix.GetLength(0);
            Cols = matrix.GetLength(1);
            FlatData = new string[Rows * Cols];
            int idx = 0;
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    FlatData[idx++] = matrix[r, c];
        }

        public string[,] ToMatrix()
        {
            string[,] matrix = new string[Rows, Cols];
            int idx = 0;
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    matrix[r, c] = FlatData[idx++];
            return matrix;
        }
    }

    [Serializable]
    public class SerializableMatrix
    {
        public int Rows;
        public int Cols;
        public int[] FlatData;

        public SerializableMatrix() { }

        public SerializableMatrix(int[,] matrix)
        {
            Rows = matrix.GetLength(0);
            Cols = matrix.GetLength(1);
            FlatData = new int[Rows * Cols];
            int idx = 0;
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    FlatData[idx++] = matrix[r, c];
        }

        public int[,] ToMatrix()
        {
            int[,] matrix = new int[Rows, Cols];
            int idx = 0;
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    matrix[r, c] = FlatData[idx++];
            return matrix;
        }
    }

    [Serializable]
    public class EnochianPayload
    {
        public string MagicNumber { get; set; } = "ENOCHIAN_SECURE_V1";
        public DateTime Timestamp { get; set; }
        public string SenderID { get; set; }
        public string FileType { get; set; }
        public int MatrixSize { get; set; }
        public int TargetHashID { get; set; }
        public int IterationCount { get; set; }

        public List<SerializableMatrix> ShuffledDeck { get; set; }
        public List<string> ShuffledTags { get; set; }

        // Stores Suits (!, @, #)
        public List<SerializableStringMatrix> MarkerData { get; set; }

        // Stores Shift Values
        public int ShiftC1 { get; set; }
        public int ShiftC2 { get; set; }

        // Stores Formatting (Spaces, Punctuation)
        // This uses the CharMarker defined in GlobalSession.cs
        public List<CharMarker> FormattingData { get; set; }

        public string DigitalSignatureString { get; set; }
        public string PackageChecksum { get; set; }
        public string FinalPackageHash { get; set; }

        public int SenderModulus { get; set; }
        public int SenderMultiplier { get; set; }
        public int[] SenderPublicVector { get; set; }

        public int ReceiverModulus { get; set; }
        public int ReceiverMultiplier { get; set; }
        public int[] ReceiverPrivateVector { get; set; }

        public int LorentzInt1 { get; set; }
        public int LorentzInt2 { get; set; }
        public int LorentzInt3 { get; set; }

        public int[] SessionVector { get; set; }
        public byte[] DigitalSignature { get; set; }
        public string SenderPublicKey { get; set; }
        public List<string> ReferenceHashList { get; set; }
    }
}