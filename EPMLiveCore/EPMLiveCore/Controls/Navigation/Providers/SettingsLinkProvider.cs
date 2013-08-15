using System.Collections.Generic;
using EPMLiveCore.Infrastructure.Navigation;
using Microsoft.SharePoint;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    [NavLinkProviderInfo(Name = "Settings")]
    public class SettingsLinkProvider : NavLinkProvider
    {
        public SettingsLinkProvider(SPWeb spWeb) : base(spWeb) { }

        #region Implementation of INavLinkProvider

        public override IEnumerable<INavObject> GetLinks()
        {
            string relativeUrl = SPWeb.ServerRelativeUrl;

            var links = new List<NavLink>
            {
                new NavLink
                {
                    Title = "Edit Page",
                    Url = "javascript:ChangeLayoutMode(false);"
                },
                new NavLink
                {
                    Title = "Add a page",
                    Url = string.Format("javascript:OpenCreateWebPageDialog('{0}/_layouts/15/createwebpage.aspx');", relativeUrl)
                },
                new NavLink
                {
                    Title = "Add an app",
                    Url = "http://market.epmlive.com/",
                    External = true
                },
                new NavLink
                {
                    Title = "Site contents",
                    Url = string.Format("{0}/_layouts/15/viewlsts.aspx", relativeUrl)
                },
                new NavLink
                {
                    Title = "Advance site settings",
                    Url = string.Format("javascript:GoToPage('{0}/_layouts/15/epmlive/settings.aspx');", relativeUrl)
                }
            };

            return links;
        }

        #endregion
    }
}