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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ChartSummary" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ChartSummaryTest : AbstractBaseSetupTypedTest<ChartSummary>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ChartSummary) Initializer

        private const string Propertyaggregate = "aggregate";
        private const string PropertyaggregateSpecified = "aggregateSpecified";
        private const string PropertyaxisBinding = "axisBinding";
        private const string PropertyaxisBindingSpecified = "axisBindingSpecified";
        private const string Propertycolumn = "column";
        private const string FieldaggregateField = "aggregateField";
        private const string FieldaggregateFieldSpecified = "aggregateFieldSpecified";
        private const string FieldaxisBindingField = "axisBindingField";
        private const string FieldaxisBindingFieldSpecified = "axisBindingFieldSpecified";
        private const string FieldcolumnField = "columnField";
        private Type _chartSummaryInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ChartSummary _chartSummaryInstance;
        private ChartSummary _chartSummaryInstanceFixture;

        #region General Initializer : Class (ChartSummary) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ChartSummary" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _chartSummaryInstanceType = typeof(ChartSummary);
            _chartSummaryInstanceFixture = Create(true);
            _chartSummaryInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ChartSummary)

        #region General Initializer : Class (ChartSummary) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ChartSummary" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyaggregate)]
        [TestCase(PropertyaggregateSpecified)]
        [TestCase(PropertyaxisBinding)]
        [TestCase(PropertyaxisBindingSpecified)]
        [TestCase(Propertycolumn)]
        public void AUT_ChartSummary_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_chartSummaryInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ChartSummary) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ChartSummary" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaggregateField)]
        [TestCase(FieldaggregateFieldSpecified)]
        [TestCase(FieldaxisBindingField)]
        [TestCase(FieldaxisBindingFieldSpecified)]
        [TestCase(FieldcolumnField)]
        public void AUT_ChartSummary_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_chartSummaryInstanceFixture, 
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
        ///     Class (<see cref="ChartSummary" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ChartSummary_Is_Instance_Present_Test()
        {
            // Assert
            _chartSummaryInstanceType.ShouldNotBeNull();
            _chartSummaryInstance.ShouldNotBeNull();
            _chartSummaryInstanceFixture.ShouldNotBeNull();
            _chartSummaryInstance.ShouldBeAssignableTo<ChartSummary>();
            _chartSummaryInstanceFixture.ShouldBeAssignableTo<ChartSummary>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ChartSummary) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ChartSummary_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ChartSummary instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _chartSummaryInstanceType.ShouldNotBeNull();
            _chartSummaryInstance.ShouldNotBeNull();
            _chartSummaryInstanceFixture.ShouldNotBeNull();
            _chartSummaryInstance.ShouldBeAssignableTo<ChartSummary>();
            _chartSummaryInstanceFixture.ShouldBeAssignableTo<ChartSummary>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ChartSummary) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ReportSummaryType) , Propertyaggregate)]
        [TestCaseGeneric(typeof(bool) , PropertyaggregateSpecified)]
        [TestCaseGeneric(typeof(ChartAxis) , PropertyaxisBinding)]
        [TestCaseGeneric(typeof(bool) , PropertyaxisBindingSpecified)]
        [TestCaseGeneric(typeof(string) , Propertycolumn)]
        public void AUT_ChartSummary_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ChartSummary, T>(_chartSummaryInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ChartSummary) => Property (aggregate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartSummary_aggregate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyaggregate);
            Action currentAction = () => propertyInfo.SetValue(_chartSummaryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChartSummary) => Property (aggregate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartSummary_Public_Class_aggregate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyaggregate);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartSummary) => Property (aggregateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartSummary_Public_Class_aggregateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaggregateSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartSummary) => Property (axisBinding) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartSummary_axisBinding_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertyaxisBinding);
            Action currentAction = () => propertyInfo.SetValue(_chartSummaryInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ChartSummary) => Property (axisBinding) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartSummary_Public_Class_axisBinding_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaxisBinding);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartSummary) => Property (axisBindingSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartSummary_Public_Class_axisBindingSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyaxisBindingSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ChartSummary) => Property (column) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ChartSummary_Public_Class_column_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertycolumn);

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