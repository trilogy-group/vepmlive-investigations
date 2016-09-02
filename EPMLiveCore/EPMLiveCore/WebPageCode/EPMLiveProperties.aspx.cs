using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;
using System.Data.SqlClient;
using System.Web.Services;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore
{
    public partial class EPMLiveProperties : System.Web.UI.Page
    {
        protected string currentWebUrl = string.Empty;
        protected string analyticsUrl = string.Empty;
        protected string epmlApiUrl = string.Empty;
        protected WebApplicationSelector WebApplicationSelector1;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentWebUrl = SPContext.Current.Web.Url;
            if (!IsPostBack)
            {
                analyticsUrl = CoreFunctions.getFarmSetting("UplandAnalyticsURL");
            }
        }

        protected void WebApplicationSelector1_ContextChange(object sender, EventArgs e)
        {
            epmlApiUrl = CoreFunctions.getWebAppSetting(new Guid(WebApplicationSelector1.CurrentId), "EPMLiveAPIURL");
        }
    }
}
