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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomApplicationTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomApplicationTranslationTest : AbstractBaseSetupTypedTest<CustomApplicationTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomApplicationTranslation) Initializer

        private const string Propertylabel = "label";
        private const string Propertyname = "name";
        private const string FieldlabelField = "labelField";
        private const string FieldnameField = "nameField";
        private Type _customApplicationTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomApplicationTranslation _customApplicationTranslationInstance;
        private CustomApplicationTranslation _customApplicationTranslationInstanceFixture;

        #region General Initializer : Class (CustomApplicationTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomApplicationTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customApplicationTranslationInstanceType = typeof(CustomApplicationTranslation);
            _customApplicationTranslationInstanceFixture = Create(true);
            _customApplicationTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomApplicationTranslation)

        #region General Initializer : Class (CustomApplicationTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomApplicationTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylabel)]
        [TestCase(Propertyname)]
        public void AUT_CustomApplicationTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customApplicationTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomApplicationTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomApplicationTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlabelField)]
        [TestCase(FieldnameField)]
        public void AUT_CustomApplicationTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customApplicationTranslationInstanceFixture, 
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
        ///     Class (<see cref="CustomApplicationTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomApplicationTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _customApplicationTranslationInstanceType.ShouldNotBeNull();
            _customApplicationTranslationInstance.ShouldNotBeNull();
            _customApplicationTranslationInstanceFixture.ShouldNotBeNull();
            _customApplicationTranslationInstance.ShouldBeAssignableTo<CustomApplicationTranslation>();
            _customApplicationTranslationInstanceFixture.ShouldBeAssignableTo<CustomApplicationTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomApplicationTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomApplicationTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomApplicationTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customApplicationTranslationInstanceType.ShouldNotBeNull();
            _customApplicationTranslationInstance.ShouldNotBeNull();
            _customApplicationTranslationInstanceFixture.ShouldNotBeNull();
            _customApplicationTranslationInstance.ShouldBeAssignableTo<CustomApplicationTranslation>();
            _customApplicationTranslationInstanceFixture.ShouldBeAssignableTo<CustomApplicationTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomApplicationTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_CustomApplicationTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomApplicationTranslation, T>(_customApplicationTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationTranslation) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationTranslation_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomApplicationTranslation) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomApplicationTranslation_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyname);

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