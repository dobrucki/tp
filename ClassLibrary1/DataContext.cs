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
        private List<Wykaz> _wykazy;
        private Dictionary<int, Katalog> _katalogi;
        private ObservableCollection<Zdarzenie> _zdarzenia;
        private List<OpisStanu> _opisyStanu;

        public DataContext()
        {
            _wykazy = new List<Wykaz>();
            _katalogi = new Dictionary<int, Katalog>();
            _zdarzenia = new ObservableCollection<Zdarzenie>();
            _opisyStanu = new List<OpisStanu>();
        }
    }
}
