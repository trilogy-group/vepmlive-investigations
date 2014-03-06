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

            return !string.IsNullOrEmpty(settingValue) &&
                   settingValue.Split(',').Any(list => list.Trim().ToLower().Equals(listTitle.ToLower()));
        }

        #endregion Methods 
    }
}