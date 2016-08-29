using System;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM
{
    public partial class optimizercs : LayoutsPageBase
    {
        protected string strOutput;

        protected void Page_Load(object sender, EventArgs e)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(Web);

            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.PortfolioEngine);
            if (activation != 0)
            {
                strOutput = act.translateStatus(activation);
                LiteralControl lit = new LiteralControl(strOutput.ToString());
                PlaceHolder1.Controls.Add(lit);
                return;
            }

            SPList list = Web.Lists[new Guid(Request["listid"])];

            {
                WorkEnginePPM.ControlTemplates.WorkEnginePPM.OptimizerControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.OptimizerControl)LoadControl("/_layouts/ppm/Optimizer.ascx");

                ctl.TicketVal = Request["dataid"];
                ctl.ListIdVal = Request["listid"];
                ctl.ViewIDVal = Request["view"];
 
                PlaceHolder1.Controls.Add(ctl);
            }


        }
    }
}
