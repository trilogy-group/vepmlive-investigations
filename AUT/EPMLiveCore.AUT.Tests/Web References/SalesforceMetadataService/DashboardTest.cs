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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.Dashboard" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DashboardTest : AbstractBaseSetupTypedTest<Dashboard>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (Dashboard) Initializer

        private const string PropertybackgroundEndColor = "backgroundEndColor";
        private const string PropertybackgroundFadeDirection = "backgroundFadeDirection";
        private const string PropertybackgroundStartColor = "backgroundStartColor";
        private const string PropertydashboardFilters = "dashboardFilters";
        private const string PropertydashboardType = "dashboardType";
        private const string PropertydashboardTypeSpecified = "dashboardTypeSpecified";
        private const string Propertydescription = "description";
        private const string PropertyleftSection = "leftSection";
        private const string PropertymiddleSection = "middleSection";
        private const string PropertyrightSection = "rightSection";
        private const string PropertyrunningUser = "runningUser";
        private const string PropertytextColor = "textColor";
        private const string Propertytitle = "title";
        private const string PropertytitleColor = "titleColor";
        private const string PropertytitleSize = "titleSize";
        private const string FieldbackgroundEndColorField = "backgroundEndColorField";
        private const string FieldbackgroundFadeDirectionField = "backgroundFadeDirectionField";
        private const string FieldbackgroundStartColorField = "backgroundStartColorField";
        private const string FielddashboardFiltersField = "dashboardFiltersField";
        private const string FielddashboardTypeField = "dashboardTypeField";
        private const string FielddashboardTypeFieldSpecified = "dashboardTypeFieldSpecified";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldleftSectionField = "leftSectionField";
        private const string FieldmiddleSectionField = "middleSectionField";
        private const string FieldrightSectionField = "rightSectionField";
        private const string FieldrunningUserField = "runningUserField";
        private const string FieldtextColorField = "textColorField";
        private const string FieldtitleField = "titleField";
        private const string FieldtitleColorField = "titleColorField";
        private const string FieldtitleSizeField = "titleSizeField";
        private Type _dashboardInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private Dashboard _dashboardInstance;
        private Dashboard _dashboardInstanceFixture;

        #region General Initializer : Class (Dashboard) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="Dashboard" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dashboardInstanceType = typeof(Dashboard);
            _dashboardInstanceFixture = Create(true);
            _dashboardInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (Dashboard)

        #region General Initializer : Class (Dashboard) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="Dashboard" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybackgroundEndColor)]
        [TestCase(PropertybackgroundFadeDirection)]
        [TestCase(PropertybackgroundStartColor)]
        [TestCase(PropertydashboardFilters)]
        [TestCase(PropertydashboardType)]
        [TestCase(PropertydashboardTypeSpecified)]
        [TestCase(Propertydescription)]
        [TestCase(PropertyleftSection)]
        [TestCase(PropertymiddleSection)]
        [TestCase(PropertyrightSection)]
        [TestCase(PropertyrunningUser)]
        [TestCase(PropertytextColor)]
        [TestCase(Propertytitle)]
        [TestCase(PropertytitleColor)]
        [TestCase(PropertytitleSize)]
        public void AUT_Dashboard_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dashboardInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (Dashboard) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="Dashboard" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbackgroundEndColorField)]
        [TestCase(FieldbackgroundFadeDirectionField)]
        [TestCase(FieldbackgroundStartColorField)]
        [TestCase(FielddashboardFiltersField)]
        [TestCase(FielddashboardTypeField)]
        [TestCase(FielddashboardTypeFieldSpecified)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldleftSectionField)]
        [TestCase(FieldmiddleSectionField)]
        [TestCase(FieldrightSectionField)]
        [TestCase(FieldrunningUserField)]
        [TestCase(FieldtextColorField)]
        [TestCase(FieldtitleField)]
        [TestCase(FieldtitleColorField)]
        [TestCase(FieldtitleSizeField)]
        public void AUT_Dashboard_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dashboardInstanceFixture, 
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
        ///     Class (<see cref="Dashboard" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_Dashboard_Is_Instance_Present_Test()
        {
            // Assert
            _dashboardInstanceType.ShouldNotBeNull();
            _dashboardInstance.ShouldNotBeNull();
            _dashboardInstanceFixture.ShouldNotBeNull();
            _dashboardInstance.ShouldBeAssignableTo<Dashboard>();
            _dashboardInstanceFixture.ShouldBeAssignableTo<Dashboard>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (Dashboard) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_Dashboard_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            Dashboard instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dashboardInstanceType.ShouldNotBeNull();
            _dashboardInstance.ShouldNotBeNull();
            _dashboardInstanceFixture.ShouldNotBeNull();
            _dashboardInstance.ShouldBeAssignableTo<Dashboard>();
            _dashboardInstanceFixture.ShouldBeAssignableTo<Dashboard>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (Dashboard) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertybackgroundEndColor)]
        [TestCaseGeneric(typeof(ChartBackgroundDirection) , PropertybackgroundFadeDirection)]
        [TestCaseGeneric(typeof(string) , PropertybackgroundStartColor)]
        [TestCaseGeneric(typeof(DashboardFilter[]) , PropertydashboardFilters)]
        [TestCaseGeneric(typeof(DashboardType) , PropertydashboardType)]
        [TestCaseGeneric(typeof(bool) , PropertydashboardTypeSpecified)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(DashboardComponentSection) , PropertyleftSection)]
        [TestCaseGeneric(typeof(DashboardComponentSection) , PropertymiddleSection)]
        [TestCaseGeneric(typeof(DashboardComponentSection) , PropertyrightSection)]
        [TestCaseGeneric(typeof(string) , PropertyrunningUser)]
        [TestCaseGeneric(typeof(string) , PropertytextColor)]
        [TestCaseGeneric(typeof(string) , Propertytitle)]
        [TestCaseGeneric(typeof(string) , PropertytitleColor)]
        [TestCaseGeneric(typeof(int) , PropertytitleSize)]
        public void AUT_Dashboard_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<Dashboard, T>(_dashboardInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (backgroundEndColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_backgroundEndColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybackgroundEndColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (backgroundFadeDirection) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_backgroundFadeDirection_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertybackgroundFadeDirection);
            Action currentAction = () => propertyInfo.SetValue(_dashboardInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (backgroundFadeDirection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_backgroundFadeDirection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybackgroundFadeDirection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (backgroundStartColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_backgroundStartColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybackgroundStartColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (dashboardFilters) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_dashboardFilters_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydashboardFilters);
            Action currentAction = () => propertyInfo.SetValue(_dashboardInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (dashboardFilters) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_dashboardFilters_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydashboardFilters);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (dashboardType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_dashboardType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydashboardType);
            Action currentAction = () => propertyInfo.SetValue(_dashboardInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (dashboardType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_dashboardType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydashboardType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (dashboardTypeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_dashboardTypeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydashboardTypeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (Dashboard) => Property (leftSection) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_leftSection_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyleftSection);
            Action currentAction = () => propertyInfo.SetValue(_dashboardInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (leftSection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_leftSection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyleftSection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (middleSection) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_middleSection_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertymiddleSection);
            Action currentAction = () => propertyInfo.SetValue(_dashboardInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (middleSection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_middleSection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymiddleSection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (rightSection) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_rightSection_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyrightSection);
            Action currentAction = () => propertyInfo.SetValue(_dashboardInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (rightSection) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_rightSection_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrightSection);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (runningUser) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_runningUser_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrunningUser);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (textColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_textColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytextColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (titleColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_titleColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytitleColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (Dashboard) => Property (titleSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_Dashboard_Public_Class_titleSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytitleSize);

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