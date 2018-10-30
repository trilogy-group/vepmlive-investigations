using System;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Serialization;
using EPMLiveCore;
using EPMLiveCore.API;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using TimeSheets.DAO;

namespace TimeSheets
{
    [ToolboxData("<{0}:MyTimesheet runat=server></{0}:MyTimesheet>")]
    [Guid("8A88ACAE-8991-4EBD-8D39-DA39769FBA88")]
    [XmlRoot(Namespace = "MyTimesheet")]
    public class MyTimesheet : Microsoft.SharePoint.WebPartPages.WebPart, IWebPartPageComponentProvider
    {
        private const string InitialTabId = "Ribbon.MyTimesheetTab";
        private const string PeriodIdColumn = "period_id";

        private readonly MyTimesheetProperties properties = new MyTimesheetProperties();

        private TimeDebug timeDebug;

        protected override void CreateChildControls()
        {
            timeDebug.AddTimer();
            properties.Act = new Act(SPContext.Current.Web);
            properties.Activation = properties.Act.CheckFeatureLicense(ActFeature.Timesheets);

            if (properties.Activation != 0)
            {
                return;
            }

            InitializeMenu();

            TryGetPeriodIdAndUserIdFromRequest();

            var web = SPContext.Current.Web;

            LoadData(web);

            InitializeDataAndLayoutParams();

            LoadDelegates(web);

            InitializeScriptManager();

            properties.Views = TimesheetAPI.GetViews(web);

            timeDebug.StopTimer();
        }

        private void InitializeMenu()
        {
            if (SPContext.Current.ViewContext.View != null)
            {
                try
                {
                    typeof(ListTitleViewSelectorMenu).GetField("m_wpSingleInit", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Page.FindControl("ctl00$PlaceHolderPageTitleInTitleArea$ctl01$ctl00").Controls[1], true);
                }
                catch (Exception e)
                {
                    Trace.TraceWarning("Could not set value of ListTitleViewSelectorMenu.m_wpSingleInit field: {0}", e);
                }
                try
                {
                    typeof(ListTitleViewSelectorMenu).GetField("m_wpSingle", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Page.FindControl("ctl00$PlaceHolderPageTitleInTitleArea$ctl01$ctl00").Controls[1], true);
                }
                catch (Exception e)
                {
                    Trace.TraceWarning("Could not set value of ListTitleViewSelectorMenu.m_wpSingle field: {0}", e);
                }
            }
        }

        private void TryGetPeriodIdAndUserIdFromRequest()
        {
            try
            {
                properties.PeriodId = Page.Request["NewPeriod"].ToString();
            }
            catch (Exception e)
            {
                Trace.TraceWarning("Could not get value of NewPeriod parameter: {0}", e);
            }
            try
            {
                properties.DelegateId = Page.Request["Delegate"].ToString();
            }
            catch (Exception e)
            {
                Trace.TraceWarning("Could not get value of Delegate parameter: {0}", e);
            }
            properties.UserId = GetUserId();
        }

