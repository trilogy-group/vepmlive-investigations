using System;
using System.Collections.Generic;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure.Navigation
{
    public abstract class NavLinkProvider : INavLinkProvider
    {
        #region Fields (5) 

        protected readonly string RelativeUrl;
        protected readonly Guid SiteId;
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
                    UserId = spWeb.CurrentUser.ID;
                }
            }
        }

        #endregion Constructors 

        #region Methods (2) 

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
            return (o ?? string.Empty).ToString();
        }

        #endregion Methods 

        #region Implementation of INavLinkProvider

        public abstract IEnumerable<INavObject> GetLinks();

        #endregion
    }
}