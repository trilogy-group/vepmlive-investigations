using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

using System.Data.SqlClient;
using System.Data;

using System.Text.RegularExpressions;

using System.Web;
using System.Xml;
using System.Collections;
using System.Text;

namespace TimeSheets
{
    [Guid("9C192BDD-0A80-4217-A54E-2245CFA79342")]
    [ToolboxData("<{0}:PMApprovals runat=server></{0}:PMApprovals>")]
    [XmlRoot(Namespace = "PMApprovals")]
    public class PMApprovals : Microsoft.SharePoint.WebPartPages.WebPart, IWebPartPageComponentProvider
    {
        TimesheetMenu ts = new TimesheetMenu();
        SPList list;
        SPView view;
        ViewToolBar toolbar;

        string status = "";

        int activation;
        private string error;
        DropDownList ddl;
        ImageButton btnNext;
        ImageButton btnPrev;

        private string username = SPContext.Current.Web.CurrentUser.LoginName;
        int intPeriod;
        SqlConnection cn;
            
        string sFullGridId;

        private string sFullParamList;
        private SortedList arrPeriods = new SortedList();
        private string strCurPeriodName;
        private string strNextPeriod;
        private string strPreviousPeriod;
        private string strAllPeriods;

        private EPMLiveCore.Act act;

        public PMApprovals()
        {
            sFullGridId = this.ZoneIndex + this.ZoneID;
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

                ribbonTsTab.Id = "Ribbon.TimesheetPMApprovals";
                ribbonTsTab.VisibilityContext = "GridViewListContextualTab" + webPartPageComponentId + ".CustomVisibilityContext";

                info.ContextualGroups.Add(contextualGroup);
                info.Tabs.Add(ribbonItemTab);
                info.Tabs.Add(ribbonListTab);
                info.Tabs.Add(ribbonTsTab);
                info.PageComponentId = SPRibbon.GetWebPartPageComponentId(this);

                return info;
            }
        }

        private void AddContextualTab()
        {


            var ribbon = SPRibbon.GetCurrent(Page);
            if (ribbon != null)
            {
                ribbon.Minimized = false;
                ribbon.CommandUIVisible = true;
                const string initialTabId = "Ribbon.TimesheetPMApprovals";
                if (!ribbon.IsTabAvailable(initialTabId))
                    ribbon.MakeTabAvailable(initialTabId);

                //ribbon.MakeContextualGroupInitiallyVisible("Ribbon.ListContextualGroup", string.Empty);

            }

            string language = SPContext.Current.Web.Language.ToString();

            Microsoft.Web.CommandUI.Ribbon ribbon1 = SPRibbon.GetCurrent(this.Page);

            XmlDocument ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml(Properties.Resources.txtTimesheetPMApprovalsTab.Replace("#language#", language));
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.ListContextualGroup._children");

            ribbonExtensions.LoadXml(Properties.Resources.flexible2);
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.Templates._children");

            ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml("<Button Id=\"Ribbon.List.Datasheet.Print\" Sequence=\"10\" Command=\"PrintGrid\" Image16by16=\"/_layouts/epmlive/images/print.gif\" Image32by32=\"/_layouts/epmlive/images/printmenu.gif\" LabelText=\"Print\" ToolTipTitle=\"Print\" ToolTipDescription=\"\" TemplateAlias=\"o1\"/>");
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.List.Share.Controls._children");


            ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml(Properties.Resources.txtTimesheetTemplate.Replace("#language#", language));
            ribbon1.RegisterDataExtension(ribbonExtensions.FirstChild, "Ribbon.Templates._children");
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
                                var _customPageComponent = new ContextualTabWebPart.CustomPageComponent('" + webPartPageComponentId + @"',mygrid" + sFullGridId + ",null,'" + ((url == "/") ? "" : url) + @"','" + HttpContext.Current.Request.Url.AbsolutePath + @"');

                                var ribbonPageManager = SP.Ribbon.PageManager.get_instance();
                                ribbonPageManager.addPageComponent(_customPageComponent);
                                ribbonPageManager.get_focusManager().requestFocusForComponent(_customPageComponent);
                            }

