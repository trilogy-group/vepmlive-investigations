using EPMLiveCore.API;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.Events.GenericListEventReceiver
{
    /// <summary>
    ///     List Events
    /// </summary>
    public class GenericListEventReceiver : SPListEventReceiver
    {
        #region Methods (3) 

        // Public Methods (2) 

        /// <summary>
        ///     A list was added.
        /// </summary>
        public override void ListAdded(SPListEventProperties properties)
        {
            try
            {
                ListCommands.InstallListsViewsWebparts(properties.List);
            }
            catch { }

            if (properties.Web.CurrentUser.ID != properties.Web.Site.SystemAccount.ID)
            {
                try
                {
                    ListCommands.MapListToReporting(properties.List);
                }
                catch { }

                try
                {
                    ListCommands.SaveIconToReporting(properties.List);
                }
                catch { }   
            }

            ClearCache(properties);
        }

        /// <summary>
        ///     A list was deleted.
        /// </summary>
        public override void ListDeleted(SPListEventProperties properties)
        {
            ClearCache(properties);
        }

        // Private Methods (1) 

        private void ClearCache(SPListEventProperties properties)
        {
            try
            {
                CacheStore.Current.RemoveSafely(properties.WebUrl, new CacheStoreCategory(properties.Web).Navigation);
            }
            catch { }
        }

        #endregion Methods 
    }
}