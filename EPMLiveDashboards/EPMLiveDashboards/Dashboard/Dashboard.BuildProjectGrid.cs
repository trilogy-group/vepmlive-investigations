using System;
using System.Data;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Xml;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace Dashboard
{
    public partial class Dashboard
    {
        // Changing methdos or parameters names are not permitted on EPM
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

            var noTasksListFound = string.Empty;
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
                    // CC-78374 - Unused variable but I'm keeping it as a container to the assignment
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
                    // CC-78374 - Unused variable but I'm keeping it as a container to the assignment
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
    }
}