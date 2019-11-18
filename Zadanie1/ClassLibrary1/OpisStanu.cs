using System;
using System.Runtime.Serialization;
using System.Text;

namespace ClassLibrary1
{
    public class OpisStanu
    {

        public Katalog Katalog { get; }
        public int RokWydania { get; }
        public Guid IdOpisuStanu { get; set; }


        public OpisStanu(Katalog katalog, int rokWydania, Guid idOpisuStanu)
        {
            Katalog = katalog;
            RokWydania = rokWydania;
            IdOpisuStanu = idOpisuStanu;
        }


        public string Serialize(ObjectIDGenerator idGenerator)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(idGenerator.GetId(Katalog, out bool firstTime) + ", ");
            sb.Append(RokWydania + ", ");
            sb.Append(IdOpisuStanu + ", ");
            sb.Append(idGenerator.GetId(this, out firstTime) + ", ");
            return sb.ToString();
        }

    }
}
