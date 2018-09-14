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
using Shouldly;
using Telerik.Web.UI;
using Telerik.Web.UI.HtmlChart;
using RC = EPMLiveWebParts.ReportingChart;

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
        private const string InternalName = "InternalName";
        private const string DisplayName = "DisplayName";
        private const string FormatPercentage = "Percentage";
        private const string FormatCurrency = "Currency";
        private const string ColorBlue = "Blue";
        private const string FieldRadChart = "_radChart";
        private const string FormatStringPercentage = "p";
        private const string FormatStringCurrency = "c";
        private const string FormatStringNone = "n";
        private const string ColumnSharePointType = "SharePointType";
        private const string ColumnTitle = "Title";
        private const string BubbleAxisColumn = "BubbleAxis";
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

            _testObject = new RC.ReportingChart
            {
                Page = new Page()
            };
            _privateObject = new PrivateObject(_testObject);

            _stringBuilder = new StringBuilder();
            _stringWriter = new StringWriter(_stringBuilder);
            _htmlWriter = new HtmlTextWriter(_stringWriter);
            _webClosed = false;

            _privateObject.Invoke("OnInit", new object[] { EventArgs.Empty });
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
        public void BuildSeries_Area_()
        {
            // Arrange
            var chart = new RadHtmlChart();
            _privateObject.SetFieldOrProperty(FieldRadChart, chart);
            _testObject.PropChartSelectedListTitle = DummyString;
            _testObject.PropChartSelectedViewTitle = DummyString;
            _testObject.PropChartAggregationType = Count;
            _testObject.PropChartType = ChartType.Area;
            _testObject.PropChartXaxisField = DummyString;
            _testObject.PropChartSelectedPaletteName = ColorBlue;
            _testObject.PropYaxisFormat = FormatPercentage;
            ShimReportBiz.AllInstances.SiteExists = _ => true;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTable();

            // Act
            _testObject.BuildSeries();

            // Assert
            var serie = chart.PlotArea.Series[0];
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1),
                () => AssertAreaSeries(chart.PlotArea.Series[0]));
        }

        [TestMethod]
        public void BuildSeries_Bar_()
        {
            // Arrange
            var chart = new RadHtmlChart();
            _privateObject.SetFieldOrProperty(FieldRadChart, chart);
            _testObject.PropChartSelectedListTitle = DummyString;
            _testObject.PropChartSelectedViewTitle = DummyString;
            _testObject.PropChartAggregationType = Count;
            _testObject.PropChartType = ChartType.Bar;
            _testObject.PropChartXaxisField = DummyString;
            _testObject.PropChartSelectedPaletteName = ColorBlue;
            _testObject.PropYaxisFormat = FormatPercentage;
            ShimReportBiz.AllInstances.SiteExists = _ => true;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTable();

            // Act
            _testObject.BuildSeries();

            // Assert
            var serie = chart.PlotArea.Series[0];
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1)
                );
        }

        [TestMethod]
        public void BuildSeries_Bubble_()
        {
            // Arrange
            var chart = new RadHtmlChart();
            _privateObject.SetFieldOrProperty(FieldRadChart, chart);
            _testObject.PropChartSelectedListTitle = DummyString;
            _testObject.PropChartSelectedViewTitle = DummyString;
            _testObject.PropChartAggregationType = Count;
            _testObject.PropChartType = ChartType.Bubble;
            _testObject.PropChartSelectedPaletteName = ColorBlue;
            _testObject.PropYaxisFormat = FormatPercentage;
            _testObject.PropChartXaxisField = BubbleAxisColumn;
            _testObject.PropChartYaxisField = BubbleAxisColumn;
            _testObject.PropChartZaxisField = BubbleAxisColumn;
            _testObject.PropBubbleChartGroupBy = DummyString;
            ShimReportBiz.AllInstances.SiteExists = _ => true;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTable();

            // Act
            _testObject.BuildSeries();

            // Assert
            var serie = chart.PlotArea.Series[0];
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1)
                );
        }

        [TestMethod]
        public void BuildSeries_Column_()
        {
            // Arrange
            var chart = new RadHtmlChart();
            _privateObject.SetFieldOrProperty(FieldRadChart, chart);
            _testObject.PropChartSelectedListTitle = DummyString;
            _testObject.PropChartSelectedViewTitle = DummyString;
            _testObject.PropChartAggregationType = Count;
            _testObject.PropChartType = ChartType.Column;
            _testObject.PropChartXaxisField = DummyString;
            _testObject.PropChartSelectedPaletteName = ColorBlue;
            _testObject.PropYaxisFormat = FormatPercentage;
            ShimReportBiz.AllInstances.SiteExists = _ => true;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTable();

            // Act
            _testObject.BuildSeries();

            // Assert
            var serie = chart.PlotArea.Series[0];
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1)
                );
        }

        [TestMethod]
        public void BuildSeries_Donut_()
        {
            // Arrange
            var chart = new RadHtmlChart();
            _privateObject.SetFieldOrProperty(FieldRadChart, chart);
            _testObject.PropChartSelectedListTitle = DummyString;
            _testObject.PropChartSelectedViewTitle = DummyString;
            _testObject.PropChartAggregationType = Count;
            _testObject.PropChartType = ChartType.Donut;
            _testObject.PropChartXaxisField = DummyString;
            _testObject.PropChartSelectedPaletteName = ColorBlue;
            _testObject.PropYaxisFormat = FormatPercentage;
            ShimReportBiz.AllInstances.SiteExists = _ => true;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTable();

            // Act
            _testObject.BuildSeries();

            // Assert
            var serie = chart.PlotArea.Series[0];
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1)
                );
        }

        [TestMethod]
        public void BuildSeries_Line_()
        {
            // Arrange
            var chart = new RadHtmlChart();
            _privateObject.SetFieldOrProperty(FieldRadChart, chart);
            _testObject.PropChartSelectedListTitle = DummyString;
            _testObject.PropChartSelectedViewTitle = DummyString;
            _testObject.PropChartAggregationType = Count;
            _testObject.PropChartType = ChartType.Line;
            _testObject.PropChartXaxisField = DummyString;
            _testObject.PropChartSelectedPaletteName = ColorBlue;
            _testObject.PropYaxisFormat = FormatPercentage;
            ShimReportBiz.AllInstances.SiteExists = _ => true;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTable();

            // Act
            _testObject.BuildSeries();

            // Assert
            var serie = chart.PlotArea.Series[0];
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1)
                );
        }

        [TestMethod]
        public void BuildSeries_Pie_()
        {
            // Arrange
            var chart = new RadHtmlChart();
            _privateObject.SetFieldOrProperty(FieldRadChart, chart);
            _testObject.PropChartSelectedListTitle = DummyString;
            _testObject.PropChartSelectedViewTitle = DummyString;
            _testObject.PropChartAggregationType = Count;
            _testObject.PropChartType = ChartType.Pie;
            _testObject.PropChartXaxisField = DummyString;
            _testObject.PropChartSelectedPaletteName = ColorBlue;
            _testObject.PropYaxisFormat = FormatPercentage;
            ShimReportBiz.AllInstances.SiteExists = _ => true;
            ShimReportingData.GetReportingDataSPWebStringBooleanStringString =
                (a, b, c, d, e) => GetDataTable();

            // Act
            _testObject.BuildSeries();

            // Assert
            var serie = chart.PlotArea.Series[0];
            this.ShouldSatisfyAllConditions(
                () => chart.PlotArea.Series.Count.ShouldBe(1)
                );
        }

        private void AssertAreaSeries(SeriesBase series)
        {
            var area = series as AreaSeries;
            series.ShouldSatisfyAllConditions(
                () => series.Name.ShouldBe(DummyString),
                () => series.Items.Count.ShouldBe(1),
                () => area.ShouldNotBeNull(),
                () => area.LabelsAppearance.DataFormatString.ShouldBe(FormatStringPercentage),
                () => area.LabelsAppearance.Position.ShouldBe(LineAndScatterLabelsPosition.Above),
                () => area.TooltipsAppearance.DataFormatString.ShouldBe(FormatStringPercentage));
        }

        private DataTable GetDataTable(string spType = DummyString)
        {
            var dt = new DataTable();
            dt.Columns.Add(DummyString);
            dt.Columns.Add($"{DummyString}Text");
            dt.Columns.Add(InternalName);
            dt.Columns.Add(DisplayName);
            dt.Columns.Add(ColumnSharePointType);
            dt.Columns.Add(ColumnTitle);
            dt.Columns.Add(BubbleAxisColumn);
            dt.Rows.Add(DummyString, DummyString, DummyString, DummyString, spType, One);
            return dt;
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
