using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using System.Data.SqlClient;
using Microsoft.SharePoint.WebControls;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace EPMLiveAccountManagement
{
    public partial class addmember : LayoutsPageBase
    {

        DataTable dtGroups;

        protected Label hlLink;
        protected GridView gvSelect;
        protected Label lblNoUsers;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                SPWeb web = SPContext.Current.Web;

                bool isAdmin = false;
                try
                {
                    isAdmin = SPContext.Current.Web.CurrentUser.IsSiteAdmin;
                }
                catch { }
                if (isAdmin)
                {
                    //hlLink.Text = "Add Accounts";
                    //hlLink.NavigateUrl = web.Site.Url + "/_layouts/epmlive/adduser.aspx";
                    hlLink.Text = "<a href=\"#\" onClick=\"window.open('" + web.Site.Url + "/_layouts/epmlive/adduser.aspx','adduser','height=500,width=700,toolbar=no,directories=no,status=no,menubar=no,scrollbars=no,resizable=yes');\">Add Account</a>";
                }
                else
                {
                    //hlLink.Text = "Request Accounts";
                    hlLink.Text = "<a href=\"" + web.Url + "/_layouts/epmlive/request.aspx\">Request Accounts</a>";
                    //hlLink.Target = "";
                }


                dtGroups = new DataTable();
                dtGroups.Columns.Add("name");
                dtGroups.Columns.Add("key");
                dtGroups.Rows.Add("No Access", "");
                foreach (SPGroup group in web.Groups)
                {
                    if (group.CanCurrentUserEditMembership)
                    {
                        dtGroups.Rows.Add(group.Name, group.Name);
                    }
                }

                SqlConnection cn = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn = new SqlConnection(Settings.getConnectionString());
                    cn.Open();
                });

                DataTable dtUsers = new DataTable();
                dtUsers.Columns.Add("name");
                dtUsers.Columns.Add("email");
                dtUsers.Columns.Add("username");

                SqlCommand cmd = new SqlCommand("SP_GetSiteAccounts", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@siteId", web.Site.ID);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    bool hasGroup = false;
                    try
                    {
                        SPUser user = web.AllUsers[dr.GetString(3)];
                        foreach (SPGroup group in user.Groups)
                        {
                            try
                            {
                                string g = web.Groups[group.Name].Name;
                                hasGroup = true;
                            }
                            catch { }
                        }
                    }
                    catch { }
                    if (!hasGroup)
                        dtUsers.Rows.Add(dr.GetString(0), dr.GetString(1), dr.GetString(3));
                }

                dr.Close();

                cn.Close();

                DataView dv = dtUsers.DefaultView;
                dv.Sort = "name";

                if (dv.Table.Rows.Count > 0)
                {
                    gvSelect.Columns[4].Visible = true;
                    gvSelect.DataSource = dv.Table;
                    gvSelect.DataBind();
                    gvSelect.Columns[4].Visible = false;
                }
                else
                {
                    lblNoUsers.Visible = true;
                }

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList l = (DropDownList)e.Row.FindControl("ddlGroup");
                l.DataTextField = "name";
                l.DataValueField = "key";
                l.DataSource = dtGroups;
                l.DataBind();

                CheckBox chk = (CheckBox)e.Row.FindControl("chkChange");
                chk.Attributes.Add("onclick", "Javascript:chk('" + chk.ClientID + "','" + e.Row.Cells[2].Text + "');");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;

            ServicePointManager.ServerCertificateValidationCallback += delegate(object sender1, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };

            foreach (GridViewRow gr in gvSelect.Rows)
            {
                CheckBox chk = (CheckBox)gr.Cells[0].Controls[1];
                if (chk.Checked)
                {
                    string username = gr.Cells[4].Text;
                    string groupName = ((DropDownList)gr.Cells[3].Controls[1]).SelectedValue;

                    SPUser user = null;
                    bool good = false;
                    try
                    {
                        user = web.AllUsers[Settings.getPrefix() + username];
                        good = true;
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            if ("User cannot be found." == ex.Message)
                            {
                                web.AllUsers.Add(Settings.getPrefix() + username, gr.Cells[2].Text, gr.Cells[1].Text, "");
                                user = web.AllUsers[Settings.getPrefix() + username];
                                good = true;
                            }
                        }
                        catch { good = false; }
                    }
                    if (good)
                    {
                        bool hasGroup = false;
                        foreach (SPGroup group in user.Groups)
                        {
                            try
                            {
                                string g = web.Groups[group.Name].Name;
                                hasGroup = true;
                            }
                            catch { }
                        }

                        try
                        {
                            web.Groups[groupName].AddUser(user);
                        }
                        catch { }

                        if (!hasGroup)
                        {
                            

                            accounts.Service accts = new accounts.Service();
                            if (ConfigurationManager.AppSettings["acctsUrl"] != null)
                                accts.Url = ConfigurationManager.AppSettings["acctsUrl"];
                            accts.Credentials = new System.Net.NetworkCredential("adaccessuser", "lkf@$farFA", "epm");

                            emailservice.Service eService = new emailservice.Service();
                            if (ConfigurationManager.AppSettings["emailUrl"] != null)
                                eService.Url = ConfigurationManager.AppSettings["emailUrl"];
                            eService.UseDefaultCredentials = true;
                            bool ret = eService.sendEmail(2, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", user.Email, new string[] { accts.getName(), web.Url, web.Title, user.LoginName });

                        }
                    }
                }
            }

            string url = web.Url;
            
            Response.Redirect(url + "/_layouts/epmlive/people.aspx");
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            string url = web.Url;
            
            Response.Redirect(url + "/_layouts/epmlive/people.aspx");
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            string url = web.Url;
            
            Response.Redirect(url + "/_layouts/epmlive/addmember.aspx");
        }
    }

}