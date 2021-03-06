﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EPMLiveCore.API.ProjectArchiver;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using DataTable = System.Data.DataTable;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    [NavLinkProviderInfo(Name = "Workspaces")]
    public class WorkspaceLinkProvider : NavLinkProvider
    {
        #region Fields (2) 

        private const string CREATE_WORKSPACE_URL =
            @"javascript:var options = {{
                    url: '{0}/_layouts/15/epmlive/QueueCreateWorkspace.aspx', 
                    dialogReturnValueCallback: function(dialogResult, returnValue){{ 
                        if (dialogResult === 1){{ 
                            toastr.options = {{
                                'private closeButton': false,
                                'debug': false,
                                'positionClass': 'toast-top-right',
                                'onclick': null,
                                'showDuration': '300',
                                'hideDuration': '1000',
                                'timeOut': '5000',
                                'extendedTimeOut': '1000',
                                'showEasing': 'swing',
                                'hideEasing': 'linear',
                                'showMethod': 'fadeIn',
                                'hideMethod': 'fadeOut'
                            }} ;

                            toastr.info('Your workspace is being created - we will notify you when it is ready.');
                        }}
                    }} 
                }}; 
                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', options);";

        private readonly string _key;

        #endregion Fields 

        #region Constructors (1) 

        public WorkspaceLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username)
        {
            _key = "NavLinks_Workspaces_S_" + SiteId + "_U_" + UserId;
        }

        #endregion Constructors 

        #region Methods (5) 

        // Private Methods (5) 

        private Guid G(object value)
        {
            Guid guid;
            Guid.TryParse(S(value), out guid);

            return guid;
        }

        private IEnumerable<SPNavLink> GetAllWorkspaces()
        {
            yield return new SPNavLink
            {
                Title = "All Workspaces",
                Url = "Header"
            };

            DataTable dataTable = null;

            using (var spSite = new SPSite(SiteId, GetUserToken()))
            {
                using (SPWeb spWeb = spSite.OpenWeb(WebId))
                {
                    try
                    {
                        var queryExecutor = new QueryExecutor(spWeb);
                        dataTable = queryExecutor.ExecuteReportingDBStoredProc("spGetWebs",
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
                DataView defaultView = dataTable.DefaultView;
                defaultView.Sort = "WebTitle";

                EnumerableRowCollection<DataRow> rows = defaultView.ToTable().AsEnumerable();

                SPNavLink rootWebLink = GetRootWebLink(rows);
                yield return rootWebLink;

                SPSite spSite = null;

                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    spSite = new SPSite(SiteId);
                });

                if (spSite == null) yield break;

                foreach (SPNavLink navLink in GetChildWebs(rows, rootWebLink.WebId, spSite))
                {
                    yield return navLink;
                }

                spSite.Dispose();
            }
            else
            {
                yield return new SPNavLink
                {
                    Title = "No workspace",
                    Url = "PlaceHolder"
                };
            }
        }

        private IEnumerable<SPNavLink> GetChildWebs(EnumerableRowCollection<DataRow> rows, string webId, SPSite spSite)
        {
            EnumerableRowCollection<DataRow> childWebs = from r in rows
                where S(r["ParentWebId"]).Equals(S(webId))
                select r;

            foreach (DataRow childWeb in childWebs)
            {
                var proceed = true;

                string cWebId = S(childWeb["WebId"]);
                var hasAccess = S(childWeb["HasAccess"]);

                if (!hasAccess.Equals("1"))
                {
                    if (!(from r in rows where S(r["ParentWebId"]).Equals(cWebId) && S(r["HasAccess"]).Equals("1") select r).Any())
                    {
                        proceed = false;
                    }
                }

                if (!proceed) continue;

                string itemId = string.Empty;

                string cItemId = S(childWeb["ItemId"]);
                if (!string.IsNullOrEmpty(cItemId) && !cItemId.Equals("-1"))
                {
                    itemId = S(childWeb["ItemWebId"]) + "." + S(childWeb["ItemListId"]) + "." + cItemId;
                }

                var archived = IsArchived(spSite.ID, S(childWeb["ItemWebId"]), S(childWeb["ItemListId"]), cItemId);

                if (hasAccess.Equals("1"))
                {
                    try
                    {
                        if (string.IsNullOrEmpty(itemId))
                        {
                            using (SPWeb spWeb = spSite.OpenWeb(new Guid(cWebId)))
                            {
                                if (spWeb.Features[WEFeatures.BuildTeam.Id] == null)
                                {
                                    itemId = "X";
                                }
                            }

                        }
                    }
                    catch { }
                }

                yield return new SPNavLink
                {
                    Id = cWebId,
                    Title = S(childWeb["WebTitle"]),
                    Url = S(childWeb["WebUrl"]),
                    SiteId = S(SiteId),
                    WebId = cWebId,
                    Active = hasAccess.Equals("1"),
                    Archived = archived,
                    Category = S(webId),
                    ItemId = itemId
                };

                foreach (SPNavLink navLink in GetChildWebs(rows, cWebId, spSite))
                {
                    yield return navLink;
                }
            }
        }

        private bool IsArchived(Guid siteId, string webIdString, string listIdString, string itemIdString)
        {
            // return false in all cases when ids are invalid (can be null or empty or "-1")
            if (string.IsNullOrWhiteSpace(webIdString) || string.IsNullOrWhiteSpace(listIdString) || string.IsNullOrWhiteSpace(itemIdString))
            {
                return false;
            }

            Guid webId;
            Guid listId;
            int itemId;

            try
            {
                webId = new Guid(webIdString);
                listId = new Guid(listIdString);
                itemId = Convert.ToInt32(itemIdString);
            }
            catch
            {
                return false;
            }

            if (siteId == Guid.Empty || webId == Guid.Empty || listId == Guid.Empty || itemId <= 0)
            {
                return false;
            }

            // done with id validation - check archived status
            var archiverService = new ProjectArchiverService();
            return archiverService.IsArchived(siteId, webId, listId, itemId);
        }

        private IEnumerable<NavLink> GetFavoriteWorkspaces(List<SPNavLink> allWorkspaces)
        {
            yield return new NavLink
            {
                Title = "Favorite Workspaces",
                Url = "Header"
            };

            DataTable dataTable = null;

            using (var spSite = new SPSite(SiteId, GetUserToken()))
            {
                using (SPWeb spWeb = spSite.OpenWeb(WebId))
                {
                    try
                    {
                        var queryExecutor = new QueryExecutor(spWeb);
                        dataTable = queryExecutor.ExecuteEpmLiveQuery(F_QUERY,
                            new Dictionary<string, object>
                            {
                                {"@SiteId", SiteId},
                                {"@UserId", spWeb.CurrentUser.ID}
                            });
                    }
                    catch { }
                }
            }

            var wsFound = false;

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    string webId = S(row["WebId"]);

                    SPNavLink navLink = allWorkspaces.FirstOrDefault(w => (w.WebId ?? string.Empty).Equals(webId));

                    if (navLink == null) continue;

                    wsFound = true;

                    yield return new SPNavLink
                    {
                        Id = S(row["LinkId"]),
                        Title = S(row["Title"]),
                        Url = S(row["Url"]),
                        CssClass = "epm-nav-sortable " + S(row["CssClass"]),
                        SiteId = S(row["SiteId"]),
                        WebId = webId,
                        ItemId = navLink.ItemId
                    };
                }
            }

            if (!wsFound)
            {
                yield return new NavLink
                {
                    Title = "No favorite workspaces",
                    Url = "PlaceHolder"
                };
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

        #endregion Methods 

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
                }
            };

            using (var spSite = new SPSite(SiteId, GetUserToken()))
            {
                using (SPWeb spWeb = spSite.OpenWeb(WebId))
                {
                    if (spWeb.DoesUserHavePermissions(SPBasePermissions.ManageSubwebs))
                    {
                        links.Add(new NavLink
                        {
                            Title = "New Workspace",
                            Url = string.Format(CREATE_WORKSPACE_URL, (RelativeUrl == "/" ? "" : RelativeUrl)),
                            CssClass = "epm-nav-button"
                        });
                    }
                }
            }

            var fLinks = (IEnumerable<INavObject>) CacheStore.Current.Get(_key, new CacheStoreCategory(Web).Navigation, () =>
            {
                var allWorkspaces = GetAllWorkspaces().Where(x => !x.Archived).ToList();
                var favoriteWorkspaces = GetFavoriteWorkspaces(allWorkspaces).ToList();
                var navLinks = new List<NavLink>();

                navLinks.AddRange(favoriteWorkspaces);
                navLinks.AddRange(allWorkspaces);

                return navLinks;
            }).Value;

            links.AddRange(fLinks.Cast<NavLink>());

            return links;
        }

        #endregion
    }
}