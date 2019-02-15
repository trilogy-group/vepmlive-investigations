using System;
using System.Text;
using Microsoft.SharePoint;
using SystemTrace = System.Diagnostics.Trace;

namespace EPMLiveCore
{
    public partial class ListDisplayPage
    {
        private const string SemiColon = ";";

        private string RenderOptions(SPField field)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            var result = new StringBuilder();
            var showWhere = false;
            var showEdit = false;

            if (field.Type != SPFieldType.Calculated)
            {
                result.Append("\n<table style=\"width: 100%\">")
                   .Append("\n<tr><td style=\"width: 150px;\"  class=\"ms-authoringcontrols\">")
                   .Append("\nOn new item, display field : ")
                   .Append("\n</td><td class=\"ms-authoringcontrols\">");

                if (field.Required)
                {
                    result.Append("\nAlways (This field is required)");
                }
                else
                {
                    result.Append($"\n{RenderOption(field, NewText, ref showWhere, ref showEdit)}")
                       .Append($"\n{RenderPanelWhere(field, NewText, ref showWhere)}");
                    UpdateGlobalScript(field, NewText);
                }

                result.Append("\n</td></tr>")
                   .Append("\n</table>");
            }

            result.Append("\n<table style=\"width: 100%\">")
               .Append("\n<tr><td style=\"width: 150px;\" class=\"ms-authoringcontrols\">")
               .Append("\nOn display item, display field : ")
               .Append("\n</td><td class=\"ms-authoringcontrols\">")
               .Append($"\n{RenderOption(field, DisplayText, ref showWhere, ref showEdit)}")
               .Append($"\n{RenderPanelWhere(field, DisplayText, ref showWhere)}");
            UpdateGlobalScript(field, DisplayText);
            result.Append("\n</td></tr>")
               .Append("\n</table>");

            showEdit = false;
            {
                result.Append("\n<table style=\"width: 100%\">")
                   .Append("\n<tr><td style=\"width: 150px;\"  class=\"ms-authoringcontrols\">")
                   .Append("\nOn edit item, display field : ")
                   .Append("\n</td><td class=\"ms-authoringcontrols\">")
                   .Append($"\n{RenderOption(field, Edit, ref showWhere, ref showEdit)}")
                   .Append($"\n{RenderPanelWhere(field, Edit, ref showWhere)}");
                UpdateGlobalScript(field, Edit);
                result.Append("\n</td></tr>")
                   .Append("\n</table>");
            }

            if (field.Type != SPFieldType.Calculated)
            {
                result.Append($"\n<table style=\"width: 100%\" id=\"Editable{field.InternalName}Edit\" style=\"display:");

                if (!showEdit)
                {
                    result.Append("\nnone");
                }

                result.Append("\n;\">")
                   .Append("\n<tr><td style=\"width: 150px;\"  class=\"ms-authoringcontrols\">")
                   .Append("\nOn edit item, editable: ")
                   .Append("\n</td><td class=\"ms-authoringcontrols\">")
                   .Append($"\n{RenderOption(field, EditableText, ref showWhere, ref showEdit)}")
                   .Append($"\n{RenderPanelWhere(field, EditableText, ref showWhere)}");
                UpdateGlobalScript(field, EditableText);
                result.Append("\n</td></tr>")
                   .Append("\n</table>");
            }

            return result.ToString();
        }

        private string RenderOption(SPField field, string mode, ref bool showWhere, ref bool showEdit)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            var result = new StringBuilder();
            result.Append(
                $"\n<select id=\"Option{field.InternalName}{mode}\" runat=\"server\" onchange=\"javascript:OptionChange(\'{field.InternalName}{mode}\');\" style=\"width: 100px;\">");

            var optionValueAlways = string.Empty;
            var optionValueNever = string.Empty;
            var optionValueWhere = string.Empty;

            if (_fieldProperties?.ContainsKey(field.InternalName) == true && _fieldProperties[field.InternalName].ContainsKey(mode))
            {
                ProcessFieldProperties(field, mode, optionValueWhere, optionValueAlways, optionValueNever, result, ref showEdit, out showWhere);
            }
            else
            {
                ProcessMode(field, mode, ref showEdit, ref optionValueAlways, ref optionValueNever);

                if (mode == EditableText)
                {
                    if (MatchROFields(field.Id) == false)
                    {
                        optionValueAlways = Selected;
                    }
                    else
                    {
                        optionValueNever = Selected;
                    }
                }

                result.Append($"\n<option {optionValueAlways}value=\"always\">Always</option>")
                   .Append($"\n<option {optionValueNever}value=\"never\">Never</option>")
                   .Append("\n<option value=\"where\">Where</option>");

                showWhere = false;
            }

            result.Append("\n</select>")
               .Append("\n</td></tr>");

            return result.ToString();
        }

        private void ProcessFieldProperties(
            SPField field,
            string mode,
            string optionValueWhere,
            string optionValueAlways,
            string optionValueNever,
            StringBuilder result,
            ref bool showEdit,
            out bool showWhere)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            var optionMode = string.Empty;

            try
            {
                optionMode = _fieldProperties[field.InternalName][mode];
            }
            catch (Exception exception)
            {
                SystemTrace.WriteLine(exception);
            }

            var selectOption = optionMode.Split(SemiColon.ToCharArray())[0];

            if (selectOption.Equals(WhereText, StringComparison.OrdinalIgnoreCase))
            {
                optionValueWhere = Selected;
                showEdit = true;
            }
            else
            {
                ProcessMode(field, mode, ref showEdit, ref optionValueAlways, ref optionValueNever);

                if (mode == EditableText)
                {
                    if (selectOption.Equals(string.Empty) || selectOption.Equals(Always, StringComparison.OrdinalIgnoreCase))
                    {
                        optionValueAlways = Selected;
                    }
                    else if (selectOption.Equals(Never, StringComparison.OrdinalIgnoreCase))
                    {
                        optionValueNever = Selected;
                    }
                    else if (selectOption.Equals(WhereText, StringComparison.OrdinalIgnoreCase))
                    {
                        optionValueWhere = Selected;
                    }
                }
                else
                {
                    SystemTrace.WriteLine($"Unexpected value : {mode}");
                }
            }

            result.Append($"\n<option {optionValueAlways}value=\"always\">Always</option>")
               .Append($"\n<option {optionValueNever}value=\"never\">Never</option>")
               .Append($"\n<option {optionValueWhere}value=\"where\">Where</option>");

            showWhere = selectOption.Equals(WhereText);
        }
    }
}