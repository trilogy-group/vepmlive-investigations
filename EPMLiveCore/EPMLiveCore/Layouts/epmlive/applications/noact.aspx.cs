using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;

namespace EPMLiveCore.Layouts.epmlive.applications
{
    public partial class noact : LayoutsPageBase
    {
        protected string sResponse = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Act act = new Act(Web);

            int activation = act.CheckFeatureLicense(ActFeature.AppsAndCommunities);

            sResponse = act.translateStatus(activation);
        }
    }
}
