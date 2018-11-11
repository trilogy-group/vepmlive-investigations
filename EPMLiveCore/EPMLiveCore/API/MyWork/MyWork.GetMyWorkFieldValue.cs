using System;
using System.Collections.Generic;
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
        ///     Gets my work element.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static XElement GetMyWorkElement(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new APIException(2061, NoParametersSpecified);
            }

            var xDocument = XDocument.Parse(data);

            if (!xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals(nameof(MyWork))))
            {
                throw new APIException(2062, CannotFindElementMyWork);
            }

            return xDocument.Element(nameof(MyWork));
        }

        /// <summary>
        ///     Gets my work field value.
        /// </summary>
        /// <param name="myWorkField">My work field.</param>
        /// <param name="myWorkDataRow">My work data row.</param>
        /// <param name="colDict">The col dict.</param>
        /// <param name="fieldsTableRows">The fields table rows.</param>
        /// <param name="flagsTable">The flags table.</param>
        /// <returns></returns>
        private static object GetMyWorkFieldValue(
            string myWorkField,
            DataRow myWorkDataRow,
            IDictionary<string, int> colDict,
            EnumerableRowCollection<DataRow> fieldsTableRows,
            DataTable flagsTable)
        {
            Guard.ArgumentIsNotNull(myWorkDataRow, nameof(myWorkDataRow));
            Guard.ArgumentIsNotNull(colDict, nameof(colDict));
            Guard.ArgumentIsNotNull(flagsTable, nameof(flagsTable));

            object tempValue;

            var listId = myWorkDataRow[ListId];

            if (!myWorkField.Equals(Flag, StringComparison.OrdinalIgnoreCase))
            {
                var colInfo = colDict[myWorkField];
                tempValue = ProcessFieldValue(myWorkField, myWorkDataRow, fieldsTableRows, colInfo, listId);
            }
            else
            {
                tempValue = 0;

                var result = flagsTable.Rows.Find(new[] { listId, myWorkDataRow[ItemId] });

                if (result != null)
                {
                    tempValue = result[Value];

                    if (tempValue == null || tempValue == DBNull.Value)
                    {
                        tempValue = 0;
                    }
                }
            }

            return tempValue;
        }

        private static object ProcessFieldValue(
            string myWorkField,
            DataRow myWorkDataRow,
            EnumerableRowCollection<DataRow> fieldsTableRows,
            int colInfo,
            object listId)
        {
            Guard.ArgumentIsNotNull(myWorkDataRow, nameof(myWorkDataRow));
            object tempValue = null;

            if (colInfo == 1)
            {
                tempValue = myWorkDataRow[myWorkField];
            }
            else if (colInfo == 2)
            {
                var lstId = new Guid(listId.ToString());
                var workField = myWorkField;

                var field = (from dataRow in fieldsTableRows
                    where
                        dataRow.Field<Guid>(ListId) == lstId &&
                        dataRow.Field<string>(InternalName).Equals(workField)
                    select dataRow).FirstOrDefault();

                if (field != null)
                {
                    var spType = field[SharePointType].ToString();

                    if (spType.Equals(Lookup) || spType.Equals(User))
                    {
                        var idValue = myWorkDataRow[$"{myWorkField}{IdText}"];
                        var textValue = myWorkDataRow[$"{myWorkField}{TextId}"];

                        if (idValue == null ||
                            idValue == DBNull.Value ||
                            textValue == null ||
                            textValue == DBNull.Value)
                        {
                            tempValue = string.Empty;
                        }
                        else
                        {
                            var ids = idValue.ToString().Split(CharComma);
                            var values = textValue.ToString().Split(CharComma);
                            var list = new List<string>();

                            for (var i = 0; i < ids.Length; i++)
                            {
                                try
                                {
                                    list.Add(ids[i]);
                                    list.Add(values[i]);
                                }
                                catch (Exception exception)
                                {
                                    Trace.WriteLine(exception);
                                }
                            }

                            tempValue = string.Join(SemiColonHash, list.ToArray());
                        }
                    }
                }
            }

            return tempValue;
        }

        /// <summary>
        ///     Gets my work item element.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static XElement GetMyWorkItemElement(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new APIException(2051, NoParametersSpecified);
            }

            var xDocument = XDocument.Parse(data);

            if (!xDocument.Descendants().ToList().Exists(e => e.Name.LocalName.Equals(MyWorkItem)))
            {
                throw new APIException(2052, CannotFindElementMyWorkItem);
            }

            return xDocument.Element(MyWorkItem);
        }

        /// <summary>
        ///     Gets the type of my work field.
        /// </summary>
        /// <param name="myWorkField">My work field.</param>
        /// <param name="fieldTypes">The field types.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        internal static string GetMyWorkFieldType(
            MyWorkField myWorkField,
            IDictionary<string, SPField> fieldTypes,
            out string format)
        {
            Guard.ArgumentIsNotNull(myWorkField, nameof(myWorkField));
            Guard.ArgumentIsNotNull(fieldTypes, nameof(fieldTypes));

            var type = Html;
            format = string.Empty;

            if (fieldTypes.ContainsKey(myWorkField.Name))
            {
                var spField = fieldTypes[myWorkField.Name];

                type = Utils.GetRelatedGridType(spField);
                format = Utils.GetFormat(spField);
            }

            return type;
        }

        /// <summary>
        ///     Gets my work list item.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        internal static string GetMyWorkListItem(string data)
        {
            try
            {
                var result = new XDocument();
                result.Add(new XElement(nameof(MyWork)));

                var myWorkElement = result.Element(nameof(MyWork));
                var xDocument = XDocument.Parse(
                    ListItem.GetListItem(
                        data.Replace(MyWorkText1, ListItemText1)
                           .Replace(SlashMyWork, SlashListItem)
                           .Replace(MyWorkSlash, ListItemSlash)
                           .Replace(MyWorkSpaceSlash, ListItemSpaceSlash)));

                var xElement = xDocument.Element(ListItemText);
                var siteUrl = xElement.Element(Site).Attribute(UrlText).Value;
                var webId = xElement.Element(WebText).Attribute(IdText).Value;
                var listId = xElement.Element(ListText).Attribute(IdText).Value;

                myWorkElement.Add(new XElement(Item));
                myWorkElement.Element(Item).Add(new XAttribute(IdText, xElement.Element(Item).Attribute(IdText).Value));

                myWorkElement.Add(new XElement(ListText));
                myWorkElement.Element(ListText).Add(new XAttribute(IdText, listId));

                myWorkElement.Add(new XElement(WebText));
                myWorkElement.Element(WebText).Add(new XAttribute(IdText, webId));

                myWorkElement.Add(new XElement(Site));
                myWorkElement.Element(Site).Add(new XAttribute(IdText, xElement.Element(Site).Attribute(IdText).Value));
                myWorkElement.Element(Site).Add(new XAttribute(UrlText, siteUrl));

                myWorkElement.Add(new XElement(Fields));
                var fieldsElement = myWorkElement.Element(Fields);

                foreach (var field in xElement.Element(Fields).Elements(Field))
                {
                    var value = GetGridSafeValue(field);

                    if (field.Attribute(Type).Value.Contains(Date))
                    {
                        value = DateTime.Parse(value).ToString(MonthDateYearFormat, CultureInfo.InvariantCulture);
                    }

                    var element = new XElement(Field, new XCData(value));
                    element.Add(new XAttribute(Name, Utils.ToGridSafeFieldName(field.Attribute(Name).Value)));
                    fieldsElement.Add(element);
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
                throw new APIException(2015, exception.Message);
            }
        }
    }
}