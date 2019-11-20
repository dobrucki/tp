using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ClassLibrary1
{
    public abstract class Zdarzenie
    {
        public Guid Guid { get; set; }
        public Wykaz Wykaz { get; set; }
        public OpisStanu OpisStanu { get; set; }
        public DateTime DataZdarzenia { get; set; }

        public Zdarzenie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataZdarzenia, Guid guid)
        {
            Wykaz = wykaz;
            OpisStanu = opisStanu;
            DataZdarzenia = dataZdarzenia;
            Guid = guid;
        }

        public Zdarzenie()
        {

        }


        public string Serialize(ObjectIDGenerator idGenerator)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetType().FullName.ToString() + ",");
            sb.Append(idGenerator.GetId(Wykaz, out bool firstTime) + ",");
            sb.Append(idGenerator.GetId(OpisStanu, out  firstTime) + ",");
            sb.Append(DataZdarzenia + ",");
            sb.Append(Guid + ",");
            sb.Append(idGenerator.GetId(this, out firstTime));
            return sb.ToString();
        }

        public void Deserialize(List<string> splitString)
        {
            DataZdarzenia = DateTime.Parse(splitString[3]); 
            Guid = new Guid(splitString[4]);
        }
    }
}