                            function _registerCustomPageComponent()
                            {
                                SP.SOD.registerSod(""GridViewContextualTabPageComponent.js"", ""\/_layouts\/epmlive\/gridlistribbon.aspx"");
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

            buildParams();

            string webPartPageComponentId = SPRibbon.GetWebPartPageComponentId(this);

            if (!Page.ClientScript.IsClientScriptBlockRegistered(base.GetType(), "listviewwebpart" + webPartPageComponentId))
                Page.ClientScript.RegisterClientScriptBlock(base.GetType(), "listviewwebpart" + webPartPageComponentId, "<script language=\"javascript\">var mygrid" + sFullGridId + ";</script>");

            AddContextualTab();

            ClientScriptManager clientScript = this.Page.ClientScript;

            clientScript.RegisterClientScriptBlock(this.GetType(), "ContextualWebPart", this.DelayScript);
        }

        private void appendParam(string param, string val)
        {
            sFullParamList += "\n" + param + "\t" + val;
        }

        private void buildParams()
        {

            bool useNew = false;
            bool rollups = false;

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
            appendParam("RLists", gSettings.RollupLists);
            if(gSettings.RollupLists != "")
                rollups = true;

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
        }

        protected override void CreateChildControls()
        {
            act = new EPMLiveCore.Act(SPContext.Current.Web);
            activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.Timesheets);
            if (activation != 0)
                return;

