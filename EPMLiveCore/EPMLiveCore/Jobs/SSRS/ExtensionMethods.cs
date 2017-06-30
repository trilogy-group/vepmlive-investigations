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
            var ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("m", "http://schemas.microsoft.com/sqlserver/reporting/2006/03/reportdatasource");
            if (doc.SelectSingleNode(path, ns) != null)
            {
                return doc.SelectSingleNode(path, ns).InnerText;
            }

            return string.Empty;
        }

        public static bool GetBooleanValue(this XmlDocument doc, string path)
        {
            var ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("m", "http://schemas.microsoft.com/sqlserver/reporting/2006/03/reportdatasource");
            if (doc.SelectSingleNode(path, ns) != null)
            {
                return Convert.ToBoolean(doc.SelectSingleNode(path, ns).InnerText);
            }

            return false;
        }
    }
}