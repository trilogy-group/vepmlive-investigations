using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    public class GenericLinkProvider : NavLinkProvider
    {
        #region Fields (4) 

        private const string A_QUERY = @"SELECT FRF_ID FROM dbo.FRF WHERE (FRF_ID = @Id) AND (Type = 1 OR Type = 2)";
        private const string D_QUERY = @"DELETE FROM dbo.FRF WHERE (FRF_ID = @Id)";
        private const string R_QUERY = @"UPDATE dbo.FRF SET F_Int = @Order WHERE FRF_ID = @Id";

        private const string U_QUERY =
            @"SELECT FRF_ID FROM dbo.FRF WHERE (FRF_ID = @Id) AND (USER_ID = @UserId) AND (Type = 1 OR Type = 2)";

        #endregion Fields 

        #region Constructors (1) 

        public GenericLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username) { }

        #endregion Constructors 

        #region Methods (3) 

        // Public Methods (2) 

        public void Remove(Guid linkId)
        {
            using (var spSite = new SPSite(SiteId))
            {
                using (SPWeb spWeb = spSite.OpenWeb(WebId))
                {
                    DataTable linkTable;

                    var queryExecutor = new QueryExecutor(spWeb);

                    SPUser currentUser = spWeb.CurrentUser;

                    if (currentUser.IsSiteAdmin || spWeb.DoesUserHavePermissions(SPBasePermissions.ManageWeb))
                    {
                        linkTable = queryExecutor.ExecuteEpmLiveQuery(A_QUERY, new Dictionary<string, object>
                        {
                            {"@Id", linkId}
                        });
                    }
                    else
                    {
                        linkTable = queryExecutor.ExecuteEpmLiveQuery(U_QUERY, new Dictionary<string, object>
                        {
                            {"@Id", linkId},
                            {"@UserId", currentUser.ID}
                        });
                    }

                    if (linkTable.Rows.Count == 0) return;

                    queryExecutor.ExecuteEpmLiveNonQuery(D_QUERY, new Dictionary<string, object>
                    {
                        {"@Id", linkId}
                    });

                    CleareCache();
                }
            }
        }

        public void Reorder(Dictionary<Guid, int> data)
        {
            if (!data.Any()) return;

            using (var spSite = new SPSite(SiteId, GetUserToken()))
            {
                using (SPWeb spWeb = spSite.OpenWeb(WebId))
                {
                    var queryExecutor = new QueryExecutor(spWeb);

                    foreach (var pair in data)
                    {
                        queryExecutor.ExecuteEpmLiveNonQuery(R_QUERY, new Dictionary<string, object>
                        {
                            {"@Id", pair.Key},
                            {"@Order", pair.Value}
                        });
                    }
                }
            }

            CleareCache();
        }

        // Private Methods (1) 

        private void CleareCache()
        {
            string postfix = SiteId + "_U_" + UserId;

            CacheStore.Current.Remove("NavLinks_Favorites_S_" + postfix, CacheStoreCategory.Navigation);
            CacheStore.Current.Remove("NavLinks_Workspaces_S_" + postfix, CacheStoreCategory.Navigation);
            CacheStore.Current.Remove("NavLinks_RecentItems_S_" + postfix, CacheStoreCategory.Navigation);
        }

        #endregion Methods 

        #region Overrides of NavLinkProvider

        public override IEnumerable<INavObject> GetLinks()
        {
            throw new Exception("Generic Link Provider does not support this operation.");
        }

        #endregion
    }
}