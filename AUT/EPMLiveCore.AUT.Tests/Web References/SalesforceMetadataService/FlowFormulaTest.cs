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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.FlowFormula" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class FlowFormulaTest : AbstractBaseSetupTypedTest<FlowFormula>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (FlowFormula) Initializer

        private const string Propertyexpression = "expression";
        private const string Propertyscale = "scale";
        private const string PropertyscaleSpecified = "scaleSpecified";
        private const string FieldexpressionField = "expressionField";
        private const string FieldscaleField = "scaleField";
        private const string FieldscaleFieldSpecified = "scaleFieldSpecified";
        private Type _flowFormulaInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private FlowFormula _flowFormulaInstance;
        private FlowFormula _flowFormulaInstanceFixture;

        #region General Initializer : Class (FlowFormula) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="FlowFormula" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _flowFormulaInstanceType = typeof(FlowFormula);
            _flowFormulaInstanceFixture = Create(true);
            _flowFormulaInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (FlowFormula)

        #region General Initializer : Class (FlowFormula) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowFormula" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyexpression)]
        [TestCase(Propertyscale)]
        [TestCase(PropertyscaleSpecified)]
        public void AUT_FlowFormula_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_flowFormulaInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (FlowFormula) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="FlowFormula" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldexpressionField)]
        [TestCase(FieldscaleField)]
        [TestCase(FieldscaleFieldSpecified)]
        public void AUT_FlowFormula_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_flowFormulaInstanceFixture, 
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
        ///     Class (<see cref="FlowFormula" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_FlowFormula_Is_Instance_Present_Test()
        {
            // Assert
            _flowFormulaInstanceType.ShouldNotBeNull();
            _flowFormulaInstance.ShouldNotBeNull();
            _flowFormulaInstanceFixture.ShouldNotBeNull();
            _flowFormulaInstance.ShouldBeAssignableTo<FlowFormula>();
            _flowFormulaInstanceFixture.ShouldBeAssignableTo<FlowFormula>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (FlowFormula) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_FlowFormula_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            FlowFormula instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _flowFormulaInstanceType.ShouldNotBeNull();
            _flowFormulaInstance.ShouldNotBeNull();
            _flowFormulaInstanceFixture.ShouldNotBeNull();
            _flowFormulaInstance.ShouldBeAssignableTo<FlowFormula>();
            _flowFormulaInstanceFixture.ShouldBeAssignableTo<FlowFormula>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (FlowFormula) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , Propertyexpression)]
        [TestCaseGeneric(typeof(int) , Propertyscale)]
        [TestCaseGeneric(typeof(bool) , PropertyscaleSpecified)]
        public void AUT_FlowFormula_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<FlowFormula, T>(_flowFormulaInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (FlowFormula) => Property (expression) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowFormula_Public_Class_expression_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyexpression);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowFormula) => Property (scale) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowFormula_Public_Class_scale_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyscale);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (FlowFormula) => Property (scaleSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_FlowFormula_Public_Class_scaleSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyscaleSpecified);

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