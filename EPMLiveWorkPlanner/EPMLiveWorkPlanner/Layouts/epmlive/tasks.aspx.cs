using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Xml;

namespace EPMLiveWorkPlanner
{
    public partial class tasks : LayoutsPageBase
    {
        protected string projectName = "";
        protected string viewList = "";
        protected string currentView = "";
        protected string currentViewGuid = "";
        protected string autoCalc = "true";
        protected string columnCalculations = "";
        protected string defaultValues = "";
        protected string minValues = "";
        protected string maxValues = "";
        protected string listId = "";
        protected string SiteUrl = "";
        protected string pcURL = "";
        protected Panel pnlMain;
        protected bool showPlanner;
        protected Panel pnlExpire;
        protected Panel pnlToolbar;
        protected Label lblExpire;
        protected string lastBaseline;
        protected Panel pnlFileToolbar;
        protected Panel pnlEditToolbar;
        protected Panel pnlResourceToolbar;
        protected Panel pnlProjectServer;
        protected string resUrl;
        protected string strDateFormat;
        protected string sUrl;
        protected string projectEditUrl;

        protected int nonwork = 0;
        protected string workdays;

        protected string useResourcePool = "false";

        protected bool hasFilters = false;
        protected bool disableFilters = false;

        SPList lstProjectCenter;
        SPList lstTaskCenter;
        string wpFields;

        protected string webId;
        protected string siteId;

