using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;

namespace EPMLiveCore.Layouts.epmlive.applications
{
    public partial class installfromstore : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(Request["appid"]))
            {
                pnlNoApp.Visible = true;
                pnlMain.Visible = false;
            }
        }
    }
}
