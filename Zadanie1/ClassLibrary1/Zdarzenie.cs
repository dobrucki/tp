using System;
using System.Runtime.Serialization;
using System.Text;

namespace ClassLibrary1
{
    public abstract class Zdarzenie
    {
        public Guid Guid { get; set; }
        public Wykaz Wykaz { get; }
        public OpisStanu OpisStanu { get; }
        public DateTime DataZdarzenia { get; }

        public Zdarzenie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataZdarzenia, Guid guid)
        {
            Wykaz = wykaz;
            OpisStanu = opisStanu;
            DataZdarzenia = dataZdarzenia;
            Guid = guid;
        }
        public string Serialize(ObjectIDGenerator idGenerator)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Wykaz + ", ");
            sb.Append(OpisStanu + ", ");
            sb.Append(DataZdarzenia + ", ");
            sb.Append(Guid + ", ");
            sb.Append(idGenerator.GetId(this, out bool firstTime) + ", ");
            return sb.ToString();
        }
    }
}
