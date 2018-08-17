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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowInputValidationRule" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowInputValidationRuleTest : AbstractBaseSetupTypedTest<FlowInputValidationRule>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowInputValidationRule) Initializer

        private const string PropertyerrorMessage = "errorMessage";
        private const string PropertyformulaExpression = "formulaExpression";
        private const string FielderrorMessageField = "errorMessageField";
        private const string FieldformulaExpressionField = "formulaExpressionField";
        private Type _flowInputValidationRuleInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowInputValidationRule _flowInputValidationRuleInstance;
        private FlowInputValidationRule _flowInputValidationRuleInstanceFixture;

        #region General Initializer : Class (FlowInputValidationRule) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowInputValidationRule" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowInputValidationRuleInstanceType = typeof(FlowInputValidationRule);
            _flowInputValidationRuleInstanceFixture = Create(true);
            _flowInputValidationRuleInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowInputValidationRule)

        #region General Initializer : Class (FlowInputValidationRule) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowInputValidationRule" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyerrorMessage)]
        [TestCase(PropertyformulaExpression)]
        public void AUT_FlowInputValidationRule_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowInputValidationRuleInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowInputValidationRule) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowInputValidationRule" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FielderrorMessageField)]
        [TestCase(FieldformulaExpressionField)]
        public void AUT_FlowInputValidationRule_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowInputValidationRuleInstanceFixture, 
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
        ///     Class (<see cref="FlowInputValidationRule" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowInputValidationRule_Is_Instance_Present_Test()
        {
            // Assert
            _flowInputValidationRuleInstanceType.ShouldNotBeNull();
            _flowInputValidationRuleInstance.ShouldNotBeNull();
            _flowInputValidationRuleInstanceFixture.ShouldNotBeNull();
            _flowInputValidationRuleInstance.ShouldBeAssignableTo<FlowInputValidationRule>();
            _flowInputValidationRuleInstanceFixture.ShouldBeAssignableTo<FlowInputValidationRule>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowInputValidationRule) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowInputValidationRule_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowInputValidationRule instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowInputValidationRuleInstanceType.ShouldNotBeNull();
            _flowInputValidationRuleInstance.ShouldNotBeNull();
            _flowInputValidationRuleInstanceFixture.ShouldNotBeNull();
            _flowInputValidationRuleInstance.ShouldBeAssignableTo<FlowInputValidationRule>();
            _flowInputValidationRuleInstanceFixture.ShouldBeAssignableTo<FlowInputValidationRule>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowInputValidationRule) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyerrorMessage)]
        [TestCaseGeneric(typeof(string) , PropertyformulaExpression)]
        public void AUT_FlowInputValidationRule_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowInputValidationRule, T>(_flowInputValidationRuleInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowInputValidationRule) => Property (errorMessage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowInputValidationRule_Public_Class_errorMessage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (FlowInputValidationRule) => Property (formulaExpression) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowInputValidationRule_Public_Class_formulaExpression_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyformulaExpression);

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