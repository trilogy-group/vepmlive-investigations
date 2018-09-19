using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EPMLiveWebParts.ReportingChart;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using RC = EPMLiveWebParts.ReportingChart;

namespace EPMLiveWebParts.Tests.ReportingChart
{
    [TestClass, ExcludeFromCodeCoverage]
    public class ReportingChartToolPartTests
    {
        private const int Id = 1;
        private const string DummyString = "DummyString";
        private const string One = "1";
        private const string ExampleUrl = "http://example.com";
        private const string ChartTypeArea = "Area";
        private const string ChartTypeBar = "Bar";
        private const string ChartTypeColumn = "Column";
        private const string ChartTypeLine = "Line";
        private const string ChartTypeBarClustered = "Bar_Clustered";
        private const string ChartTypeBar100Percent = "Bar_100Percent";
        private const string ChartTypePie = "Pie";
        private const string ChartTypeDonut = "Donut";
        private const string ChartTypeScatter = "Scatter";
        private const string ChartTypeBubble = "Bubble";
        private const string AggregationCount = "Count";
        private const string AggregationSum = "Sum";
        private const string AggregationAverage = "Avg";
        private const string MethodWriteJavascript = "WriteJavascript";
        private const string MethodOnInit = "OnInit";
        private const string MethodWriteConfigSectionHtml = "WriteConfigSectionHtml";
        private const string FieldChartTypeDropDownList = "ChartTypeDropDownList";
        private const string FieldAggregateTypeHtmlSelect = "AggregateTypeHtmlSelect";
        private const string DivXaxisSectionFull = "<div id='XaxisSection_full'>Category (X axis)<br><select>";
        private const string DivXaxisSectionFullHidden = "<div id='XaxisSection_full' style='display:none'>Category (X axis)<br><select>";
        private const string DivXaxisSectionDdlNum = "</div><div id='XaxisSection_ddl_num'>Value (X axis)<br><select>";
        private const string DivXaxisSectionDdlNumHidden = "</div><div id='XaxisSection_ddl_num' style='display:none'>Value (X axis)<br><select>";
        private const string DivXaxisSectionDdlNonnum = "</div><div id='XaxisSection_ddl_nonnum'>Category (X axis)<br><select>";
        private const string DivXaxisSectionDdlNonnumHidden = "</div><div id='XaxisSection_ddl_nonnum' style='display:none'>Category (X axis)<br><select>";
        private const string DivYAxisSectionDdl = "<tr><td><div id='YaxisSection_ddl'>Value (Y Axis) </br>";
        private const string DivYAxisSectionDdlHidden = "<tr><td><div id='YaxisSection_ddl' style='display:none'>Value (Y Axis) </br>";
        private const string DivYaxisSectionDdlNum = "Value (Y Axis) </br><div id='YaxisSection_ddl_num'><select>";
        private const string DivYaxisSectionDdlNumHidden = "Value (Y Axis) </br><div id='YaxisSection_ddl_num' style='display:none'><select>";
        private const string DivYaxisSectionDdlNonnum = "</select></div><div id='YaxisSection_ddl_nonnum'><select>";
        private const string DivYaxisSectionDdlNonnumHidden = "</select></div><div id='YaxisSection_ddl_nonnum' style='display:none'><select>";
        private const string DivYaxisSectionCbl = "<tr><td><div id='YaxisSection_cbl' >Series (Y Axis) </br>";
        private const string DivYaxisSectionCblHidden = "<tr><td><div id='YaxisSection_cbl' style='display:none'>Series (Y Axis) </br>";
        private const string DivYaxisSectionCblNum = "Series (Y Axis) </br>No fields found.<div id='YaxisSection_cbl_num'></div>";
        private const string DivYaxisSectionCblNumHidden = "Series (Y Axis) </br>No fields found.<div id='YaxisSection_cbl_num' style='display:none'></div>";
        private const string DivYaxisSectionCblNonnum = "</div><div id='YaxisSection_cbl_nonnum'></div>";
        private const string DivYaxisSectionCblNonnumHidden = "</div><div id='YaxisSection_cbl_nonnum' style='display:none'></div>";
        private const string DivYAxisFormatSection = "<tr><td><div id='YAxisFormatSection'>Y Axis Formatting<br><select>";
        private const string DivYAxisFormatSectionHidden = "<tr><td><div id='YAxisFormatSection' style='display:none'>Y Axis Formatting<br><select>";
        private const string DivZaxisSection = "</select></div></td></tr><tr><td><div id='ZaxisSection'>Size Value (Z Axis)<br/><select>";
        private const string DivZaxisSectionHidden = "</select></div></td></tr><tr><td><div id='ZaxisSection' style='display:none'>Size Value (Z Axis)<br/><select>";
        private const string DivGroupBy = "</select><br/>Group By<br/><select>";
        private const string CloseDivAndTable = "</select><br/></div></td></tr></table></div>";
        private ReportingChartToolPart _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private StringBuilder _htmlBuilder;
        private StringWriter _stringWriter;
        private HtmlTextWriter _htmlWriter;
        private ShimSPWeb _shimWeb;
        private RC.ReportingChart _reportingChart;

