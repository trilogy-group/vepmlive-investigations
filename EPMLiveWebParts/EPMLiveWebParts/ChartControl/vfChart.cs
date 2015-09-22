#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Web;
using EPMLiveCore;
using EPMLiveWebParts.EpmCharting.DomainModel;
using EPMLiveWebParts.EpmCharting.Repositories;
using EPMLiveWebParts.Personalization.DomainModel;
using EPMLiveWebParts.ReportFiltering.DomainServices;
using Microsoft.SharePoint;

#endregion

namespace EPMLiveWebParts
{
    public class VfChart
    {
        public static char Separator = '|';
        private const string ChartsXapPath = "/_layouts/epmlive/SL.Visifire.Charts.xap";
        private const string VfDataPath = "/_layouts/epmlive/vfdata.aspx";

        

        private const string QTitle = "Title";
        private const string QXfield = "XField";
        private const string QXfieldLabel = "XFieldLabel";
        private const string QYfieldLabel = "YFieldLabel";
        private const string QZfieldLabel = "ZFieldLabel";
        private const string QYfields = "YFields";
        private const string QZfield = "ZField";
        private const string QBubbleChartColorField = "BubbleChartColorFieldDropDownList";
        private const string QAggrtype = "AggrType";
        private const string QRolluplists = "RollupLists";
        private const string QRollupsites = "RollupSites";
        private const string QView = "View";
        private const string QList = "List";
        private const string QChartType = "Type";
        private const string QView3D = "View3D";
        private const string QColorSet = "Palette";
        private const string QHeight = "H";
        private const string QWidth = "W";
        private const string QLegend = "Legend";
        private const string QPercentage = "Percent";
        private const string QCurrency = "Currency";
        private const string QGridlines = "Grid";
        private const string QLabels = "Labels";
        private const string QShowZeroValueData = "ZeroValues";
        private const string QShowBubbleChartInputs = "BubbleChartInputs";
        private const string QChartWebPartId = "ChartWebPartId";
        private const string QLookupField = "LookupField";
        private const string QLookupFieldList = "LookupFieldList";

        public StringBuilder TraceOutput = new StringBuilder();
        private List<VfChartSeries> _series = new List<VfChartSeries>();

        public string ChartLookupFieldList { get; set; }
        public string ChartLookupField { get; set; }

        public VfChart(HttpRequest request)
        {
            PropChartTitle = HttpUtility.UrlDecode(request[QTitle]);
            PropChartMainStyle = request[QChartType];
            PropChartXaxisField = request[QXfield];
            PropChartXaxisFieldLabel = request[QXfieldLabel];
            PropChartYaxisFieldLabel = request[QYfieldLabel];
            PropChartZaxisFieldLabel = request[QZfieldLabel];
            PropChartYaxisField = request[QYfields];
            PropChartZaxisField = request[QZfield];
            PropBubbleChartColorField = request[QBubbleChartColorField];
            PropChartAggregationType = request[QAggrtype];
            PropChartRollupLists = HttpUtility.UrlDecode(request[QRolluplists]);
            PropChartRollupSites = HttpUtility.UrlDecode(request[QRollupsites]);
            PropChartSelectedList = request[QList];
            PropChartSelectedView = request[QView];
            PropChartView3D = request[QView3D].ToUpper() == "TRUE";
            PropChartSelectedPaletteName = request[QColorSet];
            PropChartShowLegend = request[QLegend].ToUpper() == "TRUE";
            PropChartShowYaxisValuesAsPercentage = request[QPercentage].ToUpper() == "TRUE";
            PropChartShowYaxisValuesAsCurrency = request[QCurrency].ToUpper() == "TRUE";
            PropChartShowGridlines = request[QGridlines].ToUpper() == "TRUE";
            PropChartShowSeriesLabels = request[QLabels].ToUpper() == "TRUE";
            PropChartShowZeroValueData = request[QShowZeroValueData].ToUpper() == "TRUE";
            PropChartShowBubbleChartInputsInWebPart = request[QShowBubbleChartInputs].ToUpper() == "TRUE";
            PropChartWebPartId = request[QChartWebPartId];
            ChartLookupField = request[QLookupField];
            ChartLookupFieldList = request[QLookupFieldList];
        }

