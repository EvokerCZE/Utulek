using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utulek
{
    internal class Evidence
    {
        private List<Zvire> zvirata = new List<Zvire>();

        public Evidence()
        {
            PridatZvire(new Zvire
            (
                "Azor",
                "Pes",
                "M",
                true,
                4,
                DateTime.Today.AddDays(-30),
                "OK",
                ""
            ));

            PridatZvire(new Zvire
            (
                "Micka",
                "Kočka",
                "F",
                false,
                2,
                DateTime.Today.AddDays(-10),
                "OK",
                "Potřebuje očkování"
            ));
        }

        public void PridatZvire(Zvire z)
        {
            zvirata.Add(z);
        }

        public List<Zvire> VratVse()
        {
            return zvirata;
        }

        public List<Zvire> Filtrovat(string druh, int? vekOd, int? vekDo, string jmeno)
        {
            return zvirata.Where(z =>
                (string.IsNullOrEmpty(druh) || z.Druh.ToLower().Contains(druh.ToLower())) &&
                (!vekOd.HasValue || z.Vek >= vekOd) &&
                (!vekDo.HasValue || z.Vek <= vekDo) &&
                (string.IsNullOrEmpty(jmeno) || z.Jmeno.ToLower().Contains(jmeno.ToLower()))
            ).ToList();
        }

        public bool OznacitAdopci(int id)
        {
            var zvire = zvirata.FirstOrDefault(z => z.ID == id);
            if (zvire == null || zvire.Adoptovano) return false;

            zvire.Adoptovano = true;
            return true;
        }
    }
}
