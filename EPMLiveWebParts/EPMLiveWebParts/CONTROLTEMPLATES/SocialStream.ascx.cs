using System;
using System.Web.UI;
using EPMLiveCore;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.CONTROLTEMPLATES
{
    public partial class SocialStream : UserControl
    {
        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e) { }

        #endregion Methods 

        #region Overrides of Control

        protected override void OnPreRender(EventArgs e)
        {
            string layoutPath = SPContext.Current.Web.SafeServerRelativeUrl() + "/_layouts/15/epmlive/";

            SPPageContentManager.RegisterStyleFile(layoutPath + "stylesheets/SocialStream.min.css");

            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "libraries/jquery.min", "libraries/handlebars-v1.3.0", @"libraries/amplify", "libraries/moment.min",
                "@EPMLive.SocialStream"
            });
        }

        #endregion
    }
}