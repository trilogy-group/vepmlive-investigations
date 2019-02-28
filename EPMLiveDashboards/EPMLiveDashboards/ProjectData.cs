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
using System.Diagnostics;

namespace Dashboard
{
    partial class ProjectData
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

        private void PopulateSummaryGrid()
        {
            gvPJSummary = new SPGridView
            {
                AutoGenerateColumns = false
            };

            var colTitle = new BoundField
            {
                DataField = "name",
                HeaderText = "Project Name",
                HtmlEncode = false
            };

            gvPJSummary.Columns.Add(colTitle);

            AddField("pctcomplete", "% Complete", HorizontalAlign.Center);
            AddField("latetasks", "# of Late Tasks", HorizontalAlign.Center);
            AddField("schedulestatus", "Schedule Status", HorizontalAlign.Center, false);
            AddField("issuestatus", "Issue Status", HorizontalAlign.Center, false);
            AddField("riskstatus", "Risk Status", HorizontalAlign.Center, false, "ms-vh");

            gvPJSummary.AllowGrouping = false;
            gvPJSummary.ID = "gvPJSummary";
            gvPJSummary.Width = Unit.Percentage(100);
            gvPJSummary.HeaderStyle.CssClass = "ms-vh";
        }

        private void PopulateDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("pctcomplete");
            dt.Columns.Add("latetasks");
            dt.Columns.Add("schedulestatus");
            dt.Columns.Add("issuestatus");
            dt.Columns.Add("riskstatus");
        }

        private void AddField(
            string fieldName,
            string fieldHeader,
            HorizontalAlign horizontalAlignment,
            bool? fieldEncode = null,
            string controlStyleCss = null)
        {
            var boundField = new BoundField();
            boundField.DataField = fieldName;
            boundField.HeaderText = fieldHeader;
            if (fieldEncode.HasValue)
            {
                boundField.HtmlEncode = fieldEncode.Value;
            }
            if (controlStyleCss != null)
            {
                boundField.ControlStyle.CssClass = controlStyleCss;
            }
            boundField.ItemStyle.HorizontalAlign = horizontalAlignment;
            gvPJSummary.Columns.Add(boundField);
        }

        private void processProjectSummaryItem(SPListItem li, bool pTasks, bool pRisks, bool pIssues)
        {
            DateTime start;
            DateTime finish;
            string scheduleStatus;
            string riskStatus;
            string issueStatus;
            int taskCount;
            float percentComplete;
            string title;

            TaskHelper.ProcessProjectSummaryItem(
                site,
                li,
                pTasks,
                pRisks,
                pIssues,
                getTaskCount,
                getRiskStatus,
                getIssueStatus,
                out start,
                out finish,
                out title,
                out percentComplete,
                out taskCount,
                out scheduleStatus,
                out riskStatus,
                out issueStatus);

            dt.Rows.Add(title, $"{percentComplete}%", taskCount.ToString(), scheduleStatus, issueStatus, riskStatus);
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
