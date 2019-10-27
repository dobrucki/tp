using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Katalog
    {
        public string Tytul { get; set; }
        public string ImieAutora { get; set; }
        public string NazwiskoAutora { get; set; }
        public Guid IdKatalogu { get; set; }

        public Katalog(string tytul, string imieAutora, string nazwiskoAutora, Guid idKatalogu)
        {
            Tytul = tytul;
            ImieAutora = imieAutora;
            NazwiskoAutora = nazwiskoAutora;
            IdKatalogu = idKatalogu;
        }
        

    }

    
}
