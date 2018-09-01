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
using EmailFileAttachment = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.EmailFileAttachment" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EmailFileAttachmentTest : AbstractBaseSetupTypedTest<EmailFileAttachment>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EmailFileAttachment) Initializer

        private const string Propertybody = "body";
        private const string PropertycontentType = "contentType";
        private const string PropertyfileName = "fileName";
        private const string Propertyinline = "inline";
        private const string PropertyinlineSpecified = "inlineSpecified";
        private const string FieldbodyField = "bodyField";
        private const string FieldcontentTypeField = "contentTypeField";
        private const string FieldfileNameField = "fileNameField";
        private const string FieldinlineField = "inlineField";
        private const string FieldinlineFieldSpecified = "inlineFieldSpecified";
        private Type _emailFileAttachmentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EmailFileAttachment _emailFileAttachmentInstance;
        private EmailFileAttachment _emailFileAttachmentInstanceFixture;

        #region General Initializer : Class (EmailFileAttachment) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EmailFileAttachment" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _emailFileAttachmentInstanceType = typeof(EmailFileAttachment);
            _emailFileAttachmentInstanceFixture = Create(true);
            _emailFileAttachmentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EmailFileAttachment)

        #region General Initializer : Class (EmailFileAttachment) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EmailFileAttachment" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertybody)]
        [TestCase(PropertycontentType)]
        [TestCase(PropertyfileName)]
        [TestCase(Propertyinline)]
        [TestCase(PropertyinlineSpecified)]
        public void AUT_EmailFileAttachment_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_emailFileAttachmentInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EmailFileAttachment) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EmailFileAttachment" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbodyField)]
        [TestCase(FieldcontentTypeField)]
        [TestCase(FieldfileNameField)]
        [TestCase(FieldinlineField)]
        [TestCase(FieldinlineFieldSpecified)]
        public void AUT_EmailFileAttachment_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_emailFileAttachmentInstanceFixture, 
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
        ///     Class (<see cref="EmailFileAttachment" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EmailFileAttachment_Is_Instance_Present_Test()
        {
            // Assert
            _emailFileAttachmentInstanceType.ShouldNotBeNull();
            _emailFileAttachmentInstance.ShouldNotBeNull();
            _emailFileAttachmentInstanceFixture.ShouldNotBeNull();
            _emailFileAttachmentInstance.ShouldBeAssignableTo<EmailFileAttachment>();
            _emailFileAttachmentInstanceFixture.ShouldBeAssignableTo<EmailFileAttachment>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EmailFileAttachment) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EmailFileAttachment_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EmailFileAttachment instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _emailFileAttachmentInstanceType.ShouldNotBeNull();
            _emailFileAttachmentInstance.ShouldNotBeNull();
            _emailFileAttachmentInstanceFixture.ShouldNotBeNull();
            _emailFileAttachmentInstance.ShouldBeAssignableTo<EmailFileAttachment>();
            _emailFileAttachmentInstanceFixture.ShouldBeAssignableTo<EmailFileAttachment>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EmailFileAttachment) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(byte[]) , Propertybody)]
        [TestCaseGeneric(typeof(string) , PropertycontentType)]
        [TestCaseGeneric(typeof(string) , PropertyfileName)]
        [TestCaseGeneric(typeof(bool) , Propertyinline)]
        [TestCaseGeneric(typeof(bool) , PropertyinlineSpecified)]
        public void AUT_EmailFileAttachment_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EmailFileAttachment, T>(_emailFileAttachmentInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EmailFileAttachment) => Property (body) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailFileAttachment_body_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertybody);
            Action currentAction = () => propertyInfo.SetValue(_emailFileAttachmentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EmailFileAttachment) => Property (body) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailFileAttachment_Public_Class_body_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertybody);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailFileAttachment) => Property (contentType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailFileAttachment_Public_Class_contentType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycontentType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailFileAttachment) => Property (fileName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailFileAttachment_Public_Class_fileName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfileName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailFileAttachment) => Property (inline) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailFileAttachment_Public_Class_inline_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyinline);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailFileAttachment) => Property (inlineSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailFileAttachment_Public_Class_inlineSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyinlineSpecified);

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