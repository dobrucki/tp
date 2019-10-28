using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public Guid IdWykazu { get; }
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
        
    }
}
