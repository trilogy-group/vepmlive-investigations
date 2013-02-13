using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

using System.ComponentModel;
using System.Web;

namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:WorkspaceCenter runat=server></{0}:WorkspaceCenter>")]
    [Guid("c0a8cb18-6757-4b21-b881-5f8030c2381a")]
    [XmlRoot(Namespace = "WorkspaceList")]
    public class WorkspaceList : Microsoft.SharePoint.WebPartPages.WebPart
    {
        private bool boolExecutive;
        private bool boolNewWorkspace;
        private bool boolSiteCollection;

        [Category("Custom Properties")]
        [DefaultValue(false)]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Executive View")]
        [Description("Type a string value.")]
        [Browsable(true)]
        [XmlElement(ElementName = "PropExecutive")]

        public bool PropExecutive
        {
            get
            {
                return boolExecutive;
            }
            set
            {
                boolExecutive = value;
            }
        }

        [Category("Custom Properties")]
        [DefaultValue(false)]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Show New Workspace Button")]
        [Description("Type a string value.")]
        [Browsable(true)]
        [XmlElement(ElementName = "PropNewWorkspace")]
        public bool PropNewWorkspace
        {
            get
            {
                return boolNewWorkspace;
            }
            set
            {
                boolNewWorkspace = value;
            }
        }

        [Category("Custom Properties")]
        [DefaultValue(false)]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Show Entire Site Collection")]
        [Description("Type a string value.")]
        [Browsable(true)]
        [XmlElement(ElementName = "PropSiteCollection")]
        public bool PropSiteCollection
        {
            get
            {
                return boolSiteCollection;
            }
            set
            {
                boolSiteCollection = value;
            }
        }

        public WorkspaceList()
        {
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            SPWeb web = SPContext.Current.Web;

            ScriptLink.Register(Page, "/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js", false);
            ScriptLink.Register(Page, "/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js", false);
            ScriptLink.Register(Page, "/_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js", false);
            ScriptLink.Register(Page, "/_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js", false);
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            SPBasePermissions bpSite = SPBasePermissions.ManageSubwebs;
            SPWeb cWeb = SPContext.Current.Web;

            if (PropNewWorkspace)
            {
                output.Write("<table class=\"ms-menutoolbar\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" width=\"100%\" style=\"height:10px\">");
                output.Write("<tr height=\"23\">");
                output.Write("<td class=\"ms-toolbar\" nowrap=\"true\">");
                if (SPContext.Current.Web.DoesUserHavePermissions(bpSite))
                {
                    output.Write("<table height=\"100%\" border=\"0\" width=\"95\" cellspacing=\"0\" onmouseover=\"MMU_EcbTableMouseOverOut(this, true)\" hoverActive=\"ms-splitbuttonhover\" hoverInactive=\"ms-splitbutton\" downArrowTitle=\"Add Workspace\">");
                    output.Write("<tr>");
                    output.Write("<td valign=\"middle\" class=\"ms-splitbuttontext\">");
                    SPList pcList = cWeb.Lists.TryGetList("Project Center");
                    string createNewWorkspaceUrl = cWeb.ServerRelativeUrl + "/_layouts/epmlive/createnewworkspace.aspx?list=" + pcList.ID.ToString("B") + "&type=site&source=" + HttpContext.Current.Request.Url.AbsoluteUri;
                    string href = "javascript:var options = { url:'" + createNewWorkspaceUrl + "', width: 800, height:600, title: 'Create', dialogReturnValueCallback : Function.createDelegate(null, HandleCreateNewWorkspaceCreate) }; SP.UI.ModalDialog.showModalDialog(options); return false;";
                    output.Write("<a href=\"#\" onclick = \"" + href + "\">New Workspace</a>");
                    output.Write("</td>");
                    output.Write("</tr>");
                    output.Write("</table>");
                }
                output.Write("</td>");
                output.Write("</tr>");
                output.Write("</table>");
            }
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.css\"/>");
            output.Write("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"_layouts/epmlive/DHTML/xgrid/dhtmlxgrid_skins.css\"/>");

            output.Write("<script>_css_prefix=\"_layouts/epmlive/DHTML/xgrid/\"; _js_prefix=\"_layouts/epmlive/DHTML/xgrid/\"; </script>");

            output.Write("<div id=\"grid" + this.UniqueID + "\" style=\"width:100%;display:none;\" ></div>\r\n\r\n");

            output.Write("<div  width=\"100%\" id=\"loadinggrid" + this.UniqueID + "\" align=\"center\">");
            output.Write("<img src=\"_layouts/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/> Loading Items...");
            output.Write("</div>");

            output.Write("<script>");
            output.Write("mygrid = new dhtmlXGridObject('grid" + this.UniqueID + "');");

            output.Write("mygrid.setImagePath('" + SPContext.Current.Web.Url + "/_layouts/epmlive/DHTML/xgrid/imgs/');");
            output.Write("mygrid.setSkin('myworkspace');");
            output.Write("mygrid.setImageSize(16,16);");
            output.Write("mygrid.attachEvent('onXLE',clearLoader);");
            output.Write("mygrid.enableAutoHeigth(true);");
            output.Write("mygrid.enableAlterCss('', '');");
            output.Write("mygrid.setNoHeader(true);");
            //output.Write("mygrid.setStyle('', '', '', 'background-color:white;');");
            output.Write("mygrid.init();");
            output.Write("mygrid.loadXML('" + SPContext.Current.Web.Url + "/_layouts/epmlive/getworkspacelisttree.aspx?executive=" + PropExecutive.ToString().ToLower() + "&site=" + boolSiteCollection.ToString().ToLower() + "');");
            output.Write("function clearLoader(id)");
            output.Write("{");
            output.Write("document.getElementById('grid" + this.UniqueID + "').style.display = " + "''" + ";");
            output.Write("document.getElementById('loadinggrid" + this.UniqueID + "').style.display = " + "'none'" + ";");
            output.Write("}");
            output.Write("</script>");
        }

    }
}
