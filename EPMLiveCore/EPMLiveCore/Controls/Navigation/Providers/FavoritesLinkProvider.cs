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
        #region Fields (1) 

        private readonly string _key;

        #endregion Fields 

        #region Constructors (1) 

        public FavoritesLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username)
        {
            _key = "NavLinks_Favorites_S_" + SiteId + "_U_" + UserId;
        }

        #endregion Constructors 

        #region Properties (1) 

        protected override string Key
        {
            get { return _key; }
        }

        #endregion Properties 

        #region Methods (2) 

        // Public Methods (1) 

        public override IEnumerable<INavObject> GetLinks()
        {
            return (IEnumerable<INavObject>) CacheStore.Current.Get(_key, CacheStoreCategory.Navigation, () =>
            {
                var links = new List<NavLink>
                {
                    new NavLink
                    {
                        Title = "Favorites",
                        Url = "Header"
                    }
                };

                DataTable dataTable = null;

                using (var spSite = new SPSite(SiteId, GetUserToken()))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(WebId))
                    {
                        try
                        {
                            var queryExecutor = new QueryExecutor(spWeb);
                            dataTable = queryExecutor.ExecuteEpmLiveQuery(QUERY,
                                new Dictionary<string, object>
                                {
                                    {"@SiteId", SiteId},
                                    {"@UserId", spWeb.CurrentUser.ID}
                                });
                        }
                        catch { }
                    }
                }

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    var pages = new List<DataRow>();
                    var items = new List<DataRow>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (string.IsNullOrEmpty(S(row["ItemId"])))
                        {
                            pages.Add(row);
                        }
                        else
                        {
                            items.Add(row);
                        }
                    }

                    links.Add(new NavLink {Title = "Pages", Url = "Header"});

                    if (pages.Any())
                    {
                        links.AddRange(pages.Select(GetNavLink));
                    }
                    else
                    {
                        links.Add(new NavLink
                        {
                            Title = "No pages",
                            Url = "PlaceHolder"
                        });
                    }

                    links.Add(new NavLink {Title = "Items", Url = "Header"});

                    if (items.Any())
                    {
                        links.AddRange(items.Select(GetNavLink));
                    }
                    else
                    {
                        links.Add(new NavLink
                        {
                            Title = "No items",
                            Url = "PlaceHolder"
                        });
                    }
                }
                else
                {
                    links.Add(new NavLink
                    {
                        Title = "No favorites",
                        Url = "PlaceHolder"
                    });
                }

                return links;
            }).Value;
        }

        // Private Methods (1) 

        private SPNavLink GetNavLink(DataRow row)
        {
            string linkUrl = S(row["Url"]);
            string itemId = S(row["ItemId"]);
            string webId = S(WebId);
            string listId = S(row["ListId"]);

            if (!string.IsNullOrEmpty(itemId))
            {
                linkUrl =
                    string.Format(
                        @"javascript:OpenCreateWebPageDialog('{0}/_layouts/15/epmlive/redirectionproxy.aspx?action=view&webid={1}&listid={2}&id={3}');",
                        RelativeUrl, webId, listId, itemId);
            }

            var link = new SPNavLink
            {
                Id = S(row["LinkId"]),
                Title = S(row["Title"]),
                Url = linkUrl,
                CssClass = "epm-nav-sortable " + S(row["CssClass"]),
                SiteId = S(SiteId),
                WebId = webId,
                ListId = listId,
                ItemId = itemId
            };

            return link;
        }

        #endregion Methods 

        private const string QUERY = @"SELECT FRF_ID AS LinkId, LIST_ID AS ListId, ITEM_ID AS ItemId,
                               Title, Icon AS CssClass, F_String AS Url FROM dbo.FRF
                               WHERE (SITE_ID = @SiteId) AND (USER_ID = @UserId) AND (Type = 1)
                               ORDER BY F_Int";
    }
}