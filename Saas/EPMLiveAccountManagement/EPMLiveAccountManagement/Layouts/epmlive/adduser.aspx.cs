using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Text.RegularExpressions;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace EPMLiveAccountManagement
{
    public partial class adduser : LayoutsPageBase
    {
        protected static string strWidth;
        protected static string strBarColor;
        protected int count;
        protected int max;
        protected string account_ref;
        protected string quantity;
        protected string version;
        protected string level;

        protected Button btnNext;
        protected Label lblMaxUsers;
        protected Label lblUserCount;
        protected Label lblEmailsNotification;
        protected Label lblEmailInvalid;
        protected HiddenField hdnStep;
        protected Label lblDesc;
        protected TextBox txtEmails;
        protected GridView GridView1;
        protected Button btnBack;
        protected Label lblEmailsError;
        protected Label lblGridError;
        protected Panel pnlResults;
        protected Button btnCancel;
        protected Label lblResults;

        protected string hideCount = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            level = Settings.getContractLevel();

            btnNext.Attributes.Add("onclick", "javascript:" +
                      btnNext.ClientID + ".disabled=true;" +
                      this.GetPostBackEventReference(btnNext));

            SPWeb mySite = SPContext.Current.Web;
            bool isAdmin = false;
            try
            {
                isAdmin = SPContext.Current.Web.CurrentUser.IsSiteAdmin;
            }
            catch (Exception)
            { }
            string url = mySite.Url;
            
            if (!isAdmin)
                Response.Redirect(url + "/_layouts/accessdenied.aspx");

            SPSite site = SPContext.Current.Site;
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
            int trial = 0;
            if (dr.Read())
            {
                if (dr.GetInt32(11) == 2)
                {
                    account_ref = dr.GetInt32(10).ToString();
                    count = 0;
                    max = 1000000;
                    hideCount = "none";
                }
                else
                {
                    max = dr.GetInt32(0);
                    count = dr.GetInt32(1);
                    int inTrial = dr.GetInt32(4);

                    lblMaxUsers.Text = max.ToString();
                    lblUserCount.Text = count.ToString();
                    trial = dr.GetInt32(4);
                    float tblWidth = (count * 100) / max;

                    if ((max - count) <= 1)
                        strBarColor = "FF0000";
                    else if ((max - count) < 5)
                        strBarColor = "FFFF00";
                    else
                        strBarColor = "009900";

                    strWidth = tblWidth.ToString();


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

                    lblEmailsNotification.Text = "You have " + (max - count).ToString() + " accounts available. If you need more accounts click the &quot;Buy More Users&quot; button above.";
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

            cn.Close();
            url = site.Url;

            if (count >= max)
            {
                Response.Redirect(url + "/_layouts/epmlive/people.aspx");
            }
        }
        //protected void btnCancel_Click(object sender, EventArgs e)
        //{
        //    SPWeb web = SPContext.Current.Web;
        //    string url = web.Url;
        //    web.Close();
        //    Response.Redirect(url + "/_layouts/epmlive/people.aspx");
        //}
        protected void btnNext_Click(object sender, EventArgs e)
        {
            lblEmailInvalid.Visible = false;
            switch (hdnStep.Value)
            {
                case "1":
                    int sVal = doSearch();
                    if (sVal == 0)
                    {
                        lblDesc.Text = "Enter the information below for each user and then click the Finish button.<br><br>";

                        txtEmails.Visible = false;
                        GridView1.Visible = true;

                        btnBack.Visible = true;
                        hdnStep.Value = "2";
                        btnNext.Text = "Finish";

                        lblEmailsNotification.Visible = false;
                        lblEmailsError.Visible = false;
                    }
                    else if (sVal == 1)
                    {
                        lblEmailsError.Visible = true;
                    }
                    else
                    {
                        lblEmailInvalid.Visible = true;
                    }
                    break;

                case "2":
                    lblGridError.Visible = false;
                    if (processUsers())
                    {
                        lblDesc.Text = "The following are the results: ";
                        btnBack.Visible = false;
                        hdnStep.Value = "3";
                        btnNext.Text = "Done";
                        btnCancel.Visible = false;
                        GridView1.Visible = false;
                        pnlResults.Visible = true;
                    }
                    else
                    {
                        lblGridError.Visible = true;
                    }
                    break;
                case "3":
                    SPWeb web = SPContext.Current.Web;
                    string url = web.Url;
                    //Response.Redirect(url + "/_layouts/epmlive/people.aspx");
                    this.RegisterStartupScript("closeindow", "<script language=\"javascript\">opener.location.reload(true);window.close();</script>");
                    break;
            }
        }

        private bool processUsers()
        {


            bool allGood = true;
            foreach (GridViewRow row in GridView1.Rows)
            {
                TextBox tx1 = (TextBox)row.Cells[0].Controls[1];
                if (!tx1.ReadOnly)
                {
                    if (tx1.Text == "")
                        allGood = false;
                    tx1 = (TextBox)row.Cells[1].Controls[1];
                    if (tx1.Text == "")
                        allGood = false;
                }
            }
            if (!allGood)
            {
                return false;
            }
            
            ServicePointManager.ServerCertificateValidationCallback += delegate(object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; };

            accounts.Service accts = new accounts.Service();
            if (ConfigurationManager.AppSettings["acctsUrl"] != null)
                accts.Url = ConfigurationManager.AppSettings["acctsUrl"];

            accts.Credentials = new System.Net.NetworkCredential("adaccessuser", "lkf@$farFA", "epm");

            SPWeb web = SPContext.Current.Web;

            string results = "";
            string accountid = "";
            SqlConnection cn = null;
            SPSecurity.RunWithElevatedPrivileges(delegate()
            {
                cn = new SqlConnection(Settings.getConnectionString());
                cn.Open();
            });

            SqlCommand cmd = new SqlCommand("2010SP_GetSiteAccountNums", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@siteid", web.Site.ID);
            cmd.Parameters.AddWithValue("@contractLevel", Settings.getContractLevel());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                accountid = dr.GetGuid(2).ToString();
            }
            dr.Close();

            foreach (GridViewRow row in GridView1.Rows)
            {
                string username = row.Cells[3].Text;
                string firstname = ((TextBox)row.Cells[0].Controls[1]).Text;
                string lastname = ((TextBox)row.Cells[1].Controls[1]).Text;
                string name = firstname + " " + lastname;
                string email = row.Cells[2].Text;

                if (count < max)
                {
                    if (username.Replace("&nbsp;", "").Trim() != "")
                    {
                        cmd = new SqlCommand("SP_AddAccountUserByUsername", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", Settings.getDomain() + "\\" + username);
                        cmd.Parameters.AddWithValue("@first", firstname);
                        cmd.Parameters.AddWithValue("@last", lastname);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@account_id", accountid);
                        dr = cmd.ExecuteReader();
                        int retVal = 3;
                        if (dr.Read())
                        {
                            retVal = dr.GetInt32(0);
                        }
                        dr.Close();
                        if (retVal == 0)
                        {
                            count++;
                            results = results + "<font color=\"green\">User " + name + " successfully added.<br>";
                        }
                        else if (retVal == 1)
                            results = results + "<font color=\"blue\">User " + name + " already added.<br>";
                        else
                            results = results + "<font color=\"red\">Failed to add user " + name + "<br>";
                    }
                    else
                    {
                        string err = "";
                        string newUsername = accts.createAccount(email, firstname, lastname, out err);
                        if (err == "0")
                        {
                            results = results + "<font color=\"green\">User " + name + " successfully created.<br>";
                            cmd = new SqlCommand("SP_AddAccountUserByUsername", cn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@username", Settings.getDomain() + "\\" + newUsername);
                            cmd.Parameters.AddWithValue("@first", firstname);
                            cmd.Parameters.AddWithValue("@last", lastname);
                            cmd.Parameters.AddWithValue("@email", email);
                            cmd.Parameters.AddWithValue("@account_id", accountid);
                            dr = cmd.ExecuteReader();
                            int retVal = 3;
                            if (dr.Read())
                            {
                                retVal = dr.GetInt32(0);
                            }
                            dr.Close();
                            if (retVal == 0)
                            {
                                count++;
                                results = results + "<font color=\"green\">User " + name + " successfully added.<br>";
                            }
                            else if (retVal == 1)
                                results = results + "<font color=\"blue\">User " + name + " already added.<br>";
                            else
                                results = results + "<font color=\"red\">Failed to add user " + name + "<br>";
                        }
                        else
                        {
                            results = results + "<font color=\"red\">Failed to create user " + name + "<br>";
                        }
                    }
                }
                else
                {
                    results = results + "<font color=\"red\">Skipping user " + name + "; out of licenses.<br>";
                }
            }


            lblResults.Text = results;
            
            return true;
        }

        private int doSearch()
        {

            string[] emails = txtEmails.Text.Split(";\n,".ToCharArray()); ;
            int newCount = count;
            foreach (string emaila in emails)
            {
                string email = emaila.Trim();
                if (email != "")
                {
                    string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
                   + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                   + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                   + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                   + @"[a-zA-Z]{2,}))$";
                    if (Regex.Matches(email, patternStrict).Count > 0)
                        newCount++;
                    /*int atLocation = email.IndexOf("@");
                    if (atLocation > 0)
                    {
                        int dotLocation = email.IndexOf(".", atLocation);
                        if (dotLocation > atLocation && dotLocation + 1 < email.Length)
                        {
                        
                            newCount++;
                        }
                    }*/
                }
            }
            if (newCount > max)
                return 1;
            if (newCount == count)
                return 2;

            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Columns.Add("first");
            ds.Tables[0].Columns.Add("last");
            ds.Tables[0].Columns.Add("email");
            ds.Tables[0].Columns.Add("username");

            ServicePointManager.ServerCertificateValidationCallback += delegate(object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors){ return true; };

            accounts.Service accts = new accounts.Service();
            
            if (ConfigurationManager.AppSettings["acctsUrl"] != null)
                accts.Url = ConfigurationManager.AppSettings["acctsUrl"];
            accts.Credentials = new System.Net.NetworkCredential("adaccessuser", "lkf@$farFA", "epm");
            bool found = false;

            foreach (string emaila in emails)
            {
                string email = emaila.Trim();
                if (email != "")
                {
                    int atLocation = email.IndexOf("@");
                    if (atLocation > 0)
                    {
                        int dotLocation = email.IndexOf(".", atLocation);
                        if (dotLocation > atLocation && dotLocation + 1 < email.Length)
                        {
                            found = true;
                            accounts.LookUpList[] List = accts.findUser(email.Trim());

                            if (List != null && List.Length > 0)
                            {
                                string firstName = "";
                                string last = "";
                                int tmp = List[0].name.IndexOf(' ');

                                try
                                {
                                    firstName = List[0].name.Substring(0, tmp);
                                    last = List[0].name.Substring(tmp).Trim();
                                }
                                catch (Exception) { }
                                ds.Tables[0].Rows.Add(firstName, last, email, List[0].uid);
                            }
                            else
                            {
                                ds.Tables[0].Rows.Add("", "", email, "");
                            }
                        }
                    }
                }
            }

            GridView1.Columns[3].Visible = true;
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = "last";
            GridView1.DataSource = dv.Table;
            GridView1.DataBind();
            GridView1.Columns[3].Visible = false;

            foreach (GridViewRow row in GridView1.Rows)
            {
                TextBox tx = (TextBox)row.Cells[0].Controls[1];
                if (tx.Text != "")
                {
                    tx.ReadOnly = true;
                    tx.BackColor = System.Drawing.Color.Transparent;
                    tx.BorderStyle = BorderStyle.None;
                    tx = (TextBox)row.Cells[1].Controls[1];
                    tx.ReadOnly = true;
                    tx.BorderStyle = BorderStyle.None;
                    tx.BackColor = System.Drawing.Color.Transparent;
                }
            }
            return 0;
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            switch (hdnStep.Value)
            {
                case "2":
                    lblGridError.Visible = false;
                    hdnStep.Value = "1";
                    btnBack.Visible = false;
                    txtEmails.Visible = true;
                    GridView1.Visible = false;
                    lblDesc.Text = "To add user accounts, enter a list of email addresses separated by semicolons or by a new line.";
                    btnNext.Text = "Next >";
                    lblEmailsNotification.Visible = true;
                    break;
                case "3":
                    hdnStep.Value = "2";
                    break;
            }
        }
    }
}