        private void LoadData(SPWeb web)
        {
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                properties.Settings = new TimesheetSettings(web);

                using (var repository = new MyTimesheetRepository(CoreFunctions.getConnectionString(web.Site.WebApplication.Id)))
                {
                    var periods = repository.GetPeriodsForSite(web.Site.ID);

                    SetCurrentPeriodIfPresent(periods);

                    if (periods.Rows.Count > 0)
                    {
                        if (properties.PeriodId == string.Empty)
                        {
                            SetPeriodValuesFromCurrentOrLastPeriod(periods);
                        }
                        else
                        {
                            var period = periods.Select($"period_id='{properties.PeriodId}'");
                            if (period.Length > 0)
                            {
                                properties.PeriodName = CreatePeriodName(period[0]);
                                try
                                {
                                    if (period[0]["curPeriod"].ToString() == "1")
                                    {
                                        properties.IsCurrentTimesheetPeriod = true;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Trace.TraceWarning("Could not get value of curPeriod: {0}", e);
                                }
                            }
                            else
                            {
                                SetPeriodValuesFromCurrentOrLastPeriod(periods);
                            }
                        }

                        SetPreviousAndNextPeriodValues(periods);
                        properties.Notes = properties.Settings.AllowNotes.ToString().ToLower();
                        properties.TypeObject = "{" + repository.GetTypes(web.Site.ID, properties).Trim(',') + "}";
                        SetColumnsAndDataColumns(TimesheetAPI.GetPeriodDaysArray(repository.Connection, properties.Settings, web, properties.PeriodId));

                        if (properties.GridType == 0)
                        {
                            var user = TimesheetAPI.GetUser(web, properties.DelegateId);
                            repository.SetStatus(web.Site.ID, user.LoginName, properties);
                        }
                        else
                        {
                            properties.IsLocked = true;
                        }
                        properties.HasPeriods = true;
                    }
                }
            });
        }

        private void SetCurrentPeriodIfPresent(DataTable periods)
        {
            var currentPeriod = periods.Select("CurPeriod='1'");
            if (currentPeriod.Length > 0)
            {
                properties.CurrentPeriodId = int.Parse(currentPeriod[0][PeriodIdColumn].ToString());
                properties.CurrentPeriodName = CreatePeriodName(currentPeriod[0]);
            }
        }

        private void SetPeriodValuesFromCurrentOrLastPeriod(DataTable periods)
        {
            var period = periods.Select("CurPeriod='1'");
            if (period.Length > 0)
            {
                properties.PeriodId = period[0][PeriodIdColumn].ToString();
                properties.PeriodName = CreatePeriodName(period[0]);
                properties.IsCurrentTimesheetPeriod = true;
            }
            else
            {
                properties.PeriodId = periods.Rows[periods.Rows.Count - 1][PeriodIdColumn].ToString();
                properties.PeriodName = CreatePeriodName(periods.Rows[periods.Rows.Count - 1]);
            }
        }

        private void SetPreviousAndNextPeriodValues(DataTable periods)
        {
            var previousPeriod = string.Empty;
            var isNext = false;
            var allPeriods = new StringBuilder();

            foreach (DataRow period in periods.Rows)
            {
                allPeriods.Append($",{period[PeriodIdColumn].ToString()}|{CreatePeriodName(period)}");

                if (isNext)
                {
                    isNext = false;

                    properties.NextPeriodId = int.Parse(period[PeriodIdColumn].ToString());
                }

                if (period[PeriodIdColumn].ToString() == properties.PeriodId)
                {
                    if (previousPeriod != string.Empty)
                    {
                        properties.PreviousPeriodId = int.Parse(previousPeriod);
                    }
                    isNext = true;
                }

                previousPeriod = period[PeriodIdColumn].ToString();
            }

            properties.PeriodList = allPeriods.ToString().Trim(',');
        }

        private string CreatePeriodName(DataRow period)
        {
            var periodStart = ((DateTime)period["period_start"]).ToShortDateString();
            var periodEnd = ((DateTime)period["period_end"]).ToShortDateString();
            return $"{periodStart} - {periodEnd}";
        }

        private void SetColumnsAndDataColumns(ArrayList periods)
        {
            var columnsBuilder = new StringBuilder();
            var dataColumnsBuilder = new StringBuilder();
            foreach (DateTime startDate in periods)
            {
                columnsBuilder.Append($"\"P{startDate.Ticks}\": true,");
                dataColumnsBuilder.Append($"\"P{startDate.Ticks}\": \"{properties.Settings.DayDef.Split('|')[(int)startDate.DayOfWeek * 3 + 1]}|{properties.Settings.DayDef.Split('|')[(int)startDate.DayOfWeek * 3 + 2]}\",");
            }

            properties.Columns = "{" + columnsBuilder.ToString().Trim(',') + "}";
            properties.DataColumns = "{" + dataColumnsBuilder.ToString().Trim(',') + "}";
        }

