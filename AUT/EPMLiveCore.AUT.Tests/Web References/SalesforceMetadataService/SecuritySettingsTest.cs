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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.SecuritySettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SecuritySettingsTest : AbstractBaseSetupTypedTest<SecuritySettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SecuritySettings) Initializer

        private const string PropertynetworkAccess = "networkAccess";
        private const string PropertypasswordPolicies = "passwordPolicies";
        private const string PropertysessionSettings = "sessionSettings";
        private const string FieldnetworkAccessField = "networkAccessField";
        private const string FieldpasswordPoliciesField = "passwordPoliciesField";
        private const string FieldsessionSettingsField = "sessionSettingsField";
        private Type _securitySettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SecuritySettings _securitySettingsInstance;
        private SecuritySettings _securitySettingsInstanceFixture;

        #region General Initializer : Class (SecuritySettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SecuritySettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _securitySettingsInstanceType = typeof(SecuritySettings);
            _securitySettingsInstanceFixture = Create(true);
            _securitySettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SecuritySettings)

        #region General Initializer : Class (SecuritySettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SecuritySettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertynetworkAccess)]
        [TestCase(PropertypasswordPolicies)]
        [TestCase(PropertysessionSettings)]
        public void AUT_SecuritySettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_securitySettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SecuritySettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SecuritySettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnetworkAccessField)]
        [TestCase(FieldpasswordPoliciesField)]
        [TestCase(FieldsessionSettingsField)]
        public void AUT_SecuritySettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_securitySettingsInstanceFixture, 
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
        ///     Class (<see cref="SecuritySettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SecuritySettings_Is_Instance_Present_Test()
        {
            // Assert
            _securitySettingsInstanceType.ShouldNotBeNull();
            _securitySettingsInstance.ShouldNotBeNull();
            _securitySettingsInstanceFixture.ShouldNotBeNull();
            _securitySettingsInstance.ShouldBeAssignableTo<SecuritySettings>();
            _securitySettingsInstanceFixture.ShouldBeAssignableTo<SecuritySettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SecuritySettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SecuritySettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SecuritySettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _securitySettingsInstanceType.ShouldNotBeNull();
            _securitySettingsInstance.ShouldNotBeNull();
            _securitySettingsInstanceFixture.ShouldNotBeNull();
            _securitySettingsInstance.ShouldBeAssignableTo<SecuritySettings>();
            _securitySettingsInstanceFixture.ShouldBeAssignableTo<SecuritySettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SecuritySettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(IpRange[]) , PropertynetworkAccess)]
        [TestCaseGeneric(typeof(PasswordPolicies) , PropertypasswordPolicies)]
        [TestCaseGeneric(typeof(SessionSettings) , PropertysessionSettings)]
        public void AUT_SecuritySettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SecuritySettings, T>(_securitySettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SecuritySettings) => Property (networkAccess) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SecuritySettings_networkAccess_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertynetworkAccess);
            Action currentAction = () => propertyInfo.SetValue(_securitySettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SecuritySettings) => Property (networkAccess) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SecuritySettings_Public_Class_networkAccess_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynetworkAccess);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SecuritySettings) => Property (passwordPolicies) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SecuritySettings_passwordPolicies_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertypasswordPolicies);
            Action currentAction = () => propertyInfo.SetValue(_securitySettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SecuritySettings) => Property (passwordPolicies) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SecuritySettings_Public_Class_passwordPolicies_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypasswordPolicies);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SecuritySettings) => Property (sessionSettings) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SecuritySettings_sessionSettings_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysessionSettings);
            Action currentAction = () => propertyInfo.SetValue(_securitySettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SecuritySettings) => Property (sessionSettings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SecuritySettings_Public_Class_sessionSettings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysessionSettings);

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