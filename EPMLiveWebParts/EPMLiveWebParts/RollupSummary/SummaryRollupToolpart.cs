using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveWebParts.RollupSummary
{
    [ToolboxData("<{0}:CustomToolPart runat=server></{0}:CustomToolPart>")]
    public class SummaryRollupToolpart : ToolPart
    {
        private string inputname;

        public SummaryRollupToolpart()
        {
            //Set defaults
            this.UseDefaultStyles = true;
            this.AllowMinimize = true;
            this.Title = "Rollup Summary Properties";
            this.Init += new EventHandler(CustomToolPart_Init);

        }

        private void CustomToolPart_Init(object sender, System.EventArgs e)
        {
            inputname = this.UniqueID + "message";
        }

        protected override void RenderToolPart(HtmlTextWriter output)
        {
            ToolPane tp = this.ParentToolPane;
            RollupSummary myWP =
                (RollupSummary)tp.SelectedWebPart;

            output.Write("<br>Please enter your XML: <textarea cols=\"30\" rows=\"15\" name=\""
                + inputname + "\">" + myWP.MyXml
                + "</textarea><BR>");

            output.Write("<br><br>Cross Site URL(s): <textarea cols=\"30\" rows=\"15\" name=\"rollupsites\">" + myWP.MyRollupSites
                + "</textarea><BR>");

        }

        public override void ApplyChanges()
        {
            //Get our web part
            ToolPane tp = this.ParentToolPane;
            RollupSummary myWP =
                (RollupSummary)tp.SelectedWebPart;

            //Send back our text to our web part
            myWP.MyXml = Page.Request.Form[inputname];
            myWP.MyRollupSites = Page.Request.Form["rollupsites"];
        }



    }
}
