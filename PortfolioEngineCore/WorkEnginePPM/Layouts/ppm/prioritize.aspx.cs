using System;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM
{
    public partial class prioritize : LayoutsPageBase
    {
        protected string strOutput = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(Web);

            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.PortfolioEngine);
            if (activation != 0)
            {
                strOutput = act.translateStatus(activation);
                return;
            }

            WorkEnginePPM.ControlTemplates.WorkEnginePPM.ClientPrioritizationControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.ClientPrioritizationControl)LoadControl("/_layouts/ppm/ClientPrioritization.ascx");
            PlaceHolder1.Controls.Add(ctl);
        }
    }
}
