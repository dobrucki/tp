using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DataService
    {
        private DataRepository _dataRep;

        public DataService(DataRepository dataRepository)
        {
            _dataRep = dataRepository;
        }


        public IEnumerable<Wykaz> WszystkieWykazy() =>  _dataRep.GetAllWykaz();
        public IEnumerable<Zdarzenie> WszystkieZdarzenia() => _dataRep.GetAllZdarzenie();
        public IEnumerable<OpisStanu> WszystkieOpisyStanu() => _dataRep.GetAllOpisStanu();
        public IEnumerable<Katalog> WszystkieKatalogi() => _dataRep.GetAllKatalog();


        public void Wypozycz(Wykaz w, OpisStanu o)
        {
            Zdarzenie lastZdarzenie = _dataRep.GetAllZdarzenie().Last(x => x.OpisStanu == o);
            if(typeof(Wypozyczenie) == lastZdarzenie.GetType())
            {
                throw new Exception("Dany opis stanu nie jest dostepny!");
            }
            Wypozyczenie wyp = new Wypozyczenie(w, o, DateTime.Today, Guid.NewGuid());
            _dataRep.AddZdarzenie(wyp);
        }

        public void Oddaj(Wykaz w, OpisStanu o)
        {
            Zdarzenie lastZdarzenie = _dataRep.GetAllZdarzenie().Last(x => x.OpisStanu == o);
            if (typeof(Oddanie) == lastZdarzenie.GetType())
            {
                throw new Exception("Dany opis stanu nie został wypożyczony!");
            }
            Oddanie odd = new Oddanie(w, o, DateTime.Today, Guid.NewGuid());
            _dataRep.AddZdarzenie(odd);
        }

        public IEnumerable<Zdarzenie> WypozyczeniaDlaDanegoWykazu(Wykaz wyk)
        {
            List<Zdarzenie> wypozyczeniaDanegoWykazu= new List<Zdarzenie>();

            foreach(Zdarzenie zdarzenie in WszystkieZdarzenia())
            {
                if(zdarzenie.GetType() == typeof(Wypozyczenie) && zdarzenie.Wykaz.IdWykazu.Equals(wyk.IdWykazu))
                {
                    wypozyczeniaDanegoWykazu.Add(zdarzenie);
                }
            }

            return wypozyczeniaDanegoWykazu;
        }

        public IEnumerable<Zdarzenie> OddaniaDlaDanegoWykazu(Wykaz wyk)
        {
            List<Zdarzenie> oddaniaDanegoKlienta = new List<Zdarzenie>();

            foreach (Zdarzenie zdarzenie in WszystkieZdarzenia())
            {
                if (zdarzenie.GetType() == typeof(Oddanie) && zdarzenie.Wykaz.IdWykazu.Equals(wyk.IdWykazu))
                {
                    oddaniaDanegoKlienta.Add(zdarzenie);
                }
            }

            return oddaniaDanegoKlienta;
        }













    }
}
