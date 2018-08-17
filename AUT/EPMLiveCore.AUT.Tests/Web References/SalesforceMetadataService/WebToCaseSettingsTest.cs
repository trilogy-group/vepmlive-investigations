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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.WebToCaseSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WebToCaseSettingsTest : AbstractBaseSetupTypedTest<WebToCaseSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WebToCaseSettings) Initializer

        private const string PropertycaseOrigin = "caseOrigin";
        private const string PropertydefaultResponseTemplate = "defaultResponseTemplate";
        private const string PropertyenableWebToCase = "enableWebToCase";
        private const string PropertyenableWebToCaseSpecified = "enableWebToCaseSpecified";
        private const string FieldcaseOriginField = "caseOriginField";
        private const string FielddefaultResponseTemplateField = "defaultResponseTemplateField";
        private const string FieldenableWebToCaseField = "enableWebToCaseField";
        private const string FieldenableWebToCaseFieldSpecified = "enableWebToCaseFieldSpecified";
        private Type _webToCaseSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WebToCaseSettings _webToCaseSettingsInstance;
        private WebToCaseSettings _webToCaseSettingsInstanceFixture;

        #region General Initializer : Class (WebToCaseSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WebToCaseSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _webToCaseSettingsInstanceType = typeof(WebToCaseSettings);
            _webToCaseSettingsInstanceFixture = Create(true);
            _webToCaseSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WebToCaseSettings)

        #region General Initializer : Class (WebToCaseSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WebToCaseSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycaseOrigin)]
        [TestCase(PropertydefaultResponseTemplate)]
        [TestCase(PropertyenableWebToCase)]
        [TestCase(PropertyenableWebToCaseSpecified)]
        public void AUT_WebToCaseSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_webToCaseSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WebToCaseSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WebToCaseSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcaseOriginField)]
        [TestCase(FielddefaultResponseTemplateField)]
        [TestCase(FieldenableWebToCaseField)]
        [TestCase(FieldenableWebToCaseFieldSpecified)]
        public void AUT_WebToCaseSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_webToCaseSettingsInstanceFixture, 
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
        ///     Class (<see cref="WebToCaseSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WebToCaseSettings_Is_Instance_Present_Test()
        {
            // Assert
            _webToCaseSettingsInstanceType.ShouldNotBeNull();
            _webToCaseSettingsInstance.ShouldNotBeNull();
            _webToCaseSettingsInstanceFixture.ShouldNotBeNull();
            _webToCaseSettingsInstance.ShouldBeAssignableTo<WebToCaseSettings>();
            _webToCaseSettingsInstanceFixture.ShouldBeAssignableTo<WebToCaseSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WebToCaseSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WebToCaseSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WebToCaseSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _webToCaseSettingsInstanceType.ShouldNotBeNull();
            _webToCaseSettingsInstance.ShouldNotBeNull();
            _webToCaseSettingsInstanceFixture.ShouldNotBeNull();
            _webToCaseSettingsInstance.ShouldBeAssignableTo<WebToCaseSettings>();
            _webToCaseSettingsInstanceFixture.ShouldBeAssignableTo<WebToCaseSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WebToCaseSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertycaseOrigin)]
        [TestCaseGeneric(typeof(string) , PropertydefaultResponseTemplate)]
        [TestCaseGeneric(typeof(bool) , PropertyenableWebToCase)]
        [TestCaseGeneric(typeof(bool) , PropertyenableWebToCaseSpecified)]
        public void AUT_WebToCaseSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WebToCaseSettings, T>(_webToCaseSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WebToCaseSettings) => Property (caseOrigin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebToCaseSettings_Public_Class_caseOrigin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WebToCaseSettings) => Property (defaultResponseTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebToCaseSettings_Public_Class_defaultResponseTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultResponseTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebToCaseSettings) => Property (enableWebToCase) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebToCaseSettings_Public_Class_enableWebToCase_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableWebToCase);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebToCaseSettings) => Property (enableWebToCaseSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebToCaseSettings_Public_Class_enableWebToCaseSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableWebToCaseSpecified);

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