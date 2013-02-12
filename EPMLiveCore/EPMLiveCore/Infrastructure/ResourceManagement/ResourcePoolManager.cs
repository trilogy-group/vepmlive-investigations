using Microsoft.SharePoint;

namespace EPMLiveCore.Infrastructure
{
    public sealed class ResourcePoolManager : SPListItemManager
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcePoolManager"/> class.
        /// </summary>
        public ResourcePoolManager()
            : base("Resources", SPContext.Current.Web.ID, SPContext.Current.Site.ID, "Resources", "Resource")
        {
        }

        #endregion Constructors 
    }
}