using System;
using System.Text;
using Microsoft.SharePoint;

namespace EPMLiveCore
{
    public partial class ListDisplayPage
    {
        private string RenderPanelWhere(SPField field, string mode, ref bool showWhere)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            var result = new StringBuilder();

            result.Append(
                    showWhere
                        ? $"\n<tr id=\"RowOptionPanel{field.InternalName}{mode}\" style=\"display:inline;\"><td style=\"width: 150px;\" ></td><td class=\"ms-authoringcontrols\">"
                        : $"\n<tr id=\"RowOptionPanel{field.InternalName}{mode}\" style=\"display:none;\"><td style=\"width: 150px;\" ></td><td class=\"ms-authoringcontrols\">")
               .Append($"\n{RenderWhere(field, mode)}");
            showWhere = false;

            return result.ToString();
        }

        private string RenderWhere(SPField field, string mode)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            var result = new StringBuilder();

            result.Append("\n<table cellpadding=\"0px\" cellspacing=\"0px\" style=\"width: 100%;\">")
               .Append("\n<tr><td>");

            if (_fieldProperties?.ContainsKey(field.InternalName) == true && _fieldProperties[field.InternalName].ContainsKey(mode))
            {
                ProcessInternalName(field, mode, result);
            }
            else
            {
                result.Append(
                        $"\n<select id=\"OptionFieldWhere{field.InternalName}{mode}\" runat=\"server\" onchange=\"javascript:OptionFieldWhereChange(\'{field.InternalName}{mode}\');\">")
                   .Append("\n<option selected=\"selected\" value=\"[Me]\">[Me]</option>")
                   .Append("\n<option value=\"[Field]\">Field</option>")
                   .Append("\n</select>")
                   .Append($"\n<select id=\"OptionFieldNameWhere{field.InternalName}{mode}\" runat=\"server\" style=\"display:none\" >");

                foreach (var fieldItem in _displayableFields.Values)
                {
                    result.Append($"\n<option value=\"{fieldItem.InternalName}\">{fieldItem.Title}</option>");
                }

                result.Append("\n</select>")
                   .Append($"\n<select id=\"OptionConditionWhere{field.InternalName}{mode}\" runat=\"server\" style=\"width: 200px\">")
                   .Append("\n<option selected=\"selected\" value=\"IsInGroup\">Is in group</option>")
                   .Append("\n<option value=\"IsNotInGroup\">Is not in group</option>")
                   .Append("\n</select>")
                   .Append($"\n<select id=\"OptionValueUserWhere{field.InternalName}{mode}\" runat=\"server\" style=\"width: 200px\">");

                foreach (var spGroup in _groups)
                {
                    result.Append($"\n<option value=\"{spGroup.Name}\">{spGroup.Name}</option>");
                }

                result.Append("\n</select>")
                   .Append(
                        $"\n<input id=\"OptionValueFieldWhere{field.InternalName}{mode}\" class=\"ms-long\" style=\"width: 200px; display: none\" />");
            }

            result.Append($"\n<input id=\"Hidden{field.InternalName}{mode}\" type=\"hidden\" />")
               .Append("\n</td></tr>")
               .Append("\n</table>");

