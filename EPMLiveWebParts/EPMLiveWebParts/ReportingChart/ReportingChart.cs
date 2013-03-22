using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using Telerik.Web.UI;
using EPMLiveCore.ReportingProxy;
using System.Globalization;

namespace EPMLiveWebParts.ReportingChart
{
    [ToolboxData("<{0}:ReportingChartWebpart runat=server></{0}:ReportingChartWebpart>")]
    [Guid("1F63CCFF-E542-4149-97B5-54BDB7F02EFA")]
    [XmlRoot(Namespace = "EPMLiveWebParts.ReportingChart")]
    public class ReportingChart : Microsoft.SharePoint.WebPartPages.WebPart
    {
        #region Fields
        private static string CURRENCY_SYMBOL = SPContext.Current.Web.Locale.NumberFormat.CurrencySymbol;
        public static char Separator = '|';
        protected Literal ScriptTagHolder = new Literal();
        protected DataTable ChartData;
        protected DataTable SiteDataQueryData;
        protected Literal ConfigureChartVerbiageLiteral = new Literal();
        protected SPList TopList;
        protected ToolPart[] WebPartToolPart;
        private RadHtmlChart _radChart;

        //TODO: Don't name these bubble chart specific as these could theoretically be used for other charts.
        protected DropDownList BubbleChartXaxisDropDownList;
        protected DropDownList BubbleChartYaxisAsDropDownList;
        protected CheckBoxList BubbleChartYaxisCheckBoxList;
        protected DropDownList BubbleChartZaxisDropDownList;
        protected DropDownList BubbleChartZcolorFieldDropDownList;
        protected Button BubbleChartApplyButton;
        protected HtmlTable UserSettingsTable;
        protected HtmlTable MainTable;

        private ChartType MainChartType;
        private bool bPropChartShowSeriesLabels;
        private bool bPropChartShowLegend;
        private string sPropChartLegendPosition;
        private bool bPropChartShowGridlines;

        private List<string> XAxisLabels;
        private string YAxisLabel = string.Empty;
        #endregion

        #region Properties

