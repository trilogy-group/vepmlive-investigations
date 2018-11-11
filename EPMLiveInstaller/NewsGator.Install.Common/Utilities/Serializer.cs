using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace NewsGator.Install.Common.Utilities
{
    internal static class Serializer
    {
        internal static string Serialize(object obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
                serializer.WriteObject(memoryStream, obj);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        internal static object Deserialize(string xml, Type toType)
        {
            //using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            //{                
            //    XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(memoryStream, Encoding.UTF8, new XmlDictionaryReaderQuotas(), null);
            //    DataContractSerializer serializer = new DataContractSerializer(toType);
            //    return serializer.ReadObject(reader);
            //}

            var bytes = Encoding.UTF8.GetBytes(xml);
            using (XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(bytes, 0, bytes.Length, Encoding.UTF8, new XmlDictionaryReaderQuotas(), null))
            {
                DataContractSerializer serializer = new DataContractSerializer(toType);
                return serializer.ReadObject(reader);
            }
        }
    }
}
