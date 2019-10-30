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
            

            Wykaz.Adres ad1 = new Wykaz.Adres("Łódź", "92-525", "Sacharowa", "7");
            Wykaz.Adres ad2 = new Wykaz.Adres("Zelów", "99-525", "Piotrkowska", "77");
            Wykaz.Adres ad3 = new Wykaz.Adres("Łódź", "99-999", "Kwiatowa", "33");
            Wykaz.Adres ad4 = new Wykaz.Adres("Warszawa", "66-666", "Nocna", "1");
            Wykaz.Adres ad5 = new Wykaz.Adres("Łódź", "91-225", "Gorkiego", "33");

            dataContext.Wykazy.Add(new Wykaz("Mateusz", "Wasilewski", new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), ad1));
            dataContext.Wykazy.Add(new Wykaz("Jędrzej", "Dobrucki", new Guid("a8292587-864d-4d35-be17-2081028ef439"), ad2));
            dataContext.Wykazy.Add(new Wykaz("Hubert", "Kowalski", new Guid("5241c8c9-9992-4f04-9c97-66f592a0d269"), ad3));
            dataContext.Wykazy.Add(new Wykaz("Kinga", "Sierakowska", new Guid("5f9ad251-b8dc-48c6-a027-f67c37fa6f09"), ad4));
            dataContext.Wykazy.Add(new Wykaz("Bartek", "Piguł", new Guid("ca761232-ed42-11ce-bacd-00aa0057b223"), ad5));

            dataContext.Katalogi.Add(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), new Katalog("Quo Vaids", "Henryk", "Sienkiewcz", new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")));
            dataContext.Katalogi.Add(new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5"), new Katalog("Latarnik", "Henryk", "Sienkiewcz", new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5")));
            dataContext.Katalogi.Add(new Guid("ab23a3c2-9dba-4a8a-aacf-daba29cf7000"), new Katalog("Krzyżacy", "Henryk", "Sienkiewcz", new Guid("ab23a3c2-9dba-4a8a-aacf-daba29cf7000")));
            dataContext.Katalogi.Add(new Guid("842f8c3e-878b-48f9-bc31-d50cd2be22da"), new Katalog("Pani Twardowska", "Adam", "Mickiewicz", new Guid("842f8c3e-878b-48f9-bc31-d50cd2be22da")));
            dataContext.Katalogi.Add(new Guid("c448467b-17ab-450b-8f64-1450022762ed"), new Katalog("Burza", "Henryk", "Sienkiewcz", new Guid("c448467b-17ab-450b-8f64-1450022762ed")));

            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")],1999, new Guid("434518ba-a2de-42df-ae6b-300eaf416053")));
            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5")],2010, new Guid("919a5dd9-4191-4eee-8a32-d8bbc74e36c4")));
            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[new Guid("ab23a3c2-9dba-4a8a-aacf-daba29cf7000")],2015, new Guid("5e1a8991-131b-4393-97fa-dff595b19223")));
            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[new Guid("842f8c3e-878b-48f9-bc31-d50cd2be22da")],1980, new Guid("0600e982-f656-43a0-85ba-c7eec7e5c7eb")));
            dataContext.OpisyStanu.Add(new OpisStanu(dataContext.Katalogi[new Guid("c448467b-17ab-450b-8f64-1450022762ed")],1970, new Guid("0d52260a-30d9-4101-a362-3d393a953d41")));

            dataContext.Zdarzenia.Add(new Wypozyczenie(dataContext.Wykazy[0], dataContext.OpisyStanu[0], DateTime.Today, new Guid("d473a55e-54c7-4617-9f47-090708101f2d")));
            dataContext.Zdarzenia.Add(new Wypozyczenie(dataContext.Wykazy[1], dataContext.OpisyStanu[1], DateTime.Today, new Guid("929fc65d-1dce-4b34-8f33-277afff5cb7f")));
            dataContext.Zdarzenia.Add(new Wypozyczenie(dataContext.Wykazy[2], dataContext.OpisyStanu[2], DateTime.Today, new Guid("597f4b79-c573-4c1e-a1b8-9ee7111ab832")));
            dataContext.Zdarzenia.Add(new Wypozyczenie(dataContext.Wykazy[3], dataContext.OpisyStanu[3], DateTime.Today, new Guid("7825994c-b1a8-461b-a3e4-a2519c078956")));
            dataContext.Zdarzenia.Add(new Wypozyczenie(dataContext.Wykazy[4], dataContext.OpisyStanu[4], DateTime.Today, new Guid("d174090f-c973-4674-aa06-125190c337b5")));

        }


    }
}