            return result.ToString();
        }

        private void ProcessInternalName(SPField field, string mode, StringBuilder result)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            var memMode = _fieldProperties[field.InternalName][mode];

            if (memMode.Split(SemiColon.ToCharArray()).Length > 3)
            {
                var memModeValue = memMode.Split(SemiColon.ToCharArray())[0];
                var memOptionFieldWhere = memMode.Split(SemiColon.ToCharArray())[1];
                var memOptionValueFieldNameWhere = string.Empty;
                string memOptionConditionWhere;
                var memOptionValueUserWhere = string.Empty;
                var memOptionValueFieldWhere = string.Empty;

                if (memOptionFieldWhere == "[Me]")
                {
                    memOptionConditionWhere = memMode.Split(SemiColon.ToCharArray())[2];
                    memOptionValueUserWhere = memMode.Split(SemiColon.ToCharArray())[3];
                }
                else
                {
                    memOptionValueFieldNameWhere = memMode.Split(SemiColon.ToCharArray())[2];
                    memOptionConditionWhere = memMode.Split(SemiColon.ToCharArray())[3];

                    if (memMode.Split(SemiColon.ToCharArray()).Length > 4)
                    {
                        memOptionValueFieldWhere = memMode.Split(SemiColon.ToCharArray())[4];
                    }
                }

                if (memModeValue.Equals(WhereText))
                {
                    ProcessWhere(
                        field,
                        mode,
                        result,
                        memOptionFieldWhere,
                        memOptionValueFieldNameWhere,
                        memOptionConditionWhere,
                        memOptionValueFieldWhere,
                        memOptionValueUserWhere);
                }
                else
                {
                    result.Append(
                            $"\n<select id=\"OptionFieldWhere{field.InternalName}{mode}\" runat=\"server\" onchange=\"javascript:OptionFieldWhereChange(\'{field.InternalName}{mode}\');\">")
                       .Append("\n<option selected=\"selected\" value=\"[Me]\">[Me]</option>")
                       .Append("\n<option value=\"[Field]\">Field</option>")
                       .Append("\n</select>")
                       .Append($"\n<select id=\"OptionFieldNameWhere{field.InternalName}{mode}\" runat=\"server\" style=\"display:none\" >");

                    foreach (var fieldItem in _displayableFields.Values)
                    {
                        result.Append($"\n<option value=\"{fieldItem.InternalName}\">{fieldItem.Title}</option>");
                    }

                    result.Append("\n</select>")
                       .Append($"\n<select id=\"OptionConditionWhere{field.InternalName}{mode}\" runat=\"server\" style=\"width: 200px\">")
                       .Append("\n<option selected=\"selected\" value=\"IsInGroup\">Is in group</option>")
                       .Append("\n<option value=\"IsNotInGroup\">Is not in group</option>")
                       .Append("\n</select>")
                       .Append($"\n<select id=\"OptionValueUserWhere{field.InternalName}{mode}\" runat=\"server\" style=\"width: 200px\">");

                    foreach (var spGroup in _groups)
                    {
                        result.Append($"\n<option value=\"{spGroup.Name}\">{spGroup.Name}</option>");
                    }

                    result.Append("\n</select>")
                       .Append(
                            $"\n<input id=\"OptionValueFieldWhere{field.InternalName}{mode}\" class=\"ms-long\" style=\"width: 200px; display: none\" />");
                }
            }
        }

        private void ProcessWhere(
            SPField field,
            string mode,
            StringBuilder result,
            string memOptionFieldWhere,
            string memOptionValueFieldNameWhere,
            string memOptionConditionWhere,
            string memOptionValueFieldWhere,
            string memOptionValueUserWhere)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            result.Append(
                $"\n<select id=\"OptionFieldWhere{field.InternalName}{mode}\" runat=\"server\" onchange=\"javascript:OptionFieldWhereChange(\'{field.InternalName}{mode}\');\">");

            if (memOptionFieldWhere.Equals("[Me]"))
            {
                result.Append("\n<option selected=\"selected\" value=\"[Me]\">[Me]</option>")
                   .Append("\n<option value=\"[Field]\">Field</option>");
            }
            else
            {
                result.Append("\n<option selected=\"selected\" value=\"[Field]\">Field</option>")
                   .Append("\n<option value=\"[Me]\">[Me]</option>");
            }

            result.Append("\n</select>")
               .Append(
                    memOptionFieldWhere.Equals("[Me]")
                        ? $"\n<select id=\"OptionFieldNameWhere{field.InternalName}{mode}\" runat=\"server\" style=\"display:none\" >"
                        : $"\n<select id=\"OptionFieldNameWhere{field.InternalName}{mode}\" runat=\"server\" >");

            foreach (var fieldItem in _displayableFields.Values)
            {
                result.Append(
                    memOptionValueFieldNameWhere.Equals(fieldItem.InternalName)
                        ? $"\n<option selected=\"selected\" value=\"{fieldItem.InternalName}\">{fieldItem.Title}</option>"
                        : $"\n<option value=\"{fieldItem.InternalName}\">{fieldItem.Title}</option>");
            }

            result.Append("\n</select>")
               .Append($"\n<select id=\"OptionConditionWhere{field.InternalName}{mode}\" runat=\"server\" style=\"width: 200px\">");

            ProcessMemOptionFieldWhere(result, memOptionFieldWhere, memOptionConditionWhere);

            result.Append("\n</select>");

            if (memOptionFieldWhere.Equals("[Me]"))
            {
                result.Append(
                    $"\n<select id=\"OptionValueUserWhere{field.InternalName}{mode}\" runat=\"server\" style=\"width: 200px; display:inline\">");

                foreach (var spGroup in _groups)
                {
                    result.Append(
                        memOptionValueFieldWhere.Equals(spGroup.Name)
                            ? $"\n<option {(memOptionValueUserWhere.Equals(spGroup.Name) ? "selected=\"selected\" " : string.Empty)}value=\"{spGroup.Name}\" selected=\"selected\" >{spGroup.Name}</option>"
                            : $"\n<option {(memOptionValueUserWhere.Equals(spGroup.Name) ? "selected=\"selected\" " : string.Empty)}value=\"{spGroup.Name}\">{spGroup.Name}</option>");
                }
            }
            else
            {
                result.Append(
                    $"\n<select id=\"OptionValueUserWhere{field.InternalName}{mode}\" runat=\"server\" style=\"width: 200px; display:none\">");

                foreach (var spGroup in _groups)
                {
                    result.Append(
                        memOptionValueFieldWhere.Equals(spGroup.Name)
                            ? $"\n<option selected=\"selected\" value=\"{spGroup.Name}\">{spGroup.Name}</option>"
                            : $"\n<option value=\"{spGroup.Name}\">{spGroup.Name}</option>");
                }
            }

            result.Append("\n</select>")
               .Append(
                    memOptionFieldWhere.Equals("[Me]")
                        ? $"\n<input id=\"OptionValueFieldWhere{field.InternalName}{mode}\" class=\"ms-long\" style=\"width: 200px; display: none\" />"
                        : $"\n<input id=\"OptionValueFieldWhere{field.InternalName}{mode}\" class=\"ms-long\" style=\"width: 200px; display: inline\" value=\"{memOptionValueFieldWhere}\" />");
        }

        private static void ProcessMemOptionFieldWhere(StringBuilder result, string memOptionFieldWhere, string memOptionConditionWhere)
        {
            if (memOptionFieldWhere.Equals("[Me]"))
            {
                result.Append(
                        $"\n<option {(memOptionConditionWhere.Equals("IsInGroup") ? "selected=\"selected\" " : string.Empty)}value=\"IsInGroup\">Is in group</option>")
                   .Append(
                        $"\n<option {(memOptionConditionWhere.Equals("IsNotInGroup") ? "selected=\"selected\" " : string.Empty)}value=\"IsNotInGroup\">Is not in group</option>");
            }
            else
            {
                result.Append(
                        $"\n<option {(memOptionConditionWhere.Equals("IsEqualTo") ? "selected=\"selected\" " : string.Empty)}value=\"IsEqualTo\">Is equal to</option>")
                   .Append(
                        $"\n<option {(memOptionConditionWhere.Equals("IsNotEqualTo") ? "selected=\"selected\" " : string.Empty)}value=\"IsNotEqualTo\">Is not equal to</option>")
                   .Append(
                        $"\n<option {(memOptionConditionWhere.Equals("IsGreaterThan") ? "selected=\"selected\" " : string.Empty)}value=\"IsGreaterThan\">Is greater than</option>")
                   .Append(
                        $"\n<option {(memOptionConditionWhere.Equals("IsLessThan") ? "selected=\"selected\" " : string.Empty)}value=\"IsLessThan\">Is less than</option>")
                   .Append(
                        $"\n<option {(memOptionConditionWhere.Equals("IsGreaterThanOrEqual") ? "selected=\"selected\" " : string.Empty)}value=\"IsGreaterThanOrEqual\">Is greater than or equal to</option>")
                   .Append(
                        $"\n<option {(memOptionConditionWhere.Equals("IsLessThanOrEqual") ? "selected=\"selected\" " : string.Empty)}value=\"IsLessThanOrEqual\">Is less than or equal to</option>")
                   .Append(
                        $"\n<option {(memOptionConditionWhere.Equals("BeginWith") ? "selected=\"selected\" " : string.Empty)}value=\"BeginWith\">Begins with</option>")
                   .Append(
                        $"\n<option {(memOptionConditionWhere.Equals("EndWith") ? "selected=\"selected\" " : string.Empty)}value=\"EndWith\">Ends with</option>")
                   .Append(
                        $"\n<option {(memOptionConditionWhere.Equals("Contains") ? "selected=\"selected\" " : string.Empty)}value=\"Contains\">Contains</option>");
            }
        }
    }
}