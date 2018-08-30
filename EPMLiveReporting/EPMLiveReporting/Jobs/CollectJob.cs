using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using EPMLiveCore;
using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;
using EPMLiveReportsAdmin.Properties;
using Microsoft.SharePoint;
using System.Text;
using EPMLiveCore.ReportHelper;

namespace EPMLiveReportsAdmin.Jobs
{
    /// <summary>
    ///     This job takes care of deleting and re-populating
    ///     Timesheet, PFE, and Security data in DB.
    /// </summary>
    public class CollectJob : BaseJob
    {
        StringBuilder sbErrors = null;
        private void setRPTSettings(EPMData epmdata, SPSite site)
        {
            int hours = 0;
            string workdays = " ";
            try
            {
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

                if (!sResults.Equals("success"))
                {
                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error Updating RPTSettings: " + sResults + "</font><br>");
                    epmdata.LogStatus("", "", "Reporting Refresh UpdateRPTSettings", string.Format("Error Updating RPTSettings {0}", sResults), 2, 3, "");
                }
            }
            catch (Exception ex)
            {
                bErrors = true;
                sbErrors.Append("<font color=\"red\">Error Updating RPTSettings: " + ex.Message + "</font><br>");
                epmdata.LogStatus("", "", "Reporting Refresh UpdateRPTSettings", string.Format("Error Updating RPTSettings  {0}", ex.ToString()), 2, 3, "");
            }
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
                    sbErrors.Append("<font color=\"red\">Error: " + ex.Message + "</font><br>");
                }
            }
            return sCn;
        }


        public void execute(SPSite site, SPWeb web, string data)
        {
            sbErrors = new StringBuilder();
            EPMData epmdata = null;
            Hashtable hshMessages = null;
            SPWeb rootWeb = null;
            try
            {
                hshMessages = new Hashtable();

                #region Process security

                try
                {
                    totalCount = site.AllWebs.Count;
                    epmdata = new EPMData(site.ID);
                    epmdata.LogStatus("", "", "Reporting Refresh  Collect Job", "Reporting refresh process started.", 2, 3, Convert.ToString(JobUid));
                    try
                    {
                        epmdata.LogStatus("", "", "Reporting Refresh  Collect Job", string.Format("Started processing security groups for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                        ProcessSecurity.ProcessSecurityGroups(site, epmdata.GetClientReportingConnection, "");
                        sbErrors.Append("Completed processing security groups for site: " + site.Url + ".</br>");
                        epmdata.LogStatus("", "", "Reporting Refresh  Collect Job", string.Format("Completed processing security groups for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                    }
                    catch (Exception ex)
                    {
                        var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                        bErrors = true;
                        sbErrors.Append("<font color=\"red\">Error processing security on site: " + site.Url + ". Error: " + message + "</font><br>");
                        epmdata.LogStatus("", "", "Reporting Refresh  Collect Job", string.Format("Error processing security on site: {0}. Error: {1}", site.Url, message), 2, 3, Convert.ToString(JobUid));
                    }

                    if (string.IsNullOrEmpty(data))
                    {
                        //try
                        //{
                        //    data = epmdata.GetListNames();
                        //}
                        //catch (Exception exData)
                        //{
                        //    bErrors = true;
                        //    sErrors += "<font color=\"red\">Error while retrieving list names: " + exData.Message + "</font><br>";
                        //}

                        try
                        {
                            epmdata.LogStatus("", "", "Reporting Refresh Collect Job", string.Format("Started updating reporting settings for site: {0}.", site.Url), 2, 3, Convert.ToString(JobUid));
                            setRPTSettings(epmdata, site);
                            epmdata.LogStatus("", "", "Reporting Refresh Collect Job", string.Format("Completed updating reporting settings for site: {0}.", site.Url), 2, 3, Convert.ToString(JobUid));
                        }
                        catch (Exception ex)
                        {
                            var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                            bErrors = true;
                            sbErrors.Append("<font color=\"red\">Error Updating RPTSettings: " + message + "</font><br>");
                            epmdata.LogStatus("", "", "Reporting Refresh Collect Job", string.Format("Updating reporting settings failed for site: {0}. ,Error {1}", site.Url, message), 2, 3, Convert.ToString(JobUid));
                        }
                    }
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error Updating base: " + ex.Message + "</font><br>");
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job", string.Format("Updating reporting settings failed for site: {0}. ,Error {1}", site.Url, ex.Message), 2, 3, Convert.ToString(JobUid));
                }

                #endregion

                #region History

                //try
                //{
                //    data = epmdata.UpdateListNames(data);
                //}
                //catch (Exception ex)
                //{
                //    bErrors = true;
                //    sErrors += "<font color=\"red\">Error Updating List Names: " + ex.Message + "</font><br>";
                //}

                // TODO: We need to make sure this doesn't break anything!!!!
                //foreach (SPWeb w in site.AllWebs)
                //{
                //    // IGNORE SPDispose 130 error, web is being disposed
                //    try
                //    {
                //        List<string> allLists = new List<string>(data.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                //        List<SPList> allSpLists = new List<SPList>();
                //        foreach (string l in allLists)
                //        {
                //            SPList list = w.Lists.TryGetList(l);
                //            if (list == null ||
                //                list.Title == "Work Hours" ||
                //                list.Title == "Resources")
                //            {
                //                continue;
                //            }

                //            if (list != null)
                //            {
                //                allSpLists.Add(list);
                //            }
                //        }
                //        ProcessSecurity.ProcessSecurityOnRefreshAll(w, allSpLists, epmdata.GetClientReportingConnection);
                //        if (w != null)
                //        {
                //            w.Dispose();
                //        }
                //    }
                //    catch
                //    {
                //        if (w != null)
                //        {
                //            w.Dispose();
                //        }
                //    }
                //}

                #endregion

                #region Process TimeSheet Data

                try
                {
                    string err = "";
                    bool consolidationdone;
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Process TimeSheet Data", string.Format("Starting Process TimeSheet Data for site: {0}.", site.Url), 2, 3, Convert.ToString(JobUid));
                    bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "epmliveconsolidation"), out consolidationdone);
                    bool tErrors = epmdata.RefreshTimesheets(out err, base.JobUid, consolidationdone);
                    if (tErrors)
                        bErrors = true;
                    if (bErrors)
                    {
                        sbErrors.Append("<font color=\"red\">Error Processing Timesheets: " + err + "</font><br>");
                        epmdata.LogStatus("", "", "Reporting Refresh Collect Job Process TimeSheet Data", string.Format("Process TimeSheet Data failed for site: {0}. Error {1}", site.Url, err), 2, 3, Convert.ToString(JobUid));
                    }

                    else
                    {
                        sbErrors.Append("Processed Timesheets<br>");
                        epmdata.LogStatus("", "", "Reporting Refresh Collect Job Process TimeSheet Data", string.Format("Completed timeSheet data processing for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                    }

                }
                catch (Exception ex)
                {
                    var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error Processing Timesheets: " + message + "</font><br>");
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Process TimeSheet Data", string.Format("Process TimeSheet Data failed for site: {0}. Error {1}", site.Url, message), 2, 3, Convert.ToString(JobUid));
                }

                #endregion

                #region Process PFE Data

                try
                {

                    if (site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null)
                    {
                        epmdata.LogStatus("", "", "Reporting Refresh Collect Job Process PFE Data", string.Format("Processing PFE Data for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                        rootWeb = site.RootWeb;

                        string basePath = CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                        string ppmId = CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                        string ppmCompany = CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                        string ppmDbConn = CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");

                        Assembly assemblyInstance =
                            Assembly.Load(
                                "PortfolioEngineCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                        Type thisClass = assemblyInstance.GetType("PortfolioEngineCore.WEIntegration.WEIntegration");
                        object classObject = Activator.CreateInstance(thisClass,
                            new object[] { basePath, site.WebApplication.ApplicationPool.Username, ppmId, ppmCompany, ppmDbConn, false });

                        MethodInfo m = thisClass.GetMethod("ExecuteReportExtract");
                        var message =
                            (string)
                                m.Invoke(classObject,
                                    new object[]
                                {
                                    "<ExecuteReportExtract><Params /><Data><ReportExtract Connection=\"" +
                                    getReportingConnection(web) + "\" Execute=\"1\" /></Data></ExecuteReportExtract>"
                                });

                        sbErrors.Append("Processed PfE Reporting: " + message + "<br>");
                        epmdata.LogStatus("", "", "Reporting Refresh Collect Job Process PFE Data", string.Format("Completed Processing PFE Data for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                    }
                }
                catch (Exception ex)
                {
                    var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error Processing PfE Reporting: " + message + "</font><br>");
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Process PFE Data", string.Format("Error Processing PfE Reporting for site: {0} Error {1}", site.Url, message), 2, 3, Convert.ToString(JobUid));
                }

                #endregion Process PFE Data

                #region Database checks

                try
                {
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Database checks", string.Format("Started Database checks for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                    CheckReqSP(epmdata.GetClientReportingConnection);
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Database checks", string.Format("Completed Database checks for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                }
                catch (Exception exReqSP)
                {
                    var message = exReqSP.InnerException != null ? exReqSP.InnerException.Message : exReqSP.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error while checking SPRequirement: " + message + "</font><br>");
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Database checks", string.Format("Error while checking SPRequirement for site: {0} error {1}", site.Url, message), 2, 3, Convert.ToString(JobUid));
                }

                try
                {

                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job updating schema", string.Format("Started updating schema for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                    CheckSchema(epmdata.GetClientReportingConnection);
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job updating schema", string.Format("Completed updating schema for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                }
                catch (Exception exSchema)
                {
                    var message = exSchema.InnerException != null ? exSchema.InnerException.Message : exSchema.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error while updating schema: " + message + "</font><br>");
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job updating schema", string.Format("Error while updating schema for site: {0} error {1}", site.Url, message), 2, 3, Convert.ToString(JobUid));
                }

                #endregion

                #region Clean Data

                try
                {
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job DataScrubber CleanTables", string.Format("Started DataScrubber.CleanTables for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                    DataScrubber.CleanTables(site, epmdata);
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job DataScrubber CleanTables", string.Format("Completed DataScrubber.CleanTables for site: {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                }
                catch (Exception ex)
                {
                    var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error while cleaning tables: " + message + "</font><br>");
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job DataScrubber CleanTables", string.Format("Error while cleaning tables for site: {0} error {1}", site.Url, message), 2, 3, Convert.ToString(JobUid));
                }

                #endregion

                #region Update Status Field

                try
                {
                    if (string.IsNullOrEmpty(data))
                    {
                        DataSet ds = null;
                        try
                        {
                            ds = new DataSet();
                            using (var cmd1 = new SqlCommand("SELECT TABLENAME FROM RPTList", epmdata.GetClientReportingConnection))
                            {
                                epmdata.LogStatus("", "", "Reporting Refresh Collect Job Update Status Field", string.Format("Started Update Status Field for site: {0} ,SQL  (SELECT TABLENAME FROM RPTList) ", site.Url), 2, 3, Convert.ToString(JobUid));
                                using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                                {
                                    da.Fill(ds);

                                    foreach (DataRow dr in ds.Tables[0].Rows)
                                    {
                                        using (var cmd2 = new SqlCommand("spUpdateStatusFields", epmdata.GetClientReportingConnection))
                                        {
                                            cmd2.CommandType = CommandType.StoredProcedure;
                                            cmd2.Parameters.AddWithValue("@listtable", dr[0].ToString());
                                            cmd2.ExecuteNonQuery();
                                            epmdata.LogStatus("", "", "Reporting Refresh Collect Job Update Status Field", string.Format("Executing  store procedure spUpdateStatusFields '{0}'", dr[0].ToString()), 2, 3, Convert.ToString(JobUid));
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                            bErrors = true;
                            sbErrors.Append("<font color=\"red\">Error updating status fields: " + message + "</font><br>");
                            epmdata.LogStatus("", "", "Reporting Refresh Collect Job Update Status Field", string.Format("Error updating status fields: for site {0},error {1} ", site.Url, message), 2, 3, Convert.ToString(JobUid));
                        }
                        finally
                        {
                            if (ds != null)
                                ds.Dispose();
                        }
                    }
                    else
                    {
                        try
                        {
                            foreach (string sList in data.Split(','))
                            {
                                if (sList != "")
                                {
                                    DataSet ds = null;
                                    SPList list = null;
                                    try
                                    {
                                        list = web.Lists[sList];

                                        ds = new DataSet();
                                        using (var cmd1 = new SqlCommand("SELECT TABLENAME FROM RPTList where listid=@listid", epmdata.GetClientReportingConnection))
                                        {
                                            epmdata.LogStatus("", "", "Reporting Refresh Collect Job Update Status Field", string.Format("SELECT TABLENAME FROM RPTList where listid={0} ", list.ID), 2, 3, Convert.ToString(JobUid));
                                            cmd1.Parameters.AddWithValue("@listid", list.ID);
                                            using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                                            {
                                                da.Fill(ds);

                                                using (var cmd2 = new SqlCommand("spUpdateStatusFields", epmdata.GetClientReportingConnection))
                                                {
                                                    cmd2.CommandType = CommandType.StoredProcedure;
                                                    cmd2.Parameters.AddWithValue("@listtable", ds.Tables[0].Rows[0][0].ToString());
                                                    cmd2.ExecuteNonQuery();
                                                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Update Status Field", string.Format("Executed spUpdateStatusFields '{0}' ", Convert.ToString(ds.Tables[0].Rows[0][0])), 2, 3, Convert.ToString(JobUid));
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                                        bErrors = true;
                                        sbErrors.Append("<font color=\"red\">Error updating status fields (" + sList + "): " + message + "</font><br>");
                                        epmdata.LogStatus("", "", "Reporting Refresh Collect Job Update Status Field", string.Format("Error updating status fields ({0}) Error {1}", sList, message), 2, 3, Convert.ToString(JobUid));
                                    }
                                    finally
                                    {
                                        if (ds != null)
                                            ds.Dispose();
                                        list = null;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                            bErrors = true;
                            sbErrors.Append("<font color=\"red\">Error updating status fields: " + message + "</font><br>");
                            epmdata.LogStatus("", "", "Reporting Refresh Collect Job Update Status Field", string.Format("Error updating status fields Error {0}", message), 2, 3, Convert.ToString(JobUid));
                        }

                    }

                    foreach (string list in data.Split(','))
                    {
                        if (list != "")
                        {
                            try
                            {
                                using (var cmd2 = new SqlCommand("spUpdateStatusFields", epmdata.GetClientReportingConnection))
                                {
                                    cmd2.CommandType = CommandType.StoredProcedure;
                                    cmd2.Parameters.AddWithValue("@listtable", list);
                                    cmd2.ExecuteNonQuery();
                                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Update Status Field", string.Format("Executed spUpdateStatusFields '{0}'", list), 2, 3, Convert.ToString(JobUid));
                                }
                            }
                            catch (Exception ex)
                            {
                                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                                bErrors = true;
                                sbErrors.Append("<font color=\"red\">Error running schedule field update for (" + list + "): " + message + "</font><br>");
                                epmdata.LogStatus("", "", "Reporting Refresh Collect Job Update Status Field", string.Format("Error running schedule field update for ({0}) error {1}.", list, message), 2, 3, Convert.ToString(JobUid));
                            }

                            if (!hshMessages.Contains(list))
                                hshMessages.Add(list, "");
                        }
                    }

                    sbErrors.Append("<br>Updated Status Fields<br>");
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Update Status Field", string.Format("Complete  running Updated Status Fields"), 2, 3, Convert.ToString(JobUid));
                }
                catch (Exception ex)
                {
                    var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error running schedule field update: " + message + "</font><br>");
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Update Status Field", string.Format("Error running schedule field update: {0}", message), 2, 3, Convert.ToString(JobUid));
                }

                #endregion

                #region Clear Cache

                try
                {
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Clear Cache", string.Format("Started Cleaning cache for site : {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                    CacheStore.Current.RemoveSafely(web.Url, new CacheStoreCategory(web).Navigation);
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Clear Cache", string.Format("Completed Cleaning cache for site : {0}", site.Url), 2, 3, Convert.ToString(JobUid));
                }
                catch (Exception ex)
                {
                    var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Clear Cache Error: " + message + "</font><br>");
                    epmdata.LogStatus("", "", "Reporting Refresh Collect Job Clear Cache", string.Format("Cleaning Cache Failed for site : {0} error {1}", site.Url, message), 2, 3, Convert.ToString(JobUid));
                }

                #endregion
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                bErrors = true;
                sbErrors.Append("<font color=\"red\">General Execute Error: " + message + "</font><br>");
                epmdata.LogStatus("", "", "Reporting Refresh Collect Job", string.Format("General Execute Error for site : {0} error {1}", site.Url, message), 2, 3, Convert.ToString(JobUid));
            }
            finally
            {
                sErrors = sbErrors.ToString();
                sbErrors = null;
                //Already calling from TimerClass
                //finishJob();
                hshMessages = null;
                if (epmdata != null)
                    epmdata.Dispose();
                if (web != null)
                    web.Dispose();
                if (rootWeb != null)
                    rootWeb.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
            }
        }


        private void CheckSchema(SqlConnection cn)
        {
            using (var cmd = new SqlCommand(Resources.CheckSchema, cn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }

        private void CheckReqSP(SqlConnection cn)
        {
            using (var cmd = new SqlCommand(Resources.CheckReqSP, cn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
        }
    }
}