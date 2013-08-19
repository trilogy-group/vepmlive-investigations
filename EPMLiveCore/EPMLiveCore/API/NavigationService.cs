using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public class NavigationService
    {
        private static readonly object Locker1 = new Object();
        private static readonly object Locker2 = new Object();
        private readonly Dictionary<string, INavLinkProvider> _linkProviders;
        private readonly Dictionary<string, PropertyInfo> _navLinkProperties;
        private readonly SPWeb _spWeb;

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
                    Parallel.ForEach(typeof (NavLink).GetProperties(), property =>
                    {
                        lock (Locker2)
                        {
                            _navLinkProperties.Add(property.Name, typeof (NavLink).GetProperty(property.Name));
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

        private void LoadProvider(string provider, IEnumerable<Type> types)
        {
            provider = provider.Trim();
            string key = provider.ToUpper();
            string cacheKey = "NAVIGATION_PROVIDER_" + key;

            var cachedProvider = CacheStore.Current.Get(cacheKey);
            object navProvider = cachedProvider == null ? null : cachedProvider.Value;

            if (navProvider == null)
            {
                foreach (Type t in from t in types.AsParallel()
                    where t.GetInterfaces().Contains(typeof (INavLinkProvider))
                    let atr = t.GetCustomAttributes(typeof (NavLinkProviderInfoAttribute), false)
                    where atr.Cast<NavLinkProviderInfoAttribute>().Any(a => a.Name.ToUpper().Equals(key))
                    select t)
                {
                    navProvider = Activator.CreateInstance(t, new object[] {_spWeb});
                    CacheStore.Current.Set(cacheKey, navProvider);
                    break;
                }
            }

            lock (Locker1)
            {
                _linkProviders.Add(provider, (INavLinkProvider) navProvider);
            }
        }

        public string GetLinks()
        {
            try
            {
                var nodes = new XElement("Nodes");

                Parallel.ForEach(_linkProviders, provider =>
                {
                    INavLinkProvider linkProvider = provider.Value;

                    if (linkProvider == null) return;

                    string providerName = provider.Key;

                    var node = new XElement(providerName);

                    var links = new SortedDictionary<int, NavLink>();

                    foreach (NavLink link in linkProvider.GetLinks())
                    {
                        int order = link.Order;

                        if (order == 0)
                        {
                            order = links.Count == 0 ? 1 : links.Keys.Max() + 1;
                        }

                        links.Add(order, link);
                    }

                    foreach (var linkInfo in links)
                    {
                        NavLink navLink = linkInfo.Value;
                        navLink.Order = linkInfo.Key;
                        navLink.Id = GetLinkId(navLink, providerName);

                        var link = new XElement("NavLink");

                        foreach (var property in _navLinkProperties)
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

                        node.Add(link);
                    }

                    lock (Locker1)
                    {
                        nodes.Add(node);
                    }
                });

                return nodes.ToString();
            }
            catch (Exception exception)
            {
                throw new APIException(20001, "[NavigationService:GetLinks] " + exception.Message);
            }
        }

        private static string GetLinkId(NavLink navLink, string providerName)
        {
            return navLink.Id ?? CalculateLinkId(navLink, providerName);
        }

        private static string CalculateLinkId(NavLink navLink, string providerName)
        {
            string key = providerName + "|" + navLink.Order + "|" + navLink.Url;

            var cachedId=CacheStore.Current.Get(key);
            if (cachedId != null) return (string) cachedId.Value;

            var id = key.Md5();
            CacheStore.Current.Set(key, id);

            return id;
        }
    }
}