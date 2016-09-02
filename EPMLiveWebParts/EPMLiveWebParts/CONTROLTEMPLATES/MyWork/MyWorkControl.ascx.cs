using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using EPMLiveCore;
using EPMLiveCore.Infrastructure;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.CONTROLTEMPLATES.MyWork
{
    public partial class MyWorkControl : UserControl
    {
        #region Fields (15)

        protected int DaysAfter;
        protected bool DaysAfterEnabled;
        protected int DaysAgo;
        protected bool DaysAgoEnabled;
        protected string DebugTag;
        protected bool IsNewItemIndicatorEnabled;
        protected string NewItemButtonLists;
        protected int NewItemIndicatorDays;
        protected string RequestedView;
        protected string RequestedViewType;
        protected bool UserHasDesignerPermission;
        protected string UserId;
        protected string WebId;
        protected string WebUrl;
        private string _webPartHeight;

        #endregion Fields

        #region Properties (20)

        protected string CompleteQuery
        {
            get { return GetQuery(XDocument.Parse(Resources.MyWorkWebPart_MyWorkCompleteQuery), WebPartId); }
        }

        public string CrossSiteUrls { get; set; }

        public string DefaultGlobalView { get; set; }

        public string DisplayTitle { get; set; }

        public string DueDayFilter { get; set; }

        public string MyWorkSelectedLists { get; set; }

        public string[] MyWorkSelectedLst { get; set; }

        public string NewItemIndicator { get; set; }

        protected string NonCompleteQuery
        {
            get
            {
                var from = new DateTime(1900, 1, 1, 0, 0, 0);
                var to = new DateTime(9998, 12, 31, 23, 59, 59);
                
                DateTime today = DateTime.Now.Date;

                if (DaysAgoEnabled)
                {
                    from = today.AddDays(-DaysAgo);
                }

                if (DaysAfterEnabled)
                {
                    to = today.AddDays(DaysAfter).AddHours(23).AddMinutes(59).AddSeconds(59);
                }

                if (DaysAgoEnabled || DaysAfterEnabled)
                {
                    if (DaysAfterEnabled && !DaysAgoEnabled && from != today)
                        from = today;
                    if (DaysAgoEnabled && !DaysAfterEnabled && to != today)
                        to = today;
                }

                string query =
                    HttpUtility.HtmlDecode(
                        HttpUtility.HtmlDecode(GetQuery(
                            XDocument.Parse(Resources.MyWorkWebPart_MyWorkNonCompleteQuery), WebPartId))) ??
                    string.Empty;

                query = query.Replace("{FromDateTime}", SPUtility.CreateISO8601DateTimeFromSystemDateTime(from));
                query = query.Replace("{ToDateTime}", SPUtility.CreateISO8601DateTimeFromSystemDateTime(to));

                XDocument xml = XDocument.Parse(query);

                xml.Root.Add(new XElement("DateRange", new XAttribute("From", from.ToString("yyyy-MM-dd HH:mm:ss")),
                    new XAttribute("To", to.ToString("yyyy-MM-dd HH:mm:ss"))));

                if (!string.IsNullOrEmpty(Request["listid"]))
                    xml.Root.Add(new XElement("ListId", Convert.ToString(Request["listid"])));

                return HttpUtility.HtmlEncode(HttpUtility.HtmlEncode(xml.ToString()));
            }
        }

        public bool PerformanceMode { get; set; }

        public string Qualifier { get; set; }

        public string SelectedFields { get; set; }

        public string SelectedLists { get; set; }

        public string[] SelectedLst { get; set; }

        public bool ShowToolbar { get; set; }

        public int TotalWebPartCount { get; set; }

        public bool UseCentralizedSettings { get; set; }

        public string WebPartHeight
        {
            get { return _webPartHeight.Replace("px", string.Empty); }
            set { _webPartHeight = value; }
        }

        public string WebPartId { get; set; }

        public string WebPartPageComponentId { get; set; }
        public string DecimalSeparator { get; private set; }
        public string GroupSeparator { get; private set; }
        public char PercentSymbol { get; private set; }

        #endregion Properties

        #region Methods (10)

        // Protected Methods (3) 

        protected override void CreateChildControls()
        {
            string serviceUrl = ((SPContext.Current.Web.ServerRelativeUrl == "/")
                ? ""
                : SPContext.Current.Web.ServerRelativeUrl) + "/_vti_bin/Workengine.asmx";

            ScriptManager scriptManager = ScriptManager.GetCurrent(Page);

            if (scriptManager != null) scriptManager.Services.Add(new ServiceReference(serviceUrl));
            else
            {
                scriptManager = new ScriptManager();
                scriptManager.Services.Add(new ServiceReference(serviceUrl));

                Page.Form.Controls.Add(scriptManager);
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            RegisterScripts();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb spWeb = SPContext.Current.Web;

            string epmDebug;
            bool inDebugMode = IsInDebugMode(out epmDebug);

            if (inDebugMode)
            {
                var keywords = new[] {"Error", "Problem", "Info", "Check", "IOError", "IO", "Cookie", "Page"};
                var info = new List<string> {"Error", "Problem"};

                foreach (string keyword in epmDebug.Split(',').Select(k => k.ToLower()))
                {
                    string kw = keyword;
                    info.AddRange(keyword.Equals("all") ? keywords : keywords.Where(k => kw.Equals(k.ToLower())));
                }

                DebugTag = string.Format(@"debug=""{0}""", string.Join(",", info.Distinct().ToArray()));
            }

            UserHasDesignerPermission = CheckForDesignerPermission();
            NewItemButtonLists = GetNewItemButtonLists();
            UserId = spWeb.CurrentUser.ID.ToString(CultureInfo.InvariantCulture);
            RequestedView = Page.Request.Params["view"];
            RequestedViewType = Page.Request.Params["viewtype"];
            WebUrl = SPContext.Current.Web.Url;
            WebId = spWeb.ID.ToString();

            LoadGridSettings();
            ConfigureRegionalSettings();
        }

        private void ConfigureRegionalSettings()
        {
            SPRegionalSettings regionalSettings = SPContext.Current.RegionalSettings;
            DecimalSeparator = regionalSettings.DecimalSeparator;
            GroupSeparator = regionalSettings.ThousandSeparator;
        }

        // Private Methods (7) 

        private static bool CheckForDesignerPermission()
        {
            SPWeb theWeb = SPContext.Current.Web;
            Guid lockedWeb = CoreFunctions.getLockedWeb(theWeb);

            using (SPWeb configWeb = (theWeb.ID != lockedWeb
                ? theWeb.Site.OpenWeb(lockedWeb)
                : theWeb.Site.OpenWeb(theWeb.ID)))
            {
                return configWeb.DoesUserHavePermissions(SPContext.Current.Web.CurrentUser.LoginName,
                    SPBasePermissions.AddAndCustomizePages);
            }
        }

        /// <summary>
        ///     Gets the config setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns></returns>
        private static string GetConfigSetting(string setting)
        {
            string configSetting;

            SPWeb theWeb = SPContext.Current.Web;
            Guid lockedWeb = CoreFunctions.getLockedWeb(theWeb);

            using (SPWeb configWeb = (theWeb.ID != lockedWeb
                ? theWeb.Site.OpenWeb(lockedWeb)
                : theWeb.Site.OpenWeb(theWeb.ID)))
            {
                configSetting = CoreFunctions.getConfigSetting(configWeb, setting);
            }

            return configSetting;
        }

        private string GetNewItemButtonLists()
        {
            SPWeb myworkWeb = SPContext.Current.Web;

            string newItemButtonLists = string.Empty;
            var newItemLists = new List<string>();

            List<myworksettings.MWList> excludedMyWorkLists =
                myworksettings.GetMyWorkListsFromDb(myworkWeb, EPMLiveCore.API.MyWork.GetArchivedWebs(myworkWeb.Site.ID));

            if (!UseCentralizedSettings)
            {
                foreach (
                    string myWorkSelectedList in
                        MyWorkSelectedLst.Where(myWorkSelectedList => !string.IsNullOrEmpty(myWorkSelectedList)))
                {
                    newItemLists.Add(myWorkSelectedList);
                    excludedMyWorkLists.RemoveAll(l => l.Name.Equals(myWorkSelectedList));
                }

                foreach (string selectedList in SelectedLst.Where(selectedList => !string.IsNullOrEmpty(selectedList))
                    )
                {
                    newItemLists.Add(selectedList);
                    excludedMyWorkLists.RemoveAll(l => l.Name.Equals(selectedList));
                }
            }
            else
            {
                SPWeb theWeb = SPContext.Current.Web;
                Guid lockedWeb = CoreFunctions.getLockedWeb(theWeb);

                using (SPWeb configWeb = (theWeb.ID != lockedWeb
                    ? theWeb.Site.OpenWeb(lockedWeb)
                    : theWeb.Site.OpenWeb(theWeb.ID)))
                {
                    myworkWeb = configWeb;

                    foreach (
                        string list in
                            CoreFunctions.getConfigSetting(configWeb, myworksettings.GeneralSettingsSelectedMyWorkLists)
                                .Split(new[] {','}).Where(list => !string.IsNullOrEmpty(list)))
                    {
                        newItemLists.Add(list);
                        excludedMyWorkLists.RemoveAll(l => l.Name.Equals(list));
                    }

                    foreach (
                        string list in
                            CoreFunctions.getConfigSetting(configWeb, myworksettings.GeneralSettingsSelectedLists)
                                .Split(new[] {','}).Where(list => !string.IsNullOrEmpty(list)))
                    {
                        newItemLists.Add(list);
                        excludedMyWorkLists.RemoveAll(l => l.Name.Equals(list));
                    }
                }
            }

            newItemLists = newItemLists.Distinct().OrderBy(l => l).ToList();

            if (newItemLists.Count > 0)
            {
                var newItemListsFormatted = new List<string>();

                foreach (string newItemList in newItemLists)
                {
                    SPList spList = myworkWeb.Lists.TryGetList(newItemList);

                    
                    if (spList == null) continue;

                    var gSettings = new GridGanttSettings(spList);

                    string rollupLists = gSettings.RollupLists;
                    bool usePopUp = gSettings.UsePopup;

                    if (string.IsNullOrEmpty(rollupLists))
                    {
                        if (spList.Hidden || !spList.DoesUserHavePermissions(SPBasePermissions.AddListItems) ||
                            gSettings.HideNewButton) continue;

                        newItemListsFormatted.Add(string.Format(@"{{Name:'{0}',ListID:'{1}',UsePopUp:'{2}',Rollup:false}}", newItemList, spList.ID, usePopUp));
                    }
                    else
                    {
                        newItemListsFormatted.Add(string.Format(@"{{Name:'{0}',ListID:'{1}',UsePopUp:'{2}',Rollup:true}}", newItemList, spList.ID, usePopUp));
                    }
                }

                newItemButtonLists = string.Join(",", newItemListsFormatted.ToArray());
            }

            return newItemButtonLists;
        }

        private string GetQuery(XDocument queryXml, string webPartId)
        {
            // ReSharper disable PossibleNullReferenceException

            XElement myWork = queryXml.Element("MyWork");

            if (!UseCentralizedSettings)
            {
                myWork.Add(new XElement("Lists", SelectedLists));
                myWork.Add(new XElement("MyWorkLists", MyWorkSelectedLists));
                myWork.Add(new XElement("Fields", SelectedFields));
                myWork.Add(new XElement("CrossSiteUrls", CrossSiteUrls));
                myWork.Add(new XElement("PerformanceMode", PerformanceMode ? "on" : "off"));
            }

            myWork.Add(new XElement("WebPart"));
            myWork.Element("WebPart").Add(new XAttribute("ID", webPartId));

            return HttpUtility.HtmlEncode(HttpUtility.HtmlEncode(queryXml.ToString()));

            // ReSharper restore PossibleNullReferenceException
        }

        private bool IsInDebugMode(out string epmDebug)
        {
            epmDebug = Page.Request.Params["epmdebug"];
            return !string.IsNullOrEmpty(epmDebug);
        }

        /// <summary>
        ///     Loads the grid settings.
        /// </summary>
        private void LoadGridSettings()
        {
            bool useDefault = true;

            bool agoFilterEnabled = false;
            int agoFilterDays = 0;
            bool afterFilterEnabled = false;
            int afterFilterDays = 0;

            XDocument resultXml;
            SPWeb web = SPContext.Current.Web;

            using (var spSite = new SPSite(web.Site.ID))
            {
                using (SPWeb spWeb = spSite.OpenWeb(web.ID))
                {
                    string requestXml =
                        new XElement("Personalization", new XAttribute("Key", "MyWork_DueFilter"),
                            new XElement("Filters",
                                new XElement("Filter", new XAttribute("Key", "SiteId"), spWeb.Site.ID)))
                            .ToString();

                    var personalization = new EPMLiveCore.API.Personalization();
                    resultXml = XDocument.Parse(personalization.Get(requestXml, spWeb));
                }
            }

            if (resultXml.Root != null)
            {
                IEnumerable<XElement> personalizations = resultXml.Root.Descendants("Personalization");
                XElement[] settings = personalizations as XElement[] ?? personalizations.ToArray();
                if (settings.Any())
                {
                    string[] filters = settings.First().Value.Split('|');

                    bool.TryParse(filters[0], out agoFilterEnabled);
                    int.TryParse(filters[1], out agoFilterDays);
                    bool.TryParse(filters[2], out afterFilterEnabled);
                    int.TryParse(filters[3], out afterFilterDays);

                    useDefault = false;
                }
            }

            if (useDefault)
            {
                string configSetting = UseCentralizedSettings
                    ? GetConfigSetting(myworksettings.GENERAL_SETTINGS_WORK_DAY_FILTERS)
                    : DueDayFilter;

                if (!string.IsNullOrEmpty(configSetting))
                {
                    string[] filters = configSetting.Split('|');

                    bool.TryParse(filters[0], out agoFilterEnabled);
                    int.TryParse(filters[1], out agoFilterDays);
                    bool.TryParse(filters[2], out afterFilterEnabled);
                    int.TryParse(filters[3], out afterFilterDays);
                }
            }

            DaysAgoEnabled = agoFilterEnabled;
            DaysAgo = agoFilterDays;
            DaysAfterEnabled = afterFilterEnabled;
            DaysAfter = afterFilterDays;

            string indicatorSetting = UseCentralizedSettings
                ? GetConfigSetting(myworksettings.GENERAL_SETTINGS_NEW_ITEM_INDICATOR)
                : NewItemIndicator;

            bool indicatorActive = true;
            int indicatorDays = 2;

            if (!string.IsNullOrEmpty(indicatorSetting))
            {
                string[] settings = indicatorSetting.Split('|');

                bool.TryParse(settings[0], out indicatorActive);
                int.TryParse(settings[1], out indicatorDays);
            }

            IsNewItemIndicatorEnabled = indicatorActive;
            NewItemIndicatorDays = indicatorDays;
        }

        private void RegisterScripts()
        {
            foreach (string style in new[] {"MyWorkWebPart.min"})
            {
                SPPageContentManager.RegisterStyleFile(LAYOUT_PATH + style + ".css");
            }

            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "libraries/jquery.min", "@EPM", "/treegrid/GridE", "/xml2json", "/MD5", "@/MyWorkWebPart"
            });

            ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
        }

        #endregion Methods

        private const string LAYOUT_PATH = "/_layouts/15/epmlive/";
    }
}