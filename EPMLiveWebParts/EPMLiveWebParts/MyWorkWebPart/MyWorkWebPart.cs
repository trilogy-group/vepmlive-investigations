using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Serialization;
using EPMLiveWebParts.CONTROLTEMPLATES.MyWork;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using WebPart = Microsoft.SharePoint.WebPartPages.WebPart;

namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:MyWorkWebPart runat=server></{0}:MyWorkWebPart>")]
    [Guid("8A88ACAE-8991-4EBD-8D39-DA39769FBA84")]
    [XmlRoot(Namespace = "MyWork")]
    public class MyWorkWebPart : WebPart, IWebPartPageComponentProvider
    {
        #region Fields (22) 

        private const string MANAGE_TAB_ID = "Ribbon.MyWorkTab";
        private const string VIEWS_TAB_ID = "Ribbon.MyWorkViewsTab";
        private static readonly Random Random = new Random();
        private static readonly object SyncLock = new object();
        private readonly string _allWorkGridId;
        private readonly string _contextualTab = Resources.MyWorkWebPart_ContextualTab;
        private readonly string _contextualTabTemplate = Resources.MyWorkWebPart_ContextualTabTemplate;
        private readonly string _workingOnGridId;
        private string _allowEditToggle;
        private string _crossSiteUrls;
        private string _defaultGlobalView;
        private string _defaultToEditMode;
        private string _dueDayFilter;
        private string _hideNewButton;
        private string _myWorkSelectedLists;
        private string _newItemButtonLists;
        private string _newItemIndicator;
        private string _performanceMode;
        private string _selectedFields;
        private string _selectedLists;
        private string _showToolbar;
        private string _useCentralizedSettings;

        #endregion Fields 

        #region Constructors (1) 

        public MyWorkWebPart()
        {
            _allWorkGridId =
                (DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture) + RandomNumber(1000, 2000)).Md5();
            _workingOnGridId =
                (DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture) + RandomNumber(3000, 4000)).Md5();
        }

        #endregion Constructors 

        #region Properties (15) 

        [WebPartStorage(Storage.Shared)]
        [Browsable(false)]
        public bool AllowEditToggle
        {
            get { return !string.IsNullOrEmpty(_allowEditToggle) && _allowEditToggle.Equals("True"); }
            set { _allowEditToggle = value.ToString(); }
        }

        [WebPartStorage(Storage.Shared)]
        [Browsable(false)]
        public string[] CrossSiteUrls
        {
            get { return !string.IsNullOrEmpty(_crossSiteUrls) ? _crossSiteUrls.Split('|') : new string[] {}; }
            set { _crossSiteUrls = string.Join("|", value); }
        }

        [WebPartStorage(Storage.Shared)]
        [Browsable(false)]
        public string DefaultGlobalView
        {
            get { return _defaultGlobalView ?? string.Empty; }
            set { _defaultGlobalView = value; }
        }

        [WebPartStorage(Storage.Shared)]
        [Browsable(false)]
        public bool DefaultToEditMode
        {
            get { return !string.IsNullOrEmpty(_defaultToEditMode) && _defaultToEditMode.Equals("True"); }
            set { _defaultToEditMode = value.ToString(); }
        }

        public string DelayScript
        {
            get { return Resources.MyWorkWebPart_DelayScript; }
        }

        [WebPartStorage(Storage.Shared)]
        [Browsable(false)]
        public string DueDayFilter
        {
            get { return _dueDayFilter ?? string.Empty; }
            set { _dueDayFilter = value; }
        }

        [WebPartStorage(Storage.Shared)]
        [Browsable(false)]
        public bool HideNewButton
        {
            get { return !string.IsNullOrEmpty(_hideNewButton) && _hideNewButton.Equals("True"); }
            set { _hideNewButton = value.ToString(); }
        }

        [WebPartStorage(Storage.Shared)]
        [Browsable(false)]
        public string[] MyWorkSelectedLists
        {
            get { return !string.IsNullOrEmpty(_myWorkSelectedLists) ? _myWorkSelectedLists.Split(',') : new string[] {}; }
            set { _myWorkSelectedLists = string.Join(",", value); }
        }

        [WebPartStorage(Storage.Shared)]
        [Browsable(false)]
        public string NewItemIndicator
        {
            get { return _newItemIndicator ?? string.Empty; }
            set { _newItemIndicator = value; }
        }

        [WebPartStorage(Storage.Shared)]
        [Browsable(false)]
        public bool PerformanceMode
        {
            get { return !string.IsNullOrEmpty(_performanceMode) && _performanceMode.Equals("True"); }
            set { _performanceMode = value.ToString(); }
        }

        [WebPartStorage(Storage.Shared)]
        [Browsable(false)]
        public string[] SelectedFields
        {
            get { return !string.IsNullOrEmpty(_selectedFields) ? _selectedFields.Split(',') : new string[] {}; }
            set { _selectedFields = string.Join(",", value); }
        }

        [WebPartStorage(Storage.Shared)]
        [Browsable(false)]
        public string[] SelectedLists
        {
            get { return !string.IsNullOrEmpty(_selectedLists) ? _selectedLists.Split(',') : new string[] {}; }
            set { _selectedLists = string.Join(",", value); }
        }

        [WebPartStorage(Storage.Shared)]
        [Browsable(false)]
        public bool ShowToolbar
        {
            get
            {
                return !string.IsNullOrEmpty(_showToolbar) && _showToolbar.ToLower().Equals("true");
            }
            set { _showToolbar = value.ToString(); }
        }

        [WebPartStorage(Storage.Shared)]
        [Browsable(false)]
        public bool UseCentralizedSettings
        {
            get { return string.IsNullOrEmpty(_useCentralizedSettings) || _useCentralizedSettings.Equals("True"); }
            set { _useCentralizedSettings = value.ToString(); }
        }

        /// <summary>
        ///     Gets the web part contextual info.
        /// </summary>
        public WebPartContextualInfo WebPartContextualInfo
        {
            get
            {
                var webPartRibbonContextualGroup = new WebPartRibbonContextualGroup
                                                       {
                                                           Id = "Ribbon.MyWorkContextualTabGroup",
                                                           Command = "MyWorkContextualTab.EnableContextualGroup",
                                                           VisibilityContext =
                                                               "MyWorkContextualTab.CustomVisibilityContext"
                                                       };

                var webPartContextualInfo = new WebPartContextualInfo();

                webPartContextualInfo.Tabs.Add(new WebPartRibbonTab
                                                   {
                                                       Id = MANAGE_TAB_ID,
                                                       VisibilityContext = "MyWorkContextualTab.CustomVisibilityContext"
                                                   });

                webPartContextualInfo.Tabs.Add(new WebPartRibbonTab
                                                   {
                                                       Id = VIEWS_TAB_ID,
                                                       VisibilityContext = "MyWorkContextualTab.CustomVisibilityContext"
                                                   });

                webPartContextualInfo.ContextualGroups.Add(webPartRibbonContextualGroup);
                webPartContextualInfo.PageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                return webPartContextualInfo;
            }
        }

        #endregion Properties 

        #region Methods (5) 

        // Public Methods (2) 

        /// <summary>
        ///     Determines which tool parts are displayed in the tool pane of the Web-based Web Part design user interface, and the order in which they are displayed.
        /// </summary>
        /// <returns>
        ///     An array of type <see cref="T:Microsoft.SharePoint.WebPartPages.ToolPart" /> that determines which tool parts will be displayed in the tool pane. If a Web Part that implements one or more custom properties does not override the
        ///     <see
        ///         cref="M:Microsoft.SharePoint.WebPartPages.WebPart.GetToolParts" />
        ///     method, the base class method will return an instance of the
        ///     <see
        ///         cref="T:Microsoft.SharePoint.WebPartPages.WebPartToolPart" />
        ///     class and an instance of the
        ///     <see
        ///         cref="T:Microsoft.SharePoint.WebPartPages.CustomPropertyToolPart" />
        ///     class. An instance of the
        ///     <see
        ///         cref="T:Microsoft.SharePoint.WebPartPages.WebPartToolPart" />
        ///     class displays a tool part for working with the properties provided by the WebPart base class. An instance of the
        ///     <see
        ///         cref="T:Microsoft.SharePoint.WebPartPages.CustomPropertyToolPart" />
        ///     class displays a built-in tool part for working custom Web Part properties, as long as the custom property is of one of the types supported by that tool part. The supported types are: String, Boolean, Integer, DateTime, or Enum.
        /// </returns>
        public override ToolPart[] GetToolParts()
        {
            return new ToolPart[] {new MyWorkToolpart(), new WebPartToolPart(), new CustomPropertyToolPart()};
        }

        public static int RandomNumber(int min, int max)
        {
            lock (SyncLock)
            {
                return Random.Next(min, max);
            }
        }

        // Protected Methods (2) 

        /// <summary>
        ///     Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            var control = (MyWorkShell) Page.LoadControl(@"~/_CONTROLTEMPLATES/MyWork/MyWorkShell.ascx");

            int totalWebPartCount = 0;

            try
            {
                totalWebPartCount = WebPartManager.WebParts.Cast<object>().Count(webPart => !webPart.GetType().Name.Equals("ContextualHelpSlideOut"));
            }
            catch { }

            control.MyWorkParams = new MyWorkParams(_crossSiteUrls, _defaultGlobalView, DisplayTitle,
                                                    _myWorkSelectedLists, MyWorkSelectedLists, PerformanceMode,
                                                    Qualifier, _selectedFields, _selectedLists, SelectedLists,
                                                    totalWebPartCount, UseCentralizedSettings, Height,
                                                    _allWorkGridId, SPRibbon.GetWebPartPageComponentId(this),
                                                    DueDayFilter, NewItemIndicator, ShowToolbar);

            control.WorkingOnParams = new WorkingOnParams(_workingOnGridId);

            Controls.Add(control);
        }

        /// <summary>
        ///     The event handler for the System.Web.UI.Control.PreRender event that occurs immediately before the Web Part is rendered to the Web Part Page it is contained on.
        /// </summary>
        /// <param name="e">A System.EventArgs that contains the event data.</param>
        protected override void OnPreRender(EventArgs e)
        {
            AddContextualTab();

            string delayScript =
                new Dictionary<string, string>
                    {
                        {"webPartPageComponentId", SPRibbon.GetWebPartPageComponentId(this)},
                        {"allWorkGridId", _allWorkGridId},
                        {"workingOnGridId", _workingOnGridId}
                    }.Aggregate(DelayScript,
                                (c, p) =>
                                c.Replace(string.Format(@"{{{0}}}", p.Key),
                                          p.Value));

            ClientScriptManager clientScriptManager = Page.ClientScript;
            clientScriptManager.RegisterClientScriptBlock(GetType(), "MyWorkWebPart", delayScript);

            base.OnPreRender(e);
        }

        // Private Methods (1) 

        /// <summary>
        ///     Adds the contextual tab.
        /// </summary>
        private void AddContextualTab()
        {
            SPRibbon spRibbon = SPRibbon.GetCurrent(Page);

            if (spRibbon == null) return;

            var ribbonExtensions = new XmlDocument();

            ribbonExtensions.LoadXml(_contextualTab.Replace("{title}", DisplayTitle));
            spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ContextualTabs._children");

            ribbonExtensions.LoadXml(_contextualTabTemplate);
            spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.Templates._children");

            spRibbon.MakeTabAvailable(MANAGE_TAB_ID);
            spRibbon.MakeTabAvailable(VIEWS_TAB_ID);
        }

        #endregion Methods 
    }
}