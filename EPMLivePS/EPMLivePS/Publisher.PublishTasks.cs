using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using EPMLiveCore.Helpers;
using EPMLiveEnterprise.WebSvcProject;
using Microsoft.SharePoint;

namespace EPMLiveEnterprise
{
    internal partial class Publisher
    {
        private void publishTasks(int projectId, int pubType, Guid newTransUid, Guid lastTransUid)
        {
            try
            {
                ProjectDataSet projectDataSet = null;
                SPSecurity.RunWithElevatedPrivileges(() => projectDataSet = pService.ReadProject(projectGuid, DataStoreEnum.PublishedStore));

                double taskDoneCount = 0;
                double taskCount = projectDataSet.Task.Count;
                var taskCenter = mySiteToPublish.Lists[TaskCenter];

                taskCount = PublishTasksPubTypeOne(projectId, pubType, taskCount, projectDataSet, taskCenter, ref taskDoneCount);
                ProcessProjectDataSetTask(projectId, pubType, newTransUid, lastTransUid, projectDataSet, taskCenter, taskDoneCount, taskCount);

                foreach (DictionaryEntry dictionaryEntry in hshCurTasks)
                {
                    var itemByUniqueId = taskCenter.GetItemByUniqueId(new Guid(dictionaryEntry.Value.ToString()));
                    itemByUniqueId.Delete();
                }

                foreach (Guid guid in arrDelNewTasks)
                {
                    var listItem = taskCenter.GetItemByUniqueId(guid);
                    listItem.Delete();
                }
            }
            catch (Exception exception)
            {
                myLog.WriteEntry(
                    $"Error in publishTasks(): {exception.Message}{exception.StackTrace}{exception.InnerException}",
                    EventLogEntryType.Error,
                    315);
            }
        }

        private void ProcessProjectDataSetTask(
            int projectId,
            int pubType,
            Guid newTransUid,
            Guid lastTransUid,
            ProjectDataSet projectDataSet,
            SPList taskCenter,
            double taskDoneCount,
            double taskCount)
        {
            Guard.ArgumentIsNotNull(taskCenter, nameof(taskCenter));
            Guard.ArgumentIsNotNull(projectDataSet, nameof(projectDataSet));

            foreach (ProjectDataSet.TaskRow taskRow in projectDataSet.Task)
            {
                if (taskRow.TASK_ID != 0 && !taskRow.IsTASK_NAMENull() && !taskRow.TASK_IS_SUBPROJ)
                {
                    try
                    {
                        SPListItem listItem;

                        if (hshCurTasks.Contains(taskRow.TASK_UID.ToString().ToUpper()))
                        {
                            var hshCurTask = (Guid)hshCurTasks[taskRow.TASK_UID.ToString().ToUpper()];
                            listItem = taskCenter.GetItemByUniqueId(hshCurTask);

                            hshCurTasks.Remove(taskRow.TASK_UID.ToString().ToUpper());
                        }
                        else
                        {
                            listItem = taskCenter.Items.Add();
                        }

                        listItem[ProjectText] = projectId;

                        PopulateResources(pubType, projectDataSet, listItem, taskRow);
                        PopulateListItem(pubType, newTransUid, lastTransUid, projectDataSet, taskCenter, listItem, taskRow);
                    }
                    catch (Exception exception)
                    {
                        myLog.WriteEntry(
                            $"Error in publishTasks({taskRow.TASK_NAME}) updating list item: {exception.Message}{exception.StackTrace}{exception.InnerException}",
                            EventLogEntryType.Error,
                            315);
                    }
                }

                taskDoneCount++;
                setPubPercent(taskCount, taskDoneCount);
            }
        }

        private void PopulateListItem(
            int pubType,
            Guid newTransUid,
            Guid lastTransUid,
            ProjectDataSet projectDataSet,
            SPList taskCenter,
            SPListItem listItem,
            ProjectDataSet.TaskRow taskRow)
        {
            Guard.ArgumentIsNotNull(taskRow, nameof(taskRow));
            Guard.ArgumentIsNotNull(listItem, nameof(listItem));
            Guard.ArgumentIsNotNull(taskCenter, nameof(taskCenter));
            Guard.ArgumentIsNotNull(projectDataSet, nameof(projectDataSet));

            var canProcess = true;

            try
            {
                if (pubType == PubTypeTwo || pubType == PubTypeThree && lastTransUid != new Guid())
                {
                    if (listItem[TransUid].ToString() != lastTransUid.ToString())
                    {
                        canProcess = false;
                    }
                }
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
            }

            if (canProcess)
            {
                listItem[listItem.Fields.GetFieldByInternalName(TaskHierarchy).Id] = getHierarchy(projectDataSet, taskRow.TASK_PARENT_UID);
                const string AssignmentId = "0";
                listItem[listItem.Fields.GetFieldByInternalName(IsAssignment).Id] = AssignmentId;
                listItem[TransUid] = newTransUid.ToString();
                listItem[taskCenter.Fields.GetFieldByInternalName(Title).Id] = taskRow.TASK_NAME;

                if (!taskRow.IsTASK_WBSNull())
                {
                    listItem[taskCenter.Fields.GetFieldByInternalName(Wbs).Id] = taskRow.TASK_WBS;
                }

                listItem[taskCenter.Fields.GetFieldByInternalName(TaskUid).Id] = taskRow.TASK_UID;
                listItem[taskCenter.Fields.GetFieldByInternalName(TaskOrder).Id] = taskRow.TASK_ID;
                listItem[Summary] = taskRow.TASK_IS_SUMMARY.ToString();

                if (!taskRow.IsTASK_NOTESNull())
                {
                    listItem[taskCenter.Fields.GetFieldByInternalName(Notes).Id] = taskRow.TASK_NOTES;
                }

                listItem[taskCenter.Fields.GetFieldByInternalName(LastPublished).Id] = DateTime.Now;
                processTask(taskRow, projectDataSet, arrFieldsToPublish, listItem, hshTaskCenterFields, taskRow.TASK_UID.ToString(), pubType);
            }
        }