        private void InitializeDataAndLayoutParams()
        {
            properties.DataParam = $"<Param GridId=\"{properties.FullGridId}\" Period=\"{properties.PeriodId}\" UserId=\"{properties.DelegateId}\"/>";
            properties.LayoutParam = $"<Param GridId=\"{properties.FullGridId}\" Period=\"{properties.PeriodId}\" UserId=\"{properties.DelegateId}\" Editable=\"{properties.Editable}\" GridType=\"{properties.GridType}\"/>";

            properties.DataParam = HttpUtility.HtmlEncode(HttpUtility.HtmlEncode(properties.DataParam));
            properties.LayoutParam = HttpUtility.HtmlEncode(HttpUtility.HtmlEncode(properties.LayoutParam));
        }

        private void LoadDelegates(SPWeb web)
        {
            const string spidColumn = "SPID";
            const string titleColumn = "Title";

            var delegatesBuilder = new StringBuilder();
            using (var users = APITeam.GetResourcePool($"<Resources FilterField=\"TimesheetDelegates\" FilterFieldValue=\"{web.CurrentUser.Name}\" ><Columns>SimpleColumns</Columns></Resources>", web))
            {
                foreach (DataRow user in users.Rows)
                {
                    if (properties.DelegateId == user[spidColumn].ToString())
                    {
                        properties.CurrentDelegate = user[titleColumn].ToString();
                    }

                    delegatesBuilder.Append($"{user[spidColumn].ToString()}|{user[titleColumn].ToString()}^");
                }
            }
            properties.Delegates = delegatesBuilder.ToString().Trim('^');
        }

        private void InitializeScriptManager()
        {
            var serviceUrl = $"{GetRelativeUrl()}/_vti_bin/Workengine.asmx";
            var scriptManager = ScriptManager.GetCurrent(Page) ?? new ScriptManager();

            scriptManager.Services.Add(new ServiceReference(serviceUrl));
            Page.Form.Controls.Add(scriptManager);
        }

        private string GetRelativeUrl()
        {
            return SPContext.Current.Web.ServerRelativeUrl == "/"
                ? string.Empty
                : SPContext.Current.Web.ServerRelativeUrl;
        }

