using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Wykaz // Czytelnik
    {
        private string _firstName;
        private string _lastName;
        private Guid _idWykazu;

        public Wykaz(string firstName, string lastName, Guid idWykazu)
        {
            _firstName = firstName;
            _lastName = lastName;
            _idWykazu = idWykazu;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid IdWykazu { get; set; }
        
    }
}
