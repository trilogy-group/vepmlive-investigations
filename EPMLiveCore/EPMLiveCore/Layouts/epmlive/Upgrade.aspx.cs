using System;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class Upgrade : LayoutsPageBase
    {
        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Web.CurrentUser.IsSiteAdmin)
            {
                pnlMain.Visible = false;
                lblError.Text = @"You are required to be the Site Collection Administrator in order to perform an upgrade.";

                return;
            }

            if (!Web.IsRootWeb)
            {
                NotRootMessageLabel.Visible = true;
            }
        }

        #endregion Methods 
    }
}