using System.Collections.Generic;
using System.Threading.Tasks;
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

        public WorkplaceLinkProvider(SPWeb spWeb) : base(spWeb) { }

        #endregion Constructors 

        #region Methods (2) 

        // Private Methods (2) 

        private IEnumerable<INavObject> GetMyWorkplaceLinks()
        {
            string key = SPWeb.ID + "_NavLinks_" + "GlobalMyWorkplace";
            SPUserToken userToken = SPWeb.GetUserToken(SPWeb.CurrentUser.LoginName);

            return (IEnumerable<INavObject>) CacheStore.Current.Get(key, CacheStoreCategory.Navigation, () =>
            {
                var links = new List<NavLink>();

                using (var spSite = new SPSite(SPWeb.Site.ID, userToken))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        var locker = new object();
                        SPNavigation spNavigation = spWeb.Navigation;

                        Parallel.ForEach(GetNodes(spWeb), nodeId =>
                        {
                            SPNavigationNode node = spNavigation.GetNodeById(nodeId);

                            if (node == null) return;

                            var link = new NavLink {Title = node.Title, Url = node.Url, External = node.IsExternal};

                            lock (locker)
                            {
                                links.Add(link);
                            }
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