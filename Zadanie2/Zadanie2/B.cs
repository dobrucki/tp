using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public class B :ISerializable
    {
        public string Name { get; set; }
        public float Number { get; set; }
        public DateTime Date { get; set; }
        public A A { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("Number", Number);
            info.AddValue("Date", Date);
            info.AddValue("A", A);
        }

        public B(string name, float number, DateTime date, A a)
        {
            Name = name;
            Number = number;
            Date = date;
            A = a;
        }

        public B() { }

        public B(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            Name = (string)info.GetValue("Name", typeof(string));
            Number = (float)info.GetValue("Number", typeof(float));
            Date = (DateTime)info.GetValue("Date", typeof(DateTime));
            A = (A)info.GetValue("A", typeof(A));
        }
    }
}
