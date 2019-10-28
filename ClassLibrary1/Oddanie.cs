using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Oddanie : Zdarzenie
    {
        public Oddanie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataZdarzenia, Guid id) : base(wykaz, opisStanu, dataZdarzenia, id)
        {
        }

        public override bool Validate()
        {
            if (OpisStanu.StanPozycji.RENTED == OpisStanu.Stan)
            {
                OpisStanu.Stan = OpisStanu.StanPozycji.AVALIABLE;
                return true;
            }
            return false;
        }
    }
}
