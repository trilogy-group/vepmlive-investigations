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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowScreenField" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowScreenFieldTest : AbstractBaseSetupTypedTest<FlowScreenField>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowScreenField) Initializer

        private const string PropertychoiceReferences = "choiceReferences";
        private const string PropertydataType = "dataType";
        private const string PropertydataTypeSpecified = "dataTypeSpecified";
        private const string PropertydefaultSelectedChoiceReference = "defaultSelectedChoiceReference";
        private const string PropertydefaultValue = "defaultValue";
        private const string PropertyfieldText = "fieldText";
        private const string PropertyfieldType = "fieldType";
        private const string PropertyhelpText = "helpText";
        private const string PropertyisRequired = "isRequired";
        private const string PropertyisRequiredSpecified = "isRequiredSpecified";
        private const string Propertyscale = "scale";
        private const string PropertyscaleSpecified = "scaleSpecified";
        private const string PropertyvalidationRule = "validationRule";
        private const string FieldchoiceReferencesField = "choiceReferencesField";
        private const string FielddataTypeField = "dataTypeField";
        private const string FielddataTypeFieldSpecified = "dataTypeFieldSpecified";
        private const string FielddefaultSelectedChoiceReferenceField = "defaultSelectedChoiceReferenceField";
        private const string FielddefaultValueField = "defaultValueField";
        private const string FieldfieldTextField = "fieldTextField";
        private const string FieldfieldTypeField = "fieldTypeField";
        private const string FieldhelpTextField = "helpTextField";
        private const string FieldisRequiredField = "isRequiredField";
        private const string FieldisRequiredFieldSpecified = "isRequiredFieldSpecified";
        private const string FieldscaleField = "scaleField";
        private const string FieldscaleFieldSpecified = "scaleFieldSpecified";
        private const string FieldvalidationRuleField = "validationRuleField";
        private Type _flowScreenFieldInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowScreenField _flowScreenFieldInstance;
        private FlowScreenField _flowScreenFieldInstanceFixture;

        #region General Initializer : Class (FlowScreenField) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowScreenField" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowScreenFieldInstanceType = typeof(FlowScreenField);
            _flowScreenFieldInstanceFixture = Create(true);
            _flowScreenFieldInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowScreenField)

        #region General Initializer : Class (FlowScreenField) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowScreenField" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertychoiceReferences)]
        [TestCase(PropertydataType)]
        [TestCase(PropertydataTypeSpecified)]
        [TestCase(PropertydefaultSelectedChoiceReference)]
        [TestCase(PropertydefaultValue)]
        [TestCase(PropertyfieldText)]
        [TestCase(PropertyfieldType)]
        [TestCase(PropertyhelpText)]
        [TestCase(PropertyisRequired)]
        [TestCase(PropertyisRequiredSpecified)]
        [TestCase(Propertyscale)]
        [TestCase(PropertyscaleSpecified)]
        [TestCase(PropertyvalidationRule)]
        public void AUT_FlowScreenField_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowScreenFieldInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowScreenField) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowScreenField" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldchoiceReferencesField)]
        [TestCase(FielddataTypeField)]
        [TestCase(FielddataTypeFieldSpecified)]
        [TestCase(FielddefaultSelectedChoiceReferenceField)]
        [TestCase(FielddefaultValueField)]
        [TestCase(FieldfieldTextField)]
        [TestCase(FieldfieldTypeField)]
        [TestCase(FieldhelpTextField)]
        [TestCase(FieldisRequiredField)]
        [TestCase(FieldisRequiredFieldSpecified)]
        [TestCase(FieldscaleField)]
        [TestCase(FieldscaleFieldSpecified)]
        [TestCase(FieldvalidationRuleField)]
        public void AUT_FlowScreenField_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowScreenFieldInstanceFixture, 
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
        ///     Class (<see cref="FlowScreenField" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowScreenField_Is_Instance_Present_Test()
        {
            // Assert
            _flowScreenFieldInstanceType.ShouldNotBeNull();
            _flowScreenFieldInstance.ShouldNotBeNull();
            _flowScreenFieldInstanceFixture.ShouldNotBeNull();
            _flowScreenFieldInstance.ShouldBeAssignableTo<FlowScreenField>();
            _flowScreenFieldInstanceFixture.ShouldBeAssignableTo<FlowScreenField>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowScreenField) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowScreenField_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowScreenField instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowScreenFieldInstanceType.ShouldNotBeNull();
            _flowScreenFieldInstance.ShouldNotBeNull();
            _flowScreenFieldInstanceFixture.ShouldNotBeNull();
            _flowScreenFieldInstance.ShouldBeAssignableTo<FlowScreenField>();
            _flowScreenFieldInstanceFixture.ShouldBeAssignableTo<FlowScreenField>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowScreenField) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , PropertychoiceReferences)]
        [TestCaseGeneric(typeof(FlowDataType) , PropertydataType)]
        [TestCaseGeneric(typeof(bool) , PropertydataTypeSpecified)]
        [TestCaseGeneric(typeof(string) , PropertydefaultSelectedChoiceReference)]
        [TestCaseGeneric(typeof(FlowElementReferenceOrValue) , PropertydefaultValue)]
        [TestCaseGeneric(typeof(string) , PropertyfieldText)]
        [TestCaseGeneric(typeof(FlowScreenFieldType) , PropertyfieldType)]
        [TestCaseGeneric(typeof(string) , PropertyhelpText)]
        [TestCaseGeneric(typeof(bool) , PropertyisRequired)]
        [TestCaseGeneric(typeof(bool) , PropertyisRequiredSpecified)]
        [TestCaseGeneric(typeof(int) , Propertyscale)]
        [TestCaseGeneric(typeof(bool) , PropertyscaleSpecified)]
        [TestCaseGeneric(typeof(FlowInputValidationRule) , PropertyvalidationRule)]
        public void AUT_FlowScreenField_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowScreenField, T>(_flowScreenFieldInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (choiceReferences) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_choiceReferences_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertychoiceReferences);
            Action currentAction = () => propertyInfo.SetValue(_flowScreenFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (choiceReferences) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_Public_Class_choiceReferences_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychoiceReferences);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (dataType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_dataType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydataType);
            Action currentAction = () => propertyInfo.SetValue(_flowScreenFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (dataType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_Public_Class_dataType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydataType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (dataTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_Public_Class_dataTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydataTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (defaultSelectedChoiceReference) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_Public_Class_defaultSelectedChoiceReference_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultSelectedChoiceReference);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (defaultValue) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_defaultValue_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydefaultValue);
            Action currentAction = () => propertyInfo.SetValue(_flowScreenFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (defaultValue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_Public_Class_defaultValue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultValue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (fieldText) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_Public_Class_fieldText_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfieldText);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (fieldType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_fieldType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyfieldType);
            Action currentAction = () => propertyInfo.SetValue(_flowScreenFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (fieldType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_Public_Class_fieldType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfieldType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (helpText) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_Public_Class_helpText_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhelpText);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (isRequired) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_Public_Class_isRequired_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisRequired);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (isRequiredSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_Public_Class_isRequiredSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisRequiredSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (scale) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_Public_Class_scale_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyscale);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (scaleSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_Public_Class_scaleSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyscaleSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (validationRule) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_validationRule_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyvalidationRule);
            Action currentAction = () => propertyInfo.SetValue(_flowScreenFieldInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowScreenField) => Property (validationRule) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowScreenField_Public_Class_validationRule_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyvalidationRule);

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