using System;
using System.Web.UI;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.ControlTemplates
{
    public partial class TemplateVersoning : UserControl
    {
        #region Fields (2) 

        protected readonly string SiteUrl = SPContext.Current.Web.SafeServerRelativeUrl();
        protected bool UseLiveTemplates;

        #endregion Fields 

        #region Methods (1) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid siteid = SPContext.Current.Site.ID;
            Guid webid = SPContext.Current.Web.ID;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var site = new SPSite(siteid))
                {
                    using (SPWeb web = site.OpenWeb(webid))
                    {
                        UseLiveTemplates =
                            bool.Parse(CoreFunctions.getLockConfigSetting(web, "EPMLiveUseLiveTemplates", false));
                    }
                }
            });

            if (!UseLiveTemplates)
            {
                EPMLiveScriptManager.RegisterScript(Page, new[]
                {
                    "libraries/jquery.min", "@EPMLive.TemplateVersoning"
                });
            }
        }

        #endregion Methods 
    }
}