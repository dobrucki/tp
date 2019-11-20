using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ClassLibrary1
{
    public class Katalog
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


    }

    
}