        private void PopulateResources(int pubType, ProjectDataSet projectDataSet, SPListItem listItem, ProjectDataSet.TaskRow taskRow)
        {
            Guard.ArgumentIsNotNull(taskRow, nameof(taskRow));
            Guard.ArgumentIsNotNull(listItem, nameof(listItem));
            Guard.ArgumentIsNotNull(projectDataSet, nameof(projectDataSet));

            const int PrefixLength = 2;
            const int DefaultResourceId = 0;

            if (pubType == PubTypeOne)
            {
                listItem[AssignedTo] = string.Empty;

                if (listItem.ParentList.Fields.ContainsField(ResourceNames))
                {
                    var resourcesBuilder = new StringBuilder();

                    foreach (ProjectDataSet.AssignmentRow assignmentRow in projectDataSet.Assignment.Select($"TASK_UID=\'{taskRow.TASK_UID}\'"))
                    {
                        resourcesBuilder.Append($", {getResourceName(assignmentRow.RES_UID, projectDataSet)}");
                    }

                    var resources = resourcesBuilder.ToString();

                    if (resources.Length > PrefixLength)
                    {
                        resources = resources.Substring(PrefixLength);
                    }

                    listItem[listItem.ParentList.Fields.GetFieldByInternalName(ResourceNames).Id] = resources;
                }
            }

            if (pubType == PubTypeTwo)
            {
                var tempString = string.Empty;
                var resourcesBuilder = new StringBuilder();

                foreach (ProjectDataSet.AssignmentRow assignmentRow in projectDataSet.Assignment.Select($"TASK_UID=\'{taskRow.TASK_UID}\'"))
                {
                    resourcesBuilder.Append($", {getResourceName(assignmentRow.RES_UID, projectDataSet)}");
                    var resId = getResourceWssId(assignmentRow.RES_UID_OWNER);

                    if (resId != DefaultResourceId)
                    {
                        tempString = $"{tempString};#{resId};#{getResourceName(assignmentRow.RES_UID_OWNER, projectDataSet)}";
                    }
                }

                if (tempString.Length > PrefixLength)
                {
                    tempString = tempString.Substring(PrefixLength);
                }

                var resources = resourcesBuilder.ToString();

                if (resources.Length > PrefixLength)
                {
                    resources = resources.Substring(PrefixLength);
                }

                listItem[AssignedTo] = tempString;

                if (listItem.ParentList.Fields.ContainsField(ResourceNames))
                {
                    listItem[listItem.ParentList.Fields.GetFieldByInternalName(ResourceNames).Id] = resources;
                }
            }

            if (pubType == PubTypeThree)
            {
                var resourceIdForTask = workspaceSynch.getResourceIdForTask(taskRow.TASK_UID, projectDataSet);

                listItem[AssignedTo] = resourceIdForTask != DefaultResourceId
                    ? (object)resourceIdForTask
                    : string.Empty;
            }
        }

        private double PublishTasksPubTypeOne(
            int projectId,
            int pubType,
            double taskCount,
            ProjectDataSet projectDataSet,
            SPList taskCenter,
            ref double taskDoneCount)
        {
            Guard.ArgumentIsNotNull(taskCenter, nameof(taskCenter));
            Guard.ArgumentIsNotNull(projectDataSet, nameof(projectDataSet));

            const string AssignmentId = "1";

            if (pubType == PubTypeOne)
            {
                taskCount += projectDataSet.Assignment.Count;

                foreach (ProjectDataSet.AssignmentRow assignmentRow in projectDataSet.Assignment)
                {
                    var currentTaskKey = $"{assignmentRow.TASK_UID.ToString().ToUpper()}.{assignmentRow.ASSN_UID.ToString().ToUpper()}";

                    if (!IsAssignedTaskSaved(assignmentRow.ASSN_UID))
                    {
                        SPListItem listItem;

                        if (hshCurTasks.Contains(currentTaskKey))
                        {
                            var hshCurTask = (Guid)hshCurTasks[currentTaskKey];
                            listItem = taskCenter.GetItemByUniqueId(hshCurTask);

                            hshCurTasks.Remove(currentTaskKey);
                        }
                        else
                        {
                            listItem = taskCenter.Items.Add();
                        }

                        listItem[listItem.Fields.GetFieldByInternalName(IsAssignment).Id] = AssignmentId;
                        listItem[ProjectText] = projectId;

                        processAssignment(assignmentRow, projectDataSet, listItem);
                    }
                    else
                    {
                        hshCurTasks.Remove(currentTaskKey);
                    }

                    taskDoneCount++;
                    setPubPercent(taskCount, taskDoneCount);
                }
            }

            return taskCount;
        }
    }
}