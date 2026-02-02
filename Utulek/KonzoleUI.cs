using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utulek
{
    internal class KonzoleUI
    {
        private Evidence evidence;

        public KonzoleUI(Evidence e)
        {
            evidence = e;
        }

        public void Spustit()
        {
            while (true)
            {
                VypisMenu();
                Console.Write("Volba: ");
                string volba = Console.ReadLine();

                switch (volba)
                {
                    case "1": Pridani(); break;
                    case "2": Vypis(); break;
                    case "3": Filtr(); break;
                    case "4": Adopce(); break;
                    case "0": return;
                    default: Console.WriteLine("Neplatná volba."); break;
                }
            }
        }

        private void VypisMenu()
        {
            Console.WriteLine("\n===== ÚTULEK PRO ZVÍŘATA =====");
            Console.WriteLine("1) Přidat zvíře");
            Console.WriteLine("2) Vypsat všechna zvířata");
            Console.WriteLine("3) Vyhledat / filtrovat");
            Console.WriteLine("4) Označit adopci");
            Console.WriteLine("0) Konec");
        }

        private void Pridani()
        {
            

            Console.Write("Jméno: ");
            string Jmeno = Console.ReadLine();

            Console.Write("Adoptované? (y/n): ");
            string moznost = Console.ReadLine();
            bool Adoptovano = false;
            if (moznost == "y")
            {
                Adoptovano = true;
            }
            else
            {
                Adoptovano = false;
            }

                Console.Write("Druh: ");
            string Druh = Console.ReadLine();

            int Vek = NactiInt("Věk: ");

            Console.Write("Pohlaví: ");
            string Pohlavi = Console.ReadLine();

            DateTime DatumPrijmu = DateTime.Today;

            Console.Write("Zdravotní stav: ");
            string ZdravotniStav = Console.ReadLine();

            Console.Write("Poznámka (volitelné): ");
            string Poznamka = Console.ReadLine();

            Zvire z = new Zvire(Jmeno, Druh, Pohlavi,Adoptovano,Vek,DatumPrijmu,ZdravotniStav,Poznamka );
            evidence.PridatZvire(z);
            Console.WriteLine("Zvíře přidáno.");
        }

        private void Vypis()
        {
            Console.WriteLine("\nID | Jméno      | Druh     | Věk | Pohl | ADO");
            Console.WriteLine("----------------------------------------------");
            foreach (var z in evidence.VratVse())
                Console.WriteLine(z);
        }

        private void Filtr()
        {
            Console.Write("Druh (nebo Enter): ");
            string druh = Console.ReadLine();

            int? vekOd = NactiIntNullable("Věk od (Enter = bez omezení): ");
            int? vekDo = NactiIntNullable("Věk do (Enter = bez omezení): ");

            Console.Write("Jméno (nebo Enter): ");
            string jmeno = Console.ReadLine();

            var vysledek = evidence.Filtrovat(druh, vekOd, vekDo, jmeno);
            foreach (var z in vysledek)
                Console.WriteLine(z);
        }

        private void Adopce()
        {
            int id = NactiInt("Zadej ID zvířete: ");
            if (evidence.OznacitAdopci(id))
                Console.WriteLine("Zvíře označeno jako adoptované.");
            else
                Console.WriteLine("Adopci nelze provést.");
        }

        private int NactiInt(string text)
        {
            int x;
            while (true)
            {
                Console.Write(text);
                if (int.TryParse(Console.ReadLine(), out x) && x >= 0)
                    return x;
                Console.WriteLine("Zadej nezáporné číslo.");
            }
        }

        private int? NactiIntNullable(string text)
        {
            Console.Write(text);
            string s = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s)) return null;
            if (int.TryParse(s, out int x) && x >= 0) return x;
            return null;
        }
    }
}

