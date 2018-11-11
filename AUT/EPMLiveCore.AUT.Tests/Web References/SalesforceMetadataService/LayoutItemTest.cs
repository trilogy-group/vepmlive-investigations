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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.LayoutItem" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class LayoutItemTest : AbstractBaseSetupTypedTest<LayoutItem>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (LayoutItem) Initializer

        private const string Propertybehavior = "behavior";
        private const string PropertybehaviorSpecified = "behaviorSpecified";
        private const string PropertycustomLink = "customLink";
        private const string PropertyemptySpace = "emptySpace";
        private const string PropertyemptySpaceSpecified = "emptySpaceSpecified";
        private const string Propertyfield = "field";
        private const string Propertyheight = "height";
        private const string PropertyheightSpecified = "heightSpecified";
        private const string Propertypage = "page";
        private const string Propertyscontrol = "scontrol";
        private const string PropertyshowLabel = "showLabel";
        private const string PropertyshowLabelSpecified = "showLabelSpecified";
        private const string PropertyshowScrollbars = "showScrollbars";
        private const string PropertyshowScrollbarsSpecified = "showScrollbarsSpecified";
        private const string Propertywidth = "width";
        private const string FieldbehaviorField = "behaviorField";
        private const string FieldbehaviorFieldSpecified = "behaviorFieldSpecified";
        private const string FieldcustomLinkField = "customLinkField";
        private const string FieldemptySpaceField = "emptySpaceField";
        private const string FieldemptySpaceFieldSpecified = "emptySpaceFieldSpecified";
        private const string FieldfieldField = "fieldField";
        private const string FieldheightField = "heightField";
        private const string FieldheightFieldSpecified = "heightFieldSpecified";
        private const string FieldpageField = "pageField";
        private const string FieldscontrolField = "scontrolField";
        private const string FieldshowLabelField = "showLabelField";
        private const string FieldshowLabelFieldSpecified = "showLabelFieldSpecified";
        private const string FieldshowScrollbarsField = "showScrollbarsField";
        private const string FieldshowScrollbarsFieldSpecified = "showScrollbarsFieldSpecified";
        private const string FieldwidthField = "widthField";
        private Type _layoutItemInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private LayoutItem _layoutItemInstance;
        private LayoutItem _layoutItemInstanceFixture;

        #region General Initializer : Class (LayoutItem) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="LayoutItem" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _layoutItemInstanceType = typeof(LayoutItem);
            _layoutItemInstanceFixture = Create(true);
            _layoutItemInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (LayoutItem)

        #region General Initializer : Class (LayoutItem) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="LayoutItem" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertybehavior)]
        [TestCase(PropertybehaviorSpecified)]
        [TestCase(PropertycustomLink)]
        [TestCase(PropertyemptySpace)]
        [TestCase(PropertyemptySpaceSpecified)]
        [TestCase(Propertyfield)]
        [TestCase(Propertyheight)]
        [TestCase(PropertyheightSpecified)]
        [TestCase(Propertypage)]
        [TestCase(Propertyscontrol)]
        [TestCase(PropertyshowLabel)]
        [TestCase(PropertyshowLabelSpecified)]
        [TestCase(PropertyshowScrollbars)]
        [TestCase(PropertyshowScrollbarsSpecified)]
        [TestCase(Propertywidth)]
        public void AUT_LayoutItem_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_layoutItemInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (LayoutItem) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="LayoutItem" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbehaviorField)]
        [TestCase(FieldbehaviorFieldSpecified)]
        [TestCase(FieldcustomLinkField)]
        [TestCase(FieldemptySpaceField)]
        [TestCase(FieldemptySpaceFieldSpecified)]
        [TestCase(FieldfieldField)]
        [TestCase(FieldheightField)]
        [TestCase(FieldheightFieldSpecified)]
        [TestCase(FieldpageField)]
        [TestCase(FieldscontrolField)]
        [TestCase(FieldshowLabelField)]
        [TestCase(FieldshowLabelFieldSpecified)]
        [TestCase(FieldshowScrollbarsField)]
        [TestCase(FieldshowScrollbarsFieldSpecified)]
        [TestCase(FieldwidthField)]
        public void AUT_LayoutItem_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_layoutItemInstanceFixture, 
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
        ///     Class (<see cref="LayoutItem" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_LayoutItem_Is_Instance_Present_Test()
        {
            // Assert
            _layoutItemInstanceType.ShouldNotBeNull();
            _layoutItemInstance.ShouldNotBeNull();
            _layoutItemInstanceFixture.ShouldNotBeNull();
            _layoutItemInstance.ShouldBeAssignableTo<LayoutItem>();
            _layoutItemInstanceFixture.ShouldBeAssignableTo<LayoutItem>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (LayoutItem) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_LayoutItem_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            LayoutItem instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _layoutItemInstanceType.ShouldNotBeNull();
            _layoutItemInstance.ShouldNotBeNull();
            _layoutItemInstanceFixture.ShouldNotBeNull();
            _layoutItemInstance.ShouldBeAssignableTo<LayoutItem>();
            _layoutItemInstanceFixture.ShouldBeAssignableTo<LayoutItem>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (LayoutItem) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(UiBehavior) , Propertybehavior)]
        [TestCaseGeneric(typeof(bool) , PropertybehaviorSpecified)]
        [TestCaseGeneric(typeof(string) , PropertycustomLink)]
        [TestCaseGeneric(typeof(bool) , PropertyemptySpace)]
        [TestCaseGeneric(typeof(bool) , PropertyemptySpaceSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyfield)]
        [TestCaseGeneric(typeof(int) , Propertyheight)]
        [TestCaseGeneric(typeof(bool) , PropertyheightSpecified)]
        [TestCaseGeneric(typeof(string) , Propertypage)]
        [TestCaseGeneric(typeof(string) , Propertyscontrol)]
        [TestCaseGeneric(typeof(bool) , PropertyshowLabel)]
        [TestCaseGeneric(typeof(bool) , PropertyshowLabelSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowScrollbars)]
        [TestCaseGeneric(typeof(bool) , PropertyshowScrollbarsSpecified)]
        [TestCaseGeneric(typeof(string) , Propertywidth)]
        public void AUT_LayoutItem_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<LayoutItem, T>(_layoutItemInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (LayoutItem) => Property (behavior) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_behavior_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertybehavior);
            Action currentAction = () => propertyInfo.SetValue(_layoutItemInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (LayoutItem) => Property (behavior) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_behavior_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertybehavior);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutItem) => Property (behaviorSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_behaviorSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybehaviorSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutItem) => Property (customLink) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_customLink_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomLink);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutItem) => Property (emptySpace) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_emptySpace_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemptySpace);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutItem) => Property (emptySpaceSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_emptySpaceSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyemptySpaceSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutItem) => Property (field) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_field_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfield);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutItem) => Property (height) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_height_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LayoutItem) => Property (heightSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_heightSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LayoutItem) => Property (page) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_page_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (LayoutItem) => Property (scontrol) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_scontrol_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyscontrol);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutItem) => Property (showLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_showLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutItem) => Property (showLabelSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_showLabelSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowLabelSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutItem) => Property (showScrollbars) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_showScrollbars_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowScrollbars);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutItem) => Property (showScrollbarsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_showScrollbarsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowScrollbarsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (LayoutItem) => Property (width) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_LayoutItem_Public_Class_width_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}