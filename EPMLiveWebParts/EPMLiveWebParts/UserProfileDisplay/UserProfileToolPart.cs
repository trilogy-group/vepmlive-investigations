using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint.WebPartPages;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml.Serialization;
using System.Collections;
using System.Data;
using System.Xml;
using System.Text.RegularExpressions;
using Microsoft.SharePoint.Utilities;

namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:CustomToolPart runat=server></{0}:CustomToolPart>")]
    public class UserProfileToolPart : ToolPart
    {
        protected override void RenderToolPart(HtmlTextWriter output)
        {
            base.RenderToolPart(output);
            ToolPane tp = this.ParentToolPane;
            DisplayProfilePictures myWP =
                (DisplayProfilePictures)tp.SelectedWebPart;

            //output.Write("<div>");
            output.Write("<div class=\"UserSectionTitle\">");
            output.Write("<table style=\"PADDING-LEFT: 5px\" cellPadding=\"1\">");
            output.Write("<tbody>");
            output.Write("<tr>");

            output.Write("<td>");
            if (myWP.LargeImage)
            {
                output.Write("<input type=\"checkbox\" name=\"cbLargeSize\" checked=\"checked\" value=\"true\" />Large Size");
            }
            else
            {
                output.Write("<input type=\"checkbox\" name=\"cbLargeSize\" value=\"true\" />Large Size");
            }
            output.Write("</td>");
            output.Write("</tr>");
            output.Write("</tbody>");
            output.Write("</table>");
            output.Write("</div>");
        }

        public override void ApplyChanges()
        {
            ToolPane tp = this.ParentToolPane;
            DisplayProfilePictures myWP =
                (DisplayProfilePictures)tp.SelectedWebPart;
         
            bool result = false;
            bool.TryParse(Page.Request["cbLargeSize"], out result);
            myWP.LargeImage = result;
        }
    }
}