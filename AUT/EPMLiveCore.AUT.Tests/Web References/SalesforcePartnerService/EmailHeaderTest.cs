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
using EmailHeader = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.EmailHeader" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EmailHeaderTest : AbstractBaseSetupTypedTest<EmailHeader>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EmailHeader) Initializer

        private const string PropertytriggerAutoResponseEmail = "triggerAutoResponseEmail";
        private const string PropertytriggerOtherEmail = "triggerOtherEmail";
        private const string PropertytriggerUserEmail = "triggerUserEmail";
        private const string FieldtriggerAutoResponseEmailField = "triggerAutoResponseEmailField";
        private const string FieldtriggerOtherEmailField = "triggerOtherEmailField";
        private const string FieldtriggerUserEmailField = "triggerUserEmailField";
        private Type _emailHeaderInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EmailHeader _emailHeaderInstance;
        private EmailHeader _emailHeaderInstanceFixture;

        #region General Initializer : Class (EmailHeader) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EmailHeader" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _emailHeaderInstanceType = typeof(EmailHeader);
            _emailHeaderInstanceFixture = Create(true);
            _emailHeaderInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EmailHeader)

        #region General Initializer : Class (EmailHeader) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EmailHeader" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertytriggerAutoResponseEmail)]
        [TestCase(PropertytriggerOtherEmail)]
        [TestCase(PropertytriggerUserEmail)]
        public void AUT_EmailHeader_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_emailHeaderInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EmailHeader) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EmailHeader" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldtriggerAutoResponseEmailField)]
        [TestCase(FieldtriggerOtherEmailField)]
        [TestCase(FieldtriggerUserEmailField)]
        public void AUT_EmailHeader_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_emailHeaderInstanceFixture, 
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
        ///     Class (<see cref="EmailHeader" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EmailHeader_Is_Instance_Present_Test()
        {
            // Assert
            _emailHeaderInstanceType.ShouldNotBeNull();
            _emailHeaderInstance.ShouldNotBeNull();
            _emailHeaderInstanceFixture.ShouldNotBeNull();
            _emailHeaderInstance.ShouldBeAssignableTo<EmailHeader>();
            _emailHeaderInstanceFixture.ShouldBeAssignableTo<EmailHeader>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EmailHeader) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EmailHeader_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EmailHeader instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _emailHeaderInstanceType.ShouldNotBeNull();
            _emailHeaderInstance.ShouldNotBeNull();
            _emailHeaderInstanceFixture.ShouldNotBeNull();
            _emailHeaderInstance.ShouldBeAssignableTo<EmailHeader>();
            _emailHeaderInstanceFixture.ShouldBeAssignableTo<EmailHeader>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EmailHeader) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertytriggerAutoResponseEmail)]
        [TestCaseGeneric(typeof(bool) , PropertytriggerOtherEmail)]
        [TestCaseGeneric(typeof(bool) , PropertytriggerUserEmail)]
        public void AUT_EmailHeader_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EmailHeader, T>(_emailHeaderInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EmailHeader) => Property (triggerAutoResponseEmail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailHeader_Public_Class_triggerAutoResponseEmail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytriggerAutoResponseEmail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailHeader) => Property (triggerOtherEmail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailHeader_Public_Class_triggerOtherEmail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytriggerOtherEmail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailHeader) => Property (triggerUserEmail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailHeader_Public_Class_triggerUserEmail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytriggerUserEmail);

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