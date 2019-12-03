using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zadanie2
{
    class JsonFormatter
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };

        public static void Serialize(System.IO.Stream serializationStream, object graph)
        {
            string jsonText = JsonConvert.SerializeObject(graph, Formatting.Indented, _settings);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonText);
            serializationStream.Write(buffer, 0, buffer.Length);
        }

        public static T Deserialize<T>(System.IO.Stream serializationStream)
        {
            throw new NotImplementedException();
        }
    }
}
