using System;
using System.Collections;
using System.Diagnostics;
using System.Xml;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public class ItemMessage
    {
        public ItemMessage(XmlDocument document, SPWeb oWeb)
        {
            FillFromXml(document, oWeb);
        }

        public int TemplatedId { get; private set; }
        public bool HideFromUser { get; private set; }
        public bool DoNotEmail { get; private set; }
        public bool UnMarkRead { get; private set; }
        public bool ForceNewEntry { get; private set; }
        public string ListName { get; private set; }
        public string ListId { get; private set; }
        public string ItemId { get; private set; }
        public string WebId { get; private set; }
        public string ExternalColumn { get; private set; }
        public ArrayList NewUsers { get; private set; }
        public ArrayList RemovedUsers { get; private set; }
        public Hashtable ParamsTable { get; private set; }

        private void FillFromXml(XmlDocument document, SPWeb oWeb)
        {
            TemplatedId = GetXmlAttributeValueAsInt(document, "TemplateID");

            ListName = GetXmlAttributeValueAsString(document, "ListName", string.Empty);
            ListId = GetXmlAttributeValueAsString(document, "ListID", string.Empty);
            ItemId = GetXmlAttributeValueAsString(document, "ItemID", string.Empty);
            WebId = GetXmlAttributeValueAsString(document, "WebID", string.Empty);
            HideFromUser = GetXmlAttributeValueAsBool(document, "HideFromUser", false);
            DoNotEmail = GetXmlAttributeValueAsBool(document, "DoNotEmail", false);
            UnMarkRead = GetXmlAttributeValueAsBool(document, "UnMarkRead", true);
            ForceNewEntry = GetXmlAttributeValueAsBool(document, "ForceNewEntry", false);

            ParamsTable = new Hashtable();
            var paramsNode = document.FirstChild.SelectSingleNode("Params");
            foreach (XmlNode paramNode in paramsNode.SelectNodes("Param"))
            {
                ParamsTable.Add(paramNode.Attributes["Name"].Value, paramNode.InnerText);
            }

            NewUsers = GetXmlAttributeValueAsArray(document, "NewUsers");
            RemovedUsers = GetXmlAttributeValueAsArray(document, "RemoveUsers");

            ExternalColumn = GetXmlAttributeValueAsString(document, "ExternalColumn", string.Empty);

            if (ExternalColumn != "")
            {
                FillNewFromResource(oWeb);
            }
        }

        private void FillNewFromResource(SPWeb oWeb)
        {
            var dtResources = APITeam.GetResourcePool(
                string.Format( "<Get><Columns>{0}</Columns></Get>", ExternalColumn), 
                oWeb);

            var arrNewTemp = new ArrayList();

            foreach (var parameter in NewUsers)
            {
                var row = dtResources.Select(string.Format("{0} ='{1}'", ExternalColumn, parameter));
                if (row.Length > 0)
                {
                    arrNewTemp.Add(row[0]["SPID"].ToString());
                }
            }

            NewUsers = arrNewTemp;
        }

        private static ArrayList GetXmlAttributeValueAsArray(XmlDocument document, string attributeName)
        {
            try
            {
                var attributeString = GetXmlAttributeValueAsString(document, attributeName, string.Empty);
                var attributeArray = new ArrayList(attributeString.Split(','));
                return attributeArray;
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.ToString());
            }
            return new ArrayList();
        }

        private static bool GetXmlAttributeValueAsBool(XmlDocument document, string attributeName, bool defaultValue)
        {
            try
            {
                var attributeString = GetXmlAttributeValueAsString(document, attributeName, string.Empty);
                bool attributeBool;
                if (!bool.TryParse(attributeString, out attributeBool))
                {
                    return defaultValue;
                }
                return attributeBool;
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.ToString());
            }
            return defaultValue;
        }

        private static int GetXmlAttributeValueAsInt(XmlDocument document, string attributeName)
        {
            try
            {
                var attributeString = GetXmlAttributeValueAsString(document, attributeName, string.Empty);
                int attributeInt;
                if (!int.TryParse(attributeString, out attributeInt))
                {
                    throw new InvalidOperationException(
                        string.Format("'{0}' couldn't be parsed into int.", attributeString));
                }
                return attributeInt;
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.ToString());
                throw new InvalidOperationException(
                        string.Format("couldn't parse int.", exception));
            }
        }

        private static string GetXmlAttributeValueAsString(
            XmlDocument document, 
            string attributeName, 
            string defaultValue)
        {
            try
            {
                var attributeValue = document.FirstChild.Attributes[attributeName].Value;
                return attributeValue;
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.ToString());
            }
            return defaultValue;
        }
    }
}
