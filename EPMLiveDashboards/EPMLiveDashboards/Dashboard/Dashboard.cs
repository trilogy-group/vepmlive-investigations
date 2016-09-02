using System;
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

            dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("start");
            dt.Columns.Add("finish");
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
            colTitle.DataField = "start";
            colTitle.HeaderText = "Start";
            colTitle.HtmlEncode = false;
            gvPJSummary.Columns.Add(colTitle);

            colTitle = new BoundField();
            colTitle.DataField = "finish";
            colTitle.HeaderText = "Finish";
            gvPJSummary.Columns.Add(colTitle);

            colTitle = new BoundField();
            colTitle.DataField = "pctcomplete";
            colTitle.HeaderText = "% Complete";
            colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            colTitle.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            gvPJSummary.Columns.Add(colTitle);

            colTitle = new BoundField();
            colTitle.DataField = "latetasks";
            colTitle.HeaderText = "# of Late Tasks";
            colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            colTitle.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            gvPJSummary.Columns.Add(colTitle);

            colTitle = new BoundField();
            colTitle.DataField = "schedulestatus";
            colTitle.HeaderText = "Schedule Status";
            colTitle.HtmlEncode = false;
            colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            colTitle.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            gvPJSummary.Columns.Add(colTitle);

            colTitle = new BoundField();
            colTitle.DataField = "issuestatus";
            colTitle.HeaderText = "Issue Status";
            colTitle.HtmlEncode = false;
            colTitle.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
            colTitle.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
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
            //=========================Issue Status Fields================
            try
            {
                SPField field = issueList.Fields.GetFieldByInternalName(MyIssueState);
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
                        arrIssues.Add(nd.InnerText, 0);
                    }
                }
                catch { }
            }
            catch { }
            //=========================Risk Status Fields================
            try
            {
                SPField field = riskList.Fields.GetFieldByInternalName(MyRiskState);
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
                        arrRisks.Add(nd.InnerText, 0);
                    }
                }
                catch { }
            }
            catch { }
            //====================================================

            Guid fieldGuid = projectList.Fields.GetFieldByInternalName(MyState).Id;

            if (ddlProject.SelectedItem.Value == "")
            {
                foreach (SPListItem li in projectList.Items)
                {
                    try
                    {
                        if (li[fieldGuid].ToString() == ddl.SelectedItem.Text)
                        {
                            processProjectSummaryItem(li);
                            ddlProject.Items.Add(new ListItem(li.Title, li.UniqueId.ToString()));
                        }
                    }
                    catch { }
                }
            }
            else
            {
                processProjectSummaryItem(projectList.Items[new Guid(ddlProject.SelectedItem.Value)]);
            }

            gvPJSummary.DataSource = dt;
            gvPJSummary.DataBind();
            return "";
        }

        private void processProjectSummaryItem(SPListItem li)
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

            taskCount = getTaskCount(li.Title);

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


            dt.Rows.Add(title, start.ToShortDateString(), finish.ToShortDateString(), pctComplete.ToString() + "%", taskCount.ToString(), schedulestatus, issuestatus, riskstatus);
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
                    catch
                    {
                        try
                        {
                            tskStart = DateTime.Parse(liTask["StartDate"].ToString());
                        }
                        catch { }
                    }
                    try
                    {
                        tskFinish = DateTime.Parse(liTask["DueDate"].ToString());
                    }
                    catch
                    {
                        try
                        {
                            tskFinish = DateTime.Parse(liTask["Finish"].ToString());
                        }
                        catch { }
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
            catch
            {
                return 0;
            }
            return taskCount;
        }
    }


}
