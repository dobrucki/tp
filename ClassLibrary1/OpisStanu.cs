using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class OpisStanu
    {
        private Katalog _katalog;
        private int _liczbaSztuk;

        public OpisStanu(Katalog katalog, int liczbaSztuk)
        {
            _katalog = katalog;
            _liczbaSztuk = liczbaSztuk;
        }

        public int LiczbaSztuk{ get; set; }
        public Katalog Katalog { get; set; }
    }
}
