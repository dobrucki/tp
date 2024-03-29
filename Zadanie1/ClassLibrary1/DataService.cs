﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace ClassLibrary1
{
    public class DataService
    {
        private IDataRepository _dataRep;

        public DataService(IDataRepository dataRepository)
        {
            _dataRep = dataRepository;
        }

        public void Wypozycz(Wykaz w, OpisStanu o)
        {
            if(CzyWypozyczony(o))
            {
                throw new Exception("Dany opis stanu nie jest dostepny!");
            }
            Wypozyczenie wyp = new Wypozyczenie(w, o, DateTime.Today, Guid.NewGuid());
            _dataRep.AddZdarzenie(wyp);
        }

        public void Oddaj(Wykaz w, OpisStanu o)
        {
            if (!CzyWypozyczony(o))
            {
                throw new Exception("Dany opis stanu nie został wypożyczony!");
            }
            Oddanie odd = new Oddanie(w, o, DateTime.Today, Guid.NewGuid());
            _dataRep.AddZdarzenie(odd);
        }

        public IEnumerable<Zdarzenie> WypozyczeniaDlaDanegoWykazu(Wykaz wyk)
        {
            return _dataRep.GetAllZdarzenie().Where(x => x.Wykaz == wyk).Where(x => x.GetType() == typeof(Wypozyczenie));
        }

        public IEnumerable<Zdarzenie> OddaniaDlaDanegoWykazu(Wykaz wyk)
        {
            return _dataRep.GetAllZdarzenie().Where(x => x.Wykaz == wyk).Where(x => x.GetType() == typeof(Oddanie));
        }

        public bool CzyWypozyczony(OpisStanu opisStanu)
        {
            try
            {
                Zdarzenie zdarzenie = _dataRep.GetAllZdarzenie().Last(z => z.OpisStanu == opisStanu);
                if (typeof(Wypozyczenie) == zdarzenie.GetType())
                {
                    return true;
                }
            } catch(System.InvalidOperationException)
            {
            }
            return false;
        }

        public int LiczbaDostepnychOpisowStanu(Katalog katalog)
        {
            return DostepneOpisyStanuDlaKatalogu(katalog).Count();
        }

        public IEnumerable<OpisStanu> DostepneOpisyStanuDlaKatalogu(Katalog katalog)
        {
            return _dataRep.GetAllOpisStanu().Where(x => x.Katalog == katalog).Where(x => !CzyWypozyczony(x));
        }



        public IEnumerable<Wykaz> WszystkieWykazy() => _dataRep.GetAllWykaz();
        public IEnumerable<Zdarzenie> WszystkieZdarzenia() => _dataRep.GetAllZdarzenie();
        public IEnumerable<OpisStanu> WszystkieOpisyStanu() => _dataRep.GetAllOpisStanu();
        public IEnumerable<Katalog> WszystkieKatalogi() => _dataRep.GetAllKatalog();

        public void DodajWykaz(Wykaz wykaz) => _dataRep.AddWykaz(wykaz);
        public void DodajKatalog(Katalog katalog) => _dataRep.AddKatalog(katalog);
        public void DodajOpisStanu(OpisStanu opis) => _dataRep.AddOpisStanu(opis);




    }
}
