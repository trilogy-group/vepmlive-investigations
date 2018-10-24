using System;
using System.Data;
using System.Data.SqlClient;
using EPMLiveCore.Properties;

namespace EPMLiveCore.ReportHelper
{
    public partial class ReportData
    {
        public void CreateTextFile(string sPath)
        {
            _DAO.CreateTextFile(sPath);
        }

        public void WriteToFile(string sText)
        {
            _DAO.WriteToFile(sText);
        }

        public bool DeleteExistingTSData()
        {
            return _DAO.DeleteExistingTSData();
        }

        public DataRow GetSite()
        {
            _DAO.Command = $"select * from [{Resources.ReportingDatabaseTable.Replace(SingleQuote, string.Empty)}] where siteid = @SiteId";
            _DAO.AddParam("@SiteId", _siteId);
            var dt = _DAO.GetTable(_DAO.GetEPMLiveConnection);

            return dt.Rows.Count == 0
                ? null
                : dt.Rows[0];
        }

        public bool ExecuteNonQuery(SqlConnection con)
        {
            return _DAO.ExecuteNonQuery(con);
        }

        public bool CheckServerConnection()
        {
            var passed = _DAO.GetMasterDbConnection.State == ConnectionState.Open;
            _sqlError = _DAO.SqlError;
            return passed;
        }

        public bool DatabaseExists()
        {
            _DAO.Command = $"select db_id('{_DAO.remoteDbName.Replace(SingleQuote, string.Empty)}')";
            return _DAO.ExecuteScalar(_DAO.GetMasterDbConnection) != DBNull.Value;
        }

        public bool IsReportingDB()
        {
            var sql =
                $"IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='{Resources.ReportingSettingsTable.Replace(SingleQuote, string.Empty)}') SELECT 'tablename exists' ELSE SELECT 'tablename does not exist'";
            _DAO.Command = sql;
            var exists = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection).ToString();

            return exists.Equals("tablename exists", StringComparison.OrdinalIgnoreCase);
        }

        public bool TableExists(string tableName)
        {
            _DAO.Command = $"select object_id('{tableName.Replace(SingleQuote, string.Empty)}', 'U')";
            return _DAO.ExecuteScalar(_DAO.GetClientReportingConnection) != DBNull.Value;
        }

        public bool ColumnExists(string tableName, string columnName)
        {
            _DAO.Command =
                $"select count(*) from sys.columns where object_id=object_id('{tableName.Replace(SingleQuote, string.Empty)}', 'U') and name='{columnName}'";

            var executeScalar = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
            return (int)executeScalar > 0;
        }

        public bool ProcedureExists(string procName)
        {
            _DAO.Command = $"select object_id('{procName.Replace(SingleQuote, string.Empty)}', 'P')";
            return _DAO.ExecuteScalar(_DAO.GetClientReportingConnection) != DBNull.Value;
        }

        public string GetError()
        {
            return _sqlError;
        }

        public bool CreateDatabase()
        {
            _DAO.Command = $"create database {_DAO.remoteDbName.Replace(SingleQuote, string.Empty)}";

            if (_DAO.SqlErrorOccurred)
            {
                _sqlError = _DAO.SqlError;
            }

            return _DAO.ExecuteNonQuery(_DAO.GetMasterDbConnection);
        }

        public DataTable GetTableNames(string tableNameRoot)
        {
            _DAO.Command =
                $"select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME like '{tableNameRoot.Replace(SingleQuote, string.Empty)}%' order by TABLE_NAME desc "; // - CAT.NET false-positive: All single quotes are escaped/removed.
            return _DAO.GetTable(_DAO.GetClientReportingConnection);
        }

        public int GetTableCount()
        {
            _DAO.Command = "SELECT TableCount FROM RPTSettings WHERE SiteID=@siteId";
            _DAO.AddParam("@siteId", _siteId);
            var tableCount = (int)_DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
            return tableCount;
        }

