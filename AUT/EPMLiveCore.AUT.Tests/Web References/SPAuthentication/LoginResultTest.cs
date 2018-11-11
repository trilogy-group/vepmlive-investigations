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
using EPMLiveCore.SPAuthentication;
using LoginResult = EPMLiveCore.SPAuthentication;

namespace EPMLiveCore.SPAuthentication
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SPAuthentication.LoginResult" />)
    ///     and namespace <see cref="EPMLiveCore.SPAuthentication"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LoginResultTest : AbstractBaseSetupTypedTest<LoginResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LoginResult) Initializer

        private const string PropertyCookieName = "CookieName";
        private const string PropertyErrorCode = "ErrorCode";
        private const string PropertyTimeoutSeconds = "TimeoutSeconds";
        private const string FieldcookieNameField = "cookieNameField";
        private const string FielderrorCodeField = "errorCodeField";
        private const string FieldtimeoutSecondsField = "timeoutSecondsField";
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
        [TestCase(PropertyCookieName)]
        [TestCase(PropertyErrorCode)]
        [TestCase(PropertyTimeoutSeconds)]
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
        [TestCase(FieldcookieNameField)]
        [TestCase(FielderrorCodeField)]
        [TestCase(FieldtimeoutSecondsField)]
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
        [TestCaseGeneric(typeof(string) , PropertyCookieName)]
        [TestCaseGeneric(typeof(LoginErrorCode) , PropertyErrorCode)]
        [TestCaseGeneric(typeof(int) , PropertyTimeoutSeconds)]
        public void AUT_LoginResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LoginResult, T>(_loginResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LoginResult) => Property (CookieName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginResult_Public_Class_CookieName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyCookieName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LoginResult) => Property (ErrorCode) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginResult_ErrorCode_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyErrorCode);
            Action currentAction = () => propertyInfo.SetValue(_loginResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LoginResult) => Property (ErrorCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginResult_Public_Class_ErrorCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyErrorCode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LoginResult) => Property (TimeoutSeconds) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginResult_Public_Class_TimeoutSeconds_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyTimeoutSeconds);

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