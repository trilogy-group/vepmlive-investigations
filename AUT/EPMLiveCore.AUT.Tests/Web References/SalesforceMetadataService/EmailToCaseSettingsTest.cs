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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.EmailToCaseSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EmailToCaseSettingsTest : AbstractBaseSetupTypedTest<EmailToCaseSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EmailToCaseSettings) Initializer

        private const string PropertyenableEmailToCase = "enableEmailToCase";
        private const string PropertyenableEmailToCaseSpecified = "enableEmailToCaseSpecified";
        private const string PropertyenableHtmlEmail = "enableHtmlEmail";
        private const string PropertyenableHtmlEmailSpecified = "enableHtmlEmailSpecified";
        private const string PropertyenableOnDemandEmailToCase = "enableOnDemandEmailToCase";
        private const string PropertyenableOnDemandEmailToCaseSpecified = "enableOnDemandEmailToCaseSpecified";
        private const string PropertyenableThreadIDInBody = "enableThreadIDInBody";
        private const string PropertyenableThreadIDInBodySpecified = "enableThreadIDInBodySpecified";
        private const string PropertyenableThreadIDInSubject = "enableThreadIDInSubject";
        private const string PropertyenableThreadIDInSubjectSpecified = "enableThreadIDInSubjectSpecified";
        private const string PropertynotifyOwnerOnNewCaseEmail = "notifyOwnerOnNewCaseEmail";
        private const string PropertynotifyOwnerOnNewCaseEmailSpecified = "notifyOwnerOnNewCaseEmailSpecified";
        private const string PropertyoverEmailLimitAction = "overEmailLimitAction";
        private const string PropertyoverEmailLimitActionSpecified = "overEmailLimitActionSpecified";
        private const string PropertyroutingAddresses = "routingAddresses";
        private const string PropertyunauthorizedSenderAction = "unauthorizedSenderAction";
        private const string PropertyunauthorizedSenderActionSpecified = "unauthorizedSenderActionSpecified";
        private const string FieldenableEmailToCaseField = "enableEmailToCaseField";
        private const string FieldenableEmailToCaseFieldSpecified = "enableEmailToCaseFieldSpecified";
        private const string FieldenableHtmlEmailField = "enableHtmlEmailField";
        private const string FieldenableHtmlEmailFieldSpecified = "enableHtmlEmailFieldSpecified";
        private const string FieldenableOnDemandEmailToCaseField = "enableOnDemandEmailToCaseField";
        private const string FieldenableOnDemandEmailToCaseFieldSpecified = "enableOnDemandEmailToCaseFieldSpecified";
        private const string FieldenableThreadIDInBodyField = "enableThreadIDInBodyField";
        private const string FieldenableThreadIDInBodyFieldSpecified = "enableThreadIDInBodyFieldSpecified";
        private const string FieldenableThreadIDInSubjectField = "enableThreadIDInSubjectField";
        private const string FieldenableThreadIDInSubjectFieldSpecified = "enableThreadIDInSubjectFieldSpecified";
        private const string FieldnotifyOwnerOnNewCaseEmailField = "notifyOwnerOnNewCaseEmailField";
        private const string FieldnotifyOwnerOnNewCaseEmailFieldSpecified = "notifyOwnerOnNewCaseEmailFieldSpecified";
        private const string FieldoverEmailLimitActionField = "overEmailLimitActionField";
        private const string FieldoverEmailLimitActionFieldSpecified = "overEmailLimitActionFieldSpecified";
        private const string FieldroutingAddressesField = "routingAddressesField";
        private const string FieldunauthorizedSenderActionField = "unauthorizedSenderActionField";
        private const string FieldunauthorizedSenderActionFieldSpecified = "unauthorizedSenderActionFieldSpecified";
        private Type _emailToCaseSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EmailToCaseSettings _emailToCaseSettingsInstance;
        private EmailToCaseSettings _emailToCaseSettingsInstanceFixture;

        #region General Initializer : Class (EmailToCaseSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EmailToCaseSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _emailToCaseSettingsInstanceType = typeof(EmailToCaseSettings);
            _emailToCaseSettingsInstanceFixture = Create(true);
            _emailToCaseSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EmailToCaseSettings)

        #region General Initializer : Class (EmailToCaseSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EmailToCaseSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyenableEmailToCase)]
        [TestCase(PropertyenableEmailToCaseSpecified)]
        [TestCase(PropertyenableHtmlEmail)]
        [TestCase(PropertyenableHtmlEmailSpecified)]
        [TestCase(PropertyenableOnDemandEmailToCase)]
        [TestCase(PropertyenableOnDemandEmailToCaseSpecified)]
        [TestCase(PropertyenableThreadIDInBody)]
        [TestCase(PropertyenableThreadIDInBodySpecified)]
        [TestCase(PropertyenableThreadIDInSubject)]
        [TestCase(PropertyenableThreadIDInSubjectSpecified)]
        [TestCase(PropertynotifyOwnerOnNewCaseEmail)]
        [TestCase(PropertynotifyOwnerOnNewCaseEmailSpecified)]
        [TestCase(PropertyoverEmailLimitAction)]
        [TestCase(PropertyoverEmailLimitActionSpecified)]
        [TestCase(PropertyroutingAddresses)]
        [TestCase(PropertyunauthorizedSenderAction)]
        [TestCase(PropertyunauthorizedSenderActionSpecified)]
        public void AUT_EmailToCaseSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_emailToCaseSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EmailToCaseSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EmailToCaseSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldenableEmailToCaseField)]
        [TestCase(FieldenableEmailToCaseFieldSpecified)]
        [TestCase(FieldenableHtmlEmailField)]
        [TestCase(FieldenableHtmlEmailFieldSpecified)]
        [TestCase(FieldenableOnDemandEmailToCaseField)]
        [TestCase(FieldenableOnDemandEmailToCaseFieldSpecified)]
        [TestCase(FieldenableThreadIDInBodyField)]
        [TestCase(FieldenableThreadIDInBodyFieldSpecified)]
        [TestCase(FieldenableThreadIDInSubjectField)]
        [TestCase(FieldenableThreadIDInSubjectFieldSpecified)]
        [TestCase(FieldnotifyOwnerOnNewCaseEmailField)]
        [TestCase(FieldnotifyOwnerOnNewCaseEmailFieldSpecified)]
        [TestCase(FieldoverEmailLimitActionField)]
        [TestCase(FieldoverEmailLimitActionFieldSpecified)]
        [TestCase(FieldroutingAddressesField)]
        [TestCase(FieldunauthorizedSenderActionField)]
        [TestCase(FieldunauthorizedSenderActionFieldSpecified)]
        public void AUT_EmailToCaseSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_emailToCaseSettingsInstanceFixture, 
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
        ///     Class (<see cref="EmailToCaseSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EmailToCaseSettings_Is_Instance_Present_Test()
        {
            // Assert
            _emailToCaseSettingsInstanceType.ShouldNotBeNull();
            _emailToCaseSettingsInstance.ShouldNotBeNull();
            _emailToCaseSettingsInstanceFixture.ShouldNotBeNull();
            _emailToCaseSettingsInstance.ShouldBeAssignableTo<EmailToCaseSettings>();
            _emailToCaseSettingsInstanceFixture.ShouldBeAssignableTo<EmailToCaseSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EmailToCaseSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EmailToCaseSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EmailToCaseSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _emailToCaseSettingsInstanceType.ShouldNotBeNull();
            _emailToCaseSettingsInstance.ShouldNotBeNull();
            _emailToCaseSettingsInstanceFixture.ShouldNotBeNull();
            _emailToCaseSettingsInstance.ShouldBeAssignableTo<EmailToCaseSettings>();
            _emailToCaseSettingsInstanceFixture.ShouldBeAssignableTo<EmailToCaseSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EmailToCaseSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyenableEmailToCase)]
        [TestCaseGeneric(typeof(bool) , PropertyenableEmailToCaseSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableHtmlEmail)]
        [TestCaseGeneric(typeof(bool) , PropertyenableHtmlEmailSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableOnDemandEmailToCase)]
        [TestCaseGeneric(typeof(bool) , PropertyenableOnDemandEmailToCaseSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableThreadIDInBody)]
        [TestCaseGeneric(typeof(bool) , PropertyenableThreadIDInBodySpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableThreadIDInSubject)]
        [TestCaseGeneric(typeof(bool) , PropertyenableThreadIDInSubjectSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyOwnerOnNewCaseEmail)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyOwnerOnNewCaseEmailSpecified)]
        [TestCaseGeneric(typeof(EmailToCaseOnFailureActionType) , PropertyoverEmailLimitAction)]
        [TestCaseGeneric(typeof(bool) , PropertyoverEmailLimitActionSpecified)]
        [TestCaseGeneric(typeof(EmailToCaseRoutingAddress[]) , PropertyroutingAddresses)]
        [TestCaseGeneric(typeof(EmailToCaseOnFailureActionType) , PropertyunauthorizedSenderAction)]
        [TestCaseGeneric(typeof(bool) , PropertyunauthorizedSenderActionSpecified)]
        public void AUT_EmailToCaseSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EmailToCaseSettings, T>(_emailToCaseSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (enableEmailToCase) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_enableEmailToCase_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableEmailToCase);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (enableEmailToCaseSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_enableEmailToCaseSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableEmailToCaseSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (enableHtmlEmail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_enableHtmlEmail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableHtmlEmail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (enableHtmlEmailSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_enableHtmlEmailSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableHtmlEmailSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (enableOnDemandEmailToCase) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_enableOnDemandEmailToCase_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableOnDemandEmailToCase);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (enableOnDemandEmailToCaseSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_enableOnDemandEmailToCaseSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableOnDemandEmailToCaseSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (enableThreadIDInBody) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_enableThreadIDInBody_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableThreadIDInBody);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (enableThreadIDInBodySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_enableThreadIDInBodySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableThreadIDInBodySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (enableThreadIDInSubject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_enableThreadIDInSubject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableThreadIDInSubject);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (enableThreadIDInSubjectSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_enableThreadIDInSubjectSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableThreadIDInSubjectSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (notifyOwnerOnNewCaseEmail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_notifyOwnerOnNewCaseEmail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyOwnerOnNewCaseEmail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (notifyOwnerOnNewCaseEmailSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_notifyOwnerOnNewCaseEmailSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyOwnerOnNewCaseEmailSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (overEmailLimitAction) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_overEmailLimitAction_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyoverEmailLimitAction);
            Action currentAction = () => propertyInfo.SetValue(_emailToCaseSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (overEmailLimitAction) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_overEmailLimitAction_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyoverEmailLimitAction);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (overEmailLimitActionSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_overEmailLimitActionSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyoverEmailLimitActionSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (routingAddresses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_routingAddresses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyroutingAddresses);
            Action currentAction = () => propertyInfo.SetValue(_emailToCaseSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (routingAddresses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_routingAddresses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyroutingAddresses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (unauthorizedSenderAction) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_unauthorizedSenderAction_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyunauthorizedSenderAction);
            Action currentAction = () => propertyInfo.SetValue(_emailToCaseSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (unauthorizedSenderAction) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_unauthorizedSenderAction_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyunauthorizedSenderAction);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailToCaseSettings) => Property (unauthorizedSenderActionSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailToCaseSettings_Public_Class_unauthorizedSenderActionSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyunauthorizedSenderActionSpecified);

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