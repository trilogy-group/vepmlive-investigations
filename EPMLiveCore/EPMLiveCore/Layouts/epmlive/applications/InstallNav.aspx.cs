using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Text;
using System.Web;

namespace EPMLiveCore.Layouts.epmlive.applications
{
    public partial class InstallNav : LayoutsPageBase
    {
        protected StringBuilder sbOutput = new StringBuilder();
        protected string ApplicationName;
        protected string sFullWebUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            Act act = new Act(Web);

            if(act.CheckFeatureLicense(ActFeature.AppsAndCommunities) != 0)
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/applications/noact.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);

            API.ApplicationDef appDef = API.Applications.GetApplicationInfo(Request["AppId"]);

            ApplicationName = appDef.Title;

            sFullWebUrl = Web.Url;

            try
            {
                SPList oList = Web.Lists.TryGetList("Installed Applications");
                if(oList != null)
                {
                    SPListItem li = oList.GetItemById(int.Parse(Request["CommId"]));
                    API.Applications.AddAppToCommunity(li, int.Parse(Request["AppId"]));
                }

                sbOutput.Append("<div class=\"alert alert-success\">This application has been successfully added to the community.</div>");
            }
            catch(Exception ex)
            {

                sbOutput.Append("<div class=\"alert alert-error\">There was an error adding this application to the community: " + ex.Message + "</div>");

            }
        }
    }
}
