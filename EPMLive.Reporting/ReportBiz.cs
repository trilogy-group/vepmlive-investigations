using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

namespace EPMLiveReportsAdmin
{
    public sealed class ReportBiz
    {
        private readonly bool _reportingV2Enabled;
        private readonly Guid _siteId;
        private readonly Guid _webAppId;
        private readonly Guid _webId;
        private string _webTitle = string.Empty;

        public ReportBiz(Guid siteId)
        {
            _siteId = siteId;
        }

        public ReportBiz(Guid siteId, Guid webId, bool reportingV2Enabled)
        {
            _siteId = siteId;
            _webId = webId;
            _reportingV2Enabled = reportingV2Enabled;
        }

        public ReportBiz(Guid siteId, Guid webAppId)
        {
            _siteId = siteId;
            _webAppId = webAppId;
        }

        public string WebTitle
        {
            get
            {
                if (string.IsNullOrEmpty(_webTitle))
                {
                    using (var s = new SPSite(_siteId))
                    {
                        using (SPWeb w = s.OpenWeb())
                        {
                            if (w.Exists)
                            {
                                _webTitle = w.Title;
                            }
                        }
                    }
                }

                return _webTitle;
            }
        }

        public bool SiteExists()
        {
            var rd = new ReportData(_siteId);
            return rd.GetSite() != null;
        }

        public Collection<string> GetMappedLists()
        {
            var rd = new ReportData(_siteId);
            var mappings = new Collection<string>();
            DataTable dt = rd.GetListMappings();
            foreach (DataRow row in dt.Rows)
            {
                mappings.Add(row["ListName"].ToString());
            }
            return mappings;
        }

        public Collection<string> GetMappedListsIds()
        {
            var rd = new ReportData(_siteId);
            var mappings = new Collection<string>();
            DataTable dt = rd.GetListMappings();
            foreach (DataRow row in dt.Rows)
            {
                mappings.Add(row["RPTListId"].ToString());
            }
            return mappings;
        }

        public bool RemoveDatabaseMapping()
        {
            var rd = new ReportData(_siteId, _webAppId);
            //var count = rd.GetExistingDbCount();
            //if (count == 1)
            //    return true; //This is the last Site in the DB...

            //DataTable lists = rd.GetListMappings();
            //bool success = true; //TODO - use this
            //foreach (DataRow list in lists.Rows)
            //{
            //    var listId = new Guid(list["ListId"].ToString());
            //    success = success
            //              && rd.DeleteWork(listId)
            //              && rd.DeleteList(listId)
            //              && rd.DeleteTable(list["TableNameSnapshot"].ToString())
            //              && rd.DeleteTable(list["TableName"].ToString())
            //              && rd.DeleteLog(listId)
            //        ;
            //}
            rd.DeleteDbEntry();

            return false;
        }

        public ListBiz GetListBiz(Guid listId)
        {
            return new ListBiz(listId, _siteId);
        }

        public ListBiz CreateListBiz(Guid listId, ListItemCollection fields)
        {
            return ListBiz.CreateNewMapping(_siteId, listId, fields, false);
        }

        public ListBiz CreateListBiz(Guid listId, Guid webId, ListItemCollection fields)
        {
            return ListBiz.CreateNewMapping(_siteId, listId, webId, fields);
        }

        /// <summary>
        ///     Maps a new list to reporting DB with all columns added.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public ListBiz CreateListBiz(Guid listId)
        {
            var fields = new ListItemCollection();
            return ListBiz.CreateNewMapping(_siteId, listId, fields, true);
        }

        public DataRow SAccountInfo(Guid webAppId)
        {
            var DAO = new EPMData(_siteId, webAppId);
            return DAO.SAccountInfo();
        }

        public Dictionary<string, string> GetDatabaseMappings()
        {
            var rd = new ReportData(_siteId, _webAppId);
            DataTable dt = rd.GetDbMappings();
            var databases = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                string key = string.Format("{0}", row["SiteId"]);
                string val = string.Format("{0},{1}", row["DatabaseServer"], row["DatabaseName"]);
                if (!databases.ContainsKey(key))
                    databases.Add(key, val);
            }
            return databases;
        }

