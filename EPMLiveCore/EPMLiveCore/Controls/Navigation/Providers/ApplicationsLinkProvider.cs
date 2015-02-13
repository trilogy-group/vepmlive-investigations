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
            return (IEnumerable<INavObject>) CacheStore.Current.Get(_key, new CacheStoreCategory(Web).Navigation, () =>
            {
                var links = new List<NavLink>
                {
                    new NavLink
                    {
                        Title = "Create New",
                        Url = "Header"
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

            string appStoreLink = string.Empty;

            var tasks = new List<Task>();

            Task t1 = Task.Factory.StartNew(() =>
            {
                using (var spSite = new SPSite(SiteId, GetUserToken()))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(WebId))
                    {
                        if (spWeb.DoesUserHavePermissions(SPBasePermissions.ManageWeb))
                        {
                            appStoreLink =
                                string.Format(
                                    "<span class='epm-app-btn' data-url='{0}'><span class='fui-plus'></span></span>",
                                    string.Format("{0}/_layouts/15/addanapp.aspx", RelativeUrl));
                        }

                        try
                        {
                            lists = CreateNewAjaxDataHost.GetCreatableLists(spWeb);
                        }
                        catch { }
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
                        try
                        {
                            libraries = CreateNewAjaxDataHost.GetCreatableLibraries(spWeb);

                            foreach (var library in libraries)
                            {
                                string[] libInfo = library.Value;

                                if (!libInfo[1].ToLower().Trim().Equals("site pages")) continue;
                                library.Value[4] = libInfo[4].Replace("SitePages/Forms/Upload.aspx?source=",
                                    "_layouts/15/createwebpage.aspx");

                                break;
                            }
                        }
                        catch { }
                    }
                }
            });

            tasks.Add(t2);

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException exception)
            {
                exception.Handle(e => { throw e; });
            }

            links.Add(new NavLink
            {
                Title = string.Format("List Apps{0}", appStoreLink),
                Url = "Header"
            });

            if (lists.Count > 0)
            {
                links.AddRange(lists.Select(list => list.Value).Select(l => new NavLink
                {
                    Title = l[1],
                    Url = GetUrl(l),
                    ObjectId = l[5]
                }));
            }
            else
            {
                links.Add(new NavLink
                {
                    Title = "No list apps",
                    Url = "PlaceHolder"
                });
            }

            links.Add(new NavLink
            {
                Title = string.Format("Library Apps{0}", appStoreLink),
                Url = "Header"
            });

            if (libraries.Count > 0)
            {
                links.AddRange(libraries.Select(lib => lib.Value).Select(l => new NavLink
                {
                    Title = l[1],
                    Url = GetUrl(l),
                    ObjectId = l[5]
                }));
            }
            else
            {
                links.Add(new NavLink
                {
                    Title = "No library apps",
                    Url = "PlaceHolder"
                });
            }
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

            return string.Format("javascript:window.epmLiveNavigation.createNewOpenDialog('{0}','{1}','{2}');", url.Trim(), info[1], info[5]);
        }

        #endregion
    }
}