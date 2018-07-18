using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using System.Data.SqlClient;
using System.Data;
using EPMLiveCore.Infrastructure.Logging;
using static EPMLiveCore.Infrastructure.Logging.LoggingService;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore.Jobs
{
    public class ResourcePlan : API.BaseJob
    {
        private DataTable dtResLink;
        private DataTable dtResInfo;
        StringBuilder sbErrors = null;
        public void execute(SPSite site, SPWeb web, string data)
        {
            WebAppId = site.WebApplication.Id;
            sbErrors = new StringBuilder();
            try
            {
                queuetype = 1;

                if (!initJob(site))
                    return;

                LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.TimerJob, TraceSeverity.Monitorable, "Resource Plan Job Started");

                string resPlanLists = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveResPlannerLists");
                if (resPlanLists.Trim() != "")
                {

                    string sFixLists = EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveFixLists");
                    using (SqlConnection cn = CreateConnection())
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
                        }
                        catch (Exception ex)
                        {
                            bErrors = true;
                            sErrors = ex.ToString();
                        }
                    }
                    buildResPlanInfo();

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

                    float webCount = 0;
                    base.totalCount = site.AllWebs.Count;

                    foreach (SPWeb w in site.AllWebs)
                    {
                        try
                        {
                            sbErrors.Append("<br>Processing Web: " + w.Title + " (" + w.ServerRelativeUrl + ")");
                            processResPlan(w, resPlanLists, site.ID, hours, workdays);

                        }
                        catch (Exception ex)
                        {
                            LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.TimerJob, TraceSeverity.High, String.Format("StackTrace-{0}{1}Message-{2}", ex.StackTrace, Environment.NewLine, ex.Message));
                        }
                        finally
                        {
                            if (w != null)
                                w.Dispose();
                        }
                        updateProgress(webCount++);
                    }
                    using (SqlConnection conn = CreateConnection())
                    {
                        try
                        {
                            SPSecurity.RunWithElevatedPrivileges(delegate ()
                            {
                                conn.Open();
                            });
                            storeResPlanInfo();
                        }
                        catch (Exception ex)
                        {
                            bErrors = true;
                            sErrors = ex.ToString();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.TimerJob, TraceSeverity.High, String.Format("StackTrace-{0}{1}Message-{2}", ex.StackTrace, Environment.NewLine, ex.Message));
                throw ex;
            }
            finally
            {
                sErrors = sbErrors.ToString();
                sbErrors = null;
                finishJob();
                if (dtResLink != null)
                    dtResLink.Dispose();
                if (dtResInfo != null)
                    dtResInfo.Dispose();
                if (web != null)
                    web.Dispose();
                if (site != null)
                    site.Dispose();
                data = null;
                LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.TimerJob, TraceSeverity.Monitorable, "Resource Plan Job Completed");
            }
        }

        private void processResPlan(SPWeb web, string resPlanLists, Guid siteId, int hours, string workdays)
        {
            var resourceUrl = getResUrl(EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL"));

            var processingResult = ProcessResourcePlan(
                resourceUrl,
                web,
                resPlanLists,
                siteId,
                hours,
                workdays
            );

            foreach(var resourceLinkRow in processingResult.ResourceLinkRows)
            {
                dtResLink.Rows.Add(resourceLinkRow);
            }

            foreach(var resourceInfoRow in processingResult.ResourceInfoRows)
            {
                dtResInfo.Rows.Add(resourceInfoRow);
            }

            foreach(var infoMessage in processingResult.InfoMessages)
            {
                sbErrors.Append("<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                sbErrors.Append(infoMessage);
            }

            foreach(var errorMessage in processingResult.ErrorMessages)
            {
                bErrors = true;
                sbErrors.Append("...<font color=\"red\">Error: " + errorMessage + "</font>");
            }
        }

        private void buildResPlanInfo()
        {
            dtResInfo = new DataTable();
            dtResInfo.Columns.Add("Project");
            dtResInfo.Columns.Add("Title");
            dtResInfo.Columns.Add("AssignedTo");
            dtResInfo.Columns.Add("StartDate", typeof(DateTime));
            dtResInfo.Columns.Add("DueDate", typeof(DateTime));
            dtResInfo.Columns.Add("ItemType");
            dtResInfo.Columns.Add("Status");
            dtResInfo.Columns.Add("Work");
            dtResInfo.Columns.Add("SiteId", typeof(Guid));

            dtResLink = new DataTable();
            dtResLink.Columns.Add("weburl");
            dtResLink.Columns.Add("resurl");
            dtResLink.Columns.Add("siteid", typeof(Guid));
            dtResLink.Columns.Add("nonworkdays");
            dtResLink.Columns.Add("workhours");
        }

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

        private string getResUrl(string resUrl)
        {
            try
            {
                //resUrl = resUrl.Substring(resUrl.IndexOf("/", resUrl.IndexOf("//")+2));
                if (resUrl.StartsWith("/"))
                    return resUrl;

                System.Uri u = new Uri(resUrl);
                resUrl = u.AbsolutePath;
            }
            catch (Exception ex)
            {
                LoggingService.WriteTrace(Area.EPMLiveCore, Categories.EPMLiveCore.TimerJob, TraceSeverity.High, String.Format("StackTrace-{0}{1}Message-{2}", ex.StackTrace, Environment.NewLine, ex.Message));
            }

            return resUrl;
        }
        
        public static ResourcePlanProcessingResult ProcessResourcePlan(
            string resourceUrl,
            SPWeb web, 
            string resourcePlanListsString, 
            Guid siteId, 
            int hours, 
            string workdays
        )
        {
            var result = new ResourcePlanProcessingResult();
            if (!string.IsNullOrWhiteSpace(resourceUrl))
            {
                result.ResourceLinks.Add(new ResourcePlanProcessingResult.ResourceLink(
                    web.ServerRelativeUrl, 
                    resourceUrl, 
                    siteId, 
                    workdays, 
                    hours));

                if (!string.IsNullOrWhiteSpace(resourcePlanListsString))
                {
                    var resourcePlanListsCollection = resourcePlanListsString.Replace("\r\n", "\n").Split('\n');

                    foreach (var resourcePlanList in resourcePlanListsCollection)
                    {
                        if (!string.IsNullOrWhiteSpace(resourcePlanList))
                        {
                            result.InfoMessages.Add("Processing: " + resourcePlanList);
                            ProcessResourcePlanList(resourcePlanList, web, siteId, ref result);
                        }
                    }
                }
            }

            return result;
        }

        private static void ProcessResourcePlanList(string resourcePlanList, SPWeb web, Guid siteId, ref ResourcePlanProcessingResult result)
        {
            try
            {
                var list = web.Lists[resourcePlanList];
                var query = new SPQuery();
                query.Query = "<Where><And><And><And><IsNotNull><FieldRef Name=\"StartDate\"/></IsNotNull><IsNotNull><FieldRef Name=\"DueDate\"/></IsNotNull></And><IsNotNull><FieldRef Name=\"Work\"/></IsNotNull></And><IsNotNull><FieldRef Name=\"AssignedTo\"/></IsNotNull></And></Where>";

                foreach (SPListItem listItem in list.GetItems(query))
                {
                    var resourceInfos = ProcessResourcePlanListItem(listItem, list, web, siteId, resourcePlanList);
                    foreach(var resourceInfo in resourceInfos)
                    {
                        result.ResourceInfos.Add(resourceInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                WriteTrace(
                    Area.EPMLiveCore,
                    Categories.EPMLiveCore.TimerJob,
                    TraceSeverity.High,
                    string.Format("StackTrace-{0}{1}Message-{2}", ex.StackTrace, Environment.NewLine, ex.Message));

                if (ex.Message != "Value does not fall within the expected range.")
                {
                    result.ErrorMessages.Add(ex.Message);
                }
            }
        }

        private static IEnumerable<ResourcePlanProcessingResult.ResourceInfo> ProcessResourcePlanListItem(SPListItem listItem, SPList list, SPWeb web, Guid siteId, string resourcePlanList)
        {
            var project = string.Empty;
            var assignedTo = string.Empty;

            try
            {
                project = listItem[list.Fields.GetFieldByInternalName("Project").Id].ToString();
                var lookupValue = new SPFieldLookupValue(project);
                project = lookupValue.LookupValue;
            }
            catch (Exception ex)
            {
                WriteTrace(
                    Area.EPMLiveCore,
                    Categories.EPMLiveCore.TimerJob,
                    TraceSeverity.VerboseEx,
                    string.Format("StackTrace-{0}{1}Message-{2}", ex.StackTrace, Environment.NewLine, ex.Message));
            }

            try
            {
                assignedTo = listItem[list.Fields.GetFieldByInternalName("AssignedTo").Id].ToString();
            }
            catch (Exception ex)
            {
                WriteTrace(
                    Area.EPMLiveCore,
                    Categories.EPMLiveCore.TimerJob,
                    TraceSeverity.VerboseEx,
                    string.Format("StackTrace-{0}{1}Message-{2}", ex.StackTrace, Environment.NewLine, ex.Message));
            }

            var userValueCollection = new SPFieldUserValueCollection(web, assignedTo);
            foreach (SPFieldUserValue userValue in userValueCollection)
            {
                float work = 0;
                try
                {
                    work = float.Parse(listItem[list.Fields.GetFieldByInternalName("Work").Id].ToString());
                    work = work / userValueCollection.Count;
                }
                catch (Exception ex)
                {
                    WriteTrace(
                        Area.EPMLiveCore,
                        Categories.EPMLiveCore.TimerJob,
                        TraceSeverity.VerboseEx,
                        string.Format("StackTrace-{0}{1}Message-{2}", ex.StackTrace, Environment.NewLine, ex.Message));
                }

                yield return new ResourcePlanProcessingResult.ResourceInfo(
                    project,
                    listItem.Title,
                    userValue.LookupValue,
                    listItem[list.Fields.GetFieldByInternalName("StartDate").Id].ToString(),
                    listItem[list.Fields.GetFieldByInternalName("DueDate").Id].ToString(),
                    resourcePlanList,
                    listItem[list.Fields.GetFieldByInternalName("Status").Id].ToString(),
                    work,
                    siteId
                );
            }
        }
    }
}
