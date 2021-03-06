﻿using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

using System.Text;
using System.Data;

using System.Xml;

using System.ComponentModel;
using System.Collections;
using System.Diagnostics;

namespace Dashboard
{
    [Guid("0bc20b84-5782-4bcb-a86e-399e2be233bf")]
    [XmlRoot(Namespace = "MyWebParts")]
    public class Dashboard : Microsoft.SharePoint.WebPartPages.WebPart
    {
        private string outputData;
        private SPGridView gvPJSummary;
        private Guid projectId = Guid.Empty;
        SPWeb site;
        DataTable dt;
        SPList projectList;
        SPList issueList;
        SPList riskList;
        SPList taskList;

        int task_complete = 0;
        int task_future = 0;
        int task_late = 0;
        int task_current = 0;

        int ms_complete = 0;
        int ms_future = 0;
        int ms_late = 0;
        int ms_current = 0;

        //int risk_active = 0;
        //int risk_postponed = 0;
        //int risk_closed = 0;

        //int issue_active = 0;
        //int issue_postponed = 0;
        //int issue_closed = 0;

        int totalIssues = 0;
        int totalRisks = 0;
        SortedList arrIssues = new SortedList();
        SortedList arrRisks = new SortedList();

        //string sStatus;
        //bool processed = false;
        protected DropDownList ddl;
        protected DropDownList ddlProject;
        bool dpChanged = false;
        bool dChanged = false;

        private string sError;

        private string strField;
        private string strIssueField;
        private string strRiskField;
        private string strStateField;

        int activation;

        public Dashboard()
        {
            this.ExportMode = WebPartExportMode.All;
        }

        [Category("State Fields")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Project Center State Field")]
        [Description("")]
        [Browsable(true)]
        // The accessor for this property.
        public string MyState
        {
            get
            {
                if (strField == null || strField.Trim() == "")
                    return "State";
                return strField;
            }
            set
            {
                strField = value;
            }
        }

        [Category("State Fields")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Issue State Field")]
        [Description("")]
        [Browsable(true)]
        // The accessor for this property.
        public string MyIssueState
        {
            get
            {
                if (strIssueField == null || strIssueField.Trim() == "")
                    return "Status";
                return strIssueField;
            }
            set
            {
                strIssueField = value;
            }
        }

        [Category("State Fields")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Risk Status Field")]
        [Description("")]
        [Browsable(true)]
        // The accessor for this property.
        public string MyRiskState
        {
            get
            {
                if (strRiskField == null || strRiskField.Trim() == "")
                    return "Status";
                return strRiskField;
            }
            set
            {
                strRiskField = value;
            }
        }

        protected override void CreateChildControls()
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(SPContext.Current.Web);
            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.WebParts);

            if(activation != 0)
            {
                return;
            }

            try
            {
                site = Microsoft.SharePoint.WebControls.SPControl.GetContextWeb(Context);

                base.CreateChildControls();

                ddlProject = new DropDownList();
                ddlProject.Items.Add(new ListItem("All Projects", ""));
                ddlProject.SelectedIndexChanged += new EventHandler(ddlProject_SelectedIndexChanged);
                ddlProject.AutoPostBack = true;
                Controls.Add(ddlProject);

                ddl = new DropDownList();

                try
                {
                    SPList list = site.Lists["Project Center"];
                    SPField field = list.Fields.GetFieldByInternalName(MyState);
                    strStateField = field.Title;
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(field.SchemaXml);

                    string defaultSelect = "";
                    try
                    {
                        defaultSelect = doc.SelectSingleNode("//Default").InnerText;
                    }
                    catch { }
                    try
                    {
                        XmlNode ndChoices = doc.SelectSingleNode("//CHOICES");
                        foreach (XmlNode nd in ndChoices.ChildNodes)
                        {
                            ddl.Items.Add(nd.InnerText);
                        }
                    }
                    catch { }

                    ddl.Text = defaultSelect;
                }
                catch (Exception ex)
                {
                    sError = "ERROR: " + ex.Message + "<br>";
                }

                ddl.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
                ddl.AutoPostBack = true;

                popProject(ddl.SelectedItem.Text);

                Controls.Add(ddl);
                //ddl_SelectedIndexChanged(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                sError = sError + "ERROR: " + ex.Message + "<br>";
            }
        }

        void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            dpChanged = true;
        }

