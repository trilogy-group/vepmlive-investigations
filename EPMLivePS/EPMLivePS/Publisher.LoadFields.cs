using System;
using System.Data.SqlClient;
using System.Diagnostics;
using EPMLiveEnterprise.WebSvcCustomFields;
using Microsoft.SharePoint;

namespace EPMLiveEnterprise
{
    internal partial class Publisher
    {
        private void loadFields()
        {
            try
            {
                try
                {
                    SPSecurity.RunWithElevatedPrivileges(() => cfDs = pCf.ReadCustomFieldsByEntity(taskEntity));
                }
                catch (Exception exception)
                {
                    myLog.WriteEntry(
                        $"Error in publishProject() Reading Custom Fields: {exception.Message}{exception.StackTrace}",
                        EventLogEntryType.Error,
                        320);
                }

                ProcessTaskCenterFields();
                ProcessProjectCenterFields();
            }
            catch (Exception exception)
            {
                myLog.WriteEntry($"Error reading fields\r\n\r\n{exception.Message}{exception.StackTrace}", EventLogEntryType.Error, 334);
            }
        }

        private void ProcessProjectCenterFields()
        {
            var projectCenter = mySiteToPublish.Lists["Project Center"];

            foreach (SPField spField in projectCenter.Fields)
            {
                hshProjectCenterFields.Add(spField.InternalName, spField.Id);

                if (isValidField(spField))
                {
                    var fieldInternalName = spField.InternalName;

                    if (fieldInternalName == "Start")
                    {
                        fieldInternalName = "StartDate";
                    }

                    if (fieldInternalName == "Finish")
                    {
                        fieldInternalName = "DueDate";
                    }

                    using (var sqlCommand = new SqlCommand(
                        "SELECT fieldname,wssfieldname,coalesce(assnfieldname,'') as assnfieldname,fieldcategory,fieldtype,multiplier FROM CUSTOMFIELDS where wssfieldname like @wssfieldname",
                        cn))
                    {
                        sqlCommand.Parameters.AddWithValue("@wssfieldname", fieldInternalName);

                        using (var dataReader = sqlCommand.ExecuteReader())
                        {
                            if (dataReader.Read())
                            {
                                arrPJFieldsToPublish.Add(
                                    $"{dataReader.GetString(0)}#{spField.InternalName}#{dataReader.GetString(2)}#{dataReader.GetInt32(3)}#{dataReader.GetString(4)}#{dataReader.GetInt32(5)}#{spField.Id}");
                            }
                            else
                            {
                                if (spField.InternalName.Length > 3)
                                {
                                    var fieldName = spField.InternalName.Substring(3);
                                    var temp = 0;

                                    if (int.TryParse(fieldName, out temp))
                                    {
                                        var fieldsRows = (CustomFieldDataSet.CustomFieldsRow[])cfDs.CustomFields.Select($"MD_PROP_ID={fieldName}");

                                        if (fieldsRows.Length > 0)
                                        {
                                            arrPJFieldsToPublish.Add(
                                                fieldsRows[0].IsMD_LOOKUP_TABLE_UIDNull()
                                                    ? $"{fieldsRows[0].MD_PROP_ID}#{spField.InternalName}#{fieldsRows[0].MD_PROP_UID_SECONDARY}#3#{getType(((Microsoft.Office.Project.Server.Library.PropertyType)fieldsRows[0].MD_PROP_TYPE_ENUM).ToString())}#1#{spField.Id}"
                                                    : $"{fieldsRows[0].MD_PROP_ID}#{spField.InternalName}#{fieldsRows[0].MD_PROP_UID_SECONDARY}#3#CHOICE#1#{spField.Id}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ProcessTaskCenterFields()
        {
            var taskCenter = mySiteToPublish.Lists["Task Center"];

            foreach (SPField spField in taskCenter.Fields)
            {
                hshTaskCenterFields.Add(spField.InternalName, spField.Id);

                if (isValidField(spField))
                {
                    using (var sqlCommand = new SqlCommand(
                        "SELECT fieldname,wssfieldname,coalesce(assnfieldname,'') as assnfieldname,fieldcategory,fieldtype,multiplier FROM CUSTOMFIELDS where wssfieldname like @wssfieldname",
                        cn))
                    {
                        sqlCommand.Parameters.AddWithValue("@wssfieldname", spField.InternalName);

                        using (var drField = sqlCommand.ExecuteReader())
                        {
                            var rollDown = "false";

                            if (drField.Read())
                            {
                                try
                                {
                                    if (drField.GetInt32(3) == 3)
                                    {
                                        var dataRows = (CustomFieldDataSet.CustomFieldsRow[])cfDs.CustomFields.Select(
                                            $"MD_PROP_ID={drField.GetString(0)}");

                                        if (dataRows.Length > 0)
                                        {
                                            rollDown = dataRows[0].MD_PROP_ROLLDOWN_TO_ASSN.ToString().ToLower();
                                        }
                                    }
                                }
                                catch (Exception exception)
                                {
                                    Trace.WriteLine(exception);
                                }

                                arrFieldsToPublish.Add(
                                    $"{drField.GetString(0)}#{spField.InternalName}#{drField.GetString(2)}#{drField.GetInt32(3)}#{drField.GetString(4)}#{drField.GetInt32(5)}#{spField.Id}#{rollDown}");
                            }
                            else
                            {
                                if (spField.InternalName.Length > 3)
                                {
                                    var fieldName = spField.InternalName.Substring(3);
                                    var temp = 0;

                                    if (int.TryParse(fieldName, out temp))
                                    {
                                        var fieldsRows = (CustomFieldDataSet.CustomFieldsRow[])cfDs.CustomFields.Select($"MD_PROP_ID={fieldName}");

                                        if (fieldsRows.Length > 0)
                                        {
                                            arrFieldsToPublish.Add(
                                                fieldsRows[0].IsMD_LOOKUP_TABLE_UIDNull()
                                                    ? $"{fieldsRows[0].MD_PROP_ID}#{spField.InternalName}#{fieldsRows[0].MD_PROP_UID_SECONDARY}#3#{getType(((Microsoft.Office.Project.Server.Library.PropertyType)fieldsRows[0].MD_PROP_TYPE_ENUM).ToString())}#1#{spField.Id}#{rollDown}"
                                                    : $"{fieldsRows[0].MD_PROP_ID}#{spField.InternalName}#{fieldsRows[0].MD_PROP_UID_SECONDARY}#3#CHOICE#1#{spField.Id}#{rollDown}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}