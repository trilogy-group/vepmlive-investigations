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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.KnowledgeCaseSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class KnowledgeCaseSettingsTest : AbstractBaseSetupTypedTest<KnowledgeCaseSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (KnowledgeCaseSettings) Initializer

        private const string PropertyarticlePDFCreationProfile = "articlePDFCreationProfile";
        private const string PropertyarticlePublicSharingSites = "articlePublicSharingSites";
        private const string PropertyarticlePublicSharingSitesChatterAnswers = "articlePublicSharingSitesChatterAnswers";
        private const string PropertyassignTo = "assignTo";
        private const string PropertycustomizationClass = "customizationClass";
        private const string PropertydefaultContributionArticleType = "defaultContributionArticleType";
        private const string Propertyeditor = "editor";
        private const string PropertyeditorSpecified = "editorSpecified";
        private const string PropertyenableArticleCreation = "enableArticleCreation";
        private const string PropertyenableArticleCreationSpecified = "enableArticleCreationSpecified";
        private const string PropertyenableArticlePublicSharingSites = "enableArticlePublicSharingSites";
        private const string PropertyenableArticlePublicSharingSitesSpecified = "enableArticlePublicSharingSitesSpecified";
        private const string PropertyuseProfileForPDFCreation = "useProfileForPDFCreation";
        private const string PropertyuseProfileForPDFCreationSpecified = "useProfileForPDFCreationSpecified";
        private const string FieldarticlePDFCreationProfileField = "articlePDFCreationProfileField";
        private const string FieldarticlePublicSharingSitesField = "articlePublicSharingSitesField";
        private const string FieldarticlePublicSharingSitesChatterAnswersField = "articlePublicSharingSitesChatterAnswersField";
        private const string FieldassignToField = "assignToField";
        private const string FieldcustomizationClassField = "customizationClassField";
        private const string FielddefaultContributionArticleTypeField = "defaultContributionArticleTypeField";
        private const string FieldeditorField = "editorField";
        private const string FieldeditorFieldSpecified = "editorFieldSpecified";
        private const string FieldenableArticleCreationField = "enableArticleCreationField";
        private const string FieldenableArticleCreationFieldSpecified = "enableArticleCreationFieldSpecified";
        private const string FieldenableArticlePublicSharingSitesField = "enableArticlePublicSharingSitesField";
        private const string FieldenableArticlePublicSharingSitesFieldSpecified = "enableArticlePublicSharingSitesFieldSpecified";
        private const string FielduseProfileForPDFCreationField = "useProfileForPDFCreationField";
        private const string FielduseProfileForPDFCreationFieldSpecified = "useProfileForPDFCreationFieldSpecified";
        private Type _knowledgeCaseSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private KnowledgeCaseSettings _knowledgeCaseSettingsInstance;
        private KnowledgeCaseSettings _knowledgeCaseSettingsInstanceFixture;

        #region General Initializer : Class (KnowledgeCaseSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="KnowledgeCaseSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _knowledgeCaseSettingsInstanceType = typeof(KnowledgeCaseSettings);
            _knowledgeCaseSettingsInstanceFixture = Create(true);
            _knowledgeCaseSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (KnowledgeCaseSettings)

        #region General Initializer : Class (KnowledgeCaseSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="KnowledgeCaseSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyarticlePDFCreationProfile)]
        [TestCase(PropertyarticlePublicSharingSites)]
        [TestCase(PropertyarticlePublicSharingSitesChatterAnswers)]
        [TestCase(PropertyassignTo)]
        [TestCase(PropertycustomizationClass)]
        [TestCase(PropertydefaultContributionArticleType)]
        [TestCase(Propertyeditor)]
        [TestCase(PropertyeditorSpecified)]
        [TestCase(PropertyenableArticleCreation)]
        [TestCase(PropertyenableArticleCreationSpecified)]
        [TestCase(PropertyenableArticlePublicSharingSites)]
        [TestCase(PropertyenableArticlePublicSharingSitesSpecified)]
        [TestCase(PropertyuseProfileForPDFCreation)]
        [TestCase(PropertyuseProfileForPDFCreationSpecified)]
        public void AUT_KnowledgeCaseSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_knowledgeCaseSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (KnowledgeCaseSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="KnowledgeCaseSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldarticlePDFCreationProfileField)]
        [TestCase(FieldarticlePublicSharingSitesField)]
        [TestCase(FieldarticlePublicSharingSitesChatterAnswersField)]
        [TestCase(FieldassignToField)]
        [TestCase(FieldcustomizationClassField)]
        [TestCase(FielddefaultContributionArticleTypeField)]
        [TestCase(FieldeditorField)]
        [TestCase(FieldeditorFieldSpecified)]
        [TestCase(FieldenableArticleCreationField)]
        [TestCase(FieldenableArticleCreationFieldSpecified)]
        [TestCase(FieldenableArticlePublicSharingSitesField)]
        [TestCase(FieldenableArticlePublicSharingSitesFieldSpecified)]
        [TestCase(FielduseProfileForPDFCreationField)]
        [TestCase(FielduseProfileForPDFCreationFieldSpecified)]
        public void AUT_KnowledgeCaseSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_knowledgeCaseSettingsInstanceFixture, 
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
        ///     Class (<see cref="KnowledgeCaseSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_KnowledgeCaseSettings_Is_Instance_Present_Test()
        {
            // Assert
            _knowledgeCaseSettingsInstanceType.ShouldNotBeNull();
            _knowledgeCaseSettingsInstance.ShouldNotBeNull();
            _knowledgeCaseSettingsInstanceFixture.ShouldNotBeNull();
            _knowledgeCaseSettingsInstance.ShouldBeAssignableTo<KnowledgeCaseSettings>();
            _knowledgeCaseSettingsInstanceFixture.ShouldBeAssignableTo<KnowledgeCaseSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (KnowledgeCaseSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_KnowledgeCaseSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            KnowledgeCaseSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _knowledgeCaseSettingsInstanceType.ShouldNotBeNull();
            _knowledgeCaseSettingsInstance.ShouldNotBeNull();
            _knowledgeCaseSettingsInstanceFixture.ShouldNotBeNull();
            _knowledgeCaseSettingsInstance.ShouldBeAssignableTo<KnowledgeCaseSettings>();
            _knowledgeCaseSettingsInstanceFixture.ShouldBeAssignableTo<KnowledgeCaseSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyarticlePDFCreationProfile)]
        [TestCaseGeneric(typeof(string[]) , PropertyarticlePublicSharingSites)]
        [TestCaseGeneric(typeof(string[]) , PropertyarticlePublicSharingSitesChatterAnswers)]
        [TestCaseGeneric(typeof(string) , PropertyassignTo)]
        [TestCaseGeneric(typeof(string) , PropertycustomizationClass)]
        [TestCaseGeneric(typeof(string) , PropertydefaultContributionArticleType)]
        [TestCaseGeneric(typeof(KnowledgeCaseEditor) , Propertyeditor)]
        [TestCaseGeneric(typeof(bool) , PropertyeditorSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableArticleCreation)]
        [TestCaseGeneric(typeof(bool) , PropertyenableArticleCreationSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableArticlePublicSharingSites)]
        [TestCaseGeneric(typeof(bool) , PropertyenableArticlePublicSharingSitesSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyuseProfileForPDFCreation)]
        [TestCaseGeneric(typeof(bool) , PropertyuseProfileForPDFCreationSpecified)]
        public void AUT_KnowledgeCaseSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<KnowledgeCaseSettings, T>(_knowledgeCaseSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (articlePDFCreationProfile) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_articlePDFCreationProfile_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyarticlePDFCreationProfile);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (articlePublicSharingSites) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_articlePublicSharingSites_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyarticlePublicSharingSites);
            Action currentAction = () => propertyInfo.SetValue(_knowledgeCaseSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (articlePublicSharingSites) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_articlePublicSharingSites_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyarticlePublicSharingSites);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (articlePublicSharingSitesChatterAnswers) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_articlePublicSharingSitesChatterAnswers_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyarticlePublicSharingSitesChatterAnswers);
            Action currentAction = () => propertyInfo.SetValue(_knowledgeCaseSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (articlePublicSharingSitesChatterAnswers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_articlePublicSharingSitesChatterAnswers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyarticlePublicSharingSitesChatterAnswers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (assignTo) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_assignTo_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyassignTo);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (customizationClass) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_customizationClass_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomizationClass);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (defaultContributionArticleType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_defaultContributionArticleType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultContributionArticleType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (editor) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_editor_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyeditor);
            Action currentAction = () => propertyInfo.SetValue(_knowledgeCaseSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (editor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_editor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyeditor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (editorSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_editorSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyeditorSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (enableArticleCreation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_enableArticleCreation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableArticleCreation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (enableArticleCreationSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_enableArticleCreationSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableArticleCreationSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (enableArticlePublicSharingSites) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_enableArticlePublicSharingSites_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableArticlePublicSharingSites);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (enableArticlePublicSharingSitesSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_enableArticlePublicSharingSitesSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableArticlePublicSharingSitesSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (useProfileForPDFCreation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_useProfileForPDFCreation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseProfileForPDFCreation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeCaseSettings) => Property (useProfileForPDFCreationSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeCaseSettings_Public_Class_useProfileForPDFCreationSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseProfileForPDFCreationSpecified);

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