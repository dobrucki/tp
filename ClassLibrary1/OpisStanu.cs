using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class OpisStanu
    {
        private Katalog _katalog;
        private int _liczbaSztuk;
        private int _rokWydania;


        public OpisStanu(Katalog katalog, int liczbaSztuk, int rokWydania)
        {
            _katalog = katalog;
            _liczbaSztuk = liczbaSztuk;
            _rokWydania = rokWydania;
        }

        public int LiczbaSztuk{ get; set; }
        public Katalog Katalog { get; set; }
        public int RokWydania { get; set; }
    }
}
