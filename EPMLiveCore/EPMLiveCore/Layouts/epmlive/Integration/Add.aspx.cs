using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Data;
using System.Text;

namespace EPMLiveCore.Layouts.epmlive.Integration
{
    public partial class Add : LayoutsPageBase
    {
        protected string Integrations = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {

                Act act = new Act(Web);

                API.Integration.IntegrationCore integration = new API.Integration.IntegrationCore(Web.Site.ID, Web.ID);

                DataSet dsIntegrations = integration.GetIntegrations(act.IsOnline);

                StringBuilder sb = new StringBuilder();

                DataTable dtCat = dsIntegrations.Tables[0];

                foreach (DataRow drCat in dtCat.Rows)
                {
                    sb.Append("<div class=\"header-wrapper\">");
                    sb.Append("<h4>" + drCat["CATEGORY"].ToString() + "</h4>");
                    sb.Append("</div>"); 
                    sb.Append("<div style=\"width:100%;overflow: hidden;padding-bottom:30px;\">");
                    

                    DataTable dtMods = dsIntegrations.Tables[drCat["INT_CAT_ID"].ToString()];

                    if (dtMods.Rows.Count == 0)
                    {
                        sb.Append("<div style=\"text-align:left;\">No integration modules available</div>");
                    }
                    
                    foreach(DataRow dr in dtMods.Rows)
                    {
                        sb.Append("<div style=\"width:270px;float:left;padding-right:20px\">");

                        string icon = dr["Icon"].ToString();

                        if (icon == "")
                            icon = "/_layouts/epmlive/images/integration/base.png";
                        else
                            icon = "/_layouts/epmlive/images/integration/" + icon;

                        string desc = dr["Description"].ToString();


                        sb.Append("<TABLE border=0 cellSpacing=0 cellPadding=0 width=\"100%\" height=\"100%\"><tr>");
                        sb.Append("<td class=\"add-app-logo-box\">");
                        sb.Append("<img src=\"");
                        sb.Append(((Web.ServerRelativeUrl == "/") ? "" : Web.ServerRelativeUrl));
                        sb.Append(icon);
                        sb.Append("\"></td></tr><tr>");
                        sb.Append("<td class=\"titletd\"><b>");
                        sb.Append(dr["Title"].ToString());
                        sb.Append("</b>");
                        if (desc != "")
                        {
                            sb.Append("<div style=\"padding-top: 5px;padding-bottom:10px;padding-right:5px;work-wrap:break-word;\">");
                            sb.Append(desc);
                            sb.Append("</div>");
                        }
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        sb.Append("<tr><td style=\"text-align:center;\">");
                        sb.Append("<a href=\"javascript:void(0);\" onclick=\"AddIntegration('");
                        sb.Append(dr["MODULE_ID"].ToString());
                        sb.Append("')\" class=\"btn btn-large btn-success\" style=\"text-decoration:none;\">Configure</a>");    
                        sb.Append("</td></tr>");    
                            
                        sb.Append("</table>");

                        sb.Append("</div>");
                    }

                    sb.Append("</div>");
                }

                Integrations = sb.ToString();
            });

        }
    }
}
