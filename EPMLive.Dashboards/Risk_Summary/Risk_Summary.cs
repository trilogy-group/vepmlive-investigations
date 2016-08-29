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
    [Guid("b5021273-b782-4895-a17e-fd6814c3cebf")]
    public class Risk_Summary : Microsoft.SharePoint.WebPartPages.WebPart
    {
        public Risk_Summary()
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
            pjData.buildData(false, true, false);

            output.Write(pjData.buildRiskSummary());
        }
    }
}
