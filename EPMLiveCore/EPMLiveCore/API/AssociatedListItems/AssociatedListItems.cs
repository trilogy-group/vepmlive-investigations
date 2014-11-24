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
                string siteUrl = xDoc.GetElementsByTagName("SiteUrl")[0].InnerText;
                string siteId = xDoc.GetElementsByTagName("SiteID")[0].InnerText;
                string webID = xDoc.GetElementsByTagName("WebID")[0].InnerText;
                Guid projectListID = new Guid(xDoc.GetElementsByTagName("ProjectListID")[0].InnerText);
                string projectID = xDoc.GetElementsByTagName("ProjectID")[0].InnerText;
                string projectTitle = xDoc.GetElementsByTagName("ProjectTitle")[0].InnerText;
                string sourceUrl = HttpUtility.UrlEncode(HttpContext.Current.Request.UrlReferrer.ToString());

                #endregion

                //Using SharePoint Object Model fetching data values
                using (SPSite spSite = new SPSite(siteUrl))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(new Guid(webID)))
                    {
                        SPList list = spWeb.Lists[projectListID];

                        arrAssociatedLists = EPMLiveCore.API.ListCommands.GetAssociatedLists(list);

                        if (arrAssociatedLists != null)
                        {
                            #region Prepare DataTable for Associated Items

                            //Prepare query to load list whether it is exists in Reporting database or not?!!
                            sqlGetListHeaders.Append("SELECT * FROM (");
                            foreach (EPMLiveCore.API.AssociatedListInfo item in arrAssociatedLists)
                                sqlGetListHeaders.Append("SELECT '" + item.Title + "' ListID UNION ");

                            sqlLists = sqlGetListHeaders.ToString().Substring(0, sqlGetListHeaders.ToString().Length - 7); //Removing last UNION keyword
                            sqlLists = sqlLists + ") AssociatedItemList LEFT OUTER JOIN RPTList ON AssociatedItemList.ListID = RPTList.RPTListId where RPTListId is not null ORDER BY RPTList.ListName";

                            #endregion

                            try
                            {
                                var queryExecutor = new QueryExecutor(spWeb);
                                dtListName = queryExecutor.ExecuteReportingDBQuery(sqlLists, new Dictionary<string, object> { });
                            }
                            catch { }

                            #region Load Associated Items (Count)

                            #endregion

                            if (dtListName != null && dtListName.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtListName.Rows.Count; i++)
                                {
                                    string rptListId = Convert.ToString(dtListName.Rows[i]["RPTListID"]);
                                    string listName = Convert.ToString(dtListName.Rows[i]["ListName"]);
                                    string tableName = Convert.ToString(dtListName.Rows[i]["TableName"]);

                                    //Checking if rptListId is Null or not: If Null then use Object Model to load count, database call otherwise
                                    if (!string.IsNullOrEmpty(rptListId))
                                    {
                                        #region Retrieve associated list count from database

                                        string sql = string.Empty;
                                        sql = "SELECT COUNT(*) AS 'Count' FROM " + tableName + " WHERE ProjectID = " + projectID + " AND ListId = '" + rptListId + "' GROUP BY ProjectID";

                                        DataTable dtListItemCount = null;
                                        try
                                        {
                                            // Wait for 3 seconds just in-case if reporting database is not updated.
                                            Thread.Sleep(3000);
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
                                        sbListAssociatedItemsDiv.Append("<div id='div_" + rptListId + "' class='listMainDiv'>" + listName + " [" + Convert.ToString(associatedItemsCount) + "]");

                                        #endregion
                                    }
                                    else
                                    {
                                        #region Retrieve associated list count using SharePoint Object Model

                                        //SharePoint Object Model to Load Record Count
                                        SPList otherList = spWeb.Lists[listName];
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

                                        query.Query = "<Where><Eq><FieldRef Name='" + projectLinkedField + "' LookupId='True' /><Value Type='Lookup'>" + projectID + "</Value></Eq></Where>";
                                        Int64 itemCount = otherList.GetItems(query).Count;

                                        sbListAssociatedItemsDiv.Append("<div id='div_" + rptListId + "' class='listMainDiv'>" + listName + " [" + Convert.ToString(itemCount) + "]");

                                        #endregion
                                    }

                                    #region Load Top-5 Items (Using SharePoint Object Model)

                                    //Load Top-5 Items...
                                    SPList projectAssociatedList = spWeb.Lists[listName];
                                    SPQuery qryAssociatedItems = new SPQuery();
                                    qryAssociatedItems.Query = "<Where><Eq><FieldRef Name='" + projectLinkedField + "' LookupId='True' /><Value Type='Lookup'>" + projectID + "</Value></Eq></Where><QueryOptions></QueryOptions><OrderBy><FieldRef Name='Modified' Ascending='FALSE' /></OrderBy>";
                                    qryAssociatedItems.RowLimit = 5;
                                    SPListItemCollection top5AssociatedItems = projectAssociatedList.GetItems(qryAssociatedItems);

                                    sbListAssociatedItemsDiv.Append("<div id='div_items_" + rptListId + "' class='slidingDiv'>");
                                    sbListAssociatedItemsDiv.Append("<div class='slidingDivHeader'>" + listName + "</div>");

                                    if (!EPMLiveCore.API.ListCommands.GetGridGanttSettings(projectAssociatedList).HideNewButton)
                                    {
                                        string newFormUrl = projectAssociatedList.DefaultNewFormUrl + "?LookupField=" + projectLinkedField + "&LookupValue=" + projectID;
                                        sbListAssociatedItemsDiv.Append("<div class='slidingDivAdd'><a href='#' onclick=\"javascript:showNewForm('" + newFormUrl + "');return false;\"><img title='Add new " + listName + "' alt='' src='/_layouts/epmlive/images/newitem5.png' class='ms-core-menu-buttonIcon'></img></a></div>");
                                    }

                                    sbListAssociatedItemsDiv.Append("<br/>");

                                    sbListAssociatedItemsDiv.Append("<div style='clear:both;'></div>");
                                    sbListAssociatedItemsDiv.Append("<table>");

                                    foreach (SPListItem item in top5AssociatedItems)
                                    {
                                        sbListAssociatedItemsDiv.Append("<tr>");

                                        if (item.Title != null && item.Title.TrimEnd().Length > 20)
                                        {
                                            sbListAssociatedItemsDiv.Append("<td><a href='#' alt='" + item.Title + "' title='" + item.Title + "' onclick=\"javascript:showNewForm('" + projectAssociatedList.DefaultDisplayFormUrl + "?ID=" + item.ID + "&Source=" + sourceUrl + "');return false;\">" + item.Title.Substring(0, 20) + "..." + "</a></td>");
                                        }
                                        else
                                        {
                                            sbListAssociatedItemsDiv.Append("<td><a href='#' alt='" + item.Title + "' title='" + item.Title + "' onclick=\"javascript:showNewForm('" + projectAssociatedList.DefaultDisplayFormUrl + "?ID=" + item.ID + "&Source=" + sourceUrl + "');return false;\">" + item.Title + "</a></td>");
                                        }

                                        sbListAssociatedItemsDiv.Append("<td>");
                                        sbListAssociatedItemsDiv.Append("<li class='associateditemscontextmenu'>");
                                        sbListAssociatedItemsDiv.Append("<a data-itemid='" + item.ID + "' data-listid='" + projectAssociatedList.ID.ToString() + "' data-webid='" + webID + "' data-siteid='" + siteId + "'>");
                                        sbListAssociatedItemsDiv.Append("</a>");
                                        sbListAssociatedItemsDiv.Append("</li>");
                                        sbListAssociatedItemsDiv.Append("</td>");

                                        sbListAssociatedItemsDiv.Append("</tr>");
                                    }

                                    sbListAssociatedItemsDiv.Append("</table>");
                                    sbListAssociatedItemsDiv.Append("<br/>");
                                    sbListAssociatedItemsDiv.Append("<br/>");

                                    qryAssociatedItems = new SPQuery();
                                    qryAssociatedItems.Query = "<Where><Eq><FieldRef Name='" + projectLinkedField + "' LookupId='True' /><Value Type='Lookup'>" + projectID + "</Value></Eq></Where><QueryOptions></QueryOptions><OrderBy><FieldRef Name='Modified' Ascending='FALSE' /></OrderBy>";
                                    SPListItemCollection otherAssociatedItems = projectAssociatedList.GetItems(qryAssociatedItems);

                                    if (otherAssociatedItems.Count > 5)
                                    {
                                        string viewAllItemsUrl = spWeb.Url + "/_layouts/epmlive/gridaction.aspx?action=linkeditemspost&listid=" + projectListID + "&lookups=" + projectTitle + "&field=" + projectLinkedField + "&LookupFieldList=" + projectAssociatedList.ID.ToString();// +"&Source=" + sourceUrl;
                                        sbListAssociatedItemsDiv.Append("<a href='#' onclick=\"javascript:showItemUrl('" + viewAllItemsUrl + "');return false;\">View All " + projectAssociatedList.Title + "</a>");
                                    }

                                    sbListAssociatedItemsDiv.Append("</div>"); //div_items_listGuid - Div Ends..
                                    sbListAssociatedItemsDiv.Append("</div>"); //div_listGUID - Div Ends..

                                    if (i != dtListName.Rows.Count - 1)
                                        sbListAssociatedItemsDiv.Append("<div class='pipeSeperator'>|</div>");

                                    #endregion
                                }
                            }

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

                        if (arrAssociatedLists != null)
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
                                            #region Retrieve associated list count using SharePoint Object Model

                                            //SharePoint Object Model to Load Record Count
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

        #endregion
    }
}

//No code change (EPML-3860, EPML-3433)