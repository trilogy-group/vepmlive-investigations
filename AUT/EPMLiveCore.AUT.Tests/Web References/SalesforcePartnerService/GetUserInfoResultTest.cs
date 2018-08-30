using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using Action = System.Action;
using AUT.ConfigureTestProjects;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.AutoFixtureSetup;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using AutoFixture;
using Moq;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;
using EPMLiveCore.SalesforcePartnerService;
using GetUserInfoResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.GetUserInfoResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class GetUserInfoResultTest : AbstractBaseSetupTypedTest<GetUserInfoResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (GetUserInfoResult) Initializer

        private const string PropertyaccessibilityMode = "accessibilityMode";
        private const string PropertycurrencySymbol = "currencySymbol";
        private const string PropertyorgAttachmentFileSizeLimit = "orgAttachmentFileSizeLimit";
        private const string PropertyorgDefaultCurrencyIsoCode = "orgDefaultCurrencyIsoCode";
        private const string PropertyorgDisallowHtmlAttachments = "orgDisallowHtmlAttachments";
        private const string PropertyorgHasPersonAccounts = "orgHasPersonAccounts";
        private const string PropertyorganizationId = "organizationId";
        private const string PropertyorganizationMultiCurrency = "organizationMultiCurrency";
        private const string PropertyorganizationName = "organizationName";
        private const string PropertyprofileId = "profileId";
        private const string PropertyroleId = "roleId";
        private const string PropertysessionSecondsValid = "sessionSecondsValid";
        private const string PropertyuserDefaultCurrencyIsoCode = "userDefaultCurrencyIsoCode";
        private const string PropertyuserEmail = "userEmail";
        private const string PropertyuserFullName = "userFullName";
        private const string PropertyuserId = "userId";
        private const string PropertyuserLanguage = "userLanguage";
        private const string PropertyuserLocale = "userLocale";
        private const string PropertyuserName = "userName";
        private const string PropertyuserTimeZone = "userTimeZone";
        private const string PropertyuserType = "userType";
        private const string PropertyuserUiSkin = "userUiSkin";
        private const string FieldaccessibilityModeField = "accessibilityModeField";
        private const string FieldcurrencySymbolField = "currencySymbolField";
        private const string FieldorgAttachmentFileSizeLimitField = "orgAttachmentFileSizeLimitField";
        private const string FieldorgDefaultCurrencyIsoCodeField = "orgDefaultCurrencyIsoCodeField";
        private const string FieldorgDisallowHtmlAttachmentsField = "orgDisallowHtmlAttachmentsField";
        private const string FieldorgHasPersonAccountsField = "orgHasPersonAccountsField";
        private const string FieldorganizationIdField = "organizationIdField";
        private const string FieldorganizationMultiCurrencyField = "organizationMultiCurrencyField";
        private const string FieldorganizationNameField = "organizationNameField";
        private const string FieldprofileIdField = "profileIdField";
        private const string FieldroleIdField = "roleIdField";
        private const string FieldsessionSecondsValidField = "sessionSecondsValidField";
        private const string FielduserDefaultCurrencyIsoCodeField = "userDefaultCurrencyIsoCodeField";
        private const string FielduserEmailField = "userEmailField";
        private const string FielduserFullNameField = "userFullNameField";
        private const string FielduserIdField = "userIdField";
        private const string FielduserLanguageField = "userLanguageField";
        private const string FielduserLocaleField = "userLocaleField";
        private const string FielduserNameField = "userNameField";
        private const string FielduserTimeZoneField = "userTimeZoneField";
        private const string FielduserTypeField = "userTypeField";
        private const string FielduserUiSkinField = "userUiSkinField";
        private Type _getUserInfoResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private GetUserInfoResult _getUserInfoResultInstance;
        private GetUserInfoResult _getUserInfoResultInstanceFixture;

        #region General Initializer : Class (GetUserInfoResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="GetUserInfoResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _getUserInfoResultInstanceType = typeof(GetUserInfoResult);
            _getUserInfoResultInstanceFixture = Create(true);
            _getUserInfoResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (GetUserInfoResult)

        #region General Initializer : Class (GetUserInfoResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="GetUserInfoResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyaccessibilityMode)]
        [TestCase(PropertycurrencySymbol)]
        [TestCase(PropertyorgAttachmentFileSizeLimit)]
        [TestCase(PropertyorgDefaultCurrencyIsoCode)]
        [TestCase(PropertyorgDisallowHtmlAttachments)]
        [TestCase(PropertyorgHasPersonAccounts)]
        [TestCase(PropertyorganizationId)]
        [TestCase(PropertyorganizationMultiCurrency)]
        [TestCase(PropertyorganizationName)]
        [TestCase(PropertyprofileId)]
        [TestCase(PropertyroleId)]
        [TestCase(PropertysessionSecondsValid)]
        [TestCase(PropertyuserDefaultCurrencyIsoCode)]
        [TestCase(PropertyuserEmail)]
        [TestCase(PropertyuserFullName)]
        [TestCase(PropertyuserId)]
        [TestCase(PropertyuserLanguage)]
        [TestCase(PropertyuserLocale)]
        [TestCase(PropertyuserName)]
        [TestCase(PropertyuserTimeZone)]
        [TestCase(PropertyuserType)]
        [TestCase(PropertyuserUiSkin)]
        public void AUT_GetUserInfoResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_getUserInfoResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (GetUserInfoResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="GetUserInfoResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaccessibilityModeField)]
        [TestCase(FieldcurrencySymbolField)]
        [TestCase(FieldorgAttachmentFileSizeLimitField)]
        [TestCase(FieldorgDefaultCurrencyIsoCodeField)]
        [TestCase(FieldorgDisallowHtmlAttachmentsField)]
        [TestCase(FieldorgHasPersonAccountsField)]
        [TestCase(FieldorganizationIdField)]
        [TestCase(FieldorganizationMultiCurrencyField)]
        [TestCase(FieldorganizationNameField)]
        [TestCase(FieldprofileIdField)]
        [TestCase(FieldroleIdField)]
        [TestCase(FieldsessionSecondsValidField)]
        [TestCase(FielduserDefaultCurrencyIsoCodeField)]
        [TestCase(FielduserEmailField)]
        [TestCase(FielduserFullNameField)]
        [TestCase(FielduserIdField)]
        [TestCase(FielduserLanguageField)]
        [TestCase(FielduserLocaleField)]
        [TestCase(FielduserNameField)]
        [TestCase(FielduserTimeZoneField)]
        [TestCase(FielduserTypeField)]
        [TestCase(FielduserUiSkinField)]
        public void AUT_GetUserInfoResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_getUserInfoResultInstanceFixture, 
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
        ///     Class (<see cref="GetUserInfoResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_GetUserInfoResult_Is_Instance_Present_Test()
        {
            // Assert
            _getUserInfoResultInstanceType.ShouldNotBeNull();
            _getUserInfoResultInstance.ShouldNotBeNull();
            _getUserInfoResultInstanceFixture.ShouldNotBeNull();
            _getUserInfoResultInstance.ShouldBeAssignableTo<GetUserInfoResult>();
            _getUserInfoResultInstanceFixture.ShouldBeAssignableTo<GetUserInfoResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (GetUserInfoResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_GetUserInfoResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            GetUserInfoResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _getUserInfoResultInstanceType.ShouldNotBeNull();
            _getUserInfoResultInstance.ShouldNotBeNull();
            _getUserInfoResultInstanceFixture.ShouldNotBeNull();
            _getUserInfoResultInstance.ShouldBeAssignableTo<GetUserInfoResult>();
            _getUserInfoResultInstanceFixture.ShouldBeAssignableTo<GetUserInfoResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (GetUserInfoResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyaccessibilityMode)]
        [TestCaseGeneric(typeof(string) , PropertycurrencySymbol)]
        [TestCaseGeneric(typeof(int) , PropertyorgAttachmentFileSizeLimit)]
        [TestCaseGeneric(typeof(string) , PropertyorgDefaultCurrencyIsoCode)]
        [TestCaseGeneric(typeof(bool) , PropertyorgDisallowHtmlAttachments)]
        [TestCaseGeneric(typeof(bool) , PropertyorgHasPersonAccounts)]
        [TestCaseGeneric(typeof(string) , PropertyorganizationId)]
        [TestCaseGeneric(typeof(bool) , PropertyorganizationMultiCurrency)]
        [TestCaseGeneric(typeof(string) , PropertyorganizationName)]
        [TestCaseGeneric(typeof(string) , PropertyprofileId)]
        [TestCaseGeneric(typeof(string) , PropertyroleId)]
        [TestCaseGeneric(typeof(int) , PropertysessionSecondsValid)]
        [TestCaseGeneric(typeof(string) , PropertyuserDefaultCurrencyIsoCode)]
        [TestCaseGeneric(typeof(string) , PropertyuserEmail)]
        [TestCaseGeneric(typeof(string) , PropertyuserFullName)]
        [TestCaseGeneric(typeof(string) , PropertyuserId)]
        [TestCaseGeneric(typeof(string) , PropertyuserLanguage)]
        [TestCaseGeneric(typeof(string) , PropertyuserLocale)]
        [TestCaseGeneric(typeof(string) , PropertyuserName)]
        [TestCaseGeneric(typeof(string) , PropertyuserTimeZone)]
        [TestCaseGeneric(typeof(string) , PropertyuserType)]
        [TestCaseGeneric(typeof(string) , PropertyuserUiSkin)]
        public void AUT_GetUserInfoResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<GetUserInfoResult, T>(_getUserInfoResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (accessibilityMode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_accessibilityMode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaccessibilityMode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (currencySymbol) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_currencySymbol_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycurrencySymbol);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (organizationId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_organizationId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyorganizationId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (organizationMultiCurrency) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_organizationMultiCurrency_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyorganizationMultiCurrency);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (organizationName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_organizationName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyorganizationName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (orgAttachmentFileSizeLimit) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_orgAttachmentFileSizeLimit_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyorgAttachmentFileSizeLimit);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (orgDefaultCurrencyIsoCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_orgDefaultCurrencyIsoCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyorgDefaultCurrencyIsoCode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (orgDisallowHtmlAttachments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_orgDisallowHtmlAttachments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyorgDisallowHtmlAttachments);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (orgHasPersonAccounts) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_orgHasPersonAccounts_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyorgHasPersonAccounts);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (profileId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_profileId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyprofileId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (roleId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_roleId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyroleId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (sessionSecondsValid) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_sessionSecondsValid_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysessionSecondsValid);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (userDefaultCurrencyIsoCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_userDefaultCurrencyIsoCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserDefaultCurrencyIsoCode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (userEmail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_userEmail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserEmail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (userFullName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_userFullName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserFullName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (userId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_userId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (userLanguage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_userLanguage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserLanguage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (userLocale) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_userLocale_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserLocale);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (userName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_userName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (userTimeZone) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_userTimeZone_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserTimeZone);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (userType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_userType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (GetUserInfoResult) => Property (userUiSkin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_GetUserInfoResult_Public_Class_userUiSkin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserUiSkin);

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