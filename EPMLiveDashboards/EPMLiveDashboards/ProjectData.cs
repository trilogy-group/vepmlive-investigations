using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

using System.Data;

namespace Dashboard
{
    class ProjectData
    {
        public SPGridView gvPJSummary;
        public SPGridView gvPJSummary2;
        DataTable dt;
        SPList projectList;
        SPList issueList;
        SPList riskList;
        SPList taskList;
        public SPWeb site;

        int task_complete = 0;
        int task_future = 0;
        int task_late = 0;
        int task_current = 0;

        int ms_complete = 0;
        int ms_future = 0;
        int ms_late = 0;
        int ms_current = 0;

        int risk_active = 0;
        int risk_postponed = 0;
        int risk_closed = 0;

        int issue_active = 0;
        int issue_postponed = 0;
        int issue_closed = 0;

        public string error = "";

        public string buildData(bool pTasks, bool pRisks, bool pIssues)
        {
            try
            {
                dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("pctcomplete");
                dt.Columns.Add("latetasks");
                dt.Columns.Add("schedulestatus");
                dt.Columns.Add("issuestatus");
                dt.Columns.Add("riskstatus");

                gvPJSummary = new SPGridView();
                gvPJSummary.AutoGenerateColumns = false;

                BoundField colTitle = new BoundField();
                colTitle.DataField = "name";
                colTitle.HeaderText = "Project Name";
                colTitle.HtmlEncode = false;
                //colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                gvPJSummary.Columns.Add(colTitle);

                colTitle = new BoundField();
                colTitle.DataField = "pctcomplete";
                colTitle.HeaderText = "% Complete";
                colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                gvPJSummary.Columns.Add(colTitle);

                colTitle = new BoundField();
                colTitle.DataField = "latetasks";
                colTitle.HeaderText = "# of Late Tasks";
                colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                gvPJSummary.Columns.Add(colTitle);

                colTitle = new BoundField();
                colTitle.DataField = "schedulestatus";
                colTitle.HeaderText = "Schedule Status";
                colTitle.HtmlEncode = false;
                colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                gvPJSummary.Columns.Add(colTitle);

                colTitle = new BoundField();
                colTitle.DataField = "issuestatus";
                colTitle.HeaderText = "Issue Status";
                colTitle.HtmlEncode = false;
                colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                gvPJSummary.Columns.Add(colTitle);

                colTitle = new BoundField();
                colTitle.DataField = "riskstatus";
                colTitle.HeaderText = "Risk Status";
                colTitle.HtmlEncode = false;
                colTitle.ControlStyle.CssClass = "ms-vh";
                colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                gvPJSummary.Columns.Add(colTitle);

                //gvPJSummary.GroupField = "Status";
                //gvPJSummary.GroupFieldDisplayName = "Status";

                gvPJSummary.AllowGrouping = false;
                gvPJSummary.ID = "gvPJSummary";
                gvPJSummary.Width = Unit.Percentage(100);
                gvPJSummary.HeaderStyle.CssClass = "ms-vh";

                try
                {
                    projectList = site.Lists["Project Center"];
                }
                catch
                {
                    return "The Project Center list does not exist on this site.";
                }
                try
                {
                    taskList = site.Lists["Task Center"];
                }
                catch
                {
                    try
                    {
                        taskList = site.Lists["My Tasks"];
                        return "In order to take advantage of the new EPM Live functionality, please follow the instructions located <a href=\"http://www.projectpublisher.com/downloads/ProjectPublisherUpdateProcess.pdf\" target=\"_blank\">here</a>.";
                    }
                    catch { return "No Tasks List Found"; }

                }

                try
                {
                    issueList = site.Lists["Issues"];
                }
                catch
                {
                    pIssues = false;
                }
                try
                {
                    riskList = site.Lists["Risks"];
                }
                catch
                {
                    pRisks = false;
                }
                
                foreach (SPListItem li in projectList.Items)
                {
                    try
                    {
                        if (li["State"].ToString() == "(2) Active")
                        {
                            processProjectSummaryItem(li, pTasks, pRisks, pIssues);
                        }
                    }
                    catch { }
                }
                gvPJSummary.DataSource = dt;
                gvPJSummary.DataBind();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message + ex.StackTrace;
            }
        }

