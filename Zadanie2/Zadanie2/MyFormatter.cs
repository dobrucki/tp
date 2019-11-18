using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using ClassLibrary1;

namespace Zadanie2
{
    class MyFormatter
    {
        public DataContext Deserialize(Stream serializationStream)
        {

            StreamReader reader = new StreamReader(serializationStream, Encoding.GetEncoding(1250));

            DataContext dataContext = new DataContext();


            string line;

            while ((line = reader.ReadLine()) != null)
            {
                List<string> splitedLine = line.Split(',').ToList();

            }

            return dataContext;
        }


        public void Serialize(Stream serializationStream, DataContext dataContext)
        {
            StringBuilder sb = new StringBuilder();
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();

            foreach (Wykaz w in dataContext.Wykazy)
            { 
                sb.Append(w.Serialize(idGenerator));
                sb.AppendLine();
            }
            foreach (Katalog k in dataContext.Katalogi.Values)
            {
                sb.Append(k.Serialize(idGenerator));
                sb.AppendLine();
            }
            foreach (OpisStanu op in dataContext.OpisyStanu)
            {
                sb.Append(op.Serialize(idGenerator));
                sb.AppendLine();
            }
            foreach (Zdarzenie zd in dataContext.Zdarzenia)
            {
                sb.Append(zd.Serialize(idGenerator));
                sb.AppendLine();
            }
            byte[] bytes = Encoding.GetEncoding(1250).GetBytes(sb.ToString());

            serializationStream.Write(bytes, 0, sb.Length);
        }
    }
}
