using System;
using System.Collections.Generic;
using System.Linq;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    [NavLinkProviderInfo(Name = "MyWorkplace")]
    public class WorkplaceLinkProvider : NavLinkProvider
    {
        #region Fields (1) 

        private readonly string _key;

        #endregion Fields 

        #region Constructors (1) 

        public WorkplaceLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username)
        {
            _key = "NavLinks_MyWorkplace_W_" + WebId + "_U_" + UserId;
        }

        #endregion Constructors 

        #region Methods (3) 

        // Private Methods (3) 

        private string CalculateUrl(SPNavigationNode node, bool isRootWeb)
        {
            var url = node.Url;

            if (node.Title.Equals("My Work"))
            {
                url = RelativeUrl + "/_layouts/15/epmlive/MyWork.aspx";
            }
            else if (node.Title.ToLower().Contains("timesheet"))
            {
                url = RelativeUrl + "/_layouts/15/epmlive/MyTimesheet.aspx";
            }

            if (isRootWeb) return url;

            if (url.ToLower().Contains("_layouts"))
            {
                string[] parts = url.Split(new[] {"_layouts"}, StringSplitOptions.None);
                url = RelativeUrl + "/_layouts" + string.Join(string.Empty, parts.Skip(1));
            }
            else
            {
                url = string.Format(@"javascript:SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.showModalDialog', {{ url: '{0}', showMaximized: true }});", url);
            }

            return url;
        }

        private IEnumerable<INavObject> GetMyWorkplaceLinks()
        {
            return (IEnumerable<INavObject>) CacheStore.Current.Get(_key, new CacheStoreCategory(Web).Navigation, () =>
            {
                var links = new List<NavLink>
                {
                    new NavLink
                    {
                        Title = "My Workplace",
                        Url = "Header"
                    }
                };

                var wpLinks = new List<NavLink>();

                using (var spSite = new SPSite(SiteId, GetUserToken()))
                {
                    using (SPWeb spWeb = spSite.OpenWeb())
                    {
                        try
                        {
                            bool isRootWeb = spWeb.ID == WebId;
                            SPNavigation spNavigation = spWeb.Navigation;

                            wpLinks.AddRange(from nodeId in GetNodes(spWeb)
                                select spNavigation.GetNodeById(nodeId)
                                into node
                                where node != null
                                select new NavLink
                                {
                                    Title = node.Title,
                                    Url = CalculateUrl(node, isRootWeb)
                                });
                        }
                        catch { }
                    }
                }

                if (wpLinks.Count > 0)
                {
                    links.AddRange(wpLinks);
                }
                else
                {
                    links.Add(new NavLink
                    {
                        Title = "No workplace",
                        Url = "PlaceHolder"
                    });
                }

                return links;
            }).Value;
        }

        private static IEnumerable<int> GetNodes(SPWeb spWeb)
        {
            SPList installedAppsList = null;

            try
            {
                installedAppsList = spWeb.Lists["Installed Applications"];
            }
            catch { }

            if (installedAppsList == null) yield break;

            var query = new SPQuery
            {
                Query =
                    @"<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>Global My Workplace</Value></Eq></Where>",
                ViewFields = @"<FieldRef Name='QuickLaunch' />"
            };

            SPListItemCollection communities = installedAppsList.GetItems(query);

            if (communities.Count <= 0) yield break;

            SPListItem workplace = communities[0];
            var ql = (string) (workplace["QuickLaunch"] ?? string.Empty);

            var nodes = new List<int>();

            foreach (string id in ql.Split(',').Where(id => !string.IsNullOrEmpty(id)))
            {
                int nodeId;
                if (int.TryParse(id.Split(':')[0], out nodeId))
                {
                    nodes.Add(nodeId);
                }
            }

            int totalNodes = nodes.Count;
            var processed = 0;

            foreach (SPNavigationNode node in spWeb.Navigation.QuickLaunch)
            {
                if (processed == totalNodes) yield break;
                if (!nodes.Contains(node.Id)) continue;

                processed++;
                yield return node.Id;
            }
        }

        #endregion Methods 

        #region Overrides of NavLinkProvider

        protected override string Key
        {
            get { return _key; }
        }

        public override IEnumerable<INavObject> GetLinks()
        {
            return GetMyWorkplaceLinks();
        }

        #endregion
    }
}