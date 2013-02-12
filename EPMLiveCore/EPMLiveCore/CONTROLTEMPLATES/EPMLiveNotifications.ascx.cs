using System;
using System.Web.UI;
using Microsoft.SharePoint;

namespace EPMLiveCore.ControlTemplates
{
    public partial class EPMLiveNotifications : UserControl
    {
        #region Fields (1) 

        protected readonly string SiteUrl = SPContext.Current.Web.SafeServerRelativeUrl();

        #endregion Fields 

        #region Methods (1) 

        // Protected Methods (1) 

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #endregion Methods 
    }
}