        private void createToolbar(SPWeb web)
        {
            LiteralControl sep = new LiteralControl("<TD class=ms-separator></td>");

            ToolBarButton toolbuttonGrouping = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            toolbuttonGrouping.Text = "";
            toolbuttonGrouping.ImageUrl = "../_layouts/images/NEWITEM.gif";
            toolbuttonGrouping.OnClientClick = "addRow();(arguments[0]||event).cancelBubble=true;";
            toolbuttonGrouping.NavigateUrl = "";

            ToolBarButton tbView = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            tbView.Text = "";
            tbView.ImageUrl = "../_layouts/images/DETAIL.gif";
            tbView.OnClientClick = "Javascript:viewItem();";
            tbView.NavigateUrl = "";
            tbView.ToolTip = "View";

            ToolBarButton tbEdit = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            tbEdit.Text = "";
            tbEdit.ImageUrl = "../_layouts/images/EDIT.gif";
            tbEdit.OnClientClick = "Javascript:editItem();";
            tbEdit.NavigateUrl = "";
            tbEdit.ToolTip = "Edit";

            ToolBarButton tbDelete = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            tbDelete.Text = "";
            tbDelete.ImageUrl = "../_layouts/epmlive/images/delete.gif";
            tbDelete.OnClientClick = "Javascript:deleteRow();";
            tbDelete.NavigateUrl = "";
            tbDelete.ToolTip = "Delete";

            ToolBarButton tbOutdent = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            tbOutdent.Text = "";
            tbOutdent.ImageUrl = "../_layouts/epmlive/images/left.gif";
            tbOutdent.OnClientClick = "Javascript:outdent();";
            tbOutdent.NavigateUrl = "";
            tbOutdent.ToolTip = "Outdent";

            ToolBarButton tbIndent = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            tbIndent.Text = "";
            tbIndent.ImageUrl = "../_layouts/epmlive/images/right.gif";
            tbIndent.OnClientClick = "Javascript:indent();";
            tbIndent.NavigateUrl = "";
            tbIndent.ToolTip = "Indent";

            ToolBarButton tbUp = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            tbUp.Text = "";
            tbUp.ImageUrl = "../_layouts/epmlive/images/up.gif";
            tbUp.OnClientClick = "moveup();";
            tbUp.NavigateUrl = "";
            tbUp.ToolTip = "Move Up";

            ToolBarButton tbDown = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            tbDown.Text = "";
            tbDown.ImageUrl = "../_layouts/epmlive/images/down.gif";
            tbDown.OnClientClick = "Javascript:movedown();";
            tbDown.NavigateUrl = "";
            tbDown.ToolTip = "Move Down";

            ToolBarButton tbLink = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            tbLink.Text = "";
            tbLink.ImageUrl = "../_layouts/epmlive/images/link.gif";
            tbLink.OnClientClick = "Javascript:link();";
            tbLink.NavigateUrl = "";
            tbLink.ToolTip = "Link";

            ToolBarButton tbUnLink = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            tbUnLink.Text = "";
            tbUnLink.ImageUrl = "../_layouts/epmlive/images/unlink.gif";
            tbUnLink.OnClientClick = "Javascript:unlink();";
            tbUnLink.NavigateUrl = "";
            tbUnLink.ToolTip = "UnLink";

            ToolBar toolbar = (ToolBar)Page.LoadControl("~/_controltemplates/ToolBar.ascx");
            toolbar.Buttons.Controls.Add(toolbuttonGrouping);
            toolbar.Buttons.Controls.Add(tbView);
            toolbar.Buttons.Controls.Add(tbEdit);
            toolbar.Buttons.Controls.Add(tbDelete);
            toolbar.Buttons.Controls.Add(tbOutdent);
            toolbar.Buttons.Controls.Add(tbIndent);
            toolbar.Buttons.Controls.Add(tbUp);
            toolbar.Buttons.Controls.Add(tbDown);
            toolbar.Buttons.Controls.Add(tbLink);
            toolbar.Buttons.Controls.Add(tbUnLink);
            toolbar.Attributes.Add("style", "height:10px");

            pnlToolbar.Controls.Add(toolbar);

            //===================Main Toolbar===============

            string menu = "";

            menu = "<ie:menuitem id=\"zz24_Close\" type=\"option\" iconSrc=\"/_layouts/images/CLOSE.gif\" onMenuClick=\"javascript:closePage(); return false\" text=\"Close\" menuGroupId=\"100\"></ie:menuitem>";
            menu += "<ie:menuitem id=\"zz25_Save\" type=\"option\" iconSrc=\"/_layouts/images/SAVEITEM.gif\" onMenuClick=\"javascript:saveData(); return false\" text=\"Save\" menuGroupId=\"100\"></ie:menuitem>";
            menu += "<ie:menuitem id=\"zz26_SaveClose\" type=\"option\" iconSrc=\"/_layouts/images/SAVEITEM.gif\" onMenuClick=\"javascript:saveDataClose(); return false\" text=\"Save & Close\" menuGroupId=\"100\"></ie:menuitem>";
            menu += "<ie:menuitem id=\"zz26_SaveClose\" type=\"option\" iconSrc=\"images/print.gif\" onMenuClick=\"javascript:mygrid.printView(); return false\" text=\"Print\" menuGroupId=\"100\"></ie:menuitem>";

            LiteralControl ctl = new LiteralControl("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"35\"><tr><td class='ms-toolbar'><span style=\"display:none\"><menu type='ServerMenu' id=\"FileMenuControls\" largeIconMode=\"false\">" + menu + "</menu></span><span title=\"Open Menu\"><div  id=\"FileMenu_t\" class=\"ms-menubuttoninactivehover\" onmouseover=\"MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)\" hoverActive=\"ms-menubuttonactivehover\" hoverInactive=\"ms-menubuttoninactivehover\" onclick=\" MMU_Open(byid('FileMenuControls'), MMU_GetMenuFromClientId('FileMenu'),event,false, null, 0);\" foa=\"MMU_GetMenuFromClientId('FileMenu')\" oncontextmenu=\"this.click(); return false;\" nowrap=\"nowrap\"><a id=\"FileMenu\" accesskey=\"I\" href=\"#\" onclick=\"javascript:return false;\" style=\"cursor:hand;white-space:nowrap;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('FileMenuControls'), this, true);\" onkeydown=\"MMU_EcbLinkOnKeyDown(byid('FileMenuControls'), MMU_GetMenuFromClientId('FileMenu'), event);\" onclick=\" MMU_Open(byid('FileMenuControls'), MMU_GetMenuFromClientId('FileMenu'),event,false, null, 0);\" oncontextmenu=\"this.click(); return false;\" menuTokenValues=\"MENUCLIENTID=FileMenu,TEMPLATECLIENTID=FileMenuControls\" serverclientid=\"FileMenu\">File<img src=\"/_layouts/images/blank.gif\" border=\"0\" alt=\"Use SHIFT+ENTER to open the menu (new window).\"/></a><img align=\"absbottom\" src=\"/_layouts/images/menudark.gif\" alt=\"\" /></div></span></td></tr></table>");
            pnlFileToolbar.Controls.Add(ctl);
            //================================================
            menu = "";
            menu = "<ie:menuitem id=\"zz23_EditProject\" type=\"option\" iconSrc=\"/_layouts/images/DETAIL.gif\" onMenuClick=\"javascript:editProject('" + Request["ID"].ToString() + "','" + lstProjectCenter.ID.ToString() + "'); return false\" text=\"Edit Project Information\" menuGroupId=\"100\"></ie:menuitem>";
            menu += "<ie:menuitem id=\"zz24_SaveBaseline\" type=\"option\" iconSrc=\"images/baseline.gif\" onMenuClick=\"javascript:saveBaseline(); return false\" text=\"Save Baseline\" menuGroupId=\"100\"></ie:menuitem>";

            if (autoCalc == "true")
                menu += "<ie:menuitem id=\"zz25_AutoCalculate\" type=\"option\" iconSrc=\"/_layouts/images/checkon.gif\" onMenuClick=\"javascript:autocalc(); return false\" text=\"Auto-Calculate\" menuGroupId=\"100\"></ie:menuitem>";
            else
                menu += "<ie:menuitem id=\"zz25_AutoCalculate\" type=\"option\" iconSrc=\"\" onMenuClick=\"javascript:autocalc(); return false\" text=\"Auto-Calculate\" menuGroupId=\"100\"></ie:menuitem>";

            menu += "<ie:menuitem id=\"zz25_Calculate\" type=\"option\" iconSrc=\"images/calc.gif\" onMenuClick=\"javascript:calc(); return false\" text=\"Calculate\" menuGroupId=\"100\"></ie:menuitem>";
            menu += "<ie:menuitem id=\"zz26_ViewInGantt\" type=\"option\" iconSrc=\"/_layouts/images/epmlivegantt.gif\" onMenuClick=\"javascript:showGantt('" + currentView + "','" + projectName + "'); return false\" text=\"View In Gantt\" menuGroupId=\"100\"></ie:menuitem>";
            ctl = new LiteralControl("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"35\"><tr><td class='ms-toolbar'><span style=\"display:none\"><menu type='ServerMenu' id=\"EditMenuControls\" largeIconMode=\"false\">" + menu + "</menu></span><span title=\"Open Menu\"><div  id=\"EditMenu_t\" class=\"ms-menubuttoninactivehover\" onmouseover=\"MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)\" hoverActive=\"ms-menubuttonactivehover\" hoverInactive=\"ms-menubuttoninactivehover\" onclick=\" MMU_Open(byid('EditMenuControls'), MMU_GetMenuFromClientId('EditMenu'),event,false, null, 0);\" foa=\"MMU_GetMenuFromClientId('EditMenu')\" oncontextmenu=\"this.click(); return false;\" nowrap=\"nowrap\"><a id=\"EditMenu\" accesskey=\"I\" href=\"#\" onclick=\"javascript:return false;\" style=\"cursor:hand;white-space:nowrap;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('EditMenuControls'), this, true);\" onkeydown=\"MMU_EcbLinkOnKeyDown(byid('EditMenuControls'), MMU_GetMenuFromClientId('EditMenu'), event);\" onclick=\" MMU_Open(byid('EditMenuControls'), MMU_GetMenuFromClientId('EditMenu'),event,false, null, 0);\" oncontextmenu=\"this.click(); return false;\" menuTokenValues=\"MENUCLIENTID=EditMenu,TEMPLATECLIENTID=EditMenuControls\" serverclientid=\"EditMenu\">Edit<img src=\"/_layouts/images/blank.gif\" border=\"0\" alt=\"Use SHIFT+ENTER to open the menu (new window).\"/></a><img align=\"absbottom\" src=\"/_layouts/images/menudark.gif\" alt=\"\" /></div></span></td></tr></table>");
            pnlEditToolbar.Controls.Add(ctl);

            //===================
            menu = "";

            EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(lstTaskCenter);

            if (gSettings.EnableResourcePlan)
            {
                string ssrsUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "ResToolsReportURL");
                if (ssrsUrl == "")
                {
                    try
                    {
                        bool integrated = false;
                        try
                        {
                            integrated = bool.Parse(EPMLiveCore.CoreFunctions.getWebAppSetting(web.Site.WebApplication.Id, "ReportsUseIntegrated"));
                        }
                        catch { }
                        if (integrated)
                            ssrsUrl = EPMLiveCore.CoreFunctions.getWebAppSetting(web.Site.WebApplication.Id, "ReportingServicesURL") + "?" + HttpUtility.UrlEncode(web.Site.Url) + "%2fReport+Library%2fepmlivetl%2fResource%2fResource+Work+vs.+Capacity.rdl";
                        else
                            ssrsUrl = EPMLiveCore.CoreFunctions.getWebAppSetting(web.Site.WebApplication.Id, "ReportingServicesURL") + "?%2fepmlivetl%2fResource%2fResource+Work+vs.+Capacity";
                    }
                    catch { }
                }

                try
                {
                    menu = "<ie:menuitem id=\"zz25_FindResources\" type=\"option\" iconSrc=\"/_layouts/images/epmlive_rt_find.gif\" onMenuClick=\"javascript:window.open('" + ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "/_layouts/epmlive/resourcecapacity.aspx','', config='height=600,width=800, toolbar=no, menubar=no, scrollbars=yes, resizable=yes,location=no, directories=no, status=yes'); return false\" text=\"Find Resource(s)\" description=\"Use this tool to find which resources are available for your work.\" menuGroupId=\"100\"></ie:menuitem>";
                }
                catch { }
                menu += "<ie:menuitem id=\"zz26_CheckResource\" type=\"option\" iconSrc=\"/_layouts/images/epmlive_rt_check.gif\" onMenuClick=\"javascript:showresgantt('" + resUrl + "/_layouts/epmlive/checkresgantt.aspx','" + listId + "'); return false\" text=\"Check Resource(s)\" description=\"Use this tool to check your assignment against all other work in the system.\" menuGroupId=\"100\"></ie:menuitem>";

                ctl = new LiteralControl("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"90\"><tr><td class='ms-toolbar'><span style=\"display:none\"><menu type='ServerMenu' id=\"ResourceToolsMenuControls\" largeIconMode=\"false\">" + menu + "</menu></span><span title=\"Open Menu\"><div  id=\"ResourceToolsMenu_t\" class=\"ms-menubuttoninactivehover\" onmouseover=\"MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)\" hoverActive=\"ms-menubuttonactivehover\" hoverInactive=\"ms-menubuttoninactivehover\" onclick=\" MMU_Open(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'),event,false, null, 0);\" foa=\"MMU_GetMenuFromClientId('ResourceToolsMenu')\" oncontextmenu=\"this.click(); return false;\" nowrap=\"nowrap\"><a id=\"ResourceToolsMenu\" accesskey=\"I\" href=\"#\" onclick=\"javascript:return false;\" style=\"cursor:hand;white-space:nowrap;\" onfocus=\"MMU_EcbLinkOnFocusBlur(byid('ResourceToolsMenuControls'), this, true);\" onkeydown=\"MMU_EcbLinkOnKeyDown(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'), event);\" onclick=\" MMU_Open(byid('ResourceToolsMenuControls'), MMU_GetMenuFromClientId('ResourceToolsMenu'),event,false, null, 0);\" oncontextmenu=\"this.click(); return false;\" menuTokenValues=\"MENUCLIENTID=ResourceToolsMenu,TEMPLATECLIENTID=ResourceToolsMenuControls\" serverclientid=\"ResourceToolsMenu\">Resource Tools<img src=\"/_layouts/images/blank.gif\" border=\"0\" alt=\"Use SHIFT+ENTER to open the menu (new window).\"/></a><img align=\"absbottom\" src=\"/_layouts/images/menudark.gif\" alt=\"\" /></div></span></td></tr></table>");
                pnlResourceToolbar.Controls.Add(ctl);
                
            }
        }


