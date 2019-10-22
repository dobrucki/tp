using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class WypelnianieStalymi : IDataFiller
    {
        public void Fill(DataContext dataContext)
        {   
            dataContext.Wykazy.Add(new Wykaz("Mateusz", "Wasilewski", "1"));
            dataContext.Wykazy.Add(new Wykaz("Jędrzej", "Dobrucki", "2"));
            dataContext.Wykazy.Add(new Wykaz("Hubert", "Kowalski", "3"));
            dataContext.Wykazy.Add(new Wykaz("Kinga", "Sierakowska", "4"));
            dataContext.Wykazy.Add(new Wykaz("Bartek", "Piguł", "5"));

            dataContext.Katalogi.Add(0, new Katalog("Quo Vaids", "Henryk", "Sienkiewcz"));
            dataContext.Katalogi.Add(1, new Katalog("Latarnik", "Henryk", "Sienkiewcz"));
            dataContext.Katalogi.Add(2, new Katalog("Krzyżacy", "Henryk", "Sienkiewcz"));
            dataContext.Katalogi.Add(3, new Katalog("Pani Twardowska", "Adam", "Mickiewicz"));
            dataContext.Katalogi.Add(4, new Katalog("Burza", "Henryk", "Sienkiewcz"));

            for(int i=0; i<5; i++)
            {
                dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[i], i + 5, DateTime.Today));
            }

            for(int i=0; i<5; i++)
            {
                dataContext.Zdarzenia.Add(new Zdarzenie(dataContext.Wykazy[i], dataContext.OpisyStanu[i], DateTime.Today));
            }

        }


    }
}
