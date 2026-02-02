using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utulek
{
    internal class Evidence
    {
        private List<Zvire> zvireta = new List<Zvire>();
        private int dalsiId = 1;

        public Evidence()
        {
            PridatZvire(new Zvire
            {
                Jmeno = "Azor",
                Druh = "Pes",
                Vek = 4,
                Pohlavi = "M",
                DatumPrijmu = DateTime.Today.AddDays(-30),
                ZdravotniStav = "OK"
            });

            PridatZvire(new Zvire
            {
                Jmeno = "Micka",
                Druh = "Kočka",
                Vek = 2,
                Pohlavi = "F",
                DatumPrijmu = DateTime.Today.AddDays(-10),
                ZdravotniStav = "OK"
            });
        }

        public void PridatZvire(Zvire z)
        {
            z.Id = dalsiId++;
            zvireta.Add(z);
        }

        public List<Zvire> VratVse()
        {
            return zvireta;
        }

        public List<Zvire> Filtrovat(string druh, int? vekOd, int? vekDo, string jmeno)
        {
            return zvireta.Where(z =>
                (string.IsNullOrEmpty(druh) || z.Druh.ToLower().Contains(druh.ToLower())) &&
                (!vekOd.HasValue || z.Vek >= vekOd) &&
                (!vekDo.HasValue || z.Vek <= vekDo) &&
                (string.IsNullOrEmpty(jmeno) || z.Jmeno.ToLower().Contains(jmeno.ToLower()))
            ).ToList();
        }

        public bool OznacitAdopci(int id)
        {
            var zvire = zvireta.FirstOrDefault(z => z.Id == id);
            if (zvire == null || zvire.Adoptovano) return false;

            zvire.Adoptovano = true;
            zvire.DatumAdopce = DateTime.Today;
            return true;
        }
    }
}
