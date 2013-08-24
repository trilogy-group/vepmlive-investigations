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
        #region Fields (3) 

        private const string QUERY = @"<OrderBy><FieldRef Name='Category' /><FieldRef Name='Title' /></OrderBy>";

        private const string VIEW_FIELDS =
            @"<FieldRef Name='Title' /><FieldRef Name='Category' /><FieldRef Name='Description' />";

        private readonly List<Tuple<SPBasePermissions?, NavLink>> _links;

        #endregion Fields 

        #region Constructors (1) 

        public SettingsLinkProvider(SPWeb spWeb) : base(spWeb)
        {
            string url = SPWeb.ServerRelativeUrl;

            _links = new List<Tuple<SPBasePermissions?, NavLink>>
            {
                new Tuple<SPBasePermissions?, NavLink>(SPBasePermissions.AddAndCustomizePages, new NavLink
                {
                    Title = "Edit Page",
                    Url = "javascript:ChangeLayoutMode(false);"
                }),
                new Tuple<SPBasePermissions?, NavLink>(SPBasePermissions.AddAndCustomizePages, new NavLink
                {
                    Title = "Add a page",
                    Url =
                        string.Format("javascript:OpenCreateWebPageDialog('{0}/_layouts/15/createwebpage.aspx');", url)
                }),
                new Tuple<SPBasePermissions?, NavLink>(null, new NavLink
                {
                    Title = "Site contents",
                    Url = string.Format("{0}/_layouts/15/viewlsts.aspx", url)
                }),
                new Tuple<SPBasePermissions?, NavLink>(null, new NavLink
                {
                    Title = "Advance site settings",
                    Url = string.Format("javascript:GoToPage('{0}/_layouts/15/epmlive/settings.aspx');", url)
                }),
                new Tuple<SPBasePermissions?, NavLink>(null, new NavLink {Separator = true})
            };
        }

        #endregion Constructors 

        #region Methods (2) 

        // Private Methods (2) 

        private IEnumerable<INavObject> GetSettings()
        {
            string key = SPWeb.ID + "_NavLinks_" + "Settings";
            SPUserToken userToken = SPWeb.GetUserToken(SPWeb.CurrentUser.LoginName);

            return (IEnumerable<INavObject>) CacheStore.Current.Get(key, CacheStoreCategory.Navigation, () =>
            {
                var links = new List<NavLink>();

                using (var spSite = new SPSite(SPWeb.Site.ID, userToken))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(SPWeb.ID))
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

                            links.AddRange(from DataRow dataRow in settings.Rows
                                let category = (S(dataRow["Category"]).Split(')')[1]).Trim()
                                select new NavLink
                                {
                                    Title = S(dataRow["Title"]),
                                    Url = webUrl + S(dataRow["URL"]) + "?Source={page}&BackTo={page}",
                                    Category = category
                                });
                        }
                    }
                }

                return links;
            }).Value;
        }

        private string S(object o)
        {
            return (o ?? string.Empty).ToString();
        }

        #endregion Methods 

        #region Implementation of INavLinkProvider

        public override IEnumerable<INavObject> GetLinks()
        {
            foreach (var link in _links.OrderBy(l => l.Item2.Title))
            {
                if (!link.Item1.HasValue)
                {
                    yield return link.Item2;
                }
                else
                {
                    if (SPWeb.DoesUserHavePermissions(link.Item1.Value))
                    {
                        yield return link.Item2;
                    }
                }
            }

            foreach (INavObject link in GetSettings()) yield return link;
        }

        #endregion
    }
}