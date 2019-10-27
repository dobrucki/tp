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


        private readonly Katalog _katalog;
        private readonly int _rokWydania;
        private StanPozycji _stan;


        public OpisStanu(Katalog katalog, int rokWydania)
        {
            _katalog = katalog;
            _rokWydania = rokWydania;
            _stan = StanPozycji.AVALIABLE;
        }
        
        public Katalog Katalog { get; }
        public int RokWydania { get; }
        public StanPozycji Stan { get; set; }
    }
}
