using System;

namespace EPMLiveCore.API
{
    internal static class FRFQueries
    {
        internal static readonly string QueryCheckFavStatusItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
	                    SELECT 'true'
                    END
                    ELSE
                    BEGIN
                        SELECT 'false'
                    END";

        internal static readonly string QueryCheckFavStatusNonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
	                    SELECT 'true'
                    END
                    ELSE
                    BEGIN
                        SELECT 'false'
                    END";

        internal static readonly string QueryCreateFavItem =
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

        internal static readonly string QueryCreateFavNonItem =
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

        internal static readonly string QueryRemoveFavItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
                        DECLARE @dbid uniqueidentifier
                        SET @dbid = (SELECT FRF_ID FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                        SELECT @dbid
                    END";

        internal static readonly string QueryRemoveFavNonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
                    BEGIN
                        DECLARE @dbid uniqueidentifier
                        SET @dbid = (SELECT FRF_ID FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @")
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Favorite) + @"
                        SELECT @dbid
                    END";

        internal static readonly string QueryReadFavWSStatusItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
	                    SELECT 'true'
                    END
                    ELSE
                    BEGIN
                        SELECT 'false'
                    END";

        internal static readonly string QueryReadFavWSStatusNonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
	                    SELECT 'true'
                    END
                    ELSE
                    BEGIN
                        SELECT 'false'
                    END";

        internal static readonly string QueryCreateFavWSItem =
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

        internal static readonly string QueryCreateFavWSNonItem =
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

        internal static readonly string QueryRemoveFavWSItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
                        DECLARE @dbid uniqueidentifier
                        SET @dbid = (SELECT FRF_ID FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"
                        SELECT @dbid
                    END";

        internal static readonly string QueryRemoveFavWSNonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
                    BEGIN
                        DECLARE @dbid uniqueidentifier
                        SET @dbid = (SELECT FRF_ID FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @")
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @"
                        SELECT @dbid
                    END";

        internal static readonly string QueryCheckFrequentStatusItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @")
                    BEGIN
	                    SELECT 'true'
                    END
                    ELSE
                    BEGIN
                        SELECT 'false'
                    END";

        internal static readonly string QueryCheckFrequentStatusNonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @")
                    BEGIN
	                    SELECT 'true'
                    END
                    ELSE
                    BEGIN
                        SELECT 'false'
                    END";

        internal static readonly string QueryCreateFrequent =
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

        internal static readonly string QueryRemoveFrequentItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @")
                    BEGIN
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [ITEM_ID]=@itemid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @"
                    END";

        internal static readonly string QueryRemoveFrequentNonItem =
                   @"IF EXISTS (SELECT 1 FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @")
                    BEGIN
                        DECLARE @dbid uniqueidentifier
                        SET @dbid = (SELECT FRF_ID FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @")
	                    DELETE FROM FRF WHERE [SITE_ID]=@siteid AND [WEB_ID]=@webid AND [LIST_ID]=@listid AND [USER_ID]=@userid AND [F_String]=@fstring AND [Type]=" + Convert.ToInt32(AnalyticsType.Frequent) + @"
                        SELECT @dbid
                    END";

        internal static readonly string QueryCreateRecentItem =
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
    }
}
