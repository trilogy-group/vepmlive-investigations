using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;

namespace EPMLiveCore.Controls.Navigation
{
    public class EPMLiveQuickLaunchProvider : SPNavigationProvider
    {
        #region Fields (2) 

        private Dictionary<string, IList<string>> _communityLinks;
        private Dictionary<string, SiteMapNode> _linkNodes;

        #endregion Fields 

        #region Methods (2) 

        // Private Methods (2) 

        private SiteMapNodeCollection FindChildNodes(SiteMapNode node)
        {
            var nodes = new SiteMapNodeCollection();

            PopulateCommunityLinks();

            if (node.Title.Equals("Quick launch"))
            {
                foreach (var community in _communityLinks)
                {
                    nodes.Add(new SiteMapNode(this, community.Key) {Title = community.Key});
                }

                return nodes;
            }

            if (!_communityLinks.ContainsKey(node.Key)) return base.GetChildNodes(node);

            foreach (string nodeKey in _communityLinks[node.Key])
            {
                try
                {
                    nodes.Add(_linkNodes[nodeKey]);
                }
                catch { }
            }

            return nodes;
        }

        private void PopulateCommunityLinks()
        {
            SPWeb currentWeb = SPContext.Current.Web;
            Guid siteId = currentWeb.Site.ID;
            Guid webId = currentWeb.ID;
            string username = currentWeb.CurrentUser.LoginName;

            SPUserToken token = null;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var site = new SPSite(siteId))
                {
                    using (SPWeb web = site.OpenWeb(webId))
                    {
                        token = web.GetUserToken(username);
                    }
                }
            });

            if (token == null)
            {
                throw new Exception("Unable to generate user token for: " + username);
            }

            var navLinks =
                (object[])
                    CacheStore.Current.Get("NavLinks_Navigation_W_" + webId + "_U_" + currentWeb.CurrentUser.ID,
                        CacheStoreCategory.Navigation, () =>
                        {
                            var communityLinks = new Dictionary<string, IList<string>>();
                            var linkNodes = new Dictionary<string, SiteMapNode>();

                            using (var spSite = new SPSite(siteId, token))
                            {
                                using (SPWeb spWeb = spSite.OpenWeb(webId))
                                {
                                    SPList installedAppsList = spWeb.Lists["Installed Applications"];

                                    var query = new SPQuery
                                    {
                                        Query = @"<Where><IsNotNull><FieldRef Name='QuickLaunch' /></IsNotNull></Where>",
                                        ViewFields = @"<FieldRef Name='Title' /><FieldRef Name='QuickLaunch' />"
                                    };

                                    SPListItemCollection communities = installedAppsList.GetItems(query);

                                    var locker = new Object();

                                    try
                                    {
                                        Task.WaitAll((from SPListItem c in communities
                                            select Task.Factory.StartNew(() =>
                                            {
                                                var communityName = (string) (c["Title"] ?? string.Empty);
                                                if (string.IsNullOrEmpty(communityName)) return;

                                                var ql = (string) (c["QuickLaunch"] ?? string.Empty);
                                                if (string.IsNullOrEmpty(ql)) return;

                                                foreach (
                                                    string id in ql.Split(',').Select(linkId => linkId.Split(':')[0]))
                                                {
                                                    if (!communityLinks.ContainsKey(communityName))
                                                    {
                                                        lock (locker)
                                                        {
                                                            communityLinks.Add(communityName, new List<string>());
                                                        }
                                                    }

                                                    lock (locker)
                                                    {
                                                        communityLinks[communityName].Add(id);
                                                    }

                                                    if (linkNodes.ContainsKey(id)) continue;

                                                    lock (locker)
                                                    {
                                                        linkNodes.Add(id, null);
                                                    }
                                                }
                                            })).ToArray());
                                    }
                                    catch (AggregateException exception)
                                    {
                                        exception.Handle(e => { throw e; });
                                    }

                                    string[] links = linkNodes.Keys.ToArray();
                                    foreach (string nodeKey in links)
                                    {
                                        try
                                        {
                                            SiteMapNode node = FindSiteMapNodeFromKey(nodeKey);
                                            if (node == null) continue;

                                            SiteMapNode parentNode = node.ParentNode;
                                            if (parentNode != null && parentNode.Title.Equals("Quick launch"))
                                            {
                                                linkNodes[nodeKey] = node;
                                            }
                                        }
                                        catch { }
                                    }

                                    Dictionary<string, IList<string>> tempCommunityLinks =
                                        communityLinks.ToDictionary(link => link.Key, link => link.Value);
                                    communityLinks.Clear();

                                    foreach (SPNavigationNode node in spWeb.Navigation.QuickLaunch)
                                    {
                                        foreach (var link in tempCommunityLinks)
                                        {
                                            string nodeKey = node.Id.ToString(CultureInfo.InvariantCulture);

                                            if (!link.Value.Contains(nodeKey)) continue;

                                            if (!communityLinks.ContainsKey(link.Key))
                                            {
                                                communityLinks.Add(link.Key, new List<string>());
                                            }

                                            communityLinks[link.Key].Add(nodeKey);
                                        }
                                    }
                                }
                            }

                            return new object[] {communityLinks, linkNodes};
                        }).Value;

            _communityLinks = (Dictionary<string, IList<string>>) navLinks[0];
            _linkNodes = (Dictionary<string, SiteMapNode>) navLinks[1];
        }

        #endregion Methods 

        #region Overrides of SPNavigationProvider

        public override SiteMapNodeCollection GetChildNodes(SiteMapNode node)
        {
            try
            {
                return FindChildNodes(node);
            }
            catch { }

            return new SiteMapNodeCollection();
        }

        #endregion Overrides of SPNavigationProvider
    }
}