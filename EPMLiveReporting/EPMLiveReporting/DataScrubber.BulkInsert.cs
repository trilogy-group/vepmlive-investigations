using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using EPMLiveCore.Helpers;
using EPMLiveCore.ReportHelper;

namespace EPMLiveReportsAdmin
{
    public static partial class DataScrubber
    {
        private const string DeleteReportListIds = "DELETE FROM ReportListIds";
        private const string DeleteRptWeb = "DELETE FROM RPTWeb";
        private const string DeleteRptWebGroups = "DELETE FROM RPTWEBGROUPS";
        private const string WipeDataId = "Reporting Refresh WIPE DATA FROM ReportListIds, RPTWeb, and RPTWEBGROUPS, epmlive.Webs TABLE";
        private const string RepopulateId = "Reporting Refresh REPOPULATE ReportListIds, RPTWeb, RPTWEBGROUPS, epmlive.Webs AND FRF-Recent TABLES";
        private const string RptWebGroups = "RPTWEBGROUPS";
        private const string SelectListTableRptList = "SELECT [ListName], [TableName] FROM RPTList";
        private const string PopulateRptWebGroupsId = "Reporting Refresh POPULATE RPTWEBGROUPS";
        private const string BulkInsertReportListIdsId = "Reporting Refresh BULK INSERT ReportListIds TABLE";
        private const string BulkInsertRptWebId = "Reporting Refresh  BULK INSERT RPTWeb and epmlive.Webs TABLE";
        private const string SelectIdReportListIds = "SELECT [Id] FROM ReportListIds";
        private const string CleanLstTablesId = "Reporting Refresh  CLEAN LST TABLES - DELETE ENTRIES WITH NONEXISTENT LISTIDS";
        private const string Id = "Id";
        private const string ListIcon = "ListIcon";
        private const string SiteId = "SiteId";
        private const string ItemWebId = "ItemWebId";
        private const string ItemListId = "ItemListId";
        private const string ItemId = "ItemId";
        private const string ParentWebId = "ParentWebId";
        private const string WebId = "WebId";
        private const string WebUrl = "WebUrl";
        private const string WebTitle = "WebTitle";
        private const string WebDescription = "WebDescription";
        private const string WebOwnerId = "WebOwnerId";
        private const string GroupId = "GROUPID";
        private const string SecType = "SECTYPE";
        private const string DboRptWebGroups = "dbo.RPTWEBGROUPS";
        private const string StartBulkInsertRptWebGroups = "Started bulk insert dbo.RPTWEBGROUPS";
        private const string CompleteBulkInsertRptWebGroups = "Completed bulk insert dbo.RPTWEBGROUPS";
        private const string ListName = "ListName";
        private const string BulkInsertReportListIdsTable = "BULK INSERT ReportListIds TABLE";
        private const string ReportListIds = "ReportListIds";
        private const string RptWeb = "RPTWeb";
        private const string StartBulkInsertRptWeb = "Started BULK INSERT RPTWeb and epmlive.Webs TABLE";
        private const string CompleteBulkInsertRptWeb = "Completed BULK INSERT RPTWeb and epmlive.Webs TABLE";
        private const string ParentItem = "ParentItem";
        private const string CleaningCancelled = "Cleaning has been cancelled.";
        private const string DataCleaningRefresh = "Data cleaning in Refresh process.";
        private const string NoIdsReportListIds = "No ids in ReportListIds table.";
        private const string TableName = "TableName";
        private const string Success = "Success.";
        private const string SelectFrfType2 = "SELECT * FROM FRF WHERE [Type]=2";
        private const string ListId = "LIST_ID";
        private const string WebId1 = "WEB_ID";
        private const string FrfId = "FRF_ID";
        private const string SiteId1 = "SITE_ID";
        private const string ItemId1 = "ITEM_ID";
        private const string UserId = "USER_ID";
        private const string Title = "Title";
        private const string IconText = "Icon";
        private const string TypeText = "Type";
        private const string FString = "F_String";
        private const string FDate = "F_Date";
        private const string FInt = "F_Int";
        private const string FrfTableName = "FRF";
        private const string BulkInsertFrfRecentItemsId = "Reporting Refresh  BULK INSERT FRF - Recent items";
        private const string StartBulkInsertFrfRecentItems = "Started BULK INSERT FRF - Recent items";
        private const string CompleteBulkInsertFrfRecentItems = "Completed BULK INSERT FRF - Recent items";

