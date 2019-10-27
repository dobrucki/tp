using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Wypozyczenie : Zdarzenie
    {
        public Wypozyczenie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataZdarzenia) : base(wykaz, opisStanu, dataZdarzenia)
        {
        }
    }
}
