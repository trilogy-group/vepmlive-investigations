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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowRecordUpdate" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowRecordUpdateTest : AbstractBaseSetupTypedTest<FlowRecordUpdate>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowRecordUpdate) Initializer

        private const string Propertyconnector = "connector";
        private const string PropertyfaultConnector = "faultConnector";
        private const string Propertyfilters = "filters";
        private const string PropertyinputAssignments = "inputAssignments";
        private const string FieldconnectorField = "connectorField";
        private const string FieldfaultConnectorField = "faultConnectorField";
        private const string FieldfiltersField = "filtersField";
        private const string FieldinputAssignmentsField = "inputAssignmentsField";
        private const string FieldobjectField = "objectField";
        private Type _flowRecordUpdateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowRecordUpdate _flowRecordUpdateInstance;
        private FlowRecordUpdate _flowRecordUpdateInstanceFixture;

        #region General Initializer : Class (FlowRecordUpdate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowRecordUpdate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowRecordUpdateInstanceType = typeof(FlowRecordUpdate);
            _flowRecordUpdateInstanceFixture = Create(true);
            _flowRecordUpdateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowRecordUpdate)

        #region General Initializer : Class (FlowRecordUpdate) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowRecordUpdate" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyconnector)]
        [TestCase(PropertyfaultConnector)]
        [TestCase(Propertyfilters)]
        [TestCase(PropertyinputAssignments)]
        public void AUT_FlowRecordUpdate_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowRecordUpdateInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowRecordUpdate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowRecordUpdate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldconnectorField)]
        [TestCase(FieldfaultConnectorField)]
        [TestCase(FieldfiltersField)]
        [TestCase(FieldinputAssignmentsField)]
        [TestCase(FieldobjectField)]
        public void AUT_FlowRecordUpdate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowRecordUpdateInstanceFixture, 
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
        ///     Class (<see cref="FlowRecordUpdate" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowRecordUpdate_Is_Instance_Present_Test()
        {
            // Assert
            _flowRecordUpdateInstanceType.ShouldNotBeNull();
            _flowRecordUpdateInstance.ShouldNotBeNull();
            _flowRecordUpdateInstanceFixture.ShouldNotBeNull();
            _flowRecordUpdateInstance.ShouldBeAssignableTo<FlowRecordUpdate>();
            _flowRecordUpdateInstanceFixture.ShouldBeAssignableTo<FlowRecordUpdate>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowRecordUpdate) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowRecordUpdate_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowRecordUpdate instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowRecordUpdateInstanceType.ShouldNotBeNull();
            _flowRecordUpdateInstance.ShouldNotBeNull();
            _flowRecordUpdateInstanceFixture.ShouldNotBeNull();
            _flowRecordUpdateInstance.ShouldBeAssignableTo<FlowRecordUpdate>();
            _flowRecordUpdateInstanceFixture.ShouldBeAssignableTo<FlowRecordUpdate>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowRecordUpdate) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(FlowConnector) , Propertyconnector)]
        [TestCaseGeneric(typeof(FlowConnector) , PropertyfaultConnector)]
        [TestCaseGeneric(typeof(FlowRecordFilter[]) , Propertyfilters)]
        [TestCaseGeneric(typeof(FlowInputFieldAssignment[]) , PropertyinputAssignments)]
        public void AUT_FlowRecordUpdate_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowRecordUpdate, T>(_flowRecordUpdateInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (FlowRecordUpdate) => Property (connector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordUpdate_connector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyconnector);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordUpdateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordUpdate) => Property (connector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordUpdate_Public_Class_connector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowRecordUpdate) => Property (faultConnector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordUpdate_faultConnector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyfaultConnector);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordUpdateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordUpdate) => Property (faultConnector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordUpdate_Public_Class_faultConnector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowRecordUpdate) => Property (filters) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordUpdate_filters_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfilters);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordUpdateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordUpdate) => Property (filters) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordUpdate_Public_Class_filters_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowRecordUpdate) => Property (inputAssignments) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordUpdate_inputAssignments_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyinputAssignments);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordUpdateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordUpdate) => Property (inputAssignments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordUpdate_Public_Class_inputAssignments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}