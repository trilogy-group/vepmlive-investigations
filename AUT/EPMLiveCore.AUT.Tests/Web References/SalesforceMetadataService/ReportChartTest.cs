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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.ReportChart" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class ReportChartTest : AbstractBaseSetupTypedTest<ReportChart>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (ReportChart) Initializer

        private const string PropertybackgroundColor1 = "backgroundColor1";
        private const string PropertybackgroundColor2 = "backgroundColor2";
        private const string PropertybackgroundFadeDir = "backgroundFadeDir";
        private const string PropertybackgroundFadeDirSpecified = "backgroundFadeDirSpecified";
        private const string PropertychartSummaries = "chartSummaries";
        private const string PropertychartType = "chartType";
        private const string PropertyenableHoverLabels = "enableHoverLabels";
        private const string PropertyenableHoverLabelsSpecified = "enableHoverLabelsSpecified";
        private const string PropertyexpandOthers = "expandOthers";
        private const string PropertyexpandOthersSpecified = "expandOthersSpecified";
        private const string PropertygroupingColumn = "groupingColumn";
        private const string PropertylegendPosition = "legendPosition";
        private const string PropertylegendPositionSpecified = "legendPositionSpecified";
        private const string Propertylocation = "location";
        private const string PropertylocationSpecified = "locationSpecified";
        private const string PropertysecondaryGroupingColumn = "secondaryGroupingColumn";
        private const string PropertyshowAxisLabels = "showAxisLabels";
        private const string PropertyshowAxisLabelsSpecified = "showAxisLabelsSpecified";
        private const string PropertyshowPercentage = "showPercentage";
        private const string PropertyshowPercentageSpecified = "showPercentageSpecified";
        private const string PropertyshowTotal = "showTotal";
        private const string PropertyshowTotalSpecified = "showTotalSpecified";
        private const string PropertyshowValues = "showValues";
        private const string PropertyshowValuesSpecified = "showValuesSpecified";
        private const string Propertysize = "size";
        private const string PropertysizeSpecified = "sizeSpecified";
        private const string PropertysummaryAxisManualRangeEnd = "summaryAxisManualRangeEnd";
        private const string PropertysummaryAxisManualRangeEndSpecified = "summaryAxisManualRangeEndSpecified";
        private const string PropertysummaryAxisManualRangeStart = "summaryAxisManualRangeStart";
        private const string PropertysummaryAxisManualRangeStartSpecified = "summaryAxisManualRangeStartSpecified";
        private const string PropertysummaryAxisRange = "summaryAxisRange";
        private const string PropertysummaryAxisRangeSpecified = "summaryAxisRangeSpecified";
        private const string PropertytextColor = "textColor";
        private const string PropertytextSize = "textSize";
        private const string PropertytextSizeSpecified = "textSizeSpecified";
        private const string Propertytitle = "title";
        private const string PropertytitleColor = "titleColor";
        private const string PropertytitleSize = "titleSize";
        private const string PropertytitleSizeSpecified = "titleSizeSpecified";
        private const string FieldbackgroundColor1Field = "backgroundColor1Field";
        private const string FieldbackgroundColor2Field = "backgroundColor2Field";
        private const string FieldbackgroundFadeDirField = "backgroundFadeDirField";
        private const string FieldbackgroundFadeDirFieldSpecified = "backgroundFadeDirFieldSpecified";
        private const string FieldchartSummariesField = "chartSummariesField";
        private const string FieldchartTypeField = "chartTypeField";
        private const string FieldenableHoverLabelsField = "enableHoverLabelsField";
        private const string FieldenableHoverLabelsFieldSpecified = "enableHoverLabelsFieldSpecified";
        private const string FieldexpandOthersField = "expandOthersField";
        private const string FieldexpandOthersFieldSpecified = "expandOthersFieldSpecified";
        private const string FieldgroupingColumnField = "groupingColumnField";
        private const string FieldlegendPositionField = "legendPositionField";
        private const string FieldlegendPositionFieldSpecified = "legendPositionFieldSpecified";
        private const string FieldlocationField = "locationField";
        private const string FieldlocationFieldSpecified = "locationFieldSpecified";
        private const string FieldsecondaryGroupingColumnField = "secondaryGroupingColumnField";
        private const string FieldshowAxisLabelsField = "showAxisLabelsField";
        private const string FieldshowAxisLabelsFieldSpecified = "showAxisLabelsFieldSpecified";
        private const string FieldshowPercentageField = "showPercentageField";
        private const string FieldshowPercentageFieldSpecified = "showPercentageFieldSpecified";
        private const string FieldshowTotalField = "showTotalField";
        private const string FieldshowTotalFieldSpecified = "showTotalFieldSpecified";
        private const string FieldshowValuesField = "showValuesField";
        private const string FieldshowValuesFieldSpecified = "showValuesFieldSpecified";
        private const string FieldsizeField = "sizeField";
        private const string FieldsizeFieldSpecified = "sizeFieldSpecified";
        private const string FieldsummaryAxisManualRangeEndField = "summaryAxisManualRangeEndField";
        private const string FieldsummaryAxisManualRangeEndFieldSpecified = "summaryAxisManualRangeEndFieldSpecified";
        private const string FieldsummaryAxisManualRangeStartField = "summaryAxisManualRangeStartField";
        private const string FieldsummaryAxisManualRangeStartFieldSpecified = "summaryAxisManualRangeStartFieldSpecified";
        private const string FieldsummaryAxisRangeField = "summaryAxisRangeField";
        private const string FieldsummaryAxisRangeFieldSpecified = "summaryAxisRangeFieldSpecified";
        private const string FieldtextColorField = "textColorField";
        private const string FieldtextSizeField = "textSizeField";
        private const string FieldtextSizeFieldSpecified = "textSizeFieldSpecified";
        private const string FieldtitleField = "titleField";
        private const string FieldtitleColorField = "titleColorField";
        private const string FieldtitleSizeField = "titleSizeField";
        private const string FieldtitleSizeFieldSpecified = "titleSizeFieldSpecified";
        private Type _reportChartInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private ReportChart _reportChartInstance;
        private ReportChart _reportChartInstanceFixture;

        #region General Initializer : Class (ReportChart) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="ReportChart" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _reportChartInstanceType = typeof(ReportChart);
            _reportChartInstanceFixture = Create(true);
            _reportChartInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (ReportChart)

        #region General Initializer : Class (ReportChart) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportChart" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertybackgroundColor1)]
        [TestCase(PropertybackgroundColor2)]
        [TestCase(PropertybackgroundFadeDir)]
        [TestCase(PropertybackgroundFadeDirSpecified)]
        [TestCase(PropertychartSummaries)]
        [TestCase(PropertychartType)]
        [TestCase(PropertyenableHoverLabels)]
        [TestCase(PropertyenableHoverLabelsSpecified)]
        [TestCase(PropertyexpandOthers)]
        [TestCase(PropertyexpandOthersSpecified)]
        [TestCase(PropertygroupingColumn)]
        [TestCase(PropertylegendPosition)]
        [TestCase(PropertylegendPositionSpecified)]
        [TestCase(Propertylocation)]
        [TestCase(PropertylocationSpecified)]
        [TestCase(PropertysecondaryGroupingColumn)]
        [TestCase(PropertyshowAxisLabels)]
        [TestCase(PropertyshowAxisLabelsSpecified)]
        [TestCase(PropertyshowPercentage)]
        [TestCase(PropertyshowPercentageSpecified)]
        [TestCase(PropertyshowTotal)]
        [TestCase(PropertyshowTotalSpecified)]
        [TestCase(PropertyshowValues)]
        [TestCase(PropertyshowValuesSpecified)]
        [TestCase(Propertysize)]
        [TestCase(PropertysizeSpecified)]
        [TestCase(PropertysummaryAxisManualRangeEnd)]
        [TestCase(PropertysummaryAxisManualRangeEndSpecified)]
        [TestCase(PropertysummaryAxisManualRangeStart)]
        [TestCase(PropertysummaryAxisManualRangeStartSpecified)]
        [TestCase(PropertysummaryAxisRange)]
        [TestCase(PropertysummaryAxisRangeSpecified)]
        [TestCase(PropertytextColor)]
        [TestCase(PropertytextSize)]
        [TestCase(PropertytextSizeSpecified)]
        [TestCase(Propertytitle)]
        [TestCase(PropertytitleColor)]
        [TestCase(PropertytitleSize)]
        [TestCase(PropertytitleSizeSpecified)]
        public void AUT_ReportChart_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_reportChartInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (ReportChart) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="ReportChart" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldbackgroundColor1Field)]
        [TestCase(FieldbackgroundColor2Field)]
        [TestCase(FieldbackgroundFadeDirField)]
        [TestCase(FieldbackgroundFadeDirFieldSpecified)]
        [TestCase(FieldchartSummariesField)]
        [TestCase(FieldchartTypeField)]
        [TestCase(FieldenableHoverLabelsField)]
        [TestCase(FieldenableHoverLabelsFieldSpecified)]
        [TestCase(FieldexpandOthersField)]
        [TestCase(FieldexpandOthersFieldSpecified)]
        [TestCase(FieldgroupingColumnField)]
        [TestCase(FieldlegendPositionField)]
        [TestCase(FieldlegendPositionFieldSpecified)]
        [TestCase(FieldlocationField)]
        [TestCase(FieldlocationFieldSpecified)]
        [TestCase(FieldsecondaryGroupingColumnField)]
        [TestCase(FieldshowAxisLabelsField)]
        [TestCase(FieldshowAxisLabelsFieldSpecified)]
        [TestCase(FieldshowPercentageField)]
        [TestCase(FieldshowPercentageFieldSpecified)]
        [TestCase(FieldshowTotalField)]
        [TestCase(FieldshowTotalFieldSpecified)]
        [TestCase(FieldshowValuesField)]
        [TestCase(FieldshowValuesFieldSpecified)]
        [TestCase(FieldsizeField)]
        [TestCase(FieldsizeFieldSpecified)]
        [TestCase(FieldsummaryAxisManualRangeEndField)]
        [TestCase(FieldsummaryAxisManualRangeEndFieldSpecified)]
        [TestCase(FieldsummaryAxisManualRangeStartField)]
        [TestCase(FieldsummaryAxisManualRangeStartFieldSpecified)]
        [TestCase(FieldsummaryAxisRangeField)]
        [TestCase(FieldsummaryAxisRangeFieldSpecified)]
        [TestCase(FieldtextColorField)]
        [TestCase(FieldtextSizeField)]
        [TestCase(FieldtextSizeFieldSpecified)]
        [TestCase(FieldtitleField)]
        [TestCase(FieldtitleColorField)]
        [TestCase(FieldtitleSizeField)]
        [TestCase(FieldtitleSizeFieldSpecified)]
        public void AUT_ReportChart_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_reportChartInstanceFixture, 
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
        ///     Class (<see cref="ReportChart" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_ReportChart_Is_Instance_Present_Test()
        {
            // Assert
            _reportChartInstanceType.ShouldNotBeNull();
            _reportChartInstance.ShouldNotBeNull();
            _reportChartInstanceFixture.ShouldNotBeNull();
            _reportChartInstance.ShouldBeAssignableTo<ReportChart>();
            _reportChartInstanceFixture.ShouldBeAssignableTo<ReportChart>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (ReportChart) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_ReportChart_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            ReportChart instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _reportChartInstanceType.ShouldNotBeNull();
            _reportChartInstance.ShouldNotBeNull();
            _reportChartInstanceFixture.ShouldNotBeNull();
            _reportChartInstance.ShouldBeAssignableTo<ReportChart>();
            _reportChartInstanceFixture.ShouldBeAssignableTo<ReportChart>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (ReportChart) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(string) , PropertybackgroundColor1)]
        [TestCaseGeneric(typeof(string) , PropertybackgroundColor2)]
        [TestCaseGeneric(typeof(ChartBackgroundDirection) , PropertybackgroundFadeDir)]
        [TestCaseGeneric(typeof(bool) , PropertybackgroundFadeDirSpecified)]
        [TestCaseGeneric(typeof(ChartSummary[]) , PropertychartSummaries)]
        [TestCaseGeneric(typeof(ChartType) , PropertychartType)]
        [TestCaseGeneric(typeof(bool) , PropertyenableHoverLabels)]
        [TestCaseGeneric(typeof(bool) , PropertyenableHoverLabelsSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyexpandOthers)]
        [TestCaseGeneric(typeof(bool) , PropertyexpandOthersSpecified)]
        [TestCaseGeneric(typeof(string) , PropertygroupingColumn)]
        [TestCaseGeneric(typeof(ChartLegendPosition) , PropertylegendPosition)]
        [TestCaseGeneric(typeof(bool) , PropertylegendPositionSpecified)]
        [TestCaseGeneric(typeof(ChartPosition) , Propertylocation)]
        [TestCaseGeneric(typeof(bool) , PropertylocationSpecified)]
        [TestCaseGeneric(typeof(string) , PropertysecondaryGroupingColumn)]
        [TestCaseGeneric(typeof(bool) , PropertyshowAxisLabels)]
        [TestCaseGeneric(typeof(bool) , PropertyshowAxisLabelsSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowPercentage)]
        [TestCaseGeneric(typeof(bool) , PropertyshowPercentageSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowTotal)]
        [TestCaseGeneric(typeof(bool) , PropertyshowTotalSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowValues)]
        [TestCaseGeneric(typeof(bool) , PropertyshowValuesSpecified)]
        [TestCaseGeneric(typeof(ReportChartSize) , Propertysize)]
        [TestCaseGeneric(typeof(bool) , PropertysizeSpecified)]
        [TestCaseGeneric(typeof(double) , PropertysummaryAxisManualRangeEnd)]
        [TestCaseGeneric(typeof(bool) , PropertysummaryAxisManualRangeEndSpecified)]
        [TestCaseGeneric(typeof(double) , PropertysummaryAxisManualRangeStart)]
        [TestCaseGeneric(typeof(bool) , PropertysummaryAxisManualRangeStartSpecified)]
        [TestCaseGeneric(typeof(ChartRangeType) , PropertysummaryAxisRange)]
        [TestCaseGeneric(typeof(bool) , PropertysummaryAxisRangeSpecified)]
        [TestCaseGeneric(typeof(string) , PropertytextColor)]
        [TestCaseGeneric(typeof(int) , PropertytextSize)]
        [TestCaseGeneric(typeof(bool) , PropertytextSizeSpecified)]
        [TestCaseGeneric(typeof(string) , Propertytitle)]
        [TestCaseGeneric(typeof(string) , PropertytitleColor)]
        [TestCaseGeneric(typeof(int) , PropertytitleSize)]
        [TestCaseGeneric(typeof(bool) , PropertytitleSizeSpecified)]
        public void AUT_ReportChart_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<ReportChart, T>(_reportChartInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (backgroundColor1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_backgroundColor1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybackgroundColor1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (backgroundColor2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_backgroundColor2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybackgroundColor2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (backgroundFadeDir) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_backgroundFadeDir_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertybackgroundFadeDir);
            Action currentAction = () => propertyInfo.SetValue(_reportChartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (backgroundFadeDir) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_backgroundFadeDir_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybackgroundFadeDir);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (backgroundFadeDirSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_backgroundFadeDirSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertybackgroundFadeDirSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (chartSummaries) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_chartSummaries_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertychartSummaries);
            Action currentAction = () => propertyInfo.SetValue(_reportChartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (chartSummaries) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_chartSummaries_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychartSummaries);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (chartType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_chartType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertychartType);
            Action currentAction = () => propertyInfo.SetValue(_reportChartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (chartType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_chartType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychartType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (enableHoverLabels) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_enableHoverLabels_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableHoverLabels);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (enableHoverLabelsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_enableHoverLabelsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableHoverLabelsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (expandOthers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_expandOthers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexpandOthers);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (expandOthersSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_expandOthersSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyexpandOthersSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (groupingColumn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_groupingColumn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertygroupingColumn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (legendPosition) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_legendPosition_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylegendPosition);
            Action currentAction = () => propertyInfo.SetValue(_reportChartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (legendPosition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_legendPosition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylegendPosition);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (legendPositionSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_legendPositionSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylegendPositionSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (location) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_location_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertylocation);
            Action currentAction = () => propertyInfo.SetValue(_reportChartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (location) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_location_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertylocation);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (locationSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_locationSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertylocationSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (secondaryGroupingColumn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_secondaryGroupingColumn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysecondaryGroupingColumn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (showAxisLabels) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_showAxisLabels_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowAxisLabels);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (showAxisLabelsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_showAxisLabelsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowAxisLabelsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (showPercentage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_showPercentage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowPercentage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (showPercentageSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_showPercentageSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowPercentageSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (showTotal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_showTotal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowTotal);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (showTotalSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_showTotalSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowTotalSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (showValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_showValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowValues);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (showValuesSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_showValuesSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowValuesSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (size) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_size_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(Propertysize);
            Action currentAction = () => propertyInfo.SetValue(_reportChartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (size) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_size_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertysize);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (sizeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_sizeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysizeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (summaryAxisManualRangeEnd) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_summaryAxisManualRangeEnd_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummaryAxisManualRangeEnd);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (summaryAxisManualRangeEndSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_summaryAxisManualRangeEndSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummaryAxisManualRangeEndSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (summaryAxisManualRangeStart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_summaryAxisManualRangeStart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummaryAxisManualRangeStart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (summaryAxisManualRangeStartSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_summaryAxisManualRangeStartSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummaryAxisManualRangeStartSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (summaryAxisRange) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_summaryAxisRange_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysummaryAxisRange);
            Action currentAction = () => propertyInfo.SetValue(_reportChartInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (summaryAxisRange) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_summaryAxisRange_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummaryAxisRange);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (summaryAxisRangeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_summaryAxisRangeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysummaryAxisRangeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (textColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_textColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytextColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (textSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_textSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytextSize);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (textSizeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_textSizeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytextSizeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertytitle);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (titleColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_titleColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytitleColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (titleSize) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_titleSize_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytitleSize);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (ReportChart) => Property (titleSizeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_ReportChart_Public_Class_titleSizeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertytitleSizeSpecified);

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