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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomSite" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomSiteTest : AbstractBaseSetupTypedTest<CustomSite>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomSite) Initializer

        private const string Propertyactive = "active";
        private const string PropertyallowHomePage = "allowHomePage";
        private const string PropertyallowStandardAnswersPages = "allowStandardAnswersPages";
        private const string PropertyallowStandardAnswersPagesSpecified = "allowStandardAnswersPagesSpecified";
        private const string PropertyallowStandardIdeasPages = "allowStandardIdeasPages";
        private const string PropertyallowStandardLookups = "allowStandardLookups";
        private const string PropertyallowStandardSearch = "allowStandardSearch";
        private const string PropertyanalyticsTrackingCode = "analyticsTrackingCode";
        private const string PropertyauthorizationRequiredPage = "authorizationRequiredPage";
        private const string PropertybandwidthExceededPage = "bandwidthExceededPage";
        private const string PropertychangePasswordPage = "changePasswordPage";
        private const string PropertychatterAnswersForgotPasswordConfirmPage = "chatterAnswersForgotPasswordConfirmPage";
        private const string PropertychatterAnswersForgotPasswordPage = "chatterAnswersForgotPasswordPage";
        private const string PropertychatterAnswersHelpPage = "chatterAnswersHelpPage";
        private const string PropertychatterAnswersLoginPage = "chatterAnswersLoginPage";
        private const string PropertychatterAnswersRegistrationPage = "chatterAnswersRegistrationPage";
        private const string PropertycustomWebAddresses = "customWebAddresses";
        private const string Propertydescription = "description";
        private const string PropertyfavoriteIcon = "favoriteIcon";
        private const string PropertyfileNotFoundPage = "fileNotFoundPage";
        private const string PropertygenericErrorPage = "genericErrorPage";
        private const string PropertyguestProfile = "guestProfile";
        private const string PropertyinMaintenancePage = "inMaintenancePage";
        private const string PropertyinactiveIndexPage = "inactiveIndexPage";
        private const string PropertyindexPage = "indexPage";
        private const string PropertymasterLabel = "masterLabel";
        private const string PropertymyProfilePage = "myProfilePage";
        private const string Propertyportal = "portal";
        private const string PropertyrequireInsecurePortalAccess = "requireInsecurePortalAccess";
        private const string PropertyrobotsTxtPage = "robotsTxtPage";
        private const string PropertyrootComponent = "rootComponent";
        private const string PropertyserverIsDown = "serverIsDown";
        private const string PropertysiteAdmin = "siteAdmin";
        private const string PropertysiteRedirectMappings = "siteRedirectMappings";
        private const string PropertysiteTemplate = "siteTemplate";
        private const string PropertysiteType = "siteType";
        private const string Propertysubdomain = "subdomain";
        private const string PropertyurlPathPrefix = "urlPathPrefix";
        private const string FieldactiveField = "activeField";
        private const string FieldallowHomePageField = "allowHomePageField";
        private const string FieldallowStandardAnswersPagesField = "allowStandardAnswersPagesField";
        private const string FieldallowStandardAnswersPagesFieldSpecified = "allowStandardAnswersPagesFieldSpecified";
        private const string FieldallowStandardIdeasPagesField = "allowStandardIdeasPagesField";
        private const string FieldallowStandardLookupsField = "allowStandardLookupsField";
        private const string FieldallowStandardSearchField = "allowStandardSearchField";
        private const string FieldanalyticsTrackingCodeField = "analyticsTrackingCodeField";
        private const string FieldauthorizationRequiredPageField = "authorizationRequiredPageField";
        private const string FieldbandwidthExceededPageField = "bandwidthExceededPageField";
        private const string FieldchangePasswordPageField = "changePasswordPageField";
        private const string FieldchatterAnswersForgotPasswordConfirmPageField = "chatterAnswersForgotPasswordConfirmPageField";
        private const string FieldchatterAnswersForgotPasswordPageField = "chatterAnswersForgotPasswordPageField";
        private const string FieldchatterAnswersHelpPageField = "chatterAnswersHelpPageField";
        private const string FieldchatterAnswersLoginPageField = "chatterAnswersLoginPageField";
        private const string FieldchatterAnswersRegistrationPageField = "chatterAnswersRegistrationPageField";
        private const string FieldcustomWebAddressesField = "customWebAddressesField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldfavoriteIconField = "favoriteIconField";
        private const string FieldfileNotFoundPageField = "fileNotFoundPageField";
        private const string FieldgenericErrorPageField = "genericErrorPageField";
        private const string FieldguestProfileField = "guestProfileField";
        private const string FieldinMaintenancePageField = "inMaintenancePageField";
        private const string FieldinactiveIndexPageField = "inactiveIndexPageField";
        private const string FieldindexPageField = "indexPageField";
        private const string FieldmasterLabelField = "masterLabelField";
        private const string FieldmyProfilePageField = "myProfilePageField";
        private const string FieldportalField = "portalField";
        private const string FieldrequireInsecurePortalAccessField = "requireInsecurePortalAccessField";
        private const string FieldrobotsTxtPageField = "robotsTxtPageField";
        private const string FieldrootComponentField = "rootComponentField";
        private const string FieldserverIsDownField = "serverIsDownField";
        private const string FieldsiteAdminField = "siteAdminField";
        private const string FieldsiteRedirectMappingsField = "siteRedirectMappingsField";
        private const string FieldsiteTemplateField = "siteTemplateField";
        private const string FieldsiteTypeField = "siteTypeField";
        private const string FieldsubdomainField = "subdomainField";
        private const string FieldurlPathPrefixField = "urlPathPrefixField";
        private Type _customSiteInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomSite _customSiteInstance;
        private CustomSite _customSiteInstanceFixture;

        #region General Initializer : Class (CustomSite) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomSite" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customSiteInstanceType = typeof(CustomSite);
            _customSiteInstanceFixture = Create(true);
            _customSiteInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomSite)

        #region General Initializer : Class (CustomSite) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomSite" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyactive)]
        [TestCase(PropertyallowHomePage)]
        [TestCase(PropertyallowStandardAnswersPages)]
        [TestCase(PropertyallowStandardAnswersPagesSpecified)]
        [TestCase(PropertyallowStandardIdeasPages)]
        [TestCase(PropertyallowStandardLookups)]
        [TestCase(PropertyallowStandardSearch)]
        [TestCase(PropertyanalyticsTrackingCode)]
        [TestCase(PropertyauthorizationRequiredPage)]
        [TestCase(PropertybandwidthExceededPage)]
        [TestCase(PropertychangePasswordPage)]
        [TestCase(PropertychatterAnswersForgotPasswordConfirmPage)]
        [TestCase(PropertychatterAnswersForgotPasswordPage)]
        [TestCase(PropertychatterAnswersHelpPage)]
        [TestCase(PropertychatterAnswersLoginPage)]
        [TestCase(PropertychatterAnswersRegistrationPage)]
        [TestCase(PropertycustomWebAddresses)]
        [TestCase(Propertydescription)]
        [TestCase(PropertyfavoriteIcon)]
        [TestCase(PropertyfileNotFoundPage)]
        [TestCase(PropertygenericErrorPage)]
        [TestCase(PropertyguestProfile)]
        [TestCase(PropertyinMaintenancePage)]
        [TestCase(PropertyinactiveIndexPage)]
        [TestCase(PropertyindexPage)]
        [TestCase(PropertymasterLabel)]
        [TestCase(PropertymyProfilePage)]
        [TestCase(Propertyportal)]
        [TestCase(PropertyrequireInsecurePortalAccess)]
        [TestCase(PropertyrobotsTxtPage)]
        [TestCase(PropertyrootComponent)]
        [TestCase(PropertyserverIsDown)]
        [TestCase(PropertysiteAdmin)]
        [TestCase(PropertysiteRedirectMappings)]
        [TestCase(PropertysiteTemplate)]
        [TestCase(PropertysiteType)]
        [TestCase(Propertysubdomain)]
        [TestCase(PropertyurlPathPrefix)]
        public void AUT_CustomSite_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customSiteInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomSite) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomSite" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactiveField)]
        [TestCase(FieldallowHomePageField)]
        [TestCase(FieldallowStandardAnswersPagesField)]
        [TestCase(FieldallowStandardAnswersPagesFieldSpecified)]
        [TestCase(FieldallowStandardIdeasPagesField)]
        [TestCase(FieldallowStandardLookupsField)]
        [TestCase(FieldallowStandardSearchField)]
        [TestCase(FieldanalyticsTrackingCodeField)]
        [TestCase(FieldauthorizationRequiredPageField)]
        [TestCase(FieldbandwidthExceededPageField)]
        [TestCase(FieldchangePasswordPageField)]
        [TestCase(FieldchatterAnswersForgotPasswordConfirmPageField)]
        [TestCase(FieldchatterAnswersForgotPasswordPageField)]
        [TestCase(FieldchatterAnswersHelpPageField)]
        [TestCase(FieldchatterAnswersLoginPageField)]
        [TestCase(FieldchatterAnswersRegistrationPageField)]
        [TestCase(FieldcustomWebAddressesField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldfavoriteIconField)]
        [TestCase(FieldfileNotFoundPageField)]
        [TestCase(FieldgenericErrorPageField)]
        [TestCase(FieldguestProfileField)]
        [TestCase(FieldinMaintenancePageField)]
        [TestCase(FieldinactiveIndexPageField)]
        [TestCase(FieldindexPageField)]
        [TestCase(FieldmasterLabelField)]
        [TestCase(FieldmyProfilePageField)]
        [TestCase(FieldportalField)]
        [TestCase(FieldrequireInsecurePortalAccessField)]
        [TestCase(FieldrobotsTxtPageField)]
        [TestCase(FieldrootComponentField)]
        [TestCase(FieldserverIsDownField)]
        [TestCase(FieldsiteAdminField)]
        [TestCase(FieldsiteRedirectMappingsField)]
        [TestCase(FieldsiteTemplateField)]
        [TestCase(FieldsiteTypeField)]
        [TestCase(FieldsubdomainField)]
        [TestCase(FieldurlPathPrefixField)]
        public void AUT_CustomSite_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customSiteInstanceFixture, 
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
        ///     Class (<see cref="CustomSite" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomSite_Is_Instance_Present_Test()
        {
            // Assert
            _customSiteInstanceType.ShouldNotBeNull();
            _customSiteInstance.ShouldNotBeNull();
            _customSiteInstanceFixture.ShouldNotBeNull();
            _customSiteInstance.ShouldBeAssignableTo<CustomSite>();
            _customSiteInstanceFixture.ShouldBeAssignableTo<CustomSite>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomSite) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomSite_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomSite instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customSiteInstanceType.ShouldNotBeNull();
            _customSiteInstance.ShouldNotBeNull();
            _customSiteInstanceFixture.ShouldNotBeNull();
            _customSiteInstance.ShouldBeAssignableTo<CustomSite>();
            _customSiteInstanceFixture.ShouldBeAssignableTo<CustomSite>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomSite) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyactive)]
        [TestCaseGeneric(typeof(bool) , PropertyallowHomePage)]
        [TestCaseGeneric(typeof(bool) , PropertyallowStandardAnswersPages)]
        [TestCaseGeneric(typeof(bool) , PropertyallowStandardAnswersPagesSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyallowStandardIdeasPages)]
        [TestCaseGeneric(typeof(bool) , PropertyallowStandardLookups)]
        [TestCaseGeneric(typeof(bool) , PropertyallowStandardSearch)]
        [TestCaseGeneric(typeof(string) , PropertyanalyticsTrackingCode)]
        [TestCaseGeneric(typeof(string) , PropertyauthorizationRequiredPage)]
        [TestCaseGeneric(typeof(string) , PropertybandwidthExceededPage)]
        [TestCaseGeneric(typeof(string) , PropertychangePasswordPage)]
        [TestCaseGeneric(typeof(string) , PropertychatterAnswersForgotPasswordConfirmPage)]
        [TestCaseGeneric(typeof(string) , PropertychatterAnswersForgotPasswordPage)]
        [TestCaseGeneric(typeof(string) , PropertychatterAnswersHelpPage)]
        [TestCaseGeneric(typeof(string) , PropertychatterAnswersLoginPage)]
        [TestCaseGeneric(typeof(string) , PropertychatterAnswersRegistrationPage)]
        [TestCaseGeneric(typeof(SiteWebAddress[]) , PropertycustomWebAddresses)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , PropertyfavoriteIcon)]
        [TestCaseGeneric(typeof(string) , PropertyfileNotFoundPage)]
        [TestCaseGeneric(typeof(string) , PropertygenericErrorPage)]
        [TestCaseGeneric(typeof(string) , PropertyguestProfile)]
        [TestCaseGeneric(typeof(string) , PropertyinMaintenancePage)]
        [TestCaseGeneric(typeof(string) , PropertyinactiveIndexPage)]
        [TestCaseGeneric(typeof(string) , PropertyindexPage)]
        [TestCaseGeneric(typeof(string) , PropertymasterLabel)]
        [TestCaseGeneric(typeof(string) , PropertymyProfilePage)]
        [TestCaseGeneric(typeof(string) , Propertyportal)]
        [TestCaseGeneric(typeof(bool) , PropertyrequireInsecurePortalAccess)]
        [TestCaseGeneric(typeof(string) , PropertyrobotsTxtPage)]
        [TestCaseGeneric(typeof(string) , PropertyrootComponent)]
        [TestCaseGeneric(typeof(string) , PropertyserverIsDown)]
        [TestCaseGeneric(typeof(string) , PropertysiteAdmin)]
        [TestCaseGeneric(typeof(SiteRedirectMapping[]) , PropertysiteRedirectMappings)]
        [TestCaseGeneric(typeof(string) , PropertysiteTemplate)]
        [TestCaseGeneric(typeof(SiteType) , PropertysiteType)]
        [TestCaseGeneric(typeof(string) , Propertysubdomain)]
        [TestCaseGeneric(typeof(string) , PropertyurlPathPrefix)]
        public void AUT_CustomSite_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomSite, T>(_customSiteInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (active) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_active_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyactive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (allowHomePage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_allowHomePage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowHomePage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (allowStandardAnswersPages) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_allowStandardAnswersPages_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowStandardAnswersPages);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (allowStandardAnswersPagesSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_allowStandardAnswersPagesSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowStandardAnswersPagesSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (allowStandardIdeasPages) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_allowStandardIdeasPages_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowStandardIdeasPages);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (allowStandardLookups) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_allowStandardLookups_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowStandardLookups);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (allowStandardSearch) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_allowStandardSearch_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowStandardSearch);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (analyticsTrackingCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_analyticsTrackingCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyanalyticsTrackingCode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (authorizationRequiredPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_authorizationRequiredPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyauthorizationRequiredPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (bandwidthExceededPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_bandwidthExceededPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybandwidthExceededPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (changePasswordPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_changePasswordPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychangePasswordPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (chatterAnswersForgotPasswordConfirmPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_chatterAnswersForgotPasswordConfirmPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychatterAnswersForgotPasswordConfirmPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (chatterAnswersForgotPasswordPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_chatterAnswersForgotPasswordPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychatterAnswersForgotPasswordPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (chatterAnswersHelpPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_chatterAnswersHelpPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychatterAnswersHelpPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (chatterAnswersLoginPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_chatterAnswersLoginPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychatterAnswersLoginPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (chatterAnswersRegistrationPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_chatterAnswersRegistrationPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychatterAnswersRegistrationPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (customWebAddresses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_customWebAddresses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomWebAddresses);
            Action currentAction = () => propertyInfo.SetValue(_customSiteInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (customWebAddresses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_customWebAddresses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomWebAddresses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomSite) => Property (favoriteIcon) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_favoriteIcon_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfavoriteIcon);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (fileNotFoundPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_fileNotFoundPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfileNotFoundPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (genericErrorPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_genericErrorPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertygenericErrorPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (guestProfile) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_guestProfile_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyguestProfile);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (inactiveIndexPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_inactiveIndexPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyinactiveIndexPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (indexPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_indexPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyindexPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (inMaintenancePage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_inMaintenancePage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyinMaintenancePage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (masterLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_masterLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomSite) => Property (myProfilePage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_myProfilePage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymyProfilePage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (portal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_portal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomSite) => Property (requireInsecurePortalAccess) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_requireInsecurePortalAccess_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrequireInsecurePortalAccess);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (robotsTxtPage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_robotsTxtPage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrobotsTxtPage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (rootComponent) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_rootComponent_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrootComponent);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (serverIsDown) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_serverIsDown_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyserverIsDown);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (siteAdmin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_siteAdmin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysiteAdmin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (siteRedirectMappings) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_siteRedirectMappings_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysiteRedirectMappings);
            Action currentAction = () => propertyInfo.SetValue(_customSiteInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (siteRedirectMappings) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_siteRedirectMappings_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysiteRedirectMappings);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (siteTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_siteTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysiteTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (siteType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_siteType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysiteType);
            Action currentAction = () => propertyInfo.SetValue(_customSiteInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (siteType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_siteType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysiteType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (subdomain) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_subdomain_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysubdomain);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomSite) => Property (urlPathPrefix) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomSite_Public_Class_urlPathPrefix_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyurlPathPrefix);

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