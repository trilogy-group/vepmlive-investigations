using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.SharePoint;

namespace WorkEnginePPM
{
    public class EditableFieldDisplay
    {
        private const string MeKey = "[Me]";
        private const string TodayKey = "[Today]";

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
                if (where.Equals("[Me]"))
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
            catch {
                if (field.ShowInEditForm.HasValue)
                    return field.ShowInEditForm.Value;
                else
                    return true;
            }
        }

        public static bool RenderField(SPField field, string where, string conditionField, string condition, string group, string valueCondition, SPListItem li)
        {
            bool result = false;

            if (where.Equals("[Me]"))
                result = WhereUser(condition, group);
            else // [Field]
            {
                SPField oConditionField = null;
                if (conditionField.Length > 0)
                {
                    oConditionField = li.Fields.GetFieldByInternalName(conditionField);
                }
                result = WhereField(oConditionField, where, condition, valueCondition, li);
            }
            return result;
        }



        private static bool WhereUser(string condition, string group)
        {

            SPUser user = SPContext.Current.Web.CurrentUser;
            SPGroupCollection userGroups = user.Groups;
            bool userInGroup = false;

            foreach (SPGroup groupItem in userGroups)
            {
                if (groupItem.Name.Equals(group))
                {
                    userInGroup = true;
                    continue;
                }
            }

            if (condition.Equals("IsInGroup"))
                return userInGroup;
            else
                return !userInGroup;
        }

        private static bool WhereField(SPField oConditionField, string where, string condition, string value, SPListItem li)
        {
            var evaluateResult = false;
            try
            {
                var dateFormat = GetDateFormat(oConditionField, ref value);
                var fieldValue = GetFieldValue(oConditionField, li);
                evaluateResult = EvaluateResult(oConditionField, condition, value, evaluateResult, fieldValue, dateFormat);
            }
            catch (Exception ex)
            {
                Trace.TraceError("Exception Suppressed {0}", ex);
            }
            return evaluateResult;
        }

        internal static string GetDateFormat(SPField conditionField, ref string formatValue)
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
            if (conditionField.Type == SPFieldType.Boolean)
            {
                formatValue = string.Equals(formatValue, "YES", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(formatValue, "TRUE", StringComparison.OrdinalIgnoreCase)
                        ? bool.TrueString
                        : bool.FalseString;
            }
            if (isDate(formatValue))
            {
                dateFormat = getFieldSchemaAttribValue(conditionField.SchemaXml, "Format");
            }
            return dateFormat;
        }

        internal static string GetFieldValue(SPField conditionField, SPListItem listItem)
        {
            var fieldValue = string.Empty;
            if (conditionField != null)
            {
                fieldValue = listItem[conditionField.Id].ToString();
                if (conditionField.Type != SPFieldType.DateTime
                    && conditionField.Type != SPFieldType.Boolean
                    && conditionField.Type != SPFieldType.Number
                    && conditionField.Type != SPFieldType.Currency)
                {
                    fieldValue = conditionField.GetFieldValueAsText(fieldValue);
                }
            }
            return fieldValue;
        }

