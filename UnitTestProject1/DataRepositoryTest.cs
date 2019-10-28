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
        private class TestFiller: IDataFiller
        {
            public void Fill(DataContext ctx)
            {
                ctx.Wykazy.Add(new Wykaz("Mateusz", "Wasilewski", new Guid("0f8fad5b-d9cb-469f-a165-70867728950e")));
                ctx.Katalogi.Add(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), new Katalog("Quo Vaids", "Henryk", "Sienkiewcz", new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")));
            }
        }

        [TestMethod]
        public void GetAllKatalog_ReturnsAllKatalog()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            IEnumerable<Katalog> katalogi = dataRepository.GetAllKatalog();
            Assert.AreEqual(1, katalogi.Count());

        }

        [TestMethod]
        public void GetKatalog_ValidKatalog_ReturnsKatalog()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
       
            Assert.AreEqual(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), dataRepository.GetKatalog(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")).IdKatalogu);

        }

        [TestMethod]
        public void GetKatalog_ValidKatalog_Throws()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            Assert.ThrowsException<Exception>(() => dataRepository.GetKatalog(Guid.NewGuid()));


        }

        [TestMethod]
        public void AddKatalog_ValidKatalog_AddsKatalog()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            Guid testGuid = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            dataRepository.AddKatalog(testKatalog);
            Assert.AreEqual(testKatalog, dataRepository.GetKatalog(testGuid));
            
        }

        [TestMethod]
        public void AddKatalog_ValidKatalog_Throws()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            Guid testGuid = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            dataRepository.AddKatalog(testKatalog);
            Assert.ThrowsException<Exception>(() => dataRepository.AddKatalog(testKatalog));

        }
        [TestMethod]
        public void UpdateKatalog_ExistingKey_Updates()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            Guid testGuid = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            dataRepository.UpdateKatalog(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), testKatalog);
            Assert.AreEqual(dataRepository.GetKatalog(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")), testKatalog);
            Assert.AreEqual(dataRepository.GetKatalog(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d")).IdKatalogu, new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"));


        }
        [TestMethod]
        public void UpdateKatalog_NotExistingKey_Throws()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            Guid testGuid = Guid.NewGuid();
            Katalog testKatalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            dataRepository.UpdateKatalog(new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"), testKatalog);
            Assert.ThrowsException<Exception>(() => dataRepository.UpdateKatalog(new Guid("b9b713a2-92ac-4696-96d9-ce1257b8835d"), testKatalog));
        }



        [TestMethod]
        public void GetAllKWykaz_ReturnsAllWykaz()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            IEnumerable<Katalog> wykazy = dataRepository.GetAllKatalog();
            Assert.AreEqual(1, wykazy.Count());

        }

        [TestMethod]
        public void GetWykaz_ValidWykaz_ReturnsWykaz()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            Assert.AreEqual(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), dataRepository.GetWykaz(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e")).IdWykazu);
        }

        [TestMethod]
        public void GetKWykaz_ValidWykaz_Throws()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            Assert.ThrowsException<Exception>(() => dataRepository.GetWykaz(Guid.NewGuid()));

        }

        [TestMethod]
        public void AddWykaz_ValidWykaz_AddsWykaz()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            Guid testGuid = Guid.NewGuid();
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid);
            dataRepository.AddWykaz(testWykaz);
            Assert.AreEqual(testWykaz, dataRepository.GetWykaz(testGuid));

        }

        [TestMethod]
        public void AddWykaz_ValidWykaz_Throws()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            Guid testGuid = Guid.NewGuid();
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid);
            dataRepository.AddWykaz(testWykaz);
            Assert.ThrowsException<Exception>(() => dataRepository.AddWykaz(testWykaz));

        }

        [TestMethod]
        public void UpdateWykaz_ExistingKey_Updates()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            Guid testGuid = Guid.NewGuid();
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid);
            dataRepository.UpdateWykaz(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), testWykaz);
            Assert.AreEqual(dataRepository.GetWykaz(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e")), testWykaz);
            Assert.AreEqual(dataRepository.GetWykaz(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e")).IdWykazu, new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"));

        }

        [TestMethod]
        public void UpdateWykaz_NotExistingKey_Throws()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            Guid testGuid = Guid.NewGuid();
            Wykaz testWykaz = new Wykaz("Anna", "Kowalska", testGuid);
            dataRepository.UpdateWykaz(new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), testWykaz);
            Assert.ThrowsException<Exception>(() => dataRepository.UpdateWykaz(new Guid("b9b713a2-92ac-4696-96d9-ce1257b8835d"), testWykaz));
        }


    }
}
