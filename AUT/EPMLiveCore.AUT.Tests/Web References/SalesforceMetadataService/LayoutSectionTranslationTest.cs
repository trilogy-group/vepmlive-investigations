using System;
using System.Diagnostics.CodeAnalysis;
using AUT.ConfigureTestProjects.Analyzer;
using AUT.ConfigureTestProjects.Attribute;
using AUT.ConfigureTestProjects.BaseSetup;
using AUT.ConfigureTestProjects.Extensions;
using AUT.ConfigureTestProjects.StaticTypes;
using NUnit.Framework;
using Shouldly;

namespace EPMLiveCore.SalesforceMetadataService
{
    /// <summary>
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.LayoutSectionTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LayoutSectionTranslationTest : AbstractBaseSetupTypedTest<LayoutSectionTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LayoutSectionTranslation) Initializer

        private const string Propertylabel = "label";
        private const string Propertysection = "section";
        private const string FieldlabelField = "labelField";
        private const string FieldsectionField = "sectionField";
        private Type _layoutSectionTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LayoutSectionTranslation _layoutSectionTranslationInstance;
        private LayoutSectionTranslation _layoutSectionTranslationInstanceFixture;

        #region General Initializer : Class (LayoutSectionTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LayoutSectionTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _layoutSectionTranslationInstanceType = typeof(LayoutSectionTranslation);
            _layoutSectionTranslationInstanceFixture = Create(true);
            _layoutSectionTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LayoutSectionTranslation)

        #region General Initializer : Class (LayoutSectionTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LayoutSectionTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylabel)]
        [TestCase(Propertysection)]
        public void AUT_LayoutSectionTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_layoutSectionTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LayoutSectionTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LayoutSectionTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlabelField)]
        [TestCase(FieldsectionField)]
        public void AUT_LayoutSectionTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_layoutSectionTranslationInstanceFixture, 
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
        ///     Class (<see cref="LayoutSectionTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LayoutSectionTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _layoutSectionTranslationInstanceType.ShouldNotBeNull();
            _layoutSectionTranslationInstance.ShouldNotBeNull();
            _layoutSectionTranslationInstanceFixture.ShouldNotBeNull();
            _layoutSectionTranslationInstance.ShouldBeAssignableTo<LayoutSectionTranslation>();
            _layoutSectionTranslationInstanceFixture.ShouldBeAssignableTo<LayoutSectionTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LayoutSectionTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LayoutSectionTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LayoutSectionTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _layoutSectionTranslationInstanceType.ShouldNotBeNull();
            _layoutSectionTranslationInstance.ShouldNotBeNull();
            _layoutSectionTranslationInstanceFixture.ShouldNotBeNull();
            _layoutSectionTranslationInstance.ShouldBeAssignableTo<LayoutSectionTranslation>();
            _layoutSectionTranslationInstanceFixture.ShouldBeAssignableTo<LayoutSectionTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LayoutSectionTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertysection)]
        public void AUT_LayoutSectionTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LayoutSectionTranslation, T>(_layoutSectionTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LayoutSectionTranslation) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutSectionTranslation_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LayoutSectionTranslation) => Property (section) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutSectionTranslation_Public_Class_section_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysection);

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