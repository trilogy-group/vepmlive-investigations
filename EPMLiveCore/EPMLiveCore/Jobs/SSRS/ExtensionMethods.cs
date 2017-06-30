using EPMLiveCore.SSRS2010;
using System;
using System.Linq;
using System.Xml;

namespace EPMLiveCore.Jobs.SSRS
{
    public static class ExtensionMethods
    {
        public static Role GetRole(this Role[] roles, string role)
        {
            return roles.Single(x => x.Name == role);
        }

        public static string GetStringValue(this XmlDocument doc, string path)
        {
            if(doc.SelectSingleNode(path) != null)
            {
                return doc.SelectSingleNode(path).InnerText;
            }

            return string.Empty;
        }

        public static bool GetBooleanValue(this XmlDocument doc, string path)
        {
            if (doc.SelectSingleNode(path) != null)
            {
                return Convert.ToBoolean(doc.SelectSingleNode(path).InnerText);
            }

            return false;
        }
    }
}