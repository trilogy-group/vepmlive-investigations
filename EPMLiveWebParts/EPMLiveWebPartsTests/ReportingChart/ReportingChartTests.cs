using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Xml;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveCore.ReportingProxy.Fakes;
using EPMLiveWebParts.ReportingChart;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebControls.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportFiltering.DomainServices;
using ReportFiltering.DomainServices.Fakes;
using Shouldly;
using Telerik.Web.UI;
using Telerik.Web.UI.HtmlChart;
using RC = EPMLiveWebParts.ReportingChart;
using WP = EPMLiveWebParts;

namespace EPMLiveWebParts.Tests.ReportingChart
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ReportingChartTests
    {
        private const int Id = 1;
        private const string DummyString = "DummyString";
        private const string One = "1";
        private const string ExampleUrl = "http://example.com";
        private const string ControlSize = "200";
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string Count = "Count";
        private const string Sum = "Sum";
        private const string Avg = "Avg";
        private const string InternalName = "InternalName";
        private const string DisplayName = "DisplayName";
        private const string ColorBlue = "Blue";
        private const string FormatPercentage = "Percentage";
        private const string FormatCurrency = "Currency";
        private const string NoValueSpecified = "No Value Specified";
        private const string FormatStringPercentage = "p";
        private const string FormatStringCurrency = "c";
        private const string FormatStringNone = "n";
        private const string ColumnSharePointType = "SharePointType";
        private const string ColumnTitle = "Title";
        private const string BubbleAxisColumn = "BubbleAxis";
        private const string CategorySqlColumn = "CategorySql";
        private const string FieldRadChart = "_radChart";
        private const string MethodOnInit = "OnInit";
        private const string MethodGetSeriesItems = "GetSeriesItems";
        private const string MethodGetDataForBubbleSeries = "GetDataForBubbleSeries";
        private readonly Guid DummyGuid = Guid.NewGuid();
        private RC.ReportingChart _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private ShimSPWeb _shimWeb;
        private ShimSPListCollection _shimListCollection;
        private ShimSPList _shimList;
        private ShimSPFieldCollection _shimFields;
        private ShimSPViewCollection _shimViews;
        private StringBuilder _stringBuilder;
        private StringWriter _stringWriter;
        private HtmlTextWriter _htmlWriter;
        private bool _webClosed;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();

            ShimSharePointContext();
            SetHttpContext();
            ShimQueryExecutor.AllInstances.ExecuteReportingDBQueryStringIDictionaryOfStringObject =
                (a, b, c) => GetDataTable();
            ShimQueryExecutor.ConstructorSPWeb = (_, __) => { };

            _testObject = new RC.ReportingChart
            {
                Page = new Page()
            };
            _privateObject = new PrivateObject(_testObject);

            _stringBuilder = new StringBuilder();
            _stringWriter = new StringWriter(_stringBuilder);
            _htmlWriter = new HtmlTextWriter(_stringWriter);
            _webClosed = false;

            _privateObject.Invoke(MethodOnInit, new object[] { EventArgs.Empty });
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _stringWriter?.Dispose();
            _htmlWriter?.Dispose();
        }

        [TestMethod]
        public void RenderControl_Invoke_WritesJavaScriptForDialog()
        {
            // Arrange
            _testObject.PropChartType = ChartType.Area;
            _testObject.PropYaxisFormat = FormatPercentage;
            _testObject.Width = ControlSize;
            _testObject.Height = ControlSize;
            _testObject.RebuildControlTree();
            var baseRenderCalled = false;
            ShimControl.AllInstances.RenderControlHtmlTextWriter = (_, __) => { baseRenderCalled = true; };

            // Act
            _testObject.RenderControl(_htmlWriter);

            // Assert
            var result = _stringBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => baseRenderCalled.ShouldBeTrue(),
                () => result.ShouldContain("<div id='divWizardBox' style='width:100%;text-align:center'>"),
                () => result.ShouldContain("<a onclick='loadChartWizard();' style='text-decoration:none;width:150px;'>"),
                () => result.ShouldContain("<div class='wizardBox'></div>"),
                () => result.ShouldContain("function loadChartWizard()"),
                () => result.ShouldContain("var tag = document.getElementsByTagName('object');"),
                () => result.ShouldContain("for(var i = tag.length-1;i>=0;i--)"),
                () => result.ShouldContain("tag[i].style.display='none';"),
                () => result.ShouldContain("SP.UI.ModalDialog.showModalDialog(options);"));
        }

        [TestMethod]
        public void CreateChildControls_SelectedListPercentage_BuildsChart()
        {
            // Arrange
            _testObject.PropChartSelectedListTitle = DummyString;
            _testObject.PropYaxisFormat = FormatPercentage;
            _testObject.PropChartShowGridlines = true;

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            var chart = GetRadChartFromControls();
            this.ShouldSatisfyAllConditions(
                () => _testObject.UpdatePanelClientId.ShouldNotBeNullOrEmpty(),
                () => _testObject.RadChartClientId.ShouldNotBeNullOrEmpty(),
                () => _testObject.Controls.Count.ShouldBe(2),
                () => chart.ShouldNotBeNull(),
                () => chart.PlotArea.YAxis.LabelsAppearance.DataFormatString.ShouldBe(FormatStringPercentage),
                () => chart.PlotArea.XAxis.MajorGridLines.Visible.ShouldBeTrue(),
                () => chart.PlotArea.XAxis.MinorGridLines.Visible.ShouldBeTrue(),
                () => chart.PlotArea.YAxis.MajorGridLines.Visible.ShouldBeTrue(),
                () => chart.PlotArea.YAxis.MinorGridLines.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void CreateChildControls_SelectedListCurrency_BuildsChart()
        {
            // Arrange
            _testObject.PropChartSelectedListTitle = DummyString;
            _testObject.PropYaxisFormat = FormatCurrency;
            _testObject.PropChartShowGridlines = true;

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            var chart = GetRadChartFromControls();
            this.ShouldSatisfyAllConditions(
                () => _testObject.UpdatePanelClientId.ShouldNotBeNullOrEmpty(),
                () => _testObject.RadChartClientId.ShouldNotBeNullOrEmpty(),
                () => _testObject.Controls.Count.ShouldBe(2),
                () => chart.ShouldNotBeNull(),
                () => chart.PlotArea.YAxis.LabelsAppearance.DataFormatString.ShouldBe(FormatStringCurrency),
                () => chart.PlotArea.XAxis.MajorGridLines.Visible.ShouldBeTrue(),
                () => chart.PlotArea.XAxis.MinorGridLines.Visible.ShouldBeTrue(),
                () => chart.PlotArea.YAxis.MajorGridLines.Visible.ShouldBeTrue(),
                () => chart.PlotArea.YAxis.MinorGridLines.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void CreateChildControls_SelectedList_BuildsChart()
        {
            // Arrange
            _testObject.PropChartSelectedListTitle = DummyString;
            _testObject.PropChartShowGridlines = true;

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            var chart = GetRadChartFromControls();
            this.ShouldSatisfyAllConditions(
                () => _testObject.UpdatePanelClientId.ShouldNotBeNullOrEmpty(),
                () => _testObject.RadChartClientId.ShouldNotBeNullOrEmpty(),
                () => _testObject.Controls.Count.ShouldBe(2),
                () => chart.ShouldNotBeNull(),
                () => chart.PlotArea.YAxis.LabelsAppearance.DataFormatString.ShouldBe(FormatStringNone),
                () => chart.PlotArea.XAxis.MajorGridLines.Visible.ShouldBeTrue(),
                () => chart.PlotArea.XAxis.MinorGridLines.Visible.ShouldBeTrue(),
                () => chart.PlotArea.YAxis.MajorGridLines.Visible.ShouldBeTrue(),
                () => chart.PlotArea.YAxis.MinorGridLines.Visible.ShouldBeTrue());
        }

        [TestMethod]
        public void CreateChildControls_SelectedListNoGridLines_BuildsChart()
        {
            // Arrange
            _testObject.PropChartSelectedListTitle = DummyString;
            _testObject.PropChartShowGridlines = false;

            // Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            var chart = GetRadChartFromControls();
            this.ShouldSatisfyAllConditions(
                () => _testObject.UpdatePanelClientId.ShouldNotBeNullOrEmpty(),
                () => _testObject.RadChartClientId.ShouldNotBeNullOrEmpty(),
                () => _testObject.Controls.Count.ShouldBe(2),
                () => chart.ShouldNotBeNull(),
                () => chart.PlotArea.YAxis.LabelsAppearance.DataFormatString.ShouldBe(FormatStringNone),
                () => chart.PlotArea.XAxis.MajorGridLines.Visible.ShouldBeFalse(),
                () => chart.PlotArea.XAxis.MinorGridLines.Visible.ShouldBeFalse(),
                () => chart.PlotArea.YAxis.MajorGridLines.Visible.ShouldBeFalse(),
                () => chart.PlotArea.YAxis.MinorGridLines.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void BuildSeries_AreaMultipleCategory_SetsAreaSeries()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Area);
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTableWithMultipleCategories();

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertAreaSeries(chart.PlotArea.Series[0]));
        }

        [TestMethod]
        public void BuildSeries_AreaPercentage_SetsAreaSeries()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Area);
            _testObject.PropYaxisFormat = FormatPercentage;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertAreaSeries(chart.PlotArea.Series[0]));
        }

        [TestMethod]
        public void BuildSeries_AreaCurrency_SetsAreaSeries()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Area);
            _testObject.PropYaxisFormat = FormatCurrency;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertAreaSeries(chart.PlotArea.Series[0], format: FormatStringCurrency));
        }

        [TestMethod]
        public void BuildSeries_AreaSum_SetsAreaSeriesWithCategoryColumnName()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Area);
            _testObject.PropChartAggregationType = Sum;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertAreaSeries(chart.PlotArea.Series[0], CategorySqlColumn));
        }

        [TestMethod]
        public void BuildSeries_AreaAvg_SetsAreaSeriesWithCategoryColumnName()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Area);
            _testObject.PropChartAggregationType = Avg;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertAreaSeries(chart.PlotArea.Series[0], CategorySqlColumn));
        }

        [TestMethod]
        public void BuildSeries_AreaClustered_SetsAreaSeriesWithCategoryValue()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Area_Clustered);

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertAreaSeries(chart.PlotArea.Series[0], One));
        }

        [TestMethod]
        public void BuildSeries_AreaClusteredWithNullCategory_SetsAreaSeriesWithCategoryValue()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Area_Clustered);
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTableWithNullCategory();

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertAreaSeries(chart.PlotArea.Series[0], One));
        }

        [TestMethod]
        public void BuildSeries_AreaClusteredSum_SetsAreaSeriesWithCategoryColumnName()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Area_Clustered);
            _testObject.PropChartAggregationType = Sum;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertAreaSeries(chart.PlotArea.Series[0], CategorySqlColumn));
        }

        [TestMethod]
        public void BuildSeries_AreaClusteredAvg_SetsAreaSeriesWithCategoryColumnName()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Area_Clustered);
            _testObject.PropChartAggregationType = Avg;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertAreaSeries(chart.PlotArea.Series[0], CategorySqlColumn));
        }

        [TestMethod]
        public void BuildSeries_BarPercentage_SetsBarSeries()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bar);

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBarSeries(chart.PlotArea.Series[0]));
        }

        [TestMethod]
        public void BuildSeries_BarCurrency_SetsBarSeries()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bar);
            _testObject.PropYaxisFormat = FormatCurrency;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBarSeries(chart.PlotArea.Series[0], format: FormatStringCurrency));
        }

        [TestMethod]
        public void BuildSeries_BarClustered_SetsStackedBarSeriesWithCategoryValue()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bar_Clustered);

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBarSeries(chart.PlotArea.Series[0], false, One));
        }

        [TestMethod]
        public void BuildSeries_BarStacked_SetsStackedBarSeriesWithCategoryValue()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bar_Stacked);

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBarSeries(chart.PlotArea.Series[0], true, One));
        }

        [TestMethod]
        public void BuildSeries_Bar100Percent_SetsStackedBarSeriesWithCategoryValue()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bar_100Percent);

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBarSeries(chart.PlotArea.Series[0], true, One));
        }

        [TestMethod]
        public void BuildSeries_Bar100PercentWithNullCategory_SetsStackedBarSeriesWithCategoryValue()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bar_100Percent);
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTableWithNullCategory();

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBarSeries(chart.PlotArea.Series[0], true, One));
        }

        [TestMethod]
        public void BuildSeries_Bar100PercentSum_SetsStackedBarSeriesWithCategoryColumnName()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bar_100Percent);
            _testObject.PropChartAggregationType = Sum;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBarSeries(chart.PlotArea.Series[0], true, CategorySqlColumn));
        }

        [TestMethod]
        public void BuildSeries_Bar100PercentSumWithNullCategory_SetsStackedBarSeriesWithCategoryColumnName()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bar_100Percent);
            _testObject.PropChartAggregationType = Sum;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTableWithNullCategory();

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBarSeries(chart.PlotArea.Series[0], true, CategorySqlColumn));
        }

        [TestMethod]
        public void BuildSeries_Bar100PercentAvg_SetsStackedBarSeriesWithCategoryColumnName()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bar_100Percent);
            _testObject.PropChartAggregationType = Avg;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBarSeries(chart.PlotArea.Series[0], true, CategorySqlColumn));
        }

        [TestMethod]
        public void BuildSeries_Bar100PercentAvgWithNullCategory_SetsStackedBarSeriesWithCategoryColumnName()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bar_100Percent);
            _testObject.PropChartAggregationType = Avg;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTableWithNullCategory();

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBarSeries(chart.PlotArea.Series[0], true, CategorySqlColumn));
        }

        [TestMethod]
        public void BuildSeries_BubbleNoFormat_SetsBubbleSeriesWithNoFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bubble);
            _testObject.PropYaxisFormat = string.Empty;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBubbleSeries(chart.PlotArea.Series[0], string.Empty));
        }

        [TestMethod]
        public void BuildSeries_BubbleDummyFormat_SetsBubbleSeriesWithDefaultFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bubble);
            _testObject.PropYaxisFormat = DummyString;

            // Act
            _testObject.BuildSeries();

            // Assert
            var format = $"{DummyString} = {{0}} <br/>{DummyString} = {{1}} <br/>{DummyString} = {{2}} <br/>Title = {{3}}";
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBubbleSeries(chart.PlotArea.Series[0], format));
        }

        [TestMethod]
        public void BuildSeries_BubblePercentage_SetsBubbleSeriesWithPercentageFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bubble);
            _testObject.PropYaxisFormat = FormatPercentage;

            // Act
            _testObject.BuildSeries();

            // Assert
            var format = $"{DummyString} = {{0:p}} <br/>{DummyString} = {{1:p}} <br/>{DummyString} = {{2:p}} <br/>Title = {{3}}";
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBubbleSeries(chart.PlotArea.Series[0], format));
        }

        [TestMethod]
        public void BuildSeries_BubbleNoGroupBy_SetsBubbleSeriesWithPercentageFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bubble);
            _testObject.PropBubbleChartGroupBy = "none";

            // Act
            _testObject.BuildSeries();

            // Assert
            var format = $"{DummyString} = {{0:p}} <br/>{DummyString} = {{1:p}} <br/>{DummyString} = {{2:p}} <br/>Title = {{3}}";
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBubbleSeries(chart.PlotArea.Series[0], format));
        }

        [TestMethod]
        public void BuildSeries_BubbleNullCategory_SetsBubbleSeriesWithPercentageFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bubble);
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTableWithNullCategory();

            // Act
            _testObject.BuildSeries();

            // Assert
            var format = $"{DummyString} = {{0:p}} <br/>{DummyString} = {{1:p}} <br/>{DummyString} = {{2:p}} <br/>Title = {{3}}";
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBubbleSeries(chart.PlotArea.Series[0], format, NoValueSpecified));
        }

        [TestMethod]
        public void BuildSeries_BubbleCurrency_SetsBubbleSeriesWithCurrencyFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Bubble);
            _testObject.PropYaxisFormat = FormatCurrency;

            // Act
            _testObject.BuildSeries();

            // Assert
            var format = $"{DummyString} = {{0:c}} <br/>{DummyString} = {{1:c}} <br/>{DummyString} = {{2:c}} <br/>Title = {{3}}";
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertBubbleSeries(chart.PlotArea.Series[0], format));
        }

        [TestMethod]
        public void BuildSeries_ColumnPercentage_SetsColumnSeriesWithPercentageFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Column);
            _testObject.PropYaxisFormat = FormatPercentage;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertColumnSeries(chart.PlotArea.Series[0], FormatStringPercentage));
        }

        [TestMethod]
        public void BuildSeries_ColumnCurrency_SetsColumnSeriesWithCurrencyFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Column);
            _testObject.PropYaxisFormat = FormatCurrency;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertColumnSeries(chart.PlotArea.Series[0], FormatStringCurrency));
        }

        [TestMethod]
        public void BuildSeries_ColumnClustered_SetsStackedColumnSeriesWithCategoryValue()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Column_Clustered);

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertStackedColumnSeries(chart.PlotArea.Series[0], One, false));
        }

        [TestMethod]
        public void BuildSeries_ColumnStacked_SetsStackedColumnSeriesWithCategoryValue()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Column_Stacked);

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertStackedColumnSeries(chart.PlotArea.Series[0], One));
        }

        [TestMethod]
        public void BuildSeries_Column100Percent_SetsStackedColumnSeriesWithCategoryValue()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Column_100Percent);

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertStackedColumnSeries(chart.PlotArea.Series[0], One));
        }

        [TestMethod]
        public void BuildSeries_DonutPercentage_SetsDonutSeriesWithPercentageFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Donut);
            _testObject.PropYaxisFormat = FormatPercentage;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertDonutSeries(chart.PlotArea.Series[0], FormatStringPercentage));
        }

        [TestMethod]
        public void BuildSeries_DonutCurrency_SetsDonutSeriesWithCurrencyFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Donut);
            _testObject.PropYaxisFormat = FormatCurrency;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertDonutSeries(chart.PlotArea.Series[0], FormatStringCurrency),
                () => chart.PlotArea.XAxis.MajorGridLines.Visible.ShouldBeFalse(),
                () => chart.PlotArea.XAxis.MinorGridLines.Visible.ShouldBeFalse(),
                () => chart.PlotArea.YAxis.MajorGridLines.Visible.ShouldBeFalse(),
                () => chart.PlotArea.YAxis.MinorGridLines.Visible.ShouldBeFalse());
        }

        [TestMethod]
        public void BuildSeries_DonutSum_SetsDonutSeriesWithCategoryColumnName()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Donut);
            _testObject.PropChartAggregationType = Sum;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertDonutSeries(chart.PlotArea.Series[0], seriesName: CategorySqlColumn));
        }

        [TestMethod]
        public void BuildSeries_DonutAvg_SetsDonutSeriesWithCategoryColumnName()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Donut);
            _testObject.PropChartAggregationType = Avg;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertDonutSeries(chart.PlotArea.Series[0], seriesName: CategorySqlColumn));
        }

        [TestMethod]
        public void BuildSeries_LinePercentage_SetsLineSeriesWithPercentageFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Line);
            _testObject.PropYaxisFormat = FormatPercentage;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertLineSeries(chart.PlotArea.Series[0]));
        }

        [TestMethod]
        public void BuildSeries_LineCurrency_SetsLineSeriesWithCurrencyFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Line);
            _testObject.PropYaxisFormat = FormatCurrency;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertLineSeries(chart.PlotArea.Series[0], FormatStringCurrency));
        }

        [TestMethod]
        public void BuildSeries_LineClustered_SetsLineSeriesWithCategoryValue()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Line_Clustered);

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertLineSeries(chart.PlotArea.Series[0], seriesName: One));
        }

        [TestMethod]
        public void BuildSeries_Pie_SetsPieSeriesWithPercentageFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Pie);
            _testObject.PropYaxisFormat = FormatPercentage;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertPieSeries(chart.PlotArea.Series[0]));
        }

        [TestMethod]
        public void BuildSeries_Pie_SetsPieSeriesWithCurrencyFormat()
        {
            // Arrange
            var chart = SetPropertiesForSeriesType(ChartType.Pie);
            _testObject.PropYaxisFormat = FormatCurrency;

            // Act
            _testObject.BuildSeries();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertPieSeries(chart.PlotArea.Series[0], FormatStringCurrency));
        }

        [TestMethod]
        public void GetSeriesItems_NoSelectedItem_ReturnsEmpty()
        {
            // Arrange
            _testObject.PropChartSelectedListTitle = null;
            _testObject.PropChartSelectedViewTitle = null;

            // Act
            var result = _privateObject.Invoke(MethodGetSeriesItems);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeOfType<Dictionary<string, List<SeriesItem>>>(),
                () => ((Dictionary<string, List<SeriesItem>>)result).ShouldBeEmpty());
        }

        [TestMethod]
        public void GetSeriesItems_Get_ReturnsSeriesDictionary()
        {
            // Arrange
            var queriesMerged = false;
            _testObject.PropChartSelectedListTitle = DummyString;
            _testObject.PropChartSelectedViewTitle = DummyString;
            _testObject.PropChartType = ChartType.Area;
            _testObject.PropChartAggregationType = Sum;
            _testObject.PropChartXaxisField = DummyString;
            _testObject.PropChartYaxisField = CategorySqlColumn;
            _testObject.ReportIDConsumer(new WP.ReportingFilter
            {
                ID = Guid.NewGuid().ToString()
            });
            ShimTitleFilterQueryService.AllInstances.MergeExistingQueryWithTitleQuerySPListGuidXmlDocumentRef =
                (TitleFilterQueryService a, SPList b, Guid c, ref XmlDocument d) => { queriesMerged = true; };
            ShimReportBiz.AllInstances.SiteExists = _ => true;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTable();

            // Act
            var result = _privateObject.Invoke(MethodGetSeriesItems);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => queriesMerged.ShouldBeTrue(),
                () => result.ShouldNotBeNull(),
                () => result.ShouldBeOfType<Dictionary<string, List<SeriesItem>>>(),
                () => AssertSeriesDictionary((Dictionary<string, List<SeriesItem>>)result));
        }

        //[TestMethod]
        //public void GetDataForBubbleSeries_()
        //{
        //    // Arrange

        //    // Act
        //    var result = _privateObject.Invoke(MethodGetDataForBubbleSeries, new object[] { GetDataTable(), DummyString, CategorySqlColumn, CategorySqlColumn, "none" });

        //    // Assert
        //}

        private RadHtmlChart SetPropertiesForSeriesType(ChartType type)
        {
            var chart = new RadHtmlChart();
            _privateObject.SetFieldOrProperty(FieldRadChart, chart);
            _testObject.PropChartSelectedListTitle = DummyString;
            _testObject.PropChartSelectedViewTitle = DummyString;
            _testObject.PropChartAggregationType = Count;
            _testObject.PropChartSelectedPaletteName = ColorBlue;
            _testObject.PropYaxisFormat = FormatPercentage;
            _testObject.PropChartType = type;
            _testObject.PropChartXaxisFieldLabel = DummyString;
            _testObject.PropChartYaxisFieldLabel = DummyString;
            _testObject.PropChartZaxisFieldLabel = DummyString;

            if (type == ChartType.Bubble)
            {
                _testObject.PropChartXaxisField = BubbleAxisColumn;
                _testObject.PropChartYaxisField = BubbleAxisColumn;
                _testObject.PropChartZaxisField = BubbleAxisColumn;
                _testObject.PropBubbleChartGroupBy = DummyString;
            }
            else
            {
                _testObject.PropChartXaxisField = DummyString;
                _testObject.PropChartYaxisField = CategorySqlColumn;
            }

            ShimReportBiz.AllInstances.SiteExists = _ => true;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTable();
            return chart;
        }

        private void AssertAreaSeries(SeriesBase series, string seriesName = DummyString, string format = FormatStringPercentage)
        {
            var area = series as AreaSeries;
            series.ShouldSatisfyAllConditions(
                () => series.Name.ShouldBe(seriesName),
                () => series.Items.Count.ShouldBe(1),
                () => area.ShouldNotBeNull(),
                () => area.LabelsAppearance.Position.ShouldBe(LineAndScatterLabelsPosition.Above),
                () => area.LabelsAppearance.DataFormatString.ShouldBe(format),
                () => area.TooltipsAppearance.DataFormatString.ShouldBe(format));
        }

        private void AssertBarSeries(SeriesBase series, bool stacked = false, string seriesName = DummyString, string format = FormatStringPercentage)
        {
            var position = stacked ? BarColumnLabelsPosition.Center : BarColumnLabelsPosition.OutsideEnd;
            var area = series as BarSeries;
            series.ShouldSatisfyAllConditions(
                () => series.Name.ShouldBe(seriesName),
                () => series.Items.Count.ShouldBe(1),
                () => area.ShouldNotBeNull(),
                () => area.LabelsAppearance.DataFormatString.ShouldBe(format),
                () => area.TooltipsAppearance.DataFormatString.ShouldBe(format),
                () => area.Stacked.ShouldBe(stacked),
                () => area.LabelsAppearance.Position.ShouldBe(position));
        }

        private void AssertBubbleSeries(SeriesBase series, string format, string seriesName = DummyString)
        {
            var area = series as BubbleSeries;
            series.ShouldSatisfyAllConditions(
                () => series.Name.ShouldBe(seriesName),
                () => series.Items.Count.ShouldBe(1),
                () => area.ShouldNotBeNull(),
                () => area.TooltipsAppearance.DataFormatString.ShouldBe(format));
        }

        private void AssertColumnSeries(SeriesBase series, string format)
        {
            var area = series as ColumnSeries;
            series.ShouldSatisfyAllConditions(
                () => series.Name.ShouldBe(DummyString),
                () => series.Items.Count.ShouldBe(1),
                () => area.ShouldNotBeNull(),
                () => area.LabelsAppearance.DataFormatString.ShouldBe(format),
                () => area.TooltipsAppearance.DataFormatString.ShouldBe(format),
                () => area.Stacked.ShouldBeFalse(),
                () => area.LabelsAppearance.Position.ShouldBe(BarColumnLabelsPosition.OutsideEnd));
        }

        private void AssertStackedColumnSeries(SeriesBase series, string seriesName = DummyString, bool stacked = true)
        {
            var position = stacked ? BarColumnLabelsPosition.InsideEnd : BarColumnLabelsPosition.OutsideEnd;
            var area = series as ColumnSeries;
            series.ShouldSatisfyAllConditions(
                () => series.Name.ShouldBe(seriesName),
                () => series.Items.Count.ShouldBe(1),
                () => area.ShouldNotBeNull(),
                () => area.LabelsAppearance.DataFormatString.ShouldBe(FormatStringPercentage),
                () => area.TooltipsAppearance.DataFormatString.ShouldBe(FormatStringPercentage),
                () => area.Stacked.ShouldBe(stacked),
                () => area.LabelsAppearance.Position.ShouldBe(position));
        }

        private void AssertDonutSeries(SeriesBase series, string format = FormatStringPercentage, string seriesName = DummyString)
        {
            var area = series as DonutSeries;
            series.ShouldSatisfyAllConditions(
                () => series.Name.ShouldBe(seriesName),
                () => series.Items.Count.ShouldBe(1),
                () => area.ShouldNotBeNull(),
                () => area.LabelsAppearance.Position = PieLabelsPosition.Column,
                () => area.LabelsAppearance.DataFormatString.ShouldBe(format),
                () => area.TooltipsAppearance.DataFormatString.ShouldBe($"{seriesName} = {{0:{format}}}"));
        }

        private void AssertLineSeries(SeriesBase series, string format = FormatStringPercentage, string seriesName = DummyString)
        {
            var area = series as LineSeries;
            series.ShouldSatisfyAllConditions(
                () => series.Name.ShouldBe(seriesName),
                () => series.Items.Count.ShouldBe(1),
                () => area.ShouldNotBeNull(),
                () => area.LabelsAppearance.DataFormatString.ShouldBe(format),
                () => area.TooltipsAppearance.DataFormatString.ShouldBe(format));
        }

        private void AssertPieSeries(SeriesBase series, string format = FormatStringPercentage, string seriesName = DummyString)
        {
            var area = series as PieSeries;
            series.ShouldSatisfyAllConditions(
                () => series.Name.ShouldBe(seriesName),
                () => series.Items.Count.ShouldBe(1),
                () => area.ShouldNotBeNull(),
                () => area.LabelsAppearance.DataFormatString.ShouldBe(format),
                () => area.TooltipsAppearance.DataFormatString.ShouldBe(format));
        }

        private void AssertSeriesDictionary(Dictionary<string, List<SeriesItem>> series)
        {
            series.ShouldSatisfyAllConditions(
                () => series.Count.ShouldBe(1),
                () => series.Keys.First().ShouldBe(CategorySqlColumn),
                () => series.Values.First().Count.ShouldBe(1),
                () => AssertSeriesItem(series.Values.First().First()));
        }

        private void AssertSeriesItem(SeriesItem item)
        {
            item.ShouldSatisfyAllConditions(
                () => item.Name.ShouldBeEmpty(),
                () => item.YValue.ShouldBe(1));
        }

        private DataTable CreateDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(DummyString);
            dataTable.Columns.Add($"{DummyString}Text");
            dataTable.Columns.Add(InternalName);
            dataTable.Columns.Add(DisplayName);
            dataTable.Columns.Add(ColumnSharePointType);
            dataTable.Columns.Add(ColumnTitle);
            dataTable.Columns.Add(BubbleAxisColumn);
            dataTable.Columns.Add(CategorySqlColumn);
            return dataTable;
        }

        private DataTable GetDataTable(string spType = DummyString)
        {
            var dataTable = CreateDataTable();
            dataTable.Rows.Add(DummyString, DummyString, DummyString, DummyString, spType, DummyString, One, One);
            return dataTable;
        }

        private DataTable GetDataTableWithNullCategory(string spType = DummyString)
        {
            var dataTable = CreateDataTable();
            dataTable.Rows.Add(DBNull.Value, DummyString, DummyString, DummyString, spType, DummyString, One, One);
            return dataTable;
        }

        private DataTable GetDataTableWithMultipleCategories(string spType = DummyString)
        {
            var dataTable = CreateDataTable();
            dataTable.Rows.Add($"{DummyString},{DummyString}", DummyString, DummyString, DummyString, spType, DummyString, One, One);
            return dataTable;
        }

        private RadHtmlChart GetRadChartFromControls()
        {
            if (_testObject.Controls.Count > 0)
            {
                var panel = _testObject.Controls[0] as UpdatePanel;
                if (panel?.ContentTemplateContainer.Controls.Count > 0)
                {
                    return panel?.ContentTemplateContainer.Controls[0] as RadHtmlChart;
                }
            }

            return null;
        }

        private void SetHttpContext()
        {
            HttpContext.Current = new HttpContext(
                new HttpRequest(string.Empty, ExampleUrl, string.Empty),
                new HttpResponse(_stringWriter));
        }

        private void ShimSharePointContext()
        {
            ShimSPFieldCollectionMethods();
            ShimSPViewCollectionMethods();
            ShimSPListMethods();
            ShimSPListCollectionMethods();
            ShimSPWebMethods();
            var site = ShimSPSiteMethods();

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => _shimWeb.Instance,
                SiteGet = () => site.Instance
            }.Instance;

            ShimSPSite.ConstructorGuid = (_, __) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _shimWeb;
            ShimTemplateBasedControl.AllInstances.WebGet = _ => _shimWeb;
        }

        private void ShimSPViewCollectionMethods()
        {
            var query = $@"<Where><Child>
                                <FieldRef Name=""{DummyString}""/>
                                <Values>
                                    <Value>{DummyString}</Value>
                                </Values>
                            </Child></Where>
                            <OrderBy>
                                <FieldRef Name=""{DummyString}"" Ascending=""false""/>
                            </OrderBy>";
            var _shimView = new ShimSPView
            {
                QueryGet = () => query//.Replace("\r\n", string.Empty).Replace("  ", string.Empty)
            };
            _shimViews = new ShimSPViewCollection
            {
                ItemGetString = _ => _shimView,
                
            };
        }

        private ShimSPSite ShimSPSiteMethods()
        {
            var site = new ShimSPSite
            {
                IDGet = () => DummyGuid,
                RootWebGet = () => _shimWeb.Instance,
                WebApplicationGet = () => new ShimSPWebApplication
                {
                    ApplicationPoolGet = () => new SPApplicationPool()
                }.Instance
            };
            _shimWeb.SiteGet = () => site.Instance;
            return site;
        }

        private void ShimSPFieldCollectionMethods()
        {
            _shimFields = new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = _ => new ShimSPField()
                {
                    TitleGet = () => DummyString,
                    InternalNameGet = () => DummyString,
                    TypeGet = () => SPFieldType.User
                }.Instance
            };
            
            ShimSPField.AllInstances.TitleGet = _ => DummyString;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
        }

        private void ShimSPWebMethods()
        {
            var user = new ShimSPUser
            {
                IDGet = () => Id
            };

            _shimWeb = new ShimSPWeb
            {
                IDGet = () => DummyGuid,
                CurrentUserGet = () => user,
                EnsureUserString = _ => user,
                SiteUserInfoListGet = () => _shimList.Instance,
                ListsGet = () => _shimListCollection.Instance,
                Close = () => { _webClosed = true; },
                UrlGet = () => ExampleUrl,
                LocaleGet = () => CultureInfo.InvariantCulture
            };
        }

        private void ShimSPListCollectionMethods()
        {
            _shimListCollection = new ShimSPListCollection
            {
                ItemGetString = _ => _shimList,
                ItemGetGuid = _ => _shimList,
                GetListGuidBoolean = (_, __) => _shimList,
                TryGetListString = list => _shimList.Instance
            };
        }

        private void ShimSPListMethods()
        {
            _shimList = new ShimSPList
            {
                IDGet = () => DummyGuid,
                ItemsGet = () => new ShimSPListItemCollection
                {
                    GetEnumerator = () => new List<SPListItem> { GetListItem() }.GetEnumerator(),
                    GetDataTable = () => new DataTable()
                },
                FieldsGet = () => _shimFields.Instance,
                ParentWebGet = () => _shimWeb,
                ViewsGet = () => _shimViews
            };
        }

        private ShimSPListItem GetListItem()
        {
            return new ShimSPListItem()
            {
                IDGet = () => Id,
                ItemGetGuid = _ => DummyString,
                ItemGetString = _ => DummyString
            };
        }
    }
}
