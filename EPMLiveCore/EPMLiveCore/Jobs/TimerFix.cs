﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Data;
using System.Data.SqlClient;

namespace EPMLiveCore.Jobs
{
    public class TimerFix : API.BaseJob
    {
        private DataTable dtResLink;
        private DataTable dtResInfo;
        private string sResErrors = "";
        private bool bResErrors = false;
        StringBuilder sbErrors = null;

        private void storeResPlanInfo()
        {
            using (SqlConnection cn = CreateConnection())
            {
                try
                {

                    cn.Open();

                    using (SqlBulkCopy sbc = new SqlBulkCopy(cn))
                    {
                        sbc.DestinationTableName = "RESINFO";
                        // Number Of Records Processed In One Go 
                        int iRowCount = dtResInfo.Rows.Count;
                        if (iRowCount > 500)
                        {
                            iRowCount = 500;
                        }

                        sbc.BatchSize = iRowCount;
                        sbc.NotifyAfter = dtResInfo.Rows.Count;
                        sbc.WriteToServer(dtResInfo);
                    }

                    using (SqlBulkCopy sbc = new SqlBulkCopy(cn))
                    {
                        sbc.DestinationTableName = "RESLINK";
                        // Number Of Records Processed In One Go 
                        int iRowCount = dtResLink.Rows.Count;
                        if (iRowCount > 500)
                        {
                            iRowCount = 500;
                        }

                        sbc.BatchSize = iRowCount;
                        sbc.NotifyAfter = dtResLink.Rows.Count;
                        sbc.WriteToServer(dtResLink);
                    }
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sErrors = ex.ToString();
                }
            }
        }

