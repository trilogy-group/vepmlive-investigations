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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.TouchMobileSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class TouchMobileSettingsTest : AbstractBaseSetupTypedTest<TouchMobileSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (TouchMobileSettings) Initializer

        private const string PropertyenableTouchAppIPad = "enableTouchAppIPad";
        private const string PropertyenableTouchAppIPadSpecified = "enableTouchAppIPadSpecified";
        private const string PropertyenableTouchBrowserIPad = "enableTouchBrowserIPad";
        private const string PropertyenableTouchBrowserIPadSpecified = "enableTouchBrowserIPadSpecified";
        private const string PropertyenableTouchIosPhone = "enableTouchIosPhone";
        private const string PropertyenableTouchIosPhoneSpecified = "enableTouchIosPhoneSpecified";
        private const string PropertyenableVisualforceInTouch = "enableVisualforceInTouch";
        private const string PropertyenableVisualforceInTouchSpecified = "enableVisualforceInTouchSpecified";
        private const string FieldenableTouchAppIPadField = "enableTouchAppIPadField";
        private const string FieldenableTouchAppIPadFieldSpecified = "enableTouchAppIPadFieldSpecified";
        private const string FieldenableTouchBrowserIPadField = "enableTouchBrowserIPadField";
        private const string FieldenableTouchBrowserIPadFieldSpecified = "enableTouchBrowserIPadFieldSpecified";
        private const string FieldenableTouchIosPhoneField = "enableTouchIosPhoneField";
        private const string FieldenableTouchIosPhoneFieldSpecified = "enableTouchIosPhoneFieldSpecified";
        private const string FieldenableVisualforceInTouchField = "enableVisualforceInTouchField";
        private const string FieldenableVisualforceInTouchFieldSpecified = "enableVisualforceInTouchFieldSpecified";
        private Type _touchMobileSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private TouchMobileSettings _touchMobileSettingsInstance;
        private TouchMobileSettings _touchMobileSettingsInstanceFixture;

        #region General Initializer : Class (TouchMobileSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="TouchMobileSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _touchMobileSettingsInstanceType = typeof(TouchMobileSettings);
            _touchMobileSettingsInstanceFixture = Create(true);
            _touchMobileSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (TouchMobileSettings)

        #region General Initializer : Class (TouchMobileSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="TouchMobileSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyenableTouchAppIPad)]
        [TestCase(PropertyenableTouchAppIPadSpecified)]
        [TestCase(PropertyenableTouchBrowserIPad)]
        [TestCase(PropertyenableTouchBrowserIPadSpecified)]
        [TestCase(PropertyenableTouchIosPhone)]
        [TestCase(PropertyenableTouchIosPhoneSpecified)]
        [TestCase(PropertyenableVisualforceInTouch)]
        [TestCase(PropertyenableVisualforceInTouchSpecified)]
        public void AUT_TouchMobileSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_touchMobileSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (TouchMobileSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="TouchMobileSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldenableTouchAppIPadField)]
        [TestCase(FieldenableTouchAppIPadFieldSpecified)]
        [TestCase(FieldenableTouchBrowserIPadField)]
        [TestCase(FieldenableTouchBrowserIPadFieldSpecified)]
        [TestCase(FieldenableTouchIosPhoneField)]
        [TestCase(FieldenableTouchIosPhoneFieldSpecified)]
        [TestCase(FieldenableVisualforceInTouchField)]
        [TestCase(FieldenableVisualforceInTouchFieldSpecified)]
        public void AUT_TouchMobileSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_touchMobileSettingsInstanceFixture, 
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
        ///     Class (<see cref="TouchMobileSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_TouchMobileSettings_Is_Instance_Present_Test()
        {
            // Assert
            _touchMobileSettingsInstanceType.ShouldNotBeNull();
            _touchMobileSettingsInstance.ShouldNotBeNull();
            _touchMobileSettingsInstanceFixture.ShouldNotBeNull();
            _touchMobileSettingsInstance.ShouldBeAssignableTo<TouchMobileSettings>();
            _touchMobileSettingsInstanceFixture.ShouldBeAssignableTo<TouchMobileSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (TouchMobileSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_TouchMobileSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            TouchMobileSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _touchMobileSettingsInstanceType.ShouldNotBeNull();
            _touchMobileSettingsInstance.ShouldNotBeNull();
            _touchMobileSettingsInstanceFixture.ShouldNotBeNull();
            _touchMobileSettingsInstance.ShouldBeAssignableTo<TouchMobileSettings>();
            _touchMobileSettingsInstanceFixture.ShouldBeAssignableTo<TouchMobileSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (TouchMobileSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyenableTouchAppIPad)]
        [TestCaseGeneric(typeof(bool) , PropertyenableTouchAppIPadSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableTouchBrowserIPad)]
        [TestCaseGeneric(typeof(bool) , PropertyenableTouchBrowserIPadSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableTouchIosPhone)]
        [TestCaseGeneric(typeof(bool) , PropertyenableTouchIosPhoneSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableVisualforceInTouch)]
        [TestCaseGeneric(typeof(bool) , PropertyenableVisualforceInTouchSpecified)]
        public void AUT_TouchMobileSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<TouchMobileSettings, T>(_touchMobileSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (TouchMobileSettings) => Property (enableTouchAppIPad) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TouchMobileSettings_Public_Class_enableTouchAppIPad_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableTouchAppIPad);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TouchMobileSettings) => Property (enableTouchAppIPadSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TouchMobileSettings_Public_Class_enableTouchAppIPadSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableTouchAppIPadSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TouchMobileSettings) => Property (enableTouchBrowserIPad) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TouchMobileSettings_Public_Class_enableTouchBrowserIPad_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableTouchBrowserIPad);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TouchMobileSettings) => Property (enableTouchBrowserIPadSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TouchMobileSettings_Public_Class_enableTouchBrowserIPadSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableTouchBrowserIPadSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TouchMobileSettings) => Property (enableTouchIosPhone) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TouchMobileSettings_Public_Class_enableTouchIosPhone_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableTouchIosPhone);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TouchMobileSettings) => Property (enableTouchIosPhoneSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TouchMobileSettings_Public_Class_enableTouchIosPhoneSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableTouchIosPhoneSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TouchMobileSettings) => Property (enableVisualforceInTouch) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TouchMobileSettings_Public_Class_enableVisualforceInTouch_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableVisualforceInTouch);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (TouchMobileSettings) => Property (enableVisualforceInTouchSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_TouchMobileSettings_Public_Class_enableVisualforceInTouchSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableVisualforceInTouchSpecified);

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