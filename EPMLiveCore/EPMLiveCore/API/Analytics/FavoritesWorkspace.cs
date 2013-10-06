using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing.Charts;
using EPMLiveCore.Controls.Navigation.Providers;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using EPMLiveCore;

namespace EPMLiveCore.API
{
    public static class FavoritesWorkspace
    {
        public static string IsFavWorkspace(string xml)
        {
            var result = "false";
            var data = new AnalyticsData(xml, AnalyticsType.FavoriteWorkspace, AnalyticsAction.Read);
            try
            {
                var qExec = new QueryExecutor(SPContext.Current.Web);
                var table = qExec.ExecuteEpmLiveQuery(
                                FRFQueryFactory.GetQuery(data),
                                FRFQueryParamFactory.GetParam(data));
                if (table != null)
                {
                    result = table.Rows[0][0].ToString();
                }
            }
            catch (Exception e)
            {
                throw new APIException(21000, "[FavoritesWorkspaceService-IsFavWorkspace] " + e.Message);
            }

            return result;
        }
        // insert data
        public static string AddFavWorkspace(string xml)
        {
            var result = string.Empty;
            var dt = new System.Data.DataTable();
            var data = new AnalyticsData(xml, AnalyticsType.FavoriteWorkspace, AnalyticsAction.Create);
            try
            {
                var qExec = new QueryExecutor(SPContext.Current.Web);
                dt = qExec.ExecuteEpmLiveQuery(
                    FRFQueryFactory.GetQuery(data),
                    FRFQueryParamFactory.GetParam(data));
                ClearCache(data);
                if (dt.Rows != null && dt.Rows.Count > 0)
                {
                    result = string.Join(",", dt.Rows[0].ItemArray);
                }
                else
                {
                    throw new APIException(21000, "[FavoritesWorkspaceService-AddFavWorkspace] No new fav was added.");
                }
            }
            catch (Exception e)
            {
                throw new APIException(21000, "[FavoritesWorkspaceService-AddFavWorkspace] " + e.Message);
            }

            return result;
        }

        public static string RemoveFavWorkspace(string xml)
        {
            var result = string.Empty;
            var dt = new System.Data.DataTable();
            var data = new AnalyticsData(xml, AnalyticsType.FavoriteWorkspace, AnalyticsAction.Delete);
            try
            {
                var qExec = new QueryExecutor(SPContext.Current.Web);
                dt = qExec.ExecuteEpmLiveQuery(
                    FRFQueryFactory.GetQuery(data),
                    FRFQueryParamFactory.GetParam(data));
                ClearCache(data);
                if (dt.Rows.Count > 0)
                {
                    result = string.Join(",", dt.Rows[0].ItemArray);
                }
                else
                {
                    throw new APIException(21000, "[FavoritesWorkspaceService-RemoveFavWorkspace] No fav was removed.");
                }
            }
            catch (Exception e)
            {
                throw new APIException(21000, "[FavoritesWorkspaceService-RemoveFavWorkspace] " + e.Message);
            }

            return result;
        }


        private static void ClearCache(AnalyticsData data)
        {
            try
            {
                try
                {
                    using (var spSite = new SPSite(data.SiteId))
                    {
                        using (SPWeb spWeb = spSite.OpenWeb(data.WebId))
                        {
                            new WorkspaceLinkProvider(data.SiteId, data.WebId, spWeb.Users.GetByID(data.UserId).LoginName).ClearCache();
                        }
                    }
                }
                catch
                {
                    CacheStore.Current.RemoveCategory(CacheStoreCategory.Navigation);
                }
            }
            catch { }
        }
    }
}
