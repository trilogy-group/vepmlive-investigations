using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.UI.HtmlControls;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using EPMLiveWebParts.ReportFiltering.DomainModel;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveWebParts
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveWebParts.ReportingFilter" />)
    ///     and namespace <see cref="EPMLiveWebParts"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    public class ReportingFilterTest : AbstractBaseSetupTypedTest<ReportingFilter>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportingFilter) Initializer

        private const string PropertyReportID = "ReportID";
        private const string PropertyListToFilterOn = "ListToFilterOn";
        private const string PropertyFieldToFilterOn = "FieldToFilterOn";
        private const string PropertyAllowMultipleFieldValuesToBeSelected = "AllowMultipleFieldValuesToBeSelected";
        private const string PropertyShowTitleDropDown = "ShowTitleDropDown";
        private const string PropertyAllowMultipleTitleValuesToBeSelected = "AllowMultipleTitleValuesToBeSelected";
        private const string PropertyIsPercentageField = "IsPercentageField";
        private const string PropertyDefaultValueForFieldFilter = "DefaultValueForFieldFilter";
        private const string MethodReportIDProvider = "ReportIDProvider";
        private const string MethodOnInit = "OnInit";
        private const string MethodOnPreRender = "OnPreRender";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodFilterButtonClick = "FilterButtonClick";
        private const string MethodGetToolParts = "GetToolParts";
        private const string MethodRebuildControlTree = "RebuildControlTree";
        private const string MethodInitializePageControls = "InitializePageControls";
        private const string MethodPopulateTitles = "PopulateTitles";
        private const string MethodAddStyleForPeoplePickerToShowBorder = "AddStyleForPeoplePickerToShowBorder";
        private const string MethodRenderTableForUi = "RenderTableForUi";
        private const string MethodAddProgressIndicatorToMainDiv = "AddProgressIndicatorToMainDiv";
        private const string MethodAddFilterControlsToMainDiv = "AddFilterControlsToMainDiv";
        private const string MethodAddFieldFilterControlForChoiceType = "AddFieldFilterControlForChoiceType";
        private const string MethodAddFieldFilterControlForLookupType = "AddFieldFilterControlForLookupType";
        private const string MethodAddFieldFilterControlForTextType = "AddFieldFilterControlForTextType";
        private const string MethodAddFieldFilterControlForUserType = "AddFieldFilterControlForUserType";
        private const string MethodAddFieldFilterControlForDateType = "AddFieldFilterControlForDateType";
        private const string MethodGetControlDiv = "GetControlDiv";
        private const string MethodGetControlDivForButton = "GetControlDivForButton";
        private const string MethodAddErrorLabelToMainDiv = "AddErrorLabelToMainDiv";
        private const string MethodAddTitleDropDownToMainDiv = "AddTitleDropDownToMainDiv";
        private const string MethodAddTitleButtonToMainDiv = "AddTitleButtonToMainDiv";
        private const string MethodAddFilterButtonToMainDiv = "AddFilterButtonToMainDiv";
        private const string MethodPopulateOperatorDropDown = "PopulateOperatorDropDown";
        private const string MethodGetCamlQueryOperator = "GetCamlQueryOperator";
        private const string MethodDisplayErrors = "DisplayErrors";
        private const string MethodSetSelectedValueForFieldAsDateTime = "SetSelectedValueForFieldAsDateTime";
        private const string MethodSetSelectedValueForFieldAsPeopleEditor = "SetSelectedValueForFieldAsPeopleEditor";
        private const string MethodSetSelectedValueForFieldAsTextBox = "SetSelectedValueForFieldAsTextBox";
        private const string MethodSetSelectedValueForFieldAsListBox = "SetSelectedValueForFieldAsListBox";
        private const string MethodSetSelectedFieldValues = "SetSelectedFieldValues";
        private const string MethodSetSelectedTitleValues = "SetSelectedTitleValues";
        private const string MethodGetPersistedSettings = "GetPersistedSettings";
        private const string MethodPersistUserSettings = "PersistUserSettings";
        private const string MethodGetFieldSelection = "GetFieldSelection";
        private const string MethodGetSelectedPeoplePickerUsers = "GetSelectedPeoplePickerUsers";
        private const string MethodGetTitlesToPersist = "GetTitlesToPersist";
        private const string MethodUserHasPersistedSelections = "UserHasPersistedSelections";
        private const string MethodPersistDefaultValuesIfPersistedSettingsAreInvalid = "PersistDefaultValuesIfPersistedSettingsAreInvalid";
        private const string MethodPersistedListAndFieldMatchWhatIsInWebPartProperties = "PersistedListAndFieldMatchWhatIsInWebPartProperties";
        private const string MethodRefreshPersistedTitlesWithLatestQueryResults = "RefreshPersistedTitlesWithLatestQueryResults";
        private const string MethodUpdateUsersPersistedTitlesBasedOnCurrentData = "UpdateUsersPersistedTitlesBasedOnCurrentData";
        private const string MethodReloadPage = "ReloadPage";
        private const string MethodHttpGetOriginatedFromThisPage = "HttpGetOriginatedFromThisPage";
        private const string MethodGetUserSettingsWithDefaultValues = "GetUserSettingsWithDefaultValues";
        private const string MethodGenerateMainJavascript = "GenerateMainJavascript";
        private const string MethodGetScriptForFilterOperator = "GetScriptForFilterOperator";
        private const string MethodGetScriptForSelectedFieldsAsCsv = "GetScriptForSelectedFieldsAsCsv";
        private const string MethodGetScriptToSelectAllTitlesIfNoneSelected = "GetScriptToSelectAllTitlesIfNoneSelected";
        private const string MethodGetScriptToPopulateTitlesBasedOnSelectedFields = "GetScriptToPopulateTitlesBasedOnSelectedFields";
        private const string MethodGetScriptForPeoplePicker = "GetScriptForPeoplePicker";
        private const string FieldFieldLabel = "FieldLabel";
        private const string FieldTitleLabel = "TitleLabel";
        private const string FieldErrorLabel = "ErrorLabel";
        private const string FieldFieldValueAsListBox = "FieldValueAsListBox";
        private const string FieldFieldValueAsTextBox = "FieldValueAsTextBox";
        private const string FieldFieldValueAsPeopleEditor = "FieldValueAsPeopleEditor";
        private const string FieldJqueryDatePickerBeginDate = "JqueryDatePickerBeginDate";
        private const string FieldJqueryDatePickerEndDate = "JqueryDatePickerEndDate";
        private const string FieldTitleListBox = "TitleListBox";
        private const string FieldFilterButton = "FilterButton";
        private const string FieldFilterTitlesButton = "FilterTitlesButton";
        private const string FieldOperatorDropDownList = "OperatorDropDownList";
        private const string Field_persistedSettings = "_persistedSettings";
        private Type _reportingFilterInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportingFilter _reportingFilterInstance;
        private ReportingFilter _reportingFilterInstanceFixture;

        #region General Initializer : Class (ReportingFilter) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportingFilter" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportingFilterInstanceType = typeof(ReportingFilter);
            _reportingFilterInstanceFixture = Create(true);
            _reportingFilterInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportingFilter)

        #region General Initializer : Class (ReportingFilter) All Methods Explore Verification.

        /// <summary>
        ///     Class (<see cref="ReportingFilter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(MethodReportIDProvider, 0)]
        [TestCase(MethodOnInit, 0)]
        [TestCase(MethodOnPreRender, 0)]
        [TestCase(MethodCreateChildControls, 0)]
        [TestCase(MethodFilterButtonClick, 0)]
        [TestCase(MethodGetToolParts, 0)]
        [TestCase(MethodRebuildControlTree, 0)]
        [TestCase(MethodInitializePageControls, 0)]
        [TestCase(MethodPopulateTitles, 0)]
        [TestCase(MethodAddStyleForPeoplePickerToShowBorder, 0)]
        [TestCase(MethodRenderTableForUi, 0)]
        [TestCase(MethodAddProgressIndicatorToMainDiv, 0)]
        [TestCase(MethodAddFilterControlsToMainDiv, 0)]
        [TestCase(MethodAddFieldFilterControlForChoiceType, 0)]
        [TestCase(MethodAddFieldFilterControlForLookupType, 0)]
        [TestCase(MethodAddFieldFilterControlForTextType, 0)]
        [TestCase(MethodAddFieldFilterControlForUserType, 0)]
        [TestCase(MethodAddFieldFilterControlForDateType, 0)]
        [TestCase(MethodGetControlDiv, 0)]
        [TestCase(MethodGetControlDivForButton, 0)]
        [TestCase(MethodAddErrorLabelToMainDiv, 0)]
        [TestCase(MethodAddTitleDropDownToMainDiv, 0)]
        [TestCase(MethodAddTitleButtonToMainDiv, 0)]
        [TestCase(MethodAddFilterButtonToMainDiv, 0)]
        [TestCase(MethodPopulateOperatorDropDown, 0)]
        [TestCase(MethodGetCamlQueryOperator, 0)]
        [TestCase(MethodDisplayErrors, 0)]
        [TestCase(MethodSetSelectedValueForFieldAsDateTime, 0)]
        [TestCase(MethodSetSelectedValueForFieldAsPeopleEditor, 0)]
        [TestCase(MethodSetSelectedValueForFieldAsTextBox, 0)]
        [TestCase(MethodSetSelectedValueForFieldAsListBox, 0)]
        [TestCase(MethodSetSelectedFieldValues, 0)]
        [TestCase(MethodSetSelectedTitleValues, 0)]
        [TestCase(MethodGetPersistedSettings, 0)]
        [TestCase(MethodPersistUserSettings, 0)]
        [TestCase(MethodGetFieldSelection, 0)]
        [TestCase(MethodGetSelectedPeoplePickerUsers, 0)]
        [TestCase(MethodGetTitlesToPersist, 0)]
        [TestCase(MethodUserHasPersistedSelections, 0)]
        [TestCase(MethodPersistDefaultValuesIfPersistedSettingsAreInvalid, 0)]
        [TestCase(MethodPersistedListAndFieldMatchWhatIsInWebPartProperties, 0)]
        [TestCase(MethodRefreshPersistedTitlesWithLatestQueryResults, 0)]
        [TestCase(MethodUpdateUsersPersistedTitlesBasedOnCurrentData, 0)]
        [TestCase(MethodReloadPage, 0)]
        [TestCase(MethodHttpGetOriginatedFromThisPage, 0)]
        [TestCase(MethodGetUserSettingsWithDefaultValues, 0)]
        [TestCase(MethodGenerateMainJavascript, 0)]
        [TestCase(MethodGetScriptForFilterOperator, 0)]
        [TestCase(MethodGetScriptForSelectedFieldsAsCsv, 0)]
        [TestCase(MethodGetScriptToSelectAllTitlesIfNoneSelected, 0)]
        [TestCase(MethodGetScriptToPopulateTitlesBasedOnSelectedFields, 0)]
        [TestCase(MethodGetScriptForPeoplePicker, 0)]
        public void AUT_ReportingFilter_All_Methods_Explore_Verify_Test(string methodName, int overloadingIndex = 0)
        {
            // Arrange
            var currentMethodInfo = GetMethodInfo(methodName, overloadingIndex);

            // Act
            ShouldlyExtension.ExploreMethodWithOrWithoutInstance(_reportingFilterInstanceFixture, 
                                                                 Fixture, 
                                                                 currentMethodInfo);

            // Assert
            currentMethodInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportingFilter) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportingFilter" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyReportID)]
        [TestCase(PropertyListToFilterOn)]
        [TestCase(PropertyFieldToFilterOn)]
        [TestCase(PropertyAllowMultipleFieldValuesToBeSelected)]
        [TestCase(PropertyShowTitleDropDown)]
        [TestCase(PropertyAllowMultipleTitleValuesToBeSelected)]
        [TestCase(PropertyIsPercentageField)]
        [TestCase(PropertyDefaultValueForFieldFilter)]
        public void AUT_ReportingFilter_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportingFilterInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportingFilter) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportingFilter" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldFieldLabel)]
        [TestCase(FieldTitleLabel)]
        [TestCase(FieldErrorLabel)]
        [TestCase(FieldFieldValueAsListBox)]
        [TestCase(FieldFieldValueAsTextBox)]
        [TestCase(FieldFieldValueAsPeopleEditor)]
        [TestCase(FieldJqueryDatePickerBeginDate)]
        [TestCase(FieldJqueryDatePickerEndDate)]
        [TestCase(FieldTitleListBox)]
        [TestCase(FieldFilterButton)]
        [TestCase(FieldFilterTitlesButton)]
        [TestCase(FieldOperatorDropDownList)]
        [TestCase(Field_persistedSettings)]
        public void AUT_ReportingFilter_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportingFilterInstanceFixture, 
                                                                Fixture, 
                                                                fieldInfo);

            // Assert
            fieldInfo.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion

        #region Category : Instance

        /// <summary>
        ///     Class (<see cref="ReportingFilter" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportingFilter_Is_Instance_Present_Test()
        {
            // Assert
            _reportingFilterInstanceType.ShouldNotBeNull();
            _reportingFilterInstance.ShouldNotBeNull();
            _reportingFilterInstanceFixture.ShouldNotBeNull();
            _reportingFilterInstance.ShouldBeAssignableTo<ReportingFilter>();
            _reportingFilterInstanceFixture.ShouldBeAssignableTo<ReportingFilter>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportingFilter) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportingFilter_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportingFilter instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportingFilterInstanceType.ShouldNotBeNull();
            _reportingFilterInstance.ShouldNotBeNull();
            _reportingFilterInstanceFixture.ShouldNotBeNull();
            _reportingFilterInstance.ShouldBeAssignableTo<ReportingFilter>();
            _reportingFilterInstanceFixture.ShouldBeAssignableTo<ReportingFilter>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportingFilter) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyReportID)]
        [TestCaseGeneric(typeof(string) , PropertyListToFilterOn)]
        [TestCaseGeneric(typeof(string) , PropertyFieldToFilterOn)]
        [TestCaseGeneric(typeof(bool) , PropertyAllowMultipleFieldValuesToBeSelected)]
        [TestCaseGeneric(typeof(bool) , PropertyShowTitleDropDown)]
        [TestCaseGeneric(typeof(bool) , PropertyAllowMultipleTitleValuesToBeSelected)]
        [TestCaseGeneric(typeof(bool) , PropertyIsPercentageField)]
        [TestCaseGeneric(typeof(string) , PropertyDefaultValueForFieldFilter)]
        public void AUT_ReportingFilter_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportingFilter, T>(_reportingFilterInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportingFilter) => Property (AllowMultipleFieldValuesToBeSelected) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingFilter_Public_Class_AllowMultipleFieldValuesToBeSelected_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAllowMultipleFieldValuesToBeSelected);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingFilter) => Property (AllowMultipleTitleValuesToBeSelected) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingFilter_Public_Class_AllowMultipleTitleValuesToBeSelected_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyAllowMultipleTitleValuesToBeSelected);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingFilter) => Property (DefaultValueForFieldFilter) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingFilter_Public_Class_DefaultValueForFieldFilter_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyDefaultValueForFieldFilter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingFilter) => Property (FieldToFilterOn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingFilter_Public_Class_FieldToFilterOn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyFieldToFilterOn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingFilter) => Property (IsPercentageField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingFilter_Public_Class_IsPercentageField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyIsPercentageField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingFilter) => Property (ListToFilterOn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingFilter_Public_Class_ListToFilterOn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyListToFilterOn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingFilter) => Property (ReportID) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingFilter_Public_Class_ReportID_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyReportID);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportingFilter) => Property (ShowTitleDropDown) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportingFilter_Public_Class_ShowTitleDropDown_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyShowTitleDropDown);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #region Category : MethodCallTest

        #region Method Call : Static methods call tests

        /// <summary>
        ///     Class (<see cref="ReportingFilter" />) public, non-public static only methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodGetControlDiv)]
        [TestCase(MethodGetControlDivForButton)]
        [TestCase(MethodUserHasPersistedSelections)]
        [TestCase(MethodPersistedListAndFieldMatchWhatIsInWebPartProperties)]
        public void AUT_ReportingFilter_Static_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyStaticMethodsWithOrWithoutInstance(_reportingFilterInstanceFixture,
                                                                              _reportingFilterInstanceType,
                                                                              Fixture,
                                                                              methodName);
        }

        #endregion

        #region Method Call : NonStatic methods call tests

        /// <summary>
        ///      Class (<see cref="ReportingFilter" />) public, non-public non-static methods exploration for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        [TestCase(MethodReportIDProvider)]
        [TestCase(MethodOnInit)]
        [TestCase(MethodOnPreRender)]
        [TestCase(MethodCreateChildControls)]
        [TestCase(MethodFilterButtonClick)]
        [TestCase(MethodGetToolParts)]
        [TestCase(MethodRebuildControlTree)]
        [TestCase(MethodInitializePageControls)]
        [TestCase(MethodPopulateTitles)]
        [TestCase(MethodAddStyleForPeoplePickerToShowBorder)]
        [TestCase(MethodRenderTableForUi)]
        [TestCase(MethodAddProgressIndicatorToMainDiv)]
        [TestCase(MethodAddFilterControlsToMainDiv)]
        [TestCase(MethodAddFieldFilterControlForChoiceType)]
        [TestCase(MethodAddFieldFilterControlForLookupType)]
        [TestCase(MethodAddFieldFilterControlForTextType)]
        [TestCase(MethodAddFieldFilterControlForUserType)]
        [TestCase(MethodAddFieldFilterControlForDateType)]
        [TestCase(MethodAddErrorLabelToMainDiv)]
        [TestCase(MethodAddTitleDropDownToMainDiv)]
        [TestCase(MethodAddTitleButtonToMainDiv)]
        [TestCase(MethodAddFilterButtonToMainDiv)]
        [TestCase(MethodPopulateOperatorDropDown)]
        [TestCase(MethodGetCamlQueryOperator)]
        [TestCase(MethodDisplayErrors)]
        [TestCase(MethodSetSelectedValueForFieldAsDateTime)]
        [TestCase(MethodSetSelectedValueForFieldAsPeopleEditor)]
        [TestCase(MethodSetSelectedValueForFieldAsTextBox)]
        [TestCase(MethodSetSelectedValueForFieldAsListBox)]
        [TestCase(MethodSetSelectedFieldValues)]
        [TestCase(MethodSetSelectedTitleValues)]
        [TestCase(MethodGetPersistedSettings)]
        [TestCase(MethodPersistUserSettings)]
        [TestCase(MethodGetFieldSelection)]
        [TestCase(MethodGetSelectedPeoplePickerUsers)]
        [TestCase(MethodGetTitlesToPersist)]
        [TestCase(MethodPersistDefaultValuesIfPersistedSettingsAreInvalid)]
        [TestCase(MethodRefreshPersistedTitlesWithLatestQueryResults)]
        [TestCase(MethodUpdateUsersPersistedTitlesBasedOnCurrentData)]
        [TestCase(MethodReloadPage)]
        [TestCase(MethodHttpGetOriginatedFromThisPage)]
        [TestCase(MethodGetUserSettingsWithDefaultValues)]
        [TestCase(MethodGenerateMainJavascript)]
        [TestCase(MethodGetScriptForFilterOperator)]
        [TestCase(MethodGetScriptForSelectedFieldsAsCsv)]
        [TestCase(MethodGetScriptToSelectAllTitlesIfNoneSelected)]
        [TestCase(MethodGetScriptToPopulateTitlesBasedOnSelectedFields)]
        [TestCase(MethodGetScriptForPeoplePicker)]
        public void AUT_ReportingFilter_NonStatic_Methods_Explore_Verify_Test(string methodName)
        {
            // AAA: Arrange, Act, Assert
            ShouldlyExtension.ExploreVerifyMethods<ReportingFilter>(Fixture, methodName);
        }

        #endregion

        #region Method Call : (ReportIDProvider) (Return Type : IReportID) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_ReportIDProvider_Method_Call_Internally(Type[] types)
        {
            var methodReportIDProviderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodReportIDProvider, Fixture, methodReportIDProviderPrametersTypes);
        }

        #endregion

        #region Method Call : (ReportIDProvider) (Return Type : IReportID) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_ReportIDProvider_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportingFilterInstance.ReportIDProvider();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (ReportIDProvider) (Return Type : IReportID) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_ReportIDProvider_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodReportIDProviderPrametersTypes = null;
            object[] parametersOfReportIDProvider = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReportIDProvider, methodReportIDProviderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfReportIDProvider);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReportIDProvider.ShouldBeNull();
            methodReportIDProviderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportIDProvider) (Return Type : IReportID) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_ReportIDProvider_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodReportIDProviderPrametersTypes = null;
            object[] parametersOfReportIDProvider = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, IReportID>(_reportingFilterInstance, MethodReportIDProvider, parametersOfReportIDProvider, methodReportIDProviderPrametersTypes);

            // Assert
            parametersOfReportIDProvider.ShouldBeNull();
            methodReportIDProviderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReportIDProvider) (Return Type : IReportID) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_ReportIDProvider_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodReportIDProviderPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodReportIDProvider, Fixture, methodReportIDProviderPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodReportIDProviderPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReportIDProvider) (Return Type : IReportID) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_ReportIDProvider_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodReportIDProviderPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodReportIDProvider, Fixture, methodReportIDProviderPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodReportIDProviderPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (ReportIDProvider) (Return Type : IReportID) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_ReportIDProvider_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReportIDProvider, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_OnInit_Method_Call_Internally(Type[] types)
        {
            var methodOnInitPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_OnInit_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnInit, methodOnInitPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfOnInit);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnInit.ShouldNotBeNull();
            parametersOfOnInit.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(parametersOfOnInit.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_OnInit_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnInit = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodOnInit, parametersOfOnInit, methodOnInitPrametersTypes);

            // Assert
            parametersOfOnInit.ShouldNotBeNull();
            parametersOfOnInit.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            methodOnInitPrametersTypes.Length.ShouldBe(parametersOfOnInit.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_OnInit_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnInit, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_OnInit_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnInitPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodOnInit, Fixture, methodOnInitPrametersTypes);

            // Assert
            methodOnInitPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnInit) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_OnInit_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnInit, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_OnPreRender_Method_Call_Internally(Type[] types)
        {
            var methodOnPreRenderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodOnPreRender, methodOnPreRenderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfOnPreRender);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_OnPreRender_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var e = CreateType<EventArgs>();
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };
            object[] parametersOfOnPreRender = { e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodOnPreRender, parametersOfOnPreRender, methodOnPreRenderPrametersTypes);

            // Assert
            parametersOfOnPreRender.ShouldNotBeNull();
            parametersOfOnPreRender.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            methodOnPreRenderPrametersTypes.Length.ShouldBe(parametersOfOnPreRender.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_OnPreRender_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_OnPreRender_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodOnPreRenderPrametersTypes = new Type[] { typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodOnPreRender, Fixture, methodOnPreRenderPrametersTypes);

            // Assert
            methodOnPreRenderPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (OnPreRender) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_OnPreRender_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodOnPreRender, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_CreateChildControls_Method_Call_Internally(Type[] types)
        {
            var methodCreateChildControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);
        }

        #endregion
        
        #region Method Call : (CreateChildControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_CreateChildControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;
            object[] parametersOfCreateChildControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodCreateChildControls, parametersOfCreateChildControls, methodCreateChildControlsPrametersTypes);

            // Assert
            parametersOfCreateChildControls.ShouldBeNull();
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_CreateChildControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodCreateChildControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodCreateChildControls, Fixture, methodCreateChildControlsPrametersTypes);

            // Assert
            methodCreateChildControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (CreateChildControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_CreateChildControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodCreateChildControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FilterButtonClick) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_FilterButtonClick_Method_Call_Internally(Type[] types)
        {
            var methodFilterButtonClickPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodFilterButtonClick, Fixture, methodFilterButtonClickPrametersTypes);
        }

        #endregion

        #region Method Call : (FilterButtonClick) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_FilterButtonClick_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodFilterButtonClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfFilterButtonClick = { sender, e };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodFilterButtonClick, methodFilterButtonClickPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfFilterButtonClick);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfFilterButtonClick.ShouldNotBeNull();
            parametersOfFilterButtonClick.Length.ShouldBe(2);
            methodFilterButtonClickPrametersTypes.Length.ShouldBe(2);
            methodFilterButtonClickPrametersTypes.Length.ShouldBe(parametersOfFilterButtonClick.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (FilterButtonClick) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_FilterButtonClick_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var sender = CreateType<object>();
            var e = CreateType<EventArgs>();
            var methodFilterButtonClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };
            object[] parametersOfFilterButtonClick = { sender, e };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodFilterButtonClick, parametersOfFilterButtonClick, methodFilterButtonClickPrametersTypes);

            // Assert
            parametersOfFilterButtonClick.ShouldNotBeNull();
            parametersOfFilterButtonClick.Length.ShouldBe(2);
            methodFilterButtonClickPrametersTypes.Length.ShouldBe(2);
            methodFilterButtonClickPrametersTypes.Length.ShouldBe(parametersOfFilterButtonClick.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FilterButtonClick) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_FilterButtonClick_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodFilterButtonClick, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (FilterButtonClick) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_FilterButtonClick_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodFilterButtonClickPrametersTypes = new Type[] { typeof(object), typeof(EventArgs) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodFilterButtonClick, Fixture, methodFilterButtonClickPrametersTypes);

            // Assert
            methodFilterButtonClickPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (FilterButtonClick) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_FilterButtonClick_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodFilterButtonClick, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetToolParts_Method_Call_Internally(Type[] types)
        {
            var methodGetToolPartsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetToolParts_Method_DirectCall_No_Exception_Thrown_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportingFilterInstance.GetToolParts();

            // Assert
            Should.NotThrow(executeAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetToolParts_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetToolParts, methodGetToolPartsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfGetToolParts);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetToolParts_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            object[] parametersOfGetToolParts = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, ToolPart[]>(_reportingFilterInstance, MethodGetToolParts, parametersOfGetToolParts, methodGetToolPartsPrametersTypes);

            // Assert
            parametersOfGetToolParts.ShouldBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetToolParts_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetToolParts_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetToolPartsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetToolParts, Fixture, methodGetToolPartsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetToolPartsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetToolParts) (Return Type : ToolPart[]) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetToolParts_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetToolParts, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_RebuildControlTree_Method_Call_Internally(Type[] types)
        {
            var methodRebuildControlTreePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodRebuildControlTree, Fixture, methodRebuildControlTreePrametersTypes);
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) Exception Thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RebuildControlTree_Method_DirectCall_Throw_Exception_Test()
        {
            // Arrange
            Action executeAction = null;

            // Act
            executeAction = () => _reportingFilterInstance.RebuildControlTree();

            // Assert
            Should.Throw<Exception>(executeAction);
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RebuildControlTree_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRebuildControlTreePrametersTypes = null;
            object[] parametersOfRebuildControlTree = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRebuildControlTree, methodRebuildControlTreePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfRebuildControlTree);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRebuildControlTree.ShouldBeNull();
            methodRebuildControlTreePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RebuildControlTree_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRebuildControlTreePrametersTypes = null;
            object[] parametersOfRebuildControlTree = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodRebuildControlTree, parametersOfRebuildControlTree, methodRebuildControlTreePrametersTypes);

            // Assert
            parametersOfRebuildControlTree.ShouldBeNull();
            methodRebuildControlTreePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RebuildControlTree_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRebuildControlTreePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodRebuildControlTree, Fixture, methodRebuildControlTreePrametersTypes);

            // Assert
            methodRebuildControlTreePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RebuildControlTree) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RebuildControlTree_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRebuildControlTree, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializePageControls) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_InitializePageControls_Method_Call_Internally(Type[] types)
        {
            var methodInitializePageControlsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodInitializePageControls, Fixture, methodInitializePageControlsPrametersTypes);
        }

        #endregion

        #region Method Call : (InitializePageControls) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_InitializePageControls_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodInitializePageControlsPrametersTypes = null;
            object[] parametersOfInitializePageControls = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodInitializePageControls, methodInitializePageControlsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfInitializePageControls);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfInitializePageControls.ShouldBeNull();
            methodInitializePageControlsPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (InitializePageControls) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_InitializePageControls_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodInitializePageControlsPrametersTypes = null;
            object[] parametersOfInitializePageControls = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodInitializePageControls, parametersOfInitializePageControls, methodInitializePageControlsPrametersTypes);

            // Assert
            parametersOfInitializePageControls.ShouldBeNull();
            methodInitializePageControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializePageControls) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_InitializePageControls_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodInitializePageControlsPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodInitializePageControls, Fixture, methodInitializePageControlsPrametersTypes);

            // Assert
            methodInitializePageControlsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (InitializePageControls) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_InitializePageControls_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodInitializePageControls, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateTitles) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_PopulateTitles_Method_Call_Internally(Type[] types)
        {
            var methodPopulateTitlesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodPopulateTitles, Fixture, methodPopulateTitlesPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateTitles) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PopulateTitles_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodPopulateTitlesPrametersTypes = null;
            object[] parametersOfPopulateTitles = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateTitles, methodPopulateTitlesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfPopulateTitles);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateTitles.ShouldBeNull();
            methodPopulateTitlesPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateTitles) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PopulateTitles_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodPopulateTitlesPrametersTypes = null;
            object[] parametersOfPopulateTitles = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodPopulateTitles, parametersOfPopulateTitles, methodPopulateTitlesPrametersTypes);

            // Assert
            parametersOfPopulateTitles.ShouldBeNull();
            methodPopulateTitlesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateTitles) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PopulateTitles_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodPopulateTitlesPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodPopulateTitles, Fixture, methodPopulateTitlesPrametersTypes);

            // Assert
            methodPopulateTitlesPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateTitles) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PopulateTitles_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateTitles, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddStyleForPeoplePickerToShowBorder) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_AddStyleForPeoplePickerToShowBorder_Method_Call_Internally(Type[] types)
        {
            var methodAddStyleForPeoplePickerToShowBorderPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddStyleForPeoplePickerToShowBorder, Fixture, methodAddStyleForPeoplePickerToShowBorderPrametersTypes);
        }

        #endregion

        #region Method Call : (AddStyleForPeoplePickerToShowBorder) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddStyleForPeoplePickerToShowBorder_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodAddStyleForPeoplePickerToShowBorderPrametersTypes = null;
            object[] parametersOfAddStyleForPeoplePickerToShowBorder = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddStyleForPeoplePickerToShowBorder, methodAddStyleForPeoplePickerToShowBorderPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfAddStyleForPeoplePickerToShowBorder);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddStyleForPeoplePickerToShowBorder.ShouldBeNull();
            methodAddStyleForPeoplePickerToShowBorderPrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddStyleForPeoplePickerToShowBorder) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddStyleForPeoplePickerToShowBorder_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodAddStyleForPeoplePickerToShowBorderPrametersTypes = null;
            object[] parametersOfAddStyleForPeoplePickerToShowBorder = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodAddStyleForPeoplePickerToShowBorder, parametersOfAddStyleForPeoplePickerToShowBorder, methodAddStyleForPeoplePickerToShowBorderPrametersTypes);

            // Assert
            parametersOfAddStyleForPeoplePickerToShowBorder.ShouldBeNull();
            methodAddStyleForPeoplePickerToShowBorderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddStyleForPeoplePickerToShowBorder) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddStyleForPeoplePickerToShowBorder_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodAddStyleForPeoplePickerToShowBorderPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddStyleForPeoplePickerToShowBorder, Fixture, methodAddStyleForPeoplePickerToShowBorderPrametersTypes);

            // Assert
            methodAddStyleForPeoplePickerToShowBorderPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddStyleForPeoplePickerToShowBorder) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddStyleForPeoplePickerToShowBorder_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddStyleForPeoplePickerToShowBorder, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderTableForUi) (Return Type : HtmlTable) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_RenderTableForUi_Method_Call_Internally(Type[] types)
        {
            var methodRenderTableForUiPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodRenderTableForUi, Fixture, methodRenderTableForUiPrametersTypes);
        }

        #endregion

        #region Method Call : (RenderTableForUi) (Return Type : HtmlTable) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RenderTableForUi_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodRenderTableForUiPrametersTypes = null;
            object[] parametersOfRenderTableForUi = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRenderTableForUi, methodRenderTableForUiPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfRenderTableForUi);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRenderTableForUi.ShouldBeNull();
            methodRenderTableForUiPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderTableForUi) (Return Type : HtmlTable) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RenderTableForUi_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodRenderTableForUiPrametersTypes = null;
            object[] parametersOfRenderTableForUi = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, HtmlTable>(_reportingFilterInstance, MethodRenderTableForUi, parametersOfRenderTableForUi, methodRenderTableForUiPrametersTypes);

            // Assert
            parametersOfRenderTableForUi.ShouldBeNull();
            methodRenderTableForUiPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RenderTableForUi) (Return Type : HtmlTable) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RenderTableForUi_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodRenderTableForUiPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodRenderTableForUi, Fixture, methodRenderTableForUiPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodRenderTableForUiPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderTableForUi) (Return Type : HtmlTable) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RenderTableForUi_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodRenderTableForUiPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodRenderTableForUi, Fixture, methodRenderTableForUiPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodRenderTableForUiPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (RenderTableForUi) (Return Type : HtmlTable) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RenderTableForUi_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRenderTableForUi, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AddProgressIndicatorToMainDiv) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_AddProgressIndicatorToMainDiv_Method_Call_Internally(Type[] types)
        {
            var methodAddProgressIndicatorToMainDivPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddProgressIndicatorToMainDiv, Fixture, methodAddProgressIndicatorToMainDivPrametersTypes);
        }

        #endregion

        #region Method Call : (AddProgressIndicatorToMainDiv) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddProgressIndicatorToMainDiv_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var methodAddProgressIndicatorToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };
            object[] parametersOfAddProgressIndicatorToMainDiv = { mainDiv };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddProgressIndicatorToMainDiv, methodAddProgressIndicatorToMainDivPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfAddProgressIndicatorToMainDiv);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddProgressIndicatorToMainDiv.ShouldNotBeNull();
            parametersOfAddProgressIndicatorToMainDiv.Length.ShouldBe(1);
            methodAddProgressIndicatorToMainDivPrametersTypes.Length.ShouldBe(1);
            methodAddProgressIndicatorToMainDivPrametersTypes.Length.ShouldBe(parametersOfAddProgressIndicatorToMainDiv.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddProgressIndicatorToMainDiv) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddProgressIndicatorToMainDiv_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var methodAddProgressIndicatorToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };
            object[] parametersOfAddProgressIndicatorToMainDiv = { mainDiv };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodAddProgressIndicatorToMainDiv, parametersOfAddProgressIndicatorToMainDiv, methodAddProgressIndicatorToMainDivPrametersTypes);

            // Assert
            parametersOfAddProgressIndicatorToMainDiv.ShouldNotBeNull();
            parametersOfAddProgressIndicatorToMainDiv.Length.ShouldBe(1);
            methodAddProgressIndicatorToMainDivPrametersTypes.Length.ShouldBe(1);
            methodAddProgressIndicatorToMainDivPrametersTypes.Length.ShouldBe(parametersOfAddProgressIndicatorToMainDiv.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddProgressIndicatorToMainDiv) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddProgressIndicatorToMainDiv_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddProgressIndicatorToMainDiv, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddProgressIndicatorToMainDiv) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddProgressIndicatorToMainDiv_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddProgressIndicatorToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddProgressIndicatorToMainDiv, Fixture, methodAddProgressIndicatorToMainDivPrametersTypes);

            // Assert
            methodAddProgressIndicatorToMainDivPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddProgressIndicatorToMainDiv) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddProgressIndicatorToMainDiv_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddProgressIndicatorToMainDiv, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFilterControlsToMainDiv) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_AddFilterControlsToMainDiv_Method_Call_Internally(Type[] types)
        {
            var methodAddFilterControlsToMainDivPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFilterControlsToMainDiv, Fixture, methodAddFilterControlsToMainDivPrametersTypes);
        }

        #endregion

        #region Method Call : (AddFilterControlsToMainDiv) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFilterControlsToMainDiv_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var mainDiv = CreateType<HtmlGenericControl>();
            var field = CreateType<SPField>();
            var methodAddFilterControlsToMainDivPrametersTypes = new Type[] { typeof(SPWeb), typeof(HtmlGenericControl), typeof(SPField) };
            object[] parametersOfAddFilterControlsToMainDiv = { web, mainDiv, field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddFilterControlsToMainDiv, methodAddFilterControlsToMainDivPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfAddFilterControlsToMainDiv);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddFilterControlsToMainDiv.ShouldNotBeNull();
            parametersOfAddFilterControlsToMainDiv.Length.ShouldBe(3);
            methodAddFilterControlsToMainDivPrametersTypes.Length.ShouldBe(3);
            methodAddFilterControlsToMainDivPrametersTypes.Length.ShouldBe(parametersOfAddFilterControlsToMainDiv.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddFilterControlsToMainDiv) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFilterControlsToMainDiv_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var mainDiv = CreateType<HtmlGenericControl>();
            var field = CreateType<SPField>();
            var methodAddFilterControlsToMainDivPrametersTypes = new Type[] { typeof(SPWeb), typeof(HtmlGenericControl), typeof(SPField) };
            object[] parametersOfAddFilterControlsToMainDiv = { web, mainDiv, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodAddFilterControlsToMainDiv, parametersOfAddFilterControlsToMainDiv, methodAddFilterControlsToMainDivPrametersTypes);

            // Assert
            parametersOfAddFilterControlsToMainDiv.ShouldNotBeNull();
            parametersOfAddFilterControlsToMainDiv.Length.ShouldBe(3);
            methodAddFilterControlsToMainDivPrametersTypes.Length.ShouldBe(3);
            methodAddFilterControlsToMainDivPrametersTypes.Length.ShouldBe(parametersOfAddFilterControlsToMainDiv.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFilterControlsToMainDiv) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFilterControlsToMainDiv_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddFilterControlsToMainDiv, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFilterControlsToMainDiv) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFilterControlsToMainDiv_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddFilterControlsToMainDivPrametersTypes = new Type[] { typeof(SPWeb), typeof(HtmlGenericControl), typeof(SPField) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFilterControlsToMainDiv, Fixture, methodAddFilterControlsToMainDivPrametersTypes);

            // Assert
            methodAddFilterControlsToMainDivPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFilterControlsToMainDiv) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFilterControlsToMainDiv_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddFilterControlsToMainDiv, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForChoiceType) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_AddFieldFilterControlForChoiceType_Method_Call_Internally(Type[] types)
        {
            var methodAddFieldFilterControlForChoiceTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFieldFilterControlForChoiceType, Fixture, methodAddFieldFilterControlForChoiceTypePrametersTypes);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForChoiceType) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForChoiceType_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var field = CreateType<SPField>();
            var methodAddFieldFilterControlForChoiceTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField) };
            object[] parametersOfAddFieldFilterControlForChoiceType = { mainDiv, field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForChoiceType, methodAddFieldFilterControlForChoiceTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfAddFieldFilterControlForChoiceType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddFieldFilterControlForChoiceType.ShouldNotBeNull();
            parametersOfAddFieldFilterControlForChoiceType.Length.ShouldBe(2);
            methodAddFieldFilterControlForChoiceTypePrametersTypes.Length.ShouldBe(2);
            methodAddFieldFilterControlForChoiceTypePrametersTypes.Length.ShouldBe(parametersOfAddFieldFilterControlForChoiceType.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForChoiceType) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForChoiceType_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var field = CreateType<SPField>();
            var methodAddFieldFilterControlForChoiceTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField) };
            object[] parametersOfAddFieldFilterControlForChoiceType = { mainDiv, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodAddFieldFilterControlForChoiceType, parametersOfAddFieldFilterControlForChoiceType, methodAddFieldFilterControlForChoiceTypePrametersTypes);

            // Assert
            parametersOfAddFieldFilterControlForChoiceType.ShouldNotBeNull();
            parametersOfAddFieldFilterControlForChoiceType.Length.ShouldBe(2);
            methodAddFieldFilterControlForChoiceTypePrametersTypes.Length.ShouldBe(2);
            methodAddFieldFilterControlForChoiceTypePrametersTypes.Length.ShouldBe(parametersOfAddFieldFilterControlForChoiceType.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForChoiceType) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForChoiceType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForChoiceType, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForChoiceType) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForChoiceType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddFieldFilterControlForChoiceTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFieldFilterControlForChoiceType, Fixture, methodAddFieldFilterControlForChoiceTypePrametersTypes);

            // Assert
            methodAddFieldFilterControlForChoiceTypePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForChoiceType) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForChoiceType_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForChoiceType, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForLookupType) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_AddFieldFilterControlForLookupType_Method_Call_Internally(Type[] types)
        {
            var methodAddFieldFilterControlForLookupTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFieldFilterControlForLookupType, Fixture, methodAddFieldFilterControlForLookupTypePrametersTypes);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForLookupType) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForLookupType_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var field = CreateType<SPField>();
            var web = CreateType<SPWeb>();
            var methodAddFieldFilterControlForLookupTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField), typeof(SPWeb) };
            object[] parametersOfAddFieldFilterControlForLookupType = { mainDiv, field, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForLookupType, methodAddFieldFilterControlForLookupTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfAddFieldFilterControlForLookupType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddFieldFilterControlForLookupType.ShouldNotBeNull();
            parametersOfAddFieldFilterControlForLookupType.Length.ShouldBe(3);
            methodAddFieldFilterControlForLookupTypePrametersTypes.Length.ShouldBe(3);
            methodAddFieldFilterControlForLookupTypePrametersTypes.Length.ShouldBe(parametersOfAddFieldFilterControlForLookupType.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForLookupType) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForLookupType_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var field = CreateType<SPField>();
            var web = CreateType<SPWeb>();
            var methodAddFieldFilterControlForLookupTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField), typeof(SPWeb) };
            object[] parametersOfAddFieldFilterControlForLookupType = { mainDiv, field, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodAddFieldFilterControlForLookupType, parametersOfAddFieldFilterControlForLookupType, methodAddFieldFilterControlForLookupTypePrametersTypes);

            // Assert
            parametersOfAddFieldFilterControlForLookupType.ShouldNotBeNull();
            parametersOfAddFieldFilterControlForLookupType.Length.ShouldBe(3);
            methodAddFieldFilterControlForLookupTypePrametersTypes.Length.ShouldBe(3);
            methodAddFieldFilterControlForLookupTypePrametersTypes.Length.ShouldBe(parametersOfAddFieldFilterControlForLookupType.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForLookupType) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForLookupType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForLookupType, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForLookupType) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForLookupType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddFieldFilterControlForLookupTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFieldFilterControlForLookupType, Fixture, methodAddFieldFilterControlForLookupTypePrametersTypes);

            // Assert
            methodAddFieldFilterControlForLookupTypePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForLookupType) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForLookupType_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForLookupType, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForTextType) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_AddFieldFilterControlForTextType_Method_Call_Internally(Type[] types)
        {
            var methodAddFieldFilterControlForTextTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFieldFilterControlForTextType, Fixture, methodAddFieldFilterControlForTextTypePrametersTypes);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForTextType) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForTextType_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var field = CreateType<SPField>();
            var web = CreateType<SPWeb>();
            var methodAddFieldFilterControlForTextTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField), typeof(SPWeb) };
            object[] parametersOfAddFieldFilterControlForTextType = { mainDiv, field, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForTextType, methodAddFieldFilterControlForTextTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfAddFieldFilterControlForTextType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddFieldFilterControlForTextType.ShouldNotBeNull();
            parametersOfAddFieldFilterControlForTextType.Length.ShouldBe(3);
            methodAddFieldFilterControlForTextTypePrametersTypes.Length.ShouldBe(3);
            methodAddFieldFilterControlForTextTypePrametersTypes.Length.ShouldBe(parametersOfAddFieldFilterControlForTextType.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForTextType) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForTextType_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var field = CreateType<SPField>();
            var web = CreateType<SPWeb>();
            var methodAddFieldFilterControlForTextTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField), typeof(SPWeb) };
            object[] parametersOfAddFieldFilterControlForTextType = { mainDiv, field, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodAddFieldFilterControlForTextType, parametersOfAddFieldFilterControlForTextType, methodAddFieldFilterControlForTextTypePrametersTypes);

            // Assert
            parametersOfAddFieldFilterControlForTextType.ShouldNotBeNull();
            parametersOfAddFieldFilterControlForTextType.Length.ShouldBe(3);
            methodAddFieldFilterControlForTextTypePrametersTypes.Length.ShouldBe(3);
            methodAddFieldFilterControlForTextTypePrametersTypes.Length.ShouldBe(parametersOfAddFieldFilterControlForTextType.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForTextType) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForTextType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForTextType, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForTextType) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForTextType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddFieldFilterControlForTextTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFieldFilterControlForTextType, Fixture, methodAddFieldFilterControlForTextTypePrametersTypes);

            // Assert
            methodAddFieldFilterControlForTextTypePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForTextType) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForTextType_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForTextType, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForUserType) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_AddFieldFilterControlForUserType_Method_Call_Internally(Type[] types)
        {
            var methodAddFieldFilterControlForUserTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFieldFilterControlForUserType, Fixture, methodAddFieldFilterControlForUserTypePrametersTypes);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForUserType) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForUserType_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var field = CreateType<SPField>();
            var web = CreateType<SPWeb>();
            var methodAddFieldFilterControlForUserTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField), typeof(SPWeb) };
            object[] parametersOfAddFieldFilterControlForUserType = { mainDiv, field, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForUserType, methodAddFieldFilterControlForUserTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfAddFieldFilterControlForUserType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddFieldFilterControlForUserType.ShouldNotBeNull();
            parametersOfAddFieldFilterControlForUserType.Length.ShouldBe(3);
            methodAddFieldFilterControlForUserTypePrametersTypes.Length.ShouldBe(3);
            methodAddFieldFilterControlForUserTypePrametersTypes.Length.ShouldBe(parametersOfAddFieldFilterControlForUserType.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForUserType) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForUserType_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var field = CreateType<SPField>();
            var web = CreateType<SPWeb>();
            var methodAddFieldFilterControlForUserTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField), typeof(SPWeb) };
            object[] parametersOfAddFieldFilterControlForUserType = { mainDiv, field, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodAddFieldFilterControlForUserType, parametersOfAddFieldFilterControlForUserType, methodAddFieldFilterControlForUserTypePrametersTypes);

            // Assert
            parametersOfAddFieldFilterControlForUserType.ShouldNotBeNull();
            parametersOfAddFieldFilterControlForUserType.Length.ShouldBe(3);
            methodAddFieldFilterControlForUserTypePrametersTypes.Length.ShouldBe(3);
            methodAddFieldFilterControlForUserTypePrametersTypes.Length.ShouldBe(parametersOfAddFieldFilterControlForUserType.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForUserType) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForUserType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForUserType, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForUserType) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForUserType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddFieldFilterControlForUserTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFieldFilterControlForUserType, Fixture, methodAddFieldFilterControlForUserTypePrametersTypes);

            // Assert
            methodAddFieldFilterControlForUserTypePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForUserType) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForUserType_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForUserType, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForDateType) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_AddFieldFilterControlForDateType_Method_Call_Internally(Type[] types)
        {
            var methodAddFieldFilterControlForDateTypePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFieldFilterControlForDateType, Fixture, methodAddFieldFilterControlForDateTypePrametersTypes);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForDateType) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForDateType_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var field = CreateType<SPField>();
            var web = CreateType<SPWeb>();
            var methodAddFieldFilterControlForDateTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField), typeof(SPWeb) };
            object[] parametersOfAddFieldFilterControlForDateType = { mainDiv, field, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForDateType, methodAddFieldFilterControlForDateTypePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfAddFieldFilterControlForDateType);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddFieldFilterControlForDateType.ShouldNotBeNull();
            parametersOfAddFieldFilterControlForDateType.Length.ShouldBe(3);
            methodAddFieldFilterControlForDateTypePrametersTypes.Length.ShouldBe(3);
            methodAddFieldFilterControlForDateTypePrametersTypes.Length.ShouldBe(parametersOfAddFieldFilterControlForDateType.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForDateType) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForDateType_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var field = CreateType<SPField>();
            var web = CreateType<SPWeb>();
            var methodAddFieldFilterControlForDateTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField), typeof(SPWeb) };
            object[] parametersOfAddFieldFilterControlForDateType = { mainDiv, field, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodAddFieldFilterControlForDateType, parametersOfAddFieldFilterControlForDateType, methodAddFieldFilterControlForDateTypePrametersTypes);

            // Assert
            parametersOfAddFieldFilterControlForDateType.ShouldNotBeNull();
            parametersOfAddFieldFilterControlForDateType.Length.ShouldBe(3);
            methodAddFieldFilterControlForDateTypePrametersTypes.Length.ShouldBe(3);
            methodAddFieldFilterControlForDateTypePrametersTypes.Length.ShouldBe(parametersOfAddFieldFilterControlForDateType.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForDateType) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForDateType_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForDateType, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForDateType) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForDateType_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddFieldFilterControlForDateTypePrametersTypes = new Type[] { typeof(HtmlGenericControl), typeof(SPField), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFieldFilterControlForDateType, Fixture, methodAddFieldFilterControlForDateTypePrametersTypes);

            // Assert
            methodAddFieldFilterControlForDateTypePrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFieldFilterControlForDateType) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFieldFilterControlForDateType_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddFieldFilterControlForDateType, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetControlDiv) (Return Type : HtmlGenericControl) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetControlDiv_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetControlDivPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodGetControlDiv, Fixture, methodGetControlDivPrametersTypes);
        }

        #endregion

        #region Method Call : (GetControlDiv) (Return Type : HtmlGenericControl) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetControlDiv_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetControlDivPrametersTypes = null;
            object[] parametersOfGetControlDiv = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetControlDiv, methodGetControlDivPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfGetControlDiv);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetControlDiv.ShouldBeNull();
            methodGetControlDivPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetControlDiv) (Return Type : HtmlGenericControl) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetControlDiv_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetControlDivPrametersTypes = null;
            object[] parametersOfGetControlDiv = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<HtmlGenericControl>(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodGetControlDiv, parametersOfGetControlDiv, methodGetControlDivPrametersTypes);

            // Assert
            parametersOfGetControlDiv.ShouldBeNull();
            methodGetControlDivPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetControlDiv) (Return Type : HtmlGenericControl) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetControlDiv_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetControlDivPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodGetControlDiv, Fixture, methodGetControlDivPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetControlDivPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetControlDiv) (Return Type : HtmlGenericControl) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetControlDiv_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetControlDivPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodGetControlDiv, Fixture, methodGetControlDivPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetControlDivPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetControlDiv) (Return Type : HtmlGenericControl) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetControlDiv_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetControlDiv, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetControlDivForButton) (Return Type : HtmlGenericControl) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetControlDivForButton_Static_Method_Call_Internally(Type[] types)
        {
            var methodGetControlDivForButtonPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodGetControlDivForButton, Fixture, methodGetControlDivForButtonPrametersTypes);
        }

        #endregion

        #region Method Call : (GetControlDivForButton) (Return Type : HtmlGenericControl) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetControlDivForButton_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetControlDivForButtonPrametersTypes = null;
            object[] parametersOfGetControlDivForButton = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetControlDivForButton, methodGetControlDivForButtonPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfGetControlDivForButton);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetControlDivForButton.ShouldBeNull();
            methodGetControlDivForButtonPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetControlDivForButton) (Return Type : HtmlGenericControl) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetControlDivForButton_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetControlDivForButtonPrametersTypes = null;
            object[] parametersOfGetControlDivForButton = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<HtmlGenericControl>(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodGetControlDivForButton, parametersOfGetControlDivForButton, methodGetControlDivForButtonPrametersTypes);

            // Assert
            parametersOfGetControlDivForButton.ShouldBeNull();
            methodGetControlDivForButtonPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetControlDivForButton) (Return Type : HtmlGenericControl) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetControlDivForButton_Static_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetControlDivForButtonPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodGetControlDivForButton, Fixture, methodGetControlDivForButtonPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetControlDivForButtonPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetControlDivForButton) (Return Type : HtmlGenericControl) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetControlDivForButton_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetControlDivForButtonPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodGetControlDivForButton, Fixture, methodGetControlDivForButtonPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetControlDivForButtonPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetControlDivForButton) (Return Type : HtmlGenericControl) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetControlDivForButton_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetControlDivForButton, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (AddErrorLabelToMainDiv) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_AddErrorLabelToMainDiv_Method_Call_Internally(Type[] types)
        {
            var methodAddErrorLabelToMainDivPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddErrorLabelToMainDiv, Fixture, methodAddErrorLabelToMainDivPrametersTypes);
        }

        #endregion

        #region Method Call : (AddErrorLabelToMainDiv) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddErrorLabelToMainDiv_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var methodAddErrorLabelToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };
            object[] parametersOfAddErrorLabelToMainDiv = { mainDiv };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddErrorLabelToMainDiv, methodAddErrorLabelToMainDivPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfAddErrorLabelToMainDiv);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddErrorLabelToMainDiv.ShouldNotBeNull();
            parametersOfAddErrorLabelToMainDiv.Length.ShouldBe(1);
            methodAddErrorLabelToMainDivPrametersTypes.Length.ShouldBe(1);
            methodAddErrorLabelToMainDivPrametersTypes.Length.ShouldBe(parametersOfAddErrorLabelToMainDiv.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddErrorLabelToMainDiv) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddErrorLabelToMainDiv_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var methodAddErrorLabelToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };
            object[] parametersOfAddErrorLabelToMainDiv = { mainDiv };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodAddErrorLabelToMainDiv, parametersOfAddErrorLabelToMainDiv, methodAddErrorLabelToMainDivPrametersTypes);

            // Assert
            parametersOfAddErrorLabelToMainDiv.ShouldNotBeNull();
            parametersOfAddErrorLabelToMainDiv.Length.ShouldBe(1);
            methodAddErrorLabelToMainDivPrametersTypes.Length.ShouldBe(1);
            methodAddErrorLabelToMainDivPrametersTypes.Length.ShouldBe(parametersOfAddErrorLabelToMainDiv.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddErrorLabelToMainDiv) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddErrorLabelToMainDiv_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddErrorLabelToMainDiv, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddErrorLabelToMainDiv) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddErrorLabelToMainDiv_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddErrorLabelToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddErrorLabelToMainDiv, Fixture, methodAddErrorLabelToMainDivPrametersTypes);

            // Assert
            methodAddErrorLabelToMainDivPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddErrorLabelToMainDiv) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddErrorLabelToMainDiv_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddErrorLabelToMainDiv, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTitleDropDownToMainDiv) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_AddTitleDropDownToMainDiv_Method_Call_Internally(Type[] types)
        {
            var methodAddTitleDropDownToMainDivPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddTitleDropDownToMainDiv, Fixture, methodAddTitleDropDownToMainDivPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTitleDropDownToMainDiv) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddTitleDropDownToMainDiv_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var methodAddTitleDropDownToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };
            object[] parametersOfAddTitleDropDownToMainDiv = { mainDiv };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddTitleDropDownToMainDiv, methodAddTitleDropDownToMainDivPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfAddTitleDropDownToMainDiv);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddTitleDropDownToMainDiv.ShouldNotBeNull();
            parametersOfAddTitleDropDownToMainDiv.Length.ShouldBe(1);
            methodAddTitleDropDownToMainDivPrametersTypes.Length.ShouldBe(1);
            methodAddTitleDropDownToMainDivPrametersTypes.Length.ShouldBe(parametersOfAddTitleDropDownToMainDiv.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTitleDropDownToMainDiv) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddTitleDropDownToMainDiv_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var methodAddTitleDropDownToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };
            object[] parametersOfAddTitleDropDownToMainDiv = { mainDiv };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodAddTitleDropDownToMainDiv, parametersOfAddTitleDropDownToMainDiv, methodAddTitleDropDownToMainDivPrametersTypes);

            // Assert
            parametersOfAddTitleDropDownToMainDiv.ShouldNotBeNull();
            parametersOfAddTitleDropDownToMainDiv.Length.ShouldBe(1);
            methodAddTitleDropDownToMainDivPrametersTypes.Length.ShouldBe(1);
            methodAddTitleDropDownToMainDivPrametersTypes.Length.ShouldBe(parametersOfAddTitleDropDownToMainDiv.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTitleDropDownToMainDiv) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddTitleDropDownToMainDiv_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddTitleDropDownToMainDiv, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddTitleDropDownToMainDiv) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddTitleDropDownToMainDiv_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddTitleDropDownToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddTitleDropDownToMainDiv, Fixture, methodAddTitleDropDownToMainDivPrametersTypes);

            // Assert
            methodAddTitleDropDownToMainDivPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTitleDropDownToMainDiv) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddTitleDropDownToMainDiv_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTitleDropDownToMainDiv, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTitleButtonToMainDiv) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_AddTitleButtonToMainDiv_Method_Call_Internally(Type[] types)
        {
            var methodAddTitleButtonToMainDivPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddTitleButtonToMainDiv, Fixture, methodAddTitleButtonToMainDivPrametersTypes);
        }

        #endregion

        #region Method Call : (AddTitleButtonToMainDiv) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddTitleButtonToMainDiv_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var methodAddTitleButtonToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };
            object[] parametersOfAddTitleButtonToMainDiv = { mainDiv };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddTitleButtonToMainDiv, methodAddTitleButtonToMainDivPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfAddTitleButtonToMainDiv);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddTitleButtonToMainDiv.ShouldNotBeNull();
            parametersOfAddTitleButtonToMainDiv.Length.ShouldBe(1);
            methodAddTitleButtonToMainDivPrametersTypes.Length.ShouldBe(1);
            methodAddTitleButtonToMainDivPrametersTypes.Length.ShouldBe(parametersOfAddTitleButtonToMainDiv.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTitleButtonToMainDiv) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddTitleButtonToMainDiv_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var methodAddTitleButtonToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };
            object[] parametersOfAddTitleButtonToMainDiv = { mainDiv };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodAddTitleButtonToMainDiv, parametersOfAddTitleButtonToMainDiv, methodAddTitleButtonToMainDivPrametersTypes);

            // Assert
            parametersOfAddTitleButtonToMainDiv.ShouldNotBeNull();
            parametersOfAddTitleButtonToMainDiv.Length.ShouldBe(1);
            methodAddTitleButtonToMainDivPrametersTypes.Length.ShouldBe(1);
            methodAddTitleButtonToMainDivPrametersTypes.Length.ShouldBe(parametersOfAddTitleButtonToMainDiv.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTitleButtonToMainDiv) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddTitleButtonToMainDiv_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddTitleButtonToMainDiv, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddTitleButtonToMainDiv) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddTitleButtonToMainDiv_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddTitleButtonToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddTitleButtonToMainDiv, Fixture, methodAddTitleButtonToMainDivPrametersTypes);

            // Assert
            methodAddTitleButtonToMainDivPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddTitleButtonToMainDiv) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddTitleButtonToMainDiv_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddTitleButtonToMainDiv, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFilterButtonToMainDiv) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_AddFilterButtonToMainDiv_Method_Call_Internally(Type[] types)
        {
            var methodAddFilterButtonToMainDivPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFilterButtonToMainDiv, Fixture, methodAddFilterButtonToMainDivPrametersTypes);
        }

        #endregion

        #region Method Call : (AddFilterButtonToMainDiv) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFilterButtonToMainDiv_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var methodAddFilterButtonToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };
            object[] parametersOfAddFilterButtonToMainDiv = { mainDiv };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodAddFilterButtonToMainDiv, methodAddFilterButtonToMainDivPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfAddFilterButtonToMainDiv);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfAddFilterButtonToMainDiv.ShouldNotBeNull();
            parametersOfAddFilterButtonToMainDiv.Length.ShouldBe(1);
            methodAddFilterButtonToMainDivPrametersTypes.Length.ShouldBe(1);
            methodAddFilterButtonToMainDivPrametersTypes.Length.ShouldBe(parametersOfAddFilterButtonToMainDiv.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (AddFilterButtonToMainDiv) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFilterButtonToMainDiv_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var mainDiv = CreateType<HtmlGenericControl>();
            var methodAddFilterButtonToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };
            object[] parametersOfAddFilterButtonToMainDiv = { mainDiv };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodAddFilterButtonToMainDiv, parametersOfAddFilterButtonToMainDiv, methodAddFilterButtonToMainDivPrametersTypes);

            // Assert
            parametersOfAddFilterButtonToMainDiv.ShouldNotBeNull();
            parametersOfAddFilterButtonToMainDiv.Length.ShouldBe(1);
            methodAddFilterButtonToMainDivPrametersTypes.Length.ShouldBe(1);
            methodAddFilterButtonToMainDivPrametersTypes.Length.ShouldBe(parametersOfAddFilterButtonToMainDiv.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFilterButtonToMainDiv) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFilterButtonToMainDiv_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodAddFilterButtonToMainDiv, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (AddFilterButtonToMainDiv) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFilterButtonToMainDiv_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodAddFilterButtonToMainDivPrametersTypes = new Type[] { typeof(HtmlGenericControl) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodAddFilterButtonToMainDiv, Fixture, methodAddFilterButtonToMainDivPrametersTypes);

            // Assert
            methodAddFilterButtonToMainDivPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (AddFilterButtonToMainDiv) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_AddFilterButtonToMainDiv_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodAddFilterButtonToMainDiv, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateOperatorDropDown) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_PopulateOperatorDropDown_Method_Call_Internally(Type[] types)
        {
            var methodPopulateOperatorDropDownPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodPopulateOperatorDropDown, Fixture, methodPopulateOperatorDropDownPrametersTypes);
        }

        #endregion

        #region Method Call : (PopulateOperatorDropDown) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PopulateOperatorDropDown_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodPopulateOperatorDropDownPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfPopulateOperatorDropDown = { field };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPopulateOperatorDropDown, methodPopulateOperatorDropDownPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfPopulateOperatorDropDown);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPopulateOperatorDropDown.ShouldNotBeNull();
            parametersOfPopulateOperatorDropDown.Length.ShouldBe(1);
            methodPopulateOperatorDropDownPrametersTypes.Length.ShouldBe(1);
            methodPopulateOperatorDropDownPrametersTypes.Length.ShouldBe(parametersOfPopulateOperatorDropDown.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PopulateOperatorDropDown) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PopulateOperatorDropDown_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var methodPopulateOperatorDropDownPrametersTypes = new Type[] { typeof(SPField) };
            object[] parametersOfPopulateOperatorDropDown = { field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodPopulateOperatorDropDown, parametersOfPopulateOperatorDropDown, methodPopulateOperatorDropDownPrametersTypes);

            // Assert
            parametersOfPopulateOperatorDropDown.ShouldNotBeNull();
            parametersOfPopulateOperatorDropDown.Length.ShouldBe(1);
            methodPopulateOperatorDropDownPrametersTypes.Length.ShouldBe(1);
            methodPopulateOperatorDropDownPrametersTypes.Length.ShouldBe(parametersOfPopulateOperatorDropDown.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateOperatorDropDown) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PopulateOperatorDropDown_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPopulateOperatorDropDown, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PopulateOperatorDropDown) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PopulateOperatorDropDown_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPopulateOperatorDropDownPrametersTypes = new Type[] { typeof(SPField) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodPopulateOperatorDropDown, Fixture, methodPopulateOperatorDropDownPrametersTypes);

            // Assert
            methodPopulateOperatorDropDownPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PopulateOperatorDropDown) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PopulateOperatorDropDown_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPopulateOperatorDropDown, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCamlQueryOperator) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetCamlQueryOperator_Method_Call_Internally(Type[] types)
        {
            var methodGetCamlQueryOperatorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetCamlQueryOperator, Fixture, methodGetCamlQueryOperatorPrametersTypes);
        }

        #endregion

        #region Method Call : (GetCamlQueryOperator) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetCamlQueryOperator_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetCamlQueryOperatorPrametersTypes = null;
            object[] parametersOfGetCamlQueryOperator = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetCamlQueryOperator, methodGetCamlQueryOperatorPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingFilter, string>(_reportingFilterInstanceFixture, out exception1, parametersOfGetCamlQueryOperator);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, string>(_reportingFilterInstance, MethodGetCamlQueryOperator, parametersOfGetCamlQueryOperator, methodGetCamlQueryOperatorPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetCamlQueryOperator.ShouldBeNull();
            methodGetCamlQueryOperatorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCamlQueryOperator) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetCamlQueryOperator_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetCamlQueryOperatorPrametersTypes = null;
            object[] parametersOfGetCamlQueryOperator = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetCamlQueryOperator, methodGetCamlQueryOperatorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfGetCamlQueryOperator);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetCamlQueryOperator.ShouldBeNull();
            methodGetCamlQueryOperatorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCamlQueryOperator) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetCamlQueryOperator_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetCamlQueryOperatorPrametersTypes = null;
            object[] parametersOfGetCamlQueryOperator = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, string>(_reportingFilterInstance, MethodGetCamlQueryOperator, parametersOfGetCamlQueryOperator, methodGetCamlQueryOperatorPrametersTypes);

            // Assert
            parametersOfGetCamlQueryOperator.ShouldBeNull();
            methodGetCamlQueryOperatorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetCamlQueryOperator) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetCamlQueryOperator_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetCamlQueryOperatorPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetCamlQueryOperator, Fixture, methodGetCamlQueryOperatorPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetCamlQueryOperatorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCamlQueryOperator) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetCamlQueryOperator_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetCamlQueryOperatorPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetCamlQueryOperator, Fixture, methodGetCamlQueryOperatorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetCamlQueryOperatorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetCamlQueryOperator) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetCamlQueryOperator_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetCamlQueryOperator, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (DisplayErrors) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_DisplayErrors_Method_Call_Internally(Type[] types)
        {
            var methodDisplayErrorsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodDisplayErrors, Fixture, methodDisplayErrorsPrametersTypes);
        }

        #endregion

        #region Method Call : (DisplayErrors) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_DisplayErrors_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var filteredTitles = CreateType<ReportFilterSelection>();
            var methodDisplayErrorsPrametersTypes = new Type[] { typeof(ReportFilterSelection) };
            object[] parametersOfDisplayErrors = { filteredTitles };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodDisplayErrors, parametersOfDisplayErrors, methodDisplayErrorsPrametersTypes);

            // Assert
            parametersOfDisplayErrors.ShouldNotBeNull();
            parametersOfDisplayErrors.Length.ShouldBe(1);
            methodDisplayErrorsPrametersTypes.Length.ShouldBe(1);
            methodDisplayErrorsPrametersTypes.Length.ShouldBe(parametersOfDisplayErrors.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisplayErrors) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_DisplayErrors_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodDisplayErrors, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (DisplayErrors) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_DisplayErrors_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodDisplayErrorsPrametersTypes = new Type[] { typeof(ReportFilterSelection) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodDisplayErrors, Fixture, methodDisplayErrorsPrametersTypes);

            // Assert
            methodDisplayErrorsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (DisplayErrors) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_DisplayErrors_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodDisplayErrors, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsDateTime) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_SetSelectedValueForFieldAsDateTime_Method_Call_Internally(Type[] types)
        {
            var methodSetSelectedValueForFieldAsDateTimePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodSetSelectedValueForFieldAsDateTime, Fixture, methodSetSelectedValueForFieldAsDateTimePrametersTypes);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsDateTime) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsDateTime_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var list = CreateType<SPList>();
            var methodSetSelectedValueForFieldAsDateTimePrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };
            object[] parametersOfSetSelectedValueForFieldAsDateTime = { persistedValues, list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSelectedValueForFieldAsDateTime, methodSetSelectedValueForFieldAsDateTimePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfSetSelectedValueForFieldAsDateTime);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetSelectedValueForFieldAsDateTime.ShouldNotBeNull();
            parametersOfSetSelectedValueForFieldAsDateTime.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsDateTimePrametersTypes.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsDateTimePrametersTypes.Length.ShouldBe(parametersOfSetSelectedValueForFieldAsDateTime.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsDateTime) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsDateTime_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var list = CreateType<SPList>();
            var methodSetSelectedValueForFieldAsDateTimePrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };
            object[] parametersOfSetSelectedValueForFieldAsDateTime = { persistedValues, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodSetSelectedValueForFieldAsDateTime, parametersOfSetSelectedValueForFieldAsDateTime, methodSetSelectedValueForFieldAsDateTimePrametersTypes);

            // Assert
            parametersOfSetSelectedValueForFieldAsDateTime.ShouldNotBeNull();
            parametersOfSetSelectedValueForFieldAsDateTime.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsDateTimePrametersTypes.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsDateTimePrametersTypes.Length.ShouldBe(parametersOfSetSelectedValueForFieldAsDateTime.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsDateTime) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsDateTime_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSelectedValueForFieldAsDateTime, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsDateTime) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsDateTime_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSelectedValueForFieldAsDateTimePrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodSetSelectedValueForFieldAsDateTime, Fixture, methodSetSelectedValueForFieldAsDateTimePrametersTypes);

            // Assert
            methodSetSelectedValueForFieldAsDateTimePrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsDateTime) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsDateTime_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSelectedValueForFieldAsDateTime, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsPeopleEditor) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_SetSelectedValueForFieldAsPeopleEditor_Method_Call_Internally(Type[] types)
        {
            var methodSetSelectedValueForFieldAsPeopleEditorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodSetSelectedValueForFieldAsPeopleEditor, Fixture, methodSetSelectedValueForFieldAsPeopleEditorPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsPeopleEditor) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsPeopleEditor_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var list = CreateType<SPList>();
            var methodSetSelectedValueForFieldAsPeopleEditorPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };
            object[] parametersOfSetSelectedValueForFieldAsPeopleEditor = { persistedValues, list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSelectedValueForFieldAsPeopleEditor, methodSetSelectedValueForFieldAsPeopleEditorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfSetSelectedValueForFieldAsPeopleEditor);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetSelectedValueForFieldAsPeopleEditor.ShouldNotBeNull();
            parametersOfSetSelectedValueForFieldAsPeopleEditor.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsPeopleEditorPrametersTypes.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsPeopleEditorPrametersTypes.Length.ShouldBe(parametersOfSetSelectedValueForFieldAsPeopleEditor.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsPeopleEditor) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsPeopleEditor_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var list = CreateType<SPList>();
            var methodSetSelectedValueForFieldAsPeopleEditorPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };
            object[] parametersOfSetSelectedValueForFieldAsPeopleEditor = { persistedValues, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodSetSelectedValueForFieldAsPeopleEditor, parametersOfSetSelectedValueForFieldAsPeopleEditor, methodSetSelectedValueForFieldAsPeopleEditorPrametersTypes);

            // Assert
            parametersOfSetSelectedValueForFieldAsPeopleEditor.ShouldNotBeNull();
            parametersOfSetSelectedValueForFieldAsPeopleEditor.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsPeopleEditorPrametersTypes.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsPeopleEditorPrametersTypes.Length.ShouldBe(parametersOfSetSelectedValueForFieldAsPeopleEditor.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsPeopleEditor) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsPeopleEditor_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSelectedValueForFieldAsPeopleEditor, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsPeopleEditor) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsPeopleEditor_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSelectedValueForFieldAsPeopleEditorPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodSetSelectedValueForFieldAsPeopleEditor, Fixture, methodSetSelectedValueForFieldAsPeopleEditorPrametersTypes);

            // Assert
            methodSetSelectedValueForFieldAsPeopleEditorPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsPeopleEditor) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsPeopleEditor_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSelectedValueForFieldAsPeopleEditor, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsTextBox) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_SetSelectedValueForFieldAsTextBox_Method_Call_Internally(Type[] types)
        {
            var methodSetSelectedValueForFieldAsTextBoxPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodSetSelectedValueForFieldAsTextBox, Fixture, methodSetSelectedValueForFieldAsTextBoxPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsTextBox) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsTextBox_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var list = CreateType<SPList>();
            var methodSetSelectedValueForFieldAsTextBoxPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };
            object[] parametersOfSetSelectedValueForFieldAsTextBox = { persistedValues, list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSelectedValueForFieldAsTextBox, methodSetSelectedValueForFieldAsTextBoxPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfSetSelectedValueForFieldAsTextBox);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetSelectedValueForFieldAsTextBox.ShouldNotBeNull();
            parametersOfSetSelectedValueForFieldAsTextBox.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsTextBoxPrametersTypes.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsTextBoxPrametersTypes.Length.ShouldBe(parametersOfSetSelectedValueForFieldAsTextBox.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsTextBox) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsTextBox_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var list = CreateType<SPList>();
            var methodSetSelectedValueForFieldAsTextBoxPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };
            object[] parametersOfSetSelectedValueForFieldAsTextBox = { persistedValues, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodSetSelectedValueForFieldAsTextBox, parametersOfSetSelectedValueForFieldAsTextBox, methodSetSelectedValueForFieldAsTextBoxPrametersTypes);

            // Assert
            parametersOfSetSelectedValueForFieldAsTextBox.ShouldNotBeNull();
            parametersOfSetSelectedValueForFieldAsTextBox.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsTextBoxPrametersTypes.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsTextBoxPrametersTypes.Length.ShouldBe(parametersOfSetSelectedValueForFieldAsTextBox.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsTextBox) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsTextBox_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSelectedValueForFieldAsTextBox, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsTextBox) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsTextBox_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSelectedValueForFieldAsTextBoxPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodSetSelectedValueForFieldAsTextBox, Fixture, methodSetSelectedValueForFieldAsTextBoxPrametersTypes);

            // Assert
            methodSetSelectedValueForFieldAsTextBoxPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsTextBox) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsTextBox_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSelectedValueForFieldAsTextBox, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsListBox) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_SetSelectedValueForFieldAsListBox_Method_Call_Internally(Type[] types)
        {
            var methodSetSelectedValueForFieldAsListBoxPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodSetSelectedValueForFieldAsListBox, Fixture, methodSetSelectedValueForFieldAsListBoxPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsListBox) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsListBox_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var list = CreateType<SPList>();
            var methodSetSelectedValueForFieldAsListBoxPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };
            object[] parametersOfSetSelectedValueForFieldAsListBox = { persistedValues, list };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSelectedValueForFieldAsListBox, methodSetSelectedValueForFieldAsListBoxPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfSetSelectedValueForFieldAsListBox);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetSelectedValueForFieldAsListBox.ShouldNotBeNull();
            parametersOfSetSelectedValueForFieldAsListBox.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsListBoxPrametersTypes.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsListBoxPrametersTypes.Length.ShouldBe(parametersOfSetSelectedValueForFieldAsListBox.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsListBox) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsListBox_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var list = CreateType<SPList>();
            var methodSetSelectedValueForFieldAsListBoxPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };
            object[] parametersOfSetSelectedValueForFieldAsListBox = { persistedValues, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodSetSelectedValueForFieldAsListBox, parametersOfSetSelectedValueForFieldAsListBox, methodSetSelectedValueForFieldAsListBoxPrametersTypes);

            // Assert
            parametersOfSetSelectedValueForFieldAsListBox.ShouldNotBeNull();
            parametersOfSetSelectedValueForFieldAsListBox.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsListBoxPrametersTypes.Length.ShouldBe(2);
            methodSetSelectedValueForFieldAsListBoxPrametersTypes.Length.ShouldBe(parametersOfSetSelectedValueForFieldAsListBox.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsListBox) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsListBox_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSelectedValueForFieldAsListBox, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsListBox) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsListBox_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSelectedValueForFieldAsListBoxPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodSetSelectedValueForFieldAsListBox, Fixture, methodSetSelectedValueForFieldAsListBoxPrametersTypes);

            // Assert
            methodSetSelectedValueForFieldAsListBoxPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedValueForFieldAsListBox) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedValueForFieldAsListBox_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSelectedValueForFieldAsListBox, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedFieldValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_SetSelectedFieldValues_Method_Call_Internally(Type[] types)
        {
            var methodSetSelectedFieldValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodSetSelectedFieldValues, Fixture, methodSetSelectedFieldValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSelectedFieldValues) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedFieldValues_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var spList = CreateType<SPList>();
            var methodSetSelectedFieldValuesPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };
            object[] parametersOfSetSelectedFieldValues = { persistedValues, spList };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodSetSelectedFieldValues, methodSetSelectedFieldValuesPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfSetSelectedFieldValues);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfSetSelectedFieldValues.ShouldNotBeNull();
            parametersOfSetSelectedFieldValues.Length.ShouldBe(2);
            methodSetSelectedFieldValuesPrametersTypes.Length.ShouldBe(2);
            methodSetSelectedFieldValuesPrametersTypes.Length.ShouldBe(parametersOfSetSelectedFieldValues.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedFieldValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedFieldValues_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var spList = CreateType<SPList>();
            var methodSetSelectedFieldValuesPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };
            object[] parametersOfSetSelectedFieldValues = { persistedValues, spList };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodSetSelectedFieldValues, parametersOfSetSelectedFieldValues, methodSetSelectedFieldValuesPrametersTypes);

            // Assert
            parametersOfSetSelectedFieldValues.ShouldNotBeNull();
            parametersOfSetSelectedFieldValues.Length.ShouldBe(2);
            methodSetSelectedFieldValuesPrametersTypes.Length.ShouldBe(2);
            methodSetSelectedFieldValuesPrametersTypes.Length.ShouldBe(parametersOfSetSelectedFieldValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedFieldValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedFieldValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSelectedFieldValues, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSelectedFieldValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedFieldValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSelectedFieldValuesPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPList) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodSetSelectedFieldValues, Fixture, methodSetSelectedFieldValuesPrametersTypes);

            // Assert
            methodSetSelectedFieldValuesPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedFieldValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedFieldValues_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSelectedFieldValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedTitleValues) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_SetSelectedTitleValues_Method_Call_Internally(Type[] types)
        {
            var methodSetSelectedTitleValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodSetSelectedTitleValues, Fixture, methodSetSelectedTitleValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (SetSelectedTitleValues) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedTitleValues_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var methodSetSelectedTitleValuesPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            object[] parametersOfSetSelectedTitleValues = { persistedValues };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodSetSelectedTitleValues, parametersOfSetSelectedTitleValues, methodSetSelectedTitleValuesPrametersTypes);

            // Assert
            parametersOfSetSelectedTitleValues.ShouldNotBeNull();
            parametersOfSetSelectedTitleValues.Length.ShouldBe(1);
            methodSetSelectedTitleValuesPrametersTypes.Length.ShouldBe(1);
            methodSetSelectedTitleValuesPrametersTypes.Length.ShouldBe(parametersOfSetSelectedTitleValues.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedTitleValues) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedTitleValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodSetSelectedTitleValues, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (SetSelectedTitleValues) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedTitleValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodSetSelectedTitleValuesPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodSetSelectedTitleValues, Fixture, methodSetSelectedTitleValuesPrametersTypes);

            // Assert
            methodSetSelectedTitleValuesPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (SetSelectedTitleValues) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_SetSelectedTitleValues_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodSetSelectedTitleValues, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetPersistedSettings_Method_Call_Internally(Type[] types)
        {
            var methodGetPersistedSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetPersistedSettings, Fixture, methodGetPersistedSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetPersistedSettings_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetPersistedSettingsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetPersistedSettings = { web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetPersistedSettings, methodGetPersistedSettingsPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingFilter, ReportFilterUserSettings>(_reportingFilterInstanceFixture, out exception1, parametersOfGetPersistedSettings);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, ReportFilterUserSettings>(_reportingFilterInstance, MethodGetPersistedSettings, parametersOfGetPersistedSettings, methodGetPersistedSettingsPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetPersistedSettings.ShouldNotBeNull();
            parametersOfGetPersistedSettings.Length.ShouldBe(1);
            methodGetPersistedSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetPersistedSettings_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var methodGetPersistedSettingsPrametersTypes = new Type[] { typeof(SPWeb) };
            object[] parametersOfGetPersistedSettings = { web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, ReportFilterUserSettings>(_reportingFilterInstance, MethodGetPersistedSettings, parametersOfGetPersistedSettings, methodGetPersistedSettingsPrametersTypes);

            // Assert
            parametersOfGetPersistedSettings.ShouldNotBeNull();
            parametersOfGetPersistedSettings.Length.ShouldBe(1);
            methodGetPersistedSettingsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetPersistedSettings_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetPersistedSettingsPrametersTypes = new Type[] { typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetPersistedSettings, Fixture, methodGetPersistedSettingsPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetPersistedSettingsPrametersTypes.Length.ShouldBe(1);
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetPersistedSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetPersistedSettingsPrametersTypes = new Type[] { typeof(SPWeb) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetPersistedSettings, Fixture, methodGetPersistedSettingsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetPersistedSettingsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetPersistedSettings_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetPersistedSettings, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetPersistedSettings) (Return Type : ReportFilterUserSettings) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetPersistedSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetPersistedSettings, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_PersistUserSettings_Method_Call_Internally(Type[] types)
        {
            var methodPersistUserSettingsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodPersistUserSettings, Fixture, methodPersistUserSettingsPrametersTypes);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistUserSettings_Method_Call_Void_With_2_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var web = CreateType<SPWeb>();
            var methodPersistUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPWeb) };
            object[] parametersOfPersistUserSettings = { userSettings, web };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPersistUserSettings, methodPersistUserSettingsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfPersistUserSettings);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPersistUserSettings.ShouldNotBeNull();
            parametersOfPersistUserSettings.Length.ShouldBe(2);
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(2);
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(parametersOfPersistUserSettings.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistUserSettings_Method_Call_Void_With_2_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var web = CreateType<SPWeb>();
            var methodPersistUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPWeb) };
            object[] parametersOfPersistUserSettings = { userSettings, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodPersistUserSettings, parametersOfPersistUserSettings, methodPersistUserSettingsPrametersTypes);

            // Assert
            parametersOfPersistUserSettings.ShouldNotBeNull();
            parametersOfPersistUserSettings.Length.ShouldBe(2);
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(2);
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(parametersOfPersistUserSettings.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistUserSettings_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPersistUserSettings, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistUserSettings_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPersistUserSettingsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPWeb) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodPersistUserSettings, Fixture, methodPersistUserSettingsPrametersTypes);

            // Assert
            methodPersistUserSettingsPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistUserSettings) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistUserSettings_Method_Call_With_2_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPersistUserSettings, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetFieldSelection_Method_Call_Internally(Type[] types)
        {
            var methodGetFieldSelectionPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetFieldSelection, Fixture, methodGetFieldSelectionPrametersTypes);
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetFieldSelection_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var web = CreateType<SPWeb>();
            var methodGetFieldSelectionPrametersTypes = new Type[] { typeof(SPField), typeof(SPWeb) };
            object[] parametersOfGetFieldSelection = { field, web };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetFieldSelection, methodGetFieldSelectionPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingFilter, ReportFilterSelection>(_reportingFilterInstanceFixture, out exception1, parametersOfGetFieldSelection);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, ReportFilterSelection>(_reportingFilterInstance, MethodGetFieldSelection, parametersOfGetFieldSelection, methodGetFieldSelectionPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetFieldSelection.ShouldNotBeNull();
            parametersOfGetFieldSelection.Length.ShouldBe(2);
            methodGetFieldSelectionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetFieldSelection_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var field = CreateType<SPField>();
            var web = CreateType<SPWeb>();
            var methodGetFieldSelectionPrametersTypes = new Type[] { typeof(SPField), typeof(SPWeb) };
            object[] parametersOfGetFieldSelection = { field, web };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, ReportFilterSelection>(_reportingFilterInstance, MethodGetFieldSelection, parametersOfGetFieldSelection, methodGetFieldSelectionPrametersTypes);

            // Assert
            parametersOfGetFieldSelection.ShouldNotBeNull();
            parametersOfGetFieldSelection.Length.ShouldBe(2);
            methodGetFieldSelectionPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetFieldSelection_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetFieldSelectionPrametersTypes = new Type[] { typeof(SPField), typeof(SPWeb) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetFieldSelection, Fixture, methodGetFieldSelectionPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetFieldSelectionPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetFieldSelection_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetFieldSelectionPrametersTypes = new Type[] { typeof(SPField), typeof(SPWeb) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetFieldSelection, Fixture, methodGetFieldSelectionPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetFieldSelectionPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetFieldSelection_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetFieldSelection, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetFieldSelection) (Return Type : ReportFilterSelection) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetFieldSelection_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetFieldSelection, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetSelectedPeoplePickerUsers) (Return Type : string[]) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetSelectedPeoplePickerUsers_Method_Call_Internally(Type[] types)
        {
            var methodGetSelectedPeoplePickerUsersPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetSelectedPeoplePickerUsers, Fixture, methodGetSelectedPeoplePickerUsersPrametersTypes);
        }

        #endregion

        #region Method Call : (GetSelectedPeoplePickerUsers) (Return Type : string[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetSelectedPeoplePickerUsers_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSelectedPeoplePickerUsersPrametersTypes = null;
            object[] parametersOfGetSelectedPeoplePickerUsers = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetSelectedPeoplePickerUsers, methodGetSelectedPeoplePickerUsersPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingFilter, string[]>(_reportingFilterInstanceFixture, out exception1, parametersOfGetSelectedPeoplePickerUsers);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, string[]>(_reportingFilterInstance, MethodGetSelectedPeoplePickerUsers, parametersOfGetSelectedPeoplePickerUsers, methodGetSelectedPeoplePickerUsersPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetSelectedPeoplePickerUsers.ShouldBeNull();
            methodGetSelectedPeoplePickerUsersPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSelectedPeoplePickerUsers) (Return Type : string[]) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetSelectedPeoplePickerUsers_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetSelectedPeoplePickerUsersPrametersTypes = null;
            object[] parametersOfGetSelectedPeoplePickerUsers = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, string[]>(_reportingFilterInstance, MethodGetSelectedPeoplePickerUsers, parametersOfGetSelectedPeoplePickerUsers, methodGetSelectedPeoplePickerUsersPrametersTypes);

            // Assert
            parametersOfGetSelectedPeoplePickerUsers.ShouldBeNull();
            methodGetSelectedPeoplePickerUsersPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetSelectedPeoplePickerUsers) (Return Type : string[]) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetSelectedPeoplePickerUsers_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetSelectedPeoplePickerUsersPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetSelectedPeoplePickerUsers, Fixture, methodGetSelectedPeoplePickerUsersPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetSelectedPeoplePickerUsersPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSelectedPeoplePickerUsers) (Return Type : string[]) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetSelectedPeoplePickerUsers_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetSelectedPeoplePickerUsersPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetSelectedPeoplePickerUsers, Fixture, methodGetSelectedPeoplePickerUsersPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetSelectedPeoplePickerUsersPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetSelectedPeoplePickerUsers) (Return Type : string[]) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetSelectedPeoplePickerUsers_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetSelectedPeoplePickerUsers, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetTitlesToPersist) (Return Type : List<string>) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetTitlesToPersist_Method_Call_Internally(Type[] types)
        {
            var methodGetTitlesToPersistPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetTitlesToPersist, Fixture, methodGetTitlesToPersistPrametersTypes);
        }

        #endregion

        #region Method Call : (GetTitlesToPersist) (Return Type : List<string>) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetTitlesToPersist_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var web = CreateType<SPWeb>();
            var fieldSelection = CreateType<ReportFilterSelection>();
            var methodGetTitlesToPersistPrametersTypes = new Type[] { typeof(SPWeb), typeof(ReportFilterSelection) };
            object[] parametersOfGetTitlesToPersist = { web, fieldSelection };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, List<string>>(_reportingFilterInstance, MethodGetTitlesToPersist, parametersOfGetTitlesToPersist, methodGetTitlesToPersistPrametersTypes);

            // Assert
            parametersOfGetTitlesToPersist.ShouldNotBeNull();
            parametersOfGetTitlesToPersist.Length.ShouldBe(2);
            methodGetTitlesToPersistPrametersTypes.Length.ShouldBe(2);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetTitlesToPersist) (Return Type : List<string>) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetTitlesToPersist_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetTitlesToPersistPrametersTypes = new Type[] { typeof(SPWeb), typeof(ReportFilterSelection) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetTitlesToPersist, Fixture, methodGetTitlesToPersistPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetTitlesToPersistPrametersTypes.Length.ShouldBe(2);
        }

        #endregion

        #region Method Call : (GetTitlesToPersist) (Return Type : List<string>) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetTitlesToPersist_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetTitlesToPersistPrametersTypes = new Type[] { typeof(SPWeb), typeof(ReportFilterSelection) };
            const int parametersCount = 2;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetTitlesToPersist, Fixture, methodGetTitlesToPersistPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetTitlesToPersistPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetTitlesToPersist) (Return Type : List<string>) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetTitlesToPersist_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetTitlesToPersist, 0);
            const int parametersCount = 2;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UserHasPersistedSelections) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_UserHasPersistedSelections_Static_Method_Call_Internally(Type[] types)
        {
            var methodUserHasPersistedSelectionsPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodUserHasPersistedSelections, Fixture, methodUserHasPersistedSelectionsPrametersTypes);
        }

        #endregion

        #region Method Call : (UserHasPersistedSelections) (Return Type : bool) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_UserHasPersistedSelections_Static_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var methodUserHasPersistedSelectionsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            object[] parametersOfUserHasPersistedSelections = { persistedValues };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUserHasPersistedSelections, methodUserHasPersistedSelectionsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfUserHasPersistedSelections);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUserHasPersistedSelections.ShouldNotBeNull();
            parametersOfUserHasPersistedSelections.Length.ShouldBe(1);
            methodUserHasPersistedSelectionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UserHasPersistedSelections) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_UserHasPersistedSelections_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var methodUserHasPersistedSelectionsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            object[] parametersOfUserHasPersistedSelections = { persistedValues };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodUserHasPersistedSelections, parametersOfUserHasPersistedSelections, methodUserHasPersistedSelectionsPrametersTypes);

            // Assert
            parametersOfUserHasPersistedSelections.ShouldNotBeNull();
            parametersOfUserHasPersistedSelections.Length.ShouldBe(1);
            methodUserHasPersistedSelectionsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UserHasPersistedSelections) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_UserHasPersistedSelections_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUserHasPersistedSelectionsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            const int parametersCount = 1;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodUserHasPersistedSelections, Fixture, methodUserHasPersistedSelectionsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodUserHasPersistedSelectionsPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UserHasPersistedSelections) (Return Type : bool) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_UserHasPersistedSelections_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUserHasPersistedSelections, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (UserHasPersistedSelections) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_UserHasPersistedSelections_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUserHasPersistedSelections, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PersistDefaultValuesIfPersistedSettingsAreInvalid) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_PersistDefaultValuesIfPersistedSettingsAreInvalid_Method_Call_Internally(Type[] types)
        {
            var methodPersistDefaultValuesIfPersistedSettingsAreInvalidPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodPersistDefaultValuesIfPersistedSettingsAreInvalid, Fixture, methodPersistDefaultValuesIfPersistedSettingsAreInvalidPrametersTypes);
        }

        #endregion

        #region Method Call : (PersistDefaultValuesIfPersistedSettingsAreInvalid) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistDefaultValuesIfPersistedSettingsAreInvalid_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var methodPersistDefaultValuesIfPersistedSettingsAreInvalidPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            object[] parametersOfPersistDefaultValuesIfPersistedSettingsAreInvalid = { userSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodPersistDefaultValuesIfPersistedSettingsAreInvalid, methodPersistDefaultValuesIfPersistedSettingsAreInvalidPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfPersistDefaultValuesIfPersistedSettingsAreInvalid);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfPersistDefaultValuesIfPersistedSettingsAreInvalid.ShouldNotBeNull();
            parametersOfPersistDefaultValuesIfPersistedSettingsAreInvalid.Length.ShouldBe(1);
            methodPersistDefaultValuesIfPersistedSettingsAreInvalidPrametersTypes.Length.ShouldBe(1);
            methodPersistDefaultValuesIfPersistedSettingsAreInvalidPrametersTypes.Length.ShouldBe(parametersOfPersistDefaultValuesIfPersistedSettingsAreInvalid.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (PersistDefaultValuesIfPersistedSettingsAreInvalid) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistDefaultValuesIfPersistedSettingsAreInvalid_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var methodPersistDefaultValuesIfPersistedSettingsAreInvalidPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            object[] parametersOfPersistDefaultValuesIfPersistedSettingsAreInvalid = { userSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodPersistDefaultValuesIfPersistedSettingsAreInvalid, parametersOfPersistDefaultValuesIfPersistedSettingsAreInvalid, methodPersistDefaultValuesIfPersistedSettingsAreInvalidPrametersTypes);

            // Assert
            parametersOfPersistDefaultValuesIfPersistedSettingsAreInvalid.ShouldNotBeNull();
            parametersOfPersistDefaultValuesIfPersistedSettingsAreInvalid.Length.ShouldBe(1);
            methodPersistDefaultValuesIfPersistedSettingsAreInvalidPrametersTypes.Length.ShouldBe(1);
            methodPersistDefaultValuesIfPersistedSettingsAreInvalidPrametersTypes.Length.ShouldBe(parametersOfPersistDefaultValuesIfPersistedSettingsAreInvalid.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistDefaultValuesIfPersistedSettingsAreInvalid) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistDefaultValuesIfPersistedSettingsAreInvalid_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPersistDefaultValuesIfPersistedSettingsAreInvalid, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PersistDefaultValuesIfPersistedSettingsAreInvalid) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistDefaultValuesIfPersistedSettingsAreInvalid_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPersistDefaultValuesIfPersistedSettingsAreInvalidPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodPersistDefaultValuesIfPersistedSettingsAreInvalid, Fixture, methodPersistDefaultValuesIfPersistedSettingsAreInvalidPrametersTypes);

            // Assert
            methodPersistDefaultValuesIfPersistedSettingsAreInvalidPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistDefaultValuesIfPersistedSettingsAreInvalid) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistDefaultValuesIfPersistedSettingsAreInvalid_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPersistDefaultValuesIfPersistedSettingsAreInvalid, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistedListAndFieldMatchWhatIsInWebPartProperties) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_PersistedListAndFieldMatchWhatIsInWebPartProperties_Static_Method_Call_Internally(Type[] types)
        {
            var methodPersistedListAndFieldMatchWhatIsInWebPartPropertiesPrametersTypes = types;
            ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodPersistedListAndFieldMatchWhatIsInWebPartProperties, Fixture, methodPersistedListAndFieldMatchWhatIsInWebPartPropertiesPrametersTypes);
        }

        #endregion

        #region Method Call : (PersistedListAndFieldMatchWhatIsInWebPartProperties) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistedListAndFieldMatchWhatIsInWebPartProperties_Static_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var persistedValues = CreateType<ReportFilterUserSettings>();
            var field = CreateType<SPField>();
            var list = CreateType<SPList>();
            var methodPersistedListAndFieldMatchWhatIsInWebPartPropertiesPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPField), typeof(SPList) };
            object[] parametersOfPersistedListAndFieldMatchWhatIsInWebPartProperties = { persistedValues, field, list };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfStaticMethod<bool>(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodPersistedListAndFieldMatchWhatIsInWebPartProperties, parametersOfPersistedListAndFieldMatchWhatIsInWebPartProperties, methodPersistedListAndFieldMatchWhatIsInWebPartPropertiesPrametersTypes);

            // Assert
            parametersOfPersistedListAndFieldMatchWhatIsInWebPartProperties.ShouldNotBeNull();
            parametersOfPersistedListAndFieldMatchWhatIsInWebPartProperties.Length.ShouldBe(3);
            methodPersistedListAndFieldMatchWhatIsInWebPartPropertiesPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (PersistedListAndFieldMatchWhatIsInWebPartProperties) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistedListAndFieldMatchWhatIsInWebPartProperties_Static_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodPersistedListAndFieldMatchWhatIsInWebPartPropertiesPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPField), typeof(SPList) };
            const int parametersCount = 3;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeStaticMethodWithDynamicParameters(_reportingFilterInstanceFixture, _reportingFilterInstanceType, MethodPersistedListAndFieldMatchWhatIsInWebPartProperties, Fixture, methodPersistedListAndFieldMatchWhatIsInWebPartPropertiesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodPersistedListAndFieldMatchWhatIsInWebPartPropertiesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (PersistedListAndFieldMatchWhatIsInWebPartProperties) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistedListAndFieldMatchWhatIsInWebPartProperties_Static_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodPersistedListAndFieldMatchWhatIsInWebPartProperties, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (PersistedListAndFieldMatchWhatIsInWebPartProperties) (Return Type : bool) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_PersistedListAndFieldMatchWhatIsInWebPartProperties_Static_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodPersistedListAndFieldMatchWhatIsInWebPartProperties, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshPersistedTitlesWithLatestQueryResults) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_RefreshPersistedTitlesWithLatestQueryResults_Method_Call_Internally(Type[] types)
        {
            var methodRefreshPersistedTitlesWithLatestQueryResultsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodRefreshPersistedTitlesWithLatestQueryResults, Fixture, methodRefreshPersistedTitlesWithLatestQueryResultsPrametersTypes);
        }

        #endregion

        #region Method Call : (RefreshPersistedTitlesWithLatestQueryResults) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RefreshPersistedTitlesWithLatestQueryResults_Method_Call_Void_With_1_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var persistedSettings = CreateType<ReportFilterUserSettings>();
            var methodRefreshPersistedTitlesWithLatestQueryResultsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            object[] parametersOfRefreshPersistedTitlesWithLatestQueryResults = { persistedSettings };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodRefreshPersistedTitlesWithLatestQueryResults, methodRefreshPersistedTitlesWithLatestQueryResultsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfRefreshPersistedTitlesWithLatestQueryResults);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfRefreshPersistedTitlesWithLatestQueryResults.ShouldNotBeNull();
            parametersOfRefreshPersistedTitlesWithLatestQueryResults.Length.ShouldBe(1);
            methodRefreshPersistedTitlesWithLatestQueryResultsPrametersTypes.Length.ShouldBe(1);
            methodRefreshPersistedTitlesWithLatestQueryResultsPrametersTypes.Length.ShouldBe(parametersOfRefreshPersistedTitlesWithLatestQueryResults.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (RefreshPersistedTitlesWithLatestQueryResults) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RefreshPersistedTitlesWithLatestQueryResults_Method_Call_Void_With_1_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var persistedSettings = CreateType<ReportFilterUserSettings>();
            var methodRefreshPersistedTitlesWithLatestQueryResultsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };
            object[] parametersOfRefreshPersistedTitlesWithLatestQueryResults = { persistedSettings };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodRefreshPersistedTitlesWithLatestQueryResults, parametersOfRefreshPersistedTitlesWithLatestQueryResults, methodRefreshPersistedTitlesWithLatestQueryResultsPrametersTypes);

            // Assert
            parametersOfRefreshPersistedTitlesWithLatestQueryResults.ShouldNotBeNull();
            parametersOfRefreshPersistedTitlesWithLatestQueryResults.Length.ShouldBe(1);
            methodRefreshPersistedTitlesWithLatestQueryResultsPrametersTypes.Length.ShouldBe(1);
            methodRefreshPersistedTitlesWithLatestQueryResultsPrametersTypes.Length.ShouldBe(parametersOfRefreshPersistedTitlesWithLatestQueryResults.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RefreshPersistedTitlesWithLatestQueryResults) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RefreshPersistedTitlesWithLatestQueryResults_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodRefreshPersistedTitlesWithLatestQueryResults, 0);
            const int parametersCount = 1;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (RefreshPersistedTitlesWithLatestQueryResults) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RefreshPersistedTitlesWithLatestQueryResults_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodRefreshPersistedTitlesWithLatestQueryResultsPrametersTypes = new Type[] { typeof(ReportFilterUserSettings) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodRefreshPersistedTitlesWithLatestQueryResults, Fixture, methodRefreshPersistedTitlesWithLatestQueryResultsPrametersTypes);

            // Assert
            methodRefreshPersistedTitlesWithLatestQueryResultsPrametersTypes.Length.ShouldBe(1);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (RefreshPersistedTitlesWithLatestQueryResults) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_RefreshPersistedTitlesWithLatestQueryResults_Method_Call_With_1_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodRefreshPersistedTitlesWithLatestQueryResults, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateUsersPersistedTitlesBasedOnCurrentData) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_UpdateUsersPersistedTitlesBasedOnCurrentData_Method_Call_Internally(Type[] types)
        {
            var methodUpdateUsersPersistedTitlesBasedOnCurrentDataPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodUpdateUsersPersistedTitlesBasedOnCurrentData, Fixture, methodUpdateUsersPersistedTitlesBasedOnCurrentDataPrametersTypes);
        }

        #endregion

        #region Method Call : (UpdateUsersPersistedTitlesBasedOnCurrentData) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_UpdateUsersPersistedTitlesBasedOnCurrentData_Method_Call_Void_With_3_Parameters_Throw_Exception_Thrown_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var web = CreateType<SPWeb>();
            var titles = CreateType<List<string>>();
            var methodUpdateUsersPersistedTitlesBasedOnCurrentDataPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPWeb), typeof(List<string>) };
            object[] parametersOfUpdateUsersPersistedTitlesBasedOnCurrentData = { userSettings, web, titles };
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodUpdateUsersPersistedTitlesBasedOnCurrentData, methodUpdateUsersPersistedTitlesBasedOnCurrentDataPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfUpdateUsersPersistedTitlesBasedOnCurrentData);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfUpdateUsersPersistedTitlesBasedOnCurrentData.ShouldNotBeNull();
            parametersOfUpdateUsersPersistedTitlesBasedOnCurrentData.Length.ShouldBe(3);
            methodUpdateUsersPersistedTitlesBasedOnCurrentDataPrametersTypes.Length.ShouldBe(3);
            methodUpdateUsersPersistedTitlesBasedOnCurrentDataPrametersTypes.Length.ShouldBe(parametersOfUpdateUsersPersistedTitlesBasedOnCurrentData.Length);
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (UpdateUsersPersistedTitlesBasedOnCurrentData) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_UpdateUsersPersistedTitlesBasedOnCurrentData_Method_Call_Void_With_3_Parameters_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var userSettings = CreateType<ReportFilterUserSettings>();
            var web = CreateType<SPWeb>();
            var titles = CreateType<List<string>>();
            var methodUpdateUsersPersistedTitlesBasedOnCurrentDataPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPWeb), typeof(List<string>) };
            object[] parametersOfUpdateUsersPersistedTitlesBasedOnCurrentData = { userSettings, web, titles };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodUpdateUsersPersistedTitlesBasedOnCurrentData, parametersOfUpdateUsersPersistedTitlesBasedOnCurrentData, methodUpdateUsersPersistedTitlesBasedOnCurrentDataPrametersTypes);

            // Assert
            parametersOfUpdateUsersPersistedTitlesBasedOnCurrentData.ShouldNotBeNull();
            parametersOfUpdateUsersPersistedTitlesBasedOnCurrentData.Length.ShouldBe(3);
            methodUpdateUsersPersistedTitlesBasedOnCurrentDataPrametersTypes.Length.ShouldBe(3);
            methodUpdateUsersPersistedTitlesBasedOnCurrentDataPrametersTypes.Length.ShouldBe(parametersOfUpdateUsersPersistedTitlesBasedOnCurrentData.Length);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateUsersPersistedTitlesBasedOnCurrentData) (Return Type : void) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_UpdateUsersPersistedTitlesBasedOnCurrentData_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodUpdateUsersPersistedTitlesBasedOnCurrentData, 0);
            const int parametersCount = 3;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (UpdateUsersPersistedTitlesBasedOnCurrentData) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_UpdateUsersPersistedTitlesBasedOnCurrentData_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodUpdateUsersPersistedTitlesBasedOnCurrentDataPrametersTypes = new Type[] { typeof(ReportFilterUserSettings), typeof(SPWeb), typeof(List<string>) };

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodUpdateUsersPersistedTitlesBasedOnCurrentData, Fixture, methodUpdateUsersPersistedTitlesBasedOnCurrentDataPrametersTypes);

            // Assert
            methodUpdateUsersPersistedTitlesBasedOnCurrentDataPrametersTypes.Length.ShouldBe(3);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (UpdateUsersPersistedTitlesBasedOnCurrentData) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_UpdateUsersPersistedTitlesBasedOnCurrentData_Method_Call_With_3_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodUpdateUsersPersistedTitlesBasedOnCurrentData, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReloadPage) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_ReloadPage_Method_Call_Internally(Type[] types)
        {
            var methodReloadPagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodReloadPage, Fixture, methodReloadPagePrametersTypes);
        }

        #endregion

        #region Method Call : (ReloadPage) (Return Type : void) Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_ReloadPage_Method_Call_Void_With_No_Parameters_Call_Throw_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodReloadPagePrametersTypes = null;
            object[] parametersOfReloadPage = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodReloadPage, methodReloadPagePrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfReloadPage);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfReloadPage.ShouldBeNull();
            methodReloadPagePrametersTypes.ShouldBeNull();
            Should.Throw<Exception>(currentAction);
        }

        #endregion

        #region Method Call : (ReloadPage) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_ReloadPage_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodReloadPagePrametersTypes = null;
            object[] parametersOfReloadPage = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodReloadPage, parametersOfReloadPage, methodReloadPagePrametersTypes);

            // Assert
            parametersOfReloadPage.ShouldBeNull();
            methodReloadPagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReloadPage) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_ReloadPage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodReloadPagePrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodReloadPage, Fixture, methodReloadPagePrametersTypes);

            // Assert
            methodReloadPagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (ReloadPage) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_ReloadPage_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodReloadPage, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HttpGetOriginatedFromThisPage) (Return Type : bool) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_HttpGetOriginatedFromThisPage_Method_Call_Internally(Type[] types)
        {
            var methodHttpGetOriginatedFromThisPagePrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodHttpGetOriginatedFromThisPage, Fixture, methodHttpGetOriginatedFromThisPagePrametersTypes);
        }

        #endregion

        #region Method Call : (HttpGetOriginatedFromThisPage) (Return Type : bool) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_HttpGetOriginatedFromThisPage_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            Type [] methodHttpGetOriginatedFromThisPagePrametersTypes = null;
            object[] parametersOfHttpGetOriginatedFromThisPage = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodHttpGetOriginatedFromThisPage, methodHttpGetOriginatedFromThisPagePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingFilter, bool>(_reportingFilterInstanceFixture, out exception1, parametersOfHttpGetOriginatedFromThisPage);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, bool>(_reportingFilterInstance, MethodHttpGetOriginatedFromThisPage, parametersOfHttpGetOriginatedFromThisPage, methodHttpGetOriginatedFromThisPagePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfHttpGetOriginatedFromThisPage.ShouldBeNull();
            methodHttpGetOriginatedFromThisPagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HttpGetOriginatedFromThisPage) (Return Type : bool) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_HttpGetOriginatedFromThisPage_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodHttpGetOriginatedFromThisPagePrametersTypes = null;
            object[] parametersOfHttpGetOriginatedFromThisPage = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodHttpGetOriginatedFromThisPage, methodHttpGetOriginatedFromThisPagePrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingFilter, bool>(_reportingFilterInstanceFixture, out exception1, parametersOfHttpGetOriginatedFromThisPage);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, bool>(_reportingFilterInstance, MethodHttpGetOriginatedFromThisPage, parametersOfHttpGetOriginatedFromThisPage, methodHttpGetOriginatedFromThisPagePrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfHttpGetOriginatedFromThisPage.ShouldBeNull();
            methodHttpGetOriginatedFromThisPagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HttpGetOriginatedFromThisPage) (Return Type : bool) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_HttpGetOriginatedFromThisPage_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodHttpGetOriginatedFromThisPagePrametersTypes = null;
            object[] parametersOfHttpGetOriginatedFromThisPage = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, bool>(_reportingFilterInstance, MethodHttpGetOriginatedFromThisPage, parametersOfHttpGetOriginatedFromThisPage, methodHttpGetOriginatedFromThisPagePrametersTypes);

            // Assert
            parametersOfHttpGetOriginatedFromThisPage.ShouldBeNull();
            methodHttpGetOriginatedFromThisPagePrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (HttpGetOriginatedFromThisPage) (Return Type : bool) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_HttpGetOriginatedFromThisPage_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodHttpGetOriginatedFromThisPagePrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodHttpGetOriginatedFromThisPage, Fixture, methodHttpGetOriginatedFromThisPagePrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodHttpGetOriginatedFromThisPagePrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (HttpGetOriginatedFromThisPage) (Return Type : bool) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_HttpGetOriginatedFromThisPage_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodHttpGetOriginatedFromThisPage, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUserSettingsWithDefaultValues) (Return Type : ReportFilterUserSettings) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetUserSettingsWithDefaultValues_Method_Call_Internally(Type[] types)
        {
            var methodGetUserSettingsWithDefaultValuesPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetUserSettingsWithDefaultValues, Fixture, methodGetUserSettingsWithDefaultValuesPrametersTypes);
        }

        #endregion

        #region Method Call : (GetUserSettingsWithDefaultValues) (Return Type : ReportFilterUserSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetUserSettingsWithDefaultValues_Method_Call_With_No_Parameters_Call_Results_ShouldBe_Null_If_Not_Premitive_Type_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var field = CreateType<SPField>();
            var methodGetUserSettingsWithDefaultValuesPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(SPList), typeof(SPField) };
            object[] parametersOfGetUserSettingsWithDefaultValues = { site, web, list, field };
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetUserSettingsWithDefaultValues, methodGetUserSettingsWithDefaultValuesPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingFilter, ReportFilterUserSettings>(_reportingFilterInstanceFixture, out exception1, parametersOfGetUserSettingsWithDefaultValues);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, ReportFilterUserSettings>(_reportingFilterInstance, MethodGetUserSettingsWithDefaultValues, parametersOfGetUserSettingsWithDefaultValues, methodGetUserSettingsWithDefaultValuesPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldBeNull();
            result2.ShouldBeNull();
            parametersOfGetUserSettingsWithDefaultValues.ShouldNotBeNull();
            parametersOfGetUserSettingsWithDefaultValues.Length.ShouldBe(4);
            methodGetUserSettingsWithDefaultValuesPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetUserSettingsWithDefaultValues) (Return Type : ReportFilterUserSettings) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetUserSettingsWithDefaultValues_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            var site = CreateType<SPSite>();
            var web = CreateType<SPWeb>();
            var list = CreateType<SPList>();
            var field = CreateType<SPField>();
            var methodGetUserSettingsWithDefaultValuesPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(SPList), typeof(SPField) };
            object[] parametersOfGetUserSettingsWithDefaultValues = { site, web, list, field };

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, ReportFilterUserSettings>(_reportingFilterInstance, MethodGetUserSettingsWithDefaultValues, parametersOfGetUserSettingsWithDefaultValues, methodGetUserSettingsWithDefaultValuesPrametersTypes);

            // Assert
            parametersOfGetUserSettingsWithDefaultValues.ShouldNotBeNull();
            parametersOfGetUserSettingsWithDefaultValues.Length.ShouldBe(4);
            methodGetUserSettingsWithDefaultValuesPrametersTypes.Length.ShouldBe(4);
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetUserSettingsWithDefaultValues) (Return Type : ReportFilterUserSettings) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetUserSettingsWithDefaultValues_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            var methodGetUserSettingsWithDefaultValuesPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(SPList), typeof(SPField) };

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetUserSettingsWithDefaultValues, Fixture, methodGetUserSettingsWithDefaultValuesPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetUserSettingsWithDefaultValuesPrametersTypes.Length.ShouldBe(4);
        }

        #endregion

        #region Method Call : (GetUserSettingsWithDefaultValues) (Return Type : ReportFilterUserSettings) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetUserSettingsWithDefaultValues_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            var methodGetUserSettingsWithDefaultValuesPrametersTypes = new Type[] { typeof(SPSite), typeof(SPWeb), typeof(SPList), typeof(SPField) };
            const int parametersCount = 4;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetUserSettingsWithDefaultValues, Fixture, methodGetUserSettingsWithDefaultValuesPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetUserSettingsWithDefaultValuesPrametersTypes.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GetUserSettingsWithDefaultValues) (Return Type : ReportFilterUserSettings) without parameters value verify result should be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetUserSettingsWithDefaultValues_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetUserSettingsWithDefaultValues, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetUserSettingsWithDefaultValues) (Return Type : ReportFilterUserSettings) Parameters Count verify

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetUserSettingsWithDefaultValues_Method_Call_Parameters_Count_Verification_Test()
        {
            // Arrange
            var methodInfo = GetMethodInfo(MethodGetUserSettingsWithDefaultValues, 0);
            const int parametersCount = 4;

            // Act
            var parameters = methodInfo.GetParameters();

            // Assert
            parameters.Length.ShouldBe(parametersCount);
        }

        #endregion

        #region Method Call : (GenerateMainJavascript) (Return Type : void) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GenerateMainJavascript_Method_Call_Internally(Type[] types)
        {
            var methodGenerateMainJavascriptPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGenerateMainJavascript, Fixture, methodGenerateMainJavascriptPrametersTypes);
        }

        #endregion

        #region Method Call : (GenerateMainJavascript) (Return Type : void) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GenerateMainJavascript_Method_Call_Void_With_No_Parameters_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGenerateMainJavascriptPrametersTypes = null;
            object[] parametersOfGenerateMainJavascript = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGenerateMainJavascript, methodGenerateMainJavascriptPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfGenerateMainJavascript);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGenerateMainJavascript.ShouldBeNull();
            methodGenerateMainJavascriptPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateMainJavascript) (Return Type : void) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GenerateMainJavascript_Method_Call_Void_With_No_Parameters_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGenerateMainJavascriptPrametersTypes = null;
            object[] parametersOfGenerateMainJavascript = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeVoidMethod(_reportingFilterInstance, MethodGenerateMainJavascript, parametersOfGenerateMainJavascript, methodGenerateMainJavascriptPrametersTypes);

            // Assert
            parametersOfGenerateMainJavascript.ShouldBeNull();
            methodGenerateMainJavascriptPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateMainJavascript) (Return Type : void) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GenerateMainJavascript_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGenerateMainJavascriptPrametersTypes = null;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGenerateMainJavascript, Fixture, methodGenerateMainJavascriptPrametersTypes);

            // Assert
            methodGenerateMainJavascriptPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GenerateMainJavascript) (Return Type : void) Invoke without parameter types and should not throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GenerateMainJavascript_Method_Call_With_No_Parameters_Dynamic_Invoking_Without_Parameters_Should_Not_Throw_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGenerateMainJavascript, 0);

            // Act
            Action currentAction = () => methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetScriptForFilterOperator) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetScriptForFilterOperator_Method_Call_Internally(Type[] types)
        {
            var methodGetScriptForFilterOperatorPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptForFilterOperator, Fixture, methodGetScriptForFilterOperatorPrametersTypes);
        }

        #endregion

        #region Method Call : (GetScriptForFilterOperator) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptForFilterOperator_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetScriptForFilterOperatorPrametersTypes = null;
            object[] parametersOfGetScriptForFilterOperator = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetScriptForFilterOperator, methodGetScriptForFilterOperatorPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfGetScriptForFilterOperator);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetScriptForFilterOperator.ShouldBeNull();
            methodGetScriptForFilterOperatorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetScriptForFilterOperator) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptForFilterOperator_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetScriptForFilterOperatorPrametersTypes = null;
            object[] parametersOfGetScriptForFilterOperator = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, string>(_reportingFilterInstance, MethodGetScriptForFilterOperator, parametersOfGetScriptForFilterOperator, methodGetScriptForFilterOperatorPrametersTypes);

            // Assert
            parametersOfGetScriptForFilterOperator.ShouldBeNull();
            methodGetScriptForFilterOperatorPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetScriptForFilterOperator) (Return Type : string) Results Null (if not primitive type) Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptForFilterOperator_Method_Call_Dynamic_Invoking_Results_Null_If_Not_Primitive_Type_Test()
        {
            // Arrange
            Type [] methodGetScriptForFilterOperatorPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptForFilterOperator, Fixture, methodGetScriptForFilterOperatorPrametersTypes);

            // Assert
            result.ShouldBeNull();
            methodGetScriptForFilterOperatorPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetScriptForFilterOperator) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptForFilterOperator_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetScriptForFilterOperatorPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptForFilterOperator, Fixture, methodGetScriptForFilterOperatorPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetScriptForFilterOperatorPrametersTypes.ShouldBeNull();
        }

        #endregion
        
        #region Method Call : (GetScriptForSelectedFieldsAsCsv) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetScriptForSelectedFieldsAsCsv_Method_Call_Internally(Type[] types)
        {
            var methodGetScriptForSelectedFieldsAsCsvPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptForSelectedFieldsAsCsv, Fixture, methodGetScriptForSelectedFieldsAsCsvPrametersTypes);
        }

        #endregion

        #region Method Call : (GetScriptForSelectedFieldsAsCsv) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptForSelectedFieldsAsCsv_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetScriptForSelectedFieldsAsCsvPrametersTypes = null;
            object[] parametersOfGetScriptForSelectedFieldsAsCsv = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, string>(_reportingFilterInstance, MethodGetScriptForSelectedFieldsAsCsv, parametersOfGetScriptForSelectedFieldsAsCsv, methodGetScriptForSelectedFieldsAsCsvPrametersTypes);

            // Assert
            parametersOfGetScriptForSelectedFieldsAsCsv.ShouldBeNull();
            methodGetScriptForSelectedFieldsAsCsvPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetScriptForSelectedFieldsAsCsv) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptForSelectedFieldsAsCsv_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetScriptForSelectedFieldsAsCsvPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptForSelectedFieldsAsCsv, Fixture, methodGetScriptForSelectedFieldsAsCsvPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetScriptForSelectedFieldsAsCsvPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetScriptForSelectedFieldsAsCsv) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptForSelectedFieldsAsCsv_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetScriptForSelectedFieldsAsCsvPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptForSelectedFieldsAsCsv, Fixture, methodGetScriptForSelectedFieldsAsCsvPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetScriptForSelectedFieldsAsCsvPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetScriptToSelectAllTitlesIfNoneSelected) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetScriptToSelectAllTitlesIfNoneSelected_Method_Call_Internally(Type[] types)
        {
            var methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptToSelectAllTitlesIfNoneSelected, Fixture, methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes);
        }

        #endregion

        #region Method Call : (GetScriptToSelectAllTitlesIfNoneSelected) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptToSelectAllTitlesIfNoneSelected_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes = null;
            object[] parametersOfGetScriptToSelectAllTitlesIfNoneSelected = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetScriptToSelectAllTitlesIfNoneSelected, methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfGetScriptToSelectAllTitlesIfNoneSelected);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetScriptToSelectAllTitlesIfNoneSelected.ShouldBeNull();
            methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetScriptToSelectAllTitlesIfNoneSelected) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptToSelectAllTitlesIfNoneSelected_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes = null;
            object[] parametersOfGetScriptToSelectAllTitlesIfNoneSelected = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, string>(_reportingFilterInstance, MethodGetScriptToSelectAllTitlesIfNoneSelected, parametersOfGetScriptToSelectAllTitlesIfNoneSelected, methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes);

            // Assert
            parametersOfGetScriptToSelectAllTitlesIfNoneSelected.ShouldBeNull();
            methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetScriptToSelectAllTitlesIfNoneSelected) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptToSelectAllTitlesIfNoneSelected_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptToSelectAllTitlesIfNoneSelected, Fixture, methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetScriptToSelectAllTitlesIfNoneSelected) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptToSelectAllTitlesIfNoneSelected_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptToSelectAllTitlesIfNoneSelected, Fixture, methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetScriptToSelectAllTitlesIfNoneSelectedPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetScriptToSelectAllTitlesIfNoneSelected) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptToSelectAllTitlesIfNoneSelected_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetScriptToSelectAllTitlesIfNoneSelected, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetScriptToPopulateTitlesBasedOnSelectedFields) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetScriptToPopulateTitlesBasedOnSelectedFields_Method_Call_Internally(Type[] types)
        {
            var methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptToPopulateTitlesBasedOnSelectedFields, Fixture, methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes);
        }

        #endregion

        #region Method Call : (GetScriptToPopulateTitlesBasedOnSelectedFields) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptToPopulateTitlesBasedOnSelectedFields_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes = null;
            object[] parametersOfGetScriptToPopulateTitlesBasedOnSelectedFields = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetScriptToPopulateTitlesBasedOnSelectedFields, methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfGetScriptToPopulateTitlesBasedOnSelectedFields);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetScriptToPopulateTitlesBasedOnSelectedFields.ShouldBeNull();
            methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetScriptToPopulateTitlesBasedOnSelectedFields) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptToPopulateTitlesBasedOnSelectedFields_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes = null;
            object[] parametersOfGetScriptToPopulateTitlesBasedOnSelectedFields = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, string>(_reportingFilterInstance, MethodGetScriptToPopulateTitlesBasedOnSelectedFields, parametersOfGetScriptToPopulateTitlesBasedOnSelectedFields, methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes);

            // Assert
            parametersOfGetScriptToPopulateTitlesBasedOnSelectedFields.ShouldBeNull();
            methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetScriptToPopulateTitlesBasedOnSelectedFields) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptToPopulateTitlesBasedOnSelectedFields_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptToPopulateTitlesBasedOnSelectedFields, Fixture, methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetScriptToPopulateTitlesBasedOnSelectedFields) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptToPopulateTitlesBasedOnSelectedFields_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptToPopulateTitlesBasedOnSelectedFields, Fixture, methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetScriptToPopulateTitlesBasedOnSelectedFieldsPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetScriptToPopulateTitlesBasedOnSelectedFields) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptToPopulateTitlesBasedOnSelectedFields_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetScriptToPopulateTitlesBasedOnSelectedFields, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #region Method Call : (GetScriptForPeoplePicker) (Return Type : string) private call definition

        [ExcludeFromCodeCoverage]
        private void AUT_ReportingFilter_GetScriptForPeoplePicker_Method_Call_Internally(Type[] types)
        {
            var methodGetScriptForPeoplePickerPrametersTypes = types;
            ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptForPeoplePicker, Fixture, methodGetScriptForPeoplePickerPrametersTypes);
        }

        #endregion

        #region Method Call : (GetScriptForPeoplePicker) (Return Type : string) Results Not Null and no exception thrown Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptForPeoplePicker_Method_Call_With_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Type [] methodGetScriptForPeoplePickerPrametersTypes = null;
            object[] parametersOfGetScriptForPeoplePicker = null; // no parameter present
            Exception exception, exception1;
            var methodInfo = GetMethodInfo(MethodGetScriptForPeoplePicker, methodGetScriptForPeoplePickerPrametersTypes, out exception);

            // Act
            var result1 = methodInfo.GetResultMethodInfo<ReportingFilter, string>(_reportingFilterInstanceFixture, out exception1, parametersOfGetScriptForPeoplePicker);
            var result2 = ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, string>(_reportingFilterInstance, MethodGetScriptForPeoplePicker, parametersOfGetScriptForPeoplePicker, methodGetScriptForPeoplePickerPrametersTypes);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            result1.ShouldNotBeNull();
            result2.ShouldNotBeNull();
            result1.ShouldBe(result2);
            parametersOfGetScriptForPeoplePicker.ShouldBeNull();
            methodGetScriptForPeoplePickerPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetScriptForPeoplePicker) (Return Type : string) No Exception Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptForPeoplePicker_Method_Call_With_No_Exception_Thrown_Test()
        {
            // Arrange
            Type [] methodGetScriptForPeoplePickerPrametersTypes = null;
            object[] parametersOfGetScriptForPeoplePicker = null; // no parameter present
            Exception exception = null;
            var methodInfo = GetMethodInfo(MethodGetScriptForPeoplePicker, methodGetScriptForPeoplePickerPrametersTypes, out exception);

            // Act
            Action currentAction = () => methodInfo.Invoke(_reportingFilterInstanceFixture, parametersOfGetScriptForPeoplePicker);

            // Assert
            methodInfo.ShouldNotBeNull();
            exception.ShouldBeNull();
            parametersOfGetScriptForPeoplePicker.ShouldBeNull();
            methodGetScriptForPeoplePickerPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetScriptForPeoplePicker) (Return Type : string) No Exception with encapsulation Thrown

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptForPeoplePicker_Method_Call_With_Call_No_Exception_Thrown_With_Encapsulation_Test()
        {
            // Arrange
            Type [] methodGetScriptForPeoplePickerPrametersTypes = null;
            object[] parametersOfGetScriptForPeoplePicker = null; // no parameter present

            // Act
            Action currentAction = () => ReflectionAnalyzer.GetResultOfMethod<ReportingFilter, string>(_reportingFilterInstance, MethodGetScriptForPeoplePicker, parametersOfGetScriptForPeoplePicker, methodGetScriptForPeoplePickerPrametersTypes);

            // Assert
            parametersOfGetScriptForPeoplePicker.ShouldBeNull();
            methodGetScriptForPeoplePickerPrametersTypes.ShouldBeNull();
            Should.NotThrow(currentAction);
        }

        #endregion

        #region Method Call : (GetScriptForPeoplePicker) (Return Type : string) Results Not Null Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptForPeoplePicker_Method_Call_Dynamic_Invoking_Results_Not_Null_Test()
        {
            // Arrange
            Type [] methodGetScriptForPeoplePickerPrametersTypes = null;

            // Act
            var result = ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptForPeoplePicker, Fixture, methodGetScriptForPeoplePickerPrametersTypes);

            // Assert
            result.ShouldNotBeNull();
            methodGetScriptForPeoplePickerPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetScriptForPeoplePicker) (Return Type : string) Invoke Should Not Throw

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptForPeoplePicker_Method_Call_Dynamic_Invoking_Should_Not_Throw_Test()
        {
            // Arrange
            Type [] methodGetScriptForPeoplePickerPrametersTypes = null;
            const int parametersCount = 0;

            // Act
            Action currentAction = () => ReflectionAnalyzer.InvokeNonStaticMethodWithDynamicParameters(_reportingFilterInstance, MethodGetScriptForPeoplePicker, Fixture, methodGetScriptForPeoplePickerPrametersTypes);

            // Assert
            Should.NotThrow(currentAction);
            methodGetScriptForPeoplePickerPrametersTypes.ShouldBeNull();
        }

        #endregion

        #region Method Call : (GetScriptForPeoplePicker) (Return Type : string) without parameters value verify result should not be null.

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT MethodCallTest")]
        public void AUT_ReportingFilter_GetScriptForPeoplePicker_Method_Call_Dynamic_Invoking_Without_Parameters_Results_Should_Not_Be_Null_Test()
        {
            // Arrange
            Exception exception;
            var methodInfo = GetMethodInfo(MethodGetScriptForPeoplePicker, 0);

            // Act
            var result = methodInfo.InvokeStaticMethodWithDynamicParamters(_reportingFilterInstanceFixture, Fixture, out exception);

            // Assert
            methodInfo.ShouldNotBeNull();
            result.ShouldNotBeNull();
        }

        #endregion

        #endregion

        #endregion
    }
}