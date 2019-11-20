using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ClassLibrary1
{
    public class Katalog : IEquatable<Katalog>
    {
        public string Tytul { get; set; }
        public string ImieAutora { get; set; }
        public string NazwiskoAutora { get; set; }
        public Guid IdKatalogu { get; set; }

        public Katalog(string tytul, string imieAutora, string nazwiskoAutora, Guid idKatalogu)
        {
            Tytul = tytul;
            ImieAutora = imieAutora;
            NazwiskoAutora = nazwiskoAutora;
            IdKatalogu = idKatalogu;
        }

        public Katalog()
        {
        }

        public string Serialize(ObjectIDGenerator idGenerator)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetType().FullName.ToString() + ",");
            sb.Append(Tytul + ",");
            sb.Append(ImieAutora + ",");
            sb.Append(NazwiskoAutora + ",");
            sb.Append(IdKatalogu + ",");
            sb.Append(idGenerator.GetId(this, out bool firstTime));
            return sb.ToString();
        }

        public void Deserialize(List<string> splitString)
        {
            Tytul = splitString[1];
            ImieAutora = splitString[2];
            NazwiskoAutora = splitString[3];
            IdKatalogu = new Guid(splitString[4]);
        }

        public bool Equals(Katalog other)
        {
            if (other == null) return false;
            return this.IdKatalogu == other.IdKatalogu
                && this.Tytul == other.Tytul
                && this.ImieAutora == other.ImieAutora
                && this.NazwiskoAutora == other.NazwiskoAutora;
        }

        public override bool Equals(object other)
        {
            if (other is null) return false;
            else return this.Equals(other as OpisStanu);
        }

        public override int GetHashCode()
        {
            return this.IdKatalogu.GetHashCode();
        }
    }

    
}
