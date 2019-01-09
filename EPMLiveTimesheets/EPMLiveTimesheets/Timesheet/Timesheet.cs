using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

using System.Text.RegularExpressions;
using System.ComponentModel;

using System.Data;
using System.Data.SqlClient;

using System.Xml;
using System.Collections.Generic;

using System.Web;

using System.Text;

using System.Collections;
using System.Diagnostics;
using EPMLiveCore;
using EPMLiveWebParts;

namespace TimeSheets
{
    [Guid("69af1f35-2adf-4d9a-b34a-50da8ea7ee91")]
    [ToolboxData("<{0}:TimeSheet runat=server></{0}:TimeSheet>")]
    [XmlRoot(Namespace = "TimeSheet")]
    public class TimeSheet : Microsoft.SharePoint.WebPartPages.WebPart, IWebPartPageComponentProvider
    {
        SPList list;
        SPView view;
        //ViewToolBar toolbar;

        private string sFullParamList;

        //bool locked = false;
        string editEvents = "true";

        private string error;
        private string strList;
        private string strView;
        private bool? boolLockViewContext;
        private int intPeriod;
        //private string strPeriodStart;
        //private string strPeriodEnd;
        private string appNote;
        private string username = SPContext.Current.Web.CurrentUser.LoginName;
        private bool impersonate = false;
        private bool canImpersonate = false;
        private string impersonatedUser = "";
        int activation;
        string status;
        string sFullGridId;
        private bool allowEditToggle = false;
        private bool inEditMode = false;

        //bool boxesDisabled = false;

        //DropDownList ddl;
        //ImageButton btnNext;
        //ImageButton btnPrev;
        string tsuid;
        ToolBar worktoolbar;
        //TimesheetMenu ts = new TimesheetMenu();

        private PeopleEditor peMulti;
        private PeopleEditor peSingle;

        private SortedList arrPeriods = new SortedList();
        private string strCurPeriodName;
        private string strNextPeriod = "";
        private string strPreviousPeriod = "";
        private string strAllPeriods;
        private string lockedts = "false";
        private string lockunsubmit = "false";
        private string strDelegates = "";
        
        private EPMLiveCore.Act act;

        [Category("Grid Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [Browsable(false)]
        public bool? PropLockViewContext
        {
            get
            {
                if (boolLockViewContext == null)
                    if (SPContext.Current.List != null)
                        return true;
                    else
                        return false;

                return boolLockViewContext;
            }
            set
            {
                boolLockViewContext = value;
            }
        }


        [Category("Grid Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [Browsable(false)]
        public string PropList
        {
            get
            {
                if (PropLockViewContext.Value == true)
                {
                    try
                    {
                        return SPContext.Current.List.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url;
                    }
                    catch { }
                    return strList;
                }
                else if (strList == null || strList == "")
                {
                    try
                    {
                        return SPContext.Current.List.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url;
                    }
                    catch { }
                    return strList;
                }
                else
                    return strList;
            }
            set
            {
                strList = value;
            }
        }

        [Category("Grid Properties")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Custom String for Toolpart")]
        [Description("Used by the toolpart.")]
        [Browsable(false)]
        public string PropView
        {
            get
            {
                if (PropLockViewContext.Value == true)
                {
                    try
                    {
                        return SPContext.Current.ViewContext.View.Title;
                    }
                    catch { }
                    return strView;
                }
                else if (strView == null || strView == "")
                {
                    try
                    {
                        return SPContext.Current.ViewContext.View.Title;
                    }
                    catch { }
                    return strView;
                }
                else
                    return strView;
            }
            set
            {
                strView = value;
            }
        }

        public TimeSheet()
        {
            sFullGridId = this.ZoneIndex + this.ZoneID;
        }

        protected override void CreateChildControls()
        {
            act = new EPMLiveCore.Act(SPContext.Current.Web);
            activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.Timesheets);

            if (activation != 0)
                return;

            base.CreateChildControls();

            SPWeb web = SPContext.Current.Web;
            {
                try
                {
                    list = web.GetListFromUrl(PropList);
                    view = list.Views[PropView];
                }
                catch { }

                if (view != null && list != null)
                {
                    string user = web.CurrentUser.LoginName;

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        try
                        {
                            string requestedUser = Page.Request["duser"];
                            string resUrl = EPMLiveCore.CoreFunctions.getConfigSetting(web, "EPMLiveResourceURL", true, false);
                            using (SPSite site = new SPSite(resUrl))
                            {
                                using (SPWeb rweb = site.OpenWeb())
                                {
                                    SPList rlist = rweb.Lists["Resources"];
                                    SPUser u = rweb.SiteUsers[user];

                                    SPQuery query = new SPQuery();
                                    query.Query = "<Where><Eq><FieldRef Name=\"TimesheetDelegates\" LookupId='True'/><Value Type=\"User\">" + u.ID + "</Value></Eq></Where><OrderBy><FieldRef Name=\"Title\"/></OrderBy>";

                                    SPListItemCollection lic = rlist.GetItems(query);

                                    if (lic.Count > 0)
                                    {
                                        canImpersonate = true;

                                        //SubMenuTemplate mnu = (SubMenuTemplate)ts.Controls[0].Controls[2].Controls[11];
                                        //mnu.Visible = true;

                                        //((MenuItemTemplate)mnu.Controls[1]).ClientOnClickNavigateUrl = System.Web.HttpContext.Current.Request.Url.AbsolutePath;

                                        //int counter = 2;
                                        //TODO:Impersonate//
                                        foreach (SPListItem li in lic)
                                        {
                                            try
                                            {
                                                //MenuItemTemplate mnuUser = new MenuItemTemplate();
                                                //mnuUser.Text = li.Title;
                                                SPFieldUserValue uv = new SPFieldUserValue(web, li["SharePointAccount"].ToString());
                                                //if (uv.User.Name != li.Title)
                                                //    mnuUser.Description = "Real Name: " + uv.User.Name;

                                                //mnuUser.ID = li.ID.ToString();
                                                //mnuUser.Sequence = counter++;
                                                //mnuUser.ClientOnClickNavigateUrl = System.Web.HttpContext.Current.Request.Url.AbsolutePath + "?duser=" + System.Web.HttpUtility.UrlEncode(uv.User.LoginName);

                                                //mnu.Controls.Add(mnuUser);

                                                strDelegates += "," + li.Title + "|" + uv.User.Name + "|" + System.Web.HttpUtility.UrlEncode(uv.User.LoginName);

                                                if (requestedUser != "")
                                                {
                                                    if (System.Web.HttpUtility.UrlDecode(requestedUser).ToLower() == uv.User.LoginName.ToLower())
                                                    {
                                                        impersonate = true;
                                                        username = requestedUser;
                                                        impersonatedUser = uv.User.Name;
                                                    }
                                                }
                                            }
                                            catch { }
                                        }
                                        if (strDelegates.Length > 1)
                                            strDelegates = strDelegates.Substring(1);
                                    }
                                }
                            }

                        }
                        catch { }
                        //TODO//
                        //Get New Period//
                        try
                        {

                            SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                            cn.Open();
                            SqlCommand cmd = new SqlCommand("SELECT * from TSPERIOD where site_id=@siteid and locked = 0 order by period_id", cn);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                            SqlDataReader dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                arrPeriods.Add(dr.GetInt32(0), dr.GetDateTime(1).ToShortDateString() + " - " + dr.GetDateTime(2).ToShortDateString());
                            }
                            

                            //ddl.SelectedValue = intPeriod.ToString();

                            cn.Close();
                        }
                        catch { }
                    });



                    //if (Page.IsPostBack)
                    //{
                    //    Page.Response.Cookies["EPMLiveTSPeriod"].Value = ddl.SelectedValue;
                    //    Page.Response.Cookies["EPMLiveTSPeriod"].Expires = DateTime.Now.AddMinutes(30);
                    //}
                    //ddl.ID = "ddlPeriod";
                    //ddl.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
                    //ddl.AutoPostBack = true;
                    //ddl.EnableViewState = true;

                    //btnNext.Click += new ImageClickEventHandler(btn_Click);
                    //btnNext.ImageUrl = "/_layouts/epmlive/images/right.gif";
                    //btnNext.EnableViewState = true;

                    //btnPrev.Click += new ImageClickEventHandler(btnPrev_Click);
                    //btnPrev.ImageUrl = "/_layouts/epmlive/images/left.gif";
                    //btnPrev.EnableViewState = true;

                    //Panel pnl = new Panel();
                    //pnl.Controls.Add(new LiteralControl("<table border=\"0\"><tr><td class=\"ms-toolbar\" valign=\"center\"><div class=\"ms-buttoninactivehover\" onmouseover=\"this.className='ms-buttonactivehover'\" onmouseout=\"this.className='ms-buttoninactivehover'\">"));
                    //pnl.Controls.Add(btnPrev);
                    //pnl.Controls.Add(new LiteralControl("</div></td><td valign=\"center\">"));
                    //pnl.Controls.Add(ddl);
                    //pnl.Controls.Add(new LiteralControl("</td><td valign=\"center\"><div class=\"ms-buttoninactivehover\" onmouseover=\"this.className='ms-buttonactivehover'\" onmouseout=\"this.className='ms-buttoninactivehover'\">"));
                    //pnl.Controls.Add(btnNext);
                    //pnl.Controls.Add(new LiteralControl("</div></td></tr></table>"));

                    //toolbar.Controls[0].Controls[1].Controls[0].Controls.AddAt(7, pnl);

                    worktoolbar = (ToolBar)Page.LoadControl("~/_controltemplates/ToolBar.ascx");
                    worktoolbar.ID = "NavNodesTB";
                    ////worktoolbar.Template_Buttons = new BtnTemplate();
                    Controls.Add(worktoolbar);
                }
            }

            peMulti = new PeopleEditor();
            peMulti.MultiSelect = true;
            peMulti.ID = "userpicker";
            this.Controls.Add(peMulti);

            peSingle = new PeopleEditor();
            peSingle.MultiSelect = false;
            peSingle.ID = "userpickersingle";
            this.Controls.Add(peSingle);
        }

        private void AddContextualTab()
        {


            var ribbon = SPRibbon.GetCurrent(Page);
            if (ribbon != null)
            {
                ribbon.Minimized = false;
                ribbon.CommandUIVisible = true;
                const string initialTabId = "Ribbon.Timesheet";
                if (!ribbon.IsTabAvailable(initialTabId))
                    ribbon.MakeTabAvailable(initialTabId);

                //ribbon.MakeContextualGroupInitiallyVisible("Ribbon.ListContextualGroup", string.Empty);

            }

            string language = SPContext.Current.Web.Language.ToString();

            Microsoft.Web.CommandUI.Ribbon ribbon1 = SPRibbon.GetCurrent(this.Page);

            XmlDocument ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml(Properties.Resources.txtTimesheetTab.Replace("#language#", language));
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListContextualGroup._children");

            ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml("<Button Id=\"Ribbon.List.Datasheet.Print\" Sequence=\"10\" Command=\"PrintGrid\" Image16by16=\"/_layouts/epmlive/images/print.gif\" Image32by32=\"/_layouts/epmlive/images/printmenu.gif\" LabelText=\"Print\" ToolTipTitle=\"Print\" ToolTipDescription=\"\" TemplateAlias=\"o1\"/>");
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.List.Share.Controls._children");


            ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml(Properties.Resources.txtTimesheetTemplate.Replace("#language#", language));
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.Templates._children");

            ribbon.TrimById("Ribbon.List.Actions.ExportToSpreadsheet");
        }

        public WebPartContextualInfo WebPartContextualInfo
        {
            get
            {

                string webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                WebPartContextualInfo info = new WebPartContextualInfo();
                WebPartRibbonContextualGroup contextualGroup = new WebPartRibbonContextualGroup();
                WebPartRibbonTab ribbonItemTab = new WebPartRibbonTab();
                WebPartRibbonTab ribbonListTab = new WebPartRibbonTab();
                WebPartRibbonTab ribbonTsTab = new WebPartRibbonTab();
                //Create the contextual group object and initialize its values.
                contextualGroup.Id = "Ribbon.ListContextualGroup";
                contextualGroup.Command = "ListContextualGroup";
                contextualGroup.VisibilityContext = "CustomContextualTab" + webPartPageComponentId + ".CustomVisibilityContext";

                ribbonItemTab.Id = "Ribbon.ListItem";
                ribbonItemTab.VisibilityContext = "GridViewListItemContextualTab" + webPartPageComponentId + ".CustomVisibilityContext";

                ribbonListTab.Id = "Ribbon.List";
                ribbonListTab.VisibilityContext = "GridViewListContextualTab" + webPartPageComponentId + ".CustomVisibilityContext";

                ribbonTsTab.Id = "Ribbon.Timesheet";
                ribbonTsTab.VisibilityContext = "GridViewListContextualTab" + webPartPageComponentId + ".CustomVisibilityContext";

                info.ContextualGroups.Add(contextualGroup);
                info.Tabs.Add(ribbonItemTab);
                info.Tabs.Add(ribbonListTab);
                info.Tabs.Add(ribbonTsTab);
                info.PageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                return info;
            }
        }

        public string DelayScript
        {
            get
            {
                string url = SPContext.Current.Web.ServerRelativeUrl;
                string webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);
                return @"
                <script type=""text/javascript"">
                //<![CDATA[
                            function _addCustomPageComponent()
                            {
                                var _customPageComponent = new ContextualTabWebPart.CustomPageComponent('" + webPartPageComponentId + @"',mygrid" + sFullGridId + ",myDataProcessor,'" + ((url == "/") ? "" : url) + @"','" + HttpContext.Current.Request.Url.AbsolutePath + @"');

                                var ribbonPageManager = SP.Ribbon.PageManager.get_instance();
                                ribbonPageManager.addPageComponent(_customPageComponent);
                                ribbonPageManager.get_focusManager().requestFocusForComponent(_customPageComponent);
                            }

                            function _registerCustomPageComponent()
                            {
                                SP.SOD.registerSod(""GridViewContextualTabPageComponent.js"", "" " + SPContext.Current.Web.Url + @"\/_layouts\/epmlive\/gridlistribbon.aspx"");
                                SP.SOD.executeFunc(""GridViewContextualTabPageComponent.js"", ""ContextualWebPart.CustomPageComponent"", _addCustomPageComponent);
                            }

                            SP.SOD.executeOrDelayUntilScriptLoaded(_registerCustomPageComponent, ""sp.ribbon.js"");
                //]]>
                </script>";
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            buildParams(SPContext.Current .Web);

            string webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);

            if (!Page.ClientScript.IsClientScriptBlockRegistered(base.GetType(), "listviewwebpart" + webPartPageComponentId))
                Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "listviewwebpart" + webPartPageComponentId, "<script language=\"javascript\">var mygrid" + sFullGridId + ";</script>");

