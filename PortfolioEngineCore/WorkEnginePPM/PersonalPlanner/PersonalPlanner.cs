using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM
{
    [ToolboxItemAttribute(false)]
    public class PersonalPlanner : WebPart
    {
        protected override void CreateChildControls()
        {
        }

        protected override void Render(HtmlTextWriter writer)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(SPContext.Current.Web);

            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.PortfolioEngine);
            if(activation != 0)
            {
                writer.Write(act.translateStatus(activation));
                return;
            }

            SPSite site = SPContext.Current.Site;
            string EPKURL = ConfigFunctions.getConfigSetting(site.RootWeb, "EPKURL");

            writer.WriteLine(HelperFunctions.outputEPKControl(EPKURL, "WE_Central.Nonwork", "", "true", Page));
        }
    }
}
