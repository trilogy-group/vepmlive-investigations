using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using EPMLiveWebParts.EpmCharting.DomainServices;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint;
using System.Web;

namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:CustomToolPart runat=server></{0}:CustomToolPart>")]
    public class ChartControlToolpartBase : ToolPart
    {
        #region Fields

        protected DropDownList ChartTypeDropDownList;
        protected DropDownList ChartPaletteStyleDropDownList;
        protected DropDownList ListsDropDownList;
        protected DropDownList ViewsDropDownList;
        protected DropDownList XaxisFieldDropDownList;
        protected DropDownList BubbleChartColorFieldDropDownList;
        protected DropDownList SeriesNameLabelPositionDropDownList;
        protected DropDownList SeriesValueLabelPositionDropDownList;
        protected DropDownList FrameColorDropDownList;
        protected DropDownList ZaxisFieldDropDownList;
        protected DropDownList YaxisFieldAsDropDownList;
        protected CheckBoxList YaxisFieldCheckBoxList;
        protected CheckBox ShowProjectsCheckBox;
        protected CheckBox ShowBubbleChartInputsInWebPart;
        protected CheckBox ShowIn3DCheckBox;
        protected CheckBox ShowLegendCheckBox;
        protected CheckBox ShowGridlinesCheckBox;
        protected CheckBox ShowLabelsCheckBox;
        protected CheckBox ShowSeriesNameAsLabelCheckBox;
        protected CheckBox ShowSeriesValueAsLabelCheckBox;
        protected CheckBox ShowYaxisValuesAsPercentageCheckBox;
        protected CheckBox ShowYaxisValuesAsCurrencyCheckBox;
        protected CheckBox ShowFrameCheckBox;
        protected CheckBox FrameRoundCornersCheckBox;
        protected CheckBox RollupCheckBox;
        protected CheckBox ShowZeroValueDataCheckBox;
        protected TextBox NumberOfYaxisValuesTextBox;
        protected TextBox XaxisLabelRotationAngleTextBox;
        protected TextBox XaxisLabelFontSizeTextBox;
        protected TextBox ZaxisLabelRotationAngleTextBox;
        protected TextBox SeriesDataPointLabelFontSizeTextBox;
        protected TextBox ChartLegendFontSizeCheckBox;
        protected TextBox RollupListsTextBox;
        protected TextBox RollupSitesTextBox;
        protected TextBox ChartTitleTextBox;
        protected TextBox ChartTitleFontSizeTextBox;
        protected HtmlSelect AggregateTypeHtmlSelect;

        #endregion

        public ChartControlToolpartBase()
        {
            UseDefaultStyles = true;
            AllowMinimize = true;
            Title = "Configure Chart";
        }

        protected override void OnInit(EventArgs e)
        {
            ChartTitleTextBox = new TextBox();
            ChartTitleFontSizeTextBox = new TextBox();
            ShowProjectsCheckBox = new CheckBox();
            ChartTypeDropDownList = new DropDownList();
            ChartPaletteStyleDropDownList = new DropDownList();
            ListsDropDownList = new DropDownList();
            ViewsDropDownList = new DropDownList();
            XaxisFieldDropDownList = new DropDownList();
            AggregateTypeHtmlSelect = new HtmlSelect();
            YaxisFieldCheckBoxList = new CheckBoxList();
            YaxisFieldAsDropDownList = new DropDownList();
            NumberOfYaxisValuesTextBox = new TextBox();
            XaxisLabelRotationAngleTextBox = new TextBox();
            XaxisLabelFontSizeTextBox = new TextBox();
            ChartLegendFontSizeCheckBox = new TextBox();
            ZaxisLabelRotationAngleTextBox = new TextBox();
            SeriesDataPointLabelFontSizeTextBox = new TextBox();
            ZaxisFieldDropDownList = new DropDownList();
            ShowIn3DCheckBox = new CheckBox();
            ShowGridlinesCheckBox = new CheckBox();
            ShowLabelsCheckBox = new CheckBox();
            ShowLegendCheckBox = new CheckBox();
            ShowZeroValueDataCheckBox = new CheckBox();
            SeriesNameLabelPositionDropDownList = new DropDownList();
            SeriesValueLabelPositionDropDownList = new DropDownList();
            ShowYaxisValuesAsPercentageCheckBox = new CheckBox();
            ShowYaxisValuesAsCurrencyCheckBox = new CheckBox();
            ShowFrameCheckBox = new CheckBox();
            FrameColorDropDownList = new DropDownList();
            FrameRoundCornersCheckBox = new CheckBox();
            RollupListsTextBox = new TextBox();
            RollupSitesTextBox = new TextBox();
            BubbleChartColorFieldDropDownList = new DropDownList();
            ShowBubbleChartInputsInWebPart = new CheckBox();
        }

        protected override void CreateChildControls()
        {
            CreateDisplayOptionControls();
            CreateXaxisControls();
            CreateYaxisControls();
            CreateZaxisControls();
        }

        protected override void OnPreRender(EventArgs e)
        {
            ForcePageToNotCache();

            using (var site = new SPSite(SPContext.Current.Site.Url))
            {
                using (var web = site.OpenWeb(SPContext.Current.Web.ID))
                {
                    var chart = (ChartControl)ParentToolPane.SelectedWebPart;

                    SetTextBoxValues(chart);

                    ClearDropDownLists();

                    SetupAggregateTypeHtmlSelect(chart);
                    SetupDropDownLists(web, chart);
                    SetDropDownListSelectedValues(chart);
                    SetupCheckBoxes(chart);
                }
            }
        }

        protected override void RenderToolPart(HtmlTextWriter output)
        {
            WriteJavascript(output);
            WriteDisplayOptionsSectionHtml(output);
            WriteXaxisSectionHtml(output);
            WriteYaxisSectionHtml(output);
            WriteZaxisSectionHtml(output);
            WriteOptionsSectionHtml(output);
        }

        protected void ChartTypeDropDownListSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChartTypeDropDownList.SelectedValue.Contains("None Selected")) return;

            ApplyChanges();
        }

        protected void ListsDropDownListSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListsDropDownList.SelectedValue == "<Select List>") return;

            using (var site = new SPSite(SPContext.Current.Site.Url))
            {
                using (var web = site.OpenWeb(SPContext.Current.Web.ID))
                {
                    var oList = web.Lists[ListsDropDownList.SelectedValue];

                    if (oList == null) return;

                    var myChart = (ChartControl)ParentToolPane.SelectedWebPart;
                    myChart.PropChartSelectedList = ListsDropDownList.SelectedValue;
                    myChart.PropChartTitle = ChartTitleTextBox.Text;
                    FillDropdowns(oList);
                }
            }
        }

        public override void ApplyChanges()
        {
            EnsureChildControls();

            var tp = ParentToolPane;
            var chartWp = (ChartControl)tp.SelectedWebPart;

            chartWp.PropChartTitle = ChartTitleTextBox.Text;
            chartWp.PropChartMainStyle = ChartTypeDropDownList.SelectedValue;
            chartWp.PropChartSelectedPaletteName = ChartPaletteStyleDropDownList.SelectedValue;
            chartWp.PropChartSelectedList = ListsDropDownList.SelectedValue;
            chartWp.PropChartSelectedView = ViewsDropDownList.SelectedValue;
            chartWp.PropChartRollupLists = RollupListsTextBox.Text;
            chartWp.PropChartView3D = ShowIn3DCheckBox.Checked;
            chartWp.PropChartShowBubbleChartInputsInWebPart = ShowBubbleChartInputsInWebPart.Checked;
            chartWp.PropChartShowGridlines = ShowGridlinesCheckBox.Checked;
            chartWp.PropChartShowSeriesLabels = ShowLabelsCheckBox.Checked;
            chartWp.PropChartShowZeroValueData = ShowZeroValueDataCheckBox.Checked;
            chartWp.PropBubbleChartColorField = BubbleChartColorFieldDropDownList.SelectedValue;
            chartWp.PropChartAggregationType = AggregateTypeHtmlSelect.Value;
            chartWp.PropChartXaxisField = XaxisFieldDropDownList.SelectedValue;
            chartWp.PropChartXaxisFieldLabel = XaxisFieldDropDownList.SelectedItem.Text;

            if (YaxisFieldAsDropDownList.SelectedItem != null)
            {
                chartWp.PropChartYaxisFieldLabel = YaxisFieldAsDropDownList.SelectedItem.Text;
            }

            chartWp.PropChartZaxisFieldLabel = ZaxisFieldDropDownList.SelectedItem.Text;

            if (IsBubbleChart())
            {
                chartWp.PropChartAggregationType = "SUM";
            }


            if (chartWp.PropChartAggregationType == "SUM" && !IsBubbleChart())
            {
                chartWp.PropChartZaxisField = "None Selected";
            }
            else
            {
                chartWp.PropChartZaxisField = ZaxisFieldDropDownList.SelectedValue;
            }

            if (chartWp.PropChartAggregationType == "COUNT")
            {
                chartWp.PropChartYaxisField = "";
            }
            else
            {
                if (!IsBubbleChart())
                {
                    chartWp.SetYField((from ListItem li in YaxisFieldCheckBoxList.Items where li.Selected select li.Value).ToArray());
                }
                else
                {
                    chartWp.SetYField(new[] {YaxisFieldAsDropDownList.SelectedValue});
                }
            }


            chartWp.PropChartRollupLists = RollupListsTextBox.Text;
            chartWp.PropChartRollupSites = RollupSitesTextBox.Text;

            chartWp.PropChartShowLegend = ShowLegendCheckBox.Checked;
            chartWp.PropChartShowYaxisValuesAsPercentage = ShowYaxisValuesAsPercentageCheckBox.Checked;
            chartWp.PropChartShowYaxisValuesAsCurrency = ShowYaxisValuesAsCurrencyCheckBox.Checked;

            chartWp.RebuildControlTree();
        }

        #region Control Creation

        private void CreateDisplayOptionControls()
        {
            ChartTitleTextBox.EnableViewState = true;
            Controls.Add(ChartTitleTextBox);

            ChartTitleFontSizeTextBox.EnableViewState = true;
            ChartTitleFontSizeTextBox.Text = "16";
            ChartTitleFontSizeTextBox.Width = 35;
            Controls.Add(ChartTitleFontSizeTextBox);

            ShowProjectsCheckBox.EnableViewState = true;
            Controls.Add(ShowProjectsCheckBox);

            ChartTypeDropDownList.SelectedIndexChanged += ChartTypeDropDownListSelectedIndexChanged;
            ChartTypeDropDownList.AutoPostBack = true;
            ChartTypeDropDownList.EnableViewState = true;
            Controls.Add(ChartTypeDropDownList);

            ChartPaletteStyleDropDownList.EnableViewState = true;
            Controls.Add(ChartPaletteStyleDropDownList);

            ListsDropDownList.SelectedIndexChanged += ListsDropDownListSelectedIndexChanged;
            ListsDropDownList.AutoPostBack = true;
            ListsDropDownList.EnableViewState = true;
            Controls.Add(ListsDropDownList);

            ViewsDropDownList.EnableViewState = true;
            Controls.Add(ViewsDropDownList);

            AggregateTypeHtmlSelect.EnableViewState = true;
            Controls.Add(AggregateTypeHtmlSelect);

            ShowLegendCheckBox.EnableViewState = true;
            Controls.Add(ShowLegendCheckBox);

            SeriesNameLabelPositionDropDownList.EnableViewState = true;
            Controls.Add(SeriesNameLabelPositionDropDownList);

            SeriesValueLabelPositionDropDownList.EnableViewState = true;
            Controls.Add(SeriesValueLabelPositionDropDownList);

            ShowFrameCheckBox.EnableViewState = true;
            Controls.Add(ShowFrameCheckBox);

            FrameColorDropDownList.EnableViewState = true;
            Controls.Add(FrameColorDropDownList);

            FrameRoundCornersCheckBox.EnableViewState = true;
            Controls.Add(FrameRoundCornersCheckBox);

            SeriesDataPointLabelFontSizeTextBox.Text = "10";
            SeriesDataPointLabelFontSizeTextBox.Width = 35;
            SeriesDataPointLabelFontSizeTextBox.EnableViewState = true;
            Controls.Add(SeriesDataPointLabelFontSizeTextBox);

            ChartLegendFontSizeCheckBox.Text = "10";
            ChartLegendFontSizeCheckBox.Width = 35;
            ChartLegendFontSizeCheckBox.EnableViewState = true;
            Controls.Add(ChartLegendFontSizeCheckBox);

            ShowZeroValueDataCheckBox.EnableViewState = true;
            Controls.Add(ShowZeroValueDataCheckBox);

            ShowIn3DCheckBox.EnableViewState = true;
            Controls.Add(ShowIn3DCheckBox);

            ShowGridlinesCheckBox.EnableViewState = true;
            Controls.Add(ShowGridlinesCheckBox);

            ShowLabelsCheckBox.EnableViewState = true;
            Controls.Add(ShowLabelsCheckBox);

            ShowBubbleChartInputsInWebPart.EnableViewState = true;

            Controls.Add(ShowBubbleChartInputsInWebPart);

            RollupListsTextBox.EnableViewState = true;
            RollupListsTextBox.TextMode = TextBoxMode.MultiLine;
            RollupListsTextBox.Height = 75;
            RollupListsTextBox.Width = 225;
            Controls.Add(RollupListsTextBox);

            RollupSitesTextBox.EnableViewState = true;
            RollupSitesTextBox.TextMode = TextBoxMode.MultiLine;
            RollupSitesTextBox.Height = 75;
            RollupSitesTextBox.Width = 225;
            Controls.Add(RollupSitesTextBox);

        }

        private void CreateZaxisControls()
        {
            ZaxisLabelRotationAngleTextBox.Text = "-27";
            ZaxisLabelRotationAngleTextBox.Width = 35;
            ZaxisLabelRotationAngleTextBox.EnableViewState = true;
            Controls.Add(ZaxisLabelRotationAngleTextBox);

            ZaxisFieldDropDownList.EnableViewState = true;
            Controls.Add(ZaxisFieldDropDownList);

            BubbleChartColorFieldDropDownList.EnableViewState = true;
            Controls.Add(BubbleChartColorFieldDropDownList);
        }

        private void CreateYaxisControls()
        {
            YaxisFieldCheckBoxList.EnableViewState = true;
            Controls.Add(YaxisFieldCheckBoxList);

            YaxisFieldAsDropDownList.EnableViewState = true;
            Controls.Add(YaxisFieldAsDropDownList);

            NumberOfYaxisValuesTextBox.EnableViewState = true;
            NumberOfYaxisValuesTextBox.Width = 35;
            Controls.Add(NumberOfYaxisValuesTextBox);

            ShowYaxisValuesAsPercentageCheckBox.EnableViewState = true;
            Controls.Add(ShowYaxisValuesAsPercentageCheckBox);

            ShowYaxisValuesAsCurrencyCheckBox.EnableViewState = true;
            Controls.Add(ShowYaxisValuesAsCurrencyCheckBox);
        }

        private void CreateXaxisControls()
        {
            XaxisFieldDropDownList.EnableViewState = true;
            Controls.Add(XaxisFieldDropDownList);

            XaxisLabelRotationAngleTextBox.Text = "0";
            XaxisLabelRotationAngleTextBox.Width = 35;
            XaxisLabelRotationAngleTextBox.EnableViewState = true;
            Controls.Add(XaxisLabelRotationAngleTextBox);

            XaxisLabelFontSizeTextBox.Text = "10";
            XaxisLabelFontSizeTextBox.Width = 35;
            XaxisLabelFontSizeTextBox.EnableViewState = true;
            Controls.Add(XaxisLabelFontSizeTextBox);
        }

        #endregion

        #region Control Setup

        private void SetDropDownListSelectedValues(ChartControl chart)
        {
            if (ZaxisFieldDropDownList.Items.FindByValue(chart.PropChartZaxisField) != null)
            {
                ZaxisFieldDropDownList.SelectedValue = chart.PropChartZaxisField;
            }

            if (BubbleChartColorFieldDropDownList.Items.FindByValue(chart.PropBubbleChartColorField) != null)
            {
                BubbleChartColorFieldDropDownList.SelectedValue = chart.PropBubbleChartColorField;
            }

            if (!string.IsNullOrEmpty(chart.PropChartYaxisField))
            {
                foreach (var sFld in chart.GetYaxisFields())
                {
                    var yAxisFieldItems = YaxisFieldCheckBoxList.Items.FindByValue(sFld);
                    if (yAxisFieldItems != null)
                    {
                        if (!IsBubbleChart())
                        {
                            YaxisFieldCheckBoxList.Items.FindByValue(sFld).Selected = true;
                        }
                        else
                        {
                            YaxisFieldAsDropDownList.Items.FindByValue(sFld).Selected = true;
                        }
                    }
                }
            }

            SeriesNameLabelPositionDropDownList.SelectedValue = chart.PropChartSeriesNameLabelPosition;
            SeriesValueLabelPositionDropDownList.SelectedValue = chart.PropChartSeriesValueLabelPosition;
        }

        private void SetupDropDownLists(SPWeb web, ChartControl chart)
        {
            foreach (var chartType in VfChart.ChartTypes)
            {
                ChartTypeDropDownList.Items.Add(new ListItem(chartType.Key, chartType.Value));
            }

            ChartTypeDropDownList.SelectedValue = chart.PropChartMainStyle;

            foreach (var palette in VfChart.Palettes)
            {
                ChartPaletteStyleDropDownList.Items.Add(new ListItem(palette.Key, palette.Value));
            }

            if (ChartPaletteStyleDropDownList.Items.FindByValue(chart.PropChartSelectedPaletteName) != null)
            {
                ChartPaletteStyleDropDownList.SelectedValue = chart.PropChartSelectedPaletteName;
            }

            ListsDropDownList.Items.Add("<Select List>");
            foreach (SPList lst in web.Lists)
            {
                if (!lst.Hidden)
                {
                    ListsDropDownList.Items.Add(lst.Title);
                }
            }

            if (!String.IsNullOrEmpty(chart.PropChartSelectedList.Trim()))
            {
                FillDropdowns(web.Lists[chart.PropChartSelectedList]);
            }

            if (ListsDropDownList.Items.FindByValue(chart.PropChartSelectedList) != null)
            {
                ListsDropDownList.SelectedValue = chart.PropChartSelectedList;
            }

            if (ViewsDropDownList.Items.FindByValue(chart.PropChartSelectedView) != null)
            {
                ViewsDropDownList.SelectedValue = chart.PropChartSelectedView;
            }

            if (XaxisFieldDropDownList.Items.FindByValue(chart.PropChartXaxisField) != null)
            {
                XaxisFieldDropDownList.SelectedValue = chart.PropChartXaxisField;
            }

            SeriesNameLabelPositionDropDownList.Items.Add(" --- Do Not Show ---");
            SeriesNameLabelPositionDropDownList.Items.Remove("Custom");
            SeriesValueLabelPositionDropDownList.Items.Remove("Custom");
            SeriesValueLabelPositionDropDownList.Items.Remove("Default");
            SeriesValueLabelPositionDropDownList.Items.Add(" --- Do Not Show ---");

            var knownColors = Enum.GetNames(typeof(KnownColor));
            foreach (string sColor in knownColors)
            {
                FrameColorDropDownList.Items.Add(sColor);
            }
        }

        private void SetupCheckBoxes(ChartControl chart)
        {
            ShowIn3DCheckBox.Checked = chart.PropChartView3D;
            ShowGridlinesCheckBox.Checked = chart.PropChartShowGridlines;
            ShowLegendCheckBox.Checked = chart.PropChartShowLegend;
            ShowLabelsCheckBox.Checked = chart.PropChartShowSeriesLabels;
            ShowZeroValueDataCheckBox.Checked = chart.PropChartShowZeroValueData;
            ShowYaxisValuesAsPercentageCheckBox.Checked = chart.PropChartShowYaxisValuesAsPercentage;
            ShowYaxisValuesAsCurrencyCheckBox.Checked = chart.PropChartShowYaxisValuesAsCurrency;
            FrameRoundCornersCheckBox.Checked = chart.PropChartFrameRoundCorners;
            ShowFrameCheckBox.Checked = chart.PropChartShowFrame;
            ShowBubbleChartInputsInWebPart.Checked = chart.PropChartShowBubbleChartInputsInWebPart;
        }

        private void SetupAggregateTypeHtmlSelect(ChartControl chart)
        {
            AggregateTypeHtmlSelect.Attributes.Add("onChange", "aggreg_change(this.value)");
            AggregateTypeHtmlSelect.Items.Add("COUNT");
            AggregateTypeHtmlSelect.Items.Add("SUM");
            AggregateTypeHtmlSelect.Items.Add("AVG");
            AggregateTypeHtmlSelect.Value = chart.PropChartAggregationType;
        }

        private void SetTextBoxValues(ChartControl chart)
        {
            ChartTitleTextBox.Text = chart.PropChartTitle;
            ChartTitleFontSizeTextBox.Text = chart.PropChartTitleFontSize.ToString();
            NumberOfYaxisValuesTextBox.Text = chart.PropChartYaxisNumValues.ToString();
            XaxisLabelRotationAngleTextBox.Text = chart.PropChartXaxisLabelRotationAngle.ToString();
            ZaxisLabelRotationAngleTextBox.Text = chart.PropChartZaxisLabelRotationAngle.ToString();
            XaxisLabelFontSizeTextBox.Text = chart.PropChartXaxisLabelFontSize.ToString();
            ChartLegendFontSizeCheckBox.Text = chart.PropChartLegendFontSize.ToString();
            SeriesDataPointLabelFontSizeTextBox.Text = chart.PropChartSeriesDataPointLabelFontSize.ToString();
            RollupListsTextBox.Text = chart.PropChartRollupLists;
            RollupSitesTextBox.Text = chart.PropChartRollupSites;
        }

        private void ClearDropDownLists()
        {
            ZaxisFieldDropDownList.Items.Clear();
            SeriesNameLabelPositionDropDownList.Items.Clear();
            SeriesValueLabelPositionDropDownList.Items.Clear();
            ChartTypeDropDownList.Items.Clear();
            ChartPaletteStyleDropDownList.Items.Clear();
            ListsDropDownList.Items.Clear();
            ViewsDropDownList.Items.Clear();
            XaxisFieldDropDownList.Items.Clear();
            BubbleChartColorFieldDropDownList.Items.Clear();
            AggregateTypeHtmlSelect.Items.Clear();
            YaxisFieldCheckBoxList.Items.Clear();
            YaxisFieldAsDropDownList.Items.Clear();
        }

        private void FillDropdowns(SPList oList)
        {
            if (!IsBubbleChart())
            {
                ZaxisFieldDropDownList.Items.Add("-- None Selected --");
            }

            foreach (SPField fld in oList.Fields)
            {
                if (fld.Type == SPFieldType.Choice)
                {
                    var colorFieldListItem = new ListItem(fld.Title, fld.InternalName);
                    BubbleChartColorFieldDropDownList.Items.Add(colorFieldListItem);
                }

                if (fld.Type == SPFieldType.Attachments || fld.InternalName == "Order" ||
                    fld.Type == SPFieldType.File || fld.InternalName == "MetaInfo" ||
                    fld.Type == SPFieldType.Computed ||
                    (fld.FromBaseType && (!fld.FromBaseType || fld.InternalName != "Title"))) continue;

                var liX = new ListItem(fld.Title, fld.InternalName);
                
                if (!IsBubbleChart() || (IsBubbleChart() && ChartHelper.IsCalculateableSharepointField(fld)))
                {
                    XaxisFieldDropDownList.Items.Add(liX);
                }
                
                
                var liZ = new ListItem(fld.Title, fld.InternalName);

                if (IsBubbleChart())
                {
                    if (ChartHelper.IsCalculateableSharepointField(fld))
                    {
                        ZaxisFieldDropDownList.Items.Add(liZ);
                    }
                }
                else
                {
                    ZaxisFieldDropDownList.Items.Add(liZ);
                }

                if (fld.TypeAsString != "Currency" && fld.TypeAsString != "Number" &&
                    (fld.Type != SPFieldType.Calculated ||
                        EpmChart.GetFieldSchemaAttribValue(fld.SchemaXml, "ResultType") != "Number") &&
                    (fld.Type != SPFieldType.Calculated ||
                        EpmChart.GetFieldSchemaAttribValue(fld.SchemaXml, "ResultType") != "Currency")) continue;

                var liY = new ListItem(fld.Title, fld.InternalName);
                YaxisFieldCheckBoxList.Items.Add(liY);
                YaxisFieldAsDropDownList.Items.Add(liY);
            }

            foreach (SPView vw in oList.Views)
            {
                ViewsDropDownList.Items.Add(vw.Title);
            }

            SortDropDownList(ViewsDropDownList);
            SortDropDownList(XaxisFieldDropDownList);
            SortDropDownList(YaxisFieldAsDropDownList);
            SortDropDownList(ZaxisFieldDropDownList);
            SortDropDownList(BubbleChartColorFieldDropDownList);
        }

        private static void SortDropDownList(DropDownList dropDownList)
        {
            var textList = new ArrayList();
            var valueList = new ArrayList();

            foreach (ListItem listItem in dropDownList.Items)
            {
                textList.Add(listItem.Text);
            }

            textList.Sort();

            foreach (var item in textList)
            {
                var value = dropDownList.Items.FindByText(item.ToString()).Value;
                valueList.Add(value);
            }
            dropDownList.Items.Clear();

            for (var counter = 0; counter < textList.Count; counter++)
            {
                var objItem = new ListItem(textList[counter].ToString(), valueList[counter].ToString());
                dropDownList.Items.Add(objItem);
            }
        }

        #endregion

        #region Output Html

        private void WriteXaxisSectionHtml(HtmlTextWriter output)
        {
            output.Write("<b>X Axis</b><br>");
            XaxisFieldDropDownList.RenderControl(output);
            output.Write("</td></tr><tr><td>");

            if (!IsBubbleChart())
            {
                output.Write("Aggregation Type<br>");
                AggregateTypeHtmlSelect.RenderControl(output);
                output.Write("<br></td></tr><tr><td>");
            }

            output.Write("</td></tr></table>");
            output.Write("</div>");
        }

        private void WriteDisplayOptionsSectionHtml(HtmlTextWriter output)
        {
            output.Write("<div class=\"UserSectionHead\">");
            output.Write("<b>Chart Display Options</b>");
            output.Write("<br />");
            output.Write("<table cellpadding=1 style=\"padding-left: 5px\"><tr><td>");

            output.Write("List<br>");
            ListsDropDownList.RenderControl(output);
            output.Write("</td></tr><tr><td>");
            output.Write("View<br>");
            ViewsDropDownList.RenderControl(output);
            output.Write("</td></tr><tr><td>");

            output.Write("Rollup List(s)<br>");
            RollupListsTextBox.RenderControl(output);
            output.Write("</td></tr><tr><td>");

            output.Write("Rollup Site(s)<br>");
            RollupSitesTextBox.RenderControl(output);
            output.Write("</td></tr><tr><td>");

            ShowIn3DCheckBox.RenderControl(output);
            output.Write("Show in 3D<br></td></tr><tr><td>");

            ShowGridlinesCheckBox.RenderControl(output);
            output.Write("Show Gridlines<br></td></tr><tr><td>");

            if (IsBubbleChart())
            {
                ShowBubbleChartInputsInWebPart.RenderControl(output);
                output.Write("Allow User To Select X, Y, Z Values<br></td></tr><tr><td>");
            }

            ShowLabelsCheckBox.RenderControl(output);
            output.Write("Show X-Axis Labels<br></td></tr><tr><td>");

            ShowLegendCheckBox.RenderControl(output);
            output.Write("Show Legend<br></td></tr><tr><td>");

            ShowZeroValueDataCheckBox.RenderControl(output);
            output.Write("Display Zero Value Data<br></td></tr><tr><td>");
            
            output.Write("Chart Type<br>");
            ChartTypeDropDownList.RenderControl(output);
            output.Write("</td></tr><tr><td>");

            if (!IsBubbleChart())
            {
                output.Write("Palette<br>");
                ChartPaletteStyleDropDownList.RenderControl(output);
                output.Write("</td></tr><tr><td>");
            }
            output.Write("Title<br>");
            ChartTitleTextBox.RenderControl(output);
            output.Write("</td></tr><tr><td>");
        }

        private void WriteYaxisSectionHtml(HtmlTextWriter output)
        {
            output.Write(AggregateTypeHtmlSelect.Value.ToUpper() == "COUNT" && !IsBubbleChart()
                             ? "<div id=\"YaxisSection\" style=\"display:none\">"
                             : "<div id=\"YaxisSection\" >");

            output.Write("<table cellpadding=1 style=\"padding-left: 5px\"><tr><td>");
            output.Write("<b>Y Axis </b><br>");
            if (!IsBubbleChart())
            {
                output.Write(YaxisFieldCheckBoxList.Items.Count > 0 ? "Field(s)" : "Field(s)<br>No fields found.");
                YaxisFieldCheckBoxList.RenderControl(output);
            }
            else
            {
                YaxisFieldAsDropDownList.RenderControl(output);
            }
            
            output.Write("</td></tr><tr><td>");
            output.Write("<br>");

            output.Write("</td></tr></table>");
            output.Write("</div>");

            output.Write("<table cellpadding=1><tr><td>");
            output.Write("</td></tr><tr><td>");

            if (!IsBubbleChart())
            {
                output.Write("<b>Y Axis Formatting</b><br>");
                ShowYaxisValuesAsPercentageCheckBox.RenderControl(output);
                output.Write("Show Y axis values as percent</td></tr><tr><td>");
                ShowYaxisValuesAsCurrencyCheckBox.RenderControl(output);
                output.Write("Show Y axis values as currency</td></tr><tr><td>");
            }
        }

        private void WriteZaxisSectionHtml(HtmlTextWriter output)
        {
            output.Write(AggregateTypeHtmlSelect.Value.ToUpper() == "SUM" && !IsBubbleChart()
                             ? "<div id=\"ZaxisSection\" style=\"display:none\">"
                             : "<div id=\"ZaxisSection\" >");
            output.Write("<table cellpadding=1><tr><td>");

            output.Write("<b>Z Axis</b><br>Field<br>");
            ZaxisFieldDropDownList.RenderControl(output);
            output.Write("</td></tr>");

            if (IsBubbleChart())
            {
                output.Write("</td></tr><tr><td>");
                output.Write("<b>Z Axis Color Field</b><br>");
                BubbleChartColorFieldDropDownList.RenderControl(output);
                output.Write("</td></tr>");
            }

            output.Write("<tr><td></td></tr></table>");
            output.Write("</div>");
        }

        private static void WriteOptionsSectionHtml(HtmlTextWriter output)
        {
            output.Write("<div class=\"OptionsSection\">");
            output.Write("<table cellpadding=1><tr><td>");
            output.Write("</td></tr></table>");
            output.Write("</div>");
        }

        private static void WriteJavascript(HtmlTextWriter output)
        {
            output.Write("<script type=\"text/javascript\">");
            output.Write("function aggreg_change(selval) ");
            output.Write("{");
            output.Write(" if (selval == \"COUNT\")");
            output.Write(" { ");
            output.Write("  document.getElementById(\"YaxisSection\").style.display = \"none\"; ");
            output.Write(" } ");
            output.Write(" else ");
            output.Write(" { ");
            output.Write("  document.getElementById(\"YaxisSection\").style.display = \"\"; ");
            output.Write(" } ");

            output.Write(" if (selval == \"SUM\")");
            output.Write(" { ");
            output.Write("  document.getElementById(\"ZaxisSection\").style.display = \"none\"; ");
            output.Write(" } ");
            output.Write(" else ");
            output.Write(" { ");
            output.Write("  document.getElementById(\"ZaxisSection\").style.display = \"\"; ");
            output.Write(" } ");

            output.Write("}");
            output.Write("</script>");
        }

        #endregion

        #region Helper Methods

        private void ForcePageToNotCache()
        {
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Page.Response.Expires = -1;
        }

        private bool IsBubbleChart()
        {
            return ChartTypeDropDownList.SelectedValue.ToLower() == "bubble";
        }

        #endregion
    }
}
