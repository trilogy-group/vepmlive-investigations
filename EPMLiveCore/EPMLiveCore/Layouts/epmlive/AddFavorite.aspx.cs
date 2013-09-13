using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class AddFavorite : LayoutsPageBase
    {
        protected string sid;
        protected string wid;

        protected string listid = string.Empty;
        protected string itemid = string.Empty;
        protected string url = string.Empty;
        protected string pageName = string.Empty;
        protected string userid = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request["listid"]))
            {
                listid = Request["listid"];
            }

            if (!string.IsNullOrEmpty(Request["itemid"]))
            {
                itemid = Request["itemid"];
            }

            if (!string.IsNullOrEmpty(Request["currentUrl"]))
            {
                url = Request["currentUrl"];
            }

            if (!string.IsNullOrEmpty(Request["pageName"]))
            {
                pageName = Request["pageName"];
            }

            if (!string.IsNullOrEmpty(Request["userid"]))
            {
                userid = Request["userid"];
            }

            sid = SPContext.Current.Site.ID.ToString();
            wid = SPContext.Current.Web.ID.ToString();

        }
    }
}
