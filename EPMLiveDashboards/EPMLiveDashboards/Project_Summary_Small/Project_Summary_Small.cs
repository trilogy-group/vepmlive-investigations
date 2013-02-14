using System;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Serialization;

using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.WebPartPages;

namespace Dashboard
{
    [Guid("0214f3b7-8b91-480b-97c8-52c762bb4a3b")]
    public class Project_Summary_Small : Microsoft.SharePoint.WebPartPages.WebPart
    {
        public Project_Summary_Small()
        {
            this.ExportMode = WebPartExportMode.All;
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
            string ret = pjData.buildData2();

            if (ret != "")
            {
                output.Write("Error: " + ret);
            }
            else
                pjData.gvPJSummary2.RenderControl(output);

        }
    }
}
