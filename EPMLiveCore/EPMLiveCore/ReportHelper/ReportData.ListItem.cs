using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using EPMLiveCore.Helpers;
using EPMLiveCore.Properties;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportHelper
{
    public partial class ReportData
    {
        private bool ItemHasValue(SPListItem item, string colName)
        {
            Guard.ArgumentIsNotNull(colName, nameof(colName));
            Guard.ArgumentIsNotNull(item, nameof(item));
            var test = string.Empty;

            try
            {
                test = Convert.ToString(item[colName]);
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
            }

            return !string.IsNullOrWhiteSpace(test);
        }

        private string GetFieldType(SPListItem item, string colInternalName)
        {
            Guard.ArgumentIsNotNull(colInternalName, nameof(colInternalName));
            Guard.ArgumentIsNotNull(item, nameof(item));
            var fieldType = string.Empty;

            try
            {
                var lookupField = item.Fields.GetFieldByInternalName(colInternalName);

                if (lookupField != null)
                {
                    fieldType = lookupField.TypeAsString;
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
            }

            return fieldType;
        }

        public void UpdateItem(Guid listId, SPListItem item, string tableName)
        {
            Guard.ArgumentIsNotNull(tableName, nameof(tableName));
            Guard.ArgumentIsNotNull(item, nameof(item));
            var defaultColumns = new ArrayList
            {
                "siteid",
                "webid",
                "listid",
                "itemid",
                "weburl"
            };

            var mandatoryHiddenFields = new ArrayList
            {
                "commenters",
                "commentersread",
                "commentcount",
                "workspaceurl"
            };

            var sqlString = UpdateSQL(
                tableName.Replace(SingleQuote, string.Empty),
                GetListColumns(listId),
                item,
                defaultColumns,
                mandatoryHiddenFields);
            UpdateListItem(sqlString);
        }

        public bool InsertListItem(string sqlString)
        {
            _cmdWithParams.CommandText = sqlString ?? throw new ArgumentNullException(nameof(sqlString));
            var passed = _DAO.ExecuteNonQuery(_cmdWithParams, _params, _DAO.GetClientReportingConnection);

            if (_DAO.SqlErrorOccurred)
            {
                _sqlError = _DAO.SqlError;
            }

            return passed;
        }

        public bool UpdateListItem(string sqlString)
        {
            _cmdWithParams.CommandText = sqlString ?? throw new ArgumentNullException(nameof(sqlString));
            var passed = _DAO.ExecuteNonQuery(_cmdWithParams, _params, _DAO.GetClientReportingConnection);

            if (_DAO.SqlErrorOccurred)
            {
                _sqlError = _DAO.SqlError;
            }

            return passed;
        }

        public bool InsertList(Guid listId, string tableName, string tableNameSnapshot, bool resourceList)
        {
            Guard.ArgumentIsNotNull(tableNameSnapshot, nameof(tableNameSnapshot));
            Guard.ArgumentIsNotNull(tableName, nameof(tableName));
            SPList list = null;

            using (var site = new SPSite(_siteId))
            {
                foreach (SPWeb web in site.AllWebs)
                {
                    try
                    {
                        list = web.Lists[listId];
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                    }
                    finally
                    {
                        web?.Dispose();
                    }

                    if (list != null)
                    {
                        break;
                    }
                }
            }

            _DAO.Command = $@"
                            IF NOT EXISTS (SELECT 1 FROM RPTList WHERE [RPTListId] = @RPTListId)
                            BEGIN
                                INSERT INTO [{Resources.ReportingListTable}]
                                   ([RPTListId]
                                   ,[ListName]
                                   ,[SiteId]
                                   ,[TableName]
                                   ,[TableNameSnapshot]
                                   ,[System]
                                   ,[ResourceList])
                                VALUES
                                   (@RPTListId, 
                                    @ListName,
                                    @SiteId,
                                    @TableName,
                                    @TableNameSnapshot,
                                    @System,
                                    @ResourceList)
                           END
                            ";

            _DAO.AddParam("@RPTListId", list.ID);
            _DAO.AddParam("@ListName", list.Title);
            _DAO.AddParam("@SiteId", _siteId);
            _DAO.AddParam("@TableName", tableName);
            _DAO.AddParam("@TableNameSnapshot", tableNameSnapshot);
            _DAO.AddParam("@System", 0);
            _DAO.AddParam("@ResourceList", Convert.ToBoolean(resourceList));

            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool UpdateList(Guid listId, bool resourceList)
        {
            Guard.ArgumentIsNotNull(listId, nameof(listId));

            SPList list;
            Guid siteId;
            SPWeb web = null;

            try
            {
                web = _isReportingV2Enabled
                    ? SPContext.Current.Site.OpenWeb()
                    : SPContext.Current.Site.RootWeb;
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
            }

            if (web != null)
            {
                list = web.Lists[listId];
            }
            else
            {
                using (var spSite = new SPSite(_siteId))
                {
                    using (var openWeb = spSite.OpenWeb())
                    {
                        list = openWeb.Lists[listId];
                    }
                }
            }

            _DAO.AddParam("@RPTListId", list.ID);
            _DAO.AddParam("@ResourceList", resourceList);
            _DAO.Command = $@"
                                UPDATE [{Resources.ReportingListTable.Replace(SingleQuote, string.Empty)}]
                                       SET [ResourceList] = @ResourceList
                                WHERE 
                                       RPTListId = @RPTListId
                            ";

            web?.Close();
            web?.Dispose();

            return _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
        }

        public bool DeleteListColumns(Guid listId, List<ColumnDef> columns)
        {
            Guard.ArgumentIsNotNull(columns, nameof(columns));
            var success = true;

            foreach (var column in columns)
            {
                _DAO.Command =
                    $"delete from [{Resources.ReportingColumnTable.Replace(SingleQuote, string.Empty)}] where [RPTListId] = @RPTListId and ColumnName = @ColumnName ";
                _DAO.AddParam("@RPTListId", listId);
                _DAO.AddParam("@ColumnName", column.SqlColumnName);
                success = success && _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
            }

            return success;
        }

        public bool InsertListColumns(Guid listId, List<ColumnDef> columns)
        {
            Guard.ArgumentIsNotNull(columns, nameof(columns));
            var success = true;

            foreach (var column in columns)
            {
                _DAO.AddParam("@RPTListId", listId);
                _DAO.AddParam("@ColumnName", column.SqlColumnName);
                _DAO.AddParam("@ColumnType", column.SqlColumnType.ToString());
                _DAO.AddParam("@ColumnSize", column.SqlColumnSize);
                _DAO.AddParam("@SharePointSize", column.ColumnType.ToString());
                _DAO.AddParam("@InternalName", column.InternalName);
                _DAO.AddParam("@DisplayName", column.DisplayName);
                _DAO.Command = $@"
                        insert into [{Resources.ReportingColumnTable}]
                               ([RPTListId]
                               ,[ColumnName]
                               ,[ColumnType]
                               ,[ColumnSize]
                               ,[SharePointType]
                               ,[InternalName]
                               ,[DisplayName]
                                )
                         values
                               ( @RPTListId, @ColumnName, @ColumnType, @ColumnSize, @SharePointSize, @InternalName, @DisplayName )
                    ";
                success = success && _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
            }

            return success;
        }

        public bool UpdateListColumns(Guid listId, List<ColumnDef> columns)
        {
            Guard.ArgumentIsNotNull(columns, nameof(columns));
            var success = true;

            foreach (var column in columns)
            {
                _DAO.AddParam("@RPTListId", listId);
                _DAO.AddParam("@ColumnName", column.SqlColumnName);
                _DAO.AddParam("@ColumnType", column.SqlColumnType.ToString());
                _DAO.AddParam("@ColumnSize", column.SqlColumnSize);
                _DAO.AddParam("@SharePointType", column.ColumnType.ToString());
                _DAO.AddParam("@InternalName", column.InternalName);
                _DAO.AddParam("@DisplayName", column.DisplayName);

                _DAO.Command = $@"Update [{Resources.ReportingColumnTable.Replace(SingleQuote, string.Empty)}]
                               Set [ColumnType] = @ColumnType
                               ,[ColumnSize] = @ColumnSize
                               ,[SharePointType] = @SharePointType
                               ,[InternalName] = @InternalName
                               ,[DisplayName] = @DisplayName
                                where [RPTListId] = @RPTListId and [ColumnName] = @ColumnName";

                success = success && _DAO.ExecuteNonQuery(_DAO.GetClientReportingConnection);
            }

            return success;
        }

        public Guid GetListId(string sListName)
        {
            Guard.ArgumentIsNotNull(sListName, nameof(sListName));
            _DAO.Command = "SELECT RPTListID FROM RPTList WHERE ListName=@listName AND siteId=@siteId";
            _DAO.AddParam("@listName", sListName);
            _DAO.AddParam("@siteId", _siteId);
            var val = _DAO.ExecuteScalar(_DAO.GetClientReportingConnection);
            return (Guid?)val ?? Guid.Empty;
        }
    }
}