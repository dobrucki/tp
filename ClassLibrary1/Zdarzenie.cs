using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Zdarzenie
    {
        private Wykaz _wykaz;
        private OpisStanu _opisStanu;
        private DateTime _dataWypozyczenia;

        public Zdarzenie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataWypozyczenia)
        {
            _wykaz = wykaz;
            _opisStanu = opisStanu;
            _dataWypozyczenia = dataWypozyczenia;
        }

        public Wykaz Wykaz { get; private set; }
        public OpisStanu OpisStanu { get; private set; }
        public DateTime DataWypozyczenia { get; private set; }
    }
}
