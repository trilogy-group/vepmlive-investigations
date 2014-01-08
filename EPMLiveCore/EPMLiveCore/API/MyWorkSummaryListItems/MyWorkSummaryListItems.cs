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
        public static string GetWorkItemsByWorkType(string data)
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
                string currentUser = xDoc.GetElementsByTagName("CurrentUser")[0].InnerText;


                #endregion

                using (SPSite spSite = new SPSite(siteUrl))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(new Guid(webID)))
                    {
                        var queryExecutor = new EPMLiveCore.ReportingProxy.QueryExecutor(spWeb);
                        if (queryExecutor != null)
                        {
                            sqlquery = "Select WorkType as WORKTYPE,COUNT(WorkType) as WORKTYPECOUNT,ListId as RPTLISTID FROM LSTMyWork where Status != 'Completed' and AssignedToText = '" + currentUser + "' and Siteid = '" + siteId + "'  GROUP BY WorkType,ListId";
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

                                sbListMyWorkSummaryItemsDiv.Append(string.Format("<a href='#' onclick=\"javascript:displayMyWorkItemsByFilter();return false;\"><div id=div_{0} class='listMainDiv'>{1}&nbsp;[{2}]</div></a>", rptListId, workType, workTypeCount));

                                if (i != dtMyWorkSummary.Rows.Count - 1)
                                    sbListMyWorkSummaryItemsDiv.Append("<div class='pipeSeperator'>|</div>");
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
