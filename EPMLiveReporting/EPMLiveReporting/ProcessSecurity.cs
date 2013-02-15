using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin
{
    internal class ProcessSecurity
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

            DataTable dt = new DataTable();

            DataColumn dc = new DataColumn("RPTGROUPUSERID");
            dc.DataType = System.Type.GetType("System.Guid");
            dt.Columns.Add(dc);

            dc = new DataColumn("SITEID");
            dc.DataType = System.Type.GetType("System.Guid");
            dt.Columns.Add(dc);

            dc = new DataColumn("GROUPID");
            dc.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            dc = new DataColumn("USERID");
            dc.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            if (users != "")
            {

                foreach (string sUser in sUsers)
                {
                    if (sUser != "")
                    {
                        cmd = new SqlCommand("DELETE FROM RPTGROUPUSER where SITEID=@siteid and userid=@userid", cn);
                        cmd.Parameters.AddWithValue("@siteid", site.ID);
                        cmd.Parameters.AddWithValue("@userid", sUser);
                        cmd.ExecuteNonQuery();

                        SPUser user = site.RootWeb.SiteUsers.GetByID(int.Parse(sUser));
                        foreach (SPGroup group in user.Groups)
                        {
                            dt.Rows.Add(new object[] { Guid.NewGuid(), site.ID, group.ID, user.ID });
                        }

                        if (user.IsSiteAdmin)
                            dt.Rows.Add(new object[] { Guid.NewGuid(), site.ID, 999999, user.ID });
                    }
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

                foreach (SPUser u in site.RootWeb.SiteUsers)
                {
                    if (u.IsSiteAdmin)
                    {
                        dt.Rows.Add(new object[] { Guid.NewGuid(), site.ID, 999999, u.ID });
                    }
                }
            }

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(cn))
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

            DataTable dt = new DataTable();

            DataColumn dc = new DataColumn("RPTIEMGROUPID");
            dc.DataType = System.Type.GetType("System.Guid");
            dt.Columns.Add(dc);

            dc = new DataColumn("SITEID");
            dc.DataType = System.Type.GetType("System.Guid");
            dt.Columns.Add(dc);

            dc = new DataColumn("LISTID");
            dc.DataType = System.Type.GetType("System.Guid");
            dt.Columns.Add(dc);

            dc = new DataColumn("ITEMID");
            dc.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            dc = new DataColumn("GROUPID");
            dc.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            dc = new DataColumn("SECTYPE");
            dc.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(dc);

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(w.Site.ID))
                {
                    using (SPWeb web = site.OpenWeb(w.ID))
                    {
                        SqlCommand cmd = new SqlCommand("DELETE RPTITEMGROUPS where siteid=@siteid and listid=@listid", cn);
                        cmd.Parameters.AddWithValue("@siteid", site.ID);
                        cmd.Parameters.AddWithValue("@listid", list.ID);
                        cmd.ExecuteNonQuery();

                        SPListItemCollection liCol = list.Items;

                        foreach (SPListItem li in liCol)
                        {
                            foreach (SPRoleAssignment ra in li.RoleAssignments)
                            {
                                int type = 0;
                                if (ra.Member.GetType() == typeof(SPGroup))
                                {
                                    type = 1;
                                }
                                bool found = false;
                                foreach (SPRoleDefinition def in ra.RoleDefinitionBindings)
                                {
                                    if ((def.BasePermissions & SPBasePermissions.ViewListItems) == SPBasePermissions.ViewListItems)
                                        found = true;
                                }
                                if (found)
                                {
                                    dt.Rows.Add(new object[] { Guid.NewGuid(), site.ID, list.ID, li.ID, ra.Member.ID, type });
                                }
                            }

                            dt.Rows.Add(new object[] { Guid.NewGuid(), site.ID, list.ID, li.ID, 999999, 1 });
                        }

                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(cn))
                        {
                            bulkCopy.DestinationTableName =
                                "dbo.RPTITEMGROUPS";

                            bulkCopy.WriteToServer(dt);
                        }
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

            //DataTable dt = new DataTable();

            //DataColumn dc = new DataColumn("RPTIEMGROUPID");
            //dc.DataType = System.Type.GetType("System.Guid");
            //dt.Columns.Add(dc);

            //dc = new DataColumn("SITEID");
            //dc.DataType = System.Type.GetType("System.Guid");
            //dt.Columns.Add(dc);

            //dc = new DataColumn("LISTID");
            //dc.DataType = System.Type.GetType("System.Guid");
            //dt.Columns.Add(dc);

            //dc = new DataColumn("ITEMID");
            //dc.DataType = System.Type.GetType("System.Int32");
            //dt.Columns.Add(dc);

            //dc = new DataColumn("GROUPID");
            //dc.DataType = System.Type.GetType("System.Int32");
            //dt.Columns.Add(dc);

            //dc = new DataColumn("SECTYPE");
            //dc.DataType = System.Type.GetType("System.Int32");
            //dt.Columns.Add(dc);

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(w.Site.ID))
                {
                    using (SPWeb web = site.OpenWeb(w.ID))
                    {
                        //foreach (SPList li in liCol)
                        //{
                        //    SqlCommand cmd = new SqlCommand("DELETE RPTITEMGROUPS where siteid=@siteid and listid=@listid", cn);
                        //    cmd.Parameters.AddWithValue("@siteid", site.ID);
                        //    cmd.Parameters.AddWithValue("@listid", li.ID);
                        //    cmd.ExecuteNonQuery();

                        //    SPListItemCollection lc = li.Items;

                        //    foreach (SPListItem lItem in lc)
                        //    {
                        //        foreach (SPRoleAssignment ra in li.RoleAssignments)
                        //        {
                        //            int type = 0;
                        //            if (ra.Member.GetType() == typeof(SPGroup))
                        //            {
                        //                type = 1;
                        //            }
                        //            bool found = false;
                        //            foreach (SPRoleDefinition def in ra.RoleDefinitionBindings)
                        //            {
                        //                if ((def.BasePermissions & SPBasePermissions.ViewListItems) == SPBasePermissions.ViewListItems)
                        //                    found = true;
                        //            }
                        //            if (found)
                        //            {
                        //                dt.Rows.Add(new object[] { Guid.NewGuid(), site.ID, li.ID, lItem.ID, ra.Member.ID, type });
                        //            }
                        //        }

                        //        dt.Rows.Add(new object[] { Guid.NewGuid(), site.ID, li.ID, lItem.ID, 999999, 1 });
                        //    }
                        //}

                        //using (SqlBulkCopy bulkCopy = new SqlBulkCopy(cn))
                        //{
                        //    bulkCopy.DestinationTableName =
                        //        "dbo.RPTITEMGROUPS";

                        //    bulkCopy.WriteToServer(dt);
                        //}

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
                SqlCommand cmd = new SqlCommand("IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND  TABLE_NAME = 'RPTGROUPUSER')) BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END", cn);
                exists = Convert.ToInt32(cmd.ExecuteScalar()) == 1;
            }
            catch
            {

            }

            return exists;
        }

    }
}
