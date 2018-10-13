using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using EPMLiveCore.Helpers;
using Microsoft.SharePoint;

namespace EPMLiveCore.ReportHelper
{
    public partial class ReportData
    {
        protected virtual string AddColumnValues(
            SPListItem spListItem,
            DataTable dtColumns,
            ArrayList defaultColumns,
            ArrayList mandatoryHiddenFields,
            string action)
        {
            Guard.ArgumentIsNotNull(action, nameof(action));
            Guard.ArgumentIsNotNull(mandatoryHiddenFields, nameof(mandatoryHiddenFields));
            Guard.ArgumentIsNotNull(defaultColumns, nameof(defaultColumns));
            Guard.ArgumentIsNotNull(dtColumns, nameof(dtColumns));
            Guard.ArgumentIsNotNull(spListItem, nameof(spListItem));

            _cmdWithParams = new SqlCommand();
            _params = _cmdWithParams.Parameters;

            var sColValues = string.Empty;

            if (action == InsertAction)
            {
                sColValues = " VALUES(";
            }

            var columnName = string.Empty;
            var internalName = string.Empty;
            SqlParameter param = null;

            try
            {
                foreach (DataRow row in dtColumns.Rows)
                {
                    columnName = row[ColumnName].ToString().Replace(SingleQuote, string.Empty);
                    internalName = row[InternalName].ToString().Replace(SingleQuote, string.Empty);
                    var columnNameLower = columnName.ToLower();

                    if (defaultColumns.Contains(columnNameLower))
                    {
                        param = PopulateDefaultColumnValue(columnNameLower.Replace(SingleQuote, string.Empty), spListItem);
                    }
                    else if (mandatoryHiddenFields.Contains(columnNameLower))
                    {
                        param = PopulateMandatoryHiddenFldsColumnValue(columnNameLower.Replace(SingleQuote, string.Empty), spListItem);
                    }
                    else
                    {
                        param = PopulateNonDefaultColumnValue(spListItem, internalName, columnName, param);
                    }

                    _params.Add(param);

                    if (action == InsertAction)
                    {
                        sColValues = $"{sColValues.Replace(SingleQuote, string.Empty)}{param.ParameterName.Replace(SingleQuote, string.Empty)},";
                    }
                    else if (action == UpdateAction)
                    {
                        sColValues = $"{sColValues}[{columnName.Replace(SingleQuote, string.Empty)}] = {param.ParameterName.Replace(SingleQuote, string.Empty)}, ";
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
                AddColumnValuesHandleException(exception, param, columnName, internalName);
            }

            sColValues = sColValues.Remove(sColValues.LastIndexOf(",")).Replace(SingleQuote, string.Empty);

            if (action == InsertAction)
            {
                sColValues = $"{sColValues}) ";
            }

            return sColValues;
        }

        private void AddColumnValuesHandleException(Exception exception, SqlParameter param, string columnName, string internalName)
        {
            param.Value = DBNull.Value;
            SPSecurity.RunWithElevatedPrivileges(
                delegate
                {
                    if (!EventLog.SourceExists(EpmLiveReportingGetColumnValue))
                    {
                        EventLog.CreateEventSource(EpmLiveReportingGetColumnValue, EpmLiveId);
                    }

                    var myLog = new EventLog(EpmLiveId, ".", EpmLiveReportingGetColumnValue)
                    {
                        MaximumKilobytes = 32768
                    };
                    myLog.WriteEntry(
                        $"Name: {_siteName} Url: {_siteUrl} ID: {_siteId} : {exception.Message} ColumnName: {columnName} InternalName: {internalName}",
                        EventLogEntryType.Error,
                        9000);
                });
        }

        private SqlParameter PopulateNonDefaultColumnValue(SPListItem spListItem, string internalName, string columnName, SqlParameter param)
        {
            Guard.ArgumentIsNotNull(param, nameof(param));
            Guard.ArgumentIsNotNull(columnName, nameof(columnName));
            Guard.ArgumentIsNotNull(internalName, nameof(internalName));
            Guard.ArgumentIsNotNull(spListItem, nameof(spListItem));

            SPField field = null;

            if (spListItem.Fields.ContainsField(internalName))
            {
                param = ProcessInternalNameAddColumnValues(spListItem, internalName, columnName);
            }
            else
            {
                try
                {
                    var parentList = spListItem.ParentList;
                    field = parentList.ParentWeb.Site.RootWeb.Lists[parentList.Title].Fields.GetFieldByInternalName(internalName);
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                }

                if (field != null)
                {
                    param = GetParam(field, columnName);
                    param.Value = DBNull.Value;
                    param.ParameterName = $"@{internalName.Replace(SingleQuote, string.Empty)}";
                }
            }

            return param;
        }

        private SqlParameter ProcessInternalNameAddColumnValues(SPListItem spListItem, string internalName, string columnName)
        {
            Guard.ArgumentIsNotNull(columnName, nameof(columnName));
            Guard.ArgumentIsNotNull(internalName, nameof(internalName));
            Guard.ArgumentIsNotNull(spListItem, nameof(spListItem));

            SqlParameter param;

            if (!IsLookUpField(spListItem.ParentList.Title, columnName))
            {
                param = ProcessNonLookUpField(spListItem, internalName, columnName);
            }
            else
            {
                var field = spListItem.Fields.GetFieldByInternalName(internalName);
                param = GetParam(field, columnName);
                param.ParameterName = $"@{columnName.Replace(SingleQuote, string.Empty)}";

                object lookupVal = null;

                try
                {
                    lookupVal = spListItem[field.InternalName];
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                }

                if (field is SPFieldMultiChoice)
                {
                    param.Value = columnName.EndsWith(TextId, StringComparison.OrdinalIgnoreCase) && lookupVal != null
                        ? (object)AddMultiChoiceValues(lookupVal.ToString(), TextId)
                        : DBNull.Value;
                }
                else
                {
                    if (columnName.EndsWith(TextId, StringComparison.OrdinalIgnoreCase) && lookupVal != null)
                    {
                        param.Value = AddLookUpFieldValues(lookupVal.ToString(), TextId);
                    }
                    else
                    {
                        param.Value = lookupVal != null
                            ? (object)AddLookUpFieldValues(lookupVal.ToString(), Id)
                            : DBNull.Value;
                    }
                }
            }

            return param;
        }

        private SqlParameter ProcessNonLookUpField(SPListItem spListItem, string internalName, string columnName)
        {
            Guard.ArgumentIsNotNull(columnName, nameof(columnName));
            Guard.ArgumentIsNotNull(internalName, nameof(internalName));
            Guard.ArgumentIsNotNull(spListItem, nameof(spListItem));

            var field = spListItem.Fields.GetFieldByInternalName(internalName);
            var param = GetParam(field, columnName);
            param.ParameterName = $"@{field.InternalName.Replace(SingleQuote, string.Empty)}";

            if (field.Type == SPFieldType.MultiChoice)
            {
                var multiValue = string.Empty;

                try
                {
                    multiValue = Convert.ToString(spListItem[field.InternalName]);
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                }

                if (!string.IsNullOrWhiteSpace(multiValue))
                {
                    param.Value = multiValue.StartsWith(SemiColonHash) && multiValue.EndsWith(SemiColonHash)
                        ? multiValue.Substring(SemiColonHash.Length, multiValue.Length - 4)
                        : multiValue;
                }
                else
                {
                    param.Value = DBNull.Value;
                }
            }
            else if (field.Type != SPFieldType.Calculated)
            {
                object lookupVal = null;

                try
                {
                    lookupVal = spListItem[field.InternalName];
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                }

                param.Value = lookupVal != null
                    ? (object)lookupVal.ToString()
                    : DBNull.Value;
            }
            else
            {
                try
                {
                    param.Value = _DAO.GetCalculatedFieldValue(spListItem, (SPFieldCalculated)field);
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                    param.Value = DBNull.Value;
                }
            }

            return param;
        }
    }
}