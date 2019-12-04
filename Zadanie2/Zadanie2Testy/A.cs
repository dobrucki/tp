using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2Testy
{
    [Serializable]
    public class A :ISerializable
    {
        public string Name { get; set; }
        public float Number { get; set; }
        public DateTime Date { get; set; }
        public C C { get; set; }

        public A() { }

        public A(string name, float number, DateTime date, C c)
        {
            Name = name;
            Number = number;
            Date = date;
            C = c;
        }

        public A(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            Name = (string)info.GetValue("Name", typeof(string));
            Number = (float)info.GetValue("Number", typeof(float));
            Date = (DateTime)info.GetValue("Date", typeof(DateTime));
            C = (C)info.GetValue("C", typeof(C));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Number", Number);
            info.AddValue("Date", Date);
            info.AddValue("C", C);
        }
    }

}
