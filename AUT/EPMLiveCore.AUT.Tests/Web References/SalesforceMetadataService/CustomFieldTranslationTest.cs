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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.CustomFieldTranslation" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class CustomFieldTranslationTest : AbstractBaseSetupTypedTest<CustomFieldTranslation>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (CustomFieldTranslation) Initializer

        private const string Propertyhelp = "help";
        private const string Propertylabel = "label";
        private const string Propertyname = "name";
        private const string PropertypicklistValues = "picklistValues";
        private const string PropertyrelationshipLabel = "relationshipLabel";
        private const string FieldhelpField = "helpField";
        private const string FieldlabelField = "labelField";
        private const string FieldnameField = "nameField";
        private const string FieldpicklistValuesField = "picklistValuesField";
        private const string FieldrelationshipLabelField = "relationshipLabelField";
        private Type _customFieldTranslationInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private CustomFieldTranslation _customFieldTranslationInstance;
        private CustomFieldTranslation _customFieldTranslationInstanceFixture;

        #region General Initializer : Class (CustomFieldTranslation) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="CustomFieldTranslation" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _customFieldTranslationInstanceType = typeof(CustomFieldTranslation);
            _customFieldTranslationInstanceFixture = Create(true);
            _customFieldTranslationInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (CustomFieldTranslation)

        #region General Initializer : Class (CustomFieldTranslation) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomFieldTranslation" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyhelp)]
        [TestCase(Propertylabel)]
        [TestCase(Propertyname)]
        [TestCase(PropertypicklistValues)]
        [TestCase(PropertyrelationshipLabel)]
        public void AUT_CustomFieldTranslation_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_customFieldTranslationInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (CustomFieldTranslation) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="CustomFieldTranslation" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldhelpField)]
        [TestCase(FieldlabelField)]
        [TestCase(FieldnameField)]
        [TestCase(FieldpicklistValuesField)]
        [TestCase(FieldrelationshipLabelField)]
        public void AUT_CustomFieldTranslation_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_customFieldTranslationInstanceFixture, 
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
        ///     Class (<see cref="CustomFieldTranslation" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_CustomFieldTranslation_Is_Instance_Present_Test()
        {
            // Assert
            _customFieldTranslationInstanceType.ShouldNotBeNull();
            _customFieldTranslationInstance.ShouldNotBeNull();
            _customFieldTranslationInstanceFixture.ShouldNotBeNull();
            _customFieldTranslationInstance.ShouldBeAssignableTo<CustomFieldTranslation>();
            _customFieldTranslationInstanceFixture.ShouldBeAssignableTo<CustomFieldTranslation>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (CustomFieldTranslation) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_CustomFieldTranslation_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            CustomFieldTranslation instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _customFieldTranslationInstanceType.ShouldNotBeNull();
            _customFieldTranslationInstance.ShouldNotBeNull();
            _customFieldTranslationInstanceFixture.ShouldNotBeNull();
            _customFieldTranslationInstance.ShouldBeAssignableTo<CustomFieldTranslation>();
            _customFieldTranslationInstanceFixture.ShouldBeAssignableTo<CustomFieldTranslation>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (CustomFieldTranslation) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyhelp)]
        [TestCaseGeneric(typeof(string) , Propertylabel)]
        [TestCaseGeneric(typeof(string) , Propertyname)]
        [TestCaseGeneric(typeof(PicklistValueTranslation[]) , PropertypicklistValues)]
        [TestCaseGeneric(typeof(string) , PropertyrelationshipLabel)]
        public void AUT_CustomFieldTranslation_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<CustomFieldTranslation, T>(_customFieldTranslationInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (CustomFieldTranslation) => Property (help) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomFieldTranslation_Public_Class_help_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyhelp);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomFieldTranslation) => Property (label) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomFieldTranslation_Public_Class_label_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomFieldTranslation) => Property (name) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomFieldTranslation_Public_Class_name_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (CustomFieldTranslation) => Property (picklistValues) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomFieldTranslation_picklistValues_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertypicklistValues);
            Action currentAction = () => propertyInfo.SetValue(_customFieldTranslationInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (CustomFieldTranslation) => Property (picklistValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomFieldTranslation_Public_Class_picklistValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypicklistValues);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (CustomFieldTranslation) => Property (relationshipLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_CustomFieldTranslation_Public_Class_relationshipLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyrelationshipLabel);

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