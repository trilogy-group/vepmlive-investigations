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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowStep" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowStepTest : AbstractBaseSetupTypedTest<FlowStep>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowStep) Initializer

        private const string Propertyconnectors = "connectors";
        private const string FieldconnectorsField = "connectorsField";
        private Type _flowStepInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowStep _flowStepInstance;
        private FlowStep _flowStepInstanceFixture;

        #region General Initializer : Class (FlowStep) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowStep" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowStepInstanceType = typeof(FlowStep);
            _flowStepInstanceFixture = Create(true);
            _flowStepInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowStep)

        #region General Initializer : Class (FlowStep) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowStep" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyconnectors)]
        public void AUT_FlowStep_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowStepInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowStep) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowStep" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldconnectorsField)]
        public void AUT_FlowStep_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowStepInstanceFixture, 
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
        ///     Class (<see cref="FlowStep" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowStep_Is_Instance_Present_Test()
        {
            // Assert
            _flowStepInstanceType.ShouldNotBeNull();
            _flowStepInstance.ShouldNotBeNull();
            _flowStepInstanceFixture.ShouldNotBeNull();
            _flowStepInstance.ShouldBeAssignableTo<FlowStep>();
            _flowStepInstanceFixture.ShouldBeAssignableTo<FlowStep>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowStep) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowStep_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowStep instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowStepInstanceType.ShouldNotBeNull();
            _flowStepInstance.ShouldNotBeNull();
            _flowStepInstanceFixture.ShouldNotBeNull();
            _flowStepInstance.ShouldBeAssignableTo<FlowStep>();
            _flowStepInstanceFixture.ShouldBeAssignableTo<FlowStep>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowStep) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(FlowConnector[]) , Propertyconnectors)]
        public void AUT_FlowStep_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowStep, T>(_flowStepInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowStep) => Property (connectors) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowStep_connectors_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyconnectors);
            Action currentAction = () => propertyInfo.SetValue(_flowStepInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowStep) => Property (connectors) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowStep_Public_Class_connectors_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyconnectors);

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