        private Dictionary<string, string> DictFieldIntAndDispName
        {
            get
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(PropChartSelectedListTitle))
                {
                    result = GetFldsIntAndDispNameDictionary(PropChartSelectedListTitle);
                }
                return result;
            }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [WebBrowsable(false)]
        public string PropChartTitle
        {
            get;
            set;
        }


        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [WebBrowsable(false)]
        public ChartType PropChartType
        {
            get { return MainChartType; }
            set { MainChartType = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [WebBrowsable(false)]
        public string PropChartSelectedPaletteName
        {
            get;
            set;
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [WebBrowsable(false)]
        public string PropChartSelectedListTitle
        {
            get;
            set;
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [WebBrowsable(false)]
        public string PropChartSelectedViewTitle
        {
            get;
            set;
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartXaxisField
        {
            get;
            set;
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartXaxisFieldLabel
        {
            get;
            set;
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartYaxisField
        {
            get;
            set;
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartYaxisFieldLabel
        {
            get;
            set;
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartZaxisField
        {
            get;
            set;
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartZaxisFieldLabel
        {
            get;
            set;
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropBubbleChartGroupBy
        {
            get;
            set;
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropYaxisFormat
        {
            get;
            set;
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowSeriesLabels
        {
            get { return bPropChartShowSeriesLabels; }
            set { bPropChartShowSeriesLabels = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowLegend
        {
            get { return bPropChartShowLegend; }
            set { bPropChartShowLegend = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartLegendPosition
        {
            get { return sPropChartLegendPosition; }
            set { sPropChartLegendPosition = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowGridlines
        {
            get { return bPropChartShowGridlines; }
            set { bPropChartShowGridlines = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartAggregationType
        {
            get;
            set;
        }

        public string UpdatePanelClientId
        {
            get;
            set;
        }

        public string RadChartClientId
        {
            get;
            set;
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            XAxisLabels = new List<string>();
            YAxisLabel = string.Empty;

            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "__KendoCultureJS__", "$(function () { kendo.culture('" + SPContext.Current.Web.Locale.ToString() + "'); });", true);

            // add kendo culture js reference
            ScriptReference srKendo = new ScriptReference();
            srKendo.Path = "/_layouts/epmlive/javascripts/libraries/Kendo/cultures/kendo.culture." + SPContext.Current.Web.Locale.ToString() + ".min.js";
            ScriptManager.GetCurrent(this.Page).Scripts.Add(srKendo);
        }

        protected override void CreateChildControls()
        {
            AddControls();
            ConfigureDisplayFormat();
            BuildSeries();
            BuildXAxisItemLabels();
            BuildYAxisItemLabels();
        }

        public override void RenderControl(HtmlTextWriter writer)
        {
            base.RenderControl(writer);

            if (string.IsNullOrEmpty(PropChartSelectedListTitle))
            {
                writer.Write(@"<script language=""javascript"">
                                function loadChartWizard()
                                {
                                    var tag = document.getElementsByTagName('object');
                                    for(var i = tag.length-1;i>=0;i--)
                                        tag[i].style.display='none';

                                    function myCallback(dialogResult, returnValue) 
                                    {
                                        if (dialogResult == 1){
                                            __doPostBack('" + UpdatePanelClientId + @"', '');
                                            $('#divWizardBox').css('display', 'none');
                                            $('#" + RadChartClientId + @"').css('display', '');
                                        } 
                                    }

                                    var options = {url: """ + ((SPContext.Current.Web.ServerRelativeUrl == "/") ? "" : SPContext.Current.Web.ServerRelativeUrl) + @"/_layouts/epmlive/ChartWizard.aspx"", 
                                                    dialogReturnValueCallback:myCallback, 
                                                    showClose: false,
                                                    allowMaximize: false,
                                                    args: { 
                                                        wpId: '" + this.ID + @"',
                                                        wpPagePath: '" + HttpContext.Current.Request.Url.AbsoluteUri + @"'
                                                    } 
                                                  };

                                    SP.UI.ModalDialog.showModalDialog(options);
                                }
                                
                            </script>

                            <style>
                            .wizardBox
                            {
                                height:100px;
                                width:300px;
                                margin: 20px auto;
                                display:inline-block;
                                background: url('_layouts/epmlive/images/startwizard.png') no-repeat center 0px;
                                cursor: pointer;
                            }
                            </style>

                            <div id='divWizardBox' style='width:100%;text-align:center'>
                                <a onclick='loadChartWizard();' style='text-decoration:none;width:150px;'>
                                    <div class='wizardBox'></div>
                                </a>
                            </div>
                           ");
            }

        }

        private void AddControls()
        {
            UpdatePanel updatePanel = new UpdatePanel();
            _radChart = new RadHtmlChart();
            if (!string.IsNullOrEmpty(PropChartSelectedListTitle))
            {
                SetChartProps(_radChart);
            }
            else
            {
                _radChart.Style["display"] = "none";
            }
            updatePanel.ContentTemplateContainer.Controls.Add(_radChart);
            updatePanel.Load += new EventHandler(updatePanel_Load);
            Controls.Add(updatePanel);
            UpdatePanelClientId = updatePanel.ClientID;
            RadChartClientId = _radChart.ClientID;
        }

        void updatePanel_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PropChartSelectedListTitle) && !string.IsNullOrEmpty(PropChartSelectedViewTitle))
            {
                _radChart.PlotArea.Series.Clear();
                BuildSeries();
                BuildXAxisItemLabels();
                BuildYAxisItemLabels();
            }

        }

        private void SetChartProps(RadHtmlChart c)
        {
            c.Transitions = true;
            // style x axis label
            c.PlotArea.XAxis.TitleAppearance.Text = PropChartXaxisFieldLabel;
            c.PlotArea.XAxis.TitleAppearance.TextStyle.Bold = false;
            c.PlotArea.XAxis.TitleAppearance.TextStyle.FontSize = 14;
            c.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "Arial";
            // style y axis label
            c.PlotArea.YAxis.TitleAppearance.Text = PropChartYaxisFieldLabel;
            c.PlotArea.YAxis.TitleAppearance.TextStyle.Bold = false;
            c.PlotArea.YAxis.TitleAppearance.TextStyle.FontSize = 14;
            c.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "Arial";
            // style chart title label
            c.ChartTitle.Text = PropChartTitle;
            c.ChartTitle.Appearance.TextStyle.Bold = true;
            c.ChartTitle.Appearance.TextStyle.FontSize = 18;
            c.ChartTitle.Appearance.TextStyle.FontFamily = "Arial";

            c.Legend.Appearance.Visible = PropChartShowLegend;
            c.Legend.Appearance.Position = !string.IsNullOrEmpty(PropChartLegendPosition) ?
                (Telerik.Web.UI.HtmlChart.ChartLegendPosition)Enum.Parse(typeof(Telerik.Web.UI.HtmlChart.ChartLegendPosition), PropChartLegendPosition) : Telerik.Web.UI.HtmlChart.ChartLegendPosition.Bottom;

            if (PropChartShowGridlines)
            {
                c.PlotArea.XAxis.MajorGridLines.Visible = true;
                c.PlotArea.XAxis.MinorGridLines.Visible = true;
                c.PlotArea.YAxis.MajorGridLines.Visible = true;
                c.PlotArea.YAxis.MinorGridLines.Visible = true;

            }
            else
            {
                c.PlotArea.XAxis.MajorGridLines.Visible = false;
                c.PlotArea.XAxis.MinorGridLines.Visible = false;
                c.PlotArea.YAxis.MajorGridLines.Visible = false;
                c.PlotArea.YAxis.MinorGridLines.Visible = false;
            }

            if (PropYaxisFormat == "Currency")
            {
                c.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0:c}";
            }
            else if (PropYaxisFormat == "Percentage")
            {
                c.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0:p}";
            }
            else
            {
                c.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0}";
            }

        }

        private void ConfigureDisplayFormat()
        {
            switch (PropYaxisFormat)
            {
                case "Dollar":
                    _radChart.PlotArea.YAxis.LabelsAppearance.DataFormatString = "${0}";
                    break;
                case "Percentage":
                    _radChart.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0:p}";
                    break;
                default:
                    _radChart.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0}";
                    break;
            }
        }

        private void BuildXAxisItemLabels()
        {
            if (XAxisLabels.Count > 0)
            {
                _radChart.PlotArea.XAxis.Items.Clear();
                foreach (string s in XAxisLabels)
                {
                    _radChart.PlotArea.XAxis.Items.Add(new AxisItem(s));
                }
            }

            _radChart.PlotArea.XAxis.LabelsAppearance.Visible = PropChartShowSeriesLabels;

        }

        private void BuildYAxisItemLabels()
        {
            if (!string.IsNullOrEmpty(YAxisLabel))
            {
                _radChart.PlotArea.YAxis.TitleAppearance.Text = YAxisLabel;
            }
            else
            {
                _radChart.PlotArea.YAxis.TitleAppearance.Text = PropChartYaxisFieldLabel;
            }

            if (PropYaxisFormat != "None")
            {
                if (PropYaxisFormat == "Currency")
                {
                    _radChart.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0:c}";
                }
                else if (PropYaxisFormat == "Percentage")
                {
                    _radChart.PlotArea.YAxis.LabelsAppearance.DataFormatString = "{0:p}";
                }
            }

            _radChart.PlotArea.YAxis.LabelsAppearance.Visible = true;
        }

        /// <summary>
        /// This function 
        /// (1) gets relevant data
        /// (2) and adds series by chart type.
        /// </summary>
        public void BuildSeries()
        {
            _radChart.PlotArea.Series.Clear();

            if (MainChartType == ChartType.Area || MainChartType == ChartType.Area_Clustered)
            {
                BuildAreaSeries();
            }
            else if (MainChartType == ChartType.Bar || MainChartType == ChartType.Bar_Clustered ||
                MainChartType == ChartType.Bar_Stacked || MainChartType == ChartType.Bar_100Percent)
            {
                BuildBarSeries();
            }
            else if (MainChartType == ChartType.Bubble)
            {
                BuildBubbleSeries();
            }
            else if (MainChartType == ChartType.Column || MainChartType == ChartType.Column_Clustered ||
                MainChartType == ChartType.Column_Stacked || MainChartType == ChartType.Column_100Percent)
            {
                BuildColumnSeries();
            }
            else if (MainChartType == ChartType.Donut)
            {
                BuildDonutSeries();
            }
            else if (MainChartType == ChartType.Line || MainChartType == ChartType.Line_Clustered)
            {
                BuildLineSeries();
            }
            else if (MainChartType == ChartType.Pie)
            {
                BuildPieSeries();
            }
            //else if (MainChartType == ChartType.Scatter)
            //{
            //    BuildScatterSeries();
            //}
            //else if (MainChartType == ChartType.ScatterLine)
            //{
            //    BuildScatterLineSeries();
            //}
        }

        private Color[] GetColors(string paletteName)
        {
            Color[] result;
            switch (paletteName)
            {
                case "Blue":
                    result = ColorPalettes.BluePalette;
                    break;
                case "Green":
                    result = ColorPalettes.GreenPalette;
                    break;
                case "Red":
                    result = ColorPalettes.RedPalette;
                    break;
                case "Yellow":
                    result = ColorPalettes.YellowPalette;
                    break;
                case "Gray":
                    result = ColorPalettes.GrayPalette;
                    break;
                case "Violet":
                    result = ColorPalettes.Violet;
                    break;
                case "Color1":
                    result = ColorPalettes.Color1;
                    break;
                case "Color2":
                    result = ColorPalettes.Color2;
                    break;
                default:
                    result = ColorPalettes.GrayPalette;
                    break;
            }

            return result;
        }

        private void BuildAreaSeries()
        {
            AreaSeries sArea;
            Dictionary<string, List<SeriesItem>> lListSeriesItems = GetSeriesItems();
            Random rColor = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            int colorIndex = 0;
            Color[] paletteColors = GetColors(PropChartSelectedPaletteName);
            foreach (KeyValuePair<string, List<SeriesItem>> list in lListSeriesItems)
            {
                sArea = new AreaSeries();
                sArea.Name = list.Key;
                sArea.Items.AddRange(list.Value);

                Color fillColor;
                if (colorIndex > 4)
                {
                    KnownColor randomColorName = names[rColor.Next(names.Length)];
                    fillColor = Color.FromKnownColor(randomColorName);
                }
                else
                {
                    fillColor = paletteColors[colorIndex];
                    colorIndex++;
                }
                //SPWeb spWeb = SPContext.Current.Web;
                //SPRegionalSettings spRegionalSettings = spWeb.CurrentUser.RegionalSettings ??
                //                                        spWeb.Site.RootWeb.RegionalSettings;

                //var cultureInfo = new CultureInfo((int)spRegionalSettings.LocaleId);

                //string currencyFormat = string.Format("{0}#.00", cultureInfo.NumberFormat.CurrencySymbol);
                //string shortDatePattern = cultureInfo.DateTimeFormat.ShortDatePattern;

                sArea.Appearance.FillStyle.BackgroundColor = fillColor;

                if (PropYaxisFormat == "Currency")
                {
                    sArea.LabelsAppearance.DataFormatString = "{0:c}";
                    sArea.TooltipsAppearance.DataFormatString = sArea.Name + " = {0:c}";
                }
                else if (PropYaxisFormat == "Percentage")
                {
                    sArea.LabelsAppearance.DataFormatString = "{0:p}";
                    sArea.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.LineAndScatterLabelsPosition.Above;
                    sArea.TooltipsAppearance.DataFormatString = sArea.Name + " = {0:p}";
                }
                _radChart.PlotArea.Series.Add(sArea);
            }
        }

        private void BuildBarSeries()
        {
            BarSeries sBar;
            Dictionary<string, List<SeriesItem>> lListSeriesItems = GetSeriesItems();
            Random rColor = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            int colorIndex = 0;
            Color[] paletteColors = GetColors(PropChartSelectedPaletteName);
            foreach (KeyValuePair<string, List<SeriesItem>> list in lListSeriesItems)
            {
                sBar = new BarSeries();
                sBar.Name = list.Key;
                sBar.Items.AddRange(list.Value);
                Color fillColor;
                if (colorIndex > 4)
                {
                    KnownColor randomColorName = names[rColor.Next(names.Length)];
                    fillColor = Color.FromKnownColor(randomColorName);
                }
                else
                {
                    fillColor = paletteColors[colorIndex];
                    colorIndex++;
                }
                sBar.Appearance.FillStyle.BackgroundColor = fillColor;

                if (PropYaxisFormat == "Currency")
                {
                    sBar.LabelsAppearance.DataFormatString = "{0:c}";
                    sBar.TooltipsAppearance.DataFormatString = sBar.Name + " = {0:c}";
                }
                else if (PropYaxisFormat == "Percentage")
                {
                    sBar.LabelsAppearance.DataFormatString = "{0:p}";
                    sBar.TooltipsAppearance.DataFormatString = sBar.Name + " = {0:p}";
                }

                if (MainChartType.ToString().Contains("_Stacked") || MainChartType.ToString().Contains("_100Percent"))
                {
                    sBar.Stacked = true;
                    sBar.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.BarColumnLabelsPosition.Center;
                }


                _radChart.PlotArea.Series.Add(sBar);
            }
        }

        private void BuildColumnSeries()
        {
            ColumnSeries sCol;
            Dictionary<string, List<SeriesItem>> lListSeriesItems = GetSeriesItems();
            Random rColor = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            int colorIndex = 0;
            Color[] paletteColors = GetColors(PropChartSelectedPaletteName);
            foreach (KeyValuePair<string, List<SeriesItem>> list in lListSeriesItems)
            {
                sCol = new ColumnSeries();
                sCol.Name = list.Key;
                sCol.Items.AddRange(list.Value);
                Color fillColor;
                if (colorIndex > 4)
                {
                    KnownColor randomColorName = names[rColor.Next(names.Length)];
                    fillColor = Color.FromKnownColor(randomColorName);
                }
                else
                {
                    fillColor = paletteColors[colorIndex];
                    colorIndex++;
                }

                sCol.Appearance.FillStyle.BackgroundColor = fillColor;


                if (PropYaxisFormat == "Currency")
                {
                    sCol.LabelsAppearance.DataFormatString = "{0:c}";
                    sCol.TooltipsAppearance.DataFormatString = sCol.Name + " = {0:c}";
                }
                else if (PropYaxisFormat == "Percentage")
                {
                    sCol.LabelsAppearance.DataFormatString = "{0:p}";
                    sCol.TooltipsAppearance.DataFormatString = sCol.Name + " = {0:p}";
                }

                if (MainChartType.ToString().Contains("_Stacked") || MainChartType.ToString().Contains("_100Percent"))
                {
                    sCol.Stacked = true;
                    sCol.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.BarColumnLabelsPosition.InsideEnd;
                }

                _radChart.PlotArea.Series.Add(sCol);
            }
        }

        private void BuildLineSeries()
        {
            LineSeries sLine;
            Dictionary<string, List<SeriesItem>> lListSeriesItems = GetSeriesItems();
            Random rColor = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            int colorIndex = 0;
            Color[] paletteColors = GetColors(PropChartSelectedPaletteName);
            foreach (KeyValuePair<string, List<SeriesItem>> list in lListSeriesItems)
            {
                sLine = new LineSeries();
                sLine.Name = list.Key;
                sLine.Items.AddRange(list.Value);
                Color fillColor;
                if (colorIndex > 4)
                {
                    KnownColor randomColorName = names[rColor.Next(names.Length)];
                    fillColor = Color.FromKnownColor(randomColorName);
                }
                else
                {
                    fillColor = paletteColors[colorIndex];
                    colorIndex++;
                }

                sLine.Appearance.FillStyle.BackgroundColor = fillColor;

                if (PropYaxisFormat == "Currency")
                {
                    sLine.LabelsAppearance.DataFormatString = "{0:c}";
                    sLine.TooltipsAppearance.DataFormatString = sLine.Name + " = {0:c}";
                }
                else if (PropYaxisFormat == "Percentage")
                {
                    sLine.LabelsAppearance.DataFormatString = "{0:p}";
                    sLine.TooltipsAppearance.DataFormatString = sLine.Name + " = {0:p}";
                }


                _radChart.PlotArea.Series.Add(sLine);
            }
        }

        private void BuildPieSeries()
        {
            PieSeries sPie;
            Dictionary<string, List<SeriesItem>> lListSeriesItems = GetSeriesItems();
            foreach (KeyValuePair<string, List<SeriesItem>> list in lListSeriesItems)
            {
                sPie = new PieSeries();
                sPie.Name = list.Key;
                sPie.Items.AddRange(list.Value);

                if (PropYaxisFormat == "Currency")
                {
                    sPie.LabelsAppearance.DataFormatString = "{0:c}";
                    sPie.TooltipsAppearance.DataFormatString = sPie.Name + " = {0:c}";
                }
                else if (PropYaxisFormat == "Percentage")
                {
                    sPie.LabelsAppearance.DataFormatString = "{0:p}";
                    sPie.TooltipsAppearance.DataFormatString = sPie.Name + " = {0:c}";
                }

                _radChart.PlotArea.Series.Add(sPie);
            }
        }

        private void BuildScatterSeries()
        {
            ScatterSeries sScatter;
            Dictionary<string, List<SeriesItem>> lListSeriesItems = GetSeriesItems();
            Random rColor = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            foreach (KeyValuePair<string, List<SeriesItem>> list in lListSeriesItems)
            {
                sScatter = new ScatterSeries();
                sScatter.Name = list.Key;
                sScatter.Items.AddRange(list.Value);
                KnownColor randomColorName = names[rColor.Next(names.Length)];
                Color randomColor = Color.FromKnownColor(randomColorName);
                sScatter.Appearance.FillStyle.BackgroundColor = randomColor;
                _radChart.PlotArea.Series.Add(sScatter);
            }
        }

        private void BuildScatterLineSeries()
        {
            ScatterLineSeries sScatterLine;
            Dictionary<string, List<SeriesItem>> lListSeriesItems = GetSeriesItems();
            Random rColor = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            foreach (KeyValuePair<string, List<SeriesItem>> list in lListSeriesItems)
            {
                sScatterLine = new ScatterLineSeries();
                sScatterLine.Name = list.Key;
                sScatterLine.Items.AddRange(list.Value);
                KnownColor randomColorName = names[rColor.Next(names.Length)];
                Color randomColor = Color.FromKnownColor(randomColorName);
                sScatterLine.Appearance.FillStyle.BackgroundColor = randomColor;
                _radChart.PlotArea.Series.Add(sScatterLine);
            }
        }

        private void BuildBubbleSeries()
        {
            BubbleSeries sBubble;
            Dictionary<string, List<SeriesItem>> lListSeriesItems = GetSeriesItems();
            foreach (KeyValuePair<string, List<SeriesItem>> list in lListSeriesItems)
            {
                sBubble = new BubbleSeries();
                sBubble.Name = list.Key;
                sBubble.Items.AddRange(list.Value);
                if (!string.IsNullOrEmpty(PropYaxisFormat))
                {
                    switch (PropYaxisFormat)
                    {
                        case "Currency":
                            sBubble.TooltipsAppearance.DataFormatString = PropChartZaxisFieldLabel + " = {0:c} <br/>" + PropChartXaxisFieldLabel + " = {1:c} <br/>" + PropChartYaxisFieldLabel + " = {2:c} <br/>Title = {3}";
                            break;
                        case "Percentage":
                            sBubble.TooltipsAppearance.DataFormatString = PropChartZaxisFieldLabel + " = {0:p} <br/>" + PropChartXaxisFieldLabel + " = {1:p} <br/>" + PropChartYaxisFieldLabel + " = {2:p} <br/>Title = {3}";
                            break;
                        default:
                            sBubble.TooltipsAppearance.DataFormatString = PropChartZaxisFieldLabel + " = {0} <br/>" + PropChartXaxisFieldLabel + " = {1} <br/>" + PropChartYaxisFieldLabel + " = {2} <br/>Title = {3}";
                            break;
                    }
                }

                _radChart.PlotArea.Series.Add(sBubble);
            }
        }

        private void BuildDonutSeries()
        {
            DonutSeries sDonut;
            Dictionary<string, List<SeriesItem>> lListSeriesItems = GetSeriesItems();
            foreach (KeyValuePair<string, List<SeriesItem>> list in lListSeriesItems)
            {
                sDonut = new DonutSeries();
                sDonut.Name = list.Key;
                sDonut.Items.AddRange(list.Value);
                if (!string.IsNullOrEmpty(PropYaxisFormat))
                {
                    switch (PropYaxisFormat)
                    {
                        case "Currency":
                            sDonut.LabelsAppearance.DataFormatString = "{0:c}";

                            sDonut.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieLabelsPosition.Column;
                            sDonut.TooltipsAppearance.DataFormatString = sDonut.Name + " = {0:c}";
                            break;
                        case "Percentage":
                            sDonut.LabelsAppearance.DataFormatString = "{0:p}";
                            sDonut.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieLabelsPosition.Column;
                            sDonut.TooltipsAppearance.DataFormatString = sDonut.Name + " = {0:p}";
                            break;
                        default:
                            sDonut.LabelsAppearance.DataFormatString = "{0}";
                            sDonut.LabelsAppearance.Position = Telerik.Web.UI.HtmlChart.PieLabelsPosition.Column;
                            sDonut.TooltipsAppearance.DataFormatString = sDonut.Name + " = {0}";
                            break;
                    }
                }
                _radChart.PlotArea.Series.Add(sDonut);
            }
        }

        private Dictionary<string, List<SeriesItem>> GetSeriesItems()
        {
            Dictionary<string, List<SeriesItem>> result = new Dictionary<string, List<SeriesItem>>();
            if (string.IsNullOrEmpty(PropChartSelectedListTitle) || string.IsNullOrEmpty(PropChartSelectedViewTitle))
            {
                return result;
            }
            List<SeriesItem> lsiTemp = new List<SeriesItem>();
            DataTable tbListData = new DataTable();
            string sQuery, sOrderBy = string.Empty;
            SPWeb w = SPContext.Current.Web;
            SPList l = w.Lists.TryGetList(PropChartSelectedListTitle);
            sQuery = ReportingData.GetReportQuery(w, l, l.Views[PropChartSelectedViewTitle].Query, out sOrderBy);
            tbListData = ReportingData.GetReportingData(w, l.Title, false, sQuery, sOrderBy);

            string sChartTypeVal = Enum.GetName(typeof(ChartType), PropChartType);
            string sAggType = PropChartAggregationType;
            // SINGLE SERIES
            if (sChartTypeVal == "Area" || sChartTypeVal == "Bar" || sChartTypeVal == "Column" || sChartTypeVal == "Line")
            {
                if (sAggType == "Count")
                {
                    result.Clear();
                    result = GetCountDataForSingleSeries(tbListData, PropChartXaxisField);
                }
                else if (sAggType == "Sum")
                {
                    result.Clear();
                    result = GetSumDataForMultiSeries(tbListData, PropChartXaxisField, PropChartYaxisField);
                }
                else if (sAggType == "Avg")
                {
                    result.Clear();
                    result = GetAvgDataForMultiSeries(tbListData, PropChartXaxisField, PropChartYaxisField);
                }

            }
            // MULTI SERIES
            else if (sChartTypeVal.Contains("_Clustered") || sChartTypeVal.Contains("_Stacked"))
            {
                if (sAggType == "Count")
                {
                    result.Clear();
                    result = GetCountDataForClusteredGraph(tbListData, PropChartXaxisField, PropChartYaxisField);
                }
                else if (sAggType == "Sum")
                {
                    result.Clear();
                    result = GetSumDataForMultiSeries(tbListData, PropChartXaxisField, PropChartYaxisField);
                }
                else if (sAggType == "Avg")
                {
                    result.Clear();
                    result = GetAvgDataForMultiSeries(tbListData, PropChartXaxisField, PropChartYaxisField);
                }
            }
            // MULTI SERIES 100 PERCENT
            else if (sChartTypeVal.Contains("_100Percent"))
            {
                if (sAggType == "Count")
                {
                    result.Clear();
                    result = GetCountDataForClusteredGraphInPercentage(tbListData, PropChartXaxisField, PropChartYaxisField);
                }
                else if (sAggType == "Sum")
                {
                    result.Clear();
                    result = GetSumDataForMultiSeriesInPercentage(tbListData, PropChartXaxisField, PropChartYaxisField);
                }
                else if (sAggType == "Avg")
                {
                    result.Clear();
                    result = GetAvgDataForMultiSeriesInPercentage(tbListData, PropChartXaxisField, PropChartYaxisField);
                }
            }
            else if (sChartTypeVal.Contains("Pie") || sChartTypeVal.Contains("Donut"))
            {
                // NO Y VALUE
                if (sAggType == "Count")
                {
                    result.Clear();
                    result = GetCountDataForPieSeries(tbListData, PropChartXaxisField);
                }
                else if (sAggType == "Sum")
                {
                    result.Clear();
                    result = GetSumDataForPieSeries(tbListData, PropChartXaxisField, PropChartYaxisField);
                }
                else if (sAggType == "Avg")
                {
                    result.Clear();
                    result = GetAvgDataForPieSeries(tbListData, PropChartXaxisField, PropChartYaxisField);
                }
            }
            // FOR SCATTER AND SCATTER LINE
            //else if (sChartTypeVal.Contains("Scatter"))
            //{
            //    result.Clear();
            //    result = GetDataForScatterSeries(tbListData, PropChartXaxisField, PropChartYaxisField);
            //}
            else if (sChartTypeVal.Contains("Bubble"))
            {
                result.Clear();
                result = GetDataForBubbleSeries(tbListData, PropChartXaxisField, PropChartYaxisField, PropChartZaxisField, PropBubbleChartGroupBy);
            }

            return result;
        }


        #region HELPER METHODS (GETTING SERIES ITEMS)

        private Dictionary<string, List<SeriesItem>> GetDataForBubbleSeries(DataTable dtRaw, string category, string series, string valueFld, string groupBy)
        {
            Dictionary<string, List<SeriesItem>> container = new Dictionary<string, List<SeriesItem>>();
            List<SeriesItem> result = new List<SeriesItem>();
            XAxisLabels.Clear();

            if (!string.IsNullOrEmpty(series) && valueFld != "-- None Selected --" && !string.IsNullOrEmpty(groupBy))
            {
                List<string> distinctGrps = (from DataRow r in dtRaw.AsEnumerable() where r[groupBy] != DBNull.Value select r[groupBy].ToString().Trim()).Distinct().ToList();

                foreach (string grp in distinctGrps)
                {
                    result = new List<SeriesItem>();
                    var tempGrp = (from DataRow r in dtRaw.AsEnumerable()
                                   where r[series] != DBNull.Value && r[valueFld] != DBNull.Value && r[groupBy] != DBNull.Value && r[groupBy].ToString().Trim() == grp
                                   select new[] { r[category], r[series], r[valueFld], r["Title"] }).ToArray();

                    foreach (object[] oTemp in tempGrp)
                    {
                        SeriesItem si = new SeriesItem(
                            decimal.Round(decimal.Parse(oTemp[0].ToString()), 2),
                            decimal.Round(decimal.Parse(oTemp[1].ToString()), 2)) { SizeValue = decimal.Round(decimal.Parse(oTemp[2].ToString()), 2) };
                        si.TooltipValue = oTemp[3].ToString();
                        result.Add(si);
                    }
                    container.Add(GetFldDispNameFromIntName(grp), result);
                }
            }

            return container;
        }

        //private List<SeriesItem> GetDataForScatterSeries(DataTable dtRaw, string category, string series)
        //{
        //    List<SeriesItem> result = new List<SeriesItem>();
        //    var rx = (from DataRow r in dtRaw.AsEnumerable()
        //              where r[category] != DBNull.Value && r[series] != DBNull.Value
        //              select new[] { r[category], r[series] }).ToArray();
        //    foreach (object[] o in rx)
        //    {
        //        result.Add(new SeriesItem(decimal.Parse(o[0].ToString()), decimal.Parse(o[1].ToString())));
        //    }
        //    return result;
        //}

        private Dictionary<string, List<SeriesItem>> GetCountDataForPieSeries(DataTable dtRaw, string category)
        {
            Dictionary<string, List<SeriesItem>> container = new Dictionary<string, List<SeriesItem>>();
            List<SeriesItem> result = new List<SeriesItem>();
            category = TranslateIfLookup(category);
            var rx = (from DataRow r in dtRaw.AsEnumerable()
                      group r by r[category] into gr
                      select new[] { gr.Key, gr.Count() }).ToArray();

            foreach (object[] o in rx)
            {
                SeriesItem st = new SeriesItem(decimal.Round(decimal.Parse(o[1].ToString()), 2));
                st.Name = GetFldDispNameFromIntName(o[0].ToString());
                result.Add(st);
            }
            container.Add(GetFldDispNameFromIntName(category), result);
            return container;
        }

        private Dictionary<string, List<SeriesItem>> GetSumDataForPieSeries(DataTable dtRaw, string category, string series)
        {
            Dictionary<string, List<SeriesItem>> container = new Dictionary<string, List<SeriesItem>>();
            List<SeriesItem> result = new List<SeriesItem>();
            category = TranslateIfLookup(category);
            series = TranslateIfLookup(series);
            var rx = (from DataRow r in dtRaw.AsEnumerable()
                      where r[series] != DBNull.Value
                      group r by r[category] into gr
                      select new[] { gr.Key, gr.Sum(x => int.Parse(x[series].ToString())) }).ToArray();

            foreach (object[] o in rx)
            {
                SeriesItem st = new SeriesItem(decimal.Round(decimal.Parse(o[1].ToString()), 2));
                st.Name = GetFldDispNameFromIntName(o[0].ToString());
                result.Add(st);
            }
            container.Add(GetFldDispNameFromIntName(series), result);

            return container;
        }

        private Dictionary<string, List<SeriesItem>> GetAvgDataForPieSeries(DataTable dtRaw, string category, string series)
        {
            Dictionary<string, List<SeriesItem>> container = new Dictionary<string, List<SeriesItem>>();
            List<SeriesItem> result = new List<SeriesItem>();
            category = TranslateIfLookup(category);
            var rx = (from DataRow r in dtRaw.AsEnumerable()
                      where r[series] != DBNull.Value
                      group r by r[category] into gr
                      select new[] { gr.Key, gr.Average(x => int.Parse(x[series].ToString())) }).ToArray();

            foreach (object[] o in rx)
            {
                SeriesItem st = new SeriesItem(decimal.Round(decimal.Parse(o[1].ToString()), 2));
                st.Name = GetFldDispNameFromIntName(o[0].ToString());
                result.Add(st);
            }

            container.Add(GetFldDispNameFromIntName(series), result);
            return container;
        }

        /// <summary>
        /// Gets series items that represent the count for a single series. (single y value)
        /// </summary>
        /// <param name="dtRaw">A datatable that represents a specific view for a list.</param>
        /// <param name="category">A category by which to group datarows on.</param>
        /// <returns></returns>
        private Dictionary<string, List<SeriesItem>> GetCountDataForSingleSeries(DataTable dtRaw, string category)
        {
            Dictionary<string, List<SeriesItem>> result = new Dictionary<string, List<SeriesItem>>();
            List<SeriesItem> lsTemp = new List<SeriesItem>();
            category = TranslateIfLookup(category);
            List<string> distinctCats = (from r in dtRaw.AsEnumerable() where r[category] != DBNull.Value select r[category].ToString().Trim()).Distinct().ToList();
            // add x axis labels
            XAxisLabels.Clear();
            foreach (string cat in distinctCats)
            {
                XAxisLabels.Add(GetFldDispNameFromIntName(cat));
            }

            var rx = (from DataRow r in dtRaw.AsEnumerable()
                      group r by r[category] into gr
                      select new[] { gr.Key, gr.Count() }).ToArray();

            foreach (object[] o in rx)
            {
                lsTemp.Add(new SeriesItem(decimal.Round(decimal.Parse(o[1].ToString()), 2)));
            }

            result.Add(GetFldDispNameFromIntName(category), lsTemp);
            return result;
        }



        /// <summary>
        /// Gets series items that represent the count for multiple series. (multiple y value)
        /// </summary>
        /// <param name="dtRaw">A datatable that represents a specific view for a list.</param>
        /// <param name="category">A category by which to group datarows on.</param>
        /// <param name="rawMultiSeries">A pipe delimited string that represents the different series by which to count on.</param>
        /// <returns></returns>
        private Dictionary<string, List<SeriesItem>> GetCountDataForClusteredGraph(DataTable dtRaw, string category, string series)
        {
            Dictionary<string, List<SeriesItem>> listContainer = new Dictionary<string, List<SeriesItem>>();
            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(series))
            {
                return listContainer;
            }
            category = TranslateIfLookup(category);
            series = TranslateIfLookup(series);
            List<SeriesItem> lSeries;
            List<string> distinctCats = (from r in dtRaw.AsEnumerable() where r[category] != DBNull.Value select r[category].ToString().Trim()).Distinct().ToList();
            List<string> distinctSeriesVals = (from r in dtRaw.AsEnumerable() where r[series] != DBNull.Value select r[series].ToString().Trim()).Distinct().ToList();
            // add x axis labels
            XAxisLabels.Clear();
            foreach (string cat in distinctCats)
            {
                XAxisLabels.Add(GetFldDispNameFromIntName(cat));
            }

            string sVal = string.Empty;
            foreach (string seriesVal in distinctSeriesVals)
            {
                lSeries = new List<SeriesItem>();
                foreach (string cat in distinctCats)
                {
                    string rowCount = (from r in dtRaw.AsEnumerable()
                                       where r[category] != DBNull.Value && r[series] != DBNull.Value
                                       && r[category].ToString().Trim() == cat && r[series].ToString().Trim() == seriesVal
                                       select r).ToList().Count().ToString();
                    lSeries.Add(new SeriesItem(decimal.Round(decimal.Parse(rowCount), 2)));
                }
                listContainer.Add(GetFldDispNameFromIntName(seriesVal), lSeries);
            }

            return listContainer;
        }

        /// <summary>
        /// Gets series items that represent the count for multiple series. (multiple y value)
        /// </summary>
        /// <param name="dtRaw">A datatable that represents a specific view for a list.</param>
        /// <param name="category">A category by which to group datarows on.</param>
        /// <param name="rawMultiSeries">A pipe delimited string that represents the different series by which to count on.</param>
        /// <returns></returns>
        private Dictionary<string, List<SeriesItem>> GetCountDataForClusteredGraphInPercentage(DataTable dtRaw, string category, string series)
        {
            Dictionary<string, List<SeriesItem>> listContainer = new Dictionary<string, List<SeriesItem>>();
            if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(series))
            {
                return listContainer;
            }
            category = TranslateIfLookup(category);
            series = TranslateIfLookup(series);
            List<SeriesItem> lSeries;
            List<string> distinctCats = (from r in dtRaw.AsEnumerable() where r[category] != DBNull.Value select r[category].ToString().Trim()).Distinct().ToList();
            List<string> distinctSeriesVals = (from r in dtRaw.AsEnumerable() where r[series] != DBNull.Value select r[series].ToString().Trim()).Distinct().ToList();
            // add x axis labels
            XAxisLabels.Clear();
            foreach (string cat in distinctCats)
            {
                XAxisLabels.Add(GetFldDispNameFromIntName(cat));
            }

            DataTable tbCatAndSeriesTotal = new DataTable();
            tbCatAndSeriesTotal.Columns.Add(new DataColumn("Category", typeof(string)));
            tbCatAndSeriesTotal.Columns.Add(new DataColumn("CategoryTotal", typeof(decimal)));

            foreach (string cat in distinctCats)
            {
                decimal catTotal = 0;
                foreach (string s in distinctSeriesVals)
                {
                    int rx = (from DataRow r in dtRaw.AsEnumerable()
                              where r[category] != DBNull.Value && r[series] != DBNull.Value && r[category].ToString().Trim() == cat && r[series].ToString().Trim() == s
                              select r).Count();

                    catTotal += rx;
                }
                tbCatAndSeriesTotal.Rows.Add(cat, catTotal);
            }

            string sVal = string.Empty;
            foreach (string seriesVal in distinctSeriesVals)
            {
                lSeries = new List<SeriesItem>();
                foreach (string cat in distinctCats)
                {
                    decimal dRowCount = (from r in dtRaw.AsEnumerable()
                                         where r[category] != DBNull.Value && r[series] != DBNull.Value && r[category].ToString() == cat && r[series].ToString() == seriesVal
                                         select r).ToList().Count();
                    decimal dCatTotal = decimal.Parse(tbCatAndSeriesTotal.Select("Category = '" + cat + "'").First()["CategoryTotal"].ToString());
                    lSeries.Add(
                        new SeriesItem(
                            decimal.Round(dRowCount / dCatTotal, 2)
                            ));
                }
                listContainer.Add(GetFldDispNameFromIntName(seriesVal), lSeries);
            }

            return listContainer;
        }

        /// <summary>
        /// Gets series items that represent the sum for multiple series. (multiple y value)
        /// </summary>
        /// <param name="dtRaw">A datatable that represents a specific view for a list.</param>
        /// <param name="category">A category by which to group datarows on.</param>
        /// <param name="rawMultiSeries">A pipe delimited string that represents the different series, which are the columns we sum within each category.</param>
        /// <returns></returns>
        private Dictionary<string, List<SeriesItem>> GetSumDataForMultiSeries(DataTable dtRaw, string category, string rawMultiSeries)
        {
            Dictionary<string, List<SeriesItem>> listContainer = new Dictionary<string, List<SeriesItem>>();
            List<SeriesItem> result;
            category = TranslateIfLookup(category);
            // add x axis labels
            List<string> distinctCats = (from r in dtRaw.AsEnumerable() where r[category] != DBNull.Value select r[category].ToString().Trim()).Distinct().ToList();
            XAxisLabels.Clear();
            foreach (string cat in distinctCats)
            {
                XAxisLabels.Add(GetFldDispNameFromIntName(cat));
            }
            YAxisLabel = "Sum";
            string[] yFields = rawMultiSeries.Split('|');

            foreach (string series in yFields)
            {
                if (!string.IsNullOrEmpty(series))
                {
                    result = new List<SeriesItem>();
                    var rx = (from DataRow r in dtRaw.AsEnumerable()
                              where r[series] != DBNull.Value
                              group r by r[category] into gr
                              select new[] { gr.Key, gr.Sum(x => int.Parse(x[series].ToString())) }).ToArray();
                    foreach (object[] o in rx)
                    {
                        result.Add(
                            new SeriesItem(
                                decimal.Round(decimal.Parse(o[1].ToString()), 2)
                                ));
                    }

                    listContainer.Add(GetFldDispNameFromIntName(series), result);
                }
            }

            return listContainer;
        }

        /// <summary>
        /// Gets series items that represent the sum for multiple series. (multiple y value)
        /// </summary>
        /// <param name="dtRaw">A datatable that represents a specific view for a list.</param>
        /// <param name="category">A category by which to group datarows on.</param>
        /// <param name="rawMultiSeries">A pipe delimited string that represents the different series, which are the columns we sum within each category.</param>
        /// <returns></returns>
        private Dictionary<string, List<SeriesItem>> GetSumDataForMultiSeriesInPercentage(DataTable dtRaw, string category, string rawMultiSeries)
        {
            Dictionary<string, List<SeriesItem>> listContainer = new Dictionary<string, List<SeriesItem>>();
            List<SeriesItem> result;
            category = TranslateIfLookup(category);
            // add x axis labels
            List<string> distinctCats = (from r in dtRaw.AsEnumerable() where r[category] != DBNull.Value select r[category].ToString().Trim()).Distinct().ToList();
            XAxisLabels.Clear();
            foreach (string cat in distinctCats)
            {
                XAxisLabels.Add(GetFldDispNameFromIntName(cat));
            }
            YAxisLabel = "Sum";
            string[] yFields = rawMultiSeries.Split('|');

            DataTable tbCatAndSeriesTotal = new DataTable();
            tbCatAndSeriesTotal.Columns.Add(new DataColumn("Category", typeof(string)));
            tbCatAndSeriesTotal.Columns.Add(new DataColumn("CategoryTotal", typeof(decimal)));

            foreach (string cat in distinctCats)
            {
                decimal catTotal = 0;
                foreach (string series in yFields)
                {
                    if (!string.IsNullOrEmpty(series))
                    {
                        var rx = (from DataRow r in dtRaw.AsEnumerable()
                                  where r[category] != DBNull.Value && r[series] != DBNull.Value && r[category].ToString().Trim() == cat
                                  group r by r[category] into gr
                                  select new[] { gr.Sum(x => System.Math.Abs(decimal.Parse(x[series].ToString()))) }).First();

                        catTotal += rx[0];
                    }
                }

                tbCatAndSeriesTotal.Rows.Add(cat, catTotal);
            }

            foreach (string series in yFields)
            {
                if (!string.IsNullOrEmpty(series))
                {
                    result = new List<SeriesItem>();
                    var rx = (from DataRow r in dtRaw.AsEnumerable()
                              where r[category] != DBNull.Value && r[series] != DBNull.Value
                              group r by r[category] into gr
                              select new[] { gr.Key, gr.Sum(x => decimal.Parse(x[series].ToString())) }).ToArray();

                    // foreach total
                    foreach (object[] r in rx)
                    {
                        decimal dCatTotal = decimal.Parse(tbCatAndSeriesTotal.Select("Category = '" + r[0] + "'").First()["CategoryTotal"].ToString());
                        // find the ratio of individual series value to total series value
                        decimal dPercentage = (decimal.Parse(r[1].ToString()) / dCatTotal);
                        result.Add(new SeriesItem(decimal.Round(dPercentage, 2)));
                    }

                    listContainer.Add(GetFldDispNameFromIntName(series), result);
                }
            }

            return listContainer;
        }

        /// <summary>
        /// Gets series items that represent the average for multiple series. (multiple y value)
        /// </summary>
        /// <param name="dtRaw">A datatable that represents a specific view for a list.</param>
        /// <param name="category">A category by which to group datarows on.</param>
        /// <param name="rawMultiSeries">A pipe delimited string that represents the different series, which are the columns we average within each category.</param>
        /// <returns></returns>
        private Dictionary<string, List<SeriesItem>> GetAvgDataForMultiSeries(DataTable dtRaw, string category, string rawMultiSeries)
        {
            Dictionary<string, List<SeriesItem>> listContainer = new Dictionary<string, List<SeriesItem>>();
            List<SeriesItem> result;
            category = TranslateIfLookup(category);
            // add x axis labels
            List<string> distinctCats = (from r in dtRaw.AsEnumerable() where r[category] != DBNull.Value select r[category].ToString().Trim()).Distinct().ToList();
            XAxisLabels.Clear();
            foreach (string cat in distinctCats)
            {
                XAxisLabels.Add(GetFldDispNameFromIntName(cat));
            }
            YAxisLabel = "Average";
            string[] yFields = rawMultiSeries.Split('|');
            foreach (string series in yFields)
            {
                if (!string.IsNullOrEmpty(series))
                {
                    result = new List<SeriesItem>();
                    var rx = (from DataRow r in dtRaw.AsEnumerable()
                              where r[series] != DBNull.Value
                              group r by r[category] into gr
                              select new[] { gr.Key, gr.Average(x => int.Parse(x[series].ToString())) }).ToArray();
                    foreach (object[] o in rx)
                    {
                        SeriesItem it = new SeriesItem(decimal.Round(decimal.Parse(o[1].ToString()), 2));
                        result.Add(it);
                    }

                    listContainer.Add(GetFldDispNameFromIntName(series), result);
                }
            }

            return listContainer;
        }

        /// <summary>
        /// Gets series items that represent the average for multiple series. (multiple y value)
        /// </summary>
        /// <param name="dtRaw">A datatable that represents a specific view for a list.</param>
        /// <param name="category">A category by which to group datarows on.</param>
        /// <param name="rawMultiSeries">A pipe delimited string that represents the different series, which are the columns we average within each category.</param>
        /// <returns></returns>
        private Dictionary<string, List<SeriesItem>> GetAvgDataForMultiSeriesInPercentage(DataTable dtRaw, string category, string rawMultiSeries)
        {
            Dictionary<string, List<SeriesItem>> listContainer = new Dictionary<string, List<SeriesItem>>();
            List<SeriesItem> result;
            category = TranslateIfLookup(category);
            // add x axis labels
            List<string> distinctCats = (from r in dtRaw.AsEnumerable() where r[category] != DBNull.Value select r[category].ToString().Trim()).Distinct().ToList();
            XAxisLabels.Clear();
            foreach (string cat in distinctCats)
            {
                XAxisLabels.Add(GetFldDispNameFromIntName(cat));
            }
            YAxisLabel = "Average";
            string[] yFields = rawMultiSeries.Split('|');

            DataTable tbCatAndTotalOfAvg = new DataTable();
            tbCatAndTotalOfAvg.Columns.Add(new DataColumn("Category", typeof(string)));
            tbCatAndTotalOfAvg.Columns.Add(new DataColumn("CategoryTotalOfAverage", typeof(decimal)));

            foreach (string cat in distinctCats)
            {
                decimal catTotalOfAverage = 0;
                foreach (string series in yFields)
                {
                    if (!string.IsNullOrEmpty(series))
                    {
                        var rx = (from DataRow r in dtRaw.AsEnumerable()
                                  where r[category] != DBNull.Value && r[series] != DBNull.Value && r[category].ToString().Trim() == cat
                                  group r by r[category] into gr
                                  select new[] { gr.Average(x => System.Math.Abs(decimal.Parse(x[series].ToString()))) }).First();

                        catTotalOfAverage += rx[0];
                    }
                }

                tbCatAndTotalOfAvg.Rows.Add(cat, catTotalOfAverage);
            }

            foreach (string series in yFields)
            {
                if (!string.IsNullOrEmpty(series))
                {
                    result = new List<SeriesItem>();
                    // get average for each series
                    var rx = (from DataRow r in dtRaw.AsEnumerable()
                              where r[category] != DBNull.Value && r[series] != DBNull.Value
                              group r by r[category] into gr
                              select new[] { gr.Key, gr.Average(x => int.Parse(x[series].ToString())) }).ToArray();

                    foreach (object[] r in rx)
                    {
                        decimal dCatTotalAvg = decimal.Parse(tbCatAndTotalOfAvg.Select("Category = '" + r[0] + "'").First()["CategoryTotalOfAverage"].ToString());
                        // find the ratio of individual series value to total series value
                        decimal dPercentage = (decimal.Parse(r[1].ToString()) / dCatTotalAvg);
                        result.Add(new SeriesItem(decimal.Round(dPercentage, 2)));
                    }

                    listContainer.Add(GetFldDispNameFromIntName(series), result);
                }
            }

            return listContainer;
        }
        #endregion

        private DataTable GetSelectedListData(string listName)
        {
            DataTable r = new DataTable();
            SPWeb spWeb = SPContext.Current.Web;
            SPList list = spWeb.Lists.TryGetList(listName);
            if (!string.IsNullOrEmpty(PropChartSelectedListTitle))
            {
                SPView view = null;
                try
                {
                    view = list.Views[PropChartSelectedViewTitle];
                }
                catch { }

                if (view != null)
                {
                    string sOrderBy = string.Empty;
                    string query = ReportingData.GetReportQuery(spWeb, list, view.Query, out sOrderBy);
                    r = ReportingData.GetReportingData(spWeb, listName, true, query, sOrderBy);
                }
            }


            return r;
        }

        public override ToolPart[] GetToolParts()
        {
            WebPartToolPart = new ToolPart[3];
            WebPartToolPart[0] = new ReportingChartToolPart();
            WebPartToolPart[1] = new WebPartToolPart();
            WebPartToolPart[2] = new CustomPropertyToolPart();

            return WebPartToolPart;
        }

        public void RebuildControlTree()
        {
            Controls.Clear();
            SetChartWidthAndHeight();
            CreateChildControls();
        }

        private void SetChartWidthAndHeight()
        {
            if (!string.IsNullOrEmpty(Width) && !string.IsNullOrEmpty(Height))
            {
                _radChart.Width = (int)(new Unit(Width).Value);
                _radChart.Height = (int)(new Unit(Height).Value);
            }
        }

        public void SetYFieldsValues(string[] yFields)
        {
            PropChartYaxisField = (yFields == null) ? "" : string.Join(Separator.ToString(), yFields);
        }

        public void SetYFieldsLabels(string[] yFields)
        {
            PropChartYaxisFieldLabel = (yFields == null) ? "" : string.Join(", ", yFields);
        }

        public string[] GetYFieldsValues()
        {
            return !string.IsNullOrEmpty(PropChartYaxisField) ? PropChartYaxisField.Split(Separator) : new string[0];
        }

        public string GetYFieldsLabel()
        {
            return !string.IsNullOrEmpty(PropChartYaxisFieldLabel) ? string.Join(",", PropChartYaxisFieldLabel.Split(Separator)) : string.Empty;
        }

        private bool IsBubbleChart()
        {
            bool bIsBubble = false;

            if (!string.IsNullOrEmpty(PropChartType.ToString()))
            {
                bIsBubble = PropChartType.ToString().Trim().ToLower() == "bubble";
            }

            return bIsBubble;
        }

        private string GetFldDispNameFromIntName(string internalName)
        {
            string result = internalName;

            if (DictFieldIntAndDispName != null && DictFieldIntAndDispName.Count > 0)
            {
                try
                {
                    result = DictFieldIntAndDispName[internalName];
                }
                catch { }
            }

            return result;
        }

        private Dictionary<string, string> GetFldsIntAndDispNameDictionary(string sListName)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            DataTable tCols = GetListColumns(sListName);
            foreach (DataRow r in tCols.Rows)
            {
                if (!result.ContainsKey(r["InternalName"].ToString()))
                {
                    result.Add(r["InternalName"].ToString(), r["DisplayName"].ToString());
                }
            }

            return result;
        }

        private DataTable GetListColumns(string listName)
        {
            DataTable result = new DataTable();
            if (!string.IsNullOrEmpty(listName))
            {
                QueryExecutor qExec = new QueryExecutor(SPContext.Current.Web);
                string sql = "SELECT * FROM RPTList rl JOIN RPTColumn rc ON rl.RPTListId = rc.RPTListId WHERE ListName = '" + listName + "'";
                result = qExec.ExecuteReportingDBQuery(sql, new Dictionary<string, object>());
            }
            return result;
        }

        private bool IsLookupCol(string intName)
        {
            bool isLookup = false;
            DataTable rawCols = GetListColumns(PropChartSelectedListTitle);
            List<DataRow> r = (from DataRow row in rawCols.Rows
                               where row["InternalName"].ToString().Trim() == intName && (row["SharePointType"].ToString().Trim() == "Lookup" || row["SharePointType"].ToString().Trim() == "User")
                               select row).ToList();

            if (r.Count > 0)
            {
                isLookup = true;
            }

            return isLookup;
        }

        private string TranslateIfLookup(string intName)
        {
            string lookupColName = intName;
            if (IsLookupCol(intName))
            {
                lookupColName += "Text";
            }

            return lookupColName;
        }

    }
}
