﻿using System;
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

        #region Methods (1) 

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
                                {"@UserId", spWeb.CurrentUser.ID}
                            });
                    }
                }

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    links.AddRange(from DataRow row in dataTable.Rows
                        select new SPNavLink
                        {
                            Id = S(row["LinkId"]),
                            Title = S(row["Title"]),
                            Url = S(row["Url"]),
                            CssClass = "epm-nav-sortable " + S(row["CssClass"]),
                            SiteId = S(SiteId),
                            WebId = S(WebId),
                            ListId = S(row["ListId"]),
                            ItemId = S(row["ItemId"])
                        });
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

        #endregion Methods 

        private const string QUERY = @"SELECT FRF_ID AS LinkId, LIST_ID AS ListId, ITEM_ID AS ItemId,
                               Title, Icon AS CssClass, F_String AS Url FROM dbo.FRF
                               WHERE (SITE_ID = @SiteId) AND (USER_ID = @UserId) AND (Type = 1)
                               ORDER BY F_Int";
    }
}