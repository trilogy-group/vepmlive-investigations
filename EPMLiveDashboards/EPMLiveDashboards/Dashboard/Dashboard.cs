using System;
using System.Collections;
using System.Data;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using SharepointWebPart = Microsoft.SharePoint.WebPartPages;

namespace Dashboard
{
    [Guid("0bc20b84-5782-4bcb-a86e-399e2be233bf")]
    [XmlRoot(Namespace = "MyWebParts")]
    public partial class Dashboard : SharepointWebPart.WebPart
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

        int totalIssues = 0;
        int totalRisks = 0;
        SortedList arrIssues = new SortedList();
        SortedList arrRisks = new SortedList();

        protected DropDownList ddl;
        protected DropDownList ddlProject;
        bool dpChanged = false;
        bool dChanged = false;

        private string sError;

        private string strStateField;

        int activation;

        public Dashboard()
        {
            this.ExportMode = WebPartExportMode.All;
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