        private void loadViews(SPWeb web)
        {

            listId = lstTaskCenter.ID.ToString();
            SPView view = lstTaskCenter.DefaultView;

            try
            {
                view = lstTaskCenter.Views[new Guid(Request["view"].ToString())];
            }
            catch { }
            currentView = view.Title;
            currentViewGuid = view.ID.ToString();



            //viewList = "<ie:menuitem id=\"zz29_DefaultView\" type=\"option\" onMenuClick=\"window.location='tasks.aspx?ID=" + Request["ID"].ToString() + "&view=" + lstTaskCenter.DefaultView.ID + "&source=" + HttpUtility.UrlEncode(pcURL) + "';\" text=\"" + lstTaskCenter.DefaultView.Title + "\" menuGroupId=\"100\"></ie:menuitem>\r\n";

            foreach (SPView vw in lstTaskCenter.Views)
            {
                if (!vw.Hidden)
                {
                    if (view.ID == vw.ID)
                        viewList += "<option value=\"" + vw.ID.ToString() + "\" selected>" + vw.Title + "</option>";
                    else
                        viewList += "<option value=\"" + vw.ID.ToString() + "\">" + vw.Title + "</option>";
                }
                    //viewList += "<ie:menuitem id=\"zz31_View2\" type=\"option\" onMenuClick=\"window.location = 'tasks.aspx?ID=" + Request["ID"].ToString() + "&view=" + vw.ID + "&source=" + HttpUtility.UrlEncode(pcURL) + "';\" text=\"" + vw.Title + "\" menuGroupId=\"300\"></ie:menuitem>";
            }

            



            XmlDocument docView = new XmlDocument();
            docView.LoadXml("<Query>" + view.Query + "</Query>");

            if (Request["disablefilters"] == "true")
            {
                hasFilters = false;
                disableFilters = true;
            }
            else
            {

                XmlNode ndWhere = docView.SelectSingleNode("//Where");
                if (ndWhere == null)
                {
                    hasFilters = false;
                }
                else
                {
                    if (ndWhere.ChildNodes[0].Name == "Eq")
                    {
                        if (ndWhere.ChildNodes[0].ChildNodes[0].Attributes["Name"].Value == "IsAssignment")
                            hasFilters = false;
                        else
                            hasFilters = true;
                    }
                    else
                    {
                        hasFilters = true;
                    }
                }
            }

            SPViewFieldCollection vfc = view.ViewFields;

            columnCalculations = "";

            //string URL = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWorkPlannerURL");

            Hashtable hshCalcs = new Hashtable();

            if (wpFields != null && wpFields != "")
            {
                string[] sProps = wpFields.Split('\n');
                foreach (string sProp in sProps)
                {
                    string[] sField = sProp.Split('|');
                    hshCalcs.Add(sField[0], sField[1]);
                }
            }




            ////if (URL != "")
            //{
            //    if (URL == "")
            //        URL = web.Url;
            //    using (SPSite oSiteCollection = new SPSite(URL))
            //    {
            //        using (SPWeb oWebsite = oSiteCollection.OpenWeb())
            //        {
            //            SPWeb workplannerweb = web;
            //            if (oWebsite.Url.ToLower() == URL.ToLower())
            //                workplannerweb = oWebsite;
            //            string props = workplannerweb.Properties["EPMLiveWorkPlannerFields"];
            //            if (props != null && props != "")
            //            {
            //                string[] sProps = props.Split('\n');
            //                foreach (string sProp in sProps)
            //                {
            //                    string[] sField = sProp.Split('|');
            //                    hshCalcs.Add(sField[0], sField[1]);
            //                }
            //            }
            //        }
            //    }

            //}

            foreach (string f in vfc)
            {
                if (hshCalcs.Contains(f))
                    columnCalculations += ",\"" + hshCalcs[f] + "\"";
                else
                    columnCalculations += ",\"\"";

                XmlDocument doc = new XmlDocument();
                SPField field = getRealField(lstTaskCenter.Fields.GetFieldByInternalName(f));

                doc.LoadXml(field.SchemaXml);
                //===============Default Values==================
                string def = "";

                try
                {
                    if (f == "Title" || f == "LinkTitle")
                    {
                        def = " ";
                    }
                    else
                    {
                        def = doc.ChildNodes[0].SelectSingleNode("Default").InnerText;
                    }
                    switch (field.Type)
                    {
                        case SPFieldType.MultiChoice:
                            def = def + ";#" + def;
                            break;
                        case SPFieldType.DateTime:
                            if (def.ToLower() == "[today]")
                                def = DateTime.Now.ToShortDateString();
                            break;
                    };
                }
                catch { }
                defaultValues += ",\"" + def.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";

                //===============Min Values==================
                string min = "";
                try
                {
                    min = doc.ChildNodes[0].Attributes["Min"].Value;
                    if (doc.ChildNodes[0].OuterXml.Contains("Percentage=\"TRUE\""))
                        min = (float.Parse(min) * 100).ToString();
                }
                catch { }
                minValues += ",\"" + min + "\"";

                //===============Max Values==================
                string max = "";
                try
                {
                    max = doc.ChildNodes[0].Attributes["Max"].Value;
                    if (doc.ChildNodes[0].OuterXml.Contains("Percentage=\"TRUE\""))
                        max = (float.Parse(max) * 100).ToString();
                }
                catch { }
                maxValues += ",\"" + max + "\"";
            }

            if (columnCalculations.Length > 1)
            {
                minValues = minValues.Substring(1);
                defaultValues = defaultValues.Substring(1);
                maxValues = maxValues.Substring(1);
                columnCalculations = columnCalculations.Substring(1);
            }
        }

