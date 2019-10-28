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
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid, adTest);
            dataRepository.AddWykaz(testWykaz);
            Assert.ThrowsException<Exception>(() => dataRepository.AddWykaz(testWykaz));

        }



    }
}
