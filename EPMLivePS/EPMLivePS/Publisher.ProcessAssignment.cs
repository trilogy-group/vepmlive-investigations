using System;
using System.Data;
using System.Diagnostics;
using EPMLiveCore.Helpers;
using EPMLiveEnterprise.WebSvcProject;
using Microsoft.SharePoint;

namespace EPMLiveEnterprise
{
    internal partial class Publisher
    {
        private void processAssignment(ProjectDataSet.AssignmentRow assignmentRow, ProjectDataSet projectDataSet, SPListItem listItem)
        {
            var taskRow = (ProjectDataSet.TaskRow)projectDataSet.Task.Select($"TASK_UID=\'{assignmentRow.TASK_UID}\'")[0];

            try
            {
                listItem[listItem.Fields.GetFieldByInternalName(TaskHierarchy).Id] = getHierarchy(projectDataSet, taskRow.TASK_PARENT_UID);
                listItem[listItem.Fields.GetFieldByInternalName(IsAssignment).Id] = "1";
                listItem[listItem.Fields.GetFieldByInternalName(Title).Id] = taskRow.TASK_NAME;
                listItem[listItem.Fields.GetFieldByInternalName(Wbs).Id] = taskRow.TASK_WBS;
                listItem[listItem.Fields.GetFieldByInternalName(TaskUid).Id] = $"{taskRow.TASK_UID}.{assignmentRow.ASSN_UID}";
                listItem[listItem.Fields.GetFieldByInternalName(TaskOrder).Id] = taskRow.TASK_ID;

                if (!assignmentRow.IsASSN_NOTESNull())
                {
                    listItem[listItem.Fields.GetFieldByInternalName(Notes).Id] = assignmentRow.ASSN_NOTES;
                }

                listItem[listItem.Fields.GetFieldByInternalName(LastPublished).Id] = DateTime.Now;
                var resourceWssId = getResourceWssId(assignmentRow.RES_UID_OWNER);

                if (resourceWssId != 0)
                {
                    listItem[listItem.Fields.GetFieldByInternalName(AssignedTo).Id] = resourceWssId;
                }

                listItem[Summary] = taskRow.TASK_IS_SUMMARY.ToString();

                ProcessFieldToPublish(assignmentRow, projectDataSet, listItem, taskRow);

                if (!string.IsNullOrWhiteSpace(strTimesheetField))
                {
                    if (listItem.Fields.ContainsField(TimeSheetId))
                    {
                        var dataRows = projectDataSet.TaskCustomFields.Select(
                            $"TASK_UID=\'{taskRow.TASK_UID}\' AND MD_PROP_UID=\'{strTimesheetField}\'");

                        listItem[TimeSheetId] = dataRows.Length > 0
                            ? (object)dataRows[0][FlagValue].ToString()
                            : 0;
                    }
                }

                listItem.Update();
            }
            catch (Exception ex)
            {
                myLog.WriteEntry($"Error processing Assignment ({taskRow.TASK_NAME}): {ex.Message}{ex.StackTrace}", EventLogEntryType.Error, 330);
            }
        }

