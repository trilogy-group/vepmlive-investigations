using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore.ControlTemplates
{
    public partial class EPMLiveJS : UserControl
    {
        #region Fields (7) 

        protected string EPMFileVersion;
        protected string SiteId;
        protected string SiteUrl;
        protected string WebFullUrl;
        protected string WebId;
        protected string WebUrl;
        private SPWeb _spWeb;

        #endregion Fields 

        #region Methods (2) 

        // Protected Methods (2) 

        protected override void OnPreRender(EventArgs e)
        {
            ScriptLink.Register(Page, "/_layouts/epmlive/javascripts/libraries/jquery.min.js", false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _spWeb = SPContext.Current.Web;
            SiteId = _spWeb.Site.ID.ToString();
            SiteUrl = _spWeb.Site.Url;
            WebFullUrl = _spWeb.Url;
            WebId = _spWeb.ID.ToString();
            WebUrl = _spWeb.SafeServerRelativeUrl();

            string fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            if (string.IsNullOrEmpty(fileVersion) || fileVersion.Equals("1.0.0.0"))
            {
                fileVersion = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);
            }

            EPMFileVersion = fileVersion;
        }

        #endregion Methods 
    }
}