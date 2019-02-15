using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Gets the data from lists.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <param name="query">The query.</param>
        /// <param name="spSite">The sp site.</param>
        /// <param name="spWeb">The sp web.</param>
        private static void GetDataFromLists(
            XDocument result,
            string query,
            SPSite spSite,
            SPWeb spWeb)
        {
            Guard.ArgumentIsNotNull(result, nameof(result));
            Guard.ArgumentIsNotNull(spSite, nameof(spSite));
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            foreach (var theWebId in from webId in spWeb.ToTreeList()
                let archivedWebs = GetArchivedWebs(spSite.ID)
                let theWebId = webId
                where !archivedWebs.Exists(wId => wId == theWebId)
                select theWebId)
            {
                using (var web = spSite.OpenWeb(theWebId))
                {
                    var workingOnDict = new Dictionary<string, List<string>>();
                    var dtWorkingOn = GetWorkingOn(web);

                    if (dtWorkingOn.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in dtWorkingOn.Rows)
                        {
                            var key = dataRow[ListId].ToString().ToUpper();
                            key = key.Replace(OpenCurlyBrace, string.Empty);
                            key = key.Replace(ClosedCurlyBrace, string.Empty);

                            if (!workingOnDict.ContainsKey(key))
                            {
                                workingOnDict.Add(key, new List<string>());
                            }

                            workingOnDict[key].Add(dataRow[ItemId].ToString());
                        }
                    }

                    ProcessSpListItemCollection(result, query, spSite, web, theWebId, workingOnDict);
                }
            }
        }

        private static void ProcessSpListItemCollection(
            XDocument result,
            string query,
            SPSite spSite,
            SPWeb web,
            Guid theWebId,
            Dictionary<string, List<string>> workingOnDict)
        {
            Guard.ArgumentIsNotNull(result, nameof(result));
            Guard.ArgumentIsNotNull(spSite, nameof(spSite));
            Guard.ArgumentIsNotNull(web, nameof(web));
            Guard.ArgumentIsNotNull(workingOnDict, nameof(workingOnDict));

            foreach (var selectedList in GetMyWorkParams.SelectedLists.Distinct().OrderBy(l => l))
            {
                var spList = web.Lists.TryGetList(selectedList);

                if (spList == null)
                {
                    continue;
                }

                var spQuery = new SPQuery { QueryThrottleMode = SPQueryThrottleOption.Override };

                var viewFieldsBuilder = new StringBuilder(spQuery.ViewFields);

                foreach (var selectedField in GetMyWorkParams.SelectedFields)
                {
                    viewFieldsBuilder.Append($@"<FieldRef Name='{selectedField}' Nullable='TRUE'/>");
                }

                if (!GetMyWorkParams.SelectedFields.Exists(f => f.Equals(CompletedField)))
                {
                    viewFieldsBuilder.Append($"<FieldRef Name='{CompletedField}' Nullable='TRUE'/>");
                }

                spQuery.ViewFields = viewFieldsBuilder.ToString();
                spQuery.Query = query;

                SPListItemCollection spListItemCollection = null;
                SPSecurity.RunWithElevatedPrivileges(
                    () => spListItemCollection = spList.GetItems(spQuery));

                if (!spListItemCollection.HasItems())
                {
                    continue;
                }

                var listContainsField = GetMyWorkParams.SelectedFields.Any(
                    selectedField =>
                        spListItemCollection.Fields.ContainsField(selectedField));

                if (!listContainsField)
                {
                    continue;
                }

                ProcessSpListItem(result, spSite, spListItemCollection, spList, theWebId, web, workingOnDict);
            }
        }

        private static void ProcessSpListItem(
            XDocument result,
            SPSite spSite,
            SPListItemCollection spListItemCollection,
            SPList spList,
            Guid theWebId,
            SPWeb web,
            IDictionary<string, List<string>> workingOnDict)
        {
            Guard.ArgumentIsNotNull(result, nameof(result));
            Guard.ArgumentIsNotNull(spSite, nameof(spSite));
            Guard.ArgumentIsNotNull(spListItemCollection, nameof(spListItemCollection));
            Guard.ArgumentIsNotNull(spList, nameof(spList));
            Guard.ArgumentIsNotNull(web, nameof(web));
            Guard.ArgumentIsNotNull(workingOnDict, nameof(workingOnDict));

            var itemCount = 1;

            foreach (SPListItem spListItem in spListItemCollection)
            {
                var theListItem = spListItem;
                var fieldsElement = new XElement(Fields);

                foreach (var selectedField in GetMyWorkParams.SelectedFields.Where(
                    selectedField =>
                        theListItem.Fields.ContainsFieldWithInternalName(selectedField)))
                {
                    var value =
                        (theListItem[selectedField] ?? string.Empty).ToString();

                    string type;
                    string format;

                    GetTypeAndFormat(GetMyWorkParams.FieldTypes, selectedField, out type, out format);

                    var fieldElement = new XElement(Field, new XCData(value));
                    fieldElement.Add(new XAttribute(Name, selectedField));
                    fieldElement.Add(new XAttribute(Type, type));
                    fieldElement.Add(new XAttribute(Format, format));
                    fieldsElement.Add(fieldElement);
                }

                var listId = spList.ID.ToString().ToUpper();
                var itemElement = new XElement(Item);
                itemElement.Add(
                    new XAttribute(
                        IdText,
                        spListItem[IdText].ToString().ToUpper()));

                itemElement.Add(new XAttribute(ListIdText, listId));
                itemElement.Add(new XAttribute(WebIdText, theWebId.ToString().ToUpper()));
                itemElement.Add(new XAttribute(SiteIdText, spSite.ID.ToString().ToUpper()));
                itemElement.Add(new XAttribute(SiteUrlText, spSite.Url));
                itemElement.Add(new XAttribute(WorkTypeField, spList.Title));
                itemElement.Add(new XAttribute(Workspace, web.Title));

                var workingOn = false;
                var key = listId;
                key = key.Replace(OpenCurlyBrace, string.Empty);
                key = key.Replace(ClosedCurlyBrace, string.Empty);

                if (workingOnDict.ContainsKey(key))
                {
                    workingOn =
                        workingOnDict[key].Contains(spListItem.ID.ToString(CultureInfo.InvariantCulture));
                }

                itemElement.Add(new XAttribute(WorkingOnField, workingOn));
                itemElement.Add(fieldsElement);
                result.Element(nameof(MyWork)).Add(itemElement);
            }
        }
    }
}