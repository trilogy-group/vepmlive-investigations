using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM
{
    public partial class details : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(Web);

            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.PortfolioEngine);
            if(activation != 0)
            {
                //strOutput = EPMLiveCore.CoreFunctions.translateStatus(activation);
                return;
            }
        }
    }
}
