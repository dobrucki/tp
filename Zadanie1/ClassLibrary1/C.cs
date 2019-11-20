using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class C
    {
        public string Name { get; set; }
        public B GetB { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            else
            {
                C other = obj as C;
                return string.Compare(this.Name, other.Name) < 0 ? false : true;
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
        public string Serialize(ObjectIDGenerator idGenerator)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetType().FullName.ToString() + ",");
            sb.Append(idGenerator.GetId(GetB, out bool firstTime) + ",");
            sb.Append(Name + ",");
            sb.Append(idGenerator.GetId(this, out firstTime));
            return sb.ToString();
        }

        public void Deserialize(List<string> splitString)
        {
            Name = splitString[2];
        }


    }
}
