using System;
using System.Diagnostics;
using EPMLiveEnterprise.WebSvcCustomFields;
using EPMLiveEnterprise.WebSvcLookupTables;
using EPMLiveEnterprise.WebSvcProject;
using Microsoft.SharePoint;

namespace EPMLiveEnterprise
{
    internal partial class Publisher
    {
        private string getHierarchy(ProjectDataSet projectDataSet, Guid taskuid)
        {
            if (hshTaskHierarchy.Contains(taskuid))
            {
                return hshTaskHierarchy[taskuid].ToString();
            }

            var taskRow = (ProjectDataSet.TaskRow)projectDataSet.Task.Select($"TASK_UID=\'{taskuid}\'")[0];

            var hierarchy = $"{getHierarchy(projectDataSet, taskRow.TASK_PARENT_UID)} > {taskRow.TASK_NAME}";

            if (hierarchy.Length > 3 && hierarchy[1] == '>')
            {
                hierarchy = hierarchy.Substring(3);
            }

            hshTaskHierarchy.Add(taskRow.TASK_UID, hierarchy);

            return hierarchy;
        }

        private int getResourceWssId(Guid resGuid)
        {
            var dataRows = rDs.Resources.Select($"RES_UID=\'{resGuid}\'");

            if (dataRows.Length > 0)
            {
                var dataRow = dataRows[0];

                if (dataRow[ResourceIsWindowsUser].ToString() == bool.TrueString)
                {
                    var username = dataRow[WresAccount].ToString();

                    try
                    {
                        return mySiteToPublish.AllUsers[username].ID;
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                        return 0;
                    }
                }
            }

            return 0;
        }

        /// <summary>
        /// this method used to return resource Id.
        /// </summary>
        /// <param name="resGuid"></param>
        /// <returns></returns>
        private long getResourceResId(Guid resGuid)
        {
            var drRes = rDs.Resources.Select($"RES_UID=\'{resGuid}\'");

            if (drRes.Length > 0)
            {
                var dataRow = drRes[0];

                if (dataRow[ResourceIsWindowsUser].ToString() == bool.TrueString)
                {
                    var resId = Convert.ToInt64(dataRow[ResourceId]);
                    return resId;
                }
            }

            return 0;
        }

        private string getResourceName(Guid resGuid, ProjectDataSet projectDataSet)
        {
            var drRes = rDs.Resources.Select($"RES_UID=\'{resGuid}\'");

            if (drRes.Length > 0)
            {
                var dataRow = drRes[0];

                if (dataRow[ResourceIsWindowsUser].ToString() == bool.TrueString)
                {
                    var username = dataRow[WresAccount].ToString();

                    try
                    {
                        return mySiteToPublish.AllUsers[username].Name;
                    }
                    catch (Exception exception)
                    {
                        Trace.WriteLine(exception);
                        return string.Empty;
                    }
                }

                return Convert.ToString(dataRow[ResourceName]);
            }

            var dataRows = projectDataSet.ProjectResource.Select($"RES_UID=\'{resGuid}\'");

            return dataRows.Length > 0
                ? dataRows[0][ResourceName].ToString()
                : string.Empty;
        }

        private string getResourceUsername(Guid resGuid)
        {
            var drRes = rDs.Resources.Select($"RES_UID=\'{resGuid}\'");

            if (drRes.Length > 0)
            {
                var dataRow = drRes[0];

                if (dataRow[ResourceIsWindowsUser].ToString() == bool.TrueString)
                {
                    return dataRow[WresAccount].ToString();
                }
            }

            return string.Empty;
        }

        private string getLookupValue(string fieldName, string ltStructUid)
        {
            try
            {
                var customFieldsRows = (CustomFieldDataSet.CustomFieldsRow[])dsFields.CustomFields.Select($"MD_PROP_ID={fieldName}");

                if (customFieldsRows.Length <= 0)
                {
                    SPSecurity.RunWithElevatedPrivileges(
                        () => dsFields = pCf.ReadCustomFieldsByEntity(
                            new Guid(Microsoft.Office.Project.Server.Library.EntityCollection.Entities.ProjectEntity.UniqueId)));
                    customFieldsRows = (CustomFieldDataSet.CustomFieldsRow[])dsFields.CustomFields.Select($"MD_PROP_ID={fieldName}");
                }

                var tableTreesRows = (LookupTableDataSet.LookupTableTreesRow[])dsLt.LookupTableTrees.Select($"LT_STRUCT_UID = \'{ltStructUid}\'");

                switch ((Microsoft.Office.Project.Server.Library.PSDataType)customFieldsRows[0].MD_PROP_TYPE_ENUM)
                {
                    case Microsoft.Office.Project.Server.Library.PSDataType.STRING:
                        return tableTreesRows[0].LT_VALUE_TEXT;
                    case Microsoft.Office.Project.Server.Library.PSDataType.NUMBER:
                        return tableTreesRows[0].LT_VALUE_NUM.ToString();
                    default:
                        return string.Empty;
                }
            }
            catch (Exception exception)
            {
                myLog.WriteEntry(
                    $"Error Reading Lookup Table for field ({fieldName}): {exception.Message}{exception.StackTrace}",
                    EventLogEntryType.Error,
                    330);
            }

            return string.Empty;
        }

        private string getType(string type)
        {
            var xml = string.Empty;

            switch (type)
            {
                case "NumberEng96":
                    xml = "NUMBER";
                    break;
                case "CostEng96":
                    xml = "CURRENCY";
                    break;
                case "StringEng96":
                    xml = "TEXT";
                    break;
                case "YesNoEng96":
                    xml = "BOOLEAN";
                    break;
                case "DurationEng96":
                    xml = "DURATION";
                    break;
                case "StartDateEng96":
                    xml = "DATETIME";
                    break;
                case "CHOICE":
                    xml = "CHOICE";
                    break;
                default:
                    Trace.WriteLine("Unexpected value : type");
                    break;
            }

            return xml;
        }
    }
}