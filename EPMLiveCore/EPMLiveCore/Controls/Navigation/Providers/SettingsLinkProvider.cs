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
        #region Fields (1) 

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

        #region Implementation of INavLinkProvider

        public override IEnumerable<INavObject> GetLinks()
        {
            foreach (var link in _links)
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

        private IEnumerable<INavObject> GetSettings()
        {
            string key = SPWeb.ID + "_NavLinks_" + "Settings";

            return (IEnumerable<INavObject>) CacheStore.Current.Get(key, "Navigation", () =>
            {
                var links = new List<NavLink>();

                SPSecurity.RunWithElevatedPrivileges(() =>
                {
                    using (var spSite = new SPSite(SPWeb.Site.ID))
                    {
                        using (SPWeb spWeb = spSite.OpenWeb(SPWeb.ID))
                        {
                            SPList settingsList = spWeb.Lists.TryGetList("EPM Live Settings");

                            if (settingsList == null) return;

                            DataTable settings = settingsList.Items.GetDataTable();

                            links.AddRange(from DataRow dataRow in settings.Rows
                                let category = (S(dataRow["Category"]).Split(')')[1]).Trim()
                                select new NavLink
                                {
                                    Title = S(dataRow["Title"]),
                                    Url = S(dataRow["URL"]) + "?Source={page}&BackTo={page}",
                                    Category = category
                                });
                        }
                    }
                });

                return links;
            }).Value;
        }

        private string S(object o)
        {
            return (o ?? string.Empty).ToString();
        }

        #endregion
    }
}