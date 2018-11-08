using System;
using System.Diagnostics;
using Microsoft.SharePoint;

namespace Dashboard
{
    public static class TaskHelper
    {
        public static void GetTaskCount(
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
    }
}