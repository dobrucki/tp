using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using Zadanie2;
using System.IO;

namespace Zadanie2Testy
{
    [TestClass]
    public class SerializationTest
    {
        [TestMethod]
        public void MyFormatterTest_TheSameAddres()
        {
            DataContext dataContextBeforeSerialization = new DataContext();

            Wykaz.Adres ad1 = new Wykaz.Adres("Łódź", "92-525", "Sacharowa", "7");
            Wykaz.Adres ad2 = new Wykaz.Adres("Zelów", "99-525", "Piotrkowska", "77");

            dataContextBeforeSerialization.Wykazy.Add(new Wykaz("Mateusz", "Wasilewski", new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), ad1));
            dataContextBeforeSerialization.Wykazy.Add(new Wykaz("Jędrzej", "Dobrucki", new Guid("a8292587-864d-4d35-be17-2081028ef439"), ad2));

            dataContextBeforeSerialization.Katalogi.Add(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), new Katalog("Quo Vaids", "Henryk", "Sienkiewcz", new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")));
            dataContextBeforeSerialization.Katalogi.Add(new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5"), new Katalog("Latarnik", "Henryk", "Sienkiewcz", new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5")));

            dataContextBeforeSerialization.OpisyStanu.Add(new OpisStanu(dataContextBeforeSerialization.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")], 1999, new Guid("434518ba-a2de-42df-ae6b-300eaf416053")));
            dataContextBeforeSerialization.OpisyStanu.Add(new OpisStanu(dataContextBeforeSerialization.Katalogi[new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5")], 2010, new Guid("919a5dd9-4191-4eee-8a32-d8bbc74e36c4")));

            dataContextBeforeSerialization.Zdarzenia.Add(new Wypozyczenie(dataContextBeforeSerialization.Wykazy[0], dataContextBeforeSerialization.OpisyStanu[0], DateTime.Today, new Guid("d473a55e-54c7-4617-9f47-090708101f2d")));
            dataContextBeforeSerialization.Zdarzenia.Add(new Wypozyczenie(dataContextBeforeSerialization.Wykazy[1], dataContextBeforeSerialization.OpisyStanu[1], DateTime.Today, new Guid("929fc65d-1dce-4b34-8f33-277afff5cb7f")));

            string path = "test.dat";

            MyFormatter myFormatter = new MyFormatter();
            Stream serializationStream = File.Open(path, FileMode.Create, FileAccess.Write);
            myFormatter.Serialize(serializationStream, dataContextBeforeSerialization);
            serializationStream.Close();


            Stream deserializationStream = File.Open(path, FileMode.Open, FileAccess.Read);
            DataContext dataContextAfterSerialization = myFormatter.Deserialize(deserializationStream);
            deserializationStream.Close();

            Assert.AreEqual(dataContextBeforeSerialization.Wykazy[0].AdresWykazu.KodPocztowy, dataContextAfterSerialization.Wykazy[0].AdresWykazu.KodPocztowy);
            Assert.AreEqual(dataContextBeforeSerialization.Wykazy[0].AdresWykazu.Miasto, dataContextAfterSerialization.Wykazy[0].AdresWykazu.Miasto);
            Assert.AreEqual(dataContextBeforeSerialization.Wykazy[0].AdresWykazu.Ulica, dataContextAfterSerialization.Wykazy[0].AdresWykazu.Ulica);
            Assert.AreEqual(dataContextBeforeSerialization.Wykazy[0].AdresWykazu.Numer, dataContextAfterSerialization.Wykazy[0].AdresWykazu.Numer);
        }

        [TestMethod]
        public void MyFormatterTest_TheSameWykaz()
        {
            DataContext dataContextBeforeSerialization = new DataContext();

            Wykaz.Adres ad1 = new Wykaz.Adres("Łódź", "92-525", "Sacharowa", "7");
            Wykaz.Adres ad2 = new Wykaz.Adres("Zelów", "99-525", "Piotrkowska", "77");

            dataContextBeforeSerialization.Wykazy.Add(new Wykaz("Mateusz", "Wasilewski", new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), ad1));
            dataContextBeforeSerialization.Wykazy.Add(new Wykaz("Jędrzej", "Dobrucki", new Guid("a8292587-864d-4d35-be17-2081028ef439"), ad2));

            dataContextBeforeSerialization.Katalogi.Add(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), new Katalog("Quo Vaids", "Henryk", "Sienkiewcz", new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")));
            dataContextBeforeSerialization.Katalogi.Add(new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5"), new Katalog("Latarnik", "Henryk", "Sienkiewcz", new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5")));

            dataContextBeforeSerialization.OpisyStanu.Add(new OpisStanu(dataContextBeforeSerialization.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")], 1999, new Guid("434518ba-a2de-42df-ae6b-300eaf416053")));
            dataContextBeforeSerialization.OpisyStanu.Add(new OpisStanu(dataContextBeforeSerialization.Katalogi[new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5")], 2010, new Guid("919a5dd9-4191-4eee-8a32-d8bbc74e36c4")));

            dataContextBeforeSerialization.Zdarzenia.Add(new Wypozyczenie(dataContextBeforeSerialization.Wykazy[0], dataContextBeforeSerialization.OpisyStanu[0], DateTime.Today, new Guid("d473a55e-54c7-4617-9f47-090708101f2d")));
            dataContextBeforeSerialization.Zdarzenia.Add(new Wypozyczenie(dataContextBeforeSerialization.Wykazy[1], dataContextBeforeSerialization.OpisyStanu[1], DateTime.Today, new Guid("929fc65d-1dce-4b34-8f33-277afff5cb7f")));

            string path = "test.dat";

            MyFormatter myFormatter = new MyFormatter();
            Stream serializationStream = File.Open(path, FileMode.Create, FileAccess.Write);
            myFormatter.Serialize(serializationStream, dataContextBeforeSerialization);
            serializationStream.Close();


            Stream deserializationStream = File.Open(path, FileMode.Open, FileAccess.Read);
            DataContext dataContextAfterSerialization = myFormatter.Deserialize(deserializationStream);
            deserializationStream.Close();

            Assert.AreEqual(dataContextBeforeSerialization.Wykazy[0].FirstName, dataContextAfterSerialization.Wykazy[0].FirstName);
            Assert.AreEqual(dataContextBeforeSerialization.Wykazy[0].LastName, dataContextAfterSerialization.Wykazy[0].LastName);
            Assert.AreEqual(dataContextBeforeSerialization.Wykazy[0].IdWykazu, dataContextAfterSerialization.Wykazy[0].IdWykazu);
        }

        [TestMethod]
        public void MyFormatterTest_TheSameKatalog()
        {
            DataContext dataContextBeforeSerialization = new DataContext();

            Wykaz.Adres ad1 = new Wykaz.Adres("Łódź", "92-525", "Sacharowa", "7");
            Wykaz.Adres ad2 = new Wykaz.Adres("Zelów", "99-525", "Piotrkowska", "77");

            dataContextBeforeSerialization.Wykazy.Add(new Wykaz("Mateusz", "Wasilewski", new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), ad1));
            dataContextBeforeSerialization.Wykazy.Add(new Wykaz("Jędrzej", "Dobrucki", new Guid("a8292587-864d-4d35-be17-2081028ef439"), ad2));

            dataContextBeforeSerialization.Katalogi.Add(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), new Katalog("Quo Vaids", "Henryk", "Sienkiewcz", new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")));
            dataContextBeforeSerialization.Katalogi.Add(new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5"), new Katalog("Latarnik", "Henryk", "Sienkiewcz", new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5")));

            dataContextBeforeSerialization.OpisyStanu.Add(new OpisStanu(dataContextBeforeSerialization.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")], 1999, new Guid("434518ba-a2de-42df-ae6b-300eaf416053")));
            dataContextBeforeSerialization.OpisyStanu.Add(new OpisStanu(dataContextBeforeSerialization.Katalogi[new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5")], 2010, new Guid("919a5dd9-4191-4eee-8a32-d8bbc74e36c4")));

            dataContextBeforeSerialization.Zdarzenia.Add(new Wypozyczenie(dataContextBeforeSerialization.Wykazy[0], dataContextBeforeSerialization.OpisyStanu[0], DateTime.Today, new Guid("d473a55e-54c7-4617-9f47-090708101f2d")));
            dataContextBeforeSerialization.Zdarzenia.Add(new Wypozyczenie(dataContextBeforeSerialization.Wykazy[1], dataContextBeforeSerialization.OpisyStanu[1], DateTime.Today, new Guid("929fc65d-1dce-4b34-8f33-277afff5cb7f")));

            string path = "test.dat";

            MyFormatter myFormatter = new MyFormatter();
            Stream serializationStream = File.Open(path, FileMode.Create, FileAccess.Write);
            myFormatter.Serialize(serializationStream, dataContextBeforeSerialization);
            serializationStream.Close();


            Stream deserializationStream = File.Open(path, FileMode.Open, FileAccess.Read);
            DataContext dataContextAfterSerialization = myFormatter.Deserialize(deserializationStream);
            deserializationStream.Close();

            Assert.AreEqual(dataContextBeforeSerialization.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")].ImieAutora, dataContextAfterSerialization.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")].ImieAutora);
            Assert.AreEqual(dataContextBeforeSerialization.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")].NazwiskoAutora, dataContextAfterSerialization.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")].NazwiskoAutora);
            Assert.AreEqual(dataContextBeforeSerialization.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")].Tytul, dataContextAfterSerialization.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")].Tytul);
        }
        [TestMethod]
        public void MyFormatterTest_TheSameOpisStanu()
        {
            DataContext dataContextBeforeSerialization = new DataContext();

            Wykaz.Adres ad1 = new Wykaz.Adres("Łódź", "92-525", "Sacharowa", "7");
            Wykaz.Adres ad2 = new Wykaz.Adres("Zelów", "99-525", "Piotrkowska", "77");

            dataContextBeforeSerialization.Wykazy.Add(new Wykaz("Mateusz", "Wasilewski", new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), ad1));
            dataContextBeforeSerialization.Wykazy.Add(new Wykaz("Jędrzej", "Dobrucki", new Guid("a8292587-864d-4d35-be17-2081028ef439"), ad2));

            dataContextBeforeSerialization.Katalogi.Add(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), new Katalog("Quo Vaids", "Henryk", "Sienkiewcz", new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")));
            dataContextBeforeSerialization.Katalogi.Add(new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5"), new Katalog("Latarnik", "Henryk", "Sienkiewcz", new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5")));

            dataContextBeforeSerialization.OpisyStanu.Add(new OpisStanu(dataContextBeforeSerialization.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")], 1999, new Guid("434518ba-a2de-42df-ae6b-300eaf416053")));
            dataContextBeforeSerialization.OpisyStanu.Add(new OpisStanu(dataContextBeforeSerialization.Katalogi[new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5")], 2010, new Guid("919a5dd9-4191-4eee-8a32-d8bbc74e36c4")));

            dataContextBeforeSerialization.Zdarzenia.Add(new Wypozyczenie(dataContextBeforeSerialization.Wykazy[0], dataContextBeforeSerialization.OpisyStanu[0], DateTime.Today, new Guid("d473a55e-54c7-4617-9f47-090708101f2d")));
            dataContextBeforeSerialization.Zdarzenia.Add(new Wypozyczenie(dataContextBeforeSerialization.Wykazy[1], dataContextBeforeSerialization.OpisyStanu[1], DateTime.Today, new Guid("929fc65d-1dce-4b34-8f33-277afff5cb7f")));

            string path = "test.dat";

            MyFormatter myFormatter = new MyFormatter();
            Stream serializationStream = File.Open(path, FileMode.Create, FileAccess.Write);
            myFormatter.Serialize(serializationStream, dataContextBeforeSerialization);
            serializationStream.Close();


            Stream deserializationStream = File.Open(path, FileMode.Open, FileAccess.Read);
            DataContext dataContextAfterSerialization = myFormatter.Deserialize(deserializationStream);
            deserializationStream.Close();

            Assert.AreEqual(dataContextBeforeSerialization.OpisyStanu[0].IdOpisuStanu, dataContextAfterSerialization.OpisyStanu[0].IdOpisuStanu);
            Assert.AreEqual(dataContextBeforeSerialization.OpisyStanu[0].Katalog.IdKatalogu, dataContextAfterSerialization.OpisyStanu[0].Katalog.IdKatalogu);
           
        }
        [TestMethod]
        public void MyFormatterTest_TheSameZdarzenie()
        {
            DataContext dataContextBeforeSerialization = new DataContext();

            Wykaz.Adres ad1 = new Wykaz.Adres("Łódź", "92-525", "Sacharowa", "7");
            Wykaz.Adres ad2 = new Wykaz.Adres("Zelów", "99-525", "Piotrkowska", "77");

            dataContextBeforeSerialization.Wykazy.Add(new Wykaz("Mateusz", "Wasilewski", new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), ad1));
            dataContextBeforeSerialization.Wykazy.Add(new Wykaz("Jędrzej", "Dobrucki", new Guid("a8292587-864d-4d35-be17-2081028ef439"), ad2));

            dataContextBeforeSerialization.Katalogi.Add(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), new Katalog("Quo Vaids", "Henryk", "Sienkiewcz", new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")));
            dataContextBeforeSerialization.Katalogi.Add(new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5"), new Katalog("Latarnik", "Henryk", "Sienkiewcz", new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5")));

            dataContextBeforeSerialization.OpisyStanu.Add(new OpisStanu(dataContextBeforeSerialization.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")], 1999, new Guid("434518ba-a2de-42df-ae6b-300eaf416053")));
            dataContextBeforeSerialization.OpisyStanu.Add(new OpisStanu(dataContextBeforeSerialization.Katalogi[new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5")], 2010, new Guid("919a5dd9-4191-4eee-8a32-d8bbc74e36c4")));

            dataContextBeforeSerialization.Zdarzenia.Add(new Wypozyczenie(dataContextBeforeSerialization.Wykazy[0], dataContextBeforeSerialization.OpisyStanu[0], DateTime.Today, new Guid("d473a55e-54c7-4617-9f47-090708101f2d")));
            dataContextBeforeSerialization.Zdarzenia.Add(new Wypozyczenie(dataContextBeforeSerialization.Wykazy[1], dataContextBeforeSerialization.OpisyStanu[1], DateTime.Today, new Guid("929fc65d-1dce-4b34-8f33-277afff5cb7f")));

            string path = "test.dat";

            MyFormatter myFormatter = new MyFormatter();
            Stream serializationStream = File.Open(path, FileMode.Create, FileAccess.Write);
            myFormatter.Serialize(serializationStream, dataContextBeforeSerialization);
            serializationStream.Close();


            Stream deserializationStream = File.Open(path, FileMode.Open, FileAccess.Read);
            DataContext dataContextAfterSerialization = myFormatter.Deserialize(deserializationStream);
            deserializationStream.Close();

            Assert.AreEqual(dataContextBeforeSerialization.Zdarzenia[0].Guid, dataContextAfterSerialization.Zdarzenia[0].Guid);
            Assert.AreEqual(dataContextBeforeSerialization.Zdarzenia[0].Wykaz.IdWykazu, dataContextAfterSerialization.Zdarzenia[0].Wykaz.IdWykazu);
            Assert.AreEqual(dataContextBeforeSerialization.Zdarzenia[0].OpisStanu.IdOpisuStanu, dataContextAfterSerialization.Zdarzenia[0].OpisStanu.IdOpisuStanu);

        }

        [TestMethod]
        public void MyFormatterTest_OneToMany()
        {
            DataContext dataContextBeforeSerialization = new DataContext();

           

            dataContextBeforeSerialization.Katalogi.Add(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), new Katalog("Quo Vaids", "Henryk", "Sienkiewcz", new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")));
            dataContextBeforeSerialization.Katalogi.Add(new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5"), new Katalog("Latarnik", "Henryk", "Sienkiewcz", new Guid("1df6b044-901b-452c-909e-4acdd52c1ba5")));

            dataContextBeforeSerialization.OpisyStanu.Add(new OpisStanu(dataContextBeforeSerialization.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")], 1999, new Guid("434518ba-a2de-42df-ae6b-300eaf416053")));
            dataContextBeforeSerialization.OpisyStanu.Add(new OpisStanu(dataContextBeforeSerialization.Katalogi[new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")], 2010, new Guid("919a5dd9-4191-4eee-8a32-d8bbc74e36c4")));


            string path = "test.dat";

            MyFormatter myFormatter = new MyFormatter();
            Stream serializationStream = File.Open(path, FileMode.Create, FileAccess.Write);
            myFormatter.Serialize(serializationStream, dataContextBeforeSerialization);
            serializationStream.Close();


            Stream deserializationStream = File.Open(path, FileMode.Open, FileAccess.Read);
            DataContext dataContextAfterSerialization = myFormatter.Deserialize(deserializationStream);
            deserializationStream.Close();

            Assert.AreEqual(dataContextBeforeSerialization.OpisyStanu[0].Katalog, dataContextBeforeSerialization.OpisyStanu[1].Katalog);
            Assert.AreEqual(dataContextAfterSerialization.OpisyStanu[0].Katalog, dataContextAfterSerialization.OpisyStanu[1].Katalog);
        }
    }
}
