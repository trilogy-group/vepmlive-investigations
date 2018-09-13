using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public partial class ListDisplaySettingIterator
    {
        private void AddEntityPickersToLookups()
        {
            if (mode == SPControlMode.New || mode == SPControlMode.Edit)
            {
                // this represents a comma separated list of lookup field internal names to modify
                EnhancedLookupConfigValuesHelper valueHelper = null;
                var gSettings = new GridGanttSettings(list);

                try
                {
                    var rawValue = gSettings.Lookups;
                    valueHelper = new EnhancedLookupConfigValuesHelper(rawValue);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }

                if (valueHelper == null)
                {
                    return;
                }

                var formFields = this.GetFormFieldByType(typeof(SPFieldLookup));
                foreach (var formField in formFields)
                {
                    var isEnhanced = valueHelper.ContainsKey(formField.Field.InternalName);
                    var isParent = valueHelper.IsParentField(formField.Field.InternalName);

                    if (!isEnhanced && !isParent)
                    {
                        continue;
                    }

                    var lookupData = valueHelper.GetFieldData(formField.Field.InternalName);

                    if (isParent && !isEnhanced)
                    {
                        InsertModifiedSPControl1(formField, lookupData);
                    }
                    else if (isParent && isEnhanced)
                    {
                        if (lookupData.Type == GenericType)
                        {
                            InsertEPMLiveGenericPickerControl(formField, lookupData, string.Empty);
                        }
                        else if (lookupData.Type == ModifiedType)
                        {
                            InsertModifiedSPControl1(formField, lookupData);
                        }
                    }
                    else if (!isParent && isEnhanced)
                    {
                        if (lookupData.Type == GenericType)
                        {
                            InsertEPMLiveGenericPickerControl(formField, lookupData, "SPFieldUser");
                        }
                        else if (lookupData.Type == ModifiedType)
                        {
                            InsertModifiedSPControl2(formField, lookupData);
                        }
                    }
                }
            }
        }

        private void InsertEPMLiveGenericPickerControl(FormField formField, LookupConfigData lookupData, string fieldType)
        {
            if (formField == null)
            {
                throw new ArgumentNullException(nameof(formField));
            }
            picker = new GenericEntityEditor();
            var fieldLookup = GetFieldLookup(formField);
            picker.MultiSelect = fieldLookup.AllowMultipleValues;

            var customValue = GetCustomValue(formField, lookupData, fieldLookup, fieldType);

            SPFieldLookupValueCollection lookupValCol = null;

            if (mode == SPControlMode.New)
            {
                lookupValCol = GetQueryStringLookupVal(formField);
            }
            else
            {
                try
                {
                    lookupValCol = new SPFieldLookupValueCollection(ListItem[fieldLookup.Id].ToString());
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }

            if (lookupValCol?.Count > 0)
            {
                var alItems = new ArrayList();
                foreach (var field in lookupValCol)
                {
                    var entity = new PickerEntity
                    {
                        Key = field.LookupId.ToString(),
                        DisplayText = field.LookupValue,
                        IsResolved = true
                    };
                    alItems.Add(entity);
                }
                picker.UpdateEntities(alItems);
            }

            picker.CustomProperty = customValue;
            formField.Controls.Add(picker);
        }

        private string GetCustomValue(FormField formField, LookupConfigData lookupData, SPFieldLookup fieldLookup, string fieldType)
        {
            if (lookupData == null)
            {
                throw new ArgumentNullException(nameof(lookupData));
            }
            if (fieldLookup == null)
            {
                throw new ArgumentNullException(nameof(fieldLookup));
            }
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<Data>")
                .AppendFormat("<Param key=\"SPFieldType\">{0}</Param>", fieldType)
                .AppendFormat("<Param key=\"ParentWebID\">{0}</Param>", fieldLookup.ParentList.ParentWeb.ID)
                .AppendFormat("<Param key=\"LookupWebID\">{0}</Param>", fieldLookup.LookupWebId)
                .AppendFormat("<Param key=\"LookupListID\">{0}</Param>", fieldLookup.LookupList)
                .AppendFormat("<Param key=\"LookupFieldInternalName\">{0}</Param>", fieldLookup.LookupField)
                .AppendFormat("<Param key=\"LookupFieldID\">{0}</Param>", fieldLookup.Id)
                .AppendFormat("<Param key=\"IsMultiSelect\">{0}</Param>", fieldLookup.AllowMultipleValues)
                .AppendFormat("<Param key=\"ListID\">{0}</Param>", ListId)
                .AppendFormat("<Param key=\"ItemID\">{0}</Param>", ItemId)
                .Append(GenerateControlDataForLookupField(formField, fieldLookup.AllowMultipleValues))
                .AppendFormat("<Param key=\"Field\">{0}</Param>", lookupData.Field)
                .AppendFormat("<Param key=\"ControlType\">{0}</Param>", lookupData.Type)
                .AppendFormat("<Param key=\"Parent\">{0}</Param>", lookupData.Parent)
                .AppendFormat("<Param key=\"ParentListField\">{0}</Param>", lookupData.ParentListField)
                .AppendFormat("<Param key=\"Required\">{0}</Param>", fieldLookup.Required)
                .Append("</Data>");

            return stringBuilder.ToString();
        }

        private void InsertModifiedSPControl1(FormField formField, LookupConfigData lookupData)
        {
            if (formField == null)
            {
                throw new ArgumentNullException(nameof(formField));
            }

            var fieldLookup = GetFieldLookup(formField);
            if (!fieldLookup.AllowMultipleValues)
            {
                var renderControl = new CascadingLookupRenderControl
                {
                    LookupData = lookupData,
                    LookupField = fieldLookup,
                    CustomProperty = GetCustomValue(formField, fieldLookup)
                };

                formField.Controls.Add(renderControl);
            }
        }

        private void InsertModifiedSPControl2(FormField formField, LookupConfigData lookupData)
        {
            if (formField == null)
            {
                throw new ArgumentNullException(nameof(formField));
            }

            var fieldLookup = GetFieldLookup(formField);
            if (!fieldLookup.AllowMultipleValues)
            {
                var renderControl = new CascadingLookupRenderControl
                {
                    LookupData = lookupData,
                    LookupField = fieldLookup,
                    CustomProperty = GetCustomValue(formField, fieldLookup)
                };

                formField.Controls.Add(renderControl);
            }
            else
            {
                var renderControl = new CascadingMultiLookupRenderControl
                {
                    LookupData = lookupData,
                    LookupField = fieldLookup,
                    CustomProperty = GetCustomValue(formField, fieldLookup)
                };

                formField.Controls.Add(renderControl);
            }
        }

        private string GetCustomValue(FormField formField, SPFieldLookup fieldLookup)
        {
            if (fieldLookup == null)
            {
                throw new ArgumentNullException(nameof(fieldLookup));
            }

            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<Data>")
                .Append("<Param key=\"SPFieldType\">SPFieldUser</Param>")
                .AppendFormat("<Param key=\"ParentWebID\">{0}</Param>", fieldLookup.ParentList.ParentWeb.ID)
                .AppendFormat("<Param key=\"LookupWebID\">{0}</Param>", fieldLookup.LookupWebId)
                .AppendFormat("<Param key=\"LookupListID\">{0}</Param>", fieldLookup.LookupList)
                .AppendFormat("<Param key=\"LookupFieldInternalName\">{0}</Param>", fieldLookup.LookupField)
                .AppendFormat("<Param key=\"LookupFieldID\">{0}</Param>", fieldLookup.Id)
                .AppendFormat("<Param key=\"IsMultiSelect\">{0}</Param>", fieldLookup.AllowMultipleValues)
                .AppendFormat("<Param key=\"ListID\">{0}</Param>", ListId)
                .AppendFormat("<Param key=\"ItemID\">{0}</Param>", ItemId)
                .AppendFormat("<Param key=\"Required\">{0}</Param>", fieldLookup.Required)
                .Append(GenerateControlDataForLookupField(formField, fieldLookup.AllowMultipleValues))
                .Append("</Data>");

            return stringBuilder.ToString();
        }

        private static SPFieldLookup GetFieldLookup(FormField formField)
        {
            if (formField == null)
            {
                throw new ArgumentNullException(nameof(formField));
            }

            return formField.Field as SPFieldLookup;
        }

        private string GenerateControlDataForLookupField(FormField sourceFld, bool isMulti)
        {
            StringBuilder sbResult = new StringBuilder();
            // in the case of multi select
            // we need the ids of four controls
            // to post back data
            if (isMulti)
            {
                // need control id for the addbutton, removeButton, selectCandidate, selectResult controls
                sbResult.Append("<Param key=\"SelectCandidateID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_SelectCandidate") + "</Param>" +
                                "<Param key=\"AddButtonID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_AddButton") + "</Param>" +
                                "<Param key=\"RemoveButtonID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_RemoveButton") + "</Param>" +
                                "<Param key=\"SelectResultID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_SelectResult") + "</Param>");

            }
            // in the case of a single select
            // we just need the input or the dropdown
            // controls id to post back data
            else
            {
                sbResult.Append("<Param key=\"SourceDropDownID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_$" + sourceFld.Field.FieldRenderingControl.GetType().Name) + "</Param>");
                sbResult.Append("<Param key=\"SourceControlID\">" + (sourceFld.Field.InternalName + "_" + sourceFld.Field.Id.ToString() + "_$" + sourceFld.Field.FieldRenderingControl.GetType().Name) + "</Param>");
            }

            return sbResult.ToString();
        }

        private string GenerateControlDataForLookupField(SPField fld, bool isMulti)
        {
            StringBuilder sbResult = new StringBuilder();
            // in the case of multi select
            // we need the ids of four controls
            // to post back data
            if (isMulti)
            {
                // need control id for the addbutton, removeButton, selectCandidate, selectResult controls
                sbResult.Append("<Param key=\"SelectCandidateID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_SelectCandidate") + "</Param>" +
                                "<Param key=\"AddButtonID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_AddButton") + "</Param>" +
                                "<Param key=\"RemoveButtonID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_RemoveButton") + "</Param>" +
                                "<Param key=\"SelectResultID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_SelectResult") + "</Param>");

            }
            // in the case of a single select
            // we just need the input or the dropdown
            // controls id to post back data
            else
            {
                sbResult.Append("<Param key=\"SourceDropDownID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_$" + fld.FieldRenderingControl.GetType().Name) + "</Param>");
                sbResult.Append("<Param key=\"SourceControlID\">" + (fld.InternalName + "_" + fld.Id.ToString() + "_$" + fld.FieldRenderingControl.GetType().Name) + "</Param>");
            }

            return sbResult.ToString();
        }
    }
}