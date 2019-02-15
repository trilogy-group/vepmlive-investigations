using System;
using System.Data;
using System.Diagnostics;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace Dashboard
{
    internal partial class ProjectData
    {
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

            var colTitle = new BoundField();
            colTitle.DataField = "name";
            colTitle.HeaderText = "Project Name";
            colTitle.HtmlEncode = false;

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
                    return
                        "In order to take advantage of the new EPM Live functionality, please follow the instructions located <a href=\"http://www.projectpublisher.com/downloads/ProjectPublisherUpdateProcess.pdf\" target=\"_blank\">here</a>.";
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                    return "No Tasks List Found";
                }
            }

            issueList = site.Lists["Issues"];
            riskList = site.Lists["Risks"];

            foreach (SPListItem listItem in projectList.Items)
            {
                try
                {
                    if (listItem["State"].ToString() == "(2) Active")
                    {
                        processProjectSummaryItem2(listItem);
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed {0}", ex);
                }
            }
            gvPJSummary2.DataSource = dt;
            gvPJSummary2.DataBind();
            return string.Empty;
        }

        private void processProjectSummaryItem2(SPListItem listItem)
        {
            var title = string.Format("<a href=\"{0}/Lists/Project%20Center/DispForm.aspx?ID={1}\">{2}</a>", site.Url, listItem.ID, listItem.Title);
            var start = new DateTime();
            var finish = new DateTime();
            float pctComplete = 0;
            var taskCount = 0;
            var scheduleStatus = string.Empty;
            var riskStatus = string.Empty;
            var issueStatus = string.Empty;

            try
            {
                DateTime.TryParse(listItem["Start"].ToString(), out start);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            try
            {
                DateTime.TryParse(listItem["Finish"].ToString(), out finish);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            try
            {
                float temp;
                if (float.TryParse(listItem["PercentComplete"].ToString(), out temp))
                {
                    pctComplete = temp * 100;
                }
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

            scheduleStatus = scheduleStatus == "Late"
                ? "<img src=\"/_layouts/images/red.gif\">"
                : "<img src=\"/_layouts/images/green.gif\">";

            riskStatus = string.Format("<img src=\"/_layouts/images/{0}.gif\">", getRiskStatus(listItem.Title));
            issueStatus = string.Format("<img src=\"/_layouts/images/{0}.gif\">", getIssueStatus(listItem.Title));

            dt.Rows.Add(title, pctComplete + "%", "", scheduleStatus, issueStatus, riskStatus);
        }
    }
}