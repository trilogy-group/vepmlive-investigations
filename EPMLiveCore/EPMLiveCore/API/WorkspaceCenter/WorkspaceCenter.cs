using EPMLiveCore.Infrastructure.Navigation;
using EPMLiveCore.Properties;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace EPMLiveCore.API
{
    public class WorkspaceCenter
    {
        #region Work Space Center Web Part Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static string GetWorkspaceCenterGridData(string data, SPWeb oWeb)
        {
            try
            {
                #region Xml Parsing - Parameters

                StringBuilder sbListWorkSpaceCenterDiv = new StringBuilder();
                string sqlquery = string.Empty;
                DataTable dtWorkspacecenterData = null;
                DataTable dtFRFData = null;
                DataTable dtRPTWebData = null;
                var result = new XDocument();
                #endregion

                
                using (SPSite spSite = new SPSite(oWeb.Site.ID))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(oWeb.ID))
                    {
                        try
                        {
                            var queryExecutor = new QueryExecutor(spWeb);
                            if (data == "MyFavorite")
                            {
                                sqlquery = string.Format("select WEB_ID from FRF where [TYPE] = 4 and USER_ID ={0}", SPContext.Current.Web.CurrentUser.ID);
                                dtFRFData = queryExecutor.ExecuteEpmLiveQuery(sqlquery, new Dictionary<string, object> { });
                                dtRPTWebData = queryExecutor.ExecuteReportingDBStoredProc("spGetWorkspaces",
                                   new Dictionary<string, object>
                            {
                                {"@SiteId", oWeb.Site.ID},
                                {"@UserId", spWeb.CurrentUser.ID},
                                {"@View","AllItems"}
                            });
                                if (dtRPTWebData != null && dtRPTWebData.Rows.Count > 0)
                                {
                                    dtWorkspacecenterData =
                                                            (from rptWebRow in dtRPTWebData.AsEnumerable()
                                                             join frfRow in dtFRFData.AsEnumerable()
                                                             on rptWebRow["WebId"] equals frfRow["WEB_ID"]
                                                             into tempDelete
                                                             where tempDelete.Count() > 0
                                                             select rptWebRow).CopyToDataTable();

                                }
                            }
                            else
                            {
                                dtWorkspacecenterData = queryExecutor.ExecuteReportingDBStoredProc("spGetWorkspaces",
                                    new Dictionary<string, object>
                            {
                                {"@SiteId", oWeb.Site.ID},
                                {"@UserId", spWeb.CurrentUser.ID},
                                {"@View",data}
                            });
                            }
                        }
                        catch
                        {
                        }

                        result.Add(new XElement("Grid"));
                        XElement grid = result.Element("Grid");
                        grid.Add(new XElement("Body"));
                        grid.Element("Body").Add(new XElement("B"));
                        XElement body = grid.Element("Body").Element("B");

                        if (dtWorkspacecenterData != null && dtWorkspacecenterData.Rows.Count > 0)
                        {
                            string sqlGetAllWebs = string.Empty;
                            DataTable dtSPData = new DataTable();
                            sqlGetAllWebs = "SELECT TimeCreated,LastMetadataChange,SiteId,Id FROM AllWebs";

                            using (SqlConnection sqlConnection = GetSpContentDbSqlConnection(spWeb))
                            {
                                using (var sqlCommand = new SqlCommand(sqlGetAllWebs, sqlConnection))
                                {
                                    SPSecurity.RunWithElevatedPrivileges(sqlConnection.Open);
                                    SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                                    da.Fill(dtSPData);
                                    sqlConnection.Close();
                                }
                            }

                            for (int i = 0; i < dtWorkspacecenterData.Rows.Count; i++)
                            {
                                if (dtWorkspacecenterData.Rows[i]["HasAccess"].Equals(1))
                                {
                                    var j = new XElement("I");
                                    string CDate = string.Empty;
                                    string UDate = string.Empty;
                                    var dates = (from myRow in dtSPData.AsEnumerable()
                                                 where ((myRow.Field<Guid>("Id") == (Guid)dtWorkspacecenterData.Rows[i]["WebId"]) && (myRow.Field<Guid>("SiteId") == spWeb.Site.ID))
                                                 select new
                                                 {
                                                     CreatedDate = myRow.Field<DateTime>("TimeCreated"),
                                                     ModifiedDate = myRow.Field<DateTime>("LastMetadataChange"),

                                                 }).FirstOrDefault();
                                    CDate = dates.CreatedDate.ToShortDateString();
                                    UDate = dates.ModifiedDate.ToShortDateString();
                                    //string WebTitle = Convert.ToString(dtWorkspacecenterData.Rows[i]["WebTitle"]);
                                    //string WebTitle = "<div> <div style='float:left;'>" + Convert.ToString(dtWorkspacecenterData.Rows[i]["WebTitle"] + "</div><div style='float:right;'><ul style='margin: 0px; width: 20px;'><li class='workspacecentercontextmenu'><a data-itemid='20'data-listid= '70045944-8348-4D19-A846-1911DF213FFA' data-webid='" + oWeb.ID + "' data-siteid='" + oWeb.Site.ID + "'></a></li></ul></div> </div>");
                                    string WebTitle = "<div> <div style='float:left;'><a href='" + Convert.ToString(dtWorkspacecenterData.Rows[i]["WebUrl"]) + "'>" + Convert.ToString(dtWorkspacecenterData.Rows[i]["WebTitle"]) + "</a></div><div style='float:right;'><ul style='margin: 0px; width: 20px;'><li class='workspacecentercontextmenu' id='" + oWeb.ID + "'><a data-webid='" + oWeb.ID + "' data-siteid='" + oWeb.Site.ID + "'></a></li></ul></div></div>";
                                    string Description = Convert.ToString(dtWorkspacecenterData.Rows[i]["WebDescription"]);
                                    string Members = Convert.ToString(dtWorkspacecenterData.Rows[i]["Members"]);
                                    string Owner = Convert.ToString(dtWorkspacecenterData.Rows[i]["SharePointAccountText"]);

                                    j.Add(new XAttribute("WorkSpace", WebTitle));
                                    j.Add(new XAttribute("Description", Description));
                                    j.Add(new XAttribute("Owner", Owner));
                                    j.Add(new XAttribute("CreateDate", CDate));
                                    j.Add(new XAttribute("ModifiedDate", UDate));
                                    j.Add(new XAttribute("Members", Members));

                                    body.Add(j);
                                }
                            }

                        }

                    }
                }
                return result.ToString();

            }
            catch (APIException ex)
            {
                return Response.Failure(ex.ExceptionNumber, string.Format("Error: {0}", ex.Message));
            }

        }
        /// <summary>
        ///     Gets the SP content DB SQL connection.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <returns></returns>
        public static SqlConnection GetSpContentDbSqlConnection(SPWeb spWeb)
        {
            try
            {
                SqlConnection sqlConnection = null;
                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    string databaseConnectionString =
                        spWeb.Site.ContentDatabase.DatabaseConnectionString;
                    sqlConnection = new SqlConnection(databaseConnectionString);
                });
                return sqlConnection;
            }
            catch (APIException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new APIException(2008, e.Message);
            }
        }
        #endregion

        #region Work Space Center Layout Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static string GetWorkSpaceCenterLayout(string data)
        {
            XDocument result = XDocument.Parse(Resources.WorkSpaceCenterLayout);
            return result.ToString();
        }

        #endregion
    }
}
