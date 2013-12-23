using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public static class Utils
    {
        #region Fields (2)

        private const string MyWorkList = "My Work";
        private static readonly string[] ReservedWords = new[] { "Name", "Type", "Width" };

        #endregion Fields

        #region Methods (19)

        // Public Methods (5) 

        /// <summary>
        /// Gets the config web.
        /// </summary>
        /// <returns></returns>
        public static SPWeb GetConfigWeb()
        {
            SPWeb configWeb;

            using (var spSite = new SPSite(SPContext.Current.Web.Site.Url))
            {
                using (SPWeb spWeb = spSite.OpenWeb())
                {
                    Guid lockedWeb = CoreFunctions.getLockedWeb(spWeb);
                    configWeb = GetConfigWeb(spWeb, lockedWeb);
                }
            }
            return configWeb;
        }

        /// <summary>
        /// Gets the format.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns></returns>
        public static string GetFormat(SPField field)
        {
            switch (field.Type)
            {
                case SPFieldType.DateTime:
                    return (((SPFieldDateTime) field).DisplayFormat).ToString();
                case SPFieldType.Number:
                    var spFieldNumber = (SPFieldNumber) field;

                    string percentageSign = string.Empty;

                    if (spFieldNumber.ShowAsPercentage)
                    {
                        percentageSign = @"\%";
                    }

                    switch (spFieldNumber.DisplayFormat)
                    {
                        case SPNumberFormatTypes.Automatic:
                            return ",#0.##########" + percentageSign;
                        case SPNumberFormatTypes.NoDecimal:
                            return ",#0" + percentageSign;
                        case SPNumberFormatTypes.OneDecimal:
                            return ",#0.0" + percentageSign;
                        case SPNumberFormatTypes.TwoDecimals:
                            return ",#0.00" + percentageSign;
                        case SPNumberFormatTypes.ThreeDecimals:
                            return ",#0.000" + percentageSign;
                        case SPNumberFormatTypes.FourDecimals:
                            return ",#0.0000" + percentageSign;
                        case SPNumberFormatTypes.FiveDecimals:
                            return ",#0.00000" + percentageSign;
                    }
                    return string.Empty;
                case SPFieldType.Currency:
                    return "Currency";
                case SPFieldType.Calculated:
                    return field.Description.Equals("Indicator") ? "Indicator" : string.Empty;
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Gets the grid enum.
        /// </summary>
        /// <param name="spSite">The sp site.</param>
        /// <param name="spField">The sp field.</param>
        /// <param name="values">The values.</param>
        /// <param name="range">The range.</param>
        /// <param name="keys">The keys.</param>
        public static void GetGridEnum(SPSite spSite, SPField spField, out string values, out int range,
                                       out string keys)
        {
            keys = string.Empty;
            values = string.Empty;
            range = 0;

            switch (spField.Type)
            {
                case SPFieldType.Choice:
                    values = string.Join("|", ((SPFieldChoice)spField).Choices.Cast<string>().ToArray());
                    break;
                case SPFieldType.User:
                case SPFieldType.Lookup:
                    var spFieldLookup = (SPFieldLookup)spField;
                    if (spFieldLookup.AllowMultipleValues) range = 1;
                    using (SPWeb web = spSite.OpenWeb(spFieldLookup.LookupWebId))
                    {
                        SPList list = web.Lists[new Guid(spFieldLookup.LookupList)];

                        var k = new List<string>();
                        var v = new List<string>();
                        foreach (SPListItem item in list.Items)
                        {
                            k.Add(item["ID"].ToString());
                            v.Add(item[spFieldLookup.LookupField] as string);
                        }

                        keys = string.Join("|", k.ToArray());
                        values = string.Join("|", v.ToArray());
                    }
                    break;
                case SPFieldType.MultiChoice:
                    values = string.Join("|",
                                         ((SPFieldMultiChoice)spField).Choices.Cast<string>().ToArray());
                    range = 1;
                    break;
            }

            if (string.IsNullOrEmpty(keys)) keys = values;
        }

        public static string GetRelatedGridTypeForReadOnly(SPField sPField)
        {
            switch (sPField.Type)
            {
                case SPFieldType.Integer:
                    return "Int";
                case SPFieldType.Number:
                case SPFieldType.Currency:
                    return "Float";
                case SPFieldType.DateTime:
                    return "Date";
                case SPFieldType.Boolean:
                    return "Bool";
                case SPFieldType.Note:
                    return "Lines";
                case SPFieldType.URL:
                    return "Link";
                case SPFieldType.User:
                case SPFieldType.Lookup:
                case SPFieldType.MultiChoice:
                case SPFieldType.Choice:
                    return "Enum";
                case SPFieldType.Calculated:
                    return sPField.Description.Equals("Indicator") ? "Icon" : "Html";
                case SPFieldType.Text:
                case SPFieldType.Invalid:
                    return "Html";
                default:
                    return "Html";
            }
        }

        /// <summary>
        /// Converts the field name to the grid safe name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static string ToGridSafeFieldName(string name)
        {
            return ReservedWords.Aggregate(name,
                                           (current, reservedWord) => current.Replace(reservedWord, "__" + reservedWord));
        }

        // Private Methods (1) 

        /// <summary>
        /// Gets the clean value from formatted.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private static string GetCleanValueFromFormatted(string value)
        {
            if (value.Contains("#"))
            {
                string[] parts = value.Split('#');

                switch (parts[0])
                {
                    case "float;":
                        value = float.Parse(parts[1], new CultureInfo("en-US")).ToString();
                        break;
                    default:
                        value = parts[1];
                        break;
                }
            }
            return value;
        }

        // Internal Methods (13) 

        /// <summary>
        /// Adds the item list web site to Xml element.
        /// </summary>
        /// <param name="itemId">The item id.</param>
        /// <param name="listId">The list id.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="siteId">The site id.</param>
        /// <param name="siteUrl">The site URL.</param>
        /// <param name="xElement">The xml element.</param>
        internal static void AddItemListWebSiteToXElement(int itemId, Guid listId, Guid webId, Guid siteId,
                                                          string siteUrl, ref XElement xElement)
        {
            xElement.Add(new XElement("Item"));
            xElement.Element("Item").Add(new XAttribute("ID", itemId));

            xElement.Add(new XElement("List"));
            xElement.Element("List").Add(new XAttribute("ID", listId));

            xElement.Add(new XElement("Web"));
            xElement.Element("Web").Add(new XAttribute("ID", webId));

            xElement.Add(new XElement("Site"));
            xElement.Element("Site").Add(new XAttribute("ID", siteId));
            xElement.Element("Site").Add(new XAttribute("URL", siteUrl));
        }

        /// <summary>
        /// Cleans the GUID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        internal static string CleanGuid(object id)
        {
            return id.ToString().Replace("{", string.Empty).Replace("}", string.Empty);
        }

        /// <summary>
        /// Gets the clean field value.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns></returns>
        internal static string GetCleanFieldValue(XElement field)
        {
            var cultureInfo = new CultureInfo("en-US");

            string value = field.Value;

            if (string.IsNullOrEmpty(value)) return string.Empty;

            string format = field.Attribute("Format").Value;

            switch (field.Attribute("Type").Value)
            {
                case "User":
                case "Lookup":
                case "LookupMulti":
                case "Calculated":
                case "Number":
                    value = GetCleanValueFromFormatted(value);

                    if (format.Equals("NoDecimal"))
                        value = double.Parse(value, new CultureInfo("en-US")).ToString("N0", cultureInfo);
                    else if (format.Equals("TwoDecimals"))
                        value = double.Parse(value, new CultureInfo("en-US")).ToString("N2", cultureInfo);
                    break;
            }

            return value;
        }

        /// <summary>
        /// Gets the config web.
        /// </summary>
        /// <param name="theWeb">The web.</param>
        /// <param name="lockedWeb">The locked web.</param>
        /// <returns></returns>
        internal static SPWeb GetConfigWeb(SPWeb theWeb, Guid lockedWeb)
        {
            return (theWeb.ID != lockedWeb
                        ? theWeb.Site.OpenWeb(lockedWeb)
                        : theWeb.Site.OpenWeb(theWeb.ID));
        }

        /// <summary>
        /// Gets the field properties.
        /// </summary>
        /// <param name="spList">The sp list.</param>
        /// <returns></returns>
        internal static Dictionary<string, Dictionary<string, string>> GetFieldProperties(SPList spList)
        {
            GridGanttSettings gSettings = new GridGanttSettings(spList);
            return ListDisplayUtils.ConvertFromString(gSettings.DisplaySettings);
        }

        /// <summary>
        /// Gets the field types.
        /// </summary>
        /// <returns></returns>
        internal static Dictionary<string, SPField> GetFieldTypes()
        {
            var fieldTypes = new Dictionary<string, SPField>();

            using (SPWeb configWeb = GetConfigWeb())
            {
                foreach (
                    SPField field in configWeb.Lists[MyWorkList].Fields.Cast<SPField>().Where(field => !field.Hidden))
                {
                    fieldTypes.Add(field.InternalName, field);
                }
            }
            return fieldTypes;
        }

        /// <summary>
        /// Gets the field values.
        /// </summary>
        /// <param name="xElement">The xml element.</param>
        /// <returns></returns>
        internal static Dictionary<string, string> GetFieldValues(XElement xElement)
        {
            if (!xElement.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("Fields")))
                throw new Exception("Cannot find element: Fields");

            if (!xElement.Element("Fields").Descendants().ToList().Exists(e => e.Name.LocalName.Equals("Field")))
                throw new Exception("Cannot find element: Field");

            var dictionary = new Dictionary<string, string>();

            foreach (XElement element in xElement.Element("Fields").Elements("Field"))
            {
                string field = element.Attribute("Name").Value;

                if (!dictionary.ContainsKey(field)) dictionary.Add(field, element.Value);
            }

            return dictionary;
        }

        /// <summary>
        /// Gets the item list web site.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="element">The element.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="listId">The list id.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="siteId">The site id.</param>
        /// <param name="siteUrl">The site URL.</param>
        internal static void GetItemListWebSite(string data, XElement element, out int itemId, out Guid listId,
                                                out Guid webId, out Guid siteId, out string siteUrl)
        {
            ValidateItemListWebAndSite(element);

            itemId = int.Parse(element.Element("Item").Attribute("ID").Value);
            listId = new Guid(element.Element("List").Attribute("ID").Value);
            webId = new Guid(element.Element("Web").Attribute("ID").Value);
            siteId = new Guid(element.Element("Site").Attribute("ID").Value);
            siteUrl = element.Element("Site").Attribute("URL").Value;
        }

        /// <summary>
        /// Gets the list web site.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="element">The element.</param>
        /// <param name="listId">The list id.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="siteId">The site id.</param>
        /// <param name="siteUrl">The site URL.</param>
        internal static void GetListWebSite(string data, XElement element, out Guid listId, out Guid webId,
                                            out Guid siteId, out string siteUrl)
        {
            ValidateListWebAndSite(element);

            listId = new Guid(element.Element("List").Attribute("ID").Value);
            webId = new Guid(element.Element("Web").Attribute("ID").Value);
            siteId = new Guid(element.Element("Site").Attribute("ID").Value);
            siteUrl = element.Element("Site").Attribute("URL").Value;
        }

        /// <summary>
        /// Gets the type of the related grid.
        /// </summary>
        /// <param name="sPField">The s P field.</param>
        /// <returns></returns>
        internal static string GetRelatedGridType(SPField sPField)
        {
            switch (sPField.Type)
            {
                case SPFieldType.Text:
                case SPFieldType.Invalid:
                    return "Text";
                case SPFieldType.Integer:
                    return "Float";
                case SPFieldType.Number:
                case SPFieldType.Currency:
                    return "Float";
                case SPFieldType.DateTime:
                    return "Date";
                case SPFieldType.Boolean:
                    return "Bool";
                case SPFieldType.Note:
                    return "Lines";
                case SPFieldType.URL:
                    return "Link";
                case SPFieldType.User:
                case SPFieldType.Lookup:
                case SPFieldType.MultiChoice:
                case SPFieldType.Choice:
                    return "Enum";
                case SPFieldType.Calculated:
                    return sPField.Description.Equals("Indicator") ? "Icon" : "Html";
                default:
                    return "Html";
            }
        }

        /// <summary>
        /// Converts the grid safe field name to the original field name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        internal static string ToOriginalFieldName(string name)
        {
            return ReservedWords.Aggregate(name,
                                           (current, reservedWord) => current.Replace("__" + reservedWord, reservedWord));
        }

        /// <summary>
        /// Validates the item list web and site.
        /// </summary>
        /// <param name="element">The element.</param>
        internal static void ValidateItemListWebAndSite(XElement element)
        {
            if (!element.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("Item")))
                throw new Exception("Cannot find element: Item");
            if (!element.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("List")))
                throw new Exception("Cannot find element: List");
            if (!element.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("Web")))
                throw new Exception("Cannot find element: Web");
            if (!element.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("Site")))
                throw new Exception("Cannot find element: Site");

            if (!element.Element("Item").Attributes().ToList().Exists(a => a.Name.LocalName.Equals("ID")))
                throw new Exception("Cannot find attribute ID for element Item");
            if (!element.Element("List").Attributes().ToList().Exists(a => a.Name.LocalName.Equals("ID")))
                throw new Exception("Cannot find attribute ID for element List");
            if (!element.Element("Web").Attributes().ToList().Exists(a => a.Name.LocalName.Equals("ID")))
                throw new Exception("Cannot find attribute ID for element Web");
            if (!element.Element("Site").Attributes().ToList().Exists(a => a.Name.LocalName.Equals("ID")))
                throw new Exception("Cannot find attribute ID for element Site");
            if (!element.Element("Site").Attributes().ToList().Exists(a => a.Name.LocalName.Equals("URL")))
                throw new Exception("Cannot find attribute URL for element Site");
        }

        /// <summary>
        /// Validates the list web and site.
        /// </summary>
        /// <param name="element">The element.</param>
        internal static void ValidateListWebAndSite(XElement element)
        {
            if (!element.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("List")))
                throw new Exception("Cannot find element: List");
            if (!element.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("Web")))
                throw new Exception("Cannot find element: Web");
            if (!element.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("Site")))
                throw new Exception("Cannot find element: Site");

            if (!element.Element("List").Attributes().ToList().Exists(a => a.Name.LocalName.Equals("ID")))
                throw new Exception("Cannot find attribute ID for element List");
            if (!element.Element("Web").Attributes().ToList().Exists(a => a.Name.LocalName.Equals("ID")))
                throw new Exception("Cannot find attribute ID for element Web");
            if (!element.Element("Site").Attributes().ToList().Exists(a => a.Name.LocalName.Equals("ID")))
                throw new Exception("Cannot find attribute ID for element Site");
            if (!element.Element("Site").Attributes().ToList().Exists(a => a.Name.LocalName.Equals("URL")))
                throw new Exception("Cannot find attribute URL for element Site");
        }

        #endregion Methods
    }
}