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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportColorRange" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportColorRangeTest : AbstractBaseSetupTypedTest<ReportColorRange>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportColorRange) Initializer

        private const string Propertyaggregate = "aggregate";
        private const string PropertyaggregateSpecified = "aggregateSpecified";
        private const string PropertycolumnName = "columnName";
        private const string PropertyhighBreakpoint = "highBreakpoint";
        private const string PropertyhighBreakpointSpecified = "highBreakpointSpecified";
        private const string PropertyhighColor = "highColor";
        private const string PropertylowBreakpoint = "lowBreakpoint";
        private const string PropertylowBreakpointSpecified = "lowBreakpointSpecified";
        private const string PropertylowColor = "lowColor";
        private const string PropertymidColor = "midColor";
        private const string FieldaggregateField = "aggregateField";
        private const string FieldaggregateFieldSpecified = "aggregateFieldSpecified";
        private const string FieldcolumnNameField = "columnNameField";
        private const string FieldhighBreakpointField = "highBreakpointField";
        private const string FieldhighBreakpointFieldSpecified = "highBreakpointFieldSpecified";
        private const string FieldhighColorField = "highColorField";
        private const string FieldlowBreakpointField = "lowBreakpointField";
        private const string FieldlowBreakpointFieldSpecified = "lowBreakpointFieldSpecified";
        private const string FieldlowColorField = "lowColorField";
        private const string FieldmidColorField = "midColorField";
        private Type _reportColorRangeInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportColorRange _reportColorRangeInstance;
        private ReportColorRange _reportColorRangeInstanceFixture;

        #region General Initializer : Class (ReportColorRange) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportColorRange" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportColorRangeInstanceType = typeof(ReportColorRange);
            _reportColorRangeInstanceFixture = Create(true);
            _reportColorRangeInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportColorRange)

        #region General Initializer : Class (ReportColorRange) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportColorRange" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(Propertyaggregate)]
        [TestCase(PropertyaggregateSpecified)]
        [TestCase(PropertycolumnName)]
        [TestCase(PropertyhighBreakpoint)]
        [TestCase(PropertyhighBreakpointSpecified)]
        [TestCase(PropertyhighColor)]
        [TestCase(PropertylowBreakpoint)]
        [TestCase(PropertylowBreakpointSpecified)]
        [TestCase(PropertylowColor)]
        [TestCase(PropertymidColor)]
        public void AUT_ReportColorRange_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportColorRangeInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportColorRange) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportColorRange" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldaggregateField)]
        [TestCase(FieldaggregateFieldSpecified)]
        [TestCase(FieldcolumnNameField)]
        [TestCase(FieldhighBreakpointField)]
        [TestCase(FieldhighBreakpointFieldSpecified)]
        [TestCase(FieldhighColorField)]
        [TestCase(FieldlowBreakpointField)]
        [TestCase(FieldlowBreakpointFieldSpecified)]
        [TestCase(FieldlowColorField)]
        [TestCase(FieldmidColorField)]
        public void AUT_ReportColorRange_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportColorRangeInstanceFixture, 
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
        ///     Class (<see cref="ReportColorRange" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportColorRange_Is_Instance_Present_Test()
        {
            // Assert
            _reportColorRangeInstanceType.ShouldNotBeNull();
            _reportColorRangeInstance.ShouldNotBeNull();
            _reportColorRangeInstanceFixture.ShouldNotBeNull();
            _reportColorRangeInstance.ShouldBeAssignableTo<ReportColorRange>();
            _reportColorRangeInstanceFixture.ShouldBeAssignableTo<ReportColorRange>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportColorRange) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportColorRange_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportColorRange instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportColorRangeInstanceType.ShouldNotBeNull();
            _reportColorRangeInstance.ShouldNotBeNull();
            _reportColorRangeInstanceFixture.ShouldNotBeNull();
            _reportColorRangeInstance.ShouldBeAssignableTo<ReportColorRange>();
            _reportColorRangeInstanceFixture.ShouldBeAssignableTo<ReportColorRange>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportColorRange) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(ReportSummaryType) , Propertyaggregate)]
        [TestCaseGeneric(typeof(bool) , PropertyaggregateSpecified)]
        [TestCaseGeneric(typeof(string) , PropertycolumnName)]
        [TestCaseGeneric(typeof(double) , PropertyhighBreakpoint)]
        [TestCaseGeneric(typeof(bool) , PropertyhighBreakpointSpecified)]
        [TestCaseGeneric(typeof(string) , PropertyhighColor)]
        [TestCaseGeneric(typeof(double) , PropertylowBreakpoint)]
        [TestCaseGeneric(typeof(bool) , PropertylowBreakpointSpecified)]
        [TestCaseGeneric(typeof(string) , PropertylowColor)]
        [TestCaseGeneric(typeof(string) , PropertymidColor)]
        public void AUT_ReportColorRange_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportColorRange, T>(_reportColorRangeInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportColorRange) => Property (aggregate) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColorRange_aggregate_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertyaggregate);
            Action currentAction = () => propertyInfo.SetValue(_reportColorRangeInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportColorRange) => Property (aggregate) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColorRange_Public_Class_aggregate_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportColorRange) => Property (aggregateSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColorRange_Public_Class_aggregateSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportColorRange) => Property (columnName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColorRange_Public_Class_columnName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycolumnName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportColorRange) => Property (highBreakpoint) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColorRange_Public_Class_highBreakpoint_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhighBreakpoint);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportColorRange) => Property (highBreakpointSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColorRange_Public_Class_highBreakpointSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhighBreakpointSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportColorRange) => Property (highColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColorRange_Public_Class_highColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyhighColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportColorRange) => Property (lowBreakpoint) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColorRange_Public_Class_lowBreakpoint_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylowBreakpoint);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportColorRange) => Property (lowBreakpointSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColorRange_Public_Class_lowBreakpointSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylowBreakpointSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportColorRange) => Property (lowColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColorRange_Public_Class_lowColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylowColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportColorRange) => Property (midColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportColorRange_Public_Class_midColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymidColor);

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