            SPWeb web = SPContext.Current.Web;
            {
                try
                {
                    list = SPContext.Current.List;
                    view = SPContext.Current.ViewContext.View;
                }
                catch { }

                if (view != null && list != null)
                {
                    DataSet dsPeriods = new DataSet();

                    toolbar = new ViewToolBar();
                    toolbar.TemplateName = "TSViewToolBar";

                    SPContext context = SPContext.GetContext(this.Context, view.ID, list.ID, SPContext.Current.Web);
                    toolbar.RenderContext = context;

                    Controls.Add(toolbar);

                    foreach (Control control in toolbar.Controls)
                    {
                        processControls(control, sFullGridId, view.ServerRelativeUrl, web);
                    }


                    ts.Text = "Timesheet";
                    ts.TemplateName = "ToolbarPMMenu";
                    ts.ToolTip = "Timesheet";
                    ts.MenuControl.Text = "Timesheet";
                    ts.GetMenuItem("ApproveItems").ClientOnClickScript = "approve" + sFullGridId + "();";
                    ts.GetMenuItem("RejectItems").ClientOnClickScript = "reject" + sFullGridId + "();";

                    toolbar.Controls[0].Controls[1].Controls[0].Controls.AddAt(6, ts);

                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
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
                                ddl.Items.Add(new ListItem(dr.GetDateTime(1).ToShortDateString() + " - " + dr.GetDateTime(2).ToShortDateString(), dr.GetInt32(0).ToString()));
                                arrPeriods.Add(dr.GetInt32(0), dr.GetDateTime(1).ToShortDateString() + " - " + dr.GetDateTime(2).ToShortDateString());
                            }

                            ddl.SelectedValue = intPeriod.ToString();

                            cn.Close();
                        }
                        catch { }
                    });

                    if (Page.IsPostBack)
                    {
                        Page.Response.Cookies["EPMLiveTSPeriod"].Value = ddl.SelectedValue;
                        Page.Response.Cookies["EPMLiveTSPeriod"].Expires = DateTime.Now.AddMinutes(30);
                    }
                    ddl.ID = "ddlPeriod";
                    ddl.SelectedIndexChanged += new EventHandler(ddl_SelectedIndexChanged);
                    ddl.AutoPostBack = true;
                    ddl.EnableViewState = true;

                    btnNext.Click += new ImageClickEventHandler(btn_Click);
                    btnNext.ImageUrl = "/_layouts/epmlive/images/right.gif";
                    btnNext.EnableViewState = true;

                    btnPrev.Click += new ImageClickEventHandler(btnPrev_Click);
                    btnPrev.ImageUrl = "/_layouts/epmlive/images/left.gif";
                    btnPrev.EnableViewState = true;

                    Panel pnl = new Panel();
                    pnl.Controls.Add(new LiteralControl("<table border=\"0\"><tr><td class=\"ms-toolbar\" valign=\"center\"><div class=\"ms-buttoninactivehover\" onmouseover=\"this.className='ms-buttonactivehover'\" onmouseout=\"this.className='ms-buttoninactivehover'\">"));
                    pnl.Controls.Add(btnPrev);
                    pnl.Controls.Add(new LiteralControl("</div></td><td valign=\"center\">"));
                    pnl.Controls.Add(ddl);
                    pnl.Controls.Add(new LiteralControl("</td><td valign=\"center\"><div class=\"ms-buttoninactivehover\" onmouseover=\"this.className='ms-buttonactivehover'\" onmouseout=\"this.className='ms-buttoninactivehover'\">"));
                    pnl.Controls.Add(btnNext);
                    pnl.Controls.Add(new LiteralControl("</div></td></tr></table>"));

                    toolbar.Controls[0].Controls[1].Controls[0].Controls.AddAt(7, pnl);


                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            ddl = new DropDownList();
            btnNext = new ImageButton();
            btnPrev = new ImageButton();
            base.OnInit(e);
        }

        void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Page.Response.Cookies.Remove("EPMLiveTSPeriod");
            Page.Request.Cookies.Remove("EPMLiveTSPeriod");

            HttpCookie myCookie = new HttpCookie("EPMLiveTSPeriod");

            myCookie["period"] = ddl.SelectedValue;
            myCookie.Expires = DateTime.Now.AddMinutes(30);
            Page.Response.Cookies.Add(myCookie);
        }

        void btnPrev_Click(object sender, ImageClickEventArgs e)
        {

            Page.Response.Cookies.Remove("EPMLiveTSPeriod");
            Page.Request.Cookies.Remove("EPMLiveTSPeriod");

            HttpCookie myCookie = new HttpCookie("EPMLiveTSPeriod");

            myCookie["period"] = (int.Parse(ddl.SelectedValue) - 1).ToString();
            myCookie.Expires = DateTime.Now.AddMinutes(30);
            Page.Response.Cookies.Add(myCookie);
        }

        void btn_Click(object sender, ImageClickEventArgs e)
        {

            Page.Response.Cookies.Remove("EPMLiveTSPeriod");
            Page.Request.Cookies.Remove("EPMLiveTSPeriod");

            HttpCookie myCookie = new HttpCookie("EPMLiveTSPeriod");

            myCookie["period"] = (int.Parse(ddl.SelectedValue) + 1).ToString();
            myCookie.Expires = DateTime.Now.AddMinutes(30);
            Page.Response.Cookies.Add(myCookie);
        }

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
                            lblLink.Text = "<a href=\"Javascript:switchFilter" + ZoneIndex + "('" + lblFilterText.ClientID + "');\">";
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


                }

                processControls(childControl, ZoneIndex, viewUrl, curWeb);
            }
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            if (activation != 0)
            {
                output.Write(act.translateStatus(activation));
                return;
            }

            if (ddl.Items.Count <= 0)
            {
                output.Write("No Periods Defined.");
                return;
            }
            output.Write(error);
            try
            {
                
                SPWeb web = SPContext.Current.Web;
                {
                    web.Site.CatchAccessDeniedException = false;
                    EnsureChildControls();

                    if (list != null && view != null)
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate()
                        {
                            try
                            {

                                cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
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

                                SqlCommand cmd = new SqlCommand("SELECT locked from TSPERIOD where period_id=@periodid and site_id=@site_id", cn);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@periodid", intPeriod);
                                cmd.Parameters.AddWithValue("@site_id", web.Site.ID);
                                SqlDataReader dr = cmd.ExecuteReader();

                                status = "Open";

                                if (dr.Read())
                                {
                                    if (dr.GetBoolean(0))
                                    {
                                        status = "Closed";
                                        toolbar.Controls[0].Controls[1].Controls[0].Controls[6].Visible = false;
                                    }
                                }
                                dr.Close();

                                Label lbl = new Label();
                                lbl.ID = "lblTimesheetStatus";
                                lbl.Text = "&nbsp;&nbsp;Period Status: <span id=\"divStatus\" class=\"ms-descriptiontext\">" + status + "</span>";
                                toolbar.Controls[0].Controls[1].Controls[0].Controls.Add(lbl);

                                ddl.SelectedValue = intPeriod.ToString();

                                if (ddl.SelectedIndex == 0)
                                    btnPrev.Visible = false;

                                if (ddl.SelectedIndex == ddl.Items.Count - 1)
                                    btnNext.Visible = false;

                                toolbar.RenderControl(output);
                                renderGrid(output, web);
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

        private void renderGrid(HtmlTextWriter output, SPWeb web)
        {

            //============================Time Editor===============================
            string firsteditorbox = "";
            string editEvents = "false";
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

            output.Write("<script src=\"/_layouts/epmlive/resPlanning.js\"></script>");

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
            output.Write(".grid_hover { border: 10px solid #91CDF2; background-color: #F2FAFF } ");
            output.Write("</style>");

            output.Write("<div id=\"tsnotesgrid" + this.ID + "\" style=\"display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width:200px;height:100px\">");
            //output.Write("<div id=\"multichoiceinner" + sFullGridId + "\" style=\"width: 100%; height: 100%;  background-color: #FFFFFF; border: 1px solid #808080; margin-top:2px; padding:0px;\" class=\"ms-descriptiontext\">");
            //output.Write("test");
            //output.Write("</div>");
            output.Write("<textarea id=\"tsnotes" + sFullGridId + "\" cols=\"30\" rows=\"6\" class=\"ms-input\"></textarea>");
            output.Write("<table border=\"0\" width=\"200\"><tr><td align=\"right\">");
            output.Write("<font class=\"ms-descriptiontext\"><a href=\"javascript:mygrid" + sFullGridId + ".editStop();\">Close</a></font>");
            output.Write("</td></tr></table>");
            output.Write("</div>");

            output.Write("<div id=\"dlgProcessing\" class=\"dialog\"><table width=\"100%\"><tr><td align=\"center\" class=\"ms-sectionheader\"><img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/><br /><H3 class=\"ms-standardheader\">Processing Items...</h3></td></tr></table></div>");
            output.Write("<div id=\"dlgEmailing\" class=\"dialog\"><table width=\"100%\"><tr><td align=\"center\" class=\"ms-sectionheader\"><img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/><br /><H3 class=\"ms-standardheader\">Sending Emails...</h3></td></tr></table></div>");

            output.Write("<div id=\"grid" + this.ID + "\" style=\"width:100%;display:none;\" ></div>\r\n\r\n");

            output.Write("<div  width=\"100%\" id=\"loadinggrid" + this.ID + "\" align=\"center\">");
            output.Write("<img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/> Loading Items...");
            output.Write("</div>");

            output.Write("<script language=\"javascript\">");
            
            output.Write("var actionurl" + sFullGridId + " = \"" + web.Url + "/_layouts/epmlive/dotsaction.aspx\";");
            output.Write("var emailurl" + sFullGridId + " = \"" + web.Url + "/_layouts/epmlive/sendtsemail.aspx\";");
            output.Write("var period" + sFullGridId + " = " + intPeriod.ToString() + ";");
            output.Write("function gridfilter" + sFullGridId + "(value){");
            output.Write("var vals = value.split('|');");
            //output.Write("alert(vals[0]);");
            output.Write("mygrid" + sFullGridId + ".filterBy(vals[0] + 2,vals[1]);");
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
            output.Write("</script>");

            output.Write("\r\n\r\n\r\n<script>");
            
            output.Write("var mygrid" + sFullGridId + "Hidden = false;");
            output.Write("mygrid" + sFullGridId + " = new dhtmlXGridObject('grid" + this.ID + "');");

            output.Write("mygrid" + sFullGridId + ".setImagePath(\"/_layouts/epmlive/dhtml/xgrid/imgs/\");");
            output.Write("mygrid" + sFullGridId + ".setSkin(\"timesheet\");");

            if (this.Height == "")
            {
                output.Write("mygrid" + sFullGridId + ".enableAutoHeigth(true);");
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
                output.Write("mygrid" + sFullGridId + ".enableAutoHeigth(true," + h + ",true);");
            }

            output.Write("mygrid" + sFullGridId + ".setImageSize(1,1);");
            output.Write("mygrid" + sFullGridId + ".enableTreeCellEdit(false);");
            output.Write("mygrid" + sFullGridId + ".enableEditEvents(true,false,false);");
            output.Write("mygrid" + sFullGridId + ".setDateFormat(\"%m/%d/%Y\");");
            output.Write("mygrid" + sFullGridId + ".enableSmartXMLParsing(false);");
            output.Write("mygrid" + sFullGridId + ".attachEvent(\"onXLE\",clearLoader);");
            output.Write("mygrid" + sFullGridId + ".attachEvent(\"onXLE\",disableChecks" + sFullGridId + ");");
            output.Write("mygrid" + sFullGridId + ".attachEvent(\"onXLE\",switchFilterLoad" + sFullGridId + ");");

            if(status != "Open")
                output.Write("mygrid" + sFullGridId + ".attachEvent(\"onXLE\",hideCol" + sFullGridId + ");");
            
            output.Write("mygrid" + sFullGridId + ".attachEvent(\"onXLE\",function(){");
            output.Write("mygrid" + sFullGridId + ".callEvent(\"onGridReconstructed\",[]);");
            output.Write("});");


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


            output.WriteLine("mygrid" + sFullGridId + "._cururl = '" + HttpContext.Current.Request.Url.AbsolutePath + "';");
            output.WriteLine("mygrid" + sFullGridId + "._timesheetstatus = '" + status + "';");
            output.WriteLine("mygrid" + sFullGridId + "._timesheetperiod = '" + strCurPeriodName + "';");
            output.WriteLine("mygrid" + sFullGridId + "._nextperiod = '" + strNextPeriod + "';");
            output.WriteLine("mygrid" + sFullGridId + "._previousperiod = '" + strPreviousPeriod + "';");
            output.WriteLine("mygrid" + sFullGridId + "._allperiods = '" + strAllPeriods + "';");
            output.WriteLine("mygrid" + sFullGridId + "._shownewmenu = false;");
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

            output.WriteLine(Properties.Resources.txtTimesheetPMApprovalsRibbonFunctions.Replace("#gridid#", sFullGridId));

            output.Write("mygrid" + sFullGridId + ".init();\r\n\r\n\r\n");

            output.Write("function loadX" + sFullGridId + "(){");
            output.Write("var w = document.getElementById('WebPart" + this.Qualifier + "').offsetWidth - 20;");
            output.Write("mygrid" + sFullGridId + ".loadXML(\"" + web.Url + "/_layouts/epmlive/getpmapprovals.aspx?data=" + sFullParamList + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&rnd=" + Guid.NewGuid() + "&period=" + intPeriod + "&width=\" + w);");

            output.Write("}");

            output.WriteLine("function clickTab(){");
            output.WriteLine("var wp = document.getElementById('MSOZoneCell_WebPart" + this.Qualifier + "');");
            output.WriteLine("fireEvent(wp, 'mouseup');");
            output.WriteLine("setTimeout(\"clickbrowse()\",1000);");
            output.WriteLine("}");

            output.WriteLine("function clickbrowse(){");
            output.WriteLine("var wp2 = document.getElementById('Ribbon.TimesheetPMApprovals-title').firstChild;");
            output.WriteLine("fireEvent(wp2, 'click');");
            output.WriteLine("}");

            output.Write("SP.SOD.executeOrDelayUntilScriptLoaded(clickTab, \"GridViewContextualTabPageComponent.js\");");

            output.Write("_spBodyOnLoadFunctionNames.push(\"loadX" + sFullGridId + "\");");

            output.Write("initmb();");

            output.Write(Properties.Resources.txtPMApprovalsJS.Replace("#gridid#", sFullGridId));
            output.WriteLine("<script language=\"javascript\">");
            output.Write(Properties.Resources.txtExcels.Replace("#gridid#", sFullGridId));
            output.WriteLine("</script>");

            
            //output.Write("</script>");


        }

        public string PropList
        {
            get
            {
                return SPContext.Current.List.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url;
            }
        }
        public string PropView
        {
            get
            {
                return SPContext.Current.ViewContext.View.Title;
            }
        }
    }
}
