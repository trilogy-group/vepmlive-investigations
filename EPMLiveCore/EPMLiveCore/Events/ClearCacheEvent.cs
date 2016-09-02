using EPMLiveCore.Controls.Navigation.Providers;
using Microsoft.SharePoint;

namespace EPMLiveCore.Events
{
    public class ClearCacheEvent : SPItemEventReceiver
    {
        #region Methods (1) 

        // Private Methods (1) 

        private void ClearSettingsNavigationCache(SPWeb web)
        {
            new SettingsLinkProvider(web.Site.ID, web.ID, web.CurrentUser.LoginName).ClearCache(true);
        }

        #endregion Methods 

        #region Overrides of SPItemEventReceiver

        public override void ItemAdded(SPItemEventProperties properties)
        {
            switch (properties.ListTitle)
            {
                case "EPM Live Settings":
                    ClearSettingsNavigationCache(properties.Web);
                    break;
            }
        }


        public override void ItemUpdated(SPItemEventProperties properties)
        {
            switch (properties.ListTitle)
            {
                case "EPM Live Settings":
                    ClearSettingsNavigationCache(properties.Web);
                    break;
            }
        }

        public override void ItemDeleted(SPItemEventProperties properties)
        {
            switch (properties.ListTitle)
            {
                case "EPM Live Settings":
                    ClearSettingsNavigationCache(properties.Web);
                    break;
            }
        }

        #endregion
    }
}