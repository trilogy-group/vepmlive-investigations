using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace EPMLiveCore
{
    
    //*NOTE: This class is meant to parse XML in the following format. 
    //<Data>
    //<Param key=name>value</Param>
    //<Param key=name>value</Param>
    //</Data>
   
    public class XMLDataManager
    {
        XDocument dataXml = null;

        public XMLDataManager(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
            {
                xml = HttpUtility.UrlDecode(xml);
                xml = xml.Replace("&", "&amp;");

                dataXml = XDocument.Parse(xml);
            }
        }

        public string GetPropVal(string propName)
        {
            string propVal = string.Empty;

            if (dataXml != null)
            {
                XElement element = dataXml.Elements("Data")
                    .Elements("Param")
                    .FirstOrDefault(el => el.Attribute("key").Value == propName);

                if (element != null)
                {
                    propVal = element.Value;
                }
            }

            return propVal;
        }

        public void EditProp(string key, string value)
        {
            if (dataXml != null)
            {
                XElement newEl = new XElement("Param", value);
                newEl.SetAttributeValue("key", key);
                dataXml.Root.Add(newEl);
            }
        }
    }
}
