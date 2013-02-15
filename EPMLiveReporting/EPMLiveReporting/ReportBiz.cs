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
        private readonly Guid _siteId;
        private readonly Guid _webAppId;

        public ReportBiz(Guid siteId)
        {
            _siteId = siteId;
        }

        public ReportBiz(Guid siteId, Guid webAppId)
        {
            _siteId = siteId;
            _webAppId = webAppId;
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

            return ListBiz.CreateNewMapping(_siteId, listId, fields);
        }

        /// <summary>
        /// Maps a new list to reporting DB with all columns added.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns></returns>
        public ListBiz CreateListBiz(Guid listId)
        {
            return ListBiz.CreateNewMapping(_siteId, listId);
        }

        public DataRow SAccountInfo(Guid webAppId)
        {
            EPMData DAO = new EPMData(_siteId, webAppId);
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

        public bool RefreshTimesheet(out string message)
        {
            var rd = new ReportData(_siteId);
            bool hasErrors = false;

            DataTable tblTSData = rd.GetTSAllDataWithSchema();

            if (tblTSData == null)
            {
                message = "No timesheet data exists.";
                rd.Dispose();
                hasErrors = true;
            }

            //Delete Timesheetdata start 
            rd.DeleteExistingTSData();
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

            if (!rd.CreateTable(sTableName, columns, true, out message))
            {
                rd.Dispose();
                hasErrors = true;
            }

            if (!rd.InsertTSAllData(tblTSData, out message))
            {
                rd.Dispose();
                hasErrors = true;
            }

            rd.Dispose();
            //message = "Successfully refreshed timesheet data.";
            return hasErrors;
        }

        //Modules created by xjh -- START
        public DataTable GetAllForeignKeys(EPMData DAO)
        {
            //Initialize return value DataTable (will hold all FK update scripts for both live and snapshot tables)
            DataTable AllForeignKeysByTable = new DataTable();
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
            string sql = "SELECT dbo.RPTColumn.RPTListId,  dbo.RPTList.ListName, dbo.RPTList.TableName, dbo.RPTList.TableNameSnapshot, dbo.RPTColumn.InternalName , dbo.RPTColumn.ColumnName" +
            " FROM dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId " +
            "WHERE dbo.RPTList.SiteId=@siteId AND (dbo.RPTColumn.SharePointType = N'lookup') AND ColumnType = 'Int'";
            DAO.Command = sql;
            DAO.AddParam("@siteId", _siteId);
            DataTable AllListsLookupFields = DAO.GetTable(DAO.GetClientReportingConnection);

            //Initialize and open topsite/web
            SPWeb web = null;
            SPSite site = null;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                site = new SPSite(_siteId);
                web = site.OpenWeb();
            });

            //Loop thru all mapped lists
            foreach (DataRow list in AllMappedLists.Rows)
            {
                //Init. Lookup fields for list
                DataRow[] lookupFields = AllListsLookupFields.Select("RPTListId='" + list["RPTListId"].ToString() + "'");

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
                        SPFieldLookup field = (SPFieldLookup)childList.Fields.GetFieldByInternalName(lookupField["InternalName"].ToString());
                        if (field.TypeAsString.ToLower() != "filteredlookup" && field.LookupList != null && field.LookupList != string.Empty)
                        {
                            string listuid = field.LookupList;
                            SPList parentList = null;
                            try
                            {
                                parentList = web.Lists[new Guid(listuid)];
                            }
                            catch { }
                            DataRow[] childListInfo = AllMappedLists.Select("ListName='" + childList.Title.Replace("'", "") + "'"); // - CAT.NET false-positive: All single quotes are escaped/removed.
                            DataRow[] parentListInfo = null;
                            if (parentList != null)
                            {
                                try
                                {
                                    parentListInfo = AllMappedLists.Select("ListName='" + parentList.Title.Replace("'", "") + "'"); // - CAT.NET false-positive: All single quotes are escaped/removed.
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
                                       "IF (EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = \'" + childTableName + "\')) " +
                                           "BEGIN " +
                                               "ALTER TABLE [dbo].[" + childTableName + "] WITH NOCHECK " +
                                               "ADD CONSTRAINT [FK_EPMLIVE_" + lookupField["InternalName"].ToString() + "_" + childTableName.ToUpper() + "_" + parentTableName.ToUpper() + "] FOREIGN KEY([webid], [" + lookupField["ColumnName"].ToString() + "]) REFERENCES [dbo].[" + parentTableName + "] ([WebId], [ItemId]) NOT FOR REPLICATION " +
                                               "ALTER TABLE [dbo].[" + childTableName + "] NOCHECK CONSTRAINT [FK_EPMLIVE_" + lookupField["InternalName"].ToString() + "_" + childTableName.ToUpper() + "_" + parentTableName.ToUpper() + "] " +
                                           "END ";

                                //Init. LST_XXXX_Snapshot_Table FK SCRIPT
                                string LST_SNAPSHOT_TABLE_FK_SCRIPT =
                                    "IF (EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = \'" + childTableSnapShotName + "\')) " +
                                        "BEGIN " +
                                            "ALTER TABLE [dbo].[" + childTableSnapShotName + "] WITH NOCHECK " +
                                            "ADD CONSTRAINT [FK_EPMLIVE_" + lookupField["InternalName"].ToString() + "_" + childTableSnapShotName.ToUpper() + "_" + parentTableName.ToUpper() + "] FOREIGN KEY([webid], [" + lookupField["ColumnName"].ToString() + "]) REFERENCES [dbo].[" + parentTableName + "] ([WebId], [ItemId]) NOT FOR REPLICATION " +
                                            "ALTER TABLE [dbo].[" + childTableSnapShotName.ToUpper() + "] NOCHECK CONSTRAINT [FK_EPMLIVE_" + lookupField["InternalName"].ToString() + "_" + childTableSnapShotName.ToUpper() + "_" + parentTableName.ToUpper() + "] " +
                                        "END ";

                                //Add FK SCRIPTS
                                DataRow row = AllForeignKeysByTable.NewRow();
                                row["TABLE_NAME"] = childTableName.Replace("'", "''"); // - CAT.NET false-positive: All single quotes are escaped/removed.
                                row["FK_TABLE_SCRIPT"] = LST_TABLE_FK_SCRIPT; //.Replace("'", "''"); // - CAT.NET false-positive: All single quotes are escaped/removed.
                                row["SNAPSHOT_TABLE_NAME"] = childTableSnapShotName.Replace("'", "''"); // - CAT.NET false-positive: All single quotes are escaped/removed.
                                row["FK_SNAPSHOT_TABLE_SCRIPT"] = LST_SNAPSHOT_TABLE_FK_SCRIPT; //.Replace("'", "''"); // - CAT.NET false-positive: All single quotes are escaped/removed.
                                AllForeignKeysByTable.Rows.Add(row);
                            }
                        }
                    }
                }
            }

            if (site != null)
            {
                site.Close();
            }

            return AllForeignKeysByTable;
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
                DAO.AddParam("@tableName", AllListForeignKeys["TABLE_NAME"].ToString()); // - CAT.NET false-positive: All single quotes are escaped/removed.
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
                DAO.AddParam("@tableName", AllListForeignKeys["SNAPSHOT_TABLE_NAME"].ToString()); // - CAT.NET false-positive: All single quotes are escaped/removed.
                DAO.ExecuteNonQuery(DAO.GetClientReportingConnection);

                //ADD FK's to list table
                DAO.Command = AllListForeignKeys["FK_TABLE_SCRIPT"].ToString(); // - CAT.NET false-positive: All single quotes are escaped/removed.
                DAO.ExecuteNonQuery(DAO.GetClientReportingConnection);

                //ADD FK's to list snapshot table
                DAO.Command = AllListForeignKeys["FK_SNAPSHOT_TABLE_SCRIPT"].ToString(); // - CAT.NET false-positive: All single quotes are escaped/removed.
                DAO.ExecuteNonQuery(DAO.GetClientReportingConnection);
            }
            return true;
        }

        public DataTable GetReferencingTables(EPMData DAO, string sTableName)
        {
            string sql = string.Format("EXEC sp_MSdependencies N'{0}', null, 1315327", sTableName.Replace("'", ""));// - CAT.NET false-positive: All single quotes are escaped/removed.
            //string sql = "EXEC sp_MSdependencies N'{0}', null, 1315327";
            DAO.Command = sql;
            //DAO.AddParam("@tableName", sTableName);
            return DAO.GetTable(DAO.GetClientReportingConnection);
        }
        //Modules created by xjh -- END
    }
}