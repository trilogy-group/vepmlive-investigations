using System;
using System.Collections.Generic;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    [NavLinkProviderInfo(Name = "Applications")]
    public class ApplicationsLinkProvider : NavLinkProvider
    {
        #region Constructors (1) 

        public ApplicationsLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username) { }

        #endregion Constructors 

        #region Overrides of NavLinkProvider

        public override IEnumerable<INavObject> GetLinks()
        {
            string key = "NavLinks_Applications_W_" + WebId + "_U_" + UserId;

            return (IEnumerable<INavObject>) CacheStore.Current.Get(key, CacheStoreCategory.Navigation, () =>
            {
                var links = new List<NavLink>
                {
                    new NavLink
                    {
                        Title = "Add New",
                        Url = "Header"
                    },
                    new NavLink
                    {
                        Title = "Add new application",
                        Url =
                            string.Format(
                                @"javascript:OpenCreateWebPageDialog('{0}/_layouts/15/epmlive/QueueCreateWorkspace.aspx?standalone=true&isDlg=1');",
                                RelativeUrl)
                    }
                };

                return links;
            }).Value;
        }

        #endregion
    }
}