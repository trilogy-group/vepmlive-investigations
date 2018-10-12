using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportHelper
{
    public partial class ReportData
    {
        public DataTable ListItemsDataTable(
            Guid timerJobGuid,
            string sTableName,
            SPWeb spWeb,
            string sListName,
            ArrayList defaultColumns,
            out bool error,
            out string errMsg)
        {
            Guard.ArgumentIsNotNull(defaultColumns, nameof(defaultColumns));
            Guard.ArgumentIsNotNull(sListName, nameof(sListName));
            Guard.ArgumentIsNotNull(spWeb, nameof(spWeb));
            Guard.ArgumentIsNotNull(sTableName, nameof(sTableName));

            error = false;
            errMsg = string.Empty;

            var errItemTitle = string.Empty;
            var dtItems = new DataTable();
            var errItemId = string.Empty;
            var errColumnName = string.Empty;

            try
            {
                var spList = spWeb.Lists[sListName];
                var dtColumns = GetListColumns(spList.ID);

                VerifyListColumns(dtColumns, sTableName);

                foreach (DataRow row in dtColumns.Rows)
                {
                    var columnType = row[ColumnType].ToString().ToLower();

                    switch (columnType)
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

                foreach (SPListItem item in spList.Items)
                {
                    errItemId = item.ID.ToString();
                    errItemTitle = item.Title;
                    PopulateDataTableItems(defaultColumns, dtItems, dtColumns, ref errColumnName, spList, item);
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                error = true;
                errMsg = $"{exception.Message}[LOCATION INFO] - ItemTitle: {errItemTitle}, ItemId: {errItemId}, ColumnName: {errColumnName}.";
            }

            return dtItems;
        }

        private void PopulateDataTableItems(
            ArrayList defaultColumns,
            DataTable dtItems,
            DataTable dtColumns,
            ref string errColumnName,
            SPList spList,
            SPListItem item)
        {
            Guard.ArgumentIsNotNull(item, nameof(item));
            Guard.ArgumentIsNotNull(spList, nameof(spList));
            Guard.ArgumentIsNotNull(errColumnName, nameof(errColumnName));
            Guard.ArgumentIsNotNull(dtColumns, nameof(dtColumns));
            Guard.ArgumentIsNotNull(dtItems, nameof(dtItems));
            Guard.ArgumentIsNotNull(defaultColumns, nameof(defaultColumns));

            var itemRow = dtItems.NewRow();

            foreach (DataRow column in dtColumns.Rows)
            {
                errColumnName = column[ColumnName].ToString();

                if (spList.Fields.ContainsField(column[InternalName].ToString()))
                {
                    ProcessInternalName(defaultColumns, item, column, itemRow);
                }
                else
                {
                    bool blnGuid;
                    var obj = GetDefaultColumnValue(column[ColumnName].ToString().ToLower(), item, out blnGuid);

                    if (blnGuid && obj != null)
                    {
                        var id = (Guid)obj;
                        itemRow[column[ColumnName].ToString()] = id;
                    }
                    else if (obj != null)
                    {
                        itemRow[column[ColumnName].ToString()] = obj;
                    }
                }
            }

            dtItems.Rows.Add(itemRow);
        }

        private void ProcessInternalName(ArrayList defaultColumns, SPListItem item, DataRow column, DataRow itemRow)
        {
            Guard.ArgumentIsNotNull(itemRow, nameof(itemRow));
            Guard.ArgumentIsNotNull(column, nameof(column));
            Guard.ArgumentIsNotNull(item, nameof(item));
            Guard.ArgumentIsNotNull(defaultColumns, nameof(defaultColumns));

            if (column[SharePointType].ToString().Equals(Lookup, StringComparison.OrdinalIgnoreCase) ||
                column[SharePointType].ToString().Equals(User, StringComparison.OrdinalIgnoreCase))
            {
                if (column[ColumnName].ToString().EndsWith(TextId, StringComparison.OrdinalIgnoreCase))
                {
                    itemRow[column[ColumnName].ToString()] = ItemHasValue(item, column[InternalName].ToString())
                        ? (object)AddLookUpFieldValues(item[column[InternalName].ToString()].ToString(), TextId)
                        : DBNull.Value;
                }
                else if (column[ColumnName].ToString().EndsWith(IdText, StringComparison.OrdinalIgnoreCase))
                {
                    if (ItemHasValue(item, column[InternalName].ToString()))
                    {
                        var fieldType = GetFieldType(item, column[InternalName].ToString());

                        var addLookUpFieldValues = AddLookUpFieldValues(item[column[InternalName].ToString()].ToString(), IdText);

                        if (fieldType.Equals(LookupMulti, StringComparison.InvariantCultureIgnoreCase) ||
                            fieldType.Equals(UserMulti, StringComparison.InvariantCultureIgnoreCase))
                        {
                            itemRow[column[ColumnName].ToString()] = addLookUpFieldValues;
                        }
                        else
                        {
                            if (int.TryParse(addLookUpFieldValues, out _))
                            {
                                itemRow[column[ColumnName].ToString()] = addLookUpFieldValues;
                            }
                        }
                    }
                    else
                    {
                        itemRow[column[ColumnName].ToString()] = DBNull.Value;
                    }
                }
            }
            else
            {
                ProcessNonLookupNonUserColumn(defaultColumns, item, column, itemRow);
            }
        }

        private void ProcessNonLookupNonUserColumn(ArrayList defaultColumns, SPListItem item, DataRow column, DataRow itemRow)
        {
            Guard.ArgumentIsNotNull(itemRow, nameof(itemRow));
            Guard.ArgumentIsNotNull(column, nameof(column));
            Guard.ArgumentIsNotNull(item, nameof(item));
            Guard.ArgumentIsNotNull(defaultColumns, nameof(defaultColumns));
            SPField field;

            if (column[SharePointType].ToString().Equals(MultiChoice, StringComparison.OrdinalIgnoreCase))
            {
                field = item.Fields.GetFieldByInternalName(column[ColumnNameLower].ToString());

                if (ItemHasValue(item, field.InternalName))
                {
                    var itemVal = Convert.ToString(item[field.InternalName]);

                    try
                    {
                        itemRow[column[ColumnName].ToString()] = itemVal.StartsWith(SemiColonHash) && itemVal.EndsWith(SemiColonHash)
                            ? itemVal.Substring(SemiColonHash.Length, itemVal.Length - 4)
                            : itemVal;
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                        itemRow[column[ColumnName].ToString()] = DBNull.Value;
                    }
                }
                else
                {
                    itemRow[column[ColumnName].ToString()] = DBNull.Value;
                }
            }
            else
            {
                if (!defaultColumns.Contains(column[ColumnName].ToString().ToLower()))
                {
                    field = item.Fields.GetFieldByInternalName(column[ColumnNameLower].ToString());

                    if (ItemHasValue(item, field.InternalName))
                    {
                        try
                        {
                            itemRow[column[ColumnName].ToString()] = field.Type != SPFieldType.Calculated
                                ? item[field.InternalName]
                                : _DAO.GetCalculatedFieldValue(item, (SPFieldCalculated)field);
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                            itemRow[column[ColumnName].ToString()] = DBNull.Value;
                        }
                    }
                    else
                    {
                        itemRow[column[ColumnName].ToString()] = DBNull.Value;
                    }
                }
            }
        }
    }
}