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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.WorkflowOutboundMessage" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WorkflowOutboundMessageTest : AbstractBaseSetupTypedTest<WorkflowOutboundMessage>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WorkflowOutboundMessage) Initializer

        private const string PropertyapiVersion = "apiVersion";
        private const string Propertydescription = "description";
        private const string PropertyendpointUrl = "endpointUrl";
        private const string Propertyfields = "fields";
        private const string PropertyincludeSessionId = "includeSessionId";
        private const string PropertyintegrationUser = "integrationUser";
        private const string Propertyname = "name";
        private const string PropertyuseDeadLetterQueue = "useDeadLetterQueue";
        private const string PropertyuseDeadLetterQueueSpecified = "useDeadLetterQueueSpecified";
        private const string FieldapiVersionField = "apiVersionField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldendpointUrlField = "endpointUrlField";
        private const string FieldfieldsField = "fieldsField";
        private const string FieldincludeSessionIdField = "includeSessionIdField";
        private const string FieldintegrationUserField = "integrationUserField";
        private const string FieldnameField = "nameField";
        private const string FieldprotectedField = "protectedField";
        private const string FielduseDeadLetterQueueField = "useDeadLetterQueueField";
        private const string FielduseDeadLetterQueueFieldSpecified = "useDeadLetterQueueFieldSpecified";
        private Type _workflowOutboundMessageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WorkflowOutboundMessage _workflowOutboundMessageInstance;
        private WorkflowOutboundMessage _workflowOutboundMessageInstanceFixture;

        #region General Initializer : Class (WorkflowOutboundMessage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WorkflowOutboundMessage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _workflowOutboundMessageInstanceType = typeof(WorkflowOutboundMessage);
            _workflowOutboundMessageInstanceFixture = Create(true);
            _workflowOutboundMessageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WorkflowOutboundMessage)

        #region General Initializer : Class (WorkflowOutboundMessage) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowOutboundMessage" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyapiVersion)]
        [TestCase(Propertydescription)]
        [TestCase(PropertyendpointUrl)]
        [TestCase(Propertyfields)]
        [TestCase(PropertyincludeSessionId)]
        [TestCase(PropertyintegrationUser)]
        [TestCase(Propertyname)]
        [TestCase(PropertyuseDeadLetterQueue)]
        [TestCase(PropertyuseDeadLetterQueueSpecified)]
        public void AUT_WorkflowOutboundMessage_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_workflowOutboundMessageInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WorkflowOutboundMessage) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WorkflowOutboundMessage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapiVersionField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldendpointUrlField)]
        [TestCase(FieldfieldsField)]
        [TestCase(FieldincludeSessionIdField)]
        [TestCase(FieldintegrationUserField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldprotectedField)]
        [TestCase(FielduseDeadLetterQueueField)]
        [TestCase(FielduseDeadLetterQueueFieldSpecified)]
        public void AUT_WorkflowOutboundMessage_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_workflowOutboundMessageInstanceFixture, 
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
        ///     Class (<see cref="WorkflowOutboundMessage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WorkflowOutboundMessage_Is_Instance_Present_Test()
        {
            // Assert
            _workflowOutboundMessageInstanceType.ShouldNotBeNull();
            _workflowOutboundMessageInstance.ShouldNotBeNull();
            _workflowOutboundMessageInstanceFixture.ShouldNotBeNull();
            _workflowOutboundMessageInstance.ShouldBeAssignableTo<WorkflowOutboundMessage>();
            _workflowOutboundMessageInstanceFixture.ShouldBeAssignableTo<WorkflowOutboundMessage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WorkflowOutboundMessage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WorkflowOutboundMessage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WorkflowOutboundMessage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _workflowOutboundMessageInstanceType.ShouldNotBeNull();
            _workflowOutboundMessageInstance.ShouldNotBeNull();
            _workflowOutboundMessageInstanceFixture.ShouldNotBeNull();
            _workflowOutboundMessageInstance.ShouldBeAssignableTo<WorkflowOutboundMessage>();
            _workflowOutboundMessageInstanceFixture.ShouldBeAssignableTo<WorkflowOutboundMessage>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WorkflowOutboundMessage) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(double) , PropertyapiVersion)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , PropertyendpointUrl)]
        [TestCaseGeneric(typeof(string[]) , Propertyfields)]
        [TestCaseGeneric(typeof(bool) , PropertyincludeSessionId)]
        [TestCaseGeneric(typeof(string) , PropertyintegrationUser)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(bool) , PropertyuseDeadLetterQueue)]
        [TestCaseGeneric(typeof(bool) , PropertyuseDeadLetterQueueSpecified)]
        public void AUT_WorkflowOutboundMessage_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WorkflowOutboundMessage, T>(_workflowOutboundMessageInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (WorkflowOutboundMessage) => Property (apiVersion) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowOutboundMessage_Public_Class_apiVersion_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyapiVersion);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowOutboundMessage) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowOutboundMessage_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowOutboundMessage) => Property (endpointUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowOutboundMessage_Public_Class_endpointUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyendpointUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowOutboundMessage) => Property (fields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowOutboundMessage_fields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfields);
            Action currentAction = () => propertyInfo.SetValue(_workflowOutboundMessageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowOutboundMessage) => Property (fields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowOutboundMessage_Public_Class_fields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowOutboundMessage) => Property (includeSessionId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowOutboundMessage_Public_Class_includeSessionId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyincludeSessionId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowOutboundMessage) => Property (integrationUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowOutboundMessage_Public_Class_integrationUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyintegrationUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowOutboundMessage) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowOutboundMessage_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowOutboundMessage) => Property (useDeadLetterQueue) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowOutboundMessage_Public_Class_useDeadLetterQueue_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseDeadLetterQueue);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WorkflowOutboundMessage) => Property (useDeadLetterQueueSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WorkflowOutboundMessage_Public_Class_useDeadLetterQueueSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseDeadLetterQueueSpecified);

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