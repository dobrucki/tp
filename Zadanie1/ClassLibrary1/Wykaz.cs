using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ClassLibrary1
{
    public class Wykaz // Czytelnik
    {
        public class Adres
        {
            public string Miasto { get; set; }
            public string KodPocztowy { get; set; }
            public string Ulica { get; set; }
            public string Numer { get; set;  }

            public Adres(string miasto, string kodPocztowy, string ulica, string numer)
            {
                Miasto = miasto;
                KodPocztowy = kodPocztowy;
                Ulica = ulica;
                Numer = numer;
            }

            public Adres()
            {

            }
            public string Serialize(ObjectIDGenerator idGenerator)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(GetType().ToString() + ",");
                sb.Append(Miasto + ",");
                sb.Append(KodPocztowy + ",");
                sb.Append(Ulica + ",");
                sb.Append(Numer + ",");
                sb.Append(idGenerator.GetId(this, out bool firstTime));
                sb.AppendLine();
                return sb.ToString();
            }
            public void Deserialize(List<string> splitString)
            {
                Miasto = splitString[1];
                KodPocztowy = splitString[2];
                Ulica = splitString[3];
                Numer = splitString[4];
            }

        }

        public Guid IdWykazu { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Adres AdresWykazu { get; set; }

        public Wykaz(string firstName, string lastName, Guid idWykazu, Adres adres)
        {
            FirstName = firstName;
            LastName = lastName;
            IdWykazu = idWykazu;
            AdresWykazu = adres;
        }

        public Wykaz()
        {

        }


        public string Serialize(ObjectIDGenerator idGenerator)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AdresWykazu.Serialize(idGenerator));
            sb.Append(GetType().FullName.ToString() + ",");
            sb.Append(FirstName + ",");
            sb.Append(LastName + ",");
            sb.Append(IdWykazu + ",");
            sb.Append(idGenerator.GetId(this, out bool firstTime) + ",");
            sb.Append(idGenerator.GetId(AdresWykazu, out firstTime));
            return sb.ToString();

        }
        public void Deserialize(List<string> splitString)
        {
            FirstName = splitString[1];
            LastName = splitString[2];
            IdWykazu = new Guid(splitString[3]);
        }

    }
}
