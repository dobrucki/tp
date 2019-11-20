using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class A
    {
        public string Name { get; set; }
        public C GetC { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            else
            {
                A other = obj as A;
                return string.Compare(this.Name, other.Name) < 0 ? false : true;
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
