using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using System.Text;
using EPMLiveCore.ReportHelper;

namespace EPMLiveReportsAdmin.Jobs
{
    /// <summary>
    ///     This job takes care of deleting and repopulating
    ///     sharepoint list item data into DB
    /// </summary>
    public class ListDataCleanupJob : BaseJob
    {
        StringBuilder sbErrors = null;
        private void setRPTSettings(EPMData epmdata, SPSite site)
        {
            int hours = 0;
            string workdays = " ";
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                int startHour = site.RootWeb.RegionalSettings.WorkDayStartHour / 60;
                int endHour = site.RootWeb.RegionalSettings.WorkDayEndHour / 60;
                hours = endHour - startHour - 1;

                int work = site.RootWeb.RegionalSettings.WorkDays;
                for (byte x = 0; x < 7; x++)
                {
                    workdays = ((((work >> x) & 0x01) == 0x01) ? "" : "," + (7 - x)) + workdays;
                }
            });

            if (workdays.Length > 1)
                workdays = workdays.Substring(1);

            string sResults = "";
            epmdata.UpdateRPTSettings(workdays, hours, out sResults);
        }

        private string getReportingConnection(SPWeb web)
        {
            string sCn = "";

            using (SqlConnection cn = CreateConnection())
            {
                try
                {
                    cn.Open();
                    using (var cmd =
                        new SqlCommand(
                            "SELECT Username, Password, DatabaseServer, DatabaseName from RPTDATABASES where SiteId=@SiteId",
                            cn))
                    {
                        cmd.Parameters.AddWithValue("@SiteId", web.Site.ID);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                sCn = "Data Source=" + dr.GetString(2) + ";Initial Catalog=" + dr.GetString(3);
                                if (!dr.IsDBNull(0) && dr.GetString(0) != "")
                                    sCn += ";User ID=" + dr.GetString(0) + ";Password=" + EPMData.Decrypt(dr.GetString(1));
                                else
                                    sCn += ";Trusted_Connection=True";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sErrors = ex.Message;
                }

            }
            return sCn;
        }

        public void execute(SPSite site, SPWeb web, string data)
        {
            sbErrors = new StringBuilder();
            Hashtable hshMessages = null;
            EPMData epmdata = null;
            DataTable dtListResults = null;
            WebAppId = web.Site.WebApplication.Id;
            try
            {
                float webCount = 0;
                base.totalCount = site.AllWebs.Count;

                hshMessages = new Hashtable();
                bool refreshAll = (string.IsNullOrEmpty(data) ? true : false);
                epmdata = new EPMData(true, site.ID, web.ID);

                if (data == null || data == "")
                {
                    data = epmdata.GetListNames();
                    try
                    {
                        setRPTSettings(epmdata, site);
                    }
                    catch (Exception ex)
                    {
                        bErrors = true;
                        sbErrors.Append("<font color=\"red\">Error Updating RPTSettings: " + ex.Message + "</font><br>");
                    }
                }

                //try
                //{
                //    data = epmdata.UpdateListNames(data);
                //}
                //catch (Exception ex)
                //{
                //    bErrors = true;
                //    sErrors += "<font color=\"red\">Error Updating List Names: " + ex.Message + "</font><br>";
                //}

                try
                {
                    epmdata.DeleteAllItemsDB(data, refreshAll);
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error Cleaning Up Tables: " + ex.Message + "</font><br>");
                }

                foreach (string list in data.Split(','))
                {
                    if (!hshMessages.Contains(list))
                        hshMessages.Add(list, "");
                }

                dtListResults = new RefreshLists().InitializeResultsDT(data, refreshAll);

                foreach (SPWeb w in site.AllWebs)
                {
                    // IGNORE spdispose 130, w is being disposed 
                    var dt = new DataTable();
                    try
                    {
                        sbErrors.Append("Processing Web: " + w.Title + " (" + w.ServerRelativeUrl + ")<br>");

                        //Call Reporting Code
                        var rf = new RefreshLists(w, data);

                        rf.StartRefresh(base.JobUid, out dt, refreshAll);
                        rf.AppendStatus(w.Title, w.ServerRelativeUrl, dtListResults, dt);

                        //Process Logs
                        foreach (DictionaryEntry de in hshMessages)
                        {
                            sbErrors.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Processing List (" + de.Key + ")");

                            bool lFailed = false;
                            string msg = "";
                            DataRow[] drMessages = dt.Select("ListName='" + de.Key + "'");
                            if (drMessages.Length > 0)
                            {
                                foreach (DataRow drMessage in drMessages)
                                {
                                    if (drMessage["ResultText"].ToString() != "")
                                    {
                                        msg +=
                                            "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"red\">" +
                                            drMessage["ResultText"] + "</font>";
                                        bErrors = true;
                                        lFailed = true;
                                    }
                                }
                            }

                            if (lFailed)
                                sbErrors.Append(" Failed: " + msg + ".<br>");
                            else
                                sbErrors.Append(" Success.<br>");
                        }
                        updateProgress(webCount++);
                    }
                    catch { }
                    finally
                    {
                        if (dt != null)
                            dt.Dispose();
                        if (w != null)
                            w.Dispose();
                    }
                }
            }
            finally
            {
                sErrors = sbErrors.ToString();
                sbErrors = null;
                var refreshLists = new RefreshLists(web, "");
                refreshLists.SaveResults(dtListResults, base.JobUid);
                finishJob();

                hshMessages = null;
                if (dtListResults != null)
                    dtListResults.Dispose();
                if (epmdata != null)
                    epmdata.Dispose();
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
            }


        }
    }
}