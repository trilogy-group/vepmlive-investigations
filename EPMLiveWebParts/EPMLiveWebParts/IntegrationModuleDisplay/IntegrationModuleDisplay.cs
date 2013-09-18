using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Xml;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace EPMLiveWebParts
{
    [ToolboxData("<{0}:IntegrationModuleDisplay runat=server></{0}:IntegrationModuleDisplay>")]
    [Guid("F27DF1AA-4D78-43F0-AE48-F61BAF42E155")]
    [XmlRoot(Namespace = "IntegrationModuleDisplay")]
    public class IntegrationModuleDisplay : Microsoft.SharePoint.WebPartPages.WebPart
    {
        protected override void CreateChildControls()
        {



        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            if (SPContext.Current.Item != null)
            {
                int itemid = SPContext.Current.Item.ID;
                string Errors = "";
                EPMLiveCore.API.Integration.IntegrationCore c = new EPMLiveCore.API.Integration.IntegrationCore(SPContext.Current.Site.ID, SPContext.Current.Web.ID);
                List<EPMLiveCore.API.Integration.IntegrationCore.IntegrationControlDef> cs = c.GetLocalControls(SPContext.Current.ListId, SPContext.Current.ListItem, out Errors);

                foreach (EPMLiveCore.API.Integration.IntegrationCore.IntegrationControlDef def in cs)
                {
                    output.WriteLine("<!----------------------Integration: " + def.id + "-------------------------->");
                    output.WriteLine(def.HTML);
                    output.WriteLine("<!----------------------Integration-------------------------->");
                }

                if (Errors != "")
                {
                    output.WriteLine("<br><br>Errors:<br>" + Errors);
                }
            }
            else
                output.WriteLine("This web part must be used on a display form");

        }
    }
}