        public Dictionary<string, string> GetDistinctDatabaseList()
        {
            var rd = new ReportData(_siteId, _webAppId);
            DataTable dt = rd.GetDistinctDbMappings();
            var databases = new Dictionary<string, string>();
            foreach (DataRow row in dt.Rows)
            {
                string key = string.Format("{0}:{1}", row["DatabaseServer"], row["DatabaseName"]);
                string val = string.Format("{0},{1}", row["DatabaseServer"], row["DatabaseName"]);
                databases.Add(key, val);
            }
            return databases;
        }

        public bool RefreshTimesheet(out string message, Guid jobUid)
        {
            var rd = new ReportData(_siteId);
            bool hasErrors = false;
            rd.LogStatus("",
                "TimeSheet",
                "Begin refreshing time sheet data for web: " + WebTitle,
                "Begin refreshing time sheet data for web: " + WebTitle,
                0, 1, jobUid.ToString());

            DataTable tblTSData = rd.GetTSAllDataWithSchema();

            if (tblTSData == null)
            {
                message = "No timesheet data exists.";
                rd.Dispose();
                hasErrors = true;
            }

            //Delete Timesheetdata start 
            rd.LogStatus("",
                "TimeSheet",
                "Begin deleting existing time sheet data for web: " + WebTitle,
                "Begin deleting existing time sheet data for web: " + WebTitle,
                0, 1, jobUid.ToString());

            rd.DeleteExistingTSData();
            rd.LogStatus("",
                "TimeSheet",
                "Finished deleting existing time sheet data for web: " + WebTitle,
                "Finished deleting existing time sheet data for web: " + WebTitle,
                0, 1, jobUid.ToString());
            //End

            //IF performance becomes an issue, change rpttsduid to int and auto-increment. 
            //Thus eliminating the need for the population routine below. xjh
            tblTSData.Columns.Add("rpttsduid", Type.GetType("System.Guid"));

            //Populate rpttsduid column -- Start            
            foreach (DataRow TSItem in tblTSData.Rows)
            {
                Guid rptuid = Guid.NewGuid();
                TSItem["rpttsduid"] = rptuid;
            }
            // -- End

            var columns = new ColumnDefCollection(tblTSData.Columns);
            string sTableName = rd.GetSafeTableName("RPTTSData");

            rd.LogStatus("",
                "TimeSheet",
                "Recreating RPTTSData for web: " + WebTitle,
                "Recreating RPTTSData for web: " + WebTitle,
                0, 1, jobUid.ToString());
            if (!rd.CreateTable(sTableName, columns, true, out message))
            {
                rd.Dispose();
                hasErrors = true;
                rd.LogStatus("",
                    "TimeSheet",
                    "Error occured while recreating RPTTSData for web: " + WebTitle + ".",
                    message,
                    0, 1, jobUid.ToString());
            }
            rd.LogStatus("",
                "TimeSheet",
                "Finished recreating RPTTSData for web: " + WebTitle,
                "Finished recreating RPTTSData for web: " + WebTitle,
                0, 1, jobUid.ToString());

            rd.LogStatus("", "TimeSheet",
                "Inserting data to RPTTSData for web: " + WebTitle,
                "Inserting data to RPTTSData for web: " + WebTitle,
                0, 1, jobUid.ToString());
            if (!rd.InsertTSAllData(tblTSData, out message))
            {
                rd.Dispose();
                hasErrors = true;
                rd.LogStatus("",
                    "TimeSheet",
                    "Error occurred while inserting data into RPTTSData for web: " + WebTitle,
                    message, 0, 3, jobUid.ToString());
            }
            rd.LogStatus("", "TimeSheet",
                "Finished inserting data to RPTTSData for web: " + WebTitle,
                "Finished inserting data to RPTTSData for web: " + WebTitle,
                0, 1, jobUid.ToString());
            rd.Dispose();
            //message = "Successfully refreshed timesheet data.";
            rd.LogStatus("",
                "TimeSheet",
                "Finished refreshing time sheet data for web: " + WebTitle,
                "Finished refreshing time sheet data for web: " + WebTitle,
                0, 1, jobUid.ToString());

            return hasErrors;
        }

