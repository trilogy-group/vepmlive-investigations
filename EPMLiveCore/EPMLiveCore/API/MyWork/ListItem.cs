using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore.API
{
    internal class ListItem
    {
        #region Methods (5) 

        // Private Methods (2) 

        /// <summary>
        /// Gets the list item element.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static XElement GetListItemElement(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new APIException(6051, "No parameters specified.");

            XDocument xDocument = XDocument.Parse(data);

            if (!xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("ListItem")))
                throw new APIException(6052, "Cannot find element: ListItem");

            return xDocument.Element("ListItem");
        }

        /// <summary>
        /// Gets the list item elements.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static IEnumerable<XElement> GetListItemElements(string data)
        {
            if (string.IsNullOrEmpty(data)) throw new APIException(6053, "No parameters specified.");

            XDocument xDocument = XDocument.Parse(data);

            if (!xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("ListItems")))
                throw new APIException(6054, "Cannot find element: ListItems");

            if (!xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals("ListItem")))
                throw new APIException(6055, "Cannot find element: ListItem");

            return xDocument.Element("ListItems").Elements("ListItem");
        }

        // Internal Methods (3) 

        /// <summary>
        /// Gets the list item.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetListItem(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("ListItem"));

                int itemId;
                Guid listId;
                Guid webId;
                Guid siteId;
                string siteUrl;

                Utils.GetItemListWebSite(data, GetListItemElement(data), out itemId, out listId, out webId, out siteId,
                                         out siteUrl);

                XElement listItemElement = result.Element("ListItem");
                Utils.AddItemListWebSiteToXElement(itemId, listId, webId, siteId, siteUrl, ref listItemElement);

                SPWeb web = SPContext.Current.Web;
                SPUser currentUser = web.CurrentUser;
                SPRegionalSettings currentContextRegionalSettings = currentUser.RegionalSettings ?? web.RegionalSettings;

                using (var spSite = new SPSite(siteUrl))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(webId))
                    {
                        SPRegionalSettings spRegionalSettings = spWeb.CurrentUser.RegionalSettings ?? spWeb.RegionalSettings;

                        listItemElement.Add(new XElement("Fields"));
                        XElement fieldsElement = listItemElement.Element("Fields");

                        SPList spList = spWeb.Lists[listId];

                        SPListItem spListItem = spList.Items.GetItemById(itemId);

                        foreach (
                            SPField field in
                                spListItem.Fields.Cast<SPField>().Where(
                                    field =>
                                    !field.Hidden || field.InternalName.Equals("CommentCount") ||
                                    field.InternalName.Equals("Commenters") ||
                                    field.InternalName.Equals("CommentersRead")))
                        {
                            try
                            {
                                string value = spListItem[field.Id].ToString();

                                if (field.Type == SPFieldType.Number||field.Type==SPFieldType.Currency)
                                {
                                    if (!string.IsNullOrEmpty(value))
                                    {
                                        try
                                        {
                                            value = Decimal.Parse(value,
                                                new CultureInfo((int)currentContextRegionalSettings.LocaleId))
                                                .ToString(CultureInfo.InvariantCulture);
                                        }
                                        catch
                                        {
                                        }
                                    }

                                    if (field.Type != SPFieldType.Currency && ((SPFieldNumber) field).ShowAsPercentage)
                                        value = (double.Parse(value)*100).ToString(CultureInfo.InvariantCulture);
                                }
                                else if (field.Type == SPFieldType.DateTime)
                                {
                                    if (!string.IsNullOrEmpty(value))
                                    {
                                        DateTime dateTime = currentContextRegionalSettings
                                            .TimeZone.UTCToLocalTime(spRegionalSettings.TimeZone
                                            .LocalTimeToUTC(DateTime.Parse(value)));

                                        value = dateTime.ToString("MMM dd, yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                                    }
                                }

                                var fieldElement = new XElement("Field", new XCData(value));
                                fieldElement.Add(new XAttribute("Name", field.InternalName));
                                fieldElement.Add(new XAttribute("Type", field.Type));
                                fieldElement.Add(new XAttribute("Format", Utils.GetFormat(field)));

                                fieldsElement.Add(fieldElement);
                            }
                            catch
                            {
                            }
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
                throw new APIException(6060, e.Message);
            }
        }

        /// <summary>
        /// Determines whether [is moderation enabled] [the specified list].
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string IsModerationEnabled(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("ListItems"));

                foreach (XElement xElement in GetListItemElements(data))
                {
                    var listItemElement = new XElement("ListItem");

                    int itemId;
                    Guid listId;
                    Guid webId;
                    Guid siteId;
                    string siteUrl;

                    Utils.GetItemListWebSite(data, xElement, out itemId, out listId, out webId, out siteId, out siteUrl);

                    Utils.AddItemListWebSiteToXElement(itemId, listId, webId, siteId, siteUrl, ref listItemElement);

                    listItemElement.Add(new XElement("Messages"));
                    XElement messagesElement = listItemElement.Element("Messages");

                    try
                    {
                        using (var spSite = new SPSite(siteUrl))
                        {
                            using (SPWeb spWeb = spSite.OpenWeb(webId))
                            {
                                listItemElement.Add(new XElement("ModerationEnabled",
                                                                 spWeb.Lists[listId].EnableModeration));
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        messagesElement.Add(new XElement("Message", new XCData(exception.Message)));
                    }

                    result.Element("ListItems").Add(listItemElement);
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(6070, e.Message);
            }
        }

        /// <summary>
        /// Updates the list item.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string UpdateListItem(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement("ListItems"));

                foreach (XElement xElement in GetListItemElements(data))
                {
                    var listItemElement = new XElement("ListItem");

                    int itemId;
                    Guid listId;
                    Guid webId;
                    Guid siteId;
                    string siteUrl;

                    Utils.GetItemListWebSite(data, xElement, out itemId, out listId, out webId, out siteId, out siteUrl);

                    Utils.AddItemListWebSiteToXElement(itemId, listId, webId, siteId, siteUrl, ref listItemElement);

                    listItemElement.Add(new XElement("Messages"));
                    XElement messagesElement = listItemElement.Element("Messages");

                    try
                    {
                        SPWeb web = SPContext.Current.Web;
                        SPUser currentUser = web.CurrentUser;
                        SPRegionalSettings currentContextRegionalSettings = currentUser.RegionalSettings ?? web.RegionalSettings;

                        Dictionary<string, string> fieldValues = Utils.GetFieldValues(xElement);

                        using (var spSite = new SPSite(siteUrl,web.Site.RootWeb.AllUsers[currentUser.LoginName].UserToken))
                        {
                            using (SPWeb spWeb = spSite.OpenWeb(webId))
                            {
                                SPRegionalSettings spRegionalSettings = spWeb.CurrentUser.RegionalSettings ?? spWeb.RegionalSettings;

                                spWeb.AllowUnsafeUpdates = true;

                                SPList spList = spWeb.Lists[listId];

                                SPListItem spListItem = spList.Items.GetItemById(itemId);

                                Dictionary<string, Dictionary<string, string>> fieldProperties =
                                    Utils.GetFieldProperties(spList);

                                #region Update List Item

                                foreach (var fieldValue in fieldValues)
                                {
                                    string theField = fieldValue.Key;
                                    string theValue = fieldValue.Value;

                                    if (!spList.Fields.ContainsFieldWithInternalName(theField))
                                    {
                                        messagesElement.Add(new XElement("Message",
                                                                         new XCData(
                                                                             string.Format(
                                                                                 "Cannot find a field with internal name: {0} in the list.",
                                                                                 theField))));
                                        continue;
                                    }

                                    if (spList.Fields.GetFieldByInternalName(theField).ReadOnlyField)
                                    {
                                        messagesElement.Add(new XElement("Message",
                                                                         new XCData(
                                                                             string.Format(
                                                                                 "{0} is a read-only field. Value will not be updated.",
                                                                                 theField))));
                                        continue;
                                    }

                                    if (!theField.Equals("Complete") && !theField.Equals("CommentCount") &&
                                        !theField.Equals("Commenters") && !theField.Equals("CommentersRead"))
                                    {
                                        if (
                                            !EditableFieldDisplay.isEditable(spListItem,
                                                                             spListItem.Fields.GetFieldByInternalName(
                                                                                 theField), fieldProperties))
                                        {
                                            messagesElement.Add(new XElement("Message",
                                                                             new XCData(
                                                                                 string.Format(
                                                                                     "{0} is not an editable field. The value for {0} will not be updated.",
                                                                                     theField))));
                                            continue;
                                        }
                                    }

                                    SPField spField = spListItem.Fields.GetFieldByInternalName(theField);
                                    if (spField.Type == SPFieldType.Number)
                                    {
                                        if (((SPFieldNumber) spField).ShowAsPercentage)
                                            theValue = (double.Parse(theValue, new CultureInfo("en-US")) / 100).ToString(CultureInfo.InvariantCulture);
                                    }
                                    else if (spField.Type == SPFieldType.DateTime)
                                    {
                                        var dateTime = new DateTime((Convert.ToInt64(theValue)*10000) + 621355968000000000);
                                        DateTime localTimeToUtc = currentContextRegionalSettings.TimeZone.LocalTimeToUTC(dateTime);
                                        DateTime utcToLocalTime = spRegionalSettings.TimeZone.UTCToLocalTime(localTimeToUtc);

                                        theValue = utcToLocalTime.ToString(CultureInfo.InvariantCulture);
                                    }

                                    spListItem[theField] = theValue;
                                }

                                #endregion

                                spListItem.Update();
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        messagesElement.Add(new XElement("Message", new XCData(exception.Message)));
                    }

                    result.Element("ListItems").Add(listItemElement);
                }

                return result.ToString();
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(6050, e.Message);
            }
        }

        #endregion Methods 
    }
}