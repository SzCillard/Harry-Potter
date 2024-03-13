using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    class TeszlekSuveg
    {
        public Griffendel griffendel=new Griffendel();
        public Hollohat hollohat = new Hollohat();
        public Hugrabug hugrabug= new Hugrabug();
        public Mardekar mardekar = new Mardekar();
        public int TanoncokSzama { get; set; }
        public int minStat { get; set; }
        public int maxStat { get; set; }
        public string lekerdezettTulajdonsag { get; set; }
        public int lekerdezettErtek { get; set; }

        public TeszlekSuveg()
        {
            Beolvasas();
        }
        int[] tulajdonsagokmasolat;
        public void Beoszt(Varazslo tanonc)
        {
            int[] tulajdonsagok = { tanonc.batorsag, tanonc.intelligencia, tanonc.kitartas, tanonc.ravaszsag };
            string[] tulajdonsagnevek = { "batorsag", "intelligencia", "kitartas", "ravaszsag" };
            tulajdonsagokmasolat=tulajdonsagok;
            _Beoszt(tanonc, ref tulajdonsagok, ref tulajdonsagnevek);
        }
        void _Beoszt(Varazslo tanonc,ref int[] tulajdonsagok, ref string[] tulajdonsagnevek)
        {
            if (tulajdonsagok.Length==0)
            {
                tulajdonsagok = tulajdonsagokmasolat;
                int[] hazakmerete = { griffendel.FaMerete(), hollohat.FaMerete(), hugrabug.FaMerete(), mardekar.FaMerete() };
                int[] hazakindexei = { 0, 1, 2, 3 };
                Array.Sort(hazakmerete, hazakindexei);

                bool beszurva =false;
                int hazindex = 0;
                while (!beszurva && hazindex<hazakindexei.Length)
                {
                    if (hazakindexei[hazindex]== 0)
                    {
                        int i = 0;
                        while (!beszurva || i < tulajdonsagokmasolat.Length)
                        {
                            if (!griffendel.BenneVanE(tulajdonsagokmasolat[i]))
                            {
                                griffendel.Beszuras(tanonc, tulajdonsagokmasolat[i]);
                                beszurva = true;
                            }
                            i++;
                        }
                    }
                    else if (hazakindexei[hazindex]==1)
                    {
                        int i = 0;
                        while (!beszurva || i < tulajdonsagokmasolat.Length)
                        {
                            if (!hollohat.BenneVanE(tulajdonsagokmasolat[i]))
                            {
                                hollohat.Beszuras(tanonc, tulajdonsagokmasolat[i]);
                                beszurva = true;
                            }
                            i++;
                        }
                    }
                    else if (hazakindexei[hazindex]==2)
                    {
                        int i = 0;
                        while (!beszurva || i < tulajdonsagokmasolat.Length)
                        {
                            if (!hugrabug.BenneVanE(tulajdonsagokmasolat[i]))
                            {
                                hugrabug.Beszuras(tanonc, tulajdonsagokmasolat[i]);
                                beszurva = true;
                            }
                            i++;
                        }
                    }
                    else
                    {
                        int i = 0;
                        while (!beszurva || i < tulajdonsagokmasolat.Length)
                        {
                            if (!mardekar.BenneVanE(tulajdonsagokmasolat[i]))
                            {
                                mardekar.Beszuras(tanonc, tulajdonsagokmasolat[i]);
                                beszurva = true;
                            }
                            i++;
                        }
                    }
                    hazindex++;
                }
                if (!beszurva)
                {
                    throw new Exception("Hiba! A tanonc elhelyezése nem lehetséges.");
                }
                
               
            }
            else
            {
                int bestertek = 0;
                int bestindex = 0;
                string tulajdonsagnev = "";
                for (int i = 0; i < tulajdonsagok.Length; i++)
                {
                    if (bestertek < tulajdonsagok[i])
                    {
                        bestertek = tulajdonsagok[i];
                        bestindex = i;
                        tulajdonsagnev = tulajdonsagnevek[i];
                    }
                }
                if (tulajdonsagnev == "batorsag" && !griffendel.BenneVanE(bestertek))
                {
                    griffendel.Beszuras(tanonc, tanonc.batorsag);
                }
                else if (tulajdonsagnev == "intelligencia" && !hollohat.BenneVanE(bestertek))
                {
                    hollohat.Beszuras(tanonc, tanonc.intelligencia);
                }
                else if (tulajdonsagnev == "kitartas" && !hugrabug.BenneVanE(bestertek))
                {
                    hugrabug.Beszuras(tanonc, tanonc.kitartas);
                }
                else if (tulajdonsagnev == "ravaszsag" && !mardekar.BenneVanE(bestertek))
                {
                    mardekar.Beszuras(tanonc, tanonc.ravaszsag);

                }
                else
                {
                    int[] szamtomb = new int[tulajdonsagok.Length - 1];
                    string[] nevtomb = new string[tulajdonsagok.Length - 1];
                    int j = 0;
                    for (int i = 0; i < tulajdonsagok.Length; i++)
                    {
                        if (i != bestindex)
                        {
                            szamtomb[j] = tulajdonsagok[i];
                            nevtomb[j] = tulajdonsagnevek[i];
                            j++;
                        }
                    }
                    tulajdonsagok = szamtomb;
                    tulajdonsagnevek = nevtomb;
                    _Beoszt(tanonc, ref tulajdonsagok, ref tulajdonsagnevek);
                }
            }
            


        }
        public void Lekerdezes(string tulajdonsag, int ertek)
        {
            Console.WriteLine("Lekérdezés:");
            Console.WriteLine();
            Console.WriteLine(tulajdonsag+" "+ertek);
            if (tulajdonsag != "Bátorság" && tulajdonsag != "Intelligencia" && tulajdonsag != "Kitartás" && tulajdonsag != "Ravaszság")
            {
                throw new Exception("Nem létezik a tulajdonság amit megadott.");
            }
            else
            {
                Console.WriteLine();
                _Lekerdezes(tulajdonsag, ertek);
            }
        }
        void _Lekerdezes(string tulajdonsag, int ertek)
        {
            string[] griff = griffendel.Lekerdezes(tulajdonsag, ertek);
            if (griff.Length != 0)
            {
                Console.WriteLine("Griffendél: \n");
                for (int i = 0; i < griff.Length; i++)
                {
                    Console.WriteLine(griff[i]);
                }
                Console.WriteLine();
            }
            string[] hollo = hollohat.Lekerdezes(tulajdonsag, ertek);
            if (hollo.Length != 0)
            {
                Console.WriteLine("Hollohát: \n");
                for (int i = 0; i < hollo.Length; i++)
                {
                    Console.WriteLine(hollo[i]);
                }
                Console.WriteLine();
            }
            string[] hugra = hugrabug.Lekerdezes(tulajdonsag, ertek);
            if (hugra.Length!=0)
            {
                Console.WriteLine("Hugrabug: \n");
                for (int i = 0; i < hugra.Length; i++)
                {
                    Console.WriteLine(hugra[i]);
                }
                Console.WriteLine();
            }
            string[] mard =mardekar.Lekerdezes(tulajdonsag, ertek);
            if (mard.Length!=0)
            {
                Console.WriteLine("Mardekár: \n");
                for (int i = 0; i < mard.Length; i++)
                {
                    Console.WriteLine(mard[i]);
                }
            }
        }
      
        void Beolvasas()
        {
            StreamReader sr = new StreamReader("VarazsloEsLekerdezesAdatok.txt");
            string[] sorok = new string[5];
            sorok[0] = sr.ReadLine();
            sorok[1] = sr.ReadLine();
            sorok[2] = sr.ReadLine();
            sorok[3] = sr.ReadLine();
            sorok[4] = sr.ReadLine();
            TanoncokSzama = int.Parse(sorok[0].Split(':')[1].Trim());
            minStat = int.Parse(sorok[1].Split(':')[1].Trim());
            maxStat = int.Parse(sorok[2].Split(':')[1].Trim());
            lekerdezettTulajdonsag = sorok[3].Split(':')[1].Trim();
            lekerdezettErtek = int.Parse(sorok[4].Split(':')[1].Trim());
        }
    }
}
