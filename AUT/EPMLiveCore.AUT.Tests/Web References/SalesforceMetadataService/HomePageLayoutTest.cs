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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.HomePageLayout" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class HomePageLayoutTest : AbstractBaseSetupTypedTest<HomePageLayout>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (HomePageLayout) Initializer

        private const string PropertynarrowComponents = "narrowComponents";
        private const string PropertywideComponents = "wideComponents";
        private const string FieldnarrowComponentsField = "narrowComponentsField";
        private const string FieldwideComponentsField = "wideComponentsField";
        private Type _homePageLayoutInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private HomePageLayout _homePageLayoutInstance;
        private HomePageLayout _homePageLayoutInstanceFixture;

        #region General Initializer : Class (HomePageLayout) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="HomePageLayout" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _homePageLayoutInstanceType = typeof(HomePageLayout);
            _homePageLayoutInstanceFixture = Create(true);
            _homePageLayoutInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (HomePageLayout)

        #region General Initializer : Class (HomePageLayout) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="HomePageLayout" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertynarrowComponents)]
        [TestCase(PropertywideComponents)]
        public void AUT_HomePageLayout_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_homePageLayoutInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (HomePageLayout) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="HomePageLayout" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldnarrowComponentsField)]
        [TestCase(FieldwideComponentsField)]
        public void AUT_HomePageLayout_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_homePageLayoutInstanceFixture, 
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
        ///     Class (<see cref="HomePageLayout" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_HomePageLayout_Is_Instance_Present_Test()
        {
            // Assert
            _homePageLayoutInstanceType.ShouldNotBeNull();
            _homePageLayoutInstance.ShouldNotBeNull();
            _homePageLayoutInstanceFixture.ShouldNotBeNull();
            _homePageLayoutInstance.ShouldBeAssignableTo<HomePageLayout>();
            _homePageLayoutInstanceFixture.ShouldBeAssignableTo<HomePageLayout>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (HomePageLayout) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_HomePageLayout_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            HomePageLayout instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _homePageLayoutInstanceType.ShouldNotBeNull();
            _homePageLayoutInstance.ShouldNotBeNull();
            _homePageLayoutInstanceFixture.ShouldNotBeNull();
            _homePageLayoutInstance.ShouldBeAssignableTo<HomePageLayout>();
            _homePageLayoutInstanceFixture.ShouldBeAssignableTo<HomePageLayout>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (HomePageLayout) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string[]) , PropertynarrowComponents)]
        [TestCaseGeneric(typeof(string[]) , PropertywideComponents)]
        public void AUT_HomePageLayout_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<HomePageLayout, T>(_homePageLayoutInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (HomePageLayout) => Property (narrowComponents) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_HomePageLayout_narrowComponents_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertynarrowComponents);
            Action currentAction = () => propertyInfo.SetValue(_homePageLayoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (HomePageLayout) => Property (narrowComponents) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_HomePageLayout_Public_Class_narrowComponents_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertynarrowComponents);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (HomePageLayout) => Property (wideComponents) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_HomePageLayout_wideComponents_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertywideComponents);
            Action currentAction = () => propertyInfo.SetValue(_homePageLayoutInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (HomePageLayout) => Property (wideComponents) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_HomePageLayout_Public_Class_wideComponents_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertywideComponents);

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