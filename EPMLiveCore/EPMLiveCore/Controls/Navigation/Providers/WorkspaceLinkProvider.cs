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
    [NavLinkProviderInfo(Name = "Workspaces")]
    public class WorkspaceLinkProvider : NavLinkProvider
    {
        #region Fields (1) 

        private const string CREATE_WORKSPACE_URL =
            @"javascript:var options = {{url: '{0}/_layouts/15/epmlive/QueueCreateWorkspace.aspx', width: 880, height:500}}; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);";

        #endregion Fields 

        #region Constructors (1) 

        public WorkspaceLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username) { }

        #endregion Constructors 

        private const string F_QUERY = @"SELECT FRF_ID AS LinkId, Title, Icon AS CssClass, F_String AS Url,
                                         SITE_ID AS SiteId, WEB_ID AS WebId, F_Int AS Position FROM dbo.FRF
                                         WHERE (USER_ID = @UserId) AND (Type = 4) ORDER BY Position, Title";

        #region Overrides of NavLinkProvider

        public override IEnumerable<INavObject> GetLinks()
        {
            string key = "NavLinks_Workspaces_S_" + SiteId + "_U_" + UserId;

            return (IEnumerable<INavObject>) CacheStore.Current.Get(key, CacheStoreCategory.Navigation, () =>
            {
                var links = new List<NavLink>
                {
                    new NavLink
                    {
                        Title = "Workspaces",
                        Url = "Header"
                    },
                    new NavLink
                    {
                        Title = "New Workspace",
                        Url = string.Format(CREATE_WORKSPACE_URL, RelativeUrl),
                        CssClass = "epm-nav-button fui-ext-workspace"
                    }
                };

                links.AddRange(GetFavoriteWorkspaces());

                return links;
            }).Value;
        }

        private IEnumerable<NavLink> GetFavoriteWorkspaces()
        {
            yield return new NavLink
            {
                Title = "Favorite Workspaces",
                Url = "Header"
            };

            DataTable dataTable;

            using (var spSite = new SPSite(SiteId, GetUserToken()))
            {
                using (SPWeb spWeb = spSite.OpenWeb(WebId))
                {
                    var queryExecutor = new QueryExecutor(spWeb);
                    dataTable = queryExecutor.ExecuteEpmLiveQuery(F_QUERY,
                        new Dictionary<string, object>
                        {
                            {"@UserId", spWeb.CurrentUser.ID}
                        });
                }
            }

            if (dataTable.Rows.Count > 0)
            {
                foreach (SPNavLink navLink in from DataRow row in dataTable.Rows
                    select new SPNavLink
                    {
                        Id = S(row["LinkId"]),
                        Title = S(row["Title"]),
                        Url = S(row["Url"]),
                        CssClass = "epm-nav-sortable " + S(row["CssClass"]),
                        SiteId = S(SiteId),
                        WebId = S(WebId)
                    })
                {
                    yield return navLink;
                }
            }
            else
            {
                yield return new NavLink
                {
                    Title = "No favorite workspace",
                    Url = "PlaceHolder"
                };
            }
        }

        #endregion
    }
}