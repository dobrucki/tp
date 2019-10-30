using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class WypelnianieZPliku : IDataFiller
    {
        private string _path;

        public WypelnianieZPliku(string path)
        {
            _path = path;
        }

        public void Fill(DataContext dataContext)
        {
            dataContext.Zdarzenia = new System.Collections.ObjectModel.ObservableCollection<Zdarzenie>();
            dataContext.OpisyStanu = new List<OpisStanu>();
            dataContext.Katalogi = new Dictionary<Guid, Katalog>();
            dataContext.Wykazy = new List<Wykaz>();

            using (System.IO.StreamReader reader = new System.IO.StreamReader(_path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] v = line.Split(';');

                    switch (v[0])
                    {
                        case "Wykaz":
                            Wykaz.Adres adres = new Wykaz.Adres(v[4], v[5], v[6], v[7]);
                            Wykaz wykaz = new Wykaz(v[1], v[2], new Guid(v[3]), adres);
                            dataContext.Wykazy.Add(wykaz);
                            break;

                        case "Katalog":
                            Katalog katalog = new Katalog(v[2], v[3], v[4], new Guid(v[5]));
                            dataContext.Katalogi.Add(katalog.IdKatalogu, katalog);
                            break;
                    }

                }
            }




            throw new NotImplementedException();
        }
    }
}
