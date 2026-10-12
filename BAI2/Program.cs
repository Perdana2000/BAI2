using System;
using System.Collections.Generic;


namespace BAI
{
    public partial class BAI_Afteken2
    {
        public static bool Vooruit(uint b)
        {
            // voor de opdrachten die bij 1 behoren moeten we kijken naar de informatie op een specifiek bit, dit doe je door te kijken welk getal je kan gebruiken als masker.
            
            return (b & 128) != 0;
        }
        public static uint Vermogen(uint b)
        {
            // Gebruik gemaakt van de >> operator, om bij de juiste bitjes te komen. Vervolgens een switch case gebruikt om respectievelijk het vermogen terug te geven.
            uint waarde = (b >> 5) & 3;   
            switch (waarde)
            {
                case 0: return 0;
                case 1: return 33;
                case 2: return 67;
                default: return 100;
            }
        }
        public static bool Wagon(uint b)
        {
            return (b & 16) != 0;
        }
        public static bool Licht(uint b)
        {
            return (b & 8) != 0;
        }
        public static uint ID(uint b)
        { 
            return  b & 7;
        }

        public static HashSet<uint> Alle(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            // Bij opdracht 2 lopen we door de input stroom met een loop, waarin we flowcontroll toe passen om de juiste resultaten terug te geven.
            foreach (uint b in inputStroom)
            {
                set.Add(b);
            }
            return set;
        }
        public static HashSet<uint> ZonderLicht(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            foreach (uint u in inputStroom)
            {
                if (!Licht(u))
                {
                    set.Add(u);
                }
            }
            return set;
        }
        public static HashSet<uint> MetWagon(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            foreach (uint u in inputStroom)
            {
                if (Wagon(u))
                {
                    set.Add(u);
                }
            }
            return set;
        }
        public static HashSet<uint> SelecteerID(List<uint> inputStroom, uint lower, uint upper)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            foreach (var b in inputStroom)
            {
                uint id = ID(b);
                if (id >= lower && id <= upper)
                {
                    set.Add(b);
                }
            }
            return set;
        }

        public static HashSet<uint> Opdr3a(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            
            set = SelecteerID(inputStroom, 0, 2); // Lager dan 3.
            set.IntersectWith(ZonderLicht(inputStroom)); // Zonder licht.
            
            return set;
        }

        public static HashSet<uint> Opdr3b(List<uint> inputStroom)
        {
            HashSet<uint> set = new HashSet<uint>();
            // *** IMPLEMENTATION HERE *** //
            
            set = Alle(inputStroom); // Alles
            set.ExceptWith(Opdr3a(inputStroom));// lager dan 3 en zonder licht.
            
            return set;
        }

        public static void ToonInfo(uint b)
        {
            Console.WriteLine($"ID {ID(b)}, Licht {Licht(b)}, Wagon {Wagon(b)}, Vermogen {Vermogen(b)}, Vooruit {Vooruit(b)}");
        }

        public static List<uint> GetInputStroom()
        {
            List<uint> inputStream = new List<uint>();
            for (uint i = 0; i < 256; i++)
            {
                inputStream.Add(i);
            }
            return inputStream;
        }

        public static void PrintSet(HashSet<uint> x)
        {
            Console.Write("{");
            foreach (uint i in x)
                Console.Write($" {i}");
            Console.WriteLine($" }} ({x.Count} elementen)");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("=== Opgave 1 ===");
            ToonInfo(210);
            Console.WriteLine();

            List<uint> inputStroom = GetInputStroom();

            Console.WriteLine("=== Opgave 2 ===");
            HashSet<uint> alle = Alle(inputStroom);
            PrintSet(alle);
            HashSet<uint> zonderLicht = ZonderLicht(inputStroom);
            PrintSet(zonderLicht);
            HashSet<uint> metWagon = MetWagon(inputStroom);
            PrintSet(metWagon);
            HashSet<uint> groter6 = SelecteerID(inputStroom, 6, 7);
            PrintSet(groter6);
            Console.WriteLine();

            Console.WriteLine("=== Opgave 3a ===");
            HashSet<uint> opg3a = Opdr3a(inputStroom);
            PrintSet(opg3a);
            foreach (uint b in opg3a)
            {
                ToonInfo(b);
            }
            Console.WriteLine();

            Console.WriteLine("=== Opgave 3b ===");
            HashSet<uint> opg3b = Opdr3b(inputStroom);
            PrintSet(opg3b);
            foreach (uint b in opg3b)
            {
                ToonInfo(b);
            }
            Console.WriteLine();
        }
    }
}