        private string _htmlResult;
        public string HtmlResult
        {
            get
            {
                if (string.IsNullOrEmpty(_htmlResult))
                {
                    _htmlResult = _htmlBuilder.ToString();
                }

                return _htmlResult;
            }
        }


        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testObject = new ReportingChartToolPart();
            _privateObject = new PrivateObject(_testObject);

            _privateObject.Invoke(MethodOnInit, new object[] { EventArgs.Empty });

            _htmlBuilder = new StringBuilder();
            _stringWriter = new StringWriter(_htmlBuilder);
            _htmlWriter = new HtmlTextWriter(_stringWriter);
            _htmlResult = string.Empty;

            ShimSharePointContext();
            _reportingChart = new RC.ReportingChart();

            ShimToolPart.AllInstances.ParentToolPaneGet = _ => new ShimToolPane
            {
                SelectedWebPartGet = () => _reportingChart
            };

            ShimControl.AllInstances.ClientIDGet = control =>
            {
                foreach (var field in _testObject.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if (field.GetValue(_testObject) == control)
                    {
                        return field.Name;
                    }
                }

                return DummyString;
            };
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _stringWriter?.Dispose();
            _htmlWriter?.Dispose();
        }

        [TestMethod]
        public void WriteConfigSectionHtml_Invoke_WritesTypesDropDowns()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            HtmlResult.ShouldSatisfyAllConditions(
                () => HtmlResult.ShouldContain("<div class=\"UserSectionHead\"><b>Chart Configuration</b><br /><table cellpadding=1 style=\"padding-left: 5px\">"),
                () => HtmlResult.ShouldContain("<tr><td>List<br><select>"),
                () => HtmlResult.ShouldContain("</td></tr><tr><td>Chart Type<br><select>"),
                () => HtmlResult.ShouldContain("</td></tr><tr><td><div id=\"aggTypeSec\" display='none'>Aggregation Type<br><select"),
                () => HtmlResult.ShouldContain("<br></div></td></tr>"));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_AreaCount_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeArea);
            SetAggregateTypeHtmlSelectValue(AggregationCount);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertStandardCountXAxis(),
                () => AssertStandardCountOneYAxis(),
                () => AssertStandardCountMultipleYAxis(),
                () => AssertHtmlEnd(false));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_AreaSum_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeArea);
            SetAggregateTypeHtmlSelectValue(AggregationSum);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertStandardSumOrAverageXAxis(),
                () => AssertStandardSumOrAverageOneYAxis(),
                () => AssertStandardSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_AreaAverage_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeArea);
            SetAggregateTypeHtmlSelectValue(AggregationAverage);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertStandardSumOrAverageXAxis(),
                () => AssertStandardSumOrAverageOneYAxis(),
                () => AssertStandardSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_BarCount_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeBar);
            SetAggregateTypeHtmlSelectValue(AggregationCount);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertStandardCountXAxis(),
                () => AssertStandardCountOneYAxis(),
                () => AssertStandardCountMultipleYAxis(),
                () => AssertHtmlEnd(false));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_BarSum_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeBar);
            SetAggregateTypeHtmlSelectValue(AggregationSum);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertStandardSumOrAverageXAxis(),
                () => AssertStandardSumOrAverageOneYAxis(),
                () => AssertStandardSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_BarAverage_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeBar);
            SetAggregateTypeHtmlSelectValue(AggregationAverage);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertStandardSumOrAverageXAxis(),
                () => AssertStandardSumOrAverageOneYAxis(),
                () => AssertStandardSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_ColumnCount_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeColumn);
            SetAggregateTypeHtmlSelectValue(AggregationCount);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertStandardCountXAxis(),
                () => AssertStandardCountOneYAxis(),
                () => AssertStandardCountMultipleYAxis(),
                () => AssertHtmlEnd(false));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_ColumnSum_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeColumn);
            SetAggregateTypeHtmlSelectValue(AggregationSum);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertStandardSumOrAverageXAxis(),
                () => AssertStandardSumOrAverageOneYAxis(),
                () => AssertStandardSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_ColumnAverage_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeColumn);
            SetAggregateTypeHtmlSelectValue(AggregationAverage);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertStandardSumOrAverageXAxis(),
                () => AssertStandardSumOrAverageOneYAxis(),
                () => AssertStandardSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_LineCount_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeLine);
            SetAggregateTypeHtmlSelectValue(AggregationCount);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertStandardCountXAxis(),
                () => AssertStandardCountOneYAxis(),
                () => AssertStandardCountMultipleYAxis(),
                () => AssertHtmlEnd(false));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_LineSum_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeLine);
            SetAggregateTypeHtmlSelectValue(AggregationSum);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertStandardSumOrAverageXAxis(),
                () => AssertStandardSumOrAverageOneYAxis(),
                () => AssertStandardSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_LineAverage_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeLine);
            SetAggregateTypeHtmlSelectValue(AggregationAverage);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertStandardSumOrAverageXAxis(),
                () => AssertStandardSumOrAverageOneYAxis(),
                () => AssertStandardSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_BarClusteredCount_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeBarClustered);
            SetAggregateTypeHtmlSelectValue(AggregationCount);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertClusteredCountXAxis(),
                () => AssertClusteredCountOneYAxis(),
                () => AssertClusteredCountMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_BarClusteredSum_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeBarClustered);
            SetAggregateTypeHtmlSelectValue(AggregationSum);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertClusteredSumOrAverageXAxis(),
                () => AssertClusteredSumOrAverageOneYAxis(),
                () => AssertClusteredSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_BarClusteredAverage_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeBarClustered);
            SetAggregateTypeHtmlSelectValue(AggregationAverage);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertClusteredSumOrAverageXAxis(),
                () => AssertClusteredSumOrAverageOneYAxis(),
                () => AssertClusteredSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_Bar100PercentCount_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeBar100Percent);
            SetAggregateTypeHtmlSelectValue(AggregationCount);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertClusteredCountXAxis(),
                () => AssertClusteredCountOneYAxis(),
                () => AssertClusteredCountMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_Bar100PercentSum_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeBar100Percent);
            SetAggregateTypeHtmlSelectValue(AggregationSum);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertClusteredSumOrAverageXAxis(),
                () => AssertClusteredSumOrAverageOneYAxis(),
                () => AssertClusteredSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_Bar100PercentAverage_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeBar100Percent);
            SetAggregateTypeHtmlSelectValue(AggregationAverage);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertClusteredSumOrAverageXAxis(),
                () => AssertClusteredSumOrAverageOneYAxis(),
                () => AssertClusteredSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_PieCount_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypePie);
            SetAggregateTypeHtmlSelectValue(AggregationCount);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertPieCountXAxis(),
                () => AssertPieCountOneYAxis(),
                () => AssertPieCountMultipleYAxis(),
                () => AssertHtmlEnd(false));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_PieSum_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypePie);
            SetAggregateTypeHtmlSelectValue(AggregationSum);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertPieSumOrAverageXAxis(),
                () => AssertPieSumOrAverageOneYAxis(),
                () => AssertPieSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_PieAverage_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypePie);
            SetAggregateTypeHtmlSelectValue(AggregationAverage);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertPieSumOrAverageXAxis(),
                () => AssertPieSumOrAverageOneYAxis(),
                () => AssertPieSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_DonutCount_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeDonut);
            SetAggregateTypeHtmlSelectValue(AggregationCount);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertPieCountXAxis(),
                () => AssertPieCountOneYAxis(),
                () => AssertPieCountMultipleYAxis(),
                () => AssertHtmlEnd(false));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_DonutSum_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeDonut);
            SetAggregateTypeHtmlSelectValue(AggregationSum);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertPieSumOrAverageXAxis(),
                () => AssertPieSumOrAverageOneYAxis(),
                () => AssertPieSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_DonutAverage_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeDonut);
            SetAggregateTypeHtmlSelectValue(AggregationAverage);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertPieSumOrAverageXAxis(),
                () => AssertPieSumOrAverageOneYAxis(),
                () => AssertPieSumOrAverageMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_ScatterCount_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeScatter);
            SetAggregateTypeHtmlSelectValue(AggregationCount);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertScatterCountOneYAxis(),
                () => AssertScatterCountMultipleYAxis(),
                () => AssertHtmlEnd(true));
        }

        [TestMethod]
        public void WriteConfigSectionHtml_BubbleCount_WritesAxis()
        {
            // Arrange
            SetChartTypeDropDownList(ChartTypeBubble);
            SetAggregateTypeHtmlSelectValue(AggregationCount);

            // Act
            _privateObject.Invoke(MethodWriteConfigSectionHtml, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertBubbleCountXAxis(),
                () => AssertBubbleCountOneYAxis(),
                () => AssertBubbleCountMultipleYAxis(),
                () => AssertHtmlEnd(true, true));
        }

        [TestMethod]
        public void WriteJavascript_Invoke_WritesJSVariablesDeclarations()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodWriteJavascript, new object[] { _htmlWriter });

            // Assert
            var result = _htmlBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain("<script type=\"text/javascript\">"),
                () => result.ShouldContain("function ctype_agg_change()"),
                () => result.ShouldContain("var cTypeDdl = document.getElementById(\"ChartTypeDropDownList\");"),
                () => result.ShouldContain("var cType = cTypeDdl.options[cTypeDdl.selectedIndex].value;"),
                () => result.ShouldContain("var aggreDdl = document.getElementById(\"AggregateTypeHtmlSelect\");"),
                () => result.ShouldContain("var aggVal = aggreDdl.options[aggreDdl.selectedIndex].value;"),
                () => result.ShouldContain("var aggSec = document.getElementById(\"aggTypeSec\");"),
                () => result.ShouldContain("</script>"));
        }

        [TestMethod]
        public void WriteJavascript_Invoke_WritesJSConditions()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodWriteJavascript, new object[] { _htmlWriter });

            // Assert
            var result = _htmlBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain("aggSec.style.display = (cType != 'Bubble') ? '' : 'none';"),
                () => result.ShouldContain("document.getElementById(\"ZaxisSection\").style.display = (cType == 'Bubble') ? '' : 'none';"),
                () => result.ShouldContain("if (cType == \"Area\" || cType == \"Bar\" || cType == \"Column\" || cType == \"Line\")"),
                () => result.ShouldContain("if (aggVal == \"Count\")"),
                () => result.ShouldContain("else if (aggVal == \"Sum\" || aggVal == \"Avg\")"),
                () => result.ShouldContain("else if (cType.indexOf(\"_Clustered\") != -1 || cType.indexOf(\"_Stacked\") != -1 || cType.indexOf(\"_100Percent\") != -1)"),
                () => result.ShouldContain("else if (cType == \"Pie\" || cType == \"Donut\""),
                () => result.ShouldContain("else if (cType == \"Bubble\""));
        }

        [TestMethod]
        public void WriteJavascript_Invoke_WritesJSAreaCountElementsDisplay()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodWriteJavascript, new object[] { _htmlWriter });

            // Assert
            var result = _htmlBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain("document.getElementById(\"XaxisSection_full\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YAxisFormatSection\").style.display = \"none\";"));
        }

        [TestMethod]
        public void WriteJavascript_Invoke_WritesJSAreaSumAvgElementsDisplay()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodWriteJavascript, new object[] { _htmlWriter });

            // Assert
            var result = _htmlBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain("document.getElementById(\"XaxisSection_full\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_num\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YAxisFormatSection\").style.display = \"\";"));
        }

        [TestMethod]
        public void WriteJavascript_Invoke_WritesJSClusteredCountElementsDisplay()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodWriteJavascript, new object[] { _htmlWriter });

            // Assert
            var result = _htmlBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain("document.getElementById(\"XaxisSection_full\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YAxisFormatSection\").style.display = \"\";"));
        }

        [TestMethod]
        public void WriteJavascript_Invoke_WritesJSClusteredSumAvgElementsDisplay()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodWriteJavascript, new object[] { _htmlWriter });

            // Assert
            var result = _htmlBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain("document.getElementById(\"XaxisSection_full\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_num\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YAxisFormatSection\").style.display = \"\";"));
        }

        [TestMethod]
        public void WriteJavascript_Invoke_WritesJSPieCountElementsDisplay()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodWriteJavascript, new object[] { _htmlWriter });

            // Assert
            var result = _htmlBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain("document.getElementById(\"XaxisSection_full\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YAxisFormatSection\").style.display = \"none\";"));
        }

        [TestMethod]
        public void WriteJavascript_Invoke_WritesJSPieSumAvgElementsDisplay()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodWriteJavascript, new object[] { _htmlWriter });

            // Assert
            var result = _htmlBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain("document.getElementById(\"XaxisSection_full\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_num\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YAxisFormatSection\").style.display = \"\";"));
        }

        [TestMethod]
        public void WriteJavascript_Invoke_WritesJSBubbleElementsDisplay()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodWriteJavascript, new object[] { _htmlWriter });

            // Assert
            var result = _htmlBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain("document.getElementById(\"XaxisSection_full\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_num\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_num\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_num\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\";"),
                () => result.ShouldContain("document.getElementById(\"YaxisSection_ddl\").style.display = \"\";"),
                () => result.ShouldContain("document.getElementById(\"YAxisFormatSection\").style.display = \"\";"));
        }

        private void SetChartTypeDropDownList(string type)
        {
            var aggregateSelect = _privateObject.GetFieldOrProperty(FieldChartTypeDropDownList);
            var select = aggregateSelect as DropDownList;
            if (select != null)
            {
                select.Items.Add(type);
                select.SelectedValue = type;
            }
        }

        private void SetAggregateTypeHtmlSelectValue(string type)
        {
            var aggregateSelect = _privateObject.GetFieldOrProperty(FieldAggregateTypeHtmlSelect);
            var select = aggregateSelect as HtmlSelect;
            if (select != null)
            {
                select.Items.Add(type);
                select.Value = type;
            }
        }

        private void AssertStandardCountXAxis()
        {
            AssertChartSections(
                DivXaxisSectionFull,
                DivXaxisSectionDdlNumHidden,
                DivXaxisSectionDdlNonnumHidden);
        }

        private void AssertStandardSumOrAverageXAxis()
        {
            AssertChartSections(
                DivXaxisSectionFullHidden,
                DivXaxisSectionDdlNumHidden,
                DivXaxisSectionDdlNonnum);
        }

        private void AssertClusteredCountXAxis()
        {
            AssertChartSections(
                DivXaxisSectionFullHidden,
                DivXaxisSectionDdlNumHidden,
                DivXaxisSectionDdlNonnum);
        }

        private void AssertClusteredSumOrAverageXAxis()
        {
            AssertChartSections(
                DivXaxisSectionFullHidden,
                DivXaxisSectionDdlNumHidden,
                DivXaxisSectionDdlNonnum);
        }

        private void AssertPieCountXAxis()
        {
            AssertChartSections(
                DivXaxisSectionFull,
                DivXaxisSectionDdlNumHidden,
                DivXaxisSectionDdlNonnumHidden);
        }

        private void AssertPieSumOrAverageXAxis()
        {
            AssertChartSections(
                DivXaxisSectionFullHidden,
                DivXaxisSectionDdlNumHidden,
                DivXaxisSectionDdlNonnum);
        }

        private void AssertBubbleCountXAxis()
        {
            AssertChartSections(
                DivXaxisSectionFullHidden,
                DivXaxisSectionDdlNum,
                DivXaxisSectionDdlNonnumHidden);
        }

        private void AssertStandardCountOneYAxis()
        {
            AssertChartSections(
                DivYAxisSectionDdlHidden,
                DivYaxisSectionDdlNumHidden,
                DivYaxisSectionDdlNonnum);
        }

        private void AssertStandardSumOrAverageOneYAxis()
        {
            AssertChartSections(
                DivYAxisSectionDdl,
                DivYaxisSectionDdlNum,
                DivYaxisSectionDdlNonnumHidden);
        }

        private void AssertClusteredCountOneYAxis()
        {
            AssertChartSections(
                DivYAxisSectionDdl,
                DivYaxisSectionDdlNumHidden,
                DivYaxisSectionDdlNonnum);
        }

        private void AssertClusteredSumOrAverageOneYAxis()
        {
            AssertChartSections(
                DivYAxisSectionDdlHidden,
                DivYaxisSectionDdlNumHidden,
                DivYaxisSectionDdlNonnum);
        }

        private void AssertPieCountOneYAxis()
        {
            AssertChartSections(
                DivYAxisSectionDdlHidden,
                DivYaxisSectionDdlNumHidden,
                DivYaxisSectionDdlNonnum);
        }

        private void AssertPieSumOrAverageOneYAxis()
        {
            AssertChartSections(
                DivYAxisSectionDdl,
                DivYaxisSectionDdlNum,
                DivYaxisSectionDdlNonnumHidden);
        }

        private void AssertScatterCountOneYAxis()
        {
            AssertChartSections(
                DivYAxisSectionDdl,
                DivYaxisSectionDdlNum,
                DivYaxisSectionDdlNonnumHidden);
        }

        private void AssertBubbleCountOneYAxis()
        {
            AssertChartSections(
                DivYAxisSectionDdl,
                DivYaxisSectionDdlNum,
                DivYaxisSectionDdlNonnumHidden);
        }

        private void AssertStandardCountMultipleYAxis()
        {
            AssertChartSections(
                DivYaxisSectionCblHidden,
                DivYaxisSectionCblNumHidden,
                DivYaxisSectionCblNonnum);
        }

        private void AssertStandardSumOrAverageMultipleYAxis()
        {
            AssertChartSections(
                DivYaxisSectionCblHidden,
                DivYaxisSectionCblNum,
                DivYaxisSectionCblNonnumHidden);
        }

        private void AssertClusteredCountMultipleYAxis()
        {
            AssertChartSections(
                DivYaxisSectionCblHidden,
                DivYaxisSectionCblNumHidden,
                DivYaxisSectionCblNonnum);
        }

        private void AssertClusteredSumOrAverageMultipleYAxis()
        {
            AssertChartSections(
                DivYaxisSectionCbl,
                DivYaxisSectionCblNum,
                DivYaxisSectionCblNonnumHidden);
        }

        private void AssertPieCountMultipleYAxis()
        {
            AssertChartSections(
                DivYaxisSectionCblHidden,
                DivYaxisSectionCblNumHidden,
                DivYaxisSectionCblNonnum);
        }

        private void AssertPieSumOrAverageMultipleYAxis()
        {
            AssertChartSections(
                DivYaxisSectionCblHidden,
                DivYaxisSectionCblNumHidden,
                DivYaxisSectionCblNonnum);
        }

        private void AssertScatterCountMultipleYAxis()
        {
            AssertChartSections(
                DivYaxisSectionCblHidden,
                DivYaxisSectionCblNumHidden,
                DivYaxisSectionCblNonnum);
        }

        private void AssertBubbleCountMultipleYAxis()
        {
            AssertChartSections(
                DivYaxisSectionCblHidden,
                DivYaxisSectionCblNumHidden,
                DivYaxisSectionCblNonnum);
        }

        private void AssertChartSections(string axisSectionFull, string axisSectionDllNum, string axisSectionDllNonnum)
        {
            HtmlResult.ShouldSatisfyAllConditions(
                () => HtmlResult.ShouldContain(axisSectionFull),
                () => HtmlResult.ShouldContain(axisSectionDllNum),
                () => HtmlResult.ShouldContain(axisSectionDllNonnum));
        }

        private void AssertHtmlEnd(bool bRenderY, bool isBubble = false)
        {
            HtmlResult.ShouldSatisfyAllConditions(
                () => HtmlResult.ShouldContain(bRenderY ? DivYAxisFormatSection : DivYAxisFormatSectionHidden),
                () => HtmlResult.ShouldContain(isBubble ? DivZaxisSection : DivZaxisSectionHidden),
                () => HtmlResult.ShouldContain(DivGroupBy),
                () => HtmlResult.ShouldContain(CloseDivAndTable));
        }

        private void ShimSharePointContext()
        {
            //ShimSPFieldCollectionMethods();
            //ShimSPViewCollectionMethods();
            //ShimSPListMethods();
            //ShimSPListCollectionMethods();
            ShimSPWebMethods();
            //var site = ShimSPSiteMethods();

            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => _shimWeb.Instance,
                //SiteGet = () => site.Instance
            }.Instance;

            ShimSPSite.ConstructorGuid = (_, __) => { };
            //ShimSPSite.AllInstances.OpenWebGuid = (_, __) => _shimWeb;
            //ShimTemplateBasedControl.AllInstances.WebGet = _ => _shimWeb;
        }

        //private void ShimSPViewCollectionMethods()
        //{
        //    var query = $@"<Where><Child>
        //                        <FieldRef Name=""{DummyString}""/>
        //                        <Values>
        //                            <Value>{DummyString}</Value>
        //                        </Values>
        //                    </Child></Where>
        //                    <OrderBy>
        //                        <FieldRef Name=""{DummyString}"" Ascending=""false""/>
        //                    </OrderBy>";
        //    var _shimView = new ShimSPView
        //    {
        //        QueryGet = () => query
        //    };
        //    _shimViews = new ShimSPViewCollection
        //    {
        //        ItemGetString = _ => _shimView,
        //    };
        //}

        //private ShimSPSite ShimSPSiteMethods()
        //{
        //    var site = new ShimSPSite
        //    {
        //        IDGet = () => DummyGuid,
        //        RootWebGet = () => _shimWeb.Instance,
        //        WebApplicationGet = () => new ShimSPWebApplication
        //        {
        //            ApplicationPoolGet = () => new SPApplicationPool()
        //        }.Instance
        //    };
        //    _shimWeb.SiteGet = () => site.Instance;
        //    return site;
        //}

        //private void ShimSPFieldCollectionMethods()
        //{
        //    _shimFields = new ShimSPFieldCollection
        //    {
        //        GetFieldByInternalNameString = _ => new ShimSPField()
        //        {
        //            TitleGet = () => DummyString,
        //            InternalNameGet = () => DummyString,
        //            TypeGet = () => SPFieldType.User
        //        }.Instance
        //    };

        //    ShimSPField.AllInstances.TitleGet = _ => DummyString;
        //    ShimSPField.AllInstances.InternalNameGet = _ => DummyString;
        //}

        private void ShimSPWebMethods()
        {
            //var user = new ShimSPUser
            //{
            //    IDGet = () => Id
            //};

            _shimWeb = new ShimSPWeb
            {
                //IDGet = () => DummyGuid,
                //CurrentUserGet = () => user,
                //EnsureUserString = _ => user,
                //SiteUserInfoListGet = () => _shimList.Instance,
                //ListsGet = () => _shimListCollection.Instance,
                //Close = () => { _webClosed = true; },
                //UrlGet = () => ExampleUrl,
                LocaleGet = () => CultureInfo.InvariantCulture
            };
        }

        //private void ShimSPListCollectionMethods()
        //{
        //    _shimListCollection = new ShimSPListCollection
        //    {
        //        ItemGetString = _ => _shimList,
        //        ItemGetGuid = _ => _shimList,
        //        GetListGuidBoolean = (_, __) => _shimList,
        //        TryGetListString = list => _shimList.Instance
        //    };
        //}

        //private void ShimSPListMethods()
        //{
        //    _shimList = new ShimSPList
        //    {
        //        IDGet = () => DummyGuid,
        //        ItemsGet = () => new ShimSPListItemCollection
        //        {
        //            GetEnumerator = () => new List<SPListItem> { GetListItem() }.GetEnumerator(),
        //            GetDataTable = () => new DataTable()
        //        },
        //        FieldsGet = () => _shimFields.Instance,
        //        ParentWebGet = () => _shimWeb,
        //        ViewsGet = () => _shimViews
        //    };
        //}

        //private ShimSPListItem GetListItem()
        //{
        //    return new ShimSPListItem()
        //    {
        //        IDGet = () => Id,
        //        ItemGetGuid = _ => DummyString,
        //        ItemGetString = _ => DummyString
        //    };
        //}
    }
}
