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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.WebLink" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class WebLinkTest : AbstractBaseSetupTypedTest<WebLink>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (WebLink) Initializer

        private const string Propertyavailability = "availability";
        private const string Propertydescription = "description";
        private const string PropertydisplayType = "displayType";
        private const string PropertyencodingKey = "encodingKey";
        private const string PropertyencodingKeySpecified = "encodingKeySpecified";
        private const string PropertyhasMenubar = "hasMenubar";
        private const string PropertyhasMenubarSpecified = "hasMenubarSpecified";
        private const string PropertyhasScrollbars = "hasScrollbars";
        private const string PropertyhasScrollbarsSpecified = "hasScrollbarsSpecified";
        private const string PropertyhasToolbar = "hasToolbar";
        private const string PropertyhasToolbarSpecified = "hasToolbarSpecified";
        private const string Propertyheight = "height";
        private const string PropertyheightSpecified = "heightSpecified";
        private const string PropertyisResizable = "isResizable";
        private const string PropertyisResizableSpecified = "isResizableSpecified";
        private const string PropertylinkType = "linkType";
        private const string PropertymasterLabel = "masterLabel";
        private const string PropertyopenType = "openType";
        private const string Propertypage = "page";
        private const string Propertyposition = "position";
        private const string PropertypositionSpecified = "positionSpecified";
        private const string PropertyrequireRowSelection = "requireRowSelection";
        private const string PropertyrequireRowSelectionSpecified = "requireRowSelectionSpecified";
        private const string Propertyscontrol = "scontrol";
        private const string PropertyshowsLocation = "showsLocation";
        private const string PropertyshowsLocationSpecified = "showsLocationSpecified";
        private const string PropertyshowsStatus = "showsStatus";
        private const string PropertyshowsStatusSpecified = "showsStatusSpecified";
        private const string Propertyurl = "url";
        private const string Propertywidth = "width";
        private const string PropertywidthSpecified = "widthSpecified";
        private const string FieldavailabilityField = "availabilityField";
        private const string FielddescriptionField = "descriptionField";
        private const string FielddisplayTypeField = "displayTypeField";
        private const string FieldencodingKeyField = "encodingKeyField";
        private const string FieldencodingKeyFieldSpecified = "encodingKeyFieldSpecified";
        private const string FieldhasMenubarField = "hasMenubarField";
        private const string FieldhasMenubarFieldSpecified = "hasMenubarFieldSpecified";
        private const string FieldhasScrollbarsField = "hasScrollbarsField";
        private const string FieldhasScrollbarsFieldSpecified = "hasScrollbarsFieldSpecified";
        private const string FieldhasToolbarField = "hasToolbarField";
        private const string FieldhasToolbarFieldSpecified = "hasToolbarFieldSpecified";
        private const string FieldheightField = "heightField";
        private const string FieldheightFieldSpecified = "heightFieldSpecified";
        private const string FieldisResizableField = "isResizableField";
        private const string FieldisResizableFieldSpecified = "isResizableFieldSpecified";
        private const string FieldlinkTypeField = "linkTypeField";
        private const string FieldmasterLabelField = "masterLabelField";
        private const string FieldopenTypeField = "openTypeField";
        private const string FieldpageField = "pageField";
        private const string FieldpositionField = "positionField";
        private const string FieldpositionFieldSpecified = "positionFieldSpecified";
        private const string FieldprotectedField = "protectedField";
        private const string FieldrequireRowSelectionField = "requireRowSelectionField";
        private const string FieldrequireRowSelectionFieldSpecified = "requireRowSelectionFieldSpecified";
        private const string FieldscontrolField = "scontrolField";
        private const string FieldshowsLocationField = "showsLocationField";
        private const string FieldshowsLocationFieldSpecified = "showsLocationFieldSpecified";
        private const string FieldshowsStatusField = "showsStatusField";
        private const string FieldshowsStatusFieldSpecified = "showsStatusFieldSpecified";
        private const string FieldurlField = "urlField";
        private const string FieldwidthField = "widthField";
        private const string FieldwidthFieldSpecified = "widthFieldSpecified";
        private Type _webLinkInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private WebLink _webLinkInstance;
        private WebLink _webLinkInstanceFixture;

        #region General Initializer : Class (WebLink) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="WebLink" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _webLinkInstanceType = typeof(WebLink);
            _webLinkInstanceFixture = Create(true);
            _webLinkInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (WebLink)

        #region General Initializer : Class (WebLink) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="WebLink" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyavailability)]
        [TestCase(Propertydescription)]
        [TestCase(PropertydisplayType)]
        [TestCase(PropertyencodingKey)]
        [TestCase(PropertyencodingKeySpecified)]
        [TestCase(PropertyhasMenubar)]
        [TestCase(PropertyhasMenubarSpecified)]
        [TestCase(PropertyhasScrollbars)]
        [TestCase(PropertyhasScrollbarsSpecified)]
        [TestCase(PropertyhasToolbar)]
        [TestCase(PropertyhasToolbarSpecified)]
        [TestCase(Propertyheight)]
        [TestCase(PropertyheightSpecified)]
        [TestCase(PropertyisResizable)]
        [TestCase(PropertyisResizableSpecified)]
        [TestCase(PropertylinkType)]
        [TestCase(PropertymasterLabel)]
        [TestCase(PropertyopenType)]
        [TestCase(Propertypage)]
        [TestCase(Propertyposition)]
        [TestCase(PropertypositionSpecified)]
        [TestCase(PropertyrequireRowSelection)]
        [TestCase(PropertyrequireRowSelectionSpecified)]
        [TestCase(Propertyscontrol)]
        [TestCase(PropertyshowsLocation)]
        [TestCase(PropertyshowsLocationSpecified)]
        [TestCase(PropertyshowsStatus)]
        [TestCase(PropertyshowsStatusSpecified)]
        [TestCase(Propertyurl)]
        [TestCase(Propertywidth)]
        [TestCase(PropertywidthSpecified)]
        public void AUT_WebLink_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_webLinkInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (WebLink) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="WebLink" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldavailabilityField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FielddisplayTypeField)]
        [TestCase(FieldencodingKeyField)]
        [TestCase(FieldencodingKeyFieldSpecified)]
        [TestCase(FieldhasMenubarField)]
        [TestCase(FieldhasMenubarFieldSpecified)]
        [TestCase(FieldhasScrollbarsField)]
        [TestCase(FieldhasScrollbarsFieldSpecified)]
        [TestCase(FieldhasToolbarField)]
        [TestCase(FieldhasToolbarFieldSpecified)]
        [TestCase(FieldheightField)]
        [TestCase(FieldheightFieldSpecified)]
        [TestCase(FieldisResizableField)]
        [TestCase(FieldisResizableFieldSpecified)]
        [TestCase(FieldlinkTypeField)]
        [TestCase(FieldmasterLabelField)]
        [TestCase(FieldopenTypeField)]
        [TestCase(FieldpageField)]
        [TestCase(FieldpositionField)]
        [TestCase(FieldpositionFieldSpecified)]
        [TestCase(FieldprotectedField)]
        [TestCase(FieldrequireRowSelectionField)]
        [TestCase(FieldrequireRowSelectionFieldSpecified)]
        [TestCase(FieldscontrolField)]
        [TestCase(FieldshowsLocationField)]
        [TestCase(FieldshowsLocationFieldSpecified)]
        [TestCase(FieldshowsStatusField)]
        [TestCase(FieldshowsStatusFieldSpecified)]
        [TestCase(FieldurlField)]
        [TestCase(FieldwidthField)]
        [TestCase(FieldwidthFieldSpecified)]
        public void AUT_WebLink_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_webLinkInstanceFixture, 
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
        ///     Class (<see cref="WebLink" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_WebLink_Is_Instance_Present_Test()
        {
            // Assert
            _webLinkInstanceType.ShouldNotBeNull();
            _webLinkInstance.ShouldNotBeNull();
            _webLinkInstanceFixture.ShouldNotBeNull();
            _webLinkInstance.ShouldBeAssignableTo<WebLink>();
            _webLinkInstanceFixture.ShouldBeAssignableTo<WebLink>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (WebLink) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_WebLink_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            WebLink instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _webLinkInstanceType.ShouldNotBeNull();
            _webLinkInstance.ShouldNotBeNull();
            _webLinkInstanceFixture.ShouldNotBeNull();
            _webLinkInstance.ShouldBeAssignableTo<WebLink>();
            _webLinkInstanceFixture.ShouldBeAssignableTo<WebLink>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (WebLink) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(WebLinkAvailability) , Propertyavailability)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(WebLinkDisplayType) , PropertydisplayType)]
        [TestCaseGeneric(typeof(Encoding) , PropertyencodingKey)]
        [TestCaseGeneric(typeof(bool) , PropertyencodingKeySpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyhasMenubar)]
        [TestCaseGeneric(typeof(bool) , PropertyhasMenubarSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyhasScrollbars)]
        [TestCaseGeneric(typeof(bool) , PropertyhasScrollbarsSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyhasToolbar)]
        [TestCaseGeneric(typeof(bool) , PropertyhasToolbarSpecified)]
        [TestCaseGeneric(typeof(int) , Propertyheight)]
        [TestCaseGeneric(typeof(bool) , PropertyheightSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyisResizable)]
        [TestCaseGeneric(typeof(bool) , PropertyisResizableSpecified)]
        [TestCaseGeneric(typeof(WebLinkType) , PropertylinkType)]
        [TestCaseGeneric(typeof(string) , PropertymasterLabel)]
        [TestCaseGeneric(typeof(WebLinkWindowType) , PropertyopenType)]
        [TestCaseGeneric(typeof(string) , Propertypage)]
        [TestCaseGeneric(typeof(WebLinkPosition) , Propertyposition)]
        [TestCaseGeneric(typeof(bool) , PropertypositionSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyrequireRowSelection)]
        [TestCaseGeneric(typeof(bool) , PropertyrequireRowSelectionSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyscontrol)]
        [TestCaseGeneric(typeof(bool) , PropertyshowsLocation)]
        [TestCaseGeneric(typeof(bool) , PropertyshowsLocationSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowsStatus)]
        [TestCaseGeneric(typeof(bool) , PropertyshowsStatusSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyurl)]
        [TestCaseGeneric(typeof(int) , Propertywidth)]
        [TestCaseGeneric(typeof(bool) , PropertywidthSpecified)]
        public void AUT_WebLink_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<WebLink, T>(_webLinkInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (WebLink) => Property (availability) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_availability_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyavailability);
            Action currentAction = () => propertyInfo.SetValue(_webLinkInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (availability) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_availability_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyavailability);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WebLink) => Property (displayType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_displayType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydisplayType);
            Action currentAction = () => propertyInfo.SetValue(_webLinkInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (displayType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_displayType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisplayType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (encodingKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_encodingKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyencodingKey);
            Action currentAction = () => propertyInfo.SetValue(_webLinkInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (encodingKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_encodingKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyencodingKey);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (encodingKeySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_encodingKeySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyencodingKeySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (hasMenubar) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_hasMenubar_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhasMenubar);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (hasMenubarSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_hasMenubarSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhasMenubarSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (hasScrollbars) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_hasScrollbars_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhasScrollbars);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (hasScrollbarsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_hasScrollbarsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhasScrollbarsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (hasToolbar) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_hasToolbar_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhasToolbar);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (hasToolbarSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_hasToolbarSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhasToolbarSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (height) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_height_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyheight);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (heightSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_heightSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyheightSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (isResizable) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_isResizable_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisResizable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (isResizableSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_isResizableSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisResizableSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (linkType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_linkType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylinkType);
            Action currentAction = () => propertyInfo.SetValue(_webLinkInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (linkType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_linkType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylinkType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (masterLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_masterLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymasterLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (openType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_openType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyopenType);
            Action currentAction = () => propertyInfo.SetValue(_webLinkInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (openType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_openType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyopenType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (page) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_page_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WebLink) => Property (position) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_position_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyposition);
            Action currentAction = () => propertyInfo.SetValue(_webLinkInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (position) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_position_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyposition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (positionSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_positionSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypositionSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (requireRowSelection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_requireRowSelection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrequireRowSelection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (requireRowSelectionSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_requireRowSelectionSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrequireRowSelectionSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (scontrol) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_scontrol_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WebLink) => Property (showsLocation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_showsLocation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowsLocation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (showsLocationSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_showsLocationSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowsLocationSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (showsStatus) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_showsStatus_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowsStatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (showsStatusSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_showsStatusSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowsStatusSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (url) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_url_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (WebLink) => Property (width) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_width_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertywidth);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (WebLink) => Property (widthSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_WebLink_Public_Class_widthSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertywidthSpecified);

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