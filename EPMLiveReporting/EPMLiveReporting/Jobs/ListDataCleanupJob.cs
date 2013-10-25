using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;


namespace EPMLiveReportsAdmin.Jobs
{
    /// <summary>
    /// This job takes care of deleting and repopulating 
    /// sharepoint list item data into DB
    /// </summary>
    public class ListDataCleanupJob : EPMLiveCore.API.BaseJob
    {
        private void setRPTSettings(EPMLiveReportsAdmin.EPMData epmdata, SPSite site)
        {
            int hours = 0;
            string workdays = " ";
            SPSecurity.RunWithElevatedPrivileges(delegate()
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
            cn.Open();
            string sCn = "";
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Username, Password, DatabaseServer, DatabaseName from RPTDATABASES where SiteId=@SiteId", cn);
                cmd.Parameters.AddWithValue("@SiteId", web.Site.ID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    sCn = "Data Source=" + dr.GetString(2) + ";Initial Catalog=" + dr.GetString(3);
                    if (!dr.IsDBNull(0) && dr.GetString(0) != "")
                        sCn += ";User ID=" + dr.GetString(0) + ";Password=" + EPMData.Decrypt(dr.GetString(1));
                    else
                        sCn += ";Trusted_Connection=True";
                }
            }
            catch { }
            cn.Close();
            return sCn;
        }

        public void execute(SPSite site, SPWeb web, string data)
        {
            float webCount = 0;
            base.totalCount = site.AllWebs.Count;

            Hashtable hshMessages = new Hashtable();
            bool refreshAll = (string.IsNullOrEmpty(data) ? true : false);

            EPMLiveReportsAdmin.EPMData epmdata = new EPMLiveReportsAdmin.EPMData(site.ID);

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
                    sErrors += "<font color=\"red\">Error Updating RPTSettings: " + ex.Message + "</font><br>";
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
                sErrors += "<font color=\"red\">Error Cleaning Up Tables: " + ex.Message + "</font><br>";
            }

            foreach (string list in data.Split(','))
            {
                if (!hshMessages.Contains(list))
                    hshMessages.Add(list, "");
            }

            DataTable dtListResults = new EPMLiveReportsAdmin.RefreshLists().InitializeResultsDT(data, refreshAll);

            foreach (SPWeb w in site.AllWebs)
            {
                // IGNORE spdispose 130, w is being disposed 
                try
                {
                    sErrors += "Processing Web: " + w.Title + " (" + w.ServerRelativeUrl + ")<br>";

                    //Call Reporting Code
                    EPMLiveReportsAdmin.RefreshLists rf = new EPMLiveReportsAdmin.RefreshLists(w, data);
                    DataTable dt = new DataTable();

                    rf.StartRefresh(base.JobUid, out dt, refreshAll);
                    rf.AppendStatus(w.Title, w.ServerRelativeUrl, dtListResults, dt);

                    //Process Logs
                    foreach (DictionaryEntry de in hshMessages)
                    {
                        sErrors += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Processing List (" + de.Key + ")";

                        bool lFailed = false;
                        string msg = "";
                        DataRow[] drMessages = dt.Select("ListName='" + de.Key + "'");
                        if (drMessages.Length > 0)
                        {
                            foreach (DataRow drMessage in drMessages)
                            {
                                if (drMessage["ResultText"].ToString() != "")
                                {
                                    msg += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"red\">" + drMessage["ResultText"].ToString() + "</font>";
                                    bErrors = true;
                                    lFailed = true;
                                }
                            }
                        }

                        if (lFailed)
                            sErrors += " Failed: " + msg + ".<br>";
                        else
                            sErrors += " Success.<br>";
                    }
                    updateProgress(webCount++);
                }
                catch
                {
                    if (w != null)
                    {
                        w.Dispose();
                    }
                }

                if (w != null)
                {
                    w.Dispose();
                }
            }

            EPMLiveReportsAdmin.RefreshLists refreshLists = new EPMLiveReportsAdmin.RefreshLists(web, "");
            refreshLists.SaveResults(dtListResults, base.JobUid);
            finishJob();
        }
    }
}
