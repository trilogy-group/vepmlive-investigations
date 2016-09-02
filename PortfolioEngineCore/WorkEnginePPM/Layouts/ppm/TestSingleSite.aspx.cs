using System;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class TestSingleSite : LayoutsPageBase
    {
        protected string settingsurl = "";

        protected string strOutput = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //int activation = EPMLiveCore.CoreFunctions.getFeatureLicenseStatus(7);
            //if (activation != 0)
            //{
            //    strOutput = EPMLiveCore.CoreFunctions.translateStatus(activation);
            //    LiteralControl lit = new LiteralControl(strOutput.ToString());
            //    PlaceHolder1.Controls.Add(lit);
            //    return;
            //}

            int i;

            strOutput = HelperFunctions.outputEPKControl("", "", "<Params />", "true", Page, "", true);
            LiteralControl lit = new LiteralControl(strOutput.ToString());
            PlaceHolder1.Controls.Add(lit);
        }
    }
}
