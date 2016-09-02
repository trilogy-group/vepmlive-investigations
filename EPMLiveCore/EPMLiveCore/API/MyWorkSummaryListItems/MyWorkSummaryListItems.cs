using Microsoft.SharePoint;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EPMLiveCore.API
{
    public class MyWorkSummaryListItems
    {
        #region My Work Summary List Items Web Part Methods

        /// <summary>
        /// This method retrieves my work items filtered by WorkType
        /// </summary>
        /// <param name="data">My Work Summary list data param string</param>
        /// <returns></returns>
        public static string GetMyWorkSummary(string data)
        {
            try
            {
                #region Xml Parsing - Parameters

                StringBuilder sbListMyWorkSummaryItemsDiv = new StringBuilder();
                string sqlquery = string.Empty;
                DataTable dtMyWorkSummary = null;

                //Parse XML to get paramater values
                var xDoc = new XmlDocument();
                xDoc.LoadXml(data);

                //Set values from parameter          
                string siteUrl = xDoc.GetElementsByTagName("SiteUrl")[0].InnerText;
                string siteId = xDoc.GetElementsByTagName("SiteID")[0].InnerText;
                string webID = xDoc.GetElementsByTagName("WebID")[0].InnerText;
                string currentUserId = xDoc.GetElementsByTagName("CurrentUserId")[0].InnerText;


                #endregion

                using (SPSite spSite = new SPSite(siteUrl))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(new Guid(webID)))
                    {
                        var queryExecutor = new EPMLiveCore.ReportingProxy.QueryExecutor(spWeb);
                        if (queryExecutor != null)
                        {
                            //sqlquery = string.Format("Select l1.WorkType as WORKTYPE,COUNT(l1.WorkType) as WORKTYPECOUNT,l1.ListId as RPTLISTID, isnull(l2.ListIcon,'') as RPTLISTICON FROM LSTMyWork l1 left join ReportListIds l2 on l1.ListId = l2.id where l1.AssignedToText = '{0}' and l1.Siteid = '{1}' and l1.WebId = '{2}' and (l1.Complete <> 1 or l1.Complete is null) GROUP BY l1.WorkType, l1.ListId, l2.ListIcon Order by l1.WorkType", currentUser, siteId, webID);

                            sqlquery = string.Format("Select l1.WorkType as WORKTYPE,COUNT(l1.WorkType) as WORKTYPECOUNT,l1.ListId as RPTLISTID, isnull(l2.ListIcon,'') as RPTLISTICON FROM LSTMyWork l1 left join ReportListIds l2 on l1.ListId = l2.id where l1.AssignedToID = '{0}' and l1.Siteid = '{1}' and l1.WebId = '{2}' and (l1.Complete <> 1 or l1.Complete is null) GROUP BY l1.WorkType, l1.ListId, l2.ListIcon Order by l1.WorkType", currentUserId, siteId, webID);
                            dtMyWorkSummary = queryExecutor.ExecuteReportingDBQuery(sqlquery, new Dictionary<string, object> { });
                        }

                        #region Load My Work Summary Items and Count

                        if (dtMyWorkSummary != null && dtMyWorkSummary.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtMyWorkSummary.Rows.Count; i++)
                            {
                                string workType = Convert.ToString(dtMyWorkSummary.Rows[i]["WORKTYPE"]);
                                string workTypeCount = Convert.ToString(dtMyWorkSummary.Rows[i]["WORKTYPECOUNT"]);
                                string rptListId = Convert.ToString(dtMyWorkSummary.Rows[i]["RPTLISTID"]);
                                string rptListIcon = Convert.ToString(dtMyWorkSummary.Rows[i]["RPTLISTICON"]);
                                if (Convert.ToInt32(workTypeCount) >= 100)
                                {
                                    workTypeCount = "99+";
                                }
                                //sbListMyWorkSummaryItemsDiv.Append(string.Format("<a href='#' onclick=\"javascript:MyWorkSummaryClient.openMyWorkPage('{0}','{1}');\"><div class='row'><div class='mwsItemDiv'><div class='icon-wrapper'><div class='icon fa {2}'></div><div class='text'>{3}</div></div><div class='count'>{4}</div></div></div></a>", siteUrl, rptListId, rptListIcon, workType, workTypeCount));
                                sbListMyWorkSummaryItemsDiv.Append(string.Format("<a href='#' onclick=\"javascript:MyWorkSummaryClient.openMyWorkPage('{0}','{1}');\"> <section><div class='icon fa {2}'></div><div class='text'>{3}</div><div class='count'>{4}</div> </section></a>", siteUrl, rptListId, rptListIcon, workType, workTypeCount));
                            }
                        }


                        #endregion

                    }
                }
                return Response.Success(sbListMyWorkSummaryItemsDiv.ToString());
            }

            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }

        }

        #endregion
    }
}
