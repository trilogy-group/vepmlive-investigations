using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EPMLiveCore.ReportingProxy;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveWebParts.ReportingChart
{
    [ToolboxData("<{0}:CustomToolPart runat=server></{0}:CustomToolPart>")]
    public class ReportingChartToolPart : ToolPart
    {
        #region Fields

        protected DropDownList ChartTypeDropDownList;
        protected DropDownList ChartPaletteStyleDropDownList;
        protected DropDownList ListsDropDownList;
        protected DropDownList ViewsDropDownList;
        protected DropDownList BubbleChartColorFieldDropDownList;
        protected DropDownList SeriesNameLabelPositionDropDownList;
        protected DropDownList SeriesValueLabelPositionDropDownList;
        protected DropDownList FrameColorDropDownList;
        protected DropDownList XaxisFieldDropDownList;
        protected DropDownList ddlXaxisFieldNum;
        protected DropDownList ddlXaxisFieldNonNum;
        protected DropDownList ddlYaxisFieldNum;
        protected DropDownList ddlYaxisFieldNonNum;
        protected DropDownList ZaxisFieldDropDownList;
        protected DropDownList BubbleGroupByDropDownList;
        protected HtmlSelect AggregateTypeHtmlSelect;
        protected DropDownList YaxisFormatDropDownList;
        protected DropDownList LegendPositionDropDownList;
        protected CheckBoxList cblYaxisFieldNum;
        protected CheckBoxList cblYaxisFieldNonNum;
        protected CheckBox ShowProjectsCheckBox;
        //protected CheckBox ShowBubbleChartInputsInWebPart;
        //protected CheckBox ShowIn3DCheckBox;
        protected CheckBox ShowLegendCheckBox;
        protected CheckBox ShowGridlinesCheckBox;
        protected CheckBox ShowLabelsCheckBox;
        protected CheckBox ShowSeriesNameAsLabelCheckBox;
        protected CheckBox ShowSeriesValueAsLabelCheckBox;
        protected CheckBox ShowFrameCheckBox;
        protected CheckBox FrameRoundCornersCheckBox;
        protected CheckBox RollupCheckBox;
        //protected CheckBox ShowZeroValueDataCheckBox;
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


        #endregion

        public ReportingChartToolPart()
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
            ddlXaxisFieldNum = new DropDownList();
            ddlXaxisFieldNonNum = new DropDownList();
            AggregateTypeHtmlSelect = new HtmlSelect();
            YaxisFormatDropDownList = new DropDownList();
            LegendPositionDropDownList = new DropDownList();
            cblYaxisFieldNum = new CheckBoxList();
            cblYaxisFieldNonNum = new CheckBoxList();
            ddlYaxisFieldNum = new DropDownList();
            ddlYaxisFieldNonNum = new DropDownList();
            NumberOfYaxisValuesTextBox = new TextBox();
            XaxisLabelRotationAngleTextBox = new TextBox();
            XaxisLabelFontSizeTextBox = new TextBox();
            ChartLegendFontSizeCheckBox = new TextBox();
            ZaxisLabelRotationAngleTextBox = new TextBox();
            SeriesDataPointLabelFontSizeTextBox = new TextBox();
            ZaxisFieldDropDownList = new DropDownList();
            BubbleGroupByDropDownList = new DropDownList();
            //ShowIn3DCheckBox = new CheckBox();
            ShowGridlinesCheckBox = new CheckBox();
            ShowLabelsCheckBox = new CheckBox();
            ShowLegendCheckBox = new CheckBox();
            //ShowZeroValueDataCheckBox = new CheckBox();
            SeriesNameLabelPositionDropDownList = new DropDownList();
            SeriesValueLabelPositionDropDownList = new DropDownList();
            ShowFrameCheckBox = new CheckBox();
            FrameColorDropDownList = new DropDownList();
            FrameRoundCornersCheckBox = new CheckBox();
            RollupListsTextBox = new TextBox();
            RollupSitesTextBox = new TextBox();
            BubbleChartColorFieldDropDownList = new DropDownList();
            //ShowBubbleChartInputsInWebPart = new CheckBox();
        }

        protected override void CreateChildControls()
        {
            CreateConfigSectionControls();
            CreateDisplaySectionControls();
        }

        protected override void OnPreRender(EventArgs e)
        {
            ForcePageToNotCache();

            using (var site = new SPSite(SPContext.Current.Site.Url))
            {
                using (var web = site.OpenWeb(SPContext.Current.Web.ID))
                {
                    var chart = (ReportingChart)ParentToolPane.SelectedWebPart;
                    LoadAndSetSelectedList(web, chart);
                    LoadAndSetViews(chart);
                    LoadAndSetChartTypes(chart);
                    LoadAndSetAggregateTypes(chart);
                    FillDropDowns();

                    SetTextBoxValues(chart);
                    SetupCheckBoxes(chart);
                }
            }
        }

        private void LoadAndSetAggregateTypes(ReportingChart chart)
        {
            AggregateTypeHtmlSelect.Items.Clear();
            AggregateTypeHtmlSelect.Items.Add("Count");
            AggregateTypeHtmlSelect.Items.Add("Sum");
            AggregateTypeHtmlSelect.Items.Add("Avg");
            AggregateTypeHtmlSelect.Attributes.Add("onChange", "ctype_agg_change()");
            if (!string.IsNullOrEmpty(chart.PropChartAggregationType))
            {
                AggregateTypeHtmlSelect.Value = chart.PropChartAggregationType;
            }
        }

        private void ForcePageToNotCache()
        {
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Page.Response.Expires = -1;
        }

        public override void ApplyChanges()
        {
            EnsureChildControls();
            var tp = ParentToolPane;
            var chartWp = (ReportingChart)tp.SelectedWebPart;

            chartWp.PropChartTitle = ChartTitleTextBox.Text;
            chartWp.PropChartType = (ChartType)Enum.Parse(typeof(ChartType), ChartTypeDropDownList.SelectedValue);
            chartWp.PropChartSelectedPaletteName = ChartPaletteStyleDropDownList.SelectedValue;
            chartWp.PropChartSelectedListTitle = ListsDropDownList.SelectedItem.Text;
            chartWp.PropChartSelectedViewTitle = ViewsDropDownList.SelectedItem.Text;
            chartWp.PropChartShowGridlines = ShowGridlinesCheckBox.Checked;
            chartWp.PropChartShowSeriesLabels = ShowLabelsCheckBox.Checked;
            chartWp.PropChartAggregationType = AggregateTypeHtmlSelect.Value;
            SetXAxisField(chartWp);
            SetYAxisField(chartWp);
            SetZAxisField(chartWp);

            if (BubbleGroupByDropDownList.SelectedItem != null)
            {
                chartWp.PropBubbleChartGroupBy = BubbleGroupByDropDownList.SelectedValue;
            }

            chartWp.PropChartShowLegend = ShowLegendCheckBox.Checked;
            chartWp.PropYaxisFormat = YaxisFormatDropDownList.SelectedValue;
            chartWp.PropChartLegendPosition = LegendPositionDropDownList.SelectedValue;

            chartWp.RebuildControlTree();
        }

        private void SetXAxisField(ReportingChart chartWp)
        {
            string sChartTypeVal = Enum.GetName(typeof(ChartType), chartWp.PropChartType);
            string sAggType = chartWp.PropChartAggregationType;

            if (sChartTypeVal == "Area" || sChartTypeVal == "Bar" || sChartTypeVal == "Column" || sChartTypeVal == "Line")
            {
                if (sAggType == "Count")
                {
                    // set x fld based on combined x axis fld 
                    chartWp.SetXFieldValue(XaxisFieldDropDownList.SelectedValue);
                    chartWp.SetXFieldLabel(XaxisFieldDropDownList.SelectedItem.Text);
                }
                else if (sAggType == "Sum" || sAggType == "Avg")
                {
                    // non-numerical
                    chartWp.SetXFieldValue(ddlXaxisFieldNonNum.SelectedValue);
                    chartWp.SetXFieldLabel(ddlXaxisFieldNonNum.SelectedItem.Text);

                }
            }
            else if (sChartTypeVal.Contains("_Clustered") || sChartTypeVal.Contains("_Stacked") || sChartTypeVal.Contains("_100Percent"))
            {
                if (sAggType == "Count")
                {
                    // set x fld based on combined x axis fld 
                    chartWp.SetXFieldValue(XaxisFieldDropDownList.SelectedValue);
                    chartWp.SetXFieldLabel(XaxisFieldDropDownList.SelectedItem.Text);
                }
                else if (sAggType == "Sum" || sAggType == "Avg")
                {
                    // non-numerical
                    chartWp.SetXFieldValue(ddlXaxisFieldNonNum.SelectedValue);
                    chartWp.SetXFieldLabel(ddlXaxisFieldNonNum.SelectedItem.Text);
                }
            }
            else if (sChartTypeVal.Contains("Pie") || sChartTypeVal.Contains("Donut"))
            {
                if (sAggType == "Count")
                {
                    // set x fld based on combined x axis fld 
                    chartWp.SetXFieldValue(XaxisFieldDropDownList.SelectedValue);
                    chartWp.SetXFieldLabel(XaxisFieldDropDownList.SelectedItem.Text);
                }
                else if (sAggType == "Sum" || sAggType == "Avg")
                {
                    // non-numerical
                    chartWp.SetXFieldValue(ddlXaxisFieldNonNum.SelectedValue);
                    chartWp.SetXFieldLabel(ddlXaxisFieldNonNum.SelectedItem.Text);
                }
            }
            else if (sChartTypeVal.Contains("Bubble"))
            {
                // numerical
                chartWp.SetXFieldValue(ddlXaxisFieldNum.SelectedValue);
                chartWp.SetXFieldLabel(ddlXaxisFieldNum.SelectedItem.Text);
            }
        }

        private void SetYAxisField(ReportingChart chartWp)
        {
            string sChartTypeVal = Enum.GetName(typeof(ChartType), chartWp.PropChartType);
            string sAggType = chartWp.PropChartAggregationType;

            if (sChartTypeVal == "Area" || sChartTypeVal == "Bar" || sChartTypeVal == "Column" || sChartTypeVal == "Line")
            {
                if (sAggType == "Count")
                {
                    // NO Y VALUE
                    chartWp.SetYFieldsValues(new[] { "" });
                    chartWp.SetYFieldsLabels(new[] { "" });
                }
                else if (sAggType == "Sum" || sAggType == "Avg")
                {
                    // 1 Y VALUE (non-numerical)
                    if (ddlYaxisFieldNum.SelectedItem != null)
                    {
                        chartWp.SetYFieldsValues(new[] { ddlYaxisFieldNum.SelectedValue });
                        chartWp.SetYFieldsLabels(new[] { ddlYaxisFieldNum.SelectedItem.Text });
                    }
                }
            }
            else if (sChartTypeVal.Contains("_Clustered") || sChartTypeVal.Contains("_Stacked") || sChartTypeVal.Contains("_100Percent"))
            {
                if (sAggType == "Count")
                {
                    // 1 Y VALUE
                    if (ddlYaxisFieldNonNum.SelectedItem != null)
                    {
                        chartWp.SetYFieldsValues(new[] { ddlYaxisFieldNonNum.SelectedValue });
                        chartWp.SetYFieldsLabels(new[] { ddlYaxisFieldNonNum.SelectedItem.Text });
                    }
                }
                else if (sAggType == "Sum" || sAggType == "Avg")
                {
                    // MORE THAN 1 Y VALUE
                    chartWp.SetYFieldsValues((from ListItem li in cblYaxisFieldNum.Items where li.Selected select li.Value).ToArray());
                    chartWp.SetYFieldsLabels((from ListItem li in cblYaxisFieldNum.Items where li.Selected select li.Text).ToArray());
                }
            }
            else if (sChartTypeVal.Contains("Pie") || sChartTypeVal.Contains("Donut"))
            {
                if (sAggType == "Count")
                {
                    chartWp.SetYFieldsValues(new[] { "" });
                    chartWp.SetYFieldsLabels(new[] { "" });
                }
                else if (sAggType == "Sum" || sAggType == "Avg")
                {
                    chartWp.SetYFieldsValues(new[] { ddlYaxisFieldNum.SelectedValue });
                    chartWp.SetYFieldsLabels(new[] { ddlYaxisFieldNum.SelectedItem.Text });
                }
            }
            else if (sChartTypeVal.Contains("Bubble"))
            {
                // 1 Y Field (Num)
                chartWp.SetYFieldsValues(new[] { ddlYaxisFieldNum.SelectedValue });
                chartWp.SetYFieldsLabels(new[] { ddlYaxisFieldNum.SelectedItem.Text });
            }
        }

        private void SetZAxisField(ReportingChart chartWp)
        {
            chartWp.PropChartZaxisFieldLabel = ZaxisFieldDropDownList.SelectedItem.Text;
            if (ZaxisFieldDropDownList.SelectedItem != null)
            {
                chartWp.PropChartZaxisField = ZaxisFieldDropDownList.SelectedValue;
            }
        }

        protected override void RenderToolPart(HtmlTextWriter output)
        {
            WriteJavascript(output);
            WriteConfigSectionHtml(output);
            WriteDisplaySectionHtml(output);
        }

        protected void ListsDropDownListSelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListsDropDownList.SelectedItem.Text == "<Select List>") return;
            ViewsDropDownList.Items.Clear();
            using (var site = new SPSite(SPContext.Current.Site.Url))
            {
                using (var web = site.OpenWeb(SPContext.Current.Web.ID))
                {
                    var oList = web.Lists.TryGetList(ListsDropDownList.SelectedItem.Text);

                    if (oList == null) return;

                    foreach (SPView view in oList.Views)
                    {
                        if (view.Hidden)
                        {
                            continue;
                        }

                        ListItem iView = new ListItem(view.Title, view.Title);
                        if (!ViewsDropDownList.Items.Contains(iView))
                        {
                            ViewsDropDownList.Items.Add(iView);
                        }
                    }
                }
            }
            SortListControlItems(ViewsDropDownList);

            ReportingChart chart = (ReportingChart)ParentToolPane.SelectedWebPart;
            chart.PropChartSelectedListTitle = ListsDropDownList.SelectedItem.Text;
            FillDropDowns();
        }

        private void LoadAndSetViews(ReportingChart chart)
        {
            if (!string.IsNullOrEmpty(chart.PropChartSelectedViewTitle))
            {
                ViewsDropDownList.Items.Clear();
                using (var site = new SPSite(SPContext.Current.Site.Url))
                {
                    using (var web = site.OpenWeb(SPContext.Current.Web.ID))
                    {
                        var oList = web.Lists.TryGetList(ListsDropDownList.SelectedValue);

                        if (oList == null) return;

                        foreach (SPView view in oList.Views)
                        {
                            if (view.Hidden)
                            {
                                continue;
                            }

                            ListItem iView = new ListItem(view.Title, view.ID.ToString());
                            if (!ViewsDropDownList.Items.Contains(iView))
                            {
                                ViewsDropDownList.Items.Add(iView);
                            }
                        }
                    }
                }
                SortListControlItems(ViewsDropDownList);

                if (ViewsDropDownList.Items.FindByText(chart.PropChartSelectedViewTitle) != null)
                {
                    ViewsDropDownList.Items.FindByText(chart.PropChartSelectedViewTitle).Selected = true;
                }
            }
        }

        #region Output Html

        private void WriteConfigSectionHtml(HtmlTextWriter output)
        {
            var sChartTypeVal = ChartTypeDropDownList.SelectedValue;
            var sAggType = AggregateTypeHtmlSelect.Value;


            RenderChartConfiguration(output);
            RenderListsDropDown(output);
            RenderViewsDropDown(output);

            //CC-76549 I'm leaving this commented out if statement because there's no indication on to why this block was commented ot if this if should even be kept or removed
            if (IsBubbleChart())
            {
                //output.Write("<tr><td>");
                //ShowBubbleChartInputsInWebPart.RenderControl(output);
                //output.Write("Allow User To Select X, Y, Z Values<br></td></tr>");
            }

            RenderChartTypesDropDown(output);
            RenderAggregateTypeDropDown(output);
            RenderXAxis(output, sChartTypeVal, sAggType);
            RenderYAxis(output, sChartTypeVal, sAggType);
            RenderZAxis(output, sChartTypeVal);

            output.Write("</table>");
            output.Write("</div>");
        }

        private static void RenderChartConfiguration(HtmlTextWriter output)
        {
            output.Write("<div class=\"UserSectionHead\">");
            output.Write("<b>Chart Configuration</b>");
            output.Write("<br />");
            output.Write("<table cellpadding=1 style=\"padding-left: 5px\">");
        }

        private void RenderListsDropDown(HtmlTextWriter output)
        {
            output.Write("<tr><td>");
            output.Write("List<br>");
            ListsDropDownList.RenderControl(output);
            output.Write("</td></tr>");
        }

        private void RenderViewsDropDown(HtmlTextWriter output)
        {
            output.Write("<tr><td>");
            output.Write("View<br>");
            ViewsDropDownList.RenderControl(output);
            output.Write("</td></tr>");
        }

        private void RenderChartTypesDropDown(HtmlTextWriter output)
        {
            output.Write("<tr><td>");
            output.Write("Chart Type<br>");
            ChartTypeDropDownList.RenderControl(output);
            output.Write("</td></tr>");
        }

        private void RenderAggregateTypeDropDown(HtmlTextWriter output)
        {
            output.Write("<tr><td>");
            output.Write("<div id=\"aggTypeSec\" display='none'>");
            output.Write("Aggregation Type<br>");
            AggregateTypeHtmlSelect.RenderControl(output);
            output.Write("<br>");
            output.Write("</div>");
            output.Write("</td></tr>");
        }

        private void RenderXAxis(HtmlTextWriter output, string sChartTypeVal, string sAggType)
        {
            output.Write("<tr><td>");

            if (sChartTypeVal == "Area"
                || sChartTypeVal == "Bar"
                || sChartTypeVal == "Column"
                || sChartTypeVal == "Line")
            {
                RenderAggTypeEqualsCountOrSum(output, sAggType);
            }

            else if (sChartTypeVal.Contains("_Clustered")
                     || sChartTypeVal.Contains("_Stacked")
                     || sChartTypeVal.Contains("_100Percent"))
            {
                if (sAggType == "Count"
                    || sAggType == "Sum"
                    || sAggType == "Avg")
                {
                    output.Write("<div id='XaxisSection_full' style='display:none'>");
                    output.Write("Category (X axis)<br>");
                    XaxisFieldDropDownList.RenderControl(output);
                    output.Write("</div>");

                    output.Write("<div id='XaxisSection_ddl_num' style='display:none'>");
                    output.Write("Value (X axis)<br>");
                    ddlXaxisFieldNum.RenderControl(output);
                    output.Write("</div>");

                    output.Write("<div id='XaxisSection_ddl_nonnum'>");
                    output.Write("Category (X axis)<br>");
                    ddlXaxisFieldNonNum.RenderControl(output);
                    output.Write("</div>");
                }
            }
            else if (sChartTypeVal.Contains("Pie")
                     || sChartTypeVal.Contains("Donut"))
            {
                RenderAggTypeEqualsCountOrSum(output, sAggType);
            }
            else if (sChartTypeVal.Contains("Bubble"))
            {
                output.Write("<div id='XaxisSection_full' style='display:none'>");
                output.Write("Category (X axis)<br>");
                XaxisFieldDropDownList.RenderControl(output);
                output.Write("</div>");

                output.Write("<div id='XaxisSection_ddl_num'>");
                output.Write("Value (X axis)<br>");
                ddlXaxisFieldNum.RenderControl(output);
                output.Write("</div>");

                output.Write("<div id='XaxisSection_ddl_nonnum' style='display:none'>");
                output.Write("Category (X axis)<br>");
                ddlXaxisFieldNonNum.RenderControl(output);
                output.Write("</div>");
            }

            output.Write("</td></tr>");
        }

        private void RenderAggTypeEqualsCountOrSum(HtmlTextWriter output, string sAggType)
        {
            if (sAggType == "Count")
            {
                output.Write("<div id='XaxisSection_full'>");
                output.Write("Category (X axis)<br>");
                XaxisFieldDropDownList.RenderControl(output);
                output.Write("</div>");

                output.Write("<div id='XaxisSection_ddl_num' style='display:none'>");
                output.Write("Value (X axis)<br>");
                ddlXaxisFieldNum.RenderControl(output);
                output.Write("</div>");

                output.Write("<div id='XaxisSection_ddl_nonnum' style='display:none'>");
                output.Write("Category (X axis)<br>");
                ddlXaxisFieldNonNum.RenderControl(output);
                output.Write("</div>");
            }
            else if (sAggType == "Sum"
                     || sAggType == "Avg")
            {
                output.Write("<div id='XaxisSection_full' style='display:none'>");
                output.Write("Category (X axis)<br>");
                XaxisFieldDropDownList.RenderControl(output);
                output.Write("</div>");

                output.Write("<div id='XaxisSection_ddl_num' style='display:none'>");
                output.Write("Value (X axis)<br>");
                ddlXaxisFieldNum.RenderControl(output);
                output.Write("</div>");

                output.Write("<div id='XaxisSection_ddl_nonnum'>");
                output.Write("Category (X axis)<br>");
                ddlXaxisFieldNonNum.RenderControl(output);
                output.Write("</div>");
            }
        }

        private void RenderYAxis(HtmlTextWriter output, string sChartTypeVal, string sAggType)
        {
            var bRenderY = false;

            if (sChartTypeVal == "Area"
                || sChartTypeVal == "Bar"
                || sChartTypeVal == "Column"
                || sChartTypeVal == "Line")
            {
                if (sAggType == "Count")
                {
                    RenderOneYField(output, false, true);
                    RenderMultipleYField(output, false, true);
                }
                else if (sAggType == "Sum"
                         || sAggType == "Avg")
                {
                    RenderOneYField(output, true, false);
                    RenderMultipleYField(output, true, true);
                    bRenderY = true;
                }
            }
            else if (sChartTypeVal.Contains("_Clustered")
                     || sChartTypeVal.Contains("_Stacked")
                     || sChartTypeVal.Contains("_100Percent"))
            {
                if (sAggType == "Count")
                {
                    RenderOneYField(output, false, false);
                    RenderMultipleYField(output, false, true);
                    bRenderY = true;
                }
                else if (sAggType == "Sum"
                         || sAggType == "Avg")
                {
                    RenderMultipleYField(output, true, false);
                    RenderOneYField(output, false, true);
                    bRenderY = true;
                }
            }
            else if (sChartTypeVal.Contains("Pie")
                     || sChartTypeVal.Contains("Donut"))
            {
                if (sAggType == "Count")
                {
                    RenderOneYField(output, false, true);
                    RenderMultipleYField(output, false, true);
                }
                else if (sAggType == "Sum"
                         || sAggType == "Avg")
                {
                    RenderOneYField(output, true, false);
                    RenderMultipleYField(output, false, true);
                    bRenderY = true;
                }
            }
            else if (sChartTypeVal.Contains("Scatter")
                     || sChartTypeVal.Contains("Bubble"))
            {
                RenderOneYField(output, true, false);
                RenderMultipleYField(output, false, true);
                bRenderY = true;
            }

            output.Write("<tr><td>");
            output.Write(
                bRenderY
                    ? "<div id='YAxisFormatSection'>"
                    : "<div id='YAxisFormatSection' style='display:none'>");
            output.Write("Y Axis Formatting<br>");
            YaxisFormatDropDownList.RenderControl(output);
            output.Write("</div>");
            output.Write("</td></tr>");
        }

        private void RenderZAxis(HtmlTextWriter output, string sChartTypeVal)
        {
            output.Write("<tr><td>");
            output.Write(
                sChartTypeVal.Contains("Bubble")
                    ? "<div id='ZaxisSection'>"
                    : "<div id='ZaxisSection' style='display:none'>");
            output.Write("Size Value (Z Axis)<br/>");
            ZaxisFieldDropDownList.RenderControl(output);
            output.Write("<br/>");
            output.Write("Group By<br/>");
            BubbleGroupByDropDownList.RenderControl(output);
            output.Write("<br/>");
            output.Write("</div>");
            output.Write("</td></tr>");
        }

        private void WriteDisplaySectionHtml(HtmlTextWriter output)
        {
            output.Write("<div class=\"UserSectionHead\">");
            output.Write("<b>Display Options</b>");
            output.Write("<br />");
            output.Write("<table cellpadding=1 style=\"padding-left: 5px\">");

            //output.Write("<div class=\"OptionsSection\">");
            //output.Write("<table cellpadding=1><tr><td>");

            output.Write("<tr><td>");
            output.Write("Title<br>");
            ChartTitleTextBox.RenderControl(output);
            output.Write("</td></tr>");

            output.Write("<tr><td>");
            output.Write("Palette<br>");
            ChartPaletteStyleDropDownList.RenderControl(output);
            output.Write("</td></tr>");

            //output.Write("<tr><td>");
            //ShowIn3DCheckBox.RenderControl(output);
            //output.Write("Show in 3D<br></td></tr>");

            output.Write("<tr><td>");
            ShowGridlinesCheckBox.RenderControl(output);
            output.Write("Show Gridlines<br></td></tr>");
            output.Write("<tr><td>");
            ShowLabelsCheckBox.RenderControl(output);
            output.Write("Show X-Axis Labels<br></td></tr>");

            output.Write("<tr><td>");
            ShowLegendCheckBox.RenderControl(output);
            output.Write("Show Legend<br></td></tr>");

            output.Write("<tr><td>");
            output.Write("Legend Position<br>");
            LegendPositionDropDownList.RenderControl(output);
            output.Write("</td></tr>");

            //output.Write("<tr><td>");
            //output.Write("<input type='button' value='reload' onclick='ReloadChartAjax();' />");
            //var chartWp = (ReportingChart)ParentToolPane.SelectedWebPart;
            //output.Write("<script type='text/javascript'> function ReloadChartAjax() { __doPostBack('" + chartWp.UpdatePanelClientId + "', ''); } </script>");
            //output.Write("</td></tr>");

            output.Write("</td></tr></table>");
            output.Write("</div>");
        }

        private void WriteJavascript(HtmlTextWriter output)
        {
            output.Write("<script type=\"text/javascript\">");
            output.Write("function ctype_agg_change() ");
            output.Write("{");
            output.Write(" var cTypeDdl = document.getElementById(\"" + ChartTypeDropDownList.ClientID + "\"); ");
            output.Write(" var cType = cTypeDdl.options[cTypeDdl.selectedIndex].value; ");
            output.Write(" var aggreDdl = document.getElementById(\"" + AggregateTypeHtmlSelect.ClientID + "\"); ");
            output.Write(" var aggVal = aggreDdl.options[aggreDdl.selectedIndex].value; ");
            output.Write(" var aggSec = document.getElementById(\"aggTypeSec\"); ");
            output.Write(" aggSec.style.display = (cType != 'Bubble') ? '' : 'none'; ");
            SetZFlagWhenBubbleChart(output);
            WriteAreaBarColumnLineChartTypes(output);
            WriteClusteredOrStackedCharType(output);
            WritePieOrDonutChartType(output);
            WriteBubbleCharType(output);
            output.Write("}");
            output.Write("</script>");

        }

        private static void SetZFlagWhenBubbleChart(HtmlTextWriter output)
        {
            output.Write(" document.getElementById(\"ZaxisSection\").style.display = (cType == 'Bubble') ? '' : 'none'; ");
        }

        private void WriteAreaBarColumnLineChartTypes(HtmlTextWriter output)
        {
            output.Write(" if (cType == \"Area\" || cType == \"Bar\" || cType == \"Column\" || cType == \"Line\") { ");
            WriteAggValEqualsCountCase1(output);
            WriteAggValEqualsSumOrAvgCase1(output);
            output.Write("     } ");
        }

        private void WriteClusteredOrStackedCharType(HtmlTextWriter output)
        {
            output.Write(" } else if (cType.indexOf(\"_Clustered\") != -1 || cType.indexOf(\"_Stacked\") != -1 || cType.indexOf(\"_100Percent\") != -1) { ");
            WriteAggValEqualsCountCase2(output);
            WriteAggValEqualsSumOrAvgCase2(output);
            output.Write("     } ");
        }

        private void WritePieOrDonutChartType(HtmlTextWriter output)
        {
            output.Write(" } else if (cType == \"Pie\" || cType == \"Donut\" ) { ");
            WriteAggValEqualsCountCase1(output);
            WriteAggValEqualsSumOrAvgCase1(output);
            output.Write("     } ");
        }

        private void WriteBubbleCharType(HtmlTextWriter output)
        {
            output.Write(" } else if (cType == \"Bubble\" ) { ");
            WriteTryCatchBlock(
                output,
                new Tuple<string, string>("XaxisSection_full", "none"),
                new Tuple<string, string>("XaxisSection_ddl_num", ""),
                new Tuple<string, string>("XaxisSection_ddl_nonnum", "none"),
                new Tuple<string, string>("YaxisSection_ddl_num", ""),
                new Tuple<string, string>("YaxisSection_ddl_nonnum", "none"),
                new Tuple<string, string>("YaxisSection_cbl", "none"),
                new Tuple<string, string>("YaxisSection_cbl_num", "none"),
                new Tuple<string, string>("YaxisSection_cbl_nonnum", "none"),
                new Tuple<string, string>("YaxisSection_ddl", ""),
                new Tuple<string, string>("YAxisFormatSection", ""));
        }

        private void WriteAggValEqualsSumOrAvgCase2(HtmlTextWriter output)
        {
            output.Write("     } else if (aggVal == \"Sum\" || aggVal == \"Avg\"){ ");
            WriteTryCatchBlock(
                output,
                new Tuple<string, string>("XaxisSection_full", "none"),
                new Tuple<string, string>("XaxisSection_ddl_num", "none"),
                new Tuple<string, string>("XaxisSection_ddl_nonnum", ""),
                new Tuple<string, string>("YaxisSection_cbl_num", ""),
                new Tuple<string, string>("YaxisSection_cbl_nonnum", "none"),
                new Tuple<string, string>("YaxisSection_cbl", ""),
                new Tuple<string, string>("YaxisSection_ddl", "none"),
                new Tuple<string, string>("YaxisSection_ddl_num", "none"),
                new Tuple<string, string>("YaxisSection_ddl_nonnum", "none"),
                new Tuple<string, string>("YAxisFormatSection", ""));
        }

        private void WriteAggValEqualsCountCase2(HtmlTextWriter output)
        {
            output.Write("     if (aggVal == \"Count\") { ");
            WriteTryCatchBlock(
                output,
                new Tuple<string, string>("XaxisSection_full", "none"),
                new Tuple<string, string>("XaxisSection_ddl_num", "none"),
                new Tuple<string, string>("XaxisSection_ddl_nonnum", ""),
                new Tuple<string, string>("YaxisSection_ddl_num", "none"),
                new Tuple<string, string>("YaxisSection_ddl_nonnum", ""),
                new Tuple<string, string>("YaxisSection_cbl", "none"),
                new Tuple<string, string>("YaxisSection_cbl_num", "none"),
                new Tuple<string, string>("YaxisSection_cbl_nonnum", "none"),
                new Tuple<string, string>("YaxisSection_ddl", ""),
                new Tuple<string, string>("YAxisFormatSection", ""));
        }

        private void WriteAggValEqualsSumOrAvgCase1(HtmlTextWriter output)
        {
            output.Write("     } else if (aggVal == \"Sum\" || aggVal == \"Avg\"){ ");
            WriteTryCatchBlock(
                output,
                new Tuple<string, string>("XaxisSection_full", "none"),
                new Tuple<string, string>("XaxisSection_ddl_num", "none"),
                new Tuple<string, string>("XaxisSection_ddl_nonnum", ""),
                new Tuple<string, string>("YaxisSection_ddl", ""),
                new Tuple<string, string>("YaxisSection_ddl_num", ""),
                new Tuple<string, string>("YaxisSection_ddl_nonnum", "none"),
                new Tuple<string, string>("YaxisSection_cbl", "none"),
                new Tuple<string, string>("YaxisSection_cbl_num", "none"),
                new Tuple<string, string>("YaxisSection_cbl_nonnum", "none"),
                new Tuple<string, string>("YAxisFormatSection", ""));
        }

        private void WriteAggValEqualsCountCase1(HtmlTextWriter output)
        {
            output.Write("     if (aggVal == \"Count\") { ");
            WriteTryCatchBlock(
                output,
                new Tuple<string, string>("XaxisSection_full", string.Empty),
                new Tuple<string, string>("XaxisSection_ddl_num", "none"),
                new Tuple<string, string>("XaxisSection_ddl_nonnum", "none"),
                new Tuple<string, string>("YaxisSection_ddl", "none"),
                new Tuple<string, string>("YaxisSection_ddl_num", "none"),
                new Tuple<string, string>("YaxisSection_ddl_nonnum", "none"),
                new Tuple<string, string>("YaxisSection_cbl", "none"),
                new Tuple<string, string>("YaxisSection_cbl_num", "none"),
                new Tuple<string, string>("YaxisSection_cbl_nonnum", "none"),
                new Tuple<string, string>("YAxisFormatSection", "none"));
        }

        private void WriteTryCatchBlock(HtmlTextWriter output, params Tuple<string, string>[] argsToWrite)
        {
            output.Write("      try{ ");
            foreach (var tuple in argsToWrite)
            {
                output.Write($"         document.getElementById(\"{tuple.Item1}\").style.display = \"{tuple.Item2}\"; ");
            }
            output.Write("      } catch (e) {} ");
        }

        #endregion

        #region Control Creation

        private void CreateConfigSectionControls()
        {
            ListsDropDownList.SelectedIndexChanged += ListsDropDownListSelectedIndexChanged;
            ListsDropDownList.AutoPostBack = true;
            ListsDropDownList.EnableViewState = true;
            Controls.Add(ListsDropDownList);

            ViewsDropDownList.EnableViewState = true;
            Controls.Add(ViewsDropDownList);

            ChartTypeDropDownList.EnableViewState = true;
            Controls.Add(ChartTypeDropDownList);

            AggregateTypeHtmlSelect.EnableViewState = true;
            Controls.Add(AggregateTypeHtmlSelect);

            #region CREATE X AXIS
            XaxisFieldDropDownList.EnableViewState = true;
            Controls.Add(XaxisFieldDropDownList);

            ddlXaxisFieldNum.EnableViewState = true;
            Controls.Add(ddlXaxisFieldNum);

            ddlXaxisFieldNonNum.EnableViewState = true;
            Controls.Add(ddlXaxisFieldNonNum);

            XaxisLabelRotationAngleTextBox.Text = "0";
            XaxisLabelRotationAngleTextBox.Width = 35;
            XaxisLabelRotationAngleTextBox.EnableViewState = true;
            Controls.Add(XaxisLabelRotationAngleTextBox);

            XaxisLabelFontSizeTextBox.Text = "10";
            XaxisLabelFontSizeTextBox.Width = 35;
            XaxisLabelFontSizeTextBox.EnableViewState = true;
            Controls.Add(XaxisLabelFontSizeTextBox);
            #endregion

            #region CREATE Y AXIS
            cblYaxisFieldNum.EnableViewState = true;
            Controls.Add(cblYaxisFieldNum);

            cblYaxisFieldNonNum.EnableViewState = true;
            Controls.Add(cblYaxisFieldNonNum);

            ddlYaxisFieldNum.EnableViewState = true;
            Controls.Add(ddlYaxisFieldNum);

            ddlYaxisFieldNonNum.EnableViewState = true;
            Controls.Add(ddlYaxisFieldNonNum);

            YaxisFormatDropDownList.EnableViewState = true;
            Controls.Add(YaxisFormatDropDownList);

            NumberOfYaxisValuesTextBox.EnableViewState = true;
            NumberOfYaxisValuesTextBox.Width = 35;
            Controls.Add(NumberOfYaxisValuesTextBox);
            #endregion

            #region CREATE Z AXIS
            ZaxisLabelRotationAngleTextBox.Text = "-27";
            ZaxisLabelRotationAngleTextBox.Width = 35;
            ZaxisLabelRotationAngleTextBox.EnableViewState = true;
            Controls.Add(ZaxisLabelRotationAngleTextBox);

            ZaxisFieldDropDownList.EnableViewState = true;
            Controls.Add(ZaxisFieldDropDownList);

            BubbleChartColorFieldDropDownList.EnableViewState = true;
            Controls.Add(BubbleChartColorFieldDropDownList);

            BubbleGroupByDropDownList.EnableViewState = true;
            Controls.Add(BubbleGroupByDropDownList);
            #endregion
        }

        private void CreateDisplaySectionControls()
        {
            ChartTitleTextBox.EnableViewState = true;
            Controls.Add(ChartTitleTextBox);

            ChartTitleFontSizeTextBox.EnableViewState = true;
            ChartTitleFontSizeTextBox.Text = "16";
            ChartTitleFontSizeTextBox.Width = 35;
            Controls.Add(ChartTitleFontSizeTextBox);

            ChartPaletteStyleDropDownList.EnableViewState = true;
            Controls.Add(ChartPaletteStyleDropDownList);

            ShowLegendCheckBox.EnableViewState = true;
            Controls.Add(ShowLegendCheckBox);

            LegendPositionDropDownList.EnableViewState = true;
            Controls.Add(LegendPositionDropDownList);

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

            //ShowZeroValueDataCheckBox.EnableViewState = true;
            //Controls.Add(ShowZeroValueDataCheckBox);

            //ShowIn3DCheckBox.EnableViewState = true;
            //Controls.Add(ShowIn3DCheckBox);

            ShowGridlinesCheckBox.EnableViewState = true;
            Controls.Add(ShowGridlinesCheckBox);

            ShowLabelsCheckBox.EnableViewState = true;
            Controls.Add(ShowLabelsCheckBox);

            ShowProjectsCheckBox.EnableViewState = true;
            Controls.Add(ShowProjectsCheckBox);

            //ShowBubbleChartInputsInWebPart.EnableViewState = true;
            //Controls.Add(ShowBubbleChartInputsInWebPart);
        }

        #endregion

        #region Control Setup

        private void SetDropDownListSelectedValues(ReportingChart chart)
        {
            if (ListsDropDownList.Items.FindByValue(chart.PropChartSelectedListTitle) != null)
            {
                ListsDropDownList.SelectedValue = chart.PropChartSelectedListTitle;
            }

            if (ChartTypeDropDownList.Items.FindByValue(Enum.GetName(typeof(ChartType), chart.PropChartType)) != null)
            {
                ChartTypeDropDownList.SelectedValue = Enum.GetName(typeof(ChartType), chart.PropChartType);
            }

            if (ZaxisFieldDropDownList.Items.FindByValue(chart.PropChartZaxisField) != null)
            {
                ZaxisFieldDropDownList.SelectedValue = chart.PropChartZaxisField;
            }

            if (XaxisFieldDropDownList.Items.FindByValue(chart.PropChartXaxisField) != null)
            {
                XaxisFieldDropDownList.SelectedValue = chart.PropChartXaxisField;
            }

            // set y field values
            SetYFieldControlValues(chart);

            // set aggregate value
            if (AggregateTypeHtmlSelect.Items.FindByValue(chart.PropChartAggregationType) != null)
            {
                AggregateTypeHtmlSelect.Value = chart.PropChartAggregationType;
            }

            if (YaxisFormatDropDownList.Items.FindByValue(chart.PropYaxisFormat) != null)
            {
                YaxisFormatDropDownList.SelectedValue = chart.PropYaxisFormat;
            }

            // set z fields
            if (ZaxisFieldDropDownList.Items.FindByValue(chart.PropChartZaxisField) != null)
            {
                ZaxisFieldDropDownList.SelectedValue = chart.PropChartZaxisField;
            }

            if (BubbleGroupByDropDownList.Items.FindByValue(chart.PropBubbleChartGroupBy) != null)
            {
                BubbleGroupByDropDownList.SelectedValue = chart.PropBubbleChartGroupBy;
            }

            if (LegendPositionDropDownList.Items.FindByValue(chart.PropChartLegendPosition) != null)
            {
                LegendPositionDropDownList.SelectedValue = chart.PropChartLegendPosition;
            }

        }

        private void SetYFieldControlValues(ReportingChart chart)
        {
            string[] yFields = chart.GetYFieldsValues();
            string sChartTypeVal = Enum.GetName(typeof(ChartType), chart.PropChartType);
            string sAggType = chart.PropChartAggregationType;

            if (yFields.Length > 0)
            {
                if (sChartTypeVal == "Area" || sChartTypeVal == "Bar" || sChartTypeVal == "Column" || sChartTypeVal == "Line")
                {
                    if (sAggType == "Count")
                    {
                        // NO Y VALUE
                    }
                    else if (sAggType == "Sum" || sAggType == "Avg")
                    {
                        foreach (var sFld in yFields)
                        {
                            var yAxisFieldItem = ddlYaxisFieldNum.Items.FindByValue(sFld);
                            if (yAxisFieldItem != null)
                            {
                                yAxisFieldItem.Selected = true;
                            }
                        }
                    }
                }
                else if (sChartTypeVal.Contains("_Clustered") || sChartTypeVal.Contains("_Stacked") || sChartTypeVal.Contains("_100Percent"))
                {
                    if (sAggType == "Count")
                    {
                        foreach (var sFld in yFields)
                        {
                            var yAxisFieldItems = ddlYaxisFieldNonNum.Items.FindByValue(sFld);
                            if (yAxisFieldItems != null)
                            {
                                ddlYaxisFieldNonNum.Items.FindByValue(sFld).Selected = true;
                            }
                        }
                    }
                    else if (sAggType == "Sum" || sAggType == "Avg")
                    {
                        foreach (var sFld in yFields)
                        {
                            var yAxisFieldItems = cblYaxisFieldNum.Items.FindByValue(sFld);
                            if (yAxisFieldItems != null)
                            {
                                cblYaxisFieldNum.Items.FindByValue(sFld).Selected = true;
                            }
                        }
                    }
                }
                else if (sChartTypeVal.Contains("Pie") || sChartTypeVal.Contains("Donut"))
                {
                    if (sAggType == "Count")
                    {
                        // NO Y VALUE
                    }
                    else if (sAggType == "Sum" || sAggType == "Avg")
                    {
                        foreach (var sFld in yFields)
                        {
                            var yAxisFieldItems = ddlYaxisFieldNum.Items.FindByValue(sFld);
                            if (yAxisFieldItems != null)
                            {
                                ddlYaxisFieldNum.Items.FindByValue(sFld).Selected = true;
                            }
                        }
                    }
                }
                else if (sChartTypeVal.Contains("Bubble"))
                {
                    foreach (var sFld in yFields)
                    {
                        var yAxisFieldItems = ddlYaxisFieldNum.Items.FindByValue(sFld);
                        if (yAxisFieldItems != null)
                        {
                            ddlYaxisFieldNum.Items.FindByValue(sFld).Selected = true;
                        }
                    }
                }
            }
        }

        private void LoadAndSetSelectedList(SPWeb web, ReportingChart chart)
        {
            ListsDropDownList.Items.Clear();
            // Load reporting lists
            ListsDropDownList.Items.Add(new ListItem("<Select List>", "<Select List>"));
            DataTable dtMappedLists = GetMappedLists();
            foreach (DataRow r in dtMappedLists.Rows)
            {
                if (r["ListName"] != DBNull.Value)
                {
                    string sListName = r["ListName"].ToString();
                    ListItem i = new ListItem(sListName, sListName);
                    if (!ListsDropDownList.Items.Contains(i))
                    {
                        ListsDropDownList.Items.Add(i);
                    }
                }
            }
            SortListControlItems(ListsDropDownList);

            // Set selected list
            if (!string.IsNullOrEmpty(chart.PropChartSelectedListTitle) &&
                ListsDropDownList.Items.FindByValue(chart.PropChartSelectedListTitle) != null)
            {
                ListsDropDownList.SelectedValue = chart.PropChartSelectedListTitle;
            }
        }

        private void LoadAndSetChartTypes(ReportingChart chart)
        {
            // clear
            ChartTypeDropDownList.Items.Clear();
            // fill 
            string sTypeName, sTypeVal = string.Empty;
            foreach (ChartType type in Enum.GetValues(typeof(ChartType)))
            {
                sTypeName = Enum.GetName(typeof(ChartType), type);
                sTypeVal = Enum.Parse(typeof(ChartType), sTypeName).ToString();
                ListItem iTemp = new ListItem(sTypeName, sTypeVal);
                if (!ChartTypeDropDownList.Items.Contains(iTemp))
                {
                    ChartTypeDropDownList.Items.Add(
                        new ListItem(sTypeName.Replace('_', ' '), sTypeVal)
                    );
                }
            }
            // sort
            SortListControlItems(ChartTypeDropDownList);

            // attach client side function
            ChartTypeDropDownList.Attributes.Add("onChange", "ctype_agg_change()");

            // set value
            string sType = Enum.GetName(typeof(ChartType), chart.PropChartType);

            if (ChartTypeDropDownList.Items.FindByValue(sType) != null)
            {
                ChartTypeDropDownList.SelectedValue = sType;
            }
        }

        private void SetupCheckBoxes(ReportingChart chart)
        {
            ShowGridlinesCheckBox.Checked = chart.PropChartShowGridlines;
            ShowLegendCheckBox.Checked = chart.PropChartShowLegend;
            ShowLabelsCheckBox.Checked = chart.PropChartShowSeriesLabels;
        }

        private void SetTextBoxValues(ReportingChart chart)
        {
            ChartTitleTextBox.Text = chart.PropChartTitle;

        }

        private void FillDropDowns()
        {
            var sListTitle = ListsDropDownList.SelectedValue;
            if (string.IsNullOrWhiteSpace(sListTitle)
                || sListTitle == "<Select List>")
            {
                return;
            }

            var oList = SPContext.Current.Web.Lists.TryGetList(sListTitle);
            if (oList == null)
            {
                return;
            }

            ClearControls();

            var reportingChart = (ReportingChart)ParentToolPane.SelectedWebPart;

            FillColorPalette();
            FillChartLines(oList);

            FillYAxisFormatDropdown();
            FillLegendPositionDropDown();
            SelectChartLegendPosition(reportingChart);

            SortListControls();

            ProcessXAxisFields(reportingChart);
            ProcessYAxisFields(reportingChart);

            SelectChartZAxisField(reportingChart);
            SelectBubbleChartGroupBy(reportingChart);
            SelectChartSelectedPaletteName(reportingChart);
        }

        private void FillColorPalette()
        {
            ChartPaletteStyleDropDownList.Items.AddRange(
                new[]
                {
                    new ListItem("Color 1", "Color1"),
                    new ListItem("Color 2", "Color2"),
                    new ListItem("Gray", "Gray"),
                    new ListItem("Blue", "Blue"),
                    new ListItem("Red", "Red"),
                    new ListItem("Green", "Green"),
                    new ListItem("Yellow", "Yellow"),
                    new ListItem("Violet", "Violet")
                });
        }

        private void FillChartLines(SPList oList)
        {
            var listColumns = GetListColumns(oList.ID);
            foreach (DataRow dataRow in listColumns.Rows)
            {
                var sharePointType = dataRow["SharePointType"]
                    .ToString();
                var displayName = dataRow["DisplayName"]
                    .ToString();
                var internalName = dataRow["InternalName"]
                    .ToString();
                var columnType = dataRow["ColumnType"]
                    .ToString();

                if (sharePointType == "Attachments"
                    || internalName == "Order"
                    || sharePointType == "File"
                    || internalName == "Metainfo"
                    || sharePointType == "Computed"
                    || sharePointType == "Guid"
                    || sharePointType == "Counter"
                    || sharePointType == "Note")
                {
                    continue;
                }

                var liX = new ListItem(displayName, internalName);
                if (!XaxisFieldDropDownList.Items.Contains(liX))
                {
                    XaxisFieldDropDownList.Items.Add(liX);
                }

                if (sharePointType == "Calculated" && columnType == "Float"
                    || sharePointType == "Calculated" && columnType == "Int"
                    || sharePointType == "Currency"
                    || sharePointType == "Integer"
                    || sharePointType == "Number")
                {
                    FillNumericChart(displayName, internalName);
                }
                else
                {
                    FillNonNumericChart(displayName, internalName);
                }
            }
        }

        private void FillNumericChart(string displayName, string internalName)
        {
            var numericLine = new ListItem(displayName, internalName);

            if (!ddlXaxisFieldNum.Items.Contains(numericLine))
            {
                ddlXaxisFieldNum.Items.Add(numericLine);
            }

            if (!cblYaxisFieldNum.Items.Contains(numericLine))
            {
                cblYaxisFieldNum.Items.Add(numericLine);
            }

            if (!ddlYaxisFieldNum.Items.Contains(numericLine))
            {
                ddlYaxisFieldNum.Items.Add(numericLine);
            }

            if (!ZaxisFieldDropDownList.Items.Contains(numericLine))
            {
                ZaxisFieldDropDownList.Items.Add(numericLine);
            }
        }

        private void FillNonNumericChart(string displayName, string internalName)
        {
            var nonNumericLine = new ListItem(displayName, internalName);

            if (!ddlXaxisFieldNonNum.Items.Contains(nonNumericLine))
            {
                ddlXaxisFieldNonNum.Items.Add(nonNumericLine);
            }

            if (!cblYaxisFieldNonNum.Items.Contains(nonNumericLine))
            {
                cblYaxisFieldNonNum.Items.Add(nonNumericLine);
            }

            if (!ddlYaxisFieldNonNum.Items.Contains(nonNumericLine))
            {
                ddlYaxisFieldNonNum.Items.Add(nonNumericLine);
            }

            if (!BubbleGroupByDropDownList.Items.Contains(nonNumericLine))
            {
                BubbleGroupByDropDownList.Items.Add(nonNumericLine);
            }
        }

        private void FillYAxisFormatDropdown()
        {
            YaxisFormatDropDownList.Items.Clear();
            YaxisFormatDropDownList.Items.AddRange(
                new[]
                {
                    new ListItem("None", "None"),
                    new ListItem("Currency", "Currency"),
                    new ListItem("Percentage", "Percentage")
                });
        }

        private void FillLegendPositionDropDown()
        {
            LegendPositionDropDownList.Items.Clear();
            LegendPositionDropDownList.Items.AddRange(
                new[]
                {
                    new ListItem("Left", "Left"),
                    new ListItem("Top", "Top"),
                    new ListItem("Right", "Right"),
                    new ListItem("Bottom", "Bottom")
                });
        }

        private void SelectChartLegendPosition(ReportingChart reportingChart)
        {
            if (LegendPositionDropDownList.Items.FindByText(reportingChart.PropChartLegendPosition) != null)
            {
                LegendPositionDropDownList.Items.FindByText(reportingChart.PropChartLegendPosition)
                                          .Selected = true;
            }
        }

        private void ProcessXAxisFields(ReportingChart reportingChart)
        {
            if (!string.IsNullOrWhiteSpace(reportingChart.PropChartXaxisField))
            {
                if (XaxisFieldDropDownList.Items.FindByValue(reportingChart.PropChartXaxisField) != null)
                {
                    XaxisFieldDropDownList.Items.FindByValue(reportingChart.PropChartXaxisField)
                                          .Selected = true;
                }

                if (ddlXaxisFieldNum.Items.FindByValue(reportingChart.PropChartXaxisField) != null)
                {
                    ddlXaxisFieldNum.Items.FindByValue(reportingChart.PropChartXaxisField)
                                    .Selected = true;
                }

                if (ddlXaxisFieldNonNum.Items.FindByValue(reportingChart.PropChartXaxisField) != null)
                {
                    ddlXaxisFieldNonNum.Items.FindByValue(reportingChart.PropChartXaxisField)
                                       .Selected = true;
                }
            }
        }

        private void ProcessYAxisFields(ReportingChart reportingChart)
        {
            if (!string.IsNullOrWhiteSpace(reportingChart.PropChartYaxisField))
            {
                var yFields = reportingChart.PropChartYaxisField.Split('|');
                if (yFields.Length > 1)
                {
                    foreach (var yField in yFields)
                    {
                        if (cblYaxisFieldNum.Items.FindByValue(yField) != null)
                        {
                            cblYaxisFieldNum.Items.FindByValue(yField)
                                            .Selected = true;
                        }

                        if (cblYaxisFieldNonNum.Items.FindByValue(yField) != null)
                        {
                            cblYaxisFieldNonNum.Items.FindByValue(yField)
                                               .Selected = true;
                        }
                    }
                }
                else
                {
                    var yValue = yFields[0];
                    if (ddlYaxisFieldNum.Items.FindByValue(yValue) != null)
                    {
                        ddlYaxisFieldNum.Items.FindByValue(yValue)
                                        .Selected = true;
                    }

                    if (ddlYaxisFieldNonNum.Items.FindByValue(yValue) != null)
                    {
                        ddlYaxisFieldNonNum.Items.FindByValue(yValue)
                                           .Selected = true;
                    }
                }

                SelectAxisFormat(reportingChart);
            }
        }

        private void SelectAxisFormat(ReportingChart reportingChart)
        {
            if (!string.IsNullOrWhiteSpace(reportingChart.PropYaxisFormat)
                && YaxisFormatDropDownList.Items.FindByValue(reportingChart.PropYaxisFormat) != null)
            {
                YaxisFormatDropDownList.Items.FindByValue(reportingChart.PropYaxisFormat)
                                       .Selected = true;
            }
        }

        private void SelectChartZAxisField(ReportingChart reportingChart)
        {
            if (!string.IsNullOrWhiteSpace(reportingChart.PropChartZaxisField)
                && ZaxisFieldDropDownList.Items.FindByValue(reportingChart.PropChartZaxisField) != null)
            {
                ZaxisFieldDropDownList.Items.FindByValue(reportingChart.PropChartZaxisField)
                                      .Selected = true;
            }
        }

        private void SelectBubbleChartGroupBy(ReportingChart reportingChart)
        {
            if (!string.IsNullOrWhiteSpace(reportingChart.PropBubbleChartGroupBy)
                && BubbleGroupByDropDownList.Items.FindByValue(reportingChart.PropBubbleChartGroupBy) != null)
            {
                BubbleGroupByDropDownList.Items.FindByValue(reportingChart.PropBubbleChartGroupBy)
                                         .Selected = true;
            }
        }

        private void SelectChartSelectedPaletteName(ReportingChart reportingChart)
        {
            if (!string.IsNullOrWhiteSpace(reportingChart.PropChartSelectedPaletteName)
                && ChartPaletteStyleDropDownList.Items.FindByValue(reportingChart.PropChartSelectedPaletteName) != null)
            {
                ChartPaletteStyleDropDownList.Items.FindByValue(reportingChart.PropChartSelectedPaletteName)
                                             .Selected = true;
            }
        }

        private void SortListControls()
        {
            SortListControlItems(XaxisFieldDropDownList);
            SortListControlItems(ddlXaxisFieldNum);
            SortListControlItems(ddlXaxisFieldNonNum);
            SortListControlItems(cblYaxisFieldNum);
            SortListControlItems(ddlYaxisFieldNum);
            SortListControlItems(ZaxisFieldDropDownList);
            SortListControlItems(cblYaxisFieldNonNum);
            SortListControlItems(ddlYaxisFieldNonNum);
            SortListControlItems(BubbleGroupByDropDownList);
            SortListControlItems(BubbleChartColorFieldDropDownList);
            SortListControlItems(ChartPaletteStyleDropDownList);
        }

        private void ClearControls()
        {
            XaxisFieldDropDownList?.Items.Clear();
            ddlXaxisFieldNum?.Items.Clear();
            ddlXaxisFieldNonNum?.Items.Clear();
            cblYaxisFieldNum?.Items.Clear();
            ddlYaxisFieldNum?.Items.Clear();
            ZaxisFieldDropDownList?.Items.Clear();
            cblYaxisFieldNonNum?.Items.Clear();
            ddlYaxisFieldNonNum?.Items.Clear();
            BubbleGroupByDropDownList?.Items.Clear();
            ChartPaletteStyleDropDownList?.Items.Clear();
        }

        private DataTable GetListColumns(Guid id)
        {
            DataTable result = new DataTable();
            string sGuid = id.ToString();
            if (!string.IsNullOrEmpty(sGuid))
            {
                QueryExecutor qExec = new QueryExecutor(SPContext.Current.Web);
                string sql = "SELECT * FROM RPTColumn WHERE RPTListId = '" + sGuid + "'";
                result = qExec.ExecuteReportingDBQuery(sql, new Dictionary<string, object>());
            }
            return result;
        }

        private DataTable GetMappedLists()
        {
            DataTable result = new DataTable();
            QueryExecutor qExec = new QueryExecutor(SPContext.Current.Web);
            string sql = @"SELECT ListName, RPTListId FROM RPTList WHERE TableName IN (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES)";
            result = qExec.ExecuteReportingDBQuery(sql, new Dictionary<string, object>());
            return result;
        }

        /// <summary>
        /// Sort items in controls that inherits from "ListControl"
        /// </summary>
        /// <param name="o"></param>
        private static void SortListControlItems(object o)
        {
            if (o is ListControl)
            {
                ListControl lc = (ListControl)o;
                var sorted = (from ListItem i in lc.Items
                              orderby i.Text
                    select i).ToArray();
                ListItemCollection liCol = new ListItemCollection();
                liCol.AddRange(sorted);
                lc.DataSource = liCol;
                lc.DataValueField = "Value";
                lc.DataTextField = "Text";
                lc.DataBind();
            }
        }

        #endregion

        private bool IsBubbleChart()
        {
            ReportingChart rc = (ReportingChart)ParentToolPane.SelectedWebPart;
            string sType = Enum.GetName(typeof(ChartType), rc.PropChartType);
            return sType.ToLower() == "bubble";
        }

        internal static string GetFieldSchemaAttribValue(string sStringToSearch, string sAttribName)
        {
            string sAttribVal = "";
            int iFindPos = sStringToSearch.ToUpper().IndexOf(sAttribName.ToUpper() + "=");
            int iSubStrStart = iFindPos + sAttribName.Length + 2;
            int iSubStrEnd = sStringToSearch.IndexOf("\"", iSubStrStart);
            sAttribVal = sStringToSearch.Substring(iSubStrStart, iSubStrEnd - iSubStrStart);
            return sAttribVal;
        }

        private void RenderOneYField(HtmlTextWriter output, bool isNum, bool isHidden)
        {
            output.Write("<tr><td>");

            if (isHidden)
                output.Write("<div id='YaxisSection_ddl' style='display:none'>");
            else
                output.Write("<div id='YaxisSection_ddl'>");

            output.Write("Value (Y Axis) </br>");

            if (isNum)
                output.Write("<div id='YaxisSection_ddl_num'>");
            else
                output.Write("<div id='YaxisSection_ddl_num' style='display:none'>");

            ddlYaxisFieldNum.RenderControl(output);
            output.Write("</div>");


            if (isNum)
                output.Write("<div id='YaxisSection_ddl_nonnum' style='display:none'>");
            else
                output.Write("<div id='YaxisSection_ddl_nonnum'>");

            ddlYaxisFieldNonNum.RenderControl(output);
            output.Write("</div>");


            output.Write("</div>");
            output.Write("</td></tr>");
        }

        private void RenderMultipleYField(HtmlTextWriter output, bool isNum, bool isHidden)
        {
            output.Write("<tr><td>");

            if (isHidden)
                output.Write("<div id='YaxisSection_cbl' style='display:none'>");
            else
                output.Write("<div id='YaxisSection_cbl' >");

            output.Write("Series (Y Axis) </br>");

            if (isNum)
                output.Write(cblYaxisFieldNum.Items.Count > 0 ? "" : "No fields found.");
            else
                output.Write(cblYaxisFieldNonNum.Items.Count > 0 ? "" : "No fields found.");

            if (isNum)
                output.Write("<div id='YaxisSection_cbl_num'>");
            else
                output.Write("<div id='YaxisSection_cbl_num' style='display:none'>");
            cblYaxisFieldNum.RenderControl(output);
            output.Write("</div>");


            if (isNum)
                output.Write("<div id='YaxisSection_cbl_nonnum' style='display:none'>");
            else
                output.Write("<div id='YaxisSection_cbl_nonnum'>");
            cblYaxisFieldNonNum.RenderControl(output);
            output.Write("</div>");


            output.Write("</div>");
            output.Write("</td></tr>");
        }
    }

}