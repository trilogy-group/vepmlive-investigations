using System;
using System.Linq;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.SocialEngine.Core
{
    internal static class Utilities
    {
        #region Fields (2) 

        private const string IGNORED_LISTS_SETTING_KEY = "epm_ss_ignored_lists";
        private static readonly object Locker = new Object();

        #endregion Fields 

        #region Methods (2) 

        // Public Methods (2) 

        public static string ConfigureDefaultIgnoredLists(SPWeb contextWeb)
        {
            string ignoredLists = CoreFunctions.getConfigSetting(contextWeb, IGNORED_LISTS_SETTING_KEY);
            if (!string.IsNullOrEmpty(ignoredLists)) return ignoredLists;

            const string IGNORED_LISTS =
                "PublicComments,Comments,EPMLiveFileStore,User Information List,Team,Department,Departments,Excel Reports,Holiday Schedules,My Timesheet,My Work,Non Work,Project Schedules,Resource Center,Roles,Site Assets,Site Pages,Style Library,Work Hours,Installed Applications,Planner Templates,Project Schedules,Report Library,User Profile Pictures";

            CoreFunctions.setConfigSetting(contextWeb, IGNORED_LISTS_SETTING_KEY, IGNORED_LISTS);

            return IGNORED_LISTS;
        }

        public static bool IsIgnoredList(string listTitle, SPWeb contextWeb)
        {
            lock (Locker)
            {
                var settingValue = (string) CacheStore.Current.Get(IGNORED_LISTS_SETTING_KEY,
                    new CacheStoreCategory(contextWeb).SocialStream, () =>
                        CoreFunctions.getConfigSetting(contextWeb, IGNORED_LISTS_SETTING_KEY), true).Value;

                if (!string.IsNullOrEmpty(settingValue))
                    return settingValue.Split(',').Any(list => list.Trim().ToLower().Equals(listTitle.ToLower()));

                string ignoredLists = ConfigureDefaultIgnoredLists(contextWeb);

                CacheStore.Current.Set(IGNORED_LISTS_SETTING_KEY, ignoredLists,
                    new CacheStoreCategory(contextWeb).SocialStream, true);

                return false;
            }
        }

        #endregion Methods 
    }
}