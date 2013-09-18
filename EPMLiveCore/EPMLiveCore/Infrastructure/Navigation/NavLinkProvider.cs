using System;
using System.Collections.Generic;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure.Navigation
{
    public abstract class NavLinkProvider : INavLinkProvider
    {
        #region Fields (6) 

        protected readonly string RelativeUrl;
        protected readonly Guid SiteId;
        protected readonly string Url;
        protected readonly int UserId;
        protected readonly string Username;
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
                    RelativeUrl = spWeb.ServerRelativeUrl;
                    Url = spWeb.Url;
                    UserId = spWeb.CurrentUser.ID;
                }
            }
        }

        #endregion Constructors 

        #region Properties (1) 

        protected abstract string Key { get; }

        #endregion Properties 

        #region Methods (3) 

        // Public Methods (1) 

        public virtual void ClearCache(bool safeRemove = false)
        {
            if (!safeRemove)
            {
                CacheStore.Current.Remove(Key, CacheStoreCategory.Navigation);
            }
            else
            {
                CacheStore.Current.RemoveSafely(Url, CacheStoreCategory.Navigation, Key);
            }
        }

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

        #region Implementation of INavLinkProvider

        public abstract IEnumerable<INavObject> GetLinks();

        #endregion
    }
}