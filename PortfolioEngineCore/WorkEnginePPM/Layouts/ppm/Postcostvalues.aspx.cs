﻿using System;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;

namespace WorkEnginePPM.Layouts.ppm
{
    public partial class Postcostvalues : LayoutsPageBase
    {
        protected string strOutput = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            strOutput = HelperFunctions.outputEPKControl("", "WE_PortAdmin.CostValues", "<Params Home=\"WE\"/>", "true", Page, "CostValues", false);
            LiteralControl lit = new LiteralControl(strOutput.ToString());
            PlaceHolder1.Controls.Add(lit);
        }
    }
}
