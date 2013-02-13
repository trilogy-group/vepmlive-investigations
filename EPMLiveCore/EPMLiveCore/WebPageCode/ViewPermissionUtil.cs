using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class ViewPermissionUtil
    {
        public static void ConvertFromString(ref Dictionary<int, Dictionary<string, bool>> roleProperties, ref Dictionary<int, string> defaultViews, string value, SPList currentList)
        {
            string[] groups = value.Split("|".ToCharArray());
            Dictionary<int, string> groupValues = new Dictionary<int, string>();

            foreach (string group in groups)
            {
                if (!string.IsNullOrEmpty(group))
                {
                    string[] values = group.Split("#".ToCharArray());
                    int groupId = int.Parse(values[0]);
                    groupValues.Add(groupId, group);
                }
            }

            foreach (SPGroup group in currentList.ParentWeb.Groups)
            {
                roleProperties.Add(group.ID, new Dictionary<string, bool>());
                string defaultViewId = GetDefautView(groupValues, group.ID);

                SetDefaultVue(defaultViewId, currentList.DefaultView.Url, group.ID, currentList, ref defaultViews);

                foreach (SPView view in currentList.Views)
                {
                    if ((!view.Hidden) && (!view.PersonalView))
                        roleProperties[group.ID].Add(view.Url, IsViewAllowed(groupValues, group.ID, view.Url));
                    else
                    {
                        if(view.PersonalView)
                            roleProperties[group.ID].Add(view.Url, true);
                    }
                }
            }
        }

        private static void SetDefaultVue(string defaultUserView, string listDefaultVue, int groupId, SPList currentList, ref Dictionary<int, string> defaultViews)
        {
            try
            {
                foreach (SPView view in currentList.Views)
                {
                    if (view.Url == defaultUserView)
                    {
                        defaultViews.Add(groupId, defaultUserView);
                        return;
                    }                        
                }
                    defaultViews.Add(groupId, listDefaultVue);
            }
            catch (Exception)
            {
                defaultViews.Add(groupId, listDefaultVue);
            }
        }

        public static void ConvertFromStringForPage(ref Dictionary<int, Dictionary<string, bool>> roleProperties, ref Dictionary<int, string> defaultViews, string value, SPList currentList)
        {
            string[] groups = value.Split("|".ToCharArray());
            Dictionary<int, string> groupValues = new Dictionary<int, string>();

            foreach (string group in groups)
            {
                if (!string.IsNullOrEmpty(group))
                {
                    string[] values = group.Split("#".ToCharArray());
                    int groupId = int.Parse(values[0]);
                    groupValues.Add(groupId, group);
                }
            }

            foreach (SPGroup group in currentList.ParentWeb.Groups)
            {
                roleProperties.Add(group.ID, new Dictionary<string, bool>());
                string defaultViewId = GetDefautView(groupValues, group.ID);

                SetDefaultVue(defaultViewId, currentList.DefaultView.Url, group.ID, currentList, ref defaultViews);

                foreach (SPView view in currentList.Views)
                {
                    if ((!view.Hidden) && (!view.PersonalView))
                        roleProperties[group.ID].Add(view.Url, IsViewAllowed(groupValues, group.ID, view.Url));
                }

            }
        }

        private static string GetDefautView(Dictionary<int, string> groupValues, int groupId)
        {
            if (groupValues.ContainsKey(groupId))
            {
                string[] values = groupValues[groupId].Split("#".ToCharArray());
                return values[1];
            }
            else
                return "";
        }

        private static bool IsViewAllowed(Dictionary<int, string> groupValues, int groupId, string viewToTest)
        {
            if (groupValues.ContainsKey(groupId))
            {
                string[] values = groupValues[groupId].Split("#".ToCharArray());
                return values[2].Contains(viewToTest);
            }
            else
                return true;
        }
    }
}
