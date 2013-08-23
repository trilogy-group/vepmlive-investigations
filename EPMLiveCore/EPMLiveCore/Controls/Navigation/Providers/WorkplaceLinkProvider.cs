using System.Collections.Generic;
using System.Threading.Tasks;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;
using Microsoft.SharePoint;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    [NavLinkProviderInfo(Name = "MyWorkplace")]
    public class WorkplaceLinkProvider : NavLinkProvider
    {
        #region Constructors (1) 

        public WorkplaceLinkProvider(SPWeb spWeb) : base(spWeb) { }

        #endregion Constructors 

        #region Methods (1) 

        // Private Methods (1) 

        private IEnumerable<INavObject> GetMyWorkplaceLinks()
        {
            string key = SPWeb.ID + "_NavLinks_" + "GlobalMyWorkplace";

            return (IEnumerable<INavObject>) CacheStore.Current.Get(key, CacheStoreCategory.Navigation, () =>
            {
                var links = new List<NavLink>();

                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    using (var spSite = new SPSite(SPWeb.Site.ID))
                    {
                        using (SPWeb spWeb = spSite.OpenWeb())
                        {
                            SPList installedAppsList = null;

                            try
                            {
                                installedAppsList = SPContext.Current.Web.Lists["Installed Applications"];
                            }
                            catch { }

                            if (installedAppsList == null) return;

                            var query = new SPQuery
                            {
                                Query =
                                    @"<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>Global My Workplace</Value></Eq></Where>",
                                ViewFields = @"<FieldRef Name='QuickLaunch' />"
                            };

                            SPListItemCollection communities = installedAppsList.GetItems(query);

                            if (communities.Count > 0)
                            {
                                SPListItem workplace = communities[0];
                                var ql = (string) (workplace["QuickLaunch"] ?? string.Empty);

                                Parallel.ForEach(ql.Split(','), id =>
                                {
                                    try
                                    {
                                        var nodeId = int.Parse(id);


                                    }catch{}
                                });
                            }
                        }
                    }
                });

                return links;
            }).Value;
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