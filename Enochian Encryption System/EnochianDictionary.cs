using System;
using System.Collections.Generic;
using System.Text;

namespace Enochian_Encryption_System
{
    // Holds the result: Name (e.g., "VEH"), Value (1-21), and Marker (!, @, #)
    public struct MappingResult
    {
        public string Name;
        public int Value; // 1 to 21
        public string Marker;
    }
    public static class EnochianDictionary
    {
        public static Dictionary<char, MappingResult> EnglishToEnochian = new Dictionary<char, MappingResult>();

        static EnochianDictionary()
        {
            // === MAPPING BASED ON UPLOADED IMAGE ===

            // A -> Un (6)
            Add('A', "UN", 6, "!");

            // B -> Pa (1)
            Add('B', "PA", 1, "!");

            // C -> Veh (2) [First Meaning]
            Add('C', "VEH", 2, "!");

            // D -> Gal (4)
            Add('D', "GAL", 4, "!");

            // E -> Graph (7)
            Add('E', "GRAPH", 7, "!");

            // F -> Or (5)
            Add('F', "OR", 5, "!");

            // G -> Ged (3) [First Meaning] (Image says G/J)
            Add('G', "GED", 3, "!");

            // H -> Na (10)
            Add('H', "NA", 10, "!");

            // I -> Gon (9) [First Meaning] (Image says I/Y)
            Add('I', "GON", 9, "!");

            // J -> Ged (3) [Second Meaning]
            Add('J', "GED", 3, "@");

            // K -> Veh (2) [Second Meaning]
            Add('K', "VEH", 2, "@");

            // L -> Ur (11)
            Add('L', "UR", 11, "!");

            // M -> Tal (8)
            Add('M', "TAL", 8, "!");

            // N -> Drux (14)
            Add('N', "DRUX", 14, "!");

            // O -> Med (16)
            Add('O', "MED", 16, "!");

            // P -> Mals (12)
            Add('P', "MALS", 12, "!");

            // Q -> Ger (13)
            Add('Q', "GER", 13, "!");

            // R -> Don (17)
            Add('R', "DON", 17, "!");

            // S -> Fam (20)
            Add('S', "FAM", 20, "!");

            // T -> Gisg (21) (Image spelling)
            Add('T', "GISG", 21, "!");

            // U -> Van (19) [First Meaning]
            Add('U', "VAN", 19, "!");

            // V -> Van (19) [Second Meaning]
            Add('V', "VAN", 19, "@");

            // W -> Van (19) [Third Meaning - User Rule]
            Add('W', "VAN", 19, "#");

            // X -> Pal (15)
            Add('X', "PAL", 15, "!");

            // Y -> Gon (9) [Second Meaning]
            Add('Y', "GON", 9, "@");

            // Z -> Ceph (18)
            Add('Z', "CEPH", 18, "!");
        }

        private static void Add(char eng, string name, int val, string mark)
        {
            EnglishToEnochian.Add(eng, new MappingResult { Name = name, Value = val, Marker = mark });
        }
    }
}
