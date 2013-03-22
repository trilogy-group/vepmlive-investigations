using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    public partial class WorkPlanLinkTask : LayoutsPageBase
    {
        private string sListProjectCenter;
        protected string sPlannerLayoutParam;

        protected void Page_Load(object sender, EventArgs e)
        {
            //SPSecurity.RunWithElevatedPrivileges(delegate()
            //{

            //    using(SPSite site = new SPSite(Web.Site.ID))
            //    {
            //        using(SPWeb iweb = site.OpenWeb(Web.ID))
            //        {
            //            Guid lockWeb = EPMLiveCore.CoreFunctions.getLockedWeb(iweb);
            //            if(lockWeb == Guid.Empty || lockWeb == Web.ID)
            //            {
            //                iCheckParams(Web, Web);
            //            }
            //            else
            //            {
            //                using(SPWeb w = site.OpenWeb(lockWeb))
            //                {
            //                    iCheckParams(Web, w);
            //                }

            //            }
            //        }
            //    }
            //});

            sPlannerLayoutParam = "<Params PlannerID='" + Request["PlannerID"] + "'/>";
            sPlannerLayoutParam = System.Web.HttpUtility.HtmlEncode(sPlannerLayoutParam);
        }

        private void iCheckParams(SPWeb web, SPWeb lWeb)
        {
            sListProjectCenter = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "EPMLivePlanner" + Request["PlannerID"] + "ProjectCenter");


        }
    }

    
}