        public string buildData2()
        {
            dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("pctcomplete");
            dt.Columns.Add("latetasks");
            dt.Columns.Add("schedulestatus");
            dt.Columns.Add("issuestatus");
            dt.Columns.Add("riskstatus");

            gvPJSummary2 = new SPGridView();
            gvPJSummary2.AutoGenerateColumns = false;

            BoundField colTitle = new BoundField();
            colTitle.DataField = "name";
            colTitle.HeaderText = "Project Name";
            colTitle.HtmlEncode = false;
            //colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvPJSummary2.Columns.Add(colTitle);

            colTitle = new BoundField();
            colTitle.DataField = "pctcomplete";
            colTitle.HeaderText = "% Complete";
            colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvPJSummary2.Columns.Add(colTitle);


            colTitle = new BoundField();
            colTitle.DataField = "schedulestatus";
            colTitle.HeaderText = "Schedule";
            colTitle.HtmlEncode = false;
            colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvPJSummary2.Columns.Add(colTitle);

            colTitle = new BoundField();
            colTitle.DataField = "issuestatus";
            colTitle.HeaderText = "Issues";
            colTitle.HtmlEncode = false;
            colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvPJSummary2.Columns.Add(colTitle);

            colTitle = new BoundField();
            colTitle.DataField = "riskstatus";
            colTitle.HeaderText = "Risks";
            colTitle.HtmlEncode = false;
            colTitle.ControlStyle.CssClass = "ms-vh";
            colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvPJSummary2.Columns.Add(colTitle);

            //gvPJSummary.GroupField = "Status";
            //gvPJSummary.GroupFieldDisplayName = "Status";

            gvPJSummary2.AllowGrouping = false;
            gvPJSummary2.ID = "gvPJSummary";
            gvPJSummary2.Width = Unit.Percentage(100);
            gvPJSummary2.HeaderStyle.CssClass = "ms-vh";

            projectList = site.Lists["Project Center"];

            try
            {
                taskList = site.Lists["Task Center"];
            }
            catch
            {
                try
                {
                    taskList = site.Lists["My Tasks"];
                    return "In order to take advantage of the new EPM Live functionality, please follow the instructions located <a href=\"http://www.projectpublisher.com/downloads/ProjectPublisherUpdateProcess.pdf\" target=\"_blank\">here</a>.";
                }
                catch { return "No Tasks List Found"; }
            }

            issueList = site.Lists["Issues"];
            riskList = site.Lists["Risks"];

            foreach (SPListItem li in projectList.Items)
            {
                try
                {
                    if (li["State"].ToString() == "(2) Active")
                    {
                        processProjectSummaryItem2(li);
                    }
                }
                catch { }
            }
            gvPJSummary2.DataSource = dt;
            gvPJSummary2.DataBind();
            return "";
        }

        private void processProjectSummaryItem2(SPListItem li)
        {
            string title = "<a href=\"" + site.Url + "/Lists/Project%20Center/DispForm.aspx?ID=" + li.ID.ToString() + "\">" + li.Title + "</a>";
            DateTime start = new DateTime();
            DateTime finish = new DateTime();
            float pctComplete = 0;
            int taskCount = 0;
            string schedulestatus = "";
            string riskstatus = "";
            string issuestatus = "";

            try
            {
                start = DateTime.Parse(li["Start"].ToString());
            }
            catch { }
            try
            {
                finish = DateTime.Parse(li["Finish"].ToString());
            }
            catch { }
            try
            {
                pctComplete = float.Parse(li["PercentComplete"].ToString()) * 100;
            }
            catch { }
            try
            {
                schedulestatus = li["Status"].ToString();
            }
            catch { }

            try
            {
                schedulestatus = li["Project"].ToString();
            }
            catch { }

            //taskCount = getTaskCount(li.ID.ToString() + ";#" + li.Title);

            if (schedulestatus == "Late")
            {
                schedulestatus = "<img src=\"/_layouts/images/red.gif\">";
            }
            else
            {
                schedulestatus = "<img src=\"/_layouts/images/green.gif\">";
            }

            riskstatus = "<img src=\"/_layouts/images/" + getRiskStatus(li.Title) + ".gif\">";
            issuestatus = "<img src=\"/_layouts/images/" + getIssueStatus(li.Title) + ".gif\">";


            dt.Rows.Add(title, pctComplete.ToString() + "%", "", schedulestatus, issuestatus, riskstatus);
        }

