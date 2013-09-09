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
        #region Fields (2) 

        private const string CREATE_WORKSPACE_URL =
            @"javascript:var options = {{url: '{0}/_layouts/15/epmlive/QueueCreateWorkspace.aspx', width: 880, height:500}}; SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);";

        private readonly string _key;

        #endregion Fields 

        #region Constructors (1) 

        public WorkspaceLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username)
        {
            _key = "NavLinks_Workspaces_S_" + SiteId + "_U_" + UserId;
        }

        #endregion Constructors 

        private const string F_QUERY = @"SELECT FRF_ID AS LinkId, Title, Icon AS CssClass, F_String AS Url,
                                         SITE_ID AS SiteId, WEB_ID AS WebId, F_Int AS Position FROM dbo.FRF
                                         WHERE (SITE_ID = @SiteId) AND (USER_ID = @UserId) AND (Type = 4) ORDER BY Position, Title";

        #region Overrides of NavLinkProvider

        protected override string Key
        {
            get { return _key; }
        }

        public override IEnumerable<INavObject> GetLinks()
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
                    CssClass = "epm-nav-button"
                }
            };

            var fLinks = (IEnumerable<INavObject>) CacheStore.Current.Get(_key, CacheStoreCategory.Navigation, () =>
            {
                var navLinks = new List<NavLink>();

                navLinks.AddRange(GetFavoriteWorkspaces());
                navLinks.AddRange(GetAllWorkspaces());

                return navLinks;
            }).Value;

            links.AddRange(fLinks.Cast<NavLink>());

            return links;
        }

        private IEnumerable<NavLink> GetAllWorkspaces()
        {
            yield return new NavLink
            {
                Title = "All Workspaces",
                Url = "Header"
            };

            DataTable dataTable;

            using (var spSite = new SPSite(SiteId, GetUserToken()))
            {
                using (SPWeb spWeb = spSite.OpenWeb(WebId))
                {
                    var queryExecutor = new QueryExecutor(spWeb);
                    dataTable = queryExecutor.ExecuteReportingDBStoredProc("spGetWebs", new Dictionary<string, object>
                    {
                        {"@SiteId", SiteId},
                        {"@UserId", spWeb.CurrentUser.ID}
                    });
                }
            }

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                EnumerableRowCollection<DataRow> rows = dataTable.AsEnumerable();

                SPNavLink rootWebLink = GetRootWebLink(rows);
                yield return rootWebLink;

                foreach (SPNavLink navLink in GetChildWebs(rows, rootWebLink.WebId))
                {
                    yield return navLink;
                }
            }
            else
            {
                yield return new NavLink
                {
                    Title = "No workspace",
                    Url = "PlaceHolder"
                };
            }
        }

        private IEnumerable<SPNavLink> GetChildWebs(EnumerableRowCollection<DataRow> rows, string webId)
        {
            EnumerableRowCollection<DataRow> childWebs = from r in rows
                where S(r["ParentWebId"]).Equals(S(webId))
                select r;

            foreach (DataRow childWeb in childWebs)
            {
                string cWebId = S(childWeb["WebId"]);

                yield return new SPNavLink
                {
                    Id = cWebId,
                    Title = S(childWeb["WebTitle"]),
                    Url = S(childWeb["WebUrl"]),
                    SiteId = S(SiteId),
                    WebId = cWebId,
                    Active = S(childWeb["HasAccess"]).Equals("1"),
                    Category = S(webId)
                };

                foreach (SPNavLink navLink in GetChildWebs(rows, cWebId))
                {
                    yield return navLink;
                }
            }
        }

        private SPNavLink GetRootWebLink(EnumerableRowCollection<DataRow> rows)
        {
            DataRow rootWeb = (from r in rows
                where r["ParentWebId"] == null ||
                      r["ParentWebId"] == DBNull.Value ||
                      G(r["ParentWebId"]) == Guid.Empty
                select r).First();

            string webId = S(rootWeb["WebId"]);

            return new SPNavLink
            {
                Id = webId,
                Title = S(rootWeb["WebTitle"]),
                Url = S(rootWeb["WebUrl"]),
                SiteId = S(SiteId),
                WebId = webId,
                Active = S(rootWeb["HasAccess"]).Equals("1")
            };
        }

        private Guid G(object value)
        {
            Guid guid;
            Guid.TryParse(S(value), out guid);

            return guid;
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
                            {"@SiteId", SiteId},
                            {"@UserId", spWeb.CurrentUser.ID}
                        });
                }
            }

            if (dataTable != null && dataTable.Rows.Count > 0)
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