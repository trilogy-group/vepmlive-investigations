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
using SendEmailError = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.SendEmailError" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SendEmailErrorTest : AbstractBaseSetupTypedTest<SendEmailError>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SendEmailError) Initializer

        private const string Propertyfields = "fields";
        private const string Propertymessage = "message";
        private const string PropertystatusCode = "statusCode";
        private const string PropertytargetObjectId = "targetObjectId";
        private const string FieldfieldsField = "fieldsField";
        private const string FieldmessageField = "messageField";
        private const string FieldstatusCodeField = "statusCodeField";
        private const string FieldtargetObjectIdField = "targetObjectIdField";
        private Type _sendEmailErrorInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SendEmailError _sendEmailErrorInstance;
        private SendEmailError _sendEmailErrorInstanceFixture;

        #region General Initializer : Class (SendEmailError) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SendEmailError" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sendEmailErrorInstanceType = typeof(SendEmailError);
            _sendEmailErrorInstanceFixture = Create(true);
            _sendEmailErrorInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SendEmailError)

        #region General Initializer : Class (SendEmailError) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SendEmailError" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyfields)]
        [TestCase(Propertymessage)]
        [TestCase(PropertystatusCode)]
        [TestCase(PropertytargetObjectId)]
        public void AUT_SendEmailError_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sendEmailErrorInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SendEmailError) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SendEmailError" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfieldsField)]
        [TestCase(FieldmessageField)]
        [TestCase(FieldstatusCodeField)]
        [TestCase(FieldtargetObjectIdField)]
        public void AUT_SendEmailError_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sendEmailErrorInstanceFixture, 
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
        ///     Class (<see cref="SendEmailError" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SendEmailError_Is_Instance_Present_Test()
        {
            // Assert
            _sendEmailErrorInstanceType.ShouldNotBeNull();
            _sendEmailErrorInstance.ShouldNotBeNull();
            _sendEmailErrorInstanceFixture.ShouldNotBeNull();
            _sendEmailErrorInstance.ShouldBeAssignableTo<SendEmailError>();
            _sendEmailErrorInstanceFixture.ShouldBeAssignableTo<SendEmailError>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SendEmailError) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SendEmailError_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SendEmailError instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sendEmailErrorInstanceType.ShouldNotBeNull();
            _sendEmailErrorInstance.ShouldNotBeNull();
            _sendEmailErrorInstanceFixture.ShouldNotBeNull();
            _sendEmailErrorInstance.ShouldBeAssignableTo<SendEmailError>();
            _sendEmailErrorInstanceFixture.ShouldBeAssignableTo<SendEmailError>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SendEmailError) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , Propertyfields)]
        [TestCaseGeneric(typeof(string) , Propertymessage)]
        [TestCaseGeneric(typeof(StatusCode) , PropertystatusCode)]
        [TestCaseGeneric(typeof(string) , PropertytargetObjectId)]
        public void AUT_SendEmailError_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SendEmailError, T>(_sendEmailErrorInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SendEmailError) => Property (fields) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SendEmailError_fields_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyfields);
            Action currentAction = () => propertyInfo.SetValue(_sendEmailErrorInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SendEmailError) => Property (fields) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SendEmailError_Public_Class_fields_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfields);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SendEmailError) => Property (message) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SendEmailError_Public_Class_message_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertymessage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SendEmailError) => Property (statusCode) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SendEmailError_statusCode_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertystatusCode);
            Action currentAction = () => propertyInfo.SetValue(_sendEmailErrorInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SendEmailError) => Property (statusCode) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SendEmailError_Public_Class_statusCode_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystatusCode);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SendEmailError) => Property (targetObjectId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SendEmailError_Public_Class_targetObjectId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytargetObjectId);

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