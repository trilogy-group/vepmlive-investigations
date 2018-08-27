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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.SessionSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SessionSettingsTest : AbstractBaseSetupTypedTest<SessionSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SessionSettings) Initializer

        private const string PropertydisableTimeoutWarning = "disableTimeoutWarning";
        private const string PropertydisableTimeoutWarningSpecified = "disableTimeoutWarningSpecified";
        private const string PropertyenableCSRFOnGet = "enableCSRFOnGet";
        private const string PropertyenableCSRFOnGetSpecified = "enableCSRFOnGetSpecified";
        private const string PropertyenableCSRFOnPost = "enableCSRFOnPost";
        private const string PropertyenableCSRFOnPostSpecified = "enableCSRFOnPostSpecified";
        private const string PropertyenableCacheAndAutocomplete = "enableCacheAndAutocomplete";
        private const string PropertyenableCacheAndAutocompleteSpecified = "enableCacheAndAutocompleteSpecified";
        private const string PropertyenableClickjackNonsetupSFDC = "enableClickjackNonsetupSFDC";
        private const string PropertyenableClickjackNonsetupSFDCSpecified = "enableClickjackNonsetupSFDCSpecified";
        private const string PropertyenableClickjackNonsetupUser = "enableClickjackNonsetupUser";
        private const string PropertyenableClickjackNonsetupUserSpecified = "enableClickjackNonsetupUserSpecified";
        private const string PropertyenableClickjackSetup = "enableClickjackSetup";
        private const string PropertyenableClickjackSetupSpecified = "enableClickjackSetupSpecified";
        private const string PropertyenableSMSIdentity = "enableSMSIdentity";
        private const string PropertyenableSMSIdentitySpecified = "enableSMSIdentitySpecified";
        private const string PropertyforceRelogin = "forceRelogin";
        private const string PropertyforceReloginSpecified = "forceReloginSpecified";
        private const string PropertylockSessionsToIp = "lockSessionsToIp";
        private const string PropertylockSessionsToIpSpecified = "lockSessionsToIpSpecified";
        private const string PropertysessionTimeout = "sessionTimeout";
        private const string PropertysessionTimeoutSpecified = "sessionTimeoutSpecified";
        private const string FielddisableTimeoutWarningField = "disableTimeoutWarningField";
        private const string FielddisableTimeoutWarningFieldSpecified = "disableTimeoutWarningFieldSpecified";
        private const string FieldenableCSRFOnGetField = "enableCSRFOnGetField";
        private const string FieldenableCSRFOnGetFieldSpecified = "enableCSRFOnGetFieldSpecified";
        private const string FieldenableCSRFOnPostField = "enableCSRFOnPostField";
        private const string FieldenableCSRFOnPostFieldSpecified = "enableCSRFOnPostFieldSpecified";
        private const string FieldenableCacheAndAutocompleteField = "enableCacheAndAutocompleteField";
        private const string FieldenableCacheAndAutocompleteFieldSpecified = "enableCacheAndAutocompleteFieldSpecified";
        private const string FieldenableClickjackNonsetupSFDCField = "enableClickjackNonsetupSFDCField";
        private const string FieldenableClickjackNonsetupSFDCFieldSpecified = "enableClickjackNonsetupSFDCFieldSpecified";
        private const string FieldenableClickjackNonsetupUserField = "enableClickjackNonsetupUserField";
        private const string FieldenableClickjackNonsetupUserFieldSpecified = "enableClickjackNonsetupUserFieldSpecified";
        private const string FieldenableClickjackSetupField = "enableClickjackSetupField";
        private const string FieldenableClickjackSetupFieldSpecified = "enableClickjackSetupFieldSpecified";
        private const string FieldenableSMSIdentityField = "enableSMSIdentityField";
        private const string FieldenableSMSIdentityFieldSpecified = "enableSMSIdentityFieldSpecified";
        private const string FieldforceReloginField = "forceReloginField";
        private const string FieldforceReloginFieldSpecified = "forceReloginFieldSpecified";
        private const string FieldlockSessionsToIpField = "lockSessionsToIpField";
        private const string FieldlockSessionsToIpFieldSpecified = "lockSessionsToIpFieldSpecified";
        private const string FieldsessionTimeoutField = "sessionTimeoutField";
        private const string FieldsessionTimeoutFieldSpecified = "sessionTimeoutFieldSpecified";
        private Type _sessionSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SessionSettings _sessionSettingsInstance;
        private SessionSettings _sessionSettingsInstanceFixture;

        #region General Initializer : Class (SessionSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SessionSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sessionSettingsInstanceType = typeof(SessionSettings);
            _sessionSettingsInstanceFixture = Create(true);
            _sessionSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SessionSettings)

        #region General Initializer : Class (SessionSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SessionSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertydisableTimeoutWarning)]
        [TestCase(PropertydisableTimeoutWarningSpecified)]
        [TestCase(PropertyenableCSRFOnGet)]
        [TestCase(PropertyenableCSRFOnGetSpecified)]
        [TestCase(PropertyenableCSRFOnPost)]
        [TestCase(PropertyenableCSRFOnPostSpecified)]
        [TestCase(PropertyenableCacheAndAutocomplete)]
        [TestCase(PropertyenableCacheAndAutocompleteSpecified)]
        [TestCase(PropertyenableClickjackNonsetupSFDC)]
        [TestCase(PropertyenableClickjackNonsetupSFDCSpecified)]
        [TestCase(PropertyenableClickjackNonsetupUser)]
        [TestCase(PropertyenableClickjackNonsetupUserSpecified)]
        [TestCase(PropertyenableClickjackSetup)]
        [TestCase(PropertyenableClickjackSetupSpecified)]
        [TestCase(PropertyenableSMSIdentity)]
        [TestCase(PropertyenableSMSIdentitySpecified)]
        [TestCase(PropertyforceRelogin)]
        [TestCase(PropertyforceReloginSpecified)]
        [TestCase(PropertylockSessionsToIp)]
        [TestCase(PropertylockSessionsToIpSpecified)]
        [TestCase(PropertysessionTimeout)]
        [TestCase(PropertysessionTimeoutSpecified)]
        public void AUT_SessionSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sessionSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SessionSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SessionSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddisableTimeoutWarningField)]
        [TestCase(FielddisableTimeoutWarningFieldSpecified)]
        [TestCase(FieldenableCSRFOnGetField)]
        [TestCase(FieldenableCSRFOnGetFieldSpecified)]
        [TestCase(FieldenableCSRFOnPostField)]
        [TestCase(FieldenableCSRFOnPostFieldSpecified)]
        [TestCase(FieldenableCacheAndAutocompleteField)]
        [TestCase(FieldenableCacheAndAutocompleteFieldSpecified)]
        [TestCase(FieldenableClickjackNonsetupSFDCField)]
        [TestCase(FieldenableClickjackNonsetupSFDCFieldSpecified)]
        [TestCase(FieldenableClickjackNonsetupUserField)]
        [TestCase(FieldenableClickjackNonsetupUserFieldSpecified)]
        [TestCase(FieldenableClickjackSetupField)]
        [TestCase(FieldenableClickjackSetupFieldSpecified)]
        [TestCase(FieldenableSMSIdentityField)]
        [TestCase(FieldenableSMSIdentityFieldSpecified)]
        [TestCase(FieldforceReloginField)]
        [TestCase(FieldforceReloginFieldSpecified)]
        [TestCase(FieldlockSessionsToIpField)]
        [TestCase(FieldlockSessionsToIpFieldSpecified)]
        [TestCase(FieldsessionTimeoutField)]
        [TestCase(FieldsessionTimeoutFieldSpecified)]
        public void AUT_SessionSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sessionSettingsInstanceFixture, 
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
        ///     Class (<see cref="SessionSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SessionSettings_Is_Instance_Present_Test()
        {
            // Assert
            _sessionSettingsInstanceType.ShouldNotBeNull();
            _sessionSettingsInstance.ShouldNotBeNull();
            _sessionSettingsInstanceFixture.ShouldNotBeNull();
            _sessionSettingsInstance.ShouldBeAssignableTo<SessionSettings>();
            _sessionSettingsInstanceFixture.ShouldBeAssignableTo<SessionSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SessionSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SessionSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SessionSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sessionSettingsInstanceType.ShouldNotBeNull();
            _sessionSettingsInstance.ShouldNotBeNull();
            _sessionSettingsInstanceFixture.ShouldNotBeNull();
            _sessionSettingsInstance.ShouldBeAssignableTo<SessionSettings>();
            _sessionSettingsInstanceFixture.ShouldBeAssignableTo<SessionSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SessionSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertydisableTimeoutWarning)]
        [TestCaseGeneric(typeof(bool) , PropertydisableTimeoutWarningSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableCSRFOnGet)]
        [TestCaseGeneric(typeof(bool) , PropertyenableCSRFOnGetSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableCSRFOnPost)]
        [TestCaseGeneric(typeof(bool) , PropertyenableCSRFOnPostSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableCacheAndAutocomplete)]
        [TestCaseGeneric(typeof(bool) , PropertyenableCacheAndAutocompleteSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableClickjackNonsetupSFDC)]
        [TestCaseGeneric(typeof(bool) , PropertyenableClickjackNonsetupSFDCSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableClickjackNonsetupUser)]
        [TestCaseGeneric(typeof(bool) , PropertyenableClickjackNonsetupUserSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableClickjackSetup)]
        [TestCaseGeneric(typeof(bool) , PropertyenableClickjackSetupSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableSMSIdentity)]
        [TestCaseGeneric(typeof(bool) , PropertyenableSMSIdentitySpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyforceRelogin)]
        [TestCaseGeneric(typeof(bool) , PropertyforceReloginSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertylockSessionsToIp)]
        [TestCaseGeneric(typeof(bool) , PropertylockSessionsToIpSpecified)]
        [TestCaseGeneric(typeof(SessionTimeout) , PropertysessionTimeout)]
        [TestCaseGeneric(typeof(bool) , PropertysessionTimeoutSpecified)]
        public void AUT_SessionSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SessionSettings, T>(_sessionSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (disableTimeoutWarning) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_disableTimeoutWarning_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisableTimeoutWarning);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (disableTimeoutWarningSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_disableTimeoutWarningSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisableTimeoutWarningSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableCacheAndAutocomplete) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableCacheAndAutocomplete_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableCacheAndAutocomplete);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableCacheAndAutocompleteSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableCacheAndAutocompleteSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableCacheAndAutocompleteSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableClickjackNonsetupSFDC) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableClickjackNonsetupSFDC_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableClickjackNonsetupSFDC);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableClickjackNonsetupSFDCSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableClickjackNonsetupSFDCSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableClickjackNonsetupSFDCSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableClickjackNonsetupUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableClickjackNonsetupUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableClickjackNonsetupUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableClickjackNonsetupUserSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableClickjackNonsetupUserSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableClickjackNonsetupUserSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableClickjackSetup) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableClickjackSetup_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableClickjackSetup);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableClickjackSetupSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableClickjackSetupSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableClickjackSetupSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableCSRFOnGet) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableCSRFOnGet_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableCSRFOnGet);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableCSRFOnGetSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableCSRFOnGetSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableCSRFOnGetSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableCSRFOnPost) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableCSRFOnPost_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableCSRFOnPost);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableCSRFOnPostSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableCSRFOnPostSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableCSRFOnPostSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableSMSIdentity) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableSMSIdentity_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableSMSIdentity);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (enableSMSIdentitySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_enableSMSIdentitySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableSMSIdentitySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (forceRelogin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_forceRelogin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyforceRelogin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (forceReloginSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_forceReloginSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyforceReloginSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (lockSessionsToIp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_lockSessionsToIp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylockSessionsToIp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (lockSessionsToIpSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_lockSessionsToIpSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylockSessionsToIpSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (sessionTimeout) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_sessionTimeout_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysessionTimeout);
            Action currentAction = () => propertyInfo.SetValue(_sessionSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SessionSettings) => Property (sessionTimeout) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_sessionTimeout_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (SessionSettings) => Property (sessionTimeoutSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SessionSettings_Public_Class_sessionTimeoutSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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