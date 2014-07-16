using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EPMLiveCore;
using Microsoft.SharePoint;
using WorkEnginePPM.Core.Entities;
using WorkEnginePPM.DataServiceModules;
using PortfolioEngineCore;
using WorkEnginePPM.WebServices.Core;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;

namespace WorkEnginePPM.Core.PFEDataServiceManager
{
    public class PFEDataServiceUtils
    {

        //public static string SerializeData<T>(T obj)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        var serializer = new XmlSerializer(typeof(T));
        //        serializer.Serialize(memoryStream, obj);
        //        memoryStream.Position = 0;
        //        return new StreamReader(memoryStream).ReadToEnd();
        //    }
        //}

        //public static object DeserializeData<T>(string data, T obj)
        //{
        //    using (TextReader textReader = new StreamReader(data))
        //    {
        //        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        //        return (T)xmlSerializer.Deserialize(textReader);
        //    }
        //}

        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            //Replace Json Date String                                         
            string p = @"\\/Date\((\d+)\+\d+\)\\/";
            MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertJsonDateToDateString);
            Regex reg = new Regex(p);
            jsonString = reg.Replace(jsonString, matchEvaluator);
            return jsonString;
        }

        /// <summary>
        /// JSON Deserialization
        /// </summary>
        public static T JsonDeserialize<T>(string jsonString)
        {
            //Convert "yyyy-MM-dd HH:mm:ss" String as "\/Date(1319266795390+0800)\/"
            string p = @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}";
            MatchEvaluator matchEvaluator = new MatchEvaluator(
                ConvertDateStringToJsonDate);
            Regex reg = new Regex(p);
            jsonString = reg.Replace(jsonString, matchEvaluator);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
        /// <summary>
        /// Convert Serialization Time /Date(1319266795390+0800) as String
        /// </summary>
        private static string ConvertJsonDateToDateString(Match m)
        {
            string result = string.Empty;
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
            dt = dt.ToLocalTime();
            result = dt.ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }

        /// <summary>
        /// Convert Date String as Json Time
        /// </summary>
        private static string ConvertDateStringToJsonDate(Match m)
        {
            string result = string.Empty;
            DateTime dt = DateTime.Parse(m.Groups[0].Value);
            dt = dt.ToUniversalTime();
            TimeSpan ts = dt - DateTime.Parse("1970-01-01");
            result = string.Format("\\/Date({0}+0800)\\/", ts.TotalMilliseconds);
            return result;
        }

        public static void ValidateResponse(XElement element)
        {
            if (element == null) return;

            if (element.Name.LocalName.Equals("Result"))
            {
                XAttribute statusAttribute = element.Attribute("Status");

                if (statusAttribute == null || !statusAttribute.Value.Equals("1") || statusAttribute.Parent == null)
                    return;

                XElement errorElement = statusAttribute.Parent.Element("Error");

                if (errorElement != null) throw new Exception(errorElement.Value);
            }
            else
            {
                foreach (XElement resultElement in element.Descendants("Result"))
                {
                    XAttribute statusAttribute = resultElement != null
                        ? resultElement.Attribute("Status")
                        : element.Attribute("Status");

                    if (statusAttribute == null || !statusAttribute.Value.Equals("1") || statusAttribute.Parent == null)
                        continue;

                    XElement errorElement = statusAttribute.Parent.Element("Error");

                    if (errorElement != null) throw new Exception(errorElement.Value);
                }
            }
        }

    }
}