        protected VfChart()
        {
            PropChartTitle = "";
            PropChartMainStyle = "Column";
            PropChartXaxisField = "";
            PropChartYaxisField = "";
            PropChartZaxisField = "";
            PropBubbleChartColorField = "";
            PropChartAggregationType = "SUM";
            PropChartRollupLists = "";
            PropChartRollupSites = "";
            PropChartSelectedList = "";
            PropChartSelectedView = "";
            PropChartView3D = true;
            PropChartShowGridlines = true;
            PropChartShowSeriesLabels = true;
        }

        public List<VfChartSeries> Series
        {
            get { return _series; }
            set { _series = value; }
        }

        public string ReportFilterWebPartId { get; set; }
        public bool PropTrace { get; set; }
        public string PropChartTitle { get; set; }
        public string PropChartMainStyle { get; set; }
        public string PropChartMainStyleSafe { get { return ChartTypes.ContainsValue(PropChartMainStyle) ? PropChartMainStyle : "Column"; } }
        public int PropChartHeight { get; set; }
        public int PropChartWidth { get; set; }
        public string PropChartWebPartId { get; set; }

        private EpmChartUserSettings _chartUserSettings;
        public EpmChartUserSettings ChartUserSettings
        {
            get
            {
                if (_chartUserSettings == null)
                {
                    LoadChartUserSettings();
                }

                return _chartUserSettings;
            }
            set { _chartUserSettings = value; }
        }

        private void LoadChartUserSettings()
        {
            if (string.IsNullOrEmpty(PropChartWebPartId)) return;

            var web = SPContext.Current.Web;
            var repo = new EpmChartUserSettingsRepository(web);
            var searchCriteria = new PersonalizationSearchCriteria
            {
                WebPartId = WebPartHelper.ConvertWebPartIdToGuid(PropChartWebPartId),
                WebId = web.ID,
                SiteId = web.Site.ID,
                UserId = web.CurrentUser.ID.ToString(),
                Key = EpmChartUserSettings.Key
            };

            _chartUserSettings = repo.GetChartSettings(searchCriteria);
        }

        //TODO: These properties incorporate user settings and will be refactored as it's confusing when there are also the "Raw" versions of them being used as well.
        private string _propChartXaxisField;
        public string PropChartXaxisField
        {
            get
            {
                return ChartUserSettingsAreValid() ? ChartUserSettings.XaxisField : _propChartXaxisField;
            }

            set { _propChartXaxisField = value; }
        }

        //TODO: Yeah, I don't like this either... having two properties one "Raw" version which is used by the toolpart and then a regular version. This WILL be refactored when this chart does.
        public string PropChartXaxisFieldRaw
        {
            get { return _propChartXaxisField; }
            set { _propChartXaxisField = value; }
        }

        private string _propChartXaxisFieldLabel;
        public string PropChartXaxisFieldLabel
        {
            get
            {
                return ChartUserSettingsAreValid() ? ChartUserSettings.XaxisFieldLabel : _propChartXaxisFieldLabel;
            }

            set { _propChartXaxisFieldLabel = value; }
        }

        public string PropChartXaxisFieldLabelRaw
        {
            get { return _propChartXaxisFieldLabel; }
            set { _propChartXaxisFieldLabel = value; }
        }

        public string PropChartYaxisField
        {
            get
            {
                return ChartUserSettingsAreValid() ? ChartUserSettings.YaxisFields.AsDelimitedString("|") : PropChartYaxisFieldRaw;
            }

            set { PropChartYaxisFieldRaw = value; }
        }

        public string PropChartYaxisFieldRaw { get; set; }

        private string _propChartYaxisFieldLabel;
        public string PropChartYaxisFieldLabel
        {
            get
            {
                return ChartUserSettingsAreValid() ? ChartUserSettings.YaxisFieldLabel : _propChartYaxisFieldLabel;
            }

            set { _propChartYaxisFieldLabel = value; }
        }

        public string PropChartYaxisFieldLabelRaw
        {
            get { return _propChartYaxisFieldLabel; }
            set { _propChartYaxisFieldLabel = value; }
        }

        private string _propChartZaxisField;
        public string PropChartZaxisField
        {
            get
            {
                return ChartUserSettingsAreValid() ? ChartUserSettings.ZaxisField : _propChartZaxisField;
            }

            set { _propChartZaxisField = value; }
        }

        public string PropChartZaxisFieldRaw
        {
            get { return _propChartZaxisField; }
            set { _propChartZaxisField = value; }
        }

