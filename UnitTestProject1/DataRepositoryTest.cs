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


        private DataRepository _repository;

        public DataRepositoryTest()
        {
            _repository = new DataRepository(new TestFiller());
        }


        [TestMethod]
        public void AddKatalogTest()
        {
            string title, firstName, lastName;
            title = "Foo";
            firstName = "Jon";
            lastName = "Doe";

            Katalog katalog = new Katalog(title, firstName, lastName);
            _repository.AddKatalog(katalog);

            Assert.AreEqual(katalog, _repository.GetKatalog(0));
        }
    }
}