        private void processProjectSummaryItem(SPListItem li, bool pTasks, bool pRisks, bool pIssues)
        {
            string title = "<a href=\"" + site.Url + "/Lists/Project%20Center/DispForm.aspx?ID=" + li.ID.ToString() + "\">" + li.Title + "</a>";
            DateTime start = new DateTime();
            DateTime finish = new DateTime();
            float pctComplete = 0;
            int taskCount = 0;
            string schedulestatus = "";
            string riskstatus = "";
            string issuestatus = "";
            string project = "";

            try
            {
                start = DateTime.Parse(li["Start"].ToString());
            }
            catch { }
            try
            {
                finish = DateTime.Parse(li["Finish"].ToString());
            }
            catch { }
            try
            {
                pctComplete = float.Parse(li["PercentComplete"].ToString()) * 100;
            }
            catch { }
            try
            {
                schedulestatus = li["Status"].ToString();
            }
            catch { }

            try
            {
                schedulestatus = li["Project"].ToString();
            }
            catch { }

            if (pTasks)
                taskCount = getTaskCount(li.Title);

            if (schedulestatus == "Late")
            {
                schedulestatus = "<img src=\"/_layouts/images/red.gif\">";
            }
            else
            {
                schedulestatus = "<img src=\"/_layouts/images/green.gif\">";
            }

            if(pRisks)
                riskstatus = "<img src=\"/_layouts/images/" + getRiskStatus(li.Title) + ".gif\">";
            if(pIssues)
                issuestatus = "<img src=\"/_layouts/images/" + getIssueStatus(li.Title) + ".gif\">";

            
            dt.Rows.Add(title, pctComplete.ToString() + "%", taskCount.ToString(), schedulestatus, issuestatus, riskstatus);
        }

        private string getIssueStatus(string project)
        {
            try
            {
                string status = "green";

                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Project'/><Value Type='Text'>" + project + "</Value></Eq></Where>";

                foreach (SPListItem liTask in issueList.GetItems(query))
                {
                    string pjName = "";
                    string tskStatus = "";
                    DateTime dtDue = DateTime.Now;
                    try
                    {
                        tskStatus = liTask["Status"].ToString();
                    }
                    catch { }
                    try
                    {
                        dtDue = DateTime.Parse(liTask["DueDate"].ToString());
                    }
                    catch { }
                    if (tskStatus == "Active")
                    {
                        issue_active++;
                        if (status == "green")
                            status = "yellow";
                        if (dtDue < DateTime.Now)
                            status = "red";
                    }
                    else if (tskStatus == "Postponed")
                        issue_postponed++;
                    else if (tskStatus == "Closed")
                        issue_closed++;
                }

                return status;
            }
            catch
            {
                return "";
            }
        }

        private string getRiskStatus(string project)
        {
            try
            {

                string status = "green";

                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Project'/><Value Type='Text'>" + project + "</Value></Eq></Where>";

                foreach (SPListItem liTask in riskList.GetItems(query))
                {
                    string pjName = "";
                    string tskStatus = "";
                    DateTime dtDue = DateTime.Now;

                    try
                    {
                        tskStatus = liTask["Status"].ToString();
                    }
                    catch { }
                    try
                    {
                        dtDue = DateTime.Parse(liTask["DueDate"].ToString());
                    }
                    catch { }
                    if (tskStatus == "Active")
                    {
                        risk_active++;
                        if (status == "green")
                            status = "yellow";
                        if (dtDue < DateTime.Now)
                            status = "red";
                    }
                    else if (tskStatus == "Postponed")
                        risk_postponed++;
                    else if (tskStatus == "Closed")
                        risk_closed++;
                }

                return status;
            }
            catch
            {
                return "";
            }
        }

