using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveSignals.Layouts.EPMLive
{
    public partial class Chat : LayoutsPageBase
    {
        #region Fields (1) 

        private const string JS_PATH = "/_layouts/15/epmlive/javascripts/";

        #endregion Fields 

        #region Methods (2) 

        // Protected Methods (1) 

        protected void Page_Load(object sender, EventArgs e)
        {
            string fileVersion = GetFileVersion();

            foreach (string path in new[] { "libraries/jquery.min", "jquery.signalR-1.1.3.min" }
                .Select(s => JS_PATH + s + ".js?v=" + fileVersion))
            {
                SPPageContentManager.RegisterScriptFile(Page, path, false, true, "javascript", null);
            }
        }

        // Private Methods (1) 

        private static string GetFileVersion()
        {
            string version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

            if (string.IsNullOrEmpty(version) || version.Equals("1.0.0.0"))
            {
                version = DateTime.Now.ToString("M.d.yyyy");
            }

            return version;
        }

        #endregion Methods 
    }
}