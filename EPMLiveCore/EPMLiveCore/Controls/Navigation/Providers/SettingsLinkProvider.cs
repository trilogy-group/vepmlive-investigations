using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;
using Microsoft.SharePoint;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    [NavLinkProviderInfo(Name = "Settings")]
    public class SettingsLinkProvider : NavLinkProvider
    {
        #region Fields (4) 

        private const string QUERY = @"<OrderBy><FieldRef Name='Category' /><FieldRef Name='Title' /></OrderBy>";

        private const string VIEW_FIELDS =
            @"<FieldRef Name='Title' /><FieldRef Name='URL' /><FieldRef Name='Category' /><FieldRef Name='Description' />";

        private readonly string _key;
        private readonly List<Tuple<SPBasePermissions?, NavLink>> _links;

        #endregion Fields 

        #region Constructors (1) 

        public SettingsLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username)
        {
            _key = "NavLinks_Settings_W_" + WebId;

            _links = new List<Tuple<SPBasePermissions?, NavLink>>
            {
                new Tuple<SPBasePermissions?, NavLink>(null, new NavLink
                {
                    Title = "Settings",
                    Url = "Header"
                }),
                new Tuple<SPBasePermissions?, NavLink>(SPBasePermissions.AddAndCustomizePages, new NavLink
                {
                    Title = "Edit Page",
                    Url = "javascript:ChangeLayoutMode(false);"
                }),
                new Tuple<SPBasePermissions?, NavLink>(SPBasePermissions.AddAndCustomizePages, new NavLink
                {
                    Title = "Add a page",
                    Url =
                        string.Format("javascript:OpenCreateWebPageDialog('{0}/_layouts/15/createwebpage.aspx');",
                            RelativeUrl)
                }),
                new Tuple<SPBasePermissions?, NavLink>(null, new NavLink
                {
                    Title = "Site contents",
                    Url = string.Format("{0}/_layouts/15/viewlsts.aspx", RelativeUrl)
                }),
                new Tuple<SPBasePermissions?, NavLink>(null, new NavLink
                {
                    Title = "SharePoint Site settings",
                    Url = string.Format("javascript:GoToPage('{0}/_layouts/15/settings.aspx');", RelativeUrl)
                }),
                new Tuple<SPBasePermissions?, NavLink>(null, new NavLink {Separator = true})
            };
        }

        #endregion Constructors 

        #region Methods (1) 

        // Private Methods (1) 

        private IEnumerable<INavObject> GetSettings()
        {
            return (IEnumerable<INavObject>) CacheStore.Current.Get(_key, CacheStoreCategory.Navigation, () =>
            {
                var links = new List<NavLink>();

                using (var spSite = new SPSite(SiteId, GetUserToken()))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(WebId))
                    {
                        SPList settingsList = spWeb.Lists.TryGetList("EPM Live Settings");

                        if (settingsList != null)
                        {
                            SPListItemCollectionPosition position;

                            DataTable settings = settingsList.GetDataTable(new SPQuery
                            {
                                Query = QUERY,
                                ViewFields = VIEW_FIELDS
                            }, SPListGetDataTableOptions.None, out position);

                            string webUrl = spWeb.Url;

                            var catLinks = new SortedDictionary<string, List<NavLink>>();

                            foreach (DataRow row in settings.Rows)
                            {
                                string category = (S(row["Category"]).Split(')')[1]).Trim();

                                var link = new NavLink
                                {
                                    Title = S(row["Title"]),
                                    Url = webUrl + S(row["URL"]) + "?Source={page}&BackTo={page}",
                                    Category = category
                                };

                                if (!catLinks.ContainsKey(category))
                                {
                                    catLinks.Add(category, new List<NavLink>());
                                }

                                catLinks[category].Add(link);
                            }

                            links.AddRange(catLinks.SelectMany(p => p.Value.OrderBy(l => l.Title)));
                        }
                    }
                }

                return links;
            }, true).Value;
        }

        #endregion Methods 

        #region Implementation of INavLinkProvider

        protected override string Key
        {
            get { return _key; }
        }

        public override IEnumerable<INavObject> GetLinks()
        {
            var links = new List<NavLink>();

            using (var spSite = new SPSite(SiteId, GetUserToken()))
            {
                using (SPWeb spWeb = spSite.OpenWeb(WebId))
                {
                    foreach (var link in _links)
                    {
                        if (!link.Item1.HasValue)
                        {
                            links.Add(link.Item2);
                        }
                        else
                        {
                            if (spWeb.DoesUserHavePermissions(link.Item1.Value))
                            {
                                links.Add(link.Item2);
                            }
                        }
                    }

                    SPUser user = spWeb.CurrentUser;
                    if (spWeb.DoesUserHavePermissions(SPBasePermissions.ManageWeb) || user.IsSiteAdmin)
                    {
                        links.AddRange(GetSettings().Cast<NavLink>());
                    }
                }
            }

            return links;
        }

        #endregion
    }
}