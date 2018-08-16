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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowDecision" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowDecisionTest : AbstractBaseSetupTypedTest<FlowDecision>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowDecision) Initializer

        private const string PropertydefaultConnector = "defaultConnector";
        private const string PropertydefaultConnectorLabel = "defaultConnectorLabel";
        private const string Propertyrules = "rules";
        private const string FielddefaultConnectorField = "defaultConnectorField";
        private const string FielddefaultConnectorLabelField = "defaultConnectorLabelField";
        private const string FieldrulesField = "rulesField";
        private Type _flowDecisionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowDecision _flowDecisionInstance;
        private FlowDecision _flowDecisionInstanceFixture;

        #region General Initializer : Class (FlowDecision) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowDecision" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowDecisionInstanceType = typeof(FlowDecision);
            _flowDecisionInstanceFixture = Create(true);
            _flowDecisionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowDecision)

        #region General Initializer : Class (FlowDecision) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowDecision" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydefaultConnector)]
        [TestCase(PropertydefaultConnectorLabel)]
        [TestCase(Propertyrules)]
        public void AUT_FlowDecision_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowDecisionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowDecision) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowDecision" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddefaultConnectorField)]
        [TestCase(FielddefaultConnectorLabelField)]
        [TestCase(FieldrulesField)]
        public void AUT_FlowDecision_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowDecisionInstanceFixture, 
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
        ///     Class (<see cref="FlowDecision" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowDecision_Is_Instance_Present_Test()
        {
            // Assert
            _flowDecisionInstanceType.ShouldNotBeNull();
            _flowDecisionInstance.ShouldNotBeNull();
            _flowDecisionInstanceFixture.ShouldNotBeNull();
            _flowDecisionInstance.ShouldBeAssignableTo<FlowDecision>();
            _flowDecisionInstanceFixture.ShouldBeAssignableTo<FlowDecision>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowDecision) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowDecision_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowDecision instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowDecisionInstanceType.ShouldNotBeNull();
            _flowDecisionInstance.ShouldNotBeNull();
            _flowDecisionInstanceFixture.ShouldNotBeNull();
            _flowDecisionInstance.ShouldBeAssignableTo<FlowDecision>();
            _flowDecisionInstanceFixture.ShouldBeAssignableTo<FlowDecision>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowDecision) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(FlowConnector) , PropertydefaultConnector)]
        [TestCaseGeneric(typeof(string) , PropertydefaultConnectorLabel)]
        [TestCaseGeneric(typeof(FlowRule[]) , Propertyrules)]
        public void AUT_FlowDecision_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowDecision, T>(_flowDecisionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowDecision) => Property (defaultConnector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDecision_defaultConnector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydefaultConnector);
            Action currentAction = () => propertyInfo.SetValue(_flowDecisionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowDecision) => Property (defaultConnector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDecision_Public_Class_defaultConnector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultConnector);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowDecision) => Property (defaultConnectorLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDecision_Public_Class_defaultConnectorLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultConnectorLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowDecision) => Property (rules) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDecision_rules_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyrules);
            Action currentAction = () => propertyInfo.SetValue(_flowDecisionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowDecision) => Property (rules) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowDecision_Public_Class_rules_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyrules);

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