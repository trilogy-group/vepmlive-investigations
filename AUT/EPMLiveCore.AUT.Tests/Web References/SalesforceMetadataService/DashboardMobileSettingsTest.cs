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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.DashboardMobileSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DashboardMobileSettingsTest : AbstractBaseSetupTypedTest<DashboardMobileSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DashboardMobileSettings) Initializer

        private const string PropertyenableDashboardIPadApp = "enableDashboardIPadApp";
        private const string PropertyenableDashboardIPadAppSpecified = "enableDashboardIPadAppSpecified";
        private const string FieldenableDashboardIPadAppField = "enableDashboardIPadAppField";
        private const string FieldenableDashboardIPadAppFieldSpecified = "enableDashboardIPadAppFieldSpecified";
        private Type _dashboardMobileSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DashboardMobileSettings _dashboardMobileSettingsInstance;
        private DashboardMobileSettings _dashboardMobileSettingsInstanceFixture;

        #region General Initializer : Class (DashboardMobileSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DashboardMobileSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dashboardMobileSettingsInstanceType = typeof(DashboardMobileSettings);
            _dashboardMobileSettingsInstanceFixture = Create(true);
            _dashboardMobileSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DashboardMobileSettings)

        #region General Initializer : Class (DashboardMobileSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DashboardMobileSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyenableDashboardIPadApp)]
        [TestCase(PropertyenableDashboardIPadAppSpecified)]
        public void AUT_DashboardMobileSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dashboardMobileSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DashboardMobileSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DashboardMobileSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldenableDashboardIPadAppField)]
        [TestCase(FieldenableDashboardIPadAppFieldSpecified)]
        public void AUT_DashboardMobileSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dashboardMobileSettingsInstanceFixture, 
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
        ///     Class (<see cref="DashboardMobileSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DashboardMobileSettings_Is_Instance_Present_Test()
        {
            // Assert
            _dashboardMobileSettingsInstanceType.ShouldNotBeNull();
            _dashboardMobileSettingsInstance.ShouldNotBeNull();
            _dashboardMobileSettingsInstanceFixture.ShouldNotBeNull();
            _dashboardMobileSettingsInstance.ShouldBeAssignableTo<DashboardMobileSettings>();
            _dashboardMobileSettingsInstanceFixture.ShouldBeAssignableTo<DashboardMobileSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DashboardMobileSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DashboardMobileSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DashboardMobileSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dashboardMobileSettingsInstanceType.ShouldNotBeNull();
            _dashboardMobileSettingsInstance.ShouldNotBeNull();
            _dashboardMobileSettingsInstanceFixture.ShouldNotBeNull();
            _dashboardMobileSettingsInstance.ShouldBeAssignableTo<DashboardMobileSettings>();
            _dashboardMobileSettingsInstanceFixture.ShouldBeAssignableTo<DashboardMobileSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DashboardMobileSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyenableDashboardIPadApp)]
        [TestCaseGeneric(typeof(bool) , PropertyenableDashboardIPadAppSpecified)]
        public void AUT_DashboardMobileSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DashboardMobileSettings, T>(_dashboardMobileSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardMobileSettings) => Property (enableDashboardIPadApp) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardMobileSettings_Public_Class_enableDashboardIPadApp_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableDashboardIPadApp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardMobileSettings) => Property (enableDashboardIPadAppSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardMobileSettings_Public_Class_enableDashboardIPadAppSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableDashboardIPadAppSpecified);

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