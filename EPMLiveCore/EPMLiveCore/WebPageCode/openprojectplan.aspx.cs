using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;

using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveCore
{
    public class openprojectplan : LayoutsPageBase
    {
        protected string filePath = "";
        protected string webUrl = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                filePath = Request["filePath"].ToString().Replace("\"","");
                webUrl = SPContext.Current.Web.Url;
                RegisterStartupScript();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void RegisterStartupScript()
        {
            ClientScript.RegisterStartupScript(this.GetType(), "script1", "<script language=\"javascript\">_spBodyOnLoadFunctionNames.push('editinpj');</script>");
            //ClientScript.RegisterStartupScript(this.GetType(), "script1", "<div style=\"position:absolute; left:0; top:0; width:180px; height:80px; background: #FFFFFF\" align=\"center\"><img src=\"/_layouts/images/GEARS_AN.gif\"></div><script language=\"javascript\">document.getElementById(\"href1\").click()</script>");
        }

    }
}
