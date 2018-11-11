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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.EntitlementSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EntitlementSettingsTest : AbstractBaseSetupTypedTest<EntitlementSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EntitlementSettings) Initializer

        private const string PropertyassetLookupLimitedToActiveEntitlementsOnAccount = "assetLookupLimitedToActiveEntitlementsOnAccount";
        private const string PropertyassetLookupLimitedToActiveEntitlementsOnAccountSpecified = "assetLookupLimitedToActiveEntitlementsOnAccountSpecified";
        private const string PropertyassetLookupLimitedToActiveEntitlementsOnContact = "assetLookupLimitedToActiveEntitlementsOnContact";
        private const string PropertyassetLookupLimitedToActiveEntitlementsOnContactSpecified = "assetLookupLimitedToActiveEntitlementsOnContactSpecified";
        private const string PropertyassetLookupLimitedToSameAccount = "assetLookupLimitedToSameAccount";
        private const string PropertyassetLookupLimitedToSameAccountSpecified = "assetLookupLimitedToSameAccountSpecified";
        private const string PropertyassetLookupLimitedToSameContact = "assetLookupLimitedToSameContact";
        private const string PropertyassetLookupLimitedToSameContactSpecified = "assetLookupLimitedToSameContactSpecified";
        private const string PropertyenableEntitlements = "enableEntitlements";
        private const string PropertyentitlementLookupLimitedToActiveStatus = "entitlementLookupLimitedToActiveStatus";
        private const string PropertyentitlementLookupLimitedToActiveStatusSpecified = "entitlementLookupLimitedToActiveStatusSpecified";
        private const string PropertyentitlementLookupLimitedToSameAccount = "entitlementLookupLimitedToSameAccount";
        private const string PropertyentitlementLookupLimitedToSameAccountSpecified = "entitlementLookupLimitedToSameAccountSpecified";
        private const string PropertyentitlementLookupLimitedToSameAsset = "entitlementLookupLimitedToSameAsset";
        private const string PropertyentitlementLookupLimitedToSameAssetSpecified = "entitlementLookupLimitedToSameAssetSpecified";
        private const string PropertyentitlementLookupLimitedToSameContact = "entitlementLookupLimitedToSameContact";
        private const string PropertyentitlementLookupLimitedToSameContactSpecified = "entitlementLookupLimitedToSameContactSpecified";
        private const string FieldassetLookupLimitedToActiveEntitlementsOnAccountField = "assetLookupLimitedToActiveEntitlementsOnAccountField";
        private const string FieldassetLookupLimitedToActiveEntitlementsOnAccountFieldSpecified = "assetLookupLimitedToActiveEntitlementsOnAccountFieldSpecified";
        private const string FieldassetLookupLimitedToActiveEntitlementsOnContactField = "assetLookupLimitedToActiveEntitlementsOnContactField";
        private const string FieldassetLookupLimitedToActiveEntitlementsOnContactFieldSpecified = "assetLookupLimitedToActiveEntitlementsOnContactFieldSpecified";
        private const string FieldassetLookupLimitedToSameAccountField = "assetLookupLimitedToSameAccountField";
        private const string FieldassetLookupLimitedToSameAccountFieldSpecified = "assetLookupLimitedToSameAccountFieldSpecified";
        private const string FieldassetLookupLimitedToSameContactField = "assetLookupLimitedToSameContactField";
        private const string FieldassetLookupLimitedToSameContactFieldSpecified = "assetLookupLimitedToSameContactFieldSpecified";
        private const string FieldenableEntitlementsField = "enableEntitlementsField";
        private const string FieldentitlementLookupLimitedToActiveStatusField = "entitlementLookupLimitedToActiveStatusField";
        private const string FieldentitlementLookupLimitedToActiveStatusFieldSpecified = "entitlementLookupLimitedToActiveStatusFieldSpecified";
        private const string FieldentitlementLookupLimitedToSameAccountField = "entitlementLookupLimitedToSameAccountField";
        private const string FieldentitlementLookupLimitedToSameAccountFieldSpecified = "entitlementLookupLimitedToSameAccountFieldSpecified";
        private const string FieldentitlementLookupLimitedToSameAssetField = "entitlementLookupLimitedToSameAssetField";
        private const string FieldentitlementLookupLimitedToSameAssetFieldSpecified = "entitlementLookupLimitedToSameAssetFieldSpecified";
        private const string FieldentitlementLookupLimitedToSameContactField = "entitlementLookupLimitedToSameContactField";
        private const string FieldentitlementLookupLimitedToSameContactFieldSpecified = "entitlementLookupLimitedToSameContactFieldSpecified";
        private Type _entitlementSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EntitlementSettings _entitlementSettingsInstance;
        private EntitlementSettings _entitlementSettingsInstanceFixture;

        #region General Initializer : Class (EntitlementSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EntitlementSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _entitlementSettingsInstanceType = typeof(EntitlementSettings);
            _entitlementSettingsInstanceFixture = Create(true);
            _entitlementSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EntitlementSettings)

        #region General Initializer : Class (EntitlementSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EntitlementSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyassetLookupLimitedToActiveEntitlementsOnAccount)]
        [TestCase(PropertyassetLookupLimitedToActiveEntitlementsOnAccountSpecified)]
        [TestCase(PropertyassetLookupLimitedToActiveEntitlementsOnContact)]
        [TestCase(PropertyassetLookupLimitedToActiveEntitlementsOnContactSpecified)]
        [TestCase(PropertyassetLookupLimitedToSameAccount)]
        [TestCase(PropertyassetLookupLimitedToSameAccountSpecified)]
        [TestCase(PropertyassetLookupLimitedToSameContact)]
        [TestCase(PropertyassetLookupLimitedToSameContactSpecified)]
        [TestCase(PropertyenableEntitlements)]
        [TestCase(PropertyentitlementLookupLimitedToActiveStatus)]
        [TestCase(PropertyentitlementLookupLimitedToActiveStatusSpecified)]
        [TestCase(PropertyentitlementLookupLimitedToSameAccount)]
        [TestCase(PropertyentitlementLookupLimitedToSameAccountSpecified)]
        [TestCase(PropertyentitlementLookupLimitedToSameAsset)]
        [TestCase(PropertyentitlementLookupLimitedToSameAssetSpecified)]
        [TestCase(PropertyentitlementLookupLimitedToSameContact)]
        [TestCase(PropertyentitlementLookupLimitedToSameContactSpecified)]
        public void AUT_EntitlementSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_entitlementSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EntitlementSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EntitlementSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldassetLookupLimitedToActiveEntitlementsOnAccountField)]
        [TestCase(FieldassetLookupLimitedToActiveEntitlementsOnAccountFieldSpecified)]
        [TestCase(FieldassetLookupLimitedToActiveEntitlementsOnContactField)]
        [TestCase(FieldassetLookupLimitedToActiveEntitlementsOnContactFieldSpecified)]
        [TestCase(FieldassetLookupLimitedToSameAccountField)]
        [TestCase(FieldassetLookupLimitedToSameAccountFieldSpecified)]
        [TestCase(FieldassetLookupLimitedToSameContactField)]
        [TestCase(FieldassetLookupLimitedToSameContactFieldSpecified)]
        [TestCase(FieldenableEntitlementsField)]
        [TestCase(FieldentitlementLookupLimitedToActiveStatusField)]
        [TestCase(FieldentitlementLookupLimitedToActiveStatusFieldSpecified)]
        [TestCase(FieldentitlementLookupLimitedToSameAccountField)]
        [TestCase(FieldentitlementLookupLimitedToSameAccountFieldSpecified)]
        [TestCase(FieldentitlementLookupLimitedToSameAssetField)]
        [TestCase(FieldentitlementLookupLimitedToSameAssetFieldSpecified)]
        [TestCase(FieldentitlementLookupLimitedToSameContactField)]
        [TestCase(FieldentitlementLookupLimitedToSameContactFieldSpecified)]
        public void AUT_EntitlementSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_entitlementSettingsInstanceFixture, 
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
        ///     Class (<see cref="EntitlementSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EntitlementSettings_Is_Instance_Present_Test()
        {
            // Assert
            _entitlementSettingsInstanceType.ShouldNotBeNull();
            _entitlementSettingsInstance.ShouldNotBeNull();
            _entitlementSettingsInstanceFixture.ShouldNotBeNull();
            _entitlementSettingsInstance.ShouldBeAssignableTo<EntitlementSettings>();
            _entitlementSettingsInstanceFixture.ShouldBeAssignableTo<EntitlementSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EntitlementSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EntitlementSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EntitlementSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _entitlementSettingsInstanceType.ShouldNotBeNull();
            _entitlementSettingsInstance.ShouldNotBeNull();
            _entitlementSettingsInstanceFixture.ShouldNotBeNull();
            _entitlementSettingsInstance.ShouldBeAssignableTo<EntitlementSettings>();
            _entitlementSettingsInstanceFixture.ShouldBeAssignableTo<EntitlementSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EntitlementSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyassetLookupLimitedToActiveEntitlementsOnAccount)]
        [TestCaseGeneric(typeof(bool) , PropertyassetLookupLimitedToActiveEntitlementsOnAccountSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyassetLookupLimitedToActiveEntitlementsOnContact)]
        [TestCaseGeneric(typeof(bool) , PropertyassetLookupLimitedToActiveEntitlementsOnContactSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyassetLookupLimitedToSameAccount)]
        [TestCaseGeneric(typeof(bool) , PropertyassetLookupLimitedToSameAccountSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyassetLookupLimitedToSameContact)]
        [TestCaseGeneric(typeof(bool) , PropertyassetLookupLimitedToSameContactSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableEntitlements)]
        [TestCaseGeneric(typeof(bool) , PropertyentitlementLookupLimitedToActiveStatus)]
        [TestCaseGeneric(typeof(bool) , PropertyentitlementLookupLimitedToActiveStatusSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyentitlementLookupLimitedToSameAccount)]
        [TestCaseGeneric(typeof(bool) , PropertyentitlementLookupLimitedToSameAccountSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyentitlementLookupLimitedToSameAsset)]
        [TestCaseGeneric(typeof(bool) , PropertyentitlementLookupLimitedToSameAssetSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyentitlementLookupLimitedToSameContact)]
        [TestCaseGeneric(typeof(bool) , PropertyentitlementLookupLimitedToSameContactSpecified)]
        public void AUT_EntitlementSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EntitlementSettings, T>(_entitlementSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (assetLookupLimitedToActiveEntitlementsOnAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_assetLookupLimitedToActiveEntitlementsOnAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassetLookupLimitedToActiveEntitlementsOnAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (assetLookupLimitedToActiveEntitlementsOnAccountSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_assetLookupLimitedToActiveEntitlementsOnAccountSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassetLookupLimitedToActiveEntitlementsOnAccountSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (assetLookupLimitedToActiveEntitlementsOnContact) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_assetLookupLimitedToActiveEntitlementsOnContact_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassetLookupLimitedToActiveEntitlementsOnContact);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (assetLookupLimitedToActiveEntitlementsOnContactSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_assetLookupLimitedToActiveEntitlementsOnContactSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassetLookupLimitedToActiveEntitlementsOnContactSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (assetLookupLimitedToSameAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_assetLookupLimitedToSameAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassetLookupLimitedToSameAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (assetLookupLimitedToSameAccountSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_assetLookupLimitedToSameAccountSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassetLookupLimitedToSameAccountSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (assetLookupLimitedToSameContact) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_assetLookupLimitedToSameContact_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassetLookupLimitedToSameContact);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (assetLookupLimitedToSameContactSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_assetLookupLimitedToSameContactSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassetLookupLimitedToSameContactSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (enableEntitlements) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_enableEntitlements_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableEntitlements);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (entitlementLookupLimitedToActiveStatus) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_entitlementLookupLimitedToActiveStatus_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyentitlementLookupLimitedToActiveStatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (entitlementLookupLimitedToActiveStatusSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_entitlementLookupLimitedToActiveStatusSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyentitlementLookupLimitedToActiveStatusSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (entitlementLookupLimitedToSameAccount) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_entitlementLookupLimitedToSameAccount_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyentitlementLookupLimitedToSameAccount);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (entitlementLookupLimitedToSameAccountSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_entitlementLookupLimitedToSameAccountSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyentitlementLookupLimitedToSameAccountSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (entitlementLookupLimitedToSameAsset) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_entitlementLookupLimitedToSameAsset_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyentitlementLookupLimitedToSameAsset);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (entitlementLookupLimitedToSameAssetSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_entitlementLookupLimitedToSameAssetSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyentitlementLookupLimitedToSameAssetSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (entitlementLookupLimitedToSameContact) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_entitlementLookupLimitedToSameContact_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyentitlementLookupLimitedToSameContact);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EntitlementSettings) => Property (entitlementLookupLimitedToSameContactSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EntitlementSettings_Public_Class_entitlementLookupLimitedToSameContactSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyentitlementLookupLimitedToSameContactSpecified);

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