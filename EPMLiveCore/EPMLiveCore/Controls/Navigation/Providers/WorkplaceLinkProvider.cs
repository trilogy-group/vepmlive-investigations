using System;
using System.Collections.Generic;
using System.Linq;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    [NavLinkProviderInfo(Name = "MyWorkplace")]
    public class WorkplaceLinkProvider : NavLinkProvider
    {
        #region Constructors (1) 

        public WorkplaceLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username) { }

        #endregion Constructors 

        #region Methods (3) 

        // Private Methods (3) 

        private static string CalculateUrl(string url)
        {
            return url;
        }

        private IEnumerable<INavObject> GetMyWorkplaceLinks()
        {
            string key = SiteId + "_NavLinks_" + "GlobalMyWorkplace";

            return (IEnumerable<INavObject>) CacheStore.Current.Get(key, CacheStoreCategory.Navigation, () =>
            {
                var links = new List<NavLink>();

                using (var spSite = new SPSite(SiteId, GetUserToken()))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        SPNavigation spNavigation = spWeb.Navigation;

                        links.AddRange(from nodeId in GetNodes(spWeb)
                            select spNavigation.GetNodeById(nodeId)
                            into node
                            where node != null
                            select new NavLink
                            {
                                Title = node.Title,
                                Url = CalculateUrl(node.Url),
                                External = node.IsExternal
                            });
                    }
                }

                return links;
            }).Value;
        }

        private static IEnumerable<int> GetNodes(SPWeb spWeb)
        {
            SPList installedAppsList = null;

            try
            {
                installedAppsList = spWeb.Lists["Installed Applications"];
            }
            catch { }

            if (installedAppsList == null) yield break;

            var query = new SPQuery
            {
                Query =
                    @"<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>Global My Workplace</Value></Eq></Where>",
                ViewFields = @"<FieldRef Name='QuickLaunch' />"
            };

            SPListItemCollection communities = installedAppsList.GetItems(query);

            if (communities.Count <= 0) yield break;

            SPListItem workplace = communities[0];
            var ql = (string) (workplace["QuickLaunch"] ?? string.Empty);

            foreach (string id in ql.Split(','))
            {
                int nodeId;
                if (int.TryParse(id, out nodeId))
                {
                    yield return nodeId;
                }
            }
        }

        #endregion Methods 

        #region Overrides of NavLinkProvider

        public override IEnumerable<INavObject> GetLinks()
        {
            return GetMyWorkplaceLinks();
        }

        #endregion
    }
}