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
using LeadConvertResult = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.LeadConvertResult" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LeadConvertResultTest : AbstractBaseSetupTypedTest<LeadConvertResult>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LeadConvertResult) Initializer

        private const string PropertyaccountId = "accountId";
        private const string PropertycontactId = "contactId";
        private const string Propertyerrors = "errors";
        private const string PropertyleadId = "leadId";
        private const string PropertyopportunityId = "opportunityId";
        private const string Propertysuccess = "success";
        private const string FieldaccountIdField = "accountIdField";
        private const string FieldcontactIdField = "contactIdField";
        private const string FielderrorsField = "errorsField";
        private const string FieldleadIdField = "leadIdField";
        private const string FieldopportunityIdField = "opportunityIdField";
        private const string FieldsuccessField = "successField";
        private Type _leadConvertResultInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LeadConvertResult _leadConvertResultInstance;
        private LeadConvertResult _leadConvertResultInstanceFixture;

        #region General Initializer : Class (LeadConvertResult) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LeadConvertResult" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _leadConvertResultInstanceType = typeof(LeadConvertResult);
            _leadConvertResultInstanceFixture = Create(true);
            _leadConvertResultInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LeadConvertResult)

        #region General Initializer : Class (LeadConvertResult) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LeadConvertResult" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyaccountId)]
        [TestCase(PropertycontactId)]
        [TestCase(Propertyerrors)]
        [TestCase(PropertyleadId)]
        [TestCase(PropertyopportunityId)]
        [TestCase(Propertysuccess)]
        public void AUT_LeadConvertResult_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_leadConvertResultInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LeadConvertResult) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LeadConvertResult" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaccountIdField)]
        [TestCase(FieldcontactIdField)]
        [TestCase(FielderrorsField)]
        [TestCase(FieldleadIdField)]
        [TestCase(FieldopportunityIdField)]
        [TestCase(FieldsuccessField)]
        public void AUT_LeadConvertResult_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_leadConvertResultInstanceFixture, 
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
        ///     Class (<see cref="LeadConvertResult" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LeadConvertResult_Is_Instance_Present_Test()
        {
            // Assert
            _leadConvertResultInstanceType.ShouldNotBeNull();
            _leadConvertResultInstance.ShouldNotBeNull();
            _leadConvertResultInstanceFixture.ShouldNotBeNull();
            _leadConvertResultInstance.ShouldBeAssignableTo<LeadConvertResult>();
            _leadConvertResultInstanceFixture.ShouldBeAssignableTo<LeadConvertResult>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LeadConvertResult) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LeadConvertResult_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LeadConvertResult instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _leadConvertResultInstanceType.ShouldNotBeNull();
            _leadConvertResultInstance.ShouldNotBeNull();
            _leadConvertResultInstanceFixture.ShouldNotBeNull();
            _leadConvertResultInstance.ShouldBeAssignableTo<LeadConvertResult>();
            _leadConvertResultInstanceFixture.ShouldBeAssignableTo<LeadConvertResult>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LeadConvertResult) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyaccountId)]
        [TestCaseGeneric(typeof(string) , PropertycontactId)]
        [TestCaseGeneric(typeof(Error[]) , Propertyerrors)]
        [TestCaseGeneric(typeof(string) , PropertyleadId)]
        [TestCaseGeneric(typeof(string) , PropertyopportunityId)]
        [TestCaseGeneric(typeof(bool) , Propertysuccess)]
        public void AUT_LeadConvertResult_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LeadConvertResult, T>(_leadConvertResultInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LeadConvertResult) => Property (accountId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvertResult_Public_Class_accountId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaccountId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeadConvertResult) => Property (contactId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvertResult_Public_Class_contactId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycontactId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeadConvertResult) => Property (errors) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvertResult_errors_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyerrors);
            Action currentAction = () => propertyInfo.SetValue(_leadConvertResultInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LeadConvertResult) => Property (errors) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvertResult_Public_Class_errors_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LeadConvertResult) => Property (leadId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvertResult_Public_Class_leadId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyleadId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeadConvertResult) => Property (opportunityId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvertResult_Public_Class_opportunityId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyopportunityId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeadConvertResult) => Property (success) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvertResult_Public_Class_success_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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