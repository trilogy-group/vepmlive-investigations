using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveWorkPlanner.Layouts.epmlive
{
    public partial class openmpp : LayoutsPageBase
    {
        protected string filePath = "";
        protected string webUrl = "";
        protected string sSource = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrEmpty(Request["Source"]))
                {
                    SPList pList = Web.Lists[new Guid(Request["listid"])];
                    sSource = pList.DefaultView.ServerRelativeUrl;
                }
                else
                {
                    sSource = Request["Source"];
                }

                string sPlannerIDPath = "";
                if(Request["Planner"] != "MPP")
                    sPlannerIDPath = Request["Planner"] + "/";

                SPFile tFile = Web.GetFile("Project Schedules/" + sPlannerIDPath + Request["ProjectName"] + ".mpp");

                filePath = tFile.ServerRelativeUrl;
                webUrl = Web.Url;
                RegisterStartupScript();
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void RegisterStartupScript()
        {
            ClientScript.RegisterStartupScript(this.GetType(), "script1", "<script language=\"javascript\">_spBodyOnLoadFunctionNames.push('editinpj');</script>");
        }
    }
}
