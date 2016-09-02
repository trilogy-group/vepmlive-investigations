using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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

        #region Methods (5) 

        // Public Methods (2) 

        public string DefaultViewFromPropertyBag(SPList list, out List<string> splitViewcollection)
        {
            var sb = new StringBuilder();

            string defaultViewFirstPermission = string.Empty;
            Dictionary<int, string> propBagData = new Dictionary<int, string>();
            bool hasDefaultView = false;
            SPGroupCollection spGroupcol;
            string[] viewArr;
            splitViewcollection = new List<string>();

            try
            {
                if (SPContext.Current.Web.UserIsSiteAdmin)
                {
                    spGroupcol = SPContext.Current.Web.Groups;
                }
                else
                {
                    spGroupcol = SPContext.Current.Web.CurrentUser.Groups;
                }

                try
                {
                    propBagData = ConvertFromString(
                        list.ParentWeb.Properties[String.Format("ViewPermissions{0}", list.ID)]);
                }
                catch { propBagData = null; }
                if (propBagData != null)
                {
                    foreach (var bagData in propBagData)
                    {
                        foreach (SPGroup grp in spGroupcol)
                        {
                            if (grp.ID == bagData.Key)
                            {
                                string viewList = bagData.Value.Split('#')[2];
                                if (!hasDefaultView)
                                {
                                    defaultViewFirstPermission = bagData.Value.Split('#')[1];
                                    hasDefaultView = true;
                                }

                                viewArr = viewList.Split(';');

                                foreach (var tmpViewInsert in viewArr)
                                {
                                    if (!splitViewcollection.Contains(tmpViewInsert))
                                        splitViewcollection.Add(tmpViewInsert);
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            return defaultViewFirstPermission;
        }

        // Private Methods (3) 

        private SPList GetSpList(SiteMapNode node)
        {
            SPList list = null;
            //Handle access denied exceptions 
            bool originalCatchValue = SPSecurity.CatchAccessDeniedException;
            SPSecurity.CatchAccessDeniedException = false;
            try
            {
                SPWeb currentWeb = SPContext.Current.Web;
                list = currentWeb.GetList(node.Url);
            }
            catch (Exception ex) { list = null; }
            finally
            {
                SPSecurity.CatchAccessDeniedException = originalCatchValue;
            }

            return list;
        }

        private Dictionary<int, string> ConvertFromString(string value)
        {
            string[] groups = value.Split("|".ToCharArray());
            var groupValues = new Dictionary<int, string>();

            foreach (string group in groups)
            {
                if (!string.IsNullOrEmpty(group))
                {
                    string[] values = group.Split("#".ToCharArray());
                    int groupId = int.Parse(values[0]);
                    groupValues.Add(groupId, group);
                }
            }

            return groupValues;
        }

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
                        new CacheStoreCategory(Web).Navigation, () =>
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
                                                if (
                                                    node.Url.ToLower()
                                                        .EndsWith(spWeb.ServerRelativeUrl + "/sitepages/report.aspx"))
                                                {
                                                    string title = node.Title;

                                                    SiteMapNodeCollection spNavCol;
                                                    spNavCol = ChangeChildNodeLink(spWeb, node);

                                                    node = new SiteMapNode(this, nodeKey)
                                                    {
                                                        Title = title,
                                                        Url =
                                                            spWeb.ServerRelativeUrl +
                                                            "/_layouts/15/epmlive/reporting/landing.aspx",
                                                        ChildNodes = spNavCol
                                                    };
                                                }
                                                else
                                                {
                                                    node = ChangeNodeLink(spWeb, node);
                                                }

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

        /// <summary>
        /// EPML-4667 : used to change the url of child node based on viewpermission settings.
        /// </summary>
        /// <param name="spWeb">spWeb</param>
        /// <param name="node">node</param>
        /// <returns>SiteMapNodeCollection</returns>
        private SiteMapNodeCollection ChangeChildNodeLink(SPWeb spWeb, SiteMapNode node)
        {
            SiteMapNodeCollection spChildNavCol = base.GetChildNodes(node);
            SiteMapNodeCollection nodeCol = new SiteMapNodeCollection();

            foreach (SiteMapNode cnode in spChildNavCol)
            {
                SiteMapNode currNode = FindSiteMapNodeFromKey(cnode.Key);

                currNode = ChangeNodeLink(spWeb, cnode);
                nodeCol.Add(currNode);

            }
            return nodeCol;
        }

        /// <summary>
        /// EPML-4667 : chnage the link/url of the node based on viewpermission settings
        /// </summary>
        /// <param name="spWeb">spWeb</param>
        /// <param name="node">node</param>
        /// <returns>SiteMapNode</returns>
        private SiteMapNode ChangeNodeLink(SPWeb spWeb, SiteMapNode node)
        {
            List<string> splitViewcollection;
            SiteMapNode chgNode = FindSiteMapNodeFromKey(node.Key);

            SPList list = GetSpList(node);

            if (list != null)
            {
                string defaultViewURL = DefaultViewFromPropertyBag(list, out splitViewcollection);
                string prevURL = node.Url;
                string title = node.Title;

                if (string.IsNullOrEmpty(defaultViewURL))
                    defaultViewURL = list.DefaultViewUrl;

                if (!string.IsNullOrEmpty(defaultViewURL))
                {
                    if (prevURL.EndsWith("/")) // it check if url is like "/Issues/" or not
                    {
                        chgNode = new SiteMapNode(this, node.Key)
                        {
                            Title = title,
                            Url = defaultViewURL.Contains("sites") ? defaultViewURL : spWeb.IsRootWeb ? spWeb.Url + "/" + defaultViewURL : spWeb.ServerRelativeUrl + "/" + defaultViewURL,
                            ChildNodes = ChangeChildNodeLink(spWeb, node)
                        };
                    }
                    else
                    {
                        if (splitViewcollection.Count > 0 && !splitViewcollection.Contains(prevURL.Replace((spWeb.ServerRelativeUrl + "/"), "")))
                        {
                            chgNode = new SiteMapNode(this, node.Key)
                            {
                                Title = title,
                                Url = defaultViewURL.Contains("sites") ? defaultViewURL : spWeb.IsRootWeb ? spWeb.Url + "/" + defaultViewURL : spWeb.ServerRelativeUrl + "/" + defaultViewURL,
                                ChildNodes = ChangeChildNodeLink(spWeb, node)
                            };
                        }
                        else
                        {
                            chgNode = new SiteMapNode(this, node.Key)
                            {
                                Title = title,
                                Url = prevURL,
                                ChildNodes = ChangeChildNodeLink(spWeb, node)
                            };
                        }
                    }
                }
            }
            return chgNode;
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