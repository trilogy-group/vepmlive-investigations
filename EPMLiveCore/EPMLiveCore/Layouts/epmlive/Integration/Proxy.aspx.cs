using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    public partial class Proxy : LayoutsPageBase
    {
        protected string data = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                API.Integration.IntegrationCore core = new API.Integration.IntegrationCore(Web.Site.ID, Web.ID);

                data = core.GetProxyResult(new Guid(Request["IntegrationId"]), Request["ItemId"], Request["Control"], Request["Property"]);
            });
        }
    }
}
