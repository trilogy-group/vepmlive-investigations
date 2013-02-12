using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.WebControls;
using System.Web;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class newitem : LayoutsPageBase
    {
        protected string URL = "";
        protected Label lblTitle;

        protected void Page_Load(object sender, EventArgs e)
        {
            string title = HttpUtility.HtmlEncode(Request["List"]);
            lblTitle.Text = "New " + title + " Item";

        }
    }
}
