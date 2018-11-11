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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.PicklistValue" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class PicklistValueTest : AbstractBaseSetupTypedTest<PicklistValue>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (PicklistValue) Initializer

        private const string PropertyallowEmail = "allowEmail";
        private const string PropertyallowEmailSpecified = "allowEmailSpecified";
        private const string Propertyclosed = "closed";
        private const string PropertyclosedSpecified = "closedSpecified";
        private const string Propertycolor = "color";
        private const string PropertycontrollingFieldValues = "controllingFieldValues";
        private const string Propertyconverted = "converted";
        private const string PropertyconvertedSpecified = "convertedSpecified";
        private const string PropertycssExposed = "cssExposed";
        private const string PropertycssExposedSpecified = "cssExposedSpecified";
        private const string Propertydescription = "description";
        private const string PropertyforecastCategory = "forecastCategory";
        private const string PropertyforecastCategorySpecified = "forecastCategorySpecified";
        private const string PropertyhighPriority = "highPriority";
        private const string PropertyhighPrioritySpecified = "highPrioritySpecified";
        private const string Propertyprobability = "probability";
        private const string PropertyprobabilitySpecified = "probabilitySpecified";
        private const string PropertyreverseRole = "reverseRole";
        private const string Propertyreviewed = "reviewed";
        private const string PropertyreviewedSpecified = "reviewedSpecified";
        private const string Propertywon = "won";
        private const string PropertywonSpecified = "wonSpecified";
        private const string FieldallowEmailField = "allowEmailField";
        private const string FieldallowEmailFieldSpecified = "allowEmailFieldSpecified";
        private const string FieldclosedField = "closedField";
        private const string FieldclosedFieldSpecified = "closedFieldSpecified";
        private const string FieldcolorField = "colorField";
        private const string FieldcontrollingFieldValuesField = "controllingFieldValuesField";
        private const string FieldconvertedField = "convertedField";
        private const string FieldconvertedFieldSpecified = "convertedFieldSpecified";
        private const string FieldcssExposedField = "cssExposedField";
        private const string FieldcssExposedFieldSpecified = "cssExposedFieldSpecified";
        private const string FielddefaultField = "defaultField";
        private const string FielddescriptionField = "descriptionField";
        private const string FieldforecastCategoryField = "forecastCategoryField";
        private const string FieldforecastCategoryFieldSpecified = "forecastCategoryFieldSpecified";
        private const string FieldhighPriorityField = "highPriorityField";
        private const string FieldhighPriorityFieldSpecified = "highPriorityFieldSpecified";
        private const string FieldprobabilityField = "probabilityField";
        private const string FieldprobabilityFieldSpecified = "probabilityFieldSpecified";
        private const string FieldreverseRoleField = "reverseRoleField";
        private const string FieldreviewedField = "reviewedField";
        private const string FieldreviewedFieldSpecified = "reviewedFieldSpecified";
        private const string FieldwonField = "wonField";
        private const string FieldwonFieldSpecified = "wonFieldSpecified";
        private Type _picklistValueInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private PicklistValue _picklistValueInstance;
        private PicklistValue _picklistValueInstanceFixture;

        #region General Initializer : Class (PicklistValue) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="PicklistValue" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _picklistValueInstanceType = typeof(PicklistValue);
            _picklistValueInstanceFixture = Create(true);
            _picklistValueInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (PicklistValue)

        #region General Initializer : Class (PicklistValue) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="PicklistValue" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyallowEmail)]
        [TestCase(PropertyallowEmailSpecified)]
        [TestCase(Propertyclosed)]
        [TestCase(PropertyclosedSpecified)]
        [TestCase(Propertycolor)]
        [TestCase(PropertycontrollingFieldValues)]
        [TestCase(Propertyconverted)]
        [TestCase(PropertyconvertedSpecified)]
        [TestCase(PropertycssExposed)]
        [TestCase(PropertycssExposedSpecified)]
        [TestCase(Propertydescription)]
        [TestCase(PropertyforecastCategory)]
        [TestCase(PropertyforecastCategorySpecified)]
        [TestCase(PropertyhighPriority)]
        [TestCase(PropertyhighPrioritySpecified)]
        [TestCase(Propertyprobability)]
        [TestCase(PropertyprobabilitySpecified)]
        [TestCase(PropertyreverseRole)]
        [TestCase(Propertyreviewed)]
        [TestCase(PropertyreviewedSpecified)]
        [TestCase(Propertywon)]
        [TestCase(PropertywonSpecified)]
        public void AUT_PicklistValue_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_picklistValueInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (PicklistValue) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="PicklistValue" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldallowEmailField)]
        [TestCase(FieldallowEmailFieldSpecified)]
        [TestCase(FieldclosedField)]
        [TestCase(FieldclosedFieldSpecified)]
        [TestCase(FieldcolorField)]
        [TestCase(FieldcontrollingFieldValuesField)]
        [TestCase(FieldconvertedField)]
        [TestCase(FieldconvertedFieldSpecified)]
        [TestCase(FieldcssExposedField)]
        [TestCase(FieldcssExposedFieldSpecified)]
        [TestCase(FielddefaultField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FieldforecastCategoryField)]
        [TestCase(FieldforecastCategoryFieldSpecified)]
        [TestCase(FieldhighPriorityField)]
        [TestCase(FieldhighPriorityFieldSpecified)]
        [TestCase(FieldprobabilityField)]
        [TestCase(FieldprobabilityFieldSpecified)]
        [TestCase(FieldreverseRoleField)]
        [TestCase(FieldreviewedField)]
        [TestCase(FieldreviewedFieldSpecified)]
        [TestCase(FieldwonField)]
        [TestCase(FieldwonFieldSpecified)]
        public void AUT_PicklistValue_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_picklistValueInstanceFixture, 
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
        ///     Class (<see cref="PicklistValue" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_PicklistValue_Is_Instance_Present_Test()
        {
            // Assert
            _picklistValueInstanceType.ShouldNotBeNull();
            _picklistValueInstance.ShouldNotBeNull();
            _picklistValueInstanceFixture.ShouldNotBeNull();
            _picklistValueInstance.ShouldBeAssignableTo<PicklistValue>();
            _picklistValueInstanceFixture.ShouldBeAssignableTo<PicklistValue>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (PicklistValue) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_PicklistValue_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            PicklistValue instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _picklistValueInstanceType.ShouldNotBeNull();
            _picklistValueInstance.ShouldNotBeNull();
            _picklistValueInstanceFixture.ShouldNotBeNull();
            _picklistValueInstance.ShouldBeAssignableTo<PicklistValue>();
            _picklistValueInstanceFixture.ShouldBeAssignableTo<PicklistValue>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (PicklistValue) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyallowEmail)]
        [TestCaseGeneric(typeof(bool) , PropertyallowEmailSpecified)]
        [TestCaseGeneric(typeof(bool) , Propertyclosed)]
        [TestCaseGeneric(typeof(bool) , PropertyclosedSpecified)]
        [TestCaseGeneric(typeof(string) , Propertycolor)]
        [TestCaseGeneric(typeof(string[]) , PropertycontrollingFieldValues)]
        [TestCaseGeneric(typeof(bool) , Propertyconverted)]
        [TestCaseGeneric(typeof(bool) , PropertyconvertedSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertycssExposed)]
        [TestCaseGeneric(typeof(bool) , PropertycssExposedSpecified)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(ForecastCategories) , PropertyforecastCategory)]
        [TestCaseGeneric(typeof(bool) , PropertyforecastCategorySpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyhighPriority)]
        [TestCaseGeneric(typeof(bool) , PropertyhighPrioritySpecified)]
        [TestCaseGeneric(typeof(int) , Propertyprobability)]
        [TestCaseGeneric(typeof(bool) , PropertyprobabilitySpecified)]
        [TestCaseGeneric(typeof(string) , PropertyreverseRole)]
        [TestCaseGeneric(typeof(bool) , Propertyreviewed)]
        [TestCaseGeneric(typeof(bool) , PropertyreviewedSpecified)]
        [TestCaseGeneric(typeof(bool) , Propertywon)]
        [TestCaseGeneric(typeof(bool) , PropertywonSpecified)]
        public void AUT_PicklistValue_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<PicklistValue, T>(_picklistValueInstance, propertyName, Fixture);
        }

        #endregion
        
        #region General Getters/Setters : Class (PicklistValue) => Property (allowEmail) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_allowEmail_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowEmail);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (allowEmailSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_allowEmailSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyallowEmailSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (closed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_closed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyclosed);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (closedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_closedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyclosedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (color) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_color_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycolor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (controllingFieldValues) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_controllingFieldValues_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycontrollingFieldValues);
            Action currentAction = () => propertyInfo.SetValue(_picklistValueInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (controllingFieldValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_controllingFieldValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycontrollingFieldValues);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (converted) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_converted_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyconverted);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (convertedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_convertedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyconvertedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (cssExposed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_cssExposed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycssExposed);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (cssExposedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_cssExposedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycssExposedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (PicklistValue) => Property (forecastCategory) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_forecastCategory_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyforecastCategory);
            Action currentAction = () => propertyInfo.SetValue(_picklistValueInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (forecastCategory) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_forecastCategory_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyforecastCategory);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (forecastCategorySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_forecastCategorySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyforecastCategorySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (highPriority) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_highPriority_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhighPriority);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (highPrioritySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_highPrioritySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhighPrioritySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (probability) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_probability_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyprobability);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (probabilitySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_probabilitySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyprobabilitySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (reverseRole) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_reverseRole_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreverseRole);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (reviewed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_reviewed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyreviewed);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (reviewedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_reviewedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreviewedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (won) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_won_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertywon);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (PicklistValue) => Property (wonSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_PicklistValue_Public_Class_wonSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertywonSpecified);

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