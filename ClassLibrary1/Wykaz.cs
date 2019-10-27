using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Wykaz // Czytelnik
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid IdWykazu { get; set; }

        public Wykaz(string firstName, string lastName, Guid idWykazu)
        {
            FirstName = firstName;
            LastName = lastName;
            IdWykazu = idWykazu;
        }
        
    }
}
