using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class deleteweb : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelWebUrl.Text = SPContext.Current.Web.Url;
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SPWeb w = SPContext.Current.Web;
            w.AllowUnsafeUpdates = true;
            if(CoreFunctions.DoesCurrentUserHaveFullControl(w))
            {
                string url = "";

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using(SPSite site = new SPSite(w.Site.ID))
                    {
                        site.AllowUnsafeUpdates = true;
                        using(SPWeb web = site.OpenWeb(w.ID))
                        {
                            web.AllowUnsafeUpdates = true; 
                            url = web.ParentWeb.ServerRelativeUrl;
                            web.Delete();
                        }
                    }
                });

                Response.Redirect(url);
            }

        }
    }
}
