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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportAggregate" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportAggregateTest : AbstractBaseSetupTypedTest<ReportAggregate>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportAggregate) Initializer

        private const string PropertyacrossGroupingContext = "acrossGroupingContext";
        private const string PropertycalculatedFormula = "calculatedFormula";
        private const string Propertydatatype = "datatype";
        private const string Propertydescription = "description";
        private const string PropertydeveloperName = "developerName";
        private const string PropertydownGroupingContext = "downGroupingContext";
        private const string PropertyisActive = "isActive";
        private const string PropertyisCrossBlock = "isCrossBlock";
        private const string PropertyisCrossBlockSpecified = "isCrossBlockSpecified";
        private const string PropertymasterLabel = "masterLabel";
        private const string PropertyreportType = "reportType";
        private const string Propertyscale = "scale";
        private const string PropertyscaleSpecified = "scaleSpecified";
        private const string FieldacrossGroupingContextField = "acrossGroupingContextField";
        private const string FieldcalculatedFormulaField = "calculatedFormulaField";
        private const string FielddatatypeField = "datatypeField";
        private const string FielddescriptionField = "descriptionField";
        private const string FielddeveloperNameField = "developerNameField";
        private const string FielddownGroupingContextField = "downGroupingContextField";
        private const string FieldisActiveField = "isActiveField";
        private const string FieldisCrossBlockField = "isCrossBlockField";
        private const string FieldisCrossBlockFieldSpecified = "isCrossBlockFieldSpecified";
        private const string FieldmasterLabelField = "masterLabelField";
        private const string FieldreportTypeField = "reportTypeField";
        private const string FieldscaleField = "scaleField";
        private const string FieldscaleFieldSpecified = "scaleFieldSpecified";
        private Type _reportAggregateInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportAggregate _reportAggregateInstance;
        private ReportAggregate _reportAggregateInstanceFixture;

        #region General Initializer : Class (ReportAggregate) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportAggregate" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportAggregateInstanceType = typeof(ReportAggregate);
            _reportAggregateInstanceFixture = Create(true);
            _reportAggregateInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportAggregate)

        #region General Initializer : Class (ReportAggregate) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportAggregate" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyacrossGroupingContext)]
        [TestCase(PropertycalculatedFormula)]
        [TestCase(Propertydatatype)]
        [TestCase(Propertydescription)]
        [TestCase(PropertydeveloperName)]
        [TestCase(PropertydownGroupingContext)]
        [TestCase(PropertyisActive)]
        [TestCase(PropertyisCrossBlock)]
        [TestCase(PropertyisCrossBlockSpecified)]
        [TestCase(PropertymasterLabel)]
        [TestCase(PropertyreportType)]
        [TestCase(Propertyscale)]
        [TestCase(PropertyscaleSpecified)]
        public void AUT_ReportAggregate_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportAggregateInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportAggregate) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportAggregate" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldacrossGroupingContextField)]
        [TestCase(FieldcalculatedFormulaField)]
        [TestCase(FielddatatypeField)]
        [TestCase(FielddescriptionField)]
        [TestCase(FielddeveloperNameField)]
        [TestCase(FielddownGroupingContextField)]
        [TestCase(FieldisActiveField)]
        [TestCase(FieldisCrossBlockField)]
        [TestCase(FieldisCrossBlockFieldSpecified)]
        [TestCase(FieldmasterLabelField)]
        [TestCase(FieldreportTypeField)]
        [TestCase(FieldscaleField)]
        [TestCase(FieldscaleFieldSpecified)]
        public void AUT_ReportAggregate_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportAggregateInstanceFixture, 
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
        ///     Class (<see cref="ReportAggregate" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportAggregate_Is_Instance_Present_Test()
        {
            // Assert
            _reportAggregateInstanceType.ShouldNotBeNull();
            _reportAggregateInstance.ShouldNotBeNull();
            _reportAggregateInstanceFixture.ShouldNotBeNull();
            _reportAggregateInstance.ShouldBeAssignableTo<ReportAggregate>();
            _reportAggregateInstanceFixture.ShouldBeAssignableTo<ReportAggregate>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportAggregate) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportAggregate_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportAggregate instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportAggregateInstanceType.ShouldNotBeNull();
            _reportAggregateInstance.ShouldNotBeNull();
            _reportAggregateInstanceFixture.ShouldNotBeNull();
            _reportAggregateInstance.ShouldBeAssignableTo<ReportAggregate>();
            _reportAggregateInstanceFixture.ShouldBeAssignableTo<ReportAggregate>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportAggregate) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertyacrossGroupingContext)]
        [TestCaseGeneric(typeof(string) , PropertycalculatedFormula)]
        [TestCaseGeneric(typeof(ReportAggregateDatatype) , Propertydatatype)]
        [TestCaseGeneric(typeof(string) , Propertydescription)]
        [TestCaseGeneric(typeof(string) , PropertydeveloperName)]
        [TestCaseGeneric(typeof(string) , PropertydownGroupingContext)]
        [TestCaseGeneric(typeof(bool) , PropertyisActive)]
        [TestCaseGeneric(typeof(bool) , PropertyisCrossBlock)]
        [TestCaseGeneric(typeof(bool) , PropertyisCrossBlockSpecified)]
        [TestCaseGeneric(typeof(string) , PropertymasterLabel)]
        [TestCaseGeneric(typeof(string) , PropertyreportType)]
        [TestCaseGeneric(typeof(int) , Propertyscale)]
        [TestCaseGeneric(typeof(bool) , PropertyscaleSpecified)]
        public void AUT_ReportAggregate_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportAggregate, T>(_reportAggregateInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportAggregate) => Property (acrossGroupingContext) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_Public_Class_acrossGroupingContext_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyacrossGroupingContext);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportAggregate) => Property (calculatedFormula) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_Public_Class_calculatedFormula_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycalculatedFormula);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportAggregate) => Property (datatype) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_datatype_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertydatatype);
            Action currentAction = () => propertyInfo.SetValue(_reportAggregateInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportAggregate) => Property (datatype) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_Public_Class_datatype_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertydatatype);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportAggregate) => Property (description) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_Public_Class_description_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportAggregate) => Property (developerName) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_Public_Class_developerName_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydeveloperName);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportAggregate) => Property (downGroupingContext) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_Public_Class_downGroupingContext_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydownGroupingContext);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportAggregate) => Property (isActive) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_Public_Class_isActive_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisActive);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportAggregate) => Property (isCrossBlock) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_Public_Class_isCrossBlock_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisCrossBlock);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportAggregate) => Property (isCrossBlockSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_Public_Class_isCrossBlockSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyisCrossBlockSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportAggregate) => Property (masterLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_Public_Class_masterLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportAggregate) => Property (reportType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_Public_Class_reportType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyreportType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportAggregate) => Property (scale) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_Public_Class_scale_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (ReportAggregate) => Property (scaleSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportAggregate_Public_Class_scaleSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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