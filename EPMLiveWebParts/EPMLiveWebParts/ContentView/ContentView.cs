using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;
using System.Xml;
using System.Xml.Serialization;
using System.Net;
using System.Runtime.InteropServices;

namespace EPMLiveWebParts
{
    [ToolboxItemAttribute(false)]
    [ToolboxData("<{0}:ContentView runat=server></{0}:ContentView>")]
    [XmlRoot(Namespace = "EPMLiveContentView")]
    [Guid("1ad4766b-c8c2-45a0-9751-3c47aad3565e")]

    public class ContentView : Microsoft.SharePoint.WebPartPages.WebPart
    {

        string strHtmlPath = "";

        [Category("Custom Properties")]
        [DefaultValue("")]
        [WebPartStorage(Storage.Shared)]
        [FriendlyNameAttribute("Reports Path")]
        [Description("Use this option if your reports are not installed in the root directory. Path must start with a '/'")]
        [Browsable(true)]
        [XmlElement(ElementName = "PropHtmlPath")]

        // The accessor for this property.
        public string PropHtmlPath
        {
            get
            {
                if (strHtmlPath == null)
                    return "";
                return strHtmlPath;
            }
            set
            {
                strHtmlPath = value;
            }
        }

        protected override void CreateChildControls()
        {
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (PropHtmlPath != "")
            {
                try
                {
                    using (WebClient webClient = new WebClient())
                    {

                        string content = webClient.DownloadString(PropHtmlPath);

                        //content = content.Replace("src=\"/", "src=\"" + PropHtmlPath + "/");

                        writer.Write(content);

                    }
                }
                catch (Exception ex) {
                    writer.Write("Error: " + ex.Message);
                }
            }
            base.Render(writer);
        }
    }
}
