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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.PicklistValueTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PicklistValueTranslationTest : AbstractBaseSetupTypedTest<PicklistValueTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PicklistValueTranslation) Initializer

        private const string PropertymasterLabel = "masterLabel";
        private const string Propertytranslation = "translation";
        private const string FieldmasterLabelField = "masterLabelField";
        private const string FieldtranslationField = "translationField";
        private Type _picklistValueTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PicklistValueTranslation _picklistValueTranslationInstance;
        private PicklistValueTranslation _picklistValueTranslationInstanceFixture;

        #region General Initializer : Class (PicklistValueTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PicklistValueTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _picklistValueTranslationInstanceType = typeof(PicklistValueTranslation);
            _picklistValueTranslationInstanceFixture = Create(true);
            _picklistValueTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PicklistValueTranslation)

        #region General Initializer : Class (PicklistValueTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PicklistValueTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertymasterLabel)]
        [TestCase(Propertytranslation)]
        public void AUT_PicklistValueTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_picklistValueTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PicklistValueTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PicklistValueTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldmasterLabelField)]
        [TestCase(FieldtranslationField)]
        public void AUT_PicklistValueTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_picklistValueTranslationInstanceFixture, 
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
        ///     Class (<see cref="PicklistValueTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_PicklistValueTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _picklistValueTranslationInstanceType.ShouldNotBeNull();
            _picklistValueTranslationInstance.ShouldNotBeNull();
            _picklistValueTranslationInstanceFixture.ShouldNotBeNull();
            _picklistValueTranslationInstance.ShouldBeAssignableTo<PicklistValueTranslation>();
            _picklistValueTranslationInstanceFixture.ShouldBeAssignableTo<PicklistValueTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PicklistValueTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_PicklistValueTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PicklistValueTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _picklistValueTranslationInstanceType.ShouldNotBeNull();
            _picklistValueTranslationInstance.ShouldNotBeNull();
            _picklistValueTranslationInstanceFixture.ShouldNotBeNull();
            _picklistValueTranslationInstance.ShouldBeAssignableTo<PicklistValueTranslation>();
            _picklistValueTranslationInstanceFixture.ShouldBeAssignableTo<PicklistValueTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PicklistValueTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertymasterLabel)]
        [TestCaseGeneric(typeof(string) , Propertytranslation)]
        public void AUT_PicklistValueTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PicklistValueTranslation, T>(_picklistValueTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValueTranslation) => Property (masterLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValueTranslation_Public_Class_masterLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymasterLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValueTranslation) => Property (translation) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValueTranslation_Public_Class_translation_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytranslation);

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