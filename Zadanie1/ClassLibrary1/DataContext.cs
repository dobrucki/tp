using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;


namespace ClassLibrary1
{
    public class DataContext
    {
        public List<Wykaz> Wykazy = new List<Wykaz>();
        public Dictionary<Guid, Katalog> Katalogi = new Dictionary<Guid, Katalog>();
        public ObservableCollection<Zdarzenie> Zdarzenia = new ObservableCollection<Zdarzenie>();
        public List<OpisStanu> OpisyStanu = new List<OpisStanu>();
    }


}
