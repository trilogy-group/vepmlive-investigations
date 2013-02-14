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
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace TimeSheets
{
    public partial class viewts : LayoutsPageBase
    {

        protected Panel pnlActivation;
        protected Panel pnlTs;
        protected Label lblTitle;
        protected Panel pnlActionsToolbar;
        protected string sTimeEditor;
        protected string loadUrl;
        protected string weburl;

        protected void Page_Load(object sender, EventArgs e)
        {

            EPMLiveCore.Act act = new EPMLiveCore.Act(Web);
            int activation = act.CheckFeatureLicense(EPMLiveCore.ActFeature.Timesheets);
            if (activation != 0)
            {
                pnlActivation.Visible = true;
                pnlTs.Visible = false;
            }

            try
            {
                SPWeb web = SPContext.Current.Web;
                {
                    weburl = web.Url;
                    if (!SPContext.Current.Web.UserIsSiteAdmin)
                        Response.Redirect(SPContext.Current.Web.Url + "/_layouts/accessdenied.aspx");

                    SqlConnection cn = null;
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        cn = new SqlConnection(EPMLiveCore.CoreFunctions.getConnectionString(web.Site.WebApplication.Id));
                        cn.Open();
                    });

                    SqlCommand cmd = new SqlCommand("select period_start,period_end from tsperiod where period_id=@period_id and site_id=@site_id", cn);
                    cmd.Parameters.AddWithValue("@period_Id", Request["period_id"]);
                    cmd.Parameters.AddWithValue("@site_id", web.Site.ID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lblTitle.Text = "View Timesheets for Period: " + dr.GetDateTime(0).ToShortDateString() + " - " + dr.GetDateTime(1).ToShortDateString();
                    }
                    dr.Close();

                    sTimeEditor = "";
                    cmd = new SqlCommand("SELECT tstype_id,tstype_name from TSTYPE where site_uid=@site_id", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@site_id", SPContext.Current.Site.ID);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            sTimeEditor += "<tr><td class=\"ms-descriptiontext\">" + dr.GetString(1) + "</td><td align=\"right\"><input class=\"ms-input\" size=\"5\" type=\"text\" id=\"timeeditor-" + dr.GetInt32(0).ToString() + "\" disabled=true></td></tr>";
                        }
                    }
                    else
                    {
                        sTimeEditor += "<tr><td class=\"ms-descriptiontext\">Work</td><td align=\"right\"><input class=\"ms-input\" size=\"5\" type=\"text\" id=\"timeeditor-0\" disabled=true></td></tr>";
                    }
                    dr.Close();

                    if (EPMLiveCore.CoreFunctions.getConfigSetting(web.Site.RootWeb, "EPMLiveTSAllowNotes").ToLower() == "true")
                    {
                        sTimeEditor += "<tr><td class=\"ms-descriptiontext\" colspan=\"2\">&nbsp;</td></tr>";
                        sTimeEditor += "<tr><td class=\"ms-descriptiontext\" colspan=\"2\">Notes</td></tr>";
                        sTimeEditor += "<tr><td  class=\"ms-descriptiontext\" colspan=\"2\"><textarea class=\"ms-input\" id=\"timeeditor-N\" rows=\"5\" cols=\"25\" disabled=true></textarea></td></tr>";
                    }

                    loadUrl = web.Url + "/_layouts/epmlive/getts.aspx?period_id=" + Request["period_id"];

                    cn.Close();

                }

                ToolBarButton tbDelete = (ToolBarButton)Page.LoadControl("~/_controltemplates/ToolBarButton.ascx");
                tbDelete.Text = "Delete Timesheet(s)";
                tbDelete.ImageUrl = "../_layouts/epmlive/images/delete.gif";
                tbDelete.NavigateUrl = "Javascript:deleteTimesheets();";
                tbDelete.ToolTip = "Delete";
                ToolBar toolbar = (ToolBar)Page.LoadControl("~/_controltemplates/ToolBar.ascx");
                toolbar.Buttons.Controls.Add(tbDelete);

                pnlActionsToolbar.Controls.Add(toolbar);
            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
        }
    }
}
