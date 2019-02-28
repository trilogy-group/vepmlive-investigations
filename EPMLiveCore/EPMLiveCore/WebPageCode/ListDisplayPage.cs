using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using SystemTrace = System.Diagnostics.Trace;

namespace EPMLiveCore
{
    public partial class ListDisplayPage : LayoutsPageBase
    {
        private const int PageSize = 5;
        private const string Selected = "selected ";
        private const string WhereText = "where";
        private const string NewText = "New";
        private const string Edit = "Edit";
        private const string DisplayText = "Display";
        private const string EditableText = "Editable";
        private const string Always = "always";
        private const string Never = "never";
        private string _pageRender;
        private SPList _currentList;
        private readonly SortedList<string, SPField> _displayableFields = new SortedList<string, SPField>();
        private readonly List<SPGroup> _groups = new List<SPGroup>();
        private readonly StringBuilder _computeFieldsScript = new StringBuilder();
        private Dictionary<string, Dictionary<string, string>> _fieldProperties;

        protected Button OK = new Button();
        protected Button Cancel = new Button();
        private bool _disposed;

        protected override void OnLoad(EventArgs eventArgs)
        {
            if (eventArgs == null)
            {
                throw new ArgumentNullException(nameof(eventArgs));
            }

            Title = "Editable Fields";

            var gSettings = new GridGanttSettings(CurrentList);

            if (!string.IsNullOrWhiteSpace(gSettings.DisplaySettings))
            {
                _fieldProperties = ListDisplayUtils.ConvertFromString(gSettings.DisplaySettings);
            }

            foreach (SPField field in CurrentList.Fields)
            {
                if (field.Reorderable && !field.Sealed)
                {
                    _displayableFields.Add(field.Title, field);
                }
                else
                {
                    if (MatchROFields(field.Id))
                    {
                        _displayableFields.Add(field.Title, field);
                    }
                }
            }

            foreach (SPGroup group in CurrentList.ParentWeb.Groups)
            {
                _groups.Add(group);
            }

            Cancel.PostBackUrl = $"~/_layouts/listedit.aspx?List={CurrentList.ID.ToString()}";

            if (IsPostBack)
            {
                return;
            }

            _pageRender = PrepareRenderPage();
            RegisterScript();
        }

        protected string RenderPage()
        {
            return _pageRender;
        }

        protected SPList CurrentList
        {
            get { return _currentList ?? (_currentList = SPContext.Current.Web.Lists[new Guid(Request.QueryString["List"])]); }
        }

