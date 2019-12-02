using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie2;

namespace Zadanie2Testy
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            A deserializaedA;
            C c = new C("Klasa C", 2.786F, DateTime.Now, null);
            A a = new A("Klasa A", 3.444545454F, DateTime.Now, c);
            B b = new B("Klasa B", 0.545454F, DateTime.Now, a);
            c.B = b;

            string filename = "own_serialization.dat";
            OwnFormatter formatter = new OwnFormatter();
            File.Delete(filename);
            Stream stream = File.Open(filename, FileMode.Create, FileAccess.ReadWrite);
            formatter.Serialize(stream, a);
            stream.Close();


            Stream streamDeserialize = File.Open(filename, FileMode.Open, FileAccess.Read);
            deserializaedA = (A)formatter.Deserialize(streamDeserialize);
            streamDeserialize.Close();

            Assert.AreEqual(a.Name, deserializaedA.Name);
            Assert.AreEqual(3.44f, deserializaedA.Number);
            Assert.AreEqual(a.Date.Date, deserializaedA.Date.Date); 

            C cRef = deserializaedA.C;
            Assert.AreEqual(c.Name, cRef.Name);
            Assert.AreEqual(2.79f, cRef.Number);
           Assert.AreEqual(c.Date.Date, cRef.Date.Date);

            B bRef = cRef.B;
            Assert.AreEqual(b.Name, bRef.Name);
            Assert.AreEqual(0.55f, bRef.Number);
            Assert.AreEqual(b.Date.Date, bRef.Date.Date);
            
        }
    }
}
