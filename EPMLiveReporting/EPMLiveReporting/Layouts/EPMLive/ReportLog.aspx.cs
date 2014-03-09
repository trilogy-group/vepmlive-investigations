using System;
using System.Data;
using System.Web;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class ReportLog : LayoutsPageBase
    {
        //protected GridView grdErrors;
        protected MenuItemTemplate MenuItemTemplate1;
        protected ToolBar Toolbar;
        //protected Label lblTitle;
        private Guid _listId;
        private string _logType = "";
        protected MenuTemplate mtEventMenu;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ListId"] == null)
                SPUtility.Redirect("epmlive/ListMappings.aspx", SPRedirectFlags.RelativeToLayoutsPage,
                    HttpContext.Current);
            _listId = new Guid(Request.QueryString["ListId"]);

            if (Request.QueryString["LogType"] != null)
            {
                _logType = Request.QueryString["LogType"];
                if (_logType == "1")
                    lblTitle.Text = "Reporting Log: General";
                if (_logType == "2")
                    lblTitle.Text = "Reporting Log: Snapshots";
                if (_logType == "3")
                    lblTitle.Text = "Reporting Log: Refresh";
            }

            if (!IsPostBack)
                FillData();
        }

        private void FillData()
        {
            Guid siteId = SPContext.Current.Site.ID;
            var rb = new ReportBiz(siteId);
            ListBiz list = rb.GetListBiz(_listId);
            DataTable dt = list.GetLog(0);
            DataView errors = dt.DefaultView;
            if (_logType != "")
                errors.RowFilter = "[Type] = " + _logType;
            grdErrors.DataSource = errors;
            grdErrors.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Guid siteId = SPContext.Current.Site.ID;
            var rb = new ReportBiz(siteId);
            ListBiz list = rb.GetListBiz(_listId);
            list.ClearLog(_logType);

            FillData();
        }
    }
}