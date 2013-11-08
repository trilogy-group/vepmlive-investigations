using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPMLiveCore.Controls.Navigation;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using System.Data.SqlClient;
using EPMLiveCore.GlobalResources;
using Microsoft.SharePoint.Navigation;
using System.Collections;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveCore
{
    public class AppSettingsHelper
    {
        public int CurrentAppId = -1;
        
        public AppSettingsHelper()
        {
            GetMyCurrentAppId();
        }

        public AppSettingsHelper(Guid siteId, Guid webId)
        {
            GetMyCurrentAppId(siteId, webId);
        }

        public bool AppListExists()
        {
            bool exists = false;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        if (appList != null)
                        {
                            exists = true;
                        }
                    }
                }
            });

            return exists;
        }

        public bool AppIdExists(int appId)
        {
            bool exists = false;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        if (appList != null)
                        {
                            SPListItem appItem = null;
                            try
                            {
                                appItem = appList.GetItemById(appId);
                            }
                            catch { }

                            if (appItem != null)
                            {
                                exists = true;
                            }
                        }
                    }
                }
            });

            return exists;

        }

        /// <summary>
        /// Returns id of current app, returns -1 if
        /// 1) "Installed Applications" is not found or 
        /// 2) list has no items
        /// </summary>
        /// <returns></returns>
        public void GetMyCurrentAppId()
        {
            int result = -1;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (var spSite = new SPSite(SPContext.Current.Site.ID))
                {
                    using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                    {
                        string queryString =
                            @"SELECT [Key], Value FROM PERSONALIZATIONS 
                                  WHERE [Key] = 'selectedapp' AND UserId = @userId AND WebId = @webId AND SiteId = @siteId";

                        using (var sqlCommand = new SqlCommand(queryString, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@userId", SPContext.Current.Web.CurrentUser.ID);
                            sqlCommand.Parameters.AddWithValue("@webId", SPContext.Current.Web.ID);
                            sqlCommand.Parameters.AddWithValue("@siteId", SPContext.Current.Site.ID);
                            sqlConnection.Open();

                            SqlDataReader sqlDataReader =
                                sqlCommand.ExecuteReader();

                            while (sqlDataReader.Read())
                            {
                                string currentAppId =
                                    sqlDataReader[1].ToString();
                                try
                                {
                                    result = int.Parse(currentAppId);
                                }
                                catch { }
                            }
                        }
                    }

                    // if can't get a default value
                    // and a "installed Applicatons" list
                    // exists, set new default
                    using (SPWeb ew = spSite.OpenWeb(SPContext.Current.Web.ID))
                    {
                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        if (appList != null)
                        {
                            SPListItem defaultAppItem = null;
                            try
                            {
                                defaultAppItem = appList.GetItemById(result);
                                defaultAppItem = bool.Parse(defaultAppItem["Visible"].ToString()) ? defaultAppItem : null;
                                result = -1;
                            }
                            catch { }

                            if (defaultAppItem == null)
                            {
                                defaultAppItem = GetDefaultCommunity(appList);
                            }

                            if (defaultAppItem != null)
                            {
                                SetCurrentAppId(defaultAppItem.ID);
                                result = defaultAppItem.ID;
                            }
                            else
                            {
                                result = -1;
                            }
                        }
                    }
                }
            });

            CurrentAppId = result;
        }
        public SPListItem GetDefaultCommunity(SPList appList)
        {
            SPListItem defaultAppItem = null;

            SPQuery qDefaultVisibleComs = new SPQuery();
            qDefaultVisibleComs.Query = "<Where><And><IsNull><FieldRef Name=\"EXTID\" /></IsNull><And><Eq><FieldRef Name=\"Visible\" /><Value Type=\"Boolean\">1</Value></Eq><Eq><FieldRef Name=\"Default\" /><Value Type=\"Boolean\">1</Value></Eq></And></And></Where>";
            SPListItemCollection items = appList.GetItems(qDefaultVisibleComs);

            if (items.Count == 1)
            {
                defaultAppItem = items[0];
            }
            else
            {
                if (appList.Items.Count > 0)
                {
                    SPQuery queryFirstCom = new SPQuery();
                    queryFirstCom.Query = "<Where><And><IsNull><FieldRef Name=\"EXTID\" /></IsNull><Eq><FieldRef Name=\"Visible\" /><Value Type=\"Boolean\">1</Value></Eq></And></Where>";
                    SPListItemCollection firstComs = appList.GetItems(queryFirstCom);
                    if (firstComs.Count > 0)
                    {
                        SPListItem tempItem = firstComs[0];
                        defaultAppItem = tempItem;
                    }
                }
            }

            return defaultAppItem;
        }

        /// <summary>
        /// Verify app id found in cookie
        /// </summary>
        /// <returns></returns>
        public void VerifyCookieId()
        {
            int result = -1;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (var spSite = new SPSite(SPContext.Current.Site.ID))
                {   
                    // if can't get a default value
                    // and a "installed Applicatons" list
                    // exists, set new default
                    using (SPWeb ew = spSite.OpenWeb(SPContext.Current.Web.ID))
                    {
                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        if (appList != null)
                        {
                            SPListItem defaultAppItem = null;
                            try
                            {
                                defaultAppItem = appList.GetItemById(CurrentAppId);
                                defaultAppItem = bool.Parse(defaultAppItem["Visible"].ToString()) ? defaultAppItem : null;
                                result = -1;
                            }
                            catch { }

                            if (defaultAppItem == null)
                            {
                                SPQuery qDefaultVisibleComs = new SPQuery();
                                qDefaultVisibleComs.Query = "<Where><And><IsNull><FieldRef Name=\"EXTID\" /></IsNull><And><Eq><FieldRef Name=\"Visible\" /><Value Type=\"Boolean\">1</Value></Eq><Eq><FieldRef Name=\"Default\" /><Value Type=\"Boolean\">1</Value></Eq></And></And></Where>";
                                SPListItemCollection items = appList.GetItems(qDefaultVisibleComs);

                                if (items.Count == 1)
                                {
                                    defaultAppItem = items[0];
                                }
                                else
                                {
                                    if (appList.Items.Count > 0)
                                    {
                                        SPQuery queryFirstCom = new SPQuery();
                                        queryFirstCom.Query = "<Where><And><IsNull><FieldRef Name=\"EXTID\" /></IsNull><Eq><FieldRef Name=\"Visible\" /><Value Type=\"Boolean\">1</Value></Eq></And></Where>";
                                        SPListItemCollection firstComs = appList.GetItems(queryFirstCom);
                                        if (firstComs.Count > 0)
                                        {
                                            SPListItem tempItem = firstComs[0];
                                            defaultAppItem = tempItem;
                                        }
                                    }
                                }
                            }

                            if (defaultAppItem != null)
                            {
                                SetCurrentAppId(defaultAppItem.ID);
                                result = defaultAppItem.ID;
                            }
                            else
                            {
                                result = -1;
                            }
                        }
                    }
                }
            });

            CurrentAppId = result;
        }

        public void SetCurrentAppId(int appId)
        {
            
            using (var spSite = new SPSite(SPContext.Current.Site.ID))
            {
                using (var sqlConnection = new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                {
                    string query_DeleteAll =
                            @"DELETE FROM PERSONALIZATIONS 
                              WHERE [Key] = @key 
                              AND UserId = @userId 
                              AND WebId = @webId 
                              AND SiteId = @siteId";

                    using (var sqlCommand = new SqlCommand(query_DeleteAll, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@key", MultiAppNavigationResources.PERSONALIZATION_KEY_DEFAULT_APP);
                        sqlCommand.Parameters.AddWithValue("@userId", SPContext.Current.Web.CurrentUser.ID);
                        sqlCommand.Parameters.AddWithValue("@webId", SPContext.Current.Web.ID);
                        sqlCommand.Parameters.AddWithValue("@siteId", SPContext.Current.Site.ID);

                        try
                        {
                            SPSecurity.RunWithElevatedPrivileges(() =>
                            {
                                sqlConnection.Open();
                                sqlCommand.ExecuteNonQuery();
                                sqlConnection.Close();
                            });
                        }
                        catch (SqlException sqlException)
                        {
                            throw sqlException;
                        }
                    }

                    string query_InsertNew =
                            @"INSERT INTO PERSONALIZATIONS ([Key], Value, UserId, WebID, SiteID) 
                              VALUES (@key, @value, @userId, @webId, @siteId)";

                    using (var sqlCommand = new SqlCommand(query_InsertNew, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@key", MultiAppNavigationResources.PERSONALIZATION_KEY_DEFAULT_APP);
                        sqlCommand.Parameters.AddWithValue("@value", appId);
                        sqlCommand.Parameters.AddWithValue("@userId", SPContext.Current.Web.CurrentUser.ID);
                        sqlCommand.Parameters.AddWithValue("@webId", SPContext.Current.Web.ID);
                        sqlCommand.Parameters.AddWithValue("@siteId", SPContext.Current.Site.ID);

                        try
                        {
                            SPSecurity.RunWithElevatedPrivileges(() =>
                            {
                                sqlConnection.Open();
                                sqlCommand.ExecuteNonQuery();
                                sqlConnection.Close();
                                CurrentAppId = appId;
                            });
                        }
                        catch (SqlException sqlException)
                        {
                            throw sqlException;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get a list of spnavigation ids that 
        /// includes an app's top nav and quick launch
        /// by the given app id
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public List<int> TryGetGlobalNodesByAppId(int appId)
        {
            List<int> result = null;
            List<int> topNavs = TryGetTopNavIdsByAppId(appId);
            List<int> quickLaunchs = TryGetQuickLaunchIdsByAppId(appId);

            if (topNavs != null && quickLaunchs != null)
            {
                result.AddRange(topNavs);
                result.AddRange(quickLaunchs);
            }

            return result;
        }

        /// <summary>
        /// Get a list of spnavigation ids that 
        /// includes an app's top nav and quick launch
        /// by the current app id found in database
        /// </summary>
        /// <returns></returns>
        public List<int> TryGetMyAppGlobalNodes()
        {
            List<int> result = new List<int>();
            List<int> topNavs = TryGetMyAppTopNavIds();
            List<int> quickLaunchs = TryGetMyAppQuickLaunchIds();

            if (topNavs != null)
            {
                result.AddRange(topNavs);
            }

            if (quickLaunchs != null)
            {
                result.AddRange(quickLaunchs);
            }

            return result;
        }

        public List<int> TryGetMyGlobalNavsForSiteMapProvider()
        {
            int appId = CurrentAppId;
            List<int> result = new List<int>();

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        SPList listApps = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        SPListItem appItem = null;

                        try
                        {
                            appItem = listApps.GetItemById(appId);
                        }
                        catch { }

                        if (appItem != null)
                        {
                            List<int> tnIds = (from SPNavigationNode tnNode in ew.Navigation.TopNavigationBar
                                               select tnNode.Id).ToList();
                            object fv = null;
                            string sfv = string.Empty;
                            try
                            {
                                fv = appItem["TopNav"];
                            }
                            catch { }

                            if (fv != null)
                            {
                                sfv = fv.ToString();
                            }

                            if (!string.IsNullOrEmpty(sfv))
                            {
                                List<int> appTopIds = Array.ConvertAll(sfv.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s.Split(':')[0])).ToList();
                                foreach (int i in appTopIds)
                                {
                                    if (tnIds.Contains(i))
                                    {
                                        result.Add(i);
                                    }
                                }
                            }

                            List<int> qlIds = (from SPNavigationNode qlNode in ew.Navigation.QuickLaunch
                                               select qlNode.Id).ToList();

                            try
                            {
                                fv = appItem["QuickLaunch"];
                            }
                            catch { }

                            if (fv != null)
                            {
                                sfv = fv.ToString();
                            }

                            if (!string.IsNullOrEmpty(sfv))
                            {
                                List<int> appQlIds = Array.ConvertAll(sfv.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s)).ToList();

                                foreach (int i in appQlIds)
                                {
                                    if (qlIds.Contains(i))
                                    {
                                        result.Add(i);
                                    }
                                }
                            }
                        }

                    }
                }
            });

            return result;
        }

        /// <summary>
        /// This returns all nav ids for app
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public List<int> TryGetAppGlobalNodesById(int appId)
        {
            List<int> result = new List<int>();
            List<int> topNavs = TryGetTopNavIdsByAppId(appId);
            List<int> quickLaunchs = TryGetQuickLaunchIdsByAppId(appId);

            if (topNavs != null)
            {
                result.AddRange(topNavs);
            }

            if (quickLaunchs != null)
            {
                result.AddRange(quickLaunchs);
            }

            return result;
        }

        public List<int> TryGetRootChildTopNavIdsByAppId(int appId)
        {
            List<int> result = new List<int>();
            SPNavigationNode testNode = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        SPList listApps = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        if (listApps != null)
                        {
                            string sTopNav = string.Empty;
                            SPListItem item = null;
                            try
                            {
                                item = listApps.GetItemById(appId);
                            }
                            catch { }

                            if (item != null)
                            {
                                object fv = null;
                                try
                                {
                                    fv = item["TopNav"];
                                }
                                catch { }

                                if (fv != null)
                                {
                                    sTopNav = fv.ToString().Trim();
                                }

                                if (!string.IsNullOrEmpty(sTopNav))
                                {
                                    int[] topNavIds = Array.ConvertAll(sTopNav.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s.Split(':')[0]));

                                    foreach (int id in topNavIds)
                                    {
                                        try
                                        {
                                            testNode = ew.Navigation.GetNodeById(id);
                                        }
                                        catch { }

                                        if (testNode != null && testNode.ParentId == ew.Navigation.TopNavigationBar.Parent.Id)
                                        {
                                            result.Add(id);
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            });

            return result;
        }

        /// <summary>
        /// Return a list of top nav ids if appid is valid 
        /// and contains top nav nodes, else returns null
        /// </summary>
        /// <param name="appid"></param>
        /// <returns>returns a list of int</returns>
        public List<int> TryGetTopNavIdsByAppId(int appId)
        {
            List<int> result = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        SPList listApps = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        if (listApps != null)
                        {
                            string sTopNav = string.Empty;
                            SPListItem item = null;
                            try
                            {
                                item = listApps.GetItemById(appId);
                            }
                            catch { }

                            if (item != null)
                            {
                                object fv = null;
                                try
                                {
                                    fv = item["TopNav"];
                                }
                                catch { }

                                if (fv != null)
                                {
                                    sTopNav = fv.ToString().Trim();
                                }

                                if (!string.IsNullOrEmpty(sTopNav))
                                {
                                    int[] topNavIds = Array.ConvertAll(sTopNav.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s.Split(':')[0]));
                                    result = new List<int>(topNavIds);
                                }
                            }
                        }

                    }
                }
            });

            return result;
        }

        public List<int> TryGetMyAppTopNavIds()
        {
            int appId = CurrentAppId;
            List<int> result = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        SPList listApps = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        if (listApps != null)
                        {
                            string sTopNav = string.Empty;
                            SPListItem item = null;
                            try
                            {
                                item = listApps.GetItemById(appId);
                            }
                            catch { }

                            if (item != null)
                            {
                                object fv = null;
                                try
                                {
                                    fv = item["TopNav"];
                                }
                                catch { }

                                if (fv != null)
                                {
                                    sTopNav = fv.ToString().Trim();
                                }

                                if (!string.IsNullOrEmpty(sTopNav))
                                {
                                    int[] topNavIds = Array.ConvertAll(sTopNav.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s.Split(':')[0]));
                                    result = new List<int>(topNavIds);
                                }
                            }
                        }

                    }
                }
            });

            return result;
        }

        public List<SPNavigationNode> TryGetTopNavNodeCollectionById(int appId)
        {
            List<SPNavigationNode> result = new List<SPNavigationNode>();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        ew.AllowUnsafeUpdates = true;
                        List<int> quickLaunchIds = TryGetTopNavIdsByAppId(appId);
                        SPNavigationNode n = null;
                        if (quickLaunchIds != null)
                        {
                            // can't sort here
                            SPNavigationNodeCollection topNavCol = ew.Navigation.TopNavigationBar;

                            foreach (SPNavigationNode tnNode in topNavCol)
                            {
                                if (quickLaunchIds.Contains(tnNode.Id))
                                {
                                    result.Add(tnNode);
                                }
                            }
                        }
                    }
                }
            });

            return result;
        }

        public SPNavigationNode RecursiveFindNavNodeById(SPNavigationNode node, int id)
        {
            SPNavigationNode result = null;
            SPNavigationNode placeHolder = null;
            if (node.Id == id)
            {
                result = node;
            }
            else
            {
                foreach (SPNavigationNode child in node.Children)
                {
                    placeHolder = RecursiveFindNavNodeById(child, id);
                    if (placeHolder != null)
                    {
                        result = placeHolder;
                        break;
                    }
                }
            }

            return result;
        }

        public SPNavigationNode RecursiveFindNavNodeByTitle(SPNavigationNode node, string title)
        {
            SPNavigationNode result = null;
            SPNavigationNode placeHolder = null;
            if (node.Title == title)
            {
                result = node;
            }
            else
            {
                foreach (SPNavigationNode child in node.Children)
                {
                    placeHolder = RecursiveFindNavNodeByTitle(child, title);
                    if (placeHolder != null)
                    {
                        result = placeHolder;
                        break;
                    }
                }
            }

            return result;
        }

        public List<int> TryGetRootChildQuickLaunchIdsByAppId(int appId)
        {
            List<int> result = new List<int>();
            SPNavigationNode testNode = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        SPList listApps = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        if (listApps != null)
                        {
                            string sQuickLaunch = string.Empty;
                            SPListItem item = null;
                            try
                            {
                                item = listApps.GetItemById(appId);
                            }
                            catch { }

                            if (item != null)
                            {
                                object fv = null;
                                try
                                {
                                    fv = item["QuickLaunch"];
                                }
                                catch { }

                                if (fv != null)
                                {
                                    sQuickLaunch = fv.ToString().Trim();
                                }

                                if (!string.IsNullOrEmpty(sQuickLaunch))
                                {
                                    int[] quickLaunchIds = Array.ConvertAll(sQuickLaunch.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s.Split(':')[0]));

                                    foreach (int id in quickLaunchIds)
                                    {
                                        try
                                        {
                                            testNode = ew.Navigation.GetNodeById(id);
                                        }
                                        catch { }

                                        if (testNode != null && testNode.ParentId == 1025)
                                        {
                                            result.Add(id);
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            });

            return result;
        }

        /// <summary>
        /// Return a list of quick launch nav ids if appid is valid 
        /// and contains quick launch nav nodes, else returns null
        /// </summary>
        /// <param name="appid"></param>
        /// <returns>returns a list of int</returns>
        public List<int> TryGetQuickLaunchIdsByAppId(int appId)
        {
            List<int> result = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        SPList listApps = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        if (listApps != null)
                        {
                            string sQuickLaunch = "";
                            SPListItem item = null;
                            try
                            {
                                item = listApps.GetItemById(appId);
                            }
                            catch { }

                            if (item != null)
                            {
                                object fv = null;
                                try
                                {
                                    fv = item["QuickLaunch"];
                                }
                                catch { }

                                if (fv != null)
                                {
                                    sQuickLaunch = fv.ToString().Trim();
                                }

                                if (!string.IsNullOrEmpty(sQuickLaunch))
                                {
                                    int[] quickLaunchIds = Array.ConvertAll(sQuickLaunch.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s.Split(':')[0]));
                                    result = new List<int>(quickLaunchIds);
                                }
                            }
                        }
                    }
                }
            });

            return result;
        }

        public List<int> TryGetMyAppQuickLaunchIds()
        {
            int appId = CurrentAppId;
            List<int> result = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        SPList listApps = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        if (listApps != null)
                        {
                            string sQuickLaunch = "";
                            SPListItem item = null;
                            try
                            {
                                item = listApps.GetItemById(appId);
                            }
                            catch { }

                            if (item != null)
                            {
                                object fv = null;
                                try
                                {
                                    fv = item["QuickLaunch"];
                                }
                                catch { }

                                if (fv != null)
                                {
                                    sQuickLaunch = fv.ToString().Trim();
                                }

                                if (!string.IsNullOrEmpty(sQuickLaunch))
                                {
                                    int[] quickLaunchIds = Array.ConvertAll(sQuickLaunch.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s.Split(':')[0]));
                                    result = new List<int>(quickLaunchIds);
                                }
                            }
                        }
                    }
                }
            });

            return result;
        }

        /// <summary>
        /// Gets subset of nodes 
        /// from global nodes that is used
        /// by specific app
        /// </summary>
        /// <param name="appId">id of the specific app</param>
        /// <returns></returns>
        public List<SPNavigationNode> TryGetQuickLaunchNodeCollectionById(int appId)
        {
            List<SPNavigationNode> result = new List<SPNavigationNode>();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        ew.AllowUnsafeUpdates = true;
                        List<int> quickLaunchIds = TryGetQuickLaunchIdsByAppId(appId);

                        // can't sort
                        SPNavigationNodeCollection qlCol = ew.Navigation.QuickLaunch;
                        foreach (SPNavigationNode qlNode in qlCol)
                        {
                            if (quickLaunchIds.Contains(qlNode.Id))
                            {
                                result.Add(qlNode);
                            }
                        }
                    }
                }
            });

            return result;
        }

        /// <summary>
        /// returns -1 if app has no top nav,
        /// else returns the id of the last top nav
        /// node inserted
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public int GetAppTopNavLastNodeId(int appId)
        {
            int result = -1;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        ew.AllowUnsafeUpdates = true;
                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);

                        if (appList != null)
                        {
                            SPListItem app = appList.GetItemById(appId);
                            string holder = string.Empty;
                            object fv = null;
                            try
                            {
                                fv = app["TopNav"];
                            }
                            catch { }

                            if (fv != null)
                            {
                                holder = fv.ToString().Trim();
                            }

                            if (!string.IsNullOrEmpty(holder))
                            {
                                int[] iaTopNavs = Array.ConvertAll(holder.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s.Split(':')[0]));
                                List<int> iaTopNavTopLevel = new List<int>();
                                SPNavigationNode testNode = null;
                                foreach (int id in iaTopNavs)
                                {
                                    try
                                    {
                                        testNode = ew.Navigation.GetNodeById(id);
                                    }
                                    catch { }

                                    if (testNode != null && testNode.ParentId == ew.Navigation.TopNavigationBar.Parent.Id)
                                    {
                                        iaTopNavTopLevel.Add(id);
                                    }
                                }

                                if (iaTopNavTopLevel.Count > 0)
                                {
                                    iaTopNavTopLevel.Sort();
                                    result = iaTopNavTopLevel[iaTopNavTopLevel.Count - 1];
                                }
                            }
                        }
                    }
                }
            });

            return result;
        }

        public void AddAppTopNav(int appId, int navId)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        ew.AllowUnsafeUpdates = true;
                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);

                        if (appList != null)
                        {
                            SPListItem app = appList.GetItemById(appId);
                            string sTopNav = string.Empty;
                            object fv = null;
                            try
                            {
                                fv = app["TopNav"];
                            }
                            catch { }

                            if (fv != null)
                            {
                                sTopNav = fv.ToString().Trim();
                            }

                            if (string.IsNullOrEmpty(sTopNav))
                            {
                                sTopNav = navId.ToString();
                            }
                            else
                            {
                                // convert into int array
                                List<int> lTopNav = Array.ConvertAll(sTopNav.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s.Split(':')[0])).ToList();
                                if (lTopNav.Count > 0 && !lTopNav.Contains(navId))
                                {
                                    // add the new nav id
                                    lTopNav.Add(navId);
                                    // sort the ids, so we can know the last id is the highest
                                    lTopNav.Sort();
                                    string[] saTopNav = Array.ConvertAll(lTopNav.ToArray(), s => s.ToString());
                                    sTopNav = string.Join(",", saTopNav);
                                }
                            }

                            app["TopNav"] = sTopNav;
                            app.Update();
                        }
                    }
                }
            });
        }

        public void DeleteAppTopNav(int appId, int navId)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        ew.AllowUnsafeUpdates = true;
                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);

                        if (appList != null)
                        {
                            SPListItem app = appList.GetItemById(appId);
                            string sTopNav = string.Empty;
                            object fv = null;
                            try
                            {
                                fv = app["TopNav"];
                            }
                            catch { }

                            if (fv != null)
                            {
                                sTopNav = fv.ToString().Trim();
                            }

                            if (!string.IsNullOrEmpty(sTopNav))
                            {
                                string[] saTopNav = sTopNav.Split(',').Select(s => s.Trim()).ToArray();
                                if (saTopNav.Length > 0 && saTopNav.Contains(appId.ToString()))
                                {
                                    sTopNav = sTopNav.Replace(appId.ToString(), string.Empty);
                                    string[] tempSaTopNav = sTopNav.Split(',').Select(s => s.Trim()).ToArray();
                                    sTopNav = string.Join(",", tempSaTopNav);
                                    sTopNav = sTopNav.Substring(1);
                                }
                            }

                            app["TopNav"] = sTopNav;
                            app.Update();
                        }
                    }
                }
            });
        }

        /// <summary>
        /// returns -1 if app has no quick launch,
        /// else returns the id of the last quick launch
        /// node inserted
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public int GetAppQuickLaunchLastNodeId(int appId)
        {
            int result = -1;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        ew.AllowUnsafeUpdates = true;
                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);

                        if (appList != null)
                        {
                            SPListItem app = appList.GetItemById(appId);
                            string holder = string.Empty;
                            object fv = null;
                            try
                            {
                                fv = app["QuickLaunch"];
                            }
                            catch { }

                            if (fv != null)
                            {
                                holder = fv.ToString().Trim();
                            }

                            if (!string.IsNullOrEmpty(holder))
                            {
                                int[] iaQuickLaunchs = Array.ConvertAll(holder.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s.Split(':')[0]));
                                List<int> iaQuickLaunchTopLevel = new List<int>();
                                SPNavigationNode testNode = null;
                                foreach (int id in iaQuickLaunchs)
                                {
                                    try
                                    {
                                        testNode = ew.Navigation.GetNodeById(id);
                                    }
                                    catch { }

                                    if (testNode != null && testNode.ParentId == 1025)
                                    {
                                        iaQuickLaunchTopLevel.Add(id);
                                    }
                                }

                                if (iaQuickLaunchTopLevel.Count > 0)
                                {
                                    iaQuickLaunchTopLevel.Sort();
                                    result = iaQuickLaunchTopLevel[iaQuickLaunchTopLevel.Count - 1];
                                }
                            }
                        }
                    }
                }
            });

            return result;
        }

        public void AddAppQuickLaunch(int appId, int navId)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        ew.AllowUnsafeUpdates = true;

                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);

                        if (appList != null)
                        {
                            SPListItem app = appList.GetItemById(appId);
                            string sQuickLaunch = string.Empty;
                            object fv = null;
                            try
                            {
                                fv = app["QuickLaunch"];
                            }
                            catch { }

                            if (fv != null)
                            {
                                sQuickLaunch = fv.ToString().Trim();
                            }

                            if (string.IsNullOrEmpty(sQuickLaunch))
                            {
                                sQuickLaunch = navId.ToString();
                            }
                            else
                            {
                                // convert string array to int array
                                List<int> lQuickLaunch = Array.ConvertAll(sQuickLaunch.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s.Split(':')[0])).ToList();

                                if (lQuickLaunch.Count > 0 && !lQuickLaunch.Contains(navId))
                                {
                                    // sort array, so we know last position contains highest id
                                    lQuickLaunch.Add(navId);
                                    lQuickLaunch.Sort();
                                    string[] saQuickLaunch = Array.ConvertAll(lQuickLaunch.ToArray(), s => s.ToString());
                                    sQuickLaunch = string.Join(",", saQuickLaunch);
                                }
                            }

                            app["QuickLaunch"] = sQuickLaunch;
                            app.Update();
                        }
                    }
                }
            });
        }

        public void DeleteAppQuickLaunch(int appId, int navId)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        ew.AllowUnsafeUpdates = true;
                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);

                        if (appList != null)
                        {
                            SPListItem app = appList.GetItemById(appId);
                            string sQuickLaunch = string.Empty;
                            object fv = null;
                            try
                            {
                                fv = app["QuickLaunch"];
                            }
                            catch { }

                            if (fv != null)
                            {
                                sQuickLaunch = fv.ToString().Trim();
                            }

                            if (!string.IsNullOrEmpty(sQuickLaunch))
                            {
                                string[] saQuickLaunch = sQuickLaunch.Split(',').Select(s => s.Trim()).ToArray();
                                if (saQuickLaunch.Length > 0 && saQuickLaunch.Contains(appId.ToString()))
                                {
                                    sQuickLaunch = sQuickLaunch.Replace(appId.ToString(), string.Empty);
                                    string[] tempSaQuickLaunch = sQuickLaunch.Split(',').Select(s => s.Trim()).ToArray();
                                    sQuickLaunch = string.Join(",", tempSaQuickLaunch);
                                    if (sQuickLaunch.StartsWith(","))
                                    {
                                        sQuickLaunch = sQuickLaunch.Substring(1);
                                    }
                                }
                            }

                            app["QuickLaunch"] = sQuickLaunch;
                            app.Update();
                        }
                    }
                }
            });
        }

        public string GetCurrentAppTitle()
        {
            string result = string.Empty;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        ew.AllowUnsafeUpdates = true;
                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                        if (appList != null)
                        {
                            if (CurrentAppId != -1)
                            {
                                SPListItem item = appList.GetItemById(CurrentAppId);

                                if (item != null && bool.Parse(item["Visible"].ToString()))
                                {
                                    result = item.Title;
                                }
                            }
                        }
                    }
                }
            });

            return result;
        }

        public int GetRealIndex(int parentNodeId, int position, int appId, string navType)
        {
            int result = -1;
            // the node we're trying to move
            SPNavigationNode realNode = null;
            // this represent the topnav/quicklaunch node collection of an app
            List<SPNavigationNode> appNodes = new List<SPNavigationNode>();
            List<SPNavigationNode> orderedAppNodes = new List<SPNavigationNode>();
            List<int> appNodesIds = new List<int>();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);

                        if (appList != null)
                        {
                            SPListItem item = appList.GetItemById(appId);
                            if (item != null)
                            {
                                string sfv = string.Empty;
                                object fv = null;

                                switch (navType)
                                {
                                    case "topnav":
                                        try
                                        {
                                            fv = item["TopNav"];
                                        }
                                        catch { }

                                        break;
                                    case "quiklnch":
                                        try
                                        {
                                            fv = item["QuickLaunch"];
                                        }
                                        catch { }

                                        break;
                                }

                                List<int> navIds = new List<int>();

                                if (fv != null)
                                {
                                    sfv = fv.ToString();
                                }

                                if (!string.IsNullOrEmpty(sfv))
                                {
                                    navIds = Array.ConvertAll(sfv.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s.Split(':')[0])).ToList();
                                }

                                if (navIds.Count > 0)
                                {
                                    SPNavigationNode tNode = null;
                                    foreach (int id in navIds)
                                    {
                                        try
                                        {
                                            tNode = ew.Navigation.GetNodeById(id);
                                        }
                                        catch { }

                                        if (tNode != null && tNode.ParentId == parentNodeId)
                                        {
                                            appNodes.Add(tNode);
                                            appNodesIds.Add(tNode.Id);
                                        }
                                    }
                                }

                                SPNavigationNodeCollection c = ew.Navigation.GetNodeById(parentNodeId).Children;
                                for (int i = 0; i < c.Count; i++)
                                {
                                    if (appNodesIds.Contains(c[i].Id))
                                    {
                                        orderedAppNodes.Add(c[i]);
                                    }
                                }

                                realNode = orderedAppNodes[position];

                                for (int i = 0; i < c.Count; i++)
                                {
                                    if (c[i].Id == realNode.Id)
                                    {
                                        result = i;
                                        break;
                                    }
                                }

                            }
                        }

                    }
                }
            });

            return result;
        }

        public void CreateChildNode(int appId, string nodeType, string title, string url, int headingNodeId, bool isExternal, SPUser origUser)
        {
            url = GetCleanUrl(url);

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        SPNavigationNode headingNode = null;
                        ew.AllowUnsafeUpdates = true;

                        if (headingNodeId != -1)
                        {
                            headingNode = ew.Navigation.GetNodeById(headingNodeId);
                        }

                        if (headingNode != null)
                        {
                            SPNavigationNode currentChildNode;
                            switch (nodeType)
                            {
                                case "topnav":
                                    // create internal or external node dynamically
                                    currentChildNode = !isExternal ?
                                        // if internal "http://server/sites/dev1"
                                        headingNode.Children.AddAsLast(new SPNavigationNode(title, url)) :
                                        // if external
                                        headingNode.Children.AddAsLast(new SPNavigationNode(title, url, true));
                                    // this prevents the child node from 
                                    // showing up and organized horizontally
                                    // across the top nav bar
                                    currentChildNode.IsVisible = false;

                                    if (appId != -1)
                                    {
                                        // adds the id of the newly created node
                                        // to topnav field of app item in "Installed Applications"
                                        AddAppTopNav(appId, currentChildNode.Id);
                                    }
                                    break;
                                case "quiklnch":
                                    // create internal or external node dynamically
                                    currentChildNode = !isExternal ?
                                        // if internal "http://server/sites/dev1"
                                        headingNode.Children.AddAsLast(new SPNavigationNode(title, url)) :
                                        // if external
                                        headingNode.Children.AddAsLast(new SPNavigationNode(title, url, true));
                                    // this prevents the child node from 
                                    // showing up and organized horizontally
                                    // across the top nav bar
                                    currentChildNode.IsVisible = false;

                                    if (appId != -1)
                                    {
                                        // adds the id of the newly created node
                                        // to topnav field of app item in "Installed Applications"
                                        AddAppQuickLaunch(appId, currentChildNode.Id);
                                    }
                                    break;
                            }

                            // clear EPM cache
                            CacheStore.Current.RemoveCategory(CacheStoreCategory.Navigation);
                        }

                        ew.Update();
                        ew.AllowUnsafeUpdates = false;
                    }
                }
            });


        }

        public void CreateParentNode(int appId, string nodeType, string title, string url, bool isExternal, SPUser origUser)
        {
            url = GetCleanUrl(url);
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        ew.AllowUnsafeUpdates = true;

                        if (!String.IsNullOrEmpty(url)
                            && !String.IsNullOrEmpty(title))
                        {
                            SPNavigationNode currentNode;
                            switch (nodeType)
                            {
                                case "topnav":
                                    if (appId != -1)
                                    {
                                        int lastTopNavId = GetAppTopNavLastNodeId(appId);

                                        if (lastTopNavId != -1)
                                        {
                                            // create internal or external node dynamically
                                            currentNode = !isExternal ?
                                                // if internal "http://server/sites/dev1"
                                                ew.Navigation.TopNavigationBar.Add(new SPNavigationNode(title, url),
                                                                                    ew.Navigation.GetNodeById(lastTopNavId)) :
                                                // if external "www.google.com"                   
                                                ew.Navigation.TopNavigationBar.Add(new SPNavigationNode(title, url, true),
                                                                                    ew.Navigation.GetNodeById(lastTopNavId));
                                            currentNode.Update();
                                            // adds the id of the newly created node
                                            // to topnav field of app item in "Installed Applications"
                                            AddAppTopNav(appId, currentNode.Id);
                                        }
                                        else
                                        {
                                            // create internal or external node dynamically
                                            currentNode = !isExternal ?
                                                // if internal "http://server/sites/dev1"
                                                ew.Navigation.TopNavigationBar.AddAsLast(new SPNavigationNode(title, url)) :
                                                // if external "www.google.com"                   
                                                ew.Navigation.TopNavigationBar.AddAsLast(new SPNavigationNode(title, url, true));
                                            currentNode.Update();
                                            // adds the id of the newly created node
                                            // to topnav field of app item in "Installed Applications"
                                            AddAppTopNav(appId, currentNode.Id);
                                        }
                                    }
                                    else
                                    {
                                        // create internal or external node dynamically
                                        currentNode = !isExternal ?
                                            // if internal "http://server/sites/dev1"
                                            ew.Navigation.TopNavigationBar.AddAsLast(new SPNavigationNode(title, url)) :
                                            // if external "www.google.com"                   
                                            ew.Navigation.TopNavigationBar.AddAsLast(new SPNavigationNode(title, url, true));
                                        currentNode.Update();
                                    }
                                    break;
                                case "quiklnch":
                                    if (appId != -1)
                                    {
                                        int lastTopNavId = GetAppTopNavLastNodeId(appId);

                                        if (lastTopNavId != -1)
                                        {
                                            // create internal or external node dynamically
                                            currentNode = !isExternal ?
                                                // if internal "http://server/sites/dev1"
                                                ew.Navigation.QuickLaunch.Add(new SPNavigationNode(title, url),
                                                                                    ew.Navigation.GetNodeById(lastTopNavId)) :
                                                // if external "www.google.com"                   
                                                ew.Navigation.QuickLaunch.Add(new SPNavigationNode(title, url, true),
                                                                                    ew.Navigation.GetNodeById(lastTopNavId));
                                            //currentNode.Update();
                                            // adds the id of the newly created node
                                            // to topnav field of app item in "Installed Applications"
                                            AddAppQuickLaunch(appId, currentNode.Id);
                                        }
                                        else
                                        {
                                            // create internal or external node dynamically
                                            currentNode = !isExternal ?
                                                // if internal "http://server/sites/dev1"
                                                ew.Navigation.QuickLaunch.AddAsLast(new SPNavigationNode(title, url)) :
                                                // if external "www.google.com"                   
                                                ew.Navigation.QuickLaunch.AddAsLast(new SPNavigationNode(title, url, true));

                                            currentNode.Update();
                                            // adds the id of the newly created node
                                            // to topnav field of app item in "Installed Applications"
                                            AddAppQuickLaunch(appId, currentNode.Id);
                                        }
                                    }
                                    else
                                    {
                                        // create internal or external node dynamically
                                        currentNode = !isExternal ?
                                            // if internal "http://server/sites/dev1"
                                            ew.Navigation.QuickLaunch.AddAsLast(new SPNavigationNode(title, url)) :
                                            // if external "www.google.com"                   
                                            ew.Navigation.QuickLaunch.AddAsLast(new SPNavigationNode(title, url, true));
                                        currentNode.Update();
                                    }
                                    break;
                            }

                            // clear EPM cache
                            try
                            {
                                EPMLiveCore.Infrastructure.CacheStore.Current.RemoveSafely(ew.Url, Infrastructure.CacheStoreCategory.Navigation);
                            }
                            catch { }
                        }

                        ew.Update();
                        ew.AllowUnsafeUpdates = false;
                    }
                }
            });
        }

        public void EditNodeById(int parentNodeId, int nodeId, string title, string url, int appId, string nodeType, SPUser origUser)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        int oldNodeId;
                        int newNodeId;
                        ew.AllowUnsafeUpdates = true;
                        SPNavigationNode eCurrentNode = ew.Navigation.GetNodeById(nodeId);
                        eCurrentNode.Url = url;
                        eCurrentNode.Title = title;
                        eCurrentNode.IsVisible = false;
                        eCurrentNode.Update();

                        if ((parentNodeId != -1) &&
                            (eCurrentNode.ParentId != parentNodeId))
                        {
                            SPNavigationNode oldParent = eCurrentNode.Parent;
                            SPNavigationNode newParent = ew.Navigation.GetNodeById(parentNodeId);

                            // create internal or external node dynamically
                            SPNavigationNode newECurrentNode = (IsUrlInternal(url)) ?
                                newParent.Children.AddAsLast(eCurrentNode) :
                                newParent.Children.AddAsLast(new SPNavigationNode(eCurrentNode.Title, eCurrentNode.Url, true));
                            newNodeId = newECurrentNode.Id;
                            oldNodeId = eCurrentNode.Id;

                            // delete original node
                            oldParent.Children.Delete(eCurrentNode);

                            SPList appList = ew.Lists.TryGetList(MultiAppNavigationResources.INSTALLED_APP_LIST_NAME);
                            if (appList != null)
                            {
                                SPListItem appItem = appList.GetItemById(appId);
                                if (appItem != null)
                                {
                                    object fv = null;
                                    string sfv = string.Empty;
                                    try
                                    {
                                        if (nodeType.ToLower() == "topnav")
                                        {
                                            fv = appItem["TopNav"];
                                        }
                                        else
                                        {
                                            fv = appItem["QuickLaunch"];
                                        }
                                    }
                                    catch { }

                                    if (fv != null)
                                    {
                                        sfv = fv.ToString();
                                    }
                                    string sClean = sfv;
                                    Hashtable hshNavs = new Hashtable();
                                    foreach (string s in sClean.Split(','))
                                    {
                                        string navId = string.Empty;
                                        string aId = string.Empty;
                                        if (s.Contains(':'))
                                        {
                                            string[] navAndAppIds = s.Split(':');
                                            navId = navAndAppIds[0];
                                            aId = navAndAppIds[1];
                                        }
                                        else
                                        {
                                            navId = s;
                                        }

                                        hshNavs.Add(navId, aId);
                                    }

                                    List<int> existingNavIds = Array.ConvertAll(sfv.Split(',').Select(s => s.Trim()).ToArray(), s => int.Parse(s.Split(':')[0])).ToList();
                                    if (existingNavIds.Contains(oldNodeId))
                                    {
                                        existingNavIds.Remove(oldNodeId);
                                    }

                                    existingNavIds.Add(newNodeId);

                                    StringBuilder sbNewIds = new StringBuilder();
                                    foreach (int id in existingNavIds)
                                    {
                                        if (hshNavs.ContainsKey(id.ToString()))
                                        {
                                            sbNewIds.Append(id.ToString() + ":" + hshNavs[id.ToString()] + ",");
                                        }
                                        else
                                        {
                                            sbNewIds.Append(id.ToString() + ",");
                                        }
                                    }

                                    //sfv = string.Join(",", Array.ConvertAll(existingNavIds.ToArray(), s => s.ToString()));
                                    sfv = sbNewIds.ToString().Trim(',');
                                    if (nodeType.ToLower() == "topnav")
                                    {
                                        appItem["TopNav"] = sfv;
                                    }
                                    else
                                    {
                                        appItem["QuickLaunch"] = sfv;
                                    }

                                    appItem.Update();
                                }
                            }
                        }

                        // clear EPM cache
                        new GenericLinkProvider(es.ID, ew.ID, origUser.LoginName).ClearCache();

                        ew.Update();
                        ew.AllowUnsafeUpdates = false;
                    }
                }
            });
        }

        public void DeleteNode(int appId, int nodeId, string nodeType, SPUser origUser)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        if (nodeId != -1)
                        {
                            ew.AllowUnsafeUpdates = true;

                            SPNavigationNode eNode = ew.Navigation.GetNodeById(nodeId);

                            switch (nodeType)
                            {
                                case "topnav":
                                    DeleteAppTopNav(appId, eNode.Id);
                                    break;
                                case "quiklnch":
                                    DeleteAppQuickLaunch(appId, eNode.Id);
                                    break;
                                default:
                                    break;
                            }
                            eNode.Delete();

                            // clear EPM cache
                            new GenericLinkProvider(es.ID, ew.ID, origUser.LoginName).ClearCache();
                        }
                    }
                }

            });

        }

        public void UpdateNodeOrder(int appId, string nodeType, string moveInfos, SPUser origUser)
        {
            // Get the moving record from html control called "MovedItems".
            // It a long string value that contains a ; separated set of integers. 
            // e.g., 2009, 0, 1; 2001, 2, 3;
            // Each set represents <parentId>, <oldIndex>, <newIndex>

            string[] movedItems = moveInfos.Split(';');
            string[] movementInfo;
            foreach (string movedItem in movedItems)
            {
                if (string.IsNullOrEmpty(movedItem))
                {
                    continue;
                }

                movementInfo = movedItem.Split(new char[] { ',' });
                // do the actual re-ordering
                MoveNode(appId, nodeType, movementInfo);
            }

            // clear EPM cache
            CacheStore.Current.RemoveCategory(CacheStoreCategory.Navigation);
        }

        private void MoveNode(int appId, string nodeType, string[] movementInfo)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite es = new SPSite(SPContext.Current.Site.ID))
                {
                    using (SPWeb ew = es.OpenWeb(SPContext.Current.Web.ID))
                    {
                        ew.AllowUnsafeUpdates = true;
                        int parentNodeID = Convert.ToInt32(movementInfo[0]);
                        int oldIndex = Convert.ToInt32(movementInfo[1]);
                        if (appId != -1)
                        {
                            // translate displayed index into real index in Web.Navigation
                            oldIndex = GetRealIndex(parentNodeID, oldIndex, appId, nodeType);
                        }
                        int newIndex = Convert.ToInt32(movementInfo[2]);
                        if (appId != -1)
                        {
                            // translate displayed index into real index in Web.Navigation
                            newIndex = GetRealIndex(parentNodeID, newIndex, appId, nodeType);
                        }

                        SPNavigationNode parentNode = ew.Navigation.GetNodeById(parentNodeID);
                        SPNavigationNodeCollection contextNodeCollection = parentNode.Children;
                        SPNavigationNode node = contextNodeCollection[oldIndex];

                        int currentlastIndex = contextNodeCollection.Count - 1;

                        if (newIndex != oldIndex)
                        {
                            if (newIndex == 0)
                            {
                                node.MoveToFirst(contextNodeCollection);
                            }
                            else if (newIndex == currentlastIndex)
                            {
                                node.MoveToLast(contextNodeCollection);
                            }
                            else
                            {
                                if (newIndex < oldIndex)
                                {
                                    node.Move(contextNodeCollection, contextNodeCollection[newIndex - 1]);
                                }
                                else
                                {
                                    node.Move(contextNodeCollection, contextNodeCollection[newIndex]);
                                }
                            }
                        }


                        // note: 
                        // when performing SPNavigationNode.(Move/MoveToFirst/MoveToLast) 
                        // SPNavigationNode.Update() is not necessary according to MSDN documents
                    }
                }
            });
        }


