using System;
using System.Data;
using System.Web.UI.WebControls;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using EPMLiveCore.ReportHelper;

namespace EPMLiveReportsAdmin.Layouts.EPMLive
{
    public partial class ReportDatabases : LayoutsPageBase
    {
        protected ToolBarButton AddMapping;
        protected Content Content3;
        protected GridView GridView1;
        protected MenuItemTemplate MenuItemTemplate1;
        protected WebApplicationSelector WebApplicationSelector1;
        protected HiddenField hdnUserId;
        protected Label lblError;
        protected Label lblSuccess;
        protected Label lblTitle;
        protected Label message;
        protected MenuTemplate mtEventMenu;
        protected string version;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["DeleteId"] != null)
                {
                    var webAppId = new Guid(Request["WebAppId"]);
                    var siteId = new Guid(Request["DeleteId"]);
                    var rb = new ReportBiz(siteId, webAppId);
                    bool canDeleteDb = rb.RemoveDatabaseMapping();
                }
                FillData();
            }
        }

        private void FillData()
        {
            if (WebApplicationSelector1.CurrentId != null)
            {
                var webAppId = new Guid(WebApplicationSelector1.CurrentId);
                var epmData = new ReportData(SPContext.Current.Site.ID, webAppId);

                if (epmData.EPMLiveConOpen)
                {
                    //var mappings = epmData.GetDbMappings().DefaultView;

                    DataTable dtMappings = epmData.GetDbMappings();
                    //dtMappings.Columns.Add("Version");
                    //foreach (DataRow dbMapping in dtMappings.Rows)
                    //{
                    //    dbMapping["Version"] = epmData.GetDbVersion((Guid)dbMapping["siteId"]);
                    //}

                    DataView mappings = dtMappings.DefaultView;
                    mappings.RowFilter = string.Format("WebApplicationId = '{0}'", WebApplicationSelector1.CurrentId);
                    GridView1.DataSource = mappings;
                    GridView1.DataBind();
                    epmData.Dispose();
                    string constr = CoreFunctions.getConnectionString(webAppId);
                    if (constr == "")
                    {
                        AddMapping.Visible = false;
                        WebApplicationSelector1.Visible = true;
                    }
                }
                else
                {
                    message.Text = "<br/> EPMLive ConnectionString property not initialized for Central Admin.";
                    message.Visible = true;
                    AddMapping.Visible = false;
                    WebApplicationSelector1.Visible = true;
                }
            }
        }

        protected void AddMapping_Click(object sender, EventArgs e)
        {
            SPWebApplication currentWebApp = WebApplicationSelector1.CurrentItem;
            if (currentWebApp != null)
            {
                Guid id = currentWebApp.Id;
                Response.Redirect(SPContext.Current.Site.ServerRelativeUrl +
                                  "_admin/EPMLive/SetupReportDatabase.aspx?Id=" + id);
            }
            FillData();
        }

        protected void WebApplicationSelector1_ContextChange(object sender, EventArgs e)
        {
            FillData();
        }
    }
}