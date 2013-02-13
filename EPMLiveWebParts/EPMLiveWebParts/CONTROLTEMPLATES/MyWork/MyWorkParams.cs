namespace EPMLiveWebParts.CONTROLTEMPLATES.MyWork
{
    public class MyWorkParams
    {
        #region Fields (18) 

        private readonly string _crossSiteUrls;
        private readonly string _defaultGlobalView;
        private readonly string _displayTitle;
        private readonly string _dueDayFilter;
        private readonly string _myWorkSelectedLists;
        private readonly string[] _myWorkSelectedLst;
        private readonly string _newItemIndicator;
        private readonly bool _performanceMode;
        private readonly string _qualifier;
        private readonly string _selectedFields;
        private readonly string _selectedLists;
        private readonly string[] _selectedLst;
        private readonly bool _showToolbar;
        private readonly int _totalWebPartCount;
        private readonly bool _useCentralizedSettings;
        private readonly string _webPartHeight;
        private readonly string _webPartId;
        private readonly string _webPartPageComponentId;

        #endregion Fields 

        #region Constructors (1) 

        public MyWorkParams(string crossSiteUrls, string defaultGlobalView, string displayTitle,
                            string myWorkSelectedLists, string[] myWorkSelectedLst, bool performanceMode,
                            string qualifier, string selectedFields, string selectedLists, string[] selectedLst,
                            int totalWebPartCount, bool useCentralizedSettings, string webPartHeight, string webPartId,
                            string webPartPageComponentId, string dueDayFilter, string newItemIndicator,
                            bool showToolbar)
        {
            _crossSiteUrls = crossSiteUrls;
            _defaultGlobalView = defaultGlobalView;
            _displayTitle = displayTitle;
            _myWorkSelectedLists = myWorkSelectedLists;
            _myWorkSelectedLst = myWorkSelectedLst;
            _performanceMode = performanceMode;
            _qualifier = qualifier;
            _selectedFields = selectedFields;
            _selectedLists = selectedLists;
            _selectedLst = selectedLst;
            _totalWebPartCount = totalWebPartCount;
            _useCentralizedSettings = useCentralizedSettings;
            _webPartHeight = webPartHeight;
            _webPartId = webPartId;
            _webPartPageComponentId = webPartPageComponentId;
            _dueDayFilter = dueDayFilter;
            _newItemIndicator = newItemIndicator;
            _showToolbar = showToolbar;
        }

        #endregion Constructors 

        #region Properties (18) 

        public string CrossSiteUrls
        {
            get { return _crossSiteUrls; }
        }

        public string DefaultGlobalView
        {
            get { return _defaultGlobalView; }
        }

        public string DisplayTitle
        {
            get { return _displayTitle; }
        }

        public string DueDayFilter
        {
            get { return _dueDayFilter; }
        }

        public string MyWorkSelectedLists
        {
            get { return _myWorkSelectedLists; }
        }

        public string[] MyWorkSelectedLst
        {
            get { return _myWorkSelectedLst; }
        }

        public string NewItemIndicator
        {
            get { return _newItemIndicator; }
        }

        public bool PerformanceMode
        {
            get { return _performanceMode; }
        }

        public string Qualifier
        {
            get { return _qualifier; }
        }

        public string SelectedFields
        {
            get { return _selectedFields; }
        }

        public string SelectedLists
        {
            get { return _selectedLists; }
        }

        public string[] SelectedLst
        {
            get { return _selectedLst; }
        }

        public bool ShowToolbar
        {
            get { return _showToolbar; }
        }

        public int TotalWebPartCount
        {
            get { return _totalWebPartCount; }
        }

        public bool UseCentralizedSettings
        {
            get { return _useCentralizedSettings; }
        }

        public string WebPartHeight
        {
            get { return _webPartHeight; }
        }

        public string WebPartId
        {
            get { return _webPartId; }
        }

        public string WebPartPageComponentId
        {
            get { return _webPartPageComponentId; }
        }

        #endregion Properties 
    }
}