        private SPField getRealField(SPField field)
        {
            try
            {
                if (field.Type == SPFieldType.Computed)
                {
                    {
                        XmlDocument fieldXml = new XmlDocument();
                        fieldXml.LoadXml(field.SchemaXml);

                        string parentField = "";
                        try
                        {
                            parentField = fieldXml.FirstChild.Attributes["DisplayNameSrcField"].Value;
                        }
                        catch { }
                        if (parentField != "")
                        {
                            try
                            {
                                field = field.ParentList.Fields.GetFieldByInternalName(parentField);
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
            return field;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(Web);

            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.WorkPlanner);
            if (activation != 0)
            {
                lblExpire.Text = act.translateStatus(activation);
                pnlMain.Visible = false;
                pnlExpire.Visible = true;
                return;
            }

            SPWeb web = SPContext.Current.Web;

            //createToolbar();
            web.AllowUnsafeUpdates = true;

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPSite site = SPContext.Current.Site;
                {
                    int work = site.RootWeb.RegionalSettings.WorkDays;
                    for (byte x = 0; x < 7; x++)
                    {
                        workdays = ((((work >> x) & 0x01) == 0x01) ? "1" : "0") + "," + workdays;
                        if (!(((work >> x) & 0x01) == 0x01))
                            nonwork++;
                    }
                    workdays = "[" + workdays.Substring(0, workdays.Length - 1) + "]";
                }
            });


            Guid lockWeb = EPMLiveCore.CoreFunctions.getLockedWeb(web);
            if (lockWeb == Guid.Empty || lockWeb == web.ID)
            {
                lstProjectCenter = web.Lists[EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWPProjectCenter")];
                lstTaskCenter = web.Lists[EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWPTaskCenter")];
                wpFields = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWorkPlannerFields");
                useResourcePool = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveWPUseResPool").ToLower();
                resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, true).ToLower();
            }
            else
            {
                SPSite site = SPContext.Current.Site;
                {
                    using (SPWeb w = site.OpenWeb(lockWeb))
                    {
                        lstProjectCenter = web.Lists[EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveWPProjectCenter")];
                        lstTaskCenter = web.Lists[EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveWPTaskCenter")];
                        wpFields = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveWorkPlannerFields");
                        useResourcePool = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveWPUseResPool").ToLower();
                        resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(w, "EPMLiveResourceURL", true, true).ToLower();
                    }
                }
            }

            if (resUrl == "/")
                resUrl = "";

            //SPList list = web.Lists[EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveProjectCenter")];


            SPListItem project = lstProjectCenter.GetItemById(int.Parse(Request["ID"].ToString()));


            bool canEdit = false;
            try
            {
                SPFieldLookupValue lv = new SPFieldLookupValue(project[lstProjectCenter.Fields.GetFieldByInternalName("Author").Id].ToString());
                if (lv.LookupId == web.CurrentUser.ID)
                    canEdit = true;
            }
            catch { }
            try
            {
                lastBaseline = project[lstProjectCenter.Fields.GetFieldByInternalName("BaselineSaved").Id].ToString();
            }
            catch { }
            try
            {
                SPFieldLookupValueCollection lvs = new SPFieldLookupValueCollection(project[lstProjectCenter.Fields.GetFieldByInternalName("ProjectManagers").Id].ToString());
                foreach (SPFieldLookupValue lv in lvs)
                {
                    if (lv.LookupId == web.CurrentUser.ID && lstTaskCenter.DoesUserHavePermissions(SPBasePermissions.EditListItems))
                        canEdit = true;
                }

            }
            catch { }

            if (web.CurrentUser.IsSiteAdmin)
                canEdit = true;

            if (!canEdit)
                Microsoft.SharePoint.Utilities.SPUtility.Redirect("accessdenied.aspx", Microsoft.SharePoint.Utilities.SPRedirectFlags.RelativeToLayoutsPage, HttpContext.Current);

            //string resurl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL");

            //if (resurl != "")
            //    useResourcePool = "true";

            //if (url == "")
            //{
            //    url = web.Url;
            //    if (web.Properties["EPMLiveWPUseResource"] == "True")
            //        useResourcePool = "true";
            //}
            //else if(url.ToLower() == web.Url.ToLower())
            //{
            //    if (web.Properties["EPMLiveWPUseResource"] == "True")
            //        useResourcePool = "true";
            //}
            //else
            //{
            //    using (SPSite oSiteCollection = new SPSite(url))
            //    {
            //        using (SPWeb oWebsite = oSiteCollection.OpenWeb())
            //        {
            //            //SPWeb workplannerweb = web;
            //            //if (oWebsite.Url.ToLower() == url.ToLower())
            //            //    workplannerweb = oWebsite;
            //            if (oWebsite.Properties["EPMLiveWPUseResource"] == "True")
            //                useResourcePool = "true";
            //        }
            //    }
            //}
            if (Request["source"] != null & Request["source"] != "")
            {
                pcURL = Request["source"];
            }
            else
            {
                pcURL = lstTaskCenter.DefaultViewUrl;
            }

            projectEditUrl = lstProjectCenter.Forms[PAGETYPE.PAGE_EDITFORM].ServerRelativeUrl;

            //if (resURL == "")
            //    resURL = web.Url;

            loadViews(web);

            autoCalc = "true";

            //try
            //{
            //    autoCalc = project["AutoCalculate"].ToString().ToLower();
            //}
            //catch { autoCalc = "true"; }

            projectName = project.Title.Replace(" ", "%20");

            createToolbar(web);

            System.Globalization.CultureInfo cInfo = new System.Globalization.CultureInfo(web.Locale.LCID);
            string[] dtFormat = cInfo.DateTimeFormat.ShortDatePattern.ToLower().Split(cInfo.DateTimeFormat.DateSeparator.ToCharArray());
            strDateFormat = "";
            foreach (string s in dtFormat)
            {
                if (s.Contains("m"))
                    strDateFormat += cInfo.DateTimeFormat.DateSeparator + "%m";
                else if (s.Contains("d"))
                    strDateFormat += cInfo.DateTimeFormat.DateSeparator + "%d";
                else if (s.Contains("y"))
                    strDateFormat += cInfo.DateTimeFormat.DateSeparator + "%Y";
            }
            if (strDateFormat.Length > 1)
                strDateFormat = strDateFormat.Substring(1);
            else
                strDateFormat = "%m/%d/%Y";

            SiteUrl = HttpUtility.UrlEncode(web.Url + "/_layouts/epmlive/edititem.aspx?close=1&ListId=" + listId);
            webId = web.ID.ToString();
            siteId = web.Site.ID.ToString();

            sUrl = web.Url + "/_layouts/epmlive/tasks.aspx?view=" + currentViewGuid + "&disablefilters=true&ID=" + Request["ID"];

            showPlanner = true;
            try
            {
                if (project["IsProjectServer"].ToString() == "True")
                {
                    pnlProjectServer.Visible = true;
                    pnlMain.Visible = false;
                    showPlanner = false;
                    return;
                }
            }
            catch { }
        }
    }
}