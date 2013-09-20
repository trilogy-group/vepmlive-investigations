using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
                    Parallel.ForEach(typeof (SPNavLink).GetProperties(), property =>
                    {
                        lock (Locker2)
                        {
                            _navLinkProperties.Add(property.Name, typeof (SPNavLink).GetProperty(property.Name));
                        }
                    });
                });

                tasks.Add(t2);

                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception exception)
            {
                throw new APIException(20000, "[NavigationService] " + exception.Message);
            }
        }

        public NavigationService(string provider, SPWeb spWeb) : this(new[] {provider}, spWeb) { }

        public NavigationService(SPWeb spWeb)
        {
            _spWeb = spWeb;
        }

        #endregion Constructors 

        #region Methods (12) 

        // Public Methods (5) 

        public object GetContextualMenuItems(string data)
        {
            try
            {
                Guid siteId;
                Guid webId;
                Guid listId;
                int itemId;
                bool rollups;
                bool requestList;
                bool usePopup;

                GetContextualMenuItems_ParseRequest(data, out siteId, out webId, out listId, out itemId, out rollups,
                    out requestList, out usePopup);

                var items = new XElement("Items");

                DataTable dataTable = GetMenuItems(siteId, webId, listId, itemId, rollups, requestList, usePopup);

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

                return items.ToString();
            }
            catch (Exception exception)
            {
                string message = string.Empty;

                try
                {
                    message = exception.InnerException.Message;
                }
                catch { }

                throw new APIException(20003, "[NavigationService:GetContextualMenuItems] " + exception.Message + " Inner Message: " + message);
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
                    catch { }

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

                                if (name.Equals("Url"))
                                {
                                    link.Add(new XCData(value));
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

        public DataTable GetMenuItems(Guid siteId, Guid webId, Guid listId, int itemId, bool rollups = false,
            bool requestList = false, bool usePopup = false)
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add("Title", typeof (string));
            dataTable.Columns.Add("Command", typeof (string));
            dataTable.Columns.Add("ImageUrl", typeof (string));
            dataTable.Columns.Add("Kind", typeof (string));

            using (var spSite = new SPSite(siteId))
            {
                using (SPWeb spWeb = spSite.OpenWeb(webId))
                {
                    SPList list = spWeb.Lists.GetList(listId, true);
                    SPListItem item = list.GetItemById(itemId);

                    var settings = new GridGanttSettings(list);

                    Task<Tuple<string, string, string, string, bool>[]> t1 =
                        Task.Factory.StartNew(() => GetGeneralActions(usePopup, list));

                    Task<Tuple<string, string, string, string, bool>[]> t2 =
                        Task.Factory.StartNew(() => GetPlannerActions(list));

                    Task<Tuple<string, string, string, string, bool>[]> t3 =
                        Task.Factory.StartNew(() => GetSocialActions(item, settings));

                    Task<Tuple<string, string, string, string, bool>[]> t4 =
                        Task.Factory.StartNew(() => GetWorkspaceActions(item, rollups, requestList));

                    Task<Tuple<string, string, string, string, bool>[]> t5 =
                        Task.Factory.StartNew(() => GetPFEActions(list));

                    List<Tuple<string, string, string, string, bool>> actions = new[] {t1, t2, t3, t4, t5}
                        .SelectMany(t => t.Result ?? new Tuple<string, string, string, string, bool>[] {}).ToList();

                    string lastTitle = string.Empty;

                    Tuple<string, string, string, string, bool> lastAction = actions.Last();
                    if (lastAction.Item1.Equals("--SEP--"))
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

        // Private Methods (7) 

        private static Tuple<string, string, string, string, bool> AT(string title, string command, string imgUrl,
            bool allowed, string kind = "")
        {
            return new Tuple<string, string, string, string, bool>(title, command, imgUrl, kind, allowed);
        }

        private static string CalculateLinkId(NavLink navLink, string providerName)
        {
            const string CACHE_KEY = "NavLink_ID_Dict";
            string linkKey = providerName + "|" + navLink.Order + "|" + navLink.Url;

            var dict =
                (Dictionary<string, string>)
                    CacheStore.Current.Get(CACHE_KEY, CacheStoreCategory.Navigation,
                        () => new Dictionary<string, string>()).Value;

            if (dict.ContainsKey(linkKey)) return dict[linkKey];

            string linkId = linkKey.Md5();

            dict.Add(linkKey, linkId);
            CacheStore.Current.Set(CACHE_KEY, dict, CacheStoreCategory.Navigation);

            return linkId;
        }

        private static void GetContextualMenuItems_ParseRequest(string data, out Guid siteId, out Guid webId,
            out Guid listId, out int itemId, out bool rollups, out bool requestList, out bool usePopup)
        {
            rollups = false;
            requestList = false;
            usePopup = false;

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

            XElement xRollups = parameters.Element("Rollups");
            if (xRollups != null)
            {
                try
                {
                    rollups = bool.Parse(xRollups.Value);
                }
                catch { }
            }

            XElement xRequestList = parameters.Element("RequestList");
            if (xRequestList != null)
            {
                try
                {
                    requestList = bool.Parse(xRequestList.Value);
                }
                catch { }
            }

            XElement xUsePopup = parameters.Element("Popup");
            if (xUsePopup == null) return;

            try
            {
                usePopup = bool.Parse(xUsePopup.Value);
            }
            catch { }
        }

        private static string GetLinkId(NavLink navLink, string providerName)
        {
            return navLink.Id ?? CalculateLinkId(navLink, providerName);
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
                where type.GetInterfaces().Contains(typeof (INavLinkProvider))
                from NavLinkProviderInfoAttribute attribute in
                    type.GetCustomAttributes(typeof (NavLinkProviderInfoAttribute), false)
                where attribute.Name.ToUpper().Equals(key)
                select Activator.CreateInstance(type, new object[] {sId, wId, un})).FirstOrDefault();

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

        #endregion Methods 

        private Tuple<string, string, string, string, bool>[] GetPFEActions(SPList list)
        {
            SPWeb web = list.ParentWeb;
            if (web.Site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] == null) return null;

            SPWeb rootWeb = web.Site.RootWeb;

            string[] pfeLists = CoreFunctions.getConfigSetting(rootWeb, "EPKLists").ToLower().Split(',');

            string listTitle = list.Title;

            if (!pfeLists.Contains(listTitle.ToLower())) return null;

            var actions = new List<Tuple<string, string, string, string, bool>>
            {
                AT("--SEP--", null, null, true)
            };

            string menus = CoreFunctions.getConfigSetting(rootWeb,
                "EPK" + listTitle.Replace(" ", string.Empty) + "_menus");

            if (string.IsNullOrEmpty(menus))
            {
                CoreFunctions.getConfigSetting(rootWeb, "EPKMenus");
            }

            if (string.IsNullOrEmpty(menus)) return actions.ToArray();

            string[] buttons = menus.Split('|');

            actions.Add(AT("PI Details", "epkcommand:Details", "/_layouts/images/edititem.gif",
                buttons.Contains("details")));

            actions.Add(AT("Edit Costs", "epkcommand:Costs", "/_layouts/epmlive/images/editcosts16.png",
                buttons.Contains("costs"), "6"));

            actions.Add(AT("Work Planner", "epkcommand:workplan", "/_layouts/epmlive/images/workitems.gif",
                buttons.Contains("workplan"), "6"));

            actions.Add(AT("Edit Resource Plan", "epkcommand:rpeditor", "/_layouts/epmlive/images/resplan.gif",
                buttons.Contains("resplan"), "6"));

            return actions.ToArray();
        }

        private Tuple<string, string, string, string, bool>[] GetSocialActions(SPListItem listItem,
            GridGanttSettings settings)
        {
            var actions = new[]
            {
                AT("Comments", "comments", "/_layouts/epmlive/images/comments16.gif",
                    LIP(listItem, SPBasePermissions.EditListItems), "5"),
                AT("Edit Team", "buildteam", "/_layouts/epmlive/images/buildteam16.gif",
                    LIP(listItem, SPBasePermissions.EditListItems) && settings.BuildTeam, "6")
            };

            return actions;
        }

        private Tuple<string, string, string, string, bool>[] GetWorkspaceActions(SPListItem li, bool rollups,
            bool requestList)
        {
            var actions = new List<Tuple<string, string, string, string, bool>>();

            if (rollups && li.Web.ID != _spWeb.ID)
            {
                actions.Add(AT("Go To Workspace", "workspace", "/_layouts/images/STSICON.gif", true, "1"));
            }
            else if (requestList)
            {
                string url = string.Empty;

                try
                {
                    url = li["WorkspaceUrl"].ToString();
                }
                catch { }

                actions.Add(AT("Go To Workspace", "workspace", "/_layouts/images/STSICON.gif",
                    !string.IsNullOrEmpty(url), "1"));
            }

            if (!requestList) return actions.ToArray();

            string childitem = string.Empty;

            try
            {
                childitem = li["ChildItem"].ToString();
            }
            catch { }

            bool allowed = (li.ModerationInformation == null ||
                            li.ModerationInformation.Status == SPModerationStatusType.Approved) &&
                           li.Web.ID == _spWeb.ID && string.IsNullOrEmpty(childitem);

            actions.Add(AT("Create Workspace", "createworkspace", "/_layouts/images/STSICON.gif", allowed, "1"));

            return actions.ToArray();
        }

        private static Tuple<string, string, string, string, bool>[] GetGeneralActions(bool usePopup, SPList list)
        {
            var actions = new[]
            {
                AT("View Item", "view", "/_layouts/images/blank.gif", LP(list, SPBasePermissions.ViewListItems),
                    usePopup ? "1" : string.Empty),
                AT("Edit Item", "edit", "/_layouts/images/edititem.gif", LP(list, SPBasePermissions.EditListItems),
                    usePopup ? "1" : string.Empty),
                AT("--SEP--", null, null, true),
                AT("Approve Item", "approve", "/_layouts/images/apprj.gif",
                    list.EnableModeration && LP(list, SPBasePermissions.ApproveItems)),
                AT("Workflows", "workflows", "/_layouts/images/workflows.gif", list.WorkflowAssociations.Count > 0,
                    "1"),
                AT("--SEP--", null, null, true),
                AT("Permissions", "perms", "/_layouts/images/permissions16.png",
                    LP(list, SPBasePermissions.ManagePermissions), "1"),
                AT("Delete Item", "delete", "/_layouts/images/delitem.gif",
                    LP(list, SPBasePermissions.DeleteListItems),
                    "99"),
                AT("--SEP--", null, null, true)
            };

            return actions;
        }

        private Tuple<string, string, string, string, bool>[] GetPlannerActions(SPList list)
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

                if (!planner.command.Equals(listTitle)) continue;

                command = "GoToTaskPlanner";
                break;
            }

            return string.IsNullOrEmpty(command)
                ? null
                : new[] {AT("Edit Plan", "gotoplanner", "/_layouts/epmlive/images/planner16.png", true, "1")};
        }
    }
}