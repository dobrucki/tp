using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public abstract class Zdarzenie
    {
        public Guid Guid { get; }
        public Wykaz Wykaz { get; }
        public OpisStanu OpisStanu { get; }
        public DateTime DataZdarzenia { get; }

        public Zdarzenie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataZdarzenia, Guid guid)
        {
            Wykaz = wykaz;
            OpisStanu = opisStanu;
            DataZdarzenia = dataZdarzenia;
            Guid = guid;
        }

        public abstract bool Validate();
        
    }
}
