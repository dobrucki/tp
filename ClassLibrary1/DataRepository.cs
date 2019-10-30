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

        public void DeleteKatalog(Katalog pozcyja) // Jak zabezpieczamy przed Katalogiem który posiada opis stanu? 
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


        //CRUD ZDARZENIE
        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
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
        
    }
}


