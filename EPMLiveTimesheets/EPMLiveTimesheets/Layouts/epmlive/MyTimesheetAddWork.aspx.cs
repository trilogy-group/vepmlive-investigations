using System;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;

namespace TimeSheets.Layouts.epmlive
{
    public partial class MyTimesheetAddWork : LayoutsPageBase
    {
        protected string sLayoutParam = "";
        protected string sLayoutParamShort = "";
        protected string TSUID = "";
        protected string OtherWork = "false";
        protected string NonWork = "false";
        protected string Views = "";

        protected string CurrentView = "";
        protected string CurrentViewId = "";
        protected string siteurl = "";

        protected string CurItems = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            sLayoutParam = "<GetWork TSID=\"" + Request["ID"] + "\" NonWork=\"" + Request["nonwork"] + "\" OtherWork=\"" + Request["otherwork"] + "\"/>";
            sLayoutParamShort = "<GetWork TSID=\"" + Request["ID"] + "\" NonWork=\"" + Request["nonwork"] + "\" OtherWork=\"" + Request["otherwork"] + "\"";

            sLayoutParam = System.Web.HttpUtility.HtmlEncode(System.Web.HttpUtility.HtmlEncode(sLayoutParam));
            sLayoutParamShort = System.Web.HttpUtility.HtmlEncode(sLayoutParamShort);

            TSUID = Request["ID"];

            try
            {
                if(Request["nonwork"] == "true")
                    NonWork = "true";
            }
            catch { }

            try
            {
                if(Request["otherwork"] == "true")
                    OtherWork = "true";
            }
            catch { }

            EPMLiveCore.API.ViewManager views = null;
            if(NonWork == "true")
                views = TimesheetAPI.GetNonWorkViews(Web);
            else
                views = TimesheetAPI.GetWorkViews(Web);

            Views = views.ToJSON();
            int counter = 0;

            foreach(KeyValuePair<string, Dictionary<string, string>> key in views.Views)
            {
                try
                {

                    if(key.Value["Default"].ToLower() == "true")
                    {
                        CurrentView = key.Key;
                        CurrentViewId = "V" + counter;
                    }
                }
                catch { }
                counter++;
            }

            siteurl = SPContext.Current.Web.Url;

            try
            {
                SPList lstMyWork = Web.Site.RootWeb.Lists.TryGetList("My Work");

                SortedList sl = new SortedList();

                if(lstMyWork != null)
                {
                    foreach(SPField field in lstMyWork.Fields)
                    {
                        if(field.Reorderable)
                        {

                            sl.Add(field.Title, field.InternalName);

                        }
                    }
                }

                foreach(DictionaryEntry de in sl)
                {
                    var li = new System.Web.UI.WebControls.ListItem(de.Key.ToString(), de.Value.ToString());
                    
                    if(de.Value.ToString() == "Title")
                        li.Selected = true;

                    ddlField.Items.Add(li);
                }
            }
            catch { }

            //SPSecurity.RunWithElevatedPrivileges(delegate()
            //{
            //    SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(Web.Site.WebApplication.Id));
            //    cn.Open();

            //    SqlCommand cmd = new SqlCommand("spTSGetTimesheet", cn);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@tsuid", TSUID);

            //    DataSet ds = new DataSet();
            //    SqlDataAdapter da = new SqlDataAdapter(cmd);
            //    da.Fill(ds);

            //    foreach(DataRow dr in ds.Tables[2].Rows)
            //    {

            //        CurItems += ",\"" + dr["LIST_UID"].ToString() + "." + dr["ITEM_ID"].ToString() + "\"";

            //    }

            //    cn.Close();
            //});

            ////CurItems = "[" + CurItems.Trim(',') + "]";

            try
            {
                AddJsHooks();
            }
            catch { }
        }

