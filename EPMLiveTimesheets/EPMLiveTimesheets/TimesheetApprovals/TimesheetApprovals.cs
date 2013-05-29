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
using System.Text;
using System.Collections;

namespace TimeSheets
{
    [Guid("275fb0de-192d-4fe0-bec3-31a255025d26")]
    [ToolboxData("<{0}:TimeSheetApprovals runat=server></{0}:TimeSheetApprovals>")]
    [XmlRoot(Namespace = "TimeSheetApprovals")]
    public class TimesheetApprovals : Microsoft.SharePoint.WebPartPages.WebPart, IWebPartPageComponentProvider
    {
        int activation;
        private string error;
        string status = "";
        //DropDownList ddl;
        //ImageButton btnNext;
        //ImageButton btnPrev;
        //ViewToolBar toolbar;
        //ToolBar worktoolbar;
        private string username = SPContext.Current.Web.CurrentUser.LoginName;
        int intPeriod;
        SqlConnection cn;

        //TimesheetMenu ts = new TimesheetMenu();
        SPList list;
        SPView view;
        private EPMLiveCore.Act act;
        //Panel pnl;

        //private SPWeb resWeb;
        //private SPList reslist = null;
        //private SPView resview = null;
        //private string resUrl;
        //private string viewList = "";
        //private string strCurrentView;

        //private ViewToolBar viewtoolbar;

        string sFullGridId;

        private string sFullParamList;
        private SortedList arrPeriods = new SortedList();
        private string strCurPeriodName;
        private string strNextPeriod;
        private string strPreviousPeriod;
        private string strAllPeriods;

        bool disabled = false;

        public TimesheetApprovals()
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

                ribbonTsTab.Id = "Ribbon.TimesheetApprovals";
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
                const string initialTabId = "Ribbon.TimesheetApprovals";
                if (!ribbon.IsTabAvailable(initialTabId))
                    ribbon.MakeTabAvailable(initialTabId);

                //ribbon.MakeContextualGroupInitiallyVisible("Ribbon.ListContextualGroup", string.Empty);

            }

            string language = SPContext.Current.Web.Language.ToString();

            Microsoft.Web.CommandUI.Ribbon ribbon1 = SPRibbon.GetCurrent(this.Page);

            XmlDocument ribbonExtensions = new XmlDocument();
            ribbonExtensions.LoadXml(Properties.Resources.txtTimesheetApprovalsTab.Replace("#language#", language));
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
            if (disabled) return;
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

