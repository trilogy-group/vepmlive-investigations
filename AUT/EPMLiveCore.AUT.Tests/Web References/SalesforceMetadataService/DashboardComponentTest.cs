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
    ///     Automatic Unit Tests or bulk unit tests for (<see cref="EPMLiveCore.SalesforceMetadataService.DashboardComponent" />)
    ///     and namespace <see cref="EPMLiveCore.SalesforceMetadataService"/> class using generator(v:0.2.1)'s 
    ///     artificial intelligence.
    /// </summary>
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public partial class DashboardComponentTest : AbstractBaseSetupTypedTest<DashboardComponent>
    {
        #region Category : General

        #region Category : Initializer

        #region General Initializer : Class (DashboardComponent) Initializer

        private const string PropertyautoselectColumnsFromReport = "autoselectColumnsFromReport";
        private const string PropertyautoselectColumnsFromReportSpecified = "autoselectColumnsFromReportSpecified";
        private const string PropertychartAxisRange = "chartAxisRange";
        private const string PropertychartAxisRangeSpecified = "chartAxisRangeSpecified";
        private const string PropertychartAxisRangeMax = "chartAxisRangeMax";
        private const string PropertychartAxisRangeMaxSpecified = "chartAxisRangeMaxSpecified";
        private const string PropertychartAxisRangeMin = "chartAxisRangeMin";
        private const string PropertychartAxisRangeMinSpecified = "chartAxisRangeMinSpecified";
        private const string PropertychartSummary = "chartSummary";
        private const string PropertycomponentType = "componentType";
        private const string PropertydashboardFilterColumns = "dashboardFilterColumns";
        private const string PropertydashboardTableColumn = "dashboardTableColumn";
        private const string PropertydisplayUnits = "displayUnits";
        private const string PropertydisplayUnitsSpecified = "displayUnitsSpecified";
        private const string PropertydrillDownUrl = "drillDownUrl";
        private const string PropertydrillEnabled = "drillEnabled";
        private const string PropertydrillEnabledSpecified = "drillEnabledSpecified";
        private const string PropertydrillToDetailEnabled = "drillToDetailEnabled";
        private const string PropertydrillToDetailEnabledSpecified = "drillToDetailEnabledSpecified";
        private const string PropertyenableHover = "enableHover";
        private const string PropertyenableHoverSpecified = "enableHoverSpecified";
        private const string PropertyexpandOthers = "expandOthers";
        private const string PropertyexpandOthersSpecified = "expandOthersSpecified";
        private const string Propertyfooter = "footer";
        private const string PropertygaugeMax = "gaugeMax";
        private const string PropertygaugeMaxSpecified = "gaugeMaxSpecified";
        private const string PropertygaugeMin = "gaugeMin";
        private const string PropertygaugeMinSpecified = "gaugeMinSpecified";
        private const string PropertygroupingColumn = "groupingColumn";
        private const string Propertyheader = "header";
        private const string PropertyindicatorBreakpoint1 = "indicatorBreakpoint1";
        private const string PropertyindicatorBreakpoint1Specified = "indicatorBreakpoint1Specified";
        private const string PropertyindicatorBreakpoint2 = "indicatorBreakpoint2";
        private const string PropertyindicatorBreakpoint2Specified = "indicatorBreakpoint2Specified";
        private const string PropertyindicatorHighColor = "indicatorHighColor";
        private const string PropertyindicatorLowColor = "indicatorLowColor";
        private const string PropertyindicatorMiddleColor = "indicatorMiddleColor";
        private const string PropertylegendPosition = "legendPosition";
        private const string PropertylegendPositionSpecified = "legendPositionSpecified";
        private const string PropertymaxValuesDisplayed = "maxValuesDisplayed";
        private const string PropertymaxValuesDisplayedSpecified = "maxValuesDisplayedSpecified";
        private const string PropertymetricLabel = "metricLabel";
        private const string Propertypage = "page";
        private const string PropertypageHeightInPixels = "pageHeightInPixels";
        private const string PropertypageHeightInPixelsSpecified = "pageHeightInPixelsSpecified";
        private const string Propertyreport = "report";
        private const string Propertyscontrol = "scontrol";
        private const string PropertyscontrolHeightInPixels = "scontrolHeightInPixels";
        private const string PropertyscontrolHeightInPixelsSpecified = "scontrolHeightInPixelsSpecified";
        private const string PropertyshowPercentage = "showPercentage";
        private const string PropertyshowPercentageSpecified = "showPercentageSpecified";
        private const string PropertyshowPicturesOnCharts = "showPicturesOnCharts";
        private const string PropertyshowPicturesOnChartsSpecified = "showPicturesOnChartsSpecified";
        private const string PropertyshowPicturesOnTables = "showPicturesOnTables";
        private const string PropertyshowPicturesOnTablesSpecified = "showPicturesOnTablesSpecified";
        private const string PropertyshowTotal = "showTotal";
        private const string PropertyshowTotalSpecified = "showTotalSpecified";
        private const string PropertyshowValues = "showValues";
        private const string PropertyshowValuesSpecified = "showValuesSpecified";
        private const string PropertysortBy = "sortBy";
        private const string PropertysortBySpecified = "sortBySpecified";
        private const string Propertytitle = "title";
        private const string PropertyuseReportChart = "useReportChart";
        private const string PropertyuseReportChartSpecified = "useReportChartSpecified";
        private const string FieldautoselectColumnsFromReportField = "autoselectColumnsFromReportField";
        private const string FieldautoselectColumnsFromReportFieldSpecified = "autoselectColumnsFromReportFieldSpecified";
        private const string FieldchartAxisRangeField = "chartAxisRangeField";
        private const string FieldchartAxisRangeFieldSpecified = "chartAxisRangeFieldSpecified";
        private const string FieldchartAxisRangeMaxField = "chartAxisRangeMaxField";
        private const string FieldchartAxisRangeMaxFieldSpecified = "chartAxisRangeMaxFieldSpecified";
        private const string FieldchartAxisRangeMinField = "chartAxisRangeMinField";
        private const string FieldchartAxisRangeMinFieldSpecified = "chartAxisRangeMinFieldSpecified";
        private const string FieldchartSummaryField = "chartSummaryField";
        private const string FieldcomponentTypeField = "componentTypeField";
        private const string FielddashboardFilterColumnsField = "dashboardFilterColumnsField";
        private const string FielddashboardTableColumnField = "dashboardTableColumnField";
        private const string FielddisplayUnitsField = "displayUnitsField";
        private const string FielddisplayUnitsFieldSpecified = "displayUnitsFieldSpecified";
        private const string FielddrillDownUrlField = "drillDownUrlField";
        private const string FielddrillEnabledField = "drillEnabledField";
        private const string FielddrillEnabledFieldSpecified = "drillEnabledFieldSpecified";
        private const string FielddrillToDetailEnabledField = "drillToDetailEnabledField";
        private const string FielddrillToDetailEnabledFieldSpecified = "drillToDetailEnabledFieldSpecified";
        private const string FieldenableHoverField = "enableHoverField";
        private const string FieldenableHoverFieldSpecified = "enableHoverFieldSpecified";
        private const string FieldexpandOthersField = "expandOthersField";
        private const string FieldexpandOthersFieldSpecified = "expandOthersFieldSpecified";
        private const string FieldfooterField = "footerField";
        private const string FieldgaugeMaxField = "gaugeMaxField";
        private const string FieldgaugeMaxFieldSpecified = "gaugeMaxFieldSpecified";
        private const string FieldgaugeMinField = "gaugeMinField";
        private const string FieldgaugeMinFieldSpecified = "gaugeMinFieldSpecified";
        private const string FieldgroupingColumnField = "groupingColumnField";
        private const string FieldheaderField = "headerField";
        private const string FieldindicatorBreakpoint1Field = "indicatorBreakpoint1Field";
        private const string FieldindicatorBreakpoint1FieldSpecified = "indicatorBreakpoint1FieldSpecified";
        private const string FieldindicatorBreakpoint2Field = "indicatorBreakpoint2Field";
        private const string FieldindicatorBreakpoint2FieldSpecified = "indicatorBreakpoint2FieldSpecified";
        private const string FieldindicatorHighColorField = "indicatorHighColorField";
        private const string FieldindicatorLowColorField = "indicatorLowColorField";
        private const string FieldindicatorMiddleColorField = "indicatorMiddleColorField";
        private const string FieldlegendPositionField = "legendPositionField";
        private const string FieldlegendPositionFieldSpecified = "legendPositionFieldSpecified";
        private const string FieldmaxValuesDisplayedField = "maxValuesDisplayedField";
        private const string FieldmaxValuesDisplayedFieldSpecified = "maxValuesDisplayedFieldSpecified";
        private const string FieldmetricLabelField = "metricLabelField";
        private const string FieldpageField = "pageField";
        private const string FieldpageHeightInPixelsField = "pageHeightInPixelsField";
        private const string FieldpageHeightInPixelsFieldSpecified = "pageHeightInPixelsFieldSpecified";
        private const string FieldreportField = "reportField";
        private const string FieldscontrolField = "scontrolField";
        private const string FieldscontrolHeightInPixelsField = "scontrolHeightInPixelsField";
        private const string FieldscontrolHeightInPixelsFieldSpecified = "scontrolHeightInPixelsFieldSpecified";
        private const string FieldshowPercentageField = "showPercentageField";
        private const string FieldshowPercentageFieldSpecified = "showPercentageFieldSpecified";
        private const string FieldshowPicturesOnChartsField = "showPicturesOnChartsField";
        private const string FieldshowPicturesOnChartsFieldSpecified = "showPicturesOnChartsFieldSpecified";
        private const string FieldshowPicturesOnTablesField = "showPicturesOnTablesField";
        private const string FieldshowPicturesOnTablesFieldSpecified = "showPicturesOnTablesFieldSpecified";
        private const string FieldshowTotalField = "showTotalField";
        private const string FieldshowTotalFieldSpecified = "showTotalFieldSpecified";
        private const string FieldshowValuesField = "showValuesField";
        private const string FieldshowValuesFieldSpecified = "showValuesFieldSpecified";
        private const string FieldsortByField = "sortByField";
        private const string FieldsortByFieldSpecified = "sortByFieldSpecified";
        private const string FieldtitleField = "titleField";
        private const string FielduseReportChartField = "useReportChartField";
        private const string FielduseReportChartFieldSpecified = "useReportChartFieldSpecified";
        private Type _dashboardComponentInstanceType;
        private const int TestsTimeOut = TestContants.TimeOutFiveSeconds;
        private DashboardComponent _dashboardComponentInstance;
        private DashboardComponent _dashboardComponentInstanceFixture;

        #region General Initializer : Class (DashboardComponent) One time setup

        /// <summary>
        ///    Setting up everything for <see cref="DashboardComponent" /> one time.
        /// </summary>
        [OneTimeSetUp]
        [ExcludeFromCodeCoverage]
        public void OneTimeSetup()
        {
            _dashboardComponentInstanceType = typeof(DashboardComponent);
            _dashboardComponentInstanceFixture = Create(true);
            _dashboardComponentInstance = Create(false);
        }

        #endregion

        #endregion

        #region Explore Class for Coverage Gain : Class (DashboardComponent)

        #region General Initializer : Class (DashboardComponent) All Properties Explore By Name

        /// <summary>
        ///     Class (<see cref="DashboardComponent" />) explore and verify properties for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(PropertyautoselectColumnsFromReport)]
        [TestCase(PropertyautoselectColumnsFromReportSpecified)]
        [TestCase(PropertychartAxisRange)]
        [TestCase(PropertychartAxisRangeSpecified)]
        [TestCase(PropertychartAxisRangeMax)]
        [TestCase(PropertychartAxisRangeMaxSpecified)]
        [TestCase(PropertychartAxisRangeMin)]
        [TestCase(PropertychartAxisRangeMinSpecified)]
        [TestCase(PropertychartSummary)]
        [TestCase(PropertycomponentType)]
        [TestCase(PropertydashboardFilterColumns)]
        [TestCase(PropertydashboardTableColumn)]
        [TestCase(PropertydisplayUnits)]
        [TestCase(PropertydisplayUnitsSpecified)]
        [TestCase(PropertydrillDownUrl)]
        [TestCase(PropertydrillEnabled)]
        [TestCase(PropertydrillEnabledSpecified)]
        [TestCase(PropertydrillToDetailEnabled)]
        [TestCase(PropertydrillToDetailEnabledSpecified)]
        [TestCase(PropertyenableHover)]
        [TestCase(PropertyenableHoverSpecified)]
        [TestCase(PropertyexpandOthers)]
        [TestCase(PropertyexpandOthersSpecified)]
        [TestCase(Propertyfooter)]
        [TestCase(PropertygaugeMax)]
        [TestCase(PropertygaugeMaxSpecified)]
        [TestCase(PropertygaugeMin)]
        [TestCase(PropertygaugeMinSpecified)]
        [TestCase(PropertygroupingColumn)]
        [TestCase(Propertyheader)]
        [TestCase(PropertyindicatorBreakpoint1)]
        [TestCase(PropertyindicatorBreakpoint1Specified)]
        [TestCase(PropertyindicatorBreakpoint2)]
        [TestCase(PropertyindicatorBreakpoint2Specified)]
        [TestCase(PropertyindicatorHighColor)]
        [TestCase(PropertyindicatorLowColor)]
        [TestCase(PropertyindicatorMiddleColor)]
        [TestCase(PropertylegendPosition)]
        [TestCase(PropertylegendPositionSpecified)]
        [TestCase(PropertymaxValuesDisplayed)]
        [TestCase(PropertymaxValuesDisplayedSpecified)]
        [TestCase(PropertymetricLabel)]
        [TestCase(Propertypage)]
        [TestCase(PropertypageHeightInPixels)]
        [TestCase(PropertypageHeightInPixelsSpecified)]
        [TestCase(Propertyreport)]
        [TestCase(Propertyscontrol)]
        [TestCase(PropertyscontrolHeightInPixels)]
        [TestCase(PropertyscontrolHeightInPixelsSpecified)]
        [TestCase(PropertyshowPercentage)]
        [TestCase(PropertyshowPercentageSpecified)]
        [TestCase(PropertyshowPicturesOnCharts)]
        [TestCase(PropertyshowPicturesOnChartsSpecified)]
        [TestCase(PropertyshowPicturesOnTables)]
        [TestCase(PropertyshowPicturesOnTablesSpecified)]
        [TestCase(PropertyshowTotal)]
        [TestCase(PropertyshowTotalSpecified)]
        [TestCase(PropertyshowValues)]
        [TestCase(PropertyshowValuesSpecified)]
        [TestCase(PropertysortBy)]
        [TestCase(PropertysortBySpecified)]
        [TestCase(Propertytitle)]
        [TestCase(PropertyuseReportChart)]
        [TestCase(PropertyuseReportChartSpecified)]
        public void AUT_DashboardComponent_All_Properties_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var propertyInfo = GetPropertyInfo(name);

            // Act
            ShouldlyExtension.ExploreProperty(_dashboardComponentInstanceFixture,
                                              Fixture,
                                              propertyInfo);

            // Assert
            propertyInfo.ShouldNotBeNull();
        }

        #endregion

        #region General Initializer : Class (DashboardComponent) All Fields Explore By Name

        /// <summary>
        ///     Class (<see cref="DashboardComponent" />) explore and verify fields for coverage gain.
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Initializer")]
        [TestCase(FieldautoselectColumnsFromReportField)]
        [TestCase(FieldautoselectColumnsFromReportFieldSpecified)]
        [TestCase(FieldchartAxisRangeField)]
        [TestCase(FieldchartAxisRangeFieldSpecified)]
        [TestCase(FieldchartAxisRangeMaxField)]
        [TestCase(FieldchartAxisRangeMaxFieldSpecified)]
        [TestCase(FieldchartAxisRangeMinField)]
        [TestCase(FieldchartAxisRangeMinFieldSpecified)]
        [TestCase(FieldchartSummaryField)]
        [TestCase(FieldcomponentTypeField)]
        [TestCase(FielddashboardFilterColumnsField)]
        [TestCase(FielddashboardTableColumnField)]
        [TestCase(FielddisplayUnitsField)]
        [TestCase(FielddisplayUnitsFieldSpecified)]
        [TestCase(FielddrillDownUrlField)]
        [TestCase(FielddrillEnabledField)]
        [TestCase(FielddrillEnabledFieldSpecified)]
        [TestCase(FielddrillToDetailEnabledField)]
        [TestCase(FielddrillToDetailEnabledFieldSpecified)]
        [TestCase(FieldenableHoverField)]
        [TestCase(FieldenableHoverFieldSpecified)]
        [TestCase(FieldexpandOthersField)]
        [TestCase(FieldexpandOthersFieldSpecified)]
        [TestCase(FieldfooterField)]
        [TestCase(FieldgaugeMaxField)]
        [TestCase(FieldgaugeMaxFieldSpecified)]
        [TestCase(FieldgaugeMinField)]
        [TestCase(FieldgaugeMinFieldSpecified)]
        [TestCase(FieldgroupingColumnField)]
        [TestCase(FieldheaderField)]
        [TestCase(FieldindicatorBreakpoint1Field)]
        [TestCase(FieldindicatorBreakpoint1FieldSpecified)]
        [TestCase(FieldindicatorBreakpoint2Field)]
        [TestCase(FieldindicatorBreakpoint2FieldSpecified)]
        [TestCase(FieldindicatorHighColorField)]
        [TestCase(FieldindicatorLowColorField)]
        [TestCase(FieldindicatorMiddleColorField)]
        [TestCase(FieldlegendPositionField)]
        [TestCase(FieldlegendPositionFieldSpecified)]
        [TestCase(FieldmaxValuesDisplayedField)]
        [TestCase(FieldmaxValuesDisplayedFieldSpecified)]
        [TestCase(FieldmetricLabelField)]
        [TestCase(FieldpageField)]
        [TestCase(FieldpageHeightInPixelsField)]
        [TestCase(FieldpageHeightInPixelsFieldSpecified)]
        [TestCase(FieldreportField)]
        [TestCase(FieldscontrolField)]
        [TestCase(FieldscontrolHeightInPixelsField)]
        [TestCase(FieldscontrolHeightInPixelsFieldSpecified)]
        [TestCase(FieldshowPercentageField)]
        [TestCase(FieldshowPercentageFieldSpecified)]
        [TestCase(FieldshowPicturesOnChartsField)]
        [TestCase(FieldshowPicturesOnChartsFieldSpecified)]
        [TestCase(FieldshowPicturesOnTablesField)]
        [TestCase(FieldshowPicturesOnTablesFieldSpecified)]
        [TestCase(FieldshowTotalField)]
        [TestCase(FieldshowTotalFieldSpecified)]
        [TestCase(FieldshowValuesField)]
        [TestCase(FieldshowValuesFieldSpecified)]
        [TestCase(FieldsortByField)]
        [TestCase(FieldsortByFieldSpecified)]
        [TestCase(FieldtitleField)]
        [TestCase(FielduseReportChartField)]
        [TestCase(FielduseReportChartFieldSpecified)]
        public void AUT_DashboardComponent_All_Fields_Explore_Verify_By_Name_Test(string name)
        {
            // Arrange
            var fieldInfo = GetFieldInfo(name);

            // Act
            ShouldlyExtension.ExploreFieldWithOrWithoutInstance(_dashboardComponentInstanceFixture, 
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
        ///     Class (<see cref="DashboardComponent" />) can be created test
        /// </summary>
        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Instance")]
        public void AUT_DashboardComponent_Is_Instance_Present_Test()
        {
            // Assert
            _dashboardComponentInstanceType.ShouldNotBeNull();
            _dashboardComponentInstance.ShouldNotBeNull();
            _dashboardComponentInstanceFixture.ShouldNotBeNull();
            _dashboardComponentInstance.ShouldBeAssignableTo<DashboardComponent>();
            _dashboardComponentInstanceFixture.ShouldBeAssignableTo<DashboardComponent>();
        }

        #endregion

        #region Category : Constructor

        #region General Constructor : Class (DashboardComponent) without Parameter Test

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT Constructor")]
        public void AUT_Constructor_DashboardComponent_Instantiated_Without_Parameter_No_Throw_Exception_Test()
        {
            // Arrange
            DashboardComponent instance = null;

            // Act
            var exception = CreateAnalyzer.GetThrownExceptionWhenCreate(out instance);

            // Assert
            instance.ShouldNotBeNull();
            exception.ShouldBeNull();
            _dashboardComponentInstanceType.ShouldNotBeNull();
            _dashboardComponentInstance.ShouldNotBeNull();
            _dashboardComponentInstanceFixture.ShouldNotBeNull();
            _dashboardComponentInstance.ShouldBeAssignableTo<DashboardComponent>();
            _dashboardComponentInstanceFixture.ShouldBeAssignableTo<DashboardComponent>();
        }

        #endregion

        #endregion

        #region Category : GetterSetter

        #region General Getters/Setters : Class (DashboardComponent) => all properties (non-static) explore and verify type tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        [TestCaseGeneric(typeof(bool) , PropertyautoselectColumnsFromReport)]
        [TestCaseGeneric(typeof(bool) , PropertyautoselectColumnsFromReportSpecified)]
        [TestCaseGeneric(typeof(ChartRangeType) , PropertychartAxisRange)]
        [TestCaseGeneric(typeof(bool) , PropertychartAxisRangeSpecified)]
        [TestCaseGeneric(typeof(double) , PropertychartAxisRangeMax)]
        [TestCaseGeneric(typeof(bool) , PropertychartAxisRangeMaxSpecified)]
        [TestCaseGeneric(typeof(double) , PropertychartAxisRangeMin)]
        [TestCaseGeneric(typeof(bool) , PropertychartAxisRangeMinSpecified)]
        [TestCaseGeneric(typeof(ChartSummary[]) , PropertychartSummary)]
        [TestCaseGeneric(typeof(DashboardComponentType) , PropertycomponentType)]
        [TestCaseGeneric(typeof(DashboardFilterColumn[]) , PropertydashboardFilterColumns)]
        [TestCaseGeneric(typeof(DashboardTableColumn[]) , PropertydashboardTableColumn)]
        [TestCaseGeneric(typeof(ChartUnits) , PropertydisplayUnits)]
        [TestCaseGeneric(typeof(bool) , PropertydisplayUnitsSpecified)]
        [TestCaseGeneric(typeof(string) , PropertydrillDownUrl)]
        [TestCaseGeneric(typeof(bool) , PropertydrillEnabled)]
        [TestCaseGeneric(typeof(bool) , PropertydrillEnabledSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertydrillToDetailEnabled)]
        [TestCaseGeneric(typeof(bool) , PropertydrillToDetailEnabledSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyenableHover)]
        [TestCaseGeneric(typeof(bool) , PropertyenableHoverSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyexpandOthers)]
        [TestCaseGeneric(typeof(bool) , PropertyexpandOthersSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyfooter)]
        [TestCaseGeneric(typeof(double) , PropertygaugeMax)]
        [TestCaseGeneric(typeof(bool) , PropertygaugeMaxSpecified)]
        [TestCaseGeneric(typeof(double) , PropertygaugeMin)]
        [TestCaseGeneric(typeof(bool) , PropertygaugeMinSpecified)]
        [TestCaseGeneric(typeof(string[]) , PropertygroupingColumn)]
        [TestCaseGeneric(typeof(string) , Propertyheader)]
        [TestCaseGeneric(typeof(double) , PropertyindicatorBreakpoint1)]
        [TestCaseGeneric(typeof(bool) , PropertyindicatorBreakpoint1Specified)]
        [TestCaseGeneric(typeof(double) , PropertyindicatorBreakpoint2)]
        [TestCaseGeneric(typeof(bool) , PropertyindicatorBreakpoint2Specified)]
        [TestCaseGeneric(typeof(string) , PropertyindicatorHighColor)]
        [TestCaseGeneric(typeof(string) , PropertyindicatorLowColor)]
        [TestCaseGeneric(typeof(string) , PropertyindicatorMiddleColor)]
        [TestCaseGeneric(typeof(ChartLegendPosition) , PropertylegendPosition)]
        [TestCaseGeneric(typeof(bool) , PropertylegendPositionSpecified)]
        [TestCaseGeneric(typeof(int) , PropertymaxValuesDisplayed)]
        [TestCaseGeneric(typeof(bool) , PropertymaxValuesDisplayedSpecified)]
        [TestCaseGeneric(typeof(string) , PropertymetricLabel)]
        [TestCaseGeneric(typeof(string) , Propertypage)]
        [TestCaseGeneric(typeof(int) , PropertypageHeightInPixels)]
        [TestCaseGeneric(typeof(bool) , PropertypageHeightInPixelsSpecified)]
        [TestCaseGeneric(typeof(string) , Propertyreport)]
        [TestCaseGeneric(typeof(string) , Propertyscontrol)]
        [TestCaseGeneric(typeof(int) , PropertyscontrolHeightInPixels)]
        [TestCaseGeneric(typeof(bool) , PropertyscontrolHeightInPixelsSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowPercentage)]
        [TestCaseGeneric(typeof(bool) , PropertyshowPercentageSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowPicturesOnCharts)]
        [TestCaseGeneric(typeof(bool) , PropertyshowPicturesOnChartsSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowPicturesOnTables)]
        [TestCaseGeneric(typeof(bool) , PropertyshowPicturesOnTablesSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowTotal)]
        [TestCaseGeneric(typeof(bool) , PropertyshowTotalSpecified)]
        [TestCaseGeneric(typeof(bool) , PropertyshowValues)]
        [TestCaseGeneric(typeof(bool) , PropertyshowValuesSpecified)]
        [TestCaseGeneric(typeof(DashboardComponentFilter) , PropertysortBy)]
        [TestCaseGeneric(typeof(bool) , PropertysortBySpecified)]
        [TestCaseGeneric(typeof(string) , Propertytitle)]
        [TestCaseGeneric(typeof(bool) , PropertyuseReportChart)]
        [TestCaseGeneric(typeof(bool) , PropertyuseReportChartSpecified)]
        public void AUT_DashboardComponent_Property_Type_Verify_Explore_By_Name_Test<T>(string propertyName)
        {
            // AAA : Arrange, Act, Assert
            ShouldlyExtension.PropertyTypeVerify<DashboardComponent, T>(_dashboardComponentInstance, propertyName, Fixture);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (autoselectColumnsFromReport) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_autoselectColumnsFromReport_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyautoselectColumnsFromReport);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (autoselectColumnsFromReportSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_autoselectColumnsFromReportSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyautoselectColumnsFromReportSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (chartAxisRange) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_chartAxisRange_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertychartAxisRange);
            Action currentAction = () => propertyInfo.SetValue(_dashboardComponentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (chartAxisRange) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_chartAxisRange_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychartAxisRange);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (chartAxisRangeMax) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_chartAxisRangeMax_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychartAxisRangeMax);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (chartAxisRangeMaxSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_chartAxisRangeMaxSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychartAxisRangeMaxSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (chartAxisRangeMin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_chartAxisRangeMin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychartAxisRangeMin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (chartAxisRangeMinSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_chartAxisRangeMinSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychartAxisRangeMinSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (chartAxisRangeSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_chartAxisRangeSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychartAxisRangeSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (chartSummary) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_chartSummary_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertychartSummary);
            Action currentAction = () => propertyInfo.SetValue(_dashboardComponentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (chartSummary) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_chartSummary_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertychartSummary);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (componentType) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_componentType_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertycomponentType);
            Action currentAction = () => propertyInfo.SetValue(_dashboardComponentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (componentType) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_componentType_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertycomponentType);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (dashboardFilterColumns) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_dashboardFilterColumns_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydashboardFilterColumns);
            Action currentAction = () => propertyInfo.SetValue(_dashboardComponentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (dashboardFilterColumns) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_dashboardFilterColumns_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydashboardFilterColumns);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (dashboardTableColumn) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_dashboardTableColumn_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydashboardTableColumn);
            Action currentAction = () => propertyInfo.SetValue(_dashboardComponentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (dashboardTableColumn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_dashboardTableColumn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydashboardTableColumn);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (displayUnits) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_displayUnits_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertydisplayUnits);
            Action currentAction = () => propertyInfo.SetValue(_dashboardComponentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (displayUnits) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_displayUnits_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisplayUnits);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (displayUnitsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_displayUnitsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydisplayUnitsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (drillDownUrl) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_drillDownUrl_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydrillDownUrl);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (drillEnabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_drillEnabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydrillEnabled);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (drillEnabledSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_drillEnabledSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydrillEnabledSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (drillToDetailEnabled) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_drillToDetailEnabled_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydrillToDetailEnabled);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (drillToDetailEnabledSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_drillToDetailEnabledSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertydrillToDetailEnabledSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (enableHover) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_enableHover_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableHover);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (enableHoverSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_enableHoverSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyenableHoverSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (expandOthers) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_expandOthers_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DashboardComponent) => Property (expandOthersSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_expandOthersSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DashboardComponent) => Property (footer) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_footer_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyfooter);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (gaugeMax) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_gaugeMax_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertygaugeMax);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (gaugeMaxSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_gaugeMaxSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertygaugeMaxSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (gaugeMin) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_gaugeMin_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertygaugeMin);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (gaugeMinSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_gaugeMinSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertygaugeMinSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (groupingColumn) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_groupingColumn_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertygroupingColumn);
            Action currentAction = () => propertyInfo.SetValue(_dashboardComponentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (groupingColumn) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_groupingColumn_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DashboardComponent) => Property (header) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_header_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyheader);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (indicatorBreakpoint1) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_indicatorBreakpoint1_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyindicatorBreakpoint1);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (indicatorBreakpoint1Specified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_indicatorBreakpoint1Specified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyindicatorBreakpoint1Specified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (indicatorBreakpoint2) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_indicatorBreakpoint2_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyindicatorBreakpoint2);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (indicatorBreakpoint2Specified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_indicatorBreakpoint2Specified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyindicatorBreakpoint2Specified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (indicatorHighColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_indicatorHighColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyindicatorHighColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (indicatorLowColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_indicatorLowColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyindicatorLowColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (indicatorMiddleColor) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_indicatorMiddleColor_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyindicatorMiddleColor);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (legendPosition) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_legendPosition_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertylegendPosition);
            Action currentAction = () => propertyInfo.SetValue(_dashboardComponentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (legendPosition) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_legendPosition_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DashboardComponent) => Property (legendPositionSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_legendPositionSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DashboardComponent) => Property (maxValuesDisplayed) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_maxValuesDisplayed_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymaxValuesDisplayed);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (maxValuesDisplayedSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_maxValuesDisplayedSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymaxValuesDisplayedSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (metricLabel) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_metricLabel_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertymetricLabel);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (page) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_page_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertypage);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (pageHeightInPixels) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_pageHeightInPixels_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypageHeightInPixels);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (pageHeightInPixelsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_pageHeightInPixelsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertypageHeightInPixelsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (report) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_report_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyreport);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (scontrol) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_scontrol_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(Propertyscontrol);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (scontrolHeightInPixels) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_scontrolHeightInPixels_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyscontrolHeightInPixels);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (scontrolHeightInPixelsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_scontrolHeightInPixelsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyscontrolHeightInPixelsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (showPercentage) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_showPercentage_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DashboardComponent) => Property (showPercentageSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_showPercentageSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DashboardComponent) => Property (showPicturesOnCharts) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_showPicturesOnCharts_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowPicturesOnCharts);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (showPicturesOnChartsSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_showPicturesOnChartsSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowPicturesOnChartsSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (showPicturesOnTables) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_showPicturesOnTables_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowPicturesOnTables);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (showPicturesOnTablesSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_showPicturesOnTablesSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyshowPicturesOnTablesSpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (showTotal) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_showTotal_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DashboardComponent) => Property (showTotalSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_showTotalSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DashboardComponent) => Property (showValues) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_showValues_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DashboardComponent) => Property (showValuesSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_showValuesSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DashboardComponent) => Property (sortBy) Property Type Test Except String

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_sortBy_Property_Setting_String_Throw_Argument_Exception_Test()
        {
            // Arrange
            var randomString = CreateType<string>();

            // Act
            var propertyInfo = GetPropertyInfo(PropertysortBy);
            Action currentAction = () => propertyInfo.SetValue(_dashboardComponentInstance, randomString, null);

            // Assert
            propertyInfo.ShouldNotBeNull();
            Should.Throw<ArgumentException>(currentAction);
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (sortBy) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_sortBy_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortBy);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (sortBySpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_sortBySpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertysortBySpecified);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (title) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_title_Coverage_For_Property_Is_Present_And_Can_Read_Test()
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

        #region General Getters/Setters : Class (DashboardComponent) => Property (useReportChart) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_useReportChart_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseReportChart);

            // Act
            var canRead = propertyInfo?.CanRead;

            // Assert
            propertyInfo.ShouldNotBeNull();
            canRead.ShouldNotBeNull();
            canRead?.ShouldBeTrue();
        }

        #endregion

        #region General Getters/Setters : Class (DashboardComponent) => Property (useReportChartSpecified) (Can Read) tests

        [Test]
        [Timeout(TestsTimeOut)]
        [NUnit.Framework.Category("AUT GetterSetter")]
        public void AUT_DashboardComponent_Public_Class_useReportChartSpecified_Coverage_For_Property_Is_Present_And_Can_Read_Test()
        {
            // Arrange
            var propertyInfo  = GetPropertyInfo(PropertyuseReportChartSpecified);

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