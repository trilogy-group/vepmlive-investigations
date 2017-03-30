using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveAccountManagement
{
    public partial class amerror : LayoutsPageBase
    {

        protected string siteurl;

        protected void Page_Load(object sender, EventArgs e)
        {

            using (SPWeb web = SPContext.Current.Web)
            {
                siteurl = web.Url;
            }

        }
    }
}