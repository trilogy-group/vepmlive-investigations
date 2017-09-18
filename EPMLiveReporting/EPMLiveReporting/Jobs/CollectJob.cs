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
                }
            }
            catch (Exception ex)
            {
                bErrors = true;
                sbErrors.Append("<font color=\"red\">Error Updating RPTSettings: " + ex.Message + "</font><br>");
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
                    epmdata.LogRefreshStatus(JobUid, "Reporting Refresh", JobUid, web.Title, "Process Started", 0);
                    try
                    {
                        epmdata.LogRefreshStatus(JobUid, "ProcessSecurityGroups", JobUid, web.Title, "Processing Security Group", 0);
                        ProcessSecurity.ProcessSecurityGroups(site, epmdata.GetClientReportingConnection, "");
                        sbErrors.Append("Completed processing security groups for site: " + site.Url + ".</br>");
                        epmdata.LogRefreshStatus(JobUid, "ProcessSecurityGroups", JobUid, web.Title, "Completed processing security groups for site: " + site.Url, 0);
                    }
                    catch (Exception ex)
                    {
                        var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                        bErrors = true;
                        sbErrors.Append("<font color=\"red\">Error processing security on site: " + site.Url + ". Error: " + message + "</font><br>");
                        epmdata.LogRefreshStatus(JobUid, "ProcessSecurityGroups", JobUid, web.Title, ex.ToString(), 0);
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
                            setRPTSettings(epmdata, site);
                        }
                        catch (Exception ex)
                        {
                            var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                            bErrors = true;
                            sbErrors.Append("<font color=\"red\">Error Updating RPTSettings: " + message + "</font><br>");
                            epmdata.LogRefreshStatus(JobUid, "setRPTSettings", JobUid, web.Title, message, 0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error Updating base: " + ex.Message + "</font><br>");
                    epmdata.LogRefreshStatus(JobUid, "setRPTSettings", JobUid, web.Title, ex.Message, 0);
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
                    bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(web, "epmliveconsolidation"), out consolidationdone);
                    bool tErrors = epmdata.RefreshTimesheets(out err, base.JobUid, consolidationdone);
                    if (tErrors)
                        bErrors = true;
                    if (bErrors)
                    {
                        sbErrors.Append("<font color=\"red\">Error Processing Timesheets: " + err + "</font><br>");
                        epmdata.LogRefreshStatus(JobUid, "RefreshTimesheets", JobUid, web.Title, err, 0);
                    }

                    else
                    {
                        sbErrors.Append("Processed Timesheets<br>");
                        epmdata.LogRefreshStatus(JobUid, "Processed Timesheets", JobUid, web.Title, "Processed Timesheets", 0);
                    }
                       
                }
                catch (Exception ex)
                {
                    var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error Processing Timesheets: " + message + "</font><br>");
                    epmdata.LogRefreshStatus(JobUid, "Process TimeSheet Data", JobUid, web.Title, message, 0);
                }

                #endregion

                #region Process PFE Data

                try
                {
                   
                    if (site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null)
                    {
                        epmdata.LogRefreshStatus(JobUid, " Process PFE Data", JobUid, web.Title, "Process PFE Data", 0);
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
                        epmdata.LogRefreshStatus(JobUid, "Processed PfE Reporting:", JobUid, web.Title, message, 0);
                    }
                }
                catch (Exception ex)
                {
                    var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error Processing PfE Reporting: " + message + "</font><br>");
                    epmdata.LogRefreshStatus(JobUid, "Processed PfE Reporting:", JobUid, web.Title, message, 0);
                }

                #endregion Process PFE Data

                #region Database checks

                try
                {
                    epmdata.LogRefreshStatus(JobUid, "CheckReqSP", JobUid, web.Title, "Started StoreProcedure Alteration", 0);
                    CheckReqSP(epmdata.GetClientReportingConnection);
                    epmdata.LogRefreshStatus(JobUid, "CheckReqSP", JobUid, web.Title, "Completed StoreProcedure Alteration", 0);
                }
                catch (Exception exReqSP)
                {
                    var message = exReqSP.InnerException != null ? exReqSP.InnerException.Message : exReqSP.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error while checking SPRequirement: " + message + "</font><br>");
                    epmdata.LogRefreshStatus(JobUid, "CheckReqSP", JobUid, web.Title, "Error while StoreProcedure Alteration", 0);
                }

                try
                {
                    epmdata.LogRefreshStatus(JobUid, "CheckSchema", JobUid, web.Title, "Started StoreProcedure Alteration", 0);
                    CheckSchema(epmdata.GetClientReportingConnection);
                    epmdata.LogRefreshStatus(JobUid, "CheckSchema", JobUid, web.Title, "Completed StoreProcedure Alteration", 0);
                }
                catch (Exception exSchema)
                {
                    var message = exSchema.InnerException != null ? exSchema.InnerException.Message : exSchema.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error while updating schema: " + message + "</font><br>");
                    epmdata.LogRefreshStatus(JobUid, "CheckSchema", JobUid, web.Title, "Error while  StoreProcedure Alteration", 0);
                }

                #endregion

                #region Clean Data

                try
                {
                    DataScrubber.CleanTables(site, epmdata);
                }
                catch (Exception ex)
                {
                    var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error while cleaning tables: " + message + "</font><br>");
                    epmdata.LogRefreshStatus(JobUid, "CleanTables", JobUid, web.Title, "Error while cleaning tables: " + message, 0);
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
                                epmdata.LogRefreshStatus(JobUid, " Update Status Field", JobUid, web.Title, cmd1.CommandText, 0);
                                using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                                {
                                    da.Fill(ds);
                                    epmdata.LogRefreshStatus(JobUid, " Update Status Field", JobUid, web.Title, "spUpdateStatusFields", 0);
                                    foreach (DataRow dr in ds.Tables[0].Rows)
                                    {
                                        using (var cmd2 = new SqlCommand("spUpdateStatusFields", epmdata.GetClientReportingConnection))
                                        {
                                          
                                            cmd2.CommandType = CommandType.StoredProcedure;
                                            cmd2.Parameters.AddWithValue("@listtable", dr[0].ToString());
                                            cmd2.ExecuteNonQuery();
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
                            epmdata.LogRefreshStatus(JobUid, " Update Status Field", JobUid, web.Title, "Error updating status fields: " + message, 0);
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
                                            epmdata.LogRefreshStatus(JobUid, " Update Status Field", JobUid, web.Title, cmd1.CommandText, 0);
                                            cmd1.Parameters.AddWithValue("@listid", list.ID);
                                            using (SqlDataAdapter da = new SqlDataAdapter(cmd1))
                                            {
                                                da.Fill(ds);

                                                using (var cmd2 = new SqlCommand("spUpdateStatusFields", epmdata.GetClientReportingConnection))
                                                {
                                                    epmdata.LogRefreshStatus(JobUid, " Update Status Field", JobUid, web.Title, "spUpdateStatusFields", 0);
                                                    cmd2.CommandType = CommandType.StoredProcedure;
                                                    cmd2.Parameters.AddWithValue("@listtable", ds.Tables[0].Rows[0][0].ToString());
                                                    cmd2.ExecuteNonQuery();
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                                        bErrors = true;
                                        sbErrors.Append("<font color=\"red\">Error updating status fields (" + sList + "): " + message + "</font><br>");
                                        epmdata.LogRefreshStatus(JobUid, " Update Status Field", JobUid, web.Title, "Error updating status fields (" + sList + "): " + message, 0);
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
                            epmdata.LogRefreshStatus(JobUid, " Update Status Field", JobUid, web.Title, "Error updating status fields: " + message, 0);
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
                                }
                            }
                            catch (Exception ex)
                            {
                                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                                bErrors = true;
                                sbErrors.Append("<font color=\"red\">Error running schedule field update for (" + list + "): " + message + "</font><br>");
                                epmdata.LogRefreshStatus(JobUid, " Update Status Field", JobUid, web.Title, "Error running schedule field update for (" + list + "): " + message, 0);
                            }

                            if (!hshMessages.Contains(list))
                                hshMessages.Add(list, "");
                        }
                    }

                    sbErrors.Append("<br>Updated Status Fields<br>");
                    epmdata.LogRefreshStatus(JobUid, " Update Status Field", JobUid, web.Title, "Updated Status Fields", 0);
                }
                catch (Exception ex)
                {
                    var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Error running schedule field update: " + message + "</font><br>");
                    epmdata.LogRefreshStatus(JobUid, " Update Status Field", JobUid, web.Title, "Error running schedule field update: " + message, 0);
                }

                #endregion

                #region Clear Cache

                try
                {
                    epmdata.LogRefreshStatus(JobUid, "Clear Cache", JobUid, web.Title, "Clearing Cache", 0);
                    CacheStore.Current.RemoveSafely(web.Url, new CacheStoreCategory(web).Navigation);
                    epmdata.LogRefreshStatus(JobUid, "CacheStore.Current.RemoveSafely", JobUid, web.Title, "Cache Cleard", 0);
                }
                catch (Exception ex)
                {
                    var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                    bErrors = true;
                    sbErrors.Append("<font color=\"red\">Clear Cache Error: " + message + "</font><br>");
                    epmdata.LogRefreshStatus(JobUid, "CacheStore.Current.RemoveSafely", JobUid, web.Title, "Clear Cache Error: " + message, 0);
                }

                #endregion
            }
            catch (Exception ex)
            {
                var message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                bErrors = true;
                sbErrors.Append("<font color=\"red\">General Execute Error: " + message + "</font><br>");
                epmdata.LogRefreshStatus(JobUid, "Error", JobUid, web.Title, "General Execute Error: " + message, 0);
            }
            finally
            {
                sErrors = sbErrors.ToString();
                sbErrors = null;
                finishJob();
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