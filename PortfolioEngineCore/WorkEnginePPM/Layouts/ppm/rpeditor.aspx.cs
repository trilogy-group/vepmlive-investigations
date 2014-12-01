//using System;
//using Microsoft.SharePoint;
//using Microsoft.SharePoint.WebControls;

//namespace WorkEnginePPM
//{
//    public partial class rpeditor : LayoutsPageBase
//    {
//        protected string strOutput = "";
//        protected string sProjectName = "";
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            int activation = EPMLiveCore.CoreFunctions.getFeatureLicenseStatus(7);
//            if(activation != 0)
//            {
//                strOutput = EPMLiveCore.CoreFunctions.translateStatus(activation);
//                return;
//            }

//            sProjectName = HelperFunctions.getProjectNameFromUID(Request["itemid"]);
//            int i;
//            if (int.TryParse(Request["view"], out i))
//                strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_Central.PICommitmentsEditor", "<Params WEPID=\\\"" + Request["itemid"] + "\\\" ViewID=\\\"" + Request["view"] + "\\\"/>", "true", Page);
//            else
//                strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_Central.PICommitmentsEditor", "<Params WEPID=\\\"" + Request["itemid"] + "\\\" ViewName=\\\"" + Request["view"] + "\\\"/>", "true", Page);

//        }
//    }
//}
using System;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM
{
    public partial class RPEditorASPX : LayoutsPageBase
    {
        protected string strOutput = "";
        protected string RPETitle = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(Web);

            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.PortfolioEngine);
            if (activation != 0)
            {
                RPETitle = "Resource Capacity Planner - Page Activation Issue";
                strOutput = act.translateStatus(activation);
                LiteralControl lit = new LiteralControl(strOutput.ToString());
                PlaceHolder1.Controls.Add(lit);
                return;
            }

            string dataid = Request["dataid"];
            if (string.IsNullOrEmpty(dataid) == false)
            {
                WorkEnginePPM.ControlTemplates.WorkEnginePPM.RPEditorControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.RPEditorControl)LoadControl("/_layouts/ppm/RPEditor.ascx");
                ctl.WEPID = Request["itemid"];
                ctl.TicketVal = Request["dataid"];
                ctl.IsResource = Request["isresource"];
                ctl.IsDlg = Request["IsDlg"];
                ctl.HideCloseBtn = Request["hideCloseBtn"];
                ctl.MaxPeriodLimit = GetMaxPeriodLimit();
                if (string.IsNullOrEmpty(Request["isresource"]) == true || Request["isresource"] == "0")
                    RPETitle = "Resource Planner - Project Mode";
                else
                    RPETitle = "Resource Planner - Department Mode";
                PlaceHolder1.Controls.Add(ctl);
                return;
            }

            string sListId = "";
            if (!string.IsNullOrEmpty(Request["listid"]))
            {
                sListId = Request["listid"];
            }
            else if (!string.IsNullOrEmpty(Request["itemid"]))
            {
                sListId = Request["itemid"].Split('.')[1];
            }
            if (sListId == "")
            {
                WorkEnginePPM.ControlTemplates.WorkEnginePPM.RPEditorControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.RPEditorControl)LoadControl("/_layouts/ppm/RPEditor.ascx");
                ctl.IsResource = "0";
                //ctl.IsDlg = Request["IsDlg"];
                ctl.IsDlg = "0";
                RPETitle = "Resource Planner";
                PlaceHolder1.Controls.Add(ctl);
            }
            else
            {
                SPList list = Web.Lists[new Guid(sListId)];

                if (HelperFunctions.UseNonActiveXControl("resplan", list) == false)
                {
                    RPETitle = "Resource Planner - " + HelperFunctions.getProjectNameFromUID(Request["itemid"]);
                    int i;
                    if (int.TryParse(Request["view"], out i))
                        strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_Central.PICommitmentsEditor",
                                                                        "<Params WEPID=\\\"" + Request["itemid"] +
                                                                        "\\\" ViewID=\\\"" + Request["view"] + "\\\"/>",
                                                                        "true", Page);
                    else
                        strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_Central.PICommitmentsEditor",
                                                                        "<Params WEPID=\\\"" + Request["itemid"] +
                                                                        "\\\" ViewName=\\\"" + Request["view"] + "\\\"/>",
                                                                        "true", Page);
                    LiteralControl lit = new LiteralControl(strOutput.ToString());
                    PlaceHolder1.Controls.Add(lit);
                }
                else
                {
                    WorkEnginePPM.ControlTemplates.WorkEnginePPM.RPEditorControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.RPEditorControl)LoadControl("/_layouts/ppm/RPEditor.ascx");
                    ctl.WEPID = Request["itemid"];
                    ctl.TicketVal = Request["dataid"];
                    ctl.IsResource = Request["isresource"];
                    ctl.IsDlg = Request["IsDlg"];
                    ctl.HideCloseBtn = Request["hideCloseBtn"];
                    ctl.MaxPeriodLimit = GetMaxPeriodLimit();
                    if (string.IsNullOrEmpty(Request["isresource"]) == true || Request["isresource"] == "0")
                        RPETitle = "Resource Planner - Project Mode";
                    else
                        RPETitle = "Resource Planner - Department Mode";
                    PlaceHolder1.Controls.Add(ctl);
                }
            }
        }

        protected Int32 GetMaxPeriodLimit()
        {
            Int32 maxPeriodLimit = 120;
            try
            {
                if (Web.Site.RootWeb.Properties["pfemaxperiodlimit"] != null)
                {
                    Int32 mpl;
                    if (Int32.TryParse(Convert.ToString(Web.Site.RootWeb.Properties["pfemaxperiodlimit"]), out mpl))
                        maxPeriodLimit = mpl;
                }
                else
                {
                    Web.AllowUnsafeUpdates = true;
                    EPMLiveCore.CoreFunctions.setConfigSetting(Web, "pfemaxperiodlimit", "120");
                    Web.AllowUnsafeUpdates = false;
                }
            }
            catch (Exception ex)
            {
                Web.AllowUnsafeUpdates = false;
            }
            return maxPeriodLimit;
        }

    }
}