        private string PrepareRenderPage()
        {
            var result = new StringBuilder();
            var page = 0;

            if (Request.QueryString["Page"] != null)
            {
                int.TryParse(Request.QueryString["Page"], out page);
            }

            var currentQueryString = Request.QueryString.ToString().Replace("&Page=" + page, string.Empty);

            var fields = _displayableFields.Values.Where(validField => MatchROFields(validField.Id) == false).ToList();

            result.Append("\n<style>.pageNumber, .pageNumber:visited, .pageNumber:active { color:inherit; text-decoration:none;}</style>")
               .Append($"\n{(page > 0 ? $"<a class=\'pageNumber\' href =\'?{currentQueryString}&Page={page - 1}\'>Previous</a>" : "<span>Previous</span>")}<span>&nbsp;&nbsp;&nbsp;</span>");

            for (var i = 0; i < fields.Count; i += PageSize)
            {
                var tooltip = string.Empty;

                for (var j = i; j < Math.Min(fields.Count, i + PageSize); j++)
                {
                    tooltip += $"{fields[j].Title}&#013;";
                }

                var pageNumber = (i + PageSize - 1) / PageSize;
                result.Append($"\n<a class=\'pageNumber\' title=\'{tooltip}\' href=\'?{currentQueryString}&Page={pageNumber}\'>{(page == pageNumber ? $"<b>[{pageNumber}]</b>" : $"[{pageNumber}]")}</a>&nbsp;");
            }

            result.Append($"\n<span>&nbsp;&nbsp;&nbsp;</span>{((page + 1) * PageSize < fields.Count ? $"<a class=\'pageNumber\' href = \'?{currentQueryString}&Page={page + 1}\'>Next</a>" : "<span>Next</span>")}")
               .Append("\n<br><br><br>");

            for (var i = page * PageSize; i < Math.Min(fields.Count, (page + 1) * PageSize); i++)
            {
                var field = fields[i];

                result.Append("\n<table style=\"width:100%\" cellpadding=\"0\" cellspacing=\"0\">")
                   .Append("\n<tr><td colspan=\"2\" class=\"ms-sectionline\" style=\"height:1px;\" ></td></tr>")
                   .Append($"\n<tr><td valign=\"top\" class=\"ms-sectionheader\" style=\"width:120px\">{field.Title}</td>")
                   .Append("\n<td class=\"ms-authoringcontrols\">")
                   .Append($"\n{RenderOptions(field)}")
                   .Append("\n</td></tr><tr><td></td><td class=\"ms-authoringcontrols\" style=\"height:10px;\"></td></tr>")
                   .Append("\n</table>");
            }

            return result.ToString();
        }

        private bool MatchROFields(Guid fieldId)
        {
            return SPBuiltInFieldId.ID == fieldId || SPBuiltInFieldId.Author == fieldId || SPBuiltInFieldId.Editor == fieldId;
        }

        private void UpdateGlobalScript(SPField field, string mode)
        {
            _computeFieldsScript.Append($"ComputeField(\"{field.InternalName}{mode}\");");

            ClientScript.RegisterHiddenField($"Hidden{field.InternalName}{mode}", string.Empty);
        }

        protected void SaveCustomDisplay(object sender, EventArgs e)
        {
            var newFieldProperties = new Dictionary<string, Dictionary<string, string>>();
            CurrentList.ParentWeb.AllowUnsafeUpdates = true;
            string[] modes = {NewText, DisplayText, Edit, EditableText};

            foreach (var field in _displayableFields.Values.Select(currentField => currentField.InternalName))
            {
                newFieldProperties.Add(field, new Dictionary<string, string>());

                foreach (var mode in modes)
                {
                    var hiddenValue = HttpContext.Current.Request.Params[$"Hidden{field}{mode}"];

                    if (string.IsNullOrWhiteSpace(hiddenValue))
                    {
                        continue;
                    }

                    var condition = hiddenValue.Split(";".ToCharArray())[0].ToLower();
                    var spField = CurrentList.Fields.GetFieldByInternalName(field);

                    var conditionAlwaysOrWhere = condition == Always || condition == WhereText;

                    switch (mode)
                    {
                        case NewText:
                            spField.ShowInNewForm = conditionAlwaysOrWhere;
                            break;
                        case Edit:
                            spField.ShowInEditForm = conditionAlwaysOrWhere;
                            break;
                        case DisplayText:
                            spField.ShowInDisplayForm = conditionAlwaysOrWhere;
                            break;
                        default:
                            SystemTrace.WriteLine($"Unexpected value : {mode}");
                            break;
                    }

                    try
                    {
                        spField.Update();
                    }
                    catch (Exception exception)
                    {
                        SystemTrace.WriteLine(exception);
                    }

                    newFieldProperties[field].Add(mode, hiddenValue);
                }
            }

            var gSettings = new GridGanttSettings(CurrentList)
            {
                DisplaySettings = ListDisplayUtils.ConvertToString(newFieldProperties)
            };
            gSettings.SaveSettings(CurrentList);

            CurrentList.ParentWeb.AllowUnsafeUpdates = false;

            SPUtility.Redirect($"listedit.aspx?List={CurrentList.ID}", SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);
        }

        private void ProcessMode(SPField field, string mode, ref bool showEdit, ref string optionValueAlways, ref string optionValueNever)
        {
            if (field == null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            if (mode == NewText)
            {
                if (field.ShowInNewForm == null || (field.ShowInNewForm.Value && MatchROFields(field.Id) == false))
                {
                    optionValueAlways = Selected;
                }
                else
                {
                    optionValueNever = Selected;
                }
            }
            else if (mode == Edit)
            {
                if (field.ShowInEditForm == null)
                {
                    if (field.Type == SPFieldType.Calculated)
                    {
                        optionValueNever = Selected;
                    }
                    else
                    {
                        showEdit = true;
                        optionValueAlways = Selected;
                    }
                }
                else
                {
                    if (field.ShowInEditForm.Value && MatchROFields(field.Id) == false)
                    {
                        showEdit = true;
                        optionValueAlways = Selected;
                    }
                    else
                    {
                        optionValueNever = Selected;
                    }
                }
            }
            else if (mode == DisplayText)
            {
                if (field.ShowInDisplayForm != false)
                {
                    optionValueAlways = Selected;
                }
                else
                {
                    optionValueNever = Selected;
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                base.Dispose();
                OK?.Dispose();
                Cancel?.Dispose();
            }

            _disposed = true;
        }

        public override void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            Dispose(true);
        }
    }
}