        void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            dChanged = true;
            popProject(ddl.SelectedItem.Text);
        }

        private void popProject(string state)
        {
            ddlProject.Items.Clear();
            ddlProject.Items.Add(new ListItem("All Projects", ""));
            projectList = site.Lists["Project Center"];

            Guid fieldGuid = projectList.Fields.GetFieldByInternalName(MyState).Id;

            foreach (SPListItem li in projectList.Items)
            {
                try
                {
                    if (li[MyState].ToString() == state)
                    {
                        ddlProject.Items.Add(new ListItem(li.Title, li.UniqueId.ToString()));
                    }
                }
                catch { }
            }

        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            switch (activation)
            {
                case 1:
                    output.Write("WebPart feature not activated.");
                    return;
                case 2:
                    output.Write("Too many users activated for this feature.");
                    return;
                case -1:
                    output.Write("Unable to retrieve activation status.");
                    return;
            };
            try
            {
                EnsureChildControls();

                output.Write(sError);

                output.Write(legendTable());
                output.Write("<br>");

                output.Write(buildFilterTableTop());
                ddl.RenderControl(output);
                output.Write(" Project: ");
                ddlProject.RenderControl(output);
                output.Write(buildFilterTableBottom());


                string ret = buildProjectGrid();
                if (ret != "")
                {
                    output.Write("Error: " + ret);
                }
                else
                {

                    output.Write("<br>");
                    output.Write(buildHeader("Project Summary"));
                    gvPJSummary.RenderControl(output);

                    output.Write("<br>");
                    output.Write("<table border=\"0\" width=\"100%\"><tr><td width=\"50%\" valign=\"top\">");
                    output.Write(buildHeader("Task Summary"));
                    output.Write(buildTaskSummary());

                    output.Write("</td><td width=\"50%\" valign=\"top\">");
                    output.Write(buildHeader("Milestone Summary"));
                    output.Write(buildMSSummary());
                    output.Write("</td></tr>");

                    output.Write("<tr><td width=\"50%\" valign=\"top\">");

                    output.Write(buildHeader("Issue Summary"));
                    output.Write(buildSummaryTable(arrIssues, totalIssues));

                    output.Write("</td><td width=\"50%\" valign=\"top\">");

                    output.Write(buildHeader("Risk Summary"));
                    output.Write(buildSummaryTable(arrRisks, totalRisks));
                    output.Write("</td></tr>");
                    output.Write("</table>");
                }
            }
            catch (Exception ex)
            {
                output.Write("RWP: " + ex.Message + ex.StackTrace);
            }

            output.Write(outputData);
        }

