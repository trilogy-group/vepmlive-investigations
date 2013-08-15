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

                    Parallel.ForEach(providers, provider =>
                    {
                        provider = provider.Trim();
                        string key = provider.ToUpper();

                        foreach (Type type in from t in types
                            where t.BaseType == typeof (INavLinkProvider)
                            let atr = t.GetCustomAttributes(typeof (NavLinkProviderInfoAttribute), false)
                            where atr.Cast<NavLinkProviderInfoAttribute>().Any(a => a.Name.ToUpper().Equals(key))
                            select t)
                        {
                            lock (Locker1)
                            {
                                _linkProviders.Add(provider,
                                    (INavLinkProvider) Activator.CreateInstance(type, new object[] {_spWeb}));
                            }
                        }
                    });
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

        public string GetLinks()
        {
            try
            {
                var nodes = new XElement("Nodes");

                Parallel.ForEach(_linkProviders, provider =>
                {
                    var node = new XElement(provider.Key);

                    foreach (NavLink navLink in provider.Value.GetLinks())
                    {
                        var link = new XElement("NavLink");

                        foreach (var property in _navLinkProperties)
                        {
                            string name = property.Key;
                            string value = (property.Value.GetValue(navLink) as string) ?? string.Empty;

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
    }
}