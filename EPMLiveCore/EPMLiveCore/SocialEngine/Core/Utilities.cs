using System.Linq;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Core
{
    internal static class Utilities
    {
        #region Methods (1) 

        // Public Methods (1) 

        public static bool IsIgnoredList(string listTitle, SPWeb contextWeb)
        {
            const string SETTING_KEY = "EPM_SS_Ignored_Lists";

            var settingValue =
                (string) CacheStore.Current.Get(SETTING_KEY, new CacheStoreCategory(contextWeb).SocialStream,
                    () => CoreFunctions.getConfigSetting(contextWeb, SETTING_KEY), true).Value;

            if (!string.IsNullOrEmpty(settingValue))
                return settingValue.Split(',').Any(list => list.Trim().ToLower().Equals(listTitle.ToLower()));

            const string IGNORED_LISTS = "EPMLiveFileStore,User Information List";

            CoreFunctions.setConfigSetting(contextWeb, SETTING_KEY, IGNORED_LISTS);

            CacheStore.Current.Set(SETTING_KEY, IGNORED_LISTS, new CacheStoreCategory(contextWeb).SocialStream, true);

            return false;
        }

        #endregion Methods 
    }
}