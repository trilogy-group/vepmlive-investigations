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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ValidationRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ValidationRuleTest : AbstractBaseSetupTypedTest<ValidationRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ValidationRule) Initializer

        private const string Propertyactive = "active";
        private const string Propertydescription = "description";
        private const string PropertyerrorConditionFormula = "errorConditionFormula";
        private const string PropertyerrorDisplayField = "errorDisplayField";
        private const string PropertyerrorMessage = "errorMessage";
        private const string FieldactiveField = "activeField";
        private const string FielddescriptionField = "descriptionField";
        private const string FielderrorConditionFormulaField = "errorConditionFormulaField";
        private const string FielderrorDisplayFieldField = "errorDisplayFieldField";
        private const string FielderrorMessageField = "errorMessageField";
        private Type _validationRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ValidationRule _validationRuleInstance;
        private ValidationRule _validationRuleInstanceFixture;

        #region General Initializer : Class (ValidationRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ValidationRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _validationRuleInstanceType = typeof(ValidationRule);
            _validationRuleInstanceFixture = Create(true);
            _validationRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ValidationRule)

        #region General Initializer : Class (ValidationRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ValidationRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyactive)]
        [TestCase(Propertydescription)]
        [TestCase(PropertyerrorConditionFormula)]
        [TestCase(PropertyerrorDisplayField)]
        [TestCase(PropertyerrorMessage)]
        public void AUT_ValidationRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_validationRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ValidationRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ValidationRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldactiveField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FielderrorConditionFormulaField)]
        [TestCase(FielderrorDisplayFieldField)]
        [TestCase(FielderrorMessageField)]
        public void AUT_ValidationRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_validationRuleInstanceFixture, 
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
        ///     Class (<see cref="ValidationRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ValidationRule_Is_Instance_Present_Test()
        {
            // Assert
            _validationRuleInstanceType.ShouldNotBeNull();
            _validationRuleInstance.ShouldNotBeNull();
            _validationRuleInstanceFixture.ShouldNotBeNull();
            _validationRuleInstance.ShouldBeAssignableTo<ValidationRule>();
            _validationRuleInstanceFixture.ShouldBeAssignableTo<ValidationRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ValidationRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ValidationRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ValidationRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _validationRuleInstanceType.ShouldNotBeNull();
            _validationRuleInstance.ShouldNotBeNull();
            _validationRuleInstanceFixture.ShouldNotBeNull();
            _validationRuleInstance.ShouldBeAssignableTo<ValidationRule>();
            _validationRuleInstanceFixture.ShouldBeAssignableTo<ValidationRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ValidationRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , Propertyactive)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , PropertyerrorConditionFormula)]
        [TestCaseGeneric(typeof(string) , PropertyerrorDisplayField)]
        [TestCaseGeneric(typeof(string) , PropertyerrorMessage)]
        public void AUT_ValidationRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ValidationRule, T>(_validationRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ValidationRule) => Property (active) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ValidationRule_Public_Class_active_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyactive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ValidationRule) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ValidationRule_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ValidationRule) => Property (errorConditionFormula) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ValidationRule_Public_Class_errorConditionFormula_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyerrorConditionFormula);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ValidationRule) => Property (errorDisplayField) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ValidationRule_Public_Class_errorDisplayField_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyerrorDisplayField);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ValidationRule) => Property (errorMessage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ValidationRule_Public_Class_errorMessage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #endregion

        #endregion
    }
}