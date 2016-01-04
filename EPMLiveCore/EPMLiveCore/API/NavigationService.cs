using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public class NavigationService
    {
        #region Fields (5)

        private static readonly object Locker1 = new Object();
        private static readonly object Locker2 = new Object();
        private readonly Dictionary<string, INavLinkProvider> _linkProviders;
        private readonly Dictionary<string, PropertyInfo> _navLinkProperties;
        private readonly SPWeb _spWeb;

        #endregion Fields

        #region Constructors (3)

        public NavigationService(IEnumerable<string> providers, SPWeb spWeb)
        {
            _spWeb = spWeb;
            _linkProviders = new Dictionary<string, INavLinkProvider>();
            _navLinkProperties = new Dictionary<string, PropertyInfo>();

            try
            {
                var tasks = new List<Task>();

                Task t1 = Task.Factory.StartNew(() =>
                {
                    IEnumerable<Type> types = AssemblyManager.Current.GetTypes();
                    Parallel.ForEach(providers, provider => LoadProvider(provider, types));
                });

                tasks.Add(t1);

                Task t2 = Task.Factory.StartNew(() =>
                {
                    Parallel.ForEach(typeof(SPNavLink).GetProperties(), property =>
                    {
                        lock (Locker2)
                        {
                            _navLinkProperties.Add(property.Name, typeof(SPNavLink).GetProperty(property.Name));
                        }
                    });
                });

                tasks.Add(t2);

                try
                {
                    Task.WaitAll(tasks.ToArray());
                }
                catch (AggregateException exception)
                {
                    exception.Handle(e =>
                    {
                        var loadException = e as ReflectionTypeLoadException;
                        if (loadException != null)
                        {
                            if (loadException.LoaderExceptions.Any())
                            {
                                throw loadException.LoaderExceptions.First();
                            }
                        }

                        throw e;
                    });
                }
            }
            catch (Exception exception)
            {
                throw new APIException(20000,
                    "[NavigationService] Type: " + exception.GetType() + ". Message: " + exception.Message);
            }
        }

        public NavigationService(string provider, SPWeb spWeb) : this(new[] { provider }, spWeb) { }

        public NavigationService(SPWeb spWeb)
        {
            _spWeb = spWeb;
        }

        #endregion Constructors

        #region Methods (13)

        // Public Methods (5) 

        public object GetContextualMenuItems(string data)
        {
            try
            {
                Guid siteId;
                Guid webId;
                Guid listId;
                int itemId;
                int userId;
                bool debugMode;

                GetContextualMenuItems_ParseRequest(data, out siteId, out webId, out listId, out itemId, out userId,
                    out debugMode);

                var items = new XElement("Items");

                Dictionary<string, string> diagnosticInfo;
                DataTable dataTable = GetMenuItems(siteId, webId, listId, itemId, userId, out diagnosticInfo);

                List<string> columns =
                    (from DataColumn column in dataTable.Columns select column.ColumnName).ToList();

                foreach (DataRow row in dataTable.Rows)
                {
                    var item = new XElement("Item");

                    foreach (string column in columns)
                    {
                        item.Add(new XAttribute(column, row[column]));
                    }

                    items.Add(item);
                }

                if (!debugMode) return new XElement("ContextualMenus", items).ToString();

                var di = new XElement("DiagnosticsInfo");

                foreach (var pair in diagnosticInfo)
                {
                    di.Add(new XElement(pair.Key.Replace(' ', '_'), new XCData(pair.Value)));
                }

                return new XElement("ContextualMenus", items, di).ToString();
            }
            catch (Exception exception)
            {
                throw new APIException(20003, "[NavigationService:GetContextualMenuItems] " + exception.Message);
            }
        }

        public string GetLinks()
        {
            try
            {
                var nodes = new XElement("Nodes");

                foreach (var provider in _linkProviders)
                {
                    INavLinkProvider linkProvider = provider.Value;

                    if (linkProvider == null) continue;

                    string providerName = provider.Key;

                    var node = new XElement(providerName);

                    var links = new SortedDictionary<int, NavLink>();

                    try
                    {
                        GetNavigationLinks(linkProvider, links);
                    }
                    catch
                    {
                        try
                        {
                            Thread.Sleep(1000);
                            ((NavLinkProvider)linkProvider).ClearCache();
                            GetNavigationLinks(linkProvider, links);
                        }
                        catch { }
                    }

                    if (links.Count == 0) continue;

                    foreach (var linkInfo in links)
                    {
                        NavLink navLink = linkInfo.Value;
                        navLink.Order = linkInfo.Key;
                        navLink.Id = GetLinkId(navLink, providerName);

                        var link = new XElement("NavLink");

                        foreach (var property in _navLinkProperties)
                        {
                            try
                            {
                                string name = property.Key;
                                string value = (property.Value.GetValue(navLink) ?? string.Empty).ToString().Trim();

                                if (name.Equals("Url") || name.Equals("Title"))
                                {
                                    link.Add(new XElement(name, new XCData(value)));
                                }
                                else
                                {
                                    link.Add(new XAttribute(name, value));
                                }
                            }
                            catch { }
                        }

                        node.Add(link);
                    }

                    nodes.Add(node);
                }

                return nodes.ToString();
            }
            catch (Exception exception)
            {
                throw new APIException(20001, "[NavigationService:GetLinks] " + exception.Message);
            }
        }

        public DataTable GetMenuItems(Guid siteId, Guid webId, Guid listId, int itemId, int userId,
            out Dictionary<string, string> diagnosticInfo)
        {
            var info = new Dictionary<string, string>();

            var dataTable = new DataTable();

            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("Command", typeof(string));
            dataTable.Columns.Add("ImageUrl", typeof(string));
            dataTable.Columns.Add("Kind", typeof(string));

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var site = new SPSite(siteId))
                {
                    using (SPWeb web = site.OpenWeb(webId))
                    {
                        info.Add("Web", web.Url);

                        SPUser user = web.AllUsers.GetByID(userId);
                        SPUserToken userToken = user.UserToken;

                        info.Add("Username", user.LoginName);
                        info.Add("User", user.Name);

                        Task<object[]> t1 = Task.Factory.StartNew(() =>
                        {
                            Dictionary<string, string> di;

                            var result = new Tuple<string, string, string, string, bool>[] { };

                            try
                            {
                                using (var spSite = new SPSite(siteId, userToken))
                                {
                                    using (SPWeb spWeb = spSite.OpenWeb(webId))
                                    {
                                        SPList list = spWeb.Lists.GetList(listId, true);
                                        GridGanttSettings gSettings = ListCommands.GetGridGanttSettings(list);
                                        result = GetGeneralActions(gSettings.UsePopup, list, gSettings.EnableFancyForms, out di);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                di = new Dictionary<string, string> { { "General Actions Exception", e.Message } };
                            }

                            return new object[] { result, di };
                        });

                        Task<object[]> t2 = Task.Factory.StartNew(() =>
                        {
                            Dictionary<string, string> di;

                            var result = new Tuple<string, string, string, string, bool>[] { };

                            try
                            {
                                using (var spSite = new SPSite(siteId, userToken))
                                {
                                    using (SPWeb spWeb = spSite.OpenWeb(webId))
                                    {
                                        SPList list = spWeb.Lists.GetList(listId, true);
                                        result = GetPlannerActions(list, out di);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                di = new Dictionary<string, string> { { "Planner Actions Exception", e.Message } };
                            }

                            return new object[] { result, di };
                        });

                        Task<object[]> t3 = Task.Factory.StartNew(() =>
                        {
                            Dictionary<string, string> di;

                            var result = new Tuple<string, string, string, string, bool>[] { };

                            try
                            {
                                using (var spSite = new SPSite(siteId, userToken))
                                {
                                    using (SPWeb spWeb = spSite.OpenWeb(webId))
                                    {
                                        SPList list = spWeb.Lists.GetList(listId, true);
                                        SPListItem item = list.GetItemById(itemId);

                                        result = GetSocialActions(item, ListCommands.GetGridGanttSettings(list), out di);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                di = new Dictionary<string, string> { { "Social Actions Exception", e.Message } };
                            }

                            return new object[] { result, di };
                        });

                        Task<object[]> t4 = Task.Factory.StartNew(() =>
                        {
                            Dictionary<string, string> di;

                            var result = new Tuple<string, string, string, string, bool>[] { };

                            try
                            {
                                using (var spSite = new SPSite(siteId, userToken))
                                {
                                    using (SPWeb spWeb = spSite.OpenWeb(webId))
                                    {
                                        SPList list = spWeb.Lists.GetList(listId, true);
                                        SPListItem item = list.GetItemById(itemId);

                                        result = GetWorkspaceActions(item, out di);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                di = new Dictionary<string, string> { { "Workspace Actions Exception", e.Message } };
                            }

                            return new object[] { result, di };
                        });

                        Task<object[]> t5 = Task.Factory.StartNew(() =>
                        {
                            Dictionary<string, string> di;

                            var result = new Tuple<string, string, string, string, bool>[] { };

                            try
                            {
                                using (var spSite = new SPSite(siteId, userToken))
                                {
                                    using (SPWeb spWeb = spSite.OpenWeb(webId))
                                    {
                                        SPList list = spWeb.Lists.GetList(listId, true);
                                        result = GetPFEActions(list, out di);
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                di = new Dictionary<string, string> { { "PFE Actions Exception", e.Message } };
                            }

                            return new object[] { result, di };
                        });

                        var actions = new List<Tuple<string, string, string, string, bool>>();

                        foreach (var t in new[] { t1, t2, t3, t4, t5 })
                        {
                            object[] result = t.Result;

                            var et = new Tuple<string, string, string, string, bool>(null, null, null, null, false);
                            var tuples = (Tuple<string, string, string, string, bool>[])(result[0] ?? new[] { et });

                            actions.AddRange(tuples);

                            var di = result[1] as Dictionary<string, string>;

                            if (di == null) continue;

                            foreach (var pair in di)
                            {
                                info.Add(pair.Key, pair.Value);
                            }
                        }

                        if (!actions.Any()) return;

                        string lastTitle = string.Empty;

                        Tuple<string, string, string, string, bool> lastAction = actions.Last();

                        string sepItem = lastAction.Item1;
                        if (!string.IsNullOrEmpty(sepItem) && sepItem.Equals("--SEP--"))
                        {
                            actions.Remove(lastAction);
                        }

                        foreach (var action in actions)
                        {
                            if (!action.Item5) continue;
                            if (action.Item1.Equals("--SEP--") && action.Item1.Equals(lastTitle)) continue;

                            lastTitle = action.Item1;

                            DataRow row = dataTable.NewRow();

                            row["Title"] = action.Item1;
                            row["Command"] = action.Item2;
                            row["ImageUrl"] = action.Item3;
                            row["Kind"] = action.Item4;

                            dataTable.Rows.Add(row);
                        }
                    }
                }
            });

            diagnosticInfo = info;

            return dataTable;
        }

        public void RemoveNavigationLink(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data)) return;

                var provider = new GenericLinkProvider(_spWeb.Site.ID, _spWeb.ID, _spWeb.CurrentUser.LoginName);
                provider.Remove(new Guid(data));
            }
            catch (Exception exception)
            {
                throw new APIException(20004, "[NavigationService:RemoveNavigationLink] " + exception.Message);
            }
        }

        public void ReorderLinks(string data)
        {
            try
            {
                if (string.IsNullOrEmpty(data)) return;

                var orders = new Dictionary<Guid, int>();

                foreach (
                    var parts in
                        data.Split(',')
                            .Where(link => !string.IsNullOrEmpty(link))
                            .Select(link => link.Split(':'))
                            .Where(parts => parts.Count() == 2))
                {
                    Guid id;
                    if (!Guid.TryParse(parts[0], out id) || orders.ContainsKey(id)) continue;

                    int order;
                    if (int.TryParse(parts[1], out order))
                    {
                        orders.Add(id, order);
                    }
                }

                if (!orders.Any()) return;

                var provider = new GenericLinkProvider(_spWeb.Site.ID, _spWeb.ID, _spWeb.CurrentUser.LoginName);
                provider.Reorder(orders);
            }
            catch (Exception exception)
            {
                throw new APIException(20002, "[NavigationService:ReorderLinks] " + exception.Message);
            }
        }

        // Private Methods (8) 

        private static Tuple<string, string, string, string, bool> AT(string title, string command, string imgUrl,
            bool allowed, string kind = "")
        {
            return new Tuple<string, string, string, string, bool>(title, command, imgUrl, kind, allowed);
        }

        private string CalculateLinkId(NavLink navLink, string providerName)
        {
            const string CACHE_KEY = "NavLink_ID_Dict";
            string linkKey = providerName + "|" + navLink.Order + "|" + navLink.Url;

            var dict =
                (Dictionary<string, string>)
                    CacheStore.Current.Get(CACHE_KEY, new CacheStoreCategory(_spWeb).Navigation,
                        () => new Dictionary<string, string>()).Value;

            if (dict.ContainsKey(linkKey)) return dict[linkKey];

            string linkId = linkKey.Md5();

            dict.Add(linkKey, linkId);
            CacheStore.Current.Set(CACHE_KEY, dict, new CacheStoreCategory(_spWeb).Navigation);

            return linkId;
        }

        private static void GetContextualMenuItems_ParseRequest(string data, out Guid siteId, out Guid webId,
            out Guid listId, out int itemId, out int userId, out bool debugMode)
        {
            debugMode = false;

            XDocument xmlData = XDocument.Parse(data);

            XElement root = xmlData.Root;
            if (root == null)
            {
                throw new Exception("Root element is missing.");
            }

            XElement parameters = root.Element("Params");
            if (parameters == null)
            {
                throw new Exception("GetContextualMenuItems/Params element is missing.");
            }

            XElement xSiteId = parameters.Element("SiteId");
            if (xSiteId == null)
            {
                throw new Exception("GetContextualMenuItems/Params/SiteId element is missing.");
            }

            try
            {
                siteId = Guid.Parse(xSiteId.Value);
            }
            catch (Exception exception)
            {
                throw new Exception("(SiteId) " + exception.Message);
            }

            XElement xWebId = parameters.Element("WebId");
            if (xWebId == null)
            {
                throw new Exception("GetContextualMenuItems/Params/WebId element is missing.");
            }

            try
            {
                webId = Guid.Parse(xWebId.Value);
            }
            catch (Exception exception)
            {
                throw new Exception("(WebId) " + exception.Message);
            }

            XElement xListId = parameters.Element("ListId");
            if (xListId == null)
            {
                throw new Exception("GetContextualMenuItems/Params/ListId element is missing.");
            }

            try
            {
                listId = Guid.Parse(xListId.Value);
            }
            catch (Exception exception)
            {
                throw new Exception("(ListId) " + exception.Message);
            }

            XElement xItemId = parameters.Element("ItemId");
            if (xItemId == null)
            {
                throw new Exception("GetContextualMenuItems/Params/ItemId element is missing.");
            }

            try
            {
                itemId = int.Parse(xItemId.Value);
            }
            catch (Exception exception)
            {
                throw new Exception("(ItemId) " + exception.Message);
            }

            XElement xUserId = parameters.Element("UserId");
            if (xUserId == null)
            {
                throw new Exception("GetContextualMenuItems/Params/UserId element is missing.");
            }

            try
            {
                userId = int.Parse(xUserId.Value);
            }
            catch (Exception exception)
            {
                throw new Exception("(UserId) " + exception.Message);
            }

            XElement xDebugMode = parameters.Element("DebugMode");
            if (xDebugMode == null) return;

            try
            {
                debugMode = bool.Parse(xDebugMode.Value);
            }
            catch { }
        }

        private string GetLinkId(NavLink navLink, string providerName)
        {
            return navLink.Id ?? CalculateLinkId(navLink, providerName);
        }

        private static void GetNavigationLinks(INavLinkProvider linkProvider, SortedDictionary<int, NavLink> links)
        {
            foreach (NavLink link in linkProvider.GetLinks())
            {
                int order = link.Order;

                if (order == 0)
                {
                    order = links.Count == 0 ? 1 : links.Keys.Max() + 1;
                }

                links.Add(order, link);
            }
        }

        private static bool LIP(SPListItem listItem, SPBasePermissions spBasePermissions)
        {
            return listItem.DoesUserHavePermissions(spBasePermissions);
        }

        private void LoadProvider(string provider, IEnumerable<Type> types)
        {
            provider = provider.Trim();
            string key = provider.ToUpper();

            Guid sId = _spWeb.Site.ID;
            Guid wId = _spWeb.ID;
            string un = _spWeb.CurrentUser.LoginName;

            object navProvider = (from type in types
                                  where type.GetInterfaces().Contains(typeof(INavLinkProvider))
                                  from NavLinkProviderInfoAttribute attribute in
                                      type.GetCustomAttributes(typeof(NavLinkProviderInfoAttribute), false)
                                  where attribute.Name.ToUpper().Equals(key)
                                  select Activator.CreateInstance(type, new object[] { sId, wId, un })).FirstOrDefault();

            if (navProvider == null) return;

            lock (Locker1)
            {
                _linkProviders.Add(provider, navProvider as INavLinkProvider);
            }
        }

        private static bool LP(SPList list, SPBasePermissions spBasePermissions)
        {
            return list.DoesUserHavePermissions(spBasePermissions);
        }

        private static bool LPPFEPermissionCheck(SPList list, SPBasePermissions spBasePermissions)
        {
            bool hasPFEResourceCenterPermissions = true;
            try
            {
                if (list != null)
                {
                    switch (spBasePermissions)
                    {
                        case SPBasePermissions.AddListItems:
                            {
                                if (list.DoesUserHavePermissions(SPBasePermissions.AddListItems))
                                {
                                    var args = new object[] { list.ParentWeb, list.ParentWeb.CurrentUser.ID, false, hasPFEResourceCenterPermissions };
                                    Assembly assembly = Assembly.Load("WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                                    Type type = assembly.GetType("WorkEnginePPM.Core.ResourceManagement.Utilities", true, true);
                                    type.GetMethod("CheckPFEResourceCenterPermission", BindingFlags.Public | BindingFlags.Static).Invoke(null, args);

                                    hasPFEResourceCenterPermissions = Convert.ToBoolean(args[3]);
                                    return hasPFEResourceCenterPermissions;
                                }
                            }
                            break;
                        case SPBasePermissions.EditListItems:
                            {
                                if (list.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                                {
                                    var args = new object[] { list.ParentWeb, list.ParentWeb.CurrentUser.ID, false, hasPFEResourceCenterPermissions };
                                    Assembly assembly = Assembly.Load("WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                                    Type type = assembly.GetType("WorkEnginePPM.Core.ResourceManagement.Utilities", true, true);
                                    type.GetMethod("CheckPFEResourceCenterPermission", BindingFlags.Public | BindingFlags.Static).Invoke(null, args);

                                    hasPFEResourceCenterPermissions = Convert.ToBoolean(args[3]);
                                    return hasPFEResourceCenterPermissions;
                                }
                            }
                            break;
                        case SPBasePermissions.DeleteListItems:
                            {
                                if (list.DoesUserHavePermissions(SPBasePermissions.DeleteListItems))
                                {
                                    var args = new object[] { list.ParentWeb, list.ParentWeb.CurrentUser.ID, true, hasPFEResourceCenterPermissions };
                                    Assembly assembly = Assembly.Load("WorkEnginePPM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9f4da00116c38ec5");
                                    Type type = assembly.GetType("WorkEnginePPM.Core.ResourceManagement.Utilities", true, true);
                                    type.GetMethod("CheckPFEResourceCenterPermission", BindingFlags.Public | BindingFlags.Static).Invoke(null, args);

                                    hasPFEResourceCenterPermissions = Convert.ToBoolean(args[3]);

                                    return hasPFEResourceCenterPermissions;
                                }
                            }
                            break;
                    }


                    return false;
                }
            }
            catch
            {
                //No need to handle this exception because If PFE is not configured on Share Point site then also It should show Invite button.
                //Hence, Rather then setting hasPFEResourceCenterPermissions = false; Keeping this exception block blank.
                return true;
            }
            return true;
            return list.DoesUserHavePermissions(spBasePermissions);
        }

        #endregion Methods

        private Tuple<string, string, string, string, bool>[] GetPFEActions(SPList list,
            out Dictionary<string, string> di)
        {
            bool success = true;
            di = new Dictionary<string, string> { { "PFE Actions", true.ToString() } };

            var actions = new List<Tuple<string, string, string, string, bool>>();

            try
            {
                SPWeb web = list.ParentWeb;
                if (web.Site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] == null) return null;

                di.Add("PFE Feature Enabled", true.ToString());

                SPWeb rootWeb = web.Site.RootWeb;

                string epkLists = CoreFunctions.getConfigSetting(rootWeb, "EPKLists").ToLower();
                string[] pfeLists = epkLists.Split(',');

                di.Add("EPK Lists", epkLists);

                string listTitle = list.Title;

                if (!pfeLists.Contains(listTitle.ToLower())) return null;

                actions = new List<Tuple<string, string, string, string, bool>>
                {
                    AT("--SEP--", null, null, true)
                };

                string menus = CoreFunctions.getConfigSetting(rootWeb,
                    "EPK" + listTitle.Replace(" ", string.Empty) + "_menus");

                if (string.IsNullOrEmpty(menus))
                {
                    menus = CoreFunctions.getConfigSetting(rootWeb, "EPKMenus");
                }

                di.Add("PFE Menus", menus);

                if (string.IsNullOrEmpty(menus))
                {
                    di.Add("PFE Actions Success", true.ToString());

                    return actions.ToArray();
                }

                string[] buttons = menus.Split('|');

                actions.Add(AT("PI Details", "epkcommand:Details", "/_layouts/images/edititem.gif",
                    buttons.Contains("details")));

                actions.Add(AT("Edit Costs", "epkcommand:Costs", "/_layouts/epmlive/images/editcosts16.png",
                    buttons.Contains("costs"), "6"));

                actions.Add(AT("Work Planner", "epkcommand:workplan", "/_layouts/epmlive/images/workitems.gif",
                    buttons.Contains("workplan"), "6"));

                actions.Add(AT("Edit Resource Plan", "epkcommand:rpeditor", "/_layouts/epmlive/images/resplan.gif",
                    buttons.Contains("resplan"), "6"));
            }
            catch (Exception e)
            {
                success = false;
                di.Add("PFE Actions Exception", e.Message);
            }

            di.Add("PFE Actions Success", success.ToString());

            return actions.ToArray();
        }

        private Tuple<string, string, string, string, bool>[] GetSocialActions(SPListItem listItem,
            GridGanttSettings settings, out Dictionary<string, string> di)
        {
            bool success = true;
            di = new Dictionary<string, string> { { "Social Actions", true.ToString() } };

            var actions = new Tuple<string, string, string, string, bool>[] { };

            try
            {
                actions = new[]
                {
                    AT("Comments", "comments", "/_layouts/epmlive/images/comments16.gif",
                        LIP(listItem, SPBasePermissions.EditListItems), "5"),
                    AT("Edit Team", "buildteam", "/_layouts/epmlive/images/buildteam16.gif",
                        LIP(listItem, SPBasePermissions.EditListItems) && settings.BuildTeam, "6")
                };
            }
            catch (Exception e)
            {
                success = false;
                di.Add("Social Actions Exception", e.Message);
            }

            di.Add("Social Actions Success", success.ToString());

            return actions;
        }

        private Tuple<string, string, string, string, bool>[] GetWorkspaceActions(SPListItem li,
            out Dictionary<string, string> di)
        {
            bool success = true;
            di = new Dictionary<string, string> { { "Workspace Actions", true.ToString() } };

            var actions = new List<Tuple<string, string, string, string, bool>>();

            try
            {
                string url = string.Empty;

                try
                {
                    url = li["WorkspaceUrl"].ToString();
                }
                catch { }

                actions.Add(AT("Go To Workspace", "workspace", "/_layouts/images/STSICON.gif",
                    !string.IsNullOrEmpty(url), "1"));

                string childitem = string.Empty;

                try
                {
                    childitem = li["ChildItem"].ToString();
                }
                catch { }

                bool allowed = ListCommands.GetGridGanttSettings(li.ParentList).EnableRequests &&
                               string.IsNullOrEmpty(url) && (li.ModerationInformation == null ||
                                                             li.ModerationInformation.Status ==
                                                             SPModerationStatusType.Approved)
                               && li.Web.ID == _spWeb.ID && string.IsNullOrEmpty(childitem);

                actions.Add(AT("Create Workspace", "createworkspace", "/_layouts/images/STSICON.gif", allowed, "1"));
            }
            catch (Exception e)
            {
                success = false;
                di.Add("Workspace Actions Exception", e.Message);
            }

            di.Add("Workspace Actions Success", success.ToString());

            return actions.ToArray();
        }


        private static Tuple<string, string, string, string, bool>[] GetGeneralActions(bool usePopup, SPList list, bool bfancyforms, out Dictionary<string, string> di)
        {
            bool success = true;

            di = new Dictionary<string, string> { { "Item Actions", true.ToString() } };

            var actions = new Tuple<string, string, string, string, bool>[] { };

            try
            {
                if (list.Title == "Resources")
                {
                    actions = new[]
                        {
                            AT("View Item", "view", "/_layouts/images/blank.gif", LP(list, SPBasePermissions.ViewListItems), usePopup ? (bfancyforms ? "6" : "5") : "1"),
                            AT("Edit Item", "edit", "/_layouts/images/edititem.gif", LPPFEPermissionCheck(list, SPBasePermissions.EditListItems), usePopup ? (bfancyforms ? "6" : "5") : "1"),
                            AT("--SEP--", null, null, true),
                            AT("Approve Item", "approve", "/_layouts/images/apprj.gif", list.EnableModeration && LP(list, SPBasePermissions.ApproveItems)),
                            AT("Workflows", "workflows", "/_layouts/images/workflows.gif", list.WorkflowAssociations.Count > 0,
                                "1"),
                            AT("--SEP--", null, null, true),
                            AT("Permissions", "perms", "/_layouts/images/permissions16.png",
                                LP(list, SPBasePermissions.ManagePermissions), "0"),
                            AT("Delete Item", "delete", "/_layouts/images/delitem.gif",
                                LPPFEPermissionCheck(list, SPBasePermissions.DeleteListItems),
                                "99"),
                            AT("--SEP--", null, null, true)
                        };
                }
                else
                {
                    actions = new[]
                    {
                        AT("View Item", "view", "/_layouts/images/blank.gif", LP(list, SPBasePermissions.ViewListItems), usePopup ? (bfancyforms ? "6" : "5") : "1"),
                        AT("Edit Item", "edit", "/_layouts/images/edititem.gif", LP(list, SPBasePermissions.EditListItems), usePopup ? (bfancyforms ? "6" : "5") : "1"),
                        AT("--SEP--", null, null, true),
                        AT("Approve Item", "approve", "/_layouts/images/apprj.gif", list.EnableModeration && LP(list, SPBasePermissions.ApproveItems)),
                        AT("Workflows", "workflows", "/_layouts/images/workflows.gif", list.WorkflowAssociations.Count > 0,
                            "1"),
                        AT("--SEP--", null, null, true),
                        AT("Permissions", "perms", "/_layouts/images/permissions16.png",
                            LP(list, SPBasePermissions.ManagePermissions), "0"),
                        AT("Delete Item", "delete", "/_layouts/images/delitem.gif",
                            LP(list, SPBasePermissions.DeleteListItems),
                            "99"),
                        AT("--SEP--", null, null, true)
                    };
                }
            }
            catch (Exception e)
            {
                success = false;
                di.Add("Item Actions Exception", e.Message);
            }

            di.Add("Item Actions Success", success.ToString());

            return actions;
        }

        private Tuple<string, string, string, string, bool>[] GetPlannerActions(SPList list,
            out Dictionary<string, string> di)
        {
            bool success = true;
            di = new Dictionary<string, string> { { "Planner Actions", true.ToString() } };

            var actions = new Tuple<string, string, string, string, bool>[] { };

            try
            {
                string listTitle = list.Title;
                SPWeb spWeb = list.ParentWeb;

                Dictionary<string, PlannerDefinition> planners = CoreFunctions.GetPlannerList(spWeb, null);

                string command = string.Empty;

                foreach (PlannerDefinition planner in planners.Select(p => p.Value))
                {
                    if (planner.commandPrefix.Equals(listTitle))
                    {
                        command = "gotoplanner";
                        break;
                    }

                    if (planner.command.Equals(listTitle))
                    {
                        command = "GoToTaskPlanner";
                        break;
                    }
                }

                actions = string.IsNullOrEmpty(command)
                    ? null
                    : new[] { AT("Edit Plan", command, "/_layouts/epmlive/images/planner16.png", true, "1") };
            }
            catch (Exception e)
            {
                success = false;
                di.Add("Planner Actions Exception", e.Message);
            }

            di.Add("Planner Actions Success", success.ToString());

            return actions;
        }
    }
}