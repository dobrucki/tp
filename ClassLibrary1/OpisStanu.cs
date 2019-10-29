using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class OpisStanu
    {

        public Katalog Katalog { get; }
        public int RokWydania { get; }
        public Guid IdOpisuStanu { get; }


        public OpisStanu(Katalog katalog, int rokWydania, Guid idOpisuStanu)
        {
            Katalog = katalog;
            RokWydania = rokWydania;
            IdOpisuStanu = idOpisuStanu;
        }
       
    }
}
