using System;
using System.Web.UI;
using Microsoft.SharePoint;

namespace EPMLiveCore.ControlTemplates
{
    public partial class EPMLiveStatusbar : UserControl
    {
        #region Fields (1) 

        protected readonly string SiteUrl = SPContext.Current.Web.SafeServerRelativeUrl();

        #endregion Fields 

        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #endregion Methods 
    }
}