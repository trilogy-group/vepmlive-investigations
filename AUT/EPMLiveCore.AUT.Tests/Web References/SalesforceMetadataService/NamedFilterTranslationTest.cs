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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.NamedFilterTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class NamedFilterTranslationTest : AbstractBaseSetupTypedTest<NamedFilterTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (NamedFilterTranslation) Initializer

        private const string PropertyerrorMessage = "errorMessage";
        private const string PropertyinformationalMessage = "informationalMessage";
        private const string Propertyname = "name";
        private const string FielderrorMessageField = "errorMessageField";
        private const string FieldinformationalMessageField = "informationalMessageField";
        private const string FieldnameField = "nameField";
        private Type _namedFilterTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private NamedFilterTranslation _namedFilterTranslationInstance;
        private NamedFilterTranslation _namedFilterTranslationInstanceFixture;

        #region General Initializer : Class (NamedFilterTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="NamedFilterTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _namedFilterTranslationInstanceType = typeof(NamedFilterTranslation);
            _namedFilterTranslationInstanceFixture = Create(true);
            _namedFilterTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (NamedFilterTranslation)

        #region General Initializer : Class (NamedFilterTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="NamedFilterTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyerrorMessage)]
        [TestCase(PropertyinformationalMessage)]
        [TestCase(Propertyname)]
        public void AUT_NamedFilterTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_namedFilterTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (NamedFilterTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="NamedFilterTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielderrorMessageField)]
        [TestCase(FieldinformationalMessageField)]
        [TestCase(FieldnameField)]
        public void AUT_NamedFilterTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_namedFilterTranslationInstanceFixture, 
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
        ///     Class (<see cref="NamedFilterTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_NamedFilterTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _namedFilterTranslationInstanceType.ShouldNotBeNull();
            _namedFilterTranslationInstance.ShouldNotBeNull();
            _namedFilterTranslationInstanceFixture.ShouldNotBeNull();
            _namedFilterTranslationInstance.ShouldBeAssignableTo<NamedFilterTranslation>();
            _namedFilterTranslationInstanceFixture.ShouldBeAssignableTo<NamedFilterTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (NamedFilterTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_NamedFilterTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            NamedFilterTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _namedFilterTranslationInstanceType.ShouldNotBeNull();
            _namedFilterTranslationInstance.ShouldNotBeNull();
            _namedFilterTranslationInstanceFixture.ShouldNotBeNull();
            _namedFilterTranslationInstance.ShouldBeAssignableTo<NamedFilterTranslation>();
            _namedFilterTranslationInstanceFixture.ShouldBeAssignableTo<NamedFilterTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (NamedFilterTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyerrorMessage)]
        [TestCaseGeneric(typeof(string) , PropertyinformationalMessage)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        public void AUT_NamedFilterTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<NamedFilterTranslation, T>(_namedFilterTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (NamedFilterTranslation) => Property (errorMessage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_NamedFilterTranslation_Public_Class_errorMessage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyerrorMessage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (NamedFilterTranslation) => Property (informationalMessage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_NamedFilterTranslation_Public_Class_informationalMessage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyinformationalMessage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (NamedFilterTranslation) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_NamedFilterTranslation_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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