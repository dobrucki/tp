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
            _dataContext.Katalogi.Add(_dataContext.Katalogi.Keys.Count, pozycja);
        }

        public Katalog GetKatalog(int id)
        {
            return _dataContext.Katalogi[id];
        }

        public IEnumerable<Katalog> GetAllKatalog()
        {
            return _dataContext.Katalogi.Values;
        }

        public void UpdateKatalog(int id, Katalog pozycja)
        {
            _dataContext.Katalogi[id] = pozycja;
        }

        public void DeleteKatalog(int id)
        {
            _dataContext.Katalogi.Remove(id);
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
            if (_dataContext.Wykazy.Any(wyk => wyk.IdWykazu == id))
            {
                return _dataContext.Wykazy.Find(x => x.IdWykazu.Equals(id));
            }

            else throw new Exception("Brak wykazu o podanym Id");

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

    }
}


