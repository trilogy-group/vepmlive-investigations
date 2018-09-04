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
using SendEmailResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.SendEmailResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SendEmailResultTest : AbstractBaseSetupTypedTest<SendEmailResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SendEmailResult) Initializer

        private const string Propertyerrors = "errors";
        private const string Propertysuccess = "success";
        private const string FielderrorsField = "errorsField";
        private const string FieldsuccessField = "successField";
        private Type _sendEmailResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SendEmailResult _sendEmailResultInstance;
        private SendEmailResult _sendEmailResultInstanceFixture;

        #region General Initializer : Class (SendEmailResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SendEmailResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sendEmailResultInstanceType = typeof(SendEmailResult);
            _sendEmailResultInstanceFixture = Create(true);
            _sendEmailResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SendEmailResult)

        #region General Initializer : Class (SendEmailResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SendEmailResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyerrors)]
        [TestCase(Propertysuccess)]
        public void AUT_SendEmailResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sendEmailResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SendEmailResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SendEmailResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielderrorsField)]
        [TestCase(FieldsuccessField)]
        public void AUT_SendEmailResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sendEmailResultInstanceFixture, 
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
        ///     Class (<see cref="SendEmailResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SendEmailResult_Is_Instance_Present_Test()
        {
            // Assert
            _sendEmailResultInstanceType.ShouldNotBeNull();
            _sendEmailResultInstance.ShouldNotBeNull();
            _sendEmailResultInstanceFixture.ShouldNotBeNull();
            _sendEmailResultInstance.ShouldBeAssignableTo<SendEmailResult>();
            _sendEmailResultInstanceFixture.ShouldBeAssignableTo<SendEmailResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SendEmailResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SendEmailResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SendEmailResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sendEmailResultInstanceType.ShouldNotBeNull();
            _sendEmailResultInstance.ShouldNotBeNull();
            _sendEmailResultInstanceFixture.ShouldNotBeNull();
            _sendEmailResultInstance.ShouldBeAssignableTo<SendEmailResult>();
            _sendEmailResultInstanceFixture.ShouldBeAssignableTo<SendEmailResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SendEmailResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(SendEmailError[]) , Propertyerrors)]
        [TestCaseGeneric(typeof(bool) , Propertysuccess)]
        public void AUT_SendEmailResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SendEmailResult, T>(_sendEmailResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SendEmailResult) => Property (errors) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SendEmailResult_errors_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyerrors);
            Action currentAction = () => propertyInfo.SetValue(_sendEmailResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SendEmailResult) => Property (errors) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SendEmailResult_Public_Class_errors_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyerrors);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SendEmailResult) => Property (success) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SendEmailResult_Public_Class_success_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysuccess);

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