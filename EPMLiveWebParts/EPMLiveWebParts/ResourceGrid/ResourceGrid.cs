using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Serialization;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint.WebControls;
using WebPart = Microsoft.SharePoint.WebPartPages.WebPart;

namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:ResourceGrid runat=server></{0}:ResourceGrid>")]
    [Guid("F9865C7C-CD51-4A9E-B866-E7E0E5E8B62A")]
    [XmlRoot(Namespace = "ResourceGrid")]
    public class ResourceGrid : WebPart, IWebPartPageComponentProvider
    {
        #region Fields (6) 

        private const string ASCX_PATH = @"~/_CONTROLTEMPLATES/ResourceGridUserControl.ascx";
        private const string MANAGE_TAB = "Ribbon.ResourceGridTab";
        private const string VIEWS_TAB = "Ribbon.ResourceGridViewTab";
        private const string VISIBILITY_CONTEXT = "ResourceGridContextualTab.CustomVisibilityContext";
        private readonly string _contextualTab = Resources.ResourceGrid_ContextualTab;
        private readonly string _contextualTabTemplate = Resources.ResourceGrid_ContextualTabTemplate;

        #endregion Fields 

        #region Properties (1) 

        /// <summary>
        /// Gets the delay script.
        /// </summary>
        public string DelayScript
        {
            get { return Resources.ResourceGrid_DelayScript; }
        }

        #endregion Properties 

        #region Methods (2) 

        // Protected Methods (1) 

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            string webPartId = UniqueID.Md5();

            WebPartManager currentWebPartManager = WebPartManager.GetCurrentWebPartManager(Page);

            if (currentWebPartManager != null && currentWebPartManager.DisplayMode != WebPartManager.DesignDisplayMode &&
                currentWebPartManager.DisplayMode != WebPartManager.EditDisplayMode)
            {
                AddContextualTab();

                ClientScriptManager clientScriptManager = Page.ClientScript;

                string script = DelayScript
                    .Replace("{webPartPageComponentId}", SPRibbon.GetWebPartPageComponentId(this))
                    .Replace("{gridId}", webPartId);

                clientScriptManager.RegisterClientScriptBlock(GetType(), "ResourceGridWebPart", script);
            }

            var control = (ResourceGridUserControl) Page.LoadControl(ASCX_PATH);

            control.WebPartId = webPartId;
            control.AutoFocus = WebPartManager.WebParts.Count == 1;
            control.WebPartQualifier = Qualifier;
            control.WebPartHeight = Height;

            Controls.Add(control);
        }

        // Private Methods (1) 

        /// <summary>
        /// Adds the contextual tab.
        /// </summary>
        private void AddContextualTab()
        {
            SPRibbon spRibbon = SPRibbon.GetCurrent(Page);

            if (spRibbon == null) return;

            var ribbonExtensions = new XmlDocument();

            ribbonExtensions.LoadXml(_contextualTab.Replace("{title}", DisplayTitle));
            spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ContextualTabs._children");

            ribbonExtensions.LoadXml(_contextualTabTemplate);
            spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.Templates._children");

            spRibbon.Minimized = false;
            spRibbon.CommandUIVisible = true;

            if (!spRibbon.IsTabAvailable(MANAGE_TAB))
                spRibbon.MakeTabAvailable(MANAGE_TAB);
        }

        #endregion Methods 

        #region Implementation of IWebPartPageComponentProvider

        /// <summary>
        /// Gets the web part contextual info.
        /// </summary>
        public WebPartContextualInfo WebPartContextualInfo
        {
            get
            {
                WebPartManager currentWebPartManager = WebPartManager.GetCurrentWebPartManager(Page);

                if (currentWebPartManager == null ||
                    currentWebPartManager.DisplayMode == WebPartManager.DesignDisplayMode ||
                    currentWebPartManager.DisplayMode == WebPartManager.EditDisplayMode)
                {
                    return new WebPartContextualInfo();
                }

                var webPartContextualInfo = new WebPartContextualInfo();

                var webPartRibbonContextualGroup = new WebPartRibbonContextualGroup
                                                       {
                                                           Id = "Ribbon.ResourceGridContextualTabGroup",
                                                           Command = "ResourceGridContextualTab.EnableContextualGroup",
                                                           VisibilityContext = VISIBILITY_CONTEXT
                                                       };

                webPartContextualInfo.Tabs.Add(new WebPartRibbonTab
                                                   {
                                                       Id = MANAGE_TAB,
                                                       VisibilityContext = VISIBILITY_CONTEXT
                                                   });

                webPartContextualInfo.Tabs.Add(new WebPartRibbonTab
                                                   {
                                                       Id = VIEWS_TAB,
                                                       VisibilityContext = VISIBILITY_CONTEXT
                                                   });

                webPartContextualInfo.ContextualGroups.Add(webPartRibbonContextualGroup);

                webPartContextualInfo.PageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                return webPartContextualInfo;
            }
        }

        #endregion
    }
}