        private string _propChartZaxisFieldLabel;
        public string PropChartZaxisFieldLabel
        {
            get
            {
                return ChartUserSettingsAreValid() ? ChartUserSettings.ZaxisFieldLabel : _propChartZaxisFieldLabel;
            }

            set { _propChartZaxisFieldLabel = value; }
        }

        public string PropChartZaxisFieldLabelRaw
        {
            get { return _propChartZaxisFieldLabel; }
            set { _propChartZaxisFieldLabel = value; }
        }


        private string _propBubbleChartColorField;
        public string PropBubbleChartColorField
        {
            get
            {
                return ChartUserSettingsAreValid() ? ChartUserSettings.ZaxisColorField : _propBubbleChartColorField;
            }

            set { _propBubbleChartColorField = value; }
        }

        public string PropBubbleChartColorFieldRaw
        {
            get { return _propBubbleChartColorField; }
            set { _propBubbleChartColorField = value; }
        }

        public bool PropChartShowYaxisValuesAsPercentage { get; set; }

        public bool PropChartShowYaxisValuesAsCurrency { get; set; }
        public string PropChartAggregationType { get; set; }

        private bool ChartUserSettingsAreValid()
        {
            return ChartUserSettings != null && ChartUserSettings.IsValid && IsBubbleChart();
        }

        public bool PropChartShowSeriesInZaxis { get; set; }
        public bool PropChartShowSeriesLabels { get; set; }
        public bool PropChartShowZeroValueData { get; set; }
        public int PropChartYaxisNumValues { get; set; }
        public bool PropChartShowLegend { get; set; }
        public bool PropChartShowGridlines { get; set; }
        public bool PropChartShowBubbleChartInputsInWebPart { get; set; }
        public string PropChartSelectedList { get; set; }
        public string PropChartSelectedView { get; set; }
        public string PropChartRollupLists { get; set; }
        public string PropChartRollupSites { get; set; }
        public bool PropChartRollupData { get; set; }
        public string PropChartSelectedPaletteName { get; set; }
        public string PropChartSelectedPaletteNameSafe { get { return Palettes.ContainsValue(PropChartSelectedPaletteName) ? PropChartSelectedPaletteName : "Visifire1"; } }
        public bool PropChartView3D { get; set; }

        public static Dictionary<string, string> ChartTypes
        {
            get
            {
                return new Dictionary<string, string>
                           {
                               {"Column", "Column"},
                               {"Stacked Column", "StackedColumn"},
                               {"Stacked Column 100%", "StackedColumn100"},
                               {"Bar", "Bar"},
                               {"Stacked Bar", "StackedBar"},
                               {"Stacked Bar 100%", "StackedBar100"},
                               {"Area", "Area"},
                               {"Stacked Area", "StackedArea"},
                               {"Stacked Area 100%", "StackedArea100"},
                               {"Line", "Line"},
                               {"Doughnut", "Doughnut"},
                               {"Pie", "Pie"},
                               {"Funnel Streamline", "StreamLineFunnel"},
                               {"Funnel Section", "SectionFunnel"},
                               {"Bubble", "Bubble"}
                           };
            }
        }

        public static Dictionary<string, string> Palettes
        {
            get
            {
                return new Dictionary<string, string>
                           {
                               {"Color 1", "Visifire1"},
                               {"Color 2", "Visifire2"},
                               {"Gray", "VisiGray"},
                               {"Blue", "VisiBlue"},
                               {"Orange", "VisiOrange"},
                               {"Green", "VisiGreen"},
                               {"Red", "VisiRed"},
                               {"Violet", "VisiViolet"},
                               {"Aqua", "VisiAqua"}
                           };
            }
        }

        public void SetYFields(string[] yFields)
        {
            PropChartYaxisFieldRaw = yFields == null ? "" : string.Join(Separator.ToString(), yFields);
        }

        public string[] GetYFields()
        {
            return PropChartYaxisField != "" ? PropChartYaxisField.Split(Separator) : new string[0];
        }

