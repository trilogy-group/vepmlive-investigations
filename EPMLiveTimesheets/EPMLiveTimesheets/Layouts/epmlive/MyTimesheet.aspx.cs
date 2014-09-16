using System;
using EPMLiveCore;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace TimeSheets.Layouts.epmlive
{
    public partial class MyTimesheet : LayoutsPageBase
    {
        #region Methods (3) 

        // Protected Methods (2) 

        protected override void OnPreLoad(EventArgs e)
        {
            SPRibbon spRibbon = SPRibbon.GetCurrent(Page);

            /*if (spRibbon == null) return;

            var ribbonExtensions = new XmlDocument();

            ribbonExtensions.LoadXml(Properties.Resources.txtMyTimesheet_Ribbon.Replace("{title}", "My Timesheet").Replace("#language#", SPContext.Current.Web.Language.ToString()));
            spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ContextualTabs._children");

            ribbonExtensions.LoadXml(Properties.Resources.txtMyTimesheet_Template);
            spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.Templates._children");


            //            ribbonExtensions = new XmlDocument();
            //            ribbonExtensions.LoadXml(@"<Label
            //						Id=""Ribbon.Timesheet.ActionsGroup.StatusLabel2""
            //						Sequence=""11""
            //						Command=""Ribbon.MyTimesheet.StatusLabel1""
            //						LabelText=""" + sStatus + @"""
            //                        Image16by16=""/_layouts/epmlive/images/tss_" + sStatus + @".png""
            //						TemplateAlias=""oM""
            //						/> ");
            //            spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.MyTimesheet.ActionsGroup.Controls._children");
            string sUserId = "";

            if (!string.IsNullOrEmpty(Page.Request["Delegate"]))
            {
                SPUser user = TimesheetAPI.GetUser(SPContext.Current.Web, Page.Request["Delegate"]);
                sUserId = user.ID.ToString();
            }


            DataTable dtTsDelegates = EPMLiveCore.API.APITeam.GetResourcePool("<Resources FilterField=\"TimesheetDelegates\" FilterFieldValue=\"" + SPContext.Current.Web.CurrentUser.Name + "\" Columns=\"\"/>", SPContext.Current.Web);
            string sCurrentDelegate = "";
            string sDelegates = "";
            
            foreach (DataRow dr in dtTsDelegates.Rows)
            {
                if (sUserId == dr["SPID"].ToString())
                    sCurrentDelegate = dr["Title"].ToString();

                sDelegates += dr["SPID"].ToString() + "|" + dr["Title"].ToString() + "^";
            }

            sDelegates = sDelegates.Trim('^');

            if (sDelegates == "")
            {
                spRibbon.TrimById("Ribbon.MyTimesheet.DelegateGroup");
            }


            if (sCurrentDelegate != "")
            {
                ribbonExtensions = new XmlDocument();
                ribbonExtensions.LoadXml(@"<Label
						Id=""Ribbon.Timesheet.DelegateGroup.CurrentDelegateLabel1""
						Sequence=""20""
						Command=""Ribbon.MyTimesheet.CurrentDelegate""
						LabelText=""Current Delegate:""
						TemplateAlias=""oM""
						/> ");
                spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.MyTimesheet.DelegateGroup.Controls._children");


                ribbonExtensions = new XmlDocument();
                ribbonExtensions.LoadXml(@"<Label
						Id=""Ribbon.Timesheet.DelegateGroup.CurrentDelegateLabel2""
						Sequence=""20""
						Command=""Ribbon.MyTimesheet.CurrentDelegate""
						LabelText=""" + sCurrentDelegate + @"""
						TemplateAlias=""oM""
						/> ");
                spRibbon.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.MyTimesheet.DelegateGroup.Controls._children");
            }*/
            spRibbon.MakeTabAvailable("Ribbon.MyTimesheetTab");
            spRibbon.MakeTabAvailable("Ribbon.MyTimesheetViewsTab");
            //spRibbon.InitialTabId = "Ribbon.MyTimesheetTab";

            spRibbon.Minimized = false;
            spRibbon.CommandUIVisible = true;
            base.OnPreRender(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AddJsHooks();
        }

        // Private Methods (1) 

        private void AddJsHooks()
        {
            SPWeb rootWeb = Web.Site.RootWeb;
            string jsHook = CoreFunctions.getConfigSetting(rootWeb, "epmlive_timesheet_js_hook");

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

        #endregion Methods 
    }
}