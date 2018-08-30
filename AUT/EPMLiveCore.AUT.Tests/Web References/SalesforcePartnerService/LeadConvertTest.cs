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
using LeadConvert = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.LeadConvert" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LeadConvertTest : AbstractBaseSetupTypedTest<LeadConvert>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LeadConvert) Initializer

        private const string PropertyaccountId = "accountId";
        private const string PropertycontactId = "contactId";
        private const string PropertyconvertedStatus = "convertedStatus";
        private const string PropertydoNotCreateOpportunity = "doNotCreateOpportunity";
        private const string PropertyleadId = "leadId";
        private const string PropertyopportunityName = "opportunityName";
        private const string PropertyoverwriteLeadSource = "overwriteLeadSource";
        private const string PropertyownerId = "ownerId";
        private const string PropertysendNotificationEmail = "sendNotificationEmail";
        private const string FieldaccountIdField = "accountIdField";
        private const string FieldcontactIdField = "contactIdField";
        private const string FieldconvertedStatusField = "convertedStatusField";
        private const string FielddoNotCreateOpportunityField = "doNotCreateOpportunityField";
        private const string FieldleadIdField = "leadIdField";
        private const string FieldopportunityNameField = "opportunityNameField";
        private const string FieldoverwriteLeadSourceField = "overwriteLeadSourceField";
        private const string FieldownerIdField = "ownerIdField";
        private const string FieldsendNotificationEmailField = "sendNotificationEmailField";
        private Type _leadConvertInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LeadConvert _leadConvertInstance;
        private LeadConvert _leadConvertInstanceFixture;

        #region General Initializer : Class (LeadConvert) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LeadConvert" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _leadConvertInstanceType = typeof(LeadConvert);
            _leadConvertInstanceFixture = Create(true);
            _leadConvertInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LeadConvert)

        #region General Initializer : Class (LeadConvert) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LeadConvert" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyaccountId)]
        [TestCase(PropertycontactId)]
        [TestCase(PropertyconvertedStatus)]
        [TestCase(PropertydoNotCreateOpportunity)]
        [TestCase(PropertyleadId)]
        [TestCase(PropertyopportunityName)]
        [TestCase(PropertyoverwriteLeadSource)]
        [TestCase(PropertyownerId)]
        [TestCase(PropertysendNotificationEmail)]
        public void AUT_LeadConvert_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_leadConvertInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LeadConvert) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LeadConvert" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaccountIdField)]
        [TestCase(FieldcontactIdField)]
        [TestCase(FieldconvertedStatusField)]
        [TestCase(FielddoNotCreateOpportunityField)]
        [TestCase(FieldleadIdField)]
        [TestCase(FieldopportunityNameField)]
        [TestCase(FieldoverwriteLeadSourceField)]
        [TestCase(FieldownerIdField)]
        [TestCase(FieldsendNotificationEmailField)]
        public void AUT_LeadConvert_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_leadConvertInstanceFixture, 
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
        ///     Class (<see cref="LeadConvert" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LeadConvert_Is_Instance_Present_Test()
        {
            // Assert
            _leadConvertInstanceType.ShouldNotBeNull();
            _leadConvertInstance.ShouldNotBeNull();
            _leadConvertInstanceFixture.ShouldNotBeNull();
            _leadConvertInstance.ShouldBeAssignableTo<LeadConvert>();
            _leadConvertInstanceFixture.ShouldBeAssignableTo<LeadConvert>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LeadConvert) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LeadConvert_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LeadConvert instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _leadConvertInstanceType.ShouldNotBeNull();
            _leadConvertInstance.ShouldNotBeNull();
            _leadConvertInstanceFixture.ShouldNotBeNull();
            _leadConvertInstance.ShouldBeAssignableTo<LeadConvert>();
            _leadConvertInstanceFixture.ShouldBeAssignableTo<LeadConvert>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LeadConvert) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyaccountId)]
        [TestCaseGeneric(typeof(string) , PropertycontactId)]
        [TestCaseGeneric(typeof(string) , PropertyconvertedStatus)]
        [TestCaseGeneric(typeof(bool) , PropertydoNotCreateOpportunity)]
        [TestCaseGeneric(typeof(string) , PropertyleadId)]
        [TestCaseGeneric(typeof(string) , PropertyopportunityName)]
        [TestCaseGeneric(typeof(bool) , PropertyoverwriteLeadSource)]
        [TestCaseGeneric(typeof(string) , PropertyownerId)]
        [TestCaseGeneric(typeof(bool) , PropertysendNotificationEmail)]
        public void AUT_LeadConvert_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LeadConvert, T>(_leadConvertInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LeadConvert) => Property (accountId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvert_Public_Class_accountId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LeadConvert) => Property (contactId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvert_Public_Class_contactId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LeadConvert) => Property (convertedStatus) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvert_Public_Class_convertedStatus_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyconvertedStatus);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeadConvert) => Property (doNotCreateOpportunity) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvert_Public_Class_doNotCreateOpportunity_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydoNotCreateOpportunity);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeadConvert) => Property (leadId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvert_Public_Class_leadId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LeadConvert) => Property (opportunityName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvert_Public_Class_opportunityName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyopportunityName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeadConvert) => Property (overwriteLeadSource) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvert_Public_Class_overwriteLeadSource_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyoverwriteLeadSource);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeadConvert) => Property (ownerId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvert_Public_Class_ownerId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyownerId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LeadConvert) => Property (sendNotificationEmail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LeadConvert_Public_Class_sendNotificationEmail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysendNotificationEmail);

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