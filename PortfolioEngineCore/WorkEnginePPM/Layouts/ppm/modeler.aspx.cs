using System;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM
{
    public partial class modeler : LayoutsPageBase
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

            string sListId = "";
            if (!string.IsNullOrEmpty(Request["listid"]))
            {
                sListId = Request["listid"];
            }

            if (sListId == "")
            {
                WorkEnginePPM.ControlTemplates.WorkEnginePPM.ModelControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.ModelControl)LoadControl("/_layouts/ppm/Model.ascx");
                PlaceHolder1.Controls.Add(ctl);
            }
            else
            {
                SPList list = Web.Lists[new Guid(sListId)];
                if (HelperFunctions.UseNonActiveXControl("modeler", list) == false)
                {
                    strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_LMRModeler.LMR_WE_Model", "<Params Ticket=\\\"" + Request["dataid"] + "\\\"/>", "true", Page);
                    LiteralControl lit = new LiteralControl(strOutput.ToString());
                    PlaceHolder1.Controls.Add(lit);
                }
                else
                {
                    WorkEnginePPM.ControlTemplates.WorkEnginePPM.ModelControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.ModelControl)LoadControl("/_layouts/ppm/Model.ascx");

                    ctl.TicketVal = Request["dataid"];

                    PlaceHolder1.Controls.Add(ctl);
                }
            }
        }
    }
}