        private void AddJsHooks()
        {
            SPWeb rootWeb = Web.Site.RootWeb;
            string jsHook = CoreFunctions.getConfigSetting(rootWeb, "epmlive_timesheet_add_work_js_hook");

            if (string.IsNullOrEmpty(jsHook)) return;

            string[] scripts = jsHook.Split(',');

            foreach (string script in scripts)
            {
                string src = script;

                string url = rootWeb.ServerRelativeUrl;
                if (script.StartsWith("~"))
                {
                    url = Web.ServerRelativeUrl;
                    src = script.Substring(1, script.Length);
                }

                litJsHook.Text += string.Format(@"<script type=""text/javascript"" src=""{0}{1}""></script>", url, src);
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            string serviceUrl = ((Web.ServerRelativeUrl == "/")
                                     ? ""
                                     : Web.ServerRelativeUrl) + "/_vti_bin/Workengine.asmx";

            ScriptManager scriptManager = ScriptManager.GetCurrent(Page);

            if(scriptManager != null) scriptManager.Services.Add(new ServiceReference(serviceUrl));
            else
            {
                scriptManager = new ScriptManager();
                scriptManager.Services.Add(new ServiceReference(serviceUrl));

                Page.Form.Controls.Add(scriptManager);
            }
        }

        private bool BShowAllWork()
        {
            bool bDisabled = false;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(SPContext.Current.Site.ID))
                {
                    bool.TryParse(EPMLiveCore.CoreFunctions.getConfigSetting(site.RootWeb, "EPMLiveTSAllowUnassigned"), out bDisabled);
                }
            });

            return bDisabled;
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            SPRibbon ribbon = SPRibbon.GetCurrent(this.Page);

            //Prepares an XmlDocument object used to load the ribbon
            XmlDocument ribbonExtensions = new XmlDocument();

            //WorkPlanner Tab
            ribbonExtensions.LoadXml(Properties.Resources.txtMyTimesheetWork_Ribbon);
            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                "Ribbon.Tabs._children");

            ribbonExtensions.LoadXml(Properties.Resources.txtMyTimesheetWork_ViewRibbon);
            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                "Ribbon.Tabs._children");

            ribbonExtensions.LoadXml(Properties.Resources.txtMyTimesheet_Template);
            ribbon.RegisterDataExtension(ribbonExtensions.FirstChild,
                "Ribbon.Templates._children");

            ribbon.Minimized = false;
            ribbon.CommandUIVisible = true;
            const string initialTabId = "Ribbon.MyTimesheetWorkTab";

            if(!ribbon.IsTabAvailable(initialTabId))
                ribbon.MakeTabAvailable(initialTabId);

            if(!ribbon.IsTabAvailable("Ribbon.MyTimesheetWorkViewsTab"))
                ribbon.MakeTabAvailable("Ribbon.MyTimesheetWorkViewsTab");

            ribbon.InitialTabId = initialTabId;

            var manager = new SPRibbonScriptManager();

            var methodInfo = typeof(SPRibbonScriptManager).GetMethod("RegisterInitializeFunction", BindingFlags.Instance | BindingFlags.NonPublic);

            methodInfo.Invoke(manager, new object[] { Page, "InitPageComponent", "/_layouts/epmlive/MyTimesheetWorkContextualTabPageComponent.js", false, "MyTimesheetWorkPageComponent.PageComponent.initialize()" });

            var commands = new List<IRibbonCommand>();

            //commands.Add(new SPRibbonCommand("Ribbon.MyTimesheetWork.AddWork", "alert('d');", "true"));

            manager.RegisterGetCommandsFunction(Page, "getGlobalCommands", commands);
            manager.RegisterCommandEnabledFunction(Page, "commandEnabled", commands);
            manager.RegisterHandleCommandFunction(Page, "handleCommand", commands);
            //if(!ribbon.IsTabAvailable("Ribbon.Project"))
            //    ribbon.MakeTabAvailable("Ribbon.Project");

            //if(!ribbon.IsTabAvailable("Ribbon.WorkViews"))
            //    ribbon.MakeTabAvailable("Ribbon.WorkViews");

            if(Request["nonwork"] == "true")
            {
                ribbon.TrimById("Ribbon.MyTimesheetWorkViews.AllWork");
                ribbon.TrimById("Ribbon.MyTimesheetWork.ActionsGroup.Search");
            }
            else 
            {
                bool bDisable = BShowAllWork();
                if (!bDisable)
                    ribbon.TrimById("Ribbon.MyTimesheetWorkViews.AllWork");
            }
            
        }
    }
}
