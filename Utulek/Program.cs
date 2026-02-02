using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utulek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Evidence evidence = new Evidence();
            KonzoleUI ui = new KonzoleUI(evidence);
            ui.Spustit();

        }
    }
}
