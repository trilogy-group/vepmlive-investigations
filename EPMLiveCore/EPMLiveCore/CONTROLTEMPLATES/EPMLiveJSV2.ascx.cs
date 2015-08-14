using System;
using System.Web.UI;
using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;

namespace EPMLiveCore.CONTROLTEMPLATES
{
    public partial class EPMLiveJSV2 : UserControl
    {
        #region Fields (5) 

        protected string Scheme;
        protected string UplandInsightId;
        ////EPML-5445
        //protected bool SupportIntegration;
        ////EPML-5445
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

            WebUrl = _spWeb.SafeServerRelativeUrl();

            try
            {
                ////EPML-5445
                //var configValue = CoreFunctions.getConfigSetting(_spWeb, "SupportIntegration");
                //SupportIntegration = !string.IsNullOrEmpty(configValue) && Convert.ToBoolean(configValue);
                ////EPML-5445
            }
            catch { }

            try
            {
                UplandInsightId = CoreFunctions.getConfigSetting(_spWeb.Site.RootWeb, "UplandInsightId");
            }
            catch { }

            Scheme = Request.Url.Scheme;
        }

        #endregion Methods 
    }
}