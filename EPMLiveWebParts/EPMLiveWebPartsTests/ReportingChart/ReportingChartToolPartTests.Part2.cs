using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EPMLiveWebParts.ReportingChart;
using EPMLiveWebParts.ReportingChart.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveWebParts.Tests.ReportingChartTests
{
    partial class ReportingChartToolPartTests
    {
        private const string MethodCreateChildControls = "CreateChildControls";
        private const string MethodOnPreRender = "OnPreRender";
        private const string FieldViewsDropDownList = "ViewsDropDownList";
        private const string FieldXaxisLabelRotationAngleTextBox = "XaxisLabelRotationAngleTextBox";
        private const string FieldXaxisLabelFontSizeTextBox = "XaxisLabelFontSizeTextBox";
        private const string FieldNumberOfYaxisValuesTextBox = "NumberOfYaxisValuesTextBox";
        private const string FieldZaxisLabelRotationAngleTextBox = "ZaxisLabelRotationAngleTextBox";
        private const string FieldBubbleChartColorFieldDropDownList = "BubbleChartColorFieldDropDownList";
        private const string FieldChartTitleTextBox = "ChartTitleTextBox";
        private const string FieldChartTitleFontSizeTextBox = "ChartTitleFontSizeTextBox";
        private const string FieldShowLegendCheckBox = "ShowLegendCheckBox";
        private const string FieldSeriesNameLabelPositionDropDownList = "SeriesNameLabelPositionDropDownList";
        private const string FieldSeriesValueLabelPositionDropDownList = "SeriesValueLabelPositionDropDownList";
        private const string FieldShowFrameCheckBox = "ShowFrameCheckBox";
        private const string FieldFrameColorDropDownList = "FrameColorDropDownList";
        private const string FieldFrameRoundCornersCheckBox = "FrameRoundCornersCheckBox";
        private const string FieldSeriesDataPointLabelFontSizeTextBox = "SeriesDataPointLabelFontSizeTextBox";
        private const string FieldChartLegendFontSizeCheckBox = "ChartLegendFontSizeCheckBox";
        private const string FieldShowGridlinesCheckBox = "ShowGridlinesCheckBox";
        private const string FieldShowLabelsCheckBox = "ShowLabelsCheckBox";
        private const string FieldShowProjectsCheckBox = "ShowProjectsCheckBox";
        private const string AttributeOnChange = "onChange";
        private const string MethodApplyChanges = "ApplyChanges";
        private const string MethodRenderToolPart = "RenderToolPart";
        private const string MethodListsDropDownListSelectedIndexChanged = "ListsDropDownListSelectedIndexChanged";
        private const string MethodLoadAndSetAggregateTypes = "LoadAndSetAggregateTypes";
        private const string MethodLoadAndSetChartTypes = "LoadAndSetChartTypes";
        private const string MethodSetDropDownListSelectedValues = "SetDropDownListSelectedValues";

        [TestMethod]
        public void CreateChildControls_Invoke_InsertsXAxisAndOtherControls()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertContainsControl(FieldListsDropDownList),
                () => AssertContainsControl(FieldViewsDropDownList),
                () => AssertContainsControl(FieldChartTypeDropDownList),
                () => AssertContainsControl(FieldAggregateTypeHtmlSelect),
                () => AssertContainsControl(FieldXaxisFieldDropDownList),
                () => AssertContainsControl(FieldDdlXaxisFieldNum),
                () => AssertContainsControl(FieldDdlXaxisFieldNonNum),
                () => AssertContainsControl(FieldXaxisLabelRotationAngleTextBox),
                () => AssertContainsControl(FieldXaxisLabelFontSizeTextBox));
        }

        [TestMethod]
        public void CreateChildControls_Invoke_InsertsYAndZAxisControls()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertContainsControl(FieldCblYaxisFieldNum),
                () => AssertContainsControl(FieldCblYaxisFieldNonNum),
                () => AssertContainsControl(FieldDdlYaxisFieldNum),
                () => AssertContainsControl(FieldDdlYaxisFieldNonNum),
                () => AssertContainsControl(FieldYaxisFormatDropDownList),
                () => AssertContainsControl(FieldNumberOfYaxisValuesTextBox),
                () => AssertContainsControl(FieldZaxisLabelRotationAngleTextBox),
                () => AssertContainsControl(FieldZaxisFieldDropDownList),
                () => AssertContainsControl(FieldBubbleChartColorFieldDropDownList),
                () => AssertContainsControl(FieldBubbleGroupByDropDownList));
        }

        [TestMethod]
        public void CreateChildControls_Invoke_InsertsChartDisplayControls()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertContainsControl(FieldChartTitleTextBox),
                () => AssertContainsControl(FieldChartTitleFontSizeTextBox),
                () => AssertContainsControl(FieldChartPaletteStyleDropDownList),
                () => AssertContainsControl(FieldChartLegendFontSizeCheckBox),
                () => AssertContainsControl(FieldLegendPositionDropDownList),
                () => AssertContainsControl(FieldShowLegendCheckBox),
                () => AssertContainsControl(FieldSeriesNameLabelPositionDropDownList),
                () => AssertContainsControl(FieldSeriesValueLabelPositionDropDownList),
                () => AssertContainsControl(FieldSeriesDataPointLabelFontSizeTextBox));
        }

        [TestMethod]
        public void CreateChildControls_Invoke_InsertsOtherDisplayControls()
        {
            // Arrange, Act
            _privateObject.Invoke(MethodCreateChildControls);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertContainsControl(FieldFrameColorDropDownList),
                () => AssertContainsControl(FieldFrameRoundCornersCheckBox),
                () => AssertContainsControl(FieldShowFrameCheckBox),
                () => AssertContainsControl(FieldShowGridlinesCheckBox),
                () => AssertContainsControl(FieldShowLabelsCheckBox),
                () => AssertContainsControl(FieldShowProjectsCheckBox));
        }

        [TestMethod]
        public void OnPreRender_Invoke_ForcesPageToNotCache()
        {
            // Arrange
            SetListsDropDownList(DummyString);
            ShimPageResponse();

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _pageCacheability.ShouldBe(HttpCacheability.NoCache),
                () => _responseExpiration.ShouldBe(-1));
        }

        [TestMethod]
        public void OnPreRender_Invoke_FillsListDropDown()
        {
            // Arrange
            SetListsDropDownList(DummyString);
            ShimPageResponse();

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            var field = _privateObject.GetFieldOrProperty(FieldListsDropDownList);
            var dropdown = field as DropDownList;
            this.ShouldSatisfyAllConditions(
                () => dropdown.ShouldNotBeNull(),
                () => dropdown.Items.Count.ShouldBe(2),
                () => dropdown.Items[0].ShouldBe(new ListItem(SelectListOption, SelectListOption)),
                () => dropdown.Items[1].ShouldBe(new ListItem(DummyString, DummyString)));
        }

        [TestMethod]
        public void OnPreRender_NoViewSelected_DoesNotFillListDropDown()
        {
            // Arrange
            SetListsDropDownList(DummyString);
            ShimPageResponse();
            _reportingChart.PropChartSelectedViewTitle = null;

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            var field = _privateObject.GetFieldOrProperty(FieldViewsDropDownList);
            var dropdown = field as DropDownList;
            this.ShouldSatisfyAllConditions(
                () => dropdown.ShouldNotBeNull(),
                () => dropdown.Items.Count.ShouldBe(0));
        }

        [TestMethod]
        public void OnPreRender_NoListFound_DoesNotFillListDropDown()
        {
            // Arrange
            SetListsDropDownList(DummyString);
            ShimPageResponse();
            _reportingChart.PropChartSelectedViewTitle = DummyString;
            _shimListCollection.TryGetListString = _ => null;

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            var field = _privateObject.GetFieldOrProperty(FieldViewsDropDownList);
            var dropdown = field as DropDownList;
            this.ShouldSatisfyAllConditions(
                () => dropdown.ShouldNotBeNull(),
                () => dropdown.Items.Count.ShouldBe(0));
        }

        [TestMethod]
        public void OnPreRender_ViewHidden_DoesNotFillListDropDown()
        {
            // Arrange
            SetListsDropDownList(DummyString);
            ShimPageResponse();
            _reportingChart.PropChartSelectedViewTitle = DummyString;
            _view.HiddenGet = () => true;

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            var field = _privateObject.GetFieldOrProperty(FieldViewsDropDownList);
            var dropdown = field as DropDownList;
            this.ShouldSatisfyAllConditions(
                () => dropdown.ShouldNotBeNull(),
                () => dropdown.Items.Count.ShouldBe(0));
        }

        [TestMethod]
        public void OnPreRender_LoadAndSetViews_FillsListDropDown()
        {
            // Arrange
            SetListsDropDownList(DummyString);
            ShimPageResponse();
            _reportingChart.PropChartSelectedViewTitle = DummyString;
            _view.HiddenGet = () => false;

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            var field = _privateObject.GetFieldOrProperty(FieldViewsDropDownList);
            var dropdown = field as DropDownList;
            this.ShouldSatisfyAllConditions(
                () => dropdown.ShouldNotBeNull(),
                () => dropdown.Items.Count.ShouldBe(1),
                () => dropdown.Items[0].ShouldBe(new ListItem(DummyString, DummyGuid.ToString())),
                () => dropdown.Items[0].Selected.ShouldBeTrue());
        }

        [TestMethod]
        public void OnPreRender_LoadAndSetViews_DoesNotSelectListDropDown()
        {
            // Arrange
            SetListsDropDownList(DummyString);
            ShimPageResponse();
            _reportingChart.PropChartSelectedViewTitle = One;
            _view.HiddenGet = () => false;

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            var field = _privateObject.GetFieldOrProperty(FieldViewsDropDownList);
            var dropdown = field as DropDownList;
            this.ShouldSatisfyAllConditions(
                () => dropdown.ShouldNotBeNull(),
                () => dropdown.Items.Count.ShouldBe(1),
                () => dropdown.Items[0].ShouldBe(new ListItem(DummyString, DummyGuid.ToString())),
                () => dropdown.Items[0].Selected.ShouldBeFalse());
        }

        [TestMethod]
        public void OnPreRender_LoadAndSetChartTypes_FillsAndSelectsListDropDown()
        {
            // Arrange
            SetListsDropDownList(DummyString);
            ShimPageResponse();
            _reportingChart.PropChartType = ChartType.Bubble;

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            var field = _privateObject.GetFieldOrProperty(FieldChartTypeDropDownList);
            var dropdown = field as DropDownList;
            this.ShouldSatisfyAllConditions(
                () => dropdown.ShouldNotBeNull(),
                () => AssertChartTypeDropDown(dropdown),
                () => dropdown.Items[6].Selected.ShouldBeTrue());
        }

        [TestMethod]
        public void OnPreRender_LoadAndSetAggregateTypes_FillsAndSelectsListDropDown()
        {
            // Arrange
            SetListsDropDownList(DummyString);
            ShimPageResponse();
            _reportingChart.PropChartAggregationType = AggregationSum;
            ShimReportingChartToolPart.AllInstances.FillDropDowns = _ => { };

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            var field = _privateObject.GetFieldOrProperty(FieldAggregateTypeHtmlSelect);
            var htmlSelect = field as HtmlSelect;
            htmlSelect.ShouldSatisfyAllConditions(
                () => htmlSelect.ShouldNotBeNull(),
                () => htmlSelect.Items.Count.ShouldBe(3),
                () => htmlSelect.Items[0].Value.ShouldBe(AggregationCount),
                () => htmlSelect.Items[1].Value.ShouldBe(AggregationSum),
                () => htmlSelect.Items[2].Value.ShouldBe(AggregationAverage),
                () => htmlSelect.Attributes[AttributeOnChange].ShouldBe("ctype_agg_change()"));
        }

        [TestMethod]
        public void OnPreRender_FillDropDowns_FillsDropDowns()
        {
            // Arrange
            SetListsDropDownList(DummyString);
            ShimPageResponse();
            var dropDownsFilled = false;
            ShimReportingChartToolPart.AllInstances.FillDropDowns = _ => { dropDownsFilled = true; };

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            var field = _privateObject.GetFieldOrProperty(FieldAggregateTypeHtmlSelect);
            var htmlSelect = field as HtmlSelect;
            dropDownsFilled.ShouldBeTrue();
        }

        [TestMethod]
        public void OnPreRender_SetTextBoxValues_SetsTextBoxesText()
        {
            // Arrange
            SetListsDropDownList(DummyString);
            ShimPageResponse();
            _reportingChart.PropChartTitle = DummyString;

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            var field = _privateObject.GetFieldOrProperty(FieldChartTitleTextBox);
            var textBox = field as TextBox;
            this.ShouldSatisfyAllConditions(
                () => textBox.ShouldNotBeNull(),
                () => textBox.Text.ShouldBe(DummyString));
        }

        [TestMethod]
        public void OnPreRender_SetupCheckBoxesChecked_ChecksCheckBoxes()
        {
            // Arrange
            SetListsDropDownList(DummyString);
            ShimPageResponse();
            _reportingChart.PropChartShowGridlines = true;
            _reportingChart.PropChartShowLegend = true;
            _reportingChart.PropChartShowSeriesLabels = true;

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertCheckBoxChecked(FieldShowGridlinesCheckBox, true),
                () => AssertCheckBoxChecked(FieldShowLegendCheckBox, true),
                () => AssertCheckBoxChecked(FieldShowLabelsCheckBox, true));
        }

        [TestMethod]
        public void OnPreRender_SetupCheckBoxesUnchecked_UnchecksCheckBoxes()
        {
            // Arrange
            SetListsDropDownList(DummyString);
            ShimPageResponse();
            _reportingChart.PropChartShowGridlines = false;
            _reportingChart.PropChartShowLegend = false;
            _reportingChart.PropChartShowSeriesLabels = false;

            // Act
            _privateObject.Invoke(MethodOnPreRender, new object[] { EventArgs.Empty });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => AssertCheckBoxChecked(FieldShowGridlinesCheckBox, false),
                () => AssertCheckBoxChecked(FieldShowLegendCheckBox, false),
                () => AssertCheckBoxChecked(FieldShowLabelsCheckBox, false));
        }

        [TestMethod]
        public void ApplyChanges_Invoke_SavesValuesToChart()
        {
            // Arrange
            var childEnsured = false;
            var chartRebuilt = false;
            ShimControl.AllInstances.EnsureChildControls = _ => { childEnsured = true; };
            ShimReportingChart.AllInstances.RebuildControlTree = _ => { chartRebuilt = true; };
            SetFields(ChartTypeBar, AggregationSum);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => childEnsured.ShouldBeTrue(),
                () => chartRebuilt.ShouldBeTrue(),
                () => _reportingChart.PropChartTitle.ShouldBe(DummyString),
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bar),
                () => _reportingChart.PropChartSelectedPaletteName.ShouldBe(ColorBlue),
                () => _reportingChart.PropChartSelectedListTitle.ShouldBe(DummyString),
                () => _reportingChart.PropChartSelectedViewTitle.ShouldBe(DummyString),
                () => _reportingChart.PropYaxisFormat.ShouldBe(DummyString),
                () => _reportingChart.PropChartLegendPosition.ShouldBe(PositionTop),
                () => _reportingChart.PropChartShowGridlines.ShouldBeTrue(),
                () => _reportingChart.PropChartShowSeriesLabels.ShouldBeTrue(),
                () => _reportingChart.PropChartShowLegend.ShouldBeTrue(),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationSum));
        }

        [TestMethod]
        public void ApplyChanges_AreaCount_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeArea, AggregationCount);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Area),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationCount),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(string.Empty),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(string.Empty),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_AreaSum_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeArea, AggregationSum);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Area),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_AreaAverage_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeArea, AggregationAverage);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Area),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationAverage),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_BarCount_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBar, AggregationCount);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bar),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationCount),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(string.Empty),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(string.Empty),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_BarSum_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBar, AggregationSum);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bar),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_BarAverage_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBar, AggregationAverage);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bar),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationAverage),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_ColumnCount_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeColumn, AggregationCount);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Column),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationCount),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(string.Empty),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(string.Empty),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_ColumnSum_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeColumn, AggregationSum);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Column),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_ColumnAverage_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeColumn, AggregationAverage);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Column),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationAverage),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_LineCount_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeLine, AggregationCount);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Line),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationCount),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(string.Empty),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(string.Empty),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_LineSum_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeLine, AggregationSum);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Line),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_LineAverage_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeLine, AggregationAverage);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Line),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationAverage),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_BarClusteredCount_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBarClustered, AggregationCount);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bar_Clustered),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationCount),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationCount),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_BarClusteredSum_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBarClustered, AggregationSum);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bar_Clustered),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(string.Empty),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(string.Empty),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_BarClusteredAverage_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBarClustered, AggregationAverage);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bar_Clustered),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationAverage),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(string.Empty),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(string.Empty),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_Bar100PercentCount_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBar100Percent, AggregationCount);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bar_100Percent),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationCount),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationCount),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_Bar100PercentSum_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBar100Percent, AggregationSum);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bar_100Percent),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(string.Empty),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(string.Empty),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_Bar100PercentAverage_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBar100Percent, AggregationAverage);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bar_100Percent),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationAverage),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(string.Empty),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(string.Empty),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_BarStackedCount_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBarStacked, AggregationCount);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bar_Stacked),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationCount),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationCount),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_BarStackedSum_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBarStacked, AggregationSum);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bar_Stacked),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(string.Empty),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(string.Empty),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_BarStackedAverage_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBarStacked, AggregationAverage);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bar_Stacked),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationAverage),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(string.Empty),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(string.Empty),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_PieCount_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypePie, AggregationCount);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Pie),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationCount),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(string.Empty),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(string.Empty),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_PieSum_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypePie, AggregationSum);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Pie),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_PieAverage_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypePie, AggregationAverage);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Pie),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationAverage),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_DonutCount_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeDonut, AggregationCount);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Donut),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationCount),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(string.Empty),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(string.Empty),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_DonutSum_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeDonut, AggregationSum);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Donut),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_DonutAverage_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeDonut, AggregationAverage);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Donut),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationAverage),
                () => _reportingChart.PropChartXaxisField.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_BubbleCount_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBubble, AggregationCount);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bubble),
                () => _reportingChart.PropBubbleChartGroupBy.ShouldBe(ChartTypeBubble),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationCount),
                () => _reportingChart.PropChartXaxisField.ShouldBe(ChartTypeBubble),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(ChartTypeBubble),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_BubbleSum_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBubble, AggregationSum);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bubble),
                () => _reportingChart.PropBubbleChartGroupBy.ShouldBe(ChartTypeBubble),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartXaxisField.ShouldBe(ChartTypeBubble),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(ChartTypeBubble),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ApplyChanges_BubbleAverage_SavesValuesToChartAxis()
        {
            // Arrange
            ShimControl.AllInstances.EnsureChildControls = _ => { };
            SetFields(ChartTypeBubble, AggregationAverage);

            // Act
            _privateObject.Invoke(MethodApplyChanges);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => _reportingChart.PropChartType.ShouldBe(ChartType.Bubble),
                () => _reportingChart.PropBubbleChartGroupBy.ShouldBe(ChartTypeBubble),
                () => _reportingChart.PropChartAggregationType.ShouldBe(AggregationAverage),
                () => _reportingChart.PropChartXaxisField.ShouldBe(ChartTypeBubble),
                () => _reportingChart.PropChartXaxisFieldLabel.ShouldBe(ChartTypeBubble),
                () => _reportingChart.GetYFieldsLabel().ShouldBe(AggregationSum),
                () => _reportingChart.PropChartYaxisFieldLabel.ShouldBe(AggregationSum),
                () => _reportingChart.PropChartZaxisFieldLabel.ShouldBe(DummyString),
                () => _reportingChart.PropChartZaxisField.ShouldBe(DummyString));
        }

        [TestMethod]
        public void RenderToolPart_Invoke_RendersCheckBoxes()
        {
            // Arrange
            var javascriptWritten = false;
            var htmlConfigured = false;
            ShimReportingChartToolPart.AllInstances.WriteJavascriptHtmlTextWriter = (_, __) => { javascriptWritten = true; };
            ShimReportingChartToolPart.AllInstances.WriteConfigSectionHtmlHtmlTextWriter = (_, __) => { htmlConfigured = true; };

            // Act
            _privateObject.Invoke(MethodRenderToolPart, new object[] { _htmlWriter });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => javascriptWritten.ShouldBeTrue(),
                () => htmlConfigured.ShouldBeTrue(),
                () => HtmlResult.ShouldContain("<div class=\"UserSectionHead\"><b>Display Options</b><br /><table cellpadding=1 style=\"padding-left: 5px\"><tr><td>Title<br><input type=\"text\" />"),
                () => HtmlResult.ShouldContain("<input type=\"text\" /></td></tr><tr><td>Palette<br><select"),
                () => HtmlResult.ShouldContain("</select></td></tr><tr><td><input id=\"ShowGridlinesCheckBox\" type=\"checkbox\" />"),
                () => HtmlResult.ShouldContain("<input id=\"ShowGridlinesCheckBox\" type=\"checkbox\" />Show Gridlines<br></td></tr><tr><td><input id=\"ShowLabelsCheckBox\" type=\"checkbox\" />"),
                () => HtmlResult.ShouldContain("<input id=\"ShowLabelsCheckBox\" type=\"checkbox\" />Show X-Axis Labels<br></td></tr><tr><td><input id=\"ShowLegendCheckBox\" type=\"checkbox\" />"),
                () => HtmlResult.ShouldContain("<input id=\"ShowLegendCheckBox\" type=\"checkbox\" />Show Legend<br></td></tr><tr><td>Legend Position<br><select"),
                () => HtmlResult.ShouldContain("</select></td></tr></td></tr></table></div>"));
        }

        [TestMethod]
        public void ListsDropDownListSelectedIndexChanged_NoValueSelected_DoesntFillDropDown()
        {
            // Arrange
            var dropDownsFilled = false;
            ShimReportingChartToolPart.AllInstances.FillDropDowns = _ => { dropDownsFilled = true; };
            SetListsDropDownList(SelectListOption);
            var dropDown = GetDropDown(FieldViewsDropDownList);

            // Act
            _privateObject.Invoke(MethodListsDropDownListSelectedIndexChanged, new object[] { dropDown, EventArgs.Empty });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => dropDownsFilled.ShouldBeFalse(),
                () => _reportingChart.PropChartSelectedListTitle.ShouldBeNullOrEmpty(),
                () => dropDown.Items.Count.ShouldBe(0));
        }

        [TestMethod]
        public void ListsDropDownListSelectedIndexChanged_GetNullList_DoesntFillViewsDropDown()
        {
            // Arrange
            var dropDownsFilled = false;
            ShimReportingChartToolPart.AllInstances.FillDropDowns = _ => { dropDownsFilled = true; };
            SetListsDropDownList(DummyString);
            _shimListCollection.TryGetListString = _ => null;
            var dropDown = GetDropDown(FieldViewsDropDownList);

            // Act
            _privateObject.Invoke(MethodListsDropDownListSelectedIndexChanged, new object[] { dropDown, EventArgs.Empty });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => dropDownsFilled.ShouldBeFalse(),
                () => _reportingChart.PropChartSelectedListTitle.ShouldBeNullOrEmpty(),
                () => dropDown.Items.Count.ShouldBe(0));
        }

        [TestMethod]
        public void ListsDropDownListSelectedIndexChanged_ViewIsHidden_DoesntFillViewsDropDown()
        {
            // Arrange
            var dropDownsFilled = false;
            ShimReportingChartToolPart.AllInstances.FillDropDowns = _ => { dropDownsFilled = true; };
            SetListsDropDownList(DummyString);
            _view.HiddenGet = () => true;
            var dropDown = GetDropDown(FieldViewsDropDownList);

            // Act
            _privateObject.Invoke(MethodListsDropDownListSelectedIndexChanged, new object[] { dropDown, EventArgs.Empty });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => dropDownsFilled.ShouldBeTrue(),
                () => _reportingChart.PropChartSelectedListTitle.ShouldBe(DummyString),
                () => dropDown.Items.Count.ShouldBe(0));
        }

        [TestMethod]
        public void ListsDropDownListSelectedIndexChanged_LoadViews_FillsDropDown()
        {
            // Arrange
            var dropDownsFilled = false;
            ShimReportingChartToolPart.AllInstances.FillDropDowns = _ => { dropDownsFilled = true; };
            SetListsDropDownList(DummyString);
            _view.HiddenGet = () => false;
            var dropDown = GetDropDown(FieldViewsDropDownList);

            // Act
            _privateObject.Invoke(MethodListsDropDownListSelectedIndexChanged, new object[] { dropDown, EventArgs.Empty });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => dropDownsFilled.ShouldBeTrue(),
                () => _reportingChart.PropChartSelectedListTitle.ShouldBe(DummyString),
                () => dropDown.Items.Count.ShouldBe(1),
                () => dropDown.Items[0].Value.ShouldBe(DummyString),
                () => dropDown.Items[0].Text.ShouldBe(DummyString));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_Invoke_SelectsDropDownsValues()
        {
            // Arrange
            FillDropDowns(true);
            var bubbleGroupByDropDown = SetDropDownListValue(FieldBubbleGroupByDropDownList, DummyString, false);

            _reportingChart.PropChartSelectedListTitle = DummyString;
            _reportingChart.PropChartType = ChartType.Bubble;
            _reportingChart.PropChartZaxisField = DummyString;
            _reportingChart.PropChartXaxisField = DummyString;
            _reportingChart.PropChartAggregationType = AggregationSum;
            _reportingChart.PropYaxisFormat = FormatCurrency;
            _reportingChart.PropBubbleChartGroupBy = DummyString;
            _reportingChart.PropChartLegendPosition = PositionTop;

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldListsDropDownList).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldChartTypeDropDownList).SelectedIndex.ShouldBe(6),
                () => GetDropDown(FieldZaxisFieldDropDownList).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldXaxisFieldDropDownList).SelectedIndex.ShouldBe(0),
                () => GetHtmlSelect(FieldAggregateTypeHtmlSelect).SelectedIndex.ShouldBe(1),
                () => GetDropDown(FieldYaxisFormatDropDownList).SelectedIndex.ShouldBe(1),
                () => bubbleGroupByDropDown.SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldLegendPositionDropDownList).SelectedIndex.ShouldBe(1),
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_AreaCount_DoesntSelectValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Area;
            _reportingChart.PropChartAggregationType = AggregationCount;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_AreaSum_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Area;
            _reportingChart.PropChartAggregationType = AggregationSum;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_AreaAverage_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Donut;
            _reportingChart.PropChartAggregationType = AggregationAverage;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_BarCount_DoesntSelectValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Bar;
            _reportingChart.PropChartAggregationType = AggregationCount;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_BarSum_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Bar;
            _reportingChart.PropChartAggregationType = AggregationSum;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_BarAverage_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Bar;
            _reportingChart.PropChartAggregationType = AggregationAverage;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_ColumnCount_DoesntSelectValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Column;
            _reportingChart.PropChartAggregationType = AggregationCount;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_ColumnSum_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Column;
            _reportingChart.PropChartAggregationType = AggregationSum;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_ColumnAverage_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Column;
            _reportingChart.PropChartAggregationType = AggregationAverage;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_LineCount_DoesntSelectValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Line;
            _reportingChart.PropChartAggregationType = AggregationCount;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_LineSum_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Line;
            _reportingChart.PropChartAggregationType = AggregationSum;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_LineAverage_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Line;
            _reportingChart.PropChartAggregationType = AggregationAverage;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_PieCount_DoesntSelectValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Pie;
            _reportingChart.PropChartAggregationType = AggregationCount;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_PieSum_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Pie;
            _reportingChart.PropChartAggregationType = AggregationSum;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_PieAverage_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Pie;
            _reportingChart.PropChartAggregationType = AggregationAverage;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_DonutCount_DoesntSelectValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Donut;
            _reportingChart.PropChartAggregationType = AggregationCount;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_DonutSum_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Donut;
            _reportingChart.PropChartAggregationType = AggregationSum;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_DonutAverage_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Donut;
            _reportingChart.PropChartAggregationType = AggregationAverage;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_BarClusteredCount_DoesntSelectValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Bar_Clustered;
            _reportingChart.PropChartAggregationType = AggregationCount;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_BarClusteredSum_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Bar_Clustered;
            _reportingChart.PropChartAggregationType = AggregationSum;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(0));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_BarClusteredAverage_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Bar_Clustered;
            _reportingChart.PropChartAggregationType = AggregationAverage;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(0));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_Bar100PercentCount_DoesntSelectValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Bar_100Percent;
            _reportingChart.PropChartAggregationType = AggregationCount;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_Bar100PercentSum_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Bar_100Percent;
            _reportingChart.PropChartAggregationType = AggregationSum;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(0));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_Bar100PercentAverage_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Bar_100Percent;
            _reportingChart.PropChartAggregationType = AggregationAverage;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(0));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_BarStackedCount_DoesntSelectValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Bar_Stacked;
            _reportingChart.PropChartAggregationType = AggregationCount;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(-1));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_BarStackedSum_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Bar_Stacked;
            _reportingChart.PropChartAggregationType = AggregationSum;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(0));
        }

        [TestMethod]
        public void SetDropDownListSelectedValues_BarStackedAverage_SelectsValue()
        {
            // Arrange
            _reportingChart.PropChartType = ChartType.Bar_Stacked;
            _reportingChart.PropChartAggregationType = AggregationAverage;
            FillDropDowns();
            _reportingChart.SetYFieldsValues(new string[] { DummyString });

            // Act
            _privateObject.Invoke(MethodSetDropDownListSelectedValues, new object[] { _reportingChart });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => GetDropDown(FieldDdlYaxisFieldNum).SelectedIndex.ShouldBe(0),
                () => GetDropDown(FieldDdlYaxisFieldNonNum).SelectedIndex.ShouldBe(0),
                () => GetCheckBoxList(FieldCblYaxisFieldNum).SelectedIndex.ShouldBe(0));
        }

        private void FillDropDowns(bool callMethods = false)
        {
            SetDropDownListValue(FieldListsDropDownList, DummyString, true);
            if (callMethods)
            {
                _privateObject.Invoke(MethodFillDropDowns);
                _privateObject.Invoke(MethodLoadAndSetAggregateTypes, new object[] { _reportingChart });
                _privateObject.Invoke(MethodLoadAndSetChartTypes, new object[] { _reportingChart });
            }
            else
            {
                SetDropDownListValue(FieldDdlYaxisFieldNum, DummyString, false);
                SetCheckBoxListValue(FieldCblYaxisFieldNum, DummyString, false);
            }
            SetDropDownListValue(FieldDdlYaxisFieldNonNum, DummyString, false);
        }

        private void SetFields(string chartType, string aggregationType)
        {
            SetTextBoxText(FieldChartTitleTextBox, DummyString);
            SetDropDownListValue(FieldChartTypeDropDownList, chartType);
            SetDropDownListValue(FieldChartPaletteStyleDropDownList, ColorBlue);
            SetDropDownListValue(FieldListsDropDownList, DummyString);
            SetDropDownListValue(FieldViewsDropDownList, DummyString);
            SetDropDownListValue(FieldXaxisFieldDropDownList, AggregationCount);
            SetDropDownListValue(FieldBubbleGroupByDropDownList, ChartTypeBubble);
            SetDropDownListValue(FieldDdlXaxisFieldNum, ChartTypeBubble);
            SetDropDownListValue(FieldDdlXaxisFieldNonNum, AggregationSum);
            SetDropDownListValue(FieldDdlYaxisFieldNum, AggregationSum);
            SetDropDownListValue(FieldDdlYaxisFieldNonNum, AggregationCount);
            SetDropDownListValue(FieldYaxisFormatDropDownList, DummyString);
            SetDropDownListValue(FieldZaxisFieldDropDownList, DummyString);
            SetDropDownListValue(FieldLegendPositionDropDownList, PositionTop);
            SetDropDownListValue(FieldCblYaxisFieldNum, AggregationSum);
            SetCheckBox(FieldShowGridlinesCheckBox, true);
            SetCheckBox(FieldShowLabelsCheckBox, true);
            SetCheckBox(FieldShowLegendCheckBox, true);
            SetHtmlSelect(FieldAggregateTypeHtmlSelect, aggregationType);
        }

        private void SetTextBoxText(string name, string value)
        {
            var field = _privateObject.GetFieldOrProperty(name);
            var textBox = field as TextBox;
            if (textBox != null)
            {
                textBox.Text = value;
            }
        }

        private DropDownList SetDropDownListValue(string name, string value, bool selectsValue = true)
        {
            var dropDown = GetDropDown(name);
            if (dropDown != null)
            {
                dropDown.Items.Add(value);
                if (selectsValue)
                {
                    dropDown.SelectedValue = value;
                }
            }
            return dropDown;
        }

        private void SetCheckBox(string name, bool value)
        {
            var field = _privateObject.GetFieldOrProperty(name);
            var textBox = field as CheckBox;
            if (textBox != null)
            {
                textBox.Checked = value;
            }
        }

        private void SetCheckBoxListValue(string name, string value, bool selectsValue = true)
        {
            var checkBoxList = GetCheckBoxList(name);
            if (checkBoxList != null)
            {
                checkBoxList.Items.Add(value);
                if (selectsValue)
                {
                    checkBoxList.SelectedValue = value;
                }
            }
        }

        private void SetHtmlSelect(string name, string value)
        {
            var field = _privateObject.GetFieldOrProperty(name);
            var htmlSelect = field as HtmlSelect;
            if (htmlSelect != null)
            {
                htmlSelect.Items.Add(value);
                htmlSelect.Value = value;
            }
        }

        private void AssertCheckBoxChecked(string name, bool isChecked)
        {
            var field = _privateObject.GetFieldOrProperty(name);
            var checkBox = field as CheckBox;
            checkBox.ShouldSatisfyAllConditions(
                () => checkBox.ShouldNotBeNull(),
                () => checkBox.Checked.ShouldBe(isChecked));
        }

        private void AssertChartTypeDropDown(DropDownList dropdown)
        {
            dropdown.ShouldSatisfyAllConditions(
                () => dropdown.Items.Count.ShouldBe(15),
                () => dropdown.Items[0].Value.ShouldBe(ChartTypeArea),
                () => dropdown.Items[1].Value.ShouldBe(ChartTypeAreaClustered),
                () => dropdown.Items[2].Value.ShouldBe(ChartTypeBar),
                () => dropdown.Items[3].Value.ShouldBe(ChartTypeBar100Percent),
                () => dropdown.Items[4].Value.ShouldBe(ChartTypeBarClustered),
                () => dropdown.Items[5].Value.ShouldBe(ChartTypeBarStacked),
                () => dropdown.Items[6].Value.ShouldBe(ChartTypeBubble),
                () => dropdown.Items[7].Value.ShouldBe(ChartTypeColumn),
                () => dropdown.Items[8].Value.ShouldBe(ChartTypeColumn100Percent),
                () => dropdown.Items[9].Value.ShouldBe(ChartTypeColumnClustered),
                () => dropdown.Items[10].Value.ShouldBe(ChartTypeColumnStacked),
                () => dropdown.Items[11].Value.ShouldBe(ChartTypeDonut),
                () => dropdown.Items[12].Value.ShouldBe(ChartTypeLine),
                () => dropdown.Items[13].Value.ShouldBe(ChartTypeLineClustered),
                () => dropdown.Items[14].Value.ShouldBe(ChartTypePie));
        }

        private void AssertContainsControl(string name)
        {
            var field = _privateObject.GetFieldOrProperty(name);
            var control = field as Control;
            _testObject.ShouldSatisfyAllConditions(
                () => control.ShouldNotBeNull(),
                () => control.EnableViewState.ShouldBeTrue(),
                () => ContainsControl(control));
        }

        private bool ContainsControl(Control control)
        {
            if (control == null)
            {
                return false;
            }

            foreach (var item in _testObject.Controls)
            {
                if (item == control)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
