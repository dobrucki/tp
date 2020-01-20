using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public partial class Location
    {
        public override string ToString()
        {
            return "Id: " + LocationID + " " + "Name: " + Name;
        }

        public string LocationToString
        {
            get => ToString();
        }
    }
}
