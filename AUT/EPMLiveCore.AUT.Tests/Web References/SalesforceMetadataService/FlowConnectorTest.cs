using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowConnector" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowConnectorTest : AbstractBaseSetupTypedTest<FlowConnector>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowConnector) Initializer

        private const string PropertytargetReference = "targetReference";
        private const string FieldtargetReferenceField = "targetReferenceField";
        private Type _flowConnectorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowConnector _flowConnectorInstance;
        private FlowConnector _flowConnectorInstanceFixture;

        #region General Initializer : Class (FlowConnector) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowConnector" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowConnectorInstanceType = typeof(FlowConnector);
            _flowConnectorInstanceFixture = Create(true);
            _flowConnectorInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowConnector)

        #region General Initializer : Class (FlowConnector) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowConnector" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertytargetReference)]
        public void AUT_FlowConnector_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowConnectorInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowConnector) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowConnector" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldtargetReferenceField)]
        public void AUT_FlowConnector_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowConnectorInstanceFixture, 
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
        ///     Class (<see cref="FlowConnector" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowConnector_Is_Instance_Present_Test()
        {
            // Assert
            _flowConnectorInstanceType.ShouldNotBeNull();
            _flowConnectorInstance.ShouldNotBeNull();
            _flowConnectorInstanceFixture.ShouldNotBeNull();
            _flowConnectorInstance.ShouldBeAssignableTo<FlowConnector>();
            _flowConnectorInstanceFixture.ShouldBeAssignableTo<FlowConnector>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowConnector) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowConnector_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowConnector instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowConnectorInstanceType.ShouldNotBeNull();
            _flowConnectorInstance.ShouldNotBeNull();
            _flowConnectorInstanceFixture.ShouldNotBeNull();
            _flowConnectorInstance.ShouldBeAssignableTo<FlowConnector>();
            _flowConnectorInstanceFixture.ShouldBeAssignableTo<FlowConnector>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowConnector) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertytargetReference)]
        public void AUT_FlowConnector_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowConnector, T>(_flowConnectorInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowConnector) => Property (targetReference) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowConnector_Public_Class_targetReference_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytargetReference);

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