            if (EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveTSDisableApprovals").ToLower() == "true")
            {
                disabled = true;
                return;
            }

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
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        try
                        {

                            cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                            cn.Open();
                            SqlCommand cmd = new SqlCommand("SELECT * from TSPERIOD where site_id=@siteid and locked = 0 order by period_id", cn);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
                            SqlDataReader dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                arrPeriods.Add(dr.GetInt32(0), dr.GetDateTime(1).ToShortDateString() + " - " + dr.GetDateTime(2).ToShortDateString());
                            }

                            dr.Close();
                        }
                        catch { }
                    });
                }
            }
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

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            if (activation != 0)
            {
                output.Write(act.translateStatus(activation));
                return;
            }
            if (disabled)
            {
                output.Write("Timesheet approvals are disabled.");
                return;
            }
            if (arrPeriods.Count <= 0)
            {
                output.Write("No Periods Defined.");
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
            //if (resUrl == "")
            //{
            //    output.Write("No Resource URL has been configured.");
            //    return;
            //}
            output.Write(error);
            try
            {

                SPWeb web = SPContext.Current.Web;

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    try
                    {

                        //SqlConnection cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                        //cn.Open();

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
                                //toolbar.Controls[0].Controls[1].Controls[0].Controls[6].Visible = false;
                            }
                            
                        }
                        dr.Close();
                    }
                    catch { }
                });


                renderGrid(output, web);

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
            catch (Exception exception)
            {
                output.Write("Error: " + exception.Message);
            }
            try
            {
                cn.Close();
            }
            catch { }
        }

        /*private string getGridParams(bool nonwork)
        {
            string data = "";
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                string strProps = EPMLiveCore.CoreFunctions.getListSetting(SPContext.Current.List, "GeneralSettings");

                string[] props = strProps.Split('\n');

                string strLists = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveTSLists");

                strLists = strLists.Replace(",", "|").Replace("\r\n", ",");

                if (props.Length >= 12)
                {

                    if (nonwork)
                        strLists = EPMLiveCore.CoreFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPMLiveTSNonWork");

                    data = PropList + "\n" + PropView + "\n" + props[3] + "\n" + props[5] + "\n" + props[7] + "\n" + strLists + "\n" + Page.Request["FilterField1"] + "\n" + Page.Request["FilterValue1"] + "\n" + props[9].Replace("\r\n", ",") + "\n" + sFullGridId + "\n\n";
                }
                else
                    data = PropList + "\n" + PropView + "\n\n\n\n" + strLists + "\n" + Page.Request["FilterField1"] + "\n" + Page.Request["FilterValue1"] + "\n\n" + sFullGridId + "\n\n";




            });
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(data);
            return Convert.ToBase64String(toEncodeAsBytes);
        }*/

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

        private void renderGrid(HtmlTextWriter output, SPWeb web)
        {

            //============================Time Editor===============================
            string firsteditorbox = "";
            string editEvents = "false";
            output.Write(SharedFunctions.getTimeEditorDiv(editEvents, sFullGridId, cn, web, out firsteditorbox));

            //=============end time editor======================

            //output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid.css\"/>");
            //output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xgrid/dhtmlxgrid_skins.css\"/>");
            //output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/calendar/dhtmlxcalendar.css\"/>");
            //output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xmenu/dhtmlxmenu.css\">");
            //output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xmenu/context.css\">");
            //output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/dhtml/xcombo/dhtmlxcombo.css\">");

            //output.Write("<script>_css_prefix=\"/_layouts/epmlive/DHTML/xgrid/\"; _js_prefix=\"/_layouts/epmlive/DHTML/xgrid/\"; </script>");
            //output.Write("<link rel=\"stylesheet\" href=\"/_layouts/epmlive/modal/modalmain.css\" type=\"text/css\" /> ");
            //output.Write("<script type=\"text/javascript\" src=\"/_layouts/epmlive/modal/modal.js\"></script>");
            //output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js\"></script>");
            //output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js\"></script>");
            //output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js\"></script>");
            //output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid_post.js\"></script>");

            //output.Write("<script src=\"/_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js\"></script>");
            //output.Write("<script src=\"/_layouts/epmlive/DHTML/xtreegrid/ext/dhtmlxtreegrid_filter.js\"></script>");

            //output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_nxml.js\"></script>");
            //output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_filter.js\"></script>");
            //output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_math.js\"></script>");
            //output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/ext/dhtmlxgrid_srnd.js\"></script>");

            //output.Write("<script src=\"/_layouts/epmlive/DHTML/xcombo/dhtmlxcombo.js\"></script>");

            //output.Write("<script src=\"/_layouts/epmlive/DHTML/dhtmlxajax.js\"></script>");

            //output.Write("<script language=\"JavaScript\" src=\"/_layouts/epmlive/dhtml/xmenu/dhtmlxprotobar.js\"></script>");
            //output.Write("<script language=\"JavaScript\" src=\"/_layouts/epmlive/dhtml/xmenu/dhtmlxmenubar.js\"></script>");
            //output.Write("<script language=\"JavaScript\" src=\"/_layouts/epmlive/dhtml/xmenu/dhtmlxmenubar_cp.js\"></script>");

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




            output.Write("<div id=\"dlgProcessing\" class=\"dialog\"><table width=\"100%\"><tr><td align=\"center\" class=\"ms-sectionheader\"><img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/><br /><H3 class=\"ms-standardheader\">Processing Timesheets...</h3></td></tr></table></div>");
            output.Write("<div id=\"dlgEmailing\" class=\"dialog\"><table width=\"100%\"><tr><td align=\"center\" class=\"ms-sectionheader\"><img src=\"/_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/><br /><H3 class=\"ms-standardheader\">Sending Emails...</h3></td></tr></table></div>");

            output.Write("<div id=\"grid" + this.ID + "\" style=\"width:100%;display:none;\" ></div>\r\n\r\n");

            output.Write("<div  width=\"100%\" id=\"loadinggrid" + this.ID + "\" align=\"center\">");
            output.Write("<img src=\"/_layouts/images/gears_anv4.gif\" style=\"vertical-align: middle;\"/> Loading Resources...");
            output.Write("</div>");

            output.Write("<div id=\"tsnotesgrid" + this.ID + "\" style=\"display:none; border: 1px solid #808080; padding: 3px; background-color: #F9F9F9; width:220px;height:115px\">");
            //output.Write("<div id=\"multichoiceinner" + sFullGridId + "\" style=\"width: 100%; height: 100%;  background-color: #FFFFFF; border: 1px solid #808080; margin-top:2px; padding:0px;\" class=\"ms-descriptiontext\">");
            //output.Write("test");
            //output.Write("</div>");
            string dbed = "";

            if (status != "Open")
                dbed = "disabled=\"true\"";
            output.Write("<textarea id=\"tsnotes" + sFullGridId + "\" cols=\"30\" rows=\"6\" class=\"ms-input\" " + dbed + "></textarea>");
            output.Write("<table border=\"0\" width=\"200\"><tr><td align=\"right\">");
            output.Write("<font class=\"ms-descriptiontext\"><a href=\"javascript:mygrid" + sFullGridId + ".editStop();\">Close</a></font>");
            output.Write("</td></tr></table>");
            output.Write("</div>");

            output.Write("<script language=\"javascript\">");
            output.Write("var actionurl" + sFullGridId + " = \"" + web.Url + "/_layouts/epmlive/dotsaction.aspx\";");
            output.Write("var emailurl" + sFullGridId + " = \"" + web.Url + "/_layouts/epmlive/sendtsemail.aspx\";");
            output.Write("var period" + sFullGridId + " = " + intPeriod.ToString() + ";");

            output.Write("function gridfilter" + sFullGridId + "(value){");
            output.Write("var vals = value.split('|');");
            output.Write("mygrid" + sFullGridId + ".filterBy(vals[0]+4,vals[1]);");
            output.Write("}");



            //output.Write("function changeview" + sFullGridId + "(view){");
            //output.Write("try{");
            //output.Write("document.getElementById('zz35_ViewSelectorMenu').innerText = view.replace(new RegExp( \"%20\", \"g\" ), \" \");");
            //output.Write("document.getElementById(\"grid" + this.ID + "\").style.display = \"none\";");
            //output.Write("document.getElementById(\"loadinggrid" + this.ID + "\").style.display = \"\";");
            //output.Write("mygrid" + sFullGridId + ".detachHeader(1);");
            //output.Write("mygrid" + sFullGridId + ".clearAll(true);");
            //output.Write("mygrid" + sFullGridId + ".loadXML(\"" + resWeb.Url + "/_layouts/epmlive/gettsapprovals.aspx?view=\" + view + \"&gridname=" + sFullGridId + "&period=" + intPeriod.ToString() + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "\");");
            //output.Write("}catch(e){alert(e);}");
            //output.Write("}");

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

            //output.Write("mygrid" + sFullGridId + ".attachEvent(\"onCheck\", doOnCheck" + sFullGridId + ");");

            output.Write("mygrid" + sFullGridId + ".attachEvent(\"onXLE\",switchFilterLoad" + sFullGridId + ");");

            if (status != "Open")
                output.Write("mygrid" + sFullGridId + ".attachEvent(\"onXLE\",hideCol" + sFullGridId + ");");

            //output.Write("mygrid" + sFullGridId + ".attachEvent(\"onBeforeContextMenu\",onShowMenu);");

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

            output.WriteLine(Properties.Resources.txtTimesheetApprovalsRibbonFunctions.Replace("#gridid#", sFullGridId));


            output.Write("mygrid" + sFullGridId + ".init();\r\n\r\n\r\n");

            output.Write("function loadX" + sFullGridId + "(){");
            output.Write("var w = document.getElementById('WebPart" + this.Qualifier + "').offsetWidth - 20;");
            output.Write("mygrid" + sFullGridId + ".loadXML(\"" + web.Url + "/_layouts/epmlive/gettsapprovals.aspx?data=" + sFullParamList + "&source=" + System.Web.HttpUtility.UrlEncode(System.Web.HttpContext.Current.Request.Url.ToString()) + "&rnd=" + Guid.NewGuid() + "&period=" + intPeriod + "&width=\" + w);");

            output.Write("}");


            output.Write("initmb();");

            output.WriteLine("function clickTab(){");
            output.WriteLine("var wp = document.getElementById('MSOZoneCell_WebPart" + this.Qualifier + "');");
            output.WriteLine("fireEvent(wp, 'mouseup');");
            output.WriteLine("setTimeout(\"clickbrowse()\",1000);");
            output.WriteLine("}");

            output.WriteLine("function clickbrowse(){");
            output.WriteLine("var wp2 = document.getElementById('Ribbon.TimesheetApprovals-title').firstChild;");
            output.WriteLine("fireEvent(wp2, 'click');");
            output.WriteLine("}");

            output.Write("SP.SOD.executeOrDelayUntilScriptLoaded(clickTab, \"GridViewContextualTabPageComponent.js\");");

            output.Write("_spBodyOnLoadFunctionNames.push(\"loadX" + sFullGridId + "\");");

            output.Write(Properties.Resources.txtTSApprovalsJS.Replace("#gridid#", sFullGridId));
            output.WriteLine("<script language=\"javascript\">");
            output.Write(Properties.Resources.txtExcels.Replace("#gridid#", sFullGridId));
            output.WriteLine("</script>");

            output.Write("<input type=\"hidden\" name=\"changeRes\" value=\"yes\">");
            output.Write("<input type=\"hidden\" name=\"resourceList\" value=\"\">");

        }
    }
}
