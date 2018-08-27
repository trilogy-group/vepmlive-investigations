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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ArticleTypeTemplate" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ArticleTypeTemplateTest : AbstractBaseSetupTypedTest<ArticleTypeTemplate>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ArticleTypeTemplate) Initializer

        private const string Propertychannel = "channel";
        private const string Propertypage = "page";
        private const string Propertytemplate = "template";
        private const string FieldchannelField = "channelField";
        private const string FieldpageField = "pageField";
        private const string FieldtemplateField = "templateField";
        private Type _articleTypeTemplateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ArticleTypeTemplate _articleTypeTemplateInstance;
        private ArticleTypeTemplate _articleTypeTemplateInstanceFixture;

        #region General Initializer : Class (ArticleTypeTemplate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ArticleTypeTemplate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _articleTypeTemplateInstanceType = typeof(ArticleTypeTemplate);
            _articleTypeTemplateInstanceFixture = Create(true);
            _articleTypeTemplateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ArticleTypeTemplate)

        #region General Initializer : Class (ArticleTypeTemplate) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ArticleTypeTemplate" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertychannel)]
        [TestCase(Propertypage)]
        [TestCase(Propertytemplate)]
        public void AUT_ArticleTypeTemplate_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_articleTypeTemplateInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ArticleTypeTemplate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ArticleTypeTemplate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldchannelField)]
        [TestCase(FieldpageField)]
        [TestCase(FieldtemplateField)]
        public void AUT_ArticleTypeTemplate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_articleTypeTemplateInstanceFixture, 
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
        ///     Class (<see cref="ArticleTypeTemplate" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ArticleTypeTemplate_Is_Instance_Present_Test()
        {
            // Assert
            _articleTypeTemplateInstanceType.ShouldNotBeNull();
            _articleTypeTemplateInstance.ShouldNotBeNull();
            _articleTypeTemplateInstanceFixture.ShouldNotBeNull();
            _articleTypeTemplateInstance.ShouldBeAssignableTo<ArticleTypeTemplate>();
            _articleTypeTemplateInstanceFixture.ShouldBeAssignableTo<ArticleTypeTemplate>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ArticleTypeTemplate) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ArticleTypeTemplate_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ArticleTypeTemplate instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _articleTypeTemplateInstanceType.ShouldNotBeNull();
            _articleTypeTemplateInstance.ShouldNotBeNull();
            _articleTypeTemplateInstanceFixture.ShouldNotBeNull();
            _articleTypeTemplateInstance.ShouldBeAssignableTo<ArticleTypeTemplate>();
            _articleTypeTemplateInstanceFixture.ShouldBeAssignableTo<ArticleTypeTemplate>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ArticleTypeTemplate) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Channel) , Propertychannel)]
        [TestCaseGeneric(typeof(string) , Propertypage)]
        [TestCaseGeneric(typeof(Template) , Propertytemplate)]
        public void AUT_ArticleTypeTemplate_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ArticleTypeTemplate, T>(_articleTypeTemplateInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ArticleTypeTemplate) => Property (channel) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ArticleTypeTemplate_channel_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertychannel);
            Action currentAction = () => propertyInfo.SetValue(_articleTypeTemplateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ArticleTypeTemplate) => Property (channel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ArticleTypeTemplate_Public_Class_channel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertychannel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ArticleTypeTemplate) => Property (page) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ArticleTypeTemplate_Public_Class_page_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertypage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ArticleTypeTemplate) => Property (template) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ArticleTypeTemplate_template_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertytemplate);
            Action currentAction = () => propertyInfo.SetValue(_articleTypeTemplateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ArticleTypeTemplate) => Property (template) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ArticleTypeTemplate_Public_Class_template_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytemplate);

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