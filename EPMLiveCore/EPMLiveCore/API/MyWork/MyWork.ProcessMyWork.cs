using System;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Processes my work.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <param name="spSite">The sp site.</param>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="result">The result.</param>
        private static void ProcessMyWork(
            DataTable dataTable,
            SPSite spSite,
            SPWeb spWeb,
            ref XDocument result)
        {
            Guard.ArgumentIsNotNull(dataTable, nameof(dataTable));
            Guard.ArgumentIsNotNull(result, nameof(result));

            try
            {
                AddItemElements(dataTable, spSite, spWeb, result);
            }
            catch (APIException apiException)
            {
                Trace.WriteLine(apiException);
                throw;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException(2009, exception.Message);
            }
        }

        private static void AddItemElements(
            DataTable dataTable,
            SPSite spSite,
            SPWeb spWeb,
            XDocument result)
        {
            Guard.ArgumentIsNotNull(dataTable, nameof(dataTable));
            Guard.ArgumentIsNotNull(result, nameof(result));

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var listId = Utils.CleanGuid(dataRow[ListIdField]);
                var webId = Utils.CleanGuid(dataRow[WebIdField]);
                var siteUrl = spSite.Url;
                var uniqueId = (listId + webId + spSite.ID).Md5();
                var row = dataRow;
                var fieldsElement = new XElement(Fields);

                AddFieldElements(row, fieldsElement);

                var siteId = spSite.ID;

                var itemElement = new XElement(Item);
                itemElement.Add(new XAttribute(IdText, Utils.CleanGuid(dataRow[IdText]).ToUpper()));
                itemElement.Add(new XAttribute(ListIdText, listId.ToUpper()));
                itemElement.Add(new XAttribute(WebIdText, webId.ToUpper()));
                itemElement.Add(new XAttribute(SiteIdText, siteId.ToString().ToUpper()));
                itemElement.Add(new XAttribute(SiteUrlText, siteUrl));

                if (!GetMyWorkParams.WorkTypes.ContainsKey(uniqueId))
                {
                    GetMyWorkParams.WorkTypes.Add(uniqueId, GetListNameFromDb(new Guid(listId), new Guid(webId), spWeb));
                }

                itemElement.Add(new XAttribute(WorkTypeField, GetMyWorkParams.WorkTypes[uniqueId]));

                if (!GetMyWorkParams.WorkSpaces.ContainsKey(uniqueId))
                {
                    GetMyWorkParams.WorkSpaces.Add(uniqueId, GetWorkspaceNameFromDb(new Guid(webId), siteUrl));
                }

                itemElement.Add(new XAttribute(Workspace, GetMyWorkParams.WorkSpaces[uniqueId]));
                itemElement.Add(fieldsElement);
                itemElement.Add(new XAttribute(WorkingOnField, row[WorkingOnField]));

                result.Element(nameof(MyWork)).Add(itemElement);
            }
        }

        private static void AddFieldElements(
            DataRow row,
            XElement fieldsElement)
        {
            Guard.ArgumentIsNotNull(row, nameof(row));
            Guard.ArgumentIsNotNull(fieldsElement, nameof(fieldsElement));

            foreach (var selectedField in GetMyWorkParams.SelectedFields)
            {
                var value = row[selectedField] == null || row[selectedField] == DBNull.Value
                    ? string.Empty
                    : row[selectedField].ToString();
                Action<string, string, string, string> addFieldElement = (fieldValue, nameValue, typeValue, formatValue) =>
                {
                    var xElement = new XElement(Field, new XCData(fieldValue));
                    xElement.Add(new XAttribute(Name, nameValue));
                    xElement.Add(new XAttribute(Type, typeValue));
                    xElement.Add(new XAttribute(Format, formatValue));

                    fieldsElement.Add(xElement);
                };

                if (selectedField.Equals(Author))
                {
                    var authorId = string.Empty;

                    if (!string.IsNullOrWhiteSpace(authorId))
                    {
                        authorId = value.Split(CharSemiColon)[0];
                    }

                    addFieldElement(authorId, AuthorId, string.Empty, string.Empty);
                }

                string type;
                string format;

                GetTypeAndFormat(GetMyWorkParams.FieldTypes, selectedField, out type, out format);

                if (type == BooleanText)
                {
                    value = value.Equals(bool.TrueString)
                        ? Zero
                        : One;
                }

                addFieldElement(value, selectedField, type, format);
            }
        }
    }
}