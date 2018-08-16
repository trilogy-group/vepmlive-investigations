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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowChoiceUserInput" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowChoiceUserInputTest : AbstractBaseSetupTypedTest<FlowChoiceUserInput>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowChoiceUserInput) Initializer

        private const string PropertyisRequired = "isRequired";
        private const string PropertyisRequiredSpecified = "isRequiredSpecified";
        private const string PropertypromptText = "promptText";
        private const string PropertyvalidationRule = "validationRule";
        private const string FieldisRequiredField = "isRequiredField";
        private const string FieldisRequiredFieldSpecified = "isRequiredFieldSpecified";
        private const string FieldpromptTextField = "promptTextField";
        private const string FieldvalidationRuleField = "validationRuleField";
        private Type _flowChoiceUserInputInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowChoiceUserInput _flowChoiceUserInputInstance;
        private FlowChoiceUserInput _flowChoiceUserInputInstanceFixture;

        #region General Initializer : Class (FlowChoiceUserInput) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowChoiceUserInput" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowChoiceUserInputInstanceType = typeof(FlowChoiceUserInput);
            _flowChoiceUserInputInstanceFixture = Create(true);
            _flowChoiceUserInputInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowChoiceUserInput)

        #region General Initializer : Class (FlowChoiceUserInput) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowChoiceUserInput" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyisRequired)]
        [TestCase(PropertyisRequiredSpecified)]
        [TestCase(PropertypromptText)]
        [TestCase(PropertyvalidationRule)]
        public void AUT_FlowChoiceUserInput_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowChoiceUserInputInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowChoiceUserInput) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowChoiceUserInput" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldisRequiredField)]
        [TestCase(FieldisRequiredFieldSpecified)]
        [TestCase(FieldpromptTextField)]
        [TestCase(FieldvalidationRuleField)]
        public void AUT_FlowChoiceUserInput_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowChoiceUserInputInstanceFixture, 
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
        ///     Class (<see cref="FlowChoiceUserInput" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowChoiceUserInput_Is_Instance_Present_Test()
        {
            // Assert
            _flowChoiceUserInputInstanceType.ShouldNotBeNull();
            _flowChoiceUserInputInstance.ShouldNotBeNull();
            _flowChoiceUserInputInstanceFixture.ShouldNotBeNull();
            _flowChoiceUserInputInstance.ShouldBeAssignableTo<FlowChoiceUserInput>();
            _flowChoiceUserInputInstanceFixture.ShouldBeAssignableTo<FlowChoiceUserInput>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowChoiceUserInput) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowChoiceUserInput_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowChoiceUserInput instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowChoiceUserInputInstanceType.ShouldNotBeNull();
            _flowChoiceUserInputInstance.ShouldNotBeNull();
            _flowChoiceUserInputInstanceFixture.ShouldNotBeNull();
            _flowChoiceUserInputInstance.ShouldBeAssignableTo<FlowChoiceUserInput>();
            _flowChoiceUserInputInstanceFixture.ShouldBeAssignableTo<FlowChoiceUserInput>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowChoiceUserInput) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyisRequired)]
        [TestCaseGeneric(typeof(bool) , PropertyisRequiredSpecified)]
        [TestCaseGeneric(typeof(string) , PropertypromptText)]
        [TestCaseGeneric(typeof(FlowInputValidationRule) , PropertyvalidationRule)]
        public void AUT_FlowChoiceUserInput_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowChoiceUserInput, T>(_flowChoiceUserInputInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowChoiceUserInput) => Property (isRequired) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowChoiceUserInput_Public_Class_isRequired_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowChoiceUserInput) => Property (isRequiredSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowChoiceUserInput_Public_Class_isRequiredSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowChoiceUserInput) => Property (promptText) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowChoiceUserInput_Public_Class_promptText_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypromptText);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowChoiceUserInput) => Property (validationRule) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowChoiceUserInput_validationRule_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyvalidationRule);
            Action currentAction = () => propertyInfo.SetValue(_flowChoiceUserInputInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowChoiceUserInput) => Property (validationRule) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowChoiceUserInput_Public_Class_validationRule_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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