            AddContextualTab();

            ClientScriptManager clientScript = this.Page.ClientScript;

            clientScript.RegisterClientScriptBlock(this.GetType(), "ContextualWebPart", this.DelayScript);
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {

            output.Write(error);
            try
            {
                SPWeb web =SPContext.Current.Web;

                if (activation != 0)
                {
                    output.Write(act.translateStatus(activation));
                    return;
                }

                if (arrPeriods.Count <= 0)
                {
                    
                    output.Write("No Periods Defined.<br><br>");
                    if(web.CurrentUser.IsSiteAdmin)
                    {
                        output.Write("<a href=\"");
                        output.Write(web.ServerRelativeUrl == "/" ? "" : web.ServerRelativeUrl);
                        output.Write("/_layouts/epmlive/timesheetadmin.aspx\">Go To Timesheet Admin</a>");
                        output.WriteLine("");
                        
                    }

                    output.WriteLine("<script language=\"javascript\">");
                    output.WriteLine("var myDataProcessor = new Object();");
                    output.WriteLine("var mygrid" + sFullGridId + " = new Object();");
                    output.WriteLine("</script>");

                    if(SPContext.Current.ViewContext.View != null)
                    {
                        foreach(System.Web.UI.WebControls.WebParts.WebPart wp in WebPartManager.WebParts)
                        {
                            try
                            {
                                if(wp.ToString() == "Microsoft.SharePoint.WebPartPages.XsltListViewWebPart" || wp.ToString() == "Microsoft.SharePoint.WebPartPages.ListViewWebPart")
                                {
                                    wp.Visible = false;
                                }
                            }
                            catch { }
                        }
                    }
                    return;
                }
                
                {
                    web.Site.CatchAccessDeniedException = false;
                    EnsureChildControls();

                    if (list != null && view != null)
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            try
                            {
                                string webpartid = "";
                                string doEdit = "";
                                try
                                {
                                    // switchto = Page.Request["switchto"];
                                    webpartid = Page.Request["webpartid"];
                                    doEdit = Page.Request["edit"];
                                }
                                catch { }

                                EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(list);

                                try
                                {
                                    allowEditToggle = gSettings.AllowEdit;
                                }
                                catch { }
                                try
                                {
                                    inEditMode = gSettings.EditDefault;
                                }
                                catch { }
                                if (webpartid == this.ID)
                                {
                                    try
                                    {
                                        if (doEdit == "1")
                                            inEditMode = true;
                                        else if (doEdit == "0")
                                            inEditMode = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        error = "Error Saving Personalization: " + ex.Message;
                                    }
                                }


                                SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                                cn.Open();

                                if (Page.Request["NewPeriod"] != null && Page.Request["NewPeriod"] != "")
                                {
                                    Page.Response.Cookies.Remove("EPMLiveTSPeriod");
                                    Page.Request.Cookies.Remove("EPMLiveTSPeriod");

                                    HttpCookie myCookie = new HttpCookie("EPMLiveTSPeriod");

                                    myCookie["period"] = Page.Request["NewPeriod"];
                                    myCookie.Expires = DateTime.Now.AddMinutes(30);
                                    Page.Response.Cookies.Add(myCookie);

                                }

                                string sPeriod = "";

                                if (Page.Request.Cookies["EPMLiveTSPeriod"] != null)
                                    sPeriod = Page.Request.Cookies["EPMLiveTSPeriod"]["period"];

                                //if (Page.Response.Cookies["EPMLiveTSPeriod"].Value != null)
                                //    sPeriod = Page.Response.Cookies["EPMLiveTSPeriod"].Value;
                                //else if (Page.Request.Cookies["EPMLiveTSPeriod"] != null)
                                //    sPeriod = Page.Request.Cookies["EPMLiveTSPeriod"].Value;

                                if (sPeriod == null || sPeriod == "")
                                {
                                    SqlCommand cmd1 = new SqlCommand("SELECT period_id from TSPERIOD where period_start<=@dtchecked and period_end>=@dtchecked and locked = 0 and site_id=@siteid", cn);
                                    cmd1.CommandType = CommandType.Text;
                                    cmd1.Parameters.AddWithValue("@dtchecked", DateTime.Now);
                                    cmd1.Parameters.AddWithValue("@siteid", web.Site.ID);
                                    SqlDataReader dr1 = cmd1.ExecuteReader();
                                    if (dr1.Read())
                                    {
                                        intPeriod = dr1.GetInt32(0);
                                    }
                                    else
                                    {
                                        intPeriod = int.Parse(arrPeriods.GetKey(0).ToString());
                                    }

                                    dr1.Close();
                                }
                                else
                                {
                                    intPeriod = int.Parse(sPeriod);
                                }

                                foreach (DictionaryEntry de in arrPeriods)
                                {
                                    strAllPeriods += "," + de.Value.ToString() + "|" + de.Key.ToString();
                                    if (intPeriod == (int)de.Key)
                                    {
                                        strCurPeriodName = de.Value.ToString();
                                        if (arrPeriods.IndexOfKey(de.Key) > 0)
                                            strPreviousPeriod = arrPeriods.GetKey(arrPeriods.IndexOfKey(de.Key) - 1).ToString();
                                        if (arrPeriods.IndexOfKey(de.Key) < (arrPeriods.Count - 1))
                                            strNextPeriod = arrPeriods.GetKey(arrPeriods.IndexOfKey(de.Key) + 1).ToString();
                                    }
                                }
                                if (strAllPeriods.Length > 0)
                                    strAllPeriods = strAllPeriods.Substring(1);

                                status = "New";

                                SqlCommand cmd = new SqlCommand("SELECT TS_UID, Submitted, approval_status,approval_notes from TSTIMESHEET where PERIOD_ID=@periodid and username=@username and site_uid=@site_uid", cn);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@periodid", intPeriod);
                                cmd.Parameters.AddWithValue("@username", username);
                                cmd.Parameters.AddWithValue("@site_uid", web.Site.ID);
                                SqlDataReader dr = cmd.ExecuteReader();
                                if (dr.Read())
                                {
                                    tsuid = dr.GetGuid(0).ToString();
                                    if (dr.GetBoolean(1))
                                    {
                                        lockedts = "true";
                                        if (dr.GetInt32(2) == 1)
                                        {
                                            status = "Approved";
                                            lockunsubmit = "true";
                                            SPSecurity.RunWithElevatedPrivileges(delegate()
                                            {
                                                if (EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveTSDisableApprovals").ToLower() == "true")
                                                {
                                                    lockunsubmit = "false";
                                                    //ts.GetMenuItem("UnsubmitTimesheet").Visible = true;
                                                }
                                                else if (canImpersonate)
                                                {

                                                }
                                                //else
                                                    //ts.Visible = false;
                                            });
                                            inEditMode = false;
                                        }
                                        else if (dr.GetInt32(2) == 2)
                                        {
                                            //status = "<font color='red'>Rejected</font> <a href='javascript:viewnote" + sFullGridId + "()'><img src='/_layouts/images/ICDISC.GIF' border='0'></a>";
                                            status = "Rejected";
                                            appNote = dr.GetString(3);
                                            //ts.GetMenuItem("UnsubmitTimesheet").Visible = true;
                                        }
                                        else
                                        {
                                            status = "Submitted";
                                            //ts.GetMenuItem("UnsubmitTimesheet").Visible = true;
                                            inEditMode = false;
                                        }

                                        editEvents = "false";
                                        //toolbar.Controls[0].Controls[1].Controls[0].Controls[6].Visible = false;
                                        //ts.GetMenuItem("SaveTimeSheet").Visible = false;
                                        //ts.GetMenuItem("DeleteItem").Visible = false;
                                        //ts.GetMenuItem("SubmitTimesheet").Visible = false;

                                        //ts.Controls[0].FindControl("AddWork").Visible = false;
                                    }
                                    else
                                    {
                                        if (dr.GetInt32(2) == 2)
                                        {
                                            //status = "<font color='red'>Rejected</font> <a href='javascript:viewnote" + sFullGridId + "()'><img src='/_layouts/images/ICDISC.GIF' border='0'></a>";
                                            status = "Rejected";
                                            appNote = dr.GetString(3);
                                        }
                                        else
                                            status = "Saved";
                                    }
                                }
                                dr.Close();

                                cmd = new SqlCommand("SELECT locked from TSPERIOD where period_id=@periodid and site_id=@site_id", cn);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@periodid", intPeriod);
                                cmd.Parameters.AddWithValue("@site_id", web.Site.ID);
                                dr = cmd.ExecuteReader();

                                //SPSecurity.RunWithElevatedPrivileges(delegate()
                                //{
                                //    if (EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveTSNonWork") == "")
                                //        ts.Controls[0].FindControl("NonWork").Visible = false;
                                //    else
                                //        ts.Controls[0].FindControl("NonWork").Visible = true;
                                //});

                                if (dr.Read())
                                {
                                    if (dr.GetBoolean(0))
                                    {
                                        status = "Closed";
                                        editEvents = "false";
                                        //toolbar.Controls[0].Controls[1].Controls[0].Controls[6].Visible = false;
                                        //Image img = new Image();
                                        //img.ImageUrl = "/_layouts/images/lockts.gif";
                                        //toolbar.Controls[0].Controls[1].Controls[0].Controls.AddAt(6, img);
                                    }
                                }
                                dr.Close();

                                Label lbl = new Label();
                                lbl.ID = "lblTimesheetStatus";
                                lbl.Text = "&nbsp;&nbsp;Timesheet Status: <span id=\"divStatus\" class=\"ms-descriptiontext\">" + status + "</span>";
                                //toolbar.Controls[0].Controls[1].Controls[0].Controls.Add(lbl);


                                //SqlDataReader dr = cmd.ExecuteReader();
                                //if (dr.Read())
                                //{
                                //    strPeriodStart = dr.GetDateTime(0).ToShortDateString();
                                //    strPeriodEnd = dr.GetDateTime(1).ToShortDateString();
                                //}
                                //dr.Close();

                                //ddl.SelectedValue = intPeriod.ToString();

                                //if (ddl.SelectedIndex == 0)
                                //    btnPrev.Visible = false;

                                //if (ddl.SelectedIndex == ddl.Items.Count - 1)
                                //    btnNext.Visible = false;

                                //foreach (Control control in toolbar.Controls)
                                //{
                                //    processControls(control, sFullGridId, view.ServerRelativeUrl, web);
                                //}

                                //toolbar.RenderControl(output);
                                if (impersonate)
                                {
                                    output.Write("<div style=\"height: 10px;background-color:#FFFF88;padding:2px;font-size:10px\"><b>Editing Timesheet For: " + impersonatedUser + "</b></div>");
                                }
                                renderGrid(output, web, cn);

                                cn.Close();




                            }
                            catch (Exception ex)
                            {
                                output.Write("Error: " + ex.Message);
                            }



                        });
                    }



                    if (SPContext.Current.ViewContext.View != null)
                    {
                        foreach (System.Web.UI.WebControls.WebParts.WebPart wp in WebPartManager.WebParts)
                        {
                            try
                            {
                                if (wp.ToString() == "Microsoft.SharePoint.WebPartPages.XsltListViewWebPart" || wp.ToString() == "Microsoft.SharePoint.WebPartPages.ListViewWebPart")
                                {
                                    wp.Visible = false;
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                output.Write("Error (Render WebPart): " + ex.Message);
            }
        }

        private void renderGrid(HtmlTextWriter output, SPWeb web, SqlConnection cn)
        {
            RenderStyle(output);

            RenderHeader(output);

            RenderSingleChoice(output);

            RenderMultiChoice(output);

            var firstEditorbox = RenderTimeEditor(output, web, cn);

            RenderScriptBundles(output);

            var literalControl = RenderTable(output);
            RenderToolBar(output, literalControl);
            RenderLoadingGrid(output);
            RenderScriptFunctions(output, web, firstEditorbox);
            RenderDialogNote(output);
            RenderExcels(output);
        }

        private void RenderHeader(HtmlTextWriter output)
        {
            output.Write(
                "<div id=\"people{0}\" style=\"display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width=200px; Z-Index:99;\">",
                sFullGridId);
            output.Write(
                "<div id=\"peoplecheck{0}\" style=\"overflow: auto; width: 200px; height: 100px;  background-color: #FFFFFF;"
                + " border: 1px solid #808080; margin-top:2px; padding:3px;\" class=\"ms-descriptiontext\">",
                sFullGridId);
            output.Write("</div>");

            output.Write("<table border=\"0\" width=\"100%\"><tr><td>");
            output.Write(
                "<a onclick=\"javascript:viewChecks{0}('{0}');\"><img id=\"peoplecheckimg{0}\" src=\"_layouts/images/TPMAX1.GIF\" border=\"0\"></a><br>",
                sFullGridId);
            output.Write("</td><td align=\"right\">");
            output.Write(
                "<font class=\"ms-descriptiontext\"><a style=\"cursor:pointer\" onclick=\"javascript:mygrid{0}.editStop();\">Close</a></font>",
                sFullGridId);
            output.Write("</td></tr></table>");
            output.Write("<div id=\"divPe{0}\" style=\"display:none;\">", sFullGridId);
            peMulti.RenderControl(output);
            output.Write("</div>");
            output.Write("</div>");
        }

        private static void RenderStyle(HtmlTextWriter output)
        {
            output.Write("<style>");
            output.Write(".ms-usereditor { width:200px; }");
            output.Write(".grid_hover { border: 10px solid #91CDF2; background-color: #F2FAFF } ");
            output.Write("</style>");
        }

        private void RenderSingleChoice(HtmlTextWriter output)
        {
            output.Write(
                "<div id=\"peoplesingle{0}\" style=\"display:none; border: 1px solid #808080;"
                + " padding: 3px; background-color: #F9F9F9; width=200px; Z-Index:99;\">",
                sFullGridId);
            output.Write(
                "<div id=\"peoplechecksingle{0}\" style=\"width: 200px; height: 100px;"
                + "  background-color: #FFFFFF; border: 1px solid #808080; margin-top:2px; padding:0px;\" class=\"ms-descriptiontext\">",
                sFullGridId);
            output.Write(
                "<select size=\"6\" onclick=\"changeUser{0}(this);\" id=\"peoplecheckselect{0}\""
                + "  style=\"width:100%;height:100%\"><option>test</option></select>",
                sFullGridId);
            output.Write("</div>");

            output.Write("<table border=\"0\" width=\"200\"><tr><td>");
            output.Write(
                "<a onclick=\"javascript:viewDropDown{0}('{0}');\"><img id=\"peoplechecksingleimg{0}\""
                + " src=\"_layouts/images/TPMAX1.GIF\" border=\"0\"></a><br>",
                sFullGridId);
            output.Write("</td><td align=\"right\">");
            output.Write(
                "<font class=\"ms-descriptiontext\"><a style=\"cursor:pointer\" onclick=\"javascript:mygrid{0}.editStop();\">Close</a></font>",
                sFullGridId);
            output.Write("</td></tr></table>");

            output.Write("<div id=\"divPes{0}\" style=\"display:none;\">", sFullGridId);
            peSingle.RenderControl(output);
            output.Write("</div>");
            output.Write("</div>");
        }

        private void RenderMultiChoice(HtmlTextWriter output)
        {
            output.Write(
                "<div id=\"multichoicegrid{0}\" style=\"display:none; border: 1px solid #808080; padding: 3px; background-color:"
                + " #F9F9F9; width:200px;height:160px Z-Index:99;\">",
                ID);
            output.Write(
                "<div id=\"multichoiceinner{0}\" style=\"width: 100%; height: 100%;  background-color: #FFFFFF; "
                + "border: 1px solid #808080; margin-top:2px; padding:0px;\" class=\"ms-descriptiontext\">",
                sFullGridId);
            output.Write("test");
            output.Write("</div>");
            output.Write("<table border=\"0\" width=\"200\"><tr><td align=\"right\">");
            output.Write(
                "<font class=\"ms-descriptiontext\"><a style=\"cursor:pointer\" onclick=\"javascript:mygrid{0}.editStop();\">Close</a></font>",
                sFullGridId);
            output.Write("</td></tr></table>");
            output.Write("</div>");
        }

        private string RenderTimeEditor(HtmlTextWriter output, SPWeb web, SqlConnection sqlConnection)
        {
            string firstEditorbox;
            output.Write(SharedFunctions.getTimeEditorDiv(editEvents, sFullGridId, sqlConnection, web, out firstEditorbox));
            return firstEditorbox;
        }

        private void RenderScriptBundles(HtmlTextWriter output)
        {
            output.Write("<link rel=\"stylesheet\" href=\"/_layouts/epmlive/modal/modalmain.css\" type=\"text/css\" /> ");

            output.Write("<script type=\"text/javascript\" src=\"/_layouts/epmlive/modal/modal.js\"></script>");

            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid_skins.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/calendar/dhtmlxcalendar.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/skins/dhtmlxmenu_dhx_blue.css\">");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xcombo/dhtmlxcombo.css\">");

            output.Write("<script>_css_prefix=\"/_layouts/epmlive/DHTML/xgrid/\"; _js_prefix=\"/_layouts/epmlive/DHTML/xgrid/\"; </script>");

            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js\"></script>");

            output.Write("<script src=\"_layouts/epmlive/DHTML/xtreegrid/ext/dhtmlxtreegrid_filter.js\"></script>");

            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_post.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_nxml.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_filter.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_math.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_srnd.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_drag.js\"></script>");

            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/excells/dhtmlxgrid_excell_calendar.js\"></script>");
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/excells/dhtmlxgrid_excell_combo.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/excells/dhtmlxgrid_excell_dhxcalendar.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xcombo/dhtmlxcombo.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/calendar/dhtmlxcalendar.js\"></script>");
            output.Write("<script src=\"_layouts/epmlive/DHTML/xdataproc/dhtmlxdataprocessor.js\"></script>");

            output.Write(
                "<style>.menuTable{background-color:#ffffff;}.contextMenuover, .contextMenudown{background-color:#9ac2e5;}.contextMenuover td{color:#000000;} </style>");

            output.Write("<script src=\"/_layouts/epmlive/timesheets.js\"></script>");

            output.Write("<style>");
            output.Write("div.gridbox div.ftr td{");
            output.Write("text-align:right;");
            output.Write("font-weight:bold;");
            output.Write("background-color:#d2d2d2;");
            output.Write("border: 1px solid;");
            output.Write("border-color : Gray Gray Gray white;");
            output.Write("}");
            output.Write("div.gridbox_light table.hdr td {");
            output.Write("text-align:center;");
            output.Write("}");
            output.Write(".noborder{");
            output.Write("border: 0px !important;");
            output.Write("height: 9px !important;");
            output.Write("}");
            output.Write(".statustable {");
            output.Write("border: 1px solid gray;");
            output.Write("height: 9px;");
            output.Write("}");
            output.Write("</style>");

            output.Write("<div id=\"grid{0}\"  style=\"width:100%;display:none;\" class=\"ms-listviewtable\" ></div>\r\n\r\n", ID);
        }

        private LiteralControl RenderTable(HtmlTextWriter output)
        {
            var literalControl = new LiteralControl(
                string.Format(
                    @"<table border=0 cellpadding=0 cellspacing=0 style='margin-right: 4px' width='200' id='workviewselector{0}'>
		    <tr>
		    <td nowrap class=""ms-listheaderlabel"">Work View:&nbsp;</td>
            <td id=""WorkSelectorTd"" nowrap=""nowrap"" class=""ms-viewselector"" onmouseover=""this.className='ms-viewselector'"" onmouseout=""this.className='ms-viewselector'"">
            <span style=""display:none"">
            <menu type='ServerMenu' id=""zz30_WorkSelectorMenu"" CompactMode=""true"">
                <ie:menuitem id=""zz290_DefaultView"" type=""option"" onMenuClick=""changeworkview{0}(myworkpost{0},'My Work');"" text=""My Work"" menuGroupId=""100""></ie:menuitem>
                <ie:menuitem id=""zz310_View2"" type=""option"" onMenuClick=""changeworkview{0}(otherworkpost{0},'All Work');"" text=""All Work"" menuGroupId=""300""></ie:menuitem>
            </menu>
            </span>
            <span title=""Open Menu"">
                <div  id=""zz35_WorkSelectorMenu_t"" class=""ms-viewselector"" onmouseover=""MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)"" hoverActive=""ms-viewselectorhover"" hoverInactive=""ms-viewselector"" onclick="" MMU_Open(byid('zz30_WorkSelectorMenu'), MMU_GetMenuFromClientId('zz35_WorkSelectorMenu'),event,true, 'WorkSelectorTd', 0);"" foa=""MMU_GetMenuFromClientId('zz35_WorkSelectorMenu')"" oncontextmenu=""this.click(); return false;"" nowrap=""nowrap"">
                <a id=""zz35_WorkSelectorMenu"" accesskey=""W"" href=""#"" onclick=""javascript:return false;"" style=""cursor:pointer;white-space:nowrap;"" onfocus=""MMU_EcbLinkOnFocusBlur(byid('zz30_WorkSelectorMenu'), this, true);"" onkeydown=""MMU_EcbLinkOnKeyDown(byid('zz30_WorkSelectorMenu'), MMU_GetMenuFromClientId('zz35_WorkSelectorMenu'), event);"" onclick="" MMU_Open(byid('zz30_WorkSelectorMenu'), MMU_GetMenuFromClientId('zz35_WorkSelectorMenu'),event,true, 'WorkSelectorTd', 0);"" oncontextmenu=""this.click(); return false;"" menuTokenValues=""MENUCLIENTID=zz35_WorkSelectorMenu,TEMPLATECLIENTID=zz30_WorkSelectorMenu"" serverclientid=""zz35_WorkSelectorMenu"">
                My Work
                <img src=""/_layouts/images/blank.gif"" border=""0"" alt=""Use SHIFT+ENTER to open the menu (new window).""/></a>
                <img align=""absbottom"" src=""/_layouts/images/blank.gif"" alt="""" />
                </div>
            </span>
            </td>
            </tr>
		    </table>",
                    sFullGridId));

            output.Write("<div id=\"searchdiv{0}\" style=\"width:100%;display:none;\" align=\"center\">", ID);
            output.Write(
                "<table width=\"100%\" height=\"20\" cellpadding=\"3\" cellspacing=\"0\"><tr><td valign=\"top\""
                + " align=\"left\" height=\"20\" class=\"ms-titlearealeft\"><h3 class=\"ms-pagetitle\">Search For Work</h2>"
                + "</td><td align=\"right\" height=\"20\" class=\"ms-titlearealeft\">");
            output.Write("</td></tr></table>");
            output.Write("<table width=\"100%\">");
            output.Write(
                "<tr><td class=\"ms-descriptiontext ms-inputformdescription\">Select Column:"
                + " <select id=\"searchCol{0}\" class=\"ms-input\"><option value=\"Title\">Title</option>",
                sFullGridId);

            var sortedList = new SortedList<string, string>();

            foreach (SPField spField in list.Fields)
            {
                if (spField.Reorderable && spField.InternalName != "Title")
                {
                    sortedList.Add(spField.Title, spField.InternalName);
                }
            }
            foreach (var title in sortedList.Keys)
            {
                output.Write("<option value=\"{0}\">{1}</option>", sortedList[title], title);
            }

            output.Write("</select></td></tr>");
            output.Write(
                "<tr><td class=\"ms-descriptiontext ms-inputformdescription\">Enter Search Term: <input type=\"text\" size=\"30\""
                + " class=\"ms-input\" id=\"searchTerm{0}\" onKeyDown=\"KeyDownHandler{0}(event)\"> <input type=\"button\" class=\"ms-input\""
                + " value=\"Go\" onClick=\"javascript:doSearch{0}();\"> <input type=\"button\" class=\"ms-input\" value=\"Cancel\""
                + " onClick=\"javascript:cancelSearch{0}();\"></td></tr></table>",
                sFullGridId);
            output.Write("</div>");

            output.Write("<div id=\"workdiv{0}\" style=\"width:100%;display:none;\" align=\"center\">", ID);

            output.Write(
                "<table width=\"100%\" height=\"20\" cellpadding=\"3\" cellspacing=\"0\"><tr><td valign=\"top\" align=\"left\" height=\"20\""
                + " class=\"ms-titlearealeft\"><h3 class=\"ms-pagetitle\" id=\"myworktitle\">Available Time Sheet Items: My Work</h3></td><td align=\"right\""
                + " height=\"20\" class=\"ms-titlearealeft\">");

            literalControl.RenderControl(output);

            output.Write("</td></tr></table>");
            return literalControl;
        }

        private void RenderToolBar(HtmlTextWriter output, LiteralControl literalControl)
        {
            var toolBarAddToTimeSheetButton = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            toolBarAddToTimeSheetButton.Text = "Add To Timesheet";
            toolBarAddToTimeSheetButton.ImageUrl = "/_layouts/images/EXPTITEM.GIF";
            toolBarAddToTimeSheetButton.NavigateUrl = "";
            toolBarAddToTimeSheetButton.OnClientClick = string.Format("Javascript:addMyWork{0}();", sFullGridId);
            toolBarAddToTimeSheetButton.ToolTip = "Add";

            var toolBarShowFiltersButton = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            toolBarShowFiltersButton.NavigateUrl = string.Format(
                "Javascript:switchfilterwork{0}('{1}_myworkfilter_LinkText');",
                sFullGridId,
                worktoolbar.Buttons.ClientID);
            toolBarShowFiltersButton.Text = "Show Filters";
            toolBarShowFiltersButton.ImageUrl = "/_layouts/epmlive/images/gridfilter.gif";
            toolBarShowFiltersButton.ToolTip = "Filters";
            toolBarShowFiltersButton.ID = "myworkfilter";

            var toolBarCloseButton = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            toolBarCloseButton.Text = string.Empty;
            toolBarCloseButton.ImageUrl = "/_layouts/images/close.gif";
            toolBarCloseButton.OnClientClick = string.Format("Javascript:cancelGetMyWork{0}();", sFullGridId);
            toolBarCloseButton.NavigateUrl = string.Empty;
            toolBarCloseButton.ToolTip = "Hide";

            var panel = new Panel();
            panel.Controls.Add(
                new LiteralControl(
                    string.Format(
                        "<div class=\"ms-buttoninactivehover\" onmouseover=\"this.className='ms-buttonactivehover'\" onmouseout=\"this.className='ms-buttoninactivehover'"
                        + "\" onClick=\"Javascript:addMyWork{0}();\"><img align='absmiddle' alt=\"\" src=\"/_layouts/images/EXPTITEM.gif\""
                        + " style='border-width:0px;'> Add To Timesheet</div>",
                        sFullGridId)));
            worktoolbar.Buttons.Controls.Add(panel);

            worktoolbar.RightButtons.Controls.Add(literalControl);
            worktoolbar.RightButtons.Controls.Add(toolBarCloseButton);

            worktoolbar.RenderControl(output);
        }

        private void RenderLoadingGrid(HtmlTextWriter output)
        {
            output.Write("<div  width=\"100%\" id=\"loadingmyworkgrid{0}\" align=\"center\">", ID);
            output.Write("<img src=\"/_layouts/images/gears_anv4.gif\" style=\"vertical-align: middle;\"/> Loading Items...");
            output.Write("</div>");

            output.Write("<div id=\"myworkgrid{0}\" style=\"width:100%;display:none;\"></div>", ID);
            output.Write("<div id=\"errordiv{0}\" style=\"font-color:red;font-size:11px;\"></div>", sFullGridId);

            output.Write("</div>\r\n\r\n");

            output.Write("<div  width=\"100%\" id=\"loadinggrid{0}\" align=\"center\">", ID);
            output.Write("<img src=\"_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/> Loading Items...");
            output.Write("</div>");
        }

        private void RenderScriptFunctions(HtmlTextWriter output, SPWeb web, string firstEditorbox)
        {
            output.Write("<script language=\"javascript\">");

            RenderGridFilterFunction(output);

            RenderMyWorkGridFilterFunction(output);

            RenderSetSizeFunction(output);

            RenderPrintGridFunction(output);
            RenderSwitchFilterFunction(output);
            RenderCellChangedFunction(output);

            RenderViewChecksFunction(output);
            RenderViewDropDownFunction(output);
            RenderTouchRowsFunction(output);

            RenderImpersonate(output, web);

            RenderGrid(output, web, firstEditorbox);
            RenderDataProcessorUpdateModel(output, web);
            RenderUpdateItemFunction(output);
            RenderSelectRowFunction(output);
            RenderViewErrorFunction(output);
            RenderSetTsuIdFunction(output, web);
            RenderMyErrorHandlerFunction(output);
            RenderUpdateNewsFunction(output);

            output.Write("myDataProcessor.init(mygrid{0});", sFullGridId);

            RenderLoadXFunction(output, web);
            RenderClickTabFunction(output);
            RenderValidateValuesFunction(output, web);
            RenderGridCheckedIdsFunction(output);
            RenderGridCheckedItemsFunction(output);

            output.Write("</script>");
        }

        private void RenderGridFilterFunction(HtmlTextWriter output)
        {
            output.Write("function gridfilter{0}(value){{", sFullGridId);
            output.Write("var vals = value.split('|');");
            output.Write("mygrid{0}.filterBy(vals[0],vals[1]);", sFullGridId);
            output.Write("}");
        }

        private void RenderMyWorkGridFilterFunction(HtmlTextWriter output)
        {
            output.Write("function myworkgridfilter{0}(value){{", sFullGridId);
            output.Write("var vals = value.split('|');");
            output.Write("mywork{0}.filterBy(vals[0],vals[1]);", sFullGridId);
            output.Write("}");
        }

        private void RenderSetSizeFunction(HtmlTextWriter output)
        {
            output.Write("function setSize{0}(){{mygrid{0}._askRealRows();}}", sFullGridId);
        }

        private void RenderPrintGridFunction(HtmlTextWriter output)
        {
            output.Write(
                "function printgrid{0}() {{var temp = mygrid{0}.hdr.rows[2];var parent = temp.parentNode;parent.removeChild(temp,true)"
                + ";mygrid{0}.printView();parent.appendChild(temp);}}",
                sFullGridId);
        }

        private void RenderSwitchFilterFunction(HtmlTextWriter output)
        {
            output.Write("function switchFilter{0}(hlink){{", sFullGridId);
            output.Write("var input1 = mygrid{0}.hdr.rows[2];", sFullGridId);
            output.Write("if(mygrid{0}Hidden == false){{", sFullGridId);
            output.Write("input1.style.display = \"none\";");
            output.Write("mygrid{0}Hidden = true;", sFullGridId);
            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Show Filters\";}");
            output.Write("}else{");
            output.Write("input1.style.display = \"\";");
            output.Write("mygrid{0}Hidden = false;", sFullGridId);
            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Hide Filters\";}");
            output.Write("}");
            output.Write("mygrid{0}.setSizes();", sFullGridId);
            output.Write("}");
            output.Write("function switchFilterLoad{0}(){{switchFilter{0}(null);}}", sFullGridId);

            output.Write("function switchfilterwork{0}(hlink){{", sFullGridId);
            output.Write("var input1 = mywork{0}.hdr.rows[2];", sFullGridId);
            output.Write("if(mywork{0}Hidden == false){{", sFullGridId);
            output.Write("input1.style.display = \"none\";");
            output.Write("mywork{0}Hidden = true;", sFullGridId);

            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Show Filters\";}");
            output.Write("}else{");
            output.Write("input1.style.display = \"\";");
            output.Write("mywork{0}Hidden = false;", sFullGridId);
            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Hide Filters\";}");
            output.Write("}");
            output.Write("mywork{0}.setSizes();", sFullGridId);
            output.Write("}");
            output.Write("function switchFilterLoadmywork{0}(){{switchfilterwork{0}(null);}}", sFullGridId);
        }

        private void RenderCellChangedFunction(HtmlTextWriter output)
        {
            output.Write("function cellChanged{0}(mode, id, ind, newval, oldval){{", sFullGridId);
            output.Write("  if(mode != 2) return true;");
            output.Write("     var summ = 0;");
            output.Write("      try{");
            output.Write("     if(mygrid{0}.getUserData(id,\"itemid\") != \"\"){{", sFullGridId);
            output.Write("     for(var i = 0;i<mygrid{0}.getColumnsNum();i++){{", sFullGridId);
            output.Write("          if(mygrid{0}.getColumnId(i).indexOf(\"_TsDate_\") == 0){{", sFullGridId);
            output.Write("                if(mygrid{0}.getUserData(id,\"itemid\") != \"\"){{", sFullGridId);
            output.Write("                     var vals = mygrid{0}.cells(id,i).getValue();", sFullGridId);
            output.Write("                      if(i == ind) vals = newval;");
            output.Write("                     if(mygrid{0}.getColType(i) == \"timeeditor\"){{", sFullGridId);
            output.Write("                          if(vals.split('|')[0] != \"\"){");
            output.Write("                               var strVals = vals.split('|');");
            output.Write("                               for(var j = 0;j<strVals.length && strVals[j] != \"N\";j+=2){");
            output.Write("                                    if(parseFloat(strVals[j + 1]).toString() != \"NaN\")");
            output.Write("                                         summ += parseFloat(strVals[j + 1]);");
            output.Write("                               }");
            output.Write("                          }");
            output.Write("                     }else{");
            output.Write("                          if(parseFloat(vals).toString() != \"NaN\")");
            output.Write("                               summ += parseFloat(vals);");
            output.Write("                     }");
            output.Write("               }");
            output.Write("          }}else if(mygrid{0}.getColumnId(i) == \"_TsTotal_\" || mygrid{0}.getColumnId(i) == \"_PercentWork_\"){{", sFullGridId);
            output.Write("              mygrid{0}.cells(id,i).setValue(summ);", sFullGridId);
            output.Write("          }");
            output.Write("     }");
            output.Write("     }");
            output.Write("     }catch(e){}return true;");
            output.Write("}");
        }

        private void RenderViewChecksFunction(HtmlTextWriter output)
        {
            output.Write("function viewChecks{0}(btn)", sFullGridId);
            output.Write("{");
            output.Write("var pp = document.getElementById('divPe' + btn);");
            output.Write("var ppi = document.getElementById('peoplecheckimg' + btn);");
            output.Write("if(pp.style.display == \"none\"){");
            output.Write("pp.style.display = \"\";\r\n");
            output.Write("ppi.src = \"_layouts/images/TPMIN1.GIF\";\r\n");
            output.Write("}");
            output.Write("else{");
            output.Write("pp.style.display = \"none\";");
            output.Write("ppi.src = \"_layouts/images/TPMAX1.GIF\";\r\n");
            output.Write("}");
            output.Write("}");
        }

        private void RenderViewDropDownFunction(HtmlTextWriter output)
        {
            output.Write("function viewDropDown{0}(btn)", sFullGridId);
            output.Write("{");
            output.Write("var pp = document.getElementById('divPes' + btn);");
            output.Write("var ppi = document.getElementById('peoplechecksingleimg' + btn);");
            output.Write("if(pp.style.display == \"none\"){");
            output.Write("pp.style.display = \"\";\r\n");
            output.Write("ppi.src = \"_layouts/images/TPMIN1.GIF\";\r\n");
            output.Write("}");
            output.Write("else{");
            output.Write("pp.style.display = \"none\";");
            output.Write("ppi.src = \"_layouts/images/TPMAX1.GIF\";\r\n");
            output.Write("}");
            output.Write("}");
        }

        private void RenderTouchRowsFunction(HtmlTextWriter output)
        {
            output.Write("function touchRows{0}(){{", sFullGridId);
            output.Write("mygrid{0}.forEachRow(function(id){{", sFullGridId);
            output.Write("     cellChanged{0}(2,id,0,'','');", sFullGridId);
            output.Write("})");
            output.Write("}");

            output.Write("function disableCells{0}()", sFullGridId);
            output.Write("{");
            output.Write("    mygrid{0}.forEachRow(function(id){{", sFullGridId);
            output.Write("        mygrid{0}.forEachCell(id,function(cell,i){{", sFullGridId);
            output.Write("            if(mygrid{0}.getColType(i) != \"timeeditor\")", sFullGridId);
            output.Write("              try{cell.setDisabled(true);}catch(e){}");
            output.Write("        });");
            output.Write("    });");
            output.Write("}");

            output.Write("function setAllUpdated{0}(){{", sFullGridId);
            output.Write("mygrid{0}.forEachRow(function(id){{", sFullGridId);
            output.Write("if(mygrid{0}.getUserData(id,\"itemid\") != \"\"){{", sFullGridId);
            output.Write("      myDataProcessor.setUpdated(id,true);");
            output.Write("      gridChanged{0} = true;", sFullGridId);
            output.Write("}");
            output.Write("})");
            output.Write("}");
            output.Write("</script>");
        }

        private void RenderImpersonate(HtmlTextWriter output, SPWeb web)
        {
            output.Write("<script>");
            output.Write("var gridChanged{0} = false;", sFullGridId);
            output.Write("var submitaftersave{0} = false;", sFullGridId);
            output.Write("var addaftersave{0} = false;", sFullGridId);
            output.Write("var haderrors{0} = false;", sFullGridId);
            output.Write("var myworkurl{0} = \"{1}/_layouts/epmlive/gettsmywork.aspx\";", sFullGridId, web.Url);
            if (impersonate)
            {
                output.Write("var actionurl{0} = \"{1}/_layouts/epmlive/dotsaction.aspx?duser={2}\";", sFullGridId, web.Url, HttpUtility.UrlEncode(username));
                output.Write(
                    "var myworkpost{0} = \"data={1}&edit={2}&source={3}&period={4}&duser={5}\";",
                    sFullGridId,
                    sFullParamList,
                    inEditMode,
                    HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()),
                    intPeriod,
                    HttpUtility.UrlEncode(username));
                output.Write(
                    "var otherworkpost{0} = \"data={1}&edit={2}&source={3}&period={4}&workType=1&duser={5}\";",
                    sFullGridId,
                    sFullParamList,
                    inEditMode,
                    HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()),
                    intPeriod,
                    HttpUtility.UrlEncode(username));
                output.Write(
                    "var nonworkpost{0} = \"data={1}&edit={2}&source={3}&period={4}&workType=2&duser={5}\";",
                    sFullGridId,
                    sFullParamList,
                    inEditMode,
                    HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()),
                    intPeriod,
                    HttpUtility.UrlEncode(username));
                output.Write(
                    "var searchworkpost{0} = \"data={1}&edit={2}&source={3}&period={4}&workType=4&allowOther={5}&duser={6}\";",
                    sFullGridId,
                    sFullParamList,
                    inEditMode,
                    HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()),
                    intPeriod,
                    CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPMLiveTSAllowUnassigned").ToLower(),
                    HttpUtility.UrlEncode(username));
            }
            else
            {
                output.Write("var actionurl{0} = \"{1}/_layouts/epmlive/dotsaction.aspx\";", sFullGridId, web.Url);
                output.Write(
                    "var myworkpost{0} = \"data={1}&edit={2}&source={3}&period={4}\";",
                    sFullGridId,
                    sFullParamList,
                    inEditMode,
                    HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()),
                    intPeriod);
                output.Write(
                    "var otherworkpost{0} = \"data={1}&edit={2}&source={3}&period={4}&workType=1\";",
                    sFullGridId,
                    sFullParamList,
                    inEditMode,
                    HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()),
                    intPeriod);
                output.Write(
                    "var nonworkpost{0} = \"data={1}&edit={2}&source={3}&period={4}&workType=2\";",
                    sFullGridId,
                    sFullParamList,
                    inEditMode,
                    HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()),
                    intPeriod);
                output.Write(
                    "var searchworkpost{0} = \"data={1}&edit={2}&source={3}&period={4}&workType=4&allowOther={5}\";",
                    sFullGridId,
                    sFullParamList,
                    inEditMode,
                    HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()),
                    intPeriod,
                    CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPMLiveTSAllowUnassigned").ToLower());
            }
        }

        private void RenderGrid(HtmlTextWriter output, SPWeb web, string firstEditorbox)
        {
            output.Write("var mygrid{0}Hidden = false;", sFullGridId);
            output.Write("var mygrid{0}Edit = {1};", sFullGridId, inEditMode.ToString().ToLower());
            output.Write("var mywork{0}Hidden = false;", sFullGridId);
            output.Write("var tsuid{0} = '{1}';", sFullGridId, tsuid);
            output.Write("var period{0} = '{1}';", sFullGridId, intPeriod);
            output.Write("var mygridwidth{0} = 0;", sFullGridId);
            output.Write("var firsteditorbox{0} = '{1}';", sFullGridId, firstEditorbox);
            output.Write(
                "var allowotherwork{0} = {1};",
                sFullGridId,
                EPMLiveCore.CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPMLiveTSAllowUnassigned").ToLower());
            output.Write("mygrid{0} = new dhtmlXGridObject('grid{1}');", sFullGridId, ID);
            output.Write("mygrid{0}.setImagePath(\"_layouts/epmlive/dhtml/xgrid/imgs/\");", sFullGridId);
            output.Write("mygrid{0}.setSkin(\"editgrid\");", sFullGridId);

            if (Height == "")
            {
                output.Write("mygrid{0}.enableAutoHeight(true);", sFullGridId);
            }
            else
            {
                var matches = Regex.Matches(Height, "\\d*");
                var height = "100";
                if (matches.Count > 0)
                {
                    height = matches[0].Value;
                    try
                    {
                        // CC-77863 I'm not replacing this call to int.TryParse because the code will look a lot worse
                        height = (int.Parse(height) - 30).ToString();
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError("Exception Suppressed {0}", ex);
                    }
                }
                output.Write("mygrid{0}.enableAutoHeight(true,{1},true);", sFullGridId, height);
            }

            output.Write("mygrid{0}.attachEvent(\"onEditCell\",cellChanged{0});", sFullGridId);
            output.Write("mygrid{0}.attachEvent(\"onEditCell\",function(stage,rowId,cellInd,newValue,oldValue){{", sFullGridId);
            output.Write("if ((stage==2)&&(newValue!=oldValue)){");
            output.Write("gridChanged{0} = true;", sFullGridId);
            output.Write("mygrid{0}.callEvent(\"onGridReconstructed\",[]);", sFullGridId);
            output.Write("return true;");
            output.Write("}");
            output.Write("return true;");
            output.Write("});");

            output.Write("mygrid{0}.setImageSize(1,1);", sFullGridId);
            output.Write("mygrid{0}.setDateFormat(\"%m/%d/%Y\");", sFullGridId);
            output.Write("mygrid{0}.attachEvent(\"onXLE\",clearLoader);", sFullGridId);
            output.Write("mygrid{0}.attachEvent(\"onXLE\",touchRows{0});", sFullGridId);
            if (editEvents == "false")
            {
                output.Write("mygrid{0}.attachEvent(\"onXLE\",disableCells{0});", sFullGridId);
            }

            output.Write("mygrid{0}.attachEvent(\"onXLE\",switchFilterLoad{0});", sFullGridId);
            if (status == "New")
            {
                output.Write("mygrid{0}.attachEvent(\"onXLE\",setAllUpdated{0});", sFullGridId);
            }

            output.Write("mygrid{0}.enableEditEvents(true,false,false);", sFullGridId);
            output.Write("mygrid{0}.attachEvent(\"onRowSelect\",selectRow{0});", sFullGridId);
            output.Write("mygrid{0}.enableTreeCellEdit(false);", sFullGridId);
            output.Write("mygrid{0}.enableMathEditing(false);", sFullGridId);
            output.Write("mygrid{0}.enableMathSerialization(true);", sFullGridId);

            ///CUSTOM PROPERTIES
            output.WriteLine("mygrid{0}._webpartid = '{1}';", sFullGridId, ID);
            output.WriteLine("mygrid{0}.setImagePath(\"_layouts/epmlive/dhtml/xgrid/imgs/\");", sFullGridId);
            output.WriteLine("mygrid{0}._gridMode = 'standard';", sFullGridId);

            var image = string.Format("/_layouts/{0}/images/formatmap32x32.png", web.Language);

            try
            {
                output.WriteLine(
                    "mygrid{0}._modifylist = {1};",
                    sFullGridId,
                    list.DoesUserHavePermissions(SPBasePermissions.ManageLists).ToString().ToLower());
            }
            catch
            {
                output.WriteLine("mygrid{0}._modifylist = false;", sFullGridId);
            }
            try
            {
                output.WriteLine(
                    "mygrid{0}._listperms = {1};",
                    sFullGridId,
                    list.DoesUserHavePermissions(SPBasePermissions.ManagePermissions).ToString().ToLower());
            }
            catch
            {
                output.WriteLine("mygrid{0}._listperms = false;", sFullGridId);
            }

            output.WriteLine("mygrid{0}._delegates = \"{1}\";", sFullGridId, strDelegates);
            output.WriteLine("mygrid{0}._cururl = '{1}';", sFullGridId, HttpContext.Current.Request.Url.AbsolutePath);
            output.WriteLine("mygrid{0}._lockedts = {1};", sFullGridId, lockedts);
            output.WriteLine("mygrid{0}._lockunsubmit = {1};", sFullGridId, lockunsubmit);
            output.WriteLine("mygrid{0}._timesheetstatus = '{1}';", sFullGridId, status);
            output.WriteLine("mygrid{0}._timesheetperiod = '{1}';", sFullGridId, strCurPeriodName);
            output.WriteLine("mygrid{0}._nextperiod = '{1}';", sFullGridId, strNextPeriod);
            output.WriteLine("mygrid{0}._previousperiod = '{1}';", sFullGridId, strPreviousPeriod);
            output.WriteLine("mygrid{0}._allperiods = '{1}';", sFullGridId, strAllPeriods);
            output.WriteLine("mygrid{0}._shownewmenu = false;", sFullGridId);
            output.WriteLine("mygrid{0}._allowedit = {1};", sFullGridId, allowEditToggle.ToString().ToLower());
            output.WriteLine("mygrid{0}._listid = '{1}';", sFullGridId, HttpUtility.UrlEncode(list.ID.ToString()).ToUpper());
            output.WriteLine("mygrid{0}._viewid = '{1}';", sFullGridId, HttpUtility.UrlEncode(view.ID.ToString()).ToUpper());
            output.WriteLine("mygrid{0}._viewurl = '{1}{2}';", sFullGridId, web.Url, view.ServerRelativeUrl);
            output.WriteLine("mygrid{0}._viewname = '{1}';", sFullGridId, view.Title);
            output.WriteLine("mygrid{0}._basetype = '{1}';", sFullGridId, list.BaseType);
            output.WriteLine("mygrid{0}._templatetype = '{1}';", sFullGridId, (int)list.BaseTemplate);
            output.WriteLine("mygrid{0}._newrow = false;", sFullGridId);
            output.WriteLine("mygrid{0}._gridid = '{0}';", sFullGridId);
            var stringBuilderForms = new StringBuilder();
            foreach (SPForm form in list.Forms)
            {
                switch (form.Type)
                {
                    case PAGETYPE.PAGE_DISPLAYFORM:
                        stringBuilderForms.AppendFormat(
                            "<Button Id='Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay' CommandValueId='{0}'"
                            + " Command='EditDefaultForm' Image16by16='/_layouts/{1}/images/formatmap16x16.png' Image16by16Top='-176'"
                            + " Image16by16Left='-16' Image32by32='/_layouts/{1}/images/formatmap32x32.png' Image32by32Top='-256'"
                            + " Image32by32Left='-320' LabelText='Default Display Form'/>",
                            HttpUtility.UrlEncode(form.ServerRelativeUrl),
                            web.Language);
                        break;
                    case PAGETYPE.PAGE_EDITFORM:
                        stringBuilderForms.AppendFormat(
                            "<Button Id='Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay' CommandValueId='{0}'"
                            + " Command='EditDefaultForm' Image16by16='/_layouts/{1}/images/formatmap16x16.png' Image16by16Top='-32' Image16by16Left='-80'"
                            + " Image32by32='/_layouts/{1}/images/formatmap32x32.png' Image32by32Top='-96' Image32by32Left='-448' LabelText='Default Edit Form'/>",
                            HttpUtility.UrlEncode(form.ServerRelativeUrl),
                            web.Language);
                        break;
                    case PAGETYPE.PAGE_NEWFORM:
                        stringBuilderForms.AppendFormat(
                            "<Button Id='Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay'"
                            + " CommandValueId='{0}' Command='EditDefaultForm' Image16by16='/_layouts/{1}/images/formatmap16x16.png'"
                            + " Image16by16Top='-128' Image16by16Left='-224' Image32by32='/_layouts/{1}/images/formatmap32x32.png' Image32by32Top='-128'"
                            + " Image32by32Left='-96' LabelText='Default New Form'/>",
                            HttpUtility.UrlEncode(form.ServerRelativeUrl),
                            web.Language);
                        break;
                    default:
                        Trace.TraceError("Unexpected Value {0}", form.Type);
                        break;
                }
            }
            output.WriteLine("mygrid{0}._formmenus = \"{1}\";", sFullGridId, stringBuilderForms);
            output.WriteLine(Properties.Resources.txtTimesheetRibbonFunctions.Replace("#gridid#", sFullGridId));

            output.Write("mygrid" + sFullGridId + ".init();");
        }

        private void RenderDataProcessorUpdateModel(HtmlTextWriter output, SPWeb web)
        {
            if (impersonate)
            {
                output.Write(
                    "myDataProcessor = new dataProcessor(\"{0}/_layouts/epmlive/savetimesheet.aspx?"
                    + "tsuid={1}&period={2}&edit={3}&columns={4}&duser={5}\");",
                    web.Url,
                    tsuid,
                    intPeriod,
                    inEditMode,
                    getViewFields(),
                    HttpUtility.UrlEncode(username));
            }
            else
            {
                output.Write(
                    "myDataProcessor = new dataProcessor(\"{0}/_layouts/epmlive/savetimesheet.aspx?" + "tsuid={1}&period={2}&edit={3}&columns={4}\");",
                    web.Url,
                    tsuid,
                    intPeriod,
                    inEditMode,
                    getViewFields());
            }
            output.Write("myDataProcessor.setUpdateMode(\"off\");");
        }

        private void RenderUpdateItemFunction(HtmlTextWriter output)
        {
            output.Write("function updateitem{0}(node){{", sFullGridId);
            output.Write("var id=node.getAttribute(\"sid\");");
            output.Write("mygrid{0}.setUserData(id, \"!nativeeditor_status\", \"\");", sFullGridId);
            output.Write("mygrid{0}.setUserData(id, \"tsitemuid\", node.getAttribute(\"tsitemuid\"));", sFullGridId);
            output.Write("return true;");
            output.Write("}");
        }

        private void RenderSelectRowFunction(HtmlTextWriter output)
        {
            output.Write("function selectRow{0}(id, ind){{", sFullGridId);
            output.Write("curRowId = id;");
            output.Write("curGrid = mygrid{0};", sFullGridId);
            output.Write("RefreshCommandUI();");
            output.Write("}");
        }

        private void RenderViewErrorFunction(HtmlTextWriter output)
        {
            output.Write("function viewError{0}(id){{", sFullGridId);
            output.Write("document.getElementById('dlgErrorText{0}').innerHTML=mygrid{0}.getUserData(id,\"lastError\");", sFullGridId);
            output.Write("sm('dlgError{0}',250,130);", sFullGridId);
            output.Write("}");
        }

        private void RenderSetTsuIdFunction(HtmlTextWriter output, SPWeb web)
        {
            output.Write("function settsuid{0}(node){{", sFullGridId);
            output.Write("var id=node.getAttribute(\"tsuid\");");
            output.Write(
                impersonate
                    ? string.Format(
                        "myDataProcessor.serverProcessor = \"{0}/_layouts/epmlive/savetimesheet.aspx?tsuid=\" + id + \"&period={1}&edit={2}&columns={3}&duser={4}\";",
                        web.Url,
                        intPeriod,
                        inEditMode,
                        getViewFields(),
                        HttpUtility.UrlEncode(username))
                    : string.Format(
                        "myDataProcessor.serverProcessor = \"{0}/_layouts/epmlive/savetimesheet.aspx?tsuid=\" + id + \"&period={1}&edit={2}&columns={3}\";",
                        web.Url,
                        intPeriod,
                        inEditMode,
                        getViewFields()));
            output.Write("tsuid{0} = id;", sFullGridId);
            output.Write("    if(submitaftersave{0})", sFullGridId);
            output.Write("    {");
            output.Write("      if(haderrors{0})", sFullGridId);
            output.Write("      {");
            output.Write("          alert('Cannot submit timesheet, there were 1 or more errors during save.');");
            output.Write("      }else{");
            output.Write("         submitaftersave{0} = false;", sFullGridId);
            output.Write("         submit{0}();", sFullGridId);
            output.Write("      }");
            output.Write("    }");
            output.Write("    else if(addaftersave{0}){{", sFullGridId);
            output.Write("         addaftersave{0} = false;", sFullGridId);
            output.Write("         autoAdd{0}();", sFullGridId);
            output.Write("     }");
            output.Write("}");
        }

        private void RenderMyErrorHandlerFunction(HtmlTextWriter output)
        {
            output.Write("function myErrorHandler{0}(obj){{", sFullGridId);
            output.Write("      var id = obj.getAttribute(\"sid\");");
            output.Write(
                "      mygrid{0}.cells(id,1).setValue(\"<a href=\\\"javascript:viewError{0}('\" + id + \"');"
                + "\\\"><img src='/_layouts/images/EXCLAIM.GIF' border='0'></a>\");",
                sFullGridId);
            output.Write("      mygrid{0}.setUserData(id,\"lastError\",obj.firstChild.data);", sFullGridId);
            output.Write("      haderrors{0} = true;", sFullGridId);
            output.Write("}");
        }

        private void RenderUpdateNewsFunction(HtmlTextWriter output)
        {
            output.Write("function updatewss{0}(obj){{", sFullGridId);
            output.Write("      var id = obj.getAttribute(\"sid\");");
            output.Write("      mygrid{0}.cells(id,1).setValue(\"\");", sFullGridId);
            output.Write("      mygrid{0}.setUserData(id,\"lastError\",\"\");", sFullGridId);
            output.Write("}");

            output.Write("myDataProcessor.defineAction(\"error100\", myErrorHandler{0});", sFullGridId);
            output.Write("myDataProcessor.defineAction(\"updateitem\", updateitem{0});", sFullGridId);
            output.Write("myDataProcessor.defineAction(\"settsuid\", settsuid{0});", sFullGridId);
            output.Write("myDataProcessor.defineAction(\"updatewss\", updatewss{0});", sFullGridId);
            output.Write("myDataProcessor.setTransactionMode(\"POST\", true);");

            output.Write("myDataProcessor.setOnAfterUpdate(function(id,action,newid){");
            output.Write("if(myDataProcessor.getSyncState())");
            output.Write("{");
            output.Write("    gridChanged{0} = false;", sFullGridId);
            output.Write("    mygrid{0}.setSizes();", sFullGridId);
            output.Write("    myDataProcessor.updatedRows = [];");
            output.Write("    AfterSave(mygrid{0});", sFullGridId);
            output.Write("    hm('dlgSaving');");
            output.Write("}");
            output.Write("});");
        }

        private void RenderLoadXFunction(HtmlTextWriter output, SPWeb web)
        {
            output.Write("function loadX{0}(){{", sFullGridId);
            output.Write("mygridwidth{0} = document.getElementById('WebPart{1}').offsetWidth - 20;", sFullGridId, Qualifier);
            if (impersonate)
            {
                output.Write(
                    "mygrid{0}.post(\"{1}/_layouts/epmlive/gettimesheet.aspx\",\""
                    + "data={2}&source={3}&rnd={4}&period={5}&edit={6}&status={7}&width=\" + mygridwidth{0} + \"&duser={8}\");",
                    sFullGridId,
                    web.Url,
                    sFullParamList,
                    HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()),
                    Guid.NewGuid(),
                    intPeriod,
                    inEditMode,
                    status,
                    HttpUtility.UrlEncode(username));
            }
            else
            {
                output.Write(
                    "mygrid{0}.post(\"{1}/_layouts/epmlive/gettimesheet.aspx\",\""
                    + "data={2}&source={3}&rnd={4}&period={5}&edit={6}&status={7}&width=\" + mygridwidth{0});",
                    sFullGridId,
                    web.Url,
                    sFullParamList,
                    HttpUtility.UrlEncode(HttpContext.Current.Request.Url.ToString()),
                    Guid.NewGuid(),
                    intPeriod,
                    inEditMode,
                    status);
            }

            output.Write("}");
        }

        private void RenderClickTabFunction(HtmlTextWriter output)
        {
            output.WriteLine("function clickTab(){");
            output.WriteLine("var wp = document.getElementById('MSOZoneCell_WebPart{0}');", Qualifier);
            output.WriteLine("fireEvent(wp, 'mouseup');");
            output.WriteLine("setTimeout(\"clickbrowse()\",1000);");
            output.WriteLine("}");

            output.WriteLine("function clickbrowse(){");
            output.WriteLine("var wp2 = document.getElementById('Ribbon.Timesheet-title').firstChild;");
            output.WriteLine("fireEvent(wp2, 'click');");
            output.WriteLine("}");

            output.Write("SP.SOD.executeOrDelayUntilScriptLoaded(clickTab, \"GridViewContextualTabPageComponent.js\");");

            output.Write("try{");
            output.WriteLine("setTimeout(\"loadX{0}()\", 100);", sFullGridId);

            output.Write("}catch(e){alert(e);}");
        }

        private void RenderValidateValuesFunction(HtmlTextWriter output, SPWeb web)
        {
            var daysDefinitions = EPMLiveCore.CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPMLiveDaySettings").Split('|');

            var minStringBuilder = new StringBuilder(string.Empty);
            var maxStringBuilder = new StringBuilder(string.Empty);

            for (var i = 0; i < 20; i += 3)
            {
                if (string.Equals(daysDefinitions[i], "true", StringComparison.OrdinalIgnoreCase))
                {
                    minStringBuilder.Append(string.Format(",{0}", daysDefinitions[i + 1]));
                    maxStringBuilder.Append(string.Format(",{0}", daysDefinitions[i + 2]));
                }
            }
            var min = minStringBuilder.ToString();
            var max = maxStringBuilder.ToString();

            if (min.Length > 1)
            {
                min = min.Substring(1);
            }
            if (max.Length > 1)
            {
                max = max.Substring(1);
            }

            output.Write("var dayMins = [{0}];", min);
            output.Write("var dayMaxs = [{0}];", max);

            output.Write("function validateValues{0}(){{", sFullGridId);
            output.Write(
                inEditMode
                    ? string.Format("     var cols = {0};", view.ViewFields.Count + 2)
                    : string.Format("     var cols = {0};", view.ViewFields.Count + 1));

            output.Write("      var colCount = 0;");
            output.Write("     for(var i = cols;i<mygrid{0}.getColumnsNum() - 2;i++){{", sFullGridId);
            output.Write("          var summ = 0;");
            output.Write("          mygrid" + sFullGridId + ".forEachRow(function(id){");
            output.Write("                if(mygrid{0}.getUserData(id,\"itemid\") != \"\"){{", sFullGridId);
            output.Write("                     var vals = mygrid{0}.cells(id,i).getValue();", sFullGridId);
            output.Write("                     if(mygrid{0}.getColType(i) == \"timeeditor\"){{", sFullGridId);
            output.Write("                          if(vals.split('|')[0] != \"\"){");
            output.Write("                               var strVals = vals.split('|');");
            output.Write("                               for(var j = 0;j<strVals.length;j+=2){");
            output.Write("                                    if(strVals[j] != \"N\" && parseFloat(strVals[j + 1]).toString() != \"NaN\")");
            output.Write("                                         summ += parseFloat(strVals[j + 1]);");
            output.Write("                               }");
            output.Write("                          }");
            output.Write("                     }else{");
            output.Write("                          if(parseFloat(vals).toString() != \"NaN\")");
            output.Write("                               summ += parseFloat(vals);");
            output.Write("                     }");
            output.Write("               }");
            output.Write("          });");
            output.Write("          if(summ < dayMins[colCount]){");
            output.Write(
                "               alert('The minimum for:\\r\\n ' + mygrid{0}.getColumnLabel(i) + '\\r\\n is ' + dayMins[colCount] + ' hours, you currently have ' + summ + ' hours.');",
                sFullGridId);
            output.Write("               return false;");
            output.Write("          }");
            output.Write("          if(summ > dayMaxs[colCount]){");
            output.Write(
                "               alert('The maximum for:\\r\\n ' + mygrid{0}.getColumnLabel(i) + '\\r\\n is ' + dayMaxs[colCount] + ' hours, you currently have ' + summ + ' hours.');",
                sFullGridId);
            output.Write("               return false;");
            output.Write("          }");
            output.Write("          colCount++;");
            output.Write("     }");
            output.Write("     return true;");
            output.Write("}");
        }

        private void RenderGridCheckedIdsFunction(HtmlTextWriter output)
        {
            output.WriteLine("mygrid{0}.getCheckedIds = function(){{", sFullGridId);
            output.WriteLine(
                @"
                var ids = """";
                this.forEachRow(function (id) {
			        var c = this.cells(id, 0);
			        if (c.isCheckbox() && !c.cell.firstChild.disabled && c.cell.firstChild.checked)
                    {
                        var listid = this.getUserData(id,""listid"");
        	            var itemid = this.getUserData(id,""itemid"");
        	            var webid = this.getUserData(id,""webid"");
                        if(itemid != """")
                        {
                            ids += "","" + webid + ""."" + listid + ""."" + itemid;
                        }
                    }
		        });

                if(ids == """")
                {
                    var rowId = this.getSelectedRowId();
                    var listid = this.getUserData(rowId,""listid"");
        	        var itemid = this.getUserData(rowId,""itemid"");
        	        var webid = this.getUserData(rowId,""webid"");
                    if(itemid != """")
                    {
                        ids = webid + ""."" + listid + ""."" + itemid;
                    }
                }

                if(ids != """" && ids[0] == ',')
                    ids = ids.substring(1);

                return ids;
            };");
        }

        private void RenderGridCheckedItemsFunction(HtmlTextWriter output)
        {
            output.WriteLine("mygrid{0}.getCheckedItems = function(){{", sFullGridId);
            output.WriteLine(
                @"
                var ids = """";
                this.forEachRow(function (id) {
			        var c = this.cells(id, 0);
			        if (c.isCheckbox() && !c.cell.firstChild.disabled && c.cell.firstChild.checked)
                    {
                        var listid = this.getUserData(id,""listid"");
        	            var itemid = this.getUserData(id,""itemid"");
        	            var webid = this.getUserData(id,""webid"");
                        if(itemid != """")
                        {
                            ids += "","" + itemid;
                        }
                    }
		        });

                if(ids == """")
                {
                    var rowId = this.getSelectedRowId();
                    var listid = this.getUserData(rowId,""listid"");
        	        var itemid = this.getUserData(rowId,""itemid"");
        	        var webid = this.getUserData(rowId,""webid"");
                    if(itemid != """")
                    {
                        ids = itemid;
                    }
                }

                if(ids != """" && ids[0] == ',')
                    ids = ids.substring(1);

                return ids;
            };");
        }

        private void RenderDialogNote(HtmlTextWriter output)
        {
            output.Write(
                "<div id=\"dlgNote\" class=\"dialog\"><table width=\"100%\"><tr><td align=\"left\""
                + " class=\"ms-sectionheader\"><H3 class=\"ms-standardheader\">Approval Note:</h3><br />"
                + "{0}<br><br></td></tr><tr><td align=\"right\"><a href=\"javascript:hm('dlgNote');\""
                + " class=\"ms-descriptiontext\">close</a></td></tr></table></div>",
                appNote);
        }

        private void RenderExcels(HtmlTextWriter output)
        {
            var excels = Properties.Resources.txtTimesheetBase.Replace("#gridid#", sFullGridId).Replace("#griduid#", ID);
            excels = excels.Replace("#peid#", peMulti.ClientID);
            excels = excels.Replace("#peuid#", peMulti.UniqueID);
            excels = excels.Replace("#pesid#", peSingle.ClientID);
            excels = excels.Replace("#pesuid#", peSingle.UniqueID);

            output.Write("<script language=\"javascript\">");
            output.Write(Properties.Resources.txtExcels.Replace("#gridid#", sFullGridId));

            output.Write("</script>");

            output.Write(excels);
        }

        private string getViewFields()
        {
            string fields = "";
            foreach (string f in view.ViewFields)
            {
                fields += "\n" + getRealField(list.Fields.GetFieldByInternalName(f)).InternalName;
            }
            if (fields.Length > 1)
                fields = fields.Substring(1);

            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(fields);

            return Convert.ToBase64String(toEncodeAsBytes);

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

        private void appendParam(string param, string val)
        {
            sFullParamList += "\n" + param + "\t" + val;
        }


        private void buildParams(SPWeb web)
        {

            bool useNew = false;

            appendParam("List", PropList);
            appendParam("View", PropView);
            appendParam("FilterField", Page.Request["FilterField1"]);
            appendParam("FilterValue", Page.Request["FilterValue1"]);
            appendParam("GridName", sFullGridId);
            appendParam("AGroups", "|");
            appendParam("Expand", "False");

            EPMLiveCore.GridGanttSettings gSettings = new EPMLiveCore.GridGanttSettings(list);

            appendParam("Start", gSettings.StartDate);
            appendParam("Finish", gSettings.DueDate);
            appendParam("Percent", gSettings.Progress);
            appendParam("WBS", gSettings.WBS);
            appendParam("Milestone", gSettings.Milestone);
            appendParam("Executive", gSettings.Executive.ToString());
            appendParam("Info", gSettings.Information);
            appendParam("LType", gSettings.ItemLink);
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using(SPSite site = new SPSite(web.Site.ID))
                {
                    using(SPWeb rweb = site.RootWeb)
                    {
                        appendParam("RLists", EPMLiveCore.CoreFunctions.getConfigSetting(rweb, "EPMLiveTSLists").Replace("\r\n", ","));
                    }
                }
            });
            appendParam("RSites", gSettings.RollupSites.Replace("\r\n", ","));
            appendParam("HideNew", gSettings.HideNewButton.ToString());
            appendParam("UsePerf", gSettings.Performance.ToString());
            appendParam("AllowEdit", gSettings.AllowEdit.ToString());
            appendParam("EditDefault", gSettings.EditDefault.ToString());
            appendParam("ShowInsert", gSettings.ShowInsert.ToString());
            useNew = gSettings.UseNewMenu;
            appendParam("UseNew", gSettings.UseNewMenu.ToString());
            appendParam("DisableNew", gSettings.DisableNewItemMod.ToString());
            appendParam("NewName", gSettings.NewMenuName);
            appendParam("UsePopup", gSettings.UsePopup.ToString());
            appendParam("Requests", gSettings.EnableRequests.ToString());
        
            sFullParamList = sFullParamList.Substring(1);

            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sFullParamList);

            sFullParamList = Convert.ToBase64String(toEncodeAsBytes);

            //case 0:
            //            output.Write("mygrid" + sFullGridId + "._newitemurl = '" + ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + list.Forms[PAGETYPE.PAGE_NEWFORM].ServerRelativeUrl + "';");
            //            break;
            //        case 1:
            //            output.Write("mygrid" + sFullGridId + "._newitemurl = '" + ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "/_layouts/epmlive/newitem.aspx';");
            //            break;
            //        case 2:
            //            output.Write("mygrid" + sFullGridId + "._newitemurl = '" + ((web.ServerRelativeUrl == "/") ? "" : web.ServerRelativeUrl) + "/_layouts/epmlive/newapp.aspx';");
            //            break;
        }

        //private string getGridParams(bool nonwork)
        //{
            

            
            
        //    string data = "";
        //    SPSecurity.RunWithElevatedPrivileges(delegate()
        //    {
        //        string strProps = EPMLiveCore.CoreFunctions.getListSetting(SPContext.Current.List, "GeneralSettings");
        //        string[] props = strProps.Split('\n');

        //        string strLists = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveTSLists");

        //        strLists = strLists.Replace(",", "|").Replace("\r\n", ",");

        //        if (props.Length > 12)
        //        {

        //            if (nonwork)
        //                strLists = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveTSNonWork");

        //            data = PropList + "\n" + PropView + "\n" + props[3] + "\n" + props[5] + "\n" + props[7] + "\n" + strLists + "\n" + Page.Request["FilterField1"] + "\n" + Page.Request["FilterValue1"] + "\n" + props[9].Replace("\r\n", ",") + "\n" + sFullGridId + "\n\n\n" + props[12];

        //            if (props.Length > 19)
        //                data += "\n" + props[19];
        //            else
        //                data += "\nFalse";
        //        }
        //        else
        //            data = PropList + "\n" + PropView + "\n\n\n\n" + strLists + "\n" + Page.Request["FilterField1"] + "\n" + Page.Request["FilterValue1"] + "\n\n" + sFullGridId + "\n\n\n\n";




        //    });
        //    byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(data);
        //    return Convert.ToBase64String(toEncodeAsBytes);
        //}

        public void processControls(Control parentControl, string ZoneIndex, string viewUrl, SPWeb curWeb)
        {
            foreach (Control childControl in parentControl.Controls)
            {
                if (childControl.ToString() == "System.Web.UI.WebControls.Label")
                {
                    if (childControl.ID == "lblFilter")
                    {
                        try
                        {
                            System.Web.UI.WebControls.Label lblFilterText = (System.Web.UI.WebControls.Label)parentControl.FindControl("lblFilterText");
                            System.Web.UI.WebControls.Label lblLink = (System.Web.UI.WebControls.Label)childControl;
                            lblLink.Text = "<a href=\"#\" onclick=\"Javascript:switchFilter" + ZoneIndex + "('" + lblFilterText.ClientID + "');\">";
                        }
                        catch { }
                    }
                }
                if (childControl.ToString().ToUpper() == "MICROSOFT.SHAREPOINT.WEBCONTROLS.NEWMENU")
                {
                    childControl.Visible = false;
                }

                if (childControl.ToString().ToUpper() == "MICROSOFT.SHAREPOINT.WEBCONTROLS.ACTIONSMENU")
                {
                    var menu = (ActionsMenu)childControl;

                    ResourcePlanning.SetMenuVisibility(menu, "EditInGridButton", false);
                    ResourcePlanning.SetMenuVisibility(menu, "ExportToDatabase", false);
                    ResourcePlanning.SetMenuVisibility(menu, "ExportToSpreadsheet", false);
                    ResourcePlanning.SetMenuVisibility(menu, "ViewRSS", false);
                    ResourcePlanning.SetMenuVisibility(menu, "SubscribeButton", false);

                    menu.AddMenuItem("PrintGrid", "Print Grid", "/_layouts/epmlive/images/printmenu.GIF", "View printable list.", "", "printgrid" + ZoneIndex + "()");

                    string url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                    if (url.Contains("?"))
                        url += "&";
                    else
                        url += "?";

                    if (allowEditToggle)
                    {
                        if (inEditMode)
                        {
                            menu.AddMenuItem("SwitchToView", "Switch To View Mode", "/_layouts/epmlive/images/menugridview.GIF", "View list using EPM Live Grid.", url + "webpartid=" + this.ID + "&edit=0", "");
                        }
                        else
                        {
                            menu.AddMenuItem("SwitchToEdit", "Switch To Edit Mode", "/_layouts/images/menudatasheet.gif", "Edit list using the grid view.", url + "webpartid=" + this.ID + "&edit=1", "");
                        }
                    }

                }

                processControls(childControl, ZoneIndex, viewUrl, curWeb);
            }
        }
    }
}
