using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;

namespace EPMLiveAccountManagement.Layouts.epmlive
{
    public partial class createsitecollection : LayoutsPageBase
    {
        protected const string webapp = "SharePoint - 41899";
        protected const string url = "http://jasondev2008:41899/sites/newsite2";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SPUser spuser = SPContext.Current.Web.CurrentUser;
            string user = spuser.LoginName;
            string email = spuser.Email;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                try
                {
                    SPWebService myWebService = SPWebService.ContentService;

                    SPWebApplication spApp = myWebService.WebApplications[webapp];

                    SPSite site = spApp.Sites.Add(url, user, email);
                }
                catch (Exception ex) { Response.Write(ex.Message); }
            });
        }
    }
}
