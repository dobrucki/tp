using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class OwnFormatter
    {
        public void Serialize(Stream serializationStream, Container container)
        {
            StringBuilder sb = new StringBuilder();
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();

            foreach (A a in container.ListA)
            {

                sb.Append(a.Serialize(idGenerator));
                sb.AppendLine();
            }
            foreach (B b in container.ListB)
            {

                sb.Append(b.Serialize(idGenerator));
                sb.AppendLine();
            }
            foreach (C c in container.ListC)
            {

                sb.Append(c.Serialize(idGenerator));
                sb.AppendLine();
            }

            byte[] bytes = Encoding.GetEncoding(1250).GetBytes(sb.ToString());

            serializationStream.Write(bytes, 0, sb.Length);
        }

        public Container Deserialize(Stream serializationStream)
        {
            StreamReader reader = new StreamReader(serializationStream, Encoding.GetEncoding(1250));

            Container deserializedContainer = new Container();
            string line;

            Dictionary<string, A> idAPair = new Dictionary<string, A>();
            Dictionary<string, B> idBPair = new Dictionary<string, B>();
            Dictionary<string, C> idCPair = new Dictionary<string, C>();
            List<string> cIdFromA = new List<string>();

            while ((line = reader.ReadLine()) != null)
            {
                List<string> splitedLine = line.Split(',').ToList();

                if (splitedLine[0] == "ClassLibrary1.A")
                {
                    A a = new A();
                    a.Deserialize(splitedLine);
                    deserializedContainer.ListA.Add(a);
                    idAPair.Add(splitedLine[3], a);
                    cIdFromA.Add(splitedLine[1]);

                }
                else if (splitedLine[0] == "ClassLibrary1.B")
                {
                    B b= new B();
                    b.Deserialize(splitedLine);
                    deserializedContainer.ListB.Add(b);
                    idBPair.Add(splitedLine[3], b);
                    b.GetA = idAPair[splitedLine[1]];

                }
                else 
                {
                    C c = new C();
                    c.Deserialize(splitedLine);
                    deserializedContainer.ListC.Add(c);
                    idCPair.Add(splitedLine[3], c);
                    c.GetB = idBPair[splitedLine[1]];
                }

            }

            for(int i=0; i< deserializedContainer.ListA.Count; i++)
            {
                deserializedContainer.ListA[i].GetC = idCPair[cIdFromA[i]];
   
            }



            return deserializedContainer;
        }
    }
}
