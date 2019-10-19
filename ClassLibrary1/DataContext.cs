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
        private List<Wykaz> _wykazy = new List<Wykaz>();
        private Dictionary<int, Katalog> _katalogi = new Dictionary<int, Katalog>();
        private ObservableCollection<Zdarzenie> _zdarzenia = new ObservableCollection<Zdarzenie>();
        private List<OpisStanu> _opisyStanu = new List<OpisStanu>();

        public List<Wykaz> Wykazy { get; set; }
        public Dictionary<int, Katalog> Katalogi { get; set; }
        public ObservableCollection<Zdarzenie> Zdarzenia { get; set; }
        public List<OpisStanu> OpisyStanu { get; set; }


    }
}
