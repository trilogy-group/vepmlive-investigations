using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class listViewHost : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectToView();
        }

        private void RedirectToView()
        {
            SPWeb web = SPContext.Current.Web;
            string url = (Request["url"]);
            if (!string.IsNullOrEmpty(url))
            {
                Response.Redirect(url + "?IsDlg=1");
            }
        }
    }
}
