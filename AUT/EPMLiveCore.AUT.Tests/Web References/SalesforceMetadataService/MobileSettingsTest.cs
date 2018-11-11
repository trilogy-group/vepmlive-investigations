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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.MobileSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class MobileSettingsTest : AbstractBaseSetupTypedTest<MobileSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (MobileSettings) Initializer

        private const string PropertychatterMobile = "chatterMobile";
        private const string PropertydashboardMobile = "dashboardMobile";
        private const string PropertysalesforceMobile = "salesforceMobile";
        private const string PropertytouchMobile = "touchMobile";
        private const string FieldchatterMobileField = "chatterMobileField";
        private const string FielddashboardMobileField = "dashboardMobileField";
        private const string FieldsalesforceMobileField = "salesforceMobileField";
        private const string FieldtouchMobileField = "touchMobileField";
        private Type _mobileSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private MobileSettings _mobileSettingsInstance;
        private MobileSettings _mobileSettingsInstanceFixture;

        #region General Initializer : Class (MobileSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="MobileSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _mobileSettingsInstanceType = typeof(MobileSettings);
            _mobileSettingsInstanceFixture = Create(true);
            _mobileSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (MobileSettings)

        #region General Initializer : Class (MobileSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="MobileSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertychatterMobile)]
        [TestCase(PropertydashboardMobile)]
        [TestCase(PropertysalesforceMobile)]
        [TestCase(PropertytouchMobile)]
        public void AUT_MobileSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_mobileSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (MobileSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="MobileSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldchatterMobileField)]
        [TestCase(FielddashboardMobileField)]
        [TestCase(FieldsalesforceMobileField)]
        [TestCase(FieldtouchMobileField)]
        public void AUT_MobileSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_mobileSettingsInstanceFixture, 
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
        ///     Class (<see cref="MobileSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_MobileSettings_Is_Instance_Present_Test()
        {
            // Assert
            _mobileSettingsInstanceType.ShouldNotBeNull();
            _mobileSettingsInstance.ShouldNotBeNull();
            _mobileSettingsInstanceFixture.ShouldNotBeNull();
            _mobileSettingsInstance.ShouldBeAssignableTo<MobileSettings>();
            _mobileSettingsInstanceFixture.ShouldBeAssignableTo<MobileSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (MobileSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_MobileSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            MobileSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _mobileSettingsInstanceType.ShouldNotBeNull();
            _mobileSettingsInstance.ShouldNotBeNull();
            _mobileSettingsInstanceFixture.ShouldNotBeNull();
            _mobileSettingsInstance.ShouldBeAssignableTo<MobileSettings>();
            _mobileSettingsInstanceFixture.ShouldBeAssignableTo<MobileSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (MobileSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ChatterMobileSettings) , PropertychatterMobile)]
        [TestCaseGeneric(typeof(DashboardMobileSettings) , PropertydashboardMobile)]
        [TestCaseGeneric(typeof(SFDCMobileSettings) , PropertysalesforceMobile)]
        [TestCaseGeneric(typeof(TouchMobileSettings) , PropertytouchMobile)]
        public void AUT_MobileSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<MobileSettings, T>(_mobileSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (MobileSettings) => Property (chatterMobile) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MobileSettings_chatterMobile_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertychatterMobile);
            Action currentAction = () => propertyInfo.SetValue(_mobileSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MobileSettings) => Property (chatterMobile) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MobileSettings_Public_Class_chatterMobile_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychatterMobile);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MobileSettings) => Property (dashboardMobile) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MobileSettings_dashboardMobile_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydashboardMobile);
            Action currentAction = () => propertyInfo.SetValue(_mobileSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MobileSettings) => Property (dashboardMobile) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MobileSettings_Public_Class_dashboardMobile_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydashboardMobile);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MobileSettings) => Property (salesforceMobile) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MobileSettings_salesforceMobile_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysalesforceMobile);
            Action currentAction = () => propertyInfo.SetValue(_mobileSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MobileSettings) => Property (salesforceMobile) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MobileSettings_Public_Class_salesforceMobile_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysalesforceMobile);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (MobileSettings) => Property (touchMobile) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MobileSettings_touchMobile_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertytouchMobile);
            Action currentAction = () => propertyInfo.SetValue(_mobileSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (MobileSettings) => Property (touchMobile) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_MobileSettings_Public_Class_touchMobile_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytouchMobile);

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