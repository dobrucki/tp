using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1
{
    public class DataRepository : IDataRepository
    {
        private DataContext _dataContext;

        public DataRepository(IDataFiller filler)
        {
            _dataContext = new DataContext();
            filler.Fill(_dataContext);
        }

        #region CRUDKatalog        
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
                pozycja.IdKatalogu = id;
                _dataContext.Katalogi[id] = pozycja;

            }
            else
            {
                throw new Exception("Brak katalogu o podanym Id!");
            }

        }

        public void DeleteKatalog(Katalog pozcyja)  
        {

            if(GetAllOpisStanu().Where(op => op.Katalog.IdKatalogu == pozcyja.IdKatalogu).Count() ==0)
            {
                if (!_dataContext.Katalogi.Remove(pozcyja.IdKatalogu))
                {
                    throw new Exception("Nie ma takiego katalogu");
                }
                
            }
            else
            {
                throw new Exception("Dany katalog ma opis stanu");
            }
        }

        #endregion

        #region CRUDWykaz
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
                element.IdWykazu = id;
                _dataContext.Wykazy[index] = element;
            }
            else throw new Exception("Brak Wykazu o podanym Id!");
        }

        public void DeleteWykaz(Wykaz element) 
        {

            if (GetAllZdarzenie().Where(zd => zd.Wykaz.IdWykazu == element.IdWykazu).Count() == 0)
            {
                if (!_dataContext.Wykazy.Remove(element))
                {
                    throw new Exception("Nie ma takiego wykazu");
                }

            }
            else
            {
                throw new Exception("Dany wykaz uczestniczyl juz w wydarzeniu");
            }

        }
        #endregion

        #region CRUDOpisStanu
        public void AddOpisStanu(OpisStanu opis)
        {
            if (_dataContext.OpisyStanu.Any(op => op.IdOpisuStanu == opis.IdOpisuStanu))
            {
                throw new Exception("Jest już opis stanu o podanym Id");
            }

            _dataContext.OpisyStanu.Add(opis);
        }
        public OpisStanu GetOpisStanu(Guid id)
        {
            OpisStanu opisStanu = _dataContext.OpisyStanu.Find(x => x.IdOpisuStanu.Equals(id));

            if (opisStanu is null)
            {
                throw new Exception("Brak opisu stanu o podanym Id");
            }
            return opisStanu;
        }

        public IEnumerable<OpisStanu> GetAllOpisStanu()
        {
            return _dataContext.OpisyStanu;
        }

        public void UpdateOpisStanu(Guid id, OpisStanu opisStanu)
        {
            int index = _dataContext.OpisyStanu.FindIndex(op => op.IdOpisuStanu == id);
            if (index != -1)
            {
                opisStanu.IdOpisuStanu = id;
                _dataContext.OpisyStanu[index] = opisStanu;
            }
            else throw new Exception("Brak opisu stanu o podanym Id!");
        }
        public void DeleteOpisStanu(OpisStanu opis)
        {

            if (GetAllZdarzenie().Where(zd => zd.OpisStanu.IdOpisuStanu == opis.IdOpisuStanu).Count() == 0)
            {
                if (!_dataContext.OpisyStanu.Remove(opis))
                {
                    throw new Exception("Nie ma takiego opisu stanu");
                }

            }
            else
            {
                throw new Exception("Dany opis stanu uczestniczyl juz w wydarzeniu");
            }
            #endregion
        }

        #region CRUDZdarzenie
        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            if (_dataContext.Zdarzenia.Any(zd => zd.Guid == zdarzenie.Guid))
            {
                throw new Exception("Jest już zdarzenie o podanym Id");
            }
          
            _dataContext.Zdarzenia.Add(zdarzenie);
        }

        public Zdarzenie GetZdarzenie(Guid guid)
        {
             foreach(Zdarzenie z in _dataContext.Zdarzenia){
                  if (guid == z.Guid)
                  {
                      return z;
                  }
              }
              throw new Exception("Brak zdarzenia o podanym GUID");

     

        }

        public IEnumerable<Zdarzenie> GetAllZdarzenie()
        {
            return _dataContext.Zdarzenia;
        }

        public void UpdateZdarzenie(Guid guid, Zdarzenie zdarzenie)
        {
            List<Zdarzenie> zdList= new List<Zdarzenie>(_dataContext.Zdarzenia);

            int index = zdList.FindIndex(zd => zd.Guid == guid);
            if (index != -1)
            {
                zdarzenie.Guid= guid;
                _dataContext.Zdarzenia[index] = zdarzenie;
            }
            else throw new Exception("Brak zdarzenia o podanym Id!");


        }


        public void DeleteZdarzenie(Zdarzenie zdarzenie)
        {

            if (!_dataContext.Zdarzenia.Remove(zdarzenie))
            {
                throw new Exception("Zdarzenie nie istnieje!");
            }
        }

        #endregion
    }
}


