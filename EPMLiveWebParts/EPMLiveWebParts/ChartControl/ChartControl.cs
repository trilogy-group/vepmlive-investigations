using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;
using EPMLiveWebParts.EpmCharting.DomainModel;
using EPMLiveWebParts.EpmCharting.DomainServices;
using EPMLiveWebParts.EpmCharting.Repositories;
using EPMLiveWebParts.Personalization.DomainModel;
using EPMLiveWebParts.ReportFiltering.DomainServices;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;
using ReportFiltering;
using EPMLiveCore;

using WebPart = Microsoft.SharePoint.WebPartPages.WebPart;

namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:MyWorkRollup runat=server></{0}:MyWorkRollup>")]
    [Guid("7382bd19-214a-4cab-9cce-e99243bb3fed")]
    [XmlRoot(Namespace = "MyWebParts")]
    public class ChartControl : WebPart
    {
        #region Fields

        protected Literal ScriptTagHolder = new Literal();
        protected DataTable ChartData;
        protected DataTable SiteDataQueryData;
        protected Literal ConfigureChartVerbiageLiteral = new Literal();
        protected SPList TopList;
        protected ToolPart[] WebPartToolPart;
        private EpmChart _backingChart;
        private LiteralControl _litVfChart;
        private bool _isPostBackFromBubbleChartInputsApplyButton;

        //TODO: Don't name these bubble chart specific as these could theoretically be used for other charts.
        protected DropDownList BubbleChartXaxisDropDownList;
        protected DropDownList BubbleChartYaxisAsDropDownList;
        protected CheckBoxList BubbleChartYaxisCheckBoxList;
        protected DropDownList BubbleChartZaxisDropDownList;
        protected DropDownList BubbleChartZcolorFieldDropDownList;
        protected Button BubbleChartApplyButton;
        protected HtmlTable UserSettingsTable;
        protected HtmlTable MainTable;

        #endregion
        
        #region Properties

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [WebBrowsable(false)]
        public string PropChartTitle
        {
            get { return Chart.PropChartTitle; }
            set { Chart.PropChartTitle = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public int PropChartTitleFontSize
        {
            get { return Chart.PropChartTitleFontSize; }
            set { Chart.PropChartTitleFontSize = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [WebBrowsable(false)]
        public string PropChartMainStyle
        {
            get { return Chart.PropChartMainStyle; }
            set { Chart.PropChartMainStyle = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [WebBrowsable(false)]
        public string PropChartSelectedPaletteName
        {
            get { return Chart.PropChartSelectedPaletteName; }
            set { Chart.PropChartSelectedPaletteName = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartView3D
        {
            get { return Chart.PropChartView3D; }
            set { Chart.PropChartView3D = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartXaxisField
        {
            get { return Chart.PropChartXaxisFieldRaw; }
            set { Chart.PropChartXaxisFieldRaw = value; }
        }        
        
        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartXaxisFieldLabel
        {
            get { return Chart.PropChartXaxisFieldLabelRaw; }
            set { Chart.PropChartXaxisFieldLabelRaw = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartYaxisField
        {
            get { return Chart.PropChartYaxisFieldRaw; }
            set { Chart.PropChartYaxisFieldRaw = value; }
        }
        public void SetYField(string[] yField)
        {
            Chart.SetYFields(yField);
        }
        public string[] GetYaxisFields()
        {
            return Chart.GetYFields();
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartYaxisFieldLabel
        {
            get { return Chart.PropChartYaxisFieldLabelRaw; }
            set { Chart.PropChartYaxisFieldLabelRaw = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartZaxisField
        {
            get { return Chart.PropChartZaxisFieldRaw; }
            set { Chart.PropChartZaxisFieldRaw = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartZaxisFieldLabel
        {
            get { return Chart.PropChartZaxisFieldLabelRaw; }
            set { Chart.PropChartZaxisFieldLabelRaw = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropBubbleChartColorField
        {
            get { return Chart.PropBubbleChartColorFieldRaw; }
            set { Chart.PropBubbleChartColorFieldRaw = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public int PropChartXaxisLabelRotationAngle
        {
            get { return Chart.PropChartXaxisLabelRotationAngle; }
            set { Chart.PropChartXaxisLabelRotationAngle = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public int PropChartXaxisLabelFontSize
        {
            get { return Chart.PropChartXaxisLabelFontSize; }
            set { Chart.PropChartXaxisLabelFontSize = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowYaxisValuesAsPercentage
        {
            get { return Chart.PropChartShowYaxisValuesAsPercentage; }
            set { Chart.PropChartShowYaxisValuesAsPercentage = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowYaxisValuesAsCurrency
        {
            get { return Chart.PropChartShowYaxisValuesAsCurrency; }
            set { Chart.PropChartShowYaxisValuesAsCurrency = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public int PropChartZaxisLabelRotationAngle
        {
            get { return Chart.PropChartZaxisLabelRotationAngle; }
            set { Chart.PropChartZaxisLabelRotationAngle = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public int PropChartSeriesDataPointLabelFontSize
        {
            get { return Chart.PropChartSeriesDataPointLabelFontSize; }
            set { Chart.PropChartSeriesDataPointLabelFontSize = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowSeriesInZaxis { get; set; }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowSeriesLabels
        {
            get { return Chart.PropChartShowSeriesLabels; }
            set { Chart.PropChartShowSeriesLabels = value; }
        }
        
        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowZeroValueData
        {
            get { return Chart.PropChartShowZeroValueData; }
            set { Chart.PropChartShowZeroValueData = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowSeriesNameAsLabel { get; set; }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowSeriesValueAsLabel { get; set; }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartSeriesNameLabelPosition { get; set; }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartSeriesValueLabelPosition { get; set; }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public int PropChartYaxisNumValues
        {
            get { return Chart.PropChartYaxisNumValues; }
            set { Chart.PropChartYaxisNumValues = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowLegend
        {
            get { return Chart.PropChartShowLegend; }
            set { Chart.PropChartShowLegend = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowGridlines
        {
            get { return Chart.PropChartShowGridlines; }
            set { Chart.PropChartShowGridlines = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [WebBrowsable(false)]
        public string PropChartLegendFontName { get; set; }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public int PropChartLegendFontSize
        {
            get { return Chart.PropChartLegendFontSize; }
            set { Chart.PropChartLegendFontSize = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowFrame { get; set; }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public Color PropChartFrameColor { get; set; }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartFrameRoundCorners { get; set; }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartSelectedList
        {
            get { return Chart.PropChartSelectedList; }
            set { Chart.PropChartSelectedList = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartSelectedView
        {
            get { return Chart.PropChartSelectedView; }
            set { Chart.PropChartSelectedView = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartRollupLists
        {
            get { return Chart.PropChartRollupLists.UnDelimit(); }
            set { Chart.PropChartRollupLists = value.Delimit(); }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartRollupSites
        {
            get { return Chart.PropChartRollupSites.UnDelimit(); }
            set { Chart.PropChartRollupSites = value.Delimit(); }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public string PropChartAggregationType
        {
            get { return Chart.PropChartAggregationType; }
            set { Chart.PropChartAggregationType = value; }
        }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartRollupData { get; set; }

        [Category("Chart Control Properties")]
        [Personalizable(PersonalizationScope.Shared)]
        [WebDescription("Custom string for toolpart")]
        [Description("Used by the toolpart")]
        [WebBrowsable(false)]
        public bool PropChartShowBubbleChartInputsInWebPart
        {
            get { return Chart.PropChartShowBubbleChartInputsInWebPart; }
            set { Chart.PropChartShowBubbleChartInputsInWebPart = value; }
        }

        private EpmChart Chart
        {
            get { return _backingChart ?? (_backingChart = new EpmChart()); }
            set
            {
                if (_backingChart == null) _backingChart = new EpmChart();
                _backingChart = value;
            }
        }

        #endregion

        #region Web Part Connections

        private IReportID _myProvider;

        [ConnectionConsumer("Report ID Consumer", "ReportIDConsumer")]
        public void ReportIdConsumer(IReportID provider)
        {
            _myProvider = provider;
        }

        #endregion

        private EPMLiveCore.Act act;
        private int activation;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            SetChartWidthAndHeight();
        }

        private void SetChartWidthAndHeight()
        {
            Chart.PropChartWidth = (int) (new Unit(Width).Value);
            Chart.PropChartHeight = (int) (new Unit(Height).Value);
        }

        protected override void OnPreRender(EventArgs e)
        {
            DisableBrowserCaching();
            HandleBubbleChartInputPostBack();
        }

        /// <summary>
        /// This is being done because when a postback is done, the ReportIdConsumer method gets called AFTER CreateChildControls
        /// which results in the chart not getting filtered from the Filter web part. This was happening when clicking the "Apply" button
        /// on a bubble chart that allowed the user to select the inputs (x, y, z axis etc). This method rebuilds the control tree after
        /// the ReportIdConsumer is called so long as the call to this is placed in an event handler that occurs after ReportIdConsumer
        /// such as OnPreRender.
        /// </summary>
        private void HandleBubbleChartInputPostBack()
        {
            if (_isPostBackFromBubbleChartInputsApplyButton) RebuildControlTree();
        }

        protected override void CreateChildControls()
        {

            act = new EPMLiveCore.Act(SPContext.Current.Web);
            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.WebParts);

            if(activation != 0)
            {
                return;
            }

            //base.CreateChildControls();
            MainTable = new HtmlTable();
            InitializeBubbleChartInputs();

            // Diagnostics
            Chart.PropTrace = Page.Request.QueryString["charttrace"] != null;
            Chart.ChartLookupField = Page.Request.QueryString["lookupfield"];
            Chart.ChartLookupFieldList = Page.Request.QueryString["lookupfieldlist"];

            if (_myProvider != null)
            {
                Chart.ReportFilterWebPartId = _myProvider.ReportID;
            }

            Chart.PropChartWebPartId = ID;

            Chart.BubbleChartUserSettings = GetPersistedBubbleChartPersonalizations();

            _litVfChart = new LiteralControl(Chart.GetHtml(ZoneID + ZoneIndex));

            var currentWebPartManager = WebPartManager.GetCurrentWebPartManager(Page);

            if (currentWebPartManager != null &&
                ((String.IsNullOrEmpty(PropChartSelectedList.Trim()) &&
                  currentWebPartManager.DisplayMode.Name == "Design") ||
                 (PropChartSelectedList.Trim() == "<Select List>" && currentWebPartManager.DisplayMode.Name == "Browse")))
            {
                ConfigureChartVerbiageLiteral.Text =
                    "<P><DIV class=\"UserGeneric\"><br />To configure the EPM Live Chart Web Part <a href=\"javascript:MSOTlPn_ShowToolPane2Wrapper('Edit', this, '" +
                    ID + "')\">click here</a>.<br /><br /></DIV></P>";
                Controls.Add(ConfigureChartVerbiageLiteral);
            }

            if (IsBubbleChart())
            {
                using (var site = new SPSite(SPContext.Current.Site.Url))
                {
                    using (var web = site.OpenWeb(SPContext.Current.Web.ID))
                    {
                        var selectedList = web.Lists[PropChartSelectedList];

                        if (selectedList == null) return;
                        PopulateBubbleChartInputsWithInitialValues(selectedList);

                        if (Chart.BubbleChartUserSettings != null && Chart.BubbleChartUserSettings.IsValid && selectedList.ID == Chart.BubbleChartUserSettings.ListId)
                        {
                            SetBubbleChartInputSelectionsBasedOnPersonalizationSettings(Chart.BubbleChartUserSettings, selectedList);
                        }
                        else
                        {
                            SetBubbleChartInputsBasedOnWebPartProperties();
                        }
                    }
                }
                
            }

            var tableRow = new HtmlTableRow();
            var chartCell = new HtmlTableCell();
            chartCell.Attributes.Add("valign", "top");

            var userSettingsCell = new HtmlTableCell();
            userSettingsCell.Attributes.Add("valign", "top");
            userSettingsCell.Attributes.Add("style", "padding-top:12px;");

            chartCell.Controls.Add(_litVfChart);

            MainTable.Attributes.Add("width", "100%");

            if (PropChartShowBubbleChartInputsInWebPart)
            {
                chartCell.Attributes.Add("width", "80%");
                userSettingsCell.Controls.Add(UserSettingsTable);
            }

            tableRow.Controls.Add(chartCell);
            
            if (IsBubbleChart())
            {
                tableRow.Controls.Add(userSettingsCell);
            }
            
            MainTable.Controls.Add(tableRow);

            Controls.Add(MainTable);
        }

        private bool IsBubbleChart()
        {
            return PropChartMainStyle.ToLower() == "bubble";
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            if(activation != 0)
            {
                output.Write(act.translateStatus(activation));
                return;
            }

            SPSecurity.RunWithElevatedPrivileges(() => RenderWebPartWithElevatedPermissions(output));
        }

        public override ToolPart[] GetToolParts()
        {
            WebPartToolPart = new ToolPart[3];

            WebPartToolPart[0] = new ChartControlToolpartBase();
            WebPartToolPart[1] = new WebPartToolPart();
            WebPartToolPart[2] = new CustomPropertyToolPart();

            return WebPartToolPart;
        }

        private void RenderWebPartWithElevatedPermissions(HtmlTextWriter output)
        {
            var wp = WebPartManager.GetCurrentWebPartManager(Page);
            if (wp != null && ((String.IsNullOrEmpty(PropChartSelectedList.Trim()) && wp.DisplayMode.Name == "Design") || (PropChartSelectedList.Trim() == "<Select List>" && wp.DisplayMode.Name == "Browse")))
            {
                ConfigureChartVerbiageLiteral.RenderControl(output);
            }
            else
            {
                MainTable.RenderControl(output);
            }
        }

        private void DisableBrowserCaching()
        {
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Page.Response.Expires = -1;
            Page.Response.CacheControl = "no-cache";
            Page.Response.AddHeader("Pragma", "no-cache");
            Page.Response.Cache.SetNoStore();
        }

        #region Bubble Chart Inputs

        private void InitializeBubbleChartInputs()
        {
            BubbleChartXaxisDropDownList = new DropDownList();
            BubbleChartXaxisDropDownList.Attributes.Add("style", "width:200px;");
            BubbleChartYaxisCheckBoxList = new CheckBoxList();
            BubbleChartYaxisAsDropDownList = new DropDownList();
            BubbleChartYaxisAsDropDownList.Attributes.Add("style", "width:200px;");
            BubbleChartZaxisDropDownList = new DropDownList();
            BubbleChartZaxisDropDownList.Attributes.Add("style", "width:200px;");
            BubbleChartZcolorFieldDropDownList = new DropDownList();
            BubbleChartZcolorFieldDropDownList.Attributes.Add("style", "width:200px;");

            BubbleChartApplyButton = new Button { Text = "Apply" };
            BubbleChartApplyButton.CssClass = "button-new silver";
            BubbleChartApplyButton.Click += BubbleChartApplyButtonClick;

            var xAxisIconCell = new HtmlTableCell();
            var xAxisCell = new HtmlTableCell();
            var xAxisIcon = new HtmlImage { Src = "_layouts/epmlive/images/bubblechart/XAxisIcon.png" };
            xAxisIconCell.Controls.Add(xAxisIcon);
            xAxisIconCell.Attributes.Add("valign", "top");
            xAxisCell.Controls.Add(BubbleChartXaxisDropDownList);
            var xAxisRow = new HtmlTableRow();
            xAxisRow.Controls.Add(xAxisIconCell);
            xAxisRow.Controls.Add(xAxisCell);

            var yAxisIconCell = new HtmlTableCell();
            var yAxisCell = new HtmlTableCell();
            var yAxisIcon = new HtmlImage { Src = "_layouts/epmlive/images/bubblechart/YAxisIcon.png" };
            yAxisIconCell.Controls.Add(yAxisIcon);
            yAxisIconCell.Attributes.Add("valign", "top");

            if (!IsBubbleChart())
            {
                yAxisCell.Controls.Add(BubbleChartYaxisCheckBoxList);
            }
            else
            {
                yAxisCell.Controls.Add(BubbleChartYaxisAsDropDownList);
            }

            var yAxisRow = new HtmlTableRow();
            yAxisRow.Controls.Add(yAxisIconCell);
            yAxisRow.Controls.Add(yAxisCell);

            var zAxisIconCell = new HtmlTableCell();
            var zAxisCell = new HtmlTableCell();
            var zAxisIcon = new HtmlImage { Src = "_layouts/epmlive/images/bubblechart/ZAxisIcon.png" };
            zAxisIconCell.Controls.Add(zAxisIcon);
            zAxisIconCell.Attributes.Add("valign", "top");
            zAxisCell.Controls.Add(BubbleChartZaxisDropDownList);
            var zAxisRow = new HtmlTableRow();
            zAxisRow.Controls.Add(zAxisIconCell);
            zAxisRow.Controls.Add(zAxisCell);

            var zAxisColorFieldIconCell = new HtmlTableCell();
            var zAxisColorFieldCell = new HtmlTableCell();
            var zColorFieldIcon = new HtmlImage { Src = "_layouts/epmlive/images/bubblechart/ZAxisColorIcon.png" };
            zAxisColorFieldIconCell.Controls.Add(zColorFieldIcon);
            zAxisColorFieldIconCell.Attributes.Add("valign", "top");
            zAxisColorFieldCell.Controls.Add(BubbleChartZcolorFieldDropDownList);
            var zAxisColorFieldRow = new HtmlTableRow();
            zAxisColorFieldRow.Controls.Add(zAxisColorFieldIconCell);
            zAxisColorFieldRow.Controls.Add(zAxisColorFieldCell);

            var applyButtonCell = new HtmlTableCell();
            applyButtonCell.Attributes.Add("colspan", "2");
            applyButtonCell.Attributes.Add("align", "center");
            applyButtonCell.Controls.Add(BubbleChartApplyButton);
            var applyButtonRow = new HtmlTableRow();
            applyButtonRow.Controls.Add(applyButtonCell);

            UserSettingsTable = new HtmlTable();
            UserSettingsTable.Controls.Add(xAxisRow);
            UserSettingsTable.Controls.Add(yAxisRow);

            UserSettingsTable.Controls.Add(zAxisRow);
            UserSettingsTable.Controls.Add(zAxisColorFieldRow);
            UserSettingsTable.Controls.Add(applyButtonRow);
        }

        protected void BubbleChartApplyButtonClick(object sender, EventArgs e)
        {
            PersistBubbleChartPersonalizations();
            _isPostBackFromBubbleChartInputsApplyButton = true;
        }

        private EpmChartUserSettings GetPersistedBubbleChartPersonalizations()
        {
            var web = SPContext.Current.Web;
            var searchCriteria = new PersonalizationSearchCriteria
                                     {
                                         SiteId = web.Site.ID,
                                         WebId = web.ID,
                                         WebPartId = WebPartHelper.ConvertWebPartIdToGuid(ID),
                                         UserId = web.CurrentUser.ID.ToString(),
                                         Key = EpmChartUserSettings.Key    
                                     };

            var repo = new EpmChartUserSettingsRepository(web);
            return repo.GetChartSettings(searchCriteria);
        }

        private void PersistBubbleChartPersonalizations()
        {
            var web = SPContext.Current.Web;
            var repo = new EpmChartUserSettingsRepository(web);

            var chartSettings = new EpmChartUserSettings
                                    {
                                        SiteId = web.Site.ID,
                                        WebId = web.ID,
                                        WebPartId = WebPartHelper.ConvertWebPartIdToGuid(ID),
                                        UserId = web.CurrentUser.ID.ToString(),
                                        ListId = web.Lists[PropChartSelectedList].ID,
                                        XaxisField = GetXaxisFieldSelection(),
                                        XaxisFieldLabel = GetXaxisFieldLabel(),
                                        YaxisFields = GetYaxisSelections(),
                                        YaxisFieldLabel = GetYaxisFieldLabel(),
                                        ZaxisField = GetZaxisFieldSelection(),
                                        ZaxisFieldLabel = GetZaxisFieldLabel(),
                                        ZaxisColorField = GetZaxisColorFieldSelection()
                                    };

            repo.PersistChartSettings(chartSettings);
        }

        private string GetZaxisColorFieldSelection()
        {
            return BubbleChartZcolorFieldDropDownList.SelectedValue.Contains("None Selected") ? "" : BubbleChartZcolorFieldDropDownList.SelectedValue;
        }

        private string GetZaxisFieldSelection()
        {
            return BubbleChartZaxisDropDownList.SelectedValue.Contains("None Selected") ? "" : BubbleChartZaxisDropDownList.SelectedValue;
        }

        private string GetXaxisFieldSelection()
        {
            return BubbleChartXaxisDropDownList.SelectedValue.Contains("None Selected") ? "" : BubbleChartXaxisDropDownList.SelectedValue;
        }

        private string GetXaxisFieldLabel()
        {
            return BubbleChartXaxisDropDownList.SelectedValue.Contains("None Selected") ? "" : BubbleChartXaxisDropDownList.SelectedItem.Text;
        }

        private string GetYaxisFieldLabel()
        {

            if (!IsBubbleChart())
            {
                if (BubbleChartYaxisCheckBoxList.Items.Count == 1)
                {
                    return BubbleChartYaxisCheckBoxList.Items[0].Text;
                }
            }
            else
            {
                if(!BubbleChartXaxisDropDownList.SelectedValue.Contains("None Selected"))
                {
                    return BubbleChartYaxisAsDropDownList.SelectedItem.Text;
                }
            }

            return string.Empty;
        }

        private List<string> GetYaxisSelections()
        {
            var yAxisSelections = new List<string>();

            if (!IsBubbleChart())
            {
                foreach (ListItem listItem in BubbleChartYaxisCheckBoxList.Items)
                {
                    if (listItem.Selected) yAxisSelections.Add(listItem.Value);
                }
            }
            else
            {
                foreach (ListItem listItem in BubbleChartYaxisAsDropDownList.Items)
                {
                    if (listItem.Selected) yAxisSelections.Add(listItem.Value);
                }
            }

            return yAxisSelections;
        }

        private string GetZaxisFieldLabel()
        {
            return BubbleChartZaxisDropDownList.SelectedValue.Contains("None Selected") ? "" : BubbleChartZaxisDropDownList.SelectedItem.Text;
        }

        private void SetBubbleChartInputSelectionsBasedOnPersonalizationSettings(EpmChartUserSettings userSettings, SPList selectedList)
        {
            SetXaxisSelection(userSettings);
            SetYaxisSelections(userSettings);
            SetZaxisSelection(userSettings);
            SetZaxisColorFieldSelection(userSettings);
        }

        private void SetZaxisColorFieldSelection(EpmChartUserSettings userSettings)
        {
            if (userSettings.ZaxisColorField== null) return;
            var zAxisColorSelectionItem = BubbleChartZcolorFieldDropDownList.Items.FindByValue(userSettings.ZaxisColorField);
            if (zAxisColorSelectionItem != null)
            {
                zAxisColorSelectionItem.Selected = true;
            }  
        }

        private void SetZaxisSelection(EpmChartUserSettings userSettings)
        {
            if (userSettings.ZaxisField == null) return;
            var zAxisSelectionItem = BubbleChartZaxisDropDownList.Items.FindByValue(userSettings.ZaxisField);
            if (zAxisSelectionItem != null)
            {
                zAxisSelectionItem.Selected = true;
            }   
        }

        private void SetYaxisSelections(EpmChartUserSettings userSettings)
        {
            foreach (var yAxisSelection in userSettings.YaxisFields)
            {
                ListItem yAxisSelectionItem;

                if (!IsBubbleChart())
                {
                    yAxisSelectionItem = BubbleChartYaxisCheckBoxList.Items.FindByValue(yAxisSelection);
                }
                else
                {
                    yAxisSelectionItem = BubbleChartYaxisAsDropDownList.Items.FindByValue(yAxisSelection);
                }

                if (yAxisSelectionItem != null)
                {
                    yAxisSelectionItem.Selected = true;
                }                
            }
        }

        private void SetXaxisSelection(EpmChartUserSettings userSettings)
        {
            if (userSettings.XaxisField == null) return;
            var xAxisSelecttionItem = BubbleChartXaxisDropDownList.Items.FindByValue(userSettings.XaxisField);
            if (xAxisSelecttionItem != null)
            {
                xAxisSelecttionItem.Selected = true;
            } 
        }

        private void SetBubbleChartInputsBasedOnWebPartProperties()
        {
            //TODO: These X,Y,Z settings are almost identical to the SetXAxisSelection, SetYAxisSelection methods, so consolidate.
            var xAxisFieldItem = BubbleChartXaxisDropDownList.Items.FindByValue(PropChartXaxisField);
            if (xAxisFieldItem != null)
            {
                xAxisFieldItem.Selected = true;
            }
            
            var zAxisFieldItem = BubbleChartZaxisDropDownList.Items.FindByValue(PropChartZaxisField);
            if (zAxisFieldItem != null)
            {
                zAxisFieldItem.Selected = true;
            }

            var zColorFieldItem = BubbleChartZcolorFieldDropDownList.Items.FindByValue(PropBubbleChartColorField);
            if (zColorFieldItem != null)
            {
                zColorFieldItem.Selected = true;
            }

            if (string.IsNullOrEmpty(PropChartYaxisField)) return;
            
            foreach (var yAxisField in GetYaxisFields())
            {
                ListItem yAxisFieldItems;

                if (!IsBubbleChart())
                {
                    yAxisFieldItems = BubbleChartYaxisCheckBoxList.Items.FindByValue(yAxisField);
                }
                else
                {
                    yAxisFieldItems = BubbleChartYaxisAsDropDownList.Items.FindByValue(yAxisField);
                }
                
                if (yAxisFieldItems != null)
                {
                    if (!IsBubbleChart())
                    {
                        BubbleChartYaxisCheckBoxList.Items.FindByValue(yAxisField).Selected = true;
                    }
                    else
                    {
                        BubbleChartYaxisAsDropDownList.Items.FindByValue(yAxisField).Selected = true;
                    }
                }
            }
        }

        private void PopulateBubbleChartInputsWithInitialValues(SPList list)
        {
            foreach (SPField selectedListField in list.Fields)
            {
                if (selectedListField.Type == SPFieldType.Choice)
                {
                    var colorFieldListItem = new ListItem(selectedListField.Title,
                                                            selectedListField.InternalName);
                    BubbleChartZcolorFieldDropDownList.Items.Add(colorFieldListItem);
                }

                if (selectedListField.Type == SPFieldType.Attachments ||
                    selectedListField.InternalName == "Order" ||
                    selectedListField.Type == SPFieldType.File || selectedListField.InternalName == "MetaInfo" ||
                    selectedListField.Type == SPFieldType.Computed ||
                    (selectedListField.FromBaseType &&
                        (!selectedListField.FromBaseType || selectedListField.InternalName != "Title"))) continue;

                //TODO: Consolidate these if the X axis will only ever be a number.
                var xAxisListItem = new ListItem(selectedListField.Title, selectedListField.InternalName);
                var zAxisListItem = new ListItem(selectedListField.Title, selectedListField.InternalName);

                if (ChartHelper.IsCalculateableSharepointField(selectedListField))
                {
                    BubbleChartXaxisDropDownList.Items.Add(xAxisListItem);
                    BubbleChartZaxisDropDownList.Items.Add(zAxisListItem);
                }

                if (selectedListField.TypeAsString != "Currency" && selectedListField.TypeAsString != "Number" &&
                    (selectedListField.Type != SPFieldType.Calculated ||
                        EpmChart.GetFieldSchemaAttribValue(selectedListField.SchemaXml, "ResultType") != "Number") &&
                    (selectedListField.Type != SPFieldType.Calculated ||
                        EpmChart.GetFieldSchemaAttribValue(selectedListField.SchemaXml, "ResultType") != "Currency"))
                    continue;

                var yAxisListItem = new ListItem(selectedListField.Title, selectedListField.InternalName);
                if (!IsBubbleChart())
                {
                    BubbleChartYaxisCheckBoxList.Items.Add(yAxisListItem);
                }
                else
                {
                    BubbleChartYaxisAsDropDownList.Items.Add(yAxisListItem);
                }
            }

            SortBubbleChartDropDownLists();
        }

        private void SortBubbleChartDropDownLists()
        {
            BubbleChartXaxisDropDownList.Sort();
            BubbleChartYaxisAsDropDownList.Sort();
            BubbleChartZaxisDropDownList.Sort();
            BubbleChartZcolorFieldDropDownList.Sort();
        }

        public void RebuildControlTree()
        {
            Controls.Clear();
            SetChartWidthAndHeight();
            CreateChildControls();
        }

        #endregion

    }
}
