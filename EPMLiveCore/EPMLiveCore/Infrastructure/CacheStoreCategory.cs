using System;
using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure
{
    public class CacheStoreCategory
    {
        #region Fields (3) 

        public const string Infrastructure = "Infrastructure";
        private readonly Guid _siteId;
        private readonly Guid _webId;

        #endregion Fields 

        #region Constructors (1) 

        public CacheStoreCategory(SPWeb spWeb = null)
        {
            try
            {
                spWeb = spWeb ?? SPContext.Current.Web;

                _siteId = spWeb.Site.ID;
                _webId = spWeb.ID;
            }
            catch
            {
                _siteId = Guid.Empty;
                _webId = Guid.Empty;
            }
        }

        #endregion Constructors 

        #region Properties (3) 

        public string Navigation
        {
            get { return "Navigation_S_" + _siteId; }
        }

        public string ResourceGrid
        {
            get { return "ResourceGrid_S_" + _siteId; }
        }

        public string SocialStream
        {
            get { return "SocialStream_W_" + _webId; }
        }

        #endregion Properties 
    }
}