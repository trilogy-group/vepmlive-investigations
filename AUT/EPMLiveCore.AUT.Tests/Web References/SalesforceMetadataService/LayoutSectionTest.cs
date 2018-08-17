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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.LayoutSection" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LayoutSectionTest : AbstractBaseSetupTypedTest<LayoutSection>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LayoutSection) Initializer

        private const string PropertycustomLabel = "customLabel";
        private const string PropertycustomLabelSpecified = "customLabelSpecified";
        private const string PropertydetailHeading = "detailHeading";
        private const string PropertydetailHeadingSpecified = "detailHeadingSpecified";
        private const string PropertyeditHeading = "editHeading";
        private const string PropertyeditHeadingSpecified = "editHeadingSpecified";
        private const string Propertylabel = "label";
        private const string PropertylayoutColumns = "layoutColumns";
        private const string Propertystyle = "style";
        private const string FieldcustomLabelField = "customLabelField";
        private const string FieldcustomLabelFieldSpecified = "customLabelFieldSpecified";
        private const string FielddetailHeadingField = "detailHeadingField";
        private const string FielddetailHeadingFieldSpecified = "detailHeadingFieldSpecified";
        private const string FieldeditHeadingField = "editHeadingField";
        private const string FieldeditHeadingFieldSpecified = "editHeadingFieldSpecified";
        private const string FieldlabelField = "labelField";
        private const string FieldlayoutColumnsField = "layoutColumnsField";
        private const string FieldstyleField = "styleField";
        private Type _layoutSectionInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LayoutSection _layoutSectionInstance;
        private LayoutSection _layoutSectionInstanceFixture;

        #region General Initializer : Class (LayoutSection) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LayoutSection" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _layoutSectionInstanceType = typeof(LayoutSection);
            _layoutSectionInstanceFixture = Create(true);
            _layoutSectionInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LayoutSection)

        #region General Initializer : Class (LayoutSection) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LayoutSection" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycustomLabel)]
        [TestCase(PropertycustomLabelSpecified)]
        [TestCase(PropertydetailHeading)]
        [TestCase(PropertydetailHeadingSpecified)]
        [TestCase(PropertyeditHeading)]
        [TestCase(PropertyeditHeadingSpecified)]
        [TestCase(Propertylabel)]
        [TestCase(PropertylayoutColumns)]
        [TestCase(Propertystyle)]
        public void AUT_LayoutSection_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_layoutSectionInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LayoutSection) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LayoutSection" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcustomLabelField)]
        [TestCase(FieldcustomLabelFieldSpecified)]
        [TestCase(FielddetailHeadingField)]
        [TestCase(FielddetailHeadingFieldSpecified)]
        [TestCase(FieldeditHeadingField)]
        [TestCase(FieldeditHeadingFieldSpecified)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldlayoutColumnsField)]
        [TestCase(FieldstyleField)]
        public void AUT_LayoutSection_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_layoutSectionInstanceFixture, 
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
        ///     Class (<see cref="LayoutSection" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LayoutSection_Is_Instance_Present_Test()
        {
            // Assert
            _layoutSectionInstanceType.ShouldNotBeNull();
            _layoutSectionInstance.ShouldNotBeNull();
            _layoutSectionInstanceFixture.ShouldNotBeNull();
            _layoutSectionInstance.ShouldBeAssignableTo<LayoutSection>();
            _layoutSectionInstanceFixture.ShouldBeAssignableTo<LayoutSection>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LayoutSection) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LayoutSection_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LayoutSection instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _layoutSectionInstanceType.ShouldNotBeNull();
            _layoutSectionInstance.ShouldNotBeNull();
            _layoutSectionInstanceFixture.ShouldNotBeNull();
            _layoutSectionInstance.ShouldBeAssignableTo<LayoutSection>();
            _layoutSectionInstanceFixture.ShouldBeAssignableTo<LayoutSection>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LayoutSection) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertycustomLabel)]
        [TestCaseGeneric(typeof(bool) , PropertycustomLabelSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertydetailHeading)]
        [TestCaseGeneric(typeof(bool) , PropertydetailHeadingSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyeditHeading)]
        [TestCaseGeneric(typeof(bool) , PropertyeditHeadingSpecified)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(LayoutColumn[]) , PropertylayoutColumns)]
        [TestCaseGeneric(typeof(LayoutSectionStyle) , Propertystyle)]
        public void AUT_LayoutSection_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LayoutSection, T>(_layoutSectionInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LayoutSection) => Property (customLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutSection_Public_Class_customLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutSection) => Property (customLabelSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutSection_Public_Class_customLabelSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomLabelSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutSection) => Property (detailHeading) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutSection_Public_Class_detailHeading_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydetailHeading);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutSection) => Property (detailHeadingSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutSection_Public_Class_detailHeadingSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydetailHeadingSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutSection) => Property (editHeading) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutSection_Public_Class_editHeading_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyeditHeading);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutSection) => Property (editHeadingSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutSection_Public_Class_editHeadingSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyeditHeadingSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutSection) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutSection_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LayoutSection) => Property (layoutColumns) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutSection_layoutColumns_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylayoutColumns);
            Action currentAction = () => propertyInfo.SetValue(_layoutSectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LayoutSection) => Property (layoutColumns) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutSection_Public_Class_layoutColumns_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylayoutColumns);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutSection) => Property (style) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutSection_style_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertystyle);
            Action currentAction = () => propertyInfo.SetValue(_layoutSectionInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LayoutSection) => Property (style) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutSection_Public_Class_style_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}