        private string buildFilterTableTop()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<table class=\"ms-menutoolbar\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\">");
            sb.Append("<tr height=\"23\">");
            sb.Append("<td class=\"ms-toolbar\" nowrap=\"true\">");
            sb.Append("<table border=\"0\" cellpadding=\"3\"><tr><td><b>Filter:</b> " + strStateField + ": ");

            return sb.ToString();
        }

        private string buildFilterTableBottom()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("</td></tr></table></td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            return sb.ToString();
        }

        private string buildTaskSummary()
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

        private string buildSummaryTable(SortedList arr, int totalVals)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">");
            if (totalVals == 0)
                totalVals = 1;
            foreach (DictionaryEntry de in arr)
            {
                int val = (int)de.Value;
                sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">" + de.Key + ": " + de.Value + " ( " + (val * 100 / totalVals).ToString() + "% )</td>");
                sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (val * 100 / totalVals).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");
            }

            sb.Append("</tr></table>");

            return sb.ToString();
        }

        //private string buildRiskSummary()
        //{
        //    int totalRisk = risk_active + risk_closed + risk_postponed;
        //    if (totalRisk == 0)
        //        totalRisk = 1;

        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<table border=\"0\" width=\"100%\" cellpadding=\"2\" cellspacing=\"0\">");

        //    sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Active: " + risk_active.ToString() + " ( " + (risk_active * 100 / totalRisk).ToString() + "% )</td>");
        //    sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (risk_active * 100 / totalRisk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

        //    sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Postponed: " + risk_postponed.ToString() + " ( " + (risk_postponed * 100 / totalRisk).ToString() + "% )</td>");
        //    sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (risk_postponed * 100 / totalRisk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

        //    sb.Append("<tr><td class=\"ms-formbody\" width=\"180px\" style=\"vertical-align:middle\">Closed: " + risk_closed.ToString() + " ( " + (risk_closed * 100 / totalRisk).ToString() + "% )</td>");
        //    sb.Append("<td><table width=\"100%\"><tr><td width=\"" + (risk_closed * 100 / totalRisk).ToString() + "%\" height=\"15px\" class=\"ms-selected\"></td><td width=\"100%\"></td></tr></table></td></tr>");

        //    sb.Append("</tr></table>");

        //    return sb.ToString();
        //}

        private string buildMSSummary()
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

        private string buildHeader(string title)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");
            sb.Append("<tr class=\"ms-WPHeader\">");
            sb.Append("<td title=\"" + title + "\" id=\"WebPartTitleWPQ2\" style=\"width:100%;\"><h3 class=\"ms-standardheader ms-WPTitle\"><nobr><span>" + title + "</span><span id=\"WebPartCaptionWPQ2\"></span></nobr></h3></td>");
            sb.Append("</tr>");
            sb.Append("</table>");

            return sb.ToString();
        }

        private string legendTable()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(buildHeader("Legend"));

            sb.Append("<TABLE cellSpacing=0 cellPadding=2 width=\"100%\" border=0>");
            sb.Append("<TBODY>");
            sb.Append("<TR>");
            sb.Append("<TH class=ms-vh width=\"33%\">Schedule Status</TH>");
            sb.Append("<TH class=ms-vh width=\"33%\">Issue Summary</TH>");
            sb.Append("<TH class=ms-vh width=\"33%\">Risk Summary</TH></TR>");
            sb.Append("<TR vAlign=top>");
            sb.Append("<TD class=ms-vb width=\"33%\"><IMG src=\"/_layouts/images/green.gif\" align=absMiddle> Complete<BR><IMG src=\"/_layouts/images/green.gif\" align=absMiddle> Future Project<BR><IMG src=\"/_layouts/images/green.gif\" align=absMiddle> On Schedule<BR><IMG src=\"/_layouts/images/red.gif\" align=absMiddle> Late<BR></TD>");
            sb.Append("<TD class=ms-vb width=\"33%\"><IMG src=\"/_layouts/images/green.gif\" align=absMiddle> No Active Issues<BR><IMG src=\"/_layouts/images/yellow.gif\" align=absMiddle> At Least 1 Active Issue<BR><IMG src=\"/_layouts/images/red.gif\" align=absMiddle> At Least 1 Active Overdue Issue<BR></TD>");
            sb.Append("<TD class=ms-vb width=\"33%\"><IMG src=\"/_layouts/images/green.gif\" align=absMiddle> No Active Risks<BR><IMG src=\"/_layouts/images/yellow.gif\" align=absMiddle> At Least 1 Active Risk<BR><IMG src=\"/_layouts/images/red.gif\" align=absMiddle> At Least 1 Active Overdue Risk<BR></TD></TR></TBODY></TABLE>");

            return sb.ToString();
        }

        private string buildProjectGrid()
        {
            PopulateDataTable();

            gvPJSummary = new SPGridView
            {
                AutoGenerateColumns = false
            };

            AddProjectNameColumn();
            AddStartColumn();
            AddFinishColumn();
            AddPercentCompleteColumn();
            AddLateTasksColumn();
            AddScheduleStatusColumn();
            AddIssueStatusColumn();
            AddRiskStatusColumn();

            SetGridViewProperties();

            projectList = site.Lists["Project Center"];

            string noTasksListFound = string.Empty;
            if (GetTasksLists(ref noTasksListFound))
            {
                return noTasksListFound;
            }
            issueList = site.Lists["Issues"];
            riskList = site.Lists["Risks"];

            ProcessIssueStatusFields();
            ProcessRiskStatusFields();


            var fieldGuid = projectList.Fields.GetFieldByInternalName(MyState).Id;

            ProcessProjectFields(fieldGuid);

            gvPJSummary.DataSource = dt;
            gvPJSummary.DataBind();
            return string.Empty;
        }

        private void ProcessProjectFields(Guid fieldGuid)
        {
            if (ddlProject.SelectedItem.Value == string.Empty)
            {
                ProcessGenericProjectsFields(fieldGuid);
            }
            else
            {
                processProjectSummaryItem(projectList.Items[new Guid(ddlProject.SelectedItem.Value)]);
            }
        }

        private void ProcessGenericProjectsFields(Guid fieldGuid)
        {
            foreach (SPListItem listItem in projectList.Items)
            {
                try
                {
                    if (listItem[fieldGuid].ToString() == ddl.SelectedItem.Text)
                    {
                        processProjectSummaryItem(listItem);
                        ddlProject.Items.Add(new ListItem(listItem.Title, listItem.UniqueId.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed: {0}", ex);
                }
            }
        }

        private void ProcessRiskStatusFields()
        {
            try
            {
                var field = riskList.Fields.GetFieldByInternalName(MyRiskState);
                var doc = new XmlDocument();
                doc.LoadXml(field.SchemaXml);

                var defaultSelect = string.Empty;
                try
                {
                    defaultSelect = doc.SelectSingleNode("//Default").InnerText;
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed: {0}", ex);
                }
                try
                {
                    var ndChoices = doc.SelectSingleNode("//CHOICES");
                    foreach (XmlNode nd in ndChoices.ChildNodes)
                    {
                        arrRisks.Add(nd.InnerText, 0);
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed: {0}", ex);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed: {0}", ex);
            }
        }

        private void ProcessIssueStatusFields()
        {
            try
            {
                var field = issueList.Fields.GetFieldByInternalName(MyIssueState);
                var doc = new XmlDocument();
                doc.LoadXml(field.SchemaXml);

                var defaultSelect = string.Empty;
                try
                {
                    defaultSelect = doc.SelectSingleNode("//Default").InnerText;
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed: {0}", ex);
                }
                try
                {
                    var ndChoices = doc.SelectSingleNode("//CHOICES");
                    foreach (XmlNode nd in ndChoices.ChildNodes)
                    {
                        arrIssues.Add(nd.InnerText, 0);
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("Exception Suppressed: {0}", ex);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed: {0}", ex);
            }
        }

        private bool GetTasksLists(ref string noTasksListFound)
        {
            try
            {
                taskList = site.Lists["Task Center"];
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed: {0}", ex);
                try
                {
                    taskList = site.Lists["My Tasks"];
                    {
                        noTasksListFound =
                            "In order to take advantage of the new EPM Live functionality, please follow the instructions located <a href=\"http://www.projectpublisher.com/downloads/ProjectPublisherUpdateProcess.pdf\" target=\"_blank\">here</a>.";
                        return true;
                    }
                }
                catch (Exception exception)
                {
                    Trace.TraceError("Exception Suppressed: {0}", exception);
                    {
                        noTasksListFound = "No Tasks List Found";
                        return true;
                    }
                }
            }
            return false;
        }

        private void SetGridViewProperties()
        {
            gvPJSummary.AllowGrouping = false;
            gvPJSummary.ID = "gvPJSummary";
            gvPJSummary.Width = Unit.Percentage(100);
            gvPJSummary.HeaderStyle.CssClass = "ms-vh";
        }

        private void AddRiskStatusColumn()
        {
            var colTitle = new BoundField
            {
                DataField = "riskstatus",
                HeaderText = "Risk Status",
                HtmlEncode = false
            };
            colTitle.ControlStyle.CssClass = "ms-vh";
            colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            gvPJSummary.Columns.Add(colTitle);
        }

        private void AddIssueStatusColumn()
        {
            var colTitle = new BoundField
            {
                DataField = "issuestatus",
                HeaderText = "Issue Status",
                HtmlEncode = false
            };
            colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            colTitle.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            gvPJSummary.Columns.Add(colTitle);
        }

        private void AddScheduleStatusColumn()
        {
            var colTitle = new BoundField
            {
                DataField = "schedulestatus",
                HeaderText = "Schedule Status",
                HtmlEncode = false
            };
            colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            colTitle.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            gvPJSummary.Columns.Add(colTitle);
        }

        private void AddLateTasksColumn()
        {
            var colTitle = new BoundField
            {
                DataField = "latetasks",
                HeaderText = "# of Late Tasks"
            };
            colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            colTitle.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            gvPJSummary.Columns.Add(colTitle);
        }

        private void AddPercentCompleteColumn()
        {
            var colTitle = new BoundField
            {
                DataField = "pctcomplete",
                HeaderText = "% Complete"
            };
            colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            colTitle.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            gvPJSummary.Columns.Add(colTitle);
        }

        private void AddFinishColumn()
        {
            var colTitle = new BoundField
            {
                DataField = "finish",
                HeaderText = "Finish"
            };
            gvPJSummary.Columns.Add(colTitle);
        }

        private void AddStartColumn()
        {
            var colTitle = new BoundField
            {
                DataField = "start",
                HeaderText = "Start",
                HtmlEncode = false
            };
            gvPJSummary.Columns.Add(colTitle);
        }

        private void AddProjectNameColumn()
        {
            var colTitle = new BoundField
            {
                DataField = "name",
                HeaderText = "Project Name",
                HtmlEncode = false
            };

            gvPJSummary.Columns.Add(colTitle);
        }

        private void PopulateDataTable()
        {
            dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("start");
            dt.Columns.Add("finish");
            dt.Columns.Add("pctcomplete");
            dt.Columns.Add("latetasks");
            dt.Columns.Add("schedulestatus");
            dt.Columns.Add("issuestatus");
            dt.Columns.Add("riskstatus");
        }

        private void processProjectSummaryItem(SPListItem li)
        {
            DateTime start;
            DateTime finish;
            string schedulestatus;
            string riskStatus;
            string issueStatus;
            int taskCount;
            float percentComplete;
            string title;

            TaskHelper.ProcessProjectSummaryItem(
                site,
                li,
                true,
                true,
                true,
                getTaskCount,
                getRiskStatus,
                getIssueStatus,
                out start,
                out finish,
                out title,
                out percentComplete,
                out taskCount,
                out schedulestatus,
                out riskStatus,
                out issueStatus);

            dt.Rows.Add(
                title,
                start.ToShortDateString(),
                finish.ToShortDateString(),
                $"{percentComplete}%",
                taskCount.ToString(),
                schedulestatus,
                issueStatus,
                riskStatus);
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
                    string tskStatus = "";
                    DateTime dtDue = DateTime.Now;
                    try
                    {
                        tskStatus = liTask[MyIssueState].ToString();
                    }
                    catch { }
                    try
                    {
                        dtDue = DateTime.Parse(liTask["DueDate"].ToString());
                    }
                    catch { }

                    if (arrIssues.Contains(tskStatus))
                    {
                        totalIssues++;
                        int newValue = (int)arrIssues[tskStatus] + 1;
                        arrIssues[tskStatus] = newValue;
                    }

                    //if (tskStatus == "Active")
                    //{
                    //    issue_active++;
                    //    if (status == "green")
                    //        status = "yellow";
                    //    if (dtDue < DateTime.Now)
                    //        status = "red";
                    //}
                    //else if (tskStatus == "Postponed")
                    //    issue_postponed++;
                    //else if (tskStatus == "Closed")
                    //    issue_closed++;
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
                    string tskStatus = "";
                    DateTime dtDue = DateTime.Now;
                    try
                    {
                        tskStatus = liTask[MyRiskState].ToString();
                    }
                    catch { }
                    try
                    {
                        dtDue = DateTime.Parse(liTask["DueDate"].ToString());
                    }
                    catch { }

                    if (arrRisks.Contains(tskStatus))
                    {
                        totalRisks++;
                        int newValue = (int)arrRisks[tskStatus] + 1;
                        arrRisks[tskStatus] = newValue;
                    }

                    //if (tskStatus == "Active")
                    //{
                    //    issue_active++;
                    //    if (status == "green")
                    //        status = "yellow";
                    //    if (dtDue < DateTime.Now)
                    //        status = "red";
                    //}
                    //else if (tskStatus == "Postponed")
                    //    issue_postponed++;
                    //else if (tskStatus == "Closed")
                    //    issue_closed++;
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
            catch
            {
                return 0;
            }
            return taskCount;
        }

        private bool _disposed;

        public override void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            ddl?.Dispose();
            ddlProject?.Dispose();

            _disposed = true;
        }
    }


}
