using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Queries my work data.
        /// </summary>
        /// <param name="dataQuery">The data query.</param>
        /// <param name="siteUrl">The site URL.</param>
        /// <param name="webId">The web id.</param>
        /// <param name="userToken">The user token.</param>
        /// <returns></returns>
        private static DataTable QueryMyWorkData(
            SPSiteDataQuery dataQuery,
            string siteUrl,
            Guid webId,
            SPUserToken userToken)
        {
            Guard.ArgumentIsNotNull(dataQuery, nameof(dataQuery));

            DataTable dataTable = null;

            using (var spSite = new SPSite(siteUrl, userToken))
            {
                using (var spWeb = spSite.OpenWeb(webId))
                {
                    SPSecurity.RunWithElevatedPrivileges(() => dataTable = spWeb.GetSiteData(dataQuery));
                }
            }

            return dataTable;
        }

        /// <summary>
        ///     Updates my work item.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string UpdateMyWorkItem(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement(MyWorkItem));

                result.Element(MyWorkItem).Add(new XElement(Fields));
                var fieldsElement = result.Element(MyWorkItem).Element(Fields);

                result.Element(MyWorkItem).Add(new XElement(Messages));
                var messagesElement = result.Element(MyWorkItem).Element(Messages);

                int itemId;
                Guid listId;
                Guid webId;
                Guid siteId;
                string siteUrl;

                Utils.GetItemListWebSite(
                    data,
                    GetMyWorkItemElement(data),
                    out itemId,
                    out listId,
                    out webId,
                    out siteId,
                    out siteUrl);

                AddMessagesElement(data, itemId, listId, webId, siteId, siteUrl, messagesElement);
                AddDateTimeFieldElements(itemId, listId, webId, siteId, siteUrl, fieldsElement);

                return result.ToString();
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2050, exception.Message);
            }
        }

        private static void AddMessagesElement(
            string data,
            int itemId,
            Guid listId,
            Guid webId,
            Guid siteId,
            string siteUrl,
            XElement messagesElement)
        {
            Guard.ArgumentIsNotNull(messagesElement, nameof(messagesElement));

            var fieldValues =
                Utils.GetFieldValues(XDocument.Parse(data).Element(MyWorkItem));

            var originalFieldValues =
                fieldValues.ToDictionary(
                    fieldValue => Utils.ToOriginalFieldName(fieldValue.Key),
                    fieldValue => fieldValue.Value);

            var listItemDocument = new XDocument();
            listItemDocument.Add(new XElement(ListItemsText));
            listItemDocument.Element(ListItemsText).Add(new XElement(ListItemText));

            var listItemElement = listItemDocument.Element(ListItemsText).Element(ListItemText);
            Utils.AddItemListWebSiteToXElement(itemId, listId, webId, siteId, siteUrl, ref listItemElement);

            listItemElement.Add(new XElement(Fields));
            var listItemFieldsElement = listItemElement.Element(Fields);

            foreach (var originalFieldValue in originalFieldValues)
            {
                var fieldElement = new XElement(Field, new XCData(originalFieldValue.Value));
                fieldElement.Add(new XAttribute(Name, originalFieldValue.Key));
                listItemFieldsElement.Add(fieldElement);
            }

            if (listItemFieldsElement.Elements(Field).Count() > 0)
            {
                var updateListItemDocument =
                    XDocument.Parse(ListItem.UpdateListItem(listItemDocument.ToString()));

                foreach (var xElement in updateListItemDocument.Element(ListItemsText)
                   .Element(ListItemText)
                   .Element(Messages)
                   .Elements(Message)
                   .Select(element => new XElement(Message, new XCData(element.Value))))
                {
                    messagesElement.Add(xElement);
                }
            }
        }

        private static void AddDateTimeFieldElements(int itemId, Guid listId, Guid webId, Guid siteId, string siteUrl, XElement fieldsElement)
        {
            Guard.ArgumentIsNotNull(fieldsElement, nameof(fieldsElement));

            var getItemDocument = new XDocument();
            getItemDocument.Add(new XElement(ListItemText));

            var getListItemElement = getItemDocument.Element(ListItemText);
            Utils.AddItemListWebSiteToXElement(itemId, listId, webId, siteId, siteUrl, ref getListItemElement);

            var getListItemDocument = XDocument.Parse(ListItem.GetListItem(getItemDocument.ToString()));

            foreach (var element in getListItemDocument.Element(ListItemText).Element(Fields).Elements(Field))
            {
                var name = element.Attribute(Name).Value;
                var value = GetGridSafeValue(element);
                var dateTime = DateTime.MinValue;

                if (element.Attribute(Type).Value.Contains(Date))
                {
                    dateTime = DateTime.Parse(value);
                    value = dateTime.ToString(MonthDateYearFormat, CultureInfo.InvariantCulture);
                }

                var xElement = new XElement(Field, new XCData(value));
                xElement.Add(new XAttribute(Name, Utils.ToGridSafeFieldName(name)));

                if (name.Equals(DueDateField) && !string.IsNullOrWhiteSpace(value))
                {
                    var dueDayElement = new XElement(Field, new XCData(dateTime.ToFriendlyDate()));
                    dueDayElement.Add(new XAttribute(Name, DueDayField));

                    fieldsElement.Add(dueDayElement);
                }

                fieldsElement.Add(xElement);
            }
        }
    }
}