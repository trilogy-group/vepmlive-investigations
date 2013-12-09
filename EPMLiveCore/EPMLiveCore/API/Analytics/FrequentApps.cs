using System;
using System.Collections.Generic;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public static class FrequentApps
    {
        public static string Create(string xml)
        {
            var result = string.Empty;
            var dt = new System.Data.DataTable();
            var data = new AnalyticsData(xml, AnalyticsType.Frequent, AnalyticsAction.Create);

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