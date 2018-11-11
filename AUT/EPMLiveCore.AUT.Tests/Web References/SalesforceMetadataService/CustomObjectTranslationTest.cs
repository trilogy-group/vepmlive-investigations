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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomObjectTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomObjectTranslationTest : AbstractBaseSetupTypedTest<CustomObjectTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomObjectTranslation) Initializer

        private const string PropertycaseValues = "caseValues";
        private const string Propertyfields = "fields";
        private const string Propertygender = "gender";
        private const string PropertygenderSpecified = "genderSpecified";
        private const string Propertylayouts = "layouts";
        private const string PropertynameFieldLabel = "nameFieldLabel";
        private const string PropertynamedFilters = "namedFilters";
        private const string PropertyrecordTypes = "recordTypes";
        private const string PropertysharingReasons = "sharingReasons";
        private const string PropertystartsWith = "startsWith";
        private const string PropertystartsWithSpecified = "startsWithSpecified";
        private const string PropertyvalidationRules = "validationRules";
        private const string PropertywebLinks = "webLinks";
        private const string PropertyworkflowTasks = "workflowTasks";
        private const string FieldcaseValuesField = "caseValuesField";
        private const string FieldfieldsField = "fieldsField";
        private const string FieldgenderField = "genderField";
        private const string FieldgenderFieldSpecified = "genderFieldSpecified";
        private const string FieldlayoutsField = "layoutsField";
        private const string FieldnameFieldLabelField = "nameFieldLabelField";
        private const string FieldnamedFiltersField = "namedFiltersField";
        private const string FieldrecordTypesField = "recordTypesField";
        private const string FieldsharingReasonsField = "sharingReasonsField";
        private const string FieldstartsWithField = "startsWithField";
        private const string FieldstartsWithFieldSpecified = "startsWithFieldSpecified";
        private const string FieldvalidationRulesField = "validationRulesField";
        private const string FieldwebLinksField = "webLinksField";
        private const string FieldworkflowTasksField = "workflowTasksField";
        private Type _customObjectTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomObjectTranslation _customObjectTranslationInstance;
        private CustomObjectTranslation _customObjectTranslationInstanceFixture;

        #region General Initializer : Class (CustomObjectTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomObjectTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customObjectTranslationInstanceType = typeof(CustomObjectTranslation);
            _customObjectTranslationInstanceFixture = Create(true);
            _customObjectTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomObjectTranslation)

        #region General Initializer : Class (CustomObjectTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomObjectTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycaseValues)]
        [TestCase(Propertyfields)]
        [TestCase(Propertygender)]
        [TestCase(PropertygenderSpecified)]
        [TestCase(Propertylayouts)]
        [TestCase(PropertynameFieldLabel)]
        [TestCase(PropertynamedFilters)]
        [TestCase(PropertyrecordTypes)]
        [TestCase(PropertysharingReasons)]
        [TestCase(PropertystartsWith)]
        [TestCase(PropertystartsWithSpecified)]
        [TestCase(PropertyvalidationRules)]
        [TestCase(PropertywebLinks)]
        [TestCase(PropertyworkflowTasks)]
        public void AUT_CustomObjectTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customObjectTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomObjectTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomObjectTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcaseValuesField)]
        [TestCase(FieldfieldsField)]
        [TestCase(FieldgenderField)]
        [TestCase(FieldgenderFieldSpecified)]
        [TestCase(FieldlayoutsField)]
        [TestCase(FieldnameFieldLabelField)]
        [TestCase(FieldnamedFiltersField)]
        [TestCase(FieldrecordTypesField)]
        [TestCase(FieldsharingReasonsField)]
        [TestCase(FieldstartsWithField)]
        [TestCase(FieldstartsWithFieldSpecified)]
        [TestCase(FieldvalidationRulesField)]
        [TestCase(FieldwebLinksField)]
        [TestCase(FieldworkflowTasksField)]
        public void AUT_CustomObjectTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customObjectTranslationInstanceFixture, 
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
        ///     Class (<see cref="CustomObjectTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomObjectTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _customObjectTranslationInstanceType.ShouldNotBeNull();
            _customObjectTranslationInstance.ShouldNotBeNull();
            _customObjectTranslationInstanceFixture.ShouldNotBeNull();
            _customObjectTranslationInstance.ShouldBeAssignableTo<CustomObjectTranslation>();
            _customObjectTranslationInstanceFixture.ShouldBeAssignableTo<CustomObjectTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomObjectTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomObjectTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomObjectTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customObjectTranslationInstanceType.ShouldNotBeNull();
            _customObjectTranslationInstance.ShouldNotBeNull();
            _customObjectTranslationInstanceFixture.ShouldNotBeNull();
            _customObjectTranslationInstance.ShouldBeAssignableTo<CustomObjectTranslation>();
            _customObjectTranslationInstanceFixture.ShouldBeAssignableTo<CustomObjectTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomObjectTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ObjectNameCaseValue[]) , PropertycaseValues)]
        [TestCaseGeneric(typeof(CustomFieldTranslation[]) , Propertyfields)]
        [TestCaseGeneric(typeof(Gender) , Propertygender)]
        [TestCaseGeneric(typeof(bool) , PropertygenderSpecified)]
        [TestCaseGeneric(typeof(LayoutTranslation[]) , Propertylayouts)]
        [TestCaseGeneric(typeof(string) , PropertynameFieldLabel)]
        [TestCaseGeneric(typeof(NamedFilterTranslation[]) , PropertynamedFilters)]
        [TestCaseGeneric(typeof(RecordTypeTranslation[]) , PropertyrecordTypes)]
        [TestCaseGeneric(typeof(SharingReasonTranslation[]) , PropertysharingReasons)]
        [TestCaseGeneric(typeof(StartsWith) , PropertystartsWith)]
        [TestCaseGeneric(typeof(bool) , PropertystartsWithSpecified)]
        [TestCaseGeneric(typeof(ValidationRuleTranslation[]) , PropertyvalidationRules)]
        [TestCaseGeneric(typeof(WebLinkTranslation[]) , PropertywebLinks)]
        [TestCaseGeneric(typeof(WorkflowTaskTranslation[]) , PropertyworkflowTasks)]
        public void AUT_CustomObjectTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomObjectTranslation, T>(_customObjectTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (caseValues) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_caseValues_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycaseValues);
            Action currentAction = () => propertyInfo.SetValue(_customObjectTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (caseValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_caseValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseValues);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (fields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_fields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfields);
            Action currentAction = () => propertyInfo.SetValue(_customObjectTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (fields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_fields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (gender) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_gender_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertygender);
            Action currentAction = () => propertyInfo.SetValue(_customObjectTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (gender) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_gender_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (genderSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_genderSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (layouts) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_layouts_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertylayouts);
            Action currentAction = () => propertyInfo.SetValue(_customObjectTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (layouts) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_layouts_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylayouts);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (namedFilters) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_namedFilters_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertynamedFilters);
            Action currentAction = () => propertyInfo.SetValue(_customObjectTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (namedFilters) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_namedFilters_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (nameFieldLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_nameFieldLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynameFieldLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (recordTypes) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_recordTypes_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrecordTypes);
            Action currentAction = () => propertyInfo.SetValue(_customObjectTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (recordTypes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_recordTypes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (sharingReasons) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_sharingReasons_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysharingReasons);
            Action currentAction = () => propertyInfo.SetValue(_customObjectTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (sharingReasons) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_sharingReasons_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (startsWith) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_startsWith_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertystartsWith);
            Action currentAction = () => propertyInfo.SetValue(_customObjectTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (startsWith) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_startsWith_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (startsWithSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_startsWithSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (validationRules) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_validationRules_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyvalidationRules);
            Action currentAction = () => propertyInfo.SetValue(_customObjectTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (validationRules) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_validationRules_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (webLinks) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_webLinks_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertywebLinks);
            Action currentAction = () => propertyInfo.SetValue(_customObjectTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (webLinks) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_webLinks_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (workflowTasks) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_workflowTasks_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyworkflowTasks);
            Action currentAction = () => propertyInfo.SetValue(_customObjectTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomObjectTranslation) => Property (workflowTasks) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomObjectTranslation_Public_Class_workflowTasks_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyworkflowTasks);

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