        private void ProcessFieldToPublish(
            ProjectDataSet.AssignmentRow assignmentRow,
            ProjectDataSet projectDataSet,
            SPListItem listItem,
            ProjectDataSet.TaskRow taskRow)
        {
            Guard.ArgumentIsNotNull(taskRow, nameof(taskRow));
            Guard.ArgumentIsNotNull(listItem, nameof(listItem));
            Guard.ArgumentIsNotNull(projectDataSet, nameof(projectDataSet));
            Guard.ArgumentIsNotNull(assignmentRow, nameof(assignmentRow));

            foreach (string field in arrFieldsToPublish)
            {
                var fieldSplit = field.Split('#');

                if (fieldSplit.Length < 8)
                {
                    throw new InvalidOperationException("Invalid fieldSplit length");
                }

                var fieldName = fieldSplit[0];
                var wssFieldName = fieldSplit[1];
                var assnFieldName = fieldSplit[2];
                var fieldCategory = fieldSplit[3];
                var fieldType = fieldSplit[4];
                var multiplier = fieldSplit[5];
                var rollDown = fieldSplit[7];

                try
                {
                    if (fieldName == TaskResnames)
                    {
                        listItem[listItem.Fields.GetFieldByInternalName(ResourceNames).Id] = getResourceName(assignmentRow.RES_UID, projectDataSet);
                    }
                    else if (fieldName == TaskPctComp)
                    {
                        float pctWorkComplete = assignmentRow.ASSN_PCT_WORK_COMPLETE;
                        pctWorkComplete = pctWorkComplete / (float)100.00;
                        listItem[listItem.Fields.GetFieldByInternalName(PercentComplete).Id] = pctWorkComplete;
                    }
                    else
                    {
                        if (fieldCategory == FieldCategoryThree)
                        {
                            string fieldData = null;
                            var drAssn = projectDataSet.AssignmentCustomFields.Select(
                                $"ASSN_UID=\'{assignmentRow.ASSN_UID}\' AND MD_PROP_UID=\'{assnFieldName}\'");

                            if (drAssn.Length >= 1)
                            {
                                fieldData = GetFieldData(fieldType, drAssn, fieldName);
                            }
                            else if (rollDown == bool.TrueString)
                            {
                                var dataRows = projectDataSet.TaskCustomFields.Select(
                                    $"TASK_UID=\'{taskRow.TASK_UID}\' AND MD_PROP_ID=\'{fieldName}\'");

                                if (dataRows.Length >= 1)
                                {
                                    fieldData = GetFieldData(fieldType, dataRows, fieldName);
                                }
                            }

                            listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                        }
                        else if (fieldCategory == FieldCategoryTwo)
                        {
                            var dataRows = projectDataSet.AssignmentCustomFields.Select(
                                $"ASSN_UID=\'{assignmentRow.ASSN_UID}\' AND MD_PROP_ID=\'{assnFieldName}\'");

                            if (dataRows.Length >= 1)
                            {
                                var fieldData = GetFieldData(fieldType, dataRows, fieldName);
                                listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                            }
                        }
                        else if (fieldCategory == FieldCategoryOne)
                        {
                            ProcessFilterCategoryOne(
                                assignmentRow,
                                projectDataSet,
                                listItem,
                                taskRow,
                                fieldName,
                                wssFieldName,
                                assnFieldName,
                                fieldType,
                                multiplier);
                        }
                    }
                }
                catch (Exception ex)
                {
                    myLog.WriteEntry(
                        $"Error processing Assignment ({taskRow.TASK_NAME}) Field ({fieldName}): {ex.Message}{ex.StackTrace}",
                        EventLogEntryType.Error,
                        330);
                }
            }
        }

        private void ProcessFilterCategoryOne(
            DataRow assignmentRow,
            ProjectDataSet projectDataSet,
            SPListItem listItem,
            ProjectDataSet.TaskRow taskRow,
            string fieldName,
            string wssFieldName,
            string assnFieldName,
            string fieldType,
            string multiplier)
        {
            Guard.ArgumentIsNotNull(multiplier, nameof(multiplier));
            Guard.ArgumentIsNotNull(fieldType, nameof(fieldType));
            Guard.ArgumentIsNotNull(assnFieldName, nameof(assnFieldName));
            Guard.ArgumentIsNotNull(wssFieldName, nameof(wssFieldName));
            Guard.ArgumentIsNotNull(fieldName, nameof(fieldName));
            Guard.ArgumentIsNotNull(taskRow, nameof(taskRow));
            Guard.ArgumentIsNotNull(listItem, nameof(listItem));
            Guard.ArgumentIsNotNull(projectDataSet, nameof(projectDataSet));
            Guard.ArgumentIsNotNull(assignmentRow, nameof(assignmentRow));

            if (fieldName == TaskPredecessors)
            {
                ProcessTaskPredecessors(taskRow, projectDataSet, listItem, wssFieldName);
            }
            else
            {
                string fieldData;

                try
                {
                    fieldData = assignmentRow[assnFieldName].ToString();
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception);
                    fieldData = taskRow[fieldName].ToString();
                }

                if (fieldType == DateTimeText)
                {
                    if (!string.IsNullOrWhiteSpace(fieldData.Trim()))
                    {
                        listItem[listItem.Fields.GetFieldByInternalName(wssFieldName).Id] = fieldData;
                    }
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
        }
    }
}