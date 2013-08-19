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
        private readonly List<Tuple<SPBasePermissions?, NavLink>> _links;

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
            string key = SPWeb.ID + "_" + "Settings";

            IEnumerable<INavObject> settings;
            CachedValue cachedSettings = CacheStore.Current.Get(key);

            if (cachedSettings != null)
            {
                settings = (IEnumerable<INavObject>) cachedSettings.Value;
            }
            else
            {
                settings = FetchSettings();
                CacheStore.Current.Set(key, settings);
            }

            return settings;
        }

        private IEnumerable<INavObject> FetchSettings()
        {
            SPList settingsList = SPWeb.Lists.TryGetList("EPM Live Settings");

            if (settingsList == null) yield break;

            DataTable settings = settingsList.Items.GetDataTable();

            foreach (NavLink link in from DataRow dataRow in settings.Rows
                let category = (S(dataRow["Category"]).Split(')')[1]).Trim()
                select new NavLink
                {
                    Title = S(dataRow["Title"]),
                    Url = S(dataRow["URL"]),
                    Category = category
                })
            {
                yield return link;
            }
        }

        private string S(object o)
        {
            return (o ?? string.Empty).ToString();
        }

        #endregion
    }
}