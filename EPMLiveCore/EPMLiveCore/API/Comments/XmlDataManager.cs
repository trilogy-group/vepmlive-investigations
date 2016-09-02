using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EPMLiveCore.API
{
    internal class XmlDataManager
    {
        XDocument dataXml;

        public XmlDataManager(string xml)
        {
            dataXml = XDocument.Parse(xml);
        }

        public string GetPropVal(string propName)
        {
            string propVal = string.Empty;

            XElement element = dataXml.Elements("Data")
                .Elements("Param")
                .FirstOrDefault(el => el.Attribute("key").Value == propName);

            if (element != null)
            {
                propVal = element.Value;
            }

            return propVal;
        }

        public XElement GetNodeByKey(string key)
        {
            return dataXml.Element("Data").Elements("Param").Where(e => e.Attribute("key").Value.Equals(key)).FirstOrDefault();
        }

        public void EditProp(string key, string value)
        {
            // replace value if property exists
            if (GetNodeByKey(key) != null)
            {
                dataXml.Element("Data").Elements("Param").Where(e => e.Attribute("key").Value.Equals(key)).FirstOrDefault().Value = value;
            }
            // create new node if node does not exist
            else
            {
                XElement newEl = new XElement("Param", value);
                newEl.SetAttributeValue("key", key);
                dataXml.Root.Add(newEl);
            }
        }
    }
}
