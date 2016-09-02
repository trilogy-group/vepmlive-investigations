using System;
using System.Data;
using System.Diagnostics;
using System.Web;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using EPMLiveCore.ReportHelper;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class Snapshot : LayoutsPageBase
    {
        //protected CheckBox activate;
        //protected TextBox title;
        //protected HtmlInputButton saveBtn;
        //protected DateTimeControl snapShotDate;
        //protected PlaceHolder dtPicker;
        private EPMData _DAO;

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;
            saveBtn.ServerClick += save_Click;
            //using (SPWeb spWeb = SPContext.Current.Web)
            //{
            snapShotDate.DatePickerFrameUrl = SPContext.Current.Web.Url + "/_layouts/iframe.aspx";
            //}

            if (Request.QueryString["uid"] != null)
            {
                try
                {
                    _DAO = new EPMData(SPContext.Current.Site.ID);
                    _DAO.OpenClientReportingConnection = _DAO.remoteCs;
                    LoadSnapshot();
                }
                catch (Exception ex)
                {
                    SPSecurity.RunWithElevatedPrivileges(delegate
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting - Page_Init"))
                            EventLog.CreateEventSource("EPMLive Reporting - Page_Init", "EPM Live");

                        var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting Page_Init");
                        myLog.MaximumKilobytes = 32768;
                        myLog.WriteEntry(ex.Message + ex.StackTrace, EventLogEntryType.Error, 2060);
                    });
                }
            }
            else
            {
                Response.Write("No Snapshot ID provided.");
            }
        }

        protected void LoadSnapshot()
        {
            DataTable dt;
            //_DAO.Command = "SELECT * FROM RPTPeriods WHERE PeriodID = '" + Request.QueryString["uid"] + "'"; - CAT.NET
            _DAO.Command = "SELECT * FROM RPTPeriods WHERE PeriodID = @uid";
            _DAO.AddParam("@uid", Request.QueryString["uid"]);
            dt = _DAO.GetTable(_DAO.GetClientReportingConnection);
            snapShotDate.SelectedDate = DateTime.Parse(dt.Rows[0]["PeriodDate"].ToString());
            title.Text = dt.Rows[0]["Title"].ToString();
            activate.Checked = (bool) dt.Rows[0]["Enabled"];
        }

        protected void save_Click(object sender, EventArgs e)
        {
            var id = new Guid(Request.QueryString["uid"]);
            _DAO.Command =
                "UPDATE RPTPeriods SET PeriodDate=@periodDate, Title=@title, Enabled=@enabled WHERE periodid=@period";
            _DAO.AddParam("@periodDate", snapShotDate.SelectedDate);
            _DAO.AddParam("@title", title.Text);
            _DAO.AddParam("@period", id);
            _DAO.AddParam("@enabled", activate.Checked);
            _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
            SPUtility.Redirect("/epmlive/AllSnapshots.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (_DAO != null)
            {
                _DAO.Dispose();
            }
        }
    }
}