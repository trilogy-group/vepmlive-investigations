using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class EditableFieldDisplay
    {
        private const string MeKey = "[Me]";
        private const string TodayKey = "[Today]";

        #region Methods (12)

        // Public Methods (5) 

        public static bool canEdit(SPField field, Dictionary<string, Dictionary<string, string>> fieldProperties, SPListItem li)
        {
            try
            {
                string displaySettings = fieldProperties[field.InternalName]["Editable"];
                string where = displaySettings.Split(";".ToCharArray())[1];
                string conditionField = "";
                string condition = "";
                string group = "";
                string valueCondition = "";
                if(where.Equals("[Me]"))
                {
                    condition = displaySettings.Split(";".ToCharArray())[2];
                    group = displaySettings.Split(";".ToCharArray())[3];
                }
                else // [Field]
                {
                    conditionField = displaySettings.Split(";".ToCharArray())[2];
                    condition = displaySettings.Split(";".ToCharArray())[3];
                    valueCondition = displaySettings.Split(";".ToCharArray())[4];
                }
                return RenderField(field, where, conditionField, condition, group, valueCondition, li);
            }
            catch
            {
                if(field.ShowInEditForm.HasValue)
                    return field.ShowInEditForm.Value;
                return true;
            }
        }

        public static bool isEditable(SPListItem li, SPField field, Dictionary<string, Dictionary<string, string>> fieldProperties)
        {
            if(li.Fields.GetFieldByInternalName(field.InternalName).ReadOnlyField)
                return false;
            if(li.Fields.GetFieldByInternalName(field.InternalName).ShowInEditForm == null)
                return isEditableField(li, li.Fields.GetFieldByInternalName(field.InternalName), fieldProperties, "Edit");
            if(!li.Fields.GetFieldByInternalName(field.InternalName).ShowInEditForm.Value)
                return false;
            return isEditableField(li, li.Fields.GetFieldByInternalName(field.InternalName), fieldProperties, "Edit");
        }

        public static bool isEditable(SPList list, SPField field, Dictionary<string, Dictionary<string, string>> fieldProperties)
        {
            if(list.Fields.GetFieldByInternalName(field.InternalName).ReadOnlyField)
                return false;

            if(list.Fields.GetFieldByInternalName(field.InternalName).ShowInEditForm == null)
                return isEditableField(list.Fields.GetFieldByInternalName(field.InternalName), fieldProperties, "Edit");

            if(!list.Fields.GetFieldByInternalName(field.InternalName).ShowInEditForm.Value)
                return false;

            return isEditableField(list.Fields.GetFieldByInternalName(field.InternalName), fieldProperties, "Edit");
        }

        public static bool RenderField(SPField field, string where, string conditionField, string condition, string group, string valueCondition, SPListItem li)
        {
            bool result = false;

            if(where.Equals("[Me]"))
                result = WhereUser(condition, group);
            else // [Field]
            {
                SPField oConditionField = null;
                if(conditionField.Length > 0)
                {
                    oConditionField = li.Fields.GetFieldByInternalName(conditionField);
                }
                result = WhereField(oConditionField, where, condition, valueCondition, li);
            }
            return result;
        }

        public static bool IsDisplayField(SPField field, Dictionary<string, Dictionary<string, string>> fieldProperties, string key)
        {
            try
            {
                Dictionary<string, string> fieldValue;               
                string displaySettings = string.Empty;
                if (fieldProperties.TryGetValue(Convert.ToString(field.InternalName), out fieldValue) == true)
                {
                    displaySettings = fieldProperties[field.InternalName][key];

                    if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("always"))
                        return true;

                    if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("never"))
                        return false;

                    if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
                    {
                        string where = displaySettings.Split(";".ToCharArray())[1];
                        string condition = "";
                        string group = "";
                        bool result = false;
                        if (where.Equals("[Me]"))
                        {
                            condition = displaySettings.Split(";".ToCharArray())[2];
                            group = displaySettings.Split(";".ToCharArray())[3];
                            result = WhereUser(condition, group);
                            return result;
                        }
                        else
                        {
                            //For Field
                            return result;
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            catch { }
            return false;
        }

        // Private Methods (7) 

        private static bool isEditableField(SPField field, Dictionary<string, Dictionary<string, string>> fieldProperties, string key)
        {
            try
            {
                if (!fieldProperties[field.InternalName].ContainsKey(key))
                    return true;

                string displaySettings = string.Empty;

                displaySettings = fieldProperties[field.InternalName][key];
                if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
                    return true;

                displaySettings = fieldProperties[field.InternalName]["Editable"];
                if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("never"))
                    return false;

                if (displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
                    return true;
            }
            catch
            {
            }
            return true;
        }

        private static string getFieldSchemaAttribValue(string sStringToSearch, string sAttribName)
        {
            string sAttribVal = "";
            try
            {
                int iFindPos = sStringToSearch.ToUpper().IndexOf(sAttribName.ToUpper() + "=");
                int iSubStrStart = iFindPos + sAttribName.Length + 2;
                int iSubStrEnd = sStringToSearch.IndexOf("\"", iSubStrStart);
                sAttribVal = sStringToSearch.Substring(iSubStrStart, iSubStrEnd - iSubStrStart);
            }
            catch
            {
            }
            return sAttribVal;
        }

        private static bool isDate(string sDate)
        {
            DateTime dt;
            bool bIsDate = true;

            try
            {
                dt = DateTime.Parse(sDate);
            }
            catch
            {
                bIsDate = false;
            }

            return bIsDate;
        }

        private static bool isEditableField(SPListItem li, SPField field, Dictionary<string, Dictionary<string, string>> fieldProperties, string key)
        {
            try
            {
                if(!fieldProperties[field.InternalName].ContainsKey(key))
                    return true;

                string displaySettings = string.Empty;

                displaySettings = fieldProperties[field.InternalName][key];
                if(displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
                {
                    string where = displaySettings.Split(";".ToCharArray())[1];
                    string conditionField = "";
                    string condition = "";
                    string group = "";
                    string valueCondition = "";
                    if(where.Equals("[Me]"))
                    {
                        condition = displaySettings.Split(";".ToCharArray())[2];
                        group = displaySettings.Split(";".ToCharArray())[3];
                    }
                    else // [Field]
                    {
                        conditionField = displaySettings.Split(";".ToCharArray())[2];
                        condition = displaySettings.Split(";".ToCharArray())[3];
                        valueCondition = displaySettings.Split(";".ToCharArray())[4];
                    }
                    bool e = RenderField(field, where, conditionField, condition, group, valueCondition, li);
                    if(!e)
                        return false;
                }

                displaySettings = fieldProperties[field.InternalName]["Editable"];
                if(displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("never"))
                    return false;
                if(displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
                {
                    string where = displaySettings.Split(";".ToCharArray())[1];
                    string conditionField = "";
                    string condition = "";
                    string group = "";
                    string valueCondition = "";
                    if(where.Equals("[Me]"))
                    {
                        condition = displaySettings.Split(";".ToCharArray())[2];
                        group = displaySettings.Split(";".ToCharArray())[3];
                    }
                    else // [Field]
                    {
                        conditionField = displaySettings.Split(";".ToCharArray())[2];
                        condition = displaySettings.Split(";".ToCharArray())[3];
                        valueCondition = displaySettings.Split(";".ToCharArray())[4];
                    }
                    return RenderField(field, where, conditionField, condition, group, valueCondition, li);
                }
            }
            catch
            {
            }
            return true;
        }

        private static bool IsNumeric(string value)
        {
            if(value == string.Empty) return false;
            var regexp = new Regex("^[0-9]*$");
            return regexp.Match(value).Success;
        }

        private static bool WhereField(SPField oConditionField, string where, string condition, string value, SPListItem li)
        {
            var evalResult = false;
            try
            {
                var dateFormat = GetDateFormat(oConditionField, ref value);
                var fieldValue = GetFieldValue(oConditionField, li);
                evalResult = EvaluateResult(oConditionField, condition, value, evalResult, fieldValue, dateFormat);
            }
            catch(Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            return evalResult;
        }

        private static string GetDateFormat(SPField oConditionField, ref string formatValue)
        {
            var dateFormat = string.Empty;

            if (formatValue == MeKey)
            {
                formatValue = SPContext.Current.Web.CurrentUser.Name;
            }
            if (formatValue == TodayKey)
            {
                var now = DateTime.Now;
                formatValue = now.ToString();
            }
            if (oConditionField.Type == SPFieldType.Boolean)
            {
                formatValue = string.Equals(formatValue, "YES", StringComparison.OrdinalIgnoreCase) || string.Equals(formatValue, "TRUE", StringComparison.OrdinalIgnoreCase)
                    ? bool.TrueString
                    : bool.FalseString;
            }
            if (isDate(formatValue))
            {
                dateFormat = getFieldSchemaAttribValue(oConditionField.SchemaXml, "Format");
            }
            return dateFormat;
        }

        private static string GetFieldValue(SPField oConditionField, SPListItem li)
        {
            var fieldValue = string.Empty;
            if (oConditionField != null)
            {
                fieldValue = li[oConditionField.Id].ToString();
                if (oConditionField.Type != SPFieldType.DateTime
                    && oConditionField.Type != SPFieldType.Boolean
                    && oConditionField.Type != SPFieldType.Number
                    && oConditionField.Type != SPFieldType.Currency)
                {
                    fieldValue = oConditionField.GetFieldValueAsText(fieldValue);
                }
            }
            return fieldValue;
        }

        private static bool EvaluateResult(SPField oConditionField, string condition, string value, bool evalResult, string fieldValue, string dateFormat)
        {
            switch (condition)
            {
                case "IsEqualTo":
                    evalResult = HandleEqualToCase(oConditionField, value, fieldValue, dateFormat);
                    break;
                case "IsNotEqualTo":
                    evalResult = HandleNotEqualToCase(oConditionField, value, fieldValue, dateFormat);
                    break;
                case "IsGreaterThan":
                    evalResult = HandleGreaterThanCase(oConditionField, value, fieldValue, dateFormat);
                    break;
                case "IsLessThan":
                    evalResult = HandleLessThanCase(oConditionField, value, fieldValue, dateFormat);
                    break;
                case "IsGreaterThanOrEqual":
                    evalResult = HandleGreaterThanOrEqualCase(oConditionField, value, fieldValue, dateFormat);
                    break;
                case "IsLessThanOrEqual":
                    evalResult = HandleLEssThanOrEqualCase(oConditionField, value, fieldValue, dateFormat);
                    break;
                case "Contains":
                    evalResult = fieldValue.Contains(value);
                    break;
                default:
                    Trace.TraceError("Unexpected Value for {0}: {1}", nameof(condition), condition);
                    break;
            }
            return evalResult;
        }

        private static bool HandleEqualToCase(SPField oConditionField, string value, string fieldValue, string dateFormat)
        {
            bool evalResult;
            bool booleanFieldValue;
            bool booleanValue;
            DateTime dateTimeFieldValue;
            DateTime dateTimeValue;
            double doubleFieldValue = 0;
            double doubleValue = 0;

            if (DateTime.TryParse(fieldValue, out dateTimeFieldValue) && DateTime.TryParse(value, out dateTimeValue))
            {
                if (dateFormat == "DateTime")
                {
                    evalResult = dateTimeFieldValue == dateTimeValue;
                }
                else
                {
                    evalResult = DateTime.Parse(dateTimeFieldValue.ToShortDateString()) == DateTime.Parse(dateTimeValue.ToShortDateString());
                }
            }
            else if (oConditionField.Type == SPFieldType.Number
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evalResult = doubleFieldValue.Equals(doubleValue);
            }
            else if (oConditionField.Type == SPFieldType.Currency
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evalResult = doubleFieldValue.Equals(doubleValue);
            }
            else if (oConditionField.Type == SPFieldType.Boolean
                && bool.TryParse(fieldValue, out booleanFieldValue)
                && bool.TryParse(value, out booleanValue))
            {
                evalResult = booleanFieldValue.Equals(booleanValue);
            }
            else
            {
                evalResult = fieldValue.Equals(value);
            }
            return evalResult;
        }

        private static bool HandleNotEqualToCase(SPField oConditionField, string value, string fieldValue, string dateFormat)
        {
            bool evalResult;
            bool booleanFieldValue;
            bool booleanValue;
            DateTime dateTimeFieldValue;
            DateTime dateTimeValue;
            double doubleFieldValue = 0;
            double doubleValue = 0;

            if (DateTime.TryParse(fieldValue, out dateTimeFieldValue) && DateTime.TryParse(value, out dateTimeValue))
            {
                if (dateFormat == "DateTime")
                {
                    evalResult = !dateTimeFieldValue.Equals(dateTimeValue);
                }
                else
                {
                    evalResult = DateTime.Parse(dateTimeFieldValue.ToShortDateString()) != DateTime.Parse(dateTimeValue.ToShortDateString());
                }
            }
            else if (oConditionField.Type == SPFieldType.Number
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evalResult = !doubleFieldValue.Equals(doubleValue);
            }
            else if (oConditionField.Type == SPFieldType.Currency
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evalResult = !doubleFieldValue.Equals(doubleValue);
            }
            else if (oConditionField.Type == SPFieldType.Boolean
                && bool.TryParse(fieldValue, out booleanFieldValue)
                && bool.TryParse(value, out booleanValue))
            {
                evalResult = !booleanFieldValue.Equals(booleanValue);
            }
            else
            {
                evalResult = !fieldValue.Equals(value);
            }
            return evalResult;
        }

        private static bool HandleGreaterThanCase(SPField oConditionField, string value, string fieldValue, string dateFormat)
        {
            bool evalResult;
            bool booleanFieldValue;
            bool booleanValue;
            DateTime dateTimeFieldValue;
            DateTime dateTimeValue;
            double doubleFieldValue = 0;
            double doubleValue = 0;

            if (DateTime.TryParse(fieldValue, out dateTimeFieldValue) && DateTime.TryParse(value, out dateTimeValue))
            {
                if (dateFormat == "DateTime")
                {
                    evalResult = dateTimeFieldValue > dateTimeValue;
                }
                else
                {
                    evalResult = DateTime.Parse(dateTimeFieldValue.ToShortDateString()) > DateTime.Parse(dateTimeValue.ToShortDateString());
                }
            }
            else if (oConditionField.Type == SPFieldType.Number
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evalResult = doubleFieldValue > doubleValue;
            }
            else
            {
                evalResult = oConditionField.Type == SPFieldType.Currency
                    && double.TryParse(fieldValue, out doubleFieldValue)
                    && double.TryParse(value, out doubleValue)
                    && doubleFieldValue > doubleValue;
            }
            return evalResult;
        }

        private static bool HandleLessThanCase(SPField oConditionField, string value, string fieldValue, string dateFormat)
        {
            bool evalResult;
            bool booleanFieldValue;
            bool booleanValue;
            DateTime dateTimeFieldValue;
            DateTime dateTimeValue;
            double doubleFieldValue = 0;
            double doubleValue = 0;

            if (DateTime.TryParse(fieldValue, out dateTimeFieldValue) && DateTime.TryParse(value, out dateTimeValue))
            {
                if (dateFormat == "DateTime")
                {
                    evalResult = dateTimeFieldValue < dateTimeValue;
                }
                else
                {
                    evalResult = DateTime.Parse(dateTimeFieldValue.ToShortDateString()) < DateTime.Parse(dateTimeValue.ToShortDateString());
                }
            }
            else if (oConditionField.Type == SPFieldType.Number
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evalResult = doubleFieldValue < doubleValue;
            }
            else
            {
                evalResult = oConditionField.Type == SPFieldType.Currency
                    && double.TryParse(fieldValue, out doubleFieldValue)
                    && double.TryParse(value, out doubleValue)
                    && doubleFieldValue < doubleValue;
            }
            return evalResult;
        }

        private static bool HandleGreaterThanOrEqualCase(SPField oConditionField, string value, string fieldValue, string dateFormat)
        {
            bool evalResult;
            bool booleanFieldValue;
            bool booleanValue;
            DateTime dateTimeFieldValue;
            DateTime dateTimeValue;
            double doubleFieldValue = 0;
            double doubleValue = 0;

            if (DateTime.TryParse(fieldValue, out dateTimeFieldValue) && DateTime.TryParse(value, out dateTimeValue))
            {
                if (dateFormat == "DateTime")
                {
                    evalResult = dateTimeFieldValue >= dateTimeValue;
                }
                else
                {
                    evalResult = DateTime.Parse(dateTimeFieldValue.ToShortDateString()) >= DateTime.Parse(dateTimeValue.ToShortDateString());
                }
            }
            else if (oConditionField.Type == SPFieldType.Number
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evalResult = doubleFieldValue >= doubleValue;
            }
            else
                evalResult = oConditionField.Type == SPFieldType.Currency
                    && double.TryParse(fieldValue, out doubleFieldValue)
                    && double.TryParse(value, out doubleValue)
                    && doubleFieldValue >= doubleValue;
            return evalResult;
        }

        private static bool HandleLEssThanOrEqualCase(SPField oConditionField, string value, string fieldValue, string dateFormat)
        {
            bool evalResult;
            bool booleanFieldValue;
            bool booleanValue;
            DateTime dateTimeFieldValue;
            DateTime dateTimeValue;
            double doubleFieldValue = 0;
            double doubleValue = 0;

            if (DateTime.TryParse(fieldValue, out dateTimeFieldValue) && DateTime.TryParse(value, out dateTimeValue))
            {
                evalResult = dateFormat == "DateTime"
                    ? dateTimeFieldValue <= dateTimeValue
                    : DateTime.Parse(dateTimeFieldValue.ToShortDateString()) <= DateTime.Parse(dateTimeValue.ToShortDateString());
            }
            else if (oConditionField.Type == SPFieldType.Number
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evalResult = doubleFieldValue <= doubleValue;
            }
            else
            {
                evalResult = oConditionField.Type == SPFieldType.Currency
                    && double.TryParse(fieldValue, out doubleFieldValue)
                    && double.TryParse(value, out doubleValue)
                    && doubleFieldValue <= doubleValue;
            }
            return evalResult;
        }

        private static bool WhereUser(string condition, string group)
        {
            SPUser user = SPContext.Current.Web.CurrentUser;
            SPGroupCollection userGroups = user.Groups;
            bool userInGroup = false;

            foreach(SPGroup groupItem in userGroups)
            {
                if(groupItem.Name.Equals(group))
                {
                    userInGroup = true;
                    continue;
                }
            }

            if(condition.Equals("IsInGroup"))
                return userInGroup;
            return !userInGroup;
        }

        #endregion Methods
    }
}

