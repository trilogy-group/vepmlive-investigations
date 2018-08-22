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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Translations" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class TranslationsTest : AbstractBaseSetupTypedTest<Translations>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Translations) Initializer

        private const string PropertycustomApplications = "customApplications";
        private const string PropertycustomDataTypeTranslations = "customDataTypeTranslations";
        private const string PropertycustomLabels = "customLabels";
        private const string PropertycustomPageWebLinks = "customPageWebLinks";
        private const string PropertycustomTabs = "customTabs";
        private const string PropertyreportTypes = "reportTypes";
        private const string Propertyscontrols = "scontrols";
        private const string FieldcustomApplicationsField = "customApplicationsField";
        private const string FieldcustomDataTypeTranslationsField = "customDataTypeTranslationsField";
        private const string FieldcustomLabelsField = "customLabelsField";
        private const string FieldcustomPageWebLinksField = "customPageWebLinksField";
        private const string FieldcustomTabsField = "customTabsField";
        private const string FieldreportTypesField = "reportTypesField";
        private const string FieldscontrolsField = "scontrolsField";
        private Type _translationsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Translations _translationsInstance;
        private Translations _translationsInstanceFixture;

        #region General Initializer : Class (Translations) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Translations" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _translationsInstanceType = typeof(Translations);
            _translationsInstanceFixture = Create(true);
            _translationsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Translations)

        #region General Initializer : Class (Translations) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Translations" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycustomApplications)]
        [TestCase(PropertycustomDataTypeTranslations)]
        [TestCase(PropertycustomLabels)]
        [TestCase(PropertycustomPageWebLinks)]
        [TestCase(PropertycustomTabs)]
        [TestCase(PropertyreportTypes)]
        [TestCase(Propertyscontrols)]
        public void AUT_Translations_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_translationsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Translations) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Translations" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcustomApplicationsField)]
        [TestCase(FieldcustomDataTypeTranslationsField)]
        [TestCase(FieldcustomLabelsField)]
        [TestCase(FieldcustomPageWebLinksField)]
        [TestCase(FieldcustomTabsField)]
        [TestCase(FieldreportTypesField)]
        [TestCase(FieldscontrolsField)]
        public void AUT_Translations_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_translationsInstanceFixture, 
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
        ///     Class (<see cref="Translations" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Translations_Is_Instance_Present_Test()
        {
            // Assert
            _translationsInstanceType.ShouldNotBeNull();
            _translationsInstance.ShouldNotBeNull();
            _translationsInstanceFixture.ShouldNotBeNull();
            _translationsInstance.ShouldBeAssignableTo<Translations>();
            _translationsInstanceFixture.ShouldBeAssignableTo<Translations>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Translations) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Translations_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Translations instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _translationsInstanceType.ShouldNotBeNull();
            _translationsInstance.ShouldNotBeNull();
            _translationsInstanceFixture.ShouldNotBeNull();
            _translationsInstance.ShouldBeAssignableTo<Translations>();
            _translationsInstanceFixture.ShouldBeAssignableTo<Translations>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Translations) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(CustomApplicationTranslation[]) , PropertycustomApplications)]
        [TestCaseGeneric(typeof(CustomDataTypeTranslation[]) , PropertycustomDataTypeTranslations)]
        [TestCaseGeneric(typeof(CustomLabelTranslation[]) , PropertycustomLabels)]
        [TestCaseGeneric(typeof(CustomPageWebLinkTranslation[]) , PropertycustomPageWebLinks)]
        [TestCaseGeneric(typeof(CustomTabTranslation[]) , PropertycustomTabs)]
        [TestCaseGeneric(typeof(ReportTypeTranslation[]) , PropertyreportTypes)]
        [TestCaseGeneric(typeof(ScontrolTranslation[]) , Propertyscontrols)]
        public void AUT_Translations_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Translations, T>(_translationsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (customApplications) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_customApplications_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomApplications);
            Action currentAction = () => propertyInfo.SetValue(_translationsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (customApplications) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_Public_Class_customApplications_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomApplications);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (customDataTypeTranslations) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_customDataTypeTranslations_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomDataTypeTranslations);
            Action currentAction = () => propertyInfo.SetValue(_translationsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (customDataTypeTranslations) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_Public_Class_customDataTypeTranslations_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomDataTypeTranslations);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (customLabels) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_customLabels_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomLabels);
            Action currentAction = () => propertyInfo.SetValue(_translationsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (customLabels) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_Public_Class_customLabels_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomLabels);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (customPageWebLinks) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_customPageWebLinks_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomPageWebLinks);
            Action currentAction = () => propertyInfo.SetValue(_translationsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (customPageWebLinks) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_Public_Class_customPageWebLinks_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomPageWebLinks);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (customTabs) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_customTabs_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycustomTabs);
            Action currentAction = () => propertyInfo.SetValue(_translationsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (customTabs) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_Public_Class_customTabs_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomTabs);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (reportTypes) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_reportTypes_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyreportTypes);
            Action currentAction = () => propertyInfo.SetValue(_translationsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (reportTypes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_Public_Class_reportTypes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreportTypes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (scontrols) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_scontrols_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyscontrols);
            Action currentAction = () => propertyInfo.SetValue(_translationsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Translations) => Property (scontrols) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Translations_Public_Class_scontrols_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyscontrols);

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