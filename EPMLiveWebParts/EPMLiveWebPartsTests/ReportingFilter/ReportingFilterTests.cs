using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Web.UI.HtmlControls.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using EPMLiveWebParts;
using EPMLiveWebParts.Fakes;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using EPMLiveWebParts.ReportFiltering.DomainModel.Fakes;
using EPMLiveWebParts.ReportFiltering.DomainServices.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.SharePoint.WebControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportFiltering.Repositories.Fakes;
using Shouldly;

namespace EPMLiveWebParts.Tests.ReportingFilter
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ReportingFilterTests
    {
        private IDisposable _shimObject;
        private PrivateObject _privateObject;
        private PrivateType _privateType;
        private EPMLiveWebParts.ReportingFilter _reportingFilter;
        private bool _loggerInvoked;
        private const string DummyString = "DummyString";
        private const int DummyCalenderInt = -1;
        private const int DummyInt = 1;
        private const short DummyShort = 1;
        private const double DummyDouble = 1;
        private Uri DummyURI = new Uri("http://localhost/");

        private const string OnInit = "OnInit";
        private const string OnPreRender = "OnPreRender";
        private const string CreateChildControls = "CreateChildControls";
        private const string FilterButtonClick = "FilterButtonClick";
        private const string GetToolParts = "GetToolParts";
        private const string RebuildControlTree = "RebuildControlTree";
        private const string InitializePageControls = "InitializePageControls";
        private const string PopulateTitles = "PopulateTitles";
        private const string RenderTableForUi = "RenderTableForUi";
        private const string AddProgressIndicatorToMainDiv = "AddProgressIndicatorToMainDiv";
        private const string AddFilterControlsToMainDiv = "AddFilterControlsToMainDiv";
        private const string AddFieldFilterControlForChoiceType = "AddFieldFilterControlForChoiceType";
        private const string AddFieldFilterControlForLookupType = "AddFieldFilterControlForLookupType";
        private const string AddFieldFilterControlForTextType = "AddFieldFilterControlForTextType";
        private const string AddFieldFilterControlForDateType = "AddFieldFilterControlForDateType";
        private const string GetControlDiv = "GetControlDiv";
        private const string GetControlDivForButton = "GetControlDivForButton";
        private const string AddErrorLabelToMainDiv = "AddErrorLabelToMainDiv";
        private const string AddTitleDropDownToMainDiv = "AddTitleDropDownToMainDiv";
        private const string AddTitleButtonToMainDiv = "AddTitleButtonToMainDiv";
        private const string AddFilterButtonToMainDiv = "AddFilterButtonToMainDiv";
        private const string PopulateOperatorDropDown = "PopulateOperatorDropDown";
        private const string DisplayErrors = "DisplayErrors";
        private const string GetCamlQueryOperator = "GetCamlQueryOperator";
        private const string GenerateMainJavascript = "GenerateMainJavascript";
        private const string SetSelectedValueForFieldAsDateTime = "SetSelectedValueForFieldAsDateTime";
        private const string SetSelectedValueForFieldAsPeopleEditor = "SetSelectedValueForFieldAsPeopleEditor";
        private const string SetSelectedValueForFieldAsTextBox = "SetSelectedValueForFieldAsTextBox";
        private const string SetSelectedValueForFieldAsListBox = "SetSelectedValueForFieldAsListBox";
        private const string SetSelectedFieldValues = "SetSelectedFieldValues";
        private const string SetSelectedTitleValues = "SetSelectedTitleValues";
        private const string GetPersistedSettings = "GetPersistedSettings";
        private const string PersistUserSettings = "PersistUserSettings";
        private const string GetFieldSelection = "GetFieldSelection";
        private const string GetTitlesToPersist = "GetTitlesToPersist";
        private const string UserHasPersistedSelections = "UserHasPersistedSelections";
        private const string PersistDefaultValuesIfPersistedSettingsAreInvalid = "PersistDefaultValuesIfPersistedSettingsAreInvalid";
        private const string PersistedListAndFieldMatchWhatIsInWebPartProperties = "PersistedListAndFieldMatchWhatIsInWebPartProperties";
        private const string RefreshPersistedTitlesWithLatestQueryResults = "RefreshPersistedTitlesWithLatestQueryResults";
        private const string ReloadPage = "ReloadPage";
        private const string HttpGetOriginatedFromThisPage = "HttpGetOriginatedFromThisPage";
        private const string GetUserSettingsWithDefaultValues = "GetUserSettingsWithDefaultValues";
        private const string GetScriptForFilterOperator = "GetScriptForFilterOperator";
        private const string GetScriptForSelectedFieldsAsCsv = "GetScriptForSelectedFieldsAsCsv";
        private const string GetScriptToSelectAllTitlesIfNoneSelected = "GetScriptToSelectAllTitlesIfNoneSelected";
        private const string GetScriptToPopulateTitlesBasedOnSelectedFields = "GetScriptToPopulateTitlesBasedOnSelectedFields";
        private const string GetScriptForPeoplePicker = "GetScriptForPeoplePicker";
        
        private Label _label = new Label();
        private NoEventValidationDropDownList _noEventValidationDropDownList = new NoEventValidationDropDownList();
        private HtmlGenericControl _htmlGenericControl = new HtmlGenericControl();
        private TextBox _txtBox = new TextBox();
        private Button _button = new Button();
        private DropDownList _dropDownList = new DropDownList();

        [TestInitialize]
        public void TestInitialize()
        {
            _loggerInvoked = false;
            _shimObject = ShimsContext.Create();

            _reportingFilter = new EPMLiveWebParts.ReportingFilter();
            _privateObject = new PrivateObject(_reportingFilter);
            _privateType = new PrivateType(typeof(EPMLiveWebParts.ReportingFilter));
            InitializeSetUp();
        }

        private void InitializeSetUp()
        {
            ShimControl.AllInstances.PageGet = _ => new ShimPage();
            ShimPage.AllInstances.FormGet = _ => new ShimHtmlForm();
            ShimControl.AllInstances.ControlsGet = _ => new ShimControlCollection();
            ShimControlCollection.AllInstances.AddAtInt32Control = (_, _1, _2) => { };
            ShimControlCollection.AllInstances.AddControl = (_, _1) => { };
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = _ => { };
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection();
            ShimSPListCollection.AllInstances.TryGetListString = (_, _1) => new ShimSPList();
            ShimSPListCollection.AllInstances.ItemGetString = (_,_1) => new ShimSPList();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPField();
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_, _1) => true;
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPSite.AllInstances.IDGet = _ => new Guid();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimSPWeb.AllInstances.IDGet = _ => new Guid();
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.AllDayEvent;
            ShimReportingFilter.AllInstances.ListToFilterOnGet = _ => DummyString;
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList();
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPField();
            ShimListControl.AllInstances.ItemsGet = _ => new ShimListItemCollection();
            ShimListItemCollection.AllInstances.AddString = (_, _1) => { };
            ShimReportingFilter.AllInstances.ShowTitleDropDownGet = _ => true;
            ShimReportFilterUserSettings.AllInstances.FieldSelectionGet = _ => new ShimReportFilterSelection();
            ShimReportFilterSelection.AllInstances.SelectedFieldsGet = _ => new List<string>() { new DateTime().ToString(), new DateTime().ToString() };

            ShimLabel.AllInstances.TextGet = _ => DummyString;

            _privateObject.SetFieldOrProperty("_persistedSettings", new ReportFilterUserSettings());
            _privateObject.SetFieldOrProperty("TitleListBox", _noEventValidationDropDownList);
            _privateObject.SetFieldOrProperty("FieldValueAsListBox", _noEventValidationDropDownList);
            _privateObject.SetFieldOrProperty("FieldLabel", _label);
            _privateObject.SetFieldOrProperty("FieldValueAsTextBox",_txtBox);
            _privateObject.SetFieldOrProperty("JqueryDatePickerBeginDate", _txtBox);
            _privateObject.SetFieldOrProperty("JqueryDatePickerEndDate", _txtBox);
            _privateObject.SetFieldOrProperty("ErrorLabel", _label);
            _privateObject.SetFieldOrProperty("TitleLabel", _label);
            _privateObject.SetFieldOrProperty("FilterTitlesButton", _button);
            _privateObject.SetFieldOrProperty("FilterButton", _button);
            _privateObject.SetFieldOrProperty("OperatorDropDownList",_dropDownList);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimObject.Dispose();
            _noEventValidationDropDownList?.Dispose();
            _label?.Dispose();
            _htmlGenericControl?.Dispose();
            _txtBox?.Dispose();
            _button?.Dispose();
            _dropDownList?.Dispose();
        }

        [TestMethod]
        public void OnInit_EventArgsIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { EventArgs.Empty };
            ShimPage.AllInstances.IsPostBackGet = _ => false;
            ShimReportingFilter.AllInstances.ReportIDGet = _ => new Guid().ToString();
            ShimReportingFilter.AllInstances.HttpGetOriginatedFromThisPage = _ => false;
            ShimReportingFilter.PersistedListAndFieldMatchWhatIsInWebPartPropertiesReportFilterUserSettingsSPFieldSPList =
                (_, _1, _2) => false;
            ShimReportingFilter.AllInstances.GetUserSettingsWithDefaultValuesSPSiteSPWebSPListSPField =
                (_, _1, _2, _3, _4) => new ReportFilterUserSettings();
            ShimReportingFilter.AllInstances.PersistUserSettingsReportFilterUserSettingsSPWeb =
                (_, _1, _2) => { };
            ShimReportingFilter.AllInstances.GetPersistedSettingsSPWeb = (_, _1) => new ReportFilterUserSettings();
            ShimReportingFilter.AllInstances.PersistDefaultValuesIfPersistedSettingsAreInvalidReportFilterUserSettings =
                (_, _1) => { };
            ShimQueryHelper.GetFilteredTitlesSPWebReportFilterSelection = (_, _1) => new List<string>() { DummyString };

            // Act
            var actualResult = _privateObject.Invoke(
                OnInit,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void OnPreRender_EventArgsIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { EventArgs.Empty };
            ShimReportingFilter.AllInstances.GenerateMainJavascript = _ => { };

            // Act
            var actualResult = _privateObject.Invoke(
                OnPreRender,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void CreateChildControls_InputIsEmpty_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportingFilter.AllInstances.ListToFilterOnGet = _ => DummyString;
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimReportingFilter.AllInstances.InitializePageControls = _ => { };
            ShimReportingFilter.AllInstances.PopulateOperatorDropDownSPField = (_, _1) => { };
            ShimReportingFilter.AllInstances.AddProgressIndicatorToMainDivHtmlGenericControl = (_, _1) => { };
            ShimReportingFilter.AllInstances.AddErrorLabelToMainDivHtmlGenericControl = (_, _1) => { };
            ShimReportingFilter.AllInstances.AddFilterControlsToMainDivSPWebHtmlGenericControlSPField = (_, _1, _2, _3) => { };
            ShimReportingFilter.AllInstances.AddTitleButtonToMainDivHtmlGenericControl = (_, _1) => { };
            ShimReportingFilter.AllInstances.AddTitleDropDownToMainDivHtmlGenericControl = (_, _1) => { };
            ShimReportingFilter.AllInstances.AddFilterButtonToMainDivHtmlGenericControl = (_, _1) => { };
            ShimReportingFilter.AllInstances.SetSelectedFieldValuesReportFilterUserSettingsSPList = (_, _1, _2) => { };
            ShimReportingFilter.AllInstances.PopulateTitles = _ => { };
            ShimReportingFilter.AllInstances.SetSelectedTitleValuesReportFilterUserSettings = (_, _1) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                CreateChildControls,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void FilterButtonClick_SenderAndEventArgsIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { this, EventArgs.Empty };
            ShimReportingFilter.AllInstances.GetFieldSelectionSPFieldSPWeb = (_, _1, _2) => new ReportFilterSelection()
            {
                HasErrors = false
            };
            ShimReportingFilter.AllInstances.GetTitlesToPersistSPWebReportFilterSelection = (_, _1, _2) => new List<string>() { DummyString };
            ShimReportingFilter.AllInstances.GetCamlQueryOperator = _ => DummyString;
            ShimReportingFilter.AllInstances.PersistUserSettingsReportFilterUserSettingsSPWeb = (_, _1, _2) => { };
            ShimReportingFilter.AllInstances.ReloadPage = _ => { };
            ShimWebPartHelper.ConvertWebPartIdToGuidString = _ => new Guid();
            ShimReportFilterUserSettings.AllInstances.FieldSelectionGet = _ => new ShimReportFilterSelection();
            ShimReportFilterSelection.AllInstances.FieldTypeGet = _ => SPFieldType.AllDayEvent;
            ShimReportFilterUserSettings.Constructor = _ => new ShimReportFilterUserSettings();
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                FilterButtonClick,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GetToolParts_InputIsEmpty_ReturnListOfToolPart()
        {
            // Arrange
            var parameters = new object[] { };

            // Act
            var actualResult = _privateObject.Invoke(
                GetToolParts,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void RebuildControlTree_InputIsEmpty_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportingFilter.AllInstances.GetPersistedSettingsSPWeb = (_, _1) => new ShimReportFilterUserSettings();
            ShimReportingFilter.AllInstances.PersistDefaultValuesIfPersistedSettingsAreInvalidReportFilterUserSettings =
                (_, _1) => { };
            ShimControlCollection.AllInstances.Clear = _ => { };
            ShimReportingFilter.AllInstances.CreateChildControls = _ => { };

            // Act
            var actualResult = _privateObject.Invoke(
                RebuildControlTree,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void InitializePageControls_InputIsEmpty_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportingFilter.AllInstances.AllowMultipleFieldValuesToBeSelectedGet = _ => true;
            ShimReportingFilter.AllInstances.AllowMultipleTitleValuesToBeSelectedGet = _ => true;
            
            // Act
            var actualResult = _privateObject.Invoke(
                InitializePageControls,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void InitializePageControls_InputIsEmptyAndValuesAreFalse_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportingFilter.AllInstances.AllowMultipleFieldValuesToBeSelectedGet = _ => false;
            ShimReportingFilter.AllInstances.AllowMultipleTitleValuesToBeSelectedGet = _ => false;

            // Act
            var actualResult = _privateObject.Invoke(
                InitializePageControls,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void PopulateTitles_InputIsEmpty_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { };
            ShimListControl.AllInstances.ItemsGet = _ => new ShimListItemCollection();
            ShimListItemCollection.AllInstances.Clear = _ => { };
            ShimReportingFilter.AllInstances.GetFieldSelectionSPFieldSPWeb = (_, _1, _2) => new ShimReportFilterSelection();
            ShimReportFilterSelection.AllInstances.HasFieldSelectionsGet = _ => true;
            ShimQueryHelper.GetFilteredTitlesSPWebReportFilterSelection = (_, _1) => new List<string>() { DummyString };
            ShimReportFilterSelection.AllInstances.HasErrorsGet = _ => false;
            ShimListItemCollection.AllInstances.AddString = (_, _1) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                PopulateTitles,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void RenderTableForUi_InputIsEmpty_ReturnHtmlTable()
        {
            // Arrange
            var parameters = new object[] { };
            
            // Act
            var actualResult = _privateObject.Invoke(
                RenderTableForUi,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void AddProgressIndicatorToMainDiv_HtmlGenericControlIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimHtmlGenericControl().Instance };

            // Act
            var actualResult = _privateObject.Invoke(
                AddProgressIndicatorToMainDiv,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddFilterControlsToMainDiv_SPWebAndHtmlGenericControlIsNotNullAndSPFieldIsChoice_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance, new ShimHtmlGenericControl().Instance, new ShimSPField().Instance };
            ShimReportingFilter.AllInstances.AddFieldFilterControlForChoiceTypeHtmlGenericControlSPField = (_, _1, _2) => { };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Choice;
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection();
            ShimReportingFilter.GetControlDiv = () => new ShimHtmlGenericControl();


            // Act
            var actualResult = _privateObject.Invoke(
                AddFilterControlsToMainDiv,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddFilterControlsToMainDiv_SPWebAndHtmlGenericControlIsNotNullAndSPFieldIsLookup_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance, new ShimHtmlGenericControl().Instance, new ShimSPField().Instance };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimReportingFilter.AllInstances.AddFieldFilterControlForLookupTypeHtmlGenericControlSPFieldSPWeb = (_, _1, _2, _3) => { };
            
            // Act
            var actualResult = _privateObject.Invoke(
                AddFilterControlsToMainDiv,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddFilterControlsToMainDiv_SPWebAndHtmlGenericControlIsNotNullAndSPFieldIsText_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance, new ShimHtmlGenericControl().Instance, new ShimSPField().Instance };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Text;
            ShimReportingFilter.AllInstances.AddFieldFilterControlForTextTypeHtmlGenericControlSPFieldSPWeb = (_, _1, _2, _3) => { };
            
            // Act
            var actualResult = _privateObject.Invoke(
                AddFilterControlsToMainDiv,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddFilterControlsToMainDiv_SPWebAndHtmlGenericControlIsNotNullAndSPFieldIsUser_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance, new ShimHtmlGenericControl().Instance, new ShimSPField().Instance };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.User;
            ShimReportingFilter.AllInstances.AddFieldFilterControlForUserTypeHtmlGenericControlSPFieldSPWeb = (_, _1, _2, _3) => { };
            
            // Act
            var actualResult = _privateObject.Invoke(
                AddFilterControlsToMainDiv,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddFilterControlsToMainDiv_SPWebAndHtmlGenericControlIsNotNullAndSPFieldIsDateTime_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance, new ShimHtmlGenericControl().Instance, new ShimSPField().Instance };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.DateTime;
            ShimReportingFilter.AllInstances.AddFieldFilterControlForDateTypeHtmlGenericControlSPFieldSPWeb = (_, _1, _2, _3) => { };
            
            // Act
            var actualResult = _privateObject.Invoke(
                AddFilterControlsToMainDiv,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddFieldFilterControlForChoiceType_HtmlGenericControlAndSPFieldIsNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimHtmlGenericControl().Instance, new ShimSPFieldChoice().Instance };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Choice;
            ShimSPFieldMultiChoice.AllInstances.ChoicesGet = _ => new StringCollection();
            ShimReportingFilter.GetControlDiv = () => new ShimHtmlGenericControl();
            
            // Act
            var actualResult = _privateObject.Invoke(
                AddFieldFilterControlForChoiceType,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddFieldFilterControlForLookupType_HtmlGenericControlAndSPFieldAndSpWebIsNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimHtmlGenericControl().Instance, new ShimSPFieldLookup().Instance, new ShimSPWeb().Instance };
            ShimReportingFilter.GetControlDiv = () => new HtmlGenericControl();
            ShimSPFieldLookup.AllInstances.LookupListGet = _ => DummyString;
            ShimSPListCollection.AllInstances.ItemGetGuid = (_, _1) => new ShimSPList();
            ShimReportFilterSelection.Constructor = _ => new ShimReportFilterSelection();
            ShimSPList.AllInstances.IDGet = _ => new Guid();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.TitleGet = _ => DummyString;
            ShimSPFieldCollection.AllInstances.GetFieldByInternalNameString = (_, _1) => new ShimSPField();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldLookup.AllInstances.LookupFieldGet = _ => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.File;
            ShimQueryHelper.GetFilteredTitlesSPWebReportFilterSelection = (_, _1) => new List<string>() { DummyString };
            ShimReportFilterSelection.AllInstances.HasErrorsGet = _ => false;
            ShimSPFieldLookup.AllInstances.LookupListGet = _ => new Guid().ToString();

            // Act
            var actualResult = _privateObject.Invoke(
                AddFieldFilterControlForLookupType,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddFieldFilterControlForTextType_HtmlGenericControlAndSPFieldAndSpWebIsNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimHtmlGenericControl().Instance, new ShimSPField().Instance, new ShimSPWeb().Instance };
            ShimReportingFilter.GetControlDiv = () => new HtmlGenericControl();
            
            // Act
            var actualResult = _privateObject.Invoke(
                AddFieldFilterControlForTextType,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddFieldFilterControlForDateType_HtmlGenericControlAndSPFieldAndSpWebIsNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimHtmlGenericControl().Instance, new ShimSPField().Instance, new ShimSPWeb().Instance };
            ShimReportingFilter.GetControlDiv = () => new HtmlGenericControl();

            // Act
            var actualResult = _privateObject.Invoke(
                AddFieldFilterControlForDateType,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GetControlDiv_InputIsEmpty_ReturnHtmlGenericControl()
        {
            // Arrange
            var parameters = new object[] { };

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetControlDiv,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetControlDivForButton_InputIsEmpty_ReturnHtmlGenericControl()
        {
            // Arrange
            var parameters = new object[] { };

            // Act
            var actualResult = _privateType.InvokeStatic(
                GetControlDivForButton,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void AddErrorLabelToMainDiv_HtmlGenericControlIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimHtmlGenericControl().Instance };
            ShimReportingFilter.GetControlDiv = () => new HtmlGenericControl();

            // Act
            var actualResult = _privateObject.Invoke(
                AddErrorLabelToMainDiv,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddTitleDropDownToMainDiv_HtmlGenericControlIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimHtmlGenericControl().Instance };
            ShimReportingFilter.GetControlDiv = () => new HtmlGenericControl();

            // Act
            var actualResult = _privateObject.Invoke(
                AddTitleDropDownToMainDiv,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddTitleButtonToMainDiv_HtmlGenericControlIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimHtmlGenericControl().Instance };
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;

            // Act
            var actualResult = _privateObject.Invoke(
                AddTitleButtonToMainDiv,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void AddFilterButtonToMainDiv_HtmlGenericControlIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimHtmlGenericControl().Instance };
            ShimReportingFilter.AllInstances.FilterButtonClickObjectEventArgs = (_, _1, _2) => { };
            ShimReportingFilter.GetControlDivForButton = () => new HtmlGenericControl();

            // Act
            var actualResult = _privateObject.Invoke(
                AddFilterButtonToMainDiv,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void PopulateOperatorDropDown_SPFieldIsNotNullTypeIsText_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPField().Instance };
            ShimListItem.ConstructorStringString = (_, _1, _2) => new ShimListItem();
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Text;

            // Act
            var actualResult = _privateObject.Invoke(
                PopulateOperatorDropDown,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void PopulateOperatorDropDown_SPFieldIsNotNullTypeIsNumber_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimSPField().Instance };
            ShimListItem.ConstructorStringString = (_, _1, _2) => new ShimListItem();
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Number;

            // Act
            var actualResult = _privateObject.Invoke(
                PopulateOperatorDropDown,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GetCamlQueryOperator_InputIsEmpty_ReturnEmptyString()
        {
            // Arrange
            var parameters = new object[] { };
            ShimListControl.AllInstances.SelectedValueGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                GetCamlQueryOperator,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void DisplayErrors_SPFieldIsNotNullTypeIsNumber_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterSelection().Instance };
            ShimReportFilterSelection.AllInstances.ErrorsGet = _ => new List<string>() { DummyString };

            // Act
            var actualResult = _privateObject.Invoke(
                DisplayErrors,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GenerateMainJavascript_InputIsEmpty_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] {  };
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimReportingFilter.AllInstances.ListToFilterOnGet = _ => DummyString;
            ShimReportingFilter.AllInstances.ReportIDGet = _ => DummyString;
            ShimPage.AllInstances.ClientScriptGet = _ => new ShimClientScriptManager();
            ShimClientScriptManager.AllInstances.IsClientScriptBlockRegisteredTypeString = (_, _1, _2) => false;

            // Act
            var actualResult = _privateObject.Invoke(
                GenerateMainJavascript,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void SetSelectedValueForFieldAsDateTime_ReportFilterUserSettingsAndSPListIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance, new ShimSPList().Instance };


            // Act
            var actualResult = _privateObject.Invoke(
                SetSelectedValueForFieldAsDateTime,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void SetSelectedValueForFieldAsPeopleEditor_ReportFilterUserSettingsAndSPListIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance, new ShimSPList().Instance };
            ShimReportFilterUserSettings.AllInstances.FieldSelectionGet = _ => new ShimReportFilterSelection();
            ShimReportFilterSelection.AllInstances.SelectedFieldsGet = _ => new List<string>();
            
            // Act
            var actualResult = _privateObject.Invoke(
                SetSelectedValueForFieldAsPeopleEditor,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void SetSelectedValueForFieldAsTextBox_ReportFilterUserSettingsAndSPListIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance, new ShimSPList().Instance };
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPList.AllInstances.IDGet = _ => new Guid();
            ShimReportFilterUserSettings.AllInstances.ListIdGet = _ => new Guid();
            ShimReportFilterUserSettings.AllInstances.CamlQueryOperatorGet = _ => DummyString;
            ShimReportFilterUserSettings.AllInstances.FieldSelectionGet = _ => new ShimReportFilterSelection();
            ShimReportFilterSelection.AllInstances.InternalFieldNameGet = _ => DummyString;
            
            // Act
            var actualResult = _privateObject.Invoke(
                SetSelectedValueForFieldAsTextBox,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void SetSelectedValueForFieldAsListBox_ReportFilterUserSettingsAndSPListIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance, new ShimSPList().Instance };
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimSPList.AllInstances.IDGet = _ => new Guid();
            ShimReportFilterUserSettings.AllInstances.ListIdGet = _ => new Guid();
            ShimReportFilterUserSettings.AllInstances.FieldSelectionGet = _ => new ShimReportFilterSelection();
            ShimReportFilterSelection.AllInstances.FieldNameForDisplayGet = _ => DummyString;
            ShimReportFilterSelection.AllInstances.SelectedFieldsGet = _ => new List<string>() { DummyString };
            ShimListItem.AllInstances.ValueGet = _ => DummyString;
            ShimReportingFilter.AllInstances.AllowMultipleFieldValuesToBeSelectedGet = _ => false;
            ShimListBox.AllInstances.SelectionModeGet = _ => ListSelectionMode.Multiple;
            var listListItem = new List<ListItem>() { new ShimListItem() };
            ShimListControl.AllInstances.ItemsGet = _ => new ShimListItemCollection().Bind(listListItem);

            // Act
            var actualResult = _privateObject.Invoke(
                SetSelectedValueForFieldAsListBox,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void SetSelectedFieldValues_ReportFilterUserSettingsAndSPListIsNotNullAndTypeIsLookup_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance, new ShimSPList().Instance };
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimReportingFilter.AllInstances.ListToFilterOnGet = _ => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimReportingFilter.AllInstances.SetSelectedValueForFieldAsListBoxReportFilterUserSettingsSPList =
                (_, _1, _2) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                SetSelectedFieldValues,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void SetSelectedFieldValues_ReportFilterUserSettingsAndSPListIsNotNullAndTypeIsText_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance, new ShimSPList().Instance };
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimReportingFilter.AllInstances.ListToFilterOnGet = _ => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Text;
            ShimReportingFilter.AllInstances.SetSelectedValueForFieldAsTextBoxReportFilterUserSettingsSPList =
                (_, _1, _2) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                SetSelectedFieldValues,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void SetSelectedFieldValues_ReportFilterUserSettingsAndSPListIsNotNullAndTypeIsUser_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance, new ShimSPList().Instance };
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimReportingFilter.AllInstances.ListToFilterOnGet = _ => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.User;
            ShimReportingFilter.AllInstances.SetSelectedValueForFieldAsPeopleEditorReportFilterUserSettingsSPList =
                (_, _1, _2) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                SetSelectedFieldValues,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void SetSelectedFieldValues_ReportFilterUserSettingsAndSPListIsNotNullAndTypeIsDateTime_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance, new ShimSPList().Instance };
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimReportingFilter.AllInstances.ListToFilterOnGet = _ => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.DateTime;
            ShimReportingFilter.AllInstances.SetSelectedValueForFieldAsDateTimeReportFilterUserSettingsSPList =
                (_, _1, _2) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                SetSelectedFieldValues,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void SetSelectedTitleValues_ReportFilterUserSettingsIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance };
            ShimListControl.AllInstances.ItemsGet = _ => new ShimListItemCollection();
            ShimListItemCollection.AllInstances.CountGet = _ => DummyInt;
            ShimReportingFilter.UserHasPersistedSelectionsReportFilterUserSettings = _ => true;
            ShimReportFilterUserSettings.AllInstances.TitleSelectionsGet = _ => new List<string>() { DummyString };
            ShimListBox.AllInstances.SelectionModeGet = _ => ListSelectionMode.Single;
            ShimListItemCollection.AllInstances.FindByValueString = (_, _1) => new ShimListItem();
            ShimReportFilterUserSettings.AllInstances.TitleSelectionsGet = _ => new List<string>() { DummyString };
            
            // Act
            var actualResult = _privateObject.Invoke(
                SetSelectedTitleValues,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void SetSelectedTitleValues_ReportFilterUserSettingsIsNotNullValueNotMatched_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance };
            var listListItem = new List<ListItem>() { new ShimListItem() };
            ShimListControl.AllInstances.ItemsGet = _ => new ShimListItemCollection().Bind(listListItem);
            ShimListItemCollection.AllInstances.CountGet = _ => DummyInt;
            ShimReportingFilter.UserHasPersistedSelectionsReportFilterUserSettings = _ => true;
            ShimReportFilterUserSettings.AllInstances.TitleSelectionsGet = _ => new List<string>() { DummyString };
            ShimListBox.AllInstances.SelectionModeGet = _ => ListSelectionMode.Multiple;
            ShimListItemCollection.AllInstances.FindByValueString = (_, _1) => new ShimListItem();
            ShimReportFilterUserSettings.AllInstances.TitleSelectionsGet = _ => new List<string>() { DummyString };
            ShimListItem.AllInstances.ValueGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                SetSelectedTitleValues,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GetPersistedSettings_SPWebIsNotNull_ReturnReportFilterUserSettingsIsNull()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance };
            ShimReportFilterUserSettingsRepository.ConstructorSPWeb = (_, _1) => new ShimReportFilterUserSettingsRepository();
            ShimReportFilterSearchCriteria.Constructor = _ => new ShimReportFilterSearchCriteria();
            ShimSPSite.AllInstances.IDGet = _ => new Guid();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = _ => { };
            ShimReportFilterUserSettingsRepository.AllInstances.GetUserSettingsReportFilterSearchCriteria = (_, _1) => new ShimReportFilterUserSettings();
            ShimReportingFilter.AllInstances.ReportIDGet = _ => new Guid().ToString();

            // Act
            var actualResult = _privateObject.Invoke(
                GetPersistedSettings,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void PersistUserSettings_ReportFilterUserSettingsAndSPWebIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance, new ShimSPWeb().Instance };
            ShimReportFilterUserSettingsRepository.ConstructorSPWeb = (_, _1) => new ShimReportFilterUserSettings();
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = _ => { };
            ShimReportFilterUserSettingsRepository.AllInstances.PersistUserSettingsReportFilterUserSettings = (_, _1) => { };
            
            // Act
            var actualResult = _privateObject.Invoke(
                PersistUserSettings,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void GetFieldSelection_SpFieldAndSPWebIsNotNullTypeIsChoice_ReturnReportFilterSelection()
        {
            // Arrange
            var parameters = new object[] { new ShimSPField().Instance, new ShimSPWeb().Instance };
            ShimReportFilterSelection.Constructor = _ => new ShimReportFilterSelection();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.TitleGet = _ => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Choice;
            ShimReportingFilter.AllInstances.ListToFilterOnGet = _ => DummyString;
            ShimSPList.AllInstances.IDGet = _ => new Guid();
            var listListItem = new List<ListItem>() { new ShimListItem() };
            ShimListControl.AllInstances.ItemsGet = _ => new ShimListItemCollection().Bind(listListItem);
            ShimListItem.AllInstances.SelectedGet = _ => true;
            ShimReportFilterSelection.AllInstances.SelectedFieldsGet = _ => new List<string>() { DummyString };
            ShimListItem.AllInstances.ValueGet = _ => DummyString;
            ShimReportingFilter.AllInstances.IsPercentageFieldGet = _ => true;

            // Act
            var actualResult = _privateObject.Invoke(
                GetFieldSelection,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetFieldSelection_SpFieldAndSPWebIsNotNullTypeIsLookup_ReturnReportFilterSelection()
        {
            // Arrange
            var parameters = new object[] { new ShimSPField().Instance, new ShimSPWeb().Instance };
            ShimReportFilterSelection.Constructor = _ => new ShimReportFilterSelection();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.TitleGet = _ => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimReportingFilter.AllInstances.ListToFilterOnGet = _ => DummyString;
            ShimSPList.AllInstances.IDGet = _ => new Guid();
            var listListItem = new List<ListItem>() { new ShimListItem() };
            ShimListControl.AllInstances.ItemsGet = _ => new ShimListItemCollection().Bind(listListItem);
            ShimListItem.AllInstances.SelectedGet = _ => true;
            ShimReportFilterSelection.AllInstances.SelectedFieldsGet = _ => new List<string>() { DummyString };
            ShimListItem.AllInstances.ValueGet = _ => DummyString;
            ShimReportingFilter.AllInstances.IsPercentageFieldGet = _ => true;

            // Act
            var actualResult = _privateObject.Invoke(
                GetFieldSelection,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetFieldSelection_SpFieldAndSPWebIsNotNullTypeIsText_ReturnReportFilterSelection()
        {
            // Arrange
            var parameters = new object[] { new ShimSPField().Instance, new ShimSPWeb().Instance };
            ShimReportFilterSelection.Constructor = _ => new ShimReportFilterSelection();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.TitleGet = _ => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Text;
            ShimListControl.AllInstances.SelectedValueGet = _ => DummyString;
            ShimReportFilterSelection.AllInstances.SelectedFieldsGet = _ => new List<string>() { DummyString };
            ShimReportingFilter.AllInstances.IsPercentageFieldGet = _ => true;

            // Act
            var actualResult = _privateObject.Invoke(
                GetFieldSelection,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetFieldSelection_SpFieldAndSPWebIsNotNullTypeIsDateTime_ReturnReportFilterSelection()
        {
            // Arrange
            var parameters = new object[] { new ShimSPField().Instance, new ShimSPWeb().Instance };
            ShimReportFilterSelection.Constructor = _ => new ShimReportFilterSelection();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.TitleGet = _ => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.DateTime;
            ShimReportFilterSelection.AllInstances.SelectedFieldsGet = _ => new List<string>() { DummyString };
            ShimTextBox.AllInstances.TextGet = _ => new DateTime().ToString();
            ShimReportingFilter.AllInstances.IsPercentageFieldGet = _ => true;

            // Act
            var actualResult = _privateObject.Invoke(
                GetFieldSelection,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetFieldSelection_SpFieldAndSPWebIsNotNullTypeIsUser_ReturnReportFilterSelection()
        {
            // Arrange
            var parameters = new object[] { new ShimSPField().Instance, new ShimSPWeb().Instance };
            ShimReportFilterSelection.Constructor = _ => new ShimReportFilterSelection();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.TitleGet = _ => DummyString;
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.User;
            ShimReportingFilter.AllInstances.GetSelectedPeoplePickerUsers = _ => new string[] { DummyString };
            ShimReportingFilter.AllInstances.IsPercentageFieldGet = _ => true;

            // Act
            var actualResult = _privateObject.Invoke(
                GetFieldSelection,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetTitlesToPersist_SPWebAndReportFilterSelectionIsNotNull_ReturnListOfTitle()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance, new ShimReportFilterSelection().Instance };
            ShimReportingFilter.AllInstances.ShowTitleDropDownGet = _ => true;
            var listListItem = new List<ListItem>() { new ShimListItem() };
            ShimListControl.AllInstances.ItemsGet = _ => new ShimListItemCollection().Bind(listListItem);
            ShimListItem.AllInstances.SelectedGet = _ => true;
            ShimListItem.AllInstances.ValueGet = _ => DummyString;
            
            // Act
            var actualResult = _privateObject.Invoke(
                GetTitlesToPersist,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetTitlesToPersist_SPWebAndReportFilterSelectionIsNotNullIsFale_ReturnListOfTitleIsNull()
        {
            // Arrange
            var parameters = new object[] { new ShimSPWeb().Instance, new ShimReportFilterSelection().Instance };
            ShimReportingFilter.AllInstances.ShowTitleDropDownGet = _ => false;
            ShimQueryHelper.GetFilteredTitlesSPWebReportFilterSelection = (_, _1) => new List<string>() { DummyString };
            ShimReportFilterSelection.AllInstances.HasErrorsGet = _ => true;
            ShimReportFilterSelection.AllInstances.SelectedFieldsGet = _ => new List<string>() { DummyString };
            
            // Act
            var actualResult = _privateObject.Invoke(
                GetTitlesToPersist,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void UserHasPersistedSelections_ReportFilterUserSettingsIsNotNull_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance };
            ShimReportFilterUserSettings.AllInstances.FieldSelectionGet = _ => new ShimReportFilterSelection();
            ShimReportFilterSelection.AllInstances.SelectedFieldsGet = _ => new List<string>() { DummyString };

            // Act
            var actualResult = _privateType.InvokeStatic(
                UserHasPersistedSelections,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(true);
        }

        [TestMethod]
        public void PersistDefaultValuesIfPersistedSettingsAreInvalid_ReportFilterSelectionIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance };
            ShimSPListCollection.AllInstances.TryGetListString = (_, _1) => new ShimSPList();
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList();
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection();
            ShimSPFieldCollection.AllInstances.ContainsFieldString = (_,_1) => true;
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPField();
            ShimReportFilterUserSettings.AllInstances.IsValidGet = _ => false;
            ShimReportingFilter.PersistedListAndFieldMatchWhatIsInWebPartPropertiesReportFilterUserSettingsSPFieldSPList =
                (_, _1, _2) => false;
            ShimReportingFilter.AllInstances.GetUserSettingsWithDefaultValuesSPSiteSPWebSPListSPField = (_, _1, _2, _3, _4) => new ShimReportFilterUserSettings();
            ShimReportingFilter.AllInstances.PersistUserSettingsReportFilterUserSettingsSPWeb = (_, _1, _2) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                PersistDefaultValuesIfPersistedSettingsAreInvalid,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void PersistedListAndFieldMatchWhatIsInWebPartProperties_ReportFilterSelectionSPFieldAndSPListIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance, new ShimSPField().Instance, new ShimSPList().Instance };
            ShimSPList.AllInstances.IDGet = _ => new Guid();
            ShimReportFilterUserSettings.AllInstances.ListIdGet = _ => new Guid();
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimReportFilterSelection.AllInstances.FieldNameForDisplayGet = _ => DummyString;
            
            // Act
            var actualResult = _privateType.InvokeStatic(
                PersistedListAndFieldMatchWhatIsInWebPartProperties,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(true);
        }

        [TestMethod]
        public void PersistedListAndFieldMatchWhatIsInWebPartProperties_ReportFilterSelectionSPFieldAndSPListIsNotNullNotMatched_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance, new ShimSPField().Instance, new ShimSPList().Instance };
            ShimSPList.AllInstances.IDGet = _ => new Guid();
            ShimReportFilterUserSettings.AllInstances.ListIdGet = _ => new Guid();
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.GridChoice;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimReportFilterSelection.AllInstances.FieldNameForDisplayGet = _ => DummyString;
            ShimReportFilterSelection.AllInstances.InternalFieldNameGet = _ => DummyString;

            // Act
            var actualResult = _privateType.InvokeStatic(
                PersistedListAndFieldMatchWhatIsInWebPartProperties,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(true);
        }

        [TestMethod]
        public void RefreshPersistedTitlesWithLatestQueryResults_ReportFilterUserSettingsIsNotNull_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance };
            ShimReportingFilter.UserHasPersistedSelectionsReportFilterUserSettings = _ => true;
            ShimQueryHelper.GetFilteredTitlesSPWebReportFilterSelection = (_, _1) => new List<string>() { DummyString };
            ShimReportFilterUserSettings.AllInstances.TitleSelectionsGet = _ => new List<string>() { DummyString };
            ShimReportingFilter.AllInstances.ShowTitleDropDownGet = _ => true;
            ShimReportFilterUserSettings.AllInstances.TitleSelectionsGet = _ => new List<string>() { DummyString };
            ShimReportingFilter.AllInstances.PersistUserSettingsReportFilterUserSettingsSPWeb = (_, _1, _2) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                RefreshPersistedTitlesWithLatestQueryResults,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void RefreshPersistedTitlesWithLatestQueryResults_ReportFilterUserSettingsIsNotNullAndIsFalse_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { new ShimReportFilterUserSettings().Instance };
            ShimReportingFilter.UserHasPersistedSelectionsReportFilterUserSettings = _ => true;
            ShimQueryHelper.GetFilteredTitlesSPWebReportFilterSelection = (_, _1) => new List<string>() { DummyString };
            ShimReportFilterUserSettings.AllInstances.TitleSelectionsGet = _ => new List<string>() { DummyString };
            ShimReportingFilter.AllInstances.ShowTitleDropDownGet = _ => false;
            ShimReportFilterUserSettings.AllInstances.TitleSelectionsGet = _ => new List<string>() { DummyString };
            ShimReportingFilter.AllInstances.PersistUserSettingsReportFilterUserSettingsSPWeb = (_, _1, _2) => { };

            // Act
            var actualResult = _privateObject.Invoke(
                RefreshPersistedTitlesWithLatestQueryResults,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void ReloadPage_InputIsEmpty_ConfirmResult()
        {
            // Arrange
            var parameters = new object[] { };
            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (_, _1, _2) => true;
            ShimHttpContext.CurrentGet = () => new ShimHttpContext();
            ShimHttpContext.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimHttpRequest.AllInstances.RawUrlGet = _ => DummyString;
            
            // Act
            var actualResult = _privateObject.Invoke(
                ReloadPage,
                parameters);

            // Assert
            actualResult.ShouldBeNull();
        }

        [TestMethod]
        public void HttpGetOriginatedFromThisPage_InputIsEmpty_ReturnTrue()
        {
            // Arrange
            var parameters = new object[] { };
            ShimHttpContext.CurrentGet = () => new ShimHttpContext();
            ShimHttpContext.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimPage.AllInstances.FormGet = _ => new ShimHtmlForm();
            ShimPage.AllInstances.RequestGet = _ => new ShimHttpRequest();
            ShimHttpRequest.AllInstances.UrlReferrerGet = _ => DummyURI;
            ShimHttpRequest.AllInstances.PathGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                HttpGetOriginatedFromThisPage,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe(false);
        }

        [TestMethod]
        public void GetUserSettingsWithDefaultValues_SpSiteSpWebSpFieldSpListIsNotNull_ReturnReportFilterUserSettings()
        {
            // Arrange
            var parameters = new object[] { new ShimSPSite().Instance, new ShimSPWeb().Instance, new ShimSPList().Instance, new ShimSPField().Instance };
            ShimReportFilterSelection.Constructor = _ => new ShimReportFilterSelection();
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
            ShimSPField.AllInstances.TitleGet = _ => DummyString;
            ShimSPList.AllInstances.IDGet = _ => new Guid();
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Guid;
            ShimQueryHelper.GetFilteredTitlesSPWebReportFilterSelection = (_, _1) => new List<string>() { DummyString };
            ShimReportFilterUserSettings.Constructor = _ => new ShimReportFilterUserSettings();
            ShimSPWeb.AllInstances.IDGet = _ => new Guid();
            ShimSPSite.AllInstances.IDGet = _ => new Guid();
            ShimSPList.AllInstances.IDGet = _ => new Guid();
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPUser.AllInstances.IDGet = _ => DummyInt;
            ShimReportingFilter.AllInstances.GetCamlQueryOperator = _ => DummyString;
            ShimReportFilterSelection.AllInstances.SelectedFieldsGet = _ => new List<string>() { DummyString };
            ShimReportingFilter.AllInstances.DefaultValueForFieldFilterGet = _ => DummyString;
            ShimWebPartHelper.ConvertWebPartIdToGuidString = _ => new Guid();

            // Act
            var actualResult = _privateObject.Invoke(
                GetUserSettingsWithDefaultValues,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetScriptForFilterOperator_InputIsEmpty_ReturnFilterString()
        {
            // Arrange
            var parameters = new object[] { };
            ShimControl.AllInstances.ClientIDGet = _ => DummyString;
            
            // Act
            var actualResult = _privateObject.Invoke(
                GetScriptForFilterOperator,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
            actualResult.ShouldBe("$('#DummyString option:selected').val()");
        }

        [TestMethod]
        public void GetScriptForSelectedFieldsAsCsv_InputIsEmptyTypeIsLookup_ReturnCSVString()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportingFilter.AllInstances.ListToFilterOnGet = _ => DummyString;
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList();
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPField();
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Lookup;
            ShimControl.AllInstances.ClientIDGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                GetScriptForSelectedFieldsAsCsv,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetScriptForSelectedFieldsAsCsv_InputIsEmptyTypeIsText_ReturnCSVString()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportingFilter.AllInstances.ListToFilterOnGet = _ => DummyString;
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList();
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPField();
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.Text;
            ShimControl.AllInstances.ClientIDGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                GetScriptForSelectedFieldsAsCsv,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetScriptForSelectedFieldsAsCsv_InputIsEmptyTypeIsDateTime_ReturnCSVString()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportingFilter.AllInstances.ListToFilterOnGet = _ => DummyString;
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList();
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPField();
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.DateTime;
            ShimControl.AllInstances.ClientIDGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                GetScriptForSelectedFieldsAsCsv,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetScriptForSelectedFieldsAsCsv_InputIsEmptyTypeIsUser_ReturnCSVString()
        {
            // Arrange
            var parameters = new object[] { };
            ShimReportingFilter.AllInstances.ListToFilterOnGet = _ => DummyString;
            ShimReportingFilter.AllInstances.FieldToFilterOnGet = _ => DummyString;
            ShimSPListCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPList();
            ShimSPFieldCollection.AllInstances.ItemGetString = (_, _1) => new ShimSPField();
            ShimSPField.AllInstances.TypeGet = _ => SPFieldType.User;
            ShimControl.AllInstances.ClientIDGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                GetScriptForSelectedFieldsAsCsv,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetScriptToSelectAllTitlesIfNoneSelected_InputIsEmpty_ReturnString()
        {
            // Arrange
            var parameters = new object[] { };
            ShimControl.AllInstances.ClientIDGet = _ => DummyString;
            
            // Act
            var actualResult = _privateObject.Invoke(
                GetScriptToSelectAllTitlesIfNoneSelected,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetScriptToPopulateTitlesBasedOnSelectedFields_InputIsEmpty_ReturnString()
        {
            // Arrange
            var parameters = new object[] { };
            ShimControl.AllInstances.ClientIDGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                GetScriptToPopulateTitlesBasedOnSelectedFields,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetScriptForPeoplePicker_InputIsEmpty_ReturnString()
        {
            // Arrange
            var parameters = new object[] { };
            ShimControl.AllInstances.ClientIDGet = _ => DummyString;

            // Act
            var actualResult = _privateObject.Invoke(
                GetScriptForPeoplePicker,
                parameters);

            // Assert
            actualResult.ShouldNotBeNull();
        }
    }
}