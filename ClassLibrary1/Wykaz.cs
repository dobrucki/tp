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
        private string _idWykazu;

        public Wykaz(string firstName, string lastName, string idWykazu)
        {
            _firstName = firstName;
            _lastName = lastName;
            _idWykazu = idWykazu;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdWykazu { get; set; }
        
    }
}
