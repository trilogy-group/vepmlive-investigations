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
    public static class Favorites
    {
        public static string IsFav(string xml)
        {
            var result = "false";
            var data = new AnalyticsData(xml, AnalyticsType.Favorite, AnalyticsAction.Read);
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
                throw new APIException(21000, "[FavoritesService-IsFav] " + e.Message);
            }

            return result;
        }
        // insert data
        public static string AddFav(string xml)
        {
            var result = string.Empty;
            var dt = new System.Data.DataTable();
            var data = new AnalyticsData(xml, AnalyticsType.Favorite, AnalyticsAction.Create);
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
                    throw new APIException(21000, "[FavoritesService-AddFav]");
                }
            }
            catch (Exception e)
            {
                throw new APIException(21000, "[FavoritesService-AddFav] " + e.Message);
            }

            return result;
        }

        public static string RemoveFav(string xml)
        {
            var result = string.Empty;
            var dt = new System.Data.DataTable();
            var data = new AnalyticsData(xml, AnalyticsType.Favorite, AnalyticsAction.Delete);
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
                    throw new APIException(21000, "[FavoritesService-RemoveFav] ");
                }
            }
            catch (Exception e)
            {
                throw new APIException(21000, "[FavoritesService-RemoveFav] " + e.Message);
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
                            new FavoritesLinkProvider(data.SiteId, data.WebId, spWeb.Users.GetByID(data.UserId).LoginName).ClearCache();
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
