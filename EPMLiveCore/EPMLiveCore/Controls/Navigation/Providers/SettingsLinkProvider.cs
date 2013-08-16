using System;
using System.Collections.Generic;
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
                    Url = string.Format("javascript:OpenCreateWebPageDialog('{0}/_layouts/15/createwebpage.aspx');", url)
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
                })
            };
        }

        #region Implementation of INavLinkProvider

        public override IEnumerable<INavObject> GetLinks()
        {
            foreach (Tuple<SPBasePermissions?, NavLink> link in _links)
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
        }

        #endregion
    }
}