        public bool DeleteTable(string name)
        {
            _DAO.Command = string.Format(
                @"IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[{0}]') AND type in (N'U')) DROP TABLE [{0}] ",
                name.Replace(SingleQuote, string.Empty));

            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool DeleteDbEntry()
        {
            _DAO.Command = $"delete from [{Resources.ReportingDatabaseTable.Replace(SingleQuote, string.Empty)}] where SiteId = @SiteId";
            _DAO.AddParam("@SiteId", _siteId);
            return _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
        }

        public DataTable GetDbMappings()
        {
            _DAO.Command = $"select distinct * from [{Resources.ReportingDatabaseTable.Replace(SingleQuote, string.Empty)}]";
            return _DAO.GetTable(_DAO.GetEPMLiveConnection);
        }

        public int GetExistingDbCount()
        {
            _DAO.Command =
                $@"select COUNT(r1.SiteId) from [{Resources.ReportingDatabaseTable.Replace(SingleQuote, string.Empty)}] r1 inner join [{Resources.ReportingDatabaseTable.Replace(SingleQuote, string.Empty)}] r2 on r1.DatabaseName = r2.DatabaseName and r1.DatabaseServer = r2.DatabaseServer where r2.SiteId = @SiteId";
            _DAO.AddParam("@SiteId", _siteId);
            return (int)_DAO.ExecuteScalar(_DAO.GetEPMLiveConnection);
        }

        public DataTable GetDistinctDbMappings()
        {
            _DAO.Command =
                $"select distinct databaseserver, databasename from [{Resources.ReportingDatabaseTable.Replace(SingleQuote, string.Empty)}]";
            return _DAO.GetTable(_DAO.GetEPMLiveConnection);
        }

        public DataTable GetListMappings()
        {
            _DAO.Command = $"select * from [{Resources.ReportingListSummaryView.Replace(SingleQuote, string.Empty)}] where siteId = @SiteId";
            _DAO.AddParam("@SiteId", _siteId);
            return _DAO.GetTable(_DAO.GetClientReportingConnection);
        }

        public DataTable GetListMappings(string listIds)
        {
            _DAO.Command = $"select * from [{Resources.ReportingListSummaryView.Replace(SingleQuote, string.Empty)}] where RPTListID IN ({listIds})";
            return _DAO.GetTable(_DAO.GetClientReportingConnection);
        }

        public DataRow GetListMapping(Guid listId)
        {
            _DAO.Command =
                $"select * from [{Resources.ReportingListSummaryView.Replace(SingleQuote, string.Empty)}] where siteId = @SiteId and rptlistId = @rptListId";
            _DAO.AddParam("@SiteId", _siteId);
            _DAO.AddParam("@rptListId", listId);
            return _DAO.GetRow(_DAO.GetClientReportingConnection);
        }

        public bool DeleteList(Guid listId)
        {
            _DAO.Command = $"delete from [{Resources.ReportingListTable.Replace(SingleQuote, string.Empty)}] where [RPTListId] = @RPTListId ";
            _DAO.AddParam("@RPTListId", listId);
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool DeleteAllListColumns(Guid listId)
        {
            _DAO.Command = string.Format(
                "delete from [@tableName] where [RPTListId] = @RPTListId ",
                Resources.ReportingColumnTable.Replace(SingleQuote, string.Empty));
            _DAO.AddParam("@RPTListId", listId);
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool DeleteWork(Guid guid, int itemId)
        {
            return _DAO.DeleteWork(guid, itemId);
        }

        public bool DeleteWork(Guid guid)
        {
            _DAO.Command = $"delete from [{Resources.ReportingWorkTable.Replace(SingleQuote, string.Empty)}] where [ListId] = @ListId ";
            _DAO.AddParam("@ListId", guid);
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool DeleteMyWork(Guid guid)
        {
            _DAO.Command = "Delete from [LSTMyWork] where [SiteId] = @SiteId AND [ListId] = @ListId";
            _DAO.AddParam("@ListId", guid);
            _DAO.AddParam("@SiteId", _siteId);
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public string GetTableNameSnapshot(Guid listId)
        {
            _DAO.Command =
                $"SELECT TableNameSnapshot FROM [{Resources.ReportingListTable.Replace(SingleQuote, string.Empty)}] WHERE RPTListId= @RPTListId";
            _DAO.AddParam("@RPTListId", listId);
            var objTableName = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
            return objTableName.ToString();
        }

        public DataTable GetTSAllDataWithSchema()
        {
            _DAO.AddParam("@siteuid", _siteId);
            _DAO.Command = "spTSAllData";
            _DAO.CommandType = CommandType.StoredProcedure;
            return _DAO.GetTable(_DAO.GetEPMLiveConnection, true);
        }

        public bool InsertTSAllData(DataTable table, out string message)
        {
            var ds = new DataSet();
            table.TableName = Resources.ReportingTimesheetTable;
            ds.Tables.Add(table);
            _DAO.BulkInsert(ds, false, out message);

            return string.IsNullOrWhiteSpace(message);
        }

        public void RefreshTimeSheet(Guid siteId, string webTitleId, Guid jobId)
        {
            var safeTableName = GetSafeTableName("RPTTSData");
            _DAO.Command = "spRefreshTimesheet_V2";
            _DAO.CommandType = CommandType.StoredProcedure;
            _DAO.AddParam("@dbname", _DAO.GetEPMLiveConnection.Database);
            _DAO.AddParam("@RPTTSData", safeTableName);
            _DAO.AddParam("@siteuid", siteId);
            _DAO.AddParam("@WebTitle", webTitleId);
            _DAO.AddParam("@jobUid", jobId);

            _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public string GetTableName(Guid listId)
        {
            _DAO.Command =
                $"SELECT TableName FROM {Resources.ReportingListTable.Replace(SingleQuote, string.Empty)} WHERE RPTListId=@RPTListId AND SiteId=@siteId";
            _DAO.AddParam("@RPTListId", listId);
            _DAO.AddParam("@siteId", _siteId);
            var objTableName = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
            return objTableName?.ToString() ?? string.Empty;
        }

        public string GetTableName(string listName)
        {
            _DAO.Command =
                $"SELECT TableName FROM {Resources.ReportingListTable.Replace(SingleQuote, string.Empty)} WHERE ListName=@listName AND SiteId=@siteId";
            _DAO.AddParam("@listName", listName);
            _DAO.AddParam("@siteId", _siteId);
            var objTableName = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
            return objTableName?.ToString() ?? string.Empty;
        }

        public DataTable GetListColumns(Guid listUid)
        {
            _DAO.Command =
                "SELECT DISTINCT dbo.RPTColumn.*, dbo.RPTList.ListName FROM dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId WHERE (dbo.RPTList.RPTListId = @listId)";
            _DAO.AddParam("@listId", listUid);
            var dtColumns = _DAO.GetTable(_DAO.GetClientReportingConnection);
            return dtColumns;
        }

        public DataTable GetListColumns(string sListName)
        {
            _DAO.Command =
                "SELECT DISTINCT dbo.RPTColumn.*, dbo.RPTList.ListName FROM dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId WHERE (dbo.RPTList.ListName = @listName) AND dbo.RPTList.SiteId=@siteId";
            _DAO.AddParam("@listName", sListName);
            _DAO.AddParam("@siteId", _siteId);
            var dtColumns = _DAO.GetTable(_DAO.GetClientReportingConnection);
            return dtColumns;
        }

        public bool ListReportsWork(string sTableName)
        {
            _DAO.Command =
                $"SELECT ResourceList FROM {Resources.ReportingListTable.Replace(SingleQuote, string.Empty)} WHERE TableName=\'{sTableName.Replace(SingleQuote, string.Empty)}{SingleQuote}";
            return (bool)_DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
        }

        public bool BulkInsert(DataSet dsLists, Guid timerJobGuid)
        {
            return _DAO.BulkInsert(dsLists, timerJobGuid);
        }

        public bool DeleteListItem(string sSQL)
        {
            _DAO.Command = sSQL;
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public SqlConnection GetClientReportingConnection()
        {
            return _DAO.GetClientReportingConnection;
        }

        public void InitializeStatusLog()
        {
            _DAO.InitializeStatusLog();
        }

        public bool InsertAllItemsDB(DataSet dsLists, Guid timerjobguid)
        {
            return _DAO.BulkInsert(dsLists, timerjobguid);
        }
    }
}