using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;

namespace EPMLiveWebParts.MyWorkSummary
{
    [ToolboxItemAttribute(false)]
    public partial class MyWorkSummary : WebPart
    {
        protected string dataXml;

        public MyWorkSummary()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected override void CreateChildControls()
        {
            SPWeb oWeb = SPContext.Current.Web;

            string serviceUrl = ((SPContext.Current.Web.ServerRelativeUrl == "/")
                                     ? ""
                                     : SPContext.Current.Web.ServerRelativeUrl) + "/_vti_bin/Workengine.asmx";

            ScriptManager scriptManager = ScriptManager.GetCurrent(Page);

            if (scriptManager != null)
            {
                scriptManager.Services.Add(new ServiceReference(serviceUrl));
            }
            else
            {
                scriptManager = new ScriptManager();
                scriptManager.Services.Add(new ServiceReference(serviceUrl));

                Page.Form.Controls.Add(scriptManager);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string userId;
                if (SPContext.Current.Web.CurrentUser.ID == 1073741823)
                {
                    userId = "1";
                }
                else
                {
                    userId = Convert.ToString(SPContext.Current.Web.CurrentUser.ID);
                }

                StringBuilder methodParam = new StringBuilder();
                methodParam.Append("<MyWorkSummaryMethodParam>");
                methodParam.Append("<SiteUrl>" + SPContext.Current.Site.Url + "</SiteUrl>");
                methodParam.Append("<SiteID>" + Convert.ToString(SPContext.Current.Site.ID) + "</SiteID>");
                methodParam.Append("<WebID>" + Convert.ToString(SPContext.Current.Web.ID) + "</WebID>");
                //methodParam.Append("<CurrentUser>" + Convert.ToString(SPContext.Current.Web.CurrentUser.Name) + "</CurrentUser>");
                methodParam.Append("<CurrentUserId>" + userId + "</CurrentUserId>");
                methodParam.Append("</MyWorkSummaryMethodParam>");
                dataXml = methodParam.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
