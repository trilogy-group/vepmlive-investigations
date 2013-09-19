using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.API
{
    public static class FRFQueryFactory
    {

        public static string GetQuery(AnalyticsData data)
        {
            var query = string.Empty;
            switch (data.Type)
            {
                case AnalyticsType.Favorite:
                    query = GetFavoriteQueries(data);
                    break;
                case AnalyticsType.Frequent:
                    break;
                case AnalyticsType.Recent:
                    break;
                case AnalyticsType.FavoriteWorkspace:
                    query = GetFavoriteWorkspaceQueries(data);
                    break;

            }

            return query;
        }

        private static string GetFavoriteQueries(AnalyticsData data)
        {
            var query = string.Empty;
            switch (data.Action)
            {
                case AnalyticsAction.Create:
                    query = GetAddFavQuery(data);
                    break;
                case AnalyticsAction.Read:
                    query = GetReadFavoriteQuery(data);
                    break;
                case AnalyticsAction.Update:

                    break;
                case AnalyticsAction.Delete:
                    query = GetRemoveFavQuery(data);
                    break;
            }
            return query;
        }

        private static string GetFavoriteWorkspaceQueries(AnalyticsData data)
        {
            var query = string.Empty;
            switch (data.Action)
            {
                case AnalyticsAction.Create:
                    query = GetAddFavWorkSpaceQuery(data);
                    break;
                case AnalyticsAction.Read:
                    query = GetReadFavWorkSpaceQuery(data);
                    break;
                case AnalyticsAction.Update:

                    break;
                case AnalyticsAction.Delete:
                    query = GetRemoveFavWorkSpaceQuery(data);
                    break;
            }
            return query;
        }

        #region FAVORITE 

        private static string GetAddFavQuery(AnalyticsData data)
        {
            return data.IsItem ? queryAddFav_Item : queryAddFav_NonItem;
        }

        private static string GetRemoveFavQuery(AnalyticsData data)
        {
            return data.IsItem ? queryRemoveFav_Item : queryRemoveFav_NonItem;
        }

        private static string GetReadFavoriteQuery(AnalyticsData data)
        {
            return data.IsItem ? queryCheckFavStatus_Item : queryCheckFavStatus_NonItem;
        }

        private static string queryCheckFavStatus_Item =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
	                    SELECT 'true'
                    END
                    ELSE
                    BEGIN
                        SELECT 'false'
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
                   @"IF NOT EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
                        IF ((SELECT COUNT(*) FROM FRF WHERE [Type] = 1) = 0)
                        BEGIN
	                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Title], [Icon], [Type], [F_String], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @itemid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.Favorite) + @", @fstring, 1)
                            SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                        END
                        ELSE
                        BEGIN
                            INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Title], [Icon], [Type], [F_String], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @itemid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.Favorite) + @", @fstring, (SELECT MAX([F_Int]) FROM FRF WHERE [Type] = 1) + 1)
                            SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                        END
                    END";

        private static string queryRemoveFav_Item =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                    END";

        private static string queryRemoveFav_NonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
                        DECLARE @dbid uniqueidentifier
                        SET @dbid = (SELECT FRF_ID FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                        SELECT @dbid
                    END";
        #endregion

        #region FAVORITE WORKSPACE

        private static string GetAddFavWorkSpaceQuery(AnalyticsData data)
        {
            return data.IsItem ? queryAddFavWS_Item : queryAddFavWS_NonItem;
        }

        private static string GetRemoveFavWorkSpaceQuery(AnalyticsData data)
        {
            return data.IsItem ? queryRemoveFavWS_Item : queryRemoveFavWS_NonItem;
        }

        private static string GetReadFavWorkSpaceQuery(AnalyticsData data)
        {
            return data.IsItem ? queryReadFavWSStatus_Item : queryReadFavWSStatus_NonItem;
        }


        private static string queryReadFavWSStatus_Item =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
	                    SELECT 'true'
                    END
                    ELSE
                    BEGIN
                        SELECT 'false'
                    END";
        private static string queryReadFavWSStatus_NonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
	                    SELECT 'true'
                    END
                    ELSE
                    BEGIN
                        SELECT 'false'
                    END";

        private static string queryAddFavWS_Item =
                   @"IF NOT EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Icon]=@icon AND [Title]=@title AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
	                    INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Icon], [Title], [Type], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @itemid, @userid, @icon, @title, " + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @", (SELECT MAX([F_Int]) FROM FRF) + 1 )
                        
                    END";
        private static string queryAddFavWS_NonItem =
                   @"IF NOT EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
                        IF ((SELECT COUNT(*) FROM FRF WHERE [Type] = 1) = 0)
                        BEGIN
	                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Title], [Icon], [Type], [F_String], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @itemid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @", @fstring, 1)
                            SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"
                        END
                        ELSE
                        BEGIN
                            INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Title], [Icon], [Type], [F_String], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @itemid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @", @fstring, (SELECT MAX([F_Int]) FROM FRF WHERE [Type] = 1) + 1)
                            SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"
                        END
                    END";

        private static string queryRemoveFavWS_Item =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"
                    END";

        private static string queryRemoveFavWS_NonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
                        DECLARE @dbid uniqueidentifier
                        SET @dbid = (SELECT FRF_ID FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"
                        SELECT @dbid
                    END";
        #endregion


    }
}
