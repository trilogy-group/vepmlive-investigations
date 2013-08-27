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
    [NavLinkProviderInfo(Name = "Favorites")]
    public class FavoritesLinkProvider : NavLinkProvider
    {
        #region Constructors (1) 

        public FavoritesLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username) { }

        #endregion Constructors 

        private const string QUERY = @"SELECT FRF_ID AS LinkId, LIST_ID AS ListId, ITEM_ID AS ItemId,
                               Title, Icon AS CssClass, F_String AS Url FROM dbo.FRF
                               WHERE (SITE_ID = @SiteId) AND (WEB_ID = @WebId) AND (USER_ID = @UserId) AND (Type = 1)
                               ORDER BY F_Int";

        #region Overrides of NavLinkProvider

        public override IEnumerable<INavObject> GetLinks()
        {
            string key = SiteId + "_NavLinks_" + "Favorites" + "_" + UserId;
            return (IEnumerable<INavObject>) CacheStore.Current.Get(key, CacheStoreCategory.Navigation, () =>
            {
                var links = new List<NavLink>
                {
                    new NavLink
                    {
                        Title = "Favorites",
                        Url = "Header"
                    }
                };

                DataTable dataTable;

                using (var spSite = new SPSite(SiteId, GetUserToken()))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(WebId))
                    {
                        var queryExecutor = new QueryExecutor(spWeb);
                        dataTable = queryExecutor.ExecuteEpmLiveQuery(QUERY,
                            new Dictionary<string, object>
                            {
                                {"@SiteId", SiteId},
                                {"@WebId", WebId},
                                {"@UserId", spWeb.CurrentUser.ID}
                            });
                    }
                }

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

                return links;
            }).Value;
        }

        #endregion
    }
}