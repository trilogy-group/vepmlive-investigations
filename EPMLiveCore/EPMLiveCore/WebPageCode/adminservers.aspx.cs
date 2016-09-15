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
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Administration;

namespace EPMLiveCore
{
    public partial class adminservers : System.Web.UI.Page
    {
        protected SPGridView GvItems;

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/generalapplicationsettings.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string servers = "";
            foreach (GridViewRow gvRow in GvItems.Rows)
            {
                CheckBox cb = (CheckBox)gvRow.Cells[0].Controls[1];
                if (cb.Checked)
                {
                    Label lbl = (Label)gvRow.Cells[1].Controls[0];
                    servers += "," + lbl.Text.ToLower();
                }
            }
            if (servers.Length > 1)
                servers = servers.Substring(1);

            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SPWeb web = SPContext.Current.Web;
                {
                    web.AllowUnsafeUpdates = true;
                    SPSite site = web.Site;
                    site.AllowUnsafeUpdates = true;
                    SPFarm farm = site.WebApplication.Farm;
                    farm.Properties["EPMLiveServers"] = servers;
                    farm.Update();
                }
            });

            Response.Redirect("/generalapplicationsettings.aspx");
        }

        protected void GvItems_RowDataBound(object sender, GridViewRowEventArgs e)
        {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (CheckBox)e.Row.Cells[0].Controls[1];
                    if (((DataRowView)e.Row.DataItem)["selected"].ToString().ToLower() == "true")
                        cb.Checked = true;
                }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("server");
                dt.Columns.Add("selected", typeof(bool));

                string epmliveservers = "";
                ArrayList arrServers = new ArrayList();
                try
                {
                    epmliveservers = SPFarm.Local.Properties["EPMLiveServers"].ToString();
                    foreach (string epmliveserver in epmliveservers.Split(','))
                    {
                        if (epmliveserver != "")
                            arrServers.Add(epmliveserver);
                    }
                }
                catch { }

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    SPServerCollection servers = SPFarm.Local.Servers;
                    foreach (SPServer server in servers)
                    {
                        if (server.Role == SPServerRole.WebFrontEnd || server.Role == SPServerRole.Application)
                        {
                            if (arrServers.Contains(server.Name.ToLower()))
                                dt.Rows.Add(new object[] { server.Name, true });
                            else
                                dt.Rows.Add(new object[] { server.Name, false });
                        }
                    }
                });

                GvItems.DataSource = dt;
                GvItems.DataBind();
            }
            
        }
    }
}