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
        public void GetAllKWykaz_ReturnsAllWykaz()
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
        public void GetKWykaz_ValidWykaz_Throws()
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
        public void UpdateWykaz_ExistingKey_Updates()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid, adTest);
            dataRepository.UpdateWykaz(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), testWykaz);
            Assert.AreEqual(dataRepository.GetWykaz(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e")), testWykaz);
            Assert.AreEqual(dataRepository.GetWykaz(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e")).IdWykazu, new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"));

        }

        [TestMethod]
        public void UpdateWykaz_NotExistingKey_Throws()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            Guid testGuid = Guid.NewGuid();
            Wykaz.Adres adTest = new Wykaz.Adres("Łódź", "92-445", "Gorkiego", "47");
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid, adTest);
            dataRepository.UpdateWykaz(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), testWykaz);
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

    }
}
