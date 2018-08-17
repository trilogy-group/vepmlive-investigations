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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.WebLinkTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WebLinkTranslationTest : AbstractBaseSetupTypedTest<WebLinkTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WebLinkTranslation) Initializer

        private const string Propertylabel = "label";
        private const string Propertyname = "name";
        private const string FieldlabelField = "labelField";
        private const string FieldnameField = "nameField";
        private Type _webLinkTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WebLinkTranslation _webLinkTranslationInstance;
        private WebLinkTranslation _webLinkTranslationInstanceFixture;

        #region General Initializer : Class (WebLinkTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WebLinkTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _webLinkTranslationInstanceType = typeof(WebLinkTranslation);
            _webLinkTranslationInstanceFixture = Create(true);
            _webLinkTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WebLinkTranslation)

        #region General Initializer : Class (WebLinkTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WebLinkTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylabel)]
        [TestCase(Propertyname)]
        public void AUT_WebLinkTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_webLinkTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WebLinkTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WebLinkTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlabelField)]
        [TestCase(FieldnameField)]
        public void AUT_WebLinkTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_webLinkTranslationInstanceFixture, 
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
        ///     Class (<see cref="WebLinkTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WebLinkTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _webLinkTranslationInstanceType.ShouldNotBeNull();
            _webLinkTranslationInstance.ShouldNotBeNull();
            _webLinkTranslationInstanceFixture.ShouldNotBeNull();
            _webLinkTranslationInstance.ShouldBeAssignableTo<WebLinkTranslation>();
            _webLinkTranslationInstanceFixture.ShouldBeAssignableTo<WebLinkTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WebLinkTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WebLinkTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WebLinkTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _webLinkTranslationInstanceType.ShouldNotBeNull();
            _webLinkTranslationInstance.ShouldNotBeNull();
            _webLinkTranslationInstanceFixture.ShouldNotBeNull();
            _webLinkTranslationInstance.ShouldBeAssignableTo<WebLinkTranslation>();
            _webLinkTranslationInstanceFixture.ShouldBeAssignableTo<WebLinkTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WebLinkTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_WebLinkTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WebLinkTranslation, T>(_webLinkTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (WebLinkTranslation) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLinkTranslation_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WebLinkTranslation) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLinkTranslation_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

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