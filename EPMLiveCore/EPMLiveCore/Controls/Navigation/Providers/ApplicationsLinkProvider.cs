using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.Infrastructure.Navigation;
using Microsoft.SharePoint;

namespace EPMLiveCore.Controls.Navigation.Providers
{
    [NavLinkProviderInfo(Name = "Applications")]
    public class ApplicationsLinkProvider : NavLinkProvider
    {
        #region Fields (1) 

        private readonly string _key;

        #endregion Fields 

        #region Constructors (1) 

        public ApplicationsLinkProvider(Guid siteId, Guid webId, string username) : base(siteId, webId, username)
        {
            _key = "NavLinks_Applications_W_" + WebId + "_U_" + UserId;
        }

        #endregion Constructors 

        #region Overrides of NavLinkProvider

        protected override string Key
        {
            get { return _key; }
        }

        public override IEnumerable<INavObject> GetLinks()
        {
            return (IEnumerable<INavObject>) CacheStore.Current.Get(_key, CacheStoreCategory.Navigation, () =>
            {
                var links = new List<NavLink>
                {
                    new NavLink
                    {
                        Title = "Create New",
                        Url = "Header"
                    },
                    new NavLink
                    {
                        Title = "Create App",
                        Url = string.Format(@"http://market.epmlive.com/?source={0}", Url),
                        External = true,
                        CssClass = "epm-nav-button icon-cube"
                    }
                };

                GetListLibLinks(links);

                return links;
            }).Value;
        }

        private void GetListLibLinks(List<NavLink> links)
        {
            var lists = new Dictionary<int, string[]>();
            var libraries = new Dictionary<int, string[]>();

            var tasks = new List<Task>();

            Task t1 = Task.Factory.StartNew(() =>
            {
                using (var spSite = new SPSite(SiteId, GetUserToken()))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(WebId))
                    {
                        lists = CreateNewAjaxDataHost.GetCreatableLists(spWeb);
                    }
                }
            });

            tasks.Add(t1);

            Task t2 = Task.Factory.StartNew(() =>
            {
                using (var spSite = new SPSite(SiteId, GetUserToken()))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(WebId))
                    {
                        libraries = CreateNewAjaxDataHost.GetCreatableLibraries(spWeb);
                    }
                }
            });

            tasks.Add(t2);

            Task.WaitAll(tasks.ToArray());

            links.Add(new NavLink {Title = "Apps", Url = "Header"});

            links.AddRange(lists.Select(list => list.Value).Select(l => new NavLink
            {
                Title = l[1],
                Url = GetUrl(l)
            }));

            links.Add(new NavLink {Title = "Libraries", Url = "Header"});

            links.AddRange(libraries.Select(lib => lib.Value).Select(l => new NavLink
            {
                Title = l[1],
                Url = GetUrl(l)
            }));
        }

        private static string GetUrl(string[] info)
        {
            string url = !string.IsNullOrEmpty(info[4]) ? info[4] : string.Empty;

            url = new[]
            {
                new Tuple<string, string>("javascript:window.location.href='", string.Empty),
                new Tuple<string, string>("source=", "source={page}"),
                new Tuple<string, string>("'; return false;", string.Empty)
            }.Aggregate(url, (current, p) => current.Replace(p.Item1, p.Item2));

            return string.Format("javascript:OpenCreateWebPageDialog('{0}');", url.Trim());
        }

        #endregion
    }
}