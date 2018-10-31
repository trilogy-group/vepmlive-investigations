using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Web.UI.HtmlControls.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.WebPartPages.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.ChartControl
{
    using EPMLiveWebParts;
    using Fakes;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ChartControlToolpartBaseTests
    {
        private const string OnInitMethodName = "OnInit";
        private const string CreateChildControlsMethodName = "CreateChildControls";
        private const string DummyString = "DummyString";
        private const string RenderToolPartMethodName = "RenderToolPart";
        private const string OnPreRenderMethodName = "OnPreRender";
        private const string ChartTypeDropDownListSelectedIndexChangedMethodName = "ChartTypeDropDownListSelectedIndexChanged";
        private const string ListsDropDownListSelectedIndexChangedMethodName = "ListsDropDownListSelectedIndexChanged";
        private const string ChartTypeDropDownList = "ChartTypeDropDownList";
        private const string SortDropDownListMethodName = "SortDropDownList";
        private const string FillDropdownsMethodName = "FillDropdowns";
        private IDisposable shimsContext;
        private ChartControlToolpartBase chartControlToolpartBase;
        private PrivateObject privateObject;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            chartControlToolpartBase = new ChartControlToolpartBase();
            privateObject = new PrivateObject(chartControlToolpartBase);
            privateObject.Invoke(OnInitMethodName, EventArgs.Empty);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimControl.AllInstances.PageGet = _ => new Page();
            ShimPage.AllInstances.ResponseGet = _ => new ShimHttpResponse();
            ShimHttpResponse.AllInstances.CacheGet = _ => new ShimHttpCachePolicy();
            ShimHttpCachePolicy.AllInstances.SetCacheabilityHttpCacheability = (_, cache) => { };
            ShimSPContext.CurrentGet = () => new ShimSPContext();
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb();
            ShimSPSite.ConstructorString = (_, url) => { };
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
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
            // Arrange, Act
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

        [TestMethod]
        public void ApplyChanges_IsBubbleChart_ExecutesCorrectly()
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
            chartControl.ShouldSatisfyAllConditions(
                () => rebuildControlTreeWasCalled.ShouldBeTrue(),
                () => chartControl.PropChartAggregationType.ShouldBe("SUM"),
                () => chartControl.PropChartRollupLists.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_AggregationTypeSum_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedValue = "SUM";
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
            ShimHtmlSelect.AllInstances.ValueGet = _ => ExpectedValue;

            // Act
            chartControlToolpartBase.ApplyChanges();

            // Assert
            chartControl.ShouldSatisfyAllConditions(
                () => rebuildControlTreeWasCalled.ShouldBeTrue(),
                () => chartControl.PropChartAggregationType.ShouldBe(ExpectedValue),
                () => chartControl.PropChartZaxisField.ShouldBe("None Selected"),
                () => chartControl.PropChartRollupLists.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_AggregationTypeCount_ExecutesCorrectly()
        {
            // Arrange
            const string ExpectedValue = "COUNT";
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
            ShimHtmlSelect.AllInstances.ValueGet = _ => ExpectedValue;

            // Act
            chartControlToolpartBase.ApplyChanges();

            // Assert
            chartControl.ShouldSatisfyAllConditions(
                () => rebuildControlTreeWasCalled.ShouldBeTrue(),
                () => chartControl.PropChartAggregationType.ShouldBe(ExpectedValue),
                () => chartControl.PropChartZaxisField.ShouldBeEmpty(),
                () => chartControl.PropChartRollupLists.ShouldBe(DummyString));
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
                "<td><b>Y Axis Formatting</b><br>Show Y axis values as percent</td>",
                "function aggreg_change(selval) { if (selval == \"COUNT\") { document.getElementById(\"YaxisSection\").style.display = \"none\"; }",
                "<div class=\"UserSectionHead\"><b>Chart Display Options</b><br />"
            };
            // Act
            privateObject.Invoke(RenderToolPartMethodName, writer);
            var result = stringBuilder.ToString();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(p => result.ShouldContainWithoutWhitespace(p)));
        }

        [TestMethod]
        public void RenderToolPart_BubbleChart_Should_ExecuteCorrectly()
        {
            // Arrange
            var stringBuilder = new StringBuilder();
            var writer = new ShimHtmlTextWriter
            {
                WriteString = content => stringBuilder.Append(content)
            }.Instance;
            ShimChartControlToolpartBase.AllInstances.IsBubbleChart = _ => true;
            var expectedContent = new List<string>
            {
                "<div class=\"OptionsSection\"><table cellpadding=1><tr><td></td></tr></table></div>",
                "<td><b>Z Axis Color Field</b><br></td>",
                "<td>Allow User To Select X, Y, Z Values<br></td>",
                "function aggreg_change(selval) { if (selval == \"COUNT\") { document.getElementById(\"YaxisSection\").style.display = \"none\"; }",
                "<div class=\"UserSectionHead\"><b>Chart Display Options</b><br />"
            };
            // Act
            privateObject.Invoke(RenderToolPartMethodName, writer);
            var result = stringBuilder.ToString();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => expectedContent.ForEach(p => result.ShouldContainWithoutWhitespace(p)));
        }

        [TestMethod]
        public void OnPreRender_Should_ExecuteCorrectly()
        {
            // Arrange
            var chartControl = new ChartControl
            {
                PropChartTitle = DummyString,
                PropChartAggregationType = DummyString,
                PropChartRollupLists = DummyString,
                PropChartYaxisField = DummyString,
                PropChartShowLegend = true,
                PropChartSelectedList = DummyString,
                PropChartShowBubbleChartInputsInWebPart = true
            };
            ShimToolPart.AllInstances.ParentToolPaneGet = _ => new ShimToolPane
            {
                SelectedWebPartGet = () => chartControl
            };
            ShimSPWeb.AllInstances.ListsGet = _ =>
            {
                var list = new List<SPList>().AsEnumerable();
                return new ShimSPListCollection().Bind(list);
            };
            ShimChartControl.AllInstances.GetYaxisFields = _ => new string[] { DummyString };
            ShimSPWeb.AllInstances.ListsGet = _ =>
            {
                var list = new List<SPList>
                {
                    new ShimSPList
                    {
                        HiddenGet = () => false,
                        TitleGet = () => DummyString
                    }
                }.AsEnumerable();
                return new ShimSPListCollection().Bind(list);
            };
            ShimSPListCollection.AllInstances.ItemGetString = (_, name) => new ShimSPList();
            ShimListItemCollection.AllInstances.FindByValueString = (_, name) => new ShimListItem();
            ShimChartControlToolpartBase.AllInstances.FillDropdownsSPList = (_, list) => { };

            // Act
            privateObject.Invoke(OnPreRenderMethodName, EventArgs.Empty);
            var chartTitleTextBox = privateObject.GetFieldOrProperty("ChartTitleTextBox") as TextBox;
            var rollupListsTextBox = privateObject.GetFieldOrProperty("RollupListsTextBox") as TextBox;
            var aggregateTypeHtmlSelect = privateObject.GetFieldOrProperty("AggregateTypeHtmlSelect") as HtmlSelect;
            var showBubbleChartInputsInWebPart = privateObject.GetFieldOrProperty("ShowBubbleChartInputsInWebPart") as CheckBox;
            var showLegendCheckBox = privateObject.GetFieldOrProperty("ShowLegendCheckBox") as CheckBox;

            // Assert
            chartControl.ShouldSatisfyAllConditions(
                () => chartTitleTextBox.ShouldNotBeNull(),
                () => chartTitleTextBox.Text.ShouldBe(DummyString),
                () => rollupListsTextBox.ShouldNotBeNull(),
                () => rollupListsTextBox.Text.ShouldBe(DummyString),
                () => showBubbleChartInputsInWebPart.ShouldNotBeNull(),
                () => showBubbleChartInputsInWebPart.Checked.ShouldBeTrue(),
                () => showLegendCheckBox.ShouldNotBeNull(),
                () => showLegendCheckBox.Checked.ShouldBeTrue(),
                () => aggregateTypeHtmlSelect.ShouldNotBeNull(),
                () => aggregateTypeHtmlSelect.Items?.Count.ShouldBeGreaterThan(0));
        }

        [TestMethod]
        public void ChartTypeDropDownListSelectedIndexChanged_Should_ApplyChanges()
        {
            // Arrange
            var applyChangesWasCalled = false;
            ShimChartControlToolpartBase.AllInstances.ApplyChanges = _ =>
            {
                applyChangesWasCalled = true;
            };
            ShimListControl.AllInstances.SelectedValueGet = _ => DummyString;

            // Act
            privateObject.Invoke(ChartTypeDropDownListSelectedIndexChangedMethodName, new object(), EventArgs.Empty);

            // Assert
            applyChangesWasCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void ChartTypeDropDownListSelectedIndexChanged_NoneSelected_NoActionTaken()
        {
            // Arrange
            var applyChangesWasCalled = false;
            ShimChartControlToolpartBase.AllInstances.ApplyChanges = _ =>
            {
                applyChangesWasCalled = true;
            };
            ShimListControl.AllInstances.SelectedValueGet = _ => "None Selected";

            // Act
            privateObject.Invoke(ChartTypeDropDownListSelectedIndexChangedMethodName, new object(), EventArgs.Empty);

            // Assert
            applyChangesWasCalled.ShouldBeFalse();
        }

        [TestMethod]
        public void ListsDropDownListSelectedIndexChanged_Should_ExecuteCorrectly()
        {
            // Arrange
            SPList listToFill = null;
            var list = new ShimSPList().Instance;
            var fillDropdownsWasCalled = false;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = name => list
            };
            ShimChartControlToolpartBase.AllInstances.FillDropdownsSPList = (_, spList) =>
            {
                listToFill = spList;
                fillDropdownsWasCalled = true;
            };
            ShimToolPart.AllInstances.ParentToolPaneGet = _ => new ShimToolPane
            {
                SelectedWebPartGet = () => new ChartControl()
            };

            // Act
            privateObject.Invoke(ListsDropDownListSelectedIndexChangedMethodName, new object(), EventArgs.Empty);

            // Assert
            chartControlToolpartBase.ShouldSatisfyAllConditions(
                () => fillDropdownsWasCalled.ShouldBeTrue(),
                () => listToFill.ShouldNotBeNull(),
                () => listToFill.ShouldBe(list));
        }

        [TestMethod]
        public void SortDropDownList_Should_ExecuteCorrectly()
        {
            // Arrange
            var privateType= new PrivateType(typeof(ChartControlToolpartBase));
            var dropDownList = new DropDownList();
            dropDownList.Items.Add(new ListItem("BText", "BValue"));
            dropDownList.Items.Add(new ListItem("AText", "AValue"));

            // Act
            privateType.InvokeStatic(SortDropDownListMethodName, dropDownList);

            // Assert
            dropDownList.ShouldSatisfyAllConditions(
                () => dropDownList.Items[0].ShouldNotBeNull(),
                () => dropDownList.Items[0].Value.ShouldBe("AValue"),
                () => dropDownList.Items[1].ShouldNotBeNull(),
                () => dropDownList.Items[1].Value.ShouldBe("BValue"));
        }

        [TestMethod]
        public void FillDropdowns_Should_ExecuteCorrectly()
        {
            // Arrange
            var spList = new ShimSPList
            {
                FieldsGet = () => 
                {
                    var list = new List<SPField>
                    {
                        new ShimSPField
                        {
                            TypeGet = () => SPFieldType.Choice
                        },
                        new ShimSPField
                        {
                            TypeGet = () => SPFieldType.Attachments
                        },
                        new ShimSPField
                        {
                            TypeGet = () => SPFieldType.Currency,
                            TypeAsStringGet = () => "Currency"
                        }
                    };
                    return new ShimSPFieldCollection().Bind(list);
                },
                ViewsGet = () => 
                {
                    var list = new List<SPView>
                    {
                        new ShimSPView
                        {
                            TitleGet = () => DummyString
                        }
                    };
                    return new ShimSPViewCollection().Bind(list);
                }
            }.Instance;
            ShimChartControlToolpartBase.AllInstances.IsBubbleChart = _ => false;

            // Act
            privateObject.Invoke(FillDropdownsMethodName, spList);
            var viewsDropDownList = privateObject.GetFieldOrProperty("ViewsDropDownList") as DropDownList;
            var xaxisFieldDropDownList = privateObject.GetFieldOrProperty("XaxisFieldDropDownList") as DropDownList;
            var yaxisFieldAsDropDownList = privateObject.GetFieldOrProperty("YaxisFieldAsDropDownList") as DropDownList;
            var zaxisFieldDropDownList = privateObject.GetFieldOrProperty("ViewsDropDownList") as DropDownList;
            var bubbleChartColorFieldDropDownList = privateObject.GetFieldOrProperty("BubbleChartColorFieldDropDownList") as DropDownList;

            // Assert
            chartControlToolpartBase.ShouldSatisfyAllConditions(
                () => DropDownListNotNullOrEmpty(viewsDropDownList),
                () => DropDownListNotNullOrEmpty(xaxisFieldDropDownList),
                () => DropDownListNotNullOrEmpty(yaxisFieldAsDropDownList),
                () => DropDownListNotNullOrEmpty(zaxisFieldDropDownList),
                () => DropDownListNotNullOrEmpty(bubbleChartColorFieldDropDownList));
        }

        private void DropDownListNotNullOrEmpty(DropDownList dropDown)
        {
            dropDown.ShouldNotBeNull();
            dropDown.Items.Count.ShouldBeGreaterThanOrEqualTo(1);
        }

        private void ValidateControlViewState(ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.EnableViewState.ShouldBeTrue();
            }
        }
    }
}
