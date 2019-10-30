using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class DataServiceTest
    {
        static DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
        
        static Wykaz wykaz = dataRepository.GetWykaz(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"));
        static Wykaz.Adres adres = wykaz.AdresWykazu;
        static Katalog katalog = dataRepository.GetKatalog(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"));
        static OpisStanu opisStanu = dataRepository.GetOpisStanu(new Guid("434518ba-a2de-42df-ae6b-300eaf416053"));


        [TestMethod]
        public void WypozyczTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            DataService dataService = new DataService(dataRepository);
            dataService.Wypozycz(wykaz, opisStanu);
            Assert.AreEqual(opisStanu, dataRepository.GetAllZdarzenie().Last().OpisStanu);
            Assert.AreEqual(wykaz, dataRepository.GetAllZdarzenie().Last().Wykaz);
        }

        [TestMethod]
        public void WypozyczTest1()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            DataService dataService = new DataService(dataRepository);
            dataService.Wypozycz(wykaz, opisStanu);
            Assert.ThrowsException<Exception>(() => dataService.Wypozycz(wykaz, opisStanu));
        }

        [TestMethod]
        public void OddanieTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            DataService dataService = new DataService(dataRepository);
            dataService.Wypozycz(wykaz, opisStanu);
            dataService.Oddaj(wykaz, opisStanu);
            Assert.IsFalse(dataService.CzyWypozyczony(opisStanu));
        }

        [TestMethod]
        public void OddanieTest1()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            DataService dataService = new DataService(dataRepository);
            Assert.ThrowsException<Exception>(() => dataService.Oddaj(wykaz, opisStanu));
            dataService.Wypozycz(wykaz, opisStanu);
            dataService.Oddaj(wykaz, opisStanu);
            Assert.ThrowsException<Exception>(() => dataService.Oddaj(wykaz, opisStanu));
        }

        [TestMethod]
        public void CzyWypozyczonyTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            DataService dataService = new DataService(dataRepository);
            dataService.Wypozycz(wykaz, opisStanu);
            Assert.IsTrue(dataService.CzyWypozyczony(opisStanu));
        }

        [TestMethod]
        public void LiczbaDostpenychOpisowStanuTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            DataService dataService = new DataService(dataRepository);
            Assert.AreEqual(0, dataService.LiczbaDostepnychOpisowStanu(katalog));
            OpisStanu opisStanu = new OpisStanu(katalog, 2000, new Guid());
            dataService.DodajOpisStanu(opisStanu);
            Assert.AreEqual(1, dataService.LiczbaDostepnychOpisowStanu(katalog));
        }

        [TestMethod]
        public void DostepneOpisyStanuDlaKataloguTest()
        {
            DataRepository dataRepository = new DataRepository(new WypelnianieStalymi());
            DataService dataService = new DataService(dataRepository);
            Katalog katalog = new Katalog("xd", "xd", "xd", new Guid());
            OpisStanu opisStanu = new OpisStanu(katalog, 1111, new Guid());
            dataService.DodajKatalog(katalog);
            dataService.DodajOpisStanu(opisStanu);

            Assert.AreEqual(katalog, dataService.DostepneOpisyStanuDlaKatalogu(katalog).Last().Katalog);
        }
    }
}
