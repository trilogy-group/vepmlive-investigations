using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Web;

namespace EPMLiveCore.Layouts.epmlive.applications
{
    public partial class Apps : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Act act = new Act(Web);

            if(act.CheckFeatureLicense(ActFeature.AppsAndCommunities) != 0)
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/applications/noact.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);

            DataTable dtApps = API.Applications.GetApplications("");


            GridView2.DataSource = dtApps;
            GridView2.DataBind();
        }

        protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRow dr = ((DataRowView)e.Row.DataItem).Row;

                e.Row.Cells[0].Text = "<b>" + dr["Title"].ToString() + "</b><br>" + dr["description"].ToString();
            }
        }

        protected string InstallButton(object id)
        {
            return "Install('" + id.ToString() + "');return false;";
        }
    }
}
