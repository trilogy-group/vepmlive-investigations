using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportHelper
{
    public partial class ReportData
    {
        public DataTable MyWorkListItemsDataTable(
            Guid timerJobGuid,
            string sTableName,
            SPWeb spWeb,
            string sListName,
            ArrayList defaultColumns,
            Guid listId,
            out bool error,
            out string errMsg)
        {
            Guard.ArgumentIsNotNull(defaultColumns, nameof(defaultColumns));
            Guard.ArgumentIsNotNull(sListName, nameof(sListName));
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(sTableName, nameof(sTableName));

            var dtItems = new DataTable();
            var dtColumns = GetListColumns("My Work");
            dtColumns = AddMetaInfoCols(dtColumns);
            error = false;
            errMsg = string.Empty;

            var errItemTitle = string.Empty;
            var errItemId = string.Empty;
            var errColumnName = string.Empty;

            try
            {
                VerifyListColumns(dtColumns, sTableName);

                foreach (DataRow row in dtColumns.Rows)
                {
                    var typeString = row[ColumnType].ToString().ToLower();

                    switch (typeString)
                    {
                        case UniqueIdentifier:
                            dtItems.Columns.Add(row[ColumnName].ToString(), typeof(Guid));
                            break;
                        case IntText:
                            dtItems.Columns.Add(row[ColumnName].ToString(), typeof(decimal));
                            break;
                        case DateTimeLower:
                            dtItems.Columns.Add(row[ColumnName].ToString(), typeof(DateTime));
                            break;
                        case FloatLower:
                            dtItems.Columns.Add(row[ColumnName].ToString(), typeof(decimal));
                            break;
                        default:
                            dtItems.Columns.Add(row[ColumnName].ToString());
                            break;
                    }
                }

                errItemId = ProcessSpList(
                    spWeb,
                    sListName,
                    defaultColumns,
                    listId,
                    errItemId,
                    dtItems,
                    dtColumns,
                    ref errItemTitle,
                    ref errColumnName);
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                error = true;
                errMsg = $"{exception.Message}[LOCATION INFO] - ItemTitle: {errItemTitle}, ItemId: {errItemId}, ColumnName: {errColumnName}.";
            }

            return dtItems;
        }

        private string ProcessSpList(
            SPWeb spWeb,
            string sListName,
            ArrayList defaultColumns,
            Guid listId,
            string errItemId,
            DataTable dtItems,
            DataTable dtColumns,
            ref string errItemTitle,
            ref string errColumnName)
        {
            Guard.ArgumentIsNotNull(errColumnName, nameof(errColumnName));
            Guard.ArgumentIsNotNull(errItemTitle, nameof(errItemTitle));
            Guard.ArgumentIsNotNull(dtColumns, nameof(dtColumns));
            Guard.ArgumentIsNotNull(dtItems, nameof(dtItems));
            Guard.ArgumentIsNotNull(errItemId, nameof(errItemId));
            Guard.ArgumentIsNotNull(defaultColumns, nameof(defaultColumns));
            Guard.ArgumentIsNotNull(sListName, nameof(sListName));
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));

            var spList = spWeb.Lists[sListName];

            foreach (SPListItem item in spList.Items)
            {
                errItemId = item.ID.ToString();
                errItemTitle = item.Title;

                var spFieldCollection = item.ParentList.Fields;

                if (spFieldCollection.ContainsFieldWithInternalName(AssignedTo) && item[AssignedTo] != null)
                {
                    var spFieldUserValueCollection = new SPFieldUserValueCollection(item.Web, item[AssignedTo].ToString());

                    var totalAssignedToUsers = spFieldUserValueCollection.Count;

                    ProcessFieldCollectionInternalNameWork(
                        sListName,
                        defaultColumns,
                        dtItems,
                        dtColumns,
                        ref errColumnName,
                        spFieldCollection,
                        item,
                        spFieldUserValueCollection,
                        spList,
                        totalAssignedToUsers);

                    var tableName = _DAO.GetTableName(listId);

                    if (ListReportsWork(tableName))
                    {
                        _DAO.SaveWork(item);
                    }
                }
            }

            return errItemId;
        }

        private void ProcessFieldCollectionInternalNameWork(
            string sListName,
            ArrayList defaultColumns,
            DataTable dtItems,
            DataTable dtColumns,
            ref string errColumnName,
            SPFieldCollection spFieldCollection,
            SPListItem item,
            SPFieldUserValueCollection spFieldUserValueCollection,
            SPList spList,
            int totalAssignedToUsers)
        {
            Guard.ArgumentIsNotNull(spList, nameof(spList));
            Guard.ArgumentIsNotNull(spFieldUserValueCollection, nameof(spFieldUserValueCollection));
            Guard.ArgumentIsNotNull(item, nameof(item));
            Guard.ArgumentIsNotNull(spFieldCollection, nameof(spFieldCollection));
            Guard.ArgumentIsNotNull(errColumnName, nameof(errColumnName));
            Guard.ArgumentIsNotNull(dtColumns, nameof(dtColumns));
            Guard.ArgumentIsNotNull(dtItems, nameof(dtItems));
            Guard.ArgumentIsNotNull(defaultColumns, nameof(defaultColumns));
            Guard.ArgumentIsNotNull(sListName, nameof(sListName));

            if (spFieldCollection.ContainsFieldWithInternalName(Work))
            {
                var originalWork = item[Work] ?? DBNull.Value;

                var allUsers = new List<string>();

                try
                {
                    allUsers.AddRange(spFieldUserValueCollection.Select(userValue => userValue.User.Name));
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                }

                item[AssignedTo] = "-99;#";

                errColumnName = AddSummaryRow(sListName, defaultColumns, dtItems, originalWork, dtColumns, errColumnName, spList, allUsers, item);

                double tempHours;

                var hours = double.TryParse(originalWork.ToString(), out tempHours)
                    ? tempHours / totalAssignedToUsers
                    : 0.0;

                foreach (var spFieldUserValue in spFieldUserValueCollection)
                {
                    var itemRow = dtItems.NewRow();
                    item[Work] = hours;
                    item[AssignedTo] = spFieldUserValue;
                    itemRow[WorkTypeText] = sListName;
                    itemRow[DataSourceText] = 1;

                    ProcessFieldCollectionColumns(defaultColumns, dtColumns, item, spList, itemRow, allUsers);

                    dtItems.Rows.Add(itemRow);
                }

                item[Work] = originalWork;
                item[AssignedTo] = spFieldUserValueCollection;
            }
        }

        private void ProcessFieldCollectionColumns(
            ArrayList defaultColumns,
            DataTable dtColumns,
            SPListItem item,
            SPList spList,
            DataRow itemRow,
            IList<string> allUsers)
        {
            Guard.ArgumentIsNotNull(allUsers, nameof(allUsers));
            Guard.ArgumentIsNotNull(itemRow, nameof(itemRow));
            Guard.ArgumentIsNotNull(spList, nameof(spList));
            Guard.ArgumentIsNotNull(item, nameof(item));
            Guard.ArgumentIsNotNull(dtColumns, nameof(dtColumns));
            Guard.ArgumentIsNotNull(defaultColumns, nameof(defaultColumns));

            foreach (DataRow column in dtColumns.Rows)
            {
                var internalName = column[InternalName].ToString();
                var columnName = column[ColumnName].ToString();

                if (spList.Fields.ContainsField(internalName) &&
                    spList.Fields.GetFieldByInternalName(internalName)
                       .Type.ToString()
                       .Equals(column[SharePointType].ToString().ToLower(), StringComparison.OrdinalIgnoreCase))
                {
                    var sharepointColumn = column[SharePointType].ToString();

                    if (sharepointColumn.Equals(Lookup, StringComparison.OrdinalIgnoreCase) ||
                        sharepointColumn.Equals(User, StringComparison.OrdinalIgnoreCase))
                    {
                        ProcessSharePointColumn(item, itemRow, allUsers, columnName, internalName);
                    }
                    else
                    {
                        if (!defaultColumns.Contains(columnName.ToLower()))
                        {
                            var field = item.Fields.GetFieldByInternalName(column[ColumnNameLower].ToString());

                            if (ItemHasValue(item, field.InternalName))
                            {
                                try
                                {
                                    if (field.Type != SPFieldType.Calculated)
                                    {
                                        itemRow[columnName] = item[field.InternalName];
                                    }
                                    else
                                    {
                                        itemRow[columnName] = _DAO.GetCalculatedFieldValue(item, (SPFieldCalculated)field);
                                    }
                                }
                                catch (Exception exception)
                                {
                                    Trace.WriteLine(exception);
                                    itemRow[columnName] = DBNull.Value;
                                }
                            }
                            else
                            {
                                itemRow[columnName] = DBNull.Value;
                            }
                        }
                    }
                }
                else
                {
                    bool blnGuid;
                    var obj = GetDefaultColumnValue(columnName.ToLower(), item, out blnGuid);

                    if (blnGuid && obj != null)
                    {
                        itemRow[columnName] = (Guid)obj;
                    }
                    else if (obj != null)
                    {
                        itemRow[columnName] = obj;
                    }
                }
            }
        }

        private void ProcessSharePointColumn(SPListItem item, DataRow itemRow, IEnumerable<string> allUsers, string columnName, string internalName)
        {
            if (columnName.Equals(AssignedToText, StringComparison.OrdinalIgnoreCase))
            {
                itemRow[columnName] = string.Join(", ", allUsers.Distinct());
            }
            else if (columnName.EndsWith(TextId, StringComparison.OrdinalIgnoreCase))
            {
                if (ItemHasValue(item, internalName))
                {
                    itemRow[columnName] = AddLookUpFieldValues(item[internalName].ToString(), TextId);
                }
                else
                {
                    itemRow[columnName] = DBNull.Value;
                }
            }
            else if (columnName.EndsWith(IdText, StringComparison.OrdinalIgnoreCase))
            {
                if (ItemHasValue(item, internalName))
                {
                    itemRow[columnName] = AddLookUpFieldValues(item[internalName].ToString(), IdText);
                }
                else
                {
                    itemRow[columnName] = DBNull.Value;
                }
            }
        }

        private string AddSummaryRow(
            string sListName,
            ArrayList defaultColumns,
            DataTable dtItems,
            object originalWork,
            DataTable dtColumns,
            string errColumnName,
            SPList spList,
            List<string> allUsers,
            SPListItem item)
        {
            Guard.ArgumentIsNotNull(item, nameof(item));
            Guard.ArgumentIsNotNull(allUsers, nameof(allUsers));
            Guard.ArgumentIsNotNull(spList, nameof(spList));
            Guard.ArgumentIsNotNull(errColumnName, nameof(errColumnName));
            Guard.ArgumentIsNotNull(dtColumns, nameof(dtColumns));
            Guard.ArgumentIsNotNull(originalWork, nameof(originalWork));
            Guard.ArgumentIsNotNull(dtItems, nameof(dtItems));
            Guard.ArgumentIsNotNull(defaultColumns, nameof(defaultColumns));
            Guard.ArgumentIsNotNull(sListName, nameof(sListName));

            var itemRow = dtItems.NewRow();
            itemRow[Work] = originalWork;
            itemRow[WorkTypeText] = sListName;
            itemRow[DataSourceText] = 1;

            foreach (DataRow column in dtColumns.Rows)
            {
                var internalName = column[InternalName].ToString();
                var columnName = column[ColumnName].ToString();

                errColumnName = column[ColumnName].ToString();

                if (spList.Fields.ContainsField(internalName) &&
                    spList.Fields.GetFieldByInternalName(internalName)
                       .Type.ToString()
                       .Equals(column[SharePointType].ToString().ToLower(), StringComparison.OrdinalIgnoreCase))
                {
                    ProcessInternalField(defaultColumns, allUsers, item, column, columnName, itemRow, internalName);
                }
                else
                {
                    bool blnGuid;
                    var obj = GetDefaultColumnValue(columnName.ToLower(), item, out blnGuid);

                    if (blnGuid && obj != null)
                    {
                        itemRow[columnName] = (Guid)obj;
                    }
                    else if (obj != null)
                    {
                        itemRow[columnName] = obj;
                    }
                }
            }

            dtItems.Rows.Add(itemRow);

            return errColumnName;
        }

        private void ProcessInternalField(
            ArrayList defaultColumns,
            IEnumerable<string> allUsers,
            SPListItem item,
            DataRow column,
            string columnName,
            DataRow itemRow,
            string internalName)
        {
            Guard.ArgumentIsNotNull(internalName, nameof(internalName));
            Guard.ArgumentIsNotNull(itemRow, nameof(itemRow));
            Guard.ArgumentIsNotNull(columnName, nameof(columnName));
            Guard.ArgumentIsNotNull(column, nameof(column));
            Guard.ArgumentIsNotNull(item, nameof(item));
            Guard.ArgumentIsNotNull(allUsers, nameof(allUsers));
            Guard.ArgumentIsNotNull(defaultColumns, nameof(defaultColumns));

            if (column[SharePointType].ToString().Equals(Lookup, StringComparison.OrdinalIgnoreCase) ||
                column[SharePointType].ToString().Equals(User, StringComparison.OrdinalIgnoreCase))
            {
                if (columnName.Equals(AssignedToText, StringComparison.OrdinalIgnoreCase))
                {
                    itemRow[columnName] = string.Join(", ", allUsers.Distinct());
                }
                else if (columnName.EndsWith(TextId, StringComparison.OrdinalIgnoreCase))
                {
                    if (ItemHasValue(item, internalName))
                    {
                        itemRow[columnName] = AddLookUpFieldValues(item[internalName].ToString(), TextId);
                    }
                    else
                    {
                        itemRow[columnName] = DBNull.Value;
                    }
                }
                else if (columnName.EndsWith(IdText, StringComparison.OrdinalIgnoreCase))
                {
                    if (ItemHasValue(item, internalName))
                    {
                        itemRow[columnName] = AddLookUpFieldValues(item[internalName].ToString(), IdText);
                    }
                    else
                    {
                        itemRow[columnName] = DBNull.Value;
                    }
                }
            }
            else
            {
                if (!defaultColumns.Contains(columnName.ToLower()))
                {
                    var field = item.Fields.GetFieldByInternalName(column[ColumnNameLower].ToString());

                    if (ItemHasValue(item, field.InternalName))
                    {
                        try
                        {
                            if (field.Type != SPFieldType.Calculated)
                            {
                                itemRow[columnName] = item[field.InternalName];
                            }
                            else
                            {
                                itemRow[columnName] = _DAO.GetCalculatedFieldValue(item, (SPFieldCalculated)field);
                            }
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                            itemRow[columnName] = DBNull.Value;
                        }
                    }
                    else
                    {
                        itemRow[columnName] = DBNull.Value;
                    }
                }
            }
        }
    }
}