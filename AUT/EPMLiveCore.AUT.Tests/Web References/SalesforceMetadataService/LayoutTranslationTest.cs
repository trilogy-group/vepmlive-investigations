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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.LayoutTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LayoutTranslationTest : AbstractBaseSetupTypedTest<LayoutTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LayoutTranslation) Initializer

        private const string Propertylayout = "layout";
        private const string PropertylayoutType = "layoutType";
        private const string Propertysections = "sections";
        private const string FieldlayoutField = "layoutField";
        private const string FieldlayoutTypeField = "layoutTypeField";
        private const string FieldsectionsField = "sectionsField";
        private Type _layoutTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LayoutTranslation _layoutTranslationInstance;
        private LayoutTranslation _layoutTranslationInstanceFixture;

        #region General Initializer : Class (LayoutTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LayoutTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _layoutTranslationInstanceType = typeof(LayoutTranslation);
            _layoutTranslationInstanceFixture = Create(true);
            _layoutTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LayoutTranslation)

        #region General Initializer : Class (LayoutTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LayoutTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylayout)]
        [TestCase(PropertylayoutType)]
        [TestCase(Propertysections)]
        public void AUT_LayoutTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_layoutTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LayoutTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LayoutTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlayoutField)]
        [TestCase(FieldlayoutTypeField)]
        [TestCase(FieldsectionsField)]
        public void AUT_LayoutTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_layoutTranslationInstanceFixture, 
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
        ///     Class (<see cref="LayoutTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LayoutTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _layoutTranslationInstanceType.ShouldNotBeNull();
            _layoutTranslationInstance.ShouldNotBeNull();
            _layoutTranslationInstanceFixture.ShouldNotBeNull();
            _layoutTranslationInstance.ShouldBeAssignableTo<LayoutTranslation>();
            _layoutTranslationInstanceFixture.ShouldBeAssignableTo<LayoutTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LayoutTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LayoutTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LayoutTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _layoutTranslationInstanceType.ShouldNotBeNull();
            _layoutTranslationInstance.ShouldNotBeNull();
            _layoutTranslationInstanceFixture.ShouldNotBeNull();
            _layoutTranslationInstance.ShouldBeAssignableTo<LayoutTranslation>();
            _layoutTranslationInstanceFixture.ShouldBeAssignableTo<LayoutTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LayoutTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertylayout)]
        [TestCaseGeneric(typeof(string) , PropertylayoutType)]
        [TestCaseGeneric(typeof(LayoutSectionTranslation[]) , Propertysections)]
        public void AUT_LayoutTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LayoutTranslation, T>(_layoutTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LayoutTranslation) => Property (layout) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutTranslation_Public_Class_layout_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylayout);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutTranslation) => Property (layoutType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutTranslation_Public_Class_layoutType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylayoutType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutTranslation) => Property (sections) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutTranslation_sections_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertysections);
            Action currentAction = () => propertyInfo.SetValue(_layoutTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LayoutTranslation) => Property (sections) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutTranslation_Public_Class_sections_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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