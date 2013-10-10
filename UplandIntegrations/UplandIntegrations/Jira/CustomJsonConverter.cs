using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System.Collections.Generic;
using System.IO;

namespace UplandIntegrations.Jira
{
    public class CustomJsonConverter : ISerializer, IDeserializer
    {
        private static readonly JsonSerializerSettings SerializerSettings;

        static CustomJsonConverter()
        {
            SerializerSettings = new JsonSerializerSettings
            {
                //DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                //Converters = new List<JsonConverter> { new IsoDateTimeConverter() },
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, SerializerSettings);
        }

        public T Deserialize<T>(IRestResponse response)
        {
            var type = typeof(T);

            return (T)JsonConvert.DeserializeObject(response.Content, type, SerializerSettings);
        }

        string IDeserializer.RootElement { get; set; }
        string IDeserializer.Namespace { get; set; }
        string IDeserializer.DateFormat { get; set; }
        string ISerializer.RootElement { get; set; }
        string ISerializer.Namespace { get; set; }
        string ISerializer.DateFormat { get; set; }
        public string ContentType { get; set; }
    }
}
