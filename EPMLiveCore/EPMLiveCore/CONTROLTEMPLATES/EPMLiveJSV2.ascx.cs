using System;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.CONTROLTEMPLATES
{
    public partial class EPMLiveJSV2 : UserControl
    {
        #region Fields (17) 

        protected string CurrentFileIsNull;
        protected string CurrentUrl;
        protected string CurrentUserId;
        protected string ItemId;
        protected string ItemTitle;
        protected string ListIconClass;
        protected string ListId;
        protected string ListTitle;
        protected string ListViewUrl;
        protected string ListViewTitle;
        protected string CurrentFileTitle;
        protected string Scheme;
        protected string SiteId;
        protected string SiteUrl;
        protected string WalkMeId;
        protected string WebFullUrl;
        protected string WebId;
        protected string WebUrl;
        private SPWeb _spWeb;

        #endregion Fields 

        #region Properties (3) 

        public bool DebugMode { get; private set; }

        public string EPMFileVersion { get; private set; }

        public string RootWebId
        {
            get
            {
                return SPContext.Current.Site.RootWeb.ID.ToString().ToLower();
            }
        }

        #endregion Properties 

        #region Methods (2) 

        // Protected Methods (2) 

        protected override void OnPreRender(EventArgs e)
        {
            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "libraries/jquery.min", "@EPM", "libraries/jquery-ui.min", "libraries/jquery.tmpl.min",
                "@libraries/jquery.cookie", "/xml2json", "/MD5", "jquery.multiselect.min", "@EPMLive.Analytics"
            });

            EPMFileVersion = EPMLiveScriptManager.FileVersion;

            DebugMode = false;

            try
            {
                string debug = Request.Params["epmdebug"];
                if ((debug ?? string.Empty).ToLower().Equals("true"))
                {
                    DebugMode = true;
                }
            }
            catch { }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SPContext spContext = SPContext.Current;

            _spWeb = spContext.Web;

            SiteId = _spWeb.Site.ID.ToString();
            SiteUrl = _spWeb.Site.Url;
            WebFullUrl = _spWeb.Url;
            WebId = _spWeb.ID.ToString();
            WebUrl = _spWeb.SafeServerRelativeUrl();
            
            ListTitle = string.Empty;
            try
            {
                ListTitle = HttpUtility.JavaScriptStringEncode(spContext.List.Title);
            }
            catch { }
            
            ListId = Guid.Empty.ToString();
            try
            {
                ListId = spContext.ListId.ToString();
            }
            catch { }

            ListViewUrl = string.Empty;
            try
            {
                ListViewUrl = spContext.ViewContext.View.Url;
            }
            catch { }

            ListViewTitle = string.Empty;
            try
            {
                ListViewTitle = HttpUtility.JavaScriptStringEncode(spContext.ViewContext.View.Title);
            }
            catch { }

            ItemId = "-1";
            try
            {
                ItemId = (spContext.Item != null) ? spContext.ItemId.ToString(CultureInfo.InvariantCulture) : "-1";
            }
            catch { }

            ItemTitle = string.Empty;
            try
            {
                ItemTitle = (spContext.Item != null) ? HttpUtility.JavaScriptStringEncode(spContext.ListItemDisplayName) : string.Empty;
            }
            catch { }

            CurrentFileIsNull = "True";
            try
            {
                CurrentFileIsNull = (spContext.File == null).ToString();
            }
            catch { }

            CurrentFileTitle = string.Empty;
            try
            {
                CurrentFileTitle = Path.GetFileName(Request.FilePath);
                if (!string.IsNullOrEmpty(CurrentFileTitle))
                {
                    CurrentFileTitle = CurrentFileTitle.Replace(".aspx", "");
                }    
            }
            catch
            {}

            ListIconClass = string.Empty;
            try
            {
                var sIcon = new GridGanttSettings(SPContext.Current.List).ListIcon;
                ListIconClass = !string.IsNullOrEmpty(sIcon) ? sIcon : "icon-square";
            }catch{}

            CurrentUserId = "-1";
            try
            {
                CurrentUserId = _spWeb.CurrentUser.ID.ToString(CultureInfo.InvariantCulture);
            }
            catch { }

            CurrentUrl = string.Empty;
            try
            {
                CurrentUrl = new Uri(new Uri(_spWeb.Url), HttpContext.Current.Request.RawUrl).AbsoluteUri;
            }
            catch { }

            try
            {
                WalkMeId = CoreFunctions.getConfigSetting(_spWeb, "EPMLiveWalkMeId");
            }
            catch { }
           

            Scheme = Request.Url.Scheme;
        }

        #endregion Methods 
    }
}