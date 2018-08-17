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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowSubflow" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowSubflowTest : AbstractBaseSetupTypedTest<FlowSubflow>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowSubflow) Initializer

        private const string Propertyconnector = "connector";
        private const string PropertyflowName = "flowName";
        private const string PropertyinputAssignments = "inputAssignments";
        private const string PropertyoutputAssignments = "outputAssignments";
        private const string FieldconnectorField = "connectorField";
        private const string FieldflowNameField = "flowNameField";
        private const string FieldinputAssignmentsField = "inputAssignmentsField";
        private const string FieldoutputAssignmentsField = "outputAssignmentsField";
        private Type _flowSubflowInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowSubflow _flowSubflowInstance;
        private FlowSubflow _flowSubflowInstanceFixture;

        #region General Initializer : Class (FlowSubflow) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowSubflow" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowSubflowInstanceType = typeof(FlowSubflow);
            _flowSubflowInstanceFixture = Create(true);
            _flowSubflowInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowSubflow)

        #region General Initializer : Class (FlowSubflow) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowSubflow" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyconnector)]
        [TestCase(PropertyflowName)]
        [TestCase(PropertyinputAssignments)]
        [TestCase(PropertyoutputAssignments)]
        public void AUT_FlowSubflow_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowSubflowInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowSubflow) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowSubflow" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldconnectorField)]
        [TestCase(FieldflowNameField)]
        [TestCase(FieldinputAssignmentsField)]
        [TestCase(FieldoutputAssignmentsField)]
        public void AUT_FlowSubflow_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowSubflowInstanceFixture, 
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
        ///     Class (<see cref="FlowSubflow" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowSubflow_Is_Instance_Present_Test()
        {
            // Assert
            _flowSubflowInstanceType.ShouldNotBeNull();
            _flowSubflowInstance.ShouldNotBeNull();
            _flowSubflowInstanceFixture.ShouldNotBeNull();
            _flowSubflowInstance.ShouldBeAssignableTo<FlowSubflow>();
            _flowSubflowInstanceFixture.ShouldBeAssignableTo<FlowSubflow>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowSubflow) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowSubflow_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowSubflow instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowSubflowInstanceType.ShouldNotBeNull();
            _flowSubflowInstance.ShouldNotBeNull();
            _flowSubflowInstanceFixture.ShouldNotBeNull();
            _flowSubflowInstance.ShouldBeAssignableTo<FlowSubflow>();
            _flowSubflowInstanceFixture.ShouldBeAssignableTo<FlowSubflow>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowSubflow) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(FlowConnector) , Propertyconnector)]
        [TestCaseGeneric(typeof(string) , PropertyflowName)]
        [TestCaseGeneric(typeof(FlowSubflowInputAssignment[]) , PropertyinputAssignments)]
        [TestCaseGeneric(typeof(FlowSubflowOutputAssignment[]) , PropertyoutputAssignments)]
        public void AUT_FlowSubflow_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowSubflow, T>(_flowSubflowInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowSubflow) => Property (connector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowSubflow_connector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyconnector);
            Action currentAction = () => propertyInfo.SetValue(_flowSubflowInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowSubflow) => Property (connector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowSubflow_Public_Class_connector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyconnector);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowSubflow) => Property (flowName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowSubflow_Public_Class_flowName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyflowName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowSubflow) => Property (inputAssignments) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowSubflow_inputAssignments_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyinputAssignments);
            Action currentAction = () => propertyInfo.SetValue(_flowSubflowInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowSubflow) => Property (inputAssignments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowSubflow_Public_Class_inputAssignments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyinputAssignments);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowSubflow) => Property (outputAssignments) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowSubflow_outputAssignments_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyoutputAssignments);
            Action currentAction = () => propertyInfo.SetValue(_flowSubflowInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowSubflow) => Property (outputAssignments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowSubflow_Public_Class_outputAssignments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyoutputAssignments);

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