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
    [Guid("e30a3bf4-5b47-47e9-8138-9716be800a86")]

    public class Task_Summary : Microsoft.SharePoint.WebPartPages.WebPart
    {
        public Task_Summary()
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
            string ret = pjData.buildData(true, false, false);

            if (ret != "")
            {
                output.Write("Error: " + ret);
            }
            else
                output.Write(pjData.buildTaskSummary());
        }
    }
}
