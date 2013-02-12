using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Text;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore
{
    public partial class prjsetng : LayoutsPageBase
    {
        protected string data = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            if(!CoreFunctions.DoesCurrentUserHaveFullControl(web))
            {
                Microsoft.SharePoint.Utilities.SPUtility.TransferToErrorPage("Access denied.");
            }

            if(!IsPostBack)
            {
                TxtWebTitle.Text = web.Title;
                TxtWebDescription.Text = web.Description;
                TxtSiteLogoUrl.Text = web.SiteLogoUrl;
                TxtLogoUrlDescription.Text = web.SiteLogoDescription;
            }
        }

        protected void BtnUpdateWeb_Click(object sender, EventArgs e)
        {
            SPWeb w = SPContext.Current.Web;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(w.Site.ID))
                {
                    using(SPWeb web = site.OpenWeb(w.ID))
                    {
                        web.AllowUnsafeUpdates = true;
                        web.Title = TxtWebTitle.Text;
                        web.Description = TxtWebDescription.Text;
                        web.SiteLogoUrl = TxtSiteLogoUrl.Text;
                        web.SiteLogoDescription = TxtLogoUrlDescription.Text;

                        web.Update();
                    }
                }
            });

            if(!String.IsNullOrEmpty(Request["Source"]))
            {
                Response.Redirect(Request["Source"]); 
            }
            else
            {
                SPUtility.Redirect("settings.aspx", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
            }
        }
    }
}
