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
    [Guid("a564a1c7-7005-428f-bcd4-d2a8702afb67")]
    public class Milestone_Summary : Microsoft.SharePoint.WebPartPages.WebPart
    {
        public Milestone_Summary()
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
                output.Write(pjData.buildMSSummary());

        }
    }
}
