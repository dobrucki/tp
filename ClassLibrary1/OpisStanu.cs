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
        private DateTime _dataZakupu;

        public OpisStanu(Katalog katalog, int liczbaSztuk, DateTime dataZakupu)
        {
            _katalog = katalog;
            _liczbaSztuk = liczbaSztuk;
            _dataZakupu = dataZakupu;
        }

        public int LiczbaSztuk{ get; set; }
        public Katalog Katalog { get; set; }
        public DateTime DataZakupu { get; set; }
    }
}
