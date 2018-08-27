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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FiscalYearSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FiscalYearSettingsTest : AbstractBaseSetupTypedTest<FiscalYearSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FiscalYearSettings) Initializer

        private const string PropertyfiscalYearNameBasedOn = "fiscalYearNameBasedOn";
        private const string PropertystartMonth = "startMonth";
        private const string FieldfiscalYearNameBasedOnField = "fiscalYearNameBasedOnField";
        private const string FieldstartMonthField = "startMonthField";
        private Type _fiscalYearSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FiscalYearSettings _fiscalYearSettingsInstance;
        private FiscalYearSettings _fiscalYearSettingsInstanceFixture;

        #region General Initializer : Class (FiscalYearSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FiscalYearSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _fiscalYearSettingsInstanceType = typeof(FiscalYearSettings);
            _fiscalYearSettingsInstanceFixture = Create(true);
            _fiscalYearSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FiscalYearSettings)

        #region General Initializer : Class (FiscalYearSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FiscalYearSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyfiscalYearNameBasedOn)]
        [TestCase(PropertystartMonth)]
        public void AUT_FiscalYearSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_fiscalYearSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FiscalYearSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FiscalYearSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldfiscalYearNameBasedOnField)]
        [TestCase(FieldstartMonthField)]
        public void AUT_FiscalYearSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_fiscalYearSettingsInstanceFixture, 
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
        ///     Class (<see cref="FiscalYearSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FiscalYearSettings_Is_Instance_Present_Test()
        {
            // Assert
            _fiscalYearSettingsInstanceType.ShouldNotBeNull();
            _fiscalYearSettingsInstance.ShouldNotBeNull();
            _fiscalYearSettingsInstanceFixture.ShouldNotBeNull();
            _fiscalYearSettingsInstance.ShouldBeAssignableTo<FiscalYearSettings>();
            _fiscalYearSettingsInstanceFixture.ShouldBeAssignableTo<FiscalYearSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FiscalYearSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FiscalYearSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FiscalYearSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _fiscalYearSettingsInstanceType.ShouldNotBeNull();
            _fiscalYearSettingsInstance.ShouldNotBeNull();
            _fiscalYearSettingsInstanceFixture.ShouldNotBeNull();
            _fiscalYearSettingsInstance.ShouldBeAssignableTo<FiscalYearSettings>();
            _fiscalYearSettingsInstanceFixture.ShouldBeAssignableTo<FiscalYearSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FiscalYearSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyfiscalYearNameBasedOn)]
        [TestCaseGeneric(typeof(string) , PropertystartMonth)]
        public void AUT_FiscalYearSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FiscalYearSettings, T>(_fiscalYearSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FiscalYearSettings) => Property (fiscalYearNameBasedOn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FiscalYearSettings_Public_Class_fiscalYearNameBasedOn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyfiscalYearNameBasedOn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FiscalYearSettings) => Property (startMonth) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FiscalYearSettings_Public_Class_startMonth_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertystartMonth);

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