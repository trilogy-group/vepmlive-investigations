using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class ReportSchedule : LayoutsPageBase
    {
        public static Hashtable desc;
        //protected DropDownList DropDownListScheduleType;
        //protected DropDownList DropDownListDays;
        protected DropDownList DropDownListSnapshotTime;
        protected DropDownList FixTimes;
        protected ListBox ListBoxLists;
        protected TextBox Lists;
        private EPMData _DAO;
        protected Button btnRunNow;
        protected CheckBox chkAdmin;
        protected CheckBox chkTask;
        protected string disabled;

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
        protected ListBox lstNotificationUsers;
        protected ListBox lstSiteUsers;
        protected Panel pnlAdmin;
        protected Panel pnlMain;
        protected Panel pnlSaveResults;
        protected Panel pnlTL;

        protected string siteUrl;
        protected string siteid;
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
                //using (SPWeb web = SPContext.Current.Web)
                //{
                if (!IsPostBack)
                {
                    PopulateLists();
                    loadData(SPContext.Current.Web);
                }
                //}
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        private void DropDownListScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListScheduleType.SelectedValue == "3")
            {
                DropDownListDays.Visible = true;
                CheckBoxList_days.Visible = false;
                //FrequencyOptions.LabelText = "Day of Month";
            }
            else
            {
                DropDownListDays.Visible = false;
                CheckBoxList_days.Visible = true;
                //FrequencyOptions.LabelText = "Day(s) of Week";
            }
        }

        protected void PopulateLists()
        {
            DataTable dt;
            //_DAO.Command = "SELECT ListName FROM RPTList WHERE SiteId='" + SPContext.Current.Web.Site.ID + "'"; - CAT.NET
            _DAO.Command = "SELECT ListName FROM RPTList WHERE SiteId=@siteId";
            _DAO.AddParam("@siteId", SPContext.Current.Web.Site.ID);
            dt = _DAO.GetTable(_DAO.GetClientReportingConnection);

            //using (SPContext.Current.Web)
            //{
            foreach (DataRow row in dt.Rows)
            {
                var item = new ListItem();
                item.Text = row["ListName"].ToString();
                item.Value = row["ListName"].ToString();
                ListBoxLists.Items.Add(item);
            }
            //}
        }

        protected void loadData(SPWeb web)
        {
            if (Request.QueryString["uid"] != null)
            {
                DataTable dtReport;
                //_DAO.Command = "SELECT * FROM TIMERJOBS WHERE timerjobuid='" + Request.QueryString["uid"] + "'"; - CAT.NET
                _DAO.Command = "SELECT * FROM TIMERJOBS WHERE timerjobuid=@uid";
                _DAO.AddParam("@uid", Request.QueryString["uid"]);
                dtReport = _DAO.GetTable(_DAO.GetEPMLiveConnection);

                txtScheduleTitle.Text = dtReport.Rows[0]["jobname"].ToString();
                DropDownListSnapshotTime.SelectedValue = dtReport.Rows[0]["runtime"].ToString();
                DropDownListScheduleType.SelectedValue = dtReport.Rows[0]["scheduletype"].ToString();

                if (DropDownListScheduleType.SelectedValue == "2")
                {
                    PopulateDays(dtReport.Rows[0]["days"].ToString());
                }
                else
                {
                    if (dtReport.Rows.Count > 0)
                    {
                        DropDownListDays.SelectedValue = dtReport.Rows[0]["days"].ToString();
                    }
                }

                if (dtReport.Rows.Count > 0)
                {
                    PopulateSelectedLists(dtReport.Rows[0]["jobdata"].ToString());
                }
            }

            if (DropDownListScheduleType.SelectedValue == "3")
            {
                DropDownListDays.Visible = true;
                CheckBoxList_days.Visible = false;
                //FrequencyOptions.LabelText = "Day of Month";
            }
            else
            {
                DropDownListDays.Visible = false;
                CheckBoxList_days.Visible = true;
                //FrequencyOptions.LabelText = "Day(s) of Week";
            }
        }

        protected void PopulateDays(string sDays)
        {
            char[] splitter = ",".ToCharArray();
            Array sOptions = sDays.Split(splitter[0]);
            foreach (string day in sOptions)
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
            char[] splitter = ",".ToCharArray();
            Array sOptions = sLists.Split(splitter[0]);
            foreach (string list in sOptions)
            {
                foreach (ListItem item in ListBoxLists.Items)
                {
                    if (item.Text.ToLower() == list.ToLower())
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        protected bool ScheduleValid()
        {
            if (txtScheduleTitle.Text == string.Empty)
            {
                return false;
            }


            if (DropDownListScheduleType.SelectedValue == "2")
            {
                string days = GetOptions();
                if (days == string.Empty)
                {
                    return false;
                }
            }

            if (DropDownListSnapshotTime.SelectedValue == "")
            {
                return false;
            }

            if (ListBoxLists.SelectedValue == null || ListBoxLists.SelectedValue == string.Empty)
            {
                return false;
            }
            return true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                saveSettings(SPContext.Current.Site.RootWeb);
                string url = SPContext.Current.Web.ServerRelativeUrl;
                if (url.EndsWith("/"))
                {
                    Response.Redirect(url + "/_layouts/epmlive/AllSnapShots.aspx");
                }
                else
                {
                    Response.Redirect(url + "/_layouts/epmlive/AllSnapShots.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }

        private void saveSettings(SPWeb currWeb)
        {
            if (ScheduleValid())
            {
                string sTime = DropDownListSnapshotTime.SelectedValue;
                string sTitle = txtScheduleTitle.Text;
                int iTime = 0;

                if (sTime != string.Empty)
                {
                    iTime = int.Parse(sTime);
                }

                int iScheduleType = int.Parse(DropDownListScheduleType.SelectedValue);

                if (Request.QueryString["uid"] == null) //ADD NEW JOB
                {
                    Guid timerjobuid = Guid.NewGuid();
                    _DAO.Command =
                        "INSERT INTO TIMERJOBS ([timerjobuid],[jobname],[siteguid],[webguid],[listguid],[jobtype],[enabled],[runtime],[scheduletype],[days],[jobdata],[lastqueuecheck],[parentjobuid]) " +
                        " VALUES(@timejobuid,@jobname,@siteguid,@webguid,@listguid,@jobtype,@enabled,@runtime,@scheduletype,@days,@jobdata,@lastqueuecheck,@parentjobuid)";
                    _DAO.AddParam("@timejobuid", timerjobuid);
                    _DAO.AddParam("@jobname", sTitle);
                    _DAO.AddParam("@siteguid", currWeb.Site.ID);
                    _DAO.AddParam("@webguid", currWeb.ID);
                    _DAO.AddParam("@listguid", DBNull.Value);
                    _DAO.AddParam("@jobtype", 7);
                    _DAO.AddParam("@enabled", true);
                    _DAO.AddParam("@runtime", iTime);
                    _DAO.AddParam("@scheduletype", iScheduleType);
                    _DAO.AddParam("@days", GetOptions());
                    _DAO.AddParam("@jobdata", GetLists());
                    _DAO.AddParam("@lastqueuecheck", DBNull.Value);
                    _DAO.AddParam("@parentjobuid", DBNull.Value);
                    _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
                }
                else //Udate Existing Job
                {
                    _DAO.Command =
                        "UPDATE TIMERJOBS SET jobname=@jobname,enabled=@enabled,scheduletype=@scheduletype,runtime=@runtime,days=@days,jobdata=@jobdata WHERE timerjobuid=@timerjobuid";
                    _DAO.AddParam("@jobname", sTitle);
                    _DAO.AddParam("@timerjobuid", Request.QueryString["uid"]);
                    _DAO.AddParam("@enabled", true);
                    _DAO.AddParam("@scheduletype", iScheduleType);
                    _DAO.AddParam("@runtime", iTime);
                    _DAO.AddParam("@days", GetOptions());
                    _DAO.AddParam("@jobdata", GetLists());
                    _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
                }

                if (_DAO.SqlErrorOccurred)
                {
                    _DAO.LogStatus(string.Empty, string.Empty, "Error Saving Schedule", _DAO.SqlError, 2, 1,
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

        protected string GetOptions()
        {
            string sOptions = string.Empty;
            if (DropDownListScheduleType.SelectedValue == "2")
            {
                foreach (ListItem item in CheckBoxList_days.Items)
                {
                    if (item.Selected)
                    {
                        sOptions = sOptions + item.Value + ",";
                    }
                }

                if (sOptions.EndsWith(","))
                {
                    sOptions = sOptions.Remove(sOptions.LastIndexOf(","));
                }
            }
            else
            {
                foreach (ListItem item in CheckBoxList_days.Items)
                {
                    sOptions = DropDownListDays.SelectedValue;
                }
            }
            return sOptions;
        }

        protected string GetLists()
        {
            string sLists = string.Empty;
            foreach (ListItem item in ListBoxLists.Items)
            {
                if (item.Selected)
                {
                    sLists = sLists + item.Value + ",";
                }
            }
            if (sLists.EndsWith(","))
            {
                sLists = sLists.Remove(sLists.LastIndexOf(","));
            }
            return sLists;
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            _DAO.Dispose();
        }
    }
}