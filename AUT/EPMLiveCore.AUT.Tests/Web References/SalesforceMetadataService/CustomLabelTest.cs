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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomLabel" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomLabelTest : AbstractBaseSetupTypedTest<CustomLabel>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomLabel) Initializer

        private const string Propertycategories = "categories";
        private const string Propertylanguage = "language";
        private const string PropertyshortDescription = "shortDescription";
        private const string Propertyvalue = "value";
        private const string FieldcategoriesField = "categoriesField";
        private const string FieldlanguageField = "languageField";
        private const string FieldprotectedField = "protectedField";
        private const string FieldshortDescriptionField = "shortDescriptionField";
        private const string FieldvalueField = "valueField";
        private Type _customLabelInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomLabel _customLabelInstance;
        private CustomLabel _customLabelInstanceFixture;

        #region General Initializer : Class (CustomLabel) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomLabel" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customLabelInstanceType = typeof(CustomLabel);
            _customLabelInstanceFixture = Create(true);
            _customLabelInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomLabel)

        #region General Initializer : Class (CustomLabel) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomLabel" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycategories)]
        [TestCase(Propertylanguage)]
        [TestCase(PropertyshortDescription)]
        [TestCase(Propertyvalue)]
        public void AUT_CustomLabel_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customLabelInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomLabel) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomLabel" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcategoriesField)]
        [TestCase(FieldlanguageField)]
        [TestCase(FieldprotectedField)]
        [TestCase(FieldshortDescriptionField)]
        [TestCase(FieldvalueField)]
        public void AUT_CustomLabel_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customLabelInstanceFixture, 
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
        ///     Class (<see cref="CustomLabel" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomLabel_Is_Instance_Present_Test()
        {
            // Assert
            _customLabelInstanceType.ShouldNotBeNull();
            _customLabelInstance.ShouldNotBeNull();
            _customLabelInstanceFixture.ShouldNotBeNull();
            _customLabelInstance.ShouldBeAssignableTo<CustomLabel>();
            _customLabelInstanceFixture.ShouldBeAssignableTo<CustomLabel>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomLabel) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomLabel_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomLabel instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customLabelInstanceType.ShouldNotBeNull();
            _customLabelInstance.ShouldNotBeNull();
            _customLabelInstanceFixture.ShouldNotBeNull();
            _customLabelInstance.ShouldBeAssignableTo<CustomLabel>();
            _customLabelInstanceFixture.ShouldBeAssignableTo<CustomLabel>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomLabel) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertycategories)]
        [TestCaseGeneric(typeof(string) , Propertylanguage)]
        [TestCaseGeneric(typeof(string) , PropertyshortDescription)]
        [TestCaseGeneric(typeof(string) , Propertyvalue)]
        public void AUT_CustomLabel_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomLabel, T>(_customLabelInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (CustomLabel) => Property (categories) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomLabel_Public_Class_categories_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycategories);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomLabel) => Property (language) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomLabel_Public_Class_language_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylanguage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomLabel) => Property (shortDescription) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomLabel_Public_Class_shortDescription_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshortDescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomLabel) => Property (value) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomLabel_Public_Class_value_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyvalue);

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