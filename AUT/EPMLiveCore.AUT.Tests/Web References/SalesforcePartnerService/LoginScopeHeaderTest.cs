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
using LoginScopeHeader = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.LoginScopeHeader" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LoginScopeHeaderTest : AbstractBaseSetupTypedTest<LoginScopeHeader>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LoginScopeHeader) Initializer

        private const string PropertyorganizationId = "organizationId";
        private const string PropertyportalId = "portalId";
        private const string FieldorganizationIdField = "organizationIdField";
        private const string FieldportalIdField = "portalIdField";
        private Type _loginScopeHeaderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LoginScopeHeader _loginScopeHeaderInstance;
        private LoginScopeHeader _loginScopeHeaderInstanceFixture;

        #region General Initializer : Class (LoginScopeHeader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LoginScopeHeader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _loginScopeHeaderInstanceType = typeof(LoginScopeHeader);
            _loginScopeHeaderInstanceFixture = Create(true);
            _loginScopeHeaderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LoginScopeHeader)

        #region General Initializer : Class (LoginScopeHeader) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LoginScopeHeader" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyorganizationId)]
        [TestCase(PropertyportalId)]
        public void AUT_LoginScopeHeader_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_loginScopeHeaderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LoginScopeHeader) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LoginScopeHeader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldorganizationIdField)]
        [TestCase(FieldportalIdField)]
        public void AUT_LoginScopeHeader_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_loginScopeHeaderInstanceFixture, 
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
        ///     Class (<see cref="LoginScopeHeader" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LoginScopeHeader_Is_Instance_Present_Test()
        {
            // Assert
            _loginScopeHeaderInstanceType.ShouldNotBeNull();
            _loginScopeHeaderInstance.ShouldNotBeNull();
            _loginScopeHeaderInstanceFixture.ShouldNotBeNull();
            _loginScopeHeaderInstance.ShouldBeAssignableTo<LoginScopeHeader>();
            _loginScopeHeaderInstanceFixture.ShouldBeAssignableTo<LoginScopeHeader>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LoginScopeHeader) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LoginScopeHeader_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LoginScopeHeader instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _loginScopeHeaderInstanceType.ShouldNotBeNull();
            _loginScopeHeaderInstance.ShouldNotBeNull();
            _loginScopeHeaderInstanceFixture.ShouldNotBeNull();
            _loginScopeHeaderInstance.ShouldBeAssignableTo<LoginScopeHeader>();
            _loginScopeHeaderInstanceFixture.ShouldBeAssignableTo<LoginScopeHeader>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LoginScopeHeader) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyorganizationId)]
        [TestCaseGeneric(typeof(string) , PropertyportalId)]
        public void AUT_LoginScopeHeader_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LoginScopeHeader, T>(_loginScopeHeaderInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LoginScopeHeader) => Property (organizationId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginScopeHeader_Public_Class_organizationId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LoginScopeHeader) => Property (portalId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LoginScopeHeader_Public_Class_portalId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyportalId);

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