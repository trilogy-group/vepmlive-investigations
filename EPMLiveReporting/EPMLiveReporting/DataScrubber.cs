using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin
{
    public static class DataScrubber
    {
        public static void CleanTables(SPSite site, EPMData epmdata)
        {
            #region WIPE DATA FROM ReportListIds, RPTWeb, and RPTWEBGROUPS TABLE

            SqlCommand cmd;
            cmd = new SqlCommand("DELETE FROM ReportListIds", epmdata.GetClientReportingConnection);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("DELETE FROM RPTWeb", epmdata.GetClientReportingConnection);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("DELETE FROM RPTWEBGROUPS", epmdata.GetClientReportingConnection);
            cmd.ExecuteNonQuery();

            #endregion

            #region REPOPULATE ReportListIds, RPTWeb, RPTWEBGROUPS, AND FRF-Recent TABLES

            var listNames = new DataTable();

            var listIds = new DataTable();
            listIds.Columns.Add(new DataColumn("Id", typeof (Guid)));

            var rptWeb = new DataTable();
            rptWeb.Columns.Add(new DataColumn("SiteId", typeof (Guid)));
            rptWeb.Columns.Add(new DataColumn("ItemWebId", typeof (Guid)));
            rptWeb.Columns.Add(new DataColumn("ItemListId", typeof (Guid)));
            rptWeb.Columns.Add(new DataColumn("ItemId", typeof (int)));
            rptWeb.Columns.Add(new DataColumn("ParentWebId", typeof (Guid)));
            rptWeb.Columns.Add(new DataColumn("WebId", typeof (Guid)));
            rptWeb.Columns.Add(new DataColumn("WebUrl", typeof (string)));
            rptWeb.Columns.Add(new DataColumn("WebTitle", typeof (string)));

            var listIdsTest = new DataTable();
            var rptWebTest = new DataTable();

            string errMsg = string.Empty;
            bool hasError = false;
            string sDelSql = string.Empty;
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                cmd = new SqlCommand("SELECT [ListName], [TableName] FROM RPTList");
                cmd.Connection = epmdata.GetClientReportingConnection;
                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(listNames);

                using (var es = new SPSite(site.ID))
                {
                    foreach (SPWeb w in es.AllWebs)
                    {
                        #region GATHER WEB INFO
                        var sParentItem = string.Empty;
                        try
                        {
                            sParentItem = es.RootWeb.AllProperties["ParentItem"].ToString();
                        }
                        catch
                        {
                        }

                        var r = rptWeb.Rows.Add();
                        if (!string.IsNullOrEmpty(sParentItem))
                        {
                            var sa = sParentItem.Split(new[] {"^^"}, StringSplitOptions.RemoveEmptyEntries);
                            var sItemWebId = sa[0];
                            var sItemListId = sa[0];
                            var sItemId = sa[0];
                            
                            r["SiteId"] = es.ID;
                            r["ItemWebId"] = !string.IsNullOrEmpty(sItemWebId) ? new Guid(sItemWebId) : Guid.Empty;
                            r["ItemListId"] = !string.IsNullOrEmpty(sItemListId) ? new Guid(sItemListId) : Guid.Empty;
                            r["ItemId"] = !string.IsNullOrEmpty(sItemId) ? int.Parse(sItemId) : -1;
                            r["ParentWebId"] = w.ParentWeb != null ? w.ParentWeb.ID : Guid.Empty;
                            r["WebId"] = w.ID;
                            r["WebUrl"] = w.Url;
                            r["WebTitle"] = w.Title;
                        }
                        else
                        {   
                            r["SiteId"] = es.ID;
                            r["ItemWebId"] = Guid.Empty;
                            r["ItemListId"] = Guid.Empty;
                            r["ItemId"] = -1;
                            r["ParentWebId"] = w.ParentWeb != null ? w.ParentWeb.ID : Guid.Empty;
                            r["WebId"] = w.ID;
                            r["WebUrl"] = w.Url;
                            r["WebTitle"] = w.Title;
                        }
                        #endregion

                        #region  POPULATE RPTWEBGROUPS

                        try
                        {
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
                                    dt.Rows.Add(new object[] { Guid.NewGuid(), es.ID, w.ID, ra.Member.ID, type });
                                }
                            }

                            dt.Rows.Add(new object[] { Guid.NewGuid(), es.ID, w.ID, 999999, 1 });

                            using (var bulkCopy = new SqlBulkCopy(epmdata.GetClientReportingConnection))
                            {
                                bulkCopy.DestinationTableName =
                                    "dbo.RPTWEBGROUPS";

                                bulkCopy.WriteToServer(dt);
                            }
                        }
                        catch (Exception e)
                        {
                            hasError = true;
                            errMsg += e.Message;
                        }

                        #endregion

                        #region GATHER VALID LISTS
                        // IGNORE SPDispose 130, Web is being disposed
                        try
                        {
                            if (listNames.Rows.Count > 0)
                            {
                                string sName = string.Empty;

                                foreach (DataRow row in listNames.Rows)
                                {
                                    try
                                    {
                                        sName = row["ListName"].ToString();
                                    }
                                    catch
                                    {
                                    }

                                    if (!string.IsNullOrEmpty(sName))
                                    {
                                        SPList tempList = w.Lists.TryGetList(sName);
                                        if (tempList != null)
                                        {
                                            DataRow dr = listIds.Rows.Add();
                                            dr["Id"] = tempList.ID;
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e1)
                        {
                            hasError = true;
                            errMsg += e1.Message;
                        }
                        #endregion

                        if (w != null)
                        {
                            w.Dispose();
                        }
                    }

                    #region BULK INSERT ReportListIds TABLE
                    if (listIds.Rows.Count > 0)
                    {
                        SqlTransaction tx = epmdata.GetClientReportingConnection.BeginTransaction();
                        using (
                            var sbc = new SqlBulkCopy(epmdata.GetClientReportingConnection, new SqlBulkCopyOptions(),
                                tx))
                        {
                            try
                            {
                                sbc.DestinationTableName = "ReportListIds";
                                sbc.ColumnMappings.Add("Id", "Id");
                                sbc.WriteToServer(listIds);
                                sbc.Close();
                                tx.Commit();
                                tx.Dispose();
                            }
                            catch (Exception e2)
                            {
                                hasError = true;
                                errMsg += e2.Message;
                            }
                        }
                    }
                    #endregion

                    #region BULK INSERT RPTWeb TABLE
                    if (rptWeb.Rows.Count > 0)
                    {
                        SqlTransaction tx = epmdata.GetClientReportingConnection.BeginTransaction();
                        using (
                            var sbc = new SqlBulkCopy(epmdata.GetClientReportingConnection, new SqlBulkCopyOptions(),
                                tx))
                        {
                            try
                            {
                                sbc.DestinationTableName = "RPTWeb";
                                sbc.ColumnMappings.Add("SiteId", "SiteId");
                                sbc.ColumnMappings.Add("ItemWebId", "ItemWebId");
                                sbc.ColumnMappings.Add("ItemListId", "ItemListId");
                                sbc.ColumnMappings.Add("ItemId", "ItemId");
                                sbc.ColumnMappings.Add("ParentWebId", "ParentWebId");
                                sbc.ColumnMappings.Add("WebId", "WebId");
                                sbc.ColumnMappings.Add("WebUrl", "WebUrl");
                                sbc.ColumnMappings.Add("WebTitle", "WebTitle");
                                sbc.WriteToServer(rptWeb);
                                sbc.Close();
                                tx.Commit();
                                tx.Dispose();
                            }
                            catch (Exception e3)
                            {
                                hasError = true;
                                errMsg += e3.Message;
                            }
                        }
                    }
                    #endregion
                }

                #region CLEAN LST TABLES - DELETE ENTRIES WITH NONEXISTENT LISTIDS

                cmd = new SqlCommand("SELECT [Id] FROM ReportListIds");
                cmd.Connection = epmdata.GetClientReportingConnection;
                var ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                ad.Fill(listIdsTest);

                if (listIdsTest.Rows.Count == 0)
                {
                    epmdata.LogStatus("",
                        "Data cleaning in Refresh process.",
                        "Cleaning has been cancelled.",
                        "No ids in ReportListIds table.",
                        0, 1, "");
                    //no report ids found, 
                    //something might be wrong so we cancel
                    return;
                }

                foreach (DataRow r in listNames.Rows)
                {
                    string tableName = string.Empty;
                    try
                    {
                        tableName = r["TableName"].ToString();
                    }
                    catch
                    {
                    }

                    if (!string.IsNullOrEmpty(tableName))
                    {
                        sDelSql += "DELETE FROM " + tableName +
                                   " WHERE [ListID] NOT IN (SELECT Id FROM ReportListIds) ";
                    }
                }

                if (!string.IsNullOrEmpty(sDelSql) && !hasError)
                {
                    try
                    {
                        cmd = new SqlCommand(sDelSql);
                        cmd.Connection = epmdata.GetClientReportingConnection;
                        cmd.ExecuteNonQuery();
                        epmdata.LogStatus("",
                            "Data cleaning in Refresh process.",
                            "Success.",
                            "Success.",
                            0, 1, "");
                    }
                    catch (Exception e)
                    {
                        epmdata.LogStatus("",
                            "Data cleaning in Refresh process.",
                            "Error cleaning lst tables. Error: " + e.Message,
                            errMsg,
                            0, 1, "");
                    }
                }
                else
                {
                    epmdata.LogStatus("",
                        "Data cleaning in Refresh process.",
                        "Cleaning has been cancelled.",
                        "Error: " + errMsg,
                        0, 1, "");
                }

                #endregion

                #region  GET VALID FRF - Recent items

                var recent = new DataTable();
                try
                {
                    cmd = new SqlCommand("SELECT * FROM FRF WHERE [Type]=2");
                    cmd.Connection = epmdata.GetEPMLiveConnection;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(recent);
                }
                catch (Exception e)
                {
                    epmdata.LogStatus("",
                        "Data cleaning in Refresh process.",
                        "Error cleaning lst tables. Error: " + e.Message,
                        errMsg,
                        0, 1, "");
                }

                var lsListIds = (from id in listIdsTest.AsEnumerable() select id["Id"].ToString()).ToList();
                var lsWebIds = (from webid in rptWebTest.AsEnumerable() select webid["WebId"].ToString()).ToList();

                var results = (from r in recent.AsEnumerable()
                    where lsListIds.Contains(r["LIST_ID"].ToString()) && lsWebIds.Contains(r["WEB_ID"].ToString())
                    select r).ToList<DataRow>();

                var finalRecent = new DataTable();

                foreach (DataRow row in results)
                {
                    finalRecent.Rows.Add(row);
                }

                #endregion

                #region BULK INSERT FRF - Recent items
                if (finalRecent.Rows.Count > 0)
                {
                    var tx = epmdata.GetEPMLiveConnection.BeginTransaction();
                    using (var sbc = new SqlBulkCopy(epmdata.GetEPMLiveConnection, new SqlBulkCopyOptions(), tx))
                    {
                        try
                        {
                            sbc.DestinationTableName = "FRF";
                            sbc.ColumnMappings.Add("FRF_ID", "FRF_ID");
                            sbc.ColumnMappings.Add("SITE_ID", "SITE_ID");
                            sbc.ColumnMappings.Add("WEB_ID", "WEB_ID");
                            sbc.ColumnMappings.Add("LIST_ID", "LIST_ID");
                            sbc.ColumnMappings.Add("ITEM_ID", "ITEM_ID");
                            sbc.ColumnMappings.Add("USER_ID", "USER_ID");
                            sbc.ColumnMappings.Add("Title", "Title");
                            sbc.ColumnMappings.Add("Icon", "Icon");
                            sbc.ColumnMappings.Add("Type", "Type");
                            sbc.ColumnMappings.Add("F_String", "F_String");
                            sbc.ColumnMappings.Add("F_Date", "F_Date");
                            sbc.ColumnMappings.Add("F_Int", "F_Int");
                            sbc.WriteToServer(rptWeb);
                            sbc.Close();
                            tx.Commit();
                            tx.Dispose();
                        }
                        catch (Exception e3)
                        {
                            epmdata.LogStatus("",
                                "Data cleaning in Refresh process.",
                                "Error cleaning lst tables. Error: " + e3.Message,
                                errMsg,
                                0, 1, "");
                        }
                    }
                }
                #endregion

            });

            #endregion

            
        }
    }
}