using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class OpisStanu
    {
        public enum StanPozycji
        {
            AVALIABLE,
            RENTED,
            DESTROYED
        }


        public Katalog Katalog { get; }
        public int RokWydania { get; }
        public StanPozycji Stan { get; set; }


        public OpisStanu(Katalog katalog, int rokWydania)
        {
            Katalog = katalog;
            RokWydania = rokWydania;
            Stan = StanPozycji.AVALIABLE;
        }
       
    }
}
