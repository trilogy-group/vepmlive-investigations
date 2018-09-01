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
using Email = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.Email" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EmailTest : AbstractBaseSetupTypedTest<Email>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Email) Initializer

        private const string PropertybccSender = "bccSender";
        private const string PropertyemailPriority = "emailPriority";
        private const string PropertyreplyTo = "replyTo";
        private const string PropertysaveAsActivity = "saveAsActivity";
        private const string PropertysenderDisplayName = "senderDisplayName";
        private const string Propertysubject = "subject";
        private const string PropertyuseSignature = "useSignature";
        private const string FieldbccSenderField = "bccSenderField";
        private const string FieldemailPriorityField = "emailPriorityField";
        private const string FieldreplyToField = "replyToField";
        private const string FieldsaveAsActivityField = "saveAsActivityField";
        private const string FieldsenderDisplayNameField = "senderDisplayNameField";
        private const string FieldsubjectField = "subjectField";
        private const string FielduseSignatureField = "useSignatureField";
        private Type _emailInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Email _emailInstance;
        private Email _emailInstanceFixture;

        #region General Initializer : Class (Email) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Email" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _emailInstanceType = typeof(Email);
            _emailInstanceFixture = Create(true);
            _emailInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Email)

        #region General Initializer : Class (Email) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Email" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybccSender)]
        [TestCase(PropertyemailPriority)]
        [TestCase(PropertyreplyTo)]
        [TestCase(PropertysaveAsActivity)]
        [TestCase(PropertysenderDisplayName)]
        [TestCase(Propertysubject)]
        [TestCase(PropertyuseSignature)]
        public void AUT_Email_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_emailInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Email) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Email" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbccSenderField)]
        [TestCase(FieldemailPriorityField)]
        [TestCase(FieldreplyToField)]
        [TestCase(FieldsaveAsActivityField)]
        [TestCase(FieldsenderDisplayNameField)]
        [TestCase(FieldsubjectField)]
        [TestCase(FielduseSignatureField)]
        public void AUT_Email_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_emailInstanceFixture, 
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
        ///     Class (<see cref="Email" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Email_Is_Instance_Present_Test()
        {
            // Assert
            _emailInstanceType.ShouldNotBeNull();
            _emailInstance.ShouldNotBeNull();
            _emailInstanceFixture.ShouldNotBeNull();
            _emailInstance.ShouldBeAssignableTo<Email>();
            _emailInstanceFixture.ShouldBeAssignableTo<Email>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Email) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Email_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Email instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _emailInstanceType.ShouldNotBeNull();
            _emailInstance.ShouldNotBeNull();
            _emailInstanceFixture.ShouldNotBeNull();
            _emailInstance.ShouldBeAssignableTo<Email>();
            _emailInstanceFixture.ShouldBeAssignableTo<Email>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Email) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(System.Nullable<bool>) , PropertybccSender)]
        [TestCaseGeneric(typeof(System.Nullable<EmailPriority>) , PropertyemailPriority)]
        [TestCaseGeneric(typeof(string) , PropertyreplyTo)]
        [TestCaseGeneric(typeof(System.Nullable<bool>) , PropertysaveAsActivity)]
        [TestCaseGeneric(typeof(string) , PropertysenderDisplayName)]
        [TestCaseGeneric(typeof(string) , Propertysubject)]
        [TestCaseGeneric(typeof(System.Nullable<bool>) , PropertyuseSignature)]
        public void AUT_Email_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Email, T>(_emailInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Email) => Property (bccSender) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Email_Public_Class_bccSender_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybccSender);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Email) => Property (emailPriority) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Email_Public_Class_emailPriority_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemailPriority);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Email) => Property (replyTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Email_Public_Class_replyTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreplyTo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Email) => Property (saveAsActivity) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Email_Public_Class_saveAsActivity_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysaveAsActivity);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Email) => Property (senderDisplayName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Email_Public_Class_senderDisplayName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysenderDisplayName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Email) => Property (subject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Email_Public_Class_subject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysubject);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Email) => Property (useSignature) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Email_Public_Class_useSignature_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseSignature);

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