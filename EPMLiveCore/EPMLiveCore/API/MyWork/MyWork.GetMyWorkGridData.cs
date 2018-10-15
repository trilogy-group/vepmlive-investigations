using System;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using EPMLiveCore.Helpers;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Gets my work grid data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetMyWorkGridData(string data)
        {
            try
            {
                var getMyWork = string.Empty;

                try
                {
                    getMyWork = GetMyWork(HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(data)));
                }
                catch (APIException apiException)
                {
                    return $@"<Grid><IO Result=""-{apiException.ExceptionNumber}"" Message=""{apiException.Message}"" /></Grid>";
                }

                var result = new XDocument();
                result.Add(new XElement(Grid));
                var grid = result.Element(Grid);

                GetSettings(HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(data)));

                grid.Add(new XElement(Body));
                grid.Element(Body).Add(new XElement(BField));

                AddBodyXElement(grid, getMyWork);

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
                throw new APIException(2020, exception.Message);
            }
        }

        private static void AddBodyXElement(XElement grid, string getMyWork)
        {
            Guard.ArgumentIsNotNull(grid, nameof(grid));

            var body = grid.Element(Body).Element(BField);
            var myWorkDocument = XDocument.Parse(getMyWork);
            bool processFlag;
            bool.TryParse(myWorkDocument.Root.Element(Params).Element(ProcessFlag).Value, out processFlag);

            foreach (var item in myWorkDocument.Element(MyWork1).Elements(Item))
            {
                string itemId;
                string listId;
                string webId;
                string siteId;
                string siteUrl;
                var xElement = AddXElement(item, out itemId, out listId, out webId, out siteId, out siteUrl);

                xElement.Add(
                    new XAttribute(
                        WorkingOnField,
                        bool.Parse(item.Attribute(WorkingOnField).Value)
                            ? 1
                            : 0));
                xElement.Add(new XAttribute(WorkTypeField, item.Attribute(WorkTypeField).Value));
                xElement.Add(new XAttribute(Workspace, item.Attribute(Workspace).Value));

                ProcessFlagField(processFlag, itemId, listId, webId, siteId, siteUrl, xElement);

                xElement.Attribute(Edit)?.Remove();
                xElement.Add(new XAttribute(Edit, string.Empty));
                xElement.Attribute(ItemIdText)?.Remove();
                xElement.Attribute(ListIdText)?.Remove();
                xElement.Attribute(WebIdText)?.Remove();
                xElement.Attribute(SiteIdText)?.Remove();
                xElement.Attribute(SiteUrlText)?.Remove();

                xElement.Add(new XAttribute(ItemIdText, itemId));
                xElement.Add(new XAttribute(ListIdText, listId));
                xElement.Add(new XAttribute(WebIdText, webId));
                xElement.Add(new XAttribute(SiteIdText, siteId));
                xElement.Add(new XAttribute(SiteUrlText, siteUrl));

                xElement.Attribute(MaxHeight)?.Remove();
                xElement.Add(new XAttribute(MaxHeight, 30));
                body.Add(xElement);
            }
        }

        private static XElement AddXElement(XElement item, out string itemId, out string listId, out string webId, out string siteId, out string siteUrl)
        {
            Guard.ArgumentIsNotNull(item, nameof(item));

            var xElement = new XElement(IText);
            itemId = item.Attribute(IdText).Value;
            listId = item.Attribute(ListIdText).Value;
            webId = item.Attribute(WebIdText).Value;
            siteId = item.Attribute(SiteIdText).Value;
            siteUrl = item.Attribute(SiteUrlText).Value;
            var rowId = $"{itemId}-{listId}-{webId}-{siteId}".Md5();

            xElement.Add(new XAttribute(Id, rowId));

            foreach (var field in item.Element(Fields).Elements(Field))
            {
                var name = Utils.ToGridSafeFieldName(field.Attribute(Name).Value);
                var value = GetGridSafeValue(field);
                var type = field.Attribute(Type).Value;

                if (type.Equals(Choice) && !string.IsNullOrWhiteSpace(value))
                {
                    var enumKeys = $"|{value}";
                    xElement.Add(new XAttribute($"{name}Enum", enumKeys));
                    xElement.Add(new XAttribute($"{name}EnumKeys", enumKeys));
                    xElement.Add(new XAttribute($"{name}Range", 0));
                }

                if (name.Equals(DueDateField) && !string.IsNullOrWhiteSpace(value))
                {
                    xElement.Add(new XAttribute(DueDayField, Convert.ToDateTime(value).ToFriendlyDate()));
                }

                xElement.Add(new XAttribute(name, value));
            }

            return xElement;
        }

        private static void ProcessFlagField(bool processFlag, string itemId, string listId, string webId, string siteId, string siteUrl, XElement xElement)
        {
            Guard.ArgumentIsNotNull(xElement, nameof(xElement));

            if (processFlag)
            {
                var flagQuery =
                    $@"<MyPersonalization><Keys>Flag</Keys><Item ID=""{itemId}""/><List ID=""{listId}""/><Web ID=""{webId}""/><Site ID=""{siteId}"" URL=""{siteUrl}""/></MyPersonalization>";
                var xDocument = XDocument.Parse(MyPersonalization.GetMyPersonalization(flagQuery));
                var flag = Zero;

                if (
                    xDocument.Element(MyPersonalizationText)
                       .Elements()
                       .ToList()
                       .Exists(
                            e => e.Name.LocalName.Equals(PersonalizationsField)))
                {
                    flag =
                        xDocument.Element(MyPersonalizationText)
                           .Element(PersonalizationsField)
                           .Elements()
                           .ToList()
                           .Where(e => e.Attribute(Key).Value.Equals(FlagField))
                           .FirstOrDefault()
                           .Attribute
                            (
                                Value)
                           .Value;
                }

                xElement.Attribute(FlagField)?.Remove();
                xElement.Add(new XAttribute(FlagField, flag));
            }
        }
    }
}