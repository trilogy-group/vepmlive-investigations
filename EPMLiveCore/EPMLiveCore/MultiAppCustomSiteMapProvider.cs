using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Navigation;
using System.Web;
using System.Configuration;
using System.Reflection;

namespace EPMLiveCore
{
    public class MultiAppCustomSiteMapProvider : SPNavigationProvider
    {
        private Guid _siteId;
        private Guid _webId;
        private int _userId;
        private AppSettingsHelper appHelper;

        public MultiAppCustomSiteMapProvider()
        {
            _siteId = SPContext.Current.Site.ID;
            _webId = SPContext.Current.Web.ID;
            _userId = SPContext.Current.Web.CurrentUser.ID;
            appHelper = new AppSettingsHelper();
        }
 
        public override SiteMapNodeCollection GetChildNodes(SiteMapNode node)
        {

            if (node.Title == "Quick launch" || node.Title == "Top Nav")
            {
                List<int> appGlobalNodeIds = null;
                SiteMapNodeCollection result = new SiteMapNodeCollection();
                SiteMapNodeCollection childNodes = base.GetChildNodes(node);
                
                //if (HttpContext.Current.Request.Cookies["CurrentAppId_" + _webId.ToString("N")] != null)
                //{
                //    HttpCookie cookieAppId = HttpContext.Current.Request.Cookies["CurrentAppId_" + _webId.ToString("N")];
                //    int id = -1;
                //    try
                //    {
                //        id = int.Parse(cookieAppId.Value);
                //    }
                //    catch { }
                //    if (id != -1)
                //    {
                //        appHelper.CurrentAppId = id;
                //        appHelper.VerifyCookieId();
                //    }

                //}
                //else
                //{
                //    appHelper.GetMyCurrentAppId();
                //}

                appHelper.GetMyCurrentAppId();

                if (appHelper.CurrentAppId != -1)
                {
                    appGlobalNodeIds = appHelper.TryGetMyAppGlobalNodes();

                    if (appGlobalNodeIds != null && appGlobalNodeIds.Count > 0)
                    {
                        foreach (SiteMapNode childNode in childNodes)
                        {
                            if (CanShowChildNode(childNode, appGlobalNodeIds))
                            {
                                result.Add(childNode);
                            }
                        }
                    }

                    return result;
                }
                else
                {
                    return base.GetChildNodes(node);
                }
            }
            else
            {
                return base.GetChildNodes(node);
            }

            
        }

        private bool CanShowChildNode(SiteMapNode n, List<int> globalNavIds)
        {
            bool isVisible = false;

            SPNavigationNode sn = null;

            if (TryGetMatchingNavNode(n, out sn))
            {
                if (globalNavIds.Contains(sn.Id))
                {
                    isVisible = true;
                }
            }

            return isVisible;
        }

        private bool TryGetMatchingNavNode(SiteMapNode sn, out SPNavigationNode navNode)
        {
            navNode = null;

            int nodeId = -1;

            foreach (PropertyInfo pi in sn.GetType().GetProperties())
            {
                if (pi.Name == "Id")
                {
                    nodeId = int.Parse(pi.GetValue(sn, null).ToString());
                    break;
                }
            }

            navNode = appHelper.RecursiveFindNavNodeById(Web.Navigation.TopNavigationBar.Parent, nodeId);

            if (navNode == null)
            {
                navNode = appHelper.RecursiveFindNavNodeById(Web.Navigation.QuickLaunch.Parent, nodeId);
            }

            return navNode != null;
        }

        //private bool TryGetMatchingTopNav(SiteMapNode sn, out SPNavigationNode topNavNode)
        //{
        //    topNavNode = null;
        //    List<SPNavigationNode> nodes = (from SPNavigationNode n in Web.Navigation.TopNavigationBar
        //                                    where n.Title.Equals(sn.Title)
        //                                    select n).ToList<SPNavigationNode>();
        //    if (nodes.Count == 1)
        //    {
        //        topNavNode = nodes[0];

        //    }
        //    return topNavNode != null;
        //}

        //private bool TryGetMatchingQuickLaunchNav(SiteMapNode sn, out SPNavigationNode quickLaunchNode)
        //{
        //    quickLaunchNode = null;
        //    List<SPNavigationNode> nodes = (from SPNavigationNode n in Web.Navigation.QuickLaunch
        //                                    where n.Title.Equals(sn.Title)
        //                                    select n).ToList<SPNavigationNode>();

        //    if (nodes.Count == 1)
        //    {   
        //        quickLaunchNode = nodes[0];
        //    }

        //    return quickLaunchNode != null;
        //}
        
        private List<string> GetUserGroups(SPUser user)
        {
            List<string> result = new List<string>();
            foreach (SPGroup grp in user.Groups)
            {
                result.Add(grp.Name);
            }
            return result;
        }

        private bool IsTopNavBarLink(SiteMapNode smn)
        {
            bool result = false;
            foreach (SPNavigationNode n in Web.Navigation.TopNavigationBar)
            {
                if (n.Title.Equals(smn.Title))
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
