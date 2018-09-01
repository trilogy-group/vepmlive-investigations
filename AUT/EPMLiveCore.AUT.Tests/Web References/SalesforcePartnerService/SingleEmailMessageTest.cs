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
using SingleEmailMessage = EPMLiveCore.SalesforcePartnerService;

namespace EPMLiveCore.SalesforcePartnerService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforcePartnerService.SingleEmailMessage" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforcePartnerService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SingleEmailMessageTest : AbstractBaseSetupTypedTest<SingleEmailMessage>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SingleEmailMessage) Initializer

        private const string PropertybccAddresses = "bccAddresses";
        private const string PropertyccAddresses = "ccAddresses";
        private const string Propertycharset = "charset";
        private const string PropertydocumentAttachments = "documentAttachments";
        private const string PropertyhtmlBody = "htmlBody";
        private const string PropertyinReplyTo = "inReplyTo";
        private const string PropertyfileAttachments = "fileAttachments";
        private const string PropertyorgWideEmailAddressId = "orgWideEmailAddressId";
        private const string PropertyplainTextBody = "plainTextBody";
        private const string Propertyreferences = "references";
        private const string PropertytargetObjectId = "targetObjectId";
        private const string PropertytemplateId = "templateId";
        private const string PropertytoAddresses = "toAddresses";
        private const string PropertywhatId = "whatId";
        private const string FieldbccAddressesField = "bccAddressesField";
        private const string FieldccAddressesField = "ccAddressesField";
        private const string FieldcharsetField = "charsetField";
        private const string FielddocumentAttachmentsField = "documentAttachmentsField";
        private const string FieldhtmlBodyField = "htmlBodyField";
        private const string FieldinReplyToField = "inReplyToField";
        private const string FieldfileAttachmentsField = "fileAttachmentsField";
        private const string FieldorgWideEmailAddressIdField = "orgWideEmailAddressIdField";
        private const string FieldplainTextBodyField = "plainTextBodyField";
        private const string FieldreferencesField = "referencesField";
        private const string FieldtargetObjectIdField = "targetObjectIdField";
        private const string FieldtemplateIdField = "templateIdField";
        private const string FieldtoAddressesField = "toAddressesField";
        private const string FieldwhatIdField = "whatIdField";
        private Type _singleEmailMessageInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SingleEmailMessage _singleEmailMessageInstance;
        private SingleEmailMessage _singleEmailMessageInstanceFixture;

        #region General Initializer : Class (SingleEmailMessage) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SingleEmailMessage" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _singleEmailMessageInstanceType = typeof(SingleEmailMessage);
            _singleEmailMessageInstanceFixture = Create(true);
            _singleEmailMessageInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SingleEmailMessage)

        #region General Initializer : Class (SingleEmailMessage) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SingleEmailMessage" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybccAddresses)]
        [TestCase(PropertyccAddresses)]
        [TestCase(Propertycharset)]
        [TestCase(PropertydocumentAttachments)]
        [TestCase(PropertyhtmlBody)]
        [TestCase(PropertyinReplyTo)]
        [TestCase(PropertyfileAttachments)]
        [TestCase(PropertyorgWideEmailAddressId)]
        [TestCase(PropertyplainTextBody)]
        [TestCase(Propertyreferences)]
        [TestCase(PropertytargetObjectId)]
        [TestCase(PropertytemplateId)]
        [TestCase(PropertytoAddresses)]
        [TestCase(PropertywhatId)]
        public void AUT_SingleEmailMessage_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_singleEmailMessageInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SingleEmailMessage) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SingleEmailMessage" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbccAddressesField)]
        [TestCase(FieldccAddressesField)]
        [TestCase(FieldcharsetField)]
        [TestCase(FielddocumentAttachmentsField)]
        [TestCase(FieldhtmlBodyField)]
        [TestCase(FieldinReplyToField)]
        [TestCase(FieldfileAttachmentsField)]
        [TestCase(FieldorgWideEmailAddressIdField)]
        [TestCase(FieldplainTextBodyField)]
        [TestCase(FieldreferencesField)]
        [TestCase(FieldtargetObjectIdField)]
        [TestCase(FieldtemplateIdField)]
        [TestCase(FieldtoAddressesField)]
        [TestCase(FieldwhatIdField)]
        public void AUT_SingleEmailMessage_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_singleEmailMessageInstanceFixture, 
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
        ///     Class (<see cref="SingleEmailMessage" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SingleEmailMessage_Is_Instance_Present_Test()
        {
            // Assert
            _singleEmailMessageInstanceType.ShouldNotBeNull();
            _singleEmailMessageInstance.ShouldNotBeNull();
            _singleEmailMessageInstanceFixture.ShouldNotBeNull();
            _singleEmailMessageInstance.ShouldBeAssignableTo<SingleEmailMessage>();
            _singleEmailMessageInstanceFixture.ShouldBeAssignableTo<SingleEmailMessage>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SingleEmailMessage) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SingleEmailMessage_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SingleEmailMessage instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _singleEmailMessageInstanceType.ShouldNotBeNull();
            _singleEmailMessageInstance.ShouldNotBeNull();
            _singleEmailMessageInstanceFixture.ShouldNotBeNull();
            _singleEmailMessageInstance.ShouldBeAssignableTo<SingleEmailMessage>();
            _singleEmailMessageInstanceFixture.ShouldBeAssignableTo<SingleEmailMessage>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SingleEmailMessage) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , PropertybccAddresses)]
        [TestCaseGeneric(typeof(string[]) , PropertyccAddresses)]
        [TestCaseGeneric(typeof(string) , Propertycharset)]
        [TestCaseGeneric(typeof(string[]) , PropertydocumentAttachments)]
        [TestCaseGeneric(typeof(string) , PropertyhtmlBody)]
        [TestCaseGeneric(typeof(string) , PropertyinReplyTo)]
        [TestCaseGeneric(typeof(EmailFileAttachment[]) , PropertyfileAttachments)]
        [TestCaseGeneric(typeof(string) , PropertyorgWideEmailAddressId)]
        [TestCaseGeneric(typeof(string) , PropertyplainTextBody)]
        [TestCaseGeneric(typeof(string) , Propertyreferences)]
        [TestCaseGeneric(typeof(string) , PropertytargetObjectId)]
        [TestCaseGeneric(typeof(string) , PropertytemplateId)]
        [TestCaseGeneric(typeof(string[]) , PropertytoAddresses)]
        [TestCaseGeneric(typeof(string) , PropertywhatId)]
        public void AUT_SingleEmailMessage_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SingleEmailMessage, T>(_singleEmailMessageInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (bccAddresses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_bccAddresses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertybccAddresses);
            Action currentAction = () => propertyInfo.SetValue(_singleEmailMessageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (bccAddresses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_bccAddresses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybccAddresses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (ccAddresses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_ccAddresses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyccAddresses);
            Action currentAction = () => propertyInfo.SetValue(_singleEmailMessageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (ccAddresses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_ccAddresses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyccAddresses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (charset) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_charset_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycharset);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (documentAttachments) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_documentAttachments_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydocumentAttachments);
            Action currentAction = () => propertyInfo.SetValue(_singleEmailMessageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (documentAttachments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_documentAttachments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydocumentAttachments);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (fileAttachments) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_fileAttachments_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyfileAttachments);
            Action currentAction = () => propertyInfo.SetValue(_singleEmailMessageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (fileAttachments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_fileAttachments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfileAttachments);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (htmlBody) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_htmlBody_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhtmlBody);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (inReplyTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_inReplyTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyinReplyTo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (orgWideEmailAddressId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_orgWideEmailAddressId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyorgWideEmailAddressId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (plainTextBody) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_plainTextBody_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyplainTextBody);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (references) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_references_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyreferences);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (targetObjectId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_targetObjectId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (templateId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_templateId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytemplateId);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (toAddresses) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_toAddresses_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertytoAddresses);
            Action currentAction = () => propertyInfo.SetValue(_singleEmailMessageInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (toAddresses) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_toAddresses_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytoAddresses);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SingleEmailMessage) => Property (whatId) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SingleEmailMessage_Public_Class_whatId_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertywhatId);

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