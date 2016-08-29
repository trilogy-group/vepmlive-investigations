using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive.Upgraders
{
    public partial class Upgrade : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Web.CurrentUser.IsSiteAdmin)
            {
                pnlMain.Visible = false;
                lblError.Text = "You are not an admin.";
            }
            else if(!Web.IsRootWeb)
            {
                lblError.Text = "You must run this on the root web.";
                pnlMain.Visible = false;
            }
            else
            {
            }
        }
    }
}
