using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal class FieldInfo
    {
        #region Methods (4) 

        // Private Methods (1) 

        /// <summary>
        /// Gets the field info element.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static XElement GetFieldInfoElement(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new APIException(6001, "No parameters specified.");

            XDocument xDocument = XDocument.Parse(data);

            if (!xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("FieldInfo")))
                throw new APIException(6002, "Cannot find element: FieldInfo");

            return xDocument.Element("FieldInfo");
        }

        // Internal Methods (3) 

        /// <summary>
        /// Gets the fields.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        internal static IEnumerable<string> GetFields(XElement element)
        {
            if (!element.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("Fields"))) throw new Exception("Cannot find element: Fields");

            return element.Element("Fields").Value.Split(',');
        }

        /// <summary>
        /// Gets the guess original field name setting.
        /// </summary>
        /// <param name="fieldInfoElement">The field info element.</param>
        /// <returns></returns>
        internal static bool GetGuessOriginalFieldNameSetting(XElement fieldInfoElement)
        {
            return fieldInfoElement.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("GuessOriginalFieldName"))
                   && bool.Parse(fieldInfoElement.Element("GuessOriginalFieldName").Value);
        }

        /// <summary>
        /// Determines whether the specified field is editable or not.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string IsFieldEditable(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("FieldInfo"));

                int itemId;
                Guid listId;
                Guid webId;
                Guid siteId;
                string siteUrl;

                XElement fieldInfoElement = GetFieldInfoElement(data);
                Utils.GetItemListWebSite(data, fieldInfoElement, out itemId, out listId, out webId, out siteId, out siteUrl);

                using (var spSite = new SPSite(siteUrl))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(webId))
                    {
                        SPList spList = spWeb.Lists[listId];

                        SPListItem spListItem = spList.GetItemById(itemId);

                        Dictionary<string, Dictionary<string, string>> fieldProperties = Utils.GetFieldProperties(spList);

                        result.Element("FieldInfo").Add(new XElement("Fields"));

                        XElement xElement = result.Element("FieldInfo").Element("Fields");
                        xElement.Add(new XAttribute("ItemID", itemId));
                        xElement.Add(new XAttribute("ListID", listId));
                        xElement.Add(new XAttribute("WebID", webId));
                        xElement.Add(new XAttribute("SiteID", siteId));
                        xElement.Add(new XAttribute("SiteURL", siteUrl));

                        bool guessOriginalFieldNameSetting = GetGuessOriginalFieldNameSetting(fieldInfoElement);

                        foreach (string field in GetFields(fieldInfoElement))
                        {
                            string theField = field;
                            if (guessOriginalFieldNameSetting) theField = Utils.ToOriginalFieldName(theField);

                            if (!spListItem.Fields.ContainsFieldWithInternalName(theField)) continue;

                            var element = new XElement("Field");
                            element.Add(new XAttribute("Name", theField));
                            element.Add(new XAttribute("Editable", EditableFieldDisplay.isEditable(spListItem, spListItem.Fields.GetFieldByInternalName(theField), fieldProperties)));

                            xElement.Add(element);
                        }
                    }
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(6000, e.Message);
            }
        }

        #endregion Methods 
    }
}