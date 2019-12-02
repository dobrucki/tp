using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Zadanie2
{
    public class OwnFormatter : Formatter
    {
        public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override StreamingContext Context { get; set; }
        public ObjectIDGenerator IdGenerator { get; set; }

        public OwnFormatter()
        {
            IdGenerator = new ObjectIDGenerator();
            Context = new StreamingContext(StreamingContextStates.File);

        }
        public override object Deserialize(Stream serializationStream)
        {

            StreamReader reader = new StreamReader(serializationStream);
            string line;
            Dictionary<string, Object> idObjectPair = new Dictionary<string, object>();
            Dictionary<Object, string> objectIdPair = new Dictionary<Object, string>();
            Context = new StreamingContext(StreamingContextStates.File);
            while ((line = reader.ReadLine()) != null)
            {
                List<string> splitedLine = line.Split(',').ToList();
                SerializationInfo info = new SerializationInfo(Type.GetType(splitedLine[5] + ", " + splitedLine[5].Split('.').ToList()[0]), new FormatterConverter());
                for (int j = 7; j < splitedLine.Count-3; j+=3)
                {
                    if (splitedLine[j-1].Equals("System.DateTime"))
                        info.AddValue(splitedLine[j], DateTime.Parse(splitedLine[j+1]).ToLocalTime());
                    else
                        info.AddValue(splitedLine[j], splitedLine[j + 1]);
                    
                }
               
                info.AddValue(splitedLine[splitedLine.Count -2], null);


                idObjectPair.Add(splitedLine[2] ,Activator.CreateInstance(Type.GetType(splitedLine[5] + ", " + splitedLine[5].Split('.').ToList()[0]), info, Context));
                objectIdPair.Add(idObjectPair[splitedLine[2]], splitedLine[splitedLine.Count-1]);            
            }

            for (int i = 1; i <= idObjectPair.Count; i++)
            {

                object refObj = idObjectPair[i.ToString()];
                if (objectIdPair.ContainsKey(refObj))
                {
                    foreach (PropertyInfo propertyInfo in refObj.GetType().GetProperties())
                    {

                        if (propertyInfo.PropertyType == idObjectPair[objectIdPair[refObj]].GetType())
                        {
                            propertyInfo.SetValue(refObj, idObjectPair[objectIdPair[refObj]]);
                        }
                    }
                }
            }
            reader.Close();
            return idObjectPair["1"];

        }

        bool FirstTime;
        private string fileLine = "";
        public override void Serialize(Stream serializationStream, object graph)
        {
           
       
            if (graph is ISerializable data)
            {
                SerializationInfo info = new SerializationInfo(graph.GetType(), new FormatterConverter());
                info.AddValue("id", IdGenerator.GetId(graph, out FirstTime));
                info.AddValue("ClassType", graph.GetType().FullName);
                data.GetObjectData(info, Context);
                foreach (SerializationEntry item in info)
                {
                    if (item.Value is ISerializable && item.Value != null && item.Value.GetType() != typeof(DateTime)) {
                        WriteMember(item.Name, item.Value);
                        if (FirstTime == true)
                        {
                            Serialize(serializationStream, item.Value);
                        }    

                    }
                    else
                    {
                        WriteMember(item.Name, item.Value);
                    }
                }
                byte[] content = Encoding.UTF8.GetBytes(fileLine);
                serializationStream.Write(content, 0, content.Length);
                fileLine = "";
            }

        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (memberType.Equals(typeof(string)))
            {
                WriteString(obj, name);
            }
            else
            {
                fileLine += obj.GetType() + "," + name + "," + IdGenerator.GetId(obj, out FirstTime) + "\n";
            }
             
        }

        protected void WriteString(object val, string name)
        {
            fileLine += val.GetType() + "," + name + "," + (string)val + ",";
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            fileLine += val.GetType() + "," + name + ',' + val.ToUniversalTime().ToString() + ",";
        }

        protected override void WriteSingle(float val, string name)
        {
            fileLine += val.GetType() + "," + name + ',' + val.ToString("0.00", CultureInfo.InvariantCulture) + ",";
        }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt64(long val, string name)
        {
            fileLine += val.GetType() + "," + name + "," + val.ToString() + ",";
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }
    }
}
