using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWebParts
{
    [ToolboxItemAttribute(false)]
    public class BackButton : WebPart
    {
        protected override void Render(HtmlTextWriter writer)
        {
            if(!string.IsNullOrEmpty(Page.Request["Source"]))
                writer.Write(Properties.Resources.txtBackButton.Replace("#Source#", Page.Request["Source"]));
            else if(!string.IsNullOrEmpty(Page.Request["BackTo"]))
                writer.Write(Properties.Resources.txtBackButton.Replace("#Source#", Page.Request["BackTo"]));
        }
    }
}
