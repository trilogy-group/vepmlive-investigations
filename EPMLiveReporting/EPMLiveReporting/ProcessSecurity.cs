using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin
{
    public class ProcessSecurity
    {
        public static void ProcessSecurityGroups(SPSite site, SqlConnection cn, string users)
        {
            if (!SecurityTablesExist(cn))
            {
                return;
            }

            users = users.Trim();

            string[] sUsers = users.Split(',');

            SqlCommand cmd;

            if (users == "")
            {
                cmd = new SqlCommand("DELETE FROM RPTGROUPUSER where SITEID=@siteid", cn);
                cmd.Parameters.AddWithValue("@siteid", site.ID);
                cmd.ExecuteNonQuery();
            }

            var dt = new DataTable();
            var dc = new DataColumn("RPTGROUPUSERID") { DataType = Type.GetType("System.Guid") };
            dt.Columns.Add(dc);
            dc = new DataColumn("SITEID") { DataType = Type.GetType("System.Guid") };
            dt.Columns.Add(dc);
            dc = new DataColumn("GROUPID") { DataType = Type.GetType("System.Int32") };
            dt.Columns.Add(dc);
            dc = new DataColumn("USERID") { DataType = Type.GetType("System.Int32") };
            dt.Columns.Add(dc);

            if (users != "")
            {
                foreach (string sUser in sUsers.Where(sUser => sUser != ""))
                {
                    try
                    {
                        SPUser user = site.RootWeb.SiteUsers.GetByID(int.Parse(sUser));

                        cmd = new SqlCommand("DELETE FROM RPTGROUPUSER where SITEID=@siteid and userid=@userid", cn);
                        cmd.Parameters.AddWithValue("@siteid", site.ID);
                        cmd.Parameters.AddWithValue("@userid", sUser);
                        cmd.ExecuteNonQuery();

                        foreach (SPGroup group in user.Groups)
                        {
                            dt.Rows.Add(new object[] { Guid.NewGuid(), site.ID, @group.ID, user.ID });
                        }

                        if (user.IsSiteAdmin)
                            dt.Rows.Add(new object[] { Guid.NewGuid(), site.ID, 999999, user.ID });
                    }
                    catch { }
                }
            }
            else
            {
                foreach (SPGroup group in site.RootWeb.SiteGroups)
                {
                    foreach (SPUser u in group.Users)
                    {
                        dt.Rows.Add(new object[] { Guid.NewGuid(), site.ID, group.ID, u.ID });
                    }
                }

                foreach (SPUser u in from SPUser u in site.RootWeb.SiteUsers where u.IsSiteAdmin select u)
                {
                    dt.Rows.Add(new object[] { Guid.NewGuid(), site.ID, 999999, u.ID });
                }
            }

            using (var bulkCopy = new SqlBulkCopy(cn))
            {
                bulkCopy.DestinationTableName =
                    "dbo.RPTGROUPUSER";

                bulkCopy.WriteToServer(dt);
            }
        }

        public static void ProcessSecurityOnListRefresh(SPWeb w, SPList list, SqlConnection cn)
        {
            if (!SecurityTablesExist(cn))
            {
                return;
            }

            var dt = new DataTable();
            var dc = new DataColumn("RPTIEMGROUPID") { DataType = Type.GetType("System.Guid") };
            dt.Columns.Add(dc);
            dc = new DataColumn("SITEID") { DataType = Type.GetType("System.Guid") };
            dt.Columns.Add(dc);
            dc = new DataColumn("LISTID") { DataType = Type.GetType("System.Guid") };
            dt.Columns.Add(dc);
            dc = new DataColumn("ITEMID") { DataType = Type.GetType("System.Int32") };
            dt.Columns.Add(dc);
            dc = new DataColumn("GROUPID") { DataType = Type.GetType("System.Int32") };
            dt.Columns.Add(dc);
            dc = new DataColumn("SECTYPE") { DataType = Type.GetType("System.Int32") };
            dt.Columns.Add(dc);

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (var site = new SPSite(w.Site.ID))
                {
                    var cmd = new SqlCommand("DELETE RPTITEMGROUPS where siteid=@siteid and listid=@listid", cn);
                    cmd.Parameters.AddWithValue("@siteid", site.ID);
                    cmd.Parameters.AddWithValue("@listid", list.ID);
                    cmd.ExecuteNonQuery();

                    SPListItemCollection liCol = list.Items;

                    foreach (SPListItem li in liCol)
                    {
                        try
                        {
                            foreach (SPRoleAssignment ra in from SPRoleAssignment ra in li.RoleAssignments
                                                            let found =
                                                                ra.RoleDefinitionBindings.Cast<SPRoleDefinition>()
                                                                    .Any(
                                                                        def =>
                                                                            (def.BasePermissions & SPBasePermissions.ViewListItems) ==
                                                                            SPBasePermissions.ViewListItems)
                                                            where found
                                                            select ra)
                            {
                                dt.Rows.Add(new object[]
                                {
                                Guid.NewGuid(), site.ID, list.ID, li.ID,
                                ra.Member.ID, ((ra.Member is SPGroup) ? 1 : 0)
                                });
                            }

                            dt.Rows.Add(new object[] { Guid.NewGuid(), site.ID, list.ID, li.ID, 999999, 1 });
                        }
                        catch { }
                    }

                    using (var bulkCopy = new SqlBulkCopy(cn))
                    {
                        bulkCopy.DestinationTableName =
                            "dbo.RPTITEMGROUPS";

                        bulkCopy.WriteToServer(dt);
                    }
                }
            });
        }

        public static void ProcessSecurityOnRefreshAll(SPWeb w, List<SPList> liCol, SqlConnection cn)
        {
            if (!SecurityTablesExist(cn))
            {
                return;
            }

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (var site = new SPSite(w.Site.ID))
                {
                    using (SPWeb web = site.OpenWeb(w.ID))
                    {
                        foreach (SPList li in liCol)
                        {
                            ProcessSecurityOnListRefresh(web, li, cn);
                        }
                    }
                }
            });
        }

        private static bool SecurityTablesExist(SqlConnection cn)
        {
            bool exists = false;
            try
            {
                var cmd =
                    new SqlCommand(
                        "IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND  TABLE_NAME = 'RPTGROUPUSER')) BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END",
                        cn);
                exists = Convert.ToInt32(cmd.ExecuteScalar()) == 1;
            }
            catch { }
            return exists;
        }
    }
}