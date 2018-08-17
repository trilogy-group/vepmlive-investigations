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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ContractSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ContractSettingsTest : AbstractBaseSetupTypedTest<ContractSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ContractSettings) Initializer

        private const string PropertyautoCalculateEndDate = "autoCalculateEndDate";
        private const string PropertyautoCalculateEndDateSpecified = "autoCalculateEndDateSpecified";
        private const string PropertyautoExpirationDelay = "autoExpirationDelay";
        private const string PropertyautoExpirationRecipient = "autoExpirationRecipient";
        private const string PropertyautoExpireContracts = "autoExpireContracts";
        private const string PropertyautoExpireContractsSpecified = "autoExpireContractsSpecified";
        private const string PropertyenableContractHistoryTracking = "enableContractHistoryTracking";
        private const string PropertyenableContractHistoryTrackingSpecified = "enableContractHistoryTrackingSpecified";
        private const string PropertynotifyOwnersOnContractExpiration = "notifyOwnersOnContractExpiration";
        private const string PropertynotifyOwnersOnContractExpirationSpecified = "notifyOwnersOnContractExpirationSpecified";
        private const string FieldautoCalculateEndDateField = "autoCalculateEndDateField";
        private const string FieldautoCalculateEndDateFieldSpecified = "autoCalculateEndDateFieldSpecified";
        private const string FieldautoExpirationDelayField = "autoExpirationDelayField";
        private const string FieldautoExpirationRecipientField = "autoExpirationRecipientField";
        private const string FieldautoExpireContractsField = "autoExpireContractsField";
        private const string FieldautoExpireContractsFieldSpecified = "autoExpireContractsFieldSpecified";
        private const string FieldenableContractHistoryTrackingField = "enableContractHistoryTrackingField";
        private const string FieldenableContractHistoryTrackingFieldSpecified = "enableContractHistoryTrackingFieldSpecified";
        private const string FieldnotifyOwnersOnContractExpirationField = "notifyOwnersOnContractExpirationField";
        private const string FieldnotifyOwnersOnContractExpirationFieldSpecified = "notifyOwnersOnContractExpirationFieldSpecified";
        private Type _contractSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ContractSettings _contractSettingsInstance;
        private ContractSettings _contractSettingsInstanceFixture;

        #region General Initializer : Class (ContractSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ContractSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _contractSettingsInstanceType = typeof(ContractSettings);
            _contractSettingsInstanceFixture = Create(true);
            _contractSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ContractSettings)

        #region General Initializer : Class (ContractSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ContractSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyautoCalculateEndDate)]
        [TestCase(PropertyautoCalculateEndDateSpecified)]
        [TestCase(PropertyautoExpirationDelay)]
        [TestCase(PropertyautoExpirationRecipient)]
        [TestCase(PropertyautoExpireContracts)]
        [TestCase(PropertyautoExpireContractsSpecified)]
        [TestCase(PropertyenableContractHistoryTracking)]
        [TestCase(PropertyenableContractHistoryTrackingSpecified)]
        [TestCase(PropertynotifyOwnersOnContractExpiration)]
        [TestCase(PropertynotifyOwnersOnContractExpirationSpecified)]
        public void AUT_ContractSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_contractSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ContractSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ContractSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldautoCalculateEndDateField)]
        [TestCase(FieldautoCalculateEndDateFieldSpecified)]
        [TestCase(FieldautoExpirationDelayField)]
        [TestCase(FieldautoExpirationRecipientField)]
        [TestCase(FieldautoExpireContractsField)]
        [TestCase(FieldautoExpireContractsFieldSpecified)]
        [TestCase(FieldenableContractHistoryTrackingField)]
        [TestCase(FieldenableContractHistoryTrackingFieldSpecified)]
        [TestCase(FieldnotifyOwnersOnContractExpirationField)]
        [TestCase(FieldnotifyOwnersOnContractExpirationFieldSpecified)]
        public void AUT_ContractSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_contractSettingsInstanceFixture, 
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
        ///     Class (<see cref="ContractSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ContractSettings_Is_Instance_Present_Test()
        {
            // Assert
            _contractSettingsInstanceType.ShouldNotBeNull();
            _contractSettingsInstance.ShouldNotBeNull();
            _contractSettingsInstanceFixture.ShouldNotBeNull();
            _contractSettingsInstance.ShouldBeAssignableTo<ContractSettings>();
            _contractSettingsInstanceFixture.ShouldBeAssignableTo<ContractSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ContractSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ContractSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ContractSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _contractSettingsInstanceType.ShouldNotBeNull();
            _contractSettingsInstance.ShouldNotBeNull();
            _contractSettingsInstanceFixture.ShouldNotBeNull();
            _contractSettingsInstance.ShouldBeAssignableTo<ContractSettings>();
            _contractSettingsInstanceFixture.ShouldBeAssignableTo<ContractSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ContractSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyautoCalculateEndDate)]
        [TestCaseGeneric(typeof(bool) , PropertyautoCalculateEndDateSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyautoExpirationDelay)]
        [TestCaseGeneric(typeof(string) , PropertyautoExpirationRecipient)]
        [TestCaseGeneric(typeof(bool) , PropertyautoExpireContracts)]
        [TestCaseGeneric(typeof(bool) , PropertyautoExpireContractsSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableContractHistoryTracking)]
        [TestCaseGeneric(typeof(bool) , PropertyenableContractHistoryTrackingSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyOwnersOnContractExpiration)]
        [TestCaseGeneric(typeof(bool) , PropertynotifyOwnersOnContractExpirationSpecified)]
        public void AUT_ContractSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ContractSettings, T>(_contractSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ContractSettings) => Property (autoCalculateEndDate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContractSettings_Public_Class_autoCalculateEndDate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyautoCalculateEndDate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ContractSettings) => Property (autoCalculateEndDateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContractSettings_Public_Class_autoCalculateEndDateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyautoCalculateEndDateSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ContractSettings) => Property (autoExpirationDelay) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContractSettings_Public_Class_autoExpirationDelay_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyautoExpirationDelay);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ContractSettings) => Property (autoExpirationRecipient) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContractSettings_Public_Class_autoExpirationRecipient_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyautoExpirationRecipient);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ContractSettings) => Property (autoExpireContracts) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContractSettings_Public_Class_autoExpireContracts_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyautoExpireContracts);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ContractSettings) => Property (autoExpireContractsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContractSettings_Public_Class_autoExpireContractsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyautoExpireContractsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ContractSettings) => Property (enableContractHistoryTracking) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContractSettings_Public_Class_enableContractHistoryTracking_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableContractHistoryTracking);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ContractSettings) => Property (enableContractHistoryTrackingSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContractSettings_Public_Class_enableContractHistoryTrackingSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableContractHistoryTrackingSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ContractSettings) => Property (notifyOwnersOnContractExpiration) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContractSettings_Public_Class_notifyOwnersOnContractExpiration_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyOwnersOnContractExpiration);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ContractSettings) => Property (notifyOwnersOnContractExpirationSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ContractSettings_Public_Class_notifyOwnersOnContractExpirationSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynotifyOwnersOnContractExpirationSpecified);

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