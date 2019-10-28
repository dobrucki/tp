using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Wypozyczenie : Zdarzenie
    {
        public Wypozyczenie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataZdarzenia, Guid id) : base(wykaz, opisStanu, dataZdarzenia, id)
        {
        }

        public override bool Validate(DataRepository dataRepository)
        {
            if(OpisStanu.StanPozycji.AVALIABLE != OpisStanu.Stan)
            {
                return false;
            }
            OpisStanu.Stan = OpisStanu.StanPozycji.RENTED;
            return true;
        }
    }
}
