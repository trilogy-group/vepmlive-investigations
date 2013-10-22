﻿using System;
using System.Collections.Generic;
using System.Text;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection;

namespace EPMLiveReportsAdmin.Jobs
{
    /// <summary>
    /// This job takes care of deleting and re-populating
    /// Timesheet, PFE, and Security data in DB.
    /// </summary>
    public class CollectJob : EPMLiveCore.API.BaseJob
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

        private void CheckSP(SqlConnection cn)
        {
            if (cn.State != ConnectionState.Open) cn.Open();

            SqlCommand cmd = new SqlCommand("select * from information_schema.routines where SPECIFIC_NAME = 'spUpdateStatusFields'", cn);
            bool found = false;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                found = true;
            dr.Close();

            if (!found)
            {
                cmd = new SqlCommand(Properties.Resources.spUpdateStatusFields, cn);
                cmd.ExecuteNonQuery();
            }

            cmd = new SqlCommand(Properties.Resources.spGetReportListData, cn);
            cmd.ExecuteNonQuery();
        }

        public void execute(SPSite site, SPWeb web, string data)
        {
            base.totalCount = site.AllWebs.Count;
            Hashtable hshMessages = new Hashtable();
            bool refreshAll = (string.IsNullOrEmpty(data) ? true : false);
            EPMLiveReportsAdmin.EPMData epmdata = new EPMLiveReportsAdmin.EPMData(site.ID);


            #region Process security

            try
            {
                ProcessSecurity.ProcessSecurityGroups(site, epmdata.GetClientReportingConnection, "");
                sErrors += "Completed processing security groups for site: " + site.Url + ".</br>";
            }
            catch (Exception ex)
            {
                bErrors = true;
                sErrors += "<font color=\"red\">Error processing security on site: " + site.Url + ". Error: " + ex.Message + "</font><br>";
            }

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

            try
            {
                data = epmdata.UpdateListNames(data);
            }
            catch (Exception ex)
            {
                bErrors = true;
                sErrors += "<font color=\"red\">Error Updating List Names: " + ex.Message + "</font><br>";
            }

            foreach (SPWeb w in site.AllWebs)
            {
                // IGNORE SPDispose 130 error, web is being disposed
                try
                {
                    List<string> allLists = new List<string>(data.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
                    List<SPList> allSpLists = new List<SPList>();
                    foreach (string l in allLists)
                    {
                        SPList list = w.Lists.TryGetList(l);
                        if (list == null ||
                            list.Title == "Work Hours" ||
                            list.Title == "Resources")
                        {
                            continue;
                        }

                        if (list != null)
                        {
                            allSpLists.Add(list);
                        }
                    }
                    ProcessSecurity.ProcessSecurityOnRefreshAll(w, allSpLists, epmdata.GetClientReportingConnection);
                    if (w != null)
                    {
                        w.Dispose();
                    }
                }
                catch
                {
                    if (w != null)
                    {
                        w.Dispose();
                    }
                }
            }

            #endregion

            #region Process TimeSheet Data
            try
            {
                string err = "";
                bool tErrors = epmdata.RefreshTimesheets(out err, base.JobUid);
                if (tErrors)
                    bErrors = true;
                if (bErrors)
                    sErrors += "<font color=\"red\">Error Processing Timesheets: " + err + "</font><br>";
                else
                    sErrors += "Processed Timesheets<br>";
            }
            catch (Exception ex)
            {
                bErrors = true;
                sErrors += "<font color=\"red\">Error Processing Timesheets: " + ex.Message + "</font><br>";
            }

            #endregion

            #region Process PFE Data

            try
            {
                if (site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null)
                {
                    SPWeb rootWeb = site.RootWeb;

                    string basePath = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "epkbasepath");
                    string ppmId = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmpid");
                    string ppmCompany = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmcompany");
                    string ppmDbConn = EPMLiveCore.CoreFunctions.getConfigSetting(rootWeb, "ppmdbconn");

                    Assembly assemblyInstance = Assembly.Load("PortfolioEngineCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                    Type thisClass = assemblyInstance.GetType("PortfolioEngineCore.WEIntegration.WEIntegration");
                    object classObject = Activator.CreateInstance(thisClass, new object[] { basePath, site.WebApplication.ApplicationPool.Username, ppmId, ppmCompany, ppmDbConn, false });

                    MethodInfo m = thisClass.GetMethod("ExecuteReportExtract");
                    string message = (string)m.Invoke(classObject, new object[] { "<ExecuteReportExtract><Params /><Data><ReportExtract Connection=\"" + getReportingConnection(web) + "\" Execute=\"1\" /></Data></ExecuteReportExtract>" });

                    sErrors += "Processed PfE Reporting: " + message + "<br>";
                }
            }
            catch (Exception ex)
            {
                bErrors = true;
                sErrors += "<font color=\"red\">Error Processing PfE Reporting: " + ex.Message + "</font><br>";
            }

            #endregion Process PFE Data

            #region Database checks
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {   
                CheckReqSP(epmdata.GetClientReportingConnection);
                CheckSchema(epmdata.GetClientReportingConnection);
            });
            #endregion

            #region Clean Data

            DataScrubber.CleanTables(site, epmdata);

            #endregion

            try
            {
                CheckSP(epmdata.GetClientReportingConnection);

                foreach (string list in data.Split(','))
                {
                    if (list != "")
                    {
                        try
                        {
                            SqlCommand cmd2 = new SqlCommand("spUpdateStatusFields", epmdata.GetClientReportingConnection);
                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@listname", list);

                            cmd2.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            bErrors = true;
                            sErrors += "<font color=\"red\">Error running schedule field update for (" + list + "): " + ex.Message + "</font><br>";
                        }
                        if (!hshMessages.Contains(list))
                            hshMessages.Add(list, "");
                    }
                }

                sErrors += "<br>Updated Status Fields<br>";

            }
            catch (Exception ex)
            {
                bErrors = true;
                sErrors += "<font color=\"red\">Error running schedule field update: " + ex.Message + "</font><br>";
            }

            // clear cache

            CacheStore.Current.RemoveSafely(web.Url, CacheStoreCategory.Navigation);
            finishJob();
        }


        private void CheckSchema(SqlConnection cn)
        {
            var cmd = new SqlCommand(Properties.Resources.CheckSchema, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        private void CheckReqSP(SqlConnection cn)
        {
            var cmd = new SqlCommand(Properties.Resources.CheckReqSP, cn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

    }
}
