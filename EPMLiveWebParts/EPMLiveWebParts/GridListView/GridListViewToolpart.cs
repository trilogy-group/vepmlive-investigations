using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
using Microsoft.SharePoint.WebPartPages;
using Microsoft.SharePoint;
using System.Web;

namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:CustomToolPart runat=server></{0}:CustomToolPart>")]
    public class GridListViewToolpart : ToolPart
    {
        protected DropDownList ddlList;
   

        public GridListViewToolpart()
        {
            this.UseDefaultStyles = true;
            this.AllowMinimize = true;
            this.Title = "Grid/Gantt Properties";
        }

        protected override void CreateChildControls()
        {
            //base.CreateChildControls();

            

            ToolPane tp = this.ParentToolPane;
            GridListView myWP = (GridListView)tp.SelectedWebPart;

            ddlList.EnableViewState = true;
        }

        protected override void OnInit(EventArgs e)
        {
            ddlList = new DropDownList();
        }

        protected override void RenderToolPart(HtmlTextWriter output)
        {
            SPWeb web = SPContext.Current.Web;

            ToolPane tp = this.ParentToolPane;
            GridListView myWP =
                (GridListView)tp.SelectedWebPart;



            ddlList.Items.Add(new ListItem("< Select List >", ""));
            foreach (SPList list in web.Lists)
            {
                if (!list.Hidden)
                {
                    try
                    {
                        ddlList.Items.Add(new ListItem(list.Title, list.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url));
                    }
                    catch { }
                }
            }
            ddlList.ID = "ddlList" + this.ID;
            ddlList.SelectedValue = myWP.PropList;
            output.Write("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js\"></script>");
            output.Write("<div id=\"divTpLoading\" style=\"width:100%;height:400;background:#FFFFFF;display:none\" align=\"center\">");
            output.Write("<br><br><br><br><br><br><br><img src=\"_layouts/images/gears_anv4.gif\">");
            output.Write("</div>");
            output.Write("<div id=\"divEverything\">");

            output.Write("<div class=\"UserSectionHead\">");
            output.Write("List Information");
            output.Write("<table cellpadding=1 style=\"padding-left: 5px\"><tr><td>");
            output.Write("<input type=\"checkbox\" name=\"chkLock" + this.ID + "\" id=\"chkLock" + this.ID + "\"");
            if (myWP.PropLockViewContext.Value)
                output.Write(" checked");
            output.Write(" onclick=\"lockContext();\">Lock View Context");
            output.Write("</td></tr><tr><td>");

            output.Write("List:<br>");
            if (myWP.PropLockViewContext.Value)
                ddlList.Enabled = false;

            ddlList.Attributes.Add("onchange", "changeList();");
            ddlList.RenderControl(output);

            output.Write("</td></tr><tr><td>");

            output.Write("View:<br>");
            output.Write("<select id=\"ddlView" + this.ID + "\" name=\"ddlView" + this.ID + "\"");
            if (myWP.PropLockViewContext.Value)
                output.Write(" disabled");
            output.Write(" >");
            output.Write("<option value=\"\">&lt; Select View &gt;</option>");
            if (myWP.PropList != null && myWP.PropList != "")
            {
                foreach (SPView view in web.GetListFromUrl(myWP.PropList).Views)
                {
                    if (!view.Hidden && !view.PersonalView)
                    {
                        output.Write("<option value=\"" + view.Title + "\"");
                        if (view.Title == myWP.PropView)
                            output.Write(" selected");
                        output.Write(">" + view.Title + "</option>");
                    }
                }
            }
            output.Write("</select>");
            output.Write("</td></tr><tr><td>");

            output.Write("Default Control:<br>");
            output.Write("<select id=\"ddlDefaultControl" + this.ID + "\" name=\"ddlDefaultControl" + this.ID + "\"><option value=\"Grid\">Grid</option><option value=\"Gantt\">Gantt</option></select>");
            output.Write("</td></tr><tr><td>");
            output.Write("<input type=\"checkbox\" name=\"chkUseDefaults" + this.ID + "\" id=\"chkUseDefaults" + this.ID + "\"");
            if (myWP.PropUseDefaults.Value)
                output.Write(" checked");
            output.Write(" onclick=\"useDefaults();\">Use Settings from List");
            output.Write("</td></tr><tr><td>");
            output.Write("</td></tr></table>");

            output.Write("</div>");
            output.Write("<div style='width:100%' class='UserDottedLine'></div>");

            output.Write("<div id=\"divNonDefaults\" style=\"display:");
            if (myWP.PropUseDefaults.Value)
                output.Write("none");
            output.Write("\">");

                output.Write("<div class=\"UserSectionHead\" id=\"fldSection" + this.ID + "\">");
                output.Write("Field Information");
                output.Write("<table cellpadding=1 style=\"padding-left: 5px\"><tr><td>");

                output.Write("Start:<br>");
                output.Write("<select id=\"ddlStart" + this.ID + "\" name=\"ddlStart" + this.ID + "\" onchange=\"propStart = this.options[this.selectedIndex].value;\"></select>");
                output.Write("</td></tr><tr><td>");

                output.Write("Finish:<br>");
                output.Write("<select id=\"ddlFinish" + this.ID + "\" name=\"ddlFinish" + this.ID + "\" onchange=\"propFinish = this.options[this.selectedIndex].value;\"></select>");
                output.Write("</td></tr><tr><td>");

                output.Write("Progress Bar:<br>");
                output.Write("<select id=\"ddlProgress" + this.ID + "\" name=\"ddlProgress" + this.ID + "\" onchange=\"propProgress = this.options[this.selectedIndex].value;\"></select>");
                output.Write("</td></tr><tr><td>");

                output.Write("Milestone:<br>");
                output.Write("<select id=\"ddlMilestone" + this.ID + "\" name=\"ddlMilestone" + this.ID + "\" onchange=\"propMilestone = this.options[this.selectedIndex].value;\"></select>");
                output.Write("</td></tr><tr><td>");

                output.Write("Right Information:<br>");
                output.Write("<select id=\"ddlInfo" + this.ID + "\" name=\"ddlInfo" + this.ID + "\" onchange=\"propInfo = this.options[this.selectedIndex].value;\"></select>");
                output.Write("</td></tr><tr><td>");

                output.Write("WBS:<br>");
                output.Write("<select id=\"ddlWBS" + this.ID + "\" name=\"ddlWBS" + this.ID + "\" onchange=\"propWBS = this.options[this.selectedIndex].value;\"></select>");
                output.Write("</td></tr></table>");
                output.Write("</div>");

                output.Write("<div style='width:100%' class='UserDottedLine'></div>");

                output.Write("<div class=\"UserSectionHead\">");
                output.Write("Rollup Settings<br>");
                output.Write("<table cellpadding=1 style=\"padding-left: 5px\"><tr><td>");
                output.Write("Rollup List(s):<br>");
                output.Write("<textarea name=\"rollupList\" class=\"ms-input\" cols=\"25\" rows=\"5\">" + myWP.PropRollupList + "</textarea>");

                output.Write("</td></tr><tr><td>");
                output.Write("Rollup Site(s):<br>");
                output.Write("<textarea name=\"rollupSites\" class=\"ms-input\" cols=\"25\" rows=\"5\">" + myWP.PropRollupSites + "</textarea>");

                if (SPContext.Current.Web.CurrentUser.IsSiteAdmin)
                {
                    output.Write("</td></tr><tr><td>");
                    output.Write("<input type=\"checkbox\" name=\"chkExecutive" + this.ID + "\"");
                    if (myWP.PropExecView == "on")
                        output.Write(" checked");
                    output.Write("> Executive View");
                }

                output.Write("</td></tr><tr><td>");
                output.Write("<input type=\"checkbox\" name=\"chkPerformance" + this.ID + "\"");
                if (myWP.PropPerformance.Value)
                    output.Write(" checked");
                output.Write("> Enhance Perfomance");
            
                output.Write("</td></tr><tr><td>");
                output.Write("<input type=\"checkbox\" name=\"chkContentReporting" + this.ID + "\"");
                if(myWP.PropContentReporting.Value)
                    output.Write(" checked");
                output.Write("> Use Content DB");

                output.Write("</td></tr></table>");
                output.Write("</div>");

                output.Write("<div style='width:100%' class='UserDottedLine'></div>");

                output.Write("<div class=\"UserSectionHead\">");
                output.Write("Other Information");
                output.Write("<table cellpadding=1 style=\"padding-left: 5px\"><tr><td>");
                output.Write("<input type=\"checkbox\" name=\"chkShowViewToolbar" + this.ID + "\"");
                if (myWP.PropShowViewToolbar.Value)
                    output.Write(" checked");
                output.Write(">Show View Toolbar");
                output.Write("</td></tr><tr><td>");

                output.Write("Item Link Type:<br>");
                output.Write("<select id=\"ddlLinkType" + this.ID + "\" name=\"ddlLinkType" + this.ID + "\">");
                output.Write("</select>");
                output.Write("</td></tr><tr><td>");
                output.Write("<input type=\"checkbox\" name=\"chkHideNew" + this.ID + "\"");
                if (myWP.PropHideNewButton.Value)
                    output.Write(" checked");
                output.Write(">Hide New Button");
                output.Write("</td></tr><tr><td>");
                output.Write("<input type=\"checkbox\" name=\"chkUsePopup" + this.ID + "\"");
                if (myWP.PropUsePopup.Value)
                    output.Write(" checked");
                output.Write(">Use Pop-up");
                output.Write("</td></tr></table>");
                output.Write("</div>");
                output.Write("<div style='width:100%' class='UserDottedLine'></div>");

                output.Write("<div class=\"UserSectionHead\">");
                output.Write("Edit Mode");
                output.Write("<table cellpadding=1 style=\"padding-left: 5px\"><tr><td>");
                output.Write("<input type=\"checkbox\" name=\"chkAllowEdit" + this.ID + "\"");
                if (myWP.PropAllowEdit.Value)
                    output.Write(" checked");
                output.Write(">Allow Edit Toggle");
                output.Write("</td></tr><tr><td>");
                output.Write("<input type=\"checkbox\" name=\"chkEditMode" + this.ID + "\"");
                if (myWP.PropEdit.Value)
                    output.Write(" checked");
                output.Write(">Default To Edit Mode");
                output.Write("</td></tr><tr><td>");
                output.Write("<input type=\"checkbox\" name=\"chkShowInsertRow" + this.ID + "\"");
                if (myWP.PropShowInsertRow.Value)
                    output.Write(" checked");
                output.Write(">Show Insert Row");

                output.Write("</td></tr><tr><td>");
                output.Write("<input type=\"checkbox\" name=\"chkUseParent" + this.ID + "\"");
                if(myWP.PropUseParent.Value)
                    output.Write(" checked");
                output.Write(">Use Parent Item");

                output.Write("</td></tr><tr><td>");
                output.Write("<input type=\"checkbox\" name=\"chkShowSearch" + this.ID + "\"");
                if(myWP.PropShowSearch.Value)
                    output.Write(" checked");
                output.Write(">Force Search");

                output.Write("</td></tr><tr><td>");
                output.Write("<input type=\"checkbox\" name=\"chkLockSearch" + this.ID + "\"");
                if(myWP.PropLockSearch.Value)
                    output.Write(" checked");
                output.Write(">Persist Search");

                output.Write("</td></tr></table>");
                output.Write("</div>");

                output.Write("<div style='width:100%' class='UserDottedLine'></div>");
            output.Write("</div>");

                

                
                //===================================

                output.Write("<div class=\"UserSectionHead\">");
                output.Write("Additional Groupings");
                output.Write("<table cellpadding=1 style=\"padding-left: 5px\"><tr><td>");

                output.Write("Select Field:<br>");
                output.Write("<select id=\"ddlGroup1" + this.ID + "\" name=\"ddlGroup1" + this.ID + "\" onchange=\"propGroup1 = this.options[this.selectedIndex].value;\"></select>");
                output.Write("</td></tr><tr><td>");

                output.Write("Select Field:<br>");
                output.Write("<select id=\"ddlGroup2" + this.ID + "\" name=\"ddlGroup2" + this.ID + "\" onchange=\"propGroup2 = this.options[this.selectedIndex].value;\"></select>");
                output.Write("</td></tr><tr><td>");

                output.Write("Expand To Level:<br>");
                output.Write("<select id=\"ddlExpand" + this.ID + "\" name=\"ddlExpand" + this.ID + "\">");
                output.Write("<option value=\"\">< Use View Settings ></option>");
                for (int i = 1; i <= 4; i++)
                {
                    output.Write("<option value=\"" + i + "\"");
                    if (i.ToString() == myWP.PropExpand)
                        output.Write(" selected");
                    output.Write(">Level " + i + "</option>");
                }
                output.Write("</select>");
                output.Write("</td></tr></table>");
                output.Write("</div>");


            string cList = "";
            string cView = "";
            string cFields = "";
            try
            {
                cList = SPContext.Current.List.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url;
                cView = SPContext.Current.ViewContext.View.Title;
                foreach (SPField f in SPContext.Current.List.Fields)
                {
                    if (!f.Hidden && f.Type != SPFieldType.Computed)
                    {
                        f.Title = System.Web.HttpUtility.UrlEncode(f.Title).Replace("+", "%20");
                        cFields += "," + f.Title + "|" + f.InternalName + "|" + f.Type.ToString();
                    }
                }
                if (cFields.Length > 1)
                    cFields = cFields.Substring(1);
            }
            catch { }

            string oFields = "";
            try
            {
                if (myWP.PropList != null && myWP.PropList != "")
                {
                    foreach (SPField f in web.GetListFromUrl(myWP.PropList).Fields)
                    {
                        if (!f.Hidden && f.Type != SPFieldType.Computed)
                        {
                            f.Title = System.Web.HttpUtility.UrlEncode(f.Title).Replace("+", "%20");
                            oFields += "," + f.Title + "|" + f.InternalName + "|" + f.Type.ToString();
                        }
                    }
                    if (oFields.Length > 1)
                        oFields = oFields.Substring(1);
                }
            }
            catch { }
            

            output.Write("<script>");
            output.Write("var contextList = \"" + cList + "\";");
            output.Write("var contextView = \"" + cView + "\";");
            output.Write("var contextFields = \"" + cFields + "\";");
            output.Write("var propStart = \"" + myWP.PropStart + "\";");
            output.Write("var propFinish = \"" + myWP.PropFinish + "\";");
            output.Write("var propProgress = \"" + myWP.PropProgress + "\";");
            output.Write("var propInfo = \"" + myWP.PropInformation + "\";");
            output.Write("var propWBS = \"" + myWP.PropWBS + "\";");
            output.Write("var propMilestone = \"" + myWP.PropMilestone + "\";");
            output.Write("var propGroup1 = \"" + myWP.PropGroup1 + "\";");
            output.Write("var propGroup2 = \"" + myWP.PropGroup2 + "\";");
            output.Write("var propLinkType = \"" + myWP.PropLinkType + "\";");

            output.Write("var webUrl = \"" + web.Url + "\";");


            output.Write("var oFields = \"" + oFields + "\";");

            output.Write(Properties.Resources.txtGridToolpartJS.Replace("#tpid#", this.ID));

            output.Write("_spBodyOnLoadFunctionNames.push(\"loadFields\");");

            output.Write("</script>");
            output.Write("</div>");
            
        }

        public override void ApplyChanges()
        {
            //EnsureChildControls();

            ToolPane tp = this.ParentToolPane;
            GridListView myWP =
                (GridListView)tp.SelectedWebPart;

            ////Send back our text to our web part
            myWP.PropList = Page.Request["ddlList" + this.ID];
            myWP.PropView = Page.Request["ddlView" + this.ID];

            myWP.PropRollupList = Page.Request["rollupList"];
            myWP.PropRollupSites = Page.Request["rollupSites"];

            myWP.PropFinish = Page.Request["ddlFinish" + this.ID];
            myWP.PropInformation = Page.Request["ddlInformation" + this.ID];
            myWP.PropMilestone = Page.Request["ddlMilestone" + this.ID];
            myWP.PropProgress = Page.Request["ddlProgress" + this.ID];
            myWP.PropStart = Page.Request["ddlStart" + this.ID];
            myWP.PropWBS = Page.Request["ddlWBS" + this.ID];

            string psvt = Page.Request["chkShowViewToolbar" + this.ID];
            if (psvt == "on")
                myWP.PropShowViewToolbar = true;
            else
                myWP.PropShowViewToolbar = false;

            string psup = Page.Request["chkUsePopup" + this.ID];
            if (psup == "on")
                myWP.PropUsePopup = true;
            else
                myWP.PropUsePopup = false;

            string psparent = Page.Request["chkUseParent" + this.ID];
            if(psparent == "on")
                myWP.PropUseParent = true;
            else
                myWP.PropUseParent = false;

            string search = Page.Request["chkShowSearch" + this.ID];
            if(search == "on")
                myWP.PropShowSearch = true;
            else
                myWP.PropShowSearch = false;

            string locksearch = Page.Request["chkLockSearch" + this.ID];
            if(locksearch == "on")
                myWP.PropLockSearch = true;
            else
                myWP.PropLockSearch = false;

            myWP.PropExecView = Page.Request["chkExecutive" + this.ID];
            myWP.PropLinkType = Page.Request["ddlLinkType" + this.ID];

            myWP.PropGroup1 = Page.Request["ddlGroup1" + this.ID];
            myWP.PropGroup2 = Page.Request["ddlGroup2" + this.ID];
            myWP.PropExpand = Page.Request["ddlExpand" + this.ID];

            string plvc = Page.Request["chkLock" + this.ID];
            if (plvc == "on")
                myWP.PropLockViewContext = true;
            else
                myWP.PropLockViewContext = false;

            myWP.PropDefaultControl = Page.Request["ddlDefaultControl" + this.ID];

            string ud = Page.Request["chkUseDefaults" + this.ID];
            if (ud == "on")
                myWP.PropUseDefaults = true;
            else
                myWP.PropUseDefaults = false;

            string hn = Page.Request["chkHideNew" + this.ID];
            if (hn == "on")
                myWP.PropHideNewButton = true;
            else
                myWP.PropHideNewButton = false;

            string ae = Page.Request["chkAllowEdit" + this.ID];
            if (ae == "on")
                myWP.PropAllowEdit = true;
            else
                myWP.PropAllowEdit = false;

            string em = Page.Request["chkEditMode" + this.ID];
            if (em == "on")
                myWP.PropEdit = true;
            else
                myWP.PropEdit = false;

            string ir = Page.Request["chkShowInsertRow" + this.ID];
            if (ir == "on")
                myWP.PropShowInsertRow = true;
            else
                myWP.PropShowInsertRow = false;


            string ip = Page.Request["chkPerformance" + this.ID];
            if (ip == "on")
                myWP.PropPerformance = true;
            else
                myWP.PropPerformance = false;

            string ic = Page.Request["chkContentReporting" + this.ID];
            if(ic == "on")
                myWP.PropContentReporting = true;
            else
                myWP.PropContentReporting = false;
        }

    }
}
