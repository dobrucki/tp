using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zadanie2Testy
{
    [Serializable]
    [JsonObject]
    public class C : ISerializable
    {
        public string Name { get; set; }
        public float Number { get; set; }
        public DateTime Date { get; set; }
        public B B { get; set; }

        public C(string name, float number, DateTime date, B b)
        {
            Name = name;
            Number = number;
            Date = date;
            B = b;
        }

        public C() { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Number", Number);
            info.AddValue("Date", Date);
            info.AddValue("B", B);
        }

        public C(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            Name = (string)info.GetValue("Name", typeof(string));
            Number = (float)info.GetValue("Number", typeof(float));
            Date = (DateTime)info.GetValue("Date", typeof(DateTime));
            B = (B)info.GetValue("B", typeof(B));
        }
    }
}
