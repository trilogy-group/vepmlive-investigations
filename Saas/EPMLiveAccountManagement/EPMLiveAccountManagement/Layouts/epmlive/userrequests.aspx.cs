using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace EPMLiveAccountManagement
{
    public partial class userrequests : LayoutsPageBase
    {

        protected GridView GridView1;
        protected Panel Panel2;
        protected Panel Panel3;
        protected Label Label1;
        protected Label lblRequest;

        protected void Page_Load(object sender, EventArgs e)
        {
            SPWeb mySite = SPContext.Current.Web;
            bool isAdmin = false;
            try
            {
                isAdmin = SPContext.Current.Web.CurrentUser.IsSiteAdmin;
            }
            catch { }
            if (!isAdmin)
                Response.Redirect(mySite.Url + "/_layouts/accessdenied.aspx");
            if (!IsPostBack)
            {
                fillGrid(mySite);
            }

        }

        private void fillGrid(SPWeb mySite)
        {
            accounts.Service accts = new accounts.Service();
            if (ConfigurationManager.AppSettings["acctsUrl"] != null)
                accts.Url = ConfigurationManager.AppSettings["acctsUrl"];
            accts.Credentials = new System.Net.NetworkCredential("adaccessuser", "lkf@$farFA", "epm");

            DataTable dt = getRequests(mySite);
            dt.Columns.Add("username");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                accounts.LookUpList[] list = accts.findUser(dt.Rows[i]["email"].ToString());
                if (list.Length > 0)
                {
                    dt.Rows[i]["username"] = Settings.getDomain() + "\\" + list[0].uid;
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Columns[4].Visible = false;
            /*GridView1.Columns[7].Visible = false;
            GridView1.Columns[8].Visible = false;
            GridView1.Columns[9].Visible = false;
            GridView1.Columns[10].Visible = false;*/

        }

        private DataTable getRequests(SPWeb mySite)
        {
            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();
            });

            DataSet ds;
            SqlCommand cmdGetSites;
            SqlDataAdapter da;

            cmdGetSites = new SqlCommand("SP_GetRequests", cn);
            cmdGetSites.CommandType = CommandType.StoredProcedure;
            cmdGetSites.Parameters.AddWithValue("@siteguid", mySite.Site.ID);

            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            cn.Close();

            return ds.Tables[0];
        }

        private DataTable getRequestsForUser(string email)
        {
            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();
            });

            DataSet ds;
            SqlCommand cmdGetSites;
            SqlDataAdapter da;

            cmdGetSites = new SqlCommand("SELECT * FROM REQUESTS WHERE email='" + email + "'", cn);
            cmdGetSites.CommandType = CommandType.Text;

            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            cn.Close();

            return ds.Tables[0];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            string url = web.Url;

            Response.Redirect(url + "/_layouts/epmlive/people.aspx?isDlgs=" + Request["isDlg"]);
        }

        private string getEmailFromUser(string username, SPWeb mySite)
        {
            return mySite.AllUsers[username].Email;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            SPSite site = SPContext.Current.Site;

            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();
            });

            string accountid = "";

            SqlCommand cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@siteid", site.ID);
            cmd.Parameters.AddWithValue("@contractLevel", Settings.getContractLevel());
            SqlDataReader drNums = cmd.ExecuteReader();
            int max = 0;
            int count = 0;
            if (drNums.Read())
            {
                max = drNums.GetInt32(0);
                count = drNums.GetInt32(1);
                accountid = drNums.GetGuid(2).ToString();
            }
            drNums.Close();


            SPWeb mySite = SPContext.Current.Web;
            string results = "";
            mySite.AllowUnsafeUpdates = true;

            Hashtable acceptedHash = new Hashtable();
            Hashtable rejectedHash = new Hashtable();

            Hashtable emailProcessed = new Hashtable();

            foreach (GridViewRow gr in GridView1.Rows)
            {
                DropDownList dl = (DropDownList)gr.Cells[0].Controls[1];
                string email = gr.Cells[3].Text;
                string username = gr.Cells[4].Text;
                string first = gr.Cells[1].Text;
                string last = gr.Cells[2].Text;
                string name = gr.Cells[1].Text + " " + gr.Cells[2].Text;

                if (dl.Text == "Accept")
                {
                    if (count < max)
                    {
                        SPUser user = null;
                        //try
                        {
                            user = mySite.AllUsers[username];
                        }
                        /*catch(Exception ex)
                        {
                            if (ex.Message == "User cannot be found.")
                            {
                                mySite.AllUsers.Add(username, email, first + " " + last, "");
                                user = mySite.AllUsers[username];
                            }
                            else
                            {
                                Response.Write(ex.Message);
                                return;
                            }
                        }*/
                        DataTable dt = getRequestsForUser(email);

                        cmd = new SqlCommand("SP_AddAccountUserByUsername", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@first", first);
                        cmd.Parameters.AddWithValue("@last", last);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@account_id", accountid);
                        cmd.ExecuteNonQuery();

                        foreach (DataRow dr in dt.Rows)
                        {
                            try
                            {
                                SPGroup sitegroup = mySite.SiteGroups[dr["siteGroup"].ToString()];
                                sitegroup.AddUser(user);
                                sendJoinEmail(email, mySite, dr["webGUID"].ToString(), dr["siteGroup"].ToString(), username);
                                if (dr["newuser"].ToString().ToLower() == "true")
                                {
                                    setProperOwner(username);
                                    sendAccountEmail(username, email, name);
                                }

                                string emailTo = getEmailFromUser(dr["requestor"].ToString(), mySite);

                                if (emailProcessed.Contains(emailTo))
                                {
                                    string oldData = emailProcessed[emailTo].ToString();
                                    emailProcessed[emailTo] = oldData + "<tr><td style=\"font-family:Tahoma,sans-serif;font-size:10pt;color: #2989C0;text-decoration:none;\">" + name + "</td><td style=\"font-family:Tahoma,sans-serif;font-size:10pt;color: #2989C0;text-decoration:none;\">" + mySite.Title + "</td><td style=\"font-family:Tahoma,sans-serif;font-size:10pt;color: #2989C0;text-decoration:none;\">Accepted</td></tr>";
                                }
                                else
                                {
                                    emailProcessed.Add(emailTo, "<tr><td style=\"font-family:Tahoma,sans-serif;font-size:10pt;color: #2989C0;text-decoration:none;\">" + name + "</td><td style=\"font-family:Tahoma,sans-serif;font-size:10pt;color: #2989C0;text-decoration:none;\">" + mySite.Title + "</td><td style=\"font-family:Tahoma,sans-serif;font-size:10pt;color: #2989C0;text-decoration:none;\">Accepted</td></tr>");
                                }
                                if (!acceptedHash.Contains(name))
                                    acceptedHash.Add(name, " ");
                            }
                            catch (Exception ex)
                            {
                                results = results + "<font color=red>Failed to accept user: " + name + " because: " + ex.Message + "</font><br>";
                            }
                        }

                        deleteRequests(email);
                        count++;
                    }
                    else
                    {
                        results = results + "<font color=red>Failed to accept user: " + name + " because you have no more accounts available.</font><br>";
                    }
                }
                else if (dl.Text == "Reject")
                {
                    DataTable dt = getRequestsForUser(email);
                    foreach (DataRow dr in dt.Rows)
                    {
                        string emailTo = getEmailFromUser(dr["requestor"].ToString(), mySite);

                        if (emailProcessed.Contains(emailTo))
                        {
                            string oldData = emailProcessed[emailTo].ToString();
                            emailProcessed[emailTo] = oldData + "<tr><td>" + name + "</td><td>" + mySite.Title + "</td><td>Rejected</td></tr>";
                        }
                        else
                        {
                            emailProcessed.Add(emailTo, "<tr><td style=\"font-family:Tahoma,sans-serif;font-size:10pt;color: #2989C0;text-decoration:none;\">" + name + "</td><td style=\"font-family:Tahoma,sans-serif;font-size:10pt;color: #2989C0;text-decoration:none;\">" + mySite.Title + "</td><td style=\"font-family:Tahoma,sans-serif;font-size:10pt;color: #2989C0;text-decoration:none;\">Rejected</td></tr>");
                        }
                    }
                    try
                    {
                        mySite.SiteUsers.Remove(username);
                    }
                    catch (Exception) { }
                    deleteRequests(email);
                    if (!rejectedHash.Contains(name))
                    {
                        rejectedHash.Add(name, " ");
                    }
                }
            }

            Panel2.Visible = false;
            Panel3.Visible = true;

            foreach (DictionaryEntry entry in acceptedHash)
            {
                results = results + "<font color=green>Successfully accepted user: " + entry.Key + "</font><br>";
            }
            foreach (DictionaryEntry entry in rejectedHash)
            {
                results = results + "<font color=green>Successfully rejected user: " + entry.Key + "</font><br>";
            }

            foreach (DictionaryEntry entry in emailProcessed)
            {
                sendProcessedEmail(entry.Key.ToString(), entry.Value.ToString());
            }


            Label1.Text = results;
            lblRequest.Text = "Results:";

            cn.Close();
        }

        private void setProperOwner(string username)
        {
            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();
            });

            SqlCommand cmdSetProperOwner;
            string createdby = SPContext.Current.Web.CurrentUser.LoginName;
            cmdSetProperOwner = new SqlCommand("UPDATE users set createdby = '" + createdby + "' where username like '" + username + "'", cn);
            cmdSetProperOwner.CommandType = CommandType.Text;
            cmdSetProperOwner.ExecuteNonQuery();

            cn.Close();
        }

        private void sendJoinEmail(string email, SPWeb web, string webguid, string role, string username)
        {
            SPWeb subweb = web.Webs[new Guid(webguid)];

            accounts.Service accts = new accounts.Service();
            if (ConfigurationManager.AppSettings["acctsUrl"] != null)
                accts.Url = ConfigurationManager.AppSettings["acctsUrl"];
            accts.Credentials = new System.Net.NetworkCredential("adaccessuser", "lkf@$farFA", "epm");

            emailservice.Service eService = new emailservice.Service();
            if (ConfigurationManager.AppSettings["emailUrl"] != null)
                eService.Url = ConfigurationManager.AppSettings["emailUrl"];
            eService.UseDefaultCredentials = true;
            bool ret = eService.sendEmail(2, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", email, new string[] { accts.getName(), subweb.Url, subweb.Title, username });

        }

        private void sendProcessedEmail(string email, string users)
        {

            accounts.Service accts = new accounts.Service();
            if (ConfigurationManager.AppSettings["acctsUrl"] != null)
                accts.Url = ConfigurationManager.AppSettings["acctsUrl"];
            accts.Credentials = new System.Net.NetworkCredential("adaccessuser", "lkf@$farFA", "epm");

            emailservice.Service eService = new emailservice.Service();
            if (ConfigurationManager.AppSettings["emailUrl"] != null)
                eService.Url = ConfigurationManager.AppSettings["emailUrl"];
            eService.Credentials = new System.Net.NetworkCredential("adaccessuser", "lkf@$farFA", "epm");

            bool ret = eService.sendEmail(7, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", email, new string[] { users });
        }

        private void sendAccountEmail(string username, string email, string fullname)
        {

            emailservice.Service eService = new emailservice.Service();
            if (ConfigurationManager.AppSettings["emailUrl"] != null)
                eService.Url = ConfigurationManager.AppSettings["emailUrl"];
            eService.UseDefaultCredentials = true;

            bool ret = eService.sendEmail(4, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", email, new string[] { username, getTempPassword(username) });

        }
        private void deleteRequests(string email)
        {
            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();
            });

            DataSet ds;
            SqlCommand cmdDelete;
            SqlDataAdapter da;

            cmdDelete = new SqlCommand("SP_DeleteRequests", cn);
            cmdDelete.CommandType = CommandType.StoredProcedure;
            cmdDelete.Parameters.AddWithValue("@email", email);

            cmdDelete.ExecuteNonQuery();

            cn.Close();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            SPWeb web = SPContext.Current.Web;
            string url = web.Url;

            Response.Redirect(url + "/_layouts/epmlive/people.aspx");
        }
        private string getTempPassword(string username)
        {
            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();
            });

            DataSet ds;
            SqlCommand cmdGetPassword;
            SqlDataAdapter da;

            cmdGetPassword = new SqlCommand("SP_GetPassword", cn);
            cmdGetPassword.CommandType = CommandType.StoredProcedure;
            cmdGetPassword.Parameters.AddWithValue("@username", username);

            da = new SqlDataAdapter(cmdGetPassword);
            ds = new DataSet();
            da.Fill(ds);

            cn.Close();
            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0][0].ToString();
            else
                return "";
        }
    }
}