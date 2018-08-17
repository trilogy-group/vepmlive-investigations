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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomApplicationComponent" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomApplicationComponentTest : AbstractBaseSetupTypedTest<CustomApplicationComponent>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomApplicationComponent) Initializer

        private const string PropertybuttonIconUrl = "buttonIconUrl";
        private const string PropertybuttonStyle = "buttonStyle";
        private const string PropertybuttonText = "buttonText";
        private const string PropertybuttonWidth = "buttonWidth";
        private const string PropertybuttonWidthSpecified = "buttonWidthSpecified";
        private const string Propertyheight = "height";
        private const string PropertyheightSpecified = "heightSpecified";
        private const string PropertyisHeightFixed = "isHeightFixed";
        private const string PropertyisHidden = "isHidden";
        private const string PropertyisWidthFixed = "isWidthFixed";
        private const string PropertyvisualforcePage = "visualforcePage";
        private const string Propertywidth = "width";
        private const string PropertywidthSpecified = "widthSpecified";
        private const string FieldbuttonIconUrlField = "buttonIconUrlField";
        private const string FieldbuttonStyleField = "buttonStyleField";
        private const string FieldbuttonTextField = "buttonTextField";
        private const string FieldbuttonWidthField = "buttonWidthField";
        private const string FieldbuttonWidthFieldSpecified = "buttonWidthFieldSpecified";
        private const string FieldheightField = "heightField";
        private const string FieldheightFieldSpecified = "heightFieldSpecified";
        private const string FieldisHeightFixedField = "isHeightFixedField";
        private const string FieldisHiddenField = "isHiddenField";
        private const string FieldisWidthFixedField = "isWidthFixedField";
        private const string FieldvisualforcePageField = "visualforcePageField";
        private const string FieldwidthField = "widthField";
        private const string FieldwidthFieldSpecified = "widthFieldSpecified";
        private Type _customApplicationComponentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomApplicationComponent _customApplicationComponentInstance;
        private CustomApplicationComponent _customApplicationComponentInstanceFixture;

        #region General Initializer : Class (CustomApplicationComponent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomApplicationComponent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customApplicationComponentInstanceType = typeof(CustomApplicationComponent);
            _customApplicationComponentInstanceFixture = Create(true);
            _customApplicationComponentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomApplicationComponent)

        #region General Initializer : Class (CustomApplicationComponent) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomApplicationComponent" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybuttonIconUrl)]
        [TestCase(PropertybuttonStyle)]
        [TestCase(PropertybuttonText)]
        [TestCase(PropertybuttonWidth)]
        [TestCase(PropertybuttonWidthSpecified)]
        [TestCase(Propertyheight)]
        [TestCase(PropertyheightSpecified)]
        [TestCase(PropertyisHeightFixed)]
        [TestCase(PropertyisHidden)]
        [TestCase(PropertyisWidthFixed)]
        [TestCase(PropertyvisualforcePage)]
        [TestCase(Propertywidth)]
        [TestCase(PropertywidthSpecified)]
        public void AUT_CustomApplicationComponent_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customApplicationComponentInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomApplicationComponent) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomApplicationComponent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbuttonIconUrlField)]
        [TestCase(FieldbuttonStyleField)]
        [TestCase(FieldbuttonTextField)]
        [TestCase(FieldbuttonWidthField)]
        [TestCase(FieldbuttonWidthFieldSpecified)]
        [TestCase(FieldheightField)]
        [TestCase(FieldheightFieldSpecified)]
        [TestCase(FieldisHeightFixedField)]
        [TestCase(FieldisHiddenField)]
        [TestCase(FieldisWidthFixedField)]
        [TestCase(FieldvisualforcePageField)]
        [TestCase(FieldwidthField)]
        [TestCase(FieldwidthFieldSpecified)]
        public void AUT_CustomApplicationComponent_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customApplicationComponentInstanceFixture, 
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
        ///     Class (<see cref="CustomApplicationComponent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomApplicationComponent_Is_Instance_Present_Test()
        {
            // Assert
            _customApplicationComponentInstanceType.ShouldNotBeNull();
            _customApplicationComponentInstance.ShouldNotBeNull();
            _customApplicationComponentInstanceFixture.ShouldNotBeNull();
            _customApplicationComponentInstance.ShouldBeAssignableTo<CustomApplicationComponent>();
            _customApplicationComponentInstanceFixture.ShouldBeAssignableTo<CustomApplicationComponent>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomApplicationComponent) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomApplicationComponent_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomApplicationComponent instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customApplicationComponentInstanceType.ShouldNotBeNull();
            _customApplicationComponentInstance.ShouldNotBeNull();
            _customApplicationComponentInstanceFixture.ShouldNotBeNull();
            _customApplicationComponentInstance.ShouldBeAssignableTo<CustomApplicationComponent>();
            _customApplicationComponentInstanceFixture.ShouldBeAssignableTo<CustomApplicationComponent>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomApplicationComponent) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertybuttonIconUrl)]
        [TestCaseGeneric(typeof(string) , PropertybuttonStyle)]
        [TestCaseGeneric(typeof(string) , PropertybuttonText)]
        [TestCaseGeneric(typeof(int) , PropertybuttonWidth)]
        [TestCaseGeneric(typeof(bool) , PropertybuttonWidthSpecified)]
        [TestCaseGeneric(typeof(int) , Propertyheight)]
        [TestCaseGeneric(typeof(bool) , PropertyheightSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyisHeightFixed)]
        [TestCaseGeneric(typeof(bool) , PropertyisHidden)]
        [TestCaseGeneric(typeof(bool) , PropertyisWidthFixed)]
        [TestCaseGeneric(typeof(string) , PropertyvisualforcePage)]
        [TestCaseGeneric(typeof(int) , Propertywidth)]
        [TestCaseGeneric(typeof(bool) , PropertywidthSpecified)]
        public void AUT_CustomApplicationComponent_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomApplicationComponent, T>(_customApplicationComponentInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponent) => Property (buttonIconUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponent_Public_Class_buttonIconUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybuttonIconUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponent) => Property (buttonStyle) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponent_Public_Class_buttonStyle_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybuttonStyle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponent) => Property (buttonText) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponent_Public_Class_buttonText_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybuttonText);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponent) => Property (buttonWidth) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponent_Public_Class_buttonWidth_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybuttonWidth);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponent) => Property (buttonWidthSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponent_Public_Class_buttonWidthSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybuttonWidthSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponent) => Property (height) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponent_Public_Class_height_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyheight);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponent) => Property (heightSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponent_Public_Class_heightSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyheightSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponent) => Property (isHeightFixed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponent_Public_Class_isHeightFixed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisHeightFixed);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponent) => Property (isHidden) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponent_Public_Class_isHidden_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisHidden);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponent) => Property (isWidthFixed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponent_Public_Class_isWidthFixed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisWidthFixed);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponent) => Property (visualforcePage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponent_Public_Class_visualforcePage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyvisualforcePage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponent) => Property (width) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponent_Public_Class_width_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertywidth);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationComponent) => Property (widthSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationComponent_Public_Class_widthSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertywidthSpecified);

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