        //Modules created by xjh -- START
        public DataTable GetAllForeignKeys(EPMData DAO)
        {
            //Initialize return value DataTable (will hold all FK update scripts for both live and snapshot tables)
            var AllForeignKeysByTable = new DataTable();
            AllForeignKeysByTable.Columns.Add("TABLE_NAME");
            AllForeignKeysByTable.Columns.Add("SNAPSHOT_TABLE_NAME");
            AllForeignKeysByTable.Columns.Add("FK_TABLE_SCRIPT");
            AllForeignKeysByTable.Columns.Add("FK_SNAPSHOT_TABLE_SCRIPT");

            //Get All mapped lists
            //DAO.Command = "SELECT * FROM RPTList WHERE SiteId='" + _siteId.ToString() + "'"; - CAT.NET
            DAO.Command = "SELECT * FROM RPTList WHERE SiteId=@siteId";
            DAO.AddParam("@siteId", _siteId);
            DataTable AllMappedLists = DAO.GetTable(DAO.GetClientReportingConnection);

            //Get All lookup fields for ALL mapped lists 
            string sql =
                "SELECT dbo.RPTColumn.RPTListId,  dbo.RPTList.ListName, dbo.RPTList.TableName, dbo.RPTList.TableNameSnapshot, dbo.RPTColumn.InternalName , dbo.RPTColumn.ColumnName" +
                " FROM dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId " +
                "WHERE dbo.RPTList.SiteId=@siteId AND (dbo.RPTColumn.SharePointType = N'lookup') AND ColumnType = 'Int'";
            DAO.Command = sql;
            DAO.AddParam("@siteId", _siteId);
            DataTable AllListsLookupFields = DAO.GetTable(DAO.GetClientReportingConnection);

            //Initialize and open topsite/web
            SPWeb web = null;
            SPSite site = null;

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                site = new SPSite(_siteId);
                web = site.OpenWeb(); //IGNORE SPDispose 110, web is being disposed outside scope
            });

            try
            {
                //Loop thru all mapped lists
                foreach (DataRow list in AllMappedLists.Rows)
                {
                    //Init. Lookup fields for list
                    DataRow[] lookupFields = AllListsLookupFields.Select("RPTListId='" + list["RPTListId"] + "'");

                    //Check for lookup fields for this list
                    if (lookupFields != null && lookupFields.Length > 0)
                    {
                        //Init. list
                        SPList childList = null;
                        try
                        {
                            childList = web.Lists[list["ListName"].ToString()];
                        }
                        catch { }

                        if (childList == null)
                        {
                            foreach (SPWeb w in site.AllWebs)
                            {
                                try
                                {
                                    childList = w.Lists[list["ListName"].ToString()];
                                }
                                catch { }

                                w.Close();

                                if (childList != null)
                                {
                                    break;
                                }
                            }
                        }

                        //Loop thru all list lookup fields
                        foreach (DataRow lookupField in lookupFields)
                        {
                            var field =
                                (SPFieldLookup)
                                    childList.Fields.GetFieldByInternalName(lookupField["InternalName"].ToString());
                            if (field.TypeAsString.ToLower() != "filteredlookup" && field.LookupList != null &&
                                field.LookupList != string.Empty)
                            {
                                string listuid = field.LookupList;
                                SPList parentList = null;
                                try
                                {
                                    parentList = web.Lists[new Guid(listuid)];
                                }
                                catch { }
                                DataRow[] childListInfo =
                                    AllMappedLists.Select("ListName='" + childList.Title.Replace("'", "") + "'");
                                // - CAT.NET false-positive: All single quotes are escaped/removed.
                                DataRow[] parentListInfo = null;
                                if (parentList != null)
                                {
                                    try
                                    {
                                        parentListInfo =
                                            AllMappedLists.Select("ListName='" + parentList.Title.Replace("'", "") + "'");
                                        // - CAT.NET false-positive: All single quotes are escaped/removed.
                                    }
                                    catch { }
                                }

                                if (parentListInfo != null && parentListInfo.Length > 0)
                                {
                                    //CAT.NET (issue) - Not being updated. Internal call, table name check and validation is done prior to reaching this point.
                                    string parentTableName = parentListInfo[0]["TableName"].ToString();
                                    string childTableName = childListInfo[0]["TableName"].ToString();
                                    string childTableSnapShotName = childListInfo[0]["TableNameSnapshot"].ToString();
                                    string fieldName = lookupField["InternalName"].ToString();

                                    //Init. LST_XXXX_Table FK SCRIPT
                                    string LST_TABLE_FK_SCRIPT =
                                        "IF (EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = \'" +
                                        childTableName + "\')) " +
                                        "BEGIN " +
                                        "ALTER TABLE [dbo].[" + childTableName + "] WITH NOCHECK " +
                                        "ADD CONSTRAINT [FK_EPMLIVE_" + lookupField["InternalName"] + "_" +
                                        childTableName.ToUpper() + "_" + parentTableName.ToUpper() +
                                        "] FOREIGN KEY([webid], [" + lookupField["ColumnName"] + "]) REFERENCES [dbo].[" +
                                        parentTableName + "] ([WebId], [ItemId]) NOT FOR REPLICATION " +
                                        "ALTER TABLE [dbo].[" + childTableName + "] NOCHECK CONSTRAINT [FK_EPMLIVE_" +
                                        lookupField["InternalName"] + "_" + childTableName.ToUpper() + "_" +
                                        parentTableName.ToUpper() + "] " +
                                        "END ";

                                    //Init. LST_XXXX_Snapshot_Table FK SCRIPT
                                    string LST_SNAPSHOT_TABLE_FK_SCRIPT =
                                        "IF (EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = \'" +
                                        childTableSnapShotName + "\')) " +
                                        "BEGIN " +
                                        "ALTER TABLE [dbo].[" + childTableSnapShotName + "] WITH NOCHECK " +
                                        "ADD CONSTRAINT [FK_EPMLIVE_" + lookupField["InternalName"] + "_" +
                                        childTableSnapShotName.ToUpper() + "_" + parentTableName.ToUpper() +
                                        "] FOREIGN KEY([webid], [" + lookupField["ColumnName"] + "]) REFERENCES [dbo].[" +
                                        parentTableName + "] ([WebId], [ItemId]) NOT FOR REPLICATION " +
                                        "ALTER TABLE [dbo].[" + childTableSnapShotName.ToUpper() +
                                        "] NOCHECK CONSTRAINT [FK_EPMLIVE_" + lookupField["InternalName"] + "_" +
                                        childTableSnapShotName.ToUpper() + "_" + parentTableName.ToUpper() + "] " +
                                        "END ";

                                    //Add FK SCRIPTS
                                    DataRow row = AllForeignKeysByTable.NewRow();
                                    row["TABLE_NAME"] = childTableName.Replace("'", "''");
                                    // - CAT.NET false-positive: All single quotes are escaped/removed.
                                    row["FK_TABLE_SCRIPT"] = LST_TABLE_FK_SCRIPT;
                                    //.Replace("'", "''"); // - CAT.NET false-positive: All single quotes are escaped/removed.
                                    row["SNAPSHOT_TABLE_NAME"] = childTableSnapShotName.Replace("'", "''");
                                    // - CAT.NET false-positive: All single quotes are escaped/removed.
                                    row["FK_SNAPSHOT_TABLE_SCRIPT"] = LST_SNAPSHOT_TABLE_FK_SCRIPT;
                                    //.Replace("'", "''"); // - CAT.NET false-positive: All single quotes are escaped/removed.
                                    AllForeignKeysByTable.Rows.Add(row);
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                if (web != null)
                {
                    try
                    {
                        web.Dispose();
                    }
                    catch { }
                }

                if (site != null)
                {
                    try
                    {
                        site.Dispose();
                    }
                    catch { }
                }
            }

            if (web != null)
            {
                try
                {
                    web.Dispose();
                }
                catch { }
            }

            if (site != null)
            {
                try
                {
                    site.Dispose();
                }
                catch { }
            }

            return AllForeignKeysByTable;
        }

        public DataTable GetSpecificForeignKey(EPMData DAO, string listId, string tableName, string columnName)
        {
            // Checks if the specified column has foreign key associated with it
            bool hasForeignKey = HasForeignKey(DAO, tableName, columnName);

            //Initialize return value DataTable (will hold all FK update scripts for both live and snapshot tables)
            var ForeignKeysByTable = new DataTable();
            ForeignKeysByTable.Columns.Add("TABLE_NAME");
            ForeignKeysByTable.Columns.Add("SNAPSHOT_TABLE_NAME");
            ForeignKeysByTable.Columns.Add("FK_TABLE_SCRIPT");
            ForeignKeysByTable.Columns.Add("FK_SNAPSHOT_TABLE_SCRIPT");
            // Get script if foreign key found
            if (hasForeignKey)
            {
                // Get specific lookup field from list
                string sql =
                    "SELECT dbo.RPTColumn.RPTListId,  dbo.RPTList.ListName, dbo.RPTList.TableName, dbo.RPTList.TableNameSnapshot, dbo.RPTColumn.InternalName , dbo.RPTColumn.ColumnName" +
                    " FROM dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId " +
                    "WHERE dbo.RPTList.SiteId=@siteId AND dbo.RPTList.RPTListId=@listId AND (dbo.RPTColumn.SharePointType = N'lookup') " +
                    "AND (ColumnType = 'Int' OR ColumnType = 'NTEXT') AND dbo.RPTColumn.ColumnName = @columnName";
                DAO.Command = sql;
                DAO.AddParam("@siteId", DAO.SiteId);
                DAO.AddParam("@listId", listId);
                DAO.AddParam("@columnName", columnName);
                DataTable ListLookupFields = DAO.GetTable(DAO.GetClientReportingConnection);

                //Initialize and open topsite/web
                SPWeb web = null;
                SPSite site = null;
                SPList childList = null;

                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    site = new SPSite(DAO.SiteId);
                    web = site.OpenWeb(); //IGNORE SPDispose 110, web is being disposed outside scope
                    childList = web.Lists[new Guid(listId)];
                });

                if (childList == null)
                {
                    foreach (SPWeb w in site.AllWebs)
                    {
                        try
                        {
                            childList = w.Lists[new Guid(listId)];
                        }
                        catch { }

                        w.Close();

                        if (childList != null)
                        {
                            break;
                        }
                    }
                }

                try
                {
                    if (ListLookupFields != null && ListLookupFields.Rows.Count > 0)
                    {
                        foreach (DataRow lookupField in ListLookupFields.Rows)
                        {
                            var field =
                                (SPFieldLookup)
                                    childList.Fields.GetFieldByInternalName(lookupField["InternalName"].ToString());
                            if (field.TypeAsString.ToLower() != "filteredlookup" && field.LookupList != null &&
                                field.LookupList != string.Empty)
                            {
                                #region Get parent list info of lookup field
                                string listuid = field.LookupList;
                                SPList parentList = null;
                                try
                                {
                                    parentList = web.Lists[new Guid(listuid)];
                                }
                                catch { }
                                DataRow parentListInfo = null;
                                if (parentList != null)
                                {
                                    try
                                    {
                                        //Get All mapped lists
                                        DAO.Command = "SELECT * FROM RPTList WHERE SiteId=@siteId AND RPTListId=@listId";
                                        DAO.AddParam("@siteId", DAO.SiteId);
                                        DAO.AddParam("@listId", parentList.ID);
                                        DataTable parentListTable = DAO.GetTable(DAO.GetClientReportingConnection);

                                        if (parentListTable != null && parentListTable.Rows.Count > 0)
                                        {
                                            parentListInfo = parentListTable.Rows[0];
                                        }
                                    }
                                    catch { }
                                }
                                #endregion

                                #region Add foreign key script to table
                                if (parentListInfo != null)
                                {
                                    string parentTableName = parentListInfo["TableName"].ToString();
                                    //string childTableName = childListInfo[0]["TableName"].ToString();
                                    string childTableName = lookupField["TableName"].ToString();
                                    //string childTableSnapShotName = childListInfo[0]["TableNameSnapshot"].ToString();
                                    string childTableSnapShotName = lookupField["TableNameSnapshot"].ToString();
                                    string fieldName = lookupField["InternalName"].ToString();

                                    //Init. LST_XXXX_Table FK SCRIPT
                                    string LST_TABLE_FK_SCRIPT =
                                        "IF (EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = \'" +
                                        childTableName + "\')) " +
                                        "BEGIN " +
                                        "ALTER TABLE [dbo].[" + childTableName + "] WITH NOCHECK " +
                                        "ADD CONSTRAINT [FK_EPMLIVE_" + lookupField["InternalName"] + "_" +
                                        childTableName.ToUpper() + "_" + parentTableName.ToUpper() +
                                        "] FOREIGN KEY([webid], [" + lookupField["ColumnName"] + "]) REFERENCES [dbo].[" +
                                        parentTableName + "] ([WebId], [ItemId]) NOT FOR REPLICATION " +
                                        "ALTER TABLE [dbo].[" + childTableName + "] NOCHECK CONSTRAINT [FK_EPMLIVE_" +
                                        lookupField["InternalName"] + "_" + childTableName.ToUpper() + "_" +
                                        parentTableName.ToUpper() + "] " +
                                        "END ";

                                    //Init. LST_XXXX_Snapshot_Table FK SCRIPT
                                    string LST_SNAPSHOT_TABLE_FK_SCRIPT =
                                        "IF (EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = \'" +
                                        childTableSnapShotName + "\')) " +
                                        "BEGIN " +
                                        "ALTER TABLE [dbo].[" + childTableSnapShotName + "] WITH NOCHECK " +
                                        "ADD CONSTRAINT [FK_EPMLIVE_" + lookupField["InternalName"] + "_" +
                                        childTableSnapShotName.ToUpper() + "_" + parentTableName.ToUpper() +
                                        "] FOREIGN KEY([webid], [" + lookupField["ColumnName"] + "]) REFERENCES [dbo].[" +
                                        parentTableName + "] ([WebId], [ItemId]) NOT FOR REPLICATION " +
                                        "ALTER TABLE [dbo].[" + childTableSnapShotName.ToUpper() +
                                        "] NOCHECK CONSTRAINT [FK_EPMLIVE_" + lookupField["InternalName"] + "_" +
                                        childTableSnapShotName.ToUpper() + "_" + parentTableName.ToUpper() + "] " +
                                        "END ";

                                    //Add FK SCRIPTS
                                    DataRow row = ForeignKeysByTable.NewRow();
                                    row["TABLE_NAME"] = childTableName.Replace("'", "''");
                                    // - CAT.NET false-positive: All single quotes are escaped/removed.
                                    row["FK_TABLE_SCRIPT"] = LST_TABLE_FK_SCRIPT;
                                    //.Replace("'", "''"); // - CAT.NET false-positive: All single quotes are escaped/removed.
                                    row["SNAPSHOT_TABLE_NAME"] = childTableSnapShotName.Replace("'", "''");
                                    // - CAT.NET false-positive: All single quotes are escaped/removed.
                                    row["FK_SNAPSHOT_TABLE_SCRIPT"] = LST_SNAPSHOT_TABLE_FK_SCRIPT;
                                    //.Replace("'", "''"); // - CAT.NET false-positive: All single quotes are escaped/removed.
                                    ForeignKeysByTable.Rows.Add(row);
                                }
                                #endregion
                            }
                        }
                    }
                }
                catch { }
                finally
                {
                    if (web != null)
                    {
                        web.Dispose();
                    }
                    if (site != null)
                    {
                        site.Dispose();
                    }
                }
            }
            return ForeignKeysByTable;
        }

        private bool HasForeignKey(EPMData DAO, string tableName, string columnName)
        {
            bool hasForeignKey = false;
            try
            {
                DAO.Command = "SELECT DISTINCT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
                              "WHERE TABLE_NAME = '" + tableName + "' AND COLUMN_NAME = '" + columnName + "' AND CONSTRAINT_NAME LIKE 'FK_%'";

                object result = DAO.ExecuteScalar(DAO.GetClientReportingConnection);
                if (result != null)
                {
                    hasForeignKey = true;
                }
                return hasForeignKey;
            }
            catch (Exception)
            {
                return hasForeignKey;
            }
        }

        public bool UpdateForeignKeys(EPMData DAO)
        {
            DataTable AllForeignKeysByList = GetAllForeignKeys(DAO);

            //Loop thru list tables and ADD FOREIGN KEYS
            foreach (DataRow AllListForeignKeys in AllForeignKeysByList.Rows)
            {
                //DELETE EXISTING FK's from list table
                DAO.Command =
                    "BEGIN TRY " +
                    "WHILE EXISTS(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME like 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) " +
                    "BEGIN " +
                    "DECLARE @cName nvarchar(Max) " +
                    "SELECT @cName = (SELECT TOP 1 [CONSTRAINT_NAME] FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE CONSTRAINT_NAME LIKE 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) " +
                    "DECLARE @sql nvarchar(Max) " +
                    "SELECT @sql = 'ALTER TABLE ' + @tableName + ' DROP CONSTRAINT ' + @cName " +
                    "EXEC sp_executesql @sql " +
                    "END " +
                    "END TRY " +
                    "BEGIN CATCH " +
                    "PRINT 'Error Detected' " +
                    "END CATCH";
                DAO.AddParam("@tableName", AllListForeignKeys["TABLE_NAME"].ToString());
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                DAO.ExecuteNonQuery(DAO.GetClientReportingConnection);

                //DELETE EXISTING FK's from list snapshot table
                DAO.Command =
                    "BEGIN TRY " +
                    "WHILE EXISTS(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME like 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) " +
                    "BEGIN " +
                    "DECLARE @cName nvarchar(Max) " +
                    "SELECT @cName = (SELECT TOP 1 [CONSTRAINT_NAME] FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE CONSTRAINT_NAME LIKE 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) " +
                    "DECLARE @sql nvarchar(Max) " +
                    "SELECT @sql = 'ALTER TABLE ' + @tableName + ' DROP CONSTRAINT ' + @cName " +
                    "EXEC sp_executesql @sql " +
                    "END " +
                    "END TRY " +
                    "BEGIN CATCH " +
                    "PRINT 'Error Detected' " +
                    "END CATCH";
                DAO.AddParam("@tableName", AllListForeignKeys["SNAPSHOT_TABLE_NAME"].ToString());
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                DAO.ExecuteNonQuery(DAO.GetClientReportingConnection);

                //ADD FK's to list table
                DAO.Command = AllListForeignKeys["FK_TABLE_SCRIPT"].ToString();
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                DAO.ExecuteNonQuery(DAO.GetClientReportingConnection);

                //ADD FK's to list snapshot table
                DAO.Command = AllListForeignKeys["FK_SNAPSHOT_TABLE_SCRIPT"].ToString();
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                DAO.ExecuteNonQuery(DAO.GetClientReportingConnection);
            }
            return true;
        }

        public bool AddORRemoveForeignKey(EPMData DAO, DataRow foreignKey, bool addOperation)
        {
            if (!addOperation)
            {
                //DELETE EXISTING FK's from list table
                DAO.Command =
                    "BEGIN TRY " +
                    "WHILE EXISTS(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME like 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) " +
                    "BEGIN " +
                    "DECLARE @cName nvarchar(Max) " +
                    "SELECT @cName = (SELECT TOP 1 [CONSTRAINT_NAME] FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE CONSTRAINT_NAME LIKE 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) " +
                    "DECLARE @sql nvarchar(Max) " +
                    "SELECT @sql = 'ALTER TABLE ' + @tableName + ' DROP CONSTRAINT ' + @cName " +
                    "EXEC sp_executesql @sql " +
                    "END " +
                    "END TRY " +
                    "BEGIN CATCH " +
                    "PRINT 'Error Detected' " +
                    "END CATCH";
                DAO.AddParam("@tableName", foreignKey["TABLE_NAME"].ToString());
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                DAO.ExecuteNonQuery(DAO.GetClientReportingConnection);

                //DELETE EXISTING FK's from list snapshot table
                DAO.Command =
                    "BEGIN TRY " +
                    "WHILE EXISTS(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME like 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) " +
                    "BEGIN " +
                    "DECLARE @cName nvarchar(Max) " +
                    "SELECT @cName = (SELECT TOP 1 [CONSTRAINT_NAME] FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE CONSTRAINT_NAME LIKE 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) " +
                    "DECLARE @sql nvarchar(Max) " +
                    "SELECT @sql = 'ALTER TABLE ' + @tableName + ' DROP CONSTRAINT ' + @cName " +
                    "EXEC sp_executesql @sql " +
                    "END " +
                    "END TRY " +
                    "BEGIN CATCH " +
                    "PRINT 'Error Detected' " +
                    "END CATCH";
                DAO.AddParam("@tableName", foreignKey["SNAPSHOT_TABLE_NAME"].ToString());
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                DAO.ExecuteNonQuery(DAO.GetClientReportingConnection);
            }
            else
            {
                //ADD FK's to list table
                DAO.Command = foreignKey["FK_TABLE_SCRIPT"].ToString();
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                DAO.ExecuteNonQuery(DAO.GetClientReportingConnection);

                //ADD FK's to list snapshot table
                DAO.Command = foreignKey["FK_SNAPSHOT_TABLE_SCRIPT"].ToString();
                // - CAT.NET false-positive: All single quotes are escaped/removed.
                DAO.ExecuteNonQuery(DAO.GetClientReportingConnection);
            }
            return true;
        }

        public DataTable GetReferencingTables(EPMData DAO, string sTableName)
        {
            string sql = string.Format("EXEC sp_MSdependencies N'{0}', null, 1315327", sTableName.Replace("'", ""));
            // - CAT.NET false-positive: All single quotes are escaped/removed.
            //string sql = "EXEC sp_MSdependencies N'{0}', null, 1315327";
            DAO.Command = sql;
            //DAO.AddParam("@tableName", sTableName);
            return DAO.GetTable(DAO.GetClientReportingConnection);
        }

        //Modules created by xjh -- END
    }
}