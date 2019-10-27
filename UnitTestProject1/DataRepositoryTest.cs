using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ClassLibrary1;

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
           // IEnumerable<Katalog> katalogi = dataRepository.GetAllKatalog();
            
            //Assert.AreEqual(1, );

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
            throw new NotImplementedException();

        }


    }
}
