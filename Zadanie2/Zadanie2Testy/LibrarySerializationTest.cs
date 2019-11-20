using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ClassLibrary1;
using System.IO;

namespace Zadanie2Testy
{
    /// <summary>
    /// Summary description for LibrarySerializationTest
    /// </summary>
    [TestClass]
    public class LibrarySerializationTest
    {
        


        public LibrarySerializationTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ManyToOneTest()
        {
            Katalog katalog = new Katalog("Quo Vaids", "Henryk", "Sienkiewcz", new Guid("b9b713a2-93ac-4696-96d9-ce1257b8835d"));
            OpisStanu opis1, opis2;
            opis1 = new OpisStanu(katalog, 2019, Guid.NewGuid());
            opis2 = new OpisStanu(katalog, 2018, Guid.NewGuid());
            List<OpisStanu> opisyStanu = new List<OpisStanu>
            {
                opis1,
                opis2
            };

            string json = JsonConvert.SerializeObject(opisyStanu, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            File.WriteAllText("data.json", json);

            string readJson = File.ReadAllText("data.json");
            List<OpisStanu> deserialized = JsonConvert.DeserializeObject<List<OpisStanu>>(readJson, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            Assert.AreEqual(opis1, deserialized[0]);
            Assert.AreEqual(opis2, deserialized[1]);
        }

    }
}