        private static bool BulkInsertReportListIds(EPMData epmData, DataTable listIds, StringBuilder errMsg)
        {
            Guard.ArgumentIsNotNull(epmData, nameof(epmData));
            Guard.ArgumentIsNotNull(listIds, nameof(listIds));
            Guard.ArgumentIsNotNull(errMsg, nameof(errMsg));

            var hasError = false;

            if (listIds.Rows.Count > 0)
            {
                LogStatusLevel2Type3(BulkInsertReportListIdsId, BulkInsertReportListIdsTable, epmData);

                var beginTransaction = epmData.GetClientReportingConnection.BeginTransaction();

                using (var sqlBulkCopy = new SqlBulkCopy(epmData.GetClientReportingConnection, new SqlBulkCopyOptions(), beginTransaction))
                {
                    try
                    {
                        sqlBulkCopy.DestinationTableName = ReportListIds;
                        sqlBulkCopy.ColumnMappings.Add(Id, Id);
                        sqlBulkCopy.ColumnMappings.Add(ListIcon, ListIcon);
                        sqlBulkCopy.WriteToServer(listIds);
                        sqlBulkCopy.Close();
                        beginTransaction.Commit();
                        beginTransaction.Dispose();
                    }
                    catch (Exception exception)
                    {
                        hasError = true;
                        errMsg.Append(exception.Message);
                        LogStatusLevel2Type3(
                            BulkInsertReportListIdsId,
                            $"Error while bulk insert into ReportListIds. error {exception.Message}",
                            epmData);
                        Trace.WriteLine(exception);
                    }
                }
            }

            return hasError;
        }

        private static void BulkInsertRptWeb(EPMData epmData, DataTable rptWeb, ref bool hasError, StringBuilder errMsg)
        {
            Guard.ArgumentIsNotNull(epmData, nameof(epmData));
            Guard.ArgumentIsNotNull(rptWeb, nameof(rptWeb));
            Guard.ArgumentIsNotNull(errMsg, nameof(errMsg));

            if (rptWeb.Rows.Count > 0)
            {
                LogStatusLevel2Type3(BulkInsertRptWebId, StartBulkInsertRptWeb, epmData);
                var beginTransaction = epmData.GetClientReportingConnection.BeginTransaction();

                using (var sqlBulkCopy = new SqlBulkCopy(epmData.GetClientReportingConnection, new SqlBulkCopyOptions(), beginTransaction))
                {
                    try
                    {
                        sqlBulkCopy.DestinationTableName = RptWeb;
                        sqlBulkCopy.ColumnMappings.Add(SiteId, SiteId);
                        sqlBulkCopy.ColumnMappings.Add(ItemWebId, ItemWebId);
                        sqlBulkCopy.ColumnMappings.Add(ItemListId, ItemListId);
                        sqlBulkCopy.ColumnMappings.Add(ItemId, ItemId);
                        sqlBulkCopy.ColumnMappings.Add(ParentWebId, ParentWebId);
                        sqlBulkCopy.ColumnMappings.Add(WebId, WebId);
                        sqlBulkCopy.ColumnMappings.Add(WebUrl, WebUrl);
                        sqlBulkCopy.ColumnMappings.Add(WebTitle, WebTitle);
                        sqlBulkCopy.ColumnMappings.Add(WebDescription, WebDescription);
                        sqlBulkCopy.ColumnMappings.Add(WebOwnerId, WebOwnerId);
                        sqlBulkCopy.WriteToServer(rptWeb);
                        sqlBulkCopy.Close();
                        beginTransaction.Commit();
                        beginTransaction.Dispose();
                        LogStatusLevel2Type3(BulkInsertRptWebId, CompleteBulkInsertRptWeb, epmData);
                    }
                    catch (Exception exception)
                    {
                        hasError = true;
                        errMsg.Append(exception.Message);
                        LogStatusLevel2Type3(
                            BulkInsertRptWebId,
                            $"Error while  BULK INSERT RPTWeb and epmlive.Webs TABLE. error {exception.Message}",
                            epmData);
                        Trace.WriteLine(exception);
                    }
                }
            }
        }

        private static void BulkInsertFrfRecentItems(EPMData epmData, DataTable finalRecent, DataTable rptWeb, StringBuilder errMsg)
        {
            Guard.ArgumentIsNotNull(epmData, nameof(epmData));
            Guard.ArgumentIsNotNull(finalRecent, nameof(finalRecent));
            Guard.ArgumentIsNotNull(rptWeb, nameof(rptWeb));
            Guard.ArgumentIsNotNull(errMsg, nameof(errMsg));

            if (finalRecent.Rows.Count > 0)
            {
                LogStatusLevel2Type3(BulkInsertFrfRecentItemsId, StartBulkInsertFrfRecentItems, epmData);

                try
                {
                    using (var beginTransaction = epmData.GetEPMLiveConnection.BeginTransaction())
                    {
                        using (var sqlBulkCopy = new SqlBulkCopy(epmData.GetEPMLiveConnection, new SqlBulkCopyOptions(), beginTransaction))
                        {
                            sqlBulkCopy.DestinationTableName = FrfTableName;
                            void addColumnMappings(string columnName) => sqlBulkCopy.ColumnMappings.Add(columnName, columnName);

                            addColumnMappings(FrfId);
                            addColumnMappings(SiteId1);
                            addColumnMappings(WebId1);
                            addColumnMappings(ListId);
                            addColumnMappings(ItemId1);
                            addColumnMappings(UserId);
                            addColumnMappings(Title);
                            addColumnMappings(IconText);
                            addColumnMappings(TypeText);
                            addColumnMappings(FString);
                            addColumnMappings(FDate);
                            addColumnMappings(FInt);
                            sqlBulkCopy.WriteToServer(rptWeb);
                        }

                        beginTransaction.Commit();
                    }

                    LogStatusLevel2Type3(BulkInsertFrfRecentItemsId, CompleteBulkInsertFrfRecentItems, epmData);
                }
                catch (Exception exception)
                {
                    LogStatusDataCleaning($"Error cleaning lst tables. Error: {exception.Message}", errMsg.ToString(), epmData);
                    Trace.WriteLine(exception);
                }
            }
        }