        protected override void OnInit(EventArgs e)
        {
            timeDebug = new TimeDebug("Timesheet", Page.Request["debug"]);
            if (Page.Request["Approvals"] == "true")
            {
                properties.GridType = 1;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            properties.FullGridId = ZoneIndex + ZoneID;
        }

        private string GetViews()
        {
            foreach (var key in properties.Views.Views)
            {
                if (key.Key == "Default View" && properties.Views.Views.Count == 1)
                {
                    return "{'iconClass': '','text': 'My Timesheet','events': [{'eventName': 'click','function': function () { location.href=window.epmLive.currentWebUrl + '/_layouts/15/epmlive/mytimesheet.aspx?Approvals=true'; }}]}";
                }
            }
            return string.Empty;
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            timeDebug.AddTimer();

            if (SPContext.Current.ViewContext.View != null)
            {
                SetPartsVisibility();
            }

            if (properties.Activation != 0)
            {
                output.Write(properties.Act.translateStatus(properties.Activation));
                return;
            }

            if (!properties.HasPeriods)
            {
                output.WriteLine("There are no periods setup for this TimeSheet. Please contact your system administrator");
                return;
            }

            properties.CanEditViews = SPContext.Current.Web.DoesUserHavePermissions(SPBasePermissions.ManageWeb);

            SetCurrentViewValues();

            var url = SPContext.Current.Web.Url;
            if (url == "/")
            {
                url = string.Empty;
            }
            var currentUrl = CreateCurrentUrl();
            properties.Url = url;
            properties.CurrentUrl = currentUrl;
            properties.RelativeUrl = GetRelativeUrl();
            properties.Qualifier = Qualifier;

            var renderer = new MyTimesheetRenderer(output, properties);
            renderer.RenderStyles();
            renderer.RenderVariablesInitScript();
            renderer.RenderGrid();
            renderer.RenderFooter();
            renderer.RenderScriptWithFunctions();

            timeDebug.StopTimer();
            timeDebug.WriteTimers(output);
        }

        private void SetPartsVisibility()
        {
            foreach (WebPart part in WebPartManager.WebParts)
            {
                try
                {
                    if (part.ToString() == "Microsoft.SharePoint.WebPartPages.XsltListViewWebPart"
                        || part.ToString() == "Microsoft.SharePoint.WebPartPages.ListViewWebPart")
                    {
                        part.Visible = false;
                    }
                }
                catch (Exception e)
                {
                    Trace.TraceWarning("Could not read part type: {0}", e);
                }
            }
        }

        private void SetCurrentViewValues()
        {
            var counter = 0;
            var IsDefaultAvailable = false;

            foreach (var key in properties.Views.Views)
            {
                var isDefault = false;
                IsDefaultAvailable = bool.TryParse(key.Value["Default"], out isDefault);
                if (IsDefaultAvailable)
                {
                    if (isDefault)
                    {
                        properties.CurrentView = key.Key;
                        properties.CurrentViewId = "V" + counter;
                    }
                }
                else
                {
                    Trace.TraceWarning("Could not read Default value");
                }
                counter++;
            }
            if (!IsDefaultAvailable)
            {
                counter = 0;
                foreach (var key in properties.Views.Views)
                {
                    properties.CurrentView = key.Key;
                    properties.CurrentViewId = "V" + counter;
                    counter++;
                }
            }
        }

        private string CreateCurrentUrl()
        {
            var currentUrl = Page.Request.RawUrl.ToString();

            if (currentUrl.Contains("?"))
            {
                currentUrl = currentUrl.Substring(0, currentUrl.IndexOf("?") + 1);
            }

            var currentUrlBuilder = new StringBuilder(currentUrl);
            foreach (string key in Page.Request.QueryString.AllKeys)
            {
                if (!key.ToString().Equals("newperiod", StringComparison.OrdinalIgnoreCase) &&
                    !key.ToString().Equals("delegate", StringComparison.OrdinalIgnoreCase))
                {
                    currentUrlBuilder.Append($"{key}={Page.Request.QueryString[key]}&");
                }
            }
            return currentUrlBuilder.ToString().Trim('&').Trim('?');
        }

        private string GetUserId()
        {
            if (!string.IsNullOrWhiteSpace(properties.DelegateId))
            {
                var user = TimesheetAPI.GetUser(SPContext.Current.Web, properties.DelegateId);
                return user.ID.ToString();
            }
            return string.Empty;
        }

        protected override void OnPreRender(EventArgs e)
        {
            timeDebug.AddTimer();
            if (properties.HasPeriods)
            {
                if (properties.GridType == 0)
                {
                    AddContextualTab();

                    var delayScript = DelayScript
                        .Replace("{webPartPageComponentId}", SPRibbon.GetWebPartPageComponentId(this))
                        .Replace("{TSOBJECT}", "TSObject" + properties.FullGridId);
                    ClientScriptManager clientScriptManager = Page.ClientScript;
                    clientScriptManager.RegisterClientScriptBlock(GetType(), "MyTimesheet", delayScript);
                }
                CssRegistration.Register("/_layouts/epmlive/MyTimesheet.css");
                CssRegistration.Register("/_layouts/epmlive/modal/modal.css");

                ScriptLink.Register(Page, "/_layouts/epmlive/modal/modal.js", false);
                ScriptLink.Register(Page, "/_layouts/epmlive/dhtml/xgrid/dhtmlxcommon.js", false);

                EPMLiveCore.Infrastructure.EPMLiveScriptManager.RegisterScript(Page, new[]
                {
                    "/treegrid/GridE", "MyTimesheet"
                });

                ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
            }
            base.OnPreRender(e);
            timeDebug.StopTimer();
        }

        private void AddContextualTab()
        {
            var ribbon = SPRibbon.GetCurrent(Page);

            if (ribbon == null)
            {
                return;
            }

            var ribbonExtensions = new XmlDocument();

            ribbonExtensions.LoadXml(Properties.Resources.txtMyTimesheet_Ribbon.Replace("{title}", DisplayTitle).Replace("#language#", SPContext.Current.Web.Language.ToString()));
            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ContextualTabs._children");

            ribbonExtensions.LoadXml(Properties.Resources.txtMyTimesheet_Template);
            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.Templates._children");

            if (properties.Delegates == string.Empty)
            {
                ribbon.TrimById("Ribbon.MyTimesheet.DelegateGroup");
            }

            if (properties.CurrentDelegate != string.Empty)
            {
                ribbonExtensions = new XmlDocument();
                ribbonExtensions.LoadXml(@"<Label
                        Id=""Ribbon.Timesheet.DelegateGroup.CurrentDelegateLabel1""
                        Sequence=""20""
                        Command=""Ribbon.MyTimesheet.CurrentDelegate""
                        LabelText=""Current Delegate:""
                        TemplateAlias=""oM""
                        /> ");
                ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.MyTimesheet.DelegateGroup.Controls._children");


                ribbonExtensions = new XmlDocument();
                ribbonExtensions.LoadXml($@"<Label
                        Id=""Ribbon.Timesheet.DelegateGroup.CurrentDelegateLabel2""
                        Sequence=""20""
                        Command=""Ribbon.MyTimesheet.CurrentDelegate""
                        LabelText=""{properties.CurrentDelegate}""
                        TemplateAlias=""oM""
                        /> ");
                ribbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.MyTimesheet.DelegateGroup.Controls._children");
            }

            if (IsApprovalDisabled())
            {
                ribbon.TrimById("Ribbon.MyTimesheet.Approvals.TM");
            }
        }

        private bool IsApprovalDisabled()
        {
            var disabled = false;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (var site = new SPSite(SPContext.Current.Site.ID))
                {
                    bool.TryParse(CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveTSDisableApprovals"), out disabled);
                }
            });

            return disabled;
        }

        public string DelayScript
        {
            get
            {
                if (properties.GridType == 0)
                {
                    return Properties.Resources.txtMyTimesheet_DelayScript;
                }

                return string.Empty;
            }
        }

        public WebPartContextualInfo WebPartContextualInfo
        {
            get
            {
                if (properties.GridType == 0)
                {
                    var webPartRibbonContextualGroup = new WebPartRibbonContextualGroup()
                    {
                        Id = "Ribbon.MyTimesheetContextualTabGroup",
                        Command = "MyTimesheetContextualTab.EnableContextualGroup",
                        VisibilityContext = "MyTimesheetContextualTab.CustomVisibilityContext"
                    };
                    var webPartRibbonTab = new WebPartRibbonTab()
                    {
                        Id = InitialTabId,
                        VisibilityContext = "MyTimesheetContextualTab.CustomVisibilityContext"
                    };

                    var webPartRibbonTab2 = new WebPartRibbonTab()
                    {
                        Id = "Ribbon.MyTimesheetViewsTab",
                        VisibilityContext = "MyTimesheetContextualTab.CustomVisibilityContext"
                    };

                    var webPartContextualInfo = new WebPartContextualInfo();
                    webPartContextualInfo.ContextualGroups.Add(webPartRibbonContextualGroup);
                    webPartContextualInfo.Tabs.Add(webPartRibbonTab);
                    webPartContextualInfo.Tabs.Add(webPartRibbonTab2);
                    webPartContextualInfo.PageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                    return webPartContextualInfo;
                }

                return null;
            }
        }
    }
}
