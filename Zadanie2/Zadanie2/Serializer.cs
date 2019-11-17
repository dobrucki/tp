using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;


namespace Zadanie2
{
    class Serializer
    {
        public static void Serialize(DataContext dataContext, string filename)
        {
            StringBuilder sb = new StringBuilder();
            ObjectIDGenerator idGenerator = new ObjectIDGenerator();

            foreach (Wykaz w in dataContext.Wykazy)
            {
                sb.Append(w.Serialize(idGenerator));
                sb.AppendLine();
            }

            System.IO.File.WriteAllText(filename, sb.ToString());


        }
    
   }
}
