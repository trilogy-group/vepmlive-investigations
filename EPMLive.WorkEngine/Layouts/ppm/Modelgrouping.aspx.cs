using System;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class Modelgrouping : LayoutsPageBase
    {
        protected string strOutput = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            strOutput = HelperFunctions.outputEPKControl("", "WE_Admin.General", "<Params Mode=\"ModelGroups\" Home=\"WE\"/>", "true", Page, "General", false);
            LiteralControl lit = new LiteralControl(strOutput.ToString());
            PlaceHolder1.Controls.Add(lit);
        }
    }
}
