using System;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveSignals.Layouts.EPMLive
{
    public partial class Chat : LayoutsPageBase
    {
        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            EPMLiveScriptManager.RegisterScript(Page, new[] { "libraries/jquery.min","@jquery.signalR-1.1.3" });
        }

        #endregion Methods 
    }
}