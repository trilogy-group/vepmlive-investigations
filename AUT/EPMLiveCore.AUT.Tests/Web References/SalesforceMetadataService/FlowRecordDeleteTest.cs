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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowRecordDelete" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowRecordDeleteTest : AbstractBaseSetupTypedTest<FlowRecordDelete>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowRecordDelete) Initializer

        private const string Propertyconnector = "connector";
        private const string PropertyfaultConnector = "faultConnector";
        private const string Propertyfilters = "filters";
        private const string FieldconnectorField = "connectorField";
        private const string FieldfaultConnectorField = "faultConnectorField";
        private const string FieldfiltersField = "filtersField";
        private const string FieldobjectField = "objectField";
        private Type _flowRecordDeleteInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowRecordDelete _flowRecordDeleteInstance;
        private FlowRecordDelete _flowRecordDeleteInstanceFixture;

        #region General Initializer : Class (FlowRecordDelete) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowRecordDelete" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowRecordDeleteInstanceType = typeof(FlowRecordDelete);
            _flowRecordDeleteInstanceFixture = Create(true);
            _flowRecordDeleteInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowRecordDelete)

        #region General Initializer : Class (FlowRecordDelete) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowRecordDelete" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyconnector)]
        [TestCase(PropertyfaultConnector)]
        [TestCase(Propertyfilters)]
        public void AUT_FlowRecordDelete_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowRecordDeleteInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowRecordDelete) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowRecordDelete" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldconnectorField)]
        [TestCase(FieldfaultConnectorField)]
        [TestCase(FieldfiltersField)]
        [TestCase(FieldobjectField)]
        public void AUT_FlowRecordDelete_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowRecordDeleteInstanceFixture, 
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
        ///     Class (<see cref="FlowRecordDelete" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowRecordDelete_Is_Instance_Present_Test()
        {
            // Assert
            _flowRecordDeleteInstanceType.ShouldNotBeNull();
            _flowRecordDeleteInstance.ShouldNotBeNull();
            _flowRecordDeleteInstanceFixture.ShouldNotBeNull();
            _flowRecordDeleteInstance.ShouldBeAssignableTo<FlowRecordDelete>();
            _flowRecordDeleteInstanceFixture.ShouldBeAssignableTo<FlowRecordDelete>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowRecordDelete) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowRecordDelete_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowRecordDelete instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowRecordDeleteInstanceType.ShouldNotBeNull();
            _flowRecordDeleteInstance.ShouldNotBeNull();
            _flowRecordDeleteInstanceFixture.ShouldNotBeNull();
            _flowRecordDeleteInstance.ShouldBeAssignableTo<FlowRecordDelete>();
            _flowRecordDeleteInstanceFixture.ShouldBeAssignableTo<FlowRecordDelete>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowRecordDelete) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(FlowConnector) , Propertyconnector)]
        [TestCaseGeneric(typeof(FlowConnector) , PropertyfaultConnector)]
        [TestCaseGeneric(typeof(FlowRecordFilter[]) , Propertyfilters)]
        public void AUT_FlowRecordDelete_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowRecordDelete, T>(_flowRecordDeleteInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (FlowRecordDelete) => Property (connector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordDelete_connector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyconnector);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordDeleteInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordDelete) => Property (connector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordDelete_Public_Class_connector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowRecordDelete) => Property (faultConnector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordDelete_faultConnector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyfaultConnector);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordDeleteInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordDelete) => Property (faultConnector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordDelete_Public_Class_faultConnector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfaultConnector);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordDelete) => Property (filters) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordDelete_filters_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfilters);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordDeleteInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordDelete) => Property (filters) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordDelete_Public_Class_filters_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfilters);

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