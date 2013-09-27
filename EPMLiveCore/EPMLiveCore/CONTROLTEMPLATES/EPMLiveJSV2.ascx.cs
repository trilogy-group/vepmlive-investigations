using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.CONTROLTEMPLATES
{
    public partial class EPMLiveJSV2 : UserControl
    {
        #region Fields (8) 

        protected string Scheme;
        protected string SiteId;
        protected string SiteUrl;
        protected string WalkMeId;
        protected string WebFullUrl;
        protected string WebId;
        protected string WebUrl;
        protected string ListId;
        protected string ListTitle;
        protected string ItemId;
        protected string ItemTitle;
        protected string CurrentUserId;
        protected string CurrentUrl;
        protected string ListIconClass;
        protected string ListViewUrl;
        protected string ListViewTitle;
        protected string CurrentFileIsNull;
        protected string CurrentFileTitle;
        private SPWeb _spWeb;

        #endregion Fields 

        #region Properties (2) 

        public bool DebugMode { get; private set; }

        public string EPMFileVersion { get; private set; }

        #endregion Properties 

        #region Methods (2) 

        // Protected Methods (2) 

        protected override void OnPreRender(EventArgs e)
        {
            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "libraries/jquery.min", "libraries/jquery-ui.min", "@libraries/jquery.cookie", "/xml2json", "/MD5",
                "jquery.multiselect.min", "@EPMLive.Analytics"
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
            _spWeb = SPContext.Current.Web;
            SiteId = _spWeb.Site.ID.ToString();
            SiteUrl = _spWeb.Site.Url;
            WebFullUrl = _spWeb.Url;
            WebId = _spWeb.ID.ToString();
            WebUrl = _spWeb.SafeServerRelativeUrl();
            
            ListTitle = string.Empty;
            try{ListTitle = SPContext.Current.List.Title;}catch{}
            
            ListId = Guid.Empty.ToString();
            try{ListId = SPContext.Current.ListId.ToString();}catch{}

            ListViewUrl = string.Empty;
            try{ListViewUrl = SPContext.Current.ViewContext.View.Url;}catch{}

            ListViewTitle = string.Empty;
            try { ListViewTitle = SPContext.Current.ViewContext.View.Title; }
            catch { }

            ItemId = "-1";
            try{ItemId = (SPContext.Current.Item != null) ? SPContext.Current.ItemId.ToString() : "-1";}catch{}

            ItemTitle = string.Empty;
            try { ItemTitle = (SPContext.Current.Item != null) ? SPContext.Current.ListItemDisplayName : string.Empty; }catch { }

            CurrentFileIsNull = "True";
            try { CurrentFileIsNull = (SPContext.Current.File == null).ToString(); }catch { }

            CurrentFileTitle = string.Empty;
            try { CurrentFileTitle = Path.GetFileName(Request.FilePath); }
            catch { }

            ListIconClass = string.Empty;
            try
            {
                ListIconClass = new GridGanttSettings(SPContext.Current.List).ListIcon;
            }catch{}

            CurrentUserId = "-1";
            try{CurrentUserId = SPContext.Current.Web.CurrentUser.ID.ToString();}catch{}

            CurrentUrl = string.Empty;
            try { CurrentUrl = new Uri(new Uri(SPContext.Current.Web.Url), HttpContext.Current.Request.RawUrl).AbsoluteUri; }
            catch { }

            try{WalkMeId = CoreFunctions.getConfigSetting(_spWeb, "EPMLiveWalkMeId");}catch { }
           

            Scheme = Request.Url.Scheme;
        }

        #endregion Methods 
    }
}