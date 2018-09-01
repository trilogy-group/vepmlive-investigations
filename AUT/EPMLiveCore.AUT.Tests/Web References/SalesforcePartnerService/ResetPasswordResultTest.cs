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
using ResetPasswordResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.ResetPasswordResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ResetPasswordResultTest : AbstractBaseSetupTypedTest<ResetPasswordResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ResetPasswordResult) Initializer

        private const string Propertypassword = "password";
        private const string FieldpasswordField = "passwordField";
        private Type _resetPasswordResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ResetPasswordResult _resetPasswordResultInstance;
        private ResetPasswordResult _resetPasswordResultInstanceFixture;

        #region General Initializer : Class (ResetPasswordResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ResetPasswordResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _resetPasswordResultInstanceType = typeof(ResetPasswordResult);
            _resetPasswordResultInstanceFixture = Create(true);
            _resetPasswordResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ResetPasswordResult)

        #region General Initializer : Class (ResetPasswordResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ResetPasswordResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertypassword)]
        public void AUT_ResetPasswordResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_resetPasswordResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ResetPasswordResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ResetPasswordResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldpasswordField)]
        public void AUT_ResetPasswordResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_resetPasswordResultInstanceFixture, 
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
        ///     Class (<see cref="ResetPasswordResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ResetPasswordResult_Is_Instance_Present_Test()
        {
            // Assert
            _resetPasswordResultInstanceType.ShouldNotBeNull();
            _resetPasswordResultInstance.ShouldNotBeNull();
            _resetPasswordResultInstanceFixture.ShouldNotBeNull();
            _resetPasswordResultInstance.ShouldBeAssignableTo<ResetPasswordResult>();
            _resetPasswordResultInstanceFixture.ShouldBeAssignableTo<ResetPasswordResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ResetPasswordResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ResetPasswordResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ResetPasswordResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _resetPasswordResultInstanceType.ShouldNotBeNull();
            _resetPasswordResultInstance.ShouldNotBeNull();
            _resetPasswordResultInstanceFixture.ShouldNotBeNull();
            _resetPasswordResultInstance.ShouldBeAssignableTo<ResetPasswordResult>();
            _resetPasswordResultInstanceFixture.ShouldBeAssignableTo<ResetPasswordResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ResetPasswordResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertypassword)]
        public void AUT_ResetPasswordResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ResetPasswordResult, T>(_resetPasswordResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ResetPasswordResult) => Property (password) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ResetPasswordResult_Public_Class_password_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertypassword);

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