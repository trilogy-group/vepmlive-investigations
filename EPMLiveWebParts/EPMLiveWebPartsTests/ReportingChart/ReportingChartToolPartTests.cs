using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.Fakes;
using EPMLiveWebParts.ReportingChart;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.ReportingChart
{
    [TestClass]
    public class ReportingChartToolPartTests
    {
        private const int Id = 1;
        private const string DummyString = "DummyString";
        private const string One = "1";
        private const string ExampleUrl = "http://example.com";
        private const string MethodWriteJavascript = "WriteJavascript";
        private const string MethodOnInit = "OnInit";
        private ReportingChartToolPart _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private StringBuilder _htmlBuilder;
        private StringWriter _stringWriter;
        private HtmlTextWriter _htmlWriter;

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
    }
}
