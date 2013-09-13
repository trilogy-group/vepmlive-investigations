using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var data = new AnalyticsData(xml);
            try
            {
                var qExec = new QueryExecutor(SPContext.Current.Web);
                var table = qExec.ExecuteEpmLiveQuery(
                                FavQueryFactory.GetFavoriteStatusQuery(data),
                                FavQueryParamFactory.GetFavoriteStatusQueryParams(data)
                            );
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
        public static string AddFav(string xmlConfig)
        {
            var data = new AnalyticsData(xmlConfig);
            try
            {
                var qExec = new QueryExecutor(SPContext.Current.Web);
                qExec.ExecuteEpmLiveNonQuery(
                    FavQueryFactory.GetAddQuery(data),
                    FavQueryParamFactory.GetAddFavoriteQueryParams(data));

            }
            catch (Exception e)
            {
                throw new APIException(21000, "[FavoritesService-AddFav] " + e.Message);
            }

            return "success";
        }

        public static string RemoveFav(string xmlConfig)
        {  
            var data = new AnalyticsData(xmlConfig);
            try
            {
                var qExec = new QueryExecutor(SPContext.Current.Web);
                qExec.ExecuteEpmLiveNonQuery(
                    FavQueryFactory.GetRemoveQuery(data),
                    FavQueryParamFactory.GetRemoveFavoriteQueryParams(data));
                   
            }
            catch (Exception e)
            {
                throw new APIException(21000, "[FavoritesService-RemoveFav] " + e.Message);
            }

            return "success";
        }
    }

    public static class FavQueryFactory
    {
        private static string queryCheckFavStatus_Item =
                   @"IF NOT EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Icon]=@icon AND [Title]=@title AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
	                    INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Icon], [Title], [Type], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @itemid, @userid, @icon, @title, " + Convert.ToInt32(AnalyticsType.Favorite) + @", (SELECT MAX([F_Int]) FROM FRF) + 1 )
                    END";
        private static string queryCheckFavStatus_NonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
	                    SELECT 'true'
                    END
                    ELSE
                    BEGIN
                        SELECT 'false'
                    END";

        private static string queryAddFav_Item =
                   @"IF NOT EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Icon]=@icon AND [Title]=@title AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
	                    INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Icon], [Title], [Type], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @itemid, @userid, @icon, @title, " + Convert.ToInt32(AnalyticsType.Favorite) + @", (SELECT MAX([F_Int]) FROM FRF) + 1 )
                    END";
        private static string queryAddFav_NonItem =
                   @"IF NOT EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Icon]=@icon AND [Title]=@title AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
	                    INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [USER_ID], [Title], [Icon], [Type], [F_String], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.Favorite) + @", @fstring, (SELECT MAX([F_Int]) FROM FRF) + 1)
                    END";

        private static string queryRemoveFav_Item =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                    END";

        private static string queryRemoveFav_NonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                    END";

        public static string GetAddQuery(AnalyticsData data)
        {
            return data.IsItem ? queryAddFav_Item : queryAddFav_NonItem;
        }

        public static string GetRemoveQuery(AnalyticsData data)
        {
            return data.IsItem ? queryRemoveFav_Item : queryRemoveFav_NonItem;
        }

        public static string GetFavoriteStatusQuery(AnalyticsData data)
        {
            return data.IsItem ? queryCheckFavStatus_Item : queryCheckFavStatus_NonItem;
        }


    }

    public static class FavQueryParamFactory
    {
        public static Dictionary<string, object> GetFavoriteStatusQueryParams(AnalyticsData data)
        {
            return data.IsItem ?
                    new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@itemid", data.ItemId},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                        
                    }
                    :
                    new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@userid", data.UserId},
                        {"@fstring", data.FString}
                    };
        }

        public static Dictionary<string, object> GetRemoveFavoriteQueryParams(AnalyticsData data)
        {   
            return data.IsItem ?
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@itemid", data.ItemId},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            :
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            ;
        }

        public static Dictionary<string, object> GetAddFavoriteQueryParams(AnalyticsData data)
        {
            return data.IsItem ?
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@itemid", data.ItemId},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            :
                new Dictionary<string, object>
                    {
                        {"@siteid", data.SiteId},
                        {"@webid", data.WebId},
                        {"@listid", data.ListId},
                        {"@fstring", data.FString},
                        {"@userid", data.UserId},
                        {"@icon", data.Icon},
                        {"@title", data.Title},
                    }
            ;
        }
    }

}
