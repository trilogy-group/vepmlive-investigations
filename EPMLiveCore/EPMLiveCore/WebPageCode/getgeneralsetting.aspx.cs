using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Xml;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;

namespace EPMLiveCore
{
    public partial class getgeneralsetting : System.Web.UI.Page
    {
        protected string data;

        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            Response.ContentType = "text";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            SPWeb web = SPContext.Current.Web;

            SPList list = web.Lists[new Guid(Request["listid"])];

            data = "false";

            string websetting = Request["websetting"];
            string setting = Request["setting"];
            string settingid = Request["settingid"];

            if (websetting != null && websetting != "")
            {
                Guid gWeb = CoreFunctions.getLockedWeb(web);
 
                if (websetting == "ReportingServicesURL")
                {
                    if (gWeb != web.ID)
                    {
                        using (SPWeb lWeb = web.Site.OpenWeb(gWeb))
                        {
                            data = EPMLiveCore.CoreFunctions.getConfigSetting(lWeb, "ResToolsReportURL");
                        }
                    }
                    else
                        data = EPMLiveCore.CoreFunctions.getConfigSetting(web, "ResToolsReportURL");


                    if (data == "")
                    {
                        bool integrated = false;
                        try
                        {
                            integrated = bool.Parse(EPMLiveCore.CoreFunctions.getWebAppSetting(web.Site.WebApplication.Id, "ReportsUseIntegrated"));
                        }
                        catch { }

                        if (integrated)
                            data = EPMLiveCore.CoreFunctions.getWebAppSetting(web.Site.WebApplication.Id, "ReportingServicesURL") + "?" + HttpUtility.UrlEncode(web.Site.Url) + "%2fReport+Library%2fepmlivetl%2fResource%2fResource+Work+vs.+Capacity.rdl";
                        else
                            data = EPMLiveCore.CoreFunctions.getWebAppSetting(web.Site.WebApplication.Id, "ReportingServicesURL") + "?%2fepmlivetl%2fResource%2fResource+Work+vs.+Capacity";
                    }
                }
                else
                {
                    data = EPMLiveCore.CoreFunctions.getConfigSetting(web, websetting);
                }
            }
            else if (setting != null && setting != "")
            {

                GridGanttSettings gSettings = new GridGanttSettings(list);
                switch(setting)
                {
                    case "GeneralSettings":
                        data = gSettings.AllGeneral;
                        break;
                    case "DisplaySettings":
                        data = gSettings.DisplaySettings;
                        break;
                    case "EnableResourcePlan":
                        data = gSettings.EnableResourcePlan.ToString();
                        break;
                    case "TotalSettings":
                        data = gSettings.TotalSettings;
                        break;
                }

            }

            //web.Close();

            

        }
            
    }
}