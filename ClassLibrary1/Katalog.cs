using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Katalog
    {
        private string _tytul;
        private string _imieAutora;
        private string _nazwiskoAutora;
        private string _idKatalogu;

        public Katalog(string tytul, string imieAutora, string nazwiskoAutora, string idKatalogu)
        {
            _tytul = tytul;
            _imieAutora = imieAutora;
            _nazwiskoAutora = nazwiskoAutora;
            _idKatalogu = idKatalogu;
        }

        public string Tytul { get; set; }
        public string ImieAutora { get; set; }
        public string NazwiskoAutora { get; set; }
        public string IdKatalogu { get; set; }

    }

    
}
