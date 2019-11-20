using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class B
    {
        public string Name { get; set; }
        public A GetA { get; set; }

        public string Serialize(ObjectIDGenerator idGenerator)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GetType().FullName.ToString() + ",");
            sb.Append(idGenerator.GetId(GetA, out bool firstTime) + ",");
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