        private static bool CleanLstTables(
            EPMData epmData,
            DataTable listIdsTest,
            DataTable listNames,
            bool hasError,
            StringBuilder errMsg)
        {
            Guard.ArgumentIsNotNull(epmData, nameof(epmData));
            Guard.ArgumentIsNotNull(listIdsTest, nameof(listIdsTest));
            Guard.ArgumentIsNotNull(listNames, nameof(listNames));
            Guard.ArgumentIsNotNull(errMsg, nameof(errMsg));

            LogStatusLevel2Type3(CleanLstTablesId, SelectIdReportListIds, epmData);

            using (var sqlCommand = new SqlCommand(SelectIdReportListIds, epmData.GetClientReportingConnection))
            {
                using (var adapter = new SqlDataAdapter(sqlCommand))
                {
                    adapter.Fill(listIdsTest);
                }
            }

            if (listIdsTest.Rows.Count == 0)
            {
                LogStatusDataCleaning(CleaningCancelled, NoIdsReportListIds, epmData);
                return false;
            }

            var delSqlBuilder = new StringBuilder();

            foreach (DataRow dataRow in listNames.Rows)
            {
                var tableName = string.Empty;

                try
                {
                    tableName = dataRow[TableName].ToString();
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                }

                if (!string.IsNullOrWhiteSpace(tableName))
                {
                    delSqlBuilder.Append($"DELETE FROM [{tableName}] WHERE [ListID] NOT IN (SELECT Id FROM ReportListIds) ");
                }
            }

            var delSqlBuilderString = delSqlBuilder.ToString();

            if (!string.IsNullOrWhiteSpace(delSqlBuilderString) && !hasError)
            {
                try
                {
                    using (var sqlCommand = new SqlCommand(delSqlBuilderString, epmData.GetClientReportingConnection))
                    {
                        sqlCommand.ExecuteNonQuery();
                        LogStatusDataCleaning(Success, Success, epmData);
                    }
                }
                catch (Exception exception)
                {
                    LogStatusDataCleaning($"Error cleaning lst tables. Error: {exception.Message}", errMsg.ToString(), epmData);
                    Trace.WriteLine(exception);
                }
            }
            else
            {
                epmData.LogStatus(string.Empty, DataCleaningRefresh, CleaningCancelled, $"Error: {errMsg}", 0, 1, string.Empty);
            }

            return true;
        }

        private static void LogStatusLevel2Type3(string shortMsg, string longMsg, EPMData epmData)
        {
            Guard.ArgumentIsNotNull(shortMsg, nameof(shortMsg));
            Guard.ArgumentIsNotNull(longMsg, nameof(longMsg));
            Guard.ArgumentIsNotNull(epmData, nameof(epmData));

            epmData.LogStatus(string.Empty, string.Empty, shortMsg, longMsg, 2, 3, string.Empty);
        }

        private static void LogStatusDataCleaning(string shortMsg, string longMsg, EPMData epmData)
        {
            Guard.ArgumentIsNotNull(shortMsg, nameof(shortMsg));
            Guard.ArgumentIsNotNull(longMsg, nameof(longMsg));
            Guard.ArgumentIsNotNull(epmData, nameof(epmData));

            epmData.LogStatus(string.Empty, DataCleaningRefresh, shortMsg, longMsg, 0, 1, string.Empty);
        }

        private static void WipeData(string deleteQuery, string logMsg, EPMData epmData)
        {
            Guard.ArgumentIsNotNull(deleteQuery, nameof(deleteQuery));
            Guard.ArgumentIsNotNull(logMsg, nameof(logMsg));
            Guard.ArgumentIsNotNull(epmData, nameof(epmData));

            using (var sqlCommand = new SqlCommand(deleteQuery, epmData.GetClientReportingConnection))
            {
                sqlCommand.ExecuteNonQuery();
                LogStatusLevel2Type3(logMsg, deleteQuery, epmData);
            }
        }
    }
}