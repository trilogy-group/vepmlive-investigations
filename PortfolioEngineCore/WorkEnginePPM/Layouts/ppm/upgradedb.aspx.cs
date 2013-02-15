using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class upgradedb : LayoutsPageBase
    {
        protected string sBasePath = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if(SPContext.Current.Web.CurrentUser.IsSiteAdmin)
            {

                sBasePath = EPMLiveCore.CoreFunctions.getConfigSetting(Site.RootWeb, "epkbasepath");

                if(sBasePath == "")
                {
                    lblNoBase.Visible = true;
                    pnlMain.Visible = false;
                }
            }
            else
            {
                pnlMain.Visible = false;
            }
        }
        
        protected void btnUpgrade_Click(object sender, EventArgs e)
        {

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                sBasePath = EPMLiveCore.CoreFunctions.getConfigSetting(Site.RootWeb, "epkbasepath");

                PortfolioEngineCore.Setup.SetupSite setup = new PortfolioEngineCore.Setup.SetupSite();
                setup.UpgradeDB(sBasePath);

                if(setup.SetupErrors)
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = setup.SetupMessage;
                }
                else
                {
                    lblResult.Text = setup.SetupMessage;
                }

                pnlMain.Visible = false;
            });
        }
    }
}
