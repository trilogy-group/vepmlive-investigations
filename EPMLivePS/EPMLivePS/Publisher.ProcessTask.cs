using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using EPMLiveCore.Helpers;
using EPMLiveEnterprise.WebSvcProject;
using Microsoft.SharePoint;

namespace EPMLiveEnterprise
{
    internal partial class Publisher
    {
        private void processTask(
            ProjectDataSet.TaskRow taskRow,
            ProjectDataSet projectDataSet,
            ArrayList fieldsToPublish,
            SPListItem listItem,
            Hashtable hshFields,
            string taskUid,
            int pubType)
        {
            try
            {
                ProcessFieldsToPublish(taskRow, projectDataSet, fieldsToPublish, listItem);
                UpdateTaskUidAndTimeSheetId(taskRow, projectDataSet, listItem, taskUid, pubType);
                listItem.Update();
            }
            catch (SPException spException)
            {
                myLog.WriteEntry(
                    $"SPException: Error processing Task ({taskRow.TASK_NAME}): {spException.Message}{spException.StackTrace}",
                    EventLogEntryType.Error,
                    331);
            }
            catch (Exception exception)
            {
                myLog.WriteEntry(
                    $"Error processing Task ({taskRow.TASK_NAME}): {exception.Message}{exception.StackTrace}",
                    EventLogEntryType.Error,
                    330);
            }
        }

        private void ProcessFieldsToPublish(
            ProjectDataSet.TaskRow taskRow,
            ProjectDataSet projectDataSet,
            ArrayList fieldsToPublish,
            SPListItem listItem)
        {
            Guard.ArgumentIsNotNull(listItem, nameof(listItem));
            Guard.ArgumentIsNotNull(fieldsToPublish, nameof(fieldsToPublish));
            Guard.ArgumentIsNotNull(projectDataSet, nameof(projectDataSet));
            Guard.ArgumentIsNotNull(taskRow, nameof(taskRow));

            const char FieldSplitChar = '#';

            foreach (string field in fieldsToPublish)
            {
                var fieldSplit = field.Split(FieldSplitChar);

                if (fieldSplit.Length < 6)
                {
                    throw new InvalidOperationException("Invalid fieldSplit count.");
                }

                var fieldName = fieldSplit[0];
                var wssFieldName = fieldSplit[1];
                var fieldCategory = fieldSplit[3];
                var fieldType = fieldSplit[4];
                var multiplier = fieldSplit[5];
                string fieldData = null;

                try
                {
                    if (fieldCategory == FieldCategoryThree)
                    {
                        var drAssn = projectDataSet.TaskCustomFields.Select($"TASK_UID=\'{taskRow.TASK_UID}\' AND MD_PROP_ID=\'{fieldName}\'");
                        fieldData = GetFieldData(fieldType, drAssn, fieldName);
                        listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                    }
                    else if (fieldCategory == FieldCategoryTwo)
                    {
                        var drAssn = projectDataSet.TaskCustomFields.Select($"TASK_UID=\'{taskRow.TASK_UID}\' AND MD_PROP_ID=\'{fieldName}\'");

                        if (drAssn.Length >= 1)
                        {
                            fieldData = GetFieldData(fieldType, drAssn, fieldName, true);
                            listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                        }
                    }
                    else if (fieldCategory == FieldCategoryOne)
                    {
                        fieldData = ProcessFieldCategoryOne(taskRow, projectDataSet, listItem, fieldName, wssFieldName, fieldType, multiplier);
                    }
                }
                catch (Exception exception)
                {
                    myLog.WriteEntry(
                        $"Error setting field ({fieldName}) fieldValue ({fieldData}): {exception.Message}{exception.StackTrace}",
                        EventLogEntryType.Error,
                        335);
                }
            }
        }

        private void UpdateTaskUidAndTimeSheetId(
            ProjectDataSet.TaskRow taskRow,
            ProjectDataSet projectDataSet,
            SPListItem listItem,
            string taskUid,
            int pubType)
        {
            Guard.ArgumentIsNotNull(taskUid, nameof(taskUid));
            Guard.ArgumentIsNotNull(listItem, nameof(listItem));
            Guard.ArgumentIsNotNull(projectDataSet, nameof(projectDataSet));
            Guard.ArgumentIsNotNull(taskRow, nameof(taskRow));

            if (!string.IsNullOrWhiteSpace(taskUid))
            {
                listItem[TaskUid] = taskUid;
            }

            if (!string.IsNullOrWhiteSpace(strTimesheetField))
            {
                if (listItem.Fields.ContainsField(TimeSheetId))
                {
                    if (pubType == PubTypeOne)
                    {
                        listItem[TimeSheetId] = 0;
                    }
                    else
                    {
                        var drAssn = projectDataSet.TaskCustomFields.Select(
                            $"TASK_UID=\'{taskRow.TASK_UID}\' AND MD_PROP_UID=\'{strTimesheetField}\'");

                        listItem[TimeSheetId] = drAssn.Length > 0
                            ? (object)drAssn[0][FlagValue].ToString()
                            : 0;
                    }
                }
            }
        }

