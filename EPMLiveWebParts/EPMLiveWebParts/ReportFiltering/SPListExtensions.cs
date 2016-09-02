using Microsoft.SharePoint;

namespace ReportFiltering
{
    public static class SPListExtensions
    {
        //TODO: RHS - This should be in core.
        public static bool IsRollup(this SPList list)
        {
            var listGeneralSettingsAsString = EPMLiveCore.CoreFunctions.getListSetting("GeneralSettings", list);
            var listGeneralSettingsAsArray = listGeneralSettingsAsString.Split('\n');
            var rollUpLists = listGeneralSettingsAsArray[8];

            return rollUpLists.Contains(list.Title);
        }
    }
}