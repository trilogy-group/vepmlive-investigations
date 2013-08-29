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

        //public static void SendErrorSignalsToDB(string error, Guid siteId, Guid webId, Guid listId, int itemId)
        //{
        //    SPSecurity.RunWithElevatedPrivileges(() =>
        //    {
        //        using (SPSite eSite = new SPSite(siteId))
        //        {
        //            using (SqlConnection con = new SqlConnection(CoreFunctions.getReportingConnectionString(eSite.WebApplication.Id, eSite.ID)))
        //            {
        //                con.Open();
        //                SqlCommand cmd = new SqlCommand("IF EXISTS (SELECT * FROM [dbo].[RPTWeb] WHERE [ItemSiteId] = '" + siteId.ToString() + "' AND [ItemWebId] = '" + webId.ToString() + "' AND [ItemListId] = '" + listId.ToString() + "' AND [ItemId] = " + itemId.ToString() + ") " +
        //                                                "BEGIN " +
        //                                                    "UPDATE [dbo].[RPTWeb] SET [WorkspaceStatus] = 'ERROR: " + error + "' WHERE [ItemSiteId] = '" + siteId.ToString() + "' AND [ItemWebId] = '" + webId.ToString() + "' AND [ItemListId] = '" + listId.ToString() + "' AND [ItemId] = " + itemId.ToString() + " " +
        //                                                "END " +
        //                                                "ELSE " +
        //                                                "BEGIN " +
        //                                                    "INSERT INTO [dbo].[RPTWeb] ([ItemSiteId], [ItemWebId], [ItemListId], [ItemId], [WorkspaceStatus], [WebId]) VALUES ( '" + siteId.ToString() + "', '" + webId.ToString() + "', '" + listId.ToString() + "', '" + itemId.ToString() + "', 'ERROR: " + error + "', '" + Guid.Empty.ToString() + "') " + 
        //                                                "END ");

        //                cmd.Connection = con;
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //    });
        //}

        public static void SendCompletedSignalsToDB(Guid siteId, SPWeb itemWeb, SPWeb parentWeb, Guid listId, int itemId, Guid createdWebId, string createdWebUrl)
        {
            SPSecurity.RunWithElevatedPrivileges(() =>
            {
                using (SPSite eSite = new SPSite(siteId))
                {
                    using (SqlConnection con = new SqlConnection(CoreFunctions.getReportingConnectionString(eSite.WebApplication.Id, eSite.ID)))
                    {
                        con.Open();
                        
                        SqlCommand cmd = new SqlCommand("IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[RPTWeb]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1) " +
                                                        "BEGIN " +
                                                            // if record exists, delete then insert
                                                            "IF EXISTS (SELECT * FROM [dbo].[RPTWeb] WHERE [WebId] = '" + createdWebId.ToString() + "') " +
                                                            "BEGIN " +
                                                                "DELETE FROM [dbo].[RPTWeb] WHERE [WebId] = '" + createdWebId.ToString() + "' " +
                                                            "END " +
                                                            "ELSE " +
                                                            "BEGIN " +
                                                                "INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl]) VALUES ('" + siteId.ToString() + "', '" + itemWeb.ID.ToString() + "', '" + listId.ToString() + "', " + itemId.ToString() + ", '" + parentWeb.ID.ToString() + "', '" + createdWebId.ToString() + "', '" + createdWebUrl.ToString() + "') " +
                                                            "END " +
                                                        "END " +
                                                        "ELSE " +
                                                        "BEGIN " +
                                                        // create table
                                                            "CREATE TABLE [dbo].[RPTWeb] ([SiteId] uniqueidentifier, [ItemWebId] uniqueidentifier, [ItemListId] uniqueidentifier, [ItemId] int, [ParentWebId] uniqueidentifier, [WebId] uniqueidentifier, [WebUrl] varchar(max)) " +
                                                        // insert
                                                            "INSERT INTO [dbo].[RPTWeb] ([SiteId], [ItemWebId], [ItemListId], [ItemId], [ParentWebId], [WebId], [WebUrl]) VALUES ('" + siteId.ToString() + "', '" + itemWeb.ID.ToString() + "', '" + listId.ToString() + "', " + itemId.ToString() + ", '" + parentWeb.ID.ToString() + "', '" + createdWebId.ToString() + "', '" + createdWebUrl.ToString() + "') " +
                                                        "END ");
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
                using (SPSite eSite = new SPSite(siteId))
                {
                    using (SqlConnection con = new SqlConnection(CoreFunctions.getConnectionString(eSite.WebApplication.Id)))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        switch (type){
                            case 1:
                                //cmd = new SqlCommand("INSERT INTO [dbo].[FRF] ([SITE_ID], [WEB_ID], [USER_ID], [Title], [Type]) VALUES ('" + siteId.ToString() + "', '" + createdWebId.ToString() + "', " + userId.ToString() + ", '" + createdWebUrl.ToString() + "', 1)");
                                break;
                            case 2:
                                //cmd = new SqlCommand("INSERT INTO [dbo].[FRF] ([SITE_ID], [WEB_ID], [USER_ID], [Title], [Type]) VALUES ('" + siteId.ToString() + "', '" + createdWebId.ToString() + "', " + userId.ToString() + ", '" + createdWebUrl.ToString() + "', 2)");
                                break;
                            case 3:
                                //cmd = new SqlCommand("INSERT INTO [dbo].[FRF] ([SITE_ID], [WEB_ID], [USER_ID], [Title], [Type]) VALUES ('" + siteId.ToString() + "', '" + createdWebId.ToString() + "', " + userId.ToString() + ", '" + createdWebUrl.ToString() + "', 3)");
                                break;
                            case 4:
                                cmd = new SqlCommand("INSERT INTO [dbo].[FRF] ([SITE_ID], [WEB_ID], [USER_ID], [Title], [F_String], [Type]) VALUES ('" + siteId.ToString() + "', '" + createdWebId.ToString() + "', " + userId.ToString() + ", '" + siteTitle + "', '" + createdWebUrl.ToString() + "', 4)");
                                break;
                            default:
                                break;  
                        }

                        cmd.Connection = con;
                        cmd.ExecuteNonQuery();
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
