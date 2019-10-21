using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class DataRepository
    {
        private DataContext _dataContext = new DataContext();

        public DataRepository(IDataFiller filler)
        {
            filler.Fill(_dataContext); // Nie wiem czy to zadziała
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

        //Update nie wiem co możemy updatować
        


        public void DeleteKatalog(int i)
        {
            foreach(Katalog k in _dataContext.Katalogi)
            {
                if()
            }
        }



        //CRUD Wykaz
        public void AddWykaz(Wykaz element)
        {
            _dataContext.Wykazy.Add(element);
        }

        public Wykaz GetWykaz(String id)
        {
            foreach(Wykaz w in _dataContext.Wykazy)
            {
                if (w.IdWykazu == id) return w;
                
            }

            throw new Exception("Brak wykazu o podanym ID");
            
        }

        public IEnumerable<Wykaz> GetAllWykaz()
        {
            return _dataContext.Wykazy;

        }










    }


}
