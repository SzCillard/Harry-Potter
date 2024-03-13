using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HarryPotter.Griffendel;
using static HarryPotter.Mardekar;

namespace HarryPotter
{
    class Hollohat
    {
        HollohatTanonc gyoker;
        public class HollohatTanonc
        {

            public int batorsag;
            public int intelligencia;
            public int kitartas;
            public int ravaszsag;
            public string keresztnev;
            public string vezeteknev;
            public int kulcs;
            public HollohatTanonc bal;
            public HollohatTanonc jobb;


        }
        public void Beszuras(Varazslo tanonc, int kulcs)
        {
            _Beszuras(ref gyoker, tanonc, kulcs);
        }
        void _Beszuras(ref HollohatTanonc p, Varazslo tanonc, int kulcs)
        {
            if (p == null)
            {
                p = new HollohatTanonc();
                p.kulcs = kulcs;
                p.batorsag = tanonc.batorsag;
                p.intelligencia = tanonc.intelligencia;
                p.kitartas = tanonc.kitartas;
                p.ravaszsag = tanonc.ravaszsag;
                p.keresztnev = tanonc.keresztnev;
                p.vezeteknev = tanonc.vezeteknev;
            }
            else
            {
                if (p.kulcs.CompareTo(kulcs) < 0)
                {
                    _Beszuras(ref p.jobb, tanonc, kulcs);
                }
                else if (p.kulcs.CompareTo(kulcs) > 0)
                {
                    _Beszuras(ref p.bal, tanonc, kulcs);
                }
                else
                {
                    throw new Exception("Van már ilyen elem a fában.");
                }
            }
        }
        public bool BenneVanE(int kulcs)
        {
            return _BenneVanE(gyoker, kulcs);
        }
        bool _BenneVanE(HollohatTanonc p, int kulcs)
        {
            if (p != null)
            {
                if (p.kulcs.CompareTo(kulcs) < 0)
                {
                    return _BenneVanE(p.jobb, kulcs);
                }
                else if (p.kulcs.CompareTo(kulcs) > 0)
                {
                    return _BenneVanE(p.bal, kulcs);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        public int FaMerete()
        {
            return _FaMerete(gyoker);
        }
        int _FaMerete(HollohatTanonc p)
        {
            if (p == null)
            {
                return 0;
            }
            else
            {
                return 1 + _FaMerete(p.bal) + _FaMerete(p.jobb);
            }
        }
        List<string> tanoncok = new List<string>();


        public string[] Lekerdezes(string tulajdonsag, int ertek)
        {
            tanoncok.Clear();
            _Lekerdezes(gyoker, tulajdonsag, ertek);
            return tanoncok.ToArray();
        }
        void _Lekerdezes(HollohatTanonc p, string tulajdonsag, int ertek)
        {

            if (tulajdonsag == "Bátorság")
            {
                if (p != null)
                {
                    _Lekerdezes(p.bal, tulajdonsag, ertek);
                    if (p.batorsag > ertek)
                    {
                        tanoncok.Add(p.keresztnev + " " + p.vezeteknev);
                    }
                    _Lekerdezes(p.jobb, tulajdonsag, ertek);
                }

            }
            else if (tulajdonsag == "Intelligencia")
            {
                if (p != null)
                {
                    _Lekerdezes(p.bal, tulajdonsag, ertek);
                    if (p.intelligencia > ertek)
                    {
                        tanoncok.Add(p.keresztnev + " " + p.vezeteknev);

                    }
                    _Lekerdezes(p.jobb, tulajdonsag, ertek);
                }
            }
            else if (tulajdonsag == "Kitartás")
            {
                if (p != null)
                {
                    _Lekerdezes(p.bal, tulajdonsag, ertek);
                    if (p.kitartas > ertek)
                    {
                        tanoncok.Add(p.keresztnev + " " + p.vezeteknev);

                    }
                    _Lekerdezes(p.jobb, tulajdonsag, ertek);
                }
            }
            else if (tulajdonsag == "Ravaszság")
            {
                if (p != null)
                {
                    _Lekerdezes(p.bal, tulajdonsag, ertek);
                    if (p.ravaszsag > ertek)
                    {
                        tanoncok.Add(p.keresztnev + " " + p.vezeteknev);

                    }
                    _Lekerdezes(p.jobb, tulajdonsag, ertek);
                }
            }

        }
    }
}
