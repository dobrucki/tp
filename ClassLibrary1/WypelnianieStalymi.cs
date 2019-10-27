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
            dataContext.Wykazy.Add(new Wykaz("Mateusz", "Wasilewski", new Guid("0f8fad5b-d9cb-469f-a165-70867728950e")));
            dataContext.Wykazy.Add(new Wykaz("Jędrzej", "Dobrucki", new Guid("a8292587-864d-4d35-be17-2081028ef439")));
            dataContext.Wykazy.Add(new Wykaz("Hubert", "Kowalski", new Guid("5241c8c9-9992-4f04-9c97-66f592a0d269")));
            dataContext.Wykazy.Add(new Wykaz("Kinga", "Sierakowska", new Guid("5f9ad251-b8dc-48c6-a027-f67c37fa6f09")));
            dataContext.Wykazy.Add(new Wykaz("Bartek", "Piguł", new Guid("ca761232-ed42-11ce-bacd-00aa0057b223")));

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
