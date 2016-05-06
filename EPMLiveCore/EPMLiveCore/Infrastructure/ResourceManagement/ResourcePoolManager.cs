using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using EPMLiveCore.API;
using EPMLiveCore.ReportingProxy;
using EPMLiveCore.ReportHelper;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure
{
    public sealed class ResourcePoolManager : SPListItemManager
    {
        #region Constructors (2) 

        public ResourcePoolManager(SPWeb web)
            : base("Resources", web.ID, web.Site.ID, "Resources", "Resource") { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResourcePoolManager" /> class.
        /// </summary>
        public ResourcePoolManager()
            : base("Resources", SPContext.Current.Web.ID, SPContext.Current.Site.ID, "Resources", "Resource") { }

        #endregion Constructors 

        #region Methods (4) 

        // Public Methods (1) 

        /// <summary>
        ///     Gets all.
        /// </summary>
        /// <param name="includeHidden">
        ///     if set to <c>true</c> [include hidden].
        /// </param>
        /// <param name="includeReadOnly">
        ///     if set to <c>true</c> [include read only].
        /// </param>
        /// <returns></returns>
        public override XDocument GetAll(bool includeHidden, bool includeReadOnly)
        {
            bool useReportingDb = false;

            SPWeb spWeb = ParentList.ParentWeb;

            var reportData = new ReportData(spWeb.Site.ID);

            if (reportData.GetSite() != null)
            {
                if (reportData.GetListMapping(ParentList.ID) != null)
                {
                    bool exists = true;

                    foreach (
                        DataTable dataTable in
                            from obj in new[] {"[dbo].[spGetReportListData]"}
                            let queryExecutor = new QueryExecutor(spWeb)
                            select queryExecutor.ExecuteReportingDBQuery(
                                @"SELECT COUNT(*) AS Found FROM dbo.sysobjects WHERE id = object_id(@Object)",
                                new Dictionary<string, object> {{"@Object", obj}}))
                    {
                        if (dataTable.Rows.Count > 0)
                        {
                            if ((int) dataTable.Rows[0]["Found"] != 1)
                            {
                                exists = false;
                            }
                        }
                        else
                        {
                            exists = false;
                        }
                    }

                    if (exists)
                    {
                        useReportingDb = true;
                    }
                }
            }

            return useReportingDb
                ? GetAllFromReportingDB(includeHidden, includeReadOnly)
                : base.GetAll(includeHidden, includeReadOnly);
        }

        // Private Methods (3) 

        private List<XElement> BuildXmlElements(bool includeHidden, bool includeReadOnly,
            IEnumerable<DataRow> rowCollection, List<SPField> spFieldCollection,
            DataColumnCollection dataColumnCollection, DataTable resources,
            out Dictionary<string, object[]> valueDictionary)
        {
            var elements = new List<XElement>();
            valueDictionary = new Dictionary<string, object[]>();

            var lookupColumns = new List<string>();
            var lookupValues = new Dictionary<object, string[]>();
            var userValues = new Dictionary<object, string[]>();
            var formatDictionary = new Dictionary<string, string>();

            foreach (DataRow row in rowCollection)
            {
                var itemElement = new XElement(ElementName);
                itemElement.Add(new XAttribute("ID", row["ID"]));

                foreach (SPField spField in spFieldCollection)
                {
                    string internalName = spField.InternalName;

                    bool processHtmlValue = false;

                    bool isHidden = spField.Hidden;
                    bool isReadOnly = spField.ReadOnlyField;

                    if (!internalName.Equals("EXTID"))
                    {
                        if (isHidden && !includeHidden)
                        {
                            continue;
                        }

                        if (isReadOnly && !includeReadOnly)
                        {
                            continue;
                        }
                    }

                    object value = null;

                    if (dataColumnCollection.Contains(internalName))
                    {
                        value = row[internalName];
                        if (value == null || value == DBNull.Value) value = string.Empty;
                    }
                    else
                    {
                        if (!lookupColumns.Contains(internalName))
                        {
                            if (resources.Columns.Contains(internalName + "ID"))
                            {
                                lookupColumns.Add(internalName);
                            }
                        }

                        if (lookupColumns.Contains(internalName))
                        {
                            object idValue = row[internalName + "ID"];
                            object textValue = row[internalName + "Text"];

                            if (spField.Type == SPFieldType.MultiChoice)
                            {
                                try
                                {
                                    var choiceValue = new SPFieldMultiChoiceValue(value.ToString());

                                    var list = new List<string>();
                                    for (int i = 0; i < choiceValue.Count; i++)
                                    {
                                        list.Add(choiceValue[i]);
                                    }

                                    value = string.Join(", ", list.ToArray());
                                }
                                catch { }
                            }
                            else
                            {
                                if (idValue == null || idValue == DBNull.Value || textValue == null ||
                                    textValue == DBNull.Value)
                                {
                                    value = string.Empty;
                                }
                                else
                                {
                                    string[] ids = idValue.ToString().Split(',');
                                    string[] values = textValue.ToString().Split(',');

                                    var list = new List<string>();

                                    for (int i = 0; i < ids.Length; i++)
                                    {
                                        try
                                        {
                                            list.Add(ids[i]);
                                            list.Add(values[i]);
                                        }
                                        catch { }
                                    }

                                    value = string.Join(";#", list.ToArray());
                                }
                            }
                        }
                        else
                        {
                            value = string.Empty;
                        }
                    }

                    value = value ?? string.Empty;

                    string stringValue = value.ToString().Trim();

                    string fieldEditValue;
                    string fieldTextValue;
                    string fieldHtmlValue;

                    switch (spField.Type)
                    {
                        case SPFieldType.Lookup:
                            var spFieldLookup = ((SPFieldLookup) spField);
                            string key = spFieldLookup.LookupList + spFieldLookup.LookupField + stringValue;

                            if (!lookupValues.ContainsKey(key))
                            {
                                GetFieldSpecialValues(spField, stringValue, value, out fieldEditValue,
                                    out fieldTextValue,
                                    out fieldHtmlValue);

                                fieldHtmlValue = key;

                                lookupValues.Add(key, new[] {fieldTextValue, fieldEditValue, fieldHtmlValue});

                                valueDictionary.Add(key, new[] {spField, value});
                            }
                            else
                            {
                                string[] lookupValue = lookupValues[key];

                                fieldTextValue = lookupValue[0];
                                fieldEditValue = lookupValue[1];
                                fieldHtmlValue = lookupValue[2];
                            }

                            processHtmlValue = true;
                            break;
                        case SPFieldType.User:
                            if (!userValues.ContainsKey(value))
                            {
                                GetFieldSpecialValues(spField, stringValue, value, out fieldEditValue,
                                    out fieldTextValue,
                                    out fieldHtmlValue);

                                userValues.Add(value, new[] {fieldTextValue, fieldEditValue, fieldHtmlValue});
                            }
                            else
                            {
                                string[] userValue = userValues[value];

                                fieldTextValue = userValue[0];
                                fieldEditValue = userValue[1];
                                fieldHtmlValue = userValue[2];
                            }
                            break;
                        case SPFieldType.DateTime:
                            string specialValue = string.IsNullOrEmpty(stringValue)
                                ? string.Empty
                                : ((DateTime) value).ToString("yyyy-MM-dd HH:mm:ss");

                            fieldTextValue = specialValue;
                            fieldHtmlValue = specialValue;
                            fieldEditValue = specialValue;
                            break;
                        default:
                            fieldTextValue = stringValue;
                            fieldEditValue = stringValue;
                            fieldHtmlValue = stringValue;
                            break;
                    }

                    if (!formatDictionary.ContainsKey(internalName))
                    {
                        formatDictionary.Add(internalName, Utils.GetFormat(spField));
                    }

                    itemElement.Add(new XElement("Data", new XAttribute("Field", internalName),
                        new XAttribute("Type", spField.Type),
                        new XAttribute("Format", formatDictionary[internalName]),
                        new XAttribute("Hidden", isHidden),
                        new XAttribute("ReadOnly", isReadOnly),
                        new XAttribute("TextValue", fieldTextValue),
                        new XAttribute("HtmlValue", fieldHtmlValue),
                        new XAttribute("EditValue", fieldEditValue),
                        new XAttribute("ProcessHtmlValue", processHtmlValue),
                        new XCData(stringValue)));
                }

                elements.Add(itemElement);
            }

            return elements;
        }

        /// <summary>
        ///     Gets all from reporting DB.
        /// </summary>
        /// <param name="includeHidden">
        ///     if set to <c>true</c> [include hidden].
        /// </param>
        /// <param name="includeReadOnly">
        ///     if set to <c>true</c> [include read only].
        /// </param>
        /// <returns></returns>
        private XDocument GetAllFromReportingDB(bool includeHidden, bool includeReadOnly)
        {
            try
            {
                var rootElement = new XElement(RootElementName);

                SPWeb spWeb = ParentList.ParentWeb;

                var parameters = new Dictionary<string, object>
                {
                    {"@siteid", spWeb.Site.ID},
                    {"@webid", spWeb.ID},
                    {"@weburl", spWeb.ServerRelativeUrl},
                    {"@userid", spWeb.CurrentUser.ID},
                    {"@rollup", false},
                    {"@list", "ResourcePool"},
                    {"@query", string.Empty}
                };

                var queryExecutor = new QueryExecutor(spWeb);
                DataTable resources = queryExecutor.ExecuteReportingDBStoredProc("spGetReportListData", parameters);

                if (resources == null)
                {
                    var xml = new XDocument();
                    xml.Add(rootElement);

                    return xml;
                }

                List<SPField> spFieldCollection = ParentList.Fields.Cast<SPField>().ToList();

                DataColumnCollection dataColumnCollection = resources.Columns;
                EnumerableRowCollection<DataRow> rowCollection = resources.AsEnumerable();

                var tasks = new List<Task<object[]>>();

                int totalRows = rowCollection.Count();
                int pageSize = 200;
                int threadCount = totalRows/pageSize;

                if (totalRows <= pageSize)
                {
                    pageSize = totalRows;
                    threadCount = 1;
                }

                int pagesProcessed = 0;

                while (pagesProcessed < threadCount)
                {
                    int page = pageSize;
                    int offset = pagesProcessed*pageSize;

                    pagesProcessed++;

                    if (pagesProcessed == threadCount)
                    {
                        page = totalRows - offset;
                    }

                    Task<object[]> task = Task<object[]>.Factory.StartNew(() =>
                    {
                        IEnumerable<DataRow> dataRows = (from r in rowCollection select r).Skip(offset).Take(page);

                        Dictionary<string, object[]> valueDictionary;

                        List<XElement> elements = BuildXmlElements(includeHidden,
                            includeReadOnly, dataRows,
                            spFieldCollection,
                            dataColumnCollection,
                            resources,
                            out valueDictionary);

                        return new object[] {elements, valueDictionary};
                    });

                    tasks.Add(task);
                }

                foreach (var task in tasks)
                {
                    object[] result = task.Result;

                    var elements = (List<XElement>) result[0];
                    ProcessHtmlValues(elements, (Dictionary<string, object[]>) result[1]);

                    rootElement.Add(elements);
                }

                var resourcesXml = new XDocument();
                resourcesXml.Add(rootElement);

                return resourcesXml;
            }
            catch (Exception exception)
            {
                throw new APIException((int) Errors.SPLIMGetAllFromDB, exception.GetBaseException().Message);
            }
        }

        private void ProcessHtmlValues(IEnumerable<XElement> elements, Dictionary<string, object[]> valueDictionary)
        {
            foreach (XElement xElement in elements)
            {
                foreach (XElement element in xElement.Elements("Data"))
                {
                    XAttribute processHtmlAttr = element.Attribute("ProcessHtmlValue");
                    bool process = processHtmlAttr != null && processHtmlAttr.Value.ToLower().Equals("true");

                    if (processHtmlAttr != null) processHtmlAttr.Remove();

                    if (!process) continue;

                    string key = element.Attribute("HtmlValue").Value;

                    if (!valueDictionary.ContainsKey(key)) continue;

                    object[] data = valueDictionary[key];

                    element.Attribute("HtmlValue").SetValue(((SPFieldLookup) data[0]).GetFieldValueAsHtml(data[1]));
                }
            }
        }

        #endregion Methods 
    }
}