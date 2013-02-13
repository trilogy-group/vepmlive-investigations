using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using EPMLiveCore;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using EPMLiveWebParts.ReportFiltering.DomainServices;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using ReportFiltering;
using ReportFiltering.Repositories;

namespace EPMLiveWebParts
{
    [ToolboxItemAttribute(false)]
    [ToolboxData("<{0}:ReportFilter runat=server></{0}:ReportFilter>")]
    [Guid("f816bcc6-82de-4bb6-98aa-408dd07bf627")]
    [XmlRoot(Namespace = "ReportFilter")]
    public class ReportingFilter : Microsoft.SharePoint.WebPartPages.WebPart, IReportID
    {

#region Fields

        protected Label FieldLabel;
        protected Label TitleLabel;
        protected Label ErrorLabel;
        protected NoEventValidationDropDownList FieldValueAsListBox;
        protected TextBox FieldValueAsTextBox;
        protected PeopleEditor FieldValueAsPeopleEditor;
        protected DateTimeControl FieldValueAsDateTimeControlBeginDate;
        protected DateTimeControl FieldValueAsDateTimeControlEndDate;
        protected NoEventValidationDropDownList TitleListBox;
        protected Button FilterButton;
        protected Button FilterTitlesButton;
        protected DropDownList OperatorDropDownList;
        private ReportFilterUserSettings _persistedSettings;

#endregion

#region Web Part Connections

        [ConnectionProvider("Provider for ID From Report Filter", "ReportIDProvider")]
        public IReportID ReportIDProvider()
        {
            return this;
        }

        [Personalizable]
        public string ReportID
        {
            get { return ID; }
            set {}
        }

#endregion

#region Web Part Properties

