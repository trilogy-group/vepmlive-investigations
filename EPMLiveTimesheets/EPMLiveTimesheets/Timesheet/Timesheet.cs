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
            output.Write("<style>");
            output.Write(".ms-usereditor { width:200px; }");
            output.Write(".grid_hover { border: 10px solid #91CDF2; background-color: #F2FAFF } ");
            output.Write("</style>");



            output.Write("<div id=\"people" + sFullGridId + "\" style=\"display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width=200px; Z-Index:99;\">");
            output.Write("<div id=\"peoplecheck" + sFullGridId + "\" style=\"overflow: auto; width: 200px; height: 100px;  background-color: #FFFFFF; border: 1px solid #808080; margin-top:2px; padding:3px;\" class=\"ms-descriptiontext\">");
            output.Write("</div>");

            output.Write("<table border=\"0\" width=\"100%\"><tr><td>");
            output.Write("<a onclick=\"javascript:viewChecks" + sFullGridId + "('" + sFullGridId + "');\"><img id=\"peoplecheckimg" + sFullGridId + "\" src=\"_layouts/images/TPMAX1.GIF\" border=\"0\"></a><br>");
            output.Write("</td><td align=\"right\">");
            output.Write("<font class=\"ms-descriptiontext\"><a style=\"cursor:pointer\" onclick=\"javascript:mygrid" + sFullGridId + ".editStop();\">Close</a></font>");
            output.Write("</td></tr></table>");
            output.Write("<div id=\"divPe" + sFullGridId + "\" style=\"display:none;\">");
            peMulti.RenderControl(output);
            output.Write("</div>");
            output.Write("</div>");

            //===============================Single================================
            output.Write("<div id=\"peoplesingle" + sFullGridId + "\" style=\"display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width=200px; Z-Index:99;\">");
            output.Write("<div id=\"peoplechecksingle" + sFullGridId + "\" style=\"width: 200px; height: 100px;  background-color: #FFFFFF; border: 1px solid #808080; margin-top:2px; padding:0px;\" class=\"ms-descriptiontext\">");
            output.Write("<select size=\"6\" onclick=\"changeUser" + sFullGridId + "(this);\" id=\"peoplecheckselect" + sFullGridId + "\"  style=\"width:100%;height:100%\"><option>test</option></select>");
            output.Write("</div>");

            output.Write("<table border=\"0\" width=\"200\"><tr><td>");
            output.Write("<a onclick=\"javascript:viewDropDown" + sFullGridId + "('" + sFullGridId + "');\"><img id=\"peoplechecksingleimg" + sFullGridId + "\" src=\"_layouts/images/TPMAX1.GIF\" border=\"0\"></a><br>");
            output.Write("</td><td align=\"right\">");
            output.Write("<font class=\"ms-descriptiontext\"><a style=\"cursor:pointer\" onclick=\"javascript:mygrid" + sFullGridId + ".editStop();\">Close</a></font>");
            output.Write("</td></tr></table>");

            output.Write("<div id=\"divPes" + sFullGridId + "\" style=\"display:none;\">");
            peSingle.RenderControl(output);
            output.Write("</div>");
            output.Write("</div>");
            //==============================MultiChoice==============================
            output.Write("<div id=\"multichoicegrid" + this.ID + "\" style=\"display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width:200px;height:160px Z-Index:99;\">");
            output.Write("<div id=\"multichoiceinner" + sFullGridId + "\" style=\"width: 100%; height: 100%;  background-color: #FFFFFF; border: 1px solid #808080; margin-top:2px; padding:0px;\" class=\"ms-descriptiontext\">");
            output.Write("test");
            output.Write("</div>");
            output.Write("<table border=\"0\" width=\"200\"><tr><td align=\"right\">");
            output.Write("<font class=\"ms-descriptiontext\"><a style=\"cursor:pointer\" onclick=\"javascript:mygrid" + sFullGridId + ".editStop();\">Close</a></font>");
            output.Write("</td></tr></table>");
            output.Write("</div>");

            //============================Time Editor===============================

            string firsteditorbox = "";
            output.Write(SharedFunctions.getTimeEditorDiv(editEvents, sFullGridId, cn, web, out firsteditorbox));

            //=============end time editor======================

            output.Write("<link rel=\"stylesheet\" href=\"/_layouts/epmlive/modal/modalmain.css\" type=\"text/css\" /> ");


            output.Write("<script type=\"text/javascript\" src=\"/_layouts/epmlive/modal/modal.js\"></script>");
            //===================================
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid_skins.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/calendar/dhtmlxcalendar.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/skins/dhtmlxmenu_dhx_blue.css\">");
            //output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xmenu/context.css\">");
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

            //output.Write("<script src=\"/_layouts/epmlive/DHTML/dhtmlxajax.js\"></script>");

            //if (inEditMode)
            {

                output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/excells/dhtmlxgrid_excell_calendar.js\"></script>");
                output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/excells/dhtmlxgrid_excell_combo.js\"></script>");
                output.Write("<script src=\"_layouts/epmlive/DHTML/xgrid/excells/dhtmlxgrid_excell_dhxcalendar.js\"></script>");
                output.Write("<script src=\"_layouts/epmlive/DHTML/xcombo/dhtmlxcombo.js\"></script>");
                output.Write("<script src=\"_layouts/epmlive/DHTML/calendar/dhtmlxcalendar.js\"></script>");
                output.Write("<script src=\"_layouts/epmlive/DHTML/xdataproc/dhtmlxdataprocessor.js\"></script>");
            }
            


            //-=====================================================================

            output.Write("<style>.menuTable{background-color:#ffffff;}.contextMenuover, .contextMenudown{background-color:#9ac2e5;}.contextMenuover td{color:#000000;} </style>");

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

            output.Write("<div id=\"grid" + this.ID + "\"  style=\"width:100%;display:none;\" class=\"ms-listviewtable\" ></div>\r\n\r\n");

            /*
            LiteralControl lt = new LiteralControl(@"<table border=0 cellpadding=0 cellspacing=0 style='margin-right: 4px' width='200' id='workviewselector" + sFullGridId + @"'>
            <tr>
            <td nowrap class=""ms-listheaderlabel"">Work View:&nbsp;</td>
            <td id=""EPMLiveTaskRollupViewSelectorMenuTd"" nowrap=""nowrap"" class=""ms-viewselector"" onmouseover=""this.className='ms-viewselector'"" onmouseout=""this.className='ms-viewselector'"">
            <span style=""display:none"">
                <menu type='ServerMenu' id=""EPMLiveTaskRollupViewSelectorMenu"" CompactMode=""true"">
                    <ie:menuitem id=""zz290_DefaultView"" type=""option"" onMenuClick=""changeworkview" + sFullGridId + @"(myworkpost" + sFullGridId + @",'My Work');"" text=""My Work"" menuGroupId=""100""></ie:menuitem>
                    <ie:menuitem id=""zz310_View2"" type=""option"" onMenuClick=""changeworkview" + sFullGridId + @"(otherworkpost" + sFullGridId + @",'All Work');"" text=""All Work"" menuGroupId=""300""></ie:menuitem>
                </menu>
            </span>
            <span title=""Open Menu"">
            <div  id=""zz35_WorkSelectorMenu_t"" class=""ms-viewselector"" onmouseover=""MMU_PopMenuIfShowing(this);MMU_EcbTableMouseOverOut(this, true)"" hoverActive=""ms-viewselectorhover"" hoverInactive=""ms-viewselector"" onclick=""MMU_Open(byid('EPMLivetaskRollupViewSelectorMenu'), MMU_GetMenuFromClientId('zz35_WorkSelectorMenu'),event,true, 'EPMLiveTaskRollupViewSelectorMenuTd', 0);"" foa=""MMU_GetMenuFromClientId('zz35_WorkSelectorMenu')"" oncontextmenu=""this.click(); return false;"" nowrap=""nowrap"">
            <a id=""zz35_WorkSelectorMenu"" accesskey=""W"" href=""#"" onclick=""javascript:return false;"" style=""cursor:hand;white-space:nowrap;"" onfocus=""MMU_EcbLinkOnFocusBlur(byid('EPMLivetaskRollupViewSelectorMenu'), this, true);"" onkeydown=""MMU_EcbLinkOnKeyDown(byid('EPMLivetaskRollupViewSelectorMenu'), MMU_GetMenuFromClientId('zz35_WorkSelectorMenu'), event);"" onclick=""MMU_Open(byid('EPMLivetaskRollupViewSelectorMenu'), MMU_GetMenuFromClientId('zz35_WorkSelectorMenu'),event,true, 'EPMLiveTaskRollupViewSelectorMenuTd', 0);"" oncontextmenu=""this.click(); return false;"" menuTokenValues=""MENUCLIENTID=zz35_WorkSelectorMenu,TEMPLATECLIENTID=EPMLivetaskRollupViewSelectorMenu"" serverclientid=""zz35_WorkSelectorMenu"">
            My Work
            <img src=""/_layouts/images/blank.gif"" border=""0"" alt=""Use SHIFT+ENTER to open the menu (new window).""/></a>
            <img align=""absbottom"" src=""/_layouts/images/blank.gif"" alt="""" /></div></span>
            </td>
            </tr>
            </table>");*/

            LiteralControl lt = new LiteralControl(@"<table border=0 cellpadding=0 cellspacing=0 style='margin-right: 4px' width='200' id='workviewselector" + sFullGridId + @"'>
		    <tr>
		    <td nowrap class=""ms-listheaderlabel"">Work View:&nbsp;</td>
            <td id=""WorkSelectorTd"" nowrap=""nowrap"" class=""ms-viewselector"" onmouseover=""this.className='ms-viewselector'"" onmouseout=""this.className='ms-viewselector'"">
            <span style=""display:none"">
            <menu type='ServerMenu' id=""zz30_WorkSelectorMenu"" CompactMode=""true"">
                <ie:menuitem id=""zz290_DefaultView"" type=""option"" onMenuClick=""changeworkview" + sFullGridId + @"(myworkpost" + sFullGridId + @",'My Work');"" text=""My Work"" menuGroupId=""100""></ie:menuitem>
                <ie:menuitem id=""zz310_View2"" type=""option"" onMenuClick=""changeworkview" + sFullGridId + @"(otherworkpost" + sFullGridId + @",'All Work');"" text=""All Work"" menuGroupId=""300""></ie:menuitem>
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
		    </table>");

            output.Write("<div id=\"searchdiv" + this.ID + "\" style=\"width:100%;display:none;\" align=\"center\">");
            output.Write("<table width=\"100%\" height=\"20\" cellpadding=\"3\" cellspacing=\"0\"><tr><td valign=\"top\" align=\"left\" height=\"20\" class=\"ms-titlearealeft\"><h3 class=\"ms-pagetitle\">Search For Work</h2></td><td align=\"right\" height=\"20\" class=\"ms-titlearealeft\">");
            output.Write("</td></tr></table>");
            output.Write("<table width=\"100%\">");
            output.Write("<tr><td class=\"ms-descriptiontext ms-inputformdescription\">Select Column: <select id=\"searchCol" + sFullGridId + "\" class=\"ms-input\"><option value=\"Title\">Title</option>");

            SortedList<string, string> sl = new SortedList<string, string>();

            foreach (SPField f in list.Fields)
            {
                if (f.Reorderable && f.InternalName != "Title")
                {
                    sl.Add(f.Title, f.InternalName);
                }
            }
            foreach (string f in sl.Keys)
            {
                output.Write("<option value=\"" + sl[f].ToString() + "\">" + f.ToString() + "</option>");
            }


            output.Write("</select></td></tr>");
            output.Write("<tr><td class=\"ms-descriptiontext ms-inputformdescription\">Enter Search Term: <input type=\"text\" size=\"30\" class=\"ms-input\" id=\"searchTerm" + sFullGridId + "\" onKeyDown=\"KeyDownHandler" + sFullGridId + "(event)\"> <input type=\"button\" class=\"ms-input\" value=\"Go\" onClick=\"javascript:doSearch" + sFullGridId + "();\"> <input type=\"button\" class=\"ms-input\" value=\"Cancel\" onClick=\"javascript:cancelSearch" + sFullGridId + "();\"></td></tr></table>");
            output.Write("</div>");

            output.Write("<div id=\"workdiv" + this.ID + "\" style=\"width:100%;display:none;\" align=\"center\">");

            output.Write("<table width=\"100%\" height=\"20\" cellpadding=\"3\" cellspacing=\"0\"><tr><td valign=\"top\" align=\"left\" height=\"20\" class=\"ms-titlearealeft\"><h3 class=\"ms-pagetitle\" id=\"myworktitle\">Available Time Sheet Items: My Work</h3></td><td align=\"right\" height=\"20\" class=\"ms-titlearealeft\">");

            lt.RenderControl(output);

            output.Write("</td></tr></table>");

            ToolBarButton tbLink = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            tbLink.Text = "Add To Timesheet";
            tbLink.ImageUrl = "/_layouts/images/EXPTITEM.GIF";
            tbLink.NavigateUrl = "";
            tbLink.OnClientClick = "Javascript:addMyWork" + sFullGridId + "();";
            tbLink.ToolTip = "Add";

            ToolBarButton tbLink2 = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            tbLink2.NavigateUrl = "Javascript:switchfilterwork" + sFullGridId + "('" + worktoolbar.Buttons.ClientID + "_myworkfilter_LinkText');";
            tbLink2.Text = "Show Filters";
            tbLink2.ImageUrl = "/_layouts/epmlive/images/gridfilter.gif";
            tbLink2.ToolTip = "Filters";
            tbLink2.ID = "myworkfilter";



            ToolBarButton tbClose = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
            tbClose.Text = "";
            tbClose.ImageUrl = "/_layouts/images/close.gif";
            tbClose.OnClientClick = "Javascript:cancelGetMyWork" + sFullGridId + "();";
            tbClose.NavigateUrl = "";
            tbClose.ToolTip = "Hide";

            Panel pnl1 = new Panel();
            pnl1.Controls.Add(new LiteralControl("<div class=\"ms-buttoninactivehover\" onmouseover=\"this.className='ms-buttonactivehover'\" onmouseout=\"this.className='ms-buttoninactivehover'\" onClick=\"Javascript:addMyWork" + sFullGridId + "();\"><img align='absmiddle' alt=\"\" src=\"/_layouts/images/EXPTITEM.gif\" style='border-width:0px;'> Add To Timesheet</div>"));
            worktoolbar.Buttons.Controls.Add(pnl1);
            //worktoolbar.Buttons.Controls.Add(tbLink2);



            worktoolbar.RightButtons.Controls.Add(lt);
            worktoolbar.RightButtons.Controls.Add(tbClose);

            worktoolbar.RenderControl(output);

            output.Write("<div  width=\"100%\" id=\"loadingmyworkgrid" + this.ID + "\" align=\"center\">");
            output.Write("<img src=\"/_layouts/images/gears_anv4.gif\" style=\"vertical-align: middle;\"/> Loading Items...");
            output.Write("</div>");

            output.Write("<div id=\"myworkgrid" + this.ID + "\" style=\"width:100%;display:none;\"></div>");
            output.Write("<div id=\"errordiv" + sFullGridId + "\" style=\"font-color:red;font-size:11px;\"></div>");

            output.Write("</div>\r\n\r\n");

            output.Write("<div  width=\"100%\" id=\"loadinggrid" + this.ID + "\" align=\"center\">");
            output.Write("<img src=\"_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/> Loading Items...");
            output.Write("</div>");

            output.Write("<script language=\"javascript\">");



            output.Write("function gridfilter" + sFullGridId + "(value){");
            output.Write("var vals = value.split('|');");
            output.Write("mygrid" + sFullGridId + ".filterBy(vals[0],vals[1]);");
            output.Write("}");

            output.Write("function myworkgridfilter" + sFullGridId + "(value){");
            output.Write("var vals = value.split('|');");
            output.Write("mywork" + sFullGridId + ".filterBy(vals[0],vals[1]);");
            output.Write("}");

            output.Write("function setSize" + sFullGridId + "(){mygrid" + sFullGridId + "._askRealRows();}");

            output.Write("function printgrid" + sFullGridId + "() {var temp = mygrid" + sFullGridId + ".hdr.rows[2];var parent = temp.parentNode;parent.removeChild(temp,true);mygrid" + sFullGridId + ".printView();parent.appendChild(temp);}");
            output.Write("function switchFilter" + sFullGridId + "(hlink){");
            output.Write("var input1 = mygrid" + sFullGridId + ".hdr.rows[2];");
            output.Write("if(mygrid" + sFullGridId + "Hidden == false){");
            output.Write("input1.style.display = \"none\";");
            output.Write("mygrid" + sFullGridId + "Hidden = true;");
            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Show Filters\";}");
            output.Write("}else{");
            output.Write("input1.style.display = \"\";");
            output.Write("mygrid" + sFullGridId + "Hidden = false;");
            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Hide Filters\";}");
            output.Write("}");
            output.Write("mygrid" + sFullGridId + ".setSizes();");
            output.Write("}");
            output.Write("function switchFilterLoad" + sFullGridId + "(){switchFilter" + sFullGridId + "(null);}");

            output.Write("function switchfilterwork" + sFullGridId + "(hlink){");
            output.Write("var input1 = mywork" + sFullGridId + ".hdr.rows[2];");
            output.Write("if(mywork" + sFullGridId + "Hidden == false){");
            output.Write("input1.style.display = \"none\";");
            output.Write("mywork" + sFullGridId + "Hidden = true;");

            

            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Show Filters\";}");
            output.Write("}else{");
            output.Write("input1.style.display = \"\";");
            output.Write("mywork" + sFullGridId + "Hidden = false;");
            output.Write("if(hlink != null){document.getElementById(hlink).innerHTML=\"&nbsp;Hide Filters\";}");
            output.Write("}");
            output.Write("mywork" + sFullGridId + ".setSizes();");
            output.Write("}");
            output.Write("function switchFilterLoadmywork" + sFullGridId + "(){switchfilterwork" + sFullGridId + "(null);}");

            output.Write("function cellChanged" + sFullGridId + "(mode, id, ind, newval, oldval){");
            output.Write("  if(mode != 2) return true;");
            output.Write("     var summ = 0;");
            output.Write("      try{");
            output.Write("     if(mygrid" + sFullGridId + ".getUserData(id,\"itemid\") != \"\"){");
            output.Write("     for(var i = 0;i<mygrid" + sFullGridId + ".getColumnsNum();i++){");
            output.Write("          if(mygrid" + sFullGridId + ".getColumnId(i).indexOf(\"_TsDate_\") == 0){");
            output.Write("                if(mygrid" + sFullGridId + ".getUserData(id,\"itemid\") != \"\"){");
            output.Write("                     var vals = mygrid" + sFullGridId + ".cells(id,i).getValue();");
            output.Write("                      if(i == ind) vals = newval;");
            output.Write("                     if(mygrid" + sFullGridId + ".getColType(i) == \"timeeditor\"){");
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
            output.Write("          }else if(mygrid" + sFullGridId + ".getColumnId(i) == \"_TsTotal_\" || mygrid" + sFullGridId + ".getColumnId(i) == \"_PercentWork_\"){");
            output.Write("              mygrid" + sFullGridId + ".cells(id,i).setValue(summ);");
            output.Write("          }");
            output.Write("     }");
            output.Write("     }");
            output.Write("     }catch(e){}return true;");
            output.Write("}");

            output.Write("function viewChecks" + sFullGridId + "(btn)");
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

            output.Write("function viewDropDown" + sFullGridId + "(btn)");
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

            output.Write("function touchRows" + sFullGridId + "(){");
            output.Write("mygrid" + sFullGridId + ".forEachRow(function(id){");
            output.Write("     cellChanged" + sFullGridId + "(2,id,0,'','');");
            output.Write("})");
            output.Write("}");

            output.Write("function disableCells" + sFullGridId + "()");
            output.Write("{");
            output.Write("    mygrid" + sFullGridId + ".forEachRow(function(id){");
            output.Write("        mygrid" + sFullGridId + ".forEachCell(id,function(cell,i){");
            output.Write("            if(mygrid" + sFullGridId + ".getColType(i) != \"timeeditor\")");
            output.Write("              try{cell.setDisabled(true);}catch(e){}");
            output.Write("        });");
            output.Write("    });");
            output.Write("}");

            output.Write("function setAllUpdated" + sFullGridId + "(){");
            output.Write("mygrid" + sFullGridId + ".forEachRow(function(id){");
            output.Write("if(mygrid" + sFullGridId + ".getUserData(id,\"itemid\") != \"\"){");
            output.Write("      myDataProcessor.setUpdated(id,true);");
            output.Write("      gridChanged" + sFullGridId + " = true;");
            output.Write("}");
            output.Write("})");
            output.Write("}");
            output.Write("</script>");

            output.Write("<script>");
            output.Write("var gridChanged" + sFullGridId + " = false;");
            //output.Write("var myworkpost" + sFullGridId + " = \"data=" + getGridParams(false) + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&period=" + intPeriod + "\";");
            //output.Write("var otherworkpost" + sFullGridId + " = \"data=" + getGridParams(false) + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&period=" + intPeriod + "&workType=1\";");
            //output.Write("var nonworkpost" + sFullGridId + " = \"data=" + getGridParams(true) + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&period=" + intPeriod + "&workType=2\";");
            //output.Write("var searchworkpost" + sFullGridId + " = \"data=" + getGridParams(false) + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&period=" + intPeriod + "&workType=4&allowOther=" + EPMLiveCore.CoreFunctions.getConfigSetting(web.Site.RootWeb,"EPMLiveTSAllowUnassigned").ToLower() + "\";");
            output.Write("var submitaftersave" + sFullGridId + " = false;");
            output.Write("var addaftersave" + sFullGridId + " = false;");
            output.Write("var haderrors" + sFullGridId + " = false;");
            output.Write("var myworkurl" + sFullGridId + " = \"" + web.Url + "/_layouts/epmlive/gettsmywork.aspx\";");
            if (impersonate)
            {
                output.Write("var actionurl" + sFullGridId + " = \"" + web.Url + "/_layouts/epmlive/dotsaction.aspx?duser=" + System.Web.HttpUtility.UrlEncode(username) + "\";");
                output.Write("var myworkpost" + sFullGridId + " = \"data=" + sFullParamList + "&edit=" + inEditMode + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&period=" + intPeriod + "&duser=" + System.Web.HttpUtility.UrlEncode(username) + "\";");
                output.Write("var otherworkpost" + sFullGridId + " = \"data=" + sFullParamList + "&edit=" + inEditMode + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&period=" + intPeriod + "&workType=1&duser=" + System.Web.HttpUtility.UrlEncode(username) + "\";");
                output.Write("var nonworkpost" + sFullGridId + " = \"data=" + sFullParamList + "&edit=" + inEditMode + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&period=" + intPeriod + "&workType=2&duser=" + System.Web.HttpUtility.UrlEncode(username) + "\";");
                output.Write("var searchworkpost" + sFullGridId + " = \"data=" + sFullParamList + "&edit=" + inEditMode + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&period=" + intPeriod + "&workType=4&allowOther=" + EPMLiveCore.CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPMLiveTSAllowUnassigned").ToLower() + "&duser=" + System.Web.HttpUtility.UrlEncode(username) + "\";");

            }
            else
            {
                output.Write("var actionurl" + sFullGridId + " = \"" + web.Url + "/_layouts/epmlive/dotsaction.aspx\";");
                output.Write("var myworkpost" + sFullGridId + " = \"data=" + sFullParamList + "&edit=" + inEditMode + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&period=" + intPeriod + "\";");
                output.Write("var otherworkpost" + sFullGridId + " = \"data=" + sFullParamList + "&edit=" + inEditMode + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&period=" + intPeriod + "&workType=1\";");
                output.Write("var nonworkpost" + sFullGridId + " = \"data=" + sFullParamList + "&edit=" + inEditMode + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&period=" + intPeriod + "&workType=2\";");
                output.Write("var searchworkpost" + sFullGridId + " = \"data=" + sFullParamList + "&edit=" + inEditMode + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&period=" + intPeriod + "&workType=4&allowOther=" + EPMLiveCore.CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPMLiveTSAllowUnassigned").ToLower() + "\";");

            }
            output.Write("var mygrid" + sFullGridId + "Hidden = false;");
            output.Write("var mygrid" + sFullGridId + "Edit = " + inEditMode.ToString().ToLower() + ";");
            output.Write("var mywork" + sFullGridId + "Hidden = false;");
            output.Write("var tsuid" + sFullGridId + " = '" + tsuid + "';");
            output.Write("var period" + sFullGridId + " = '" + intPeriod + "';");
            output.Write("var mygridwidth" + sFullGridId + " = 0;");
            output.Write("var firsteditorbox" + sFullGridId + " = '" + firsteditorbox + "';");
            output.Write("var allowotherwork" + sFullGridId + " = " + EPMLiveCore.CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPMLiveTSAllowUnassigned").ToLower() + ";");
            output.Write("mygrid" + sFullGridId + " = new dhtmlXGridObject('grid" + this.ID + "');");

            output.Write("mygrid" + sFullGridId + ".setImagePath(\"_layouts/epmlive/dhtml/xgrid/imgs/\");");
            output.Write("mygrid" + sFullGridId + ".setSkin(\"editgrid\");");

            if (this.Height == "")
            {
                output.Write("mygrid" + sFullGridId + ".enableAutoHeight(true);");
            }
            else
            {
                MatchCollection mc = Regex.Matches(this.Height, "\\d*");
                string h = "100";
                if (mc.Count > 0)
                {
                    h = mc[0].Value;
                    try
                    {
                        h = (int.Parse(h) - 30).ToString();
                    }
                    catch { }
                }
                output.Write("mygrid" + sFullGridId + ".enableAutoHeight(true," + h + ",true);");
            }

            output.Write("mygrid" + sFullGridId + ".attachEvent(\"onEditCell\",cellChanged" + sFullGridId + ");");

            output.Write("mygrid" + sFullGridId + ".attachEvent(\"onEditCell\",function(stage,rowId,cellInd,newValue,oldValue){");
            output.Write("if ((stage==2)&&(newValue!=oldValue)){");
            output.Write("gridChanged" + sFullGridId + " = true;");
            output.Write("mygrid" + sFullGridId + ".callEvent(\"onGridReconstructed\",[]);");
            output.Write("return true;");
            output.Write("}");
            output.Write("return true;");
            output.Write("});");

            output.Write("mygrid" + sFullGridId + ".setImageSize(1,1);");

            output.Write("mygrid" + sFullGridId + ".setDateFormat(\"%m/%d/%Y\");");
            output.Write("mygrid" + sFullGridId + ".attachEvent(\"onXLE\",clearLoader);");
            output.Write("mygrid" + sFullGridId + ".attachEvent(\"onXLE\",touchRows" + sFullGridId + ");");
            if (editEvents == "false")
                output.Write("mygrid" + sFullGridId + ".attachEvent(\"onXLE\",disableCells" + sFullGridId + ");");

            output.Write("mygrid" + sFullGridId + ".attachEvent(\"onXLE\",switchFilterLoad" + sFullGridId + ");");
            if (status == "New")
            {
                output.Write("mygrid" + sFullGridId + ".attachEvent(\"onXLE\",setAllUpdated" + sFullGridId + ");");
            }


            //output.Write("mygrid" + sFullGridId + ".enableEditEvents('" + editEvents + "',false,false);");
            output.Write("mygrid" + sFullGridId + ".enableEditEvents(true,false,false);");

            output.Write("mygrid" + sFullGridId + ".attachEvent(\"onRowSelect\",selectRow" + sFullGridId + ");");

            //if(status != "New" && status != "Saved")
            output.Write("mygrid" + sFullGridId + ".enableTreeCellEdit(false);");

            output.Write("mygrid" + sFullGridId + ".enableMathEditing(false);");
            output.Write("mygrid" + sFullGridId + ".enableMathSerialization(true);");
            //output.Write("mygrid" + sFullGridId + ".enableSmartXMLParsing(false);");

            //output.Write("mygrid" + sFullGridId + ".setColumnHidden(0,!" + editEvents + ");");
            //output.Write("mygrid" + sFullGridId + ".attachEvent(\"onXLE\",function(){mygrid" + sFullGridId + ".setColumnHidden(0,!" + editEvents + ")});");

            ///CUSTOM PROPERTIES
            output.WriteLine("mygrid" + sFullGridId + "._webpartid = '" + this.ID + "';");
            output.WriteLine("mygrid" + sFullGridId + ".setImagePath(\"_layouts/epmlive/dhtml/xgrid/imgs/\");");
            output.WriteLine("mygrid" + sFullGridId + "._gridMode = 'standard';");

            string image = "/_layouts/" + web.Language + "/images/formatmap32x32.png";

            try
            {
                output.WriteLine("mygrid" + sFullGridId + "._modifylist = " + list.DoesUserHavePermissions(SPBasePermissions.ManageLists).ToString().ToLower() + ";");
            }
            catch
            {
                output.WriteLine("mygrid" + sFullGridId + "._modifylist = false;");
            }
            try
            {
                output.WriteLine("mygrid" + sFullGridId + "._listperms = " + list.DoesUserHavePermissions(SPBasePermissions.ManagePermissions).ToString().ToLower() + ";");
            }
            catch
            {
                output.WriteLine("mygrid" + sFullGridId + "._listperms = false;");
            }


            output.WriteLine("mygrid" + sFullGridId + "._delegates = \"" + strDelegates + "\";");
            output.WriteLine("mygrid" + sFullGridId + "._cururl = '" + HttpContext.Current.Request.Url.AbsolutePath + "';");
            output.WriteLine("mygrid" + sFullGridId + "._lockedts = " + lockedts + ";");
            output.WriteLine("mygrid" + sFullGridId + "._lockunsubmit = " + lockunsubmit + ";");
            output.WriteLine("mygrid" + sFullGridId + "._timesheetstatus = '" + status + "';");
            output.WriteLine("mygrid" + sFullGridId + "._timesheetperiod = '" + strCurPeriodName + "';");
            output.WriteLine("mygrid" + sFullGridId + "._nextperiod = '" + strNextPeriod + "';");
            output.WriteLine("mygrid" + sFullGridId + "._previousperiod = '" + strPreviousPeriod + "';");
            output.WriteLine("mygrid" + sFullGridId + "._allperiods = '" + strAllPeriods + "';");
            output.WriteLine("mygrid" + sFullGridId + "._shownewmenu = false;");
            output.WriteLine("mygrid" + sFullGridId + "._allowedit = " + allowEditToggle.ToString().ToLower() + ";");
            output.WriteLine("mygrid" + sFullGridId + "._listid = '" + HttpUtility.UrlEncode(list.ID.ToString()).ToUpper() + "';");
            output.WriteLine("mygrid" + sFullGridId + "._viewid = '" + HttpUtility.UrlEncode(view.ID.ToString()).ToUpper() + "';");
            output.WriteLine("mygrid" + sFullGridId + "._viewurl = '" + web.Url + view.ServerRelativeUrl + "';");
            output.WriteLine("mygrid" + sFullGridId + "._viewname = '" + view.Title + "';");
            output.WriteLine("mygrid" + sFullGridId + "._basetype = '" + list.BaseType + "';");
            output.WriteLine("mygrid" + sFullGridId + "._templatetype = '" + (int)list.BaseTemplate + "';");
            output.WriteLine("mygrid" + sFullGridId + "._newrow = false;");
            output.WriteLine("mygrid" + sFullGridId + "._gridid = '" + sFullGridId + "';");
            StringBuilder sbForms = new StringBuilder();
            foreach (SPForm form in list.Forms)
            {
                switch (form.Type)
                {
                    case PAGETYPE.PAGE_DISPLAYFORM:
                        sbForms.Append("<Button Id='Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay' CommandValueId='" + HttpUtility.UrlEncode(form.ServerRelativeUrl) + "' Command='EditDefaultForm' Image16by16='/_layouts/" + web.Language + "/images/formatmap16x16.png' Image16by16Top='-176' Image16by16Left='-16' Image32by32='/_layouts/" + web.Language + "/images/formatmap32x32.png' Image32by32Top='-256' Image32by32Left='-320' LabelText='Default Display Form'/>");
                        break;
                    case PAGETYPE.PAGE_EDITFORM:
                        sbForms.Append("<Button Id='Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay' CommandValueId='" + HttpUtility.UrlEncode(form.ServerRelativeUrl) + "' Command='EditDefaultForm' Image16by16='/_layouts/" + web.Language + "/images/formatmap16x16.png' Image16by16Top='-32' Image16by16Left='-80' Image32by32='/_layouts/" + web.Language + "/images/formatmap32x32.png' Image32by32Top='-96' Image32by32Left='-448' LabelText='Default Edit Form'/>");
                        break;
                    case PAGETYPE.PAGE_NEWFORM:
                        sbForms.Append("<Button Id='Ribbon.List.Settings.EditDefaultForms.Menu.MS.EditDefaultFormDisplay' CommandValueId='" + HttpUtility.UrlEncode(form.ServerRelativeUrl) + "' Command='EditDefaultForm' Image16by16='/_layouts/" + web.Language + "/images/formatmap16x16.png' Image16by16Top='-128' Image16by16Left='-224' Image32by32='/_layouts/" + web.Language + "/images/formatmap32x32.png' Image32by32Top='-128' Image32by32Left='-96' LabelText='Default New Form'/>");
                        break;
                };

            }
            output.WriteLine("mygrid" + sFullGridId + "._formmenus = \"" + sbForms + "\";");

            output.WriteLine(Properties.Resources.txtTimesheetRibbonFunctions.Replace("#gridid#", sFullGridId));

            ////////////////////////////////////////////////////////////////////////

            output.Write("mygrid" + sFullGridId + ".init();");

            if (impersonate)
                output.Write("myDataProcessor = new dataProcessor(\"" + web.Url + "/_layouts/epmlive/savetimesheet.aspx?tsuid=" + tsuid + "&period=" + intPeriod.ToString() + "&edit=" + inEditMode + "&columns=" + getViewFields() + "&duser=" + System.Web.HttpUtility.UrlEncode(username) + "\");");
            else
                output.Write("myDataProcessor = new dataProcessor(\"" + web.Url + "/_layouts/epmlive/savetimesheet.aspx?tsuid=" + tsuid + "&period=" + intPeriod.ToString() + "&edit=" + inEditMode + "&columns=" + getViewFields() + "\");");
            output.Write("myDataProcessor.setUpdateMode(\"off\");");

            output.Write("function updateitem" + sFullGridId + "(node){");
            output.Write("var id=node.getAttribute(\"sid\");");
            output.Write("mygrid" + sFullGridId + ".setUserData(id, \"!nativeeditor_status\", \"\");");
            output.Write("mygrid" + sFullGridId + ".setUserData(id, \"tsitemuid\", node.getAttribute(\"tsitemuid\"));");
            output.Write("return true;");
            output.Write("}");

            output.Write("function selectRow" + sFullGridId + "(id, ind){");
            output.Write("curRowId = id;");
	        output.Write("curGrid = mygrid" + sFullGridId + ";");
	        output.Write("RefreshCommandUI();");
            output.Write("}");

            output.Write("function viewError" + sFullGridId + "(id){");
            output.Write("document.getElementById('dlgErrorText" + sFullGridId + "').innerHTML=mygrid" + sFullGridId + ".getUserData(id,\"lastError\");");
            output.Write("sm('dlgError" + sFullGridId + "',250,130);");
            output.Write("}");

            output.Write("function settsuid" + sFullGridId + "(node){");
            output.Write("var id=node.getAttribute(\"tsuid\");");
            if (impersonate)
                output.Write("myDataProcessor.serverProcessor = \"" + web.Url + "/_layouts/epmlive/savetimesheet.aspx?tsuid=\" + id + \"&period=" + intPeriod.ToString() + "&edit=" + inEditMode + "&columns=" + getViewFields() + "&duser=" + System.Web.HttpUtility.UrlEncode(username) + "\";");
            else
                output.Write("myDataProcessor.serverProcessor = \"" + web.Url + "/_layouts/epmlive/savetimesheet.aspx?tsuid=\" + id + \"&period=" + intPeriod.ToString() + "&edit=" + inEditMode + "&columns=" + getViewFields() + "\";");

            output.Write("tsuid" + sFullGridId + " = id;");
            output.Write("    if(submitaftersave" + sFullGridId + ")");
            output.Write("    {");
            output.Write("      if(haderrors" + sFullGridId + ")");
            output.Write("      {");
            output.Write("          alert('Cannot submit timesheet, there were 1 or more errors during save.');");
            output.Write("      }else{");
            output.Write("         submitaftersave" + sFullGridId + " = false;");
            output.Write("         submit" + sFullGridId + "();");
            output.Write("      }");
            output.Write("    }");
            output.Write("    else if(addaftersave" + sFullGridId + "){");
            output.Write("         addaftersave" + sFullGridId + " = false;");
            output.Write("         autoAdd" + sFullGridId + "();");
            output.Write("     }");
            output.Write("}");

            output.Write("function myErrorHandler" + sFullGridId + "(obj){");
            output.Write("      var id = obj.getAttribute(\"sid\");");
            output.Write("      mygrid" + sFullGridId + ".cells(id,1).setValue(\"<a href=\\\"javascript:viewError" + sFullGridId + "('\" + id + \"');\\\"><img src='/_layouts/images/EXCLAIM.GIF' border='0'></a>\");");
            output.Write("      mygrid" + sFullGridId + ".setUserData(id,\"lastError\",obj.firstChild.data);");
            output.Write("      haderrors" + sFullGridId + " = true;");
            //output.Write("      return true;");
            output.Write("}");

            output.Write("function updatewss" + sFullGridId + "(obj){");
            output.Write("      var id = obj.getAttribute(\"sid\");");
            output.Write("      mygrid" + sFullGridId + ".cells(id,1).setValue(\"\");");
            output.Write("      mygrid" + sFullGridId + ".setUserData(id,\"lastError\",\"\");");
            //output.Write("      return true;");
            output.Write("}");

            output.Write("myDataProcessor.defineAction(\"error100\", myErrorHandler" + sFullGridId + ");");
            output.Write("myDataProcessor.defineAction(\"updateitem\", updateitem" + sFullGridId + ");");
            output.Write("myDataProcessor.defineAction(\"settsuid\", settsuid" + sFullGridId + ");");
            output.Write("myDataProcessor.defineAction(\"updatewss\", updatewss" + sFullGridId + ");");
            output.Write("myDataProcessor.setTransactionMode(\"POST\", true);");

            output.Write("myDataProcessor.setOnAfterUpdate(function(id,action,newid){");
            //output.Write("if(action != \"error100\" && action != \"delete\"){mygrid" + sFullGridId + ".cells(id,1).setValue(\"\");}");
            output.Write("if(myDataProcessor.getSyncState())");
            output.Write("{");
            output.Write("    gridChanged" + sFullGridId + " = false;");
            output.Write("    mygrid" + sFullGridId + ".setSizes();");
            output.Write("    myDataProcessor.updatedRows = [];");
            output.Write("    AfterSave(mygrid" + sFullGridId + ");");
            output.Write("    hm('dlgSaving');");
            //output.Write("    if(submitaftersave" + sFullGridId + ")");
            //output.Write("    {");
            //output.Write("         //submitaftersave" + sFullGridId + " = false;");
            //output.Write("         //submit" + sFullGridId + "();");
            //output.Write("    }else{");
            //output.Write("         alert('Timesheet Saved');");
            //output.Write("    }");
            output.Write("}");
            output.Write("});");

            output.Write("myDataProcessor.init(mygrid" + sFullGridId + ");");


            //output.Write("mygrid" + sFullGridId + ".attachFooter(\"Totals:,#cspan,#cspan,{#stat_total},{#stat_total},{#stat_total},{#stat_total},{#stat_total}\");");

            //output.Write("mygrid" + sFullGridId + ".attachEvent(\"onBeforeContextMenu\",onShowMenu);");


            

            output.Write("function loadX" + sFullGridId + "(){");
            output.Write("mygridwidth" + sFullGridId + " = document.getElementById('WebPart" + this.Qualifier + "').offsetWidth - 20;");
            if (impersonate)
                output.Write("mygrid" + sFullGridId + ".post(\"" + web.Url + "/_layouts/epmlive/gettimesheet.aspx\",\"data=" + sFullParamList + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&rnd=" + Guid.NewGuid() + "&period=" + intPeriod + "&edit=" + inEditMode + "&status=" + status + "&width=\" + mygridwidth" + sFullGridId + " + \"&duser=" + System.Web.HttpUtility.UrlEncode(username) + "\");");
            else
                output.Write("mygrid" + sFullGridId + ".post(\"" + web.Url + "/_layouts/epmlive/gettimesheet.aspx\",\"data=" + sFullParamList + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&rnd=" + Guid.NewGuid() + "&period=" + intPeriod + "&edit=" + inEditMode + "&status=" + status + "&width=\" + mygridwidth" + sFullGridId + ");");

            output.Write("}");

            output.WriteLine("function clickTab(){");
            output.WriteLine("var wp = document.getElementById('MSOZoneCell_WebPart" + this.Qualifier + "');");
            output.WriteLine("fireEvent(wp, 'mouseup');");
            output.WriteLine("setTimeout(\"clickbrowse()\",1000);");
            output.WriteLine("}");

            output.WriteLine("function clickbrowse(){");
            output.WriteLine("var wp2 = document.getElementById('Ribbon.Timesheet-title').firstChild;");
            output.WriteLine("fireEvent(wp2, 'click');");
            output.WriteLine("}");

            output.Write("SP.SOD.executeOrDelayUntilScriptLoaded(clickTab, \"GridViewContextualTabPageComponent.js\");");



            output.Write("try{");
            //output.Write("_spBodyOnLoadFunctionNames.push(\"loadX" + sFullGridId + "\");");
            output.WriteLine("setTimeout(\"loadX" + sFullGridId + "()\", 100);");

            output.Write("}catch(e){alert(e);}");

            string[] dayDefs = EPMLiveCore.CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPMLiveDaySettings").Split('|');

            string min = "";
            string max = "";

            for (int i = 0; i < 20; i += 3)
            {
                if (dayDefs[i].ToLower() == "true")
                {
                    min += "," + dayDefs[i + 1];
                    max += "," + dayDefs[i + 2];
                }
            }
            if (min.Length > 1)
                min = min.Substring(1);
            if (max.Length > 1)
                max = max.Substring(1);

            output.Write("var dayMins = [" + min + "];");
            output.Write("var dayMaxs = [" + max + "];");


            output.Write("function validateValues" + sFullGridId + "(){");
            if (inEditMode)
                output.Write("     var cols = " + (view.ViewFields.Count + 2).ToString() + ";");
            else
                output.Write("     var cols = " + (view.ViewFields.Count + 1).ToString() + ";");

            output.Write("      var colCount = 0;");
            output.Write("     for(var i = cols;i<mygrid" + sFullGridId + ".getColumnsNum() - 2;i++){");
            output.Write("          var summ = 0;");
            //output.Write("          alert(mygrid" + sFullGridId + ".getColId(i))");
            output.Write("          mygrid" + sFullGridId + ".forEachRow(function(id){");
            output.Write("                if(mygrid" + sFullGridId + ".getUserData(id,\"itemid\") != \"\"){");
            output.Write("                     var vals = mygrid" + sFullGridId + ".cells(id,i).getValue();");
            output.Write("                     if(mygrid" + sFullGridId + ".getColType(i) == \"timeeditor\"){");
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
            output.Write("               alert('The minimum for:\\r\\n ' + mygrid" + sFullGridId + ".getColumnLabel(i) + '\\r\\n is ' + dayMins[colCount] + ' hours, you currently have ' + summ + ' hours.');");
            output.Write("               return false;");
            output.Write("          }");
            output.Write("          if(summ > dayMaxs[colCount]){");
            output.Write("               alert('The maximum for:\\r\\n ' + mygrid" + sFullGridId + ".getColumnLabel(i) + '\\r\\n is ' + dayMaxs[colCount] + ' hours, you currently have ' + summ + ' hours.');");
            output.Write("               return false;");
            output.Write("          }");
            output.Write("          colCount++;");
            output.Write("     }");
            output.Write("     return true;");
            output.Write("}");


            output.WriteLine("mygrid" + sFullGridId + ".getCheckedIds = function(){");
            output.WriteLine(@"
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

            output.WriteLine("mygrid" + sFullGridId + ".getCheckedItems = function(){");
            output.WriteLine(@"
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

            output.Write("</script>");

            output.Write("<div id=\"dlgNote\" class=\"dialog\"><table width=\"100%\"><tr><td align=\"left\" class=\"ms-sectionheader\"><H3 class=\"ms-standardheader\">Approval Note:</h3><br />" + appNote + "<br><br></td></tr><tr><td align=\"right\"><a href=\"javascript:hm('dlgNote');\" class=\"ms-descriptiontext\">close</a></td></tr></table></div>");

            string cExcells = Properties.Resources.txtTimesheetBase.Replace("#gridid#", sFullGridId).Replace("#griduid#", this.ID);
            cExcells = cExcells.Replace("#peid#", peMulti.ClientID);
            cExcells = cExcells.Replace("#peuid#", peMulti.UniqueID);
            cExcells = cExcells.Replace("#pesid#", peSingle.ClientID);
            cExcells = cExcells.Replace("#pesuid#", peSingle.UniqueID);

            output.Write("<script language=\"javascript\">");
            output.Write(Properties.Resources.txtExcels.Replace("#gridid#", sFullGridId));

            output.Write("</script>");

            output.Write(cExcells);



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
                    ActionsMenu menu = (ActionsMenu)childControl;

                    try { menu.GetMenuItem("EditInGridButton").Visible = false; }
                    catch { }
                    try { menu.GetMenuItem("ExportToDatabase").Visible = false; }
                    catch { }
                    try
                    {
                        menu.GetMenuItem("ExportToSpreadsheet").Visible = false;
                    }
                    catch { }
                    try
                    {
                        menu.GetMenuItem("ViewRSS").Visible = false;
                    }
                    catch { }
                    try
                    {
                        menu.GetMenuItem("SubscribeButton").Visible = false;
                    }
                    catch { }
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
