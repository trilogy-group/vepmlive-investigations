using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace EPMLiveAccountManagement
{
    public partial class people : LayoutsPageBase
    {
        protected string weburl;
        protected string strWidth;
        protected string strBarColor;
        static CheckBox[] checks;
        bool isAdmin = false;
        protected string account_ref;
        protected string quantity;
        protected string version;
        protected string level;
        protected Guid accountid;

        protected Panel pnlRequests;
        protected Panel pnlAddUser;
        protected GridView GridView1;
        protected Panel pnlBuild;
        protected Label lblTitle;
        protected Panel pnlCounter;
        protected Label lblDesc;
        protected Label lblError;
        protected Label lblMaxUsers;
        protected Label lblUserCount;
        protected Label lblSuccess;
        protected HiddenField hdnAccountId;
        protected HiddenField hdnUserId;
        protected Panel pnlEdit;
        protected Panel pnl;
        protected HiddenField HiddenUsername;
        protected Label lblName;
        protected Label lblEmail;
        protected Panel pnlGroups;

        protected string isdlg;

        protected string hideAdd;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["isDlg"] != null && Request["isDlg"] != "")
                isdlg = "?isDlg=1";

            SPWeb mySite = SPContext.Current.Web;
            weburl = mySite.Url;
            try
            {
                isAdmin = SPContext.Current.Web.CurrentUser.IsSiteAdmin;
            }
            catch (Exception)
            { }

            if (mySite.IsRootWeb && isRequests(mySite) && isAdmin)
                pnlRequests.Visible = true;

            if (!isAdmin)
            {
                pnlAddUser.Visible = false;
                if (mySite.IsRootWeb)
                    GridView1.Columns[4].Visible = false;
            }

            level = Settings.getContractLevel();

            if (!IsPostBack)
            {

                fillData(mySite.Site);

            }

            if (mySite.IsRootWeb)
            {
                pnlBuild.Visible = false;
                lblTitle.Text = "Manage Accounts";


            }
            else
            {
                lblTitle.Text = "Manage Site Members";
                pnlCounter.Visible = false;
                pnlBuild.Visible = true;
                pnlAddUser.Visible = false;
            }

            bool canEdit = false;

            foreach (SPGroup group in mySite.Groups)
            {
                if (group.CanCurrentUserEditMembership)
                {
                    canEdit = true;
                    break;
                }
            }

            if (!canEdit)
            {
                pnlBuild.Visible = false;
                GridView1.Columns[4].Visible = false;
            }
        }

        private void fillData(SPSite site)
        {
            SPWeb web = SPContext.Current.Web;
            bool isRoot = web.IsRootWeb;
            bool bCanUserEditAGroup = false;

            foreach (SPGroup group in web.Groups)
            {
                if (group.CanCurrentUserEditMembership)
                {
                    bCanUserEditAGroup = true;
                }
            }

            if (bCanUserEditAGroup)
            {
                if (isRoot)
                    fillRootData(site);
                else
                    fillSubData(web);
            }
            else
            {
                string url = web.Url + "/_layouts/accessdenied.aspx";
                Response.Redirect(url);
            }
        }

        private void fillSubData(SPWeb web)
        {
            lblDesc.Text = "The Site Members list below displays users that have access to this Workspace.  You can edit their permissions or remove them from this site by using the links below.";

            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Columns.Add("name");
            ds.Tables[0].Columns.Add("email");
            ds.Tables[0].Columns.Add("group");
            ds.Tables[0].Columns.Add("username");
            ds.Tables[0].Columns.Add("uid");

            Hashtable tblUsers = new Hashtable();

            foreach (SPGroup group in web.Groups)
            {
                if (group.CanCurrentUserViewMembership)
                {
                    foreach (SPUser user in group.Users)
                    {
                        if (tblUsers.Contains(user.ID))
                        {
                            string val = tblUsers[user.ID].ToString();
                            tblUsers[user.ID] = val + group.Name + "<br>";
                        }
                        else
                        {
                            tblUsers.Add(user.ID, user.Name + "\n" + user.Email + "\n" + user.LoginName + "\n" + group.Name + "<br>");
                        }
                    }
                }
            }

            /*foreach (SPUser user in web.AllUsers)
            {
                string groups = "";
                foreach (SPGroup group in user.Groups)
                {
                    try
                    {
                        groups = groups + web.Groups[group.Name].Name + "<br>";
                    }
                    catch { }
                }
                if(groups != "")
                    ds.Tables[0].Rows.Add(user.Name, user.Email, groups, user.LoginName, user.LoginName);
            }*/

            foreach (DictionaryEntry entry in tblUsers)
            {
                string[] vals = entry.Value.ToString().Split('\n');
                ds.Tables[0].Rows.Add(vals[0], vals[1], vals[3], vals[2], vals[2]);
            }

            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = "name";

            GridView1.DataSource = dv.Table;
            GridView1.DataBind();

        }

        private bool isRequests(SPWeb mySite)
        {
            DataSet ds = new DataSet();
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                SqlConnection cn = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn = new SqlConnection(Settings.getConnectionString());
                    cn.Open();
                });


                SqlCommand cmdGetSites;
                SqlDataAdapter da;

                cmdGetSites = new SqlCommand("SP_GetRequests", cn);
                cmdGetSites.CommandType = CommandType.StoredProcedure;
                cmdGetSites.Parameters.AddWithValue("@siteguid", mySite.Site.ID);

                da = new SqlDataAdapter(cmdGetSites);
                da.Fill(ds);

                cn.Close();
            });
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
            }
            catch { }
            return false;
        }

        private void fillRootData(SPSite site)
        {


            try
            {
                SqlConnection cn = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn = new SqlConnection(Settings.getConnectionString());
                    cn.Open();
                });

                SqlCommand cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@siteid", site.ID);
                cmd.Parameters.AddWithValue("@contractLevel", Settings.getContractLevel());

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    int billingtype = dr.GetInt32(11);
                    if (billingtype == 2)
                    {
                        pnlCounter.Visible = false;
                        hdnAccountId.Value = dr.GetGuid(2).ToString();
                        hdnUserId.Value = dr.GetGuid(3).ToString();
                        account_ref = dr.GetInt32(10).ToString();
                        accountid = dr.GetGuid(2);
                        lblDesc.Text = "The User Accounts Pool is the central repository of User Accounts.  This User Accounts Pool is associated with Account Owner <b>" + dr.GetString(5) + "</b>.  Only Site Collection Administrators of this Site Collection have permission to add and delete users from this User Accounts Pool.  Additionally, only resources in this User Accounts Pool can be added as Site Members to Workspaces created from this Site Collection.<br /><br /> If you want to grant your resources access to this site, you will need to edit their resource permissions after you add their account on this page.";

                    }
                    else
                    {
                        int max = dr.GetInt32(0);
                        int count = dr.GetInt32(1);
                        int inTrial = dr.GetInt32(4);
                        if (dr.IsDBNull(2))
                        {
                            dr.Close();
                            lblError.Visible = true;
                            lblMaxUsers.Text = "0";
                            lblUserCount.Text = count.ToString();
                            lblError.Text = "This site does not appear to be linked to an account.<br>Please contact <a href=\"mailto:support@epmlive.com\">support@epmlive.com</a> to add this site to an account.";
                            pnlAddUser.Visible = false;
                            hideAdd = "display:none";
                            return;
                        }
                        if (max <= count || max == 0)
                        {
                            lblSuccess.Text = "If you would like to add more user accounts, please click the &quot;Buy More Users&quot; button to the right.";
                            lblSuccess.Visible = true;
                            pnlAddUser.Visible = false;
                            hideAdd = "display:none";
                        }

                        lblDesc.Text = "The User Accounts Pool is the central repository of User Accounts.  This User Accounts Pool is associated with Account Owner <b>" + dr.GetString(5) + "</b>.  Only Site Collection Administrators of this Site Collection have permission to add and delete users from this User Accounts Pool.  Additionally, only resources in this User Accounts Pool can be added as Site Members to Workspaces created from this Site Collection.<br /><br /> If you want to grant your resources access to this site, you will need to edit their resource permissions after you add their account on this page.";

                        lblMaxUsers.Text = max.ToString();
                        lblUserCount.Text = count.ToString();


                        float tblWidth = 0;
                        if(max != 0)
                            tblWidth = (count * 100) / max;

                        if (tblWidth > 100)
                            tblWidth = 100;

                        if ((max - count) <= 1)
                            strBarColor = "FF0000";
                        else if ((max - count) < 5)
                            strBarColor = "FFFF00";
                        else
                            strBarColor = "009900";

                        strWidth = tblWidth.ToString();

                        hdnAccountId.Value = dr.GetGuid(2).ToString();
                        hdnUserId.Value = dr.GetGuid(3).ToString();
                        int trial = dr.GetInt32(4);

                        if (count >= max || max == 0)
                        {
                            pnlAddUser.Visible = false;
                            hideAdd = "display:none";
                        }
                        //else
                        //    if (isAdmin)
                        //        pnlAddUser.Visible = true;

                        int buyUsers = 1;
                        if (inTrial == 1)
                        {
                            buyUsers = count;
                        }
                        else
                        {
                            buyUsers = count - max;
                            if (buyUsers < 0)
                                buyUsers = 0;
                        }
                        quantity = buyUsers.ToString();
                        account_ref = dr.GetInt32(10).ToString();
                        accountid = dr.GetGuid(2);
                    }
                }
                dr.Close();

                cmd = new SqlCommand("SELECT min(version) as version from orders where account_ref=@accountref", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@accountref", account_ref);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                version = ds.Tables[0].Rows[0][0].ToString();

                ds = new DataSet();
                ds.Tables.Add();
                ds.Tables[0].Columns.Add("name");
                ds.Tables[0].Columns.Add("email");
                ds.Tables[0].Columns.Add("group");
                ds.Tables[0].Columns.Add("username");
                ds.Tables[0].Columns.Add("uid");

                cmd = new SqlCommand("SP_GetAccountUsers", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@account_id", accountid);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string username = Settings.getPrefix() + dr.GetString(3);
                    string groups = "";
                    try
                    {
                        SPUser user = site.RootWeb.AllUsers[username];
                        if (user.IsSiteAdmin)
                            groups = "Site Collection Administrator<br>";
                        foreach (SPGroup group in user.Groups)
                        {
                            try
                            {
                                groups = groups + site.RootWeb.Groups[group.Name].Name + "<br>";
                            }
                            catch { }
                        }
                    }
                    catch (Exception ex)
                    {
                        if ("User cannot be found." == ex.Message)
                        {
                            groups = "No Access";
                        }
                    }
                    if (groups.Trim() == "")
                        groups = "No Access";
                    ds.Tables[0].Rows.Add(dr.GetString(0), dr.GetString(1), groups, username, dr.GetGuid(2).ToString());
                }

                dr.Close();

                DataView dv = ds.Tables[0].DefaultView;
                dv.Sort = "name";

                GridView1.DataSource = dv.Table;
                GridView1.DataBind();

                cn.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString() + "<br>" + ex.StackTrace);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SPWeb web = SPContext.Current.Web;

                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton2");
                string cmd = l.CommandArgument;

                l = (LinkButton)e.Row.FindControl("LinkButton1");
                if (l.CommandArgument.ToUpper() == hdnUserId.Value.ToUpper())
                    l.Visible = false;
                if (web.IsRootWeb)
                {
                    l.Attributes.Add("onclick", "javascript:return " +
                    "confirm('Are you sure you want to delete " +
                    DataBinder.Eval(e.Row.DataItem, "name") + " from your account?')");
                }
                else
                {
                    l.Attributes.Add("onclick", "javascript:return " +
                    "confirm('Are you sure you want to delete " +
                    DataBinder.Eval(e.Row.DataItem, "name") + " from your site?')");
                }

                if (!web.IsRootWeb)
                {
                    l.CommandArgument = cmd;
                }
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblError.Visible = false;
            lblSuccess.Visible = false;
            if (e.CommandName == "Del")
            {
                SPWeb web = SPContext.Current.Web;
                if (web.IsRootWeb)
                {
                    string username = "";


                    SqlConnection cn = null;
                    SPSecurity.RunWithElevatedPrivileges(delegate()
                    {
                        cn = new SqlConnection(Settings.getConnectionString());
                        cn.Open();
                    });

                    SqlCommand cmd = new SqlCommand("SELECT username FROM USERS where uid=@user_id", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@user_id", e.CommandArgument.ToString());
                    SqlDataReader dReader = cmd.ExecuteReader();
                    if (dReader.Read())
                        username = dReader.GetString(0);
                    dReader.Close();


                    cmd = new SqlCommand("SP_GetAccountSites", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@account_id", hdnAccountId.Value);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    bool deletedFromSite = true;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (!deleteUsersFromSite(dr["siteguid"].ToString(), username))
                            deletedFromSite = false;
                    }

                    deleteUsersFromSite(web.Site.ID.ToString(), username);

                    if (deletedFromSite)
                    {
                        cmd = new SqlCommand("UPDATE ACCOUNT_USERS set deleted=GETDATE() where user_id=@user_id and account_id=@account_id", cn);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@user_id", e.CommandArgument.ToString());
                        cmd.Parameters.AddWithValue("@account_id", hdnAccountId.Value);
                        cmd.ExecuteNonQuery();

                        lblSuccess.Visible = true;
                        lblSuccess.Text = "User has been successfully deleted";
                    }
                    cn.Close();

                }
                else
                {
                    SPUser user = web.AllUsers[e.CommandArgument.ToString().Replace("\\\\", "\\")];
                    foreach (SPGroup group in web.Groups)
                    {
                        if (group.CanCurrentUserEditMembership)
                        {
                            try
                            {
                                group.RemoveUser(user);
                            }
                            catch (Exception) { }
                        }
                    }
                }
                string url = web.Url;
                if(Request["isDlg"] != null && Request["isDlg"] != "")
                    Response.Redirect(url + "/_layouts/epmlive/people.aspx?isDlg=" + Request["isDlg"]);
                else
                    Response.Redirect(url + "/_layouts/epmlive/people.aspx");
            }
            if (e.CommandName == "Edi")
            {
                SqlConnection cn = null;
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    cn = new SqlConnection(Settings.getConnectionString());
                    cn.Open();
                });

                SPWeb mySite = SPContext.Current.Web;

                pnlEdit.Visible = true;
                pnl.Visible = false;
                string username = e.CommandArgument.ToString().Replace("\\\\", "\\");

                HiddenUsername.Value = username;
                try
                {
                    lblName.Text = mySite.AllUsers[username].Name;
                    lblEmail.Text = mySite.AllUsers[username].Email;
                }
                catch (Exception ex)
                {
                    try
                    {
                        if ("User cannot be found." == ex.Message)
                        {
                            string rawUsername = username;
                            try
                            {
                                rawUsername = rawUsername.Split('|')[1];
                            }
                            catch { }

                            SqlCommand cmd = new SqlCommand("SELECT coalesce(email,' ') as email, firstName + ' ' + lastName as fullname FROM [USERS] where username=@username", cn);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@username", rawUsername);
                            SqlDataReader dReader = cmd.ExecuteReader();

                            if (dReader.Read())
                            {
                                mySite.AllUsers.Add(username, dReader.GetString(0), dReader.GetString(1), "");
                                dReader.Close();
                            }
                            else
                            {
                                dReader.Close();
                                cn.Close();
                                Response.Write("ERROR");
                                return;
                            }
                        }
                    }
                    catch (Exception ex2)
                    {
                        Response.Write(ex2.StackTrace);
                    }
                    lblName.Text = mySite.AllUsers[username].Name;
                    lblEmail.Text = mySite.AllUsers[username].Email;
                }
                cn.Close();

                if (mySite.UserIsSiteAdmin)
                {
                    if (mySite.AllUsers[username].IsSiteAdmin)
                        pnlGroups.Controls.Add(new LiteralControl("<input type=\"checkbox\" name=\"Groups\" checked value=\"@\"> Site Collection Administrator"));
                    else
                        pnlGroups.Controls.Add(new LiteralControl("<input type=\"checkbox\" name=\"Groups\" value=\"@\"> Site Collection Administrator"));
                    pnlGroups.Controls.Add(new LiteralControl("<br>"));
                }


                checks = new CheckBox[mySite.Groups.Count];
                SPUser user = mySite.AllUsers[username];
                foreach (SPGroup g in mySite.Groups)
                {
                    string group = g.Name;
                    bool canEdit = mySite.Groups[group].CanCurrentUserEditMembership;
                    bool found = false;
                    foreach (SPGroup ugroup in user.Groups)
                    {
                        if (ugroup.Name == group)
                            found = true;
                    }
                    if (found)
                        if (canEdit)
                            pnlGroups.Controls.Add(new LiteralControl("<input type=\"checkbox\" name=\"Groups\" checked value=\"" + group + "\">" + group));
                        else
                            pnlGroups.Controls.Add(new LiteralControl("<input type=\"checkbox\" name=\"Groups\" checked value=\"" + group + "\" disabled>" + group));
                    else
                        if (canEdit)
                            pnlGroups.Controls.Add(new LiteralControl("<input type=\"checkbox\" name=\"Groups\" value=\"" + group + "\">" + group));
                        else
                            pnlGroups.Controls.Add(new LiteralControl("<input type=\"checkbox\" name=\"Groups\" value=\"" + group + "\" disabled>" + group));
                    pnlGroups.Controls.Add(new LiteralControl("<br>"));
                }
            }
        }

        private bool deleteUsersFromSite(string guid, string username)
        {
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite spSite = new SPSite(new Guid(guid)))
                    {

                        spSite.AllowUnsafeUpdates = true;

                        SPWeb web = spSite.RootWeb;
                        web.AllowUnsafeUpdates = true;

                        web.SiteUsers.Remove(Settings.getPrefix() + username);

                    }
                });
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message == "You cannot delete the owners of a Web site collection.")
                {
                    lblError.Visible = true;
                    lblError.Text = "You cannot delete that user because they are a Site Collection Administrator for one or more sites.";
                    return false;
                }

                return true;
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            ServicePointManager.ServerCertificateValidationCallback += delegate(object ssender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };

            SPSite site = SPContext.Current.Site;
            SPWeb mySite = SPContext.Current.Web;
            mySite.AllowUnsafeUpdates = true;

            pnlEdit.Visible = false;
            GridView1.Visible = true;
            Hashtable myHash = new Hashtable();
            SPUser user = mySite.AllUsers[HiddenUsername.Value];



            bool hasGroup = false;
            bool addGroup = false;
            foreach (SPGroup group in user.Groups)
            {
                try
                {
                    string g = mySite.Groups[group.Name].Name;
                    hasGroup = true;
                }
                catch { }
            }

            bool setSiteAdmin = false;

            if (Request["Groups"] != null)
            {
                string[] groups = Request["Groups"].Split(',');
                if (groups.Length > 0)
                {
                    foreach (string group in groups)
                    {
                        if (group == "@")
                        {
                            setSiteAdmin = true;
                        }
                        else
                        {
                            try
                            {
                                myHash.Add(group, "");
                                mySite.Groups[group].AddUser(user);
                                addGroup = true;
                            }
                            catch (Exception) { }
                        }
                    }
                }
            }


            checks = new CheckBox[mySite.Groups.Count];
            foreach (SPGroup g in mySite.Groups)
            {
                string group = g.Name;
                if (mySite.Groups[group].CanCurrentUserEditMembership)
                {
                    if (!myHash.Contains(group))
                    {
                        try
                        {
                            mySite.Groups[group].RemoveUser(user);
                        }
                        catch (Exception) { }
                    }
                }
            }
            string url = site.Url;

            if (!hasGroup && addGroup)
            {
                string username = user.LoginName;
                try
                {
                    username = username.Split('|')[1];
                }
                catch { }

                accounts.Service accts = new accounts.Service();
                if (ConfigurationManager.AppSettings["acctsUrl"] != null)
                    accts.Url = ConfigurationManager.AppSettings["acctsUrl"];
                accts.Credentials = new System.Net.NetworkCredential("adaccessuser", "lkf@$farFA", "epm");

                emailservice.Service eService = new emailservice.Service();
                if (ConfigurationManager.AppSettings["emailUrl"] != null)
                    eService.Url = ConfigurationManager.AppSettings["emailUrl"];
                eService.Credentials = new System.Net.NetworkCredential("adaccessuser", "lkf@$farFA", "epm");
                bool ret = eService.sendEmail(2, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", user.Email, new string[] { SPContext.Current.Web.CurrentUser.Name, mySite.Url, mySite.Title, username });
            }

            if (mySite.UserIsSiteAdmin)
            {
                if (setSiteAdmin)
                {
                    user.IsSiteAdmin = true;
                    user.Update();
                }
                else
                {
                    user.IsSiteAdmin = false;
                    user.Update();
                }
            }

            url = mySite.Url;

            if (Request["isDlg"] != null && Request["isDlg"] != "")
                Response.Redirect(url + "/_layouts/epmlive/people.aspx?isDlg=" + Request["isDlg"]);
            else
                Response.Redirect(url + "/_layouts/epmlive/people.aspx");


        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            SPWeb mySite = SPContext.Current.Web;
            string url = mySite.Url;

            if (Request["isDlg"] != null && Request["isDlg"] != "")
                Response.Redirect(url + "/_layouts/epmlive/people.aspx?isDlg=" + Request["isDlg"]);
            else
                Response.Redirect(url + "/_layouts/epmlive/people.aspx");

        }
    }
}