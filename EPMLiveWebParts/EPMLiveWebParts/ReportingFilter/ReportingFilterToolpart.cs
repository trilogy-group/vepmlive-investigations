using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPMLiveCore;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveWebParts
{
    public class ReportingFilterToolpart : ToolPart
    {
        private const string DefaultFieldValue = "<SELECT FIELD>";
        private const string DefaultListValue = "<SELECT LIST>";
        protected DropDownList SharepointListDropDownList;
        protected DropDownList SharepointListFieldDropDownList;
        protected CheckBox ShowTitlesDropDownCheckBox;
        protected CheckBox AllowMultipleFieldsSelectedDropDownCheckBox;
        protected CheckBox AllowMultipleTitlesSelectedDropDownCheckBox;
        protected CheckBox IsPercentageCheckBox;
        protected ListBox DefaultValueAsListBox;
        protected TextBox DefaultValueAsTextBox;
        protected PeopleEditor DefaultValueAsPeopleEditor;
        protected DateTimeControl DefaultValueAsDateTimeBeginDate;
        protected DateTimeControl DefaultValueAsDateTimeEndDate;
        protected UpdatePanel WebControlUpdatePanel;
        
        public ReportingFilterToolpart()
        {
            UseDefaultStyles = true;
            AllowMinimize = true;
            Title = "Report Filter Properties";
        }

        protected override void CreateChildControls()
        {
            InitializeChildControls();

            Controls.Add(SharepointListDropDownList);
            Controls.Add(SharepointListFieldDropDownList);
            Controls.Add(AllowMultipleFieldsSelectedDropDownCheckBox);
            Controls.Add(ShowTitlesDropDownCheckBox);
            Controls.Add(AllowMultipleTitlesSelectedDropDownCheckBox);
            Controls.Add(IsPercentageCheckBox);
            Controls.Add(DefaultValueAsListBox);
            Controls.Add(DefaultValueAsTextBox);
            Controls.Add(DefaultValueAsPeopleEditor);
            Controls.Add(DefaultValueAsDateTimeBeginDate);
            Controls.Add(DefaultValueAsDateTimeEndDate);
        }

        protected override void OnPreRender(EventArgs e)
        {
            PopulateListDropDown();
            
            if (SharepointListDropDownList.SelectedValue == DefaultListValue)
            {
                SetControlState();
            }

            PopulateDefaultValueListBox();
            SetDefaultValueControlState();

            HideOrShowControlsBasedOnType();
        }

        protected override void RenderToolPart(HtmlTextWriter output)
        {
            output.Write("List: ");
            SharepointListDropDownList.RenderControl(output);
            output.Write("<br/>Field: ");
            SharepointListFieldDropDownList.RenderControl(output);
            output.Write("<br/>");
            AllowMultipleFieldsSelectedDropDownCheckBox.RenderControl(output);
            output.Write("<br/>");
            IsPercentageCheckBox.RenderControl(output);
            output.Write("<br/>");
            ShowTitlesDropDownCheckBox.RenderControl(output);
            output.Write("<br/>");
            AllowMultipleTitlesSelectedDropDownCheckBox.RenderControl(output);
            output.Write("<br/><br/>Default Value:<br/>");
            RenderDefaultValueControls(output);
        }

        protected void SharepointListDropDownListSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedSharepointList = SharepointListDropDownList.SelectedValue;

            PopulateFieldsDropDown(selectedSharepointList);
        }
        
        public override void ApplyChanges()
        {
            var reportingFilterWebPart = (ReportingFilter)ParentToolPane.SelectedWebPart;
            
            reportingFilterWebPart.ListToFilterOn = SharepointListDropDownList.SelectedValue;
            reportingFilterWebPart.FieldToFilterOn = SharepointListFieldDropDownList.SelectedValue;
            reportingFilterWebPart.ShowTitleDropDown = ShowTitlesDropDownCheckBox.Checked;
            reportingFilterWebPart.AllowMultipleFieldValuesToBeSelected = AllowMultipleFieldsSelectedDropDownCheckBox.Checked;
            reportingFilterWebPart.AllowMultipleTitleValuesToBeSelected = AllowMultipleTitlesSelectedDropDownCheckBox.Checked;
            reportingFilterWebPart.IsPercentageField = IsPercentageCheckBox.Visible && IsPercentageCheckBox.Checked;

            var field = GetFieldObjectFromSelectedField();

            switch (field.Type)
            {
                case SPFieldType.Choice:
                case SPFieldType.Lookup:
                    reportingFilterWebPart.DefaultValueForFieldFilter = (from ListItem item in DefaultValueAsListBox.Items where item.Selected select item.Value).AsDelimitedString(",");
                    break;
                case SPFieldType.Currency:
                case SPFieldType.Integer:
                case SPFieldType.Number:
                case SPFieldType.Text:
                    reportingFilterWebPart.DefaultValueForFieldFilter = DefaultValueAsTextBox.Text;
                    break;
                case SPFieldType.User:
                    reportingFilterWebPart.DefaultValueForFieldFilter = DefaultValueAsPeopleEditor.CommaSeparatedAccounts;
                    break;
                case SPFieldType.DateTime:
                    reportingFilterWebPart.DefaultValueForFieldFilter = string.Format("{0},{1}", DefaultValueAsDateTimeBeginDate.SelectedDate.ToShortDateString(), DefaultValueAsDateTimeEndDate.SelectedDate.ToShortDateString());
                    break;
            }

            reportingFilterWebPart.RebuildControlTree();

        }

        private void InitializeChildControls()
        {
            
            DefaultValueAsTextBox = new TextBox();
            DefaultValueAsPeopleEditor = new PeopleEditor { ValidatorEnabled = true, MultiSelect = true };
            DefaultValueAsListBox = new ListBox { EnableViewState = true };

            var calendarPopupUrl = SPContext.Current.Web.ServerRelativeUrl + "/_layouts/iframe.aspx";
            DefaultValueAsDateTimeBeginDate = new DateTimeControl
                                                  {
                                                      DateOnly = true,
                                                      DatePickerFrameUrl = calendarPopupUrl
                                                  };
            
            DefaultValueAsDateTimeEndDate = new DateTimeControl
                                                {
                                                    DateOnly = true,
                                                    DatePickerFrameUrl = calendarPopupUrl 
                                                };

            SharepointListDropDownList = new DropDownList { AutoPostBack = true, EnableViewState = true };
            SharepointListDropDownList.SelectedIndexChanged += SharepointListDropDownListSelectedIndexChanged;
            SharepointListFieldDropDownList = new DropDownList { AutoPostBack = true, EnableViewState = true };
            AllowMultipleFieldsSelectedDropDownCheckBox = new CheckBox
                                                              {
                                                                  Text = "Allow multiple \"Field\" values to be selected.",
                                                                  AutoPostBack = true
                                                              };

            ShowTitlesDropDownCheckBox = new CheckBox { Text = "Show Titles Drop down" };
            AllowMultipleTitlesSelectedDropDownCheckBox = new CheckBox { Text = "Allow multiple \"Title\" values to be selected." };
            IsPercentageCheckBox = new CheckBox { Text = "Is Percentage Value" };
        }

        private void PopulateListDropDown()
        {
            var web = SPContext.Current.Web;
            var selectedValue = SharepointListDropDownList.SelectedValue;
            SharepointListDropDownList.Items.Clear();
            SharepointListDropDownList.Items.Add(new ListItem(DefaultListValue));
            
            foreach (SPList list in web.Lists)
            {
                var item = new ListItem(list.Title);
                SharepointListDropDownList.Items.Add(item);
            }

            SharepointListDropDownList.SelectedValue = selectedValue;
        }

        private void PopulateFieldsDropDown(string selectedSharepointList)
        {
            if (selectedSharepointList == DefaultListValue) return;
            
            var web = SPContext.Current.Web;
            var listFields = web.Lists[selectedSharepointList].Fields;

            SharepointListFieldDropDownList.Items.Clear();
            SharepointListFieldDropDownList.Items.Add(new ListItem(DefaultFieldValue));

            var fieldsToSort = new List<string>();

            foreach (SPField field in listFields)
            {
                if (!FieldIsSupportedByThisWebPart(field)) continue;

                var item = new ListItem(field.Title);
                fieldsToSort.Add(item.Text);
            }

            fieldsToSort.Sort(string.Compare);
            SharepointListFieldDropDownList.DataSource = fieldsToSort;
            SharepointListFieldDropDownList.DataBind();
        }

        private void PopulateDefaultValueListBox()
        {
            DefaultValueAsListBox.Items.Clear();
            
            var selectedSharepointListName = SharepointListDropDownList.SelectedValue;
            var selectedSharepointField = SharepointListFieldDropDownList.SelectedValue;

            if (selectedSharepointField == DefaultFieldValue) return;
            if (selectedSharepointListName == DefaultListValue) return;

            var sharepointList = SPContext.Current.Web.Lists[selectedSharepointListName];
            var field = sharepointList.Fields[selectedSharepointField];

            switch (field.Type)
            {
                case SPFieldType.Choice:
                    DefaultValueAsListBox.Rows = AllowMultipleFieldsSelectedDropDownCheckBox.Checked ? 6 : 1;
                    DefaultValueAsListBox.SelectionMode = AllowMultipleFieldsSelectedDropDownCheckBox.Checked ? ListSelectionMode.Multiple : ListSelectionMode.Single;

                    foreach (var choice in ((SPFieldChoice)field).Choices)
                    {
                        DefaultValueAsListBox.Items.Add(choice);
                    }

                    break;
                case SPFieldType.Lookup:
                    DefaultValueAsListBox.Rows = AllowMultipleFieldsSelectedDropDownCheckBox.Checked ? 6 : 1;
                    DefaultValueAsListBox.SelectionMode = AllowMultipleFieldsSelectedDropDownCheckBox.Checked ? ListSelectionMode.Multiple : ListSelectionMode.Single;

                    var lookupField = (SPFieldLookup)field;

                    if (string.IsNullOrEmpty(lookupField.LookupList)) return;
                    var web = SPContext.Current.Web; 
                    var lookUpWeb = web.Site.AllWebs[lookupField.LookupWebId];
                    var lookupList = lookUpWeb.Lists[new Guid(lookupField.LookupList)];

                    var reportFilterSelection = new ReportFilterSelection
                                                    {
                                                        IsLookUp = true,
                                                        ListToFilterOn = lookupList.ID,
                                                        InternalFieldName = lookupField.InternalName,
                                                        FieldNameForDisplay = lookupField.Title,
                                                        LookupFieldType = lookupList.Fields.GetFieldByInternalName(lookupField.LookupField).Type
                                                    };

                    var filteredTitles = QueryHelper.GetFilteredTitles(web, reportFilterSelection);


                    if (filteredTitles == null || filteredTitles.Count <= 0) return;
            
                    filteredTitles.Sort(string.Compare);

                    if (!reportFilterSelection.HasErrors)
                    {
                        foreach (var title in filteredTitles)
                        {
                            DefaultValueAsListBox.Items.Add(title);
                        }
                    }

                    break;
            }
        }

        private void RenderDefaultValueControls(HtmlTextWriter output)
        {
            var selectedSharepointListName = SharepointListDropDownList.SelectedValue;
            var selectedSharepointField = SharepointListFieldDropDownList.SelectedValue;

            if (selectedSharepointField == DefaultFieldValue) return;
            if (selectedSharepointListName == DefaultListValue) return;

            var sharepointList = SPContext.Current.Web.Lists[selectedSharepointListName];
            var field = sharepointList.Fields[selectedSharepointField];

            switch (field.Type)
            {
                case SPFieldType.Choice:
                    DefaultValueAsListBox.RenderControl(output);
                    break;
                case SPFieldType.Lookup:
                    DefaultValueAsListBox.RenderControl(output);
                    break;
                case SPFieldType.Currency:
                case SPFieldType.Integer:
                case SPFieldType.Number:
                case SPFieldType.Text:
                    DefaultValueAsTextBox.RenderControl(output);
                    break;
                case SPFieldType.User:
                    DefaultValueAsPeopleEditor.RenderControl(output);
                    break;
                case SPFieldType.DateTime:
                    DefaultValueAsDateTimeBeginDate.RenderControl(output);
                    DefaultValueAsDateTimeEndDate.RenderControl(output);
                    break;
            }
        }

        private void SetControlState()
        {
            var reportingFilterWebPart = (ReportingFilter) ParentToolPane.SelectedWebPart;

            if (!string.IsNullOrEmpty(reportingFilterWebPart.ListToFilterOn) && SharepointListDropDownList.SelectedValue == DefaultListValue)
            {
                SharepointListDropDownList.SelectedValue = reportingFilterWebPart.ListToFilterOn;
            }

            if (!string.IsNullOrEmpty(SharepointListDropDownList.SelectedValue) && SharepointListDropDownList.SelectedValue != DefaultListValue)
            {
                PopulateFieldsDropDown(SharepointListDropDownList.SelectedValue);
            }

            if (!string.IsNullOrEmpty(reportingFilterWebPart.FieldToFilterOn) && SharepointListDropDownList.SelectedValue != DefaultListValue)
            {
                var foundItem = SharepointListFieldDropDownList.Items.FindByValue(reportingFilterWebPart.FieldToFilterOn);
                if (foundItem != null)
                {
                    SharepointListFieldDropDownList.SelectedValue = reportingFilterWebPart.FieldToFilterOn;
                }
            }

            AllowMultipleFieldsSelectedDropDownCheckBox.Checked = reportingFilterWebPart.AllowMultipleFieldValuesToBeSelected;
            AllowMultipleTitlesSelectedDropDownCheckBox.Checked = reportingFilterWebPart.AllowMultipleTitleValuesToBeSelected;
            IsPercentageCheckBox.Checked = reportingFilterWebPart.IsPercentageField;
            ShowTitlesDropDownCheckBox.Checked = reportingFilterWebPart.ShowTitleDropDown;
        }

        private void SetDefaultValueControlState()
        {
            var reportingFilterWebPart = (ReportingFilter)ParentToolPane.SelectedWebPart;

            if (reportingFilterWebPart.ListToFilterOn != SharepointListDropDownList.SelectedValue ||
                reportingFilterWebPart.FieldToFilterOn != SharepointListFieldDropDownList.SelectedValue ||
                string.IsNullOrEmpty(reportingFilterWebPart.DefaultValueForFieldFilter)) return;

            var field = GetFieldObjectFromSelectedField();

            switch (field.Type)
            {
                case SPFieldType.Choice:
                case SPFieldType.Lookup:
                    var arrayOfSelections = reportingFilterWebPart.DefaultValueForFieldFilter.Split(new[] {','});
                    if (arrayOfSelections.Length == 0) break;

                    foreach (var value in arrayOfSelections)
                    {
                        var item = DefaultValueAsListBox.Items.FindByText(value);
                        if (item != null) item.Selected = true;
                        if (AllowMultipleFieldsSelectedDropDownCheckBox.Checked == false) break;
                    }
                        
                    break;
                case SPFieldType.Currency:
                case SPFieldType.Integer:
                case SPFieldType.Number:
                case SPFieldType.Text:
                    DefaultValueAsTextBox.Text = reportingFilterWebPart.DefaultValueForFieldFilter;
                    break;
                case SPFieldType.User:
                    DefaultValueAsPeopleEditor.CommaSeparatedAccounts = reportingFilterWebPart.DefaultValueForFieldFilter;
                    break;
                case SPFieldType.DateTime:
                    if (string.IsNullOrEmpty(reportingFilterWebPart.DefaultValueForFieldFilter) ||
                        reportingFilterWebPart.DefaultValueForFieldFilter.Split(new[] {','}).Length != 2) break;

                    var selectedDates = reportingFilterWebPart.DefaultValueForFieldFilter.Split(new[] {','});

                    DateTime beginDate;
                    DateTime.TryParse(selectedDates[0], out beginDate);

                    DateTime endDate;
                    DateTime.TryParse(selectedDates[1], out endDate);

                    if (beginDate != DateTime.MinValue)
                    {
                        DefaultValueAsDateTimeBeginDate.SelectedDate = beginDate;
                    }

                    if (endDate != DateTime.MinValue)
                    {
                        DefaultValueAsDateTimeEndDate.SelectedDate = endDate;
                    }

                    break;
            }
        }

        private void HideOrShowControlsBasedOnType()
        {
            var selectedSharepointListName = SharepointListDropDownList.SelectedValue;
            var selectedSharepointField = SharepointListFieldDropDownList.SelectedValue;

            if (selectedSharepointField == DefaultFieldValue) return;
            if (selectedSharepointListName == DefaultListValue) return;

            var sharepointList = SPContext.Current.Web.Lists[selectedSharepointListName];
            var field = sharepointList.Fields[selectedSharepointField];            
            
            switch (field.Type)
            {
                case SPFieldType.Integer:
                case SPFieldType.Number:
                    AllowMultipleFieldsSelectedDropDownCheckBox.Visible = false;
                    IsPercentageCheckBox.Visible = true;
                    break;
                case SPFieldType.DateTime:
                case SPFieldType.Text:
                    AllowMultipleFieldsSelectedDropDownCheckBox.Visible = false;
                    IsPercentageCheckBox.Visible = false;
                    break;
                default:
                    AllowMultipleFieldsSelectedDropDownCheckBox.Visible = true;
                    IsPercentageCheckBox.Visible = false;
                    break;
            }
        }

        private SPField GetFieldObjectFromSelectedField()
        {
            var selectedSharepointListName = SharepointListDropDownList.SelectedValue;
            if (selectedSharepointListName == DefaultListValue) return null;
            var selectedSharepointField = SharepointListFieldDropDownList.SelectedValue;

            var sharepointList = SPContext.Current.Web.Lists[selectedSharepointListName];
            var field = sharepointList.Fields[selectedSharepointField];
            return field;
        }

        private static bool FieldIsSupportedByThisWebPart(SPField field)
        {
            return field.Reorderable && (
                   field.Type == SPFieldType.Text ||
                   field.Type == SPFieldType.Currency ||
                   field.Type == SPFieldType.Integer ||
                   field.Type == SPFieldType.Number ||
                   field.Type == SPFieldType.Choice ||
                   field.Type == SPFieldType.Lookup ||
                   field.Type == SPFieldType.DateTime ||
                   field.Type == SPFieldType.User);
        }

    }
}