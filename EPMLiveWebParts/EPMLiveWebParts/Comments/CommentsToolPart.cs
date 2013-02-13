using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.WebPartPages;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;

namespace EPMLiveWebParts.Comments
{
    [ToolboxData("<{0}:CustomToolPart runat=server></{0}:CustomToolPart>")]
    public class CommentsToolPart : ToolPart
    {   
        public override void ApplyChanges()
        {
            ToolPane tp = this.ParentToolPane;
            Comments wpComments = (Comments)tp.SelectedWebPart;

            wpComments.NumThreads = int.Parse(Page.Request["tbMaxThreads"]);
            wpComments.MaxComments = int.Parse(Page.Request["tbMaxComments"]);
        }

        protected override void RenderToolPart(HtmlTextWriter output)
        {
            base.RenderToolPart(output);
            ToolPane tp = this.ParentToolPane;
            Comments myWP =
                (Comments)tp.SelectedWebPart;

            output.Write("<div class=\"UserSectionTitle\">");
            output.Write("<table style=\"PADDING-LEFT: 5px\" cellPadding=\"1\">");
            output.Write("<tbody>");

            output.Write("<tr>");
            output.Write("<td>");
            output.Write("Number of threads to display: \r\n <input type=\"text\" id=\"tbMaxThreads\" name=\"tbMaxThreads\" value=\"" + myWP.NumThreads.ToString() + "\" />");
            output.Write("</td>");
            output.Write("</tr>");

            output.Write("<tr>");
            output.Write("<td>");
            output.Write("Default number of comments per thread: \r\n <input type=\"text\" id=\"tbMaxComments\" name=\"tbMaxComments\" value=\"" + myWP.MaxComments.ToString() + "\" />");
            output.Write("</td>");
            output.Write("</tr>");

            output.Write("</tbody>");
            output.Write("</table>");
            output.Write("</div>");
        }

    }
}
