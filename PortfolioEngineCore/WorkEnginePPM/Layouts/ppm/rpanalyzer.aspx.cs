//using System;
//using Microsoft.SharePoint;
//using Microsoft.SharePoint.WebControls;

//namespace WorkEnginePPM
//{
//    public partial class rpanalyzer : LayoutsPageBase
//    {
//        protected string strOutput;

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            int activation = EPMLiveCore.CoreFunctions.getFeatureLicenseStatus(7);
//            if(activation != 0)
//            {
//                strOutput = EPMLiveCore.CoreFunctions.translateStatus(activation);
//                return;
//            }

//            int i;
//            if (int.TryParse(Request["view"], out i))
//                strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_ResCenter.RPAnalyzer", "<Params Ticket=\\\"" + Request["dataid"] + "\\\" ViewID=\\\"" + Request["view"] + "\\\"/>", "true", Page);
//            else
//                strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_ResCenter.RPAnalyzer", "<Params Ticket=\\\"" + Request["dataid"] + "\\\" ViewName=\\\"" + Request["view"] + "\\\"/>", "true", Page);

//        }
//    }
//}
using System;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM
{
    public partial class rpanalyzer : LayoutsPageBase
    {
        protected string strOutput = "";
        protected string sProjectName = "";

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

            sProjectName = HelperFunctions.getProjectNameFromUID(Request["itemid"]);
            int i;

            if (string.IsNullOrEmpty((Request["listid"])))
            {

                WorkEnginePPM.ControlTemplates.WorkEnginePPM.ResPlanAnalyzerControl ctl =
                    (WorkEnginePPM.ControlTemplates.WorkEnginePPM.ResPlanAnalyzerControl)
                    LoadControl("/_layouts/ppm/ResPlanAnalyzer.ascx");

                ctl.TicketVal = Request["dataid"];

                PlaceHolder1.Controls.Add(ctl);
            }
            else
            {
                

                SPList list = Web.Lists[new Guid(Request["listid"])];

                if (HelperFunctions.UseNonActiveXControl("resanalyzer", list) == false)
                {
                    if (int.TryParse(Request["view"], out i))
                        strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_ResCenter.RPAnalyzer",
                                                                     "<Params Ticket=\\\"" + Request["dataid"] +
                                                                     "\\\" ViewID=\\\"" + Request["view"] + "\\\"/>",
                                                                     "true",
                                                                     Page);
                    else
                        strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_ResCenter.RPAnalyzer",
                                                                     "<Params Ticket=\\\"" + Request["dataid"] +
                                                                     "\\\" ViewName=\\\"" + Request["view"] + "\\\"/>",
                                                                     "true", Page);
                    LiteralControl lit = new LiteralControl(strOutput.ToString());
                    PlaceHolder1.Controls.Add(lit);
                }
                else
                {
                    WorkEnginePPM.ControlTemplates.WorkEnginePPM.ResPlanAnalyzerControl ctl =
                        (WorkEnginePPM.ControlTemplates.WorkEnginePPM.ResPlanAnalyzerControl)
                        LoadControl("/_layouts/ppm/ResPlanAnalyzer.ascx");

                    ctl.TicketVal = Request["dataid"];

                    PlaceHolder1.Controls.Add(ctl);
                }
            }
        }
    }
}
