using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Xml.Linq;
using EPMLiveCore.Helpers;
using EPMLiveCore.ReportHelper;
using Microsoft.SharePoint;

namespace EPMLiveCore.API
{
    public partial class MyWork
    {
        /// <summary>
        ///     Gets the data from reporting DB.
        /// </summary>
        /// <param name="spWeb">The sp web.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private static IEnumerable<DataTable> GetDataFromReportingDb(
            SPWeb spWeb,
            string data)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            SqlDateTime dateTimeFrom;
            SqlDateTime dateTimeTo;
            bool getCompletedItems;
            var listIdQuery = ListIdQuery(data, out dateTimeFrom, out dateTimeTo, out getCompletedItems);

            Guid myWorkListId;
            var theWeb = spWeb;
            var lockedWeb = CoreFunctions.getLockedWeb(theWeb);

            using (var configWeb = Utils.GetConfigWeb(theWeb, lockedWeb))
            {
                myWorkListId = configWeb.Lists[MyWorkText].ID;
            }

            var tables = new List<DataTable>();
            DataTable myWorkDataTable;
            DataTable fieldsTable;
            DataTable flagsTable;
            var siteId = spWeb.Site.ID;

            using (var myWorkReportData = new MyWorkReportData(siteId))
            {
                MapCompleteField(spWeb, myWorkReportData);

                string sql;
                var currentUser = CurrentUser(spWeb, listIdQuery, getCompletedItems, siteId, dateTimeFrom, dateTimeTo, out sql);

                IEnumerable<string> columns;
                IList<string> lists;
                IEnumerable<DataTable> enumerable = null;

                if (ProcessDataTables(myWorkReportData, sql, tables, myWorkListId, out myWorkDataTable, out columns, out lists, ref enumerable))
                {
                    return enumerable;
                }

                sql =
                    $@"SELECT ColumnName, InternalName, SharePointType, RPTListId AS ListId 
                                 FROM dbo.RPTColumn WHERE (ColumnName IN ({string.Join(Comma, columns.ToArray())})) AND (RPTListId IN ({string.Join(Comma, lists.ToArray())}))";
                fieldsTable = myWorkReportData.ExecuteSql(sql);

                sql =
                    $@"SELECT ListId, ItemId, Value FROM dbo.PERSONALIZATIONS WHERE [Key] = 'Flag' AND UserId = N'{currentUser.LoginName.ToSqlCompliant()}'";
                flagsTable = myWorkReportData.ExecuteEpmLiveSql(sql);
                flagsTable.PrimaryKey = new[] {flagsTable.Columns[ListId], flagsTable.Columns[ItemId]};
            }

            AddTables(spWeb, myWorkDataTable, fieldsTable, flagsTable, tables);

