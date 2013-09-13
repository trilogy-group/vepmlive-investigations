﻿using System;
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
        protected string ItemId;
        protected string CurrentUserId;
        protected string CurrentUrl;
        protected string ListIconClass;
        protected string ListViewUrl;
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
            ListId = Guid.Empty.ToString();
            try
            {
                if (!(SPContext.Current.List is SPDocumentLibrary))
                {
                    ListId = SPContext.Current.ListId.ToString();
                }
            }
            catch{}
            ListViewUrl = string.Empty;
            try
            {
                ListViewUrl = SPContext.Current.ViewContext.View.Url;
            }catch{}
            ListIconClass = string.Empty;
            try
            {
                ListIconClass = new GridGanttSettings(SPContext.Current.List).ListIcon;
            }
            catch{}
            ItemId = "-1";
            try
            {
                if (!(SPContext.Current.List is SPDocumentLibrary) && string.IsNullOrEmpty(ListViewUrl))
                {
                    ItemId = SPContext.Current.ItemId.ToString();
                }
            }
            catch
            {
            }
            CurrentUserId = "-1";
            try
            {
                CurrentUserId = SPContext.Current.Web.CurrentUser.ID.ToString();
            }
            catch
            {
            }
            CurrentUrl = string.Empty;
            try
            {
                CurrentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            }
            catch{}

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