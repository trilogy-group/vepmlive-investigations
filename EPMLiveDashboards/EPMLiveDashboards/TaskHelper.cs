using System;
using System.Diagnostics;
using Microsoft.SharePoint;

namespace Dashboard
{
    public static class TaskHelper
    {
        internal static void GetTaskCount(
            SPList spList,
            string project,
            ref int taskCount,
            ref int milestoneComplete,
            ref int taskComplete,
            ref int milestoneFuture,
            ref int taskFuture,
            ref int milestoneLate,
            ref int taskLate,
            ref int milestoneCurrent,
            ref int taskCurrent)
        {
            if (spList == null)
            {
                throw new ArgumentNullException(nameof(spList));
            }

            var query = new SPQuery();
            query.Query = string.Format("<Where><Eq><FieldRef Name='Project'/><Value Type='Text'>{0}</Value></Eq></Where>", project);

            foreach (SPListItem task in spList.GetItems(query))
            {
                var tskFinish = DateTime.Now;
                var tskStart = DateTime.Now;
                float pctComplete = 0;
                var isMilestone = bool.FalseString;
                try
                {
                    tskStart = DateTime.Parse(task["StartDate"].ToString());
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                    try
                    {
                        tskStart = DateTime.Parse(task["StartDate"].ToString());
                    }
                    catch (Exception innerEx)
                    {
                        Trace.TraceError("Exception Suppressed {0}", innerEx);
                    }
                }
                try
                {
                    tskFinish = DateTime.Parse(task["DueDate"].ToString());
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                    try
                    {
                        tskFinish = DateTime.Parse(task["Finish"].ToString());
                    }
                    catch (Exception innerEx)
                    {
                        Trace.TraceError("Exception Suppressed {0}", innerEx);
                    }
                }
                try
                {
                    pctComplete = float.Parse(task["PercentComplete"].ToString()) * 100;
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }
                try
                {
                    isMilestone = task["Milestone"].ToString();
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }

                if (tskFinish < DateTime.Now.AddDays(-1) && pctComplete < 100)
                {
                    taskCount++;
                }
                if (pctComplete >= 100)
                {
                    if (isMilestone == bool.TrueString)
                    {
                        milestoneComplete++;
                    }
                    else
                    {
                        taskComplete++;
                    }
                }
                else
                {
                    if (tskStart > DateTime.Now && pctComplete == 0)
                    {
                        if (isMilestone == bool.TrueString)
                        {
                            milestoneFuture++;
                        }
                        else
                        {
                            taskFuture++;
                        }
                    }
                    else if (tskFinish < DateTime.Now.AddDays(-1))
                    {
                        if (isMilestone == bool.TrueString)
                        {
                            milestoneLate++;
                        }
                        else
                        {
                            taskLate++;
                        }
                    }
                    else
                    {
                        if (isMilestone == bool.TrueString)
                        {
                            milestoneCurrent++;
                        }
                        else
                        {
                            taskCurrent++;
                        }
                    }
                }
            }
        }

        internal static void ProcessProjectSummaryItem(
            SPWeb spWeb,
            SPListItem listItem,
            bool pTasks,
            bool pRisks,
            bool pIssues,
            Func<string, int> getTaskCountFunc,
            Func<string, string> getRiskStatusFunc,
            Func<string, string> getIssueStatusFunc,
            out DateTime start,
            out DateTime finish,
            out string title,
            out float percentComplete,
            out int taskCount,
            out string scheduleStatus,
            out string riskStatus,
            out string issueStatus)
        {
            if (spWeb == null)
            {
                throw new ArgumentNullException(nameof(spWeb));
            }

            start = new DateTime();
            finish = new DateTime();
            title = string.Format("<a href=\"{0}/Lists/Project%20Center/DispForm.aspx?ID={1}\">{2}</a>", spWeb.Url, listItem.ID, listItem.Title);
            percentComplete = 0;
            taskCount = 0;
            scheduleStatus = string.Empty;
            riskStatus = string.Empty;
            issueStatus = string.Empty;
            var project = string.Empty;

            try
            {
                start = DateTime.Parse(listItem["Start"].ToString());
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            try
            {
                finish = DateTime.Parse(listItem["Finish"].ToString());
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            try
            {
                percentComplete = float.Parse(listItem["PercentComplete"].ToString()) * 100;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            try
            {
                scheduleStatus = listItem["Status"].ToString();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }

            try
            {
                scheduleStatus = listItem["Project"].ToString();
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }

            if (getTaskCountFunc != null && pTasks)
            {
                taskCount = getTaskCountFunc(listItem.Title);
            }

            scheduleStatus = scheduleStatus == "Late"
                ? "<img src=\"/_layouts/images/red.gif\">"
                : "<img src=\"/_layouts/images/green.gif\">";

            if (getRiskStatusFunc != null && pRisks)
            {
                riskStatus = string.Format("<img src=\"/_layouts/images/{0}.gif\">", getRiskStatusFunc(listItem.Title));
            }
            if (getIssueStatusFunc != null && pIssues)
            {
                issueStatus = string.Format("<img src=\"/_layouts/images/{0}.gif\">", getIssueStatusFunc(listItem.Title));
            }
        }
    }
}