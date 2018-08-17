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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportTypeTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportTypeTranslationTest : AbstractBaseSetupTypedTest<ReportTypeTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportTypeTranslation) Initializer

        private const string Propertydescription = "description";
        private const string Propertylabel = "label";
        private const string Propertyname = "name";
        private const string Propertysections = "sections";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldlabelField = "labelField";
        private const string FieldnameField = "nameField";
        private const string FieldsectionsField = "sectionsField";
        private Type _reportTypeTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportTypeTranslation _reportTypeTranslationInstance;
        private ReportTypeTranslation _reportTypeTranslationInstanceFixture;

        #region General Initializer : Class (ReportTypeTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportTypeTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportTypeTranslationInstanceType = typeof(ReportTypeTranslation);
            _reportTypeTranslationInstanceFixture = Create(true);
            _reportTypeTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportTypeTranslation)

        #region General Initializer : Class (ReportTypeTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportTypeTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertydescription)]
        [TestCase(Propertylabel)]
        [TestCase(Propertyname)]
        [TestCase(Propertysections)]
        public void AUT_ReportTypeTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportTypeTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportTypeTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportTypeTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldsectionsField)]
        public void AUT_ReportTypeTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportTypeTranslationInstanceFixture, 
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
        ///     Class (<see cref="ReportTypeTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportTypeTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _reportTypeTranslationInstanceType.ShouldNotBeNull();
            _reportTypeTranslationInstance.ShouldNotBeNull();
            _reportTypeTranslationInstanceFixture.ShouldNotBeNull();
            _reportTypeTranslationInstance.ShouldBeAssignableTo<ReportTypeTranslation>();
            _reportTypeTranslationInstanceFixture.ShouldBeAssignableTo<ReportTypeTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportTypeTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportTypeTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportTypeTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportTypeTranslationInstanceType.ShouldNotBeNull();
            _reportTypeTranslationInstance.ShouldNotBeNull();
            _reportTypeTranslationInstanceFixture.ShouldNotBeNull();
            _reportTypeTranslationInstance.ShouldBeAssignableTo<ReportTypeTranslation>();
            _reportTypeTranslationInstanceFixture.ShouldBeAssignableTo<ReportTypeTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportTypeTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(ReportTypeSectionTranslation[]) , Propertysections)]
        public void AUT_ReportTypeTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportTypeTranslation, T>(_reportTypeTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportTypeTranslation) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeTranslation_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportTypeTranslation) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeTranslation_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportTypeTranslation) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeTranslation_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportTypeTranslation) => Property (sections) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeTranslation_sections_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertysections);
            Action currentAction = () => propertyInfo.SetValue(_reportTypeTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportTypeTranslation) => Property (sections) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportTypeTranslation_Public_Class_sections_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysections);

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