#region helper methods

        public bool IsUrlInternal(string url)
        {
            bool isInt = false;
            if (!url.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase)
                && !url.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase))
            {
                isInt = true;
            }
            // if url does start with http:// or https://
            else
            {
                if (url.Contains(SPContext.Current.Web.Url))
                {
                    isInt = true;
                }
            }
            return isInt;
        }

        private string GetCleanUrl(string url)
        {
            string sUrl = url;
            if (string.IsNullOrEmpty(sUrl))
            {
                return sUrl;
            }

            try
            {
                sUrl = Uri.UnescapeDataString(sUrl);
            }
            catch { }

            bool bHttp = sUrl.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase) || sUrl.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase);
            if (bHttp)
            {
                return sUrl;
            }

            bool bSlash = sUrl.StartsWith("/");
            if (!bSlash)
            {
                bool bIsTop = (SPContext.Current.Web.ServerRelativeUrl == "/");

                if (sUrl.StartsWith("sites"))
                {
                    sUrl = ("/" + sUrl);
                }
                else if (sUrl.StartsWith(SPContext.Current.Web.Title, StringComparison.CurrentCultureIgnoreCase))
                {
                    if (!bIsTop)
                    {
                        sUrl = ("/sites/" + sUrl);
                    }
                }
                else
                {
                    if (bIsTop)
                    {
                        sUrl = "/" + sUrl;
                    }
                    else
                    {
                        sUrl = SPContext.Current.Web.ServerRelativeUrl + "/" + sUrl;
                    }
                }
            }

            return sUrl;
        }

#endregion


    }
}
