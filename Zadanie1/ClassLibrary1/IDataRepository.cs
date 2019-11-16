using System;
using System.Collections.Generic;


namespace ClassLibrary1
{
    public interface IDataRepository
    {
        void AddKatalog(Katalog katalog);
        Katalog GetKatalog(Guid id);
        IEnumerable<Katalog> GetAllKatalog();
        void UpdateKatalog(Guid id, Katalog pozycja);
        void DeleteKatalog(Katalog pozcyja);


        void AddWykaz(Wykaz element);
        Wykaz GetWykaz(Guid id);
        IEnumerable<Wykaz> GetAllWykaz();
        void UpdateWykaz(Guid id, Wykaz element);
        void DeleteWykaz(Wykaz element);


        void AddOpisStanu(OpisStanu opis);
        OpisStanu GetOpisStanu(Guid id);
        IEnumerable<OpisStanu> GetAllOpisStanu();
        void UpdateOpisStanu(Guid id, OpisStanu opisStanu);
        void DeleteOpisStanu(OpisStanu opis);


        void AddZdarzenie(Zdarzenie zdarzenie);
        Zdarzenie GetZdarzenie(Guid guid);
        IEnumerable<Zdarzenie> GetAllZdarzenie();
        void UpdateZdarzenie(Guid guid, Zdarzenie zdarzenie);
        void DeleteZdarzenie(Zdarzenie zdarzenie);

    }
}
