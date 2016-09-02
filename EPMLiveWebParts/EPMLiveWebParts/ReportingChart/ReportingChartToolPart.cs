using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.WebPartPages;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;
using Microsoft.SharePoint;
using System.Web;
using Telerik.Web.UI;
using System.Drawing;
using EPMLiveWebParts.EpmCharting.DomainServices;
using EPMLiveWebParts;
using System.Data;
using EPMLiveCore.ReportingProxy;


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
            string sChartTypeVal = ChartTypeDropDownList.SelectedValue;
            string sAggType = AggregateTypeHtmlSelect.Value;


            output.Write("<div class=\"UserSectionHead\">");
            output.Write("<b>Chart Configuration</b>");
            output.Write("<br />");
            output.Write("<table cellpadding=1 style=\"padding-left: 5px\">");

            #region RENDER LISTS DROP DOWN
            output.Write("<tr><td>");
            output.Write("List<br>");
            ListsDropDownList.RenderControl(output);
            output.Write("</td></tr>");
            #endregion

            #region RENDER VIEWS DROP DOWN
            output.Write("<tr><td>");
            output.Write("View<br>");
            ViewsDropDownList.RenderControl(output);
            output.Write("</td></tr>");
            #endregion

            if (IsBubbleChart())
            {
                //output.Write("<tr><td>");
                //ShowBubbleChartInputsInWebPart.RenderControl(output);
                //output.Write("Allow User To Select X, Y, Z Values<br></td></tr>");
            }

            #region RENDER CHART TYPES DROPDOWN
            output.Write("<tr><td>");
            output.Write("Chart Type<br>");
            ChartTypeDropDownList.RenderControl(output);
            output.Write("</td></tr>");
            #endregion

            #region RENDER AGGREGATE TYPE DROPDOWN

            output.Write("<tr><td>");
            if (sChartTypeVal.Contains("Bubble"))
            {
                output.Write("<div id=\"aggTypeSec\" display='none'>");
            }
            else
            {
                output.Write("<div id=\"aggTypeSec\" display='none'>");
            }
            output.Write("Aggregation Type<br>");
            AggregateTypeHtmlSelect.RenderControl(output);
            output.Write("<br>");
            output.Write("</div>");
            output.Write("</td></tr>");

            #endregion

            #region RENDER X AXIS
            output.Write("<tr><td>");

            if (sChartTypeVal == "Area" || sChartTypeVal == "Bar" || sChartTypeVal == "Column" || sChartTypeVal == "Line")
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
                else if (sAggType == "Sum" || sAggType == "Avg")
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
            // MULTI SERIES
            else if (sChartTypeVal.Contains("_Clustered") || sChartTypeVal.Contains("_Stacked") || sChartTypeVal.Contains("_100Percent"))
            {
                if (sAggType == "Count")
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
                else if (sAggType == "Sum" || sAggType == "Avg")
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
            else if (sChartTypeVal.Contains("Pie") || sChartTypeVal.Contains("Donut"))
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
                else if (sAggType == "Sum" || sAggType == "Avg")
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
            #endregion

            #region RENDER Y AXIS
            bool bRenderY = false;
            // SINGLE SERIES
            if (sChartTypeVal == "Area" || sChartTypeVal == "Bar" || sChartTypeVal == "Column" || sChartTypeVal == "Line")
            {
                if (sAggType == "Count")
                {
                    // NO Y VALUE
                    RenderOneYField(output, false, true);
                    RenderMultipleYField(output, false, true);
                }
                else if (sAggType == "Sum" || sAggType == "Avg")
                {
                    // 1 Y VALUE                   
                    RenderOneYField(output, true, false);
                    RenderMultipleYField(output, true, true);
                    bRenderY = true;
                }
            }
            // MULTI SERIES
            else if (sChartTypeVal.Contains("_Clustered") || sChartTypeVal.Contains("_Stacked") || sChartTypeVal.Contains("_100Percent"))
            {
                if (sAggType == "Count")
                {
                    // 1 Y VALUE
                    RenderOneYField(output, false, false);
                    RenderMultipleYField(output, false, true);
                    bRenderY = true;
                }
                else if (sAggType == "Sum" || sAggType == "Avg")
                {
                    // MORE THAN 1 Y VALUE
                    RenderMultipleYField(output, true, false);
                    RenderOneYField(output, false, true);
                    bRenderY = true;
                }
            }
            else if (sChartTypeVal.Contains("Pie") || sChartTypeVal.Contains("Donut"))
            {
                if (sAggType == "Count")
                {
                    // NO Y VALUE 
                    RenderOneYField(output, false, true);
                    RenderMultipleYField(output, false, true);
                }
                else if (sAggType == "Sum" || sAggType == "Avg")
                {
                    // 1 Y VALUE
                    RenderOneYField(output, true, false);
                    RenderMultipleYField(output, false, true);
                    bRenderY = true;
                }
            }
            // FOR SCATTER AND SCATTER LINE
            else if (sChartTypeVal.Contains("Scatter"))
            {
                // 1 Y VALUE
                RenderOneYField(output, true, false);
                RenderMultipleYField(output, false, true);
                bRenderY = true;
            }
            else if (sChartTypeVal.Contains("Bubble"))
            {
                // 1 Y VALUE
                RenderOneYField(output, true, false);
                RenderMultipleYField(output, false, true);
                bRenderY = true;
            }

            // render y axis formatting controls
            output.Write("<tr><td>");
            if (bRenderY)
            {
                output.Write("<div id='YAxisFormatSection'>");
            }
            else
            {
                output.Write("<div id='YAxisFormatSection' style='display:none'>");
            }
            output.Write("Y Axis Formatting<br>");
            YaxisFormatDropDownList.RenderControl(output);
            output.Write("</div>");
            output.Write("</td></tr>");

            #endregion

            #region RENDER Z AXIS
            output.Write("<tr><td>");
            if (sChartTypeVal.Contains("Bubble"))
            {
                output.Write("<div id='ZaxisSection'>");
            }
            else
            {
                output.Write("<div id='ZaxisSection' style='display:none'>");
            }
            output.Write("Size Value (Z Axis)<br/>");
            ZaxisFieldDropDownList.RenderControl(output);
            output.Write("<br/>");
            //output.Write("<b>Z Axis Color Field</b><br>");
            //BubbleChartColorFieldDropDownList.RenderControl(output);
            output.Write("Group By<br/>");
            BubbleGroupByDropDownList.RenderControl(output);
            output.Write("<br/>");
            output.Write("</div>");
            output.Write("</td></tr>");
            #endregion

            output.Write("</table>");
            output.Write("</div>");
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
            // SHOW Z ONLY WHEN CONFIGURATING BUBBLE CHARTS
            output.Write(" document.getElementById(\"ZaxisSection\").style.display = (cType == 'Bubble') ? '' : 'none'; ");
            output.Write(" if (cType == \"Area\" || cType == \"Bar\" || cType == \"Column\" || cType == \"Line\") { ");
            output.Write("     if (aggVal == \"Count\") { ");
            // NO Y VALUE
            output.Write("      try{ ");
            output.Write("         document.getElementById(\"XaxisSection_full\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YAxisFormatSection\").style.display = \"none\"; ");
            output.Write("      } catch (e) {} ");
            output.Write("     } else if (aggVal == \"Sum\" || aggVal == \"Avg\"){ ");
            // 1 Y VALUE (NUMERICAL)
            output.Write("      try{ ");
            output.Write("         document.getElementById(\"XaxisSection_full\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_num\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YAxisFormatSection\").style.display = \"\"; ");
            output.Write("      } catch (e) {} ");
            output.Write("     } ");
            output.Write(" } else if (cType.indexOf(\"_Clustered\") != -1 || cType.indexOf(\"_Stacked\") != -1 || cType.indexOf(\"_100Percent\") != -1) { ");
            output.Write("     if (aggVal == \"Count\") { ");
            // 1 Y VALUE (NON NUMERICAL)
            output.Write("      try{ ");
            output.Write("         document.getElementById(\"XaxisSection_full\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YAxisFormatSection\").style.display = \"\"; ");
            output.Write("      } catch (e) {} ");
            output.Write("     } else if (aggVal == \"Sum\" || aggVal == \"Avg\"){ ");
            // MORE THAN 1 Y VALUE (Numerical)
            output.Write("      try{ ");
            output.Write("         document.getElementById(\"XaxisSection_full\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_num\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YAxisFormatSection\").style.display = \"\"; ");
            output.Write("      } catch (e) {} ");
            output.Write("     } ");
            output.Write(" } else if (cType == \"Pie\" || cType == \"Donut\" ) { ");
            output.Write("     if (aggVal == \"Count\") { ");
            // NO Y VALUE
            output.Write("      try{ ");
            output.Write("         document.getElementById(\"XaxisSection_full\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YAxisFormatSection\").style.display = \"none\"; ");
            output.Write("      } catch (e) {} ");
            output.Write("     } else if (aggVal == \"Sum\" || aggVal == \"Avg\"){ ");
            // 1 Y VALUE (Numerical)
            output.Write("      try{ ");
            output.Write("         document.getElementById(\"XaxisSection_full\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_num\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YAxisFormatSection\").style.display = \"\"; ");
            output.Write("      } catch (e) {} ");
            output.Write("     } ");
            output.Write(" } else if (cType == \"Bubble\" ) { ");
            // 1 Y VALUE (NUMERICAL)
            output.Write("      try{ ");
            output.Write("         document.getElementById(\"XaxisSection_full\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_num\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"XaxisSection_ddl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_num\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_num\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_cbl_nonnum\").style.display = \"none\"; ");
            output.Write("         document.getElementById(\"YaxisSection_ddl\").style.display = \"\"; ");
            output.Write("         document.getElementById(\"YAxisFormatSection\").style.display = \"\"; ");
            output.Write("      } catch (e) {} ");
            output.Write(" } ");
            output.Write("}");
            output.Write("</script>");

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
            string sListTitle = ListsDropDownList.SelectedValue;
            if (string.IsNullOrEmpty(sListTitle) || sListTitle == "<Select List>")
                return;

            SPList oList = SPContext.Current.Web.Lists.TryGetList(sListTitle);
            if (oList == null)
                return;

            XaxisFieldDropDownList.Items.Clear();
            ddlXaxisFieldNum.Items.Clear();
            ddlXaxisFieldNonNum.Items.Clear();
            cblYaxisFieldNum.Items.Clear();
            ddlYaxisFieldNum.Items.Clear();
            ZaxisFieldDropDownList.Items.Clear();
            cblYaxisFieldNonNum.Items.Clear();
            ddlYaxisFieldNonNum.Items.Clear();
            BubbleGroupByDropDownList.Items.Clear();
            ChartPaletteStyleDropDownList.Items.Clear();

            ReportingChart rc = (ReportingChart)ParentToolPane.SelectedWebPart;

            // fill color paletWte ddl
            ChartPaletteStyleDropDownList.Items.AddRange(new ListItem[] {
                new ListItem("Color 1", "Color1"),
                new ListItem("Color 2", "Color2"),
                new ListItem("Gray", "Gray"),
                new ListItem("Blue", "Blue"),
                new ListItem("Red", "Red"),
                new ListItem("Green", "Green"),
                new ListItem("Yellow", "Yellow"),
                new ListItem("Violet", "Violet")
            });

            DataTable dt = GetListColumns(oList.ID);
            foreach (DataRow fld in dt.Rows)
            {
                string sFldSharePointType = fld["SharePointType"].ToString();
                string sFldDisplayName = fld["DisplayName"].ToString();
                string sFldInternalName = fld["InternalName"].ToString();
                string sFldColType = fld["ColumnType"].ToString();

                if (sFldSharePointType == "Attachments" || sFldInternalName == "Order" ||
                    sFldSharePointType == "File" || sFldInternalName == "Metainfo" ||
                    sFldSharePointType == "Computed" || sFldSharePointType == "Guid" ||
                    sFldSharePointType == "Counter" || sFldSharePointType == "Note")
                    continue;

                var liX = new ListItem(sFldDisplayName, sFldInternalName);
                if (!XaxisFieldDropDownList.Items.Contains(liX))
                    XaxisFieldDropDownList.Items.Add(liX);

                // numeric
                if ((sFldSharePointType == "Calculated" && sFldColType == "Float") ||
                    (sFldSharePointType == "Calculated" && sFldColType == "Int") ||
                    sFldSharePointType == "Currency" ||
                    sFldSharePointType == "Integer" ||
                    sFldSharePointType == "Number")
                {
                    var liNum = new ListItem(sFldDisplayName, sFldInternalName);

                    if (!ddlXaxisFieldNum.Items.Contains(liNum))
                        ddlXaxisFieldNum.Items.Add(liNum);

                    if (!cblYaxisFieldNum.Items.Contains(liNum))
                        cblYaxisFieldNum.Items.Add(liNum);

                    if (!ddlYaxisFieldNum.Items.Contains(liNum))
                        ddlYaxisFieldNum.Items.Add(liNum);

                    if (!ZaxisFieldDropDownList.Items.Contains(liNum))
                        ZaxisFieldDropDownList.Items.Add(liNum);
                }
                // non-numeric
                else
                {
                    var liNonNum = new ListItem(sFldDisplayName, sFldInternalName);

                    if (!ddlXaxisFieldNonNum.Items.Contains(liNonNum))
                        ddlXaxisFieldNonNum.Items.Add(liNonNum);

                    if (!cblYaxisFieldNonNum.Items.Contains(liNonNum))
                        cblYaxisFieldNonNum.Items.Add(liNonNum);

                    if (!ddlYaxisFieldNonNum.Items.Contains(liNonNum))
                        ddlYaxisFieldNonNum.Items.Add(liNonNum);

                    if (!BubbleGroupByDropDownList.Items.Contains(liNonNum))
                        BubbleGroupByDropDownList.Items.Add(liNonNum);
                }
            }

            YaxisFormatDropDownList.Items.Clear();
            // fill y axis format ddl
            YaxisFormatDropDownList.Items.AddRange(new ListItem[] {
                new ListItem("None", "None"),
                new ListItem("Currency", "Currency"),
                new ListItem("Percentage", "Percentage")
            });

            LegendPositionDropDownList.Items.Clear();
            LegendPositionDropDownList.Items.AddRange(new ListItem[] {
                new ListItem("Left", "Left"),
                new ListItem("Top", "Top"),
                new ListItem("Right", "Right"),
                new ListItem("Bottom", "Bottom")
            });

            if (LegendPositionDropDownList.Items.FindByText(rc.PropChartLegendPosition) != null)
            {
                LegendPositionDropDownList.Items.FindByText(rc.PropChartLegendPosition).Selected = true;
            }

            SortListControlItems(XaxisFieldDropDownList);
            SortListControlItems(ddlXaxisFieldNum);
            SortListControlItems(ddlXaxisFieldNonNum);
            // sort numeric fields
            SortListControlItems(cblYaxisFieldNum);
            SortListControlItems(ddlYaxisFieldNum);
            SortListControlItems(ZaxisFieldDropDownList);
            // sort non-numeric fields
            SortListControlItems(cblYaxisFieldNonNum);
            SortListControlItems(ddlYaxisFieldNonNum);
            SortListControlItems(BubbleGroupByDropDownList);
            SortListControlItems(BubbleChartColorFieldDropDownList);
            SortListControlItems(ChartPaletteStyleDropDownList);


            if (!string.IsNullOrEmpty(rc.PropChartXaxisField))
            {
                if (XaxisFieldDropDownList.Items.FindByValue(rc.PropChartXaxisField) != null)
                {
                    XaxisFieldDropDownList.Items.FindByValue(rc.PropChartXaxisField).Selected = true;
                }

                if (ddlXaxisFieldNum.Items.FindByValue(rc.PropChartXaxisField) != null)
                {
                    ddlXaxisFieldNum.Items.FindByValue(rc.PropChartXaxisField).Selected = true;
                }

                if (ddlXaxisFieldNonNum.Items.FindByValue(rc.PropChartXaxisField) != null)
                {
                    ddlXaxisFieldNonNum.Items.FindByValue(rc.PropChartXaxisField).Selected = true;
                }
            }

            if (!string.IsNullOrEmpty(rc.PropChartYaxisField))
            {
                string[] yFlds = rc.PropChartYaxisField.Split('|');
                if (yFlds.Count() > 1)
                {
                    foreach (string yFld in yFlds)
                    {
                        if (cblYaxisFieldNum.Items.FindByValue(yFld) != null)
                        {
                            cblYaxisFieldNum.Items.FindByValue(yFld).Selected = true;
                        }

                        if (cblYaxisFieldNonNum.Items.FindByValue(yFld) != null)
                        {
                            cblYaxisFieldNonNum.Items.FindByValue(yFld).Selected = true;
                        }
                    }
                }
                else
                {
                    string yVal = yFlds[0];
                    if (ddlYaxisFieldNum.Items.FindByValue(yVal) != null)
                    {
                        ddlYaxisFieldNum.Items.FindByValue(yVal).Selected = true;
                    }

                    if (ddlYaxisFieldNonNum.Items.FindByValue(yVal) != null)
                    {
                        ddlYaxisFieldNonNum.Items.FindByValue(yVal).Selected = true;
                    }
                }

                if (!string.IsNullOrEmpty(rc.PropYaxisFormat))
                {
                    if (YaxisFormatDropDownList.Items.FindByValue(rc.PropYaxisFormat) != null)
                    {
                        YaxisFormatDropDownList.Items.FindByValue(rc.PropYaxisFormat).Selected = true;
                    }
                }
            }

            if (!string.IsNullOrEmpty(rc.PropChartZaxisField))
            {
                if (ZaxisFieldDropDownList.Items.FindByValue(rc.PropChartZaxisField) != null)
                {
                    ZaxisFieldDropDownList.Items.FindByValue(rc.PropChartZaxisField).Selected = true;
                }
            }

            if (!string.IsNullOrEmpty(rc.PropBubbleChartGroupBy))
            {
                if (BubbleGroupByDropDownList.Items.FindByValue(rc.PropBubbleChartGroupBy) != null)
                {
                    BubbleGroupByDropDownList.Items.FindByValue(rc.PropBubbleChartGroupBy).Selected = true;
                }
            }

            if (!string.IsNullOrEmpty(rc.PropChartSelectedPaletteName))
            {
                if (ChartPaletteStyleDropDownList.Items.FindByValue(rc.PropChartSelectedPaletteName) != null)
                {
                    ChartPaletteStyleDropDownList.Items.FindByValue(rc.PropChartSelectedPaletteName).Selected = true;
                }
            }

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
                              orderby i.Text ascending
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