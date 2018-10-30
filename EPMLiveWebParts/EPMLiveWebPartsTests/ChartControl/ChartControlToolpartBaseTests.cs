using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.ChartControl
{
    using System.Web.UI.HtmlControls.Fakes;
    using System.Web.UI.WebControls.Fakes;
    using EPMLiveWebParts;
    using Fakes;

    [TestClass]
    public class ChartControlToolpartBaseTests
    {
        private IDisposable shimsContext;
        private ChartControlToolpartBase chartControlToolpartBase;
        private PrivateObject privateObject;
        private string OnInitMethodName = "OnInit";
        private string CreateChildControlsMethodName = "CreateChildControls";
        private string DummyString = "DummyString";
        private string RenderToolPartMethodName = "RenderToolPart";

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            chartControlToolpartBase = new ChartControlToolpartBase();
            privateObject = new PrivateObject(chartControlToolpartBase);
            privateObject.Invoke(OnInitMethodName, EventArgs.Empty);

        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        [TestMethod]
        public void Constructor_Should_CreateInstance()
        {
            // Arrange
            const string ExpectedTitle = "Configure Chart";
            // Act
            var instance = new ChartControlToolpartBase();

            // Assert
            instance.ShouldSatisfyAllConditions(
                () => instance.ShouldNotBeNull(),
                () => instance.Title.ShouldBe(ExpectedTitle),
                () => instance.AllowMinimize.ShouldBeTrue(),
                () => instance.UseDefaultStyles.ShouldBeTrue());
        }

        [TestMethod]
        public void CreateChildControls_Should_ExecuteCorrectly()
        {
            // Arrange

            // Act
            privateObject.Invoke(CreateChildControlsMethodName);
            var controls = privateObject.GetFieldOrProperty("Controls") as ControlCollection;

            // Assert
            controls.ShouldSatisfyAllConditions(
                () => controls.ShouldNotBeNull(),
                () => controls.Count.ShouldBeGreaterThan(0),
                () => controls.OfType<TextBox>().ShouldNotBeEmpty(),
                () => controls.OfType<CheckBox>().ShouldNotBeEmpty(),
                () => controls.OfType<DropDownList>().ShouldNotBeEmpty(),
                () => ValidateControlViewState(controls));
        }

        private void ValidateControlViewState(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.EnableViewState.ShouldBeTrue();
            }
        }


        [TestMethod]
        public void ApplyChanges_IsBubbleChart()
        {
            // Arrange
            var rebuildControlTreeWasCalled = false;
            var chartControl = new ChartControl();
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            ShimToolPart.AllInstances.ParentToolPaneGet = _ => new ShimToolPane
            {
                SelectedWebPartGet = () => chartControl
            };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem("Dummy");
            ShimChartControlToolpartBase.AllInstances.IsBubbleChart = _ => true;
            ShimChartControl.AllInstances.RebuildControlTree = _ =>
            {
                rebuildControlTreeWasCalled = true;
            };
            ShimTextBox.AllInstances.TextGet = _ => DummyString;

            // Act
            chartControlToolpartBase.ApplyChanges();

            // Assert
            rebuildControlTreeWasCalled.ShouldBeTrue();
            chartControl.PropChartAggregationType.ShouldBe("SUM");
            chartControl.PropChartRollupLists.ShouldBe(DummyString);
        }

        [TestMethod]
        public void ApplyChanges_AggregationTypeSum()
        {
            // Arrange
            var rebuildControlTreeWasCalled = false;
            var chartControl = new ChartControl();
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            ShimToolPart.AllInstances.ParentToolPaneGet = _ => new ShimToolPane
            {
                SelectedWebPartGet = () => chartControl
            };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem("Dummy");
            ShimChartControlToolpartBase.AllInstances.IsBubbleChart = _ => false;
            ShimChartControl.AllInstances.RebuildControlTree = _ =>
            {
                rebuildControlTreeWasCalled = true;
            };
            ShimTextBox.AllInstances.TextGet = _ => DummyString;
            ShimHtmlSelect.AllInstances.ValueGet = _ => "SUM";

            // Act
            chartControlToolpartBase.ApplyChanges();

            // Assert
            rebuildControlTreeWasCalled.ShouldBeTrue();
            chartControl.PropChartAggregationType.ShouldBe("SUM");
            chartControl.PropChartZaxisField.ShouldBe("None Selected");
            chartControl.PropChartRollupLists.ShouldBe(DummyString);
        }


        [TestMethod]
        public void ApplyChanges_AggregationTypeCount()
        {
            // Arrange
            var rebuildControlTreeWasCalled = false;
            var chartControl = new ChartControl();
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            ShimToolPart.AllInstances.ParentToolPaneGet = _ => new ShimToolPane
            {
                SelectedWebPartGet = () => chartControl
            };
            ShimListControl.AllInstances.SelectedItemGet = _ => new ListItem("Dummy");
            ShimChartControlToolpartBase.AllInstances.IsBubbleChart = _ => false;
            ShimChartControl.AllInstances.RebuildControlTree = _ =>
            {
                rebuildControlTreeWasCalled = true;
            };
            ShimTextBox.AllInstances.TextGet = _ => DummyString;
            ShimHtmlSelect.AllInstances.ValueGet = _ => "COUNT";

            // Act
            chartControlToolpartBase.ApplyChanges();

            // Assert
            rebuildControlTreeWasCalled.ShouldBeTrue();
            chartControl.PropChartAggregationType.ShouldBe("COUNT");
            chartControl.PropChartZaxisField.ShouldBeEmpty();
            chartControl.PropChartRollupLists.ShouldBe(DummyString);
        }

        [TestMethod]
        public void RenderToolPart_Should_ExecuteCorrectly()
        {
            // Arrange
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            ShimChartControlToolpartBase.AllInstances.IsBubbleChart = _ => false;
            var expectedContent = new List<string>
            {
                "<div class=\"OptionsSection\"><table cellpadding=1><tr><td></td></tr></table></div>",
                "<td><b>Z Axis Color Field</b><br></td>",
                "function aggreg_change(selval) { if (selval == \"COUNT\") { document.getElementById(\"YaxisSection\").style.display = \"none\"; }",
                "<div class=\"UserSectionHead\"><b>Chart Display Options</b><br />"
            };
            // Act
            privateObject.Invoke(RenderToolPartMethodName, writer);
            var result = stringBuilder.ToString();

            // Assert
            result.ShouldNotBeNullOrEmpty();
            expectedContent.ForEach(p => result.ShouldContainWithoutWhitespace(p));
        }

    }
}
