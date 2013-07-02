using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class Action : LayoutsPageBase
    {
        EPMData _DAO;
        protected void Page_Load(object sender, EventArgs e)
        {
            _DAO = new EPMData(SPContext.Current.Site.ID);
            var action = Request["Action"];
            Guid timerjobguid = Guid.NewGuid();
            //DataTable dtResults;

            if (action != null && action == "SnapshotAll")
            {
                try
                {
                    //Local Testing -- Start
                    //_DAO.SnapshotLists(timerjobguid, _DAO.GetListNames());
                    //dtResults = _DAO.GetSnapshotResults(timerjobguid);
                    // -- END

                    //PROD -- Start
                    string sLists = _DAO.GetListNames();
                    using (SPSite site = SPContext.Current.Site)
                    {
                        using (SPWeb web = SPContext.Current.Web)
                        {

                            _DAO.Command = "INSERT INTO TIMERJOBS (timerjobuid, siteguid, jobtype, jobname, scheduletype, webguid, jobdata) VALUES (@timerjobuid,@siteguid, 7, 'Reporting Snapshot All', 0, @webguid, @jobdata)";
                            _DAO.AddParam("@timerjobuid", timerjobguid);
                            _DAO.AddParam("@siteguid", site.ID.ToString());
                            _DAO.AddParam("@webguid", web.ID.ToString());
                            _DAO.AddParam("@jobdata", sLists);
                            _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
                        }
                        EPMLiveCore.CoreFunctions.enqueue(timerjobguid, 0);
                    }
                    //END

                }
                catch (Exception ex)
                {
                    _DAO.LogStatus(string.Empty, string.Empty, "Process: SnapshotAll - " + ex.Message, ex.StackTrace, 2, 9, string.Empty);
                    Response.Write("Error: " + ex.Message);
                    return;
                }
                SPUtility.Redirect("epmlive/ListMappings.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
            else if (action != null && action == "CleanupAll")
            {
                //Local Testing -- Start
                //string sListNames = _DAO.GetListNames();
                //DataTable dtWebResults = null;
                //timerjobguid = new Guid();
                //DataTable dtListResults = new RefreshLists().InitializeResultsDT(sListNames);

                //if (sListNames != string.Empty)
                //{
                //    RefreshLists oListRefresh = null;
                //    foreach (SPWeb web in SPContext.Current.Site.AllWebs)
                //    {
                //        oListRefresh = new RefreshLists(web, sListNames);
                //        oListRefresh.StartRefresh(timerjobguid, out dtWebResults);
                //        dtWebResults.TableName = web.ServerRelativeUrl;
                //        oListRefresh.AppendStatus(web.Name, web.ServerRelativeUrl, dtListResults, dtWebResults);
                //    }
                //    oListRefresh.SaveResults(dtListResults, timerjobguid);
                //}
                // -- End 

                //PROD -- Start
                using (SPSite site = SPContext.Current.Site)
                {
                    using (SPWeb web = SPContext.Current.Web)
                    {
                        //DELETE WORK
                        _DAO.DeleteWork(Guid.Empty, -1);
                        //END

                        _DAO.Command = "select timerjobuid from timerjobs where siteguid=@siteguid and listguid is null and jobtype=6";
                        _DAO.AddParam("@siteguid", site.ID.ToString());
                        object oResult = _DAO.ExecuteScalar(_DAO.GetEPMLiveConnection);
                        Guid timerjobuid = Guid.Empty;

                        if (oResult != null)
                        {
                            timerjobuid = (Guid)oResult;
                        }
                        else
                        {
                            timerjobuid = Guid.NewGuid();
                            _DAO.Command = "INSERT INTO TIMERJOBS (siteguid, jobtype, jobname, scheduletype, webguid, timerjobuid) VALUES (@siteguid, 6, 'List Data Cleanup', 2, @webguid, @timerjobuid)";
                            _DAO.AddParam("@siteguid", site.ID.ToString());
                            _DAO.AddParam("@webguid", web.ID.ToString());
                            _DAO.AddParam("@timerjobuid", timerjobuid);
                            _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
                        }

                        if (timerjobuid != Guid.Empty)
                            EPMLiveCore.CoreFunctions.enqueue(timerjobuid, 0);
                    }
                }
                // -- END
                SPUtility.Redirect("epmlive/ListMappings.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }

        }
    }
}
