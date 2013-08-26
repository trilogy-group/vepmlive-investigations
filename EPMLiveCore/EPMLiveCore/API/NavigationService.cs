using System;
using System.Collections.Generic;
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

        #region Constructors (2) 

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

        #endregion Constructors 

        #region Methods (4) 

        // Public Methods (1) 

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

        // Private Methods (3) 

        private static string CalculateLinkId(NavLink navLink, string providerName)
        {
            string key = providerName + "|" + navLink.Order + "|" + navLink.Url;
            return (string) CacheStore.Current.Get(key, CacheStoreCategory.Navigation, key.Md5).Value;
        }

        private static string GetLinkId(NavLink navLink, string providerName)
        {
            return navLink.Id ?? CalculateLinkId(navLink, providerName);
        }

        private void LoadProvider(string provider, IEnumerable<Type> types)
        {
            provider = provider.Trim();
            string key = provider.ToUpper();
            string cacheKey = "NAVIGATION_PROVIDER_" + key;

            Guid sId = _spWeb.Site.ID;
            Guid wId = _spWeb.ID;
            string un = _spWeb.CurrentUser.LoginName;

            object navProvider =
                CacheStore.Current.Get(cacheKey, CacheStoreCategory.Navigation, () => (from type in types
                    where type.GetInterfaces().Contains(typeof (INavLinkProvider))
                    from NavLinkProviderInfoAttribute attribute in
                        type.GetCustomAttributes(typeof (NavLinkProviderInfoAttribute), false)
                    where attribute.Name.ToUpper().Equals(key)
                    select Activator.CreateInstance(type, new object[] {sId, wId, un})).FirstOrDefault(), true).Value;

            if (navProvider == null) return;

            lock (Locker1)
            {
                _linkProviders.Add(provider, navProvider as INavLinkProvider);
            }
        }

        #endregion Methods 
    }
}