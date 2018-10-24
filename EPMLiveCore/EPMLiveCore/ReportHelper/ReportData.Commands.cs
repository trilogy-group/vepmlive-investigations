using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using EPMLiveCore.Helpers;
using EPMLiveCore.Properties;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportHelper
{
    public partial class ReportData
    {
        public virtual string InsertSQL(
            string tableName,
            DataTable dtColumns,
            SPListItem spListItem,
            ArrayList defaultColumns,
            ArrayList mandatoryHiddenFields)
        {
            Guard.ArgumentIsNotNull(mandatoryHiddenFields, nameof(mandatoryHiddenFields));
            Guard.ArgumentIsNotNull(defaultColumns, nameof(defaultColumns));
            Guard.ArgumentIsNotNull(spListItem, nameof(spListItem));
            Guard.ArgumentIsNotNull(dtColumns, nameof(dtColumns));
            Guard.ArgumentIsNotNull(tableName, nameof(tableName));

            return
                $"INSERT INTO {tableName.Replace(SingleQuote, string.Empty)}{AddColums(spListItem, dtColumns).Replace(SingleQuote, string.Empty)}{AddColumnValues(spListItem, dtColumns, defaultColumns, mandatoryHiddenFields, "insert").Replace(SingleQuote, string.Empty)}";
        }

        public virtual string UpdateSQL(
            string tableName,
            DataTable dtColumns,
            SPListItem spListItem,
            ArrayList defaultColumns,
            ArrayList mandatoryHiddenFields)
        {
            Guard.ArgumentIsNotNull(mandatoryHiddenFields, nameof(mandatoryHiddenFields));
            Guard.ArgumentIsNotNull(defaultColumns, nameof(defaultColumns));
            Guard.ArgumentIsNotNull(spListItem, nameof(spListItem));
            Guard.ArgumentIsNotNull(dtColumns, nameof(dtColumns));
            Guard.ArgumentIsNotNull(tableName, nameof(tableName));

            return
                $"UPDATE {tableName.Replace(SingleQuote, string.Empty)} SET {AddColumnValues(spListItem, dtColumns, defaultColumns, mandatoryHiddenFields, "update").Replace(SingleQuote, string.Empty)} WHERE listid=\'{spListItem.ParentList.ID.ToString().Replace(SingleQuote, string.Empty)}\' AND itemid={spListItem.ID.ToString().Replace(SingleQuote, string.Empty)} IF @@ROWCOUNT = 0 INSERT INTO {tableName.Replace(SingleQuote, string.Empty)}{AddColums(spListItem, dtColumns).Replace(SingleQuote, string.Empty)}{AddColumnValues(spListItem, dtColumns, defaultColumns, mandatoryHiddenFields, "insert").Replace(SingleQuote, string.Empty)}";
        }

        public string DeleteSQL(string sTableName, Guid listId, int itemId)
        {
            return
                $"DELETE FROM {sTableName.Replace(SingleQuote, string.Empty)} WHERE listid=\'{listId.ToString().Replace(SingleQuote, string.Empty)}\' AND itemid={itemId.ToString().Replace(SingleQuote, string.Empty)}";
        }

        public bool AddColumns(string table, List<ColumnDef> columns)
        {
            Guard.ArgumentIsNotNull(columns, nameof(columns));
            Guard.ArgumentIsNotNull(table, nameof(table));

            if (columns.Count == 0)
            {
                return true;
            }

            var columnsBuilder = new StringBuilder();

            foreach (var columnDef in columns)
            {
                if (columnsBuilder.Length > 0)
                {
                    columnsBuilder.Append(", ");
                }

                columnsBuilder.Append(columnDef);
            }

            _DAO.Command = $@"ALTER TABLE [{table.Replace(SingleQuote, string.Empty)}] ADD {columnsBuilder.Replace(SingleQuote, string.Empty)}";

            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool UpdateColumns(string table, List<ColumnDef> columns)
        {
            Guard.ArgumentIsNotNull(columns, nameof(columns));
            Guard.ArgumentIsNotNull(table, nameof(table));

            if (columns.Count == 0)
            {
                return true;
            }

            var success = DeleteColumns(table, columns);

            if (success)
            {
                success = AddColumns(table, columns);
            }

            return success;
        }

        public bool DeleteColumns(string table, List<ColumnDef> columns)
        {
            Guard.ArgumentIsNotNull(columns, nameof(columns));
            Guard.ArgumentIsNotNull(table, nameof(table));

            if (columns.Count == 0)
            {
                return true;
            }

            var columnsBuilder = new StringBuilder();

            foreach (var columnDef in columns)
            {
                if (columnsBuilder.Length > 0)
                {
                    columnsBuilder.Append(", ");
                }

                columnsBuilder.Append($"[{columnDef.SqlColumnName}]");
            }

            _DAO.Command =
                $@"ALTER TABLE [{table.Replace(SingleQuote, string.Empty)}] DROP COLUMN {columnsBuilder.Replace(SingleQuote, string.Empty)}";

            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool InsertDbEntry()
        {
            string url;
            Guid webApplicationId;

            using (var site = new SPSite(_siteId))
            {
                url = site.Url;
                webApplicationId = site.WebApplication.Id;
            }

            _DAO.AddParam("@SiteId", _siteId);
            _DAO.AddParam("@WebApplicationId", webApplicationId);
            _DAO.AddParam("@Url", url);
            _DAO.AddParam("@Server", _DAO.remoteServerName);
            _DAO.AddParam("@Database", _DAO.remoteDbName);
            _DAO.AddParam("@useSAccount", _DAO.UseSqlAccount);

            if (!_DAO.UseSqlAccount)
            {
                _DAO.Command =
                    $@"insert into [{Resources.ReportingDatabaseTable.Replace(SingleQuote, string.Empty)}]([SiteId],[WebApplicationId],[Url],[DatabaseServer],[DatabaseName], [SAccount]) 
                                      values(@SiteId,@WebApplicationId,@Url,@Server,@Database,@useSAccount)";
            }
            else
            {
                _DAO.AddParam("@username", _DAO.UserName);
                _DAO.AddParam("@password", _DAO.Password);
                _DAO.Command =
                    $@"insert into [{Resources.ReportingDatabaseTable.Replace(SingleQuote, string.Empty)}]([SiteId],[WebApplicationId],[Url],[DatabaseServer],[DatabaseName], [SAccount], [UserName], [Password]) 
                                      values(@SiteId,@WebApplicationId,@Url,@Server,@Database,@useSAccount,@username,@password)";
            }

            return _DAO.ExecuteNonQuery(_DAO.GetEPMLiveConnection);
        }

        public void ReportError(Guid listId, string sListName, string sErrMsg, string sSection, int iErrType)
        {
            Guard.ArgumentIsNotNull(sSection, nameof(sSection));
            Guard.ArgumentIsNotNull(sErrMsg, nameof(sErrMsg));
            Guard.ArgumentIsNotNull(sListName, nameof(sListName));

            _DAO.Command =
                $"INSERT INTO {Resources.ReportingLogTable.Replace(SingleQuote, string.Empty)} VALUES(@RPTListID,@ListName,@ShortMsg,@LongMsg,@ErrorType,@Level,@TimeStamp,@timerjobguid)";
            _DAO.AddParam("@RPTListID", listId);
            _DAO.AddParam("@ListName", sListName);
            _DAO.AddParam("@ShortMsg", $"{sSection}--{sErrMsg}");

            if (_DAO.SqlError != null)
            {
                _DAO.AddParam("@LongMsg", _DAO.SqlError);
            }
            else
            {
                _DAO.AddParam("@LongMsg", DBNull.Value);
            }

            _DAO.AddParam("@ErrorType", iErrType);
            _DAO.AddParam("@Level", 1);
            _DAO.AddParam("@TimeStamp", DateTime.Now);
            _DAO.AddParam("@timerjobguid", DBNull.Value);
            _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        protected string AddColums(DataTable dataTable)
        {
            Guard.ArgumentIsNotNull(dataTable, nameof(dataTable));
            var columns = " (";

            foreach (DataRow row in dataTable.Rows)
            {
                columns = (string)row[SharePointType] != Lookup
                    ? $"{columns}[{row[ColumnName].ToString().Replace(SingleQuote, string.Empty)}],"
                    : $"{columns}[{row[ColumnName].ToString().Replace(SingleQuote, string.Empty)}ID], [{row[ColumnName].ToString().Replace(SingleQuote, string.Empty)}Text],";
            }

            columns = columns.Remove(columns.Length - 1);
            columns = $"{columns}) ";
            return columns;
        }

        protected string AddColums(SPListItem item, DataTable dataTable)
        {
            Guard.ArgumentIsNotNull(dataTable, nameof(dataTable));
            Guard.ArgumentIsNotNull(item, nameof(item));
            var columns = " (";

            foreach (DataRow row in dataTable.Rows)
            {
                var columnName = row[ColumnName].ToString().Replace(SingleQuote, string.Empty);
                var internalName = row[InternalName].ToString().Replace(SingleQuote, string.Empty);

                if (item.Fields.ContainsField(internalName) ||
                    columnName == "SiteId" ||
                    columnName == "WebId" ||
                    columnName == "ListId" ||
                    columnName == "ItemId" ||
                    columnName == "WebUrl" ||
                    columnName == "Commenters" ||
                    columnName == "CommentersRead" ||
                    columnName == "CommentCount" ||
                    columnName == "WorkspaceUrl")
                {
                    columns = (string)row[SharePointType] != Lookup
                        ? $"{columns}[{row[ColumnName].ToString().Replace(SingleQuote, string.Empty)}],"
                        : $"{columns}[{row[ColumnName].ToString().Replace(SingleQuote, string.Empty)}ID], [{row[ColumnName].ToString().Replace(SingleQuote, string.Empty)}Text],";
                }
            }

            columns = columns.Remove(columns.Length - 1);
            columns = $"{columns}) ";
            return columns;
        }

        protected virtual bool IsLookUpField(string sListName, string sColumnName)
        {
            Guard.ArgumentIsNotNull(sColumnName, nameof(sColumnName));
            Guard.ArgumentIsNotNull(sListName, nameof(sListName));
            var blnLookup = false;

            _DAO.AddParam("@listName", sListName);
            _DAO.AddParam("@colName", sColumnName);
            _DAO.Command =
                "SELECT dbo.RPTColumn.SharePointType, dbo.RPTList.ListName FROM dbo.RPTList INNER JOIN dbo.RPTColumn ON dbo.RPTList.RPTListId = dbo.RPTColumn.RPTListId WHERE (dbo.RPTList.ListName = @listName) AND (ColumnName=@colName)";
            var objType = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection);

            if (objType.ToString().Equals(LookupLower, StringComparison.OrdinalIgnoreCase) ||
                objType.ToString().Equals(User, StringComparison.OrdinalIgnoreCase) ||
                objType.ToString().Equals("flookup", StringComparison.OrdinalIgnoreCase))
            {
                blnLookup = true;
            }

            return blnLookup;
        }

        public static string AddLookUpFieldValues(string sValue, string sValueType)
        {
            Guard.ArgumentIsNotNull(sValueType, nameof(sValueType));
            Guard.ArgumentIsNotNull(sValue, nameof(sValue));
            var returnValueBuilder = new StringBuilder();
            sValue = HttpUtility.HtmlDecode(sValue);
            var lookupValueCollection = new SPFieldLookupValueCollection(sValue);

            foreach (var lookupValue in lookupValueCollection)
            {
                if (sValueType == IdText)
                {
                    returnValueBuilder.Append($"{lookupValue.LookupId},");
                }
                else if (sValueType == TextId)
                {
                    returnValueBuilder.Append($"{lookupValue.LookupValue},");
                }
            }

            var returnValue = returnValueBuilder.ToString();

            if (string.IsNullOrWhiteSpace(returnValue) && sValueType.Equals(TextId, StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    if (sValue.Contains(SemiColonHash))
                    {
                        var splitter = ",".ToCharArray();
                        sValue = sValue.Replace(SemiColonHash, ",");
                        var arrVals = sValue.Split(splitter);

                        returnValue = arrVals.Where(val => !string.IsNullOrWhiteSpace(val))
                           .Aggregate(returnValue, (current, val) => $"{current}{val},");

                        if (returnValue.IndexOf(",") == 0)
                        {
                            returnValue.Remove(0, 1);
                        }
                    }
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                    SPSecurity.RunWithElevatedPrivileges(
                        delegate
                        {
                            if (!EventLog.SourceExists("EPMLive Reporting AddLookUpFieldValue"))
                            {
                                EventLog.CreateEventSource("EPMLive Reporting AddLookUpFieldValue", "EPM Live");
                            }

                            using (var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting AddLookUpFieldValue")
                            {
                                MaximumKilobytes = 32768
                            })
                            {
                                myLog.WriteEntry($"{exception.Message} -- Stack: {exception.StackTrace}", EventLogEntryType.Error, 9000);
                            }
                        });
                }
            }

            if (returnValue.Contains(","))
            {
                returnValue = returnValue.Remove(returnValue.LastIndexOf(","));
            }

            return returnValue;
        }

        public static string AddMultiChoiceValues(string sValue, string sValueType)
        {
            Guard.ArgumentIsNotNull(sValueType, nameof(sValueType));
            Guard.ArgumentIsNotNull(sValue, nameof(sValue));
            var returnValueBuilder = new StringBuilder();

            try
            {
                var mcv = new SPFieldMultiChoiceValue(sValue);

                for (var i = 0; i < mcv.Count; i++)
                {
                    if (sValueType == TextId)
                    {
                        returnValueBuilder.Append($"{mcv[i]},");
                    }
                }
            }
            catch (Exception ex)
            {
                SPSecurity.RunWithElevatedPrivileges(
                    delegate
                    {
                        if (!EventLog.SourceExists("EPMLive Reporting AddMultiChoiceValues"))
                        {
                            EventLog.CreateEventSource("EPMLive Reporting AddMultiChoiceValues", "EPM Live");
                        }

                        using (var myLog = new EventLog("EPM Live", ".", "EPMLive Reporting AddMultiChoiceValues")
                        {
                            MaximumKilobytes = 32768
                        })
                        {
                            myLog.WriteEntry($"{ex.Message} -- Stack: {ex.StackTrace}", EventLogEntryType.Error, 9000);
                        }
                    });
            }

            var returnValue = returnValueBuilder.ToString();

            if (returnValue.Contains(","))
            {
                returnValue = returnValue.Remove(returnValue.LastIndexOf(","));
            }

            return returnValue;
        }
    }
}