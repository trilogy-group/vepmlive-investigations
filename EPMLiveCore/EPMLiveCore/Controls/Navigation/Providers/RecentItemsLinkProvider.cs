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
    [NavLinkProviderInfo(Name = "RecentItems")]
    public class RecentItemsLinkProvider : NavLinkProvider
    {
        #region Constructors (1) 

        public RecentItemsLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username) { }

        #endregion Constructors 

        private const string RI_QUERY = @"SELECT TOP (30) FRF_ID AS LinkId, LIST_ID AS ListId, ITEM_ID AS ItemId,
                                        Title, Icon AS CssClass, F_String AS Url FROM dbo.FRF
                                        WHERE (SITE_ID = @SiteId) AND (WEB_ID = @WebId) AND (USER_ID = @UserId) AND (Type = 2)
                                        ORDER BY F_Date DESC";

        private const string FA_QUERY = @"SELECT TOP (5) FRF_ID AS LinkId, LIST_ID AS ListId, ITEM_ID AS ItemId, Title, 
                                        Icon AS CssClass, F_String AS Url FROM dbo.FRF 
                                        WHERE (SITE_ID = @SiteId) AND (WEB_ID = @WebId) AND (USER_ID = @UserId) AND (Type = 3)
                                        ORDER BY F_Int DESC, Title";

        #region Overrides of NavLinkProvider

        public override IEnumerable<INavObject> GetLinks()
        {
            string key = SiteId + "_NavLinks_" + "RecentItems" + "_" + UserId;
            return (IEnumerable<INavObject>) CacheStore.Current.Get(key, CacheStoreCategory.Navigation, () =>
            {
                List<NavLink> links = GetFrequentApps();
                links.AddRange(GetRecentItems());

                return links;
            }).Value;
        }

        private List<NavLink> GetFrequentApps()
        {
            var links = new List<NavLink>
            {
                new NavLink
                {
                    Title = "Frequent Apps",
                    Url = "Header"
                }
            };

            DataTable dataTable = GetData(FA_QUERY);
            GetLinks(dataTable, links);

            return links;
        }

        private IEnumerable<NavLink> GetRecentItems()
        {
            var links = new List<NavLink>
            {
                new NavLink
                {
                    Title = "Recent Items",
                    Url = "Header"
                }
            };

            DataTable dataTable = GetData(RI_QUERY);
            GetLinks(dataTable, links);

            return links;
        }

        private void GetLinks(DataTable dataTable, List<NavLink> links)
        {
            if (dataTable != null)
            {
                links.AddRange(from DataRow row in dataTable.Rows
                    select new SPNavLink
                    {
                        Id = S(row["LinkId"]),
                        Title = S(row["Title"]),
                        Url = S(row["Url"]),
                        CssClass = S(row["CssClass"]),
                        SiteId = S(SiteId),
                        WebId = S(WebId),
                        ListId = S(row["ListId"]),
                        ItemId = S(row["ItemId"])
                    });
            }
        }

        private DataTable GetData(string query)
        {
            DataTable dataTable;

            using (var spSite = new SPSite(SiteId, GetUserToken()))
            {
                using (SPWeb spWeb = spSite.OpenWeb(WebId))
                {
                    var queryExecutor = new QueryExecutor(spWeb);
                    dataTable = queryExecutor.ExecuteEpmLiveQuery(query,
                        new Dictionary<string, object>
                        {
                            {"@SiteId", SiteId},
                            {"@WebId", WebId},
                            {"@UserId", spWeb.CurrentUser.ID}
                        });
                }
            }

            return dataTable;
        }

        #endregion
    }
}