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

            }
        }


        [TestMethod]
        public void AddKatalog_ValidKatalog_AddsKatalog()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            Guid testGuid = Guid.NewGuid();
            Katalog katalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            dataRepository.AddKatalog(katalog);
            Assert.AreEqual(katalog.IdKatalogu, dataRepository.GetKatalog(testGuid).IdKatalogu);
        }

        [TestMethod]
        public void AddKatalog_ValidKatalog_Throws()
        {
            DataRepository dataRepository = new DataRepository(new TestFiller());
            Guid testGuid = Guid.NewGuid();
            Katalog katalog = new Katalog("Foo", "Jon", "Doe", testGuid);
            dataRepository.AddKatalog(katalog);
            Assert.ThrowsException<Exception>(() => dataRepository.AddKatalog(katalog));

        }


    }
}
