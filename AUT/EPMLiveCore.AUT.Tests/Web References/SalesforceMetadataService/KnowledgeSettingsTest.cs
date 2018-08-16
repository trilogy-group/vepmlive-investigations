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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.KnowledgeSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class KnowledgeSettingsTest : AbstractBaseSetupTypedTest<KnowledgeSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (KnowledgeSettings) Initializer

        private const string Propertyanswers = "answers";
        private const string Propertycases = "cases";
        private const string PropertydefaultLanguage = "defaultLanguage";
        private const string PropertyenableCreateEditOnArticlesTab = "enableCreateEditOnArticlesTab";
        private const string PropertyenableCreateEditOnArticlesTabSpecified = "enableCreateEditOnArticlesTabSpecified";
        private const string PropertyenableExternalMediaContent = "enableExternalMediaContent";
        private const string PropertyenableExternalMediaContentSpecified = "enableExternalMediaContentSpecified";
        private const string PropertyenableKnowledge = "enableKnowledge";
        private const string PropertyenableKnowledgeSpecified = "enableKnowledgeSpecified";
        private const string PropertyshowArticleSummariesCustomerPortal = "showArticleSummariesCustomerPortal";
        private const string PropertyshowArticleSummariesCustomerPortalSpecified = "showArticleSummariesCustomerPortalSpecified";
        private const string PropertyshowArticleSummariesInternalApp = "showArticleSummariesInternalApp";
        private const string PropertyshowArticleSummariesInternalAppSpecified = "showArticleSummariesInternalAppSpecified";
        private const string PropertyshowArticleSummariesPartnerPortal = "showArticleSummariesPartnerPortal";
        private const string PropertyshowArticleSummariesPartnerPortalSpecified = "showArticleSummariesPartnerPortalSpecified";
        private const string PropertyshowValidationStatusField = "showValidationStatusField";
        private const string PropertyshowValidationStatusFieldSpecified = "showValidationStatusFieldSpecified";
        private const string FieldanswersField = "answersField";
        private const string FieldcasesField = "casesField";
        private const string FielddefaultLanguageField = "defaultLanguageField";
        private const string FieldenableCreateEditOnArticlesTabField = "enableCreateEditOnArticlesTabField";
        private const string FieldenableCreateEditOnArticlesTabFieldSpecified = "enableCreateEditOnArticlesTabFieldSpecified";
        private const string FieldenableExternalMediaContentField = "enableExternalMediaContentField";
        private const string FieldenableExternalMediaContentFieldSpecified = "enableExternalMediaContentFieldSpecified";
        private const string FieldenableKnowledgeField = "enableKnowledgeField";
        private const string FieldenableKnowledgeFieldSpecified = "enableKnowledgeFieldSpecified";
        private const string FieldshowArticleSummariesCustomerPortalField = "showArticleSummariesCustomerPortalField";
        private const string FieldshowArticleSummariesCustomerPortalFieldSpecified = "showArticleSummariesCustomerPortalFieldSpecified";
        private const string FieldshowArticleSummariesInternalAppField = "showArticleSummariesInternalAppField";
        private const string FieldshowArticleSummariesInternalAppFieldSpecified = "showArticleSummariesInternalAppFieldSpecified";
        private const string FieldshowArticleSummariesPartnerPortalField = "showArticleSummariesPartnerPortalField";
        private const string FieldshowArticleSummariesPartnerPortalFieldSpecified = "showArticleSummariesPartnerPortalFieldSpecified";
        private const string FieldshowValidationStatusFieldField = "showValidationStatusFieldField";
        private const string FieldshowValidationStatusFieldFieldSpecified = "showValidationStatusFieldFieldSpecified";
        private Type _knowledgeSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private KnowledgeSettings _knowledgeSettingsInstance;
        private KnowledgeSettings _knowledgeSettingsInstanceFixture;

        #region General Initializer : Class (KnowledgeSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="KnowledgeSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _knowledgeSettingsInstanceType = typeof(KnowledgeSettings);
            _knowledgeSettingsInstanceFixture = Create(true);
            _knowledgeSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (KnowledgeSettings)

        #region General Initializer : Class (KnowledgeSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="KnowledgeSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyanswers)]
        [TestCase(Propertycases)]
        [TestCase(PropertydefaultLanguage)]
        [TestCase(PropertyenableCreateEditOnArticlesTab)]
        [TestCase(PropertyenableCreateEditOnArticlesTabSpecified)]
        [TestCase(PropertyenableExternalMediaContent)]
        [TestCase(PropertyenableExternalMediaContentSpecified)]
        [TestCase(PropertyenableKnowledge)]
        [TestCase(PropertyenableKnowledgeSpecified)]
        [TestCase(PropertyshowArticleSummariesCustomerPortal)]
        [TestCase(PropertyshowArticleSummariesCustomerPortalSpecified)]
        [TestCase(PropertyshowArticleSummariesInternalApp)]
        [TestCase(PropertyshowArticleSummariesInternalAppSpecified)]
        [TestCase(PropertyshowArticleSummariesPartnerPortal)]
        [TestCase(PropertyshowArticleSummariesPartnerPortalSpecified)]
        [TestCase(PropertyshowValidationStatusField)]
        [TestCase(PropertyshowValidationStatusFieldSpecified)]
        public void AUT_KnowledgeSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_knowledgeSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (KnowledgeSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="KnowledgeSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldanswersField)]
        [TestCase(FieldcasesField)]
        [TestCase(FielddefaultLanguageField)]
        [TestCase(FieldenableCreateEditOnArticlesTabField)]
        [TestCase(FieldenableCreateEditOnArticlesTabFieldSpecified)]
        [TestCase(FieldenableExternalMediaContentField)]
        [TestCase(FieldenableExternalMediaContentFieldSpecified)]
        [TestCase(FieldenableKnowledgeField)]
        [TestCase(FieldenableKnowledgeFieldSpecified)]
        [TestCase(FieldshowArticleSummariesCustomerPortalField)]
        [TestCase(FieldshowArticleSummariesCustomerPortalFieldSpecified)]
        [TestCase(FieldshowArticleSummariesInternalAppField)]
        [TestCase(FieldshowArticleSummariesInternalAppFieldSpecified)]
        [TestCase(FieldshowArticleSummariesPartnerPortalField)]
        [TestCase(FieldshowArticleSummariesPartnerPortalFieldSpecified)]
        [TestCase(FieldshowValidationStatusFieldField)]
        [TestCase(FieldshowValidationStatusFieldFieldSpecified)]
        public void AUT_KnowledgeSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_knowledgeSettingsInstanceFixture, 
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
        ///     Class (<see cref="KnowledgeSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_KnowledgeSettings_Is_Instance_Present_Test()
        {
            // Assert
            _knowledgeSettingsInstanceType.ShouldNotBeNull();
            _knowledgeSettingsInstance.ShouldNotBeNull();
            _knowledgeSettingsInstanceFixture.ShouldNotBeNull();
            _knowledgeSettingsInstance.ShouldBeAssignableTo<KnowledgeSettings>();
            _knowledgeSettingsInstanceFixture.ShouldBeAssignableTo<KnowledgeSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (KnowledgeSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_KnowledgeSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            KnowledgeSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _knowledgeSettingsInstanceType.ShouldNotBeNull();
            _knowledgeSettingsInstance.ShouldNotBeNull();
            _knowledgeSettingsInstanceFixture.ShouldNotBeNull();
            _knowledgeSettingsInstance.ShouldBeAssignableTo<KnowledgeSettings>();
            _knowledgeSettingsInstanceFixture.ShouldBeAssignableTo<KnowledgeSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (KnowledgeSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(KnowledgeAnswerSettings) , Propertyanswers)]
        [TestCaseGeneric(typeof(KnowledgeCaseSettings) , Propertycases)]
        [TestCaseGeneric(typeof(string) , PropertydefaultLanguage)]
        [TestCaseGeneric(typeof(bool) , PropertyenableCreateEditOnArticlesTab)]
        [TestCaseGeneric(typeof(bool) , PropertyenableCreateEditOnArticlesTabSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableExternalMediaContent)]
        [TestCaseGeneric(typeof(bool) , PropertyenableExternalMediaContentSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableKnowledge)]
        [TestCaseGeneric(typeof(bool) , PropertyenableKnowledgeSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowArticleSummariesCustomerPortal)]
        [TestCaseGeneric(typeof(bool) , PropertyshowArticleSummariesCustomerPortalSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowArticleSummariesInternalApp)]
        [TestCaseGeneric(typeof(bool) , PropertyshowArticleSummariesInternalAppSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowArticleSummariesPartnerPortal)]
        [TestCaseGeneric(typeof(bool) , PropertyshowArticleSummariesPartnerPortalSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowValidationStatusField)]
        [TestCaseGeneric(typeof(bool) , PropertyshowValidationStatusFieldSpecified)]
        public void AUT_KnowledgeSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<KnowledgeSettings, T>(_knowledgeSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (answers) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_answers_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyanswers);
            Action currentAction = () => propertyInfo.SetValue(_knowledgeSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (answers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_answers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyanswers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (cases) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_cases_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertycases);
            Action currentAction = () => propertyInfo.SetValue(_knowledgeSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (cases) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_cases_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycases);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (defaultLanguage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_defaultLanguage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydefaultLanguage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (enableCreateEditOnArticlesTab) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_enableCreateEditOnArticlesTab_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableCreateEditOnArticlesTab);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (enableCreateEditOnArticlesTabSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_enableCreateEditOnArticlesTabSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableCreateEditOnArticlesTabSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (enableExternalMediaContent) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_enableExternalMediaContent_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableExternalMediaContent);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (enableExternalMediaContentSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_enableExternalMediaContentSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableExternalMediaContentSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (enableKnowledge) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_enableKnowledge_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableKnowledge);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (enableKnowledgeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_enableKnowledgeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableKnowledgeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (showArticleSummariesCustomerPortal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_showArticleSummariesCustomerPortal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowArticleSummariesCustomerPortal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (showArticleSummariesCustomerPortalSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_showArticleSummariesCustomerPortalSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowArticleSummariesCustomerPortalSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (showArticleSummariesInternalApp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_showArticleSummariesInternalApp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowArticleSummariesInternalApp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (showArticleSummariesInternalAppSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_showArticleSummariesInternalAppSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowArticleSummariesInternalAppSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (showArticleSummariesPartnerPortal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_showArticleSummariesPartnerPortal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowArticleSummariesPartnerPortal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (showArticleSummariesPartnerPortalSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_showArticleSummariesPartnerPortalSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowArticleSummariesPartnerPortalSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (showValidationStatusField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_showValidationStatusField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowValidationStatusField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (KnowledgeSettings) => Property (showValidationStatusFieldSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_KnowledgeSettings_Public_Class_showValidationStatusFieldSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowValidationStatusFieldSpecified);

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