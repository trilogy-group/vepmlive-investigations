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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.AddressSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class AddressSettingsTest : AbstractBaseSetupTypedTest<AddressSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (AddressSettings) Initializer

        private const string PropertycountriesAndStates = "countriesAndStates";
        private const string FieldcountriesAndStatesField = "countriesAndStatesField";
        private Type _addressSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private AddressSettings _addressSettingsInstance;
        private AddressSettings _addressSettingsInstanceFixture;

        #region General Initializer : Class (AddressSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="AddressSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _addressSettingsInstanceType = typeof(AddressSettings);
            _addressSettingsInstanceFixture = Create(true);
            _addressSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (AddressSettings)

        #region General Initializer : Class (AddressSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="AddressSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertycountriesAndStates)]
        public void AUT_AddressSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_addressSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (AddressSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="AddressSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcountriesAndStatesField)]
        public void AUT_AddressSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_addressSettingsInstanceFixture, 
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
        ///     Class (<see cref="AddressSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_AddressSettings_Is_Instance_Present_Test()
        {
            // Assert
            _addressSettingsInstanceType.ShouldNotBeNull();
            _addressSettingsInstance.ShouldNotBeNull();
            _addressSettingsInstanceFixture.ShouldNotBeNull();
            _addressSettingsInstance.ShouldBeAssignableTo<AddressSettings>();
            _addressSettingsInstanceFixture.ShouldBeAssignableTo<AddressSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (AddressSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_AddressSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            AddressSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _addressSettingsInstanceType.ShouldNotBeNull();
            _addressSettingsInstance.ShouldNotBeNull();
            _addressSettingsInstanceFixture.ShouldNotBeNull();
            _addressSettingsInstance.ShouldBeAssignableTo<AddressSettings>();
            _addressSettingsInstanceFixture.ShouldBeAssignableTo<AddressSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (AddressSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(Country[]) , PropertycountriesAndStates)]
        public void AUT_AddressSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<AddressSettings, T>(_addressSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (AddressSettings) => Property (countriesAndStates) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AddressSettings_countriesAndStates_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycountriesAndStates);
            Action currentAction = () => propertyInfo.SetValue(_addressSettingsInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (AddressSettings) => Property (countriesAndStates) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_AddressSettings_Public_Class_countriesAndStates_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycountriesAndStates);

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