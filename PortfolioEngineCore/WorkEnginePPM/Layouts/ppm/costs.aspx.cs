using System;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM
{
    public partial class costs : LayoutsPageBase
    {
        protected string strOutput = "";
        protected string sTitle = "";

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
            if(!string.IsNullOrEmpty(Request["listid"]))
            {
                sListId = Request["listid"];
            }
            else if (!string.IsNullOrEmpty(Request["itemid"]))
            {
                sListId = Request["itemid"].Split('.')[1];
            }

            if (sListId == "")
            {
                sTitle = "Cost Planner";
                WorkEnginePPM.ControlTemplates.WorkEnginePPM.EditCostsControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.EditCostsControl)LoadControl("/_layouts/ppm/EditCosts.ascx");
                ctl.ViewUID = 0;
                ctl.WEPID = "";
                ctl.IsDlg = Request["IsDlg"];
                PlaceHolder1.Controls.Add(ctl);
            }
            else
            {
                sTitle = "Cost Planner - " + HelperFunctions.getProjectNameFromUID(Request["itemid"]);

                SPList list = Web.Lists[new Guid(sListId)];

                int i;

                if (HelperFunctions.UseNonActiveXControl("costs", list) == false)
                {
                    if (int.TryParse(Request["view"], out i))
                    {
                        strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_LMRCost.LMR_WE_Costs", "<Params WEPID=\\\"" + Request["itemid"] + "\\\" ViewID=\\\"" + Request["view"] + "\\\"/>", "true", Page);
                    }
                    else
                    {
                        strOutput = HelperFunctions.outputEPKControl(Request["epkurl"], "WE_LMRCost.LMR_WE_Costs", "<Params WEPID=\\\"" + Request["itemid"] + "\\\" ViewName=\\\"" + Request["view"] + "\\\"/>", "true", Page);
                    }
                    LiteralControl lit = new LiteralControl(strOutput.ToString());
                    PlaceHolder1.Controls.Add(lit);
                }
                else
                {
                    WorkEnginePPM.ControlTemplates.WorkEnginePPM.EditCostsControl ctl = (WorkEnginePPM.ControlTemplates.WorkEnginePPM.EditCostsControl)LoadControl("/_layouts/ppm/EditCosts.ascx");
                    ctl.ViewUID = 0;
                    string sView = Request["view"].ToString();

                    if (sView == "")
                        sView = EPMLiveCore.CoreFunctions.getConfigSetting(Web.Site.RootWeb, "EPK" + list.Title.Replace(" ", "") + "_costview");

                    if (int.TryParse(sView, out i))
                    {
                        ctl.ViewUID = i;
                    }
                    ctl.WEPID = Request["itemid"];
                    ctl.IsDlg = Request["IsDlg"];
                    PlaceHolder1.Controls.Add(ctl);
                }
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
        }
    }
}
