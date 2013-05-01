using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI;

namespace EPMLiveCore
{
    public partial class WorkspaceListWPCanvas : LayoutsPageBase
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            RenderHTML();
        }

        private void RenderHTML()
        {   
            mainPanel.Controls.Add(new LiteralControl("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.css\"/>"));
            mainPanel.Controls.Add(new LiteralControl("<link rel=\"STYLESHEET\" type=\"text/css\" href=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid_skins.css\"/>"));

            mainPanel.Controls.Add(new LiteralControl("<script>_css_prefix=\"/_layouts/epmlive/DHTML/xgrid/\"; _js_prefix=\"/_layouts/epmlive/DHTML/xgrid/\"; </script>"));

            
            mainPanel.Controls.Add(new LiteralControl("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxcommon.js\"></script>"));
            mainPanel.Controls.Add(new LiteralControl("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxgrid.js\"></script>"));
            mainPanel.Controls.Add(new LiteralControl("<script src=\"/_layouts/epmlive/DHTML/xgrid/dhtmlxgridcell.js\"></script>"));
            mainPanel.Controls.Add(new LiteralControl("<script src=\"/_layouts/epmlive/DHTML/xtreegrid/dhtmlxtreegrid.js\"></script>"));

            mainPanel.Controls.Add(new LiteralControl("<div id=\"grid" + this.UniqueID + "\" style=\"width:100%;display:none;\" ></div>\r\n\r\n"));

            mainPanel.Controls.Add(new LiteralControl("<div  width=\"100%\" id=\"loadinggrid" + this.UniqueID + "\" align=\"center\">"));
            mainPanel.Controls.Add(new LiteralControl("<img src=\"/_layouts/15/images/GEARS_ANv4.GIF\" style=\"vertical-align: middle;\"/> Loading Items..."));
            mainPanel.Controls.Add(new LiteralControl("</div>"));

            mainPanel.Controls.Add(new LiteralControl("<script>"));
            mainPanel.Controls.Add(new LiteralControl("mygrid = new dhtmlXGridObject('grid" + this.UniqueID + "');"));

            mainPanel.Controls.Add(new LiteralControl("mygrid.setImagePath('" + (SPContext.Current.Web.ServerRelativeUrl == "/" ? "" : SPContext.Current.Web.ServerRelativeUrl) + "/_layouts/epmlive/DHTML/xgrid/imgs/');"));
            mainPanel.Controls.Add(new LiteralControl("mygrid.setSkin('myworkspace');"));
            mainPanel.Controls.Add(new LiteralControl("mygrid.setImageSize(16,16);"));
            mainPanel.Controls.Add(new LiteralControl("mygrid.attachEvent('onXLE',clearLoader);"));
            mainPanel.Controls.Add(new LiteralControl("mygrid.enableAutoHeight(true);"));
            mainPanel.Controls.Add(new LiteralControl("mygrid.enableAlterCss('', '');"));
            mainPanel.Controls.Add(new LiteralControl("mygrid.setNoHeader(true);"));
            mainPanel.Controls.Add(new LiteralControl("mygrid.init();"));
            mainPanel.Controls.Add(new LiteralControl("mygrid.loadXML('" + (SPContext.Current.Web.ServerRelativeUrl == "/" ? "" : SPContext.Current.Web.ServerRelativeUrl) + "/_layouts/epmlive/getworkspacelisttree.aspx?executive=true&site=true');"));
            mainPanel.Controls.Add(new LiteralControl("function clearLoader(id)"));
            mainPanel.Controls.Add(new LiteralControl("{"));
            mainPanel.Controls.Add(new LiteralControl("document.getElementById('grid" + this.UniqueID + "').style.display = " + "''" + ";"));
            mainPanel.Controls.Add(new LiteralControl("document.getElementById('loadinggrid" + this.UniqueID + "').style.display = " + "'none'" + ";"));
            mainPanel.Controls.Add(new LiteralControl("}"));
            mainPanel.Controls.Add(new LiteralControl("</script>"));
        }
    }
}
