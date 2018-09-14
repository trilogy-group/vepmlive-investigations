using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using EPMLiveWebParts.ReportingChart;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using RC = EPMLiveWebParts.ReportingChart;

namespace EPMLiveWebParts.Tests.ReportingChart
{
    [TestClass]
    public class ReportingChartTests
    {
        private const int Id = 1;
        private const string DummyString = "DummyString";
        private const string One = "1";
        private const string ExampleUrl = "http://example.com";
        private const string ControlSize = "200";
        private RC.ReportingChart _testObject;
        private PrivateObject _privateObject;
        private IDisposable _shimsContext;
        private StringBuilder _stringBuilder;
        private StringWriter _stringWriter;
        private HtmlTextWriter _htmlWriter;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testObject = new RC.ReportingChart();
            _privateObject = new PrivateObject(_testObject);

            _stringBuilder = new StringBuilder();
            _stringWriter = new StringWriter(_stringBuilder);
            _htmlWriter = new HtmlTextWriter(_stringWriter);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
            _stringWriter?.Dispose();
            _htmlWriter?.Dispose();
        }

        [TestMethod]
        public void RenderControl_()
        {
            // Arrange
            _testObject.PropChartType = ChartType.Area;
            _testObject.PropYaxisFormat = "Percentage";
            _testObject.Width = ControlSize;
            _testObject.Height = ControlSize;
            _testObject.RebuildControlTree();

            // Act
            _testObject.RenderControl(_htmlWriter);

            // Assert
            var result = _stringBuilder.ToString();
            result.ShouldSatisfyAllConditions(
                () => result.ShouldContain("<div id='divWizardBox' style='width:100%;text-align:center'>"),
                () => result.ShouldContain("<a onclick='loadChartWizard();' style='text-decoration:none;width:150px;'>"),
                () => result.ShouldContain("<div class='wizardBox'></div>"),
                () => result.ShouldContain("function loadChartWizard()"),
                () => result.ShouldContain("var tag = document.getElementsByTagName('object');"),
                () => result.ShouldContain("for(var i = tag.length-1;i>=0;i--)"),
                () => result.ShouldContain("tag[i].style.display='none';"));
        }
    }
}
