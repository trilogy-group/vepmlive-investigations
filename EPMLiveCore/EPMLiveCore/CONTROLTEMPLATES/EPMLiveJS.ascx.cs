﻿using System;
using System.Web.UI;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.ControlTemplates
{
    [MdsCompliant(true)]
    public partial class EPMLiveJS : UserControl
    {
        #region Fields (8) 

        protected string Scheme;
        protected string SiteId;
        protected string SiteUrl;
        ////EPML-5445
        //protected bool SupportIntegration;
        ////EPML-5445
        protected string WebFullUrl;
        protected string WebId;
        protected string WebUrl;
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
                "jquery.multiselect.min"
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

            try
            {
                ////EPML-5445
                //var configValue = CoreFunctions.getConfigSetting(_spWeb, "SupportIntegration");
                //SupportIntegration = !string.IsNullOrEmpty(configValue) && Convert.ToBoolean(configValue);
                ////EPML-5445
            }
            catch { }

            Scheme = Request.Url.Scheme;
        }

        #endregion Methods 
    }
}