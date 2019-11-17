using System;
using System.Runtime.Serialization;
using System.Text;

namespace ClassLibrary1
{
    public class Wykaz // Czytelnik
    {
        public class Adres
        {
            public string Miasto { get; }
            public string KodPocztowy { get; }
            public string Ulica { get; }
            public string Numer { get; }

            public Adres(string miasto, string kodPocztowy, string ulica, string numer)
            {
                Miasto = miasto;
                KodPocztowy = kodPocztowy;
                Ulica = ulica;
                Numer = numer;
            }
            public string Serialize(ObjectIDGenerator idGenerator)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Miasto + ", ");
                sb.Append(KodPocztowy + ", ");
                sb.Append(Ulica + ", ");
                sb.Append(Numer + ", ");
                sb.Append(idGenerator.GetId(this, out bool firstTime) + ", ");
                return sb.ToString();
            }
        }

        public Guid IdWykazu { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public Adres AdresWykazu { get; set; }

        public Wykaz(string firstName, string lastName, Guid idWykazu, Adres adres)
        {
            FirstName = firstName;
            LastName = lastName;
            IdWykazu = idWykazu;
            AdresWykazu = adres;
        }


        public string Serialize(ObjectIDGenerator idGenerator)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FirstName + ", ");
            sb.Append(LastName + ", ");
            sb.Append(IdWykazu + ", ");
            sb.Append(idGenerator.GetId(this, out bool firstTime) + ", ");
            sb.Append(AdresWykazu.Serialize (idGenerator));
            return sb.ToString();

 
        }
        
    }
}
