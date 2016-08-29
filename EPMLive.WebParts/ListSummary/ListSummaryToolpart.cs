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
    [ToolboxData("<{0}:ListSummaryToolPart runat=server></{0}:CustomToolPart>")]
    public class ListSummaryToolpart : ToolPart
    {
        protected DropDownList ddlList;
   

        public ListSummaryToolpart()
        {
            this.UseDefaultStyles = true;
            this.AllowMinimize = true;
            this.Title = "ListSummary Properties";
        }

        protected override void CreateChildControls()
        {
            //base.CreateChildControls();

            

            ToolPane tp = this.ParentToolPane;
            ListSummary myWP = (ListSummary)tp.SelectedWebPart;

            
        }

        protected override void OnInit(EventArgs e)
        {
            ddlList = new DropDownList();
        }

        protected override void RenderToolPart(HtmlTextWriter output)
        {
            SPWeb web = SPContext.Current.Web;

            ToolPane tp = this.ParentToolPane;
            ListSummary myWP =
                (ListSummary)tp.SelectedWebPart;



            ddlList.Items.Add(new ListItem("< Select List >", ""));
            foreach (SPList list in web.Lists)
            {
                if (!list.Hidden)
                {
                    ddlList.Items.Add(new ListItem(list.Title, list.Forms[PAGETYPE.PAGE_DISPLAYFORM].Url));
                }
            }
            ddlList.ID = "ddlList" + this.ID;
            ddlList.SelectedValue = myWP.PropList;


            output.Write("<script src=\"/_layouts/epmlive/DHTML/dhtmlxajax.js\"></script>");

            output.Write("<div id=\"divTpLoading\" style=\"width:100%;height:400;background:#FFFFFF;display:none\" align=\"center\">");
            output.Write("<br><br><br><br><br><br><br><img src=\"_layouts/images/GEARS_ANv4.GIF\">");
            output.Write("</div>");

            output.Write("<div id=\"divEverything\">");

                output.Write("<div class=\"UserSectionHead\">");
                    output.Write("List Information");

                    output.Write("<table cellpadding=1 style=\"padding-left: 5px\"><tr><td>");
                    output.Write("List:<br>");

                    ddlList.Attributes.Add("onchange", "changeList();");
                    ddlList.RenderControl(output);

                    output.Write("</td></tr><tr><td>");

                    output.Write("View Filters:<br>");
                    output.Write("<select id=\"ddlView" + this.ID + "\" name=\"ddlView" + this.ID + "\"");
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

                    output.Write("Count Value Field:<br>");
                    output.Write("<select id=\"ddlStatus" + this.ID + "\" name=\"ddlStatus" + this.ID + "\" onchange=\"propStatus = this.options[this.selectedIndex].value;\"></select>");

                    output.Write("</td></tr></table>");
                output.Write("</div>");

                //output.Write("<div class=\"UserSectionHead\" id=\"fldSection" + this.ID + "\">");
                output.Write("<div style='width:100%' class='UserDottedLine'></div>");

                output.Write("<div class=\"UserSectionHead\">");
                output.Write("Rollup Settings<br>");
                output.Write("<table cellpadding=1 style=\"padding-left: 5px\"><tr><td>");
                output.Write("Rollup List(s):<br>");
                output.Write("<textarea name=\"rollupList\" class=\"ms-input\" cols=\"25\" rows=\"5\">" + myWP.PropRollupList + "</textarea>");

                output.Write("</td></tr><tr><td>");
                output.Write("Rollup Site(s):<br>");
                output.Write("<textarea name=\"rollupSites\" class=\"ms-input\" cols=\"25\" rows=\"5\">" + myWP.PropRollupSites + "</textarea>");
                output.Write("</td></tr></table>");

                output.Write("</div>");

            output.Write("<div style='width:100%' class='UserDottedLine'></div>");
            output.Write("<div class=\"UserSectionHead\">");
            output.Write("Additional Settings<br>");
                output.Write("<table cellpadding=1 style=\"padding-left: 5px\"><tr><td>");
                output.Write("Action URL:<br>");
                output.Write("<input type=\"text\" name=\"actionurl\" class=\"ms-input\" value=\"" + myWP.PropUrl + "\"><br>Note: Use {SiteUrl} as a wildcard for your site url.");
                output.Write("</td></tr></table>");
            output.Write("</div>");

               //output.Write("</div>");

                

                


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
            output.Write("var propStatus = \"" + myWP.PropStatus + "\";");

            output.Write("var webUrl = \"" + web.Url + "\";");


            output.Write("var oFields = \"" + oFields + "\";");

            output.Write(Properties.Resources.txtListSummaryJS.Replace("#tpid#", this.ID));

            output.Write("_spBodyOnLoadFunctionNames.push(\"loadFields\");");

            output.Write("</script>");
            output.Write("</div>");
            
        }

        public override void ApplyChanges()
        {
            //EnsureChildControls();

            ToolPane tp = this.ParentToolPane;
            ListSummary myWP =
                (ListSummary)tp.SelectedWebPart;

            ////Send back our text to our web part
            myWP.PropList = Page.Request["ddlList" + this.ID];
            myWP.PropView = Page.Request["ddlView" + this.ID];

            myWP.PropRollupList = Page.Request["rollupList"];
            myWP.PropRollupSites = Page.Request["rollupSites"];

            myWP.PropStatus = Page.Request["ddlStatus" + this.ID];

            myWP.PropUrl = Page.Request["actionurl"].ToString().Replace(SPContext.Current.Web.Url,"{SiteUrl}");
            
        }

    }
}
