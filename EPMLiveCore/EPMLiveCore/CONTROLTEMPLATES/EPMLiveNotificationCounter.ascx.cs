using System;
using System.Web.UI;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.CONTROLTEMPLATES
{
    [MdsCompliant(true)]
    public partial class EPMLiveNotificationCounter : UserControl
    {
        #region Fields (1) 

        private const string LAYOUT_PATH = "/_layouts/15/epmlive/";

        #endregion Fields 

        #region Methods (2) 

        // Protected Methods (2) 

        protected override void OnPreRender(EventArgs e)
        {
            SPPageContentManager.RegisterStyleFile(LAYOUT_PATH + "stylesheets/notifications.min.css");
            EPMLiveScriptManager.RegisterScript(Page, new[] {"libraries/jquery.min", "@EPMLive.Notifications"});
        }

        protected void Page_Load(object sender, EventArgs e) { }

        #endregion Methods 
    }
}