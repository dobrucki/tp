using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class DataRepositoryTest
    {

        #region KatalogTests
        [TestMethod]
        public void GetAllKatalog_ReturnsAllKatalog()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            IEnumerable<Katalog> katalogi = dataRepository.GetAllKatalog();
            Assert.AreEqual(5, katalogi.Count());

        }

        [TestMethod]
        public void GetKatalog_ValidKatalog_ReturnsKatalog()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
       
            Assert.AreEqual(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), dataRepository.GetKatalog(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")).IdKatalogu);

        }

        [TestMethod]
        public void GetKatalog_ValidKatalog_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Assert.ThrowsException<Exception>(() => dataRepository.GetKatalog(Guid.NewGuid()));


        }

        [TestMethod]
        public void AddKatalog_ValidKatalog_AddsKatalog()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            dataRepository.AddKatalog(testKatalog);
            Assert.AreEqual(testKatalog, dataRepository.GetKatalog(testGuid));
            
        }

        [TestMethod]
        public void AddKatalog_ValidKatalog_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            dataRepository.AddKatalog(testKatalog);
            Assert.ThrowsException<Exception>(() => dataRepository.AddKatalog(testKatalog));

        }

        [TestMethod]
        public void UpdateKatalog_ExistingKey_Updates()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            dataRepository.UpdateKatalog(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), testKatalog);
            Assert.AreEqual(dataRepository.GetKatalog(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")), testKatalog);
            Assert.AreEqual(dataRepository.GetKatalog(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")).IdKatalogu, new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"));

        }
        [TestMethod]
        public void UpdateKatalog_NotExistingKey_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            dataRepository.UpdateKatalog(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), testKatalog);
            Assert.ThrowsException<Exception>(() => dataRepository.UpdateKatalog(new Guid("b9b713a2-92ac-4696-96d9-ce1257b8835d"), testKatalog));
        }
        [TestMethod]
        public void DeleteKatalog_NoExisintgOpisStanu_Deletes()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            dataRepository.AddKatalog(testKatalog);
            dataRepository.DeleteKatalog(testKatalog);
            Assert.AreEqual(5, dataRepository.GetAllKatalog().Count());
        }
        [TestMethod]
        public void DeleteKatalog_NonExisintgKatalog_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            Assert.ThrowsException<Exception>(() => dataRepository.DeleteKatalog(testKatalog));
        }
        [TestMethod]
        public void DeleteKatalog_ExisintgOpisStanu_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            dataRepository.AddKatalog(testKatalog);
            dataRepository.AddOpisStanu(new OpisStanu(testKatalog, 1999, Guid.NewGuid()));
            Assert.ThrowsException<Exception>(() => dataRepository.DeleteKatalog(testKatalog));
        }
        #endregion

        #region WykazTests
        [TestMethod]
        public void GetAllWykaz_ReturnsAllWykaz()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(5, dataRepository.GetAllWykaz().Count());
        }

        [TestMethod]
        public void GetWykaz_ValidWykaz_ReturnsWykaz()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), dataRepository.GetWykaz(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e")).IdWykazu);
        }

        [TestMethod]
        public void GetWykaz_ValidWykaz_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Assert.ThrowsException<Exception>(() => dataRepository.GetWykaz(Guid.NewGuid()));

        }

        [TestMethod]
        public void AddWykaz_ValidWykaz_AddsWykaz()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid, adTest);
            dataRepository.AddWykaz(testWykaz);
            Assert.AreEqual(testWykaz, dataRepository.GetWykaz(testGuid));

        }

        [TestMethod]
        public void AddWykaz_ValidWykaz_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalsk    a", testGuid, adTest);
            dataRepository.AddWykaz(testWykaz);
            Assert.ThrowsException<Exception>(() => dataRepository.AddWykaz(testWykaz));
        }


        

        [TestMethod]
        public void UpdateWykaz_NotExistingKey_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid, adTest);
            Assert.ThrowsException<Exception>(() => dataRepository.UpdateWykaz(new Guid("b9b713a2-92ac-4696-96d9-ce1257b8835d"), testWykaz));
        }


        [TestMethod]
        public void DeleteWykaz_NotExistingZdarzenie_Deletes()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid, adTest);
            dataRepository.AddWykaz(testWykaz);
            dataRepository.DeleteWykaz(testWykaz);
            Assert.AreEqual(5, dataRepository.GetAllKatalog().Count());
        }

        [TestMethod]
        public void DeleteWykaz_NonExisintgWykaz_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid, adTest);
            Assert.ThrowsException<Exception>(() => dataRepository.DeleteWykaz(testWykaz));
        }
        [TestMethod]
        public void DeleteWykaz_ExisintgZdarzenie_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            
            Guid testGuid1 = Guid.NewGuid();
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid1, adTest);

            OpisStanu testOpis = new OpisStanu(testKatalog, 1999, Guid.NewGuid());
            
            dataRepository.AddWykaz(testWykaz);
            dataRepository.AddKatalog(testKatalog);
            dataRepository.AddOpisStanu(testOpis);
            dataRepository.AddZdarzenie(new Wypozyczenie(testWykaz, testOpis,DateTime.Now, Guid.NewGuid()));
            Assert.ThrowsException<Exception>(() => dataRepository.DeleteWykaz(testWykaz));
        }

        #endregion

        #region OpisStanuTests

        [TestMethod]
        public void GetAllOpisStanu_ReturnsAllOpisStanu()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(5, dataRepository.GetAllOpisStanu().Count());
        }

        [TestMethod]
        public void GetOpisStanu_ValidOpisStanu_ReturnsOpisStanu()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(new Guid("434518ba-a2de-42df-ae6b-300eaf416053"), dataRepository.GetOpisStanu(new Guid("434518ba-a2de-42df-ae6b-300eaf416053")).IdOpisuStanu);
        }

       
        [TestMethod]
        public void GetOpisStanu_ValidOpisStanu_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Assert.ThrowsException<Exception>(() => dataRepository.GetOpisStanu(Guid.NewGuid()));

        }

        [TestMethod]
        public void AddOpisStanu_ValidOpisStanu_AddsOpisStanu()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Guid testGuid1 = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            OpisStanu testOpisStanu = new OpisStanu(testKatalog, 2019, testGuid1);
            dataRepository.AddOpisStanu(testOpisStanu);
            Assert.AreEqual(testOpisStanu, dataRepository.GetOpisStanu(testGuid1));

        }

        [TestMethod]
        public void AddOpisStanu_ValidOpisStanu_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Guid testGuid1 = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            OpisStanu testOpisStanu = new OpisStanu(testKatalog, 2019, testGuid1);
            dataRepository.AddOpisStanu(testOpisStanu);

            Assert.ThrowsException<Exception>(() => dataRepository.AddOpisStanu(testOpisStanu));
        }


        [TestMethod]
        public void UpdateOpisStanu_ExistingKey_Updates()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());

            Guid testGuid = Guid.NewGuid();
            Guid testGuid1 = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            OpisStanu testOpisStanu = new OpisStanu(testKatalog, 2019, testGuid1);

            dataRepository.UpdateOpisStanu(new Guid("919a5dd9-4191-4eee-8a32-d8bbc74e36c4"), testOpisStanu);
            
            Assert.AreEqual(dataRepository.GetOpisStanu(new Guid("919a5dd9-4191-4eee-8a32-d8bbc74e36c4")), testOpisStanu);
            Assert.AreEqual(dataRepository.GetOpisStanu(new Guid("919a5dd9-4191-4eee-8a32-d8bbc74e36c4")).IdOpisuStanu, new Guid("919a5dd9-4191-4eee-8a32-d8bbc74e36c4"));
        }

        [TestMethod]
        public void UpdateOpisStanu_NotExistingKey_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Guid testGuid1 = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            OpisStanu testOpisStanu = new OpisStanu(testKatalog, 2019, testGuid1);
            Assert.ThrowsException<Exception>(() => dataRepository.UpdateOpisStanu(new Guid("929a5dd9-4191-4eee-8a32-d8bbc74e36c4"), testOpisStanu));
        }


        [TestMethod]
        public void DeleteOpisStanu_NotExistingZdarzenie_Deletes()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Guid testGuid1 = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            OpisStanu testOpisStanu = new OpisStanu(testKatalog, 2019, testGuid1);
            dataRepository.AddOpisStanu(testOpisStanu);
            dataRepository.DeleteOpisStanu(testOpisStanu);
            Assert.AreEqual(5, dataRepository.GetAllOpisStanu().Count());
        }

        [TestMethod]
        public void DeleteOpisStanu_NonExistingOpisStanu_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Guid testGuid1 = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            OpisStanu testOpisStanu = new OpisStanu(testKatalog, 2019, testGuid1);
            Assert.ThrowsException<Exception>(() => dataRepository.DeleteOpisStanu(testOpisStanu));
        }

        [TestMethod]
        public void DeleteOpisStanu_ExistingZdarzenie_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);

            Guid testGuid1 = Guid.NewGuid();
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid1, adTest);

            OpisStanu testOpis = new OpisStanu(testKatalog, 1999, Guid.NewGuid());

            dataRepository.AddWykaz(testWykaz);
            dataRepository.AddKatalog(testKatalog);
            dataRepository.AddOpisStanu(testOpis);
            dataRepository.AddZdarzenie(new Wypozyczenie(testWykaz, testOpis, DateTime.Now, Guid.NewGuid()));
            Assert.ThrowsException<Exception>(() => dataRepository.DeleteOpisStanu(testOpis));
        }
        #endregion

        #region ZdarzenieTest

        [TestMethod]
        public void GetAllZdarzenie_ReturnsAllZdarzenie()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(5, dataRepository.GetAllZdarzenie().Count());
        }

        [TestMethod]
        public void GetZdarzenie_ValidZdarzenie_ReturnsZdarzenie()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Assert.AreEqual(new Guid("d174090f-c973-4674-aa06-125190c337b5"), dataRepository.GetZdarzenie(new Guid("d174090f-c973-4674-aa06-125190c337b5")).Guid);
        }


        [TestMethod]
        public void GetZdarzenie_ValidZdarzenie_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Assert.ThrowsException<Exception>(() => dataRepository.GetZdarzenie(Guid.NewGuid()));

        }

        [TestMethod]
        public void AddZdarzenie_ValidZdarzenie_AddsZdarzenie()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Guid testGuid1 = Guid.NewGuid();
            Guid testGuid2 = Guid.NewGuid();
            Guid testGuid3 = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            OpisStanu testOpisStanu = new OpisStanu(testKatalog, 2019, testGuid1);
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid2, adTest);

            Zdarzenie zd = new Wypozyczenie(testWykaz, testOpisStanu, DateTime.Today, testGuid3);
            dataRepository.AddZdarzenie(zd);
            Assert.AreEqual(zd, dataRepository.GetZdarzenie(testGuid3));

        }

        [TestMethod]
        public void AddZdarzenie_ValidZdarzenie_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Guid testGuid1 = Guid.NewGuid();
            Guid testGuid2 = Guid.NewGuid();
            Guid testGuid3 = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            OpisStanu testOpisStanu = new OpisStanu(testKatalog, 2019, testGuid1);
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid2, adTest);

            Zdarzenie zd = new Wypozyczenie(testWykaz, testOpisStanu, DateTime.Today, testGuid3);
            dataRepository.AddZdarzenie(zd);

            Assert.ThrowsException<Exception>(() => dataRepository.AddZdarzenie(zd));
        }



        [TestMethod]
        public void UpdateZdarzenie_ExistingKey_Updates()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Guid testGuid1 = Guid.NewGuid();
            Guid testGuid2 = Guid.NewGuid();
            Guid testGuid3 = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            OpisStanu testOpisStanu = new OpisStanu(testKatalog, 2019, testGuid1);
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid2, adTest);

            Zdarzenie zd = new Wypozyczenie(testWykaz, testOpisStanu, DateTime.Today, testGuid3);

            dataRepository.UpdateZdarzenie(new Guid("d473a55e-54c7-4617-9f47-090708101f2d"), zd);

            Assert.AreEqual(dataRepository.GetZdarzenie(new Guid("d473a55e-54c7-4617-9f47-090708101f2d")), zd);
            Assert.AreEqual(dataRepository.GetZdarzenie(new Guid("d473a55e-54c7-4617-9f47-090708101f2d")).Guid, new Guid("d473a55e-54c7-4617-9f47-090708101f2d"));
        }

        [TestMethod]
        public void UpdateZdarzenie_NotExistingKey_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Guid testGuid1 = Guid.NewGuid();
            Guid testGuid2 = Guid.NewGuid();
            Guid testGuid3 = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            OpisStanu testOpisStanu = new OpisStanu(testKatalog, 2019, testGuid1);
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid2, adTest);

            Zdarzenie zd = new Wypozyczenie(testWykaz, testOpisStanu, DateTime.Today, testGuid3);
            Assert.ThrowsException<Exception>(() => dataRepository.UpdateZdarzenie(new Guid("929a5dd9-4191-4eee-8a32-d8bbc74e36c4"), zd));
        }

        [TestMethod]
        public void DeleteZdarzenie_Deletes()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Guid testGuid1 = Guid.NewGuid();
            Guid testGuid2 = Guid.NewGuid();
            Guid testGuid3 = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            OpisStanu testOpisStanu = new OpisStanu(testKatalog, 2019, testGuid1);
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid2, adTest);

            Zdarzenie zd = new Wypozyczenie(testWykaz, testOpisStanu, DateTime.Today, testGuid3);
            dataRepository.AddZdarzenie(zd);
            dataRepository.DeleteZdarzenie(zd);
            Assert.AreEqual(5, dataRepository.GetAllZdarzenie().Count());
        }

        [TestMethod]
        public void DeleteZdarzenie_NonExistingZdarzenie_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Guid testGuid1 = Guid.NewGuid();
            Guid testGuid2 = Guid.NewGuid();
            Guid testGuid3 = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            OpisStanu testOpisStanu = new OpisStanu(testKatalog, 2019, testGuid1);
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid2, adTest);

            Zdarzenie zd = new Wypozyczenie(testWykaz, testOpisStanu, DateTime.Today, testGuid3);

            Assert.ThrowsException<Exception>(() => dataRepository.DeleteZdarzenie(zd));
        }

        #endregion

    }
}
