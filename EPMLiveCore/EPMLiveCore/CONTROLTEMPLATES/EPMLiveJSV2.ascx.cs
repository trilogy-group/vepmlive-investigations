using System;
using System.Configuration;
using System.Web.UI;
using EPMLiveCore.Infrastructure;
using EPMLiveCore.UsageTracking;
using Microsoft.SharePoint;
using Microsoft.Web.Hosting.Administration;
using System.Web;


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
        
        //EPML-5446: Totango Implementation
        protected bool EnableUsageTracking = false;
        protected string SiteGuid;
        protected string SiteName;
        protected string UserEmail;
        protected string UserName;
        protected string Version;
        protected string PageTitle;
        protected string ToolKitOrderNumber;
        protected string TrackingUrl = string.Empty;

        //EPML-5446
        
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

                //EPML-5446: Enable Totango
                var configValue = CoreFunctions.getConfigSetting(_spWeb, "EPMLiveEnableUsageTracking");
                EnableUsageTracking = !string.IsNullOrEmpty(configValue) && Convert.ToBoolean(configValue);

                var configValue1 = CoreFunctions.getConfigSetting(_spWeb, "ToolKitOrderNumber");
                ToolKitOrderNumber = (!String.IsNullOrEmpty(configValue1))
                    ? Convert.ToString(configValue1)
                    : string.Empty;

                //Get Site parameters
                SiteGuid = _spWeb.Site.ID.ToString();
                SiteName = _spWeb.Title;
                SPUser currentUser = SPContext.Current.Web.CurrentUser;
                UserEmail = currentUser.Email;
                UserName =HttpUtility.UrlEncode(currentUser.Name);
                Version = CoreFunctions.GetFullAssemblyVersion();

                //Get Totango service URL
                if (ConfigurationManager.AppSettings["trackingUrl"] != null)
                {
                    TrackingUrl = ConfigurationManager.AppSettings["trackingUrl"];
                }

                //EPML-5445
            }
            catch (Exception ex)
            {
                //TODO handle exception
            }

            try
            {
                UplandInsightId = CoreFunctions.getConfigSetting(_spWeb.Site.RootWeb, "UplandInsightId");
            }
            catch (Exception ex)
            {
                //TODO handle exception
            }

            Scheme = Request.Url.Scheme;
        }

        #endregion Methods 
    }
}