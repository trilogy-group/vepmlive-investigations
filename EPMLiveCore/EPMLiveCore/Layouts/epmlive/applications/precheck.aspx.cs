using System;
using System.Data;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class precheck : LayoutsPageBase
    {
        protected string ApplicationName = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Act act = new Act(Web);

            if(act.CheckFeatureLicense(ActFeature.AppsAndCommunities) != 0)
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("epmlive/applications/noact.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);

            API.ApplicationDef appDef = API.Applications.GetApplicationInfo(Request["AppId"]);

            ApplicationName = appDef.Title;
            
        }        
    }
}