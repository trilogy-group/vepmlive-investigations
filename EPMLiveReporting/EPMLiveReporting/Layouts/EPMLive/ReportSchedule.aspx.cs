using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using EPMLiveCore.ReportHelper;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using SystemTrace = System.Diagnostics.Trace;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class ReportSchedule : LayoutsPageBase
    {
        public static Hashtable desc;
        private EPMData _DAO;
        protected Button btnRunNow;
        protected CheckBox chkAdmin;
        protected CheckBox chkTask;
        protected string disabled;
        protected DropDownList DropDownListSnapshotTime;
        protected DropDownList FixTimes;

        protected HyperLink hlAdmin;
        protected Label lblLastResResult;
        protected Label lblLastResRun;
        protected Label lblLastRun;

        protected Label lblMessages;
        protected Label lblNotEnabled;
        protected Label lblPropertyEPMLiveFixLists;
        protected Label lblPropertyEPMLiveFixTime;
        protected Label lblPropertyEPMLiveFixTimeValue;
        protected Label lblResLog;
        protected ListBox ListBoxLists;
        protected TextBox Lists;
        protected ListBox lstNotificationUsers;
        protected ListBox lstSiteUsers;
        protected Panel pnlAdmin;
        protected Panel pnlMain;
        protected Panel pnlSaveResults;
        protected Panel pnlTL;
        protected string siteid;

        protected string siteUrl;
        public string strTemplate;
        public string strTitle;
        protected TextBox txtPropertyEPMLiveFixListsValue;
        protected TextBox txtResPlannerLists;
        protected TextBox txtScheduleTitle;

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;
            lblErrorSite.Visible = false;

            _DAO = new EPMData(SPContext.Current.Web.Site.ID);
            _DAO.OpenClientReportingConnection = _DAO.remoteCs;
            DropDownListScheduleType.SelectedIndexChanged += DropDownListScheduleType_SelectedIndexChanged;

            try
            {
                if (!IsPostBack)
                {
                    PopulateLists();
                    loadData(SPContext.Current.Web);
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        protected void PopulateLists()
        {
            DataTable dataTable;
            _DAO.Command = "SELECT ListName FROM RPTList WHERE SiteId=@siteId";
            _DAO.AddParam("@siteId", SPContext.Current.Web.Site.ID);
            dataTable = _DAO.GetTable(_DAO.GetClientReportingConnection);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                var item = new ListItem
                {
                    Text = dataRow["ListName"].ToString(),
                    Value = dataRow["ListName"].ToString()
                };
                ListBoxLists.Items.Add(item);
            }
        }

        protected void loadData(SPWeb web)
        {
            if (Request.QueryString["uid"] != null)
            {
                _DAO.Command = "SELECT * FROM TIMERJOBS WHERE timerjobuid=@uid";
                _DAO.AddParam("@uid", Request.QueryString["uid"]);
                var report = _DAO.GetTable(_DAO.GetEPMLiveConnection);

                if (report.Rows.Count == 0)
                {
                    throw new InvalidOperationException("report table does not have any row.");
                }

                txtScheduleTitle.Text = report.Rows[0]["jobname"].ToString();
                DropDownListSnapshotTime.SelectedValue = report.Rows[0]["runtime"].ToString();
                DropDownListScheduleType.SelectedValue = report.Rows[0]["scheduletype"].ToString();

                if (DropDownListScheduleType.SelectedValue == "2")
                {
                    PopulateDays(report.Rows[0]["days"].ToString());
                }
                else
                {
                    if (report.Rows.Count > 0)
                    {
                        DropDownListDays.SelectedValue = report.Rows[0]["days"].ToString();
                    }
                }
                if (report.Rows.Count > 0)
                {
                    PopulateSelectedLists(report.Rows[0]["jobdata"].ToString());
                }
            }
            if (DropDownListScheduleType.SelectedValue == "3")
            {
                DropDownListDays.Visible = true;
                CheckBoxList_days.Visible = false;
            }
            else
            {
                DropDownListDays.Visible = false;
                CheckBoxList_days.Visible = true;
            }
        }

        protected void PopulateDays(string sDays)
        {
            var splitter = ",".ToCharArray();
            foreach (string day in (Array)sDays.Split(splitter[0]))
            {
                foreach (ListItem item in CheckBoxList_days.Items)
                {
                    if (item.Value == day)
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        protected void PopulateSelectedLists(string sLists)
        {
            var splitter = ",".ToCharArray();
            foreach (string list in (Array)sLists.Split(splitter[0]))
            {
                foreach (ListItem item in ListBoxLists.Items)
                {
                    if (string.Equals(item.Text, list, StringComparison.OrdinalIgnoreCase))
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        protected bool ScheduleValid()
        {
            if (txtScheduleTitle.Text?.Length == 0)
            {
                return false;
            }
            if (DropDownListScheduleType.SelectedValue == "2" && GetOptions()?.Length == 0)
            {
                return false;
            }
            if (DropDownListSnapshotTime.SelectedValue?.Length == 0)
            {
                return false;
            }
            return !string.IsNullOrWhiteSpace(ListBoxLists.SelectedValue);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                saveSettings(SPContext.Current.Site.RootWeb);
                var url = SPContext.Current.Web.ServerRelativeUrl;
                Response.Redirect(string.Format("{0}/_layouts/epmlive/AllSnapShots.aspx", url));
            }
            catch (Exception ex)
            {
                SystemTrace.TraceError("Exception Suppressed {0}", ex);
                Response.Write(string.Format("Error: {0}", ex.Message));
            }
        }

        protected string GetOptions()
        {
            var options = string.Empty;
            if (DropDownListScheduleType.SelectedValue == "2")
            {
                options = GetFromList(CheckBoxList_days.Items);
            }
            else
            {
                foreach (var unused in CheckBoxList_days.Items)
                {
                    options = DropDownListDays.SelectedValue;
                }
            }
            return options;
        }

        protected string GetLists()
        {
            return GetFromList(ListBoxLists.Items);
        }

        private string GetFromList(ListItemCollection listItemCollection)
        {
            var stringBuilder = new StringBuilder();
            foreach (ListItem item in listItemCollection)
            {
                if (item.Selected)
                {
                    stringBuilder.Append(string.Format("{0},", item.Value));
                }
            }
            var result = stringBuilder.ToString();
            if (result.EndsWith(","))
            {
                result = result.Remove(result.LastIndexOf(","));
            }
            return result;
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            _DAO.Dispose();
        }

        private void DropDownListScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListScheduleType.SelectedValue == "3")
            {
                DropDownListDays.Visible = true;
                CheckBoxList_days.Visible = false;
            }
            else
            {
                DropDownListDays.Visible = false;
                CheckBoxList_days.Visible = true;
            }
        }

        private void saveSettings(SPWeb currWeb)
        {
            if (ScheduleValid())
            {
                var time = 0;
                if (DropDownListSnapshotTime.SelectedValue != string.Empty)
                {
                    time = int.Parse(DropDownListSnapshotTime.SelectedValue);
                }
                var scheduleType = int.Parse(DropDownListScheduleType.SelectedValue);
                if (Request.QueryString["uid"] == null)
                {
                    AddNewJob(currWeb, time, scheduleType);
                }
                else
                {
                    UpdateNewJob(scheduleType, time);
                }
                if (_DAO.SqlErrorOccurred)
                {
                    _DAO.LogStatus(
                        string.Empty,
                        string.Empty,
                        "Error Saving Schedule",
                        _DAO.SqlError,
                        2,
                        1,
                        string.Empty);
                }
                lblErrorSite.Visible = false;
            }
            else
            {
                lblErrorSite.Visible = true;
                lblErrorSite.Text = "Invalid value. Please check your settings and try again.";
            }
        }

        private void UpdateNewJob(int scheduleType, int time)
        {
            _DAO.Command =
                "UPDATE TIMERJOBS SET jobname=@jobname,enabled=@enabled,scheduletype=@scheduletype,runtime=@runtime,days=@days,jobdata=@jobdata WHERE timerjobuid=@timerjobuid";
            _DAO.AddParam("@jobname", txtScheduleTitle.Text);
            _DAO.AddParam("@timerjobuid", Request.QueryString["uid"]);
            _DAO.AddParam("@enabled", true);
            _DAO.AddParam("@scheduletype", scheduleType);
            _DAO.AddParam("@runtime", time);
            _DAO.AddParam("@days", GetOptions());
            _DAO.AddParam("@jobdata", GetLists());
            _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
        }

        private void AddNewJob(SPWeb currWeb, int time, int scheduleType)
        {
            var timerJobUId = Guid.NewGuid();
            _DAO.Command =
                "INSERT INTO TIMERJOBS ([timerjobuid],[jobname],[siteguid],[webguid],[listguid],[jobtype],[enabled],[runtime],[scheduletype],[days],[jobdata],[lastqueuecheck],[parentjobuid]) "
                + " VALUES(@timejobuid,@jobname,@siteguid,@webguid,@listguid,@jobtype,@enabled,@runtime,@scheduletype,@days,@jobdata,@lastqueuecheck,@parentjobuid)";
            _DAO.AddParam("@timejobuid", timerJobUId);
            _DAO.AddParam("@jobname", txtScheduleTitle.Text);
            _DAO.AddParam("@siteguid", currWeb.Site.ID);
            _DAO.AddParam("@webguid", currWeb.ID);
            _DAO.AddParam("@listguid", DBNull.Value);
            _DAO.AddParam("@jobtype", 7);
            _DAO.AddParam("@enabled", true);
            _DAO.AddParam("@runtime", time);
            _DAO.AddParam("@scheduletype", scheduleType);
            _DAO.AddParam("@days", GetOptions());
            _DAO.AddParam("@jobdata", GetLists());
            _DAO.AddParam("@lastqueuecheck", DBNull.Value);
            _DAO.AddParam("@parentjobuid", DBNull.Value);
            _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
        }
    }
}