        [Category("Report Filter Control Properties")]
        [WebPartStorage(Storage.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string ListToFilterOn { get; set; }

        [Category("Report Filter Control Properties")]
        [WebPartStorage(Storage.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string FieldToFilterOn { get; set; }

        [Category("Report Filter Control Properties")]
        [WebPartStorage(Storage.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool AllowMultipleFieldValuesToBeSelected { get; set; }

        [Category("Report Filter Control Properties")]
        [WebPartStorage(Storage.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool ShowTitleDropDown { get; set; }

        [Category("Report Filter Control Properties")]
        [WebPartStorage(Storage.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool AllowMultipleTitleValuesToBeSelected { get; set; }

        [Category("Report Filter Control Properties")]
        [WebPartStorage(Storage.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool IsPercentageField { get; set; }

        [Category("Report Filter Control Properties")]
        [WebPartStorage(Storage.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string DefaultValueForFieldFilter { get; set; }

#endregion

        protected override void OnInit(EventArgs e)
        {
            AddStyleForPeoplePickerToShowBorder();

            if (SPContext.Current == null) return;

            _persistedSettings = GetPersistedSettings(SPContext.Current.Web);
            if (Page.IsPostBack || HttpGetOriginatedFromThisPage()) return;

            PersistDefaultValuesIfPersistedSettingsAreInvalid(_persistedSettings);
            if (_persistedSettings == null) return;
            RefreshPersistedTitlesWithLatestQueryResults(_persistedSettings);
        }

        protected override void OnPreRender(EventArgs e)
        {
            CssRegistration.Register("/_layouts/epmlive/ReportingFilterWebPart.css");
            GenerateMainJavascript();
        }

        protected override void CreateChildControls()
        {
            if (string.IsNullOrEmpty(ListToFilterOn)) return;
            if (string.IsNullOrEmpty(FieldToFilterOn)) return;

            var web = SPContext.Current.Web;
            var list = web.Lists[ListToFilterOn];
            var field = list.Fields[FieldToFilterOn];

            InitializePageControls();
            PopulateOperatorDropDown(field);

            var mainDiv = new HtmlGenericControl("div");
            mainDiv.Attributes.Add("id", "mainReportFilterDiv");
            mainDiv.Attributes.Add("style", "display: none");

            AddProgressIndicatorToMainDiv(mainDiv);
            AddErrorLabelToMainDiv(mainDiv);
            AddFilterControlsToMainDiv(web, mainDiv, field);
            AddTitleButtonToMainDiv(mainDiv);
            AddTitleDropDownToMainDiv(mainDiv);
            AddFilterButtonToMainDiv(mainDiv);

            Controls.Add(mainDiv);

            SetSelectedFieldValues(_persistedSettings, list);
            PopulateTitles();
            SetSelectedTitleValues(_persistedSettings);
        }

        protected void FilterButtonClick(object sender, EventArgs e)
        {
            var web = SPContext.Current.Web;
            var list = web.Lists[ListToFilterOn];
            var field = list.Fields[FieldToFilterOn];

            var fieldSelection = GetFieldSelection(field, web);
            var titleSelections = GetTitlesToPersist(web, fieldSelection);

            if (fieldSelection.HasErrors)
            {
                DisplayErrors(fieldSelection);
                return;
            }

            var camlQueryOperator = GetCamlQueryOperator();

            var userSettings = new ReportFilterUserSettings
            {
                WebPartId = WebPartHelper.ConvertWebPartIdToGuid(ID),
                SiteId = web.Site.ID,
                WebId = web.ID,
                UserId = web.CurrentUser.ID.ToString(),
                ListId = web.Lists[ListToFilterOn].ID,
                FieldSelection = fieldSelection,
                TitleSelections = titleSelections,
                CamlQueryOperator = camlQueryOperator
            };

            userSettings.FieldSelection.FieldType = field.Type;

            PersistUserSettings(userSettings, web);

            ReloadPage();
        }

        public override ToolPart[] GetToolParts()
        {
            var toolparts = new ToolPart[3];
            toolparts[0] = new ReportingFilterToolpart();
            toolparts[1] = new WebPartToolPart();
            toolparts[2] = new CustomPropertyToolPart();
            return toolparts;
        }

        /// <summary>
        /// Rebuilds the control tree. This is used to refresh the page after the properties are saved in the toolpart.
        /// The toolpart saves the properties after this page has already created child controls, so this allows the toolpart
        /// to recreate the child controls after it saves the properties.
        /// </summary>
        public void RebuildControlTree()
        {
            _persistedSettings = GetPersistedSettings(SPContext.Current.Web);
            PersistDefaultValuesIfPersistedSettingsAreInvalid(_persistedSettings);

            Controls.Clear();
            CreateChildControls();
        }

#region Control Initialization Methods

        /// <summary>
        /// Initializes the page controls.
        /// </summary>
        private void InitializePageControls()
        {
            FieldLabel = new Label {CssClass = "ui-multiselect-label"};
            FilterButton = new Button {CssClass = "button-new silver"};
            FilterTitlesButton = new Button
                                     {
                                         CssClass = "button-new silver",
                                         OnClientClick = "SetFilteredTitles(); return false;"
                                     };
            TitleLabel = new Label { CssClass = "ui-multiselect-label" };
            TitleListBox = new NoEventValidationDropDownList {EnableViewState = false};
            OperatorDropDownList = new DropDownList();
            OperatorDropDownList.Attributes.Add("IsSingleSelect", "IsSingleSelect");
            
            ErrorLabel = new Label();

            FieldValueAsPeopleEditor = new PeopleEditor { EnableViewState = true, Width = new Unit(200, UnitType.Pixel)};

            FieldValueAsListBox = new NoEventValidationDropDownList { EnableViewState = false };
            FieldValueAsListBox.Attributes.Add("DropdownType", "Field");

            if(AllowMultipleFieldValuesToBeSelected)
            {
                FieldValueAsListBox.Attributes.Add("IsMultiSelect", "IsMultiSelect");
            }
            else
            {
                FieldValueAsListBox.Attributes.Add("IsSingleSelect", "IsSingleSelect");
            }

            if (AllowMultipleTitleValuesToBeSelected)
            {
                TitleListBox.Attributes.Add("IsMultiSelect", "IsMultiSelect");
            }
            else
            {
                TitleListBox.Attributes.Add("IsSingleSelect", "IsSingleSelect");
            }

            FieldValueAsTextBox = new TextBox {EnableViewState = false};

            var calendarPopupUrl = SPContext.Current.Web.ServerRelativeUrl + "/_layouts/iframe.aspx";
            FieldValueAsDateTimeControlBeginDate = new DateTimeControl
                                                       {
                                                           DatePickerFrameUrl = calendarPopupUrl,
                                                           EnableViewState = false
                                                       };

            FieldValueAsDateTimeControlEndDate = new DateTimeControl
                                                     {
                                                         DatePickerFrameUrl = calendarPopupUrl,
                                                         EnableViewState = false
                                                     };
        }

        private void PopulateTitles()
        {
            TitleListBox.Items.Clear();

            var web = SPContext.Current.Web;
            var list = web.Lists[ListToFilterOn];
            var field = list.Fields[FieldToFilterOn];

            var fieldSelection = GetFieldSelection(field, web);

            if (!fieldSelection.HasFieldSelections) return;

            var filteredTitles = QueryHelper.GetFilteredTitles(web, fieldSelection);

            if (filteredTitles == null || filteredTitles.Count <= 0) return;

            filteredTitles.Sort(string.Compare);

            if (!fieldSelection.HasErrors)
            {
                foreach (var title in filteredTitles)
                {
                    TitleListBox.Items.Add(title);
                }
            }
            else
            {
                DisplayErrors(fieldSelection);
            }
        }

#endregion

#region Adding Controls to Control Tree Methods

        private void AddStyleForPeoplePickerToShowBorder()
        {
            if (Page.Form == null) return;
            
            var styleForPeoplePickerToShowBorder = new HtmlGenericControl("style");
            styleForPeoplePickerToShowBorder.Attributes.Add("type", "text/css");
            styleForPeoplePickerToShowBorder.InnerHtml = ".ms-inputuserfield{ font-size:8pt; font-family:Verdana,sans-serif; border:1px solid #a5a5a5;} div.ms-inputuserfield a{color:#000000;text-decoration: none;font-weight:normal;font-style:normal;}div.ms-inputuserfield{padding-left:1px;padding-top:2px;}";
            Page.Form.Controls.AddAt(1, styleForPeoplePickerToShowBorder);
        }

        private HtmlTable RenderTableForUi()
        {
            var table = new HtmlTable { Width = "500" };

            return table;
        }

        private void AddProgressIndicatorToMainDiv(HtmlGenericControl mainDiv)
        {
            var progressImage = new HtmlImage { Src = "/_layouts/IMAGES/PROGRESS-CIRCLE-24.GIF" };
            progressImage.Attributes.Add("style", "MARGIN: 30px 10px; VERTICAL-ALIGN: middle");
            var progressLabel = new Label { Text = "Loading ..." };
            progressLabel.Attributes.Add("style", "TEXT-ALIGN: center; MARGIN: 30px 10px; WHITE-SPACE: nowrap; COLOR: black; VERTICAL-ALIGN: middle; OVERFLOW: hidden;font-family:Verdana;font-size:12px;color:#686868;");

            var div = new HtmlGenericControl("div");
            div.Attributes.Add("id", "ProgressDiv");
            div.Controls.Add(progressImage);
            div.Controls.Add(progressLabel);
            div.Attributes.Add("style", "left:40%; padding-right: 20px; padding-left: 20px; vertical-align: middle; border-top-color: #ebeef2; border-right-color: #ebeef2; border-bottom-color: #ebeef2; border-left-color: #ebeef2; border-top-width: 1px; border-right-width: 1px; border-bottom-width: 1px; border-left-width: 1px; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; white-space: nowrap; position: absolute; background-color: rgb(255, 255, 255);");
            mainDiv.Controls.Add(div);
        }

        private void AddFilterControlsToMainDiv(SPWeb web, HtmlGenericControl mainDiv, SPField field)
        {
            switch (field.Type)
            {
                case SPFieldType.Choice:
                    AddFieldFilterControlForChoiceType(mainDiv, field);
                    break;
                case SPFieldType.Lookup:
                    AddFieldFilterControlForLookupType(mainDiv, field, web);
                    break;
                case SPFieldType.Currency:
                case SPFieldType.Integer:
                case SPFieldType.Number:
                case SPFieldType.Text:
                    AddFieldFilterControlForTextType(mainDiv, field, web);
                    break;
                case SPFieldType.User:
                    AddFieldFilterControlForUserType(mainDiv, field, web);
                    break;
                case SPFieldType.DateTime:
                    AddFieldFilterControlForDateType(mainDiv, field, web);
                    break;
            }
        }

        private void AddFieldFilterControlForChoiceType(HtmlGenericControl mainDiv, SPField field)
        {
            foreach (var choice in ((SPFieldChoice)field).Choices)
            {
                FieldValueAsListBox.Items.Add(choice);
            }

            FieldLabel.Text = field.Title;

            var labelDiv = GetControlDiv();
            labelDiv.Controls.Add(FieldLabel);

            var fieldInputControlDiv = GetControlDiv();
            FieldValueAsListBox.Rows = AllowMultipleFieldValuesToBeSelected ? 6 : 1;
            FieldValueAsListBox.Width = new Unit(200, UnitType.Pixel);
            FieldValueAsListBox.SelectionMode = AllowMultipleFieldValuesToBeSelected ? ListSelectionMode.Multiple : ListSelectionMode.Single;
            fieldInputControlDiv.Controls.Add(FieldValueAsListBox);
            
            mainDiv.Controls.Add(labelDiv);
            mainDiv.Controls.Add(fieldInputControlDiv);
        }

        private void AddFieldFilterControlForLookupType(HtmlGenericControl mainDiv, SPField field, SPWeb web)
        {
            var lookupField = (SPFieldLookup)field;

            if (string.IsNullOrEmpty(lookupField.LookupList)) return;

            var lookupList = web.Lists[new Guid(lookupField.LookupList)];

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
                    FieldValueAsListBox.Items.Add(title);
                }
            }

            FieldLabel.Text = field.Title;

            var labelDiv = GetControlDiv();
            labelDiv.Controls.Add(FieldLabel);

            var fieldInputControlDiv = GetControlDiv();
            FieldValueAsListBox.Rows = AllowMultipleFieldValuesToBeSelected ? 6 : 1;
            FieldValueAsListBox.Width = new Unit(200, UnitType.Pixel);
            FieldValueAsListBox.SelectionMode = AllowMultipleFieldValuesToBeSelected ? ListSelectionMode.Multiple : ListSelectionMode.Single;
            fieldInputControlDiv.Controls.Add(FieldValueAsListBox);

            mainDiv.Controls.Add(labelDiv);
            mainDiv.Controls.Add(fieldInputControlDiv);
        }

        private void AddFieldFilterControlForTextType(HtmlGenericControl mainDiv, SPField field, SPWeb web)
        {
            var labelDiv = GetControlDiv();
            labelDiv.Attributes.Add("valign", "top");
            FieldLabel.Text = field.Title;
            labelDiv.Controls.Add(FieldLabel);

            var textBoxDiv = GetControlDiv();
            FieldValueAsTextBox.Width = new Unit(200, UnitType.Pixel);
            textBoxDiv.Controls.Add(FieldValueAsTextBox);

            var operatorDiv = GetControlDiv();
            operatorDiv.Controls.Add(OperatorDropDownList);

            mainDiv.Controls.Add(labelDiv);
            mainDiv.Controls.Add(operatorDiv);
            mainDiv.Controls.Add(textBoxDiv);
        }

        private void AddFieldFilterControlForUserType(HtmlGenericControl mainDiv, SPField field, SPWeb web)
        {
            FieldLabel.Text = field.Title;
            
            var labelDiv = GetControlDiv();
            labelDiv.Attributes.Add("valign", "top");
            labelDiv.Controls.Add(FieldLabel);

            FieldValueAsPeopleEditor.MultiSelect = true;
            FieldValueAsPeopleEditor.AllowTypeIn = true;
            var peoplePickerDiv = GetControlDiv();
            peoplePickerDiv.Controls.Add(FieldValueAsPeopleEditor);

            mainDiv.Controls.Add(labelDiv);
            mainDiv.Controls.Add(peoplePickerDiv);
        }

        private void AddFieldFilterControlForDateType(HtmlGenericControl mainDiv, SPField field, SPWeb web)
        {
            var beginDateLabel = new Label { Text = "Begin Date" };
            var beginDateLabelDiv = GetControlDiv();
            beginDateLabelDiv.Controls.Add(beginDateLabel);

            var endDateLabel = new Label { Text = "End Date" };
            var endDateLabelDiv = GetControlDiv();
            endDateLabelDiv.Controls.Add(endDateLabel);

            FieldValueAsDateTimeControlBeginDate.DateOnly = true;
            var beginDateCalendarDiv = GetControlDiv();
            beginDateCalendarDiv.Controls.Add(FieldValueAsDateTimeControlBeginDate);

            FieldValueAsDateTimeControlEndDate.DateOnly = true;
            var endDateCalendarDiv = GetControlDiv();
            endDateCalendarDiv.Controls.Add(FieldValueAsDateTimeControlEndDate);

            mainDiv.Controls.Add(beginDateLabelDiv);
            mainDiv.Controls.Add(beginDateCalendarDiv);
            mainDiv.Controls.Add(endDateLabelDiv);
            mainDiv.Controls.Add(endDateCalendarDiv);
        }

        private static HtmlGenericControl GetControlDiv()
        {
            var div = new HtmlGenericControl("div");
            div.Attributes.Add("class", "reportFilterDiv");
            return div;
        }

        private static HtmlGenericControl GetControlDivForButton()
        {
            var div = new HtmlGenericControl("div");
            div.Attributes.Add("class", "reportFilterButtonDiv");
            return div;
        }

        private void AddErrorLabelToMainDiv(HtmlGenericControl mainDiv)
        {
            ErrorLabel.Text = string.Empty;

            var errorDiv = GetControlDiv();
            ErrorLabel.Style.Add("color", "red");
            errorDiv.Controls.Add(ErrorLabel);

            mainDiv.Controls.Add(errorDiv);
        }

        private void AddTitleDropDownToMainDiv(HtmlGenericControl mainDiv)
        {
            if (!ShowTitleDropDown) return;

            var titleLabelDiv = GetControlDiv();
            TitleLabel.Text = "Titles";
            titleLabelDiv.Attributes.Add("valign", "top");
            titleLabelDiv.Controls.Add(TitleLabel);

            var titleListDropDownDiv = GetControlDiv();
            TitleListBox.Rows = AllowMultipleTitleValuesToBeSelected ? 6 : 1;
            TitleListBox.Width = new Unit(200, UnitType.Pixel);
            TitleListBox.SelectionMode = AllowMultipleTitleValuesToBeSelected ? ListSelectionMode.Multiple : ListSelectionMode.Single;
            TitleListBox.ID = "TitleListBox";
            titleListDropDownDiv.Controls.Add(TitleListBox);
            
            mainDiv.Controls.Add(titleLabelDiv);
            mainDiv.Controls.Add(titleListDropDownDiv);
        }

        private void AddTitleButtonToMainDiv(HtmlGenericControl mainDiv)
        {
            if (!ShowTitleDropDown) return;

            var filterFieldType = SPContext.Current.Web.Lists[ListToFilterOn].Fields[FieldToFilterOn].Type;
            FilterTitlesButton.Text = "Get Titles";

            if (filterFieldType == SPFieldType.Choice || filterFieldType == SPFieldType.Lookup)
            {
                FilterTitlesButton.Style.Add("display", "none"); // This button is triggered by javascript.
            }
            
            var filterTitlesDiv = GetControlDivForButton();
            filterTitlesDiv.Controls.Add(FilterTitlesButton);            
 
            mainDiv.Controls.Add(filterTitlesDiv);
        }


        private void AddFilterButtonToMainDiv(HtmlGenericControl mainDiv)
        {
            FilterButton.Click += FilterButtonClick;
            FilterButton.Text = "Filter";
            FilterButton.OnClientClick = "CheckAllTitlesIfNoneSelectedAndFilterButtonClicked()";

            var filterButtonDiv = GetControlDivForButton();
            filterButtonDiv.Controls.Add(FilterButton);
            
            mainDiv.Controls.Add(filterButtonDiv);
        }

        private void PopulateOperatorDropDown(SPField field)
        {
            var equalToItem = new ListItem(CamlComparisonOperator.EqualTo.OperatorName, CamlComparisonOperator.EqualTo.Operator);
            var containsItem = new ListItem(CamlComparisonOperator.Contains.OperatorName, CamlComparisonOperator.Contains.Operator);
            var notEqualToItem = new ListItem(CamlComparisonOperator.NotEqualTo.OperatorName, CamlComparisonOperator.NotEqualTo.Operator);
            var beginsWithItem = new ListItem(CamlComparisonOperator.BeginsWith.OperatorName, CamlComparisonOperator.BeginsWith.Operator);
            var greaterThanOrEqualToItem = new ListItem(CamlComparisonOperator.GreaterThanOrEqualTo.OperatorName, CamlComparisonOperator.GreaterThanOrEqualTo.Operator);
            var lessThanOrEqualToItem = new ListItem(CamlComparisonOperator.LessThanOrEqualTo.OperatorName, CamlComparisonOperator.LessThanOrEqualTo.Operator);
            var greaterThanItem = new ListItem(CamlComparisonOperator.GreaterThan.OperatorName, CamlComparisonOperator.GreaterThan.Operator);
            var lessThanItem = new ListItem(CamlComparisonOperator.LessThan.OperatorName, CamlComparisonOperator.LessThan.Operator);

            switch (field.Type)
            {
                case SPFieldType.Text:
                    OperatorDropDownList.Items.Add(equalToItem);
                    OperatorDropDownList.Items.Add(containsItem);
                    OperatorDropDownList.Items.Add(beginsWithItem);
                    OperatorDropDownList.Items.Add(notEqualToItem);
                    break;
                case SPFieldType.Currency:
                case SPFieldType.Integer:
                case SPFieldType.Number:
                    OperatorDropDownList.Items.Add(equalToItem);
                    OperatorDropDownList.Items.Add(notEqualToItem);
                    OperatorDropDownList.Items.Add(greaterThanOrEqualToItem);
                    OperatorDropDownList.Items.Add(lessThanOrEqualToItem);
                    OperatorDropDownList.Items.Add(greaterThanItem);
                    OperatorDropDownList.Items.Add(lessThanItem);
                    break;
            }
        }

        private string GetCamlQueryOperator()
        {
            return OperatorDropDownList != null && OperatorDropDownList.Items.Count > 0 ? OperatorDropDownList.SelectedValue : string.Empty;
        }

        private void DisplayErrors(ReportFilterSelection filteredTitles)
        {
            var errorMsg = new StringBuilder();
            foreach (var error in filteredTitles.Errors)
            {
                errorMsg.Add("{0}<br>", error);
            }

            ErrorLabel.Text = errorMsg.ToString();
        }

#endregion

#region Control State Methods

        private void SetSelectedValueForFieldAsDateTime(ReportFilterUserSettings persistedValues, SPList list)
        {
            if (persistedValues == null) return;
            
            var beginDateValue = persistedValues.FieldSelection.SelectedFields[0];
            var endDateValue = persistedValues.FieldSelection.SelectedFields[1];

            if (string.IsNullOrEmpty(beginDateValue) || string.IsNullOrEmpty(endDateValue)) return;
            
            DateTime beginDate;
            DateTime.TryParse(beginDateValue, out beginDate);

            DateTime endDate;
            DateTime.TryParse(endDateValue, out endDate);

            if (beginDate != DateTime.MinValue)
            {
                FieldValueAsDateTimeControlBeginDate.SelectedDate = DateTime.Parse(beginDateValue);
            }
            
            if (endDate != DateTime.MinValue)
            {
                FieldValueAsDateTimeControlEndDate.SelectedDate = DateTime.Parse(endDateValue);
            }
        }

        private void SetSelectedValueForFieldAsPeopleEditor(ReportFilterUserSettings persistedValues, SPList list)
        {
            if (persistedValues == null) return;

            var fieldValuesAsCsv = persistedValues.FieldSelection.SelectedFields.AsDelimitedString(",");

            if (!string.IsNullOrEmpty(fieldValuesAsCsv))
            {
               FieldValueAsPeopleEditor.CommaSeparatedAccounts = fieldValuesAsCsv;
            }
        }

        private void SetSelectedValueForFieldAsTextBox(ReportFilterUserSettings persistedValues, SPList list)
        {
            if (persistedValues == null) return;
            
            string fieldValues = null;

            //TODO: RHS - This check is also done in at least one other place. Extract method.
            var fieldName = list.Fields[FieldToFilterOn].InternalName;
            if (list.ID == persistedValues.ListId && persistedValues.FieldSelection.InternalFieldName == fieldName)
            {
                fieldValues = persistedValues.FieldSelection.SelectedFields[0];
            }

            FieldValueAsTextBox.Text = fieldValues;

            //TODO: RHS - Add this to default value control in the toolpart?
            if (!string.IsNullOrEmpty(persistedValues.CamlQueryOperator))
            {
                OperatorDropDownList.SelectedValue = persistedValues.CamlQueryOperator;
            }
        }

        private void SetSelectedValueForFieldAsListBox(ReportFilterUserSettings persistedValues, SPList list)
        {
            if (persistedValues == null) return;
            
            if (list.ID != persistedValues.ListId) return;
            if (persistedValues.FieldSelection.FieldNameForDisplay != FieldToFilterOn) return;

            foreach (ListItem item in FieldValueAsListBox.Items)
            {
                var fieldValues = persistedValues.FieldSelection.SelectedFields;
                if (fieldValues.Contains(item.Value))
                {
                    item.Selected = true;
                }

                if (AllowMultipleFieldValuesToBeSelected == false && FieldValueAsListBox.SelectionMode == ListSelectionMode.Multiple) break;
            }
        }

        private void SetSelectedFieldValues(ReportFilterUserSettings persistedValues, SPList spList)
        {
            if (persistedValues == null) return;
            
            var web = SPContext.Current.Web;
            var list = web.Lists[ListToFilterOn];
            var field = list.Fields[FieldToFilterOn];

            switch (field.Type)
            {
                case SPFieldType.Choice:
                case SPFieldType.Lookup:
                    SetSelectedValueForFieldAsListBox(persistedValues, list);
                    break;
                case SPFieldType.Currency:
                case SPFieldType.Integer:
                case SPFieldType.Number:
                case SPFieldType.Text:
                    SetSelectedValueForFieldAsTextBox(persistedValues, list);
                    break;
                case SPFieldType.User:
                    SetSelectedValueForFieldAsPeopleEditor(persistedValues, list);
                    break;
                case SPFieldType.DateTime:
                    SetSelectedValueForFieldAsDateTime(persistedValues, list);
                    break;
            }
        }

        private void SetSelectedTitleValues(ReportFilterUserSettings persistedValues)
        {
            if (persistedValues == null) return;
            if (TitleListBox.Items.Count == 0) return;
            if (!UserHasPersistedSelections(persistedValues)) return;
            if (persistedValues.TitleSelections.Count == 0) return;

            if (TitleListBox.SelectionMode == ListSelectionMode.Single)
            {
                var item = TitleListBox.Items.FindByValue(persistedValues.TitleSelections[0]);
                if (item != null) item.Selected = true;
            }
            else
            {
                //foreach (var selection in persistedValues.TitleSelections)
                //{
                //    var item = TitleListBox.Items.FindByValue(selection);
                //    if (item != null) item.Selected = true;
                //}

                foreach (ListItem item in TitleListBox.Items)
                {
                    if (persistedValues.TitleSelections.Contains(item.Value))
                    {
                        item.Selected = true;
                    }
                }
            }
        }

#endregion

#region Persistence Methods

        private ReportFilterUserSettings GetPersistedSettings(SPWeb web)
        {
            var repo = new ReportFilterUserSettingsRepository(web);
            var searchCriteria = new ReportFilterSearchCriteria
            {
                SiteId = web.Site.ID,
                UserId = web.CurrentUser.ID.ToString(),
                WebId = web.ID,
                WebPartId = WebPartHelper.ConvertWebPartIdToGuid(ReportID)
            };

            ReportFilterUserSettings userSettings = null;

            SPSecurity.RunWithElevatedPrivileges(delegate
                                                     {
                                                         userSettings = repo.GetUserSettings(searchCriteria); 
                                                     });

            return userSettings;
        }

        private void PersistUserSettings(ReportFilterUserSettings userSettings, SPWeb web)
        {
            var repo = new ReportFilterUserSettingsRepository(web);

            SPSecurity.RunWithElevatedPrivileges(() => repo.PersistUserSettings(userSettings));
            
            _persistedSettings = userSettings;
        }

        private ReportFilterSelection GetFieldSelection(SPField field, SPWeb web)
        {
            var returnValue = new ReportFilterSelection
            {
                InternalFieldName = field.InternalName,
                FieldNameForDisplay = field.Title,
                FieldType = field.Type,
                ListToFilterOn = web.Lists[ListToFilterOn].ID
            };

            switch (field.Type)
            {
                case SPFieldType.Choice:
                    foreach (ListItem item in FieldValueAsListBox.Items)
                    {
                        if (item.Selected) returnValue.SelectedFields.Add(item.Value);
                    }
                    break;
                case SPFieldType.Lookup:
                    foreach (ListItem item in FieldValueAsListBox.Items)
                    {
                        if (item.Selected) returnValue.SelectedFields.Add(item.Value);
                    }
                    break;
                case SPFieldType.Currency:
                case SPFieldType.Integer:
                case SPFieldType.Number:
                case SPFieldType.Text:
                    returnValue.CamlComparisonOperator = CamlComparisonOperator.GetCamlOperatorByValue(OperatorDropDownList.SelectedValue);
                    returnValue.SelectedFields.Add(FieldValueAsTextBox.Text);
                    break;
                case SPFieldType.DateTime:
                    returnValue.SelectedFields.Add(FieldValueAsDateTimeControlBeginDate.SelectedDate.ToString("yyyy-MM-dd"));
                    returnValue.SelectedFields.Add(FieldValueAsDateTimeControlEndDate.SelectedDate.ToString("yyyy-MM-dd"));
                    break;
                case SPFieldType.User:
                    var usersAsArray = FieldValueAsPeopleEditor.CommaSeparatedAccounts.Split(new[] { ',' });
                    returnValue.SelectedFields = new List<string>(usersAsArray);
                    break;
            }

            returnValue.IsPercentage = IsPercentageField;

            return returnValue;
        }

        private List<string> GetTitlesToPersist(SPWeb web, ReportFilterSelection fieldSelection)
        {
            if (ShowTitleDropDown)
            {
                return (from ListItem item in TitleListBox.Items where item.Selected select item.Value).ToList();
            }

            return (fieldSelection.HasErrors || fieldSelection.SelectedFields.Count < 1) ? null : QueryHelper.GetFilteredTitles(web, fieldSelection);
        }

        private static bool UserHasPersistedSelections(ReportFilterUserSettings persistedValues)
        {
            return persistedValues.FieldSelection != null && persistedValues.FieldSelection.SelectedFields.Count > 0;
        }

        private void PersistDefaultValuesIfPersistedSettingsAreInvalid(ReportFilterUserSettings userSettings)
        {
            var site = SPContext.Current.Site;
            var web = SPContext.Current.Web;

            if (web.Lists.TryGetList(ListToFilterOn) == null) return;
            if (FieldToFilterOn == null) return;
            if (!web.Lists[ListToFilterOn].Fields.ContainsField(FieldToFilterOn)) return;

            var list = web.Lists[ListToFilterOn];
            var field = list.Fields[FieldToFilterOn];

            if (userSettings.IsValid && PersistedListAndFieldMatchWhatIsInWebPartProperties(userSettings, field, list)) return;

            var userSettingsWithDefaultValues = GetUserSettingsWithDefaultValues(site, web, list, field);
            PersistUserSettings(userSettingsWithDefaultValues, web);
        }

        private static bool PersistedListAndFieldMatchWhatIsInWebPartProperties(ReportFilterUserSettings persistedValues, SPField field, SPList list)
        {
            if ((list.ID == persistedValues.ListId))
            {
                if (field.Type == SPFieldType.Lookup)
                {
                    if (field.InternalName == persistedValues.FieldSelection.FieldNameForDisplay)
                    {
                        return true;
                    }
                }
                else
                {
                    if (field.InternalName == persistedValues.FieldSelection.InternalFieldName)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        private void RefreshPersistedTitlesWithLatestQueryResults(ReportFilterUserSettings persistedSettings)
        {
            if (!UserHasPersistedSelections(persistedSettings)) return;

            var web = SPContext.Current.Web;
            
            var titles = QueryHelper.GetFilteredTitles(web, persistedSettings.FieldSelection);
            UpdateUsersPersistedTitlesBasedOnCurrentData(persistedSettings, web, titles);
        }

        private void UpdateUsersPersistedTitlesBasedOnCurrentData(ReportFilterUserSettings userSettings, SPWeb web, List<string> titles)
        {
            if (userSettings.TitleSelections.Count == 0) return;

            if (ShowTitleDropDown)
            {
                var itemsToRemove = userSettings.TitleSelections.Except(titles);

                userSettings.TitleSelections.RemoveAll(itemsToRemove.Contains);
            }
            else
            {
                userSettings.TitleSelections = titles;
            }

            PersistUserSettings(userSettings, web);
        }

        #endregion

#region Helper Methods

        private void ReloadPage()
        {
            SPUtility.Redirect(HttpContext.Current.Request.RawUrl, SPRedirectFlags.Default, HttpContext.Current);
        }

        private bool HttpGetOriginatedFromThisPage()
        {
            if (Page.Form == null) return false;
            if (Page.Request.UrlReferrer == null) return false;

            return Page.Request.UrlReferrer.PathAndQuery == HttpContext.Current.Request.Path;
        }

        private ReportFilterUserSettings GetUserSettingsWithDefaultValues(SPSite site, SPWeb web, SPList list, SPField field)
        {
            var fieldSelection = new ReportFilterSelection {InternalFieldName = field.InternalName, FieldNameForDisplay = field.Title};
            fieldSelection.SelectedFields.PopulateFromCommaSeparatedString(DefaultValueForFieldFilter);
            fieldSelection.ListToFilterOn = list.ID;
            fieldSelection.FieldType = field.Type;

            var titlesToPersist = QueryHelper.GetFilteredTitles(web, fieldSelection);

            var userSettingsToReturn = new ReportFilterUserSettings
                                           {
                                               FieldSelection = fieldSelection,
                                               WebId = web.ID,
                                               SiteId = site.ID,
                                               ListId = list.ID,
                                               UserId = web.CurrentUser.ID.ToString(),
                                               WebPartId = WebPartHelper.ConvertWebPartIdToGuid(ID),
                                               CamlQueryOperator = GetCamlQueryOperator(),
                                               TitleSelections = titlesToPersist
                                           };

            return userSettingsToReturn;
        }

        private void GenerateMainJavascript()
        {

            if(FieldToFilterOn != null && ListToFilterOn != null && ReportID != null && TitleListBox != null && FieldValueAsListBox != null)
            {
                //TODO: RHS - Create a server control that is a listbox containing the multiselect jquery code. That way any dev can just plop it into a page/web part.
                CssRegistration.Register("/_layouts/epmlive/jquery.multiselect.css");
                CssRegistration.Register("/_layouts/epmlive/styles/themes/grey/jquery-ui-1.8.20.custom.css");

                var initializationJavascript = @"<script language=""Javascript"">   
                                                function registerEpmLiveReportFilterScript()
                                                {
                                                    $('#ProgressDiv')
                                                        .hide()  // hide it initially
                                                        .ajaxStart(function() {
                                                            $(this).show();
                                                        })
                                                        .ajaxStop(function() {
                                                            $(this).hide();
                                                        });                                                            

                                                    $(function() {
                                                        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(registerEpmLiveReportFilterScript);
                                                    });

                                                    $(function () {
                                                        $('[IsMultiSelect=""IsMultiSelect""]').multiselect({
                                                            selectedList: 1
                                                        });
                                                                
                                                        $('#mainReportFilterDiv').show();

                                                        $('[IsSingleSelect=""IsSingleSelect""]').multiselect({
                                                            multiple: false,
                                                            header: 'Select an option',
                                                            noneSelectedText: 'Select an Option',
                                                            selectedList: 1
                                                        });

                                                        $('mainReportFilterDiv').show();

                                                        " + GetScriptToPopulateTitlesBasedOnSelectedFields()  
                                                          + @"
                                                    });
                                                    }

                                                    ExecuteOrDelayUntilScriptLoaded(registerEpmLiveReportFilterScript, 'EPMLive.js');

                                                // This is used to maximize the modal popup when the filter control is used in a dashboard inside a modal.                                                        
                                                function maximizeWindow() {
                                                    var currentDialog = SP.UI.ModalDialog.get_childDialog();
             
                                                    if(currentDialog != null) {
                                                        if(!currentDialog.$S_0) {
                                                            currentDialog.$z();
                                                        }
                                                    }
                                                }
         
                                                ExecuteOrDelayUntilScriptLoaded(maximizeWindow, 'sp.ui.dialog.js');

                                                " + GetScriptToSelectAllTitlesIfNoneSelected() + @"                                                        

                                                function SetFilteredTitles(){
                                                    $.ajax({
                                                            url: L_Menu_BaseUrl + '/_layouts/epmlive/getreportfiltertitles.aspx',
                                                            type: 'POST',
                                                            dataType: 'json',
                                                            data: {
                                                                    ""FieldName"":""" + FieldToFilterOn + @""",
                                                                    ""ListName"":""" + ListToFilterOn + @""",
                                                                    ""FilterOperator"":" + GetScriptForFilterOperator() + @",
                                                                    ""SelectedFields"": GetSelectedFieldsAsCsv(),
                                                                    ""WebPartId"":""" + ReportID + @"""  
                                                                }
                                                    })
                                                    .done(function(data, textStatus, jqXHR) {
                                                        $('#" + TitleListBox.ClientID + @"').empty();
                                                        $.each(data, function(index, val) {
                                                                $('#" + TitleListBox.ClientID + @"').append('<option value=""' + val.title + '"">' + val.title + '</option>');
                                                            });
                                                    })
                                                    .fail(function(jqXHR, textStatus, errorThrown) {
                                                        alert(errorThrown);
                                                    })
                                                    .always(function(){
                                                        $('#" + TitleListBox.ClientID + @"').multiselect('refresh');
                                                    })
                                                }

                                                " + GetScriptForSelectedFieldsAsCsv()
                                                  + GetScriptForPeoplePicker()
                                                  + @"


                                                </script>";


                if(!Page.ClientScript.IsClientScriptBlockRegistered(GetType(), "reportFilterWebPart" + ID))
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "reportFilterWebPart" + ID, initializationJavascript);
                }
            }
        }
        private string GetScriptForFilterOperator()
        {
            if (string.IsNullOrEmpty(OperatorDropDownList.ClientID)) return "\"\"";
            return @"$('#" + OperatorDropDownList.ClientID + @" option:selected').val()";
        }

        private string GetScriptForSelectedFieldsAsCsv()
        {
            if (FilterTitlesButton == null) return "";

            var web = SPContext.Current.Web;
            var list = web.Lists[ListToFilterOn];
            var field = list.Fields[FieldToFilterOn];
            var arrayString = "";

            switch (field.Type)
            {
                case SPFieldType.Choice:
                case SPFieldType.Lookup:
                    arrayString = @"var arr = $('#" + FieldValueAsListBox.ClientID + @" option:selected').map(function() { return this.value; }).get(); 
                                return arr.join(',');
                               ";
                    break;
                case SPFieldType.Currency:
                case SPFieldType.Integer:
                case SPFieldType.Number:
                case SPFieldType.Text:
                    arrayString = @"return $('#" + FieldValueAsTextBox.ClientID + @"').val();";
                    break;
                case SPFieldType.DateTime:
                    arrayString = @"
                                var startDate = new Date($('#" + FieldValueAsDateTimeControlBeginDate.ClientID + @"_Date').val());
                                var startMonth = startDate.getMonth() + 1;
                                var startDateString = startMonth + '/' + startDate.getDate() + '/' + startDate.getFullYear();
                                var endDate = new Date($('#" + FieldValueAsDateTimeControlEndDate.ClientID + @"_Date').val());
                                var endMonth = endDate.getMonth() + 1;
                                var endDateString =  endMonth + '/' + endDate.getDate() + '/' + endDate.getFullYear();
                                return startDateString + ',' + endDateString;";
                    break;
                case SPFieldType.User:
                    arrayString = @"var arr = getPickerValue('" + FieldValueAsPeopleEditor.ClientID + @"_upLevelDiv'); 
                                return arr.join(',');
                               ";
                    break;
            }

            var returnString = string.Format("function GetSelectedFieldsAsCsv(){{ {0} }}", arrayString);

            return returnString;
        }

        private string GetScriptToSelectAllTitlesIfNoneSelected()
        {
            var returnString = string.Empty;

            if (TitleListBox != null)
            {
                returnString = @"function CheckAllTitlesIfNoneSelectedAndFilterButtonClicked()
                                {
                                    var titleListBoxId = '" + TitleListBox.ClientID + @"';                                                            
                                    var titleDropDown = $(titleListBoxId);

                                    if (titleDropDown != null)
                                    {
                                        if($('#' + titleListBoxId).find(':selected').length == 0)
                                        {
                                            $('#' + titleListBoxId).find('option').attr('selected', true);
                                        }
                                    }
                                };";
                
            }

            return returnString;
        }

        private string GetScriptToPopulateTitlesBasedOnSelectedFields()
        {
            var returnString = string.Empty;
            
            if (FilterTitlesButton != null)
            {
                returnString = @"$('[DropDownType=""Field""]').live('multiselectclose',
                                                                    function(event, ui)
                                                                    {
                                                                        SetFilteredTitles();
                                                                    });";
            }

            return returnString;
        }

        private string GetScriptForPeoplePicker()
        {
            const string returnString = @"
                                        function getPickerValue(identifier) { 
                                            var arrayToReturn = [];                                         
                                            var tags = document.getElementsByTagName('DIV'); 
                                            for (var i=0; i < tags.length; i++) { 
                                                var tempString = tags[i].id; 
                                                if (tempString == identifier){ 
                                                    var innerSpans = tags[i].getElementsByTagName('SPAN'); 
                                                    for(var j=0; j < innerSpans.length; j++) { 
                                                        if(innerSpans[j].id == 'content') { 
                                                           arrayToReturn.push(innerSpans[j].innerHTML.trim()); 
                                                        }
                                                    } 
                                                } 
                                            }
                                            return arrayToReturn;
                                        }
                                        ";

            return returnString;
        }

        #endregion

    }

    /// <summary>
    /// This class is to allow you to have a ListBox that you add/remove options using ajax. Without it, you'll get errors
    /// regarding event validation which asp.net has in place to prevent things like CSS attacks. The error you'll see starts with:
    /// "Invalid postback or callback argument..."
    /// Since this class is a different type than the .NET ListBox control (even though it inherits it), it will be ignored from event
    /// validation so you can modify the list contents with ajax.
    /// </summary>
    public class NoEventValidationDropDownList : ListBox
    {
    }
}