        public void execute(SPSite site, SPWeb web, string data)
        {
            sbErrors = new StringBuilder();


            try
            {
                WebAppId = site.WebApplication.Id;
                SqlConnection cn;

                Guid ResJobUid = Guid.Empty;
                try
                {
                    queuetype = 2;

                    if (!initJob(site))
                        return;

                    //==================Code===================

                    string resPlanLists = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveResPlannerLists");
                    //string sFixLists = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveFixLists");
                    string sFixLists = "Resources";
                    using (cn = CreateConnection())
                    {
                        try
                        {
                            SPSecurity.RunWithElevatedPrivileges(delegate ()
                            {
                                cn.Open();
                            });

                            using (SqlCommand cmd = new SqlCommand("DELETE FROM RESINFO where siteid=@siteid", cn))
                            {
                                cmd.Parameters.AddWithValue("@siteid", site.ID);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd1 = new SqlCommand("DELETE FROM RESLINK where siteid=@siteid or siteid in (select siteid from reslink where weburl=@weburl)", cn))
                            {
                                cmd1.Parameters.AddWithValue("@siteid", site.ID);
                                cmd1.Parameters.AddWithValue("@weburl", site.ServerRelativeUrl);
                                cmd1.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd2 = new SqlCommand("select timerjobuid from vwQueueTimer where siteguid=@siteguid and jobtype=1", cn))
                            {
                                cmd2.Parameters.AddWithValue("@siteguid", site.ID);
                                using (SqlDataReader dr = cmd2.ExecuteReader())
                                {
                                    if (dr.Read())
                                    {
                                        ResJobUid = dr.GetGuid(0);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            bErrors = true;
                            sErrors = ex.ToString();
                        }
                    }

                    dtResInfo = ResourcePlan.BuildResourceInfoDataTable();
                    dtResLink = ResourcePlan.BuildResourceLinkDataTable();

                    int hours = 0;
                    string workdays = " ";
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
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

                    float counter = 0;
                    base.totalCount = site.AllWebs.Count;

                    if (sFixLists.Trim().Length > 0)
                    {
                        string[] arLists = sFixLists.Replace("\r\n", "\n").Split('\n');
                        base.totalCount = base.totalCount * arLists.Length;
                    }

                    foreach (SPWeb w in site.AllWebs)
                    {
                        try
                        {
                            sbErrors.Append("<br>Processing Web: " + w.Title + " (" + w.ServerRelativeUrl + ")");
                            sResErrors += "<br>Processing Web: " + w.Title + " (" + w.ServerRelativeUrl + ")";
                            processWeb(w, sFixLists, ref counter);
                            processResPlan(w, resPlanLists, site.ID, hours, workdays);
                        }
                        catch { }
                        finally
                        {
                            if (w != null)
                                w.Dispose();
                        }
                    }

                    //=========================================
                }
                catch (Exception ex)
                {
                    bErrors = true;
                    sbErrors.Append("Execute Error: " + ex.Message);
                }
                //Already Called in TimerClass.cs
                //finishJob();

                using (cn = CreateConnection())
                {
                    try
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate ()
                        {
                            cn.Open();
                        });
                        storeResPlanInfo();

                        if (ResJobUid != Guid.Empty)
                        {
                            //cmd.ExecuteNonQuery();
                            using (SqlCommand cmd = new SqlCommand("update queue set status = 2, dtstarted=ISNULL(dtstarted,getdate()), dtfinished=GETDATE() where timerjobuid=@timerjobuid", cn))
                            {
                                cmd.Parameters.AddWithValue("@timerjobuid", ResJobUid);
                                cmd.ExecuteNonQuery();
                            }

                            using (SqlCommand cmd1 = new SqlCommand("DELETE FROM EPMLIVE_LOG where timerjobuid=@timerjobuid", cn))
                            {
                                cmd1.Parameters.AddWithValue("@timerjobuid", ResJobUid);
                                cmd1.ExecuteNonQuery();
                            }
                            using (SqlCommand cmd2 = new SqlCommand("INSERT INTO EPMLIVE_LOG (timerjobuid,result,resulttext) VALUES (@timerjobuid,@result,@resulttext)", cn))
                            {
                                if (bResErrors)
                                    cmd2.Parameters.AddWithValue("@result", "Errors");
                                else
                                    cmd2.Parameters.AddWithValue("@result", "No Errors");
                                cmd2.Parameters.AddWithValue("@resulttext", sResErrors);
                                cmd2.Parameters.AddWithValue("@timerjobuid", ResJobUid);
                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        bErrors = true;
                        sErrors = ex.Message;
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sErrors += sbErrors.ToString();
                sbErrors = null;
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
            }
        }



        private string getResUrl(string resUrl)
        {
            try
            {
                //resUrl = resUrl.Substring(resUrl.IndexOf("/", resUrl.IndexOf("//")+2));
                System.Uri u = new Uri(resUrl);
                resUrl = u.AbsolutePath;
            }
            catch { }

            return resUrl;
        }

        private void processResPlan(SPWeb web, string resPlanLists, Guid siteId, int hours, string workdays)
        {
            var resourceUrl = getResUrl(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL"));

            var processingResult = ResourcePlan.ProcessResourcePlan(
                resourceUrl,
                web,
                resPlanLists,
                siteId,
                hours,
                workdays);

            foreach (var resourceLinkRow in processingResult.ResourceLinkRows)
            {
                dtResLink.Rows.Add(resourceLinkRow);
            }

            foreach (var resourceInfoRow in processingResult.ResourceInfoRows)
            {
                dtResInfo.Rows.Add(resourceInfoRow);
            }

            foreach (var infoMessage in processingResult.InfoMessages)
            {
                sbErrors.Append("<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                sbErrors.Append(infoMessage);
            }

            foreach (var errorMessage in processingResult.ErrorMessages)
            {
                bErrors = true;
                sbErrors.Append("...<font color=\"red\">Error: ")
                    .Append(errorMessage)
                    .Append("</font>");
            }
        }

        private void processWeb(SPWeb web, string sFixLists, ref float counter)
        {

            SPList oList;

            if (sFixLists.Trim().Length > 0)
            {
                string[] arLists = sFixLists.Replace("\r\n", "\n").Split('\n');

                foreach (string sList in arLists)
                {
                    if (sList.Trim().Length > 0)
                    {
                        try
                        {
                            sbErrors.Append("<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Processing List: " + sList);
                            oList = web.Lists.TryGetList(sList);
                            if (oList != null)
                            {

                                try
                                {
                                    SPQuery query = new SPQuery();
                                    query.Query = "";

                                    SPListItemCollection lic = oList.GetItems(query);
                                    foreach (SPListItem li in lic)
                                    {
                                        foreach (SPField f in oList.Fields)
                                        {
                                            if (f.TypeAsString == "TotalRollup")
                                            {
                                                li[f.InternalName] = getListItemCount(web, f, li.Title);
                                            }
                                        }
                                        try
                                        {
                                            if (oList.Fields.ContainsField("PubUpdate"))
                                                li["PubUpdate"] = li["PubUpdate"];
                                        }
                                        catch { }
                                        try
                                        {
                                            if (oList.Fields.ContainsField("IsPublished"))
                                                li["IsPublished"] = li["IsPublished"];
                                        }
                                        catch { }

                                        if (web.Features[new Guid("ebc3f0dc-533c-4c72-8773-2aaf3eac1055")] != null && sList.ToLower() == "task center")
                                        {
                                            li["taskuid"] = li["taskuid"].ToString();
                                        }
                                        li.SystemUpdate();
                                        //li.Update();
                                    }
                                }
                                catch (Exception exc)
                                {
                                    bErrors = true;
                                    sbErrors.Append("...<font color=\"red\">Error: " + exc.Message + "</font>");
                                }
                                sbErrors.Append("...Success");
                            }
                        }
                        catch (Exception exc)
                        {
                            if (exc.Message != "Value does not fall within the expected range.")
                            {
                                bErrors = true;
                                sbErrors.Append("...<font color=\"red\">Error: " + exc.Message + "</font>");
                            }
                            else
                            {
                                sbErrors.Append("...Skipping");
                            }
                        }
                    }
                    try
                    {
                        updateProgress(counter++);
                    }
                    catch { }
                }
            }
        }

        private double getListItemCount(SPWeb web, SPField f, string project)
        {
            string list = f.GetCustomProperty("ListName").ToString();
            string query = f.GetCustomProperty("ListQuery").ToString();
            string lookup = "";
            try
            {
                lookup = f.GetCustomProperty("LookupColumn").ToString();
            }
            catch { }
            string aggtype = "";
            try
            {
                aggtype = f.GetCustomProperty("AggType").ToString();
            }
            catch { }
            string aggcolumn = "";
            try
            {
                aggcolumn = f.GetCustomProperty("AggColumn").ToString();
            }
            catch { }

            try
            {


                if (lookup == "")
                {
                    lookup = "Project";
                }

                SPList tList = web.Lists[list];

                if (query != "")
                {
                    query = "<And>" + query + "<Eq><FieldRef Name='" + lookup + "'/><Value Type='Lookup'>" + project + "</Value></Eq></And>";
                }
                else
                    query = "<Eq><FieldRef Name='" + lookup + "'/><Value Type='Lookup'>" + project + "</Value></Eq>";

                SPQuery q = new SPQuery();
                q.Query = "<Where>" + query + "</Where>";

                switch (aggtype)
                {
                    case "Sum":
                        double val = 0;
                        foreach (SPListItem li in tList.GetItems(q))
                        {
                            try
                            {
                                string sval = li.Fields.GetFieldByInternalName(aggcolumn).GetFieldValue(li[aggcolumn].ToString()).ToString();
                                if (sval.Contains(";#"))
                                    sval = sval.Replace(";#", "\n").Split('\n')[1];
                                val += double.Parse(sval);
                            }
                            catch { }
                        }
                        return val;
                    case "Avg":
                        double val1 = 0;
                        double counter = 0;
                        foreach (SPListItem li in tList.GetItems(q))
                        {
                            counter++;
                            try
                            {
                                string sval = li.Fields.GetFieldByInternalName(aggcolumn).GetFieldValue(li[aggcolumn].ToString()).ToString();
                                if (sval.Contains(";#"))
                                    sval = sval.Replace(";#", "\n").Split('\n')[1];
                                val1 += double.Parse(sval);
                            }
                            catch { }
                        }
                        if (counter == 0)
                            return 0;
                        return val1 / counter;
                    default:
                        return tList.GetItems(q).Count;
                }

            }
            catch (Exception ex)
            {
                //Response.Write("ERR ROLLUP: " + ex.Message + " " + HttpUtility.HtmlEncode(query) + "<br>");
            }
            return 0;
        }

    }
}