            return tables;
        }

        private static Guid ListIdQuery(string data, out SqlDateTime sqlDateTime, out SqlDateTime dateTime, out bool getCompletedItems)
        {
            const string DateFormat = "yyyy-MM-dd HH:mm:ss";
            var listIdQuery = Guid.Empty;
            sqlDateTime = SqlDateTime.MinValue;
            dateTime = SqlDateTime.MaxValue;
            var requestXml = XDocument.Parse(data);
            getCompletedItems = false;
            var xElement = requestXml.Root?.Element(CompleteItemsQuery);

            if (xElement != null)
            {
                bool.TryParse(xElement.Value, out getCompletedItems);
            }

            var dateRange = requestXml.Root?.Element(DateRange);
            var fromAttribute = dateRange?.Attribute(FromText);

            if (fromAttribute != null)
            {
                var exact = DateTime.ParseExact(fromAttribute.Value, DateFormat, null);

                if (exact > sqlDateTime.Value)
                {
                    sqlDateTime = exact;
                }
            }

            var toAttribute = dateRange?.Attribute(ToText);

            if (toAttribute != null)
            {
                var exact = DateTime.ParseExact(toAttribute.Value, DateFormat, null);

                if (exact < dateTime.Value)
                {
                    dateTime = exact;
                }
            }

            var listIdXElement = requestXml.Root?.Element(ListId);

            if (listIdXElement != null)
            {
                listIdQuery = new Guid(listIdXElement.Value);
            }

            return listIdQuery;
        }

        private static SPUser CurrentUser(
            SPWeb spWeb,
            Guid listIdQuery,
            bool getCompletedItems,
            Guid siteId,
            SqlDateTime sqlDateTime,
            SqlDateTime dateTime,
            out string sql)
        {
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            var archivedWebIds = string.Empty;

            if (GetMyWorkParams.ArchivedWebs.Any())
            {
                var strJoin = string.Join(
                    Comma,
                    GetMyWorkParams.ArchivedWebs.Distinct()
                       .Select(
                            w => $@"N'{w}'")
                       .ToArray());
                archivedWebIds = $@"AND (WebId NOT IN ({strJoin}))";
            }

            var queryLists = string.Join(
                Comma,
                GetMyWorkParams.SelectedLists.Select(
                        l => $@"N'{l}'")
                   .ToArray());
            var currentUser = spWeb.CurrentUser;
            sql = string.Empty;

            if (listIdQuery == Guid.Empty)
            {
                sql = $@"SELECT DISTINCT * FROM dbo.LSTMyWork WHERE ([AssignedToID] = {currentUser.ID})  AND ([Complete] {(getCompletedItems
                    ? EqualSign
                    : InEquality)} 1 OR [Complete] IS NULL)
                                AND [SiteId] = N'{siteId}'
                                AND ([DueDate] IS NULL OR ([DueDate] >= '{((DateTime)sqlDateTime).ToString(MonthDateYearFormat)}' AND [DueDate] <= '{((DateTime)dateTime).ToString(MonthDateYearFormat)}'))
                                AND ([WorkType] IN ({queryLists})) {archivedWebIds}";
            }
            else
            {
                sql =
                    $@"SELECT DISTINCT * FROM dbo.LSTMyWork WHERE [SiteId] = N'{siteId}' AND [WebId] = N'{spWeb.ID}' AND [ListId] = N'{listIdQuery}' AND [AssignedToID] = {currentUser.ID}  AND ([Complete] != 1 OR [Complete] IS NULL)";
            }

            return currentUser;
        }

        private static bool ProcessDataTables(
            MyWorkReportData myWorkReportData,
            string sql,
            IList<DataTable> tables,
            Guid myWorkListId,
            out DataTable myWorkDataTable,
            out IEnumerable<string> columns,
            out IList<string> lists,
            ref IEnumerable<DataTable> enumerable)
        {
            Guard.ArgumentIsNotNull(myWorkReportData, nameof(myWorkReportData));
            Guard.ArgumentIsNotNull(tables, nameof(tables));

            var dataTable = myWorkReportData.ExecuteSql(sql);
            myWorkDataTable = new DataTable();

            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                myWorkDataTable.Columns.Add(dataColumn.ColumnName, dataColumn.DataType);
            }

            IEnumerable<DataTable> dataTables = null;

            if (DataFromReportingDb(dataTable, myWorkDataTable, tables, ref dataTables))
            {
                {
                    enumerable = dataTables;
                    columns = null;
                    lists = null;
                    return true;
                }
            }

            columns = from DataColumn dataColumn in myWorkDataTable.Columns
                select $@"N'{dataColumn.ColumnName}'";

            lists = new List<string>
            {
                $@"N'{myWorkListId.ToString()
                   .Replace(OpenCurlyBrace, string.Empty)
                   .Replace(ClosedCurlyBrace, string.Empty)}'"
            };

            foreach (DataRow dataRow in myWorkDataTable.Rows)
            {
                var listId = dataRow[ListId].ToString();
                var lstId = $@"N'{listId}'";

                if (!lists.Contains(lstId))
                {
                    lists.Add(lstId);
                }

                var uniqueId = (listId + dataRow[WebIdText] + dataRow[SiteId]).Md5();

                if (!GetMyWorkParams.WorkTypes.ContainsKey(uniqueId))
                {
                    GetMyWorkParams.WorkTypes.Add(uniqueId, dataRow[WorkType].ToString());
                }
            }

            return false;
        }

        private static bool DataFromReportingDb(
            DataTable dataTable,
            DataTable myWorkDataTable,
            IList<DataTable> tables,
            ref IEnumerable<DataTable> dataTables)
        {
            Guard.ArgumentIsNotNull(dataTable, nameof(dataTable));
            Guard.ArgumentIsNotNull(myWorkDataTable, nameof(myWorkDataTable));
            Guard.ArgumentIsNotNull(tables, nameof(tables));
            Guard.ArgumentIsNotNull(dataTable, nameof(dataTable));

            var list = new List<string>();
            var dataRows = dataTable.AsEnumerable();

            foreach (var dataRow in dataRows)
            {
                var key = $"{dataRow[SiteId]}{dataRow[WebIdText]}{dataRow[ListId]}{dataRow[ItemId]}{dataRow[AssignedToId]}";
                key = key.Replace(OpenCurlyBrace, string.Empty).Replace(ClosedCurlyBrace, string.Empty).ToUpper();

                if (list.Contains(key))
                {
                    continue;
                }

                list.Add(key);

                var row = myWorkDataTable.NewRow();

                foreach (DataColumn dataColumn in myWorkDataTable.Columns)
                {
                    row[dataColumn.ColumnName] = dataRow[dataColumn.ColumnName];
                }

                myWorkDataTable.Rows.Add(row);
            }

            if (myWorkDataTable.Rows.Count == 0)
            {
                dataTables = tables;
                return true;
            }

            return false;
        }
    }
}