using System;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.CONTROLTEMPLATES
{
    public partial class EPMLiveHead : UserControl
    {
        #region Fields (17) 

        protected string CurrentFileIsNull;
        protected string CurrentFileTitle;
        protected string CurrentUrl;
        protected string CurrentUserId;
        protected string ItemId;
        protected string ItemTitle;
        protected string ListIconClass;
        protected string ListId;
        protected string ListTitle;
        protected string ListViewTitle;
        protected string ListViewUrl;
        protected string SiteId;
        protected string SiteUrl;
        protected string WebFullUrl;
        protected string WebId;
        protected string WebUrl;
        private SPWeb _spWeb;

        #endregion Fields 

        #region Properties (3) 

        public bool DebugMode { get; private set; }

        public string EPMLiveVersion { get; private set; }

        public string RootWebId { get; private set; }

        #endregion Properties 

        #region Methods (2) 

        // Protected Methods (2) 

        protected override void OnPreRender(EventArgs e)
        {
            EPMLiveVersion = EPMLiveScriptManager.FileVersion;

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

            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "@masterpages/uplandv5.master"
            });
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
            RootWebId = spContext.Site.RootWeb.ID.ToString().ToLower();

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
                ItemTitle = (spContext.Item != null)
                    ? HttpUtility.JavaScriptStringEncode(spContext.ListItemDisplayName)
                    : string.Empty;
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
            catch { }

            ListIconClass = string.Empty;
            try
            {
                string sIcon = new GridGanttSettings(SPContext.Current.List).ListIcon;
                ListIconClass = !string.IsNullOrEmpty(sIcon) ? sIcon : "icon-square";
            }
            catch { }

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
        }

        #endregion Methods 
    }
}