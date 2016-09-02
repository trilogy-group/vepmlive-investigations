using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM
{
    public partial class settings : LayoutsPageBase
    {
        protected string strOutput;

        protected void Page_Load(object sender, EventArgs e)
        {
            EPMLiveCore.Act act = new EPMLiveCore.Act(Web);

            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.PortfolioEngine);
            if(activation != 0)
            {
                strOutput = act.translateStatus(activation);
                return;
            }

            string url = ConfigFunctions.getConfigSetting(SPContext.Current.Site.RootWeb, "EPKUrl");

            if (url == "")
            {
                strOutput = "The SharePoint Integration URL is not set";
            }
            else
            {
                strOutput = "<a style=\"margin:5px\" href=\"settings.aspx\">&lt; PortfolioEngine Administration</a><br><iframe id=\"frmPPM\" name=\"frmPPM\" src=\"" + url + "/adminpages.aspx?simpleui=nobranding,nomenu,notitle\" ddf_src=\"" + url + "/adminpages.aspx?simpleui=nobranding,nomenu,notitle\" width=\"100%\" height=\"700\" frameborder=\"0\"></iframe>";
            }
        }
    }
}
