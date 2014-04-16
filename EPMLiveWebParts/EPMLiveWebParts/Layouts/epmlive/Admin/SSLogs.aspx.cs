using System;
using EPMLiveCore;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.Layouts.epmlive.Admin
{
    public partial class SSLogs : LayoutsPageBase
    {
        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            string layoutPath = SPContext.Current.Web.SafeServerRelativeUrl() + "/_layouts/15/epmlive/";

            SPPageContentManager.RegisterStyleFile(layoutPath + "stylesheets/SocialStream.Logs.min.css");
            SPPageContentManager.RegisterStyleFile(layoutPath + "javascripts/libraries/highlight/styles/vs.css");

            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "libraries/jquery.min", "libraries/handlebars-v1.3.0",
                "@libraries/amplify", "@libraries/bundles/moment",
                "libraries/highlight/highlight.pack", "@EPMLive.SocialStream.Logs"
            });
        }

        #endregion Methods 
    }
}