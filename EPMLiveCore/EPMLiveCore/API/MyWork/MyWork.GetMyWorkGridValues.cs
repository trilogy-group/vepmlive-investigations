using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Gets the type of my work grid col.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetMyWorkGridColType(string data)
        {
            return GetMyWorkGrid(data, AddElementGridColType, 2060);
        }

        private static string GetMyWorkGrid(string data, Action<SPListItem, SPSite, XElement, XElement, string> addElementGrid, int exceptionNumber)
        {
            Guard.ArgumentIsNotNull(addElementGrid, nameof(addElementGrid));

            try
            {
                var result = new XDocument();
                result.Add(new XElement(nameof(MyWork)));

                int itemId;
                Guid listId;
                Guid webId;
                Guid siteId;
                string siteUrl;

                var myWorkElement = GetMyWorkElement(data);
                Utils.GetItemListWebSite(data, myWorkElement, out itemId, out listId, out webId, out siteId, out siteUrl);

                result.Element(nameof(MyWork)).Add(new XElement(Fields));

                var xElement = result.Element(nameof(MyWork)).Element(Fields);
                xElement.Add(new XAttribute(ItemIdText, itemId));
                xElement.Add(new XAttribute(ListIdText, listId));
                xElement.Add(new XAttribute(WebIdText, webId));
                xElement.Add(new XAttribute(SiteIdText, siteId));
                xElement.Add(new XAttribute(SiteUrlText, siteUrl));

                var guessOriginalFieldNameSetting = FieldInfo.GetGuessOriginalFieldNameSetting(myWorkElement);

                using (var spSite = new SPSite(siteUrl))
                {
                    using (var spWeb = spSite.OpenWeb(webId))
                    {
                        var spList = spWeb.Lists[listId];
                        var spListItem = spList.GetItemById(itemId);

                        foreach (var field in FieldInfo.GetFields(myWorkElement))
                        {
                            var theField = field;

                            if (guessOriginalFieldNameSetting)
                            {
                                theField = Utils.ToOriginalFieldName(theField);
                            }

                            if (!spListItem.Fields.ContainsFieldWithInternalName(theField))
                            {
                                continue;
                            }

                            var element = new XElement(Field);
                            element.Add(new XAttribute(Name, theField));

                            addElementGrid(spListItem, spSite, myWorkElement, element, theField);
                            xElement.Add(element);
                        }
                    }
                }

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
                throw new APIException(exceptionNumber, exception.Message);
            }
        }

        private static void AddElementGridColType(SPListItem spListItem, SPSite spSite, XElement myWorkElement, XElement element, string theField)
        {
            Guard.ArgumentIsNotNull(myWorkElement, nameof(myWorkElement));
            Guard.ArgumentIsNotNull(element, nameof(element));
            Guard.ArgumentIsNotNull(spListItem, nameof(spListItem));

            var isFromMyTimeSheet =
                myWorkElement.Descendants().ToList().Exists(e => e.Name.LocalName.Equals(IsFromMyTimeSheetText)) &&
                bool.Parse(myWorkElement.Element(IsFromMyTimeSheetText).Value);
            element.Add(
                new XAttribute(
                    Type,
                    isFromMyTimeSheet
                        ? Utils.GetRelatedGridTypeForMyTimesheet(spListItem.Fields.GetFieldByInternalName(theField))
                        : Utils.GetRelatedGridType(spListItem.Fields.GetFieldByInternalName(theField))));
        }

        /// <summary>
        ///     Gets my work grid enum.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetMyWorkGridEnum(string data)
        {
            return GetMyWorkGrid(data, AddElementGridEnum, 2070);
        }

        private static void AddElementGridEnum(SPListItem spListItem, SPSite spSite, XElement myWorkElement, XElement element, string theField)
        {
            Guard.ArgumentIsNotNull(spListItem, nameof(spListItem));
            Guard.ArgumentIsNotNull(spSite, nameof(spSite));
            Guard.ArgumentIsNotNull(element, nameof(element));

            var spField = spListItem.Fields.GetFieldByInternalName(theField);

            string values;
            int range;
            string keys;

            Utils.GetGridEnum(spSite, spField, out values, out range, out keys);

            element.Add(new XAttribute(EnumText, $"|{values}"));
            element.Add(new XAttribute(EnumKeys, $"|{keys}"));
            element.Add(new XAttribute(RangeText, range));
        }
    }
}