using System.ComponentModel;
using Microsoft.SharePoint.WebPartPages;

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
    }
}