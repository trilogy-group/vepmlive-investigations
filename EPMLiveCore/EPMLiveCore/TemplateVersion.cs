using System;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

using System.Text;

namespace EPMLiveCore
{
    [Guid("cae3b039-7af2-4aaf-b0c3-496513f821c4")]
    public class TemplateVersion : Microsoft.SharePoint.WebPartPages.WebPart
    {

        public TemplateVersion()
        {
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {

            if (SPContext.Current.Web.Properties.ContainsKey("TemplateVersion"))
            {
                try
                {
                    output.Write("<P align=\"right\" style=\"font-size: 9px\" >v" + SPContext.Current.Web.Properties["TemplateVersion"] + "</P>");
                }
                catch { }
            }
            else
            {
                output.Write("<IMG SRC=\"/_layouts/images/blank.gif\" width=1 height=10 alt=\"\">");
            }
        }
    }
}
