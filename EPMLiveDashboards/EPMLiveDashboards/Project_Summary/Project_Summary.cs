using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

using System.Data;

namespace Dashboard
{
    [Guid("34048450-1a83-4076-89e7-8731a0d0853c")]
    [XmlRoot(Namespace = "MyWebParts")]
    public class Project_Summary : Microsoft.SharePoint.WebPartPages.WebPart
    {
        public Project_Summary()
        {
            this.ExportMode = WebPartExportMode.All;
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
        }

        protected override void RenderWebPart(HtmlTextWriter output)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(SPContext.Current.Web);
            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.WebParts);

            if(activation != 0)
            {
                output.Write(act.translateStatus(activation));
                return;
            }

            ProjectData pjData = new ProjectData();
            pjData.site = Microsoft.SharePoint.WebControls.SPControl.GetContextWeb(Context);
            string ret = pjData.buildData(true, true, true);

            if (ret != "")
            {
                output.Write("Error: " + ret);
            }
            else
                pjData.gvPJSummary.RenderControl(output);

        }


    }
}
