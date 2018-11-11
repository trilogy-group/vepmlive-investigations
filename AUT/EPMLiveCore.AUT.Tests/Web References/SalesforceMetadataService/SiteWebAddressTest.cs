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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.SiteWebAddress" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SiteWebAddressTest : AbstractBaseSetupTypedTest<SiteWebAddress>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SiteWebAddress) Initializer

        private const string Propertycertificate = "certificate";
        private const string PropertydomainName = "domainName";
        private const string Propertyprimary = "primary";
        private const string FieldcertificateField = "certificateField";
        private const string FielddomainNameField = "domainNameField";
        private const string FieldprimaryField = "primaryField";
        private Type _siteWebAddressInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SiteWebAddress _siteWebAddressInstance;
        private SiteWebAddress _siteWebAddressInstanceFixture;

        #region General Initializer : Class (SiteWebAddress) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SiteWebAddress" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _siteWebAddressInstanceType = typeof(SiteWebAddress);
            _siteWebAddressInstanceFixture = Create(true);
            _siteWebAddressInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SiteWebAddress)

        #region General Initializer : Class (SiteWebAddress) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SiteWebAddress" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycertificate)]
        [TestCase(PropertydomainName)]
        [TestCase(Propertyprimary)]
        public void AUT_SiteWebAddress_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_siteWebAddressInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SiteWebAddress) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SiteWebAddress" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcertificateField)]
        [TestCase(FielddomainNameField)]
        [TestCase(FieldprimaryField)]
        public void AUT_SiteWebAddress_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_siteWebAddressInstanceFixture, 
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
        ///     Class (<see cref="SiteWebAddress" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SiteWebAddress_Is_Instance_Present_Test()
        {
            // Assert
            _siteWebAddressInstanceType.ShouldNotBeNull();
            _siteWebAddressInstance.ShouldNotBeNull();
            _siteWebAddressInstanceFixture.ShouldNotBeNull();
            _siteWebAddressInstance.ShouldBeAssignableTo<SiteWebAddress>();
            _siteWebAddressInstanceFixture.ShouldBeAssignableTo<SiteWebAddress>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SiteWebAddress) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SiteWebAddress_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SiteWebAddress instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _siteWebAddressInstanceType.ShouldNotBeNull();
            _siteWebAddressInstance.ShouldNotBeNull();
            _siteWebAddressInstanceFixture.ShouldNotBeNull();
            _siteWebAddressInstance.ShouldBeAssignableTo<SiteWebAddress>();
            _siteWebAddressInstanceFixture.ShouldBeAssignableTo<SiteWebAddress>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SiteWebAddress) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertycertificate)]
        [TestCaseGeneric(typeof(string) , PropertydomainName)]
        [TestCaseGeneric(typeof(bool) , Propertyprimary)]
        public void AUT_SiteWebAddress_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SiteWebAddress, T>(_siteWebAddressInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SiteWebAddress) => Property (certificate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SiteWebAddress_Public_Class_certificate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (SiteWebAddress) => Property (domainName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SiteWebAddress_Public_Class_domainName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydomainName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SiteWebAddress) => Property (primary) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SiteWebAddress_Public_Class_primary_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyprimary);

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