        private int getTaskCount(string project)
        {
            int taskCount = 0;
            try
            {
                //taskList.GetItems();
                SPQuery query = new SPQuery();
                query.Query = "<Where><Eq><FieldRef Name='Project'/><Value Type='Text'>" + project + "</Value></Eq></Where>";

                foreach (SPListItem liTask in taskList.GetItems(query))
                {
                    string pjName = "";
                    DateTime tskFinish = DateTime.Now;
                    DateTime tskStart = DateTime.Now;
                    float pctComplete = 0;
                    string isMS = "False";
                    try
                    {
                        tskStart = DateTime.Parse(liTask["StartDate"].ToString());
                    }
                    catch {
                    }
                    try
                    {
                        tskFinish = DateTime.Parse(liTask["DueDate"].ToString());
                    }
                    catch {
                    }
                    try
                    {
                        pctComplete = float.Parse(liTask["PercentComplete"].ToString()) * (float)100;
                    }
                    catch { }
                    try
                    {
                        isMS = liTask["Milestone"].ToString();
                    }
                    catch { }

                    if (tskFinish < DateTime.Now.AddDays(-1) && pctComplete < 100)
                    {
                        taskCount++;
                    }
                    if (pctComplete >= 100)
                    {
                        if (isMS == "True")
                            ms_complete++;
                        else
                            task_complete++;
                    }
                    else
                    {
                        if (tskStart > DateTime.Now && pctComplete == 0)
                        {
                            if (isMS == "True")
                                ms_future++;
                            else
                                task_future++;
                        }
                        else if (tskFinish < DateTime.Now.AddDays(-1))
                        {
                            if (isMS == "True")
                                ms_late++;
                            else
                                task_late++;
                        }
                        else
                        {
                            if (isMS == "True")
                                ms_current++;
                            else
                                task_current++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return -1;
            }
            return taskCount;
        }
        public string buildHeader(string title)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");
            sb.Append("<tr class=\"ms-WPHeader\">");
            sb.Append("<td title=\"" + title + "\" id=\"WebPartTitleWPQ2\" style=\"width:100%;\"><h3 class=\"ms-standardheader ms-WPTitle\"><nobr><span>" + title + "</span><span id=\"WebPartCaptionWPQ2\"></span></nobr></h3></td>");
            sb.Append("</tr>");
            sb.Append("</table>");

            return sb.ToString();
        }

        public string buildTaskSummary()
        {
            int totalTsk = task_complete + task_current + task_future + task_late;

            if (totalTsk == 0)
                totalTsk = 1;

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">In Progress: " + task_current.ToString() + " ( " + (task_current * 100 / totalTsk).ToString() + "% )</td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (task_current * 100 / totalTsk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Late: " + task_late.ToString() + " ( " + (task_late * 100 / totalTsk).ToString() + "% )</td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (task_late * 100 / totalTsk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Not Started: " + task_future.ToString() + " ( " + (task_future * 100 / totalTsk).ToString() + "% )</td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (task_future * 100 / totalTsk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Completed: " + task_complete.ToString() + " ( " + (task_complete * 100 / totalTsk).ToString() + "% ) </td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (task_complete * 100 / totalTsk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("</tr></table>");

            return sb.ToString();
        }

        public string buildIssueSummary()
        {
            int totalIssue = issue_active + issue_closed + issue_postponed;

            if (totalIssue == 0)
                totalIssue = 1;

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Active: " + issue_active.ToString() + " ( " + (issue_active * 100 / totalIssue).ToString() + "% )</td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (issue_active * 100 / totalIssue).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Postponed: " + issue_postponed.ToString() + " ( " + (issue_postponed * 100 / totalIssue).ToString() + "% )</td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (issue_postponed * 100 / totalIssue).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Closed: " + issue_closed.ToString() + " ( " + (issue_closed * 100 / totalIssue).ToString() + "% )</td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (issue_closed * 100 / totalIssue).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("</tr></table>");

            return sb.ToString();
        }

        public string buildRiskSummary()
        {
            int totalRisk = risk_active + risk_closed + risk_postponed;
            if (totalRisk == 0)
                totalRisk = 1;

            StringBuilder sb = new StringBuilder();
            sb.Append("<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Active: " + risk_active.ToString() + " ( " + (risk_active * 100 / totalRisk).ToString() + "% )</td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (risk_active * 100 / totalRisk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Postponed: " + risk_postponed.ToString() + " ( " + (risk_postponed * 100 / totalRisk).ToString() + "% )</td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (risk_postponed * 100 / totalRisk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Closed: " + risk_closed.ToString() + " ( " + (risk_closed * 100 / totalRisk).ToString() + "% )</td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (risk_closed * 100 / totalRisk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("</tr></table>");

            return sb.ToString();
        }

        public string buildMSSummary()
        {
            int totalTsk = ms_complete + ms_current + ms_future + ms_late;
            if (totalTsk == 0)
                totalTsk = 1;
            StringBuilder sb = new StringBuilder();
            sb.Append("<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">In Progress: " + ms_current.ToString() + " ( " + (ms_current * 100 / totalTsk).ToString() + "% )</td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (ms_current * 100 / totalTsk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Late: " + ms_late.ToString() + " ( " + (ms_late * 100 / totalTsk).ToString() + "% )</td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (ms_late * 100 / totalTsk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Not Started: " + ms_future.ToString() + " ( " + (ms_future * 100 / totalTsk).ToString() + "% )</td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (ms_future * 100 / totalTsk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Completed: " + ms_complete.ToString() + " ( " + (ms_complete * 100 / totalTsk).ToString() + "% ) </td>");
            sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (ms_complete * 100 / totalTsk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

            sb.Append("</tr></table>");

            return sb.ToString();
        }
    }
}
