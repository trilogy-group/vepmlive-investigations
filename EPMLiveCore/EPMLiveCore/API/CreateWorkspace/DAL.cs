using System.Reflection;
using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPMLiveCore.API
{
    public static class WorkspaceData
    {
        public static bool IsFirstAttempt(SPSite site, SPWeb web, string listId, string itemId)
        {
            int iRecs = 0;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (SPSite eSite = new SPSite(site.ID))
                {
                    using (SqlConnection con = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id)))
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("IF EXISTS (SELECT 1 FROM TIMERJOBS j JOIN [QUEUE] q ON j.timerjobuid = q.timerjobuid WHERE j.[siteguid] = '" + site.ID.ToString() + "' AND j.[webguid] = '" + web.ID.ToString() + "' AND j.[listguid] = '" + listId.ToString() + "' AND j.[itemid] = " + itemId.ToString() + ")" +
                                                         "BEGIN " +
                                                            "SELECT 1 " +
                                                         "END " +
                                                         "ELSE " +
                                                         "BEGIN " +
                                                            "SELECT 0 " +
                                                         "END ");
                        cmd.Connection = con;
                        iRecs = int.Parse(cmd.ExecuteScalar().ToString());
                    }
                }
            });

            return iRecs == 0;
        }

        public static void SendCompletedSignalsToDB(Guid siteId, SPWeb itemWeb, SPWeb parentWeb, Guid listId, int itemId, Guid createdWebId, string createdWebServerRelativeUrl, string createdWebTitle, string creatorId, string createdWebDescription)
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (SPSite eSite = new SPSite(siteId))
                {
                    var eRootWeb = eSite.RootWeb;

                    using (SqlConnection con = new SqlConnection(CoreFunctions.getReportingConnectionString(eSite.WebApplication.Id, eSite.ID)))
                    {
                        con.Open();

                        var cmd = new SqlCommand(@"IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[RPTWeb]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
                                                    BEGIN 
                                                        IF NOT EXISTS (SELECT * FROM [dbo].[RPTWeb] WHERE [WebId] = '" + eRootWeb.ID + @"')
                                                        BEGIN 
                                                            INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl], [WebTitle]) VALUES ('" + eSite.ID + @"', '" + Guid.Empty + @"', '" + Guid.Empty + @"', " + (-1) + @", '" + Guid.Empty + @"', '" + eRootWeb.ID + @"', '" + eRootWeb.ServerRelativeUrl + @"', '" + eRootWeb.Title + @"') 
                                                        END 
                                                            
                                                        IF EXISTS (SELECT * FROM [dbo].[RPTWeb] WHERE [WebId] = '" + createdWebId + @"')
                                                        BEGIN                                                            
                                                            DELETE FROM [dbo].[RPTWeb] WHERE [WebId] = '" + createdWebId + @"'  
                                                        END 

                                                        INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl], [WebTitle], [WebOwnerId], [WebDescription]) VALUES ('" + siteId + @"', '" + itemWeb.ID + @"', '" + listId + @"', " + itemId + @", '" + parentWeb.ID + @"', '" + createdWebId + @"', '" + createdWebServerRelativeUrl + @"', '" + createdWebTitle + @"', " + creatorId + @", '" + createdWebDescription + @"') 
                                                    END 
                                                    ELSE 
                                                    BEGIN 
                                                        CREATE TABLE [dbo].[RPTWeb] ([SiteId] uniqueidentifier, [ItemWebId] uniqueidentifier, [ItemListId] uniqueidentifier, [ItemId] int, [ParentWebId] uniqueidentifier, [WebId] uniqueidentifier, [WebUrl] varchar(max), [WebTitle] varchar(max), [WebOwnerId] int null, [WebDescription] varchar(max) null, [Members] int null)
                                                        INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl], [WebTitle]) VALUES ('" + eSite.ID + @"', '" + Guid.Empty + @"', '" + Guid.Empty + @"', " + (-1) + @", '" + Guid.Empty + @"', '" + eRootWeb.ID + @"', '" + eRootWeb.ServerRelativeUrl + @"', '" + eRootWeb.Title + @"') 
                                                        INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl], [WebTitle], [WebOwnerId], [WebDescription]) VALUES ('" + siteId + @"', '" + itemWeb.ID + @"', '" + listId + @"', " + itemId + @", '" + parentWeb.ID + @"', '" + createdWebId + @"', '" + createdWebServerRelativeUrl + @"', '" + createdWebTitle + @"', " + creatorId + @", '" + createdWebDescription + @"') 
                                                    END");
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
                }
            });
        }

        public static void SendCompletedSignalsToDB(Guid siteId, SPWeb parentWeb, Guid createdWebId, string createdWebServerRelativeUrl, string createdWebTitle, string creatorId, string createdWebDescription)
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (SPSite eSite = new SPSite(siteId))
                {
                    var eRootWeb = eSite.RootWeb;

                    using (SqlConnection con = new SqlConnection(CoreFunctions.getReportingConnectionString(eSite.WebApplication.Id, eSite.ID)))
                    {
                        con.Open();

                        var cmd = new SqlCommand(@"IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[RPTWeb]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) 
                                                    BEGIN 
                                                        IF NOT EXISTS (SELECT * FROM [dbo].[RPTWeb] WHERE [WebId] = '" + eRootWeb.ID + @"')
                                                        BEGIN 
                                                            INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl], [WebTitle]) VALUES ('" + eSite.ID + @"', '" + Guid.Empty + @"', '" + Guid.Empty + @"', " + (-1) + @", '" + Guid.Empty + @"', '" + eRootWeb.ID + @"', '" + eRootWeb.ServerRelativeUrl + @"', '" + eRootWeb.Title + @"') 
                                                        END 
                                                            
                                                        IF EXISTS (SELECT * FROM [dbo].[RPTWeb] WHERE [WebId] = '" + createdWebId + @"')
                                                        BEGIN                                                            
                                                            DELETE FROM [dbo].[RPTWeb] WHERE [WebId] = '" + createdWebId + @"'  
                                                        END 

                                                        INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl], [WebTitle], [WebOwnerId], [WebDescription]) VALUES ('" + siteId + @"', '" + Guid.Empty + @"', '" + Guid.Empty + @"', " + (-1) + @", '" + parentWeb.ID + @"', '" + createdWebId + @"', '" + createdWebServerRelativeUrl + @"', '" + createdWebTitle + @"', " + creatorId + @", '" + createdWebDescription + @"') 
                                                    END 
                                                    ELSE 
                                                    BEGIN 
                                                        CREATE TABLE [dbo].[RPTWeb] ([SiteId] uniqueidentifier, [ItemWebId] uniqueidentifier, [ItemListId] uniqueidentifier, [ItemId] int, [ParentWebId] uniqueidentifier, [WebId] uniqueidentifier, [WebUrl] varchar(max), [WebTitle] varchar(max), [WebOwnerId] int null, [WebDescription] varchar(max) null, [Members] int null)
                                                        INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl], [WebTitle]) VALUES ('" + eSite.ID + @"', '" + Guid.Empty + @"', '" + Guid.Empty + @"', " + (-1) + @", '" + Guid.Empty + @"', '" + eRootWeb.ID + @"', '" + eRootWeb.ServerRelativeUrl + @"', '" + eRootWeb.Title + @"') 
                                                        INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl], [WebTitle], [WebOwnerId], [WebDescription]) VALUES ('" + siteId + @"', '" + Guid.Empty + @"', '" + Guid.Empty + @"', " + (-1) + @", '" + parentWeb.ID + @"', '" + createdWebId + @"', '" + createdWebServerRelativeUrl + @"', '" + createdWebTitle + @"', " + creatorId + @", '" + createdWebDescription + @"') 
                                                    END");
                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
                    }
                }
            });
        }

        public static void AddToFRF(Guid siteId, Guid createdWebId, string siteTitle, string createdWebUrl, int userId, int type)
        {
            // type legend
            // 1 = favorites
            // 2 = recent
            // 3 = frequent apps
            // 4 = workspace
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var eSite = new SPSite(siteId))
                {
                    using (var con = new SqlConnection(CoreFunctions.getConnectionString(eSite.WebApplication.Id)))
                    {
                        con.Open();
                        var cmd = new SqlCommand
                        {
                            CommandText =
                            @"IF((SELECT COUNT(*) FROM FRF WHERE [Type]=4) = 0)
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
                            END",
                            Connection = con
                        };

                        cmd.ExecuteNonQuery();
                    }
                }
            });
        }

        public static void AddToFRF(Guid siteId, Guid createdWebId, string siteTitle, string createdWebUrl, int userId, int type, Guid listId, int itemId)
        {
            // type legend
            // 1 = favorites
            // 2 = recent
            // 3 = frequent apps
            // 4 = workspace
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var eSite = new SPSite(siteId))
                {
                    using (var con = new SqlConnection(CoreFunctions.getConnectionString(eSite.WebApplication.Id)))
                    {
                        con.Open();
                        var cmd = new SqlCommand
                        {
                            CommandText =
                            @"IF((SELECT COUNT(*) FROM FRF WHERE [Type]=4) = 0)
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
                            END",
                            Connection = con
                        };

                        cmd.ExecuteNonQuery();
                    }
                }
            });
        }
        public static void AddWsPermission(Guid siteId, Guid createdWebId)
        {
                const string ensureRptWebScript = "IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[RPTWEBGROUPS]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) " +
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

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var s = new SPSite(siteId))
                {  
                    using (var w = s.OpenWeb(createdWebId))
                    {
                        using (var con = new SqlConnection(CoreFunctions.getReportingConnectionString(s.WebApplication.Id, s.ID)))
                        {
                            con.Open();
                            var cmd = new SqlCommand(ensureRptWebScript) { Connection = con };
                            cmd.ExecuteNonQuery();

                           
                            var dt = new DataTable();
                            var dc = new DataColumn("RPTWEBGROUPS") { DataType = System.Type.GetType("System.Guid") };
                            dt.Columns.Add(dc);
                            dc = new DataColumn("SITEID") { DataType = System.Type.GetType("System.Guid") };
                            dt.Columns.Add(dc);
                            dc = new DataColumn("WEBID") { DataType = System.Type.GetType("System.Guid") };
                            dt.Columns.Add(dc);
                            dc = new DataColumn("GROUPID") { DataType = System.Type.GetType("System.Int32") };
                            dt.Columns.Add(dc);
                            dc = new DataColumn("SECTYPE") { DataType = System.Type.GetType("System.Int32") };
                            dt.Columns.Add(dc);

                            foreach (SPRoleAssignment ra in w.RoleAssignments)
                            {
                                var type = 0;
                                if (ra.Member is SPGroup)
                                {
                                    type = 1;
                                }
                                var found = ra.RoleDefinitionBindings.Cast<SPRoleDefinition>().Any(def => (def.BasePermissions & SPBasePermissions.ViewListItems) == SPBasePermissions.ViewListItems);
                                if (found)
                                {
                                    dt.Rows.Add(new object[] { Guid.NewGuid(), s.ID, w.ID, ra.Member.ID, type });
                                }
                            }

                            dt.Rows.Add(new object[] { Guid.NewGuid(), s.ID, w.ID, 999999, 1 });

                            using (var bulkCopy = new SqlBulkCopy(con))
                            {
                                bulkCopy.DestinationTableName =
                                    "dbo.RPTWEBGROUPS";

                                bulkCopy.WriteToServer(dt);
                            }

                            try
                            {
                                const string epmLiveReportingAssembly = "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";
                                MethodInfo m = null;
                                Assembly assemblyInstance = null;
                                Type thisClass = null;
                                object apiClass = null;
                                // use reflection to map list
                                try
                                {
                                    assemblyInstance = Assembly.Load(epmLiveReportingAssembly);
                                    thisClass = assemblyInstance.GetType("EPMLiveReportsAdmin.ProcessSecurity", true, true);
                                    m = thisClass.GetMethod("ProcessSecurityGroups",
                                        BindingFlags.Public | BindingFlags.Static);
                                }
                                catch
                                {
                                }

                                if (m != null && assemblyInstance != null && thisClass != null )
                                {
                                    using (
                                        var conn =
                                            new SqlConnection(
                                                CoreFunctions.getReportingConnectionString(s.WebApplication.Id, s.ID)))
                                    {
                                        conn.Open();
                                        m.Invoke(null, new object[]
                                            {
                                                s,
                                                conn,
                                                ""
                                            });
                                    }
                                    
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            });
        }

        public static bool DoesWorkspaceExist(Guid siteId, Guid webId, Guid listId, int itemId)
        {
            bool exists = false;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (SPSite eSite = new SPSite(siteId))
                {
                    using (SqlConnection con = new SqlConnection(CoreFunctions.getReportingConnectionString(eSite.WebApplication.Id, eSite.ID)))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("IF EXISTS (SELECT 1 FROM [dbo].[RPTWeb] WHERE [SiteId] = '" + siteId.ToString() + "' AND [ItemWebId] = '" + webId.ToString() + "' AND [ItemListId] = '" + listId.ToString() + "' AND [ItemId] = " + itemId.ToString() + ") " +
                                                        "BEGIN " +
                                                            "SELECT 'true' " +
                                                        "END " +
                                                        "ELSE " +
                                                        "BEGIN " +
                                                            "SELECT 'false' " +
                                                        "END ");

                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            bool.TryParse(rdr[0].ToString(), out exists);
                        }
                    }
                }
            });
            return exists;
        }

        public static string GetWorkspaceStatus(Guid siteId, Guid webId, Guid listId, int itemId)
        {
            string status = "NotTried";
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (SPSite eSite = new SPSite(siteId))
                {
                    using (SqlConnection con = new SqlConnection(CoreFunctions.getConnectionString(eSite.WebApplication.Id)))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("SELECT q.[Status] FROM TIMERJOBS j JOIN [QUEUE] q ON j.timerjobuid = q.timerjobuid WHERE j.[siteguid] = '" + siteId.ToString() + "' AND j.[webguid] = '" + webId.ToString() + "' AND j.[listguid] = '" + listId.ToString() + "' AND j.[itemid] = " + itemId.ToString());
                        cmd.Connection = con;
                        SqlDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            if (rdr[0].ToString() == "1")
                            {
                                status = "InProgress";
                            }
                            else if (rdr[0].ToString() == "2")
                            {
                                status = "Ready";
                            }
                        }
                    }
                }
            });
            return status;
        }

        public static string GetWorkspaceUrl(Guid siteId, Guid webId, Guid listId, int itemId)
        {
            string url = string.Empty;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (SPSite s = new SPSite(siteId))
                {
                    using (SPWeb w = s.OpenWeb(webId))
                    {
                        SPFieldUrlValue spUrl = null;
                        try
                        {
                            spUrl = new SPFieldUrlValue(w.Lists[listId].GetItemById(itemId)["WorkspaceUrl"].ToString());
                        }
                        catch { }

                        if (spUrl != null)
                        {
                            url = spUrl.Url;
                        }
                    }
                }
            });
            return url;
        }

        //public static void SendStartSignalsToDB(Guid siteId, SPWeb itemParentWeb, Guid listId, int itemId)
        //{
        //    SPSecurity.RunWithElevatedPrivileges(() =>
        //    {
        //        using (SPSite eSite = new SPSite(siteId))
        //        {
        //            using (SqlConnection con = new SqlConnection(CoreFunctions.getReportingConnectionString(eSite.WebApplication.Id, eSite.ID)))
        //            {
        //                con.Open();
        //                SqlCommand cmd = new SqlCommand("IF NOT EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[RPTWeb]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) " +
        //                                                "BEGIN " +
        //                                                    "CREATE TABLE [dbo].[RPTWeb] ([ParentSiteId] uniqueidentifier, [ParentWebId] uniqueidentifier, [ParentWebUrl] varchar(max), [ParentListId] uniqueidentifier, [ParentItemId] int, [WebId] uniqueidentifier, [WebUrl] varchar(max)) " +
        //                                                "END " +
        //                                                "IF NOT EXISTS (SELECT * FROM [dbo].[RPTWeb] WHERE [ParentSiteId] = '" + siteId.ToString() + "' AND [ParentWebId] = '" + itemParentWeb.ID.ToString() + "' AND [ParentListId] = '" + listId.ToString() + "' AND [ParentItemId] = " + itemId.ToString() + ") " +
        //                                                "BEGIN " +
        //                                                    "INSERT INTO [dbo].[RPTWeb] ([ItemSiteId], [ItemWebId], [ItemListId], [ItemId], [WorkspaceStatus], [WebId]) VALUES ('" + siteId.ToString() + "', '" + itemParentWeb.ID.ToString() + "', '" + listId.ToString() + "', " + itemId.ToString() + ", 'In Progress', '" + Guid.Empty.ToString() + "')" +
        //                                                "END ");
        //                cmd.Connection = con;
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    });
        //}

        public static Guid GetParentWebId(Guid itemSiteId, Guid itemWebId, Guid itemListId, int itemId)
        {
            Guid id = Guid.Empty;
            SPFieldUrlValue url = null;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (SPSite s = new SPSite(itemSiteId))
                {
                    using (SPWeb w = s.OpenWeb(itemWebId))
                    {
                        try
                        {
                            SPList l = w.Lists[itemListId];
                            SPListItem i = l.GetItemById(itemId);
                            url = new SPFieldUrlValue(i["WorkspaceUrl"].ToString());
                        }
                        catch { }
                    }
                }

                if (url != null)
                {
                    using (SPSite s = new SPSite(url.Url))
                    {
                        using (SPWeb w = s.OpenWeb())
                        {
                            if (w.Exists)
                            {
                                id = w.ID;
                            }
                        }
                    }
                }
            });

            return id;
        }
    }
}
