﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public static class WorkspaceData
    {
        public static bool IsFirstAttempt(SPSite site, SPWeb web, string listId, string itemId)
        {
            var iRecs = 0;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                Guard.ArgumentIsNotNull(site, nameof(site));
                var siteId = site.ID;
                using (var eSite = new SPSite(site.ID))
                {
                    using (var con = new SqlConnection(CoreFunctions.getConnectionString(site.WebApplication.Id)))
                    {
                        con.Open();
                        using (var cmd = new SqlCommand(WorkspaceQueries.GetFirstAttemptQuery(siteId, web, listId, itemId)))
                        {
                            cmd.Connection = con;
                            iRecs = int.Parse(cmd.ExecuteScalar().ToString());
                        }
                    }
                }
            });

            return iRecs == 0;
        }

        public static void SendCompletedSignalsToDB(
            Guid siteId,
            SPWeb itemWeb,
            SPWeb parentWeb,
            Guid listId,
            int itemId,
            Guid createdWebId,
            string createdWebServerRelativeUrl,
            string createdWebTitle,
            string creatorId,
            string createdWebDescription)
        {
            Guard.ArgumentIsNotNull(itemWeb, nameof(itemWeb));

            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var eSite = new SPSite(siteId))
                {
                    var eRootWeb = eSite.RootWeb;

                    using (var con = new SqlConnection(
                        CoreFunctions.getReportingConnectionString(eSite.WebApplication.Id, eSite.ID)))
                    {
                        con.Open();

                        using (var cmd = new SqlCommand(WorkspaceQueries.GetSendCompletedSignalsQuery(
                            siteId,
                            itemWeb.ID,
                            parentWeb,
                            listId,
                            itemId,
                            createdWebId,
                            createdWebServerRelativeUrl,
                            createdWebTitle,
                            creatorId,
                            createdWebDescription,
                            eSite,
                            eRootWeb)))
                        {
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            });
        }

        public static void SendCompletedSignalsToDB(
            Guid siteId,
            SPWeb parentWeb,
            Guid createdWebId,
            string createdWebServerRelativeUrl,
            string createdWebTitle,
            string creatorId,
            string createdWebDescription)
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var eSite = new SPSite(siteId))
                {
                    var eRootWeb = eSite.RootWeb;

                    using (var con = new SqlConnection(
                        CoreFunctions.getReportingConnectionString(eSite.WebApplication.Id, eSite.ID)))
                    {
                        con.Open();

                        using (var cmd = new SqlCommand(WorkspaceQueries.GetSendCompletedSignalsQuery(
                            siteId,
                            Guid.Empty,
                            parentWeb,
                            Guid.Empty,
                            -1,
                            createdWebId,
                            createdWebServerRelativeUrl,
                            createdWebTitle,
                            creatorId,
                            createdWebDescription,
                            eSite,
                            eRootWeb)))
                        {
                            cmd.Connection = con;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            });
        }

        public static void AddToFRF(
            Guid siteId,
            Guid createdWebId,
            string siteTitle,
            string createdWebUrl,
            int userId,
            int type)
        {
            // type legend
            // 1 = favorites
            // 2 = recent
            // 3 = frequent apps
            // 4 = workspace
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var spSite = new SPSite(siteId))
                {
                    using (var con = new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                    {
                        con.Open();
                        using (var cmd = new SqlCommand
                        {
                            CommandText = WorkspaceQueries.GetAddToFRFQuery(
                                siteId,
                                createdWebId,
                                siteTitle,
                                createdWebUrl,
                                userId),
                            Connection = con
                        })
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            });
        }

        public static void AddToFRF(
            Guid siteId,
            Guid createdWebId,
            string siteTitle,
            string createdWebUrl,
            int userId,
            int type,
            Guid listId,
            int itemId)
        {
            // type legend
            // 1 = favorites
            // 2 = recent
            // 3 = frequent apps
            // 4 = workspace
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var spSite = new SPSite(siteId))
                {
                    using (var con = new SqlConnection(CoreFunctions.getConnectionString(spSite.WebApplication.Id)))
                    {
                        con.Open();
                        using (var cmd = new SqlCommand
                        {
                            CommandText = WorkspaceQueries.GetAddToFRFQuery(
                                siteId,
                                createdWebId,
                                siteTitle,
                                createdWebUrl,
                                userId,
                                listId,
                                itemId),
                            Connection = con
                        })
                        {
                            cmd.ExecuteNonQuery();
                        }
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
                                                  "ALTER TABLE[dbo].[RPTWEBGROUPS]      ADD CONSTRAINT UQ_RPTWEBGROUPS_SITEID_WEBID_GROUPID UNIQUE(SITEID, WEBID, GROUPID)" +
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
                using (var spSite = new SPSite(siteId))
                {
                    using (var spWeb = spSite.OpenWeb(createdWebId))
                    {
                        using (var con = new SqlConnection(
                            CoreFunctions.getReportingConnectionString(spSite.WebApplication.Id, spSite.ID)))
                        {
                            con.Open();
                            WriteTableToServer(spSite, spWeb, con);

                            try
                            {
                                const string epmLiveReportingAssembly = "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";
                                MethodInfo methodInfo = null;
                                Assembly assemblyInstance = null;
                                Type thisClass = null;
                                object apiClass = null;
                                // use reflection to map list
                                try
                                {
                                    assemblyInstance = Assembly.Load(epmLiveReportingAssembly);
                                    thisClass = assemblyInstance.GetType("EPMLiveReportsAdmin.ProcessSecurity", true, true);
                                    methodInfo = thisClass.GetMethod(
                                        "ProcessSecurityGroups",
                                        BindingFlags.Public | BindingFlags.Static);
                                }
                                catch (Exception ex)
                                {
                                    Trace.WriteLine(ex);
                                }

                                if (methodInfo != null && assemblyInstance != null && thisClass != null)
                                {
                                    using (var conn = new SqlConnection(
                                        CoreFunctions.getReportingConnectionString(spSite.WebApplication.Id, spSite.ID)))
                                    {
                                        conn.Open();
                                        methodInfo.Invoke(null, new object[]
                                        {
                                            spSite,
                                            conn,
                                            string.Empty
                                        });
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Trace.WriteLine(ex);
                            }
                        }
                    }
                }
            });
        }

        private static void WriteTableToServer(SPSite spSite, SPWeb spWeb, SqlConnection con)
        {
            using (var cmd = new SqlCommand(WorkspaceQueries.EnsureRptWebScript) { Connection = con })
            {
                cmd.ExecuteNonQuery();
            }

            using (var table = new DataTable())
            {
                var column = new DataColumn("RPTWEBGROUPS") { DataType = Type.GetType("System.Guid") };
                table.Columns.Add(column);
                column = new DataColumn("SITEID") { DataType = Type.GetType("System.Guid") };
                table.Columns.Add(column);
                column = new DataColumn("WEBID") { DataType = Type.GetType("System.Guid") };
                table.Columns.Add(column);
                column = new DataColumn("GROUPID") { DataType = Type.GetType("System.Int32") };
                table.Columns.Add(column);
                column = new DataColumn("SECTYPE") { DataType = Type.GetType("System.Int32") };
                table.Columns.Add(column);

                foreach (SPRoleAssignment roleAssignment in spWeb.RoleAssignments)
                {
                    var type = roleAssignment.Member is SPGroup
                        ? 1
                        : 0;

                    var found = roleAssignment.RoleDefinitionBindings.Cast<SPRoleDefinition>()
                        .Any(def => (def.BasePermissions & SPBasePermissions.ViewListItems) == SPBasePermissions.ViewListItems);
                    if (found)
                    {
                        table.Rows.Add(new object[] { Guid.NewGuid(), spSite.ID, spWeb.ID, roleAssignment.Member.ID, type });
                    }
                }

                table.Rows.Add(new object[] { Guid.NewGuid(), spSite.ID, spWeb.ID, 999999, 1 });

                using (var bulkCopy = new SqlBulkCopy(con))
                {
                    bulkCopy.DestinationTableName = "dbo.RPTWEBGROUPS";
                    bulkCopy.WriteToServer(table);
                }
            }
        }

        public static bool DoesWorkspaceExist(Guid siteId, Guid webId, Guid listId, int itemId)
        {
            bool exists = false;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var eSite = new SPSite(siteId))
                {
                    using (var con = new SqlConnection(
                        CoreFunctions.getReportingConnectionString(eSite.WebApplication.Id, eSite.ID)))
                    {
                        con.Open();

                        using (var cmd = new SqlCommand(WorkspaceQueries.GetDoesWorkSpaceExistQuery(siteId, webId, listId, itemId)))
                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                bool.TryParse(rdr[0].ToString(), out exists);
                            }
                        }
                    }
                }
            });

            return exists;
        }

        public static string GetWorkspaceStatus(Guid siteId, Guid webId, Guid listId, int itemId)
        {
            var status = "NotTried";
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var eSite = new SPSite(siteId))
                {
                    using (var con = new SqlConnection(CoreFunctions.getConnectionString(eSite.WebApplication.Id)))
                    {
                        con.Open();
                        using (var cmd = new SqlCommand(
                            "SELECT q.[Status] FROM TIMERJOBS j JOIN [QUEUE] q ON j.timerjobuid = q.timerjobuid WHERE j.[siteguid] = '" + siteId.ToString() + "' AND j.[webguid] = '" + webId.ToString() + "' AND j.[listguid] = '" + listId.ToString() + "' AND j.[itemid] = " + itemId.ToString()))
                        {
                            cmd.Connection = con;
                            using (var rdr = cmd.ExecuteReader())
                            {
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
                    }
                }
            });

            return status;
        }

        public static string GetWorkspaceUrl(Guid siteId, Guid webId, Guid listId, int itemId)
        {
            var url = string.Empty;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var spSite = new SPSite(siteId))
                {
                    using (var spWeb = spSite.OpenWeb(webId))
                    {
                        SPFieldUrlValue spUrl = null;
                        try
                        {
                            spUrl = new SPFieldUrlValue(spWeb.Lists[listId].GetItemById(itemId)["WorkspaceUrl"].ToString());
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex);
                        }

                        if (spUrl != null)
                        {
                            url = spUrl.Url;
                        }
                    }
                }
            });

            return url;
        }

        public static Guid GetParentWebId(Guid itemSiteId, Guid itemWebId, Guid itemListId, int itemId)
        {
            var id = Guid.Empty;
            SPFieldUrlValue url = null;
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (var spSite = new SPSite(itemSiteId))
                {
                    using (var spWeb = spSite.OpenWeb(itemWebId))
                    {
                        try
                        {
                            var spList = spWeb.Lists[itemListId];
                            var listItem = spList.GetItemById(itemId);
                            url = new SPFieldUrlValue(listItem["WorkspaceUrl"].ToString());
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine(ex);
                        }
                    }
                }

                if (url != null)
                {
                    using (var spSite = new SPSite(url.Url))
                    {
                        using (var spWeb = spSite.OpenWeb())
                        {
                            if (spWeb.Exists)
                            {
                                id = spWeb.ID;
                            }
                        }
                    }
                }
            });

            return id;
        }
    }
}
