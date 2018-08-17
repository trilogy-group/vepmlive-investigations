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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.EmailToCaseRoutingAddress" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EmailToCaseRoutingAddressTest : AbstractBaseSetupTypedTest<EmailToCaseRoutingAddress>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EmailToCaseRoutingAddress) Initializer

        private const string PropertyaddressType = "addressType";
        private const string PropertyaddressTypeSpecified = "addressTypeSpecified";
        private const string PropertyauthorizedSenders = "authorizedSenders";
        private const string PropertycaseOrigin = "caseOrigin";
        private const string PropertycaseOwner = "caseOwner";
        private const string PropertycaseOwnerType = "caseOwnerType";
        private const string PropertycasePriority = "casePriority";
        private const string PropertycreateTask = "createTask";
        private const string PropertycreateTaskSpecified = "createTaskSpecified";
        private const string PropertyemailAddress = "emailAddress";
        private const string PropertyroutingName = "routingName";
        private const string PropertysaveEmailHeaders = "saveEmailHeaders";
        private const string PropertysaveEmailHeadersSpecified = "saveEmailHeadersSpecified";
        private const string PropertytaskStatus = "taskStatus";
        private const string FieldaddressTypeField = "addressTypeField";
        private const string FieldaddressTypeFieldSpecified = "addressTypeFieldSpecified";
        private const string FieldauthorizedSendersField = "authorizedSendersField";
        private const string FieldcaseOriginField = "caseOriginField";
        private const string FieldcaseOwnerField = "caseOwnerField";
        private const string FieldcaseOwnerTypeField = "caseOwnerTypeField";
        private const string FieldcasePriorityField = "casePriorityField";
        private const string FieldcreateTaskField = "createTaskField";
        private const string FieldcreateTaskFieldSpecified = "createTaskFieldSpecified";
        private const string FieldemailAddressField = "emailAddressField";
        private const string FieldroutingNameField = "routingNameField";
        private const string FieldsaveEmailHeadersField = "saveEmailHeadersField";
        private const string FieldsaveEmailHeadersFieldSpecified = "saveEmailHeadersFieldSpecified";
        private const string FieldtaskStatusField = "taskStatusField";
        private Type _emailToCaseRoutingAddressInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EmailToCaseRoutingAddress _emailToCaseRoutingAddressInstance;
        private EmailToCaseRoutingAddress _emailToCaseRoutingAddressInstanceFixture;

        #region General Initializer : Class (EmailToCaseRoutingAddress) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EmailToCaseRoutingAddress" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _emailToCaseRoutingAddressInstanceType = typeof(EmailToCaseRoutingAddress);
            _emailToCaseRoutingAddressInstanceFixture = Create(true);
            _emailToCaseRoutingAddressInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EmailToCaseRoutingAddress)

        #region General Initializer : Class (EmailToCaseRoutingAddress) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EmailToCaseRoutingAddress" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyaddressType)]
        [TestCase(PropertyaddressTypeSpecified)]
        [TestCase(PropertyauthorizedSenders)]
        [TestCase(PropertycaseOrigin)]
        [TestCase(PropertycaseOwner)]
        [TestCase(PropertycaseOwnerType)]
        [TestCase(PropertycasePriority)]
        [TestCase(PropertycreateTask)]
        [TestCase(PropertycreateTaskSpecified)]
        [TestCase(PropertyemailAddress)]
        [TestCase(PropertyroutingName)]
        [TestCase(PropertysaveEmailHeaders)]
        [TestCase(PropertysaveEmailHeadersSpecified)]
        [TestCase(PropertytaskStatus)]
        public void AUT_EmailToCaseRoutingAddress_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_emailToCaseRoutingAddressInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EmailToCaseRoutingAddress) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EmailToCaseRoutingAddress" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaddressTypeField)]
        [TestCase(FieldaddressTypeFieldSpecified)]
        [TestCase(FieldauthorizedSendersField)]
        [TestCase(FieldcaseOriginField)]
        [TestCase(FieldcaseOwnerField)]
        [TestCase(FieldcaseOwnerTypeField)]
        [TestCase(FieldcasePriorityField)]
        [TestCase(FieldcreateTaskField)]
        [TestCase(FieldcreateTaskFieldSpecified)]
        [TestCase(FieldemailAddressField)]
        [TestCase(FieldroutingNameField)]
        [TestCase(FieldsaveEmailHeadersField)]
        [TestCase(FieldsaveEmailHeadersFieldSpecified)]
        [TestCase(FieldtaskStatusField)]
        public void AUT_EmailToCaseRoutingAddress_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_emailToCaseRoutingAddressInstanceFixture, 
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
        ///     Class (<see cref="EmailToCaseRoutingAddress" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EmailToCaseRoutingAddress_Is_Instance_Present_Test()
        {
            // Assert
            _emailToCaseRoutingAddressInstanceType.ShouldNotBeNull();
            _emailToCaseRoutingAddressInstance.ShouldNotBeNull();
            _emailToCaseRoutingAddressInstanceFixture.ShouldNotBeNull();
            _emailToCaseRoutingAddressInstance.ShouldBeAssignableTo<EmailToCaseRoutingAddress>();
            _emailToCaseRoutingAddressInstanceFixture.ShouldBeAssignableTo<EmailToCaseRoutingAddress>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EmailToCaseRoutingAddress) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EmailToCaseRoutingAddress_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EmailToCaseRoutingAddress instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _emailToCaseRoutingAddressInstanceType.ShouldNotBeNull();
            _emailToCaseRoutingAddressInstance.ShouldNotBeNull();
            _emailToCaseRoutingAddressInstanceFixture.ShouldNotBeNull();
            _emailToCaseRoutingAddressInstance.ShouldBeAssignableTo<EmailToCaseRoutingAddress>();
            _emailToCaseRoutingAddressInstanceFixture.ShouldBeAssignableTo<EmailToCaseRoutingAddress>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(EmailToCaseRoutingAddressType) , PropertyaddressType)]
        [TestCaseGeneric(typeof(bool) , PropertyaddressTypeSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyauthorizedSenders)]
        [TestCaseGeneric(typeof(string) , PropertycaseOrigin)]
        [TestCaseGeneric(typeof(string) , PropertycaseOwner)]
        [TestCaseGeneric(typeof(string) , PropertycaseOwnerType)]
        [TestCaseGeneric(typeof(string) , PropertycasePriority)]
        [TestCaseGeneric(typeof(bool) , PropertycreateTask)]
        [TestCaseGeneric(typeof(bool) , PropertycreateTaskSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyemailAddress)]
        [TestCaseGeneric(typeof(string) , PropertyroutingName)]
        [TestCaseGeneric(typeof(bool) , PropertysaveEmailHeaders)]
        [TestCaseGeneric(typeof(bool) , PropertysaveEmailHeadersSpecified)]
        [TestCaseGeneric(typeof(string) , PropertytaskStatus)]
        public void AUT_EmailToCaseRoutingAddress_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EmailToCaseRoutingAddress, T>(_emailToCaseRoutingAddressInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (addressType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_addressType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyaddressType);
            Action currentAction = () => propertyInfo.SetValue(_emailToCaseRoutingAddressInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (addressType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_addressType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaddressType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (addressTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_addressTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaddressTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (authorizedSenders) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_authorizedSenders_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyauthorizedSenders);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (caseOrigin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_caseOrigin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseOrigin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (caseOwner) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_caseOwner_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseOwner);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (caseOwnerType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_caseOwnerType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycaseOwnerType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (casePriority) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_casePriority_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycasePriority);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (createTask) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_createTask_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycreateTask);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (createTaskSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_createTaskSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycreateTaskSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (emailAddress) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_emailAddress_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailAddress);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (routingName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_routingName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyroutingName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (saveEmailHeaders) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_saveEmailHeaders_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysaveEmailHeaders);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (saveEmailHeadersSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_saveEmailHeadersSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysaveEmailHeadersSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseRoutingAddress) => Property (taskStatus) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseRoutingAddress_Public_Class_taskStatus_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytaskStatus);

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