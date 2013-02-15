using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM
{
    public partial class workitems : LayoutsPageBase
    {
        protected string strOutput;
        protected string sProjectName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(Web);

            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.PortfolioEngine);
            if(activation != 0)
            {
                strOutput = act.translateStatus(activation);
                return;
            }

            sProjectName = HelperFunctions.getProjectNameFromUID(Request["itemid"]);

            int i;
            if (int.TryParse(Request["view"], out i))
                strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_LMRWI.LMR_WE_WI", "<Params WEPID=\\\"" + Request["itemid"] + "\\\" ViewID=\\\"" + Request["view"] + "\\\"/>", "true", Page);
            else
                strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_LMRWI.LMR_WE_WI", "<Params WEPID=\\\"" + Request["itemid"] + "\\\" ViewName=\\\"" + Request["view"] + "\\\"/>", "true", Page);

        }
    }
}
