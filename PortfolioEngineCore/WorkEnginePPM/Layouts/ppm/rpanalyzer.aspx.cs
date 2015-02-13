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
            int irpemode;

            if (int.TryParse(Request["rpemode"], out irpemode) == false)
                irpemode = 0;


            if (string.IsNullOrEmpty((Request["listid"])))
            {

                WorkEnginePPM.ControlTemplates.WorkEnginePPM.ResPlanAnalyzerControl ctl =
                    (WorkEnginePPM.ControlTemplates.WorkEnginePPM.ResPlanAnalyzerControl)
                    LoadControl("/_layouts/ppm/ResPlanAnalyzer.ascx");

                ctl.TicketVal = Request["dataid"];
                ctl.RPEMode = irpemode;
                ctl.MaxPeriodLimit = GetMaxPeriodLimit();
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
                                                                 "\\\" rpemode=\\\"" + irpemode.ToString() + "\\" +
                                                                 "\\\" ViewID=\\\"" + Request["view"] + "\\\"/>",
                                                                 "true",
                                                                 Page);
                    else
                        strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_ResCenter.RPAnalyzer",
                                                                     "<Params Ticket=\\\"" + Request["dataid"] +
                                                                     "\\\" rpemode=\\\"" + irpemode.ToString() + "\\" +
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
                    ctl.RPEMode = irpemode;
                    ctl.MaxPeriodLimit = GetMaxPeriodLimit();
                    PlaceHolder1.Controls.Add(ctl);
                }
            }
        }

        protected Int32 GetMaxPeriodLimit()
        {
            Int32 maxPeriodLimit = 120;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                using (SPSite site = new SPSite(Web.Site.ID))
                {
                    using (SPWeb web = site.RootWeb)
                    {
                        try
                        {
                            if (web.Properties["pfemaxperiodlimit"] != null)
                            {
                                Int32 mpl;
                                if (Int32.TryParse(Convert.ToString(web.Properties["pfemaxperiodlimit"]), out mpl))
                                    maxPeriodLimit = mpl;
                            }
                            else
                            {
                                web.AllowUnsafeUpdates = true;
                                EPMLiveCore.CoreFunctions.setConfigSetting(web, "pfemaxperiodlimit", "120");
                                web.AllowUnsafeUpdates = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            web.AllowUnsafeUpdates = false;
                        }
                    }
                }
            });
            return maxPeriodLimit;
        }
    }
}
