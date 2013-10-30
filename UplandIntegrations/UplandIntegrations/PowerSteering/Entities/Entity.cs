using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace UplandIntegrations.PowerSteering.Entities
{
    internal class Entity
    {
        #region Fields (1) 

        private readonly string _objectKind;

        #endregion Fields 

        #region Constructors (1) 

        public Entity(string objectKind)
        {
            _objectKind = objectKind;
            Fields = new Dictionary<string, string>();
        }

        #endregion Constructors 

        #region Properties (3) 

        public int EPMLiveId { get; set; }

        public Dictionary<string, string> Fields { get; set; }

        internal string ObjectKind
        {
            get { return _objectKind; }
        }

        #endregion Properties 

        #region Methods (4) 

        // Public Methods (2) 

        public static Entity Deserialize(string content, IEnumerable<Field> fields, Entity entity = null)
        {
            XDocument document = XDocument.Parse(content);
            XElement root = document.Root;

            if (entity != null)
            {
                if (bool.Parse(root.Element("success").Value))
                {
                    Set(entity, root.Element("id").Value, "id");
                }
                else
                {
                    throw new Exception(root.Element("error").Value);
                }
            }
            else
            {
                entity = new Entity(root.Name.LocalName);

                Set(entity, root.Attribute("id").Value, "id");

                foreach (XElement element in root.Elements())
                {
                    Field[] entityFields = fields as Field[] ?? fields.ToArray();
                    string name = GetFieldName(element.Name.LocalName.ToLower(), entityFields);

                    if (name.Equals("objecttype") || name.Equals("customfieldlist")) continue;

                    if (name.Equals("owner"))
                    {
                        Set(entity, element.Element("name").Value, name);
                    }
                    else if (name.Equals("taglist"))
                    {
                        Set(entity, element.Element("tagset").Element("tag").Element("value").Value,
                            element.Element("tagset").Element("name").Value);
                    }
                    else
                    {
                        Set(entity, element.Value, name);
                    }
                }
            }

            return entity;
        }

        public string Serialize(IEnumerable<Field> fields)
        {
            List<string> tagFields = (from field in fields where field.Tag select field.Name).ToList();

            var element = new XElement(_objectKind.ToLower());

            foreach (var field in Fields)
            {
                string name = field.Key;

                string value = field.Value;
                if (string.IsNullOrEmpty(value)) continue;

                if (tagFields.Contains(name))
                {
                    XElement tagList = element.Element("tagList");
                    if (tagList == null)
                    {
                        element.Add(new XElement("tagList"));
                        tagList = element.Element("tagList");
                    }

                    tagList.Add(new XElement("tagset", new XElement("name", name),
                        new XElement("tag", new XElement("value", value))));
                }
                else if (name.Equals("owner"))
                {
                    element.Add(new XElement(name, new XElement("name", value)));
                }
                else
                {
                    element.Add(new XElement(name, value));
                }
            }

            return element.ToString();
        }

        // Internal Methods (2) 

        internal static string GetFieldName(string name, IEnumerable<Field> entityFields)
        {
            string fieldName = name;

            foreach (Field field in entityFields.Where(field => field.Name.ToLower().Equals(name.ToLower())))
            {
                fieldName = field.Name;
                break;
            }

            return fieldName;
        }

        internal static void Set(Entity entity, string value, string key)
        {
            var field = key;
            foreach (string k in entity.Fields.Keys.Where(k => k.ToLower().Equals(field.ToLower())))
            {
                key = k;
                break;
            }

            if (!entity.Fields.ContainsKey(key)) entity.Fields.Add(key, value);
            else entity.Fields[key] = value;
        }

        #endregion Methods 
    }
}