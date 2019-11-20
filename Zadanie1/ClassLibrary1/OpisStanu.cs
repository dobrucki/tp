using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ClassLibrary1
{
    public class OpisStanu : IEquatable<OpisStanu>
    {

        public Katalog Katalog { get; set; }
        public int RokWydania { get; set; }
        public Guid IdOpisuStanu { get; set; }


        public OpisStanu(Katalog katalog, int rokWydania, Guid idOpisuStanu)
        {
            Katalog = katalog;
            RokWydania = rokWydania;
            IdOpisuStanu = idOpisuStanu;
        }

        public OpisStanu()
        {

        }
        public string Serialize(ObjectIDGenerator idGenerator)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetType().FullName.ToString() + ",");
            sb.Append(idGenerator.GetId(Katalog, out bool firstTime) + ",");
            sb.Append(RokWydania + ",");
            sb.Append(IdOpisuStanu + ",");
            sb.Append(idGenerator.GetId(this, out firstTime));
            return sb.ToString();
        }

        public void Deserialize(List<string> splitString)
        {
            RokWydania = Int32.Parse(splitString[2]);
            IdOpisuStanu = new Guid(splitString[3]);
        }

        public bool Equals(OpisStanu other)
        {
            if (other is null) return false;
            return this.IdOpisuStanu == other.IdOpisuStanu 
                && this.Katalog.Equals(other.Katalog) 
                && this.RokWydania == other.RokWydania;
        }

        public override bool Equals(object other)
        {
            if (other is OpisStanu)
            {
                return this.Equals(other as OpisStanu);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.IdOpisuStanu.GetHashCode();
        }
    }
}
