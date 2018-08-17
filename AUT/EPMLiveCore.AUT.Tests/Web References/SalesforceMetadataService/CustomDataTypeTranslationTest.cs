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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomDataTypeTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomDataTypeTranslationTest : AbstractBaseSetupTypedTest<CustomDataTypeTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomDataTypeTranslation) Initializer

        private const string Propertycomponents = "components";
        private const string PropertycustomDataTypeName = "customDataTypeName";
        private const string Propertydescription = "description";
        private const string Propertylabel = "label";
        private const string FieldcomponentsField = "componentsField";
        private const string FieldcustomDataTypeNameField = "customDataTypeNameField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldlabelField = "labelField";
        private Type _customDataTypeTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomDataTypeTranslation _customDataTypeTranslationInstance;
        private CustomDataTypeTranslation _customDataTypeTranslationInstanceFixture;

        #region General Initializer : Class (CustomDataTypeTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomDataTypeTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customDataTypeTranslationInstanceType = typeof(CustomDataTypeTranslation);
            _customDataTypeTranslationInstanceFixture = Create(true);
            _customDataTypeTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomDataTypeTranslation)

        #region General Initializer : Class (CustomDataTypeTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomDataTypeTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertycomponents)]
        [TestCase(PropertycustomDataTypeName)]
        [TestCase(Propertydescription)]
        [TestCase(Propertylabel)]
        public void AUT_CustomDataTypeTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customDataTypeTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomDataTypeTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomDataTypeTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldcomponentsField)]
        [TestCase(FieldcustomDataTypeNameField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldlabelField)]
        public void AUT_CustomDataTypeTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customDataTypeTranslationInstanceFixture, 
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
        ///     Class (<see cref="CustomDataTypeTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomDataTypeTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _customDataTypeTranslationInstanceType.ShouldNotBeNull();
            _customDataTypeTranslationInstance.ShouldNotBeNull();
            _customDataTypeTranslationInstanceFixture.ShouldNotBeNull();
            _customDataTypeTranslationInstance.ShouldBeAssignableTo<CustomDataTypeTranslation>();
            _customDataTypeTranslationInstanceFixture.ShouldBeAssignableTo<CustomDataTypeTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomDataTypeTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomDataTypeTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomDataTypeTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customDataTypeTranslationInstanceType.ShouldNotBeNull();
            _customDataTypeTranslationInstance.ShouldNotBeNull();
            _customDataTypeTranslationInstanceFixture.ShouldNotBeNull();
            _customDataTypeTranslationInstance.ShouldBeAssignableTo<CustomDataTypeTranslation>();
            _customDataTypeTranslationInstanceFixture.ShouldBeAssignableTo<CustomDataTypeTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomDataTypeTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(CustomDataTypeComponentTranslation[]) , Propertycomponents)]
        [TestCaseGeneric(typeof(string) , PropertycustomDataTypeName)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        public void AUT_CustomDataTypeTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomDataTypeTranslation, T>(_customDataTypeTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeTranslation) => Property (components) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeTranslation_components_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertycomponents);
            Action currentAction = () => propertyInfo.SetValue(_customDataTypeTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeTranslation) => Property (components) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeTranslation_Public_Class_components_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycomponents);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeTranslation) => Property (customDataTypeName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeTranslation_Public_Class_customDataTypeName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycustomDataTypeName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeTranslation) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeTranslation_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydescription);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomDataTypeTranslation) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomDataTypeTranslation_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}