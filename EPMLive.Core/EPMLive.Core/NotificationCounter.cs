using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLiveCore.CONTROLTEMPLATES;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    [MdsCompliant(true)]
    [ToolboxData("<{0}:NotificationCounter runat=server></{0}:NotificationCounter>")]
    public class NotificationCounter : WebControl, INamingContainer
    {
        private const string ASCX_PATH = @"~/_controltemplates/EPMLiveNotificationCounter.ascx";

        protected override void CreateChildControls()
        {
            var control = (EPMLiveNotificationCounter) Page.LoadControl(ASCX_PATH);
            Controls.Add(control);
        }
    }
}