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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ChatterMobileSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ChatterMobileSettingsTest : AbstractBaseSetupTypedTest<ChatterMobileSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ChatterMobileSettings) Initializer

        private const string PropertyandroidAuthorized = "androidAuthorized";
        private const string PropertyandroidAuthorizedSpecified = "androidAuthorizedSpecified";
        private const string PropertyblackberryAuthorized = "blackberryAuthorized";
        private const string PropertyblackberryAuthorizedSpecified = "blackberryAuthorizedSpecified";
        private const string PropertyenableChatterMobile = "enableChatterMobile";
        private const string PropertyenableChatterMobileSpecified = "enableChatterMobileSpecified";
        private const string PropertyenablePushNotifications = "enablePushNotifications";
        private const string PropertyenablePushNotificationsSpecified = "enablePushNotificationsSpecified";
        private const string PropertyiPadAuthorized = "iPadAuthorized";
        private const string PropertyiPadAuthorizedSpecified = "iPadAuthorizedSpecified";
        private const string PropertyiPhoneAuthorized = "iPhoneAuthorized";
        private const string PropertyiPhoneAuthorizedSpecified = "iPhoneAuthorizedSpecified";
        private const string PropertysessionTimeout = "sessionTimeout";
        private const string PropertysessionTimeoutSpecified = "sessionTimeoutSpecified";
        private const string FieldandroidAuthorizedField = "androidAuthorizedField";
        private const string FieldandroidAuthorizedFieldSpecified = "androidAuthorizedFieldSpecified";
        private const string FieldblackberryAuthorizedField = "blackberryAuthorizedField";
        private const string FieldblackberryAuthorizedFieldSpecified = "blackberryAuthorizedFieldSpecified";
        private const string FieldenableChatterMobileField = "enableChatterMobileField";
        private const string FieldenableChatterMobileFieldSpecified = "enableChatterMobileFieldSpecified";
        private const string FieldenablePushNotificationsField = "enablePushNotificationsField";
        private const string FieldenablePushNotificationsFieldSpecified = "enablePushNotificationsFieldSpecified";
        private const string FieldiPadAuthorizedField = "iPadAuthorizedField";
        private const string FieldiPadAuthorizedFieldSpecified = "iPadAuthorizedFieldSpecified";
        private const string FieldiPhoneAuthorizedField = "iPhoneAuthorizedField";
        private const string FieldiPhoneAuthorizedFieldSpecified = "iPhoneAuthorizedFieldSpecified";
        private const string FieldsessionTimeoutField = "sessionTimeoutField";
        private const string FieldsessionTimeoutFieldSpecified = "sessionTimeoutFieldSpecified";
        private Type _chatterMobileSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ChatterMobileSettings _chatterMobileSettingsInstance;
        private ChatterMobileSettings _chatterMobileSettingsInstanceFixture;

        #region General Initializer : Class (ChatterMobileSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ChatterMobileSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _chatterMobileSettingsInstanceType = typeof(ChatterMobileSettings);
            _chatterMobileSettingsInstanceFixture = Create(true);
            _chatterMobileSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ChatterMobileSettings)

        #region General Initializer : Class (ChatterMobileSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ChatterMobileSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyandroidAuthorized)]
        [TestCase(PropertyandroidAuthorizedSpecified)]
        [TestCase(PropertyblackberryAuthorized)]
        [TestCase(PropertyblackberryAuthorizedSpecified)]
        [TestCase(PropertyenableChatterMobile)]
        [TestCase(PropertyenableChatterMobileSpecified)]
        [TestCase(PropertyenablePushNotifications)]
        [TestCase(PropertyenablePushNotificationsSpecified)]
        [TestCase(PropertyiPadAuthorized)]
        [TestCase(PropertyiPadAuthorizedSpecified)]
        [TestCase(PropertyiPhoneAuthorized)]
        [TestCase(PropertyiPhoneAuthorizedSpecified)]
        [TestCase(PropertysessionTimeout)]
        [TestCase(PropertysessionTimeoutSpecified)]
        public void AUT_ChatterMobileSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_chatterMobileSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ChatterMobileSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ChatterMobileSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldandroidAuthorizedField)]
        [TestCase(FieldandroidAuthorizedFieldSpecified)]
        [TestCase(FieldblackberryAuthorizedField)]
        [TestCase(FieldblackberryAuthorizedFieldSpecified)]
        [TestCase(FieldenableChatterMobileField)]
        [TestCase(FieldenableChatterMobileFieldSpecified)]
        [TestCase(FieldenablePushNotificationsField)]
        [TestCase(FieldenablePushNotificationsFieldSpecified)]
        [TestCase(FieldiPadAuthorizedField)]
        [TestCase(FieldiPadAuthorizedFieldSpecified)]
        [TestCase(FieldiPhoneAuthorizedField)]
        [TestCase(FieldiPhoneAuthorizedFieldSpecified)]
        [TestCase(FieldsessionTimeoutField)]
        [TestCase(FieldsessionTimeoutFieldSpecified)]
        public void AUT_ChatterMobileSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_chatterMobileSettingsInstanceFixture, 
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
        ///     Class (<see cref="ChatterMobileSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ChatterMobileSettings_Is_Instance_Present_Test()
        {
            // Assert
            _chatterMobileSettingsInstanceType.ShouldNotBeNull();
            _chatterMobileSettingsInstance.ShouldNotBeNull();
            _chatterMobileSettingsInstanceFixture.ShouldNotBeNull();
            _chatterMobileSettingsInstance.ShouldBeAssignableTo<ChatterMobileSettings>();
            _chatterMobileSettingsInstanceFixture.ShouldBeAssignableTo<ChatterMobileSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ChatterMobileSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ChatterMobileSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ChatterMobileSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _chatterMobileSettingsInstanceType.ShouldNotBeNull();
            _chatterMobileSettingsInstance.ShouldNotBeNull();
            _chatterMobileSettingsInstanceFixture.ShouldNotBeNull();
            _chatterMobileSettingsInstance.ShouldBeAssignableTo<ChatterMobileSettings>();
            _chatterMobileSettingsInstanceFixture.ShouldBeAssignableTo<ChatterMobileSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ChatterMobileSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyandroidAuthorized)]
        [TestCaseGeneric(typeof(bool) , PropertyandroidAuthorizedSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyblackberryAuthorized)]
        [TestCaseGeneric(typeof(bool) , PropertyblackberryAuthorizedSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableChatterMobile)]
        [TestCaseGeneric(typeof(bool) , PropertyenableChatterMobileSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenablePushNotifications)]
        [TestCaseGeneric(typeof(bool) , PropertyenablePushNotificationsSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyiPadAuthorized)]
        [TestCaseGeneric(typeof(bool) , PropertyiPadAuthorizedSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyiPhoneAuthorized)]
        [TestCaseGeneric(typeof(bool) , PropertyiPhoneAuthorizedSpecified)]
        [TestCaseGeneric(typeof(MobileSessionTimeout) , PropertysessionTimeout)]
        [TestCaseGeneric(typeof(bool) , PropertysessionTimeoutSpecified)]
        public void AUT_ChatterMobileSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ChatterMobileSettings, T>(_chatterMobileSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (androidAuthorized) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_androidAuthorized_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyandroidAuthorized);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (androidAuthorizedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_androidAuthorizedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyandroidAuthorizedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (blackberryAuthorized) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_blackberryAuthorized_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyblackberryAuthorized);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (blackberryAuthorizedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_blackberryAuthorizedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyblackberryAuthorizedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (enableChatterMobile) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_enableChatterMobile_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableChatterMobile);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (enableChatterMobileSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_enableChatterMobileSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableChatterMobileSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (enablePushNotifications) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_enablePushNotifications_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenablePushNotifications);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (enablePushNotificationsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_enablePushNotificationsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenablePushNotificationsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (iPadAuthorized) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_iPadAuthorized_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyiPadAuthorized);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (iPadAuthorizedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_iPadAuthorizedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyiPadAuthorizedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (iPhoneAuthorized) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_iPhoneAuthorized_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyiPhoneAuthorized);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (iPhoneAuthorizedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_iPhoneAuthorizedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyiPhoneAuthorizedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (sessionTimeout) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_sessionTimeout_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysessionTimeout);
            Action currentAction = () => propertyInfo.SetValue(_chatterMobileSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (sessionTimeout) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_sessionTimeout_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysessionTimeout);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChatterMobileSettings) => Property (sessionTimeoutSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChatterMobileSettings_Public_Class_sessionTimeoutSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysessionTimeoutSpecified);

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