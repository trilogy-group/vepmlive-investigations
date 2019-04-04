using System;
using System.Diagnostics;
using Microsoft.SharePoint;

namespace Dashboard
{
    internal partial class ProjectData
    {
        public string buildData(bool pTasks, bool pRisks, bool pIssues)
        {
            try
            {
                PopulateDataTable();
                PopulateSummaryGrid();

                try
                {
                    projectList = site.Lists["Project Center"];
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                    return "The Project Center list does not exist on this site.";
                }
                try
                {
                    taskList = site.Lists["Task Center"];
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                    try
                    {
                        taskList = site.Lists["My Tasks"];
                        return
                            "In order to take advantage of the new EPM Live functionality, please follow the instructions located <a href=\"http://www.projectpublisher.com/downloads/ProjectPublisherUpdateProcess.pdf\" target=\"_blank\">here</a>.";
                    }
                    catch (Exception exc)
                    {
                        Trace.TraceError("Exception Suppressed {0}", exc);
                        return "No Tasks List Found";
                    }
                }

                try
                {
                    issueList = site.Lists["Issues"];
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                    pIssues = false;
                }
                try
                {
                    riskList = site.Lists["Risks"];
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                    pRisks = false;
                }

                ProcessListItems(pTasks, pRisks, pIssues);
                gvPJSummary.DataSource = dt;
                gvPJSummary.DataBind();
                return string.Empty;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                return string.Format("{0}{1}", ex.Message, ex.StackTrace);
            }
        }

        private void ProcessListItems(bool pTasks, bool pRisks, bool pIssues)
        {
            foreach (SPListItem listItem in projectList.Items)
            {
                try
                {
                    if (string.Equals(listItem["State"].ToString(), "(2) Active", StringComparison.Ordinal))
                    {
                        processProjectSummaryItem(listItem, pTasks, pRisks, pIssues);
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }
            }
        }
    }
}