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
using LoginResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.LoginResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LoginResultTest : AbstractBaseSetupTypedTest<LoginResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LoginResult) Initializer

        private const string PropertymetadataServerUrl = "metadataServerUrl";
        private const string PropertypasswordExpired = "passwordExpired";
        private const string Propertysandbox = "sandbox";
        private const string PropertyserverUrl = "serverUrl";
        private const string PropertysessionId = "sessionId";
        private const string PropertyuserId = "userId";
        private const string PropertyuserInfo = "userInfo";
        private const string FieldmetadataServerUrlField = "metadataServerUrlField";
        private const string FieldpasswordExpiredField = "passwordExpiredField";
        private const string FieldsandboxField = "sandboxField";
        private const string FieldserverUrlField = "serverUrlField";
        private const string FieldsessionIdField = "sessionIdField";
        private const string FielduserIdField = "userIdField";
        private const string FielduserInfoField = "userInfoField";
        private Type _loginResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LoginResult _loginResultInstance;
        private LoginResult _loginResultInstanceFixture;

        #region General Initializer : Class (LoginResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LoginResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _loginResultInstanceType = typeof(LoginResult);
            _loginResultInstanceFixture = Create(true);
            _loginResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LoginResult)

        #region General Initializer : Class (LoginResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LoginResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertymetadataServerUrl)]
        [TestCase(PropertypasswordExpired)]
        [TestCase(Propertysandbox)]
        [TestCase(PropertyserverUrl)]
        [TestCase(PropertysessionId)]
        [TestCase(PropertyuserId)]
        [TestCase(PropertyuserInfo)]
        public void AUT_LoginResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_loginResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LoginResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LoginResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldmetadataServerUrlField)]
        [TestCase(FieldpasswordExpiredField)]
        [TestCase(FieldsandboxField)]
        [TestCase(FieldserverUrlField)]
        [TestCase(FieldsessionIdField)]
        [TestCase(FielduserIdField)]
        [TestCase(FielduserInfoField)]
        public void AUT_LoginResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_loginResultInstanceFixture, 
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
        ///     Class (<see cref="LoginResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LoginResult_Is_Instance_Present_Test()
        {
            // Assert
            _loginResultInstanceType.ShouldNotBeNull();
            _loginResultInstance.ShouldNotBeNull();
            _loginResultInstanceFixture.ShouldNotBeNull();
            _loginResultInstance.ShouldBeAssignableTo<LoginResult>();
            _loginResultInstanceFixture.ShouldBeAssignableTo<LoginResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LoginResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LoginResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LoginResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _loginResultInstanceType.ShouldNotBeNull();
            _loginResultInstance.ShouldNotBeNull();
            _loginResultInstanceFixture.ShouldNotBeNull();
            _loginResultInstance.ShouldBeAssignableTo<LoginResult>();
            _loginResultInstanceFixture.ShouldBeAssignableTo<LoginResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LoginResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertymetadataServerUrl)]
        [TestCaseGeneric(typeof(bool) , PropertypasswordExpired)]
        [TestCaseGeneric(typeof(bool) , Propertysandbox)]
        [TestCaseGeneric(typeof(string) , PropertyserverUrl)]
        [TestCaseGeneric(typeof(string) , PropertysessionId)]
        [TestCaseGeneric(typeof(string) , PropertyuserId)]
        [TestCaseGeneric(typeof(GetUserInfoResult) , PropertyuserInfo)]
        public void AUT_LoginResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LoginResult, T>(_loginResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LoginResult) => Property (metadataServerUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginResult_Public_Class_metadataServerUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymetadataServerUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LoginResult) => Property (passwordExpired) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginResult_Public_Class_passwordExpired_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypasswordExpired);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LoginResult) => Property (sandbox) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginResult_Public_Class_sandbox_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysandbox);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LoginResult) => Property (serverUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginResult_Public_Class_serverUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyserverUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LoginResult) => Property (sessionId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginResult_Public_Class_sessionId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysessionId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LoginResult) => Property (userId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginResult_Public_Class_userId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LoginResult) => Property (userInfo) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginResult_userInfo_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyuserInfo);
            Action currentAction = () => propertyInfo.SetValue(_loginResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LoginResult) => Property (userInfo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginResult_Public_Class_userInfo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuserInfo);

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