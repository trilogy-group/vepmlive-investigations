using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;

namespace EPMLiveCore.Controls.Navigation
{
    public class EPMLiveQuickLaunchProvider : SPNavigationProvider
    {
        #region Fields (4) 

        private static object _locker;
        private readonly Dictionary<string, IList<string>> _communityLinks;
        private readonly Dictionary<string, SiteMapNode> _linkNodes;
        private DateTime _lastCachedOn;

        #endregion Fields 

        #region Constructors (1) 

        public EPMLiveQuickLaunchProvider()
        {
            _communityLinks = new Dictionary<string, IList<string>>();
            _linkNodes = new Dictionary<string, SiteMapNode>();
            _lastCachedOn = DateTime.MinValue;
            _locker = new object();
        }

        #endregion Constructors 

        #region Methods (2) 

        // Private Methods (2) 

        private SiteMapNodeCollection FindChildNodes(SiteMapNode node)
        {
            var nodes = new SiteMapNodeCollection();

            if ((DateTime.Now - _lastCachedOn).TotalMinutes > 5)
            {
                PopulateCommunityLinks();
            }

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
            SPList installedAppsList;

            try
            {
                installedAppsList = SPContext.Current.Web.Lists["Installed Applications"];
            }
            catch (Exception e)
            {
                throw new Exception("[EPM Live QL] " + e.Message);
            }

            if (installedAppsList == null) return;

            var query = new SPQuery
            {
                Query = @"<Where><IsNotNull><FieldRef Name='QuickLaunch' /></IsNotNull></Where>",
                ViewFields = @"<FieldRef Name='Title' /><FieldRef Name='QuickLaunch' />"
            };

            SPListItemCollection communities = installedAppsList.GetItems(query);

            _communityLinks.Clear();
            _linkNodes.Clear();

            Task.WaitAll((from SPListItem c in communities
                select Task.Factory.StartNew(() =>
                {
                    var communityName = (string) (c["Title"] ?? string.Empty);
                    if (string.IsNullOrEmpty(communityName)) return;

                    var ql = (string) (c["QuickLaunch"] ?? string.Empty);
                    if (string.IsNullOrEmpty(ql)) return;

                    foreach (string linkId in ql.Split(','))
                    {
                        string id = linkId;

                        if (!_communityLinks.ContainsKey(communityName))
                        {
                            lock (_locker)
                            {
                                _communityLinks.Add(communityName, new List<string>());
                            }
                        }

                        lock (_locker)
                        {
                            _communityLinks[communityName].Add(id);
                        }

                        if (_linkNodes.ContainsKey(id)) continue;

                        lock (_locker)
                        {
                            _linkNodes.Add(id, null);
                        }
                    }
                })).ToArray());

            string[] links = _linkNodes.Keys.ToArray();
            foreach (string nodeKey in links)
            {
                try
                {
                    _linkNodes[nodeKey] = FindSiteMapNodeFromKey(nodeKey);
                }
                catch { }
            }

            _lastCachedOn = DateTime.Now;
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