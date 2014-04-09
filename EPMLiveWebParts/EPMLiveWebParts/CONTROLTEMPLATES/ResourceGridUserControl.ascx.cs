using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Xml.Linq;
using EPMLiveCore;
using EPMLiveCore.Infrastructure;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;

namespace EPMLiveWebParts
{
    public partial class ResourceGridUserControl : UserControl
    {
        #region Fields (5)

        private const string LAYOUT_PATH = "/_layouts/15/epmlive/";
        protected string WcReportId = "Resource Work vs. Capacity".Md5();
        protected string WebUrl = SPContext.Current.Web.SafeServerRelativeUrl();
        private string _debugTag;
        private string _webPartHeight;
        public string _reqListId;
        public string _reqId;
        public string _reqWebId;
        SPWeb _currentWeb;

        #endregion Fields

        #region Properties (10)

        /// <summary>
        ///     Gets or sets a value indicating whether [auto focus].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [auto focus]; otherwise, <c>false</c>.
        /// </value>
        public bool AutoFocus { get; set; }

        /// <summary>
        ///     Gets a value indicating whether [current user has designer permission].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [current user has designer permission]; otherwise, <c>false</c>.
        /// </value>
        protected bool CurrentUserHasDesignerPermission
        {
            get
            {
                SPWeb theWeb = SPContext.Current.Web;
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
        ///     Gets the data XML.
        /// </summary>
        protected string DataXml
        {
            get
            {
                if (_currentWeb.IsRootWeb && string.IsNullOrEmpty(Request["listId"]) && string.IsNullOrEmpty(Request["id"]))
                {
                    return GetGridParam(XDocument.Parse(Resources.ResourceGrid_DataXml))
                        .Replace(Environment.NewLine, string.Empty).Replace(@"\t", string.Empty);
                }
                else
                {
                    SPWeb web = _currentWeb;
                    bool inheritedWeb = web.Permissions.Inherited;
                    while (inheritedWeb)
                    {
                        _currentWeb = web.ParentWeb;
                        inheritedWeb = web.Permissions.Inherited;
                    }

                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(Resources.ResourceGrid_DataXml);

                    XmlAttribute attr = doc.CreateAttribute("WebId");
                    attr.Value = web.ID.ToString();
                    doc.FirstChild.Attributes.Append(attr);

                    attr = doc.CreateAttribute("ListId");
                    attr.Value = Request["listid"];
                    doc.FirstChild.Attributes.Append(attr);

                    attr = doc.CreateAttribute("ItemId");
                    attr.Value = Request["id"];
                    doc.FirstChild.Attributes.Append(attr);

                    return GetGridParam(XDocument.Parse(doc.OuterXml)).Replace(Environment.NewLine, string.Empty).Replace(@"\t", string.Empty);
                }
            }
        }

        protected string NewFormUrl
        {
            get
            {
                SPList resourcesList = null;
                var url = string.Empty;
                _currentWeb = SPContext.Current.Web;

                if (_currentWeb.IsRootWeb && string.IsNullOrEmpty(Request["listId"]) && string.IsNullOrEmpty(Request["id"]))
                {
                    resourcesList = _currentWeb.Lists.TryGetList("Resources");
                    url = resourcesList.Forms[PAGETYPE.PAGE_NEWFORM].Url;
                }
                else
                {
                    url = "/_layouts/epmlive/BuildTeam.aspx?listid=" + Request["listid"] + "&id=" + Request["id"];
                }

                return url;
            }
        }

        /// <summary>
        ///     Gets the debug tag.
        /// </summary>
        protected string DebugTag
        {
            get { return _debugTag; }
        }

        /// <summary>
        ///     Gets the layout XML.
        /// </summary>
        protected string LayoutXml
        {
            get
            {
                XDocument xDocument = XDocument.Parse(Resources.ResourceGrid_LayoutXml);
                if (xDocument.Root != null) xDocument.Root.Add(new XElement("Id", WebPartId));

                return GetGridParam(xDocument).Replace(Environment.NewLine, string.Empty).Replace(@"\t", string.Empty);

            }
        }

        /// <summary>
        ///     Gets the max V scroll.
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
        ///     Gets a value indicating whether [PFE installed].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [PFE installed]; otherwise, <c>false</c>.
        /// </value>
        protected bool PFEInstalled
        {
            get { return SPContext.Current.Site.Features[new Guid("158c5682-d839-4248-b780-82b4710ee152")] != null; }
        }

        /// <summary>
        ///     Gets or sets the height of the web part.
        /// </summary>
        /// <value>
        ///     The height of the web part.
        /// </value>
        public string WebPartHeight
        {
            get { return _webPartHeight ?? string.Empty; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _webPartHeight = string.Format("height:{0}", value);
                }
            }
        }

        /// <summary>
        ///     Gets or sets the web part id.
        /// </summary>
        /// <value>
        ///     The web part id.
        /// </value>
        public string WebPartId { get; set; }

        /// <summary>
        ///     Gets or sets the web part qualifier.
        /// </summary>
        /// <value>
        ///     The web part qualifier.
        /// </value>
        public string WebPartQualifier { get; set; }

        /// <summary>
        /// Get/Set Ribbon Behaviour
        /// </summary>
        public int RibbonBehavior { get; set; }

        #endregion Properties

        #region Methods (4)

        // Protected Methods (2) 

        /// <summary>
        ///     Raises the <see cref="E:System.Web.UI.Control.PreRender" /> event.
        /// </summary>
        /// <param name="e">
        ///     An <see cref="T:System.EventArgs" /> object that contains the event data.
        /// </param>
        protected override void OnPreRender(EventArgs e)
        {
            _currentWeb = SPContext.Current.Web;
            _reqWebId = Convert.ToString(_currentWeb.ID);

            SPList resourcesList;

            if (_currentWeb.IsRootWeb && string.IsNullOrEmpty(Request["listId"]) && string.IsNullOrEmpty(Request["id"]))
            {
                resourcesList = _currentWeb.Lists.TryGetList("Resources");
            }
            else
            {
                resourcesList = _currentWeb.Lists.TryGetList("Team");
            }

            if (resourcesList != null)
            {
                foreach (string style in new[] { "libraries/jquery-ui" })
                {
                    SPPageContentManager.RegisterStyleFile(LAYOUT_PATH + "stylesheets/" + style + ".css");
                }

                EPMLiveScriptManager.RegisterScript(Page, new[]
                {
                    "libraries/jquery.min", "@EPM", "/treegrid/GridE", "@EPMLive.ResourceGrid"
                });

                ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            }
            else
            {
                lblError.Text = @"<b>ERROR: </b>There is no ""Resources"" list at this level.";

                pnlGrid.Visible = false;
                pnlError.Visible = true;
            }
            EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(resourcesList);
            if (string.IsNullOrEmpty(gSettings.RibbonBehavior))
                this.RibbonBehavior = 0;
            else
                this.RibbonBehavior = Convert.ToInt16(gSettings.RibbonBehavior);
        }

        /// <summary>
        ///     Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">
        ///     The <see cref="System.EventArgs" /> instance containing the event data.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            _debugTag = string.Empty;
            _reqListId = Convert.ToString(Request["listId"]);
            _reqId = Convert.ToString(Request["id"]);

            string epmDebug;
            bool inDebugMode = IsInDebugMode(out epmDebug);

            if (!inDebugMode) return;

            var keywords = new[] { "Error", "Problem", "Info", "Check", "IOError", "IO", "Cookie", "Page", "Event" };
            var info = new List<string> { "Error", "Problem" };

            foreach (string keyword in epmDebug.Split(',').Select(k => k.ToLower()))
            {
                info.AddRange(keyword.Equals("all")
                    ? keywords.Where(k => !k.Equals("Event"))
                    : keywords.Where(k => keyword.Equals(k.ToLower())));
            }

            _debugTag = string.Format(@"debug=""{0}""", string.Join(",", info.Distinct().ToArray()));
        }

        // Private Methods (2) 

        /// <summary>
        ///     Gets the grid param.
        /// </summary>
        /// <param name="dataXml">The data XML.</param>
        /// <returns></returns>
        private static string GetGridParam(XDocument dataXml)
        {
            return HttpUtility.HtmlEncode(HttpUtility.HtmlEncode(dataXml.ToString()));
        }

        private bool IsInDebugMode(out string epmDebug)
        {
            epmDebug = Page.Request.Params["epmdebug"];
            return !string.IsNullOrEmpty(epmDebug);
        }

        #endregion Methods
    }
}