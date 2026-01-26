using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utulek
{
    internal class Zvire
    {
        public string Jmeno {get;set;}
        public string Druh {get;set;}
        public string Pohlavi {get;set;}
        public bool Adoptovano {get;set;}
        public int Vek {get;set;}
        public static int ID {get;set;}

        public Zvire(string jmeno, string druh, string pohlavi, bool adoptovano, int vek)
    {
        Jmeno = jmeno;
        Druh = druh;
        Pohlavi = pohlavi;
        Adoptovano = adoptovano;
        Vek = vek;
        ID++;
    }
    }
}
