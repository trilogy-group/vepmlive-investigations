using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public class EditableFieldDisplay
    {
        #region Methods (9)

        // Public Methods (3) 

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
                return isEditableField(li, li.Fields.GetFieldByInternalName(field.InternalName), fieldProperties);
            if(!li.Fields.GetFieldByInternalName(field.InternalName).ShowInEditForm.Value)
                return false;
            return isEditableField(li, li.Fields.GetFieldByInternalName(field.InternalName), fieldProperties);
        }

        public static bool isEditable(SPList list, SPField field, Dictionary<string, Dictionary<string, string>> fieldProperties)
        {
            if(list.Fields.GetFieldByInternalName(field.InternalName).ReadOnlyField)
                return false;

            if(list.Fields.GetFieldByInternalName(field.InternalName).ShowInEditForm == null)
                return isEditableField(list.Fields.GetFieldByInternalName(field.InternalName), fieldProperties);

            if(!list.Fields.GetFieldByInternalName(field.InternalName).ShowInEditForm.Value)
                return false;

            return isEditableField(list.Fields.GetFieldByInternalName(field.InternalName), fieldProperties);
        }

        private static bool isEditableField(SPField field, Dictionary<string, Dictionary<string, string>> fieldProperties)
        {
            try
            {
                if(!fieldProperties[field.InternalName].ContainsKey("Edit"))
                    return true;

                string displaySettings = string.Empty;

                displaySettings = fieldProperties[field.InternalName]["Edit"];
                if(displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
                    return true;

                displaySettings = fieldProperties[field.InternalName]["Editable"];
                if(displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("never"))
                    return false;

                if(displaySettings.Split(";".ToCharArray())[0].ToLower().Equals("where"))
                    return true;
            }
            catch
            {
            }
            return true;
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

        // Private Methods (6) 

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

        private static bool isEditableField(SPListItem li, SPField field, Dictionary<string, Dictionary<string, string>> fieldProperties)
        {
            try
            {
                if(!fieldProperties[field.InternalName].ContainsKey("Edit"))
                    return true;

                string displaySettings = string.Empty;

                displaySettings = fieldProperties[field.InternalName]["Edit"];
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
            bool bEvalResult = false;
            try
            {
                string sDateFormat = "";

                if(value == "[Me]")
                {
                    value = SPContext.Current.Web.CurrentUser.Name;
                }
                if(value == "[Today]")
                {
                    DateTime dtNow = DateTime.Now;
                    value = dtNow.ToString();
                }
                if(oConditionField.Type == SPFieldType.Boolean)
                {
                    if(value.ToUpper() == "YES" || value.ToUpper() == "TRUE")
                    {
                        value = "True";
                    }
                    else
                    {
                        value = "False";
                    }
                }
                if(isDate(value))
                {
                    sDateFormat = getFieldSchemaAttribValue(oConditionField.SchemaXml, "Format");
                }

                string sFldVal = "";
                if(oConditionField != null)
                {
                    sFldVal = li[oConditionField.Id].ToString();
                    if(oConditionField.Type != SPFieldType.DateTime && oConditionField.Type != SPFieldType.Boolean && oConditionField.Type != SPFieldType.Number && oConditionField.Type != SPFieldType.Currency)
                    {
                        sFldVal = oConditionField.GetFieldValueAsText(sFldVal);
                    }
                }

                bool bFldVal;
                bool bVal;
                DateTime dtFldVal;
                DateTime dtVal;
                double dblFldVal = 0;
                double dblVal = 0;

                switch(condition)
                {
                    case "IsEqualTo":
                        if(DateTime.TryParse(sFldVal, out dtFldVal) && DateTime.TryParse(value, out dtVal))
                            if(sDateFormat == "DateTime")
                            {
                                if(dtFldVal == dtVal)
                                    bEvalResult = true;
                                else
                                    bEvalResult = false;
                            }
                            else
                            {
                                if(DateTime.Parse(dtFldVal.ToShortDateString()) == DateTime.Parse(dtVal.ToShortDateString()))
                                    bEvalResult = true;
                                else
                                    bEvalResult = false;
                            }
                        else if(oConditionField.Type == SPFieldType.Number && double.TryParse(sFldVal, out dblFldVal) && double.TryParse(value, out dblVal))
                            if(dblFldVal.Equals(dblVal))
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else if(oConditionField.Type == SPFieldType.Currency && double.TryParse(sFldVal, out dblFldVal) && double.TryParse(value, out dblVal))
                            if(dblFldVal.Equals(dblVal))
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else if(oConditionField.Type == SPFieldType.Boolean && bool.TryParse(sFldVal, out bFldVal) && bool.TryParse(value, out bVal))
                            if(bFldVal.Equals(bVal))
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else if(sFldVal.Equals(value))
                            bEvalResult = true;
                        else
                            bEvalResult = false;
                        break;
                    case "IsNotEqualTo":
                        if(DateTime.TryParse(sFldVal, out dtFldVal) && DateTime.TryParse(value, out dtVal))
                            if(sDateFormat == "DateTime")
                            {
                                if(!dtFldVal.Equals(dtVal))
                                    bEvalResult = true;
                                else
                                    bEvalResult = false;
                            }
                            else
                            {
                                if(DateTime.Parse(dtFldVal.ToShortDateString()) != DateTime.Parse(dtVal.ToShortDateString()))
                                    bEvalResult = true;
                                else
                                    bEvalResult = false;
                            }
                        else if(oConditionField.Type == SPFieldType.Number && double.TryParse(sFldVal, out dblFldVal) && double.TryParse(value, out dblVal))
                            if(!dblFldVal.Equals(dblVal))
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else if(oConditionField.Type == SPFieldType.Currency && double.TryParse(sFldVal, out dblFldVal) && double.TryParse(value, out dblVal))
                            if(!dblFldVal.Equals(dblVal))
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else if(oConditionField.Type == SPFieldType.Boolean && bool.TryParse(sFldVal, out bFldVal) && bool.TryParse(value, out bVal))
                            if(!bFldVal.Equals(bVal))
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else if(!sFldVal.Equals(value))
                            bEvalResult = true;
                        else
                            bEvalResult = false;
                        break;
                    case "IsGreaterThan":
                        if(DateTime.TryParse(sFldVal, out dtFldVal) && DateTime.TryParse(value, out dtVal))
                            if(sDateFormat == "DateTime")
                            {
                                if(dtFldVal > dtVal)
                                    bEvalResult = true;
                                else
                                    bEvalResult = false;
                            }
                            else
                            {
                                if(DateTime.Parse(dtFldVal.ToShortDateString()) > DateTime.Parse(dtVal.ToShortDateString()))
                                    bEvalResult = true;
                                else
                                    bEvalResult = false;
                            }
                        else if(oConditionField.Type == SPFieldType.Number && double.TryParse(sFldVal, out dblFldVal) && double.TryParse(value, out dblVal))
                            if(dblFldVal > dblVal)
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else if(oConditionField.Type == SPFieldType.Currency && double.TryParse(sFldVal, out dblFldVal) && double.TryParse(value, out dblVal))
                            if(dblFldVal > dblVal)
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else
                            bEvalResult = false;
                        break;
                    case "IsLessThan":
                        if(DateTime.TryParse(sFldVal, out dtFldVal) && DateTime.TryParse(value, out dtVal))
                            if(sDateFormat == "DateTime")
                            {
                                if(dtFldVal < dtVal)
                                    bEvalResult = true;
                                else
                                    bEvalResult = false;
                            }
                            else
                            {
                                if(DateTime.Parse(dtFldVal.ToShortDateString()) < DateTime.Parse(dtVal.ToShortDateString()))
                                    bEvalResult = true;
                                else
                                    bEvalResult = false;
                            }
                        else if(oConditionField.Type == SPFieldType.Number && double.TryParse(sFldVal, out dblFldVal) && double.TryParse(value, out dblVal))
                            if(dblFldVal < dblVal)
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else if(oConditionField.Type == SPFieldType.Currency && double.TryParse(sFldVal, out dblFldVal) && double.TryParse(value, out dblVal))
                            if(dblFldVal < dblVal)
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else
                            bEvalResult = false;
                        break;
                    case "IsGreaterThanOrEqual":
                        if(DateTime.TryParse(sFldVal, out dtFldVal) && DateTime.TryParse(value, out dtVal))
                            if(sDateFormat == "DateTime")
                            {
                                if(dtFldVal >= dtVal)
                                    bEvalResult = true;
                                else
                                    bEvalResult = false;
                            }
                            else
                            {
                                if(DateTime.Parse(dtFldVal.ToShortDateString()) >= DateTime.Parse(dtVal.ToShortDateString()))
                                    bEvalResult = true;
                                else
                                    bEvalResult = false;
                            }
                        else if(oConditionField.Type == SPFieldType.Number && double.TryParse(sFldVal, out dblFldVal) && double.TryParse(value, out dblVal))
                            if(dblFldVal >= dblVal)
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else if(oConditionField.Type == SPFieldType.Currency && double.TryParse(sFldVal, out dblFldVal) && double.TryParse(value, out dblVal))
                            if(dblFldVal >= dblVal)
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else
                            bEvalResult = false;
                        break;
                    case "IsLessThanOrEqual":
                        if(DateTime.TryParse(sFldVal, out dtFldVal) && DateTime.TryParse(value, out dtVal))
                            if(sDateFormat == "DateTime")
                            {
                                if(dtFldVal <= dtVal)
                                    bEvalResult = true;
                                else
                                    bEvalResult = false;
                            }
                            else
                            {
                                if(DateTime.Parse(dtFldVal.ToShortDateString()) <= DateTime.Parse(dtVal.ToShortDateString()))
                                    bEvalResult = true;
                                else
                                    bEvalResult = false;
                            }
                        else if(oConditionField.Type == SPFieldType.Number && double.TryParse(sFldVal, out dblFldVal) && double.TryParse(value, out dblVal))
                            if(dblFldVal <= dblVal)
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else if(oConditionField.Type == SPFieldType.Currency && double.TryParse(sFldVal, out dblFldVal) && double.TryParse(value, out dblVal))
                            if(dblFldVal <= dblVal)
                                bEvalResult = true;
                            else
                                bEvalResult = false;
                        else
                            bEvalResult = false;
                        break;
                    //case "BeginWith":
                    //    if (sFldVal.StartsWith(value))
                    //        bEvalResult = true;
                    //    else
                    //        bEvalResult = false;
                    //    break;
                    //case "EndWith":
                    //    if (sFldVal.EndsWith(value))
                    //        bEvalResult = true;
                    //    else
                    //        bEvalResult = false;
                    //    break;
                    case "Contains":
                        if(sFldVal.Contains(value))
                            bEvalResult = true;
                        else
                            bEvalResult = false;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
            }
            return bEvalResult;
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

