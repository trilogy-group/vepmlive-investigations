using System;
using System.Collections.Generic;
using System.Data;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    [NavLinkProviderInfo(Name = "RecentItems")]
    public class RecentItemsLinkProvider : NavLinkProvider
    {
        #region Fields (1) 

        private readonly string _key;

        #endregion Fields 

        #region Constructors (1) 

        public RecentItemsLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username)
        {
            _key = "NavLinks_RecentItems_S_" + SiteId + "_U_" + UserId;
        }

        #endregion Constructors 

        private const string RI_QUERY =
            @"SELECT TOP (30) FRF_ID AS LinkId, WEB_ID AD WebId, LIST_ID AS ListId, ITEM_ID AS ItemId,
                                        Title, Icon AS CssClass FROM dbo.FRF
                                        WHERE (SITE_ID = @SiteId) AND (USER_ID = @UserId) AND (Type = 2)
                                        ORDER BY F_Date DESC";

        private const string FA_QUERY = @"SELECT TOP (5) FRF_ID AS LinkId, WEB_ID AS WebId, LIST_ID AS ListId, Title,
                                        Icon AS CssClass FROM dbo.FRF
                                        WHERE (SITE_ID = @SiteId) AND (USER_ID = @UserId) AND (Type = 3)
                                        ORDER BY F_Int DESC, Title";

        #region Overrides of NavLinkProvider

        protected override string Key
        {
            get { return _key; }
        }

        public override IEnumerable<INavObject> GetLinks()
        {
            return (IEnumerable<INavObject>) CacheStore.Current.Get(_key, CacheStoreCategory.Navigation, () =>
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

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                try
                {
                    GetLinks(dataTable, links);
                }
                catch { }
            }
            else
            {
                links.Add(new NavLink
                {
                    Title = "No frequent apps",
                    Url = "PlaceHolder"
                });
            }

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

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                try
                {
                    GetLinks(dataTable, links);
                }
                catch { }
            }
            else
            {
                links.Add(new NavLink
                {
                    Title = "No recent items",
                    Url = "PlaceHolder"
                });
            }

            return links;
        }

        private void GetLinks(DataTable dataTable, List<NavLink> links)
        {
            if (dataTable == null || dataTable.Rows.Count == 0) return;

            foreach (DataRow row in dataTable.Rows)
            {
                string itemId = string.Empty;

                try
                {
                    itemId = S(row["ItemId"]);
                }
                catch { }

                string webId = S(WebId);
                string listId = S(row["ListId"]);

                string url =
                    string.Format(
                        @"{0}/_layouts/15/epmlive/redirectionproxy.aspx?action=gotolist&webid={1}&listid={2}&isdlg=0",
                        RelativeUrl, webId, listId);

                if (!string.IsNullOrEmpty(itemId))
                {
                    url =
                        string.Format(
                            @"javascript:OpenCreateWebPageDialog('{0}/_layouts/15/epmlive/redirectionproxy.aspx?action=view&webid={1}&listid={2}&id={3}');",
                            RelativeUrl, webId, listId, itemId);
                }

                var link = new SPNavLink
                {
                    Id = S(row["LinkId"]),
                    Title = S(row["Title"]),
                    Url = url,
                    CssClass = S(row["CssClass"]),
                    SiteId = S(SiteId),
                    WebId = webId,
                    ListId = listId,
                    ItemId = itemId
                };

                links.Add(link);
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
                            {"@UserId", spWeb.CurrentUser.ID}
                        });
                }
            }

            return dataTable;
        }

        #endregion
    }
}