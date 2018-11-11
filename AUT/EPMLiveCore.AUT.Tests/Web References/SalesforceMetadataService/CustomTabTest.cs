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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomTab" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomTabTest : AbstractBaseSetupTypedTest<CustomTab>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomTab) Initializer

        private const string PropertycustomObject = "customObject";
        private const string PropertycustomObjectSpecified = "customObjectSpecified";
        private const string Propertydescription = "description";
        private const string PropertyframeHeight = "frameHeight";
        private const string PropertyframeHeightSpecified = "frameHeightSpecified";
        private const string PropertyhasSidebar = "hasSidebar";
        private const string PropertyhasSidebarSpecified = "hasSidebarSpecified";
        private const string Propertyicon = "icon";
        private const string Propertylabel = "label";
        private const string PropertymobileReady = "mobileReady";
        private const string Propertymotif = "motif";
        private const string Propertypage = "page";
        private const string Propertyscontrol = "scontrol";
        private const string PropertysplashPageLink = "splashPageLink";
        private const string Propertyurl = "url";
        private const string PropertyurlEncodingKey = "urlEncodingKey";
        private const string PropertyurlEncodingKeySpecified = "urlEncodingKeySpecified";
        private const string FieldcustomObjectField = "customObjectField";
        private const string FieldcustomObjectFieldSpecified = "customObjectFieldSpecified";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldframeHeightField = "frameHeightField";
        private const string FieldframeHeightFieldSpecified = "frameHeightFieldSpecified";
        private const string FieldhasSidebarField = "hasSidebarField";
        private const string FieldhasSidebarFieldSpecified = "hasSidebarFieldSpecified";
        private const string FieldiconField = "iconField";
        private const string FieldlabelField = "labelField";
        private const string FieldmobileReadyField = "mobileReadyField";
        private const string FieldmotifField = "motifField";
        private const string FieldpageField = "pageField";
        private const string FieldscontrolField = "scontrolField";
        private const string FieldsplashPageLinkField = "splashPageLinkField";
        private const string FieldurlField = "urlField";
        private const string FieldurlEncodingKeyField = "urlEncodingKeyField";
        private const string FieldurlEncodingKeyFieldSpecified = "urlEncodingKeyFieldSpecified";
        private Type _customTabInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomTab _customTabInstance;
        private CustomTab _customTabInstanceFixture;

        #region General Initializer : Class (CustomTab) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomTab" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customTabInstanceType = typeof(CustomTab);
            _customTabInstanceFixture = Create(true);
            _customTabInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomTab)

        #region General Initializer : Class (CustomTab) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomTab" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycustomObject)]
        [TestCase(PropertycustomObjectSpecified)]
        [TestCase(Propertydescription)]
        [TestCase(PropertyframeHeight)]
        [TestCase(PropertyframeHeightSpecified)]
        [TestCase(PropertyhasSidebar)]
        [TestCase(PropertyhasSidebarSpecified)]
        [TestCase(Propertyicon)]
        [TestCase(Propertylabel)]
        [TestCase(PropertymobileReady)]
        [TestCase(Propertymotif)]
        [TestCase(Propertypage)]
        [TestCase(Propertyscontrol)]
        [TestCase(PropertysplashPageLink)]
        [TestCase(Propertyurl)]
        [TestCase(PropertyurlEncodingKey)]
        [TestCase(PropertyurlEncodingKeySpecified)]
        public void AUT_CustomTab_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customTabInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomTab) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomTab" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcustomObjectField)]
        [TestCase(FieldcustomObjectFieldSpecified)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldframeHeightField)]
        [TestCase(FieldframeHeightFieldSpecified)]
        [TestCase(FieldhasSidebarField)]
        [TestCase(FieldhasSidebarFieldSpecified)]
        [TestCase(FieldiconField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldmobileReadyField)]
        [TestCase(FieldmotifField)]
        [TestCase(FieldpageField)]
        [TestCase(FieldscontrolField)]
        [TestCase(FieldsplashPageLinkField)]
        [TestCase(FieldurlField)]
        [TestCase(FieldurlEncodingKeyField)]
        [TestCase(FieldurlEncodingKeyFieldSpecified)]
        public void AUT_CustomTab_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customTabInstanceFixture, 
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
        ///     Class (<see cref="CustomTab" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomTab_Is_Instance_Present_Test()
        {
            // Assert
            _customTabInstanceType.ShouldNotBeNull();
            _customTabInstance.ShouldNotBeNull();
            _customTabInstanceFixture.ShouldNotBeNull();
            _customTabInstance.ShouldBeAssignableTo<CustomTab>();
            _customTabInstanceFixture.ShouldBeAssignableTo<CustomTab>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomTab) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomTab_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomTab instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customTabInstanceType.ShouldNotBeNull();
            _customTabInstance.ShouldNotBeNull();
            _customTabInstanceFixture.ShouldNotBeNull();
            _customTabInstance.ShouldBeAssignableTo<CustomTab>();
            _customTabInstanceFixture.ShouldBeAssignableTo<CustomTab>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomTab) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertycustomObject)]
        [TestCaseGeneric(typeof(bool) , PropertycustomObjectSpecified)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(int) , PropertyframeHeight)]
        [TestCaseGeneric(typeof(bool) , PropertyframeHeightSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyhasSidebar)]
        [TestCaseGeneric(typeof(bool) , PropertyhasSidebarSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyicon)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(bool) , PropertymobileReady)]
        [TestCaseGeneric(typeof(string) , Propertymotif)]
        [TestCaseGeneric(typeof(string) , Propertypage)]
        [TestCaseGeneric(typeof(string) , Propertyscontrol)]
        [TestCaseGeneric(typeof(string) , PropertysplashPageLink)]
        [TestCaseGeneric(typeof(string) , Propertyurl)]
        [TestCaseGeneric(typeof(Encoding) , PropertyurlEncodingKey)]
        [TestCaseGeneric(typeof(bool) , PropertyurlEncodingKeySpecified)]
        public void AUT_CustomTab_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomTab, T>(_customTabInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (customObject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_customObject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomObject);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (customObjectSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_customObjectSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomObjectSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (frameHeight) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_frameHeight_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyframeHeight);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (frameHeightSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_frameHeightSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyframeHeightSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (hasSidebar) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_hasSidebar_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhasSidebar);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (hasSidebarSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_hasSidebarSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhasSidebarSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (icon) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_icon_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyicon);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomTab) => Property (mobileReady) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_mobileReady_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymobileReady);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (motif) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_motif_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymotif);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (page) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_page_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertypage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (scontrol) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_scontrol_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyscontrol);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (splashPageLink) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_splashPageLink_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysplashPageLink);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (url) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_url_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyurl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (urlEncodingKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_urlEncodingKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyurlEncodingKey);
            Action currentAction = () => propertyInfo.SetValue(_customTabInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (urlEncodingKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_urlEncodingKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyurlEncodingKey);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomTab) => Property (urlEncodingKeySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomTab_Public_Class_urlEncodingKeySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyurlEncodingKeySpecified);

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