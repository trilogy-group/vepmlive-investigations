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
                PrepareMyWorkSummaryListsString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void PrepareMyWorkSummaryListsString()
        {
            StringBuilder mainDivHtml = new StringBuilder();
            mainDivHtml.Append("<MyWorkItemsbyWorkType>");
            mainDivHtml.Append("<SiteUrl>" + SPContext.Current.Site.Url + "</SiteUrl>");
            mainDivHtml.Append("<SiteID>" + Convert.ToString(SPContext.Current.Site.ID) + "</SiteID>");
            mainDivHtml.Append("<WebID>" + Convert.ToString(SPContext.Current.Web.ID) + "</WebID>");
            mainDivHtml.Append("<CurrentUser>" + Convert.ToString(SPContext.Current.Web.CurrentUser.Name) + "</CurrentUser>");
            mainDivHtml.Append("</MyWorkItemsbyWorkType>");

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyWorkSummaryDataXml", "<script type=\"text/javascript\">var dataXmlMyWorkSummary='" + mainDivHtml.ToString() + "';</script>");

        }
    }
}
