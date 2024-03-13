using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HarryPotter
{
    class Nevek
    {
        static string[] keresztnevek = File.ReadAllLines("Keresztnevek.txt");
        static string[] vezeteknevek = File.ReadAllLines("Vezeteknevek.txt");

        public static string Kernev()
        {
            return keresztnevek[Program.rnd.Next(0, keresztnevek.Length)];
        }
        public static string Veznev()
        {
            return vezeteknevek[Program.rnd.Next(0, vezeteknevek.Length)];
        }
    }
}
