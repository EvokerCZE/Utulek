using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utulek
{
    internal class Zvire
    {
        private static int _pocitadloId = 0;
        public string Jmeno {get;set;}
        public string Druh {get;set;}
        public string Pohlavi {get;set;}
        public bool Adoptovano {get;set;}
        public int Vek {get;set;}
        public int ID {get;set;}
        public DateTime DatumPrijmu { get; set;}
        public string ZdravotniStav { get; set; }
        public string Poznamka { get; set; }

        public Zvire(string jmeno, string druh, string pohlavi, bool adoptovano, int vek, DateTime datumPrijmu, string zdravotniStav, string poznamka = null)
    {
        _pocitadloId++;
        Jmeno = jmeno;
        Druh = druh;
        Pohlavi = pohlavi;
        Adoptovano = adoptovano;
        Vek = vek;
        ID = _pocitadloId;
        DatumPrijmu = datumPrijmu;
        ZdravotniStav = zdravotniStav;
        Poznamka = poznamka;
    }
    public override string ToString()
    {
            return $"{ID,-3} | {Jmeno,-10} | {Druh,-8} | {Vek,3} | {Pohlavi,-5} | " +
                   $"{(Adoptovano ? "ANO" : "NE"),-3}";
    }
    }
}
