using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveAccountManagement.Layouts.epmlive
{
    public partial class onlinesettings : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                chkDisableRes.Checked = bool.Parse(EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Web, "OnlineDisableResReq"));
            }
            catch { }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            EPMLiveCore.CoreFunctions.setConfigSetting(web, "OnlineDisableResReq", chkDisableRes.Checked.ToString());

            Microsoft.SharePoint.Utilities.SPUtility.Redirect("settings.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
        }

    }
}
