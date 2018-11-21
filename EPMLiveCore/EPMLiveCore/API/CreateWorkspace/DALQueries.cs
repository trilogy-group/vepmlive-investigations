using System;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    internal static class DALQueries
    {
        internal static string EnsureRptWebScript => 
            "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[RPTWEBGROUPS]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) " +
            "BEGIN " +
            "CREATE TABLE [dbo].[RPTWEBGROUPS]( " +
            "[RPTWEBGROUPID] [uniqueidentifier] NOT NULL, " +
            "[SITEID] [uniqueidentifier] NULL, " +
            "[WEBID] [uniqueidentifier] NULL, " +
            "[GROUPID] [int] NULL, " +
            "[SECTYPE] [int] NULL, " +
            "CONSTRAINT [PK_RPTWEBGROUPS] PRIMARY KEY CLUSTERED  " +
            "( " +
            "[RPTWEBGROUPID] ASC " +
            ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " +
            ") ON [PRIMARY] " +

            "ALTER TABLE [dbo].[RPTWEBGROUPS] ADD  CONSTRAINT [DF_RPTWEBGROUPS_RPTWEBGROUPID]  DEFAULT (newid()) FOR [RPTWEBGROUPID] " +

            "IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[RPTWEBGROUPS]') AND name = N'PK_RPTWEBGROUPS') " +
            "ALTER TABLE [dbo].[RPTWEBGROUPS] DROP CONSTRAINT [PK_RPTWEBGROUPS] " +

            "ALTER TABLE [dbo].[RPTWEBGROUPS] ADD  CONSTRAINT [PK_RPTWEBGROUPS] PRIMARY KEY CLUSTERED  " +
            "( " +
            "[RPTWEBGROUPID] ASC " +
            ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " +

            "CREATE NONCLUSTERED INDEX [IX_RPTWEBGROUPS_GROUPID_SECTYPE] ON [dbo].[RPTWEBGROUPS]  " +
            "( " +
            "[GROUPID] ASC, " +
            "[SECTYPE] ASC " +
            ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " +

            "CREATE NONCLUSTERED INDEX [IX_RPTWEBGROUPS_GROUPID] ON [dbo].[RPTWEBGROUPS]  " +
            "( " +
            "[GROUPID] ASC " +
            ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " +

            "END ";

        internal static string GetFirstAttemptQuery(Guid siteId, SPWeb web, string listId, string itemId)
        {
            Guard.ArgumentIsNotNull(web, nameof(web));
            return "IF EXISTS (SELECT 1 FROM TIMERJOBS j JOIN [QUEUE] q ON j.timerjobuid = q.timerjobuid WHERE j.[siteguid] = '" + siteId.ToString() + "' AND j.[webguid] = '" + web.ID.ToString() + "' AND j.[listguid] = '" + listId + "' AND j.[itemid] = " + itemId + ")" +
                "BEGIN " +
                   "SELECT 1 " +
                "END " +
                "ELSE " +
                "BEGIN " +
                   "SELECT 0 " +
                "END ";
        }

        internal static string GetSendCompletedSignalsQuery(
            Guid siteId,
            Guid itemWebId,
            SPWeb parentWeb,
            Guid listId,
            int itemId,
            Guid createdWebId,
            string createdWebServerRelativeUrl,
            string createdWebTitle,
            string creatorId,
            string createdWebDescription,
            SPSite eSite,
            SPWeb eRootWeb)
        {
            Guard.ArgumentIsNotNull(parentWeb, nameof(parentWeb));
            Guard.ArgumentIsNotNull(eSite, nameof(eSite));
            Guard.ArgumentIsNotNull(eRootWeb, nameof(eRootWeb));

            return @"IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[RPTWeb]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
                    BEGIN 
                        IF NOT EXISTS (SELECT * FROM [dbo].[RPTWeb] WHERE [WebId] = '" + eRootWeb.ID + @"')
                        BEGIN 
                            INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl], [WebTitle]) VALUES ('" + eSite.ID + @"', '" + Guid.Empty + @"', '" + Guid.Empty + @"', " + (-1) + @", '" + Guid.Empty + @"', '" + eRootWeb.ID + @"', '" + eRootWeb.ServerRelativeUrl + @"', '" + eRootWeb.Title + @"') 
                        END 
                            
                        IF EXISTS (SELECT * FROM [dbo].[RPTWeb] WHERE [WebId] = '" + createdWebId + @"')
                        BEGIN                                                            
                            DELETE FROM [dbo].[RPTWeb] WHERE [WebId] = '" + createdWebId + @"'  
                        END 

                        INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl], [WebTitle], [WebOwnerId], [WebDescription], [Members]) VALUES ('" + siteId + @"', '" + itemWebId + @"', '" + listId + @"', " + itemId + @", '" + parentWeb.ID + @"', '" + createdWebId + @"', '" + createdWebServerRelativeUrl + @"', '" + createdWebTitle + @"', " + creatorId + @", '" + createdWebDescription + @"', " + 1 + @") 
                    END 
                    ELSE 
                    BEGIN 
                        CREATE TABLE [dbo].[RPTWeb] ([SiteId] uniqueidentifier, [ItemWebId] uniqueidentifier, [ItemListId] uniqueidentifier, [ItemId] int, [ParentWebId] uniqueidentifier, [WebId] uniqueidentifier, [WebUrl] varchar(max), [WebTitle] varchar(max), [WebOwnerId] int null, [WebDescription] varchar(max) null, [Members] int null)
                        INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl], [WebTitle]) VALUES ('" + eSite.ID + @"', '" + Guid.Empty + @"', '" + Guid.Empty + @"', " + (-1) + @", '" + Guid.Empty + @"', '" + eRootWeb.ID + @"', '" + eRootWeb.ServerRelativeUrl + @"', '" + eRootWeb.Title + @"') 
                        INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl], [WebTitle], [WebOwnerId], [WebDescription], [Members]) VALUES ('" + siteId + @"', '" + itemWebId + @"', '" + listId + @"', " + itemId + @", '" + parentWeb.ID + @"', '" + createdWebId + @"', '" + createdWebServerRelativeUrl + @"', '" + createdWebTitle + @"', " + creatorId + @", '" + createdWebDescription + @"'," + 1 + @") 
                    END";
        }

        internal static string GetAddToFRFQuery(
            Guid siteId, 
            Guid createdWebId, 
            string siteTitle, 
            string createdWebUrl, 
            int userId)
        {
            return @"IF((SELECT COUNT(*) FROM FRF WHERE [Type]=4) = 0)
                    BEGIN
                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [USER_ID], [Title], [F_String], [Type], [F_Date], [F_Int])
                        VALUES ('" + siteId + @"', '" + createdWebId + @"', '" + userId + @"', '" + siteTitle +
                            @"', '" + createdWebUrl + @"', " + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) +
                            @", GETDATE(), 1)
                    END
                    ELSE
                    BEGIN
                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [USER_ID], [Title], [F_String], [Type], [F_Date], [F_Int])
                        VALUES ('" + siteId + @"', '" + createdWebId + @"', '" + userId + @"', '" + siteTitle +
                            @"', '" + createdWebUrl + @"', " + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) +
                            @", GETDATE(), (SELECT MAX([F_Int]) FROM FRF WHERE [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @") + 1)
                    END";
        }

        internal static string GetAddToFRFQuery(
            Guid siteId, 
            Guid createdWebId, 
            string siteTitle, 
            string createdWebUrl, 
            int userId, 
            Guid listId, 
            int itemId)
        {
            return @"IF((SELECT COUNT(*) FROM FRF WHERE [Type]=4) = 0)
                    BEGIN
                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Title], [F_String], [Type], [F_Date], [F_Int])
                        VALUES ('" + siteId + @"', '" + createdWebId + @"', '" + listId + @"', " + itemId + @", " + userId + @", '" + siteTitle +
                            @"', '" + createdWebUrl + @"', " + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) +
                            @", GETDATE(), 1)
                    END
                    ELSE
                    BEGIN
                        INSERT INTO FRF ([SITE_ID], [WEB_ID], [LIST_ID], [ITEM_ID], [USER_ID], [Title], [F_String], [Type], [F_Date], [F_Int])
                        VALUES ('" + siteId + @"', '" + createdWebId + @"', '" + listId + @"', " + itemId + @", " + userId + @", '" + siteTitle +
                            @"', '" + createdWebUrl + @"', " + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) +
                            @", GETDATE(), (SELECT MAX([F_Int]) FROM FRF WHERE [Type]=" + Convert.ToInt32(AnalyticsType.FavoriteWorkspace) + @") + 1)
                    END";
        }

        internal static string GetDoesWorkSpaceExistQuery(Guid siteId, Guid webId, Guid listId, int itemId)
        {
            return "IF EXISTS (SELECT 1 FROM [dbo].[RPTWeb] WHERE [SiteId] = '" + siteId.ToString() + "' AND [ItemWebId] = '" + webId.ToString() + "' AND [ItemListId] = '" + listId.ToString() + "' AND [ItemId] = " + itemId.ToString() + ") " +
                    "BEGIN " +
                        "SELECT 'true' " +
                    "END " +
                    "ELSE " +
                    "BEGIN " +
                        "SELECT 'false' " +
                    "END ";
        }
    }    
}
