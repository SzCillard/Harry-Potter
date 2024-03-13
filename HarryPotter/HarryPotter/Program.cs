using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace HarryPotter
{
    class Program
    {
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            // TeszlekSüveg létrehozása, ami a négy ház bináris fáját tartalmazza
            TeszlekSuveg teszlekSuveg = new TeszlekSuveg();
            //A varázslótanoncok létrehozásai
            Varazslo[] varazslotanoncok=new Varazslo[teszlekSuveg.TanoncokSzama];
            for (int i = 0; i < teszlekSuveg.TanoncokSzama; i++)
            {
                varazslotanoncok[i]=new Varazslo(teszlekSuveg.minStat,teszlekSuveg.maxStat);
            }
            

            //Tanoncok beosztása a megfelelő házba 
            for (int i = 0; i < teszlekSuveg.TanoncokSzama; i++)
            {
                teszlekSuveg.Beoszt(varazslotanoncok[i]);
            }

            //A házak, vagyis a fák méretének kiíratása
            Console.WriteLine("Griffendél:" + teszlekSuveg.griffendel.FaMerete());
            Console.WriteLine("Hollohát:" + teszlekSuveg.hollohat.FaMerete());
            Console.WriteLine("Hugrabug:" + teszlekSuveg.hugrabug.FaMerete());
            Console.WriteLine("Mardekár:" + teszlekSuveg.mardekar.FaMerete());

            //Lekérdezés metódus meghívása, amely listázza azokat akiknek Y tulajdonsága legalább X értékű
            teszlekSuveg.Lekerdezes(teszlekSuveg.lekerdezettTulajdonsag, teszlekSuveg.lekerdezettErtek);
            Console.ReadKey();
            
        }

    }
}
