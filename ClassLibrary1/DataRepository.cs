using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class DataRepository
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
            _dataContext.Wykazy.Add(element);
        }

        public Wykaz GetWykaz(String id)
        {
            return _dataContext.Wykazy.Find(x => x.IdWykazu.Equals(id));    
        }

        public IEnumerable<Wykaz> GetAllWykaz()
        {
            return _dataContext.Wykazy;
        }

        public void UpdateWykaz(int id, Wykaz element)
        {
            _dataContext.Wykazy.Insert(id, element);
        }

        public void DeleteWykaz(Wykaz element)
        {
            _dataContext.Wykazy.Remove(element);
        }










    }


}
