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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowChoice" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowChoiceTest : AbstractBaseSetupTypedTest<FlowChoice>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowChoice) Initializer

        private const string PropertychoiceText = "choiceText";
        private const string PropertydataType = "dataType";
        private const string PropertyuserInput = "userInput";
        private const string Propertyvalue = "value";
        private const string FieldchoiceTextField = "choiceTextField";
        private const string FielddataTypeField = "dataTypeField";
        private const string FielduserInputField = "userInputField";
        private const string FieldvalueField = "valueField";
        private Type _flowChoiceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowChoice _flowChoiceInstance;
        private FlowChoice _flowChoiceInstanceFixture;

        #region General Initializer : Class (FlowChoice) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowChoice" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowChoiceInstanceType = typeof(FlowChoice);
            _flowChoiceInstanceFixture = Create(true);
            _flowChoiceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowChoice)

        #region General Initializer : Class (FlowChoice) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowChoice" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertychoiceText)]
        [TestCase(PropertydataType)]
        [TestCase(PropertyuserInput)]
        [TestCase(Propertyvalue)]
        public void AUT_FlowChoice_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowChoiceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowChoice) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowChoice" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldchoiceTextField)]
        [TestCase(FielddataTypeField)]
        [TestCase(FielduserInputField)]
        [TestCase(FieldvalueField)]
        public void AUT_FlowChoice_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowChoiceInstanceFixture, 
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
        ///     Class (<see cref="FlowChoice" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowChoice_Is_Instance_Present_Test()
        {
            // Assert
            _flowChoiceInstanceType.ShouldNotBeNull();
            _flowChoiceInstance.ShouldNotBeNull();
            _flowChoiceInstanceFixture.ShouldNotBeNull();
            _flowChoiceInstance.ShouldBeAssignableTo<FlowChoice>();
            _flowChoiceInstanceFixture.ShouldBeAssignableTo<FlowChoice>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowChoice) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowChoice_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowChoice instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowChoiceInstanceType.ShouldNotBeNull();
            _flowChoiceInstance.ShouldNotBeNull();
            _flowChoiceInstanceFixture.ShouldNotBeNull();
            _flowChoiceInstance.ShouldBeAssignableTo<FlowChoice>();
            _flowChoiceInstanceFixture.ShouldBeAssignableTo<FlowChoice>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowChoice) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertychoiceText)]
        [TestCaseGeneric(typeof(FlowDataType) , PropertydataType)]
        [TestCaseGeneric(typeof(FlowChoiceUserInput) , PropertyuserInput)]
        [TestCaseGeneric(typeof(FlowElementReferenceOrValue) , Propertyvalue)]
        public void AUT_FlowChoice_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowChoice, T>(_flowChoiceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowChoice) => Property (choiceText) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowChoice_Public_Class_choiceText_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychoiceText);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowChoice) => Property (dataType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowChoice_dataType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydataType);
            Action currentAction = () => propertyInfo.SetValue(_flowChoiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowChoice) => Property (dataType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowChoice_Public_Class_dataType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowChoice) => Property (userInput) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowChoice_userInput_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyuserInput);
            Action currentAction = () => propertyInfo.SetValue(_flowChoiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowChoice) => Property (userInput) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowChoice_Public_Class_userInput_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserInput);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowChoice) => Property (value) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowChoice_value_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyvalue);
            Action currentAction = () => propertyInfo.SetValue(_flowChoiceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowChoice) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowChoice_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalue);

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