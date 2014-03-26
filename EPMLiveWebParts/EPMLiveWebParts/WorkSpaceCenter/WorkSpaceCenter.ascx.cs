using EPMLiveCore.Infrastructure;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;

namespace EPMLiveWebParts.WorkSpaceCenter
{
    [ToolboxItemAttribute(false)]
    public partial class WorkSpaceCenter : WebPart
    {
        #region Fields (3)

        protected string WebUrl;
        protected string DebugTag;
        protected string SiteId;
        private const string LAYOUT_PATH = "/_layouts/15/epmlive/";

        #endregion Fields
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public WorkSpaceCenter()
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected override void OnPreRender(EventArgs e)
        {
            SPPageContentManager.RegisterStyleFile(LAYOUT_PATH + "Stylesheets/EPMLiveToolBar.min.css");

            EPMLiveScriptManager.RegisterScript(Page, new[]
            {
                "/treegrid/GridE","libraries/jquery.min","libraries/jquery-ui",
            });
            ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
        }
        protected override void CreateChildControls()
        {
            SPWeb oWeb = SPContext.Current.Web;

            string serviceUrl = ((SPContext.Current.Web.ServerRelativeUrl == "/")
                                     ? ""
                                     : SPContext.Current.Web.ServerRelativeUrl) + "/_vti_bin/Workengine.asmx";

            ScriptManager scriptManager = ScriptManager.GetCurrent(Page);

            if (scriptManager != null)
            {
                scriptManager.Services.Add(new ServiceReference(serviceUrl));
            }
            else
            {
                scriptManager = new ScriptManager();
                scriptManager.Services.Add(new ServiceReference(serviceUrl));

                Page.Form.Controls.Add(scriptManager);
            }
        }
        private bool IsInDebugMode(out string epmDebug)
        {
            epmDebug = Page.Request.Params["epmdebug"];
            return !string.IsNullOrEmpty(epmDebug);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb spWeb = SPContext.Current.Web;

            string epmDebug;
            bool inDebugMode = IsInDebugMode(out epmDebug);

            if (inDebugMode)
            {
                var keywords = new[] { "Error", "Problem", "Info", "Check", "IOError", "IO", "Cookie", "Page" };
                var info = new List<string> { "Error", "Problem" };

                foreach (string keyword in epmDebug.Split(',').Select(k => k.ToLower()))
                {
                    string kw = keyword;
                    info.AddRange(keyword.Equals("all") ? keywords : keywords.Where(k => kw.Equals(k.ToLower())));
                }

                DebugTag = string.Format(@"debug=""{0}""", string.Join(",", info.Distinct().ToArray()));
            }

            WebUrl = SPContext.Current.Web.Url;

            //Below code is required to set SiteId if we want to make workspace like workspace gallary

            //using (SPSite site = new SPSite(SPContext.Current.Site.ID))
            //{
            //    using (SPWeb web = site.OpenWeb(SPContext.Current.Web.ID))
            //    {
            //        string _templateResourceUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveTemplateGalleryURL", true, false);

            //        try
            //        {
            //            using (SPSite tsite = new SPSite(_templateResourceUrl))
            //            {
            //                using (SPWeb tweb = tsite.OpenWeb())
            //                {
            //                    SPList tlist = tweb.Lists.TryGetList("Template Gallery");
            //                    SiteId = tlist.ID.ToString();
            //                }
            //            }
            //        }
            //        catch { }
            //    }
            //}
        }
    }
}
