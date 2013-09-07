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
        #region Fields (1) 

        private readonly string _key;

        #endregion Fields 

        #region Constructors (1) 

        public WorkplaceLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username)
        {
            _key = "NavLinks_MyWorkplace_W_" + WebId + "_U_" + UserId;
        }

        #endregion Constructors 

        #region Methods (3) 

        // Private Methods (3) 

        private string CalculateUrl(string url, bool isRootWeb)
        {
            if (isRootWeb) return url;

            if (url.Contains("_layouts"))
            {
                string[] parts = url.Split(new[] {"_layouts"}, StringSplitOptions.None);
                url = RelativeUrl + "_layouts" + string.Join(string.Empty, parts.Skip(1));
            }
            else
            {
                url = string.Format(@"javascript:OpenCreateWebPageDialog('{0}');", url);
            }

            return url;
        }

        private IEnumerable<INavObject> GetMyWorkplaceLinks()
        {
            return (IEnumerable<INavObject>) CacheStore.Current.Get(_key, CacheStoreCategory.Navigation, () =>
            {
                var links = new List<NavLink>
                {
                    new NavLink
                    {
                        Title = "My Workplace",
                        Url = "Header"
                    }
                };

                using (var spSite = new SPSite(SiteId, GetUserToken()))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        bool isRootWeb = spWeb.IsRootWeb;
                        SPNavigation spNavigation = spWeb.Navigation;

                        links.AddRange(from nodeId in GetNodes(spWeb)
                            select spNavigation.GetNodeById(nodeId)
                            into node
                            where node != null
                            select new NavLink
                            {
                                Title = node.Title,
                                Url = CalculateUrl(node.Url, isRootWeb)
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

        protected override string Key
        {
            get { return _key; }
        }

        public override IEnumerable<INavObject> GetLinks()
        {
            return GetMyWorkplaceLinks();
        }

        #endregion
    }
}