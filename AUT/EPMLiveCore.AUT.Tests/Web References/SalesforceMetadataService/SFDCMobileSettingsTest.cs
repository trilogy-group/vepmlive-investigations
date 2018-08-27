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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.SFDCMobileSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class SFDCMobileSettingsTest : AbstractBaseSetupTypedTest<SFDCMobileSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (SFDCMobileSettings) Initializer

        private const string PropertyenableMobileLite = "enableMobileLite";
        private const string PropertyenableMobileLiteSpecified = "enableMobileLiteSpecified";
        private const string PropertyenableUserToDeviceLinking = "enableUserToDeviceLinking";
        private const string PropertyenableUserToDeviceLinkingSpecified = "enableUserToDeviceLinkingSpecified";
        private const string FieldenableMobileLiteField = "enableMobileLiteField";
        private const string FieldenableMobileLiteFieldSpecified = "enableMobileLiteFieldSpecified";
        private const string FieldenableUserToDeviceLinkingField = "enableUserToDeviceLinkingField";
        private const string FieldenableUserToDeviceLinkingFieldSpecified = "enableUserToDeviceLinkingFieldSpecified";
        private Type _sFDCMobileSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private SFDCMobileSettings _sFDCMobileSettingsInstance;
        private SFDCMobileSettings _sFDCMobileSettingsInstanceFixture;

        #region General Initializer : Class (SFDCMobileSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="SFDCMobileSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _sFDCMobileSettingsInstanceType = typeof(SFDCMobileSettings);
            _sFDCMobileSettingsInstanceFixture = Create(true);
            _sFDCMobileSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (SFDCMobileSettings)

        #region General Initializer : Class (SFDCMobileSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="SFDCMobileSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyenableMobileLite)]
        [TestCase(PropertyenableMobileLiteSpecified)]
        [TestCase(PropertyenableUserToDeviceLinking)]
        [TestCase(PropertyenableUserToDeviceLinkingSpecified)]
        public void AUT_SFDCMobileSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_sFDCMobileSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (SFDCMobileSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="SFDCMobileSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldenableMobileLiteField)]
        [TestCase(FieldenableMobileLiteFieldSpecified)]
        [TestCase(FieldenableUserToDeviceLinkingField)]
        [TestCase(FieldenableUserToDeviceLinkingFieldSpecified)]
        public void AUT_SFDCMobileSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_sFDCMobileSettingsInstanceFixture, 
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
        ///     Class (<see cref="SFDCMobileSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_SFDCMobileSettings_Is_Instance_Present_Test()
        {
            // Assert
            _sFDCMobileSettingsInstanceType.ShouldNotBeNull();
            _sFDCMobileSettingsInstance.ShouldNotBeNull();
            _sFDCMobileSettingsInstanceFixture.ShouldNotBeNull();
            _sFDCMobileSettingsInstance.ShouldBeAssignableTo<SFDCMobileSettings>();
            _sFDCMobileSettingsInstanceFixture.ShouldBeAssignableTo<SFDCMobileSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (SFDCMobileSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_SFDCMobileSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            SFDCMobileSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _sFDCMobileSettingsInstanceType.ShouldNotBeNull();
            _sFDCMobileSettingsInstance.ShouldNotBeNull();
            _sFDCMobileSettingsInstanceFixture.ShouldNotBeNull();
            _sFDCMobileSettingsInstance.ShouldBeAssignableTo<SFDCMobileSettings>();
            _sFDCMobileSettingsInstanceFixture.ShouldBeAssignableTo<SFDCMobileSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (SFDCMobileSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyenableMobileLite)]
        [TestCaseGeneric(typeof(bool) , PropertyenableMobileLiteSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableUserToDeviceLinking)]
        [TestCaseGeneric(typeof(bool) , PropertyenableUserToDeviceLinkingSpecified)]
        public void AUT_SFDCMobileSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<SFDCMobileSettings, T>(_sFDCMobileSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (SFDCMobileSettings) => Property (enableMobileLite) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SFDCMobileSettings_Public_Class_enableMobileLite_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableMobileLite);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SFDCMobileSettings) => Property (enableMobileLiteSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SFDCMobileSettings_Public_Class_enableMobileLiteSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableMobileLiteSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SFDCMobileSettings) => Property (enableUserToDeviceLinking) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SFDCMobileSettings_Public_Class_enableUserToDeviceLinking_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableUserToDeviceLinking);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (SFDCMobileSettings) => Property (enableUserToDeviceLinkingSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_SFDCMobileSettings_Public_Class_enableUserToDeviceLinkingSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableUserToDeviceLinkingSpecified);

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