using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Web;
using System.Xml;

namespace EPMLiveCore.API
{
    using System.Diagnostics;

    public class AssociatedListItems
    {
        #region Associated Items Web Part Methods

        /// <summary>
        /// Retrieves Associated Items
        /// </summary>
        /// <param name="data">associated list data param string</param>
        /// <returns></returns>
        public static string GetAssociatedItems(string data)
        {
            try
            {
                var listAssociatedItemsDivStringBuilder = new StringBuilder();
                var sqlGetListHeaders = new StringBuilder();
                ArrayList arrAssociatedLists = null;
                var projectLinkedField = "Project";
                DataTable listName = null;

                //Parse XML to get paramater values
                var xmlDocument = ParseXmlDocument(data);

                //Set values from parameter
                var siteUrl = xmlDocument.GetElementsByTagName("SiteUrl")[0].InnerText;
                var siteId = xmlDocument.GetElementsByTagName("SiteID")[0].InnerText;
                var webId = xmlDocument.GetElementsByTagName("WebID")[0].InnerText;
                var projectListId = new Guid(xmlDocument.GetElementsByTagName("ProjectListID")[0].InnerText);
                var projectId = xmlDocument.GetElementsByTagName("ProjectID")[0].InnerText;
                var projectTitle = xmlDocument.GetElementsByTagName("ProjectTitle")[0].InnerText;
                var sourceUrl = HttpUtility.UrlEncode(HttpContext.Current.Request.UrlReferrer.ToString());

                FetchDataValues(
                    new SiteData(
                        siteUrl,
                        webId,
                        projectListId,
                        listName,
                        projectId,
                        siteId,
                        projectTitle),
                    new ProjectData(sqlGetListHeaders, listAssociatedItemsDivStringBuilder, projectLinkedField, sourceUrl));

                return Response.Success(listAssociatedItemsDivStringBuilder.ToString());
            }
            catch (APIException ex)
            {
                Trace.TraceError("Exception suppressed {0}", ex);
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        private static void FetchDataValues(
            SiteData siteData,
            ProjectData projectData)
        {
            using (var spSite = new SPSite(siteData.SiteUrl))
            using (var spWeb = spSite.OpenWeb(new Guid(siteData.WebId)))
            {
                var associatedLists = LoadAssociatedLists(siteData, spWeb);

                if (associatedLists != null && associatedLists.Count > 0)
                {
                    var sqlLists = PrepareDataTableForLists(projectData.SqlGetListHeaders, associatedLists);

                    SetListNAmeTable(siteData, spWeb, sqlLists);


                    if (siteData.ListNameTable != null && siteData.ListNameTable.Rows.Count > 0)
                    {
                        for (var i = 0; i < siteData.ListNameTable.Rows.Count; i++)
                        {
                            var rptListId = Convert.ToString(siteData.ListNameTable.Rows[i]["RPTListID"]);
                            var listName = Convert.ToString(siteData.ListNameTable.Rows[i]["ListName"]);
                            var tableName = Convert.ToString(siteData.ListNameTable.Rows[i]["TableName"]);

                            if (!string.IsNullOrWhiteSpace(rptListId))
                            {
                                LoadCountFromDatabase(new Tuple<SiteData, ProjectData>(siteData, projectData), tableName, rptListId, spWeb, listName);
                            }
                            else
                            {
                                rptListId = LoadRecordCountFromSharepoint(siteData, projectData, spWeb, listName, associatedLists);
                            }

                            SPList projectAssociatedList;
                            var top5AssociatedItems = LoadTop5Items(siteData, projectData, spWeb, listName, out projectAssociatedList);

                            AppendBasicDivs(siteData, projectData, rptListId, listName, projectAssociatedList);
                            AppendFromTop5Items(siteData, projectData, top5AssociatedItems, projectAssociatedList);
                            AppendBasicClosingTags(projectData);
                            AppendOtherAssociatedItems(siteData, projectData, projectAssociatedList, spWeb);
                            AppendClosingAssociatedItemsDivs(siteData, projectData, i);
                        }
                    }
                }
            }
        }

        private static void AppendClosingAssociatedItemsDivs(SiteData siteData, ProjectData projectData, int i)
        {
            projectData.ListAssociatedItemsDivStringBuilder
                .Append("</div>")
                .Append("</div>");

            if (i != siteData.ListNameTable.Rows.Count - 1)
            {
                projectData.ListAssociatedItemsDivStringBuilder.Append("<div class='pipeSeperator'>|</div>");
            }
        }

        private static void AppendOtherAssociatedItems(SiteData siteData, ProjectData projectData, SPList projectAssociatedList, SPWeb spWeb)
        {
            var queryAssociatedItems = new SPQuery();
            queryAssociatedItems.Query = string.Format(
                "<Where><Eq><FieldRef Name='{0}' LookupId='True' /><Value Type='Lookup'>{1}</Value></Eq></Where><QueryOptions></QueryOptions><OrderBy><FieldRef Name='Modified' Ascending='FALSE' /></OrderBy>",
                projectData.ProjectLinkedField,
                siteData.ProjectId);
            var otherAssociatedItems = projectAssociatedList.GetItems(queryAssociatedItems);

            if (otherAssociatedItems.Count > 5)
            {
                var viewAllItemsUrl = string.Format(
                    "{0}/_layouts/epmlive/gridaction.aspx?action=linkeditemspost&listid={1}&lookups={2}&field={3}&LookupFieldList={4}",
                    spWeb.Url,
                    siteData.ProjectListId,
                    siteData.ProjectTitle,
                    projectData.ProjectLinkedField,
                    projectAssociatedList.ID);
                projectData.ListAssociatedItemsDivStringBuilder.AppendFormat(
                    "<a href='#' onclick=\"javascript:showItemUrl('{0}');return false;\">View All {1}</a>",
                    viewAllItemsUrl,
                    projectAssociatedList.Title);
            }
        }

        private static void AppendBasicClosingTags(ProjectData projectData)
        {
            projectData.ListAssociatedItemsDivStringBuilder
                .Append("</table>")
                .Append("<br/>")
                .Append("<br/>");
        }

        private static void AppendFromTop5Items(
            SiteData siteData,
            ProjectData projectData,
            SPListItemCollection top5AssociatedItems,
            SPList projectAssociatedList)
        {
            foreach (SPListItem item in top5AssociatedItems)
            {
                projectData.ListAssociatedItemsDivStringBuilder.Append("<tr>");

                if (item.Title != null && item.Title.TrimEnd().Length > 20)
                {
                    projectData.ListAssociatedItemsDivStringBuilder.AppendFormat(
                        "<td><a href='#' alt='{0}' title='{0}' onclick=\"javascript:showNewForm('{1}?ID={2}&Source={3}');return false;\">{4}...</a></td>",
                        item.Title,
                        projectAssociatedList.DefaultDisplayFormUrl,
                        item.ID,
                        projectData.SourceUrl,
                        item.Title.Substring(0, 20));
                }
                else
                {
                    projectData.ListAssociatedItemsDivStringBuilder.AppendFormat(
                        "<td><a href='#' alt='{0}' title='{0}' onclick=\"javascript:showNewForm('{1}?ID={2}&Source={3}');return false;\">{0}</a></td>",
                        item.Title,
                        projectAssociatedList.DefaultDisplayFormUrl,
                        item.ID,
                        projectData.SourceUrl);
                }

                projectData.ListAssociatedItemsDivStringBuilder
                    .Append("<td>")
                    .Append("<li class='associateditemscontextmenu'>")
                    .AppendFormat(
                        "<a data-itemid='{0}' data-listid='{1}' data-webid='{2}' data-siteid='{3}'>",
                        item.ID,
                        projectAssociatedList.ID,
                        siteData.WebId,
                        siteData.SiteId)
                    .Append("</a>")
                    .Append("</li>")
                    .Append("</td>")
                    .Append("</tr>");
            }
        }

        private static void AppendBasicDivs(
            SiteData siteData,
            ProjectData projectData,
            string rptListId,
            string listName,
            SPList projectAssociatedList)
        {
            projectData.ListAssociatedItemsDivStringBuilder
                .AppendFormat("<div id='div_items_{0}' class='slidingDiv'>", rptListId)
                .AppendFormat("<div class='slidingDivHeader'>{0}</div>", listName);

            if (!ListCommands.GetGridGanttSettings(projectAssociatedList).HideNewButton)
            {
                var newFormUrl = string.Format(
                    "{0}?LookupField={1}&LookupValue={2}",
                    projectAssociatedList.DefaultNewFormUrl,
                    projectData.ProjectLinkedField,
                    siteData.ProjectId);
                projectData.ListAssociatedItemsDivStringBuilder.AppendFormat(
                    "<div class='slidingDivAdd'><a href='#' onclick=\"javascript:showNewForm('{0}');return false;\"><img title='Add new {1}' alt='' src='/_layouts/epmlive/images/newitem5.png' class='ms-core-menu-buttonIcon'></img></a></div>",
                    newFormUrl,
                    listName);
            }

            projectData.ListAssociatedItemsDivStringBuilder
                .Append("<br/>")
                .Append("<div style='clear:both;'></div>")
                .Append("<table>");
        }

        private static SPListItemCollection LoadTop5Items(
            SiteData siteData,
            ProjectData projectData,
            SPWeb spWeb,
            string listName,
            out SPList projectAssociatedList)
        {
            projectAssociatedList = spWeb.Lists[listName];
            var queryAssociatedItems = new SPQuery();
            queryAssociatedItems.Query = string.Format(
                "<Where><Eq><FieldRef Name='{0}' LookupId='True' /><Value Type='Lookup'>{1}</Value></Eq></Where><QueryOptions></QueryOptions><OrderBy><FieldRef Name='Modified' Ascending='FALSE' /></OrderBy>",
                projectData.ProjectLinkedField,
                siteData.ProjectId);
            queryAssociatedItems.RowLimit = 5;
            var top5AssociatedItems = projectAssociatedList.GetItems(queryAssociatedItems);
            return top5AssociatedItems;
        }

        private static void LoadCountFromDatabase(
            Tuple<SiteData, ProjectData> transferredData,
            string tableName,
            string rptListId,
            SPWeb spWeb,
            string listName)
        {
            var sql = string.Format(
                "SELECT COUNT(*) AS 'Count' FROM {0} WHERE ProjectID = {1} AND ListId = '{2}' GROUP BY ProjectID",
                tableName,
                transferredData.Item1.ProjectId,
                rptListId);

            DataTable dtListItemCount = null;
            try
            {
                // Wait for 3 seconds just in-case if reporting database is not updated.
                Thread.Sleep(3000);
                var queryExecutor = new QueryExecutor(spWeb);
                dtListItemCount = queryExecutor.ExecuteReportingDBQuery(sql, new Dictionary<string, object>());
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception suppressed {0}", ex);
            }

            var associatedItemsCount = 0;
            if (dtListItemCount != null && dtListItemCount.Rows.Count > 0)
            {
                associatedItemsCount = Convert.ToInt32(dtListItemCount.Rows[0]["Count"]);
            }

            transferredData.Item2.ListAssociatedItemsDivStringBuilder.AppendFormat(
                "<div id='div_{0}' class='listMainDiv'>{1} [{2}]",
                rptListId,
                listName,
                Convert.ToString(associatedItemsCount));
        }

        private static string LoadRecordCountFromSharepoint(
            SiteData siteData,
            ProjectData projectData,
            SPWeb spWeb,
            string listName,
            ArrayList associatedLists)
        {
            string rptListId;

            //SharePoint Object Model to Load Record Count
            var otherList = spWeb.Lists[listName];
            var query = new SPQuery();
            rptListId = otherList.ID.ToString();

            foreach (AssociatedListInfo item in associatedLists)
            {
                if (item.ListId.ToString().Equals(rptListId, StringComparison.InvariantCultureIgnoreCase))
                {
                    projectData.ProjectLinkedField = item.LinkedField;
                    break;
                }
            }

            query.Query = string.Format(
                "<Where><Eq><FieldRef Name='{0}' LookupId='True' /><Value Type='Lookup'>{1}</Value></Eq></Where>",
                projectData.ProjectLinkedField,
                siteData.ProjectId);
            long itemCount = otherList.GetItems(query).Count;

            projectData.ListAssociatedItemsDivStringBuilder.AppendFormat(
                "<div id='div_{0}' class='listMainDiv'>{1} [{2}]",
                rptListId,
                listName,
                Convert.ToString(itemCount));
            return rptListId;
        }

        private static void SetListNAmeTable(SiteData siteData, SPWeb spWeb, string sqlLists)
        {
            try
            {
                var queryExecutor = new QueryExecutor(spWeb);
                siteData.ListNameTable = queryExecutor.ExecuteReportingDBQuery(sqlLists, new Dictionary<string, object>());
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception suppressed {0}", ex);
            }
        }

        private static ArrayList LoadAssociatedLists(SiteData siteData, SPWeb spWeb)
        {
            var list = spWeb.Lists[siteData.ProjectListId];

            var associatedLists = ListCommands.GetAssociatedLists(list);
            return associatedLists;
        }

        private static string PrepareDataTableForLists(StringBuilder sqlGetListHeaders, ArrayList associatedLists)
        {
            sqlGetListHeaders.Append("SELECT * FROM (");
            foreach (AssociatedListInfo item in associatedLists)
            {
                sqlGetListHeaders.Append("SELECT '" + item.Title + "' ListID UNION ");
            }

            return string.Format(
                "{0}) AssociatedItemList LEFT OUTER JOIN RPTList ON AssociatedItemList.ListID = RPTList.RPTListId where RPTListId is not null ORDER BY RPTList.ListName",
                sqlGetListHeaders.ToString().Substring(0, sqlGetListHeaders.ToString().Length - 7));
        }

        private static XmlDocument ParseXmlDocument(string data)
        {
            var xDoc = new XmlDocument();
            xDoc.LoadXml(data);
            return xDoc;
        }

        #endregion

        #region Fancy Display Form Web Part Method

        public static string GetFancyFormAssociatedItems(string data, SPWeb oWeb)
        {
            try
            {
                #region Xml Parsing - Parameters

                StringBuilder sbListAssociatedItemsDiv = new StringBuilder();
                string sqlLists = string.Empty;
                StringBuilder sqlGetListHeaders = new StringBuilder();
                ArrayList arrAssociatedLists = null;
                string projectLinkedField = "Project";
                DataTable dtListName = null;

                //Parse XML to get paramater values
                var xDoc = new XmlDocument();
                xDoc.LoadXml(data);

                //Set values from parameter
                Guid listId = new Guid(xDoc.GetElementsByTagName("FancyFormListID")[0].InnerText);
                string itemId = xDoc.GetElementsByTagName("FancyFormItemID")[0].InnerText;
                string itemTitle = string.Empty;
                string sourceUrl = HttpUtility.UrlEncode(HttpContext.Current.Request.UrlReferrer.ToString());

                #endregion

                //Using SharePoint Object Model fetching data values
                using (SPSite spSite = new SPSite(oWeb.Site.ID))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(oWeb.ID))
                    {
                        SPList list = spWeb.Lists[listId];
                        SPListItem currListItem = list.GetItemById(Convert.ToInt32(itemId));
                        itemTitle = currListItem.Title;

                        arrAssociatedLists = EPMLiveCore.API.ListCommands.GetAssociatedLists(list);

                        if (arrAssociatedLists != null && arrAssociatedLists.Count > 0)
                        {
                            #region Prepare DataTable for Associated Items

                            //Prepare query to load list whether it is exists in Reporting database or not?!!
                            sqlGetListHeaders.Append("SELECT * FROM (");
                            foreach (EPMLiveCore.API.AssociatedListInfo item in arrAssociatedLists)
                                sqlGetListHeaders.Append("SELECT '" + item.ListId + "' ListID UNION ");

                            sqlLists = sqlGetListHeaders.ToString().Substring(0, sqlGetListHeaders.ToString().Length - 7); //Removing last UNION keyword
                            sqlLists = sqlLists + ") AssociatedItemList LEFT OUTER JOIN RPTList ON AssociatedItemList.ListID = RPTList.RPTListId where RPTListId is not null ORDER BY RPTList.ListName";

                            #endregion

                            try
                            {
                                var queryExecutor = new QueryExecutor(spWeb);
                                dtListName = queryExecutor.ExecuteReportingDBQuery(sqlLists, new Dictionary<string, object> { });
                            }
                            catch { }

                            if (dtListName != null)
                            {
                                if (dtListName.Rows.Count == 0)
                                {
                                    if (arrAssociatedLists != null)
                                    {
                                        if (arrAssociatedLists.Count > 0)
                                        {
                                            sbListAssociatedItemsDiv.Append("<table style='width:100%'><tr><td><table style='border-collapse: collapse;' class='fancy-col-table'>");
                                            foreach (AssociatedListInfo item in arrAssociatedLists)
                                            {
                                                sbListAssociatedItemsDiv.Append("<tr style=''>");
                                                sbListAssociatedItemsDiv.Append("<td>" + item.Title + "</td>");
                                                sbListAssociatedItemsDiv.Append("<td><a href='#'><div id='div_" + item.ListId + "' class='listMainDiv'><span class='badge'>0</span></a></div>");
                                                sbListAssociatedItemsDiv.Append("</tr>");
                                            }
                                            sbListAssociatedItemsDiv.Append("</table></td></tr></table>");
                                        }
                                    }
                                }
                                else
                                {
                                    SPList otherList = null;
                                    sbListAssociatedItemsDiv.Append("<table style='width: 100%;'><tr><td><table style='border-collapse: collapse;'  class='fancy-col-table'>");

                                    for (int i = 0; i < dtListName.Rows.Count; i++)
                                    {
                                        string rptListId = Convert.ToString(dtListName.Rows[i]["RPTListID"]);
                                        string listName = Convert.ToString(dtListName.Rows[i]["ListName"]);
                                        string tableName = Convert.ToString(dtListName.Rows[i]["TableName"]);

                                        try { otherList = spWeb.Lists[listName]; }
                                        catch { }

                                        //Checking if rptListId is Null or not: If Null then use Object Model to load count, database call otherwise
                                        if (!string.IsNullOrEmpty(rptListId) && otherList != null && otherList.BaseTemplate != SPListTemplateType.DocumentLibrary)
                                        {
                                            #region Retrieve associated list count from database

                                            foreach (EPMLiveCore.API.AssociatedListInfo associatedListItemInfo in arrAssociatedLists)
                                            {
                                                if (associatedListItemInfo.ListId.ToString().Equals(rptListId, StringComparison.InvariantCultureIgnoreCase))
                                                {
                                                    projectLinkedField = associatedListItemInfo.LinkedField;
                                                    break;
                                                }
                                            }

                                            string sql = string.Empty;
                                            //sql = "SELECT COUNT(*) AS 'Count' FROM " + tableName + " WHERE ProjectID = " + itemId + " AND ListId = '" + rptListId + "' GROUP BY ProjectID";
                                            sql = "SELECT COUNT(*) AS 'Count' FROM " + tableName + " WHERE ',' + CONVERT(NVARCHAR(MAX), " + projectLinkedField + "ID) + ',' LIKE N'%," + itemId + ",%' AND ListId = '" + rptListId + "'";

                                            DataTable dtListItemCount = null;
                                            try
                                            {
                                                // Wait for 3 seconds just in-case if reporting database is not updated.
                                                // Thread.Sleep(3000);
                                                var queryExecutor = new QueryExecutor(spWeb);
                                                dtListItemCount = queryExecutor.ExecuteReportingDBQuery(sql, new Dictionary<string, object> { });
                                            }
                                            catch { }

                                            int associatedItemsCount = 0;
                                            if (dtListItemCount != null && dtListItemCount.Rows.Count > 0)
                                            {
                                                associatedItemsCount = Convert.ToInt32(dtListItemCount.Rows[0]["Count"]);
                                            }

                                            //Display ListName [ItemCount] on UI
                                            //sbListAssociatedItemsDiv.Append("<div id='div_" + rptListId + "' class='listMainDiv'>" + listName + " [" + Convert.ToString(associatedItemsCount) + "]");

                                            //string viewAllItemsUrl = oWeb.Url + "/_layouts/epmlive/gridaction.aspx?action=linkeditemspost&listid=" + listId + "&lookups=" + itemTitle + "&field=" + projectLinkedField + "&LookupFieldList=" + rptListId;// +"&Source=" + sourceUrl;

                                            sbListAssociatedItemsDiv.Append("<tr style=''>");
                                            sbListAssociatedItemsDiv.Append("<td>" + listName + "</td>");
                                            sbListAssociatedItemsDiv.Append("<td><a href='#' onclick=\"javascript:FancyDispFormClient.emptyFunction('');\"><div id='div_" + rptListId + "' class='listMainDiv'><span class='badge'>" + Convert.ToString(associatedItemsCount) + "</span></a>");
                                            //sbListAssociatedItemsDiv.Append("</tr>");

                                            #endregion
                                        }
                                        else
                                        {
                                            if (otherList != null && otherList.EnableThrottling && otherList.BaseTemplate != SPListTemplateType.DocumentLibrary) //In terms of bulk record SharePoint throws exception hence we need to retrieve records from EPMLive Reporting Database.
                                            {
                                                #region If Threshold is enabled for processed list then retrieve those records from reporting database

                                                //SharePoint Object Model to Load Record Count
                                                otherList = spWeb.Lists[listName];
                                                rptListId = otherList.ID.ToString();

                                                foreach (EPMLiveCore.API.AssociatedListInfo associatedListItemInfo in arrAssociatedLists)
                                                {
                                                    if (associatedListItemInfo.ListId.ToString().Equals(rptListId, StringComparison.InvariantCultureIgnoreCase))
                                                    {
                                                        projectLinkedField = associatedListItemInfo.LinkedField;
                                                        break;
                                                    }
                                                }

                                                string sql = string.Empty;
                                                //sql = "SELECT COUNT(*) AS 'Count' FROM " + tableName + " WHERE ProjectID = " + itemId + " AND ListId = '" + rptListId + "' GROUP BY ProjectID";
                                                sql = "SELECT COUNT(*) AS 'Count' FROM " + tableName + " WHERE ',' + CONVERT(NVARCHAR(MAX), " + projectLinkedField + "ID) + ',' LIKE N'%," + itemId + ",%' AND ListId = '" + rptListId + "'";

                                                DataTable dtListItemCount = null;
                                                try
                                                {
                                                    // Wait for 3 seconds just in-case if reporting database is not updated.
                                                    // Thread.Sleep(3000);
                                                    var queryExecutor = new QueryExecutor(spWeb);
                                                    dtListItemCount = queryExecutor.ExecuteReportingDBQuery(sql, new Dictionary<string, object> { });
                                                }
                                                catch { }

                                                int associatedItemsCount = 0;
                                                if (dtListItemCount != null && dtListItemCount.Rows.Count > 0)
                                                {
                                                    associatedItemsCount = Convert.ToInt32(dtListItemCount.Rows[0]["Count"]);
                                                }

                                                //Display ListName [ItemCount] on UI
                                                //sbListAssociatedItemsDiv.Append("<div id='div_" + rptListId + "' class='listMainDiv'>" + listName + " [" + Convert.ToString(associatedItemsCount) + "]");

                                                //string viewAllItemsUrl = oWeb.Url + "/_layouts/epmlive/gridaction.aspx?action=linkeditemspost&listid=" + listId + "&lookups=" + itemTitle + "&field=" + projectLinkedField + "&LookupFieldList=" + rptListId;// +"&Source=" + sourceUrl;

                                                sbListAssociatedItemsDiv.Append("<tr style=''>");
                                                sbListAssociatedItemsDiv.Append("<td>" + listName + "</td>");
                                                sbListAssociatedItemsDiv.Append("<td><a href='#' onclick=\"javascript:FancyDispFormClient.emptyFunction('');\"><div id='div_" + rptListId + "' class='listMainDiv'><span class='badge'>" + Convert.ToString(associatedItemsCount) + "</span></a>");
                                                //sbListAssociatedItemsDiv.Append("</tr>");

                                                #endregion
                                            }
                                            else
                                            {
                                                #region Retrieve associated list count using SharePoint Object Model

                                                //SharePoint Object Model to Load Record Count
                                                otherList = spWeb.Lists[listName];
                                                SPQuery query = new SPQuery();
                                                rptListId = otherList.ID.ToString();

                                                foreach (EPMLiveCore.API.AssociatedListInfo item in arrAssociatedLists)
                                                {
                                                    if (item.ListId.ToString().Equals(rptListId, StringComparison.InvariantCultureIgnoreCase))
                                                    {
                                                        projectLinkedField = item.LinkedField;
                                                        break;
                                                    }
                                                }

                                                query.Query = "<Where><Eq><FieldRef Name='" + projectLinkedField + "' LookupId='True' /><Value Type='Lookup'>" + itemId + "</Value></Eq></Where>";
                                                Int64 itemCount = otherList.GetItems(query).Count;

                                                //sbListAssociatedItemsDiv.Append("<div id='div_" + rptListId + "' class='listMainDiv'>" + listName + " [" + Convert.ToString(itemCount) + "]");
                                                //string viewAllItemsUrl = oWeb.Url + "/_layouts/epmlive/gridaction.aspx?action=linkeditemspost&listid=" + listId + "&lookups=" + itemTitle + "&field=" + projectLinkedField + "&LookupFieldList=" + otherList.ID.ToString();// +"&Source=" + sourceUrl;

                                                sbListAssociatedItemsDiv.Append("<tr>");
                                                sbListAssociatedItemsDiv.Append("<td>" + listName + "</td>");
                                                sbListAssociatedItemsDiv.Append("<td><a href='#' onclick=\"javascript:FancyDispFormClient.emptyFunction('');\"> <div id='div_" + rptListId + "' class='listMainDiv'><span class='badge'>" + Convert.ToString(itemCount) + "</span></a>");
                                                //sbListAssociatedItemsDiv.Append("</tr><tr><td>");


                                                #endregion
                                            }
                                        }

                                        if (otherList != null && otherList.EnableThrottling && otherList.BaseTemplate != SPListTemplateType.DocumentLibrary)
                                        {
                                            #region Load Top-5 Items (From Database, In case of Enable Throttling is Set to True)

                                            string sql = string.Empty;
                                            //sql = "SELECT COUNT(*) AS 'Count' FROM " + tableName + " WHERE ProjectID = " + itemId + " AND ListId = '" + rptListId + "' GROUP BY ProjectID";
                                            sql = "SELECT Top 6 Title, ItemId FROM " + tableName + " WHERE ',' + CONVERT(NVARCHAR(MAX), " + projectLinkedField + "ID) + ',' LIKE N'%," + itemId + ",%' AND ListId = '" + rptListId + "' ORDER BY Created DESC";

                                            DataTable dtTop5ListItems = null;
                                            try
                                            {
                                                // Wait for 3 seconds just in-case if reporting database is not updated.
                                                // Thread.Sleep(3000);
                                                var queryExecutor = new QueryExecutor(spWeb);
                                                dtTop5ListItems = queryExecutor.ExecuteReportingDBQuery(sql, new Dictionary<string, object> { });
                                            }
                                            catch { }

                                            sbListAssociatedItemsDiv.Append("<div id='div_items_" + rptListId + "' class='slidingDiv'>");
                                            sbListAssociatedItemsDiv.Append("<div class='fancy-display-form-wrapper slidingDivHeader'>" + listName + "</div>");

                                            if (!EPMLiveCore.API.ListCommands.GetGridGanttSettings(otherList).HideNewButton)
                                            {
                                                string newFormUrl = otherList.DefaultNewFormUrl + "?LookupField=" + projectLinkedField + "&LookupValue=" + itemId;
                                                sbListAssociatedItemsDiv.Append("<div class='slidingDivAdd'><a href='#' onclick=\"javascript:FancyDispFormClient.showNewForm('" + newFormUrl + "');return false;\"><img title='Add new " + listName + "' alt='' src='/_layouts/epmlive/images/newitem5.png' class='ms-core-menu-buttonIcon'></img></a></div>");
                                            }

                                            sbListAssociatedItemsDiv.Append("<br/>");

                                            sbListAssociatedItemsDiv.Append("<div style='clear:both;'></div>");
                                            sbListAssociatedItemsDiv.Append("<table class='fancy-col-table' style='color:#555555; font-weight:normal;'>");

                                            int associatedItemsCount = 0;
                                            if (dtTop5ListItems != null && dtTop5ListItems.Rows.Count > 0)
                                            {
                                                for (int rowId = 0; rowId < dtTop5ListItems.Rows.Count; rowId++)
                                                {
                                                    if (rowId == 5)
                                                        break;

                                                    string title = Convert.ToString(dtTop5ListItems.Rows[rowId]["Title"]);
                                                    string id = Convert.ToString(dtTop5ListItems.Rows[rowId]["ItemId"]);

                                                    sbListAssociatedItemsDiv.Append("<tr>");

                                                    if (string.IsNullOrEmpty(title) && title.TrimEnd().Length > 25)
                                                    {
                                                        sbListAssociatedItemsDiv.Append("<td><a href='#' alt='" + title + "' title='" + title + "' onclick=\"javascript:FancyDispFormClient.showNewForm('" + otherList.DefaultDisplayFormUrl + "?ID=" + id + "&Source=" + sourceUrl + "');return false;\">" + title.Substring(0, 25) + "..." + "</a></td>");
                                                    }
                                                    else
                                                    {
                                                        sbListAssociatedItemsDiv.Append("<td><a href='#' alt='" + title + "' title='" + title + "' onclick=\"javascript:FancyDispFormClient.showNewForm('" + otherList.DefaultDisplayFormUrl + "?ID=" + id + "&Source=" + sourceUrl + "');return false;\">" + title + "</a></td>");
                                                    }

                                                    sbListAssociatedItemsDiv.Append("<td>");
                                                    sbListAssociatedItemsDiv.Append("<li class='fancyDisplayFormAssociatedItemsContextMenu'>");
                                                    sbListAssociatedItemsDiv.Append("<a data-itemid='" + id + "' data-listid='" + otherList.ID.ToString() + "' data-webid='" + oWeb.ID + "' data-siteid='" + oWeb.Site.ID + "'>");
                                                    sbListAssociatedItemsDiv.Append("</a>");
                                                    sbListAssociatedItemsDiv.Append("</li>");
                                                    sbListAssociatedItemsDiv.Append("</td>");

                                                    sbListAssociatedItemsDiv.Append("</tr>");
                                                }
                                            }

                                            sbListAssociatedItemsDiv.Append("</table>");
                                            sbListAssociatedItemsDiv.Append("<br/>");

                                            if (dtTop5ListItems != null && dtTop5ListItems.Rows.Count > 5)
                                            {
                                                string viewAllItemsUrl = spWeb.Url + "/_layouts/epmlive/gridaction.aspx?action=linkeditemspost&listid=" + listId + "&lookups=" + itemTitle + "&field=" + projectLinkedField + "&LookupFieldList=" + otherList.ID.ToString();// +"&Source=" + sourceUrl;
                                                sbListAssociatedItemsDiv.Append("<a href='#' onclick=\"javascript:FancyDispFormClient.showItemUrl('" + viewAllItemsUrl + "');return false;\">View All " + otherList.Title + "</a>");
                                            }

                                            sbListAssociatedItemsDiv.Append("</div>"); //div_items_listGuid - Div Ends..
                                            sbListAssociatedItemsDiv.Append("</div>"); //div_listGUID - Div Ends..
                                            sbListAssociatedItemsDiv.Append("</td></tr>");

                                            #endregion
                                        }
                                        else
                                        {
                                            #region Load Top-5 Items (Using SharePoint Object Model)

                                            //Load Top-5 Items...
                                            SPList projectAssociatedList = spWeb.Lists[listName];
                                            SPQuery qryAssociatedItems = new SPQuery();
                                            qryAssociatedItems.Query = "<Where><Eq><FieldRef Name='" + projectLinkedField + "' LookupId='True' /><Value Type='Lookup'>" + itemId + "</Value></Eq></Where><QueryOptions></QueryOptions><OrderBy><FieldRef Name='Modified' Ascending='FALSE' /></OrderBy>";
                                            qryAssociatedItems.RowLimit = 5;
                                            SPListItemCollection top5AssociatedItems = projectAssociatedList.GetItems(qryAssociatedItems);

                                            sbListAssociatedItemsDiv.Append("<div id='div_items_" + rptListId + "' class='slidingDiv'>");
                                            sbListAssociatedItemsDiv.Append("<div class='fancy-display-form-wrapper slidingDivHeader'>" + listName + "</div>");

                                            if (!EPMLiveCore.API.ListCommands.GetGridGanttSettings(projectAssociatedList).HideNewButton)
                                            {
                                                string newFormUrl = projectAssociatedList.DefaultNewFormUrl + "?LookupField=" + projectLinkedField + "&LookupValue=" + itemId;
                                                sbListAssociatedItemsDiv.Append("<div class='slidingDivAdd'><a href='#' onclick=\"javascript:FancyDispFormClient.showNewForm('" + newFormUrl + "');return false;\"><img title='Add new " + listName + "' alt='' src='/_layouts/epmlive/images/newitem5.png' class='ms-core-menu-buttonIcon'></img></a></div>");
                                            }

                                            sbListAssociatedItemsDiv.Append("<br/>");

                                            sbListAssociatedItemsDiv.Append("<div style='clear:both;'></div>");
                                            sbListAssociatedItemsDiv.Append("<table class='fancy-col-table' style='color:#555555; font-weight:normal;'>");

                                            foreach (SPListItem item in top5AssociatedItems)
                                            {
                                                sbListAssociatedItemsDiv.Append("<tr>");

                                                if (item.Title != null && item.Title.TrimEnd().Length > 25)
                                                {
                                                    sbListAssociatedItemsDiv.Append("<td><a href='#' alt='" + item.Title + "' title='" + item.Title + "' onclick=\"javascript:FancyDispFormClient.showNewForm('" + projectAssociatedList.DefaultDisplayFormUrl + "?ID=" + item.ID + "&Source=" + sourceUrl + "');return false;\">" + item.Title.Substring(0, 25) + "..." + "</a></td>");
                                                }
                                                else
                                                {
                                                    sbListAssociatedItemsDiv.Append("<td><a href='#' alt='" + item.Title + "' title='" + item.Title + "' onclick=\"javascript:FancyDispFormClient.showNewForm('" + projectAssociatedList.DefaultDisplayFormUrl + "?ID=" + item.ID + "&Source=" + sourceUrl + "');return false;\">" + item.Title + "</a></td>");
                                                }

                                                sbListAssociatedItemsDiv.Append("<td>");
                                                sbListAssociatedItemsDiv.Append("<li class='fancyDisplayFormAssociatedItemsContextMenu'>");
                                                sbListAssociatedItemsDiv.Append("<a data-itemid='" + item.ID + "' data-listid='" + projectAssociatedList.ID.ToString() + "' data-webid='" + oWeb.ID + "' data-siteid='" + oWeb.Site.ID + "'>");
                                                sbListAssociatedItemsDiv.Append("</a>");
                                                sbListAssociatedItemsDiv.Append("</li>");
                                                sbListAssociatedItemsDiv.Append("</td>");

                                                sbListAssociatedItemsDiv.Append("</tr>");
                                            }

                                            sbListAssociatedItemsDiv.Append("</table>");
                                            sbListAssociatedItemsDiv.Append("<br/>");

                                            qryAssociatedItems = new SPQuery();
                                            qryAssociatedItems.Query = "<Where><Eq><FieldRef Name='" + projectLinkedField + "' LookupId='True' /><Value Type='Lookup'>" + itemId + "</Value></Eq></Where><QueryOptions></QueryOptions><OrderBy><FieldRef Name='Modified' Ascending='FALSE' /></OrderBy>";
                                            SPListItemCollection otherAssociatedItems = projectAssociatedList.GetItems(qryAssociatedItems);

                                            if (otherAssociatedItems.Count > 5)
                                            {
                                                string viewAllItemsUrl = spWeb.Url + "/_layouts/epmlive/gridaction.aspx?action=linkeditemspost&listid=" + listId + "&lookups=" + itemTitle + "&field=" + projectLinkedField + "&LookupFieldList=" + projectAssociatedList.ID.ToString();// +"&Source=" + sourceUrl;
                                                sbListAssociatedItemsDiv.Append("<a href='#' onclick=\"javascript:FancyDispFormClient.showItemUrl('" + viewAllItemsUrl + "');return false;\">View All " + projectAssociatedList.Title + "</a>");
                                            }

                                            sbListAssociatedItemsDiv.Append("</div>"); //div_items_listGuid - Div Ends..
                                            sbListAssociatedItemsDiv.Append("</div>"); //div_listGUID - Div Ends..
                                            sbListAssociatedItemsDiv.Append("</td></tr>");
                                            #endregion
                                        }
                                    }
                                }
                            }
                            sbListAssociatedItemsDiv.Append("</table></td></tr></table>");
                            //} //Report Admin - if ends...
                        }
                    }
                }
                return Response.Success(sbListAssociatedItemsDiv.ToString());
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        public static string GetFancyFormAssociatedItemAttachments(string data, SPWeb oWeb)
        {
            StringBuilder sbItemAttachments = new StringBuilder();

            try
            {
                #region Xml Parsing - Parameters

                //Parse XML to get paramater values
                var xDoc = new XmlDocument();
                xDoc.LoadXml(data);

                //Set values from parameter
                Guid listId = new Guid(xDoc.GetElementsByTagName("FancyFormListID")[0].InnerText);
                string itemId = xDoc.GetElementsByTagName("FancyFormItemID")[0].InnerText;
                string sourceUrl = HttpUtility.UrlEncode(HttpContext.Current.Request.UrlReferrer.ToString());

                #endregion

                //Using SharePoint Object Model fetching data values
                using (SPSite spSite = new SPSite(oWeb.Site.ID))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(oWeb.ID))
                    {
                        SPList list = spWeb.Lists[listId];
                        SPListItem item = list.GetItemById(Convert.ToInt32(itemId));

                        sbItemAttachments.Append("<div id='attach-wrapper'>");
                        if (item.Attachments != null && item.Attachments.Count == 0)
                        {
                            sbItemAttachments.Append("<table class='fancy-col-table'><tr><td style='color:#bbbbbb;'>There are no attachments, click the \"+\" icon above to upload new attachments.</td></tr></table>");
                        }
                        else
                        {
                            foreach (string fileName in item.Attachments)
                            {
                                string attachmentUrl = spWeb.Url + "/" + list.RootFolder.Url + "/attachments/" + item.ID + "/" + fileName;
                                

                                sbItemAttachments.Append("<div id='attach-text-wrapper'>");

                                sbItemAttachments.Append("<div class='attach-text'>");
                                sbItemAttachments.Append("<span class='icon-file'  style='margin-right:5px;color:#999999;'></span>");
                                sbItemAttachments.Append("<a href='" + attachmentUrl + "' target='_blank' ID='" + fileName + "' class='fancybox'><span>" + fileName + "</span></a>");

                                string deleteAttachmentLink = spWeb.Url + "/_layouts/epmlive/gridaction.aspx?action=deleteitemattachment&listid=" + list.ID.ToString() + "&itemid=" + item.ID + "&fname=" + fileName;// +"&Source=" + sourceUrl;
                                sbItemAttachments.Append("<a href='#' onclick=\"javascript:FancyDispFormClient.DeleteItemAttachment('" + deleteAttachmentLink + "');return false;\"><span class='fui-cross delete' style='top:2px;position:relative;'></span></a>");

                                sbItemAttachments.Append("</div>");
                                sbItemAttachments.Append("</div>");
                            }
                        }
                        sbItemAttachments.Append("</div>");
                    }
                }
                return Response.Success(sbItemAttachments.ToString());
            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }
        }

        #endregion
    }
}