        public string GetXaml()
        {
            //var regionalSettings = SPContext.Current.Web.CurrentUser.RegionalSettings ?? SPContext.Current.Web.RegionalSettings;
            //var cultureInfo = new CultureInfo((int)regionalSettings.LocaleId);
            var valueformatstring = PropChartShowYaxisValuesAsCurrency ? "C" : "#,0.##" + (PropChartShowYaxisValuesAsPercentage ? "%" : "");
            var xaml = new StringBuilder();
            xaml.Add("<vc:Chart xmlns:vc=\"clr-namespace:Visifire.Charts;assembly=SLVisifire.Charts\" BorderThickness=\"0\"  Watermark=\"False\"  Theme=\"Theme2\" View3D=\"{0}\" ColorSet=\"{1}\" Height=\"150\">", PropChartView3D, PropChartSelectedPaletteNameSafe);
            xaml.Add("<vc:Chart.Titles>");
            xaml.Add("<vc:Title Text=\"{0}\"/>", HttpUtility.HtmlEncode(PropChartTitle));
            xaml.Add("</vc:Chart.Titles>");
            xaml.Add("<vc:Chart.Legends><vc:Legend Enabled=\"{0}\" /></vc:Chart.Legends>", ShouldShowLegend() ? "True" : "False");
            xaml.Add("<vc:Chart.AxesX>");
            xaml.Add("<vc:Axis Title=\"{0}\" ScrollBarScale=\"1\">", PropChartShowSeriesLabels ? HttpUtility.HtmlEncode(PropChartXaxisFieldLabel) : "");
            xaml.Add("<vc:Axis.Grids><vc:ChartGrid Enabled=\"{0}\" /></vc:Axis.Grids>", PropChartShowGridlines ? "True" : "False");
            xaml.Add("</vc:Axis>");
            xaml.Add("</vc:Chart.AxesX>");
            xaml.Add("<vc:Chart.AxesY>");
            xaml.Add("<vc:Axis Title=\"{0}\" ValueFormatString=\"{1}\" >", HttpUtility.HtmlEncode(GetYAxisTitle()), valueformatstring);
            xaml.Add("<vc:Axis.Grids><vc:ChartGrid Enabled=\"{0}\" /></vc:Axis.Grids>", PropChartShowGridlines ? "True" : "False");
            xaml.Add("</vc:Axis>");
            xaml.Add("</vc:Chart.AxesY>");
            xaml.Add("<vc:Chart.Series>");

            foreach (VfChartSeries vfChartSeries in _series)
            {
                if (!IsBubbleChart())
                {
                    xaml.Add("<vc:DataSeries LegendText=\"{0}\" RenderAs=\"{1}\" >", HttpUtility.HtmlEncode(vfChartSeries.SeriesName), PropChartMainStyleSafe);
                }
                else
                {
                    xaml.Add("<vc:DataSeries LegendText=\"{0}\" RenderAs=\"{1}\"  ShowInLegend=\"false\" >", HttpUtility.HtmlEncode(vfChartSeries.SeriesName), PropChartMainStyleSafe);
                }

                xaml.Add("<vc:DataSeries.DataPoints>");

                if (!IsBubbleChart())
                {
                    SortChart(vfChartSeries);
                }

                foreach (VfPoint point in vfChartSeries.GetRange(0, vfChartSeries.Count))
                {
                    if (PointShouldBeDisplayed(point))
                    {
                        if (IsBubbleChart())
                        {
                            if (ShouldShowLegend())
                            {
                                xaml.Add("<vc:DataPoint XValue=\"{0}\" YValue=\"{1}\" ZValue=\"{2}\" ToolTipText=\"{3}\" Color=\"{4}\" ShowInLegend=\"{5}\" LegendText=\"{6}\" />", point.XAxisValue, point.YValue, point.ZValue, GetBubbleToolTipText(point), point.DataPointColorAsString, point.ShowInLegend, point.LegendText);
                            }
                            else
                            {
                                xaml.Add("<vc:DataPoint XValue=\"{0}\" YValue=\"{1}\" ZValue=\"{2}\" ToolTipText=\"{3}\" />", point.XAxisValue, point.YValue, point.ZValue, GetBubbleToolTipText(point));
                            }
                        }
                        else
                        {
                            xaml.Add("<vc:DataPoint AxisXLabel=\"{0}\" YValue=\"{1}\"/>", HttpUtility.HtmlEncode(point.XAxisLabel), point.YValue);
                        }

                    }
                }
                xaml.Add("</vc:DataSeries.DataPoints>");
                xaml.Add("</vc:DataSeries>");
            }

            xaml.Add("</vc:Chart.Series>");
            xaml.Add("</vc:Chart>");
            return xaml.ToString();
        }

