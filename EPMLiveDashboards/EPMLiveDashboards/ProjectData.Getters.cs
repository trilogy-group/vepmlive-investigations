using System;
using System.Diagnostics;
using Microsoft.SharePoint;

namespace Dashboard
{
    internal partial class ProjectData
    {
        private string getIssueStatus(string project)
        {
            try
            {
                var status = "green";

                var query = new SPQuery
                {
                    Query = string.Format("<Where><Eq><FieldRef Name='Project'/><Value Type='Text'>{0}</Value></Eq></Where>", project)
                };

                foreach (SPListItem liTask in issueList.GetItems(query))
                {
                    var taskStatus = string.Empty;
                    var dueDate = DateTime.Now;
                    try
                    {
                        taskStatus = liTask["Status"].ToString();
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                    }
                    try
                    {
                        dueDate = DateTime.Parse(liTask["DueDate"].ToString());
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                    }
                    if (taskStatus == "Active")
                    {
                        issue_active++;
                        if (status == "green")
                        {
                            status = "yellow";
                        }
                        if (dueDate < DateTime.Now)
                        {
                            status = "red";
                        }
                    }
                    else if (taskStatus == "Postponed")
                    {
                        issue_postponed++;
                    }
                    else if (taskStatus == "Closed")
                    {
                        issue_closed++;
                    }
                }

                return status;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                return string.Empty;
            }
        }

        private string getRiskStatus(string project)
        {
            try
            {
                var status = "green";

                var query = new SPQuery
                {
                    Query = string.Format("<Where><Eq><FieldRef Name='Project'/><Value Type='Text'>{0}</Value></Eq></Where>", project)
                };

                foreach (SPListItem liTask in riskList.GetItems(query))
                {
                    var taskStatus = string.Empty;
                    var dueDate = DateTime.Now;

                    try
                    {
                        taskStatus = liTask["Status"].ToString();
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                    }
                    try
                    {
                        dueDate = DateTime.Parse(liTask["DueDate"].ToString());
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                    }
                    if (taskStatus == "Active")
                    {
                        risk_active++;
                        if (status == "green")
                        {
                            status = "yellow";
                        }
                        if (dueDate < DateTime.Now)
                        {
                            status = "red";
                        }
                    }
                    else if (taskStatus == "Postponed")
                    {
                        risk_postponed++;
                    }
                    else if (taskStatus == "Closed")
                    {
                        risk_closed++;
                    }
                }

                return status;
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
                return string.Empty;
            }
        }

        private int getTaskCount(string project)
        {
            var taskCount = 0;
            try
            {
                TaskHelper.GetTaskCount(
                    taskList,
                    project,
                    ref taskCount,
                    ref ms_complete,
                    ref task_complete,
                    ref ms_future,
                    ref task_future,
                    ref ms_late,
                    ref task_late,
                    ref ms_current,
                    ref task_current);
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return -1;
            }
            return taskCount;
        }
    }
}