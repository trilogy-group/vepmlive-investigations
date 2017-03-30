using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveAccountManagement
{
    public partial class nolink : LayoutsPageBase
    {

        protected string siteguid;

        protected void Page_Load(object sender, EventArgs e)
        {

            using (SPWeb web = SPContext.Current.Web)
            {
                siteguid = web.Site.ID.ToString();
            }

        }
    }
}