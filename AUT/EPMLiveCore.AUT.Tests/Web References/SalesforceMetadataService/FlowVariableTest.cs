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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowVariable" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowVariableTest : AbstractBaseSetupTypedTest<FlowVariable>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowVariable) Initializer

        private const string PropertydataType = "dataType";
        private const string PropertyisInput = "isInput";
        private const string PropertyisInputSpecified = "isInputSpecified";
        private const string PropertyisOutput = "isOutput";
        private const string PropertyisOutputSpecified = "isOutputSpecified";
        private const string Propertyscale = "scale";
        private const string PropertyscaleSpecified = "scaleSpecified";
        private const string Propertyvalue = "value";
        private const string FielddataTypeField = "dataTypeField";
        private const string FieldisInputField = "isInputField";
        private const string FieldisInputFieldSpecified = "isInputFieldSpecified";
        private const string FieldisOutputField = "isOutputField";
        private const string FieldisOutputFieldSpecified = "isOutputFieldSpecified";
        private const string FieldscaleField = "scaleField";
        private const string FieldscaleFieldSpecified = "scaleFieldSpecified";
        private const string FieldvalueField = "valueField";
        private Type _flowVariableInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowVariable _flowVariableInstance;
        private FlowVariable _flowVariableInstanceFixture;

        #region General Initializer : Class (FlowVariable) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowVariable" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowVariableInstanceType = typeof(FlowVariable);
            _flowVariableInstanceFixture = Create(true);
            _flowVariableInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowVariable)

        #region General Initializer : Class (FlowVariable) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowVariable" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydataType)]
        [TestCase(PropertyisInput)]
        [TestCase(PropertyisInputSpecified)]
        [TestCase(PropertyisOutput)]
        [TestCase(PropertyisOutputSpecified)]
        [TestCase(Propertyscale)]
        [TestCase(PropertyscaleSpecified)]
        [TestCase(Propertyvalue)]
        public void AUT_FlowVariable_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowVariableInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowVariable) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowVariable" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddataTypeField)]
        [TestCase(FieldisInputField)]
        [TestCase(FieldisInputFieldSpecified)]
        [TestCase(FieldisOutputField)]
        [TestCase(FieldisOutputFieldSpecified)]
        [TestCase(FieldscaleField)]
        [TestCase(FieldscaleFieldSpecified)]
        [TestCase(FieldvalueField)]
        public void AUT_FlowVariable_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowVariableInstanceFixture, 
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
        ///     Class (<see cref="FlowVariable" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowVariable_Is_Instance_Present_Test()
        {
            // Assert
            _flowVariableInstanceType.ShouldNotBeNull();
            _flowVariableInstance.ShouldNotBeNull();
            _flowVariableInstanceFixture.ShouldNotBeNull();
            _flowVariableInstance.ShouldBeAssignableTo<FlowVariable>();
            _flowVariableInstanceFixture.ShouldBeAssignableTo<FlowVariable>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowVariable) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowVariable_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowVariable instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowVariableInstanceType.ShouldNotBeNull();
            _flowVariableInstance.ShouldNotBeNull();
            _flowVariableInstanceFixture.ShouldNotBeNull();
            _flowVariableInstance.ShouldBeAssignableTo<FlowVariable>();
            _flowVariableInstanceFixture.ShouldBeAssignableTo<FlowVariable>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowVariable) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(FlowDataType) , PropertydataType)]
        [TestCaseGeneric(typeof(bool) , PropertyisInput)]
        [TestCaseGeneric(typeof(bool) , PropertyisInputSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyisOutput)]
        [TestCaseGeneric(typeof(bool) , PropertyisOutputSpecified)]
        [TestCaseGeneric(typeof(int) , Propertyscale)]
        [TestCaseGeneric(typeof(bool) , PropertyscaleSpecified)]
        [TestCaseGeneric(typeof(FlowElementReferenceOrValue) , Propertyvalue)]
        public void AUT_FlowVariable_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowVariable, T>(_flowVariableInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowVariable) => Property (dataType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowVariable_dataType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydataType);
            Action currentAction = () => propertyInfo.SetValue(_flowVariableInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowVariable) => Property (dataType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowVariable_Public_Class_dataType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowVariable) => Property (isInput) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowVariable_Public_Class_isInput_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisInput);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowVariable) => Property (isInputSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowVariable_Public_Class_isInputSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisInputSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowVariable) => Property (isOutput) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowVariable_Public_Class_isOutput_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisOutput);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowVariable) => Property (isOutputSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowVariable_Public_Class_isOutputSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisOutputSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowVariable) => Property (scale) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowVariable_Public_Class_scale_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowVariable) => Property (scaleSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowVariable_Public_Class_scaleSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowVariable) => Property (value) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowVariable_value_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyvalue);
            Action currentAction = () => propertyInfo.SetValue(_flowVariableInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowVariable) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowVariable_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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