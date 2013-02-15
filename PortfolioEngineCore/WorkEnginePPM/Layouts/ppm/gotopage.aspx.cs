using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class gotopage : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SPWeb web = SPContext.Current.Web)
            {
                Response.Redirect(Request["page"] + ".aspx?itemid=" + Request["itemid"] + "&epkurl=" + ConfigFunctions.getConfigSetting(web, "EPKURL") + "&view=1&isDlg=1");
            }
        }
    }
}