        private string ProcessFieldCategoryOne(
            ProjectDataSet.TaskRow taskRow,
            ProjectDataSet projectDataSet,
            SPListItem listItem,
            string fieldName,
            string wssFieldName,
            string fieldType,
            string multiplier)
        {
            Guard.ArgumentIsNotNull(multiplier, nameof(multiplier));
            Guard.ArgumentIsNotNull(fieldType, nameof(fieldType));
            Guard.ArgumentIsNotNull(wssFieldName, nameof(wssFieldName));
            Guard.ArgumentIsNotNull(fieldName, nameof(fieldName));
            Guard.ArgumentIsNotNull(listItem, nameof(listItem));
            Guard.ArgumentIsNotNull(projectDataSet, nameof(projectDataSet));
            Guard.ArgumentIsNotNull(taskRow, nameof(taskRow));

            string fieldData = null;

            if (fieldName == TaskPredecessors)
            {
                ProcessTaskPredecessors(taskRow, projectDataSet, listItem, wssFieldName);
            }
            else if (fieldName != TaskResnames)
            {
                try
                {
                    fieldData = taskRow[fieldName].ToString();
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                }

                if (fieldType == DateTimeText)
                {
                    listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = !string.IsNullOrWhiteSpace(fieldData.Trim())
                        ? (object)DateTime.Parse(fieldData)
                        : null;
                }
                else
                {
                    if (multiplier != "1")
                    {
                        fieldData = multiplyField(fieldData, multiplier);
                    }

                    listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                }
            }

            return fieldData;
        }

        private static void ProcessTaskPredecessors(
            ProjectDataSet.TaskRow taskRow,
            ProjectDataSet projectDataSet,
            SPListItem listItem,
            string wssFieldName)
        {
            Guard.ArgumentIsNotNull(wssFieldName, nameof(wssFieldName));
            Guard.ArgumentIsNotNull(listItem, nameof(listItem));
            Guard.ArgumentIsNotNull(projectDataSet, nameof(projectDataSet));
            Guard.ArgumentIsNotNull(taskRow, nameof(taskRow));

            const string LinkTypeZero = "0";
            const string LinkTypeTwo = "2";
            const string LinkTypeThree = "3";

            var predecessorDataSetBuilder = new StringBuilder();
            var dataRows = projectDataSet.Dependency.Select($"LINK_SUCC_UID=\'{taskRow.TASK_UID}\'");

            foreach (var dataRow in dataRows)
            {
                var drTask = (ProjectDataSet.TaskRow[])projectDataSet.Task.Select($"TASK_UID=\'{dataRow["LINK_PRED_UID"]}\'");

                if (drTask.Length > 0)
                {
                    predecessorDataSetBuilder.Append($",{drTask[0].TASK_ID}");

                    var linkType = dataRow[LinkType].ToString();

                    switch (linkType)
                    {
                        case LinkTypeZero:
                            predecessorDataSetBuilder.Append("FF");
                            break;
                        case LinkTypeTwo:
                            predecessorDataSetBuilder.Append("SF");
                            break;
                        case LinkTypeThree:
                            predecessorDataSetBuilder.Append("SS");
                            break;
                        default:
                            Trace.WriteLine($"Unexpected value : {linkType}");
                            break;
                    }
                }
            }

            var predecessorDataSet = predecessorDataSetBuilder.ToString();

            if (predecessorDataSet.Length > 1)
            {
                predecessorDataSet = predecessorDataSet.Substring(1);
            }

            listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = predecessorDataSet;
        }

        private string GetFieldData(string fieldType, IReadOnlyList<DataRow> dataRows, string fieldName, bool formatDateTimeValue = false)
        {
            Guard.ArgumentIsNotNull(fieldName, nameof(fieldName));
            Guard.ArgumentIsNotNull(dataRows, nameof(dataRows));
            Guard.ArgumentIsNotNull(fieldType, nameof(fieldType));

            var fieldData = string.Empty;

            if (dataRows.Count >= 1)
            {
                var firstDataRow = dataRows[0];

                switch (fieldType)
                {
                    case DateTimeText:
                        fieldData = firstDataRow[DateValue].ToString();

                        if (formatDateTimeValue)
                        {
                            fieldData =
                                $"{DateTime.Parse(fieldData).Year}-{DateTime.Parse(fieldData).Month}-{DateTime.Parse(fieldData).Day} {DateTime.Parse(fieldData).Hour}:{DateTime.Parse(fieldData).Minute}:{DateTime.Parse(fieldData).Second}";
                        }

                        break;
                    case Duration:
                        fieldData = firstDataRow[DurationValue].ToString();

                        try
                        {
                            fieldData = (float.Parse(fieldData) / 4800.0).ToString();
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                        }

                        break;
                    case NumberText:
                        fieldData = firstDataRow[NumberValue].ToString();
                        break;
                    case Currency:
                        fieldData = firstDataRow[NumberValue].ToString();

                        try
                        {
                            fieldData = (float.Parse(fieldData) / 100).ToString();
                        }
                        catch (Exception exception)
                        {
                            Trace.WriteLine(exception);
                        }

                        break;
                    case BooleanText:
                        fieldData = firstDataRow[FlagValue].ToString();
                        break;
                    case TextId:
                        fieldData = firstDataRow[TextValue].ToString();
                        break;
                    case Choice:
                        fieldData = firstDataRow[CodeValue].ToString();
                        fieldData = getLookupValue(fieldName, fieldData);
                        break;
                    default:
                        Trace.WriteLine($"Unexpected Value :{fieldType}");
                        break;
                }
            }

            return fieldData;
        }
    }
}