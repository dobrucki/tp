using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class Zdarzenie
    {
        private Wykaz _wykaz;
        private OpisStanu _opisStanu;
        private DateTime _dataZdarzenia;

        public Zdarzenie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataZdarzenia)
        {
            _wykaz = wykaz;
            _opisStanu = opisStanu;
            _dataZdarzenia = dataZdarzenia;
        }

        public Wykaz Wykaz { get; }
        public OpisStanu OpisStanu { get; }
        public DateTime DataWypozyczenia { get; }
    }
}
