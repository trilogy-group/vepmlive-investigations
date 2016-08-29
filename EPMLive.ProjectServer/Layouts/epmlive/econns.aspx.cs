using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.WebControls;

namespace EPMLiveEnterprise.Layouts.epmlive
{
    public partial class econns : LayoutsPageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    txtPublished.Text = EPMLiveEnterprise.EPMLiveHelperClasses.getProjectServerPublishedConnectionString(SPContext.Current.Site.ID);

                });
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                EPMLiveEnterprise.EPMLiveHelperClasses.setProjectServerPublishedConnectionString(SPContext.Current.Site.ID, txtPublished.Text);
            });
        }
    }
}
