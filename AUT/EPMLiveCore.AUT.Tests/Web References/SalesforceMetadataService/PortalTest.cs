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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Portal" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PortalTest : AbstractBaseSetupTypedTest<Portal>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Portal) Initializer

        private const string Propertyactive = "active";
        private const string Propertyadmin = "admin";
        private const string PropertydefaultLanguage = "defaultLanguage";
        private const string Propertydescription = "description";
        private const string PropertyemailSenderAddress = "emailSenderAddress";
        private const string PropertyemailSenderName = "emailSenderName";
        private const string PropertyenableSelfCloseCase = "enableSelfCloseCase";
        private const string PropertyenableSelfCloseCaseSpecified = "enableSelfCloseCaseSpecified";
        private const string PropertyfooterDocument = "footerDocument";
        private const string PropertyforgotPassTemplate = "forgotPassTemplate";
        private const string PropertyheaderDocument = "headerDocument";
        private const string PropertyisSelfRegistrationActivated = "isSelfRegistrationActivated";
        private const string PropertyisSelfRegistrationActivatedSpecified = "isSelfRegistrationActivatedSpecified";
        private const string PropertyloginHeaderDocument = "loginHeaderDocument";
        private const string PropertylogoDocument = "logoDocument";
        private const string PropertylogoutUrl = "logoutUrl";
        private const string PropertynewCommentTemplate = "newCommentTemplate";
        private const string PropertynewPassTemplate = "newPassTemplate";
        private const string PropertynewUserTemplate = "newUserTemplate";
        private const string PropertyownerNotifyTemplate = "ownerNotifyTemplate";
        private const string PropertyselfRegNewUserUrl = "selfRegNewUserUrl";
        private const string PropertyselfRegUserDefaultProfile = "selfRegUserDefaultProfile";
        private const string PropertyselfRegUserDefaultRole = "selfRegUserDefaultRole";
        private const string PropertyselfRegUserDefaultRoleSpecified = "selfRegUserDefaultRoleSpecified";
        private const string PropertyselfRegUserTemplate = "selfRegUserTemplate";
        private const string PropertyshowActionConfirmation = "showActionConfirmation";
        private const string PropertyshowActionConfirmationSpecified = "showActionConfirmationSpecified";
        private const string PropertystylesheetDocument = "stylesheetDocument";
        private const string Propertytype = "type";
        private const string FieldactiveField = "activeField";
        private const string FieldadminField = "adminField";
        private const string FielddefaultLanguageField = "defaultLanguageField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldemailSenderAddressField = "emailSenderAddressField";
        private const string FieldemailSenderNameField = "emailSenderNameField";
        private const string FieldenableSelfCloseCaseField = "enableSelfCloseCaseField";
        private const string FieldenableSelfCloseCaseFieldSpecified = "enableSelfCloseCaseFieldSpecified";
        private const string FieldfooterDocumentField = "footerDocumentField";
        private const string FieldforgotPassTemplateField = "forgotPassTemplateField";
        private const string FieldheaderDocumentField = "headerDocumentField";
        private const string FieldisSelfRegistrationActivatedField = "isSelfRegistrationActivatedField";
        private const string FieldisSelfRegistrationActivatedFieldSpecified = "isSelfRegistrationActivatedFieldSpecified";
        private const string FieldloginHeaderDocumentField = "loginHeaderDocumentField";
        private const string FieldlogoDocumentField = "logoDocumentField";
        private const string FieldlogoutUrlField = "logoutUrlField";
        private const string FieldnewCommentTemplateField = "newCommentTemplateField";
        private const string FieldnewPassTemplateField = "newPassTemplateField";
        private const string FieldnewUserTemplateField = "newUserTemplateField";
        private const string FieldownerNotifyTemplateField = "ownerNotifyTemplateField";
        private const string FieldselfRegNewUserUrlField = "selfRegNewUserUrlField";
        private const string FieldselfRegUserDefaultProfileField = "selfRegUserDefaultProfileField";
        private const string FieldselfRegUserDefaultRoleField = "selfRegUserDefaultRoleField";
        private const string FieldselfRegUserDefaultRoleFieldSpecified = "selfRegUserDefaultRoleFieldSpecified";
        private const string FieldselfRegUserTemplateField = "selfRegUserTemplateField";
        private const string FieldshowActionConfirmationField = "showActionConfirmationField";
        private const string FieldshowActionConfirmationFieldSpecified = "showActionConfirmationFieldSpecified";
        private const string FieldstylesheetDocumentField = "stylesheetDocumentField";
        private const string FieldtypeField = "typeField";
        private Type _portalInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Portal _portalInstance;
        private Portal _portalInstanceFixture;

        #region General Initializer : Class (Portal) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Portal" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _portalInstanceType = typeof(Portal);
            _portalInstanceFixture = Create(true);
            _portalInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Portal)

        #region General Initializer : Class (Portal) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Portal" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyactive)]
        [TestCase(Propertyadmin)]
        [TestCase(PropertydefaultLanguage)]
        [TestCase(Propertydescription)]
        [TestCase(PropertyemailSenderAddress)]
        [TestCase(PropertyemailSenderName)]
        [TestCase(PropertyenableSelfCloseCase)]
        [TestCase(PropertyenableSelfCloseCaseSpecified)]
        [TestCase(PropertyfooterDocument)]
        [TestCase(PropertyforgotPassTemplate)]
        [TestCase(PropertyheaderDocument)]
        [TestCase(PropertyisSelfRegistrationActivated)]
        [TestCase(PropertyisSelfRegistrationActivatedSpecified)]
        [TestCase(PropertyloginHeaderDocument)]
        [TestCase(PropertylogoDocument)]
        [TestCase(PropertylogoutUrl)]
        [TestCase(PropertynewCommentTemplate)]
        [TestCase(PropertynewPassTemplate)]
        [TestCase(PropertynewUserTemplate)]
        [TestCase(PropertyownerNotifyTemplate)]
        [TestCase(PropertyselfRegNewUserUrl)]
        [TestCase(PropertyselfRegUserDefaultProfile)]
        [TestCase(PropertyselfRegUserDefaultRole)]
        [TestCase(PropertyselfRegUserDefaultRoleSpecified)]
        [TestCase(PropertyselfRegUserTemplate)]
        [TestCase(PropertyshowActionConfirmation)]
        [TestCase(PropertyshowActionConfirmationSpecified)]
        [TestCase(PropertystylesheetDocument)]
        [TestCase(Propertytype)]
        public void AUT_Portal_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_portalInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Portal) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Portal" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactiveField)]
        [TestCase(FieldadminField)]
        [TestCase(FielddefaultLanguageField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldemailSenderAddressField)]
        [TestCase(FieldemailSenderNameField)]
        [TestCase(FieldenableSelfCloseCaseField)]
        [TestCase(FieldenableSelfCloseCaseFieldSpecified)]
        [TestCase(FieldfooterDocumentField)]
        [TestCase(FieldforgotPassTemplateField)]
        [TestCase(FieldheaderDocumentField)]
        [TestCase(FieldisSelfRegistrationActivatedField)]
        [TestCase(FieldisSelfRegistrationActivatedFieldSpecified)]
        [TestCase(FieldloginHeaderDocumentField)]
        [TestCase(FieldlogoDocumentField)]
        [TestCase(FieldlogoutUrlField)]
        [TestCase(FieldnewCommentTemplateField)]
        [TestCase(FieldnewPassTemplateField)]
        [TestCase(FieldnewUserTemplateField)]
        [TestCase(FieldownerNotifyTemplateField)]
        [TestCase(FieldselfRegNewUserUrlField)]
        [TestCase(FieldselfRegUserDefaultProfileField)]
        [TestCase(FieldselfRegUserDefaultRoleField)]
        [TestCase(FieldselfRegUserDefaultRoleFieldSpecified)]
        [TestCase(FieldselfRegUserTemplateField)]
        [TestCase(FieldshowActionConfirmationField)]
        [TestCase(FieldshowActionConfirmationFieldSpecified)]
        [TestCase(FieldstylesheetDocumentField)]
        [TestCase(FieldtypeField)]
        public void AUT_Portal_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_portalInstanceFixture, 
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
        ///     Class (<see cref="Portal" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Portal_Is_Instance_Present_Test()
        {
            // Assert
            _portalInstanceType.ShouldNotBeNull();
            _portalInstance.ShouldNotBeNull();
            _portalInstanceFixture.ShouldNotBeNull();
            _portalInstance.ShouldBeAssignableTo<Portal>();
            _portalInstanceFixture.ShouldBeAssignableTo<Portal>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Portal) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Portal_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Portal instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _portalInstanceType.ShouldNotBeNull();
            _portalInstance.ShouldNotBeNull();
            _portalInstanceFixture.ShouldNotBeNull();
            _portalInstance.ShouldBeAssignableTo<Portal>();
            _portalInstanceFixture.ShouldBeAssignableTo<Portal>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Portal) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyactive)]
        [TestCaseGeneric(typeof(string) , Propertyadmin)]
        [TestCaseGeneric(typeof(string) , PropertydefaultLanguage)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , PropertyemailSenderAddress)]
        [TestCaseGeneric(typeof(string) , PropertyemailSenderName)]
        [TestCaseGeneric(typeof(bool) , PropertyenableSelfCloseCase)]
        [TestCaseGeneric(typeof(bool) , PropertyenableSelfCloseCaseSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyfooterDocument)]
        [TestCaseGeneric(typeof(string) , PropertyforgotPassTemplate)]
        [TestCaseGeneric(typeof(string) , PropertyheaderDocument)]
        [TestCaseGeneric(typeof(bool) , PropertyisSelfRegistrationActivated)]
        [TestCaseGeneric(typeof(bool) , PropertyisSelfRegistrationActivatedSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyloginHeaderDocument)]
        [TestCaseGeneric(typeof(string) , PropertylogoDocument)]
        [TestCaseGeneric(typeof(string) , PropertylogoutUrl)]
        [TestCaseGeneric(typeof(string) , PropertynewCommentTemplate)]
        [TestCaseGeneric(typeof(string) , PropertynewPassTemplate)]
        [TestCaseGeneric(typeof(string) , PropertynewUserTemplate)]
        [TestCaseGeneric(typeof(string) , PropertyownerNotifyTemplate)]
        [TestCaseGeneric(typeof(string) , PropertyselfRegNewUserUrl)]
        [TestCaseGeneric(typeof(string) , PropertyselfRegUserDefaultProfile)]
        [TestCaseGeneric(typeof(PortalRoles) , PropertyselfRegUserDefaultRole)]
        [TestCaseGeneric(typeof(bool) , PropertyselfRegUserDefaultRoleSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyselfRegUserTemplate)]
        [TestCaseGeneric(typeof(bool) , PropertyshowActionConfirmation)]
        [TestCaseGeneric(typeof(bool) , PropertyshowActionConfirmationSpecified)]
        [TestCaseGeneric(typeof(string) , PropertystylesheetDocument)]
        [TestCaseGeneric(typeof(PortalType) , Propertytype)]
        public void AUT_Portal_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Portal, T>(_portalInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (active) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_active_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Portal) => Property (admin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_admin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyadmin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (defaultLanguage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_defaultLanguage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultLanguage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Portal) => Property (emailSenderAddress) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_emailSenderAddress_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailSenderAddress);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (emailSenderName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_emailSenderName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailSenderName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (enableSelfCloseCase) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_enableSelfCloseCase_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableSelfCloseCase);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (enableSelfCloseCaseSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_enableSelfCloseCaseSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableSelfCloseCaseSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (footerDocument) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_footerDocument_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfooterDocument);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (forgotPassTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_forgotPassTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyforgotPassTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (headerDocument) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_headerDocument_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyheaderDocument);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (isSelfRegistrationActivated) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_isSelfRegistrationActivated_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisSelfRegistrationActivated);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (isSelfRegistrationActivatedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_isSelfRegistrationActivatedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisSelfRegistrationActivatedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (loginHeaderDocument) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_loginHeaderDocument_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyloginHeaderDocument);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (logoDocument) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_logoDocument_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylogoDocument);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (logoutUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_logoutUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylogoutUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (newCommentTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_newCommentTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynewCommentTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (newPassTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_newPassTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynewPassTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (newUserTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_newUserTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynewUserTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (ownerNotifyTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_ownerNotifyTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyownerNotifyTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (selfRegNewUserUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_selfRegNewUserUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyselfRegNewUserUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (selfRegUserDefaultProfile) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_selfRegUserDefaultProfile_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyselfRegUserDefaultProfile);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (selfRegUserDefaultRole) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_selfRegUserDefaultRole_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyselfRegUserDefaultRole);
            Action currentAction = () => propertyInfo.SetValue(_portalInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (selfRegUserDefaultRole) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_selfRegUserDefaultRole_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyselfRegUserDefaultRole);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (selfRegUserDefaultRoleSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_selfRegUserDefaultRoleSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyselfRegUserDefaultRoleSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (selfRegUserTemplate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_selfRegUserTemplate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyselfRegUserTemplate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (showActionConfirmation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_showActionConfirmation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowActionConfirmation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (showActionConfirmationSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_showActionConfirmationSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowActionConfirmationSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (stylesheetDocument) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_stylesheetDocument_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystylesheetDocument);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (type) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytype);
            Action currentAction = () => propertyInfo.SetValue(_portalInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Portal) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Portal_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}