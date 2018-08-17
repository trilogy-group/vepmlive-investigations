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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.IdeasSettings" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class IdeasSettingsTest : AbstractBaseSetupTypedTest<IdeasSettings>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (IdeasSettings) Initializer

        private const string PropertyenableIdeaThemes = "enableIdeaThemes";
        private const string PropertyenableIdeaThemesSpecified = "enableIdeaThemesSpecified";
        private const string PropertyenableIdeas = "enableIdeas";
        private const string PropertyenableIdeasSpecified = "enableIdeasSpecified";
        private const string PropertyhalfLife = "halfLife";
        private const string PropertyhalfLifeSpecified = "halfLifeSpecified";
        private const string FieldenableIdeaThemesField = "enableIdeaThemesField";
        private const string FieldenableIdeaThemesFieldSpecified = "enableIdeaThemesFieldSpecified";
        private const string FieldenableIdeasField = "enableIdeasField";
        private const string FieldenableIdeasFieldSpecified = "enableIdeasFieldSpecified";
        private const string FieldhalfLifeField = "halfLifeField";
        private const string FieldhalfLifeFieldSpecified = "halfLifeFieldSpecified";
        private Type _ideasSettingsInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private IdeasSettings _ideasSettingsInstance;
        private IdeasSettings _ideasSettingsInstanceFixture;

        #region General Initializer : Class (IdeasSettings) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="IdeasSettings" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _ideasSettingsInstanceType = typeof(IdeasSettings);
            _ideasSettingsInstanceFixture = Create(true);
            _ideasSettingsInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (IdeasSettings)

        #region General Initializer : Class (IdeasSettings) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="IdeasSettings" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyenableIdeaThemes)]
        [TestCase(PropertyenableIdeaThemesSpecified)]
        [TestCase(PropertyenableIdeas)]
        [TestCase(PropertyenableIdeasSpecified)]
        [TestCase(PropertyhalfLife)]
        [TestCase(PropertyhalfLifeSpecified)]
        public void AUT_IdeasSettings_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_ideasSettingsInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (IdeasSettings) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="IdeasSettings" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldenableIdeaThemesField)]
        [TestCase(FieldenableIdeaThemesFieldSpecified)]
        [TestCase(FieldenableIdeasField)]
        [TestCase(FieldenableIdeasFieldSpecified)]
        [TestCase(FieldhalfLifeField)]
        [TestCase(FieldhalfLifeFieldSpecified)]
        public void AUT_IdeasSettings_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_ideasSettingsInstanceFixture, 
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
        ///     Class (<see cref="IdeasSettings" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_IdeasSettings_Is_Instance_Present_Test()
        {
            // Assert
            _ideasSettingsInstanceType.ShouldNotBeNull();
            _ideasSettingsInstance.ShouldNotBeNull();
            _ideasSettingsInstanceFixture.ShouldNotBeNull();
            _ideasSettingsInstance.ShouldBeAssignableTo<IdeasSettings>();
            _ideasSettingsInstanceFixture.ShouldBeAssignableTo<IdeasSettings>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (IdeasSettings) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_IdeasSettings_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            IdeasSettings instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _ideasSettingsInstanceType.ShouldNotBeNull();
            _ideasSettingsInstance.ShouldNotBeNull();
            _ideasSettingsInstanceFixture.ShouldNotBeNull();
            _ideasSettingsInstance.ShouldBeAssignableTo<IdeasSettings>();
            _ideasSettingsInstanceFixture.ShouldBeAssignableTo<IdeasSettings>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (IdeasSettings) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyenableIdeaThemes)]
        [TestCaseGeneric(typeof(bool) , PropertyenableIdeaThemesSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableIdeas)]
        [TestCaseGeneric(typeof(bool) , PropertyenableIdeasSpecified)]
        [TestCaseGeneric(typeof(double) , PropertyhalfLife)]
        [TestCaseGeneric(typeof(bool) , PropertyhalfLifeSpecified)]
        public void AUT_IdeasSettings_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<IdeasSettings, T>(_ideasSettingsInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (IdeasSettings) => Property (enableIdeas) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_IdeasSettings_Public_Class_enableIdeas_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableIdeas);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (IdeasSettings) => Property (enableIdeasSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_IdeasSettings_Public_Class_enableIdeasSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableIdeasSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (IdeasSettings) => Property (enableIdeaThemes) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_IdeasSettings_Public_Class_enableIdeaThemes_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableIdeaThemes);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (IdeasSettings) => Property (enableIdeaThemesSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_IdeasSettings_Public_Class_enableIdeaThemesSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableIdeaThemesSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (IdeasSettings) => Property (halfLife) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_IdeasSettings_Public_Class_halfLife_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhalfLife);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (IdeasSettings) => Property (halfLifeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_IdeasSettings_Public_Class_halfLifeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhalfLifeSpecified);

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