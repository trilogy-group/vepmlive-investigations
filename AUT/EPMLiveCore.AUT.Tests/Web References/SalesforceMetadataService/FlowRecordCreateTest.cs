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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowRecordCreate" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowRecordCreateTest : AbstractBaseSetupTypedTest<FlowRecordCreate>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowRecordCreate) Initializer

        private const string PropertyassignRecordIdToReference = "assignRecordIdToReference";
        private const string Propertyconnector = "connector";
        private const string PropertyfaultConnector = "faultConnector";
        private const string PropertyinputAssignments = "inputAssignments";
        private const string FieldassignRecordIdToReferenceField = "assignRecordIdToReferenceField";
        private const string FieldconnectorField = "connectorField";
        private const string FieldfaultConnectorField = "faultConnectorField";
        private const string FieldinputAssignmentsField = "inputAssignmentsField";
        private const string FieldobjectField = "objectField";
        private Type _flowRecordCreateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowRecordCreate _flowRecordCreateInstance;
        private FlowRecordCreate _flowRecordCreateInstanceFixture;

        #region General Initializer : Class (FlowRecordCreate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowRecordCreate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowRecordCreateInstanceType = typeof(FlowRecordCreate);
            _flowRecordCreateInstanceFixture = Create(true);
            _flowRecordCreateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowRecordCreate)

        #region General Initializer : Class (FlowRecordCreate) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowRecordCreate" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyassignRecordIdToReference)]
        [TestCase(Propertyconnector)]
        [TestCase(PropertyfaultConnector)]
        [TestCase(PropertyinputAssignments)]
        public void AUT_FlowRecordCreate_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowRecordCreateInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowRecordCreate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowRecordCreate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldassignRecordIdToReferenceField)]
        [TestCase(FieldconnectorField)]
        [TestCase(FieldfaultConnectorField)]
        [TestCase(FieldinputAssignmentsField)]
        [TestCase(FieldobjectField)]
        public void AUT_FlowRecordCreate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowRecordCreateInstanceFixture, 
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
        ///     Class (<see cref="FlowRecordCreate" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowRecordCreate_Is_Instance_Present_Test()
        {
            // Assert
            _flowRecordCreateInstanceType.ShouldNotBeNull();
            _flowRecordCreateInstance.ShouldNotBeNull();
            _flowRecordCreateInstanceFixture.ShouldNotBeNull();
            _flowRecordCreateInstance.ShouldBeAssignableTo<FlowRecordCreate>();
            _flowRecordCreateInstanceFixture.ShouldBeAssignableTo<FlowRecordCreate>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowRecordCreate) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowRecordCreate_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowRecordCreate instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowRecordCreateInstanceType.ShouldNotBeNull();
            _flowRecordCreateInstance.ShouldNotBeNull();
            _flowRecordCreateInstanceFixture.ShouldNotBeNull();
            _flowRecordCreateInstance.ShouldBeAssignableTo<FlowRecordCreate>();
            _flowRecordCreateInstanceFixture.ShouldBeAssignableTo<FlowRecordCreate>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowRecordCreate) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyassignRecordIdToReference)]
        [TestCaseGeneric(typeof(FlowConnector) , Propertyconnector)]
        [TestCaseGeneric(typeof(FlowConnector) , PropertyfaultConnector)]
        [TestCaseGeneric(typeof(FlowInputFieldAssignment[]) , PropertyinputAssignments)]
        public void AUT_FlowRecordCreate_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowRecordCreate, T>(_flowRecordCreateInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (FlowRecordCreate) => Property (assignRecordIdToReference) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordCreate_Public_Class_assignRecordIdToReference_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignRecordIdToReference);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordCreate) => Property (connector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordCreate_connector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyconnector);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordCreateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordCreate) => Property (connector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordCreate_Public_Class_connector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowRecordCreate) => Property (faultConnector) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordCreate_faultConnector_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyfaultConnector);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordCreateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordCreate) => Property (faultConnector) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordCreate_Public_Class_faultConnector_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowRecordCreate) => Property (inputAssignments) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordCreate_inputAssignments_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyinputAssignments);
            Action currentAction = () => propertyInfo.SetValue(_flowRecordCreateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (FlowRecordCreate) => Property (inputAssignments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowRecordCreate_Public_Class_inputAssignments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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