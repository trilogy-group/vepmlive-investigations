using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebPartPages;

namespace EPMLiveCore
{
    public partial class manageschedule : System.Web.UI.Page
    {
        protected string taskcenterid;
        protected string strTabs;
        protected string listId;
        protected string projectId;
        protected string taskCenterHtml;
        protected string projectCenterHtml;
        protected Label lblProjectName;
        protected Label lblError;
        protected string strContent;
        protected Panel pnlContent;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request["ID"] != null)
                    projectId = Request["ID"].ToString();

                if (!IsPostBack)
                {

                    SPWeb web = SPContext.Current.Web;
                    web.AllowUnsafeUpdates = true;
                    SPList lstProjectCenter = web.Lists[CoreFunctions.getConfigSetting(web, "EPMLiveProjectCenter")];

                    SPListItem listItem = lstProjectCenter.GetItemById(int.Parse(projectId));

                    lblProjectName.Text = listItem.Title;

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message.Trim();
                Response.Write(message);
            }
        }

        private string getFieldVal(SPListItem li, string field)
        {
            try
            {
                return li[field].ToString();
            }
            catch { }
            return "";
        }
    }
}
