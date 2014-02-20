using System;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive.Upgraders
{
    public partial class OptInUpgrade55 : LayoutsPageBase
    {
        #region Fields (1) 

        private const string LAYOUT_PATH = "/_layouts/15/epmlive/";

        #endregion Fields 

        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Web.CurrentUser.IsSiteAdmin)
            {
                pnlMain.Visible = false;
                lblError.Text =
                    @"You are required to be the Site Collection Administrator in order to perform an upgrade.";

                return;
            }

            if (!Web.IsRootWeb)
            {
                NotRootMessageLabel.Visible = true;
            }
        }

        #endregion Methods 

        #region Overrides of UnsecuredLayoutsPageBase

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            foreach (string style in new[] {"upgrader.min"})
            {
                SPPageContentManager.RegisterStyleFile(LAYOUT_PATH + "stylesheets/" + style + ".css");
            }

            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "@EPMLive.Upgrader"
            });
        }

        #endregion
    }
}