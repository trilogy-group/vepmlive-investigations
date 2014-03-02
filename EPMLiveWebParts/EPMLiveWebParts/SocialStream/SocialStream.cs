using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using WebPart = Microsoft.SharePoint.WebPartPages.WebPart;

namespace EPMLiveWebParts
{
    [ToolboxItem(false)]
    public class SocialStream : WebPart
    {
        #region Methods (1) 

        // Protected Methods (1) 

        protected override void CreateChildControls()
        {
            var control = (CONTROLTEMPLATES.SocialStream) Page.LoadControl(@"~/_CONTROLTEMPLATES/SocialStream.ascx");
            Controls.Add(control);
        }

        #endregion Methods 

        #region Overrides of WebPart

        protected override void OnPreRender(EventArgs e)
        {
            ChromeType = PartChromeType.None;
        }

        #endregion
    }
}