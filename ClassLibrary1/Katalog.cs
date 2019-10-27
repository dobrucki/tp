using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Katalog
    {
        private string _tytul;
        private string _imieAutora;
        private string _nazwiskoAutora;
        private Guid _idKatalogu;

        public Katalog(string tytul, string imieAutora, string nazwiskoAutora, Guid idKatalogu)
        {
            _tytul = tytul;
            _imieAutora = imieAutora;
            _nazwiskoAutora = nazwiskoAutora;
            _idKatalogu = idKatalogu;
        }

        public string Tytul { get; set; }
        public string ImieAutora { get; set; }
        public string NazwiskoAutora { get; set; }
        public Guid IdKatalogu { get; set; }

    }

    
}
