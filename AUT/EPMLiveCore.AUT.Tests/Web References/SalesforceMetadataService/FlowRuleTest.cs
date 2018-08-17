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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowRuleTest : AbstractBaseSetupTypedTest<FlowRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowRule) Initializer

        private const string PropertyconditionLogic = "conditionLogic";
        private const string Propertyconditions = "conditions";
        private const string Propertyconnector = "connector";
        private const string Propertylabel = "label";
        private const string FieldconditionLogicField = "conditionLogicField";
        private const string FieldconditionsField = "conditionsField";
        private const string FieldconnectorField = "connectorField";
        private const string FieldlabelField = "labelField";
        private Type _flowRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowRule _flowRuleInstance;
        private FlowRule _flowRuleInstanceFixture;

        #region General Initializer : Class (FlowRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowRuleInstanceType = typeof(FlowRule);
            _flowRuleInstanceFixture = Create(true);
            _flowRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowRule)

        #region General Initializer : Class (FlowRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyconditionLogic)]
        [TestCase(Propertyconditions)]
        [TestCase(Propertyconnector)]
        [TestCase(Propertylabel)]
        public void AUT_FlowRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldconditionLogicField)]
        [TestCase(FieldconditionsField)]
        [TestCase(FieldconnectorField)]
        [TestCase(FieldlabelField)]
        public void AUT_FlowRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowRuleInstanceFixture, 
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
        ///     Class (<see cref="FlowRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowRule_Is_Instance_Present_Test()
        {
            // Assert
            _flowRuleInstanceType.ShouldNotBeNull();
            _flowRuleInstance.ShouldNotBeNull();
            _flowRuleInstanceFixture.ShouldNotBeNull();
            _flowRuleInstance.ShouldBeAssignableTo<FlowRule>();
            _flowRuleInstanceFixture.ShouldBeAssignableTo<FlowRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowRuleInstanceType.ShouldNotBeNull();
            _flowRuleInstance.ShouldNotBeNull();
            _flowRuleInstanceFixture.ShouldNotBeNull();
            _flowRuleInstance.ShouldBeAssignableTo<FlowRule>();
            _flowRuleInstanceFixture.ShouldBeAssignableTo<FlowRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyconditionLogic)]
        [TestCaseGeneric(typeof(FlowCondition[]) , Propertyconditions)]
        [TestCaseGeneric(typeof(FlowConnector) , Propertyconnector)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        public void AUT_FlowRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowRule, T>(_flowRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRule) => Property (conditionLogic) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRule_Public_Class_conditionLogic_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyconditionLogic);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowRule) => Property (conditions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRule_conditions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyconditions);
            Action currentAction = () => propertyInfo.SetValue(_flowRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRule) => Property (conditions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRule_Public_Class_conditions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyconditions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowRule) => Property (connector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRule_connector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyconnector);
            Action currentAction = () => propertyInfo.SetValue(_flowRuleInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRule) => Property (connector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRule_Public_Class_connector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowRule) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRule_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}