        internal static bool EvaluateResult(
            SPField conditionField,
            string condition,
            string value,
            bool evalResult,
            string fieldValue,
            string dateFormat)
        {
            switch (condition)
            {
                case "IsEqualTo":
                    evalResult = HandleEqualToCase(conditionField, value, fieldValue, dateFormat);
                    break;
                case "IsNotEqualTo":
                    evalResult = HandleNotEqualToCase(conditionField, value, fieldValue, dateFormat);
                    break;
                case "IsGreaterThan":
                    evalResult = HandleGreaterThanCase(conditionField, value, fieldValue, dateFormat);
                    break;
                case "IsLessThan":
                    evalResult = HandleLessThanCase(conditionField, value, fieldValue, dateFormat);
                    break;
                case "IsGreaterThanOrEqual":
                    evalResult = HandleGreaterThanOrEqualCase(conditionField, value, fieldValue, dateFormat);
                    break;
                case "IsLessThanOrEqual":
                    evalResult = HandleLessThanOrEqualCase(conditionField, value, fieldValue, dateFormat);
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

        internal static bool HandleEqualToCase(SPField conditionField, string value, string fieldValue, string dateFormat)
        {
            bool evaluateResult;
            bool booleanFieldValue;
            bool booleanValue;
            DateTime dateTimeFieldValue;
            DateTime dateTimeValue;
            double doubleFieldValue;
            double doubleValue;

            if (DateTime.TryParse(fieldValue, out dateTimeFieldValue) && DateTime.TryParse(value, out dateTimeValue))
            {
                if (dateFormat == "DateTime")
                {
                    evaluateResult = dateTimeFieldValue == dateTimeValue;
                }
                else
                {
                    evaluateResult = DateTime.Parse(dateTimeFieldValue.ToShortDateString()) == DateTime.Parse(dateTimeValue.ToShortDateString());
                }
            }
            else if (conditionField.Type == SPFieldType.Number
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evaluateResult = doubleFieldValue.Equals(doubleValue);
            }
            else if (conditionField.Type == SPFieldType.Currency
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evaluateResult = doubleFieldValue.Equals(doubleValue);
            }
            else if (conditionField.Type == SPFieldType.Boolean
                && bool.TryParse(fieldValue, out booleanFieldValue)
                && bool.TryParse(value, out booleanValue))
            {
                evaluateResult = booleanFieldValue.Equals(booleanValue);
            }
            else
            {
                evaluateResult = fieldValue.Equals(value);
            }
            return evaluateResult;
        }

        internal static bool HandleNotEqualToCase(SPField conditionField, string value, string fieldValue, string dateFormat)
        {
            bool evaluateResult;
            bool booleanFieldValue;
            bool booleanValue;
            DateTime dateTimeFieldValue;
            DateTime dateTimeValue;
            double doubleFieldValue;
            double doubleValue;

            if (DateTime.TryParse(fieldValue, out dateTimeFieldValue) && DateTime.TryParse(value, out dateTimeValue))
            {
                if (dateFormat == "DateTime")
                {
                    evaluateResult = !dateTimeFieldValue.Equals(dateTimeValue);
                }
                else
                {
                    evaluateResult = DateTime.Parse(dateTimeFieldValue.ToShortDateString()) != DateTime.Parse(dateTimeValue.ToShortDateString());
                }
            }
            else if (conditionField.Type == SPFieldType.Number
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evaluateResult = !doubleFieldValue.Equals(doubleValue);
            }
            else if (conditionField.Type == SPFieldType.Currency
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evaluateResult = !doubleFieldValue.Equals(doubleValue);
            }
            else if (conditionField.Type == SPFieldType.Boolean
                && bool.TryParse(fieldValue, out booleanFieldValue)
                && bool.TryParse(value, out booleanValue))
            {
                evaluateResult = !booleanFieldValue.Equals(booleanValue);
            }
            else
            {
                evaluateResult = !fieldValue.Equals(value);
            }
            return evaluateResult;
        }

        internal static bool HandleGreaterThanCase(SPField conditionField, string value, string fieldValue, string dateFormat)
        {
            bool evaluateResult;
            DateTime dateTimeFieldValue;
            DateTime dateTimeValue;
            double doubleFieldValue;
            double doubleValue;

            if (DateTime.TryParse(fieldValue, out dateTimeFieldValue) && DateTime.TryParse(value, out dateTimeValue))
            {
                if (dateFormat == "DateTime")
                {
                    evaluateResult = dateTimeFieldValue > dateTimeValue;
                }
                else
                {
                    evaluateResult = DateTime.Parse(dateTimeFieldValue.ToShortDateString()) > DateTime.Parse(dateTimeValue.ToShortDateString());
                }
            }
            else if (conditionField.Type == SPFieldType.Number
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evaluateResult = doubleFieldValue > doubleValue;
            }
            else
            {
                evaluateResult = conditionField.Type == SPFieldType.Currency
                    && double.TryParse(fieldValue, out doubleFieldValue)
                    && double.TryParse(value, out doubleValue)
                    && doubleFieldValue > doubleValue;
            }
            return evaluateResult;
        }

        internal static bool HandleLessThanCase(SPField conditionField, string value, string fieldValue, string dateFormat)
        {
            bool evaluateResult;
            DateTime dateTimeFieldValue;
            DateTime dateTimeValue;
            double doubleFieldValue;
            double doubleValue;

            if (DateTime.TryParse(fieldValue, out dateTimeFieldValue) && DateTime.TryParse(value, out dateTimeValue))
            {
                if (dateFormat == "DateTime")
                {
                    evaluateResult = dateTimeFieldValue < dateTimeValue;
                }
                else
                {
                    evaluateResult = DateTime.Parse(dateTimeFieldValue.ToShortDateString()) < DateTime.Parse(dateTimeValue.ToShortDateString());
                }
            }
            else if (conditionField.Type == SPFieldType.Number
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evaluateResult = doubleFieldValue < doubleValue;
            }
            else
            {
                evaluateResult = conditionField.Type == SPFieldType.Currency
                    && double.TryParse(fieldValue, out doubleFieldValue)
                    && double.TryParse(value, out doubleValue)
                    && doubleFieldValue < doubleValue;
            }
            return evaluateResult;
        }

        internal static bool HandleGreaterThanOrEqualCase(SPField conditionField, string value, string fieldValue, string dateFormat)
        {
            bool evaluateResult;
            DateTime dateTimeFieldValue;
            DateTime dateTimeValue;
            double doubleFieldValue;
            double doubleValue;

            if (DateTime.TryParse(fieldValue, out dateTimeFieldValue) && DateTime.TryParse(value, out dateTimeValue))
            {
                if (dateFormat == "DateTime")
                {
                    evaluateResult = dateTimeFieldValue >= dateTimeValue;
                }
                else
                {
                    evaluateResult = DateTime.Parse(dateTimeFieldValue.ToShortDateString()) >= DateTime.Parse(dateTimeValue.ToShortDateString());
                }
            }
            else if (conditionField.Type == SPFieldType.Number
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evaluateResult = doubleFieldValue >= doubleValue;
            }
            else
            {
                evaluateResult = conditionField.Type == SPFieldType.Currency
                    && double.TryParse(fieldValue, out doubleFieldValue)
                    && double.TryParse(value, out doubleValue)
                    && doubleFieldValue >= doubleValue;
            }
            return evaluateResult;
        }

        internal static bool HandleLessThanOrEqualCase(SPField conditionField, string value, string fieldValue, string dateFormat)
        {
            bool evaluateResult;
            DateTime dateTimeFieldValue;
            DateTime dateTimeValue;
            double doubleFieldValue;
            double doubleValue;

            if (DateTime.TryParse(fieldValue, out dateTimeFieldValue) && DateTime.TryParse(value, out dateTimeValue))
            {
                evaluateResult = dateFormat == "DateTime"
                    ? dateTimeFieldValue <= dateTimeValue
                    : DateTime.Parse(dateTimeFieldValue.ToShortDateString()) <= DateTime.Parse(dateTimeValue.ToShortDateString());
            }
            else if (conditionField.Type == SPFieldType.Number
                && double.TryParse(fieldValue, out doubleFieldValue)
                && double.TryParse(value, out doubleValue))
            {
                evaluateResult = doubleFieldValue <= doubleValue;
            }
            else
            {
                evaluateResult = conditionField.Type == SPFieldType.Currency
                    && double.TryParse(fieldValue, out doubleFieldValue)
                    && double.TryParse(value, out doubleValue)
                    && doubleFieldValue <= doubleValue;
            }
            return evaluateResult;
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
            catch { }
            return sAttribVal;
        }

        private static bool IsNumeric(string value)
        {
            if (value == string.Empty) return false;
            System.Text.RegularExpressions.Regex regexp = new System.Text.RegularExpressions.Regex("^[0-9]*$");
            return regexp.Match(value).Success;
        }
    }
}
