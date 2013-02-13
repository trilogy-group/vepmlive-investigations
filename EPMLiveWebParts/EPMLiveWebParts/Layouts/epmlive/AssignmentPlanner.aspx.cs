using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using EPMLiveCore;
using EPMLiveWebParts.Properties;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts.Layouts.epmlive
{
    public partial class AssignmentPlanner : LayoutsPageBase
    {
        #region Fields (7) 

        private const string INITIAL_TAB_ID = "Ribbon.AssignmentPlannerTab";
        protected readonly SPWeb SPWeb = SPContext.Current.Web;
        protected readonly string WebUrl = SPContext.Current.Web.SafeServerRelativeUrl();
        protected string ResourceIds;
        private string _debugTag;
        private DateTime _dueDate;
        private DateTime _startDate;

        #endregion Fields 

        #region Properties (8) 

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

                dataXml.Root.Add(new XElement("Params",
                                              new XElement("DateRange",
                                                           new XAttribute("StartDate",
                                                                          SPUtility.
                                                                              CreateISO8601DateTimeFromSystemDateTime(
                                                                                  _startDate)),
                                                           new XAttribute("DueDate",
                                                                          SPUtility.
                                                                              CreateISO8601DateTimeFromSystemDateTime(
                                                                                  _dueDate))),
                                              new XElement("Resources", ResourceIds)));

                return GetGridParam(dataXml);
            }
        }

        /// <summary>
        /// Gets the debug tag.
        /// </summary>
        protected string DebugTag
        {
            get { return _debugTag; }
        }

        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        /// <value>
        /// The due date.
        /// </value>
        protected string DueDate
        {
            get { return GetFormattedDate(_dueDate); }
        }

        /// <summary>
        /// Gets the grid id.
        /// </summary>
        protected string GridId
        {
            get { return UniqueID.Md5(); }
        }

        /// <summary>
        /// Gets the layout XML.
        /// </summary>
        protected string LayoutXml
        {
            get
            {
                XDocument xDocument = XDocument.Parse(Resources.AssignmentPlanner_LayoutXml);
                if (xDocument.Root != null) xDocument.Root.Add(new XElement("Id", GridId));

                return GetGridParam(xDocument);
            }
        }

        /// <summary>
        /// Gets the splash display.
        /// </summary>
        protected string SplashDisplay
        {
            get { return Page.Request.Url.ToString().ToLower().Contains("date") ? "none" : "block"; }
        }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        protected string StartDate
        {
            get { return GetFormattedDate(_startDate); }
        }

        #endregion Properties 

        #region Methods (6) 

        // Protected Methods (2) 

        /// <summary>
        /// Represents the method that handles the PreRender event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnPreRender(EventArgs e)
        {
            RegisterScripts();
            RegisterRibbon();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ResourceIds = Page.Request.Params["resources"];

            DateTime date;

            DateTime startDate = DateTime.Now.AddDays(-7);

            string value = Page.Request.Params["startdate"];
            if (!string.IsNullOrEmpty(value))
            {
                if (DateTime.TryParse(value, out date)) startDate = date;
            }

            _startDate = startDate.Date;

            DateTime dueDate = DateTime.Now.AddDays(30).Date;

            value = Page.Request.Params["duedate"];
            if (!string.IsNullOrEmpty(value))
            {
                if (DateTime.TryParse(value, out date)) dueDate = date;
            }

            _dueDate = dueDate.AddHours(23).AddMinutes(59).AddSeconds(59);

            _debugTag = string.Empty;

            string epmDebug = Page.Request.Params["epmdebug"];
            if (string.IsNullOrEmpty(epmDebug)) return;

            var keywords = new[] {"Error", "Problem", "Info", "Check", "IOError", "IO", "Cookie", "Page"};
            var info = new List<string> {"Error", "Problem"};

            foreach (string keyword in epmDebug.Split(',').Select(k => k.ToLower()))
            {
                info.AddRange(keyword.Equals("all") ? keywords : keywords.Where(k => keyword.Equals(k.ToLower())));
            }

            _debugTag = string.Format(@"debug=""{0}""", string.Join(",", info.Distinct().ToArray()));
        }

        // Private Methods (4) 

        /// <summary>
        /// Gets the formatted date.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        private string GetFormattedDate(DateTime dateTime)
        {
            return
                dateTime.ToString(
                    new CultureInfo((int) (Web.CurrentUser.RegionalSettings ?? Web.RegionalSettings).LocaleId).
                        DateTimeFormat.ShortDatePattern);
        }

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

        /// <summary>
        /// Registers the ribbon.
        /// </summary>
        private void RegisterRibbon()
        {
            var xmlDocument = new XmlDocument();
            SPRibbon spRibbon = SPRibbon.GetCurrent(Page);

            xmlDocument.LoadXml(Resources.AssignmentPlanner_ContextualTab);
            spRibbon.RegisterDataExtension(xmlDocument.FirstChild, "Ribbon.Tabs._children");

            xmlDocument.LoadXml(Resources.AssignmentPlanner_ContextualTabTemplate);
            spRibbon.RegisterDataExtension(xmlDocument.FirstChild, "Ribbon.Templates._children");

            spRibbon.Minimized = false;
            spRibbon.CommandUIVisible = true;

            if (!spRibbon.IsTabAvailable(INITIAL_TAB_ID)) spRibbon.MakeTabAvailable(INITIAL_TAB_ID);

            spRibbon.InitialTabId = INITIAL_TAB_ID;
        }

        /// <summary>
        /// Registers the scripts.
        /// </summary>
        private void RegisterScripts()
        {
            var javascripts = new[] {"treegrid/GridE.js", "javascripts/EPMLive.AssignmentPlanner.js"};

            foreach (string javascript in javascripts)
            {
                ScriptLink.Register(Page, string.Format("/_layouts/epmlive/{0}", javascript), false);
            }

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
        }

        #endregion Methods 
    }
}