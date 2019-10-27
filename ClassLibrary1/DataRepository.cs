using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class DataRepository
    {
        private DataContext _dataContext;

        public DataRepository(IDataFiller filler)
        {
            _dataContext = new DataContext();
            filler.Fill(_dataContext);
        }

        //CRUD Katalog
        public void AddKatalog(Katalog pozycja)
        {
            if(_dataContext.Katalogi.ContainsKey(pozycja.IdKatalogu))
            {
                throw new Exception("Jest już dodany katalog o podanym Id!");
            }
            else
            {
                _dataContext.Katalogi.Add(pozycja.IdKatalogu, pozycja);
            }
        }

        public Katalog GetKatalog(Guid id)
        {
            if (_dataContext.Katalogi.ContainsKey(id))
            {
                return _dataContext.Katalogi[id];
            }
            else
            {
                throw new Exception("Brak katalogu o podanym Id!");
            }
        }

        public IEnumerable<Katalog> GetAllKatalog()
        {
            return _dataContext.Katalogi.Values;
        }

        public void UpdateKatalog(Guid id, Katalog pozycja)
        {
            if (_dataContext.Katalogi.ContainsKey(id))
            {
                _dataContext.Katalogi[id] = pozycja;
            }
            else
            {
                throw new Exception("Brak katalogu o podanym Id!");
            }

        }

        public void DeleteKatalog(Guid id) // Jak zabezpieczamy przed Katalogiem który posiada opis stanu? 
        {
            if (_dataContext.Katalogi.ContainsKey(id))
            {
                _dataContext.Katalogi.Remove(id);
            }
            else
            {
                throw new Exception("Brak katalogu o podanym Id!");
            }
        }

        //CRUD Wykaz
        public void AddWykaz(Wykaz element)
        {
            if (_dataContext.Wykazy.Any(wyk => wyk.IdWykazu == element.IdWykazu))
            {
                throw new Exception("Jest już wykaz o podanym Id");
            }

            _dataContext.Wykazy.Add(element);
        }

        public Wykaz GetWykaz(Guid id)
        {
            Wykaz wykaz = _dataContext.Wykazy.Find(x => x.IdWykazu.Equals(id));
            
            if (wykaz is null) {
                throw new Exception("Brak wykazu o podanym Id");
            }
            return wykaz;
        }

        public IEnumerable<Wykaz> GetAllWykaz()
        {
            return _dataContext.Wykazy;
        }

        public void UpdateWykaz(Guid id, Wykaz element)
        {
            int index = _dataContext.Wykazy.FindIndex(wyk => wyk.IdWykazu == id);
            if (index != -1)
            {
                _dataContext.Wykazy.Insert(index, element);
            }
            else throw new Exception("Brak Wykazu o podanym Id!");
        }

        public void DeleteWykaz(Wykaz element) // Jak zabezpieczamy przed Wykazem użytym w zdarzeniu? 
        {
            if (!_dataContext.Wykazy.Remove(element))
            {
                throw new Exception("Taki wykaz nie istnieje!");
            }


        }

        //CRUD OPIS STANU
        // ...
        //CRUD ZDARZENIE
        //...


    }
}


