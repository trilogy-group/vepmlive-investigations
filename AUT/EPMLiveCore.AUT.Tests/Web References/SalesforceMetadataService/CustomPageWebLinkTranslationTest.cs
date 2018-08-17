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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomPageWebLinkTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomPageWebLinkTranslationTest : AbstractBaseSetupTypedTest<CustomPageWebLinkTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomPageWebLinkTranslation) Initializer

        private const string Propertylabel = "label";
        private const string Propertyname = "name";
        private const string FieldlabelField = "labelField";
        private const string FieldnameField = "nameField";
        private Type _customPageWebLinkTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomPageWebLinkTranslation _customPageWebLinkTranslationInstance;
        private CustomPageWebLinkTranslation _customPageWebLinkTranslationInstanceFixture;

        #region General Initializer : Class (CustomPageWebLinkTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomPageWebLinkTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customPageWebLinkTranslationInstanceType = typeof(CustomPageWebLinkTranslation);
            _customPageWebLinkTranslationInstanceFixture = Create(true);
            _customPageWebLinkTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomPageWebLinkTranslation)

        #region General Initializer : Class (CustomPageWebLinkTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomPageWebLinkTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertylabel)]
        [TestCase(Propertyname)]
        public void AUT_CustomPageWebLinkTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customPageWebLinkTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomPageWebLinkTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomPageWebLinkTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldlabelField)]
        [TestCase(FieldnameField)]
        public void AUT_CustomPageWebLinkTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customPageWebLinkTranslationInstanceFixture, 
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
        ///     Class (<see cref="CustomPageWebLinkTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomPageWebLinkTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _customPageWebLinkTranslationInstanceType.ShouldNotBeNull();
            _customPageWebLinkTranslationInstance.ShouldNotBeNull();
            _customPageWebLinkTranslationInstanceFixture.ShouldNotBeNull();
            _customPageWebLinkTranslationInstance.ShouldBeAssignableTo<CustomPageWebLinkTranslation>();
            _customPageWebLinkTranslationInstanceFixture.ShouldBeAssignableTo<CustomPageWebLinkTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomPageWebLinkTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomPageWebLinkTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomPageWebLinkTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customPageWebLinkTranslationInstanceType.ShouldNotBeNull();
            _customPageWebLinkTranslationInstance.ShouldNotBeNull();
            _customPageWebLinkTranslationInstanceFixture.ShouldNotBeNull();
            _customPageWebLinkTranslationInstance.ShouldBeAssignableTo<CustomPageWebLinkTranslation>();
            _customPageWebLinkTranslationInstanceFixture.ShouldBeAssignableTo<CustomPageWebLinkTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomPageWebLinkTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_CustomPageWebLinkTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomPageWebLinkTranslation, T>(_customPageWebLinkTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomPageWebLinkTranslation) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomPageWebLinkTranslation_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomPageWebLinkTranslation) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomPageWebLinkTranslation_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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