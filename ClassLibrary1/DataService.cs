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
            Wypozyczenie wyp = new Wypozyczenie(w, o, DateTime.Today, Guid.NewGuid());
            if(wyp.Validate())
            {
                _dataRep.AddZdarzenie(wyp);
            }
            else
            {
                throw new Exception("Dany opis stanu nie jest dostepny!");
            }
            
        }

        public void Oddaj(Wykaz w, OpisStanu o)
        {
            Oddanie odd = new Oddanie(w, o, DateTime.Today, Guid.NewGuid());
            if (odd.Validate())
            {
                _dataRep.AddZdarzenie(odd);
            }
            else
            {
                throw new Exception("Nie mozna oddac tego opisu stanu!");
            }

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
