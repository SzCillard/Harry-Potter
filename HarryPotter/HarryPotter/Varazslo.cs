using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HarryPotter
{

    class Varazslo
    {

        public int batorsag;
        public int intelligencia;
        public int kitartas;
        public int ravaszsag;
        public string keresztnev;
        public string vezeteknev;
       
        
        public Varazslo(int minStat, int maxStat)
        {
   
            batorsag = Program.rnd.Next(minStat, maxStat);
            intelligencia= Program.rnd.Next(minStat, maxStat);
            kitartas = Program.rnd.Next(minStat, maxStat);
            ravaszsag = Program.rnd.Next(minStat, maxStat);
            keresztnev = Nevek.Kernev();
            vezeteknev = Nevek.Veznev();
        }
       
        
    }
}
