using System;
using System.Collections.Generic;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure.Navigation
{
    public abstract class NavLinkProvider : INavLinkProvider
    {
		#region Fields (7) 

        protected readonly string RelativeUrl;
        protected readonly Guid SiteId;
        protected readonly string Url;
        protected readonly int UserId;
        protected readonly string Username;
        protected readonly SPWeb Web;
        protected readonly Guid WebId;

		#endregion Fields 

		#region Constructors (1) 

        protected NavLinkProvider(Guid siteId, Guid webId, string username)
        {
            SiteId = siteId;
            WebId = webId;
            Username = username;

            using (var spSite = new SPSite(siteId, GetUserToken()))
            {
                using (SPWeb spWeb = spSite.OpenWeb(webId))
                {
                    RelativeUrl = spWeb.SafeServerRelativeUrl();
                    Url = spWeb.Url;
                    UserId = spWeb.CurrentUser.ID;
                    Web = spWeb;
                }
            }
        }

		#endregion Constructors 

		#region Properties (1) 

        protected abstract string Key { get; }

		#endregion Properties 

		#region Methods (4) 

		// Public Methods (2) 

        public virtual void ClearCache(bool safeRemove = false)
        {
            if (!safeRemove)
            {
                CacheStore.Current.Remove(Key, new CacheStoreCategory(Web).Navigation);
            }
            else
            {
                CacheStore.Current.RemoveSafely(Url, new CacheStoreCategory(Web).Navigation, Key);
            }
        }

        public abstract IEnumerable<INavObject> GetLinks();
		// Protected Methods (2) 

        protected SPUserToken GetUserToken()
        {
            SPUserToken token = null;

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var spSite = new SPSite(SiteId))
                {
                    using (SPWeb spWeb = spSite.OpenWeb(WebId))
                    {
                        token = spWeb.GetUserToken(Username);
                    }
                }
            });

            if (token != null) return token;

            throw new Exception("Unable to generate user token for: " + Username);
        }

        protected string S(object o)
        {
            o = o == DBNull.Value ? null : o;
            return (o ?? string.Empty).ToString();
        }

		#endregion Methods 
    }
}