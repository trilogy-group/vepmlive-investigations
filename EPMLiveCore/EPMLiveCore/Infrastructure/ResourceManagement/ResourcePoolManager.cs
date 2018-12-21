using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using EPMLiveCore.API;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure
{
    public sealed class ResourcePoolManager : SPListItemManager
    {
        public ResourcePoolManager(SPWeb web)
            : base("Resources", web.ID, web.Site.ID, "Resources", "Resource") { }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ResourcePoolManager" /> class.
        /// </summary>
        public ResourcePoolManager()
            : base("Resources", SPContext.Current.Web.ID, SPContext.Current.Site.ID, "Resources", "Resource") { }

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
            var useReportingDb = false;
            var spWeb = ParentList.ParentWeb;
            var reportData = new ReportData(spWeb.Site.ID);

            if (reportData.GetSite() != null)
            {
                if (reportData.GetListMapping(ParentList.ID) != null)
                {
                    var exists = true;
                    var dataTables = from obj in new[] { "[dbo].[spGetReportListData]" }
                                     let queryExecutor = new QueryExecutor(spWeb)
                                     select queryExecutor.ExecuteReportingDBQuery(
                                         @"SELECT COUNT(*) AS Found FROM dbo.sysobjects WHERE id = object_id(@Object)",
                                         new Dictionary<string, object> { { "@Object", obj } });
                    foreach (var dataTable in dataTables)
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
                var spWeb = ParentList.ParentWeb;

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
                var resources = queryExecutor.ExecuteReportingDBStoredProc("spGetReportListData", parameters);

                if (resources == null)
                {
                    var xml = new XDocument();
                    xml.Add(rootElement);

                    return xml;
                }

                var spFieldCollection = ParentList.Fields.Cast<SPField>().ToList();
                var dataColumnCollection = resources.Columns;
                var rowCollection = resources.AsEnumerable();
                var tasks = new List<Task<object[]>>();
                var totalRows = rowCollection.Count();
                var pageSize = 200;
                var threadCount = totalRows / pageSize;

                var reportXmlBuilder = new ReportXmlBuilder(this, ElementName);

                if (totalRows <= pageSize)
                {
                    pageSize = totalRows;
                    threadCount = 1;
                }

                var pagesProcessed = 0;

                while (pagesProcessed < threadCount)
                {
                    var page = pageSize;
                    var offset = pagesProcessed * pageSize;

                    pagesProcessed++;

                    if (pagesProcessed == threadCount)
                    {
                        page = totalRows - offset;
                    }

                    var task = Task<object[]>.Factory.StartNew(() =>
                    {
                        var dataRows = rowCollection
                            .Skip(offset)
                            .Take(page);

                        Dictionary<string, object[]> valueDictionary;
                        var elements = reportXmlBuilder.BuildXmlElements(includeHidden,
                            includeReadOnly, dataRows,
                            spFieldCollection,
                            dataColumnCollection,
                            resources,
                            out valueDictionary);

                        return new object[]
                        {
                            elements,
                            valueDictionary
                        };
                    });

                    tasks.Add(task);
                }

                foreach (var task in tasks)
                {
                    var result = task.Result;

                    var elements = (List<XElement>)result[0];
                    ProcessHtmlValues(elements, (Dictionary<string, object[]>)result[1]);

                    rootElement.Add(elements);
                }

                var resourcesXml = new XDocument();
                resourcesXml.Add(rootElement);

                return resourcesXml;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                throw new APIException((int)Errors.SPLIMGetAllFromDB, exception.GetBaseException().Message);
            }
        }

        private void ProcessHtmlValues(IEnumerable<XElement> elements, Dictionary<string, object[]> valueDictionary)
        {
            foreach (var xElement in elements)
            {
                foreach (var element in xElement.Elements("Data"))
                {
                    var processHtmlAttr = element.Attribute("ProcessHtmlValue");
                    var process = processHtmlAttr != null && processHtmlAttr.Value.ToLower().Equals("true");

                    if (processHtmlAttr != null)
                    {
                        processHtmlAttr.Remove();
                    }

                    if (!process)
                    {
                        continue;
                    }

                    var key = element.Attribute("HtmlValue").Value;

                    if (!valueDictionary.ContainsKey(key))
                    {
                        continue;
                    }

                    var data = valueDictionary[key];

                    element.Attribute("HtmlValue").SetValue(((SPFieldLookup) data[0]).GetFieldValueAsHtml(data[1]));
                }
            }
        }

        internal void GetFieldSpecialValues(
            SPField spField, 
            string stringValue, 
            object value,
            out string fieldEditValue,
            out string fieldTextValue, 
            out string fieldHtmlValue)
        {
            base.GetFieldSpecialValues(spField, stringValue, value, out fieldEditValue, out fieldTextValue, out fieldHtmlValue);
        }
    }
}