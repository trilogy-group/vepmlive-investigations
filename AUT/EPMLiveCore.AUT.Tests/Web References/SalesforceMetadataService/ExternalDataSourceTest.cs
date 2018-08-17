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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ExternalDataSource" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ExternalDataSourceTest : AbstractBaseSetupTypedTest<ExternalDataSource>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ExternalDataSource) Initializer

        private const string PropertyapiKey = "apiKey";
        private const string Propertycertificate = "certificate";
        private const string Propertyendpoint = "endpoint";
        private const string Propertylabel = "label";
        private const string Propertypassword = "password";
        private const string PropertyprincipalType = "principalType";
        private const string Propertyprotocol = "protocol";
        private const string Propertyrepository = "repository";
        private const string Propertytype = "type";
        private const string Propertyusername = "username";
        private const string Propertyversion = "version";
        private const string FieldapiKeyField = "apiKeyField";
        private const string FieldcertificateField = "certificateField";
        private const string FieldendpointField = "endpointField";
        private const string FieldlabelField = "labelField";
        private const string FieldpasswordField = "passwordField";
        private const string FieldprincipalTypeField = "principalTypeField";
        private const string FieldprotocolField = "protocolField";
        private const string FieldrepositoryField = "repositoryField";
        private const string FieldtypeField = "typeField";
        private const string FieldusernameField = "usernameField";
        private const string FieldversionField = "versionField";
        private Type _externalDataSourceInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ExternalDataSource _externalDataSourceInstance;
        private ExternalDataSource _externalDataSourceInstanceFixture;

        #region General Initializer : Class (ExternalDataSource) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ExternalDataSource" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _externalDataSourceInstanceType = typeof(ExternalDataSource);
            _externalDataSourceInstanceFixture = Create(true);
            _externalDataSourceInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ExternalDataSource)

        #region General Initializer : Class (ExternalDataSource) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ExternalDataSource" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyapiKey)]
        [TestCase(Propertycertificate)]
        [TestCase(Propertyendpoint)]
        [TestCase(Propertylabel)]
        [TestCase(Propertypassword)]
        [TestCase(PropertyprincipalType)]
        [TestCase(Propertyprotocol)]
        [TestCase(Propertyrepository)]
        [TestCase(Propertytype)]
        [TestCase(Propertyusername)]
        [TestCase(Propertyversion)]
        public void AUT_ExternalDataSource_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_externalDataSourceInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ExternalDataSource) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ExternalDataSource" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapiKeyField)]
        [TestCase(FieldcertificateField)]
        [TestCase(FieldendpointField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldpasswordField)]
        [TestCase(FieldprincipalTypeField)]
        [TestCase(FieldprotocolField)]
        [TestCase(FieldrepositoryField)]
        [TestCase(FieldtypeField)]
        [TestCase(FieldusernameField)]
        [TestCase(FieldversionField)]
        public void AUT_ExternalDataSource_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_externalDataSourceInstanceFixture, 
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
        ///     Class (<see cref="ExternalDataSource" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ExternalDataSource_Is_Instance_Present_Test()
        {
            // Assert
            _externalDataSourceInstanceType.ShouldNotBeNull();
            _externalDataSourceInstance.ShouldNotBeNull();
            _externalDataSourceInstanceFixture.ShouldNotBeNull();
            _externalDataSourceInstance.ShouldBeAssignableTo<ExternalDataSource>();
            _externalDataSourceInstanceFixture.ShouldBeAssignableTo<ExternalDataSource>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ExternalDataSource) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ExternalDataSource_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ExternalDataSource instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _externalDataSourceInstanceType.ShouldNotBeNull();
            _externalDataSourceInstance.ShouldNotBeNull();
            _externalDataSourceInstanceFixture.ShouldNotBeNull();
            _externalDataSourceInstance.ShouldBeAssignableTo<ExternalDataSource>();
            _externalDataSourceInstanceFixture.ShouldBeAssignableTo<ExternalDataSource>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ExternalDataSource) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyapiKey)]
        [TestCaseGeneric(typeof(string) , Propertycertificate)]
        [TestCaseGeneric(typeof(string) , Propertyendpoint)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertypassword)]
        [TestCaseGeneric(typeof(ExternalPrincipalType) , PropertyprincipalType)]
        [TestCaseGeneric(typeof(AuthenticationProtocol) , Propertyprotocol)]
        [TestCaseGeneric(typeof(string) , Propertyrepository)]
        [TestCaseGeneric(typeof(ExternalDataSourceType) , Propertytype)]
        [TestCaseGeneric(typeof(string) , Propertyusername)]
        [TestCaseGeneric(typeof(string) , Propertyversion)]
        public void AUT_ExternalDataSource_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ExternalDataSource, T>(_externalDataSourceInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (apiKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_Public_Class_apiKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyapiKey);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (certificate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_Public_Class_certificate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycertificate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (endpoint) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_Public_Class_endpoint_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyendpoint);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (password) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_Public_Class_password_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertypassword);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (principalType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_principalType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyprincipalType);
            Action currentAction = () => propertyInfo.SetValue(_externalDataSourceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (principalType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_Public_Class_principalType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyprincipalType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (protocol) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_protocol_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyprotocol);
            Action currentAction = () => propertyInfo.SetValue(_externalDataSourceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (protocol) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_Public_Class_protocol_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyprotocol);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (repository) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_Public_Class_repository_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyrepository);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (type) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytype);
            Action currentAction = () => propertyInfo.SetValue(_externalDataSourceInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytype);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (username) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_Public_Class_username_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyusername);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ExternalDataSource) => Property (version) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ExternalDataSource_Public_Class_version_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyversion);

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