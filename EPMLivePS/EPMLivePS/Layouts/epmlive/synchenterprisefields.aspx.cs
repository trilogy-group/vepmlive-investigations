using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace EPMLiveEnterprise
{
    public partial class synchenterprisefields : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            EPMLiveEnterprise.ProjectWorkspaceSynch pws = new ProjectWorkspaceSynch(SPContext.Current.Site.ID, SPContext.Current.Web.Url, new Guid(), SPContext.Current.Web.CurrentUser.LoginName);
            pws.processProjectCenter();
            pws.processTaskCenter();

            Page.RegisterStartupScript("Alert", "<script language=\"javascript\">alert('All fields have been synchronize');location.href='../settings.aspx';</script>");
        }

    }
}