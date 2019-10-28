using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Wykaz // Czytelnik
    {
        public string FirstName { get; }
        public string LastName { get; }
        public Guid IdWykazu { get; }

        public Wykaz(string firstName, string lastName, Guid idWykazu)
        {
            FirstName = firstName;
            LastName = lastName;
            IdWykazu = idWykazu;
        }
        
    }
}
