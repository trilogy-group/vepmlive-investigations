using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomObject" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomObjectTest : AbstractBaseSetupTypedTest<CustomObject>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomObject) Initializer

        private const string PropertyactionOverrides = "actionOverrides";
        private const string PropertyarticleTypeChannelDisplay = "articleTypeChannelDisplay";
        private const string PropertybusinessProcesses = "businessProcesses";
        private const string PropertycustomHelp = "customHelp";
        private const string PropertycustomHelpPage = "customHelpPage";
        private const string PropertycustomSettingsType = "customSettingsType";
        private const string PropertycustomSettingsTypeSpecified = "customSettingsTypeSpecified";
        private const string PropertycustomSettingsVisibility = "customSettingsVisibility";
        private const string PropertycustomSettingsVisibilitySpecified = "customSettingsVisibilitySpecified";
        private const string PropertydeploymentStatus = "deploymentStatus";
        private const string PropertydeploymentStatusSpecified = "deploymentStatusSpecified";
        private const string Propertydeprecated = "deprecated";
        private const string PropertydeprecatedSpecified = "deprecatedSpecified";
        private const string Propertydescription = "description";
        private const string PropertyenableActivities = "enableActivities";
        private const string PropertyenableActivitiesSpecified = "enableActivitiesSpecified";
        private const string PropertyenableDivisions = "enableDivisions";
        private const string PropertyenableDivisionsSpecified = "enableDivisionsSpecified";
        private const string PropertyenableEnhancedLookup = "enableEnhancedLookup";
        private const string PropertyenableEnhancedLookupSpecified = "enableEnhancedLookupSpecified";
        private const string PropertyenableFeeds = "enableFeeds";
        private const string PropertyenableFeedsSpecified = "enableFeedsSpecified";
        private const string PropertyenableHistory = "enableHistory";
        private const string PropertyenableHistorySpecified = "enableHistorySpecified";
        private const string PropertyenableReports = "enableReports";
        private const string PropertyenableReportsSpecified = "enableReportsSpecified";
        private const string PropertyfieldSets = "fieldSets";
        private const string Propertyfields = "fields";
        private const string Propertygender = "gender";
        private const string PropertygenderSpecified = "genderSpecified";
        private const string Propertyhousehold = "household";
        private const string PropertyhouseholdSpecified = "householdSpecified";
        private const string Propertylabel = "label";
        private const string PropertylistViews = "listViews";
        private const string PropertynameField = "nameField";
        private const string PropertynamedFilters = "namedFilters";
        private const string PropertypluralLabel = "pluralLabel";
        private const string PropertyrecordTypeTrackFeedHistory = "recordTypeTrackFeedHistory";
        private const string PropertyrecordTypeTrackFeedHistorySpecified = "recordTypeTrackFeedHistorySpecified";
        private const string PropertyrecordTypeTrackHistory = "recordTypeTrackHistory";
        private const string PropertyrecordTypeTrackHistorySpecified = "recordTypeTrackHistorySpecified";
        private const string PropertyrecordTypes = "recordTypes";
        private const string PropertysearchLayouts = "searchLayouts";
        private const string PropertysharingModel = "sharingModel";
        private const string PropertysharingModelSpecified = "sharingModelSpecified";
        private const string PropertysharingReasons = "sharingReasons";
        private const string PropertysharingRecalculations = "sharingRecalculations";
        private const string PropertystartsWith = "startsWith";
        private const string PropertystartsWithSpecified = "startsWithSpecified";
        private const string PropertyvalidationRules = "validationRules";
        private const string PropertywebLinks = "webLinks";
        private const string FieldactionOverridesField = "actionOverridesField";
        private const string FieldarticleTypeChannelDisplayField = "articleTypeChannelDisplayField";
        private const string FieldbusinessProcessesField = "businessProcessesField";
        private const string FieldcustomHelpField = "customHelpField";
        private const string FieldcustomHelpPageField = "customHelpPageField";
        private const string FieldcustomSettingsTypeField = "customSettingsTypeField";
        private const string FieldcustomSettingsTypeFieldSpecified = "customSettingsTypeFieldSpecified";
        private const string FieldcustomSettingsVisibilityField = "customSettingsVisibilityField";
        private const string FieldcustomSettingsVisibilityFieldSpecified = "customSettingsVisibilityFieldSpecified";
        private const string FielddeploymentStatusField = "deploymentStatusField";
        private const string FielddeploymentStatusFieldSpecified = "deploymentStatusFieldSpecified";
        private const string FielddeprecatedField = "deprecatedField";
        private const string FielddeprecatedFieldSpecified = "deprecatedFieldSpecified";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldenableActivitiesField = "enableActivitiesField";
        private const string FieldenableActivitiesFieldSpecified = "enableActivitiesFieldSpecified";
        private const string FieldenableDivisionsField = "enableDivisionsField";
        private const string FieldenableDivisionsFieldSpecified = "enableDivisionsFieldSpecified";
        private const string FieldenableEnhancedLookupField = "enableEnhancedLookupField";
        private const string FieldenableEnhancedLookupFieldSpecified = "enableEnhancedLookupFieldSpecified";
        private const string FieldenableFeedsField = "enableFeedsField";
        private const string FieldenableFeedsFieldSpecified = "enableFeedsFieldSpecified";
        private const string FieldenableHistoryField = "enableHistoryField";
        private const string FieldenableHistoryFieldSpecified = "enableHistoryFieldSpecified";
        private const string FieldenableReportsField = "enableReportsField";
        private const string FieldenableReportsFieldSpecified = "enableReportsFieldSpecified";
        private const string FieldfieldSetsField = "fieldSetsField";
        private const string FieldfieldsField = "fieldsField";
        private const string FieldgenderField = "genderField";
        private const string FieldgenderFieldSpecified = "genderFieldSpecified";
        private const string FieldhouseholdField = "householdField";
        private const string FieldhouseholdFieldSpecified = "householdFieldSpecified";
        private const string FieldlabelField = "labelField";
        private const string FieldlistViewsField = "listViewsField";
        private const string FieldnameFieldField = "nameFieldField";
        private const string FieldnamedFiltersField = "namedFiltersField";
        private const string FieldpluralLabelField = "pluralLabelField";
        private const string FieldrecordTypeTrackFeedHistoryField = "recordTypeTrackFeedHistoryField";
        private const string FieldrecordTypeTrackFeedHistoryFieldSpecified = "recordTypeTrackFeedHistoryFieldSpecified";
        private const string FieldrecordTypeTrackHistoryField = "recordTypeTrackHistoryField";
        private const string FieldrecordTypeTrackHistoryFieldSpecified = "recordTypeTrackHistoryFieldSpecified";
        private const string FieldrecordTypesField = "recordTypesField";
        private const string FieldsearchLayoutsField = "searchLayoutsField";
        private const string FieldsharingModelField = "sharingModelField";
        private const string FieldsharingModelFieldSpecified = "sharingModelFieldSpecified";
        private const string FieldsharingReasonsField = "sharingReasonsField";
        private const string FieldsharingRecalculationsField = "sharingRecalculationsField";
        private const string FieldstartsWithField = "startsWithField";
        private const string FieldstartsWithFieldSpecified = "startsWithFieldSpecified";
        private const string FieldvalidationRulesField = "validationRulesField";
        private const string FieldwebLinksField = "webLinksField";
        private Type _customObjectInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomObject _customObjectInstance;
        private CustomObject _customObjectInstanceFixture;

        #region General Initializer : Class (CustomObject) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomObject" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customObjectInstanceType = typeof(CustomObject);
            _customObjectInstanceFixture = Create(true);
            _customObjectInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomObject)

        #region General Initializer : Class (CustomObject) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomObject" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyactionOverrides)]
        [TestCase(PropertyarticleTypeChannelDisplay)]
        [TestCase(PropertybusinessProcesses)]
        [TestCase(PropertycustomHelp)]
        [TestCase(PropertycustomHelpPage)]
        [TestCase(PropertycustomSettingsType)]
        [TestCase(PropertycustomSettingsTypeSpecified)]
        [TestCase(PropertycustomSettingsVisibility)]
        [TestCase(PropertycustomSettingsVisibilitySpecified)]
        [TestCase(PropertydeploymentStatus)]
        [TestCase(PropertydeploymentStatusSpecified)]
        [TestCase(Propertydeprecated)]
        [TestCase(PropertydeprecatedSpecified)]
        [TestCase(Propertydescription)]
        [TestCase(PropertyenableActivities)]
        [TestCase(PropertyenableActivitiesSpecified)]
        [TestCase(PropertyenableDivisions)]
        [TestCase(PropertyenableDivisionsSpecified)]
        [TestCase(PropertyenableEnhancedLookup)]
        [TestCase(PropertyenableEnhancedLookupSpecified)]
        [TestCase(PropertyenableFeeds)]
        [TestCase(PropertyenableFeedsSpecified)]
        [TestCase(PropertyenableHistory)]
        [TestCase(PropertyenableHistorySpecified)]
        [TestCase(PropertyenableReports)]
        [TestCase(PropertyenableReportsSpecified)]
        [TestCase(PropertyfieldSets)]
        [TestCase(Propertyfields)]
        [TestCase(Propertygender)]
        [TestCase(PropertygenderSpecified)]
        [TestCase(Propertyhousehold)]
        [TestCase(PropertyhouseholdSpecified)]
        [TestCase(Propertylabel)]
        [TestCase(PropertylistViews)]
        [TestCase(PropertynameField)]
        [TestCase(PropertynamedFilters)]
        [TestCase(PropertypluralLabel)]
        [TestCase(PropertyrecordTypeTrackFeedHistory)]
        [TestCase(PropertyrecordTypeTrackFeedHistorySpecified)]
        [TestCase(PropertyrecordTypeTrackHistory)]
        [TestCase(PropertyrecordTypeTrackHistorySpecified)]
        [TestCase(PropertyrecordTypes)]
        [TestCase(PropertysearchLayouts)]
        [TestCase(PropertysharingModel)]
        [TestCase(PropertysharingModelSpecified)]
        [TestCase(PropertysharingReasons)]
        [TestCase(PropertysharingRecalculations)]
        [TestCase(PropertystartsWith)]
        [TestCase(PropertystartsWithSpecified)]
        [TestCase(PropertyvalidationRules)]
        [TestCase(PropertywebLinks)]
        public void AUT_CustomObject_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customObjectInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomObject) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomObject" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactionOverridesField)]
        [TestCase(FieldarticleTypeChannelDisplayField)]
        [TestCase(FieldbusinessProcessesField)]
        [TestCase(FieldcustomHelpField)]
        [TestCase(FieldcustomHelpPageField)]
        [TestCase(FieldcustomSettingsTypeField)]
        [TestCase(FieldcustomSettingsTypeFieldSpecified)]
        [TestCase(FieldcustomSettingsVisibilityField)]
        [TestCase(FieldcustomSettingsVisibilityFieldSpecified)]
        [TestCase(FielddeploymentStatusField)]
        [TestCase(FielddeploymentStatusFieldSpecified)]
        [TestCase(FielddeprecatedField)]
        [TestCase(FielddeprecatedFieldSpecified)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldenableActivitiesField)]
        [TestCase(FieldenableActivitiesFieldSpecified)]
        [TestCase(FieldenableDivisionsField)]
        [TestCase(FieldenableDivisionsFieldSpecified)]
        [TestCase(FieldenableEnhancedLookupField)]
        [TestCase(FieldenableEnhancedLookupFieldSpecified)]
        [TestCase(FieldenableFeedsField)]
        [TestCase(FieldenableFeedsFieldSpecified)]
        [TestCase(FieldenableHistoryField)]
        [TestCase(FieldenableHistoryFieldSpecified)]
        [TestCase(FieldenableReportsField)]
        [TestCase(FieldenableReportsFieldSpecified)]
        [TestCase(FieldfieldSetsField)]
        [TestCase(FieldfieldsField)]
        [TestCase(FieldgenderField)]
        [TestCase(FieldgenderFieldSpecified)]
        [TestCase(FieldhouseholdField)]
        [TestCase(FieldhouseholdFieldSpecified)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldlistViewsField)]
        [TestCase(FieldnameFieldField)]
        [TestCase(FieldnamedFiltersField)]
        [TestCase(FieldpluralLabelField)]
        [TestCase(FieldrecordTypeTrackFeedHistoryField)]
        [TestCase(FieldrecordTypeTrackFeedHistoryFieldSpecified)]
        [TestCase(FieldrecordTypeTrackHistoryField)]
        [TestCase(FieldrecordTypeTrackHistoryFieldSpecified)]
        [TestCase(FieldrecordTypesField)]
        [TestCase(FieldsearchLayoutsField)]
        [TestCase(FieldsharingModelField)]
        [TestCase(FieldsharingModelFieldSpecified)]
        [TestCase(FieldsharingReasonsField)]
        [TestCase(FieldsharingRecalculationsField)]
        [TestCase(FieldstartsWithField)]
        [TestCase(FieldstartsWithFieldSpecified)]
        [TestCase(FieldvalidationRulesField)]
        [TestCase(FieldwebLinksField)]
        public void AUT_CustomObject_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customObjectInstanceFixture, 
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
        ///     Class (<see cref="CustomObject" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomObject_Is_Instance_Present_Test()
        {
            // Assert
            _customObjectInstanceType.ShouldNotBeNull();
            _customObjectInstance.ShouldNotBeNull();
            _customObjectInstanceFixture.ShouldNotBeNull();
            _customObjectInstance.ShouldBeAssignableTo<CustomObject>();
            _customObjectInstanceFixture.ShouldBeAssignableTo<CustomObject>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomObject) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomObject_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomObject instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customObjectInstanceType.ShouldNotBeNull();
            _customObjectInstance.ShouldNotBeNull();
            _customObjectInstanceFixture.ShouldNotBeNull();
            _customObjectInstance.ShouldBeAssignableTo<CustomObject>();
            _customObjectInstanceFixture.ShouldBeAssignableTo<CustomObject>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomObject) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ActionOverride[]) , PropertyactionOverrides)]
        [TestCaseGeneric(typeof(ArticleTypeTemplate[]) , PropertyarticleTypeChannelDisplay)]
        [TestCaseGeneric(typeof(BusinessProcess[]) , PropertybusinessProcesses)]
        [TestCaseGeneric(typeof(string) , PropertycustomHelp)]
        [TestCaseGeneric(typeof(string) , PropertycustomHelpPage)]
        [TestCaseGeneric(typeof(CustomSettingsType) , PropertycustomSettingsType)]
        [TestCaseGeneric(typeof(bool) , PropertycustomSettingsTypeSpecified)]
        [TestCaseGeneric(typeof(CustomSettingsVisibility) , PropertycustomSettingsVisibility)]
        [TestCaseGeneric(typeof(bool) , PropertycustomSettingsVisibilitySpecified)]
        [TestCaseGeneric(typeof(DeploymentStatus) , PropertydeploymentStatus)]
        [TestCaseGeneric(typeof(bool) , PropertydeploymentStatusSpecified)]
        [TestCaseGeneric(typeof(bool) , Propertydeprecated)]
        [TestCaseGeneric(typeof(bool) , PropertydeprecatedSpecified)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(bool) , PropertyenableActivities)]
        [TestCaseGeneric(typeof(bool) , PropertyenableActivitiesSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableDivisions)]
        [TestCaseGeneric(typeof(bool) , PropertyenableDivisionsSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableEnhancedLookup)]
        [TestCaseGeneric(typeof(bool) , PropertyenableEnhancedLookupSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableFeeds)]
        [TestCaseGeneric(typeof(bool) , PropertyenableFeedsSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableHistory)]
        [TestCaseGeneric(typeof(bool) , PropertyenableHistorySpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableReports)]
        [TestCaseGeneric(typeof(bool) , PropertyenableReportsSpecified)]
        [TestCaseGeneric(typeof(FieldSet[]) , PropertyfieldSets)]
        [TestCaseGeneric(typeof(CustomField[]) , Propertyfields)]
        [TestCaseGeneric(typeof(Gender) , Propertygender)]
        [TestCaseGeneric(typeof(bool) , PropertygenderSpecified)]
        [TestCaseGeneric(typeof(bool) , Propertyhousehold)]
        [TestCaseGeneric(typeof(bool) , PropertyhouseholdSpecified)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(ListView[]) , PropertylistViews)]
        [TestCaseGeneric(typeof(CustomField) , PropertynameField)]
        [TestCaseGeneric(typeof(NamedFilter[]) , PropertynamedFilters)]
        [TestCaseGeneric(typeof(string) , PropertypluralLabel)]
        [TestCaseGeneric(typeof(bool) , PropertyrecordTypeTrackFeedHistory)]
        [TestCaseGeneric(typeof(bool) , PropertyrecordTypeTrackFeedHistorySpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyrecordTypeTrackHistory)]
        [TestCaseGeneric(typeof(bool) , PropertyrecordTypeTrackHistorySpecified)]
        [TestCaseGeneric(typeof(RecordType[]) , PropertyrecordTypes)]
        [TestCaseGeneric(typeof(SearchLayouts) , PropertysearchLayouts)]
        [TestCaseGeneric(typeof(SharingModel) , PropertysharingModel)]
        [TestCaseGeneric(typeof(bool) , PropertysharingModelSpecified)]
        [TestCaseGeneric(typeof(SharingReason[]) , PropertysharingReasons)]
        [TestCaseGeneric(typeof(SharingRecalculation[]) , PropertysharingRecalculations)]
        [TestCaseGeneric(typeof(StartsWith) , PropertystartsWith)]
        [TestCaseGeneric(typeof(bool) , PropertystartsWithSpecified)]
        [TestCaseGeneric(typeof(ValidationRule[]) , PropertyvalidationRules)]
        [TestCaseGeneric(typeof(WebLink[]) , PropertywebLinks)]
        public void AUT_CustomObject_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomObject, T>(_customObjectInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (actionOverrides) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_actionOverrides_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyactionOverrides);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (actionOverrides) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_actionOverrides_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyactionOverrides);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (articleTypeChannelDisplay) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_articleTypeChannelDisplay_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyarticleTypeChannelDisplay);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (articleTypeChannelDisplay) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_articleTypeChannelDisplay_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyarticleTypeChannelDisplay);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (businessProcesses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_businessProcesses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertybusinessProcesses);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (businessProcesses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_businessProcesses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybusinessProcesses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (customHelp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_customHelp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomHelp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (customHelpPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_customHelpPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomHelpPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (customSettingsType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_customSettingsType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomSettingsType);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (customSettingsType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_customSettingsType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomSettingsType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (customSettingsTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_customSettingsTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomSettingsTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (customSettingsVisibility) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_customSettingsVisibility_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomSettingsVisibility);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (customSettingsVisibility) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_customSettingsVisibility_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomSettingsVisibility);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (customSettingsVisibilitySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_customSettingsVisibilitySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomSettingsVisibilitySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (deploymentStatus) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_deploymentStatus_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydeploymentStatus);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (deploymentStatus) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_deploymentStatus_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeploymentStatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (deploymentStatusSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_deploymentStatusSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeploymentStatusSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (deprecated) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_deprecated_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydeprecated);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (deprecatedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_deprecatedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeprecatedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (enableActivities) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_enableActivities_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableActivities);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (enableActivitiesSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_enableActivitiesSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableActivitiesSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (enableDivisions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_enableDivisions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableDivisions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (enableDivisionsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_enableDivisionsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableDivisionsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (enableEnhancedLookup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_enableEnhancedLookup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableEnhancedLookup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (enableEnhancedLookupSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_enableEnhancedLookupSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableEnhancedLookupSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (enableFeeds) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_enableFeeds_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableFeeds);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (enableFeedsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_enableFeedsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableFeedsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (enableHistory) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_enableHistory_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableHistory);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (enableHistorySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_enableHistorySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableHistorySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (enableReports) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_enableReports_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableReports);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (enableReportsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_enableReportsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableReportsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (fields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_fields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfields);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (fields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_fields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (fieldSets) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_fieldSets_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyfieldSets);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (fieldSets) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_fieldSets_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfieldSets);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (gender) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_gender_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertygender);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (gender) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_gender_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertygender);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (genderSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_genderSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertygenderSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (household) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_household_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyhousehold);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (householdSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_householdSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhouseholdSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (listViews) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_listViews_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylistViews);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (listViews) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_listViews_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylistViews);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (namedFilters) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_namedFilters_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertynamedFilters);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (namedFilters) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_namedFilters_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynamedFilters);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (nameField) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_nameField_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertynameField);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (nameField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_nameField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynameField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (pluralLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_pluralLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypluralLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (recordTypes) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_recordTypes_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrecordTypes);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (recordTypes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_recordTypes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrecordTypes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (recordTypeTrackFeedHistory) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_recordTypeTrackFeedHistory_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrecordTypeTrackFeedHistory);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (recordTypeTrackFeedHistorySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_recordTypeTrackFeedHistorySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrecordTypeTrackFeedHistorySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (recordTypeTrackHistory) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_recordTypeTrackHistory_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrecordTypeTrackHistory);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (recordTypeTrackHistorySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_recordTypeTrackHistorySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrecordTypeTrackHistorySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (searchLayouts) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_searchLayouts_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysearchLayouts);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (searchLayouts) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_searchLayouts_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysearchLayouts);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (sharingModel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_sharingModel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysharingModel);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (sharingModel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_sharingModel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysharingModel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (sharingModelSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_sharingModelSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysharingModelSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (sharingReasons) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_sharingReasons_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysharingReasons);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (sharingReasons) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_sharingReasons_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysharingReasons);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (sharingRecalculations) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_sharingRecalculations_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysharingRecalculations);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (sharingRecalculations) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_sharingRecalculations_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysharingRecalculations);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (startsWith) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_startsWith_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertystartsWith);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (startsWith) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_startsWith_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystartsWith);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (startsWithSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_startsWithSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystartsWithSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (validationRules) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_validationRules_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyvalidationRules);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (validationRules) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_validationRules_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyvalidationRules);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (webLinks) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_webLinks_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertywebLinks);
            Action currentAction = () => propertyInfo.SetValue(_customObjectInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObject) => Property (webLinks) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObject_Public_Class_webLinks_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertywebLinks);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #endregion

        #endregion
    }
}