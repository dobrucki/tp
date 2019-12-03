using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Zadanie2
{
    public class JsonFormatter
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };

        public void Serialize(System.IO.Stream serializationStream, object graph)
        {
            string jsonText = JsonConvert.SerializeObject(graph, Formatting.Indented, _settings);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonText);
            serializationStream.Write(buffer, 0, buffer.Length);
        }

        public object Deserialize(System.IO.Stream serializationStream)
        {
            using (StreamReader streamReader = new StreamReader(serializationStream))
            {
                string buffer = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject(buffer, _settings);
            }
        }
    }
}
