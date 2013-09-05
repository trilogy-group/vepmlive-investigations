using System;
using System.Collections.Generic;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    [NavLinkProviderInfo(Name = "Workspaces")]
    public class WorkspaceLinkProvider : NavLinkProvider
    {
        #region Fields (1) 

        private const string CREATE_WORKSPACE_URL =
            @"javascript:OpenCreateWebPageDialog('{0}/_layouts/15/QueueCreateWorkspace.aspx?standalone=true');";

        #endregion Fields 

        #region Constructors (1) 

        public WorkspaceLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username) { }

        #endregion Constructors 

        #region Overrides of NavLinkProvider

        public override IEnumerable<INavObject> GetLinks()
        {
            string key = "NavLinks_Workspaces_S_" + SiteId + "_U_" + UserId;

            return (IEnumerable<INavObject>) CacheStore.Current.Get(key, CacheStoreCategory.Navigation, () =>
            {
                var links = new List<NavLink>
                {
                    new NavLink
                    {
                        Title = "Workspaces",
                        Url = "Header"
                    },
                    new NavLink
                    {
                        Title = "New Workspace",
                        Url = string.Format(CREATE_WORKSPACE_URL, RelativeUrl),
                        CssClass = "epm-nav-button icon-cube"
                    }
                };

                return links;
            }).Value;
        }

        #endregion
    }
}