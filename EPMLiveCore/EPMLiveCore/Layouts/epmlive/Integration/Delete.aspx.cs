using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    public partial class Delete : LayoutsPageBase
    {
        protected Guid intlistid = Guid.Empty;
        protected Guid moduleid = Guid.Empty;
        API.Integration.IntegrationCore intcore;
        API.Integration.IntegrationAdmin intadmin;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                intlistid=new Guid(Request["intlistid"]);
            }catch{}
            try
            {
                moduleid=new Guid(Request["module"]);
            }catch{}

            intcore = new API.Integration.IntegrationCore(Web.Site.ID, Web.ID);
            intadmin = new API.Integration.IntegrationAdmin(intcore, intlistid, moduleid);

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                intadmin.DeleteIntegration(intlistid);
            });

            SPUtility.Redirect("epmlive/integration/integrationlist.aspx?LIST=" + Request["List"], SPRedirectFlags.RelativeToLayoutsPage, System.Web.HttpContext.Current);
        }
    }
}
