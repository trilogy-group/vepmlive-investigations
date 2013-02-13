using System;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using EPMLiveCore;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts
{
    public partial class AssignmentPlannerUserControl : UserControl
    {
        #region Fields (6) 

        protected readonly SPWeb SPWeb;
        protected string EpmDebug;
        protected bool InDebugMode;
        protected string ResourceIds;
        protected string WebUrl;
        private string _webPartHeight;

        #endregion Fields 

        #region Constructors (1) 

        /// <summary>
        /// Prevents a default instance of the <see cref="AssignmentPlannerUserControl"/> class from being created.
        /// </summary>
        public AssignmentPlannerUserControl()
        {
            SPWeb = SPContext.Current.Web;
            WebUrl = SPWeb.SafeServerRelativeUrl();
        }

        #endregion Constructors 

        #region Properties (8) 

        /// <summary>
        /// Gets or sets a value indicating whether [auto focus].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [auto focus]; otherwise, <c>false</c>.
        /// </value>
        public bool AutoFocus { get; set; }

        /// <summary>
        /// Gets a value indicating whether [current user has designer permission].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [current user has designer permission]; otherwise, <c>false</c>.
        /// </value>
        protected bool CurrentUserHasDesignerPermission
        {
            get
            {
                SPWeb theWeb = SPWeb;
                Guid lockedWeb = CoreFunctions.getLockedWeb(theWeb);

                using (SPWeb configWeb = (theWeb.ID != lockedWeb
                                              ? theWeb.Site.OpenWeb(lockedWeb)
                                              : theWeb.Site.OpenWeb(theWeb.ID)))
                {
                    return configWeb.DoesUserHavePermissions(theWeb.CurrentUser.LoginName,
                                                             SPBasePermissions.AddAndCustomizePages);
                }
            }
        }

        /// <summary>
        /// Gets the data XML.
        /// </summary>
        protected string DataXml
        {
            get
            {
                XDocument dataXml = XDocument.Parse(Resources.AssignmentPlanner_DataXml);

                dataXml.Root.Add(new XElement("Params", new XElement("Resources", ResourceIds)));

                return GetGridParam(dataXml);
            }
        }

        /// <summary>
        /// Gets the layout XML.
        /// </summary>
        protected string LayoutXml
        {
            get
            {
                XDocument xDocument = XDocument.Parse(Resources.AssignmentPlanner_LayoutXml);
                if (xDocument.Root != null) xDocument.Root.Add(new XElement("Id", WebPartId));

                return GetGridParam(xDocument);
            }
        }

        /// <summary>
        /// Gets the max V scroll.
        /// </summary>
        protected int MaxVScroll
        {
            get
            {
                return !string.IsNullOrEmpty(WebPartHeight)
                           ? Convert.ToInt32(WebPartHeight.Replace("height:", string.Empty).Replace("px", string.Empty))
                           : 0;
            }
        }

        /// <summary>
        /// Gets or sets the height of the web part.
        /// </summary>
        /// <value>
        /// The height of the web part.
        /// </value>
        public string WebPartHeight
        {
            get { return _webPartHeight; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _webPartHeight = string.Format("height:{0}", value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the web part id.
        /// </summary>
        /// <value>
        /// The web part id.
        /// </value>
        public string WebPartId { get; set; }

        /// <summary>
        /// Gets or sets the web part qualifier.
        /// </summary>
        /// <value>
        /// The web part qualifier.
        /// </value>
        public string WebPartQualifier { get; set; }

        #endregion Properties 

        #region Methods (3) 

        // Protected Methods (2) 

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        protected override void OnPreRender(EventArgs e)
        {
            long ticks = DateTime.Now.Ticks;

            var javascripts = new[] {"treegrid/GridE.js", "javascripts/EPMLive.AssignmentPlanner.js"};

            foreach (string javascript in javascripts)
            {
                ScriptLink.Register(Page,
                                    string.Format("/_layouts/epmlive/{0}?v={1}", javascript,
                                                  InDebugMode ? (object) string.Empty : ticks), false);
            }

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
        }

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            EpmDebug = Page.Request.Params["epmdebug"];
            ResourceIds = Page.Request.Params["resources"];

            InDebugMode = EpmDebug != null;
        }

        // Private Methods (1) 

        /// <summary>
        /// Gets the grid param.
        /// </summary>
        /// <param name="dataXml">The data XML.</param>
        /// <returns></returns>
        private static string GetGridParam(XDocument dataXml)
        {
            return
                HttpUtility.HtmlEncode(
                    HttpUtility.HtmlEncode(dataXml.ToString().Replace(Environment.NewLine, string.Empty)));
        }

        #endregion Methods 
    }
}