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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.AuthProvider" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AuthProviderTest : AbstractBaseSetupTypedTest<AuthProvider>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AuthProvider) Initializer

        private const string PropertyconsumerKey = "consumerKey";
        private const string PropertyconsumerSecret = "consumerSecret";
        private const string PropertyerrorUrl = "errorUrl";
        private const string PropertyexecutionUser = "executionUser";
        private const string PropertyfriendlyName = "friendlyName";
        private const string Propertyportal = "portal";
        private const string PropertyproviderType = "providerType";
        private const string PropertyregistrationHandler = "registrationHandler";
        private const string FieldconsumerKeyField = "consumerKeyField";
        private const string FieldconsumerSecretField = "consumerSecretField";
        private const string FielderrorUrlField = "errorUrlField";
        private const string FieldexecutionUserField = "executionUserField";
        private const string FieldfriendlyNameField = "friendlyNameField";
        private const string FieldportalField = "portalField";
        private const string FieldproviderTypeField = "providerTypeField";
        private const string FieldregistrationHandlerField = "registrationHandlerField";
        private Type _authProviderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AuthProvider _authProviderInstance;
        private AuthProvider _authProviderInstanceFixture;

        #region General Initializer : Class (AuthProvider) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AuthProvider" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _authProviderInstanceType = typeof(AuthProvider);
            _authProviderInstanceFixture = Create(true);
            _authProviderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AuthProvider)

        #region General Initializer : Class (AuthProvider) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AuthProvider" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyconsumerKey)]
        [TestCase(PropertyconsumerSecret)]
        [TestCase(PropertyerrorUrl)]
        [TestCase(PropertyexecutionUser)]
        [TestCase(PropertyfriendlyName)]
        [TestCase(Propertyportal)]
        [TestCase(PropertyproviderType)]
        [TestCase(PropertyregistrationHandler)]
        public void AUT_AuthProvider_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_authProviderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AuthProvider) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AuthProvider" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldconsumerKeyField)]
        [TestCase(FieldconsumerSecretField)]
        [TestCase(FielderrorUrlField)]
        [TestCase(FieldexecutionUserField)]
        [TestCase(FieldfriendlyNameField)]
        [TestCase(FieldportalField)]
        [TestCase(FieldproviderTypeField)]
        [TestCase(FieldregistrationHandlerField)]
        public void AUT_AuthProvider_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_authProviderInstanceFixture, 
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
        ///     Class (<see cref="AuthProvider" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AuthProvider_Is_Instance_Present_Test()
        {
            // Assert
            _authProviderInstanceType.ShouldNotBeNull();
            _authProviderInstance.ShouldNotBeNull();
            _authProviderInstanceFixture.ShouldNotBeNull();
            _authProviderInstance.ShouldBeAssignableTo<AuthProvider>();
            _authProviderInstanceFixture.ShouldBeAssignableTo<AuthProvider>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AuthProvider) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AuthProvider_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AuthProvider instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _authProviderInstanceType.ShouldNotBeNull();
            _authProviderInstance.ShouldNotBeNull();
            _authProviderInstanceFixture.ShouldNotBeNull();
            _authProviderInstance.ShouldBeAssignableTo<AuthProvider>();
            _authProviderInstanceFixture.ShouldBeAssignableTo<AuthProvider>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AuthProvider) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyconsumerKey)]
        [TestCaseGeneric(typeof(string) , PropertyconsumerSecret)]
        [TestCaseGeneric(typeof(string) , PropertyerrorUrl)]
        [TestCaseGeneric(typeof(string) , PropertyexecutionUser)]
        [TestCaseGeneric(typeof(string) , PropertyfriendlyName)]
        [TestCaseGeneric(typeof(string) , Propertyportal)]
        [TestCaseGeneric(typeof(AuthProviderType) , PropertyproviderType)]
        [TestCaseGeneric(typeof(string) , PropertyregistrationHandler)]
        public void AUT_AuthProvider_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AuthProvider, T>(_authProviderInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AuthProvider) => Property (consumerKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AuthProvider_Public_Class_consumerKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyconsumerKey);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AuthProvider) => Property (consumerSecret) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AuthProvider_Public_Class_consumerSecret_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyconsumerSecret);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AuthProvider) => Property (errorUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AuthProvider_Public_Class_errorUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyerrorUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AuthProvider) => Property (executionUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AuthProvider_Public_Class_executionUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexecutionUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AuthProvider) => Property (friendlyName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AuthProvider_Public_Class_friendlyName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfriendlyName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AuthProvider) => Property (portal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AuthProvider_Public_Class_portal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyportal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AuthProvider) => Property (providerType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AuthProvider_providerType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyproviderType);
            Action currentAction = () => propertyInfo.SetValue(_authProviderInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AuthProvider) => Property (providerType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AuthProvider_Public_Class_providerType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyproviderType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (AuthProvider) => Property (registrationHandler) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AuthProvider_Public_Class_registrationHandler_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyregistrationHandler);

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