using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using EPMLiveCore;
using EPMLiveWebParts.Utilities;
using Microsoft.SharePoint;

namespace EPMLiveWebParts
{
    internal class ListSummaryProcessHelper
    {
        private const int MAX_LOOKUPFILTER = 300;

        internal static string GetReportFilters(ArrayList reportFilterIds)
        {
            var stringBuilder = new StringBuilder();
            foreach (string str in reportFilterIds)
            {
                stringBuilder.Append("<Value Type=\"Text\">");
                stringBuilder.Append(HttpUtility.HtmlEncode(str));
                stringBuilder.Append("</Value>");
            }

            return stringBuilder.ToString();
        }

        internal static string ProcessReportFilter(
            SPList list,
            SPWeb web,
            IReportID provider,
            ref ArrayList reportFilterIds,
            ref string reportFilterField)
        {
            var ret = string.Empty;
            if (provider != null)
            {
                var listId = Guid.Empty;
                var localReportFilterIds = reportFilterIds;

                SPSecurity.RunWithElevatedPrivileges(
                    delegate
                    {
                        try
                        {
                            using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(web.Site.WebApplication.Id)))
                            {
                                sqlConnection.Open();

                                using (var sqlCommand = new SqlCommand(
                                    "SELECT VALUE,listid FROM PERSONALIZATIONS where userid=@userid and [key]=@key and FK=@FK",
                                    sqlConnection))
                                {
                                    sqlCommand.Parameters.AddWithValue("@userid", web.CurrentUser.ID);
                                    sqlCommand.Parameters.AddWithValue("@key", "ReportFilterWebPartSelections");
                                    sqlCommand.Parameters.AddWithValue("@FK", provider.ReportID.Replace("g_", "").Replace("_", "-"));
                                    sqlCommand.ExecuteNonQuery();
                                    using (var dataReader = sqlCommand.ExecuteReader())
                                    {
                                        if (dataReader.Read())
                                        {
                                            localReportFilterIds = new ArrayList(dataReader.GetString(0).Split('|')[0].Split(','));
                                            listId = dataReader.GetGuid(1);
                                        }
                                        dataReader.Close();
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Trace.TraceError("Exception Suppressed {0}", ex);
                        }
                    });

                reportFilterIds = localReportFilterIds;

                if (listId == list.ID)
                {
                    reportFilterField = "Title";

                    if (reportFilterIds.Count < MAX_LOOKUPFILTER)
                    {
                        ret = "<In><FieldRef Name=\"Title\"/><Values>" + GetReportFilters(reportFilterIds) + "</Values></In>";
                    }
                }
                else if (listId != Guid.Empty)
                {
                    foreach (SPField oField in list.Fields)
                    {
                        if (oField.Type == SPFieldType.Lookup)
                        {
                            try
                            {
                                var oLookup = (SPFieldLookup)oField;
                                if (new Guid(oLookup.LookupList) == listId)
                                {
                                    reportFilterField = oLookup.InternalName;
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Trace.TraceError("Exception Suppressed {0}", ex);
                            }
                        }
                    }

                    if (reportFilterIds.Count < MAX_LOOKUPFILTER && reportFilterField != "")
                    {
                        ret = string.Format(
                            "<In><FieldRef Name=\"{0}\"/><Values>{1}</Values></In>",
                            reportFilterField,
                            GetReportFilters(reportFilterIds));
                    }
                }
            }

            return ret;
        }

        internal static void ProcessWeb(
            SPWeb web,
            SortedList<string, int> statusList,
            string rollupList,
            ref string errors,
            Func<XmlDocument, SPList, SPWeb, string> processReportFilterFunc,
            Action<DataTable> processListAction,
            string propList,
            string propView,
            string propStatus,
            string lookupField,
            string lookupFieldList)
        {
            try
            {
                var siteUrl = web.ServerRelativeUrl.Substring(1);
                var list = web.GetListFromUrl(propList);
                var view = list.Views[propView];
                var spQuery = view.Query;
                var spField = list.Fields.GetFieldByInternalName(propStatus);

                PopulateStatusList(statusList, spField);

                var dqFields = string.Format("<FieldRef Name='{0}' Nullable='TRUE'/>", propStatus);
                var dQuery = string.Empty;
                var doc = new XmlDocument();
                doc.LoadXml(string.Format("<Query>{0}</Query>", view.Query));

                var reportInternal = processReportFilterFunc?.Invoke(doc, list, web);
                LookupFilterHelper.AppendLookupQueryToExistingQuery(ref doc, lookupField, lookupFieldList);
                var ndWhere = setupWhereNode(doc, reportInternal);

                ProcessList(web, rollupList, ref errors, processListAction, propStatus, ndWhere, dQuery, siteUrl, dqFields, list);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                errors += string.Format("General Error: {0}<br>", ex.Message);
            }
        }

        private static void PopulateStatusList(SortedList<string, int> statusList, SPField spField)
        {
            if (spField.Type == SPFieldType.Choice || spField.Type == SPFieldType.MultiChoice)
            {
                var docField = new XmlDocument();
                docField.LoadXml(spField.SchemaXml);
                foreach (XmlNode ndChoice in docField.FirstChild.SelectNodes("//CHOICE"))
                {
                    statusList.Add(ndChoice.InnerText, 0);
                }
            }
        }

        private static void ProcessList(
            SPWeb web,
            string rollupList,
            ref string errors,
            Action<DataTable> processListAction,
            string propStatus,
            XmlNode ndWhere,
            string dQuery,
            string siteUrl,
            string dqFields,
            SPList list)
        {
            if (ndWhere != null)
            {
                dQuery = ndWhere.OuterXml;
            }

            dQuery = string.Format("{0}<OrderBy><FieldRef Name='{1}'/></OrderBy>", dQuery, propStatus);

            if (rollupList != string.Empty)
            {
                ProcessRollupList(web, rollupList, ref errors, processListAction, siteUrl, dQuery, dqFields);
            }
            else
            {
                ProcessListFromDataTable(web, ref errors, processListAction, list, dQuery, dqFields);
            }
        }

        private static XmlNode setupWhereNode(XmlDocument doc, string reportInternal)
        {
            var ndWhere = doc.FirstChild.SelectSingleNode("//Where");

            if (!string.IsNullOrWhiteSpace(reportInternal))
            {
                if (ndWhere == null)
                {
                    ndWhere = doc.CreateElement("Where");
                    doc.FirstChild.PrependChild(ndWhere);

                    ndWhere.InnerXml = reportInternal;
                }
                else
                {
                    ndWhere.InnerXml = string.Format("<And>{0}{1}</And>", reportInternal, ndWhere.InnerXml);
                }
            }
            return ndWhere;
        }

        private static void ProcessListFromDataTable(SPWeb web, ref string errors, Action<DataTable> processListAction, SPList list, string dquery, string dqFields)
        {
            var spSiteDataQuery = new SPSiteDataQuery
            {
                Lists = string.Format("<Lists MaxListLimit='0'><List ID='{0}'/></Lists>", list.ID),
                Query = dquery,
                ViewFields = dqFields,
                QueryThrottleMode = SPQueryThrottleOption.Override
            };

            try
            {
                var dataTable = web.GetSiteData(spSiteDataQuery);

                processListAction?.Invoke(dataTable);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                errors += string.Format("Get Site Data Error: {0}<br>", ex.Message);
            }
        }

        private static void ProcessRollupList(
            SPWeb web,
            string rollupList,
            ref string errors,
            Action<DataTable> processListAction,
            string siteUrl,
            string dQuery,
            string dqFields)
        {
            SqlConnection sqlConnection = null;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(
                    delegate
                    {
                        using (var spSite = new SPSite(web.Site.ID))
                        {
                            var dbConnection = spSite.ContentDatabase.DatabaseConnectionString;
                            sqlConnection = new SqlConnection(dbConnection);
                            sqlConnection.Open();
                        }
                    });

                var projectedRollup = rollupList.Replace("\r\n", "\n").Split('\n').Distinct().ToArray();
                foreach (var rollup in projectedRollup)
                {
                    try
                    {
                        var lists = string.Empty;

                        var query = string.IsNullOrWhiteSpace(siteUrl)
                            ? string.Format(
                                "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     webs.siteid='{0}' AND (dbo.AllLists.tp_Title like '{1}')",
                                web.Site.ID,
                                rollup.Replace("'", "''"))
                            : string.Format(
                                "SELECT     dbo.AllLists.tp_ID FROM         dbo.Webs INNER JOIN dbo.AllLists ON dbo.Webs.Id = dbo.AllLists.tp_WebId WHERE     (dbo.Webs.FullUrl LIKE '{0}/%' OR dbo.Webs.FullUrl = '{0}') AND (dbo.AllLists.tp_Title like '{1}')",
                                siteUrl,
                                rollup.Replace("'", "''"));

                        using (var sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            using (var dataReader = sqlCommand.ExecuteReader())
                            {
                                while (dataReader.Read())
                                {
                                    lists += "<List ID='" + dataReader.GetGuid(0) + "'/>";
                                }
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(lists))
                        {
                            var dataQuery = new SPSiteDataQuery
                            {
                                Lists = string.Format("<Lists MaxListLimit='0'>{0}</Lists>", lists),
                                Query = dQuery,
                                Webs = "<Webs Scope='Recursive'/>",
                                ViewFields = dqFields,
                                QueryThrottleMode = SPQueryThrottleOption.Override
                            };

                            try
                            {
                                //CC-77556: I don't know how to handle the below scenario regarding Dispose.
                                //The first assignment seems useless as the variable is replaced right away,
                                //and creating a variable and disposing it right away also doesn't make sense,
                                //so I'm keeping the current behavior intact
                                var dataTable = new DataTable();
                                SPSecurity.RunWithElevatedPrivileges(delegate { dataTable = web.GetSiteData(dataQuery); });

                                processListAction?.Invoke(dataTable);
                            }
                            catch (Exception ex)
                            {
                                errors += "Get Rollup Site Data Error: " + ex.Message + "<br>";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                        errors += "Rollup List Error: " + ex.Message + "<br>";
                    }
                }
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        internal static void ProcessList(
            DataTable dataTable,
            ArrayList reportFilterIds,
            string reportFilterField,
            SortedList<string, int> statusList,
            string status,
            ref int totalItems)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var canCount = true;
                if (reportFilterIds.Count >= MAX_LOOKUPFILTER)
                {
                    if (!reportFilterIds.Contains(dataRow[reportFilterField]))
                    {
                        canCount = false;
                    }
                }

                if (canCount)
                {
                    if (statusList.ContainsKey(dataRow[status].ToString()))
                    {
                        statusList[dataRow[status].ToString()] = statusList[dataRow[status].ToString()] + 1;
                    }
                    else
                    {
                        statusList.Add(dataRow[status].ToString(), 1);
                    }

                    totalItems++;
                }
            }
        }
    }
}