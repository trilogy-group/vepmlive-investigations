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

                DataTable dt = integration.GetIntegrations(act.IsOnline);

                StringBuilder sb = new StringBuilder();

                foreach(DataRow dr in dt.Rows)
                {
                    sb.Append("<div style=\"\">");

                    string icon = dr["Icon"].ToString();

                    if(icon == "")
                        icon = "/_layouts/epmlive/images/integration/base.png";
                    else
                        icon = "/_layouts/epmlive/images/integration/" + icon;

                    string desc = dr["Description"].ToString();


                    sb.Append("<a href=\"javascript:void(0);\" onclick=\"AddIntegration('");
                    sb.Append(dr["MODULE_ID"].ToString());
                    sb.Append("')\" class=\"btn btn-large\"><TABLE border=0 cellSpacing=0 cellPadding=0 width=\"100%\" height=\"100%\"><tr>");
                    sb.Append("<td style=\"vertical-align:middle; text-align:center\" width=\"80px\" valign=\"center\" align=\"center\">");
                    sb.Append("<img src=\"");
                    sb.Append(((Web.ServerRelativeUrl == "/") ? "" : Web.ServerRelativeUrl));
                    sb.Append(icon);
                    sb.Append("\"></td>");
                    sb.Append("<td class=\"titletd\"><b>");
                    sb.Append(dr["Title"].ToString());
                    sb.Append("</b>");
                    if(desc != "")
                    {
                        sb.Append("<div style=\"padding-top: 5px;padding-bottom:10px;padding-right:5px;work-wrap:break-word;\">");
                        sb.Append(desc);
                        sb.Append("</div>");
                    }
                    sb.Append("</td>");
                    sb.Append("</tr></table></a>");

                    sb.Append("</div>");
                }

                Integrations = sb.ToString();
            });

        }
    }
}
