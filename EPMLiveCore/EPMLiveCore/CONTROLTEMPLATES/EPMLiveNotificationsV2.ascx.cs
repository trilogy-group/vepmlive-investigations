using System;
using System.Web.UI;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.ControlTemplates
{
    [MdsCompliant(true)]
    public partial class EPMLiveNotificationsV2 : UserControl
    {
        #region Fields (1)

        protected readonly string SiteUrl = SPContext.Current.Web.SafeServerRelativeUrl();

        #endregion Fields

        #region Methods (2)

        // Protected Methods (2) 

        protected override void OnPreRender(EventArgs e)
        {
            EPMLiveScriptManager.RegisterScript(Page, "@Notifications");
        }

        /// <summary>
        ///     Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected void Page_Load(object sender, EventArgs e) { }

        #endregion Methods
    }
}