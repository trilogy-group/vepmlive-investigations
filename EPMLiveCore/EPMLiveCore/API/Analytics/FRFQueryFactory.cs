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
                    query = GetFrequentQueries(data);
                    break;
                case AnalyticsType.Recent:
                    query = GetRecentQueries(data);
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
                    query = GetCreateFavoriteQuery(data);
                    break;
                case AnalyticsAction.Read:
                    query = GetReadFavoriteQuery(data);
                    break;
                case AnalyticsAction.Update:

                    break;
                case AnalyticsAction.Delete:
                    query = GetRemoveFavoriteQuery(data);
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
                    query = GetCreateFavWorkSpaceQuery(data);
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

        private static string GetFrequentQueries(AnalyticsData data)
        {
            var query = string.Empty;
            switch (data.Action)
            {
                case AnalyticsAction.Create:
                    query = GetCreateFrequentQuery(data);
                    break;
                case AnalyticsAction.Read:
                    query = GetReadFrequentQuery(data);
                    break;
                case AnalyticsAction.Update:
                    query = GetUpdateFrequentQuery(data);
                    break;
                case AnalyticsAction.Delete:
                    query = GetRemoveFrequentQuery(data);
                    break;
            }
            return query;
        }

        private static string GetRecentQueries(AnalyticsData data)
        {
            var query = string.Empty;
            switch (data.Action)
            {
                case AnalyticsAction.Create:
                    query = GetCreateRecentItemQuery(data);
                    break;
            }
            return query;
        }

		


        #region FAVORITE 

        private static string GetCreateFavoriteQuery(AnalyticsData data)
        {
            return data.IsItem ? queryCreateFav_Item : queryCreateFav_NonItem;
        }

        private static string GetRemoveFavoriteQuery(AnalyticsData data)
        {
            return data.IsItem ? queryRemoveFav_Item : queryRemoveFav_NonItem;
        }

        private static string GetReadFavoriteQuery(AnalyticsData data)
        {
            return data.IsItem ? queryCheckFavStatus_Item : queryCheckFavStatus_NonItem;
        }

        private static string queryCheckFavStatus_Item =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
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

        private static string queryCreateFav_Item =
                   @"IF NOT EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
                        IF ((SELECT COUNT(*) FROM FRF WHERE [Type] = 1) = 0)
                        BEGIN
	                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Title], [Icon], [Type], [F_Int], [F_String])
                                    VALUES (@siteid, @webid, @listid, @itemid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.Favorite) + @", 1, @fstring)
                            SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                        END
                        ELSE
                        BEGIN
                            INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Title], [Icon], [Type], [F_Int], [F_String])
                                    VALUES (@siteid, @webid, @listid, @itemid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.Favorite) + @", (SELECT MAX([F_Int]) FROM FRF WHERE [Type] = 1) + 1, @fstring)
                            SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                        END
                    END";
        private static string queryCreateFav_NonItem =
                   @"IF NOT EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
                        IF ((SELECT COUNT(*) FROM FRF WHERE [Type] = 1) = 0)
                        BEGIN
	                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [USER_ID], [Title], [Icon], [Type], [F_String], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.Favorite) + @", @fstring, 1)
                            SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                        END
                        ELSE
                        BEGIN
                            INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [USER_ID], [Title], [Icon], [Type], [F_String], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.Favorite) + @", @fstring, (SELECT MAX([F_Int]) FROM FRF WHERE [Type] = 1) + 1)
                            SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                        END
                    END
                    SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                    ";

        private static string queryRemoveFav_Item =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
                        DECLARE @dbid uniqueidentifier
                        SET @dbid = (SELECT FRF_ID FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                        SELECT @dbid
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

        private static string GetCreateFavWorkSpaceQuery(AnalyticsData data)
        {
            return data.IsItem ? queryCreateFavWS_Item : queryCreateFavWS_NonItem;
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

        private static string queryCreateFavWS_Item =
                   @"IF NOT EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
                        IF ((SELECT COUNT(*) FROM FRF WHERE [Type] = 1) = 0)
                        BEGIN
	                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Title], [Icon], [Type], [F_Int], [F_String])
                                    VALUES (@siteid, @webid, @listid, @itemid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @", 1, @fstring)
                            SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"
                        END
                        ELSE
                        BEGIN
                            INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Title], [Icon], [Type], [F_Int], [F_String])
                                    VALUES (@siteid, @webid, @listid, @itemid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @", (SELECT MAX([F_Int]) FROM FRF WHERE [Type] = 1) + 1, @fstring)
                            SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"
                        END
                    END
                    SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"    
                    ";
        private static string queryCreateFavWS_NonItem =
                   @"IF NOT EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
                        IF ((SELECT COUNT(*) FROM FRF WHERE [Type] = 1) = 0)
                        BEGIN
	                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [USER_ID], [Title], [Icon], [Type], [F_String], [F_Int])
                                    VALUES (@siteid, @webid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @", @fstring, 1)
                            SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"
                        END
                        ELSE
                        BEGIN
                            INSERT INTO FRF ([SITE_ID], [WEB_ID], [USER_ID], [Title], [Icon], [Type], [F_String], [F_Int])
                                    VALUES (@siteid, @webid, @userid, @title, @icon, " + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @", @fstring, (SELECT MAX([F_Int]) FROM FRF WHERE [Type] = 1) + 1)
                            SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"
                        END
                    END
                    SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"
                    ";

        private static string queryRemoveFavWS_Item =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
                        DECLARE @dbid uniqueidentifier
                        SET @dbid = (SELECT FRF_ID FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"
                        SELECT @dbid
                    END";

        private static string queryRemoveFavWS_NonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
                        DECLARE @dbid uniqueidentifier
                        SET @dbid = (SELECT FRF_ID FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"
                        SELECT @dbid
                    END";
        #endregion

        #region FREQUENTS

        private static string GetCreateFrequentQuery(AnalyticsData data)
        {
            return queryCreateFrequent;
        }

        private static string GetRemoveFrequentQuery(AnalyticsData data)
        {
            return data.IsItem ? queryRemoveFrequent_Item : queryRemoveFrequent_NonItem;
        }

        private static string GetReadFrequentQuery(AnalyticsData data)
        {
            return data.IsItem ? queryCheckFrequentStatus_Item : queryCheckFrequentStatus_NonItem;
        }

        private static string GetUpdateFrequentQuery(AnalyticsData data)
        {
            return data.IsItem ? queryCheckFrequentStatus_Item : queryCheckFrequentStatus_NonItem;
        }

        private static string queryCheckFrequentStatus_Item =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @")
                    BEGIN
	                    SELECT 'true'
                    END
                    ELSE
                    BEGIN
                        SELECT 'false'
                    END";
        private static string queryCheckFrequentStatus_NonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @")
                    BEGIN
	                    SELECT 'true'
                    END
                    ELSE
                    BEGIN
                        SELECT 'false'
                    END";

        private static string queryCreateFrequent =
                   @"IF NOT EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @")
                    BEGIN
	                    INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [USER_ID], [Icon], [Title], [Type], [F_Date], [F_Int])
                                    VALUES (@siteid, @webid, @listid, @userid, @icon, @title, " + Convert.ToInt32(AnalyticsType.Frequent) + @", GETDATE(), 1)
                        SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @"
                    END
                    ELSE 
                    BEGIN
                        UPDATE FRF SET [F_Int] = [F_Int] + 1 
                        WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @"                                    
                        SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @"
                    END";
        

        private static string queryRemoveFrequent_Item =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @")
                    BEGIN
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @"
                    END";

        private static string queryRemoveFrequent_NonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @")
                    BEGIN
                        DECLARE @dbid uniqueidentifier
                        SET @dbid = (SELECT FRF_ID FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @")
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @"
                        SELECT @dbid
                    END";
        #endregion

        #region RECENT ITEMS

        private static string GetCreateRecentItemQuery(AnalyticsData data)
        {
            return queryCreateRecentItem;
        }

        private static string queryCreateRecentItem =
                    @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Recent) + @")
                    BEGIN
                        UPDATE FRF SET [F_Date] = GETDATE() 
                        WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Recent) + @" 
                        SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Recent) + @"
                    END
                    ELSE
                    BEGIN
                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Icon], [Title], [Type], [F_Date])
                        VALUES (@siteid, @webid, @listid, @itemid, @userid, @icon, @title, " + Convert.ToInt32(AnalyticsType.Recent) + @", GETDATE())
                        SELECT * FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Recent) + @"
                    END

                    IF ((SELECT COUNT(*) FROM FRF WHERE [Type] = 2) > 20)
                    BEGIN
	                    DELETE FROM FRF 
	                    WHERE [Type] = 2 
	                    AND [F_Date] NOT IN (SELECT TOP 20 [F_Date] FROM FRF WHERE [Type] = 2 ORDER BY [F_Date] DESC)
                    END
                    ";
        #endregion
    }
}
