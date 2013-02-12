using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.Layouts.epmlive
{
    public partial class TemplateGalleryRedirect : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            Guid lWeb = web.ID;

            string url = "";

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(SPContext.Current.Site.ID))
                {
                    using(SPWeb w = site.OpenWeb(web.ID))
                    {
                        lWeb = CoreFunctions.getLockedWeb(web);

                        if(lWeb != web.ID)
                        {
                            using(SPWeb oLockWeb = web.Site.OpenWeb(lWeb))
                            {
                                pnlAdmin.Visible = true;
                                hlAdmin.NavigateUrl = oLockWeb.ServerRelativeUrl + "/_layouts/epmlive/templategalleryredirect.aspx";
                                pnlMain.Visible = false;
                            }
                        }
                        else
                        {
                            SPList list = web.Lists.TryGetList("Template Gallery");
                            if(list != null)
                            {
                                url = list.DefaultViewUrl;
                            }
                        }
                    }
                }
            });

            if(url != "")
            {
                Response.Redirect(url);
            }
        }
    }
}
