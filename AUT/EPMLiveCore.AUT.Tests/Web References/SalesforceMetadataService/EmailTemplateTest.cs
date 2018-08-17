using System;
using System.Diagnostics.CodeAnalysis;
using Action = System.Action;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Should = Shouldly.Should;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.EmailTemplate" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class EmailTemplateTest : AbstractBaseSetupTypedTest<EmailTemplate>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (EmailTemplate) Initializer

        private const string PropertyapiVersion = "apiVersion";
        private const string PropertyapiVersionSpecified = "apiVersionSpecified";
        private const string PropertyattachedDocuments = "attachedDocuments";
        private const string Propertyattachments = "attachments";
        private const string Propertyavailable = "available";
        private const string Propertydescription = "description";
        private const string PropertyencodingKey = "encodingKey";
        private const string Propertyletterhead = "letterhead";
        private const string Propertyname = "name";
        private const string PropertypackageVersions = "packageVersions";
        private const string Propertystyle = "style";
        private const string Propertysubject = "subject";
        private const string PropertytextOnly = "textOnly";
        private const string Propertytype = "type";
        private const string FieldapiVersionField = "apiVersionField";
        private const string FieldapiVersionFieldSpecified = "apiVersionFieldSpecified";
        private const string FieldattachedDocumentsField = "attachedDocumentsField";
        private const string FieldattachmentsField = "attachmentsField";
        private const string FieldavailableField = "availableField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldencodingKeyField = "encodingKeyField";
        private const string FieldletterheadField = "letterheadField";
        private const string FieldnameField = "nameField";
        private const string FieldpackageVersionsField = "packageVersionsField";
        private const string FieldstyleField = "styleField";
        private const string FieldsubjectField = "subjectField";
        private const string FieldtextOnlyField = "textOnlyField";
        private const string FieldtypeField = "typeField";
        private Type _emailTemplateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private EmailTemplate _emailTemplateInstance;
        private EmailTemplate _emailTemplateInstanceFixture;

        #region General Initializer : Class (EmailTemplate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="EmailTemplate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _emailTemplateInstanceType = typeof(EmailTemplate);
            _emailTemplateInstanceFixture = Create(true);
            _emailTemplateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (EmailTemplate)

        #region General Initializer : Class (EmailTemplate) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="EmailTemplate" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyapiVersion)]
        [TestCase(PropertyapiVersionSpecified)]
        [TestCase(PropertyattachedDocuments)]
        [TestCase(Propertyattachments)]
        [TestCase(Propertyavailable)]
        [TestCase(Propertydescription)]
        [TestCase(PropertyencodingKey)]
        [TestCase(Propertyletterhead)]
        [TestCase(Propertyname)]
        [TestCase(PropertypackageVersions)]
        [TestCase(Propertystyle)]
        [TestCase(Propertysubject)]
        [TestCase(PropertytextOnly)]
        [TestCase(Propertytype)]
        public void AUT_EmailTemplate_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_emailTemplateInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (EmailTemplate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="EmailTemplate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldapiVersionField)]
        [TestCase(FieldapiVersionFieldSpecified)]
        [TestCase(FieldattachedDocumentsField)]
        [TestCase(FieldattachmentsField)]
        [TestCase(FieldavailableField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldencodingKeyField)]
        [TestCase(FieldletterheadField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldpackageVersionsField)]
        [TestCase(FieldstyleField)]
        [TestCase(FieldsubjectField)]
        [TestCase(FieldtextOnlyField)]
        [TestCase(FieldtypeField)]
        public void AUT_EmailTemplate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_emailTemplateInstanceFixture, 
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
        ///     Class (<see cref="EmailTemplate" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_EmailTemplate_Is_Instance_Present_Test()
        {
            // Assert
            _emailTemplateInstanceType.ShouldNotBeNull();
            _emailTemplateInstance.ShouldNotBeNull();
            _emailTemplateInstanceFixture.ShouldNotBeNull();
            _emailTemplateInstance.ShouldBeAssignableTo<EmailTemplate>();
            _emailTemplateInstanceFixture.ShouldBeAssignableTo<EmailTemplate>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (EmailTemplate) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_EmailTemplate_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            EmailTemplate instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _emailTemplateInstanceType.ShouldNotBeNull();
            _emailTemplateInstance.ShouldNotBeNull();
            _emailTemplateInstanceFixture.ShouldNotBeNull();
            _emailTemplateInstance.ShouldBeAssignableTo<EmailTemplate>();
            _emailTemplateInstanceFixture.ShouldBeAssignableTo<EmailTemplate>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (EmailTemplate) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(double) , PropertyapiVersion)]
        [TestCaseGeneric(typeof(bool) , PropertyapiVersionSpecified)]
        [TestCaseGeneric(typeof(string[]) , PropertyattachedDocuments)]
        [TestCaseGeneric(typeof(Attachment[]) , Propertyattachments)]
        [TestCaseGeneric(typeof(bool) , Propertyavailable)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(Encoding) , PropertyencodingKey)]
        [TestCaseGeneric(typeof(string) , Propertyletterhead)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(PackageVersion[]) , PropertypackageVersions)]
        [TestCaseGeneric(typeof(EmailTemplateStyle) , Propertystyle)]
        [TestCaseGeneric(typeof(string) , Propertysubject)]
        [TestCaseGeneric(typeof(string) , PropertytextOnly)]
        [TestCaseGeneric(typeof(EmailTemplateType) , Propertytype)]
        public void AUT_EmailTemplate_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<EmailTemplate, T>(_emailTemplateInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (apiVersion) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_apiVersion_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyapiVersion);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (apiVersionSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_apiVersionSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyapiVersionSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (attachedDocuments) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_attachedDocuments_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyattachedDocuments);
            Action currentAction = () => propertyInfo.SetValue(_emailTemplateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (attachedDocuments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_attachedDocuments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyattachedDocuments);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (attachments) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_attachments_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyattachments);
            Action currentAction = () => propertyInfo.SetValue(_emailTemplateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (attachments) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_attachments_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyattachments);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (available) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_available_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyavailable);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (encodingKey) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_encodingKey_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyencodingKey);
            Action currentAction = () => propertyInfo.SetValue(_emailTemplateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (encodingKey) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_encodingKey_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyencodingKey);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (letterhead) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_letterhead_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyletterhead);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (packageVersions) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_packageVersions_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertypackageVersions);
            Action currentAction = () => propertyInfo.SetValue(_emailTemplateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (packageVersions) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_packageVersions_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypackageVersions);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (style) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_style_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertystyle);
            Action currentAction = () => propertyInfo.SetValue(_emailTemplateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (style) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_style_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertystyle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (subject) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_subject_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (EmailTemplate) => Property (textOnly) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_textOnly_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytextOnly);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (type) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_type_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytype);
            Action currentAction = () => propertyInfo.SetValue(_emailTemplateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (EmailTemplate) => Property (type) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_EmailTemplate_Public_Class_type_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytype);

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