        private bool PointShouldBeDisplayed(VfPoint point)
        {
            if (!PropChartShowZeroValueData)
            {
                return (IsBubbleChart() && point.XAxisValue > 0 && point.YValue > 0) || (!IsBubbleChart() && point.YValue > 0);
            }

            return true;
        }

        private string GetYAxisTitle()
        {
            if (IsBubbleChart()) return PropChartYaxisFieldLabel;

            return GetYFields().Length == 1 ? GetYFieldDisplayName(GetYFields()[0]) : "";
        }

        private string GetYFieldDisplayName(string internalYfieldName)
        {
            var list = SPContext.Current.Web.Lists[PropChartSelectedList];
            var field = list.Fields.GetFieldByInternalName(internalYfieldName);
            return field != null ? field.Title : "";
        }

        private static void SortChart(VfChartSeries vfChartSeries)
        {
            vfChartSeries.Sort((a, b) => a.XAxisLabel.CompareTo(b.XAxisLabel));
        }

        private bool ShouldShowLegend()
        {
            if (IsBubbleChart() && PropBubbleChartColorField != null && PropBubbleChartColorField.Contains("None Selected")) return false;
            return PropChartShowLegend;
        }

        private string GetBubbleToolTipText(VfPoint dataPoint)
        {
            return HttpUtility.HtmlEncode(string.Format("{0} - {5}:{6} {3}:{4} {1}:{2}", dataPoint.Title, PropChartZaxisFieldLabel, Math.Round(dataPoint.ZValue, 2), PropChartYaxisFieldLabel, Math.Round(dataPoint.YValue, 2), PropChartXaxisFieldLabel, Math.Round(dataPoint.XAxisValue, 2)));
        }

        private bool IsBubbleChart()
        {
            return PropChartMainStyleSafe.ToLower() == "bubble";
        }

