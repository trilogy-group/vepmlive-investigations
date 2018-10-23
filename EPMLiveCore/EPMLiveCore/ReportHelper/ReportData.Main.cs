using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using EPMLiveCore.Helpers;
using EPMLiveCore.Properties;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportHelper
{
    public partial class ReportData
    {
        public bool ProcessAssignments(
            string sWork,
            string sAssignedTo,
            object startDate,
            object dueDate,
            Guid listId,
            Guid siteId,
            int itemId,
            string sListName)
        {
            var blnProcess = true;

            _DAO.Command = "spRPTProcessAssignments";
            _DAO.CommandType = CommandType.StoredProcedure;

            if (!string.IsNullOrWhiteSpace(sWork))
            {
                _DAO.AddParam("@Work", sWork);
            }
            else
            {
                _DAO.AddParam("@Work", DBNull.Value);
            }

            if (!string.IsNullOrWhiteSpace(sAssignedTo))
            {
                _DAO.AddParam("@AssignedTo", sAssignedTo);
            }
            else
            {
                _DAO.AddParam("@AssignedTo", DBNull.Value);
            }

            _DAO.AddParam("@Start", startDate);
            _DAO.AddParam("@Finish", dueDate);
            _DAO.AddParam("@ListID", listId);
            _DAO.AddParam("@SiteID", siteId);
            _DAO.AddParam("@ItemID", itemId);

            _DAO.ExecuteScalar(_DAO.GetClientReportingConnection);

            if (_DAO.SqlErrorOccurred)
            {
                _sqlError = _DAO.SqlError;
            }

            return blnProcess;
        }

        public void GetMappedFields()
        {
            throw new NotImplementedException();
        }

        public string RemoveTags(string sValue, SPField field)
        {
            Guard.ArgumentIsNotNull(field, nameof(field));
            Guard.ArgumentIsNotNull(sValue, nameof(sValue));

            return field.GetFieldValueAsText(sValue);
        }

        protected object GetDefaultColumnValue(string column, SPListItem listItem, out bool blnGuid)
        {
            Guard.ArgumentIsNotNull(listItem, nameof(listItem));
            Guard.ArgumentIsNotNull(column, nameof(column));

            object objectValue = null;
            blnGuid = false;

            switch (column)
            {
                case "siteid":
                    objectValue = listItem.ParentList.ParentWeb.Site.ID;
                    blnGuid = true;
                    break;
                case "webid":
                    objectValue = listItem.ParentList.ParentWeb.ID;
                    blnGuid = true;
                    break;
                case "rptlistid":
                    objectValue = listItem.ParentList.ID;
                    blnGuid = true;
                    break;
                case "listid":
                    objectValue = listItem.ParentList.ID;
                    blnGuid = true;
                    break;
                case "itemid":
                    objectValue = listItem.ID;
                    break;
                case "weburl":
                    objectValue = listItem.ParentList.ParentWeb.ServerRelativeUrl;
                    break;
                default:
                    Trace.WriteLine($"Unexpected value : {column}");
                    break;
            }

            return objectValue;
        }

        private DataTable AddMetaInfoCols(DataTable dataTable)
        {
            Guard.ArgumentIsNotNull(dataTable, nameof(dataTable));
            var result = dataTable;

            if (result != null)
            {
                var listId = dataTable.Rows[0]["RPTListId"].ToString();

                var dataSourceRows = (from DataRow dataRow in dataTable.Rows
                    where dataRow[ColumnName].ToString() == "DataSource"
                    select dataRow).ToList();

                if (dataSourceRows.Count == 0)
                {
                    result.Rows.Add(listId, "DataSource", "NVarChar", "8001", "Integer", "DataSource", "DataSource");
                }

                var workTypeRows = (from DataRow dataRow in dataTable.Rows
                    where dataRow[ColumnName].ToString() == "WorkType"
                    select dataRow).ToList();

                if (workTypeRows.Count == 0)
                {
                    result.Rows.Add(listId, "WorkType", "NVarChar", "256", "Text", "WorkType", "WorkType");
                }

                var commentersRows = (from DataRow dataRow in dataTable.Rows
                    where dataRow[ColumnName].ToString() == "Commenters"
                    select dataRow).ToList();

                if (commentersRows.Count == 0)
                {
                    result.Rows.Add(listId, "Commenters", "NVarChar", "8001", "Text", "Commenters", "Commenters");
                }

                var commentersReadRows = (from DataRow dataRow in dataTable.Rows
                    where dataRow[ColumnName].ToString() == "CommentersRead"
                    select dataRow).ToList();

                if (commentersRows.Count == 0)
                {
                    result.Rows.Add(listId, "CommentersRead", "NVarChar", "8001", "Text", "CommentersRead", "CommentersRead");
                }

                var commentersCountRows = (from DataRow dataRow in dataTable.Rows
                    where dataRow[ColumnName].ToString() == "CommentCount"
                    select dataRow).ToList();

                if (commentersRows.Count == 0)
                {
                    result.Rows.Add(listId, "CommentCount", "NVarChar", "0", "Integer", "CommentCount", "CommentCount");
                }
            }

            return result;
        }

        public bool SnapshotLists(string listName)
        {
            Guard.ArgumentIsNotNull(listName, nameof(listName));
            _DAO.AddParam("@SiteId", _siteId);
            _DAO.AddParam("@Listnames", listName);
            _DAO.AddParam("@Enabled", true);
            _DAO.Command = "spRPTLists";
            _DAO.CommandType = CommandType.StoredProcedure;
            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public string GetSafeTableName(string tableName)
        {
            Guard.ArgumentIsNotNull(tableName, nameof(tableName));
            string tblName;
            var iTableCount = GetTableCount();

            if (iTableCount == 0)
            {
                if (_isReportingV2Enabled && !_isRootWeb)
                {
                    tblName = $"{webTitle}_{tableName}_{_webId.ToString().Replace("-", string.Empty)}";
                    tableName = tblName;
                }
            }
            else
            {
                if (_isReportingV2Enabled && !_isRootWeb)
                {
                    tblName = $"{webTitle}_{tableName}{iTableCount}_{_webId.ToString().Replace("-", string.Empty)}";
                    tableName = tblName;
                }
                else
                {
                    return tableName + iTableCount;
                }
            }

            return tableName;
        }

        public bool CreateTable(string name, List<ColumnDef> columnDefs)
        {
            Guard.ArgumentIsNotNull(columnDefs, nameof(columnDefs));
            string message;
            return CreateTable(name, columnDefs, false, out message);
        }

        public string GetDbVersion(Guid siteId)
        {
            string version;
            var con = _DAO.GetSpecificReportingDbConnection(siteId);

            if (con != null && con.State == ConnectionState.Open)
            {
                _DAO.Command = "SELECT Version, [Installed On] FROM Version";
                var dataTable = _DAO.GetTable(con);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    dataTable.DefaultView.Sort = "[Installed On] ASC";
                    version = dataTable.Rows[0]["Version"].ToString();
                }
                else
                {
                    version = "Unable to get version. Table may not exist.";
                }

                con.Close();
                con.Dispose();
            }
            else
            {
                version = "Unable to connect to database.";
            }

            return version;
        }

        public bool InitializeDatabase()
        {
            var fvi = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            var sVersion = $"\'\'{fvi.FileVersion}\'\'";

            _DAO.Command = Resources.ReportingInitDatabaseCreateTables.Replace("@version", sVersion);
            var success = _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);

            if (success)
            {
                _DAO.Command = Resources.ReportingInitDatabaseCreateProcedures;

                if (!_DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection))
                {
                    _sqlError = _DAO.SqlError;
                    success = false;
                }
            }
            else
            {
                _sqlError = _DAO.SqlError;
            }

            return success;
        }

        public void VerifyListColumns(DataTable columns, string tableName)
        {
            Guard.ArgumentIsNotNull(columns, nameof(columns));

            foreach (DataRow col in columns.Rows)
            {
                var colName = col[ColumnName].ToString();
                _DAO.Command =
                    $"IF (COL_LENGTH (\'{tableName}\', \'{colName}\') IS NOT NULL) BEGIN SELECT \'True\' AS [Result] END ELSE BEGIN SELECT \'False\' AS [Result] END";
                var colExists = bool.Parse(_DAO.ExecuteScalar(_DAO.GetClientReportingConnection).ToString());

                if (!colExists)
                {
                    throw new InvalidOperationException(
                        $"Column mismatch error: Column {colName} exists in RPTColumns table but not in {tableName}.");
                }
            }
        }
    }
}