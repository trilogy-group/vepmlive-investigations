using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.ApplicationPages.Calendar.Exchange;

namespace EPMLiveCore.API
{
    public class RecentItems
    {
        public static string Create(string xml)
        {
            var result = string.Empty;
            var dt = new System.Data.DataTable();
            var data = new AnalyticsData(xml, AnalyticsType.Recent, AnalyticsAction.Create);

            if (!IsValidList(data))
            {
                return result;
            }

            try
            {
                var exec = new QueryExecutor(SPContext.Current.Web);
                dt = exec.ExecuteEpmLiveQuery(
                    FRFQueryFactory.GetQuery(data),
                    FRFQueryParamFactory.GetParam(data));
                if (dt != null && dt.Rows.Count > 0)
                {
                    result = string.Join(",", dt.Rows[0].ItemArray);
                }


                ClearCache(data);
            }
            catch (Exception e)
            {
                result = "error: " + e.Message;
            }
            return result;
        }

        private static bool IsValidList(AnalyticsData data)
        {
            bool isValid = false;
            var inValidLists = new List<string>
            {
                "Holiday Schedules",
                "My Timesheet",
                "Holidays",
                "My Work",
                "Roles",
                "Departments",
                "Non Work",
                "Project Schedules",
                "Site Assets",
                "IzendaReports",
                "Planner Templates",
                "Report Library",
                "Site Pages",
                "User Profile Pictures",
                "Excel Reports",
                "Style Library",
                "Work Hour"
            };
            try
            {
                try
                {
                    using (var spSite = new SPSite(data.SiteId))
                    {
                        using (var spWeb = spSite.OpenWeb(data.WebId))
                        {
                            SPList testList = null;
                            try
                            {
                                testList = spWeb.Lists[data.ListId];

                            }
                            catch
                            {
                            }

                            if (testList != null && !testList.Hidden && !inValidLists.Contains(testList.Title))
                            {
                                isValid = true;
                            }
                        }
                    }
                }
                catch
                {
                   
                }
            }
            catch { }

            return isValid;
        }

        private static void ClearCache(AnalyticsData data)
        {
            try
            {
                SPWeb web = null;

                try
                {
                    using (var spSite = new SPSite(data.SiteId))
                    {
                        using (SPWeb spWeb = spSite.OpenWeb(data.WebId))
                        {
                            web = spWeb;
                            new RecentItemsLinkProvider(data.SiteId, data.WebId, spWeb.Users.GetByID(data.UserId).LoginName).ClearCache();
                        }
                    }
                }
                catch
                {
                    CacheStore.Current.RemoveCategory(new CacheStoreCategory(web).Navigation);
                }
            }
            catch { }
        }
    }
}
