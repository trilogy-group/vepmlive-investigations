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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Attachment" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AttachmentTest : AbstractBaseSetupTypedTest<Attachment>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Attachment) Initializer

        private const string Propertycontent = "content";
        private const string Propertyname = "name";
        private const string FieldcontentField = "contentField";
        private const string FieldnameField = "nameField";
        private Type _attachmentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Attachment _attachmentInstance;
        private Attachment _attachmentInstanceFixture;

        #region General Initializer : Class (Attachment) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Attachment" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _attachmentInstanceType = typeof(Attachment);
            _attachmentInstanceFixture = Create(true);
            _attachmentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Attachment)

        #region General Initializer : Class (Attachment) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Attachment" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycontent)]
        [TestCase(Propertyname)]
        public void AUT_Attachment_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_attachmentInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Attachment) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Attachment" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcontentField)]
        [TestCase(FieldnameField)]
        public void AUT_Attachment_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_attachmentInstanceFixture, 
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
        ///     Class (<see cref="Attachment" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Attachment_Is_Instance_Present_Test()
        {
            // Assert
            _attachmentInstanceType.ShouldNotBeNull();
            _attachmentInstance.ShouldNotBeNull();
            _attachmentInstanceFixture.ShouldNotBeNull();
            _attachmentInstance.ShouldBeAssignableTo<Attachment>();
            _attachmentInstanceFixture.ShouldBeAssignableTo<Attachment>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Attachment) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Attachment_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Attachment instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _attachmentInstanceType.ShouldNotBeNull();
            _attachmentInstance.ShouldNotBeNull();
            _attachmentInstanceFixture.ShouldNotBeNull();
            _attachmentInstance.ShouldBeAssignableTo<Attachment>();
            _attachmentInstanceFixture.ShouldBeAssignableTo<Attachment>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Attachment) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(byte[]) , Propertycontent)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_Attachment_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Attachment, T>(_attachmentInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Attachment) => Property (content) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Attachment_content_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertycontent);
            Action currentAction = () => propertyInfo.SetValue(_attachmentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Attachment) => Property (content) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Attachment_Public_Class_content_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycontent);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Attachment) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Attachment_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}