        public string GetHtml(string uniqueId)
        {
            var html = new StringBuilder(
                @"
    <script type='text/javascript' src='/_layouts/epmlive/Visifire.js?nocachetoken=" + DateTime.Now.Ticks + @"'></script>
    <script type='text/javascript'>


    addLoadEvent(onLoad);


    function addLoadEvent(func) {
      var oldonload = window.onload;
      if (typeof window.onload != 'function') {
        window.onload = func;
      } else {
        window.onload = function() {
          if (oldonload) {
            oldonload();
          }
          func();
        }
      }
    }

    // Returns XmlHttp object for any browser
    function GetXMLHttpObj() {
        var objXmlHttp; // XMLHttpRequest object
        try {
            objXmlHttp = new XMLHttpRequest();
        }
        catch (e) {
            try {
                objXmlHttp = new ActiveXObject('Msxml2.XMLHTTP');
            }
            catch (e) {
                try {
                    objXmlHttp = new ActiveXObject('Microsoft.XMLHTTP');
                }
                catch (e) {
                    alert('Your browser does not support AJAX!');
                    return null;
                }
            }
        }
        return objXmlHttp;
    }

    // Loads Visifire Chart
    function onLoad() {
        var xmlHttp = GetXMLHttpObj();
        xmlHttp.onreadystatechange = function () {
            if (xmlHttp.readyState == 4) {
                var vChart = new Visifire(L_Menu_BaseUrl + '#XAPPATH#');
                vChart.setDataXml(xmlHttp.responseText);

            var chart;
            var width;
            var height;

            /* This event will be fired before loading the chart into Silverlight
               user-control */

            vChart.preLoad = function(args)
            {
                /* First Chart Reference. If there are multiple charts in a XAML
                   file, array of chart references will be available as an event
                   argument, e.g. args[0], args[1], args[2] etc. */

                chart = args[0];

                // Get the Div size
                width = " + GetWidth() + @";
                height = " + GetHeight() + @";

                // Set plugin size
                vChart.setSize(width, height);

                // Set Chart size
                chart.SetPropertyFromJs('Width', width);
                chart.SetPropertyFromJs('Height', height);
            };

            vChart.setCulture('#CULTURENAME#')
            vChart.render('Visifire#ID#');
            }
        }
        xmlHttp.open('GET', L_Menu_BaseUrl + '#VFDATAPATH#?#QUERYSTRING#', true);
        xmlHttp.send(null);
    }

    </script>
    <div style='width:100%;height:100%;' id='Visifire#ID#' ></div>
    
    <div id='ChartDiagnostics' style='width:400px;#DIAGNOSTICS#'>
    <p>Querystring: #QUERYSTRING#</p>
    <a onclick=""javascript:window.open(L_Menu_BaseUrl + '#VFDATAPATH#?#QUERYSTRING#Trace=True', 'Diagnostics')"" href='#'>Trace</a>
    </div>
            ")
                .Replace("#QUERYSTRING#", GetQueryString())
                .Replace("#ID#", uniqueId)
                .Replace("#XAPPATH#", ChartsXapPath)
                .Replace("#VFDATAPATH#", VfDataPath)
                .Replace("#CULTURENAME#", Thread.CurrentThread.CurrentCulture.Name)
                .Replace("#DIAGNOSTICS#", PropTrace ? "display: block;" : "display: none;");

            return html.ToString();
        }

        private string GetWidth()
        {
            return PropChartWidth > 0 ? (PropChartWidth - 10).ToString() : "document.getElementById('Visifire#ID#').offsetWidth";
        }

        private string GetHeight()
        {
            return PropChartHeight > 0 ? (PropChartHeight - 10).ToString() : "document.getElementById('Visifire#ID#').offsetHeight";
        }

        public string GetQueryString()
        {
            //TODO: Put in a switch to use the user's persisted selections (if bubble chart) instead of the ones in the web part properties.

            var qsItems = new Dictionary<string, object>
                              {
                                  {QXfield, HttpUtility.UrlEncode(PropChartXaxisField)},
                                  {QXfieldLabel,  HttpUtility.UrlEncode(PropChartXaxisFieldLabel)},
                                  {QYfieldLabel, HttpUtility.UrlEncode(PropChartYaxisFieldLabel)},
                                  {QZfieldLabel, HttpUtility.UrlEncode(PropChartZaxisFieldLabel)},
                                  {QBubbleChartColorField, HttpUtility.UrlEncode(PropBubbleChartColorField)},
                                  {QYfields, HttpUtility.UrlEncode(PropChartYaxisField)},
                                  {QZfield, HttpUtility.UrlEncode(PropChartZaxisField)},
                                  {QAggrtype, HttpUtility.UrlEncode(PropChartAggregationType)},
                                  {QList, HttpUtility.UrlEncode(PropChartSelectedList)},
                                  {QView, HttpUtility.UrlEncode(PropChartSelectedView)},
                                  {QRolluplists, HttpUtility.UrlEncode(PropChartRollupLists)},
                                  {QRollupsites, HttpUtility.UrlEncode(PropChartRollupSites)},
                                  {QChartType, HttpUtility.UrlEncode(PropChartMainStyle)},
                                  {QView3D, PropChartView3D},
                                  {QWidth, PropChartWidth},
                                  {QHeight, PropChartHeight},
                                  {QColorSet, HttpUtility.UrlEncode(PropChartSelectedPaletteName)},
                                  {QLegend, PropChartShowLegend},
                                  {QPercentage, PropChartShowYaxisValuesAsPercentage},
                                  {QCurrency, PropChartShowYaxisValuesAsCurrency},
                                  {QGridlines, PropChartShowGridlines},
                                  {QLabels, PropChartShowSeriesLabels},
                                  {QShowZeroValueData, PropChartShowZeroValueData},
                                  {QShowBubbleChartInputs, PropChartShowBubbleChartInputsInWebPart},
                                  {QChartWebPartId, HttpUtility.UrlEncode(PropChartWebPartId)},
                                  {QLookupField, HttpUtility.UrlEncode(ChartLookupField)},
                                  {QLookupFieldList, HttpUtility.UrlEncode(ChartLookupFieldList)}
                              };

            if (!string.IsNullOrEmpty(ReportFilterWebPartId))
            {
                qsItems.Add("ReportFilterId", ReportFilterWebPartId);
            }

            var qs = new StringBuilder();
            foreach (KeyValuePair<string, object> qsItem in qsItems)
                qs.Append(string.Format("{0}={1}&", qsItem.Key, qsItem.Value));
            return qs.ToString();
        }

        protected void HandleException(Exception ex)
        {
            TraceOutput.AppendLine("**** EXCEPTION ****");
            TraceOutput.AppendLine(ex.Message);
            TraceOutput.AppendLine(ex.StackTrace);
            if (ex.InnerException != null)
                HandleException(ex.InnerException);
        }
    }
}