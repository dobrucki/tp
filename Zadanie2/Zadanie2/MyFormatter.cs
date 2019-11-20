using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using ClassLibrary1;
using System.Reflection;

namespace Zadanie2
{
    public class MyFormatter
    {

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

        public DataContext Deserialize(Stream serializationStream)
        {
            StreamReader reader = new StreamReader(serializationStream, Encoding.GetEncoding(1250));

            DataContext deserializedDataContext = new DataContext();
            string line;
            Assembly asm = typeof(Wykaz).Assembly;

            Dictionary<string, Wykaz.Adres> idAdresPair = new Dictionary<string, Wykaz.Adres>();
            Dictionary<string, Wykaz> idWykazPair = new Dictionary<string, Wykaz>();
            Dictionary<string, Katalog> idKatalogPair = new Dictionary<string, Katalog>();
            Dictionary<string, OpisStanu> idOpisStanuPair = new Dictionary<string, OpisStanu>();

            while ((line = reader.ReadLine()) != null)
            {
                List<string> splitedLine = line.Split(',').ToList();
                    
                    if (splitedLine[0] == "ClassLibrary1.Wykaz+Adres")
                    {
                        Wykaz.Adres adres = new Wykaz.Adres();
                        adres.Deserialize(splitedLine);
                        idAdresPair.Add(splitedLine[5], adres);

                    }
                    else if (splitedLine[0] == "ClassLibrary1.Wykaz")
                    {
                        Wykaz wykaz = new Wykaz();
                        wykaz.Deserialize(splitedLine);
                        deserializedDataContext.Wykazy.Add(wykaz);
                        idWykazPair.Add(splitedLine[4], wykaz);
                        wykaz.AdresWykazu = idAdresPair[splitedLine[5]];

                    }
                    else if (splitedLine[0] == "ClassLibrary1.Katalog")
                    {
                        Katalog katalog = new Katalog();
                        katalog.Deserialize(splitedLine);
                        deserializedDataContext.Katalogi.Add(katalog.IdKatalogu, katalog);
                        idKatalogPair.Add(splitedLine[5], katalog);
                    }
                    else if (splitedLine[0] == "ClassLibrary1.OpisStanu")
                    {
                        OpisStanu opisStanu = new OpisStanu();
                        opisStanu.Deserialize(splitedLine);
                        deserializedDataContext.OpisyStanu.Add(opisStanu);
                        idOpisStanuPair.Add(splitedLine[4], opisStanu);
                        opisStanu.Katalog = idKatalogPair[splitedLine[1]];
                    }
                    else if (splitedLine[0] == "ClassLibrary1.Wypozyczenie")
                    {
                        Zdarzenie zdarzenie = new Wypozyczenie();
                        zdarzenie.Deserialize(splitedLine);
                        deserializedDataContext.Zdarzenia.Add(zdarzenie);
                        zdarzenie.Wykaz = idWykazPair[splitedLine[1]];
                        zdarzenie.OpisStanu = idOpisStanuPair[splitedLine[2]];
                    }
                    else
                    {
                        Zdarzenie zdarzenie = new Oddanie();
                        zdarzenie.Deserialize(splitedLine);
                        deserializedDataContext.Zdarzenia.Add(zdarzenie);
                        zdarzenie.Wykaz = idWykazPair[splitedLine[1]];
                        zdarzenie.OpisStanu = idOpisStanuPair[splitedLine[2]];
                    }
                
                
            }

            return deserializedDataContext;
        }
    }
}
