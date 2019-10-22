using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class DataContext
    {
        public List<Wykaz> Wykazy = new List<Wykaz>();
        public Dictionary<int, Katalog> Katalogi = new Dictionary<int, Katalog>();
        public ObservableCollection<Zdarzenie> Zdarzenia = new ObservableCollection<Zdarzenie>();
        public List<OpisStanu> OpisyStanu = new List<OpisStanu>();
    }
}
