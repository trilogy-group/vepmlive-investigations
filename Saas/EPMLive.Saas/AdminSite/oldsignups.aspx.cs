using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Threading;

namespace AdminSite
{
    public partial class oldsignups : System.Web.UI.Page
    {
        public class SiteCreateData
        {
            public accountsSvc.Service accts;
            public emailservice.Service eService;
            public string name;
            public string url;
            public string email;
            public string fullname;
        }

        private void doCreateTrialSite(object data)
        {
            SiteCreateData sc = (SiteCreateData)data;

            Thread.Sleep(120000);

            string sError = "";

            sc.accts.createTrialSite(sc.name, sc.url, sc.email, "EPM Live Project Management Application", "EPM Live Project Management Application", out sError);

            if(sError == "")
            {
                sc.eService.sendEmail(6, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", sc.email, new string[] { sc.fullname, "https://my.epmlive.com/" + sc.url.Replace(" ", "%20"), sc.name });
            }
            else
            {
                sc.eService.sendEmail(20, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", "jhughes@epmlive.com", new string[] { "Create Trial Site (AdminSite)", sError });
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            DataSet ds;
            SqlCommand cmdGetSites;
            SqlDataAdapter da;

            cmdGetSites = new SqlCommand("SP_GetSignUps", cn);

            cmdGetSites.CommandType = CommandType.StoredProcedure;

            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            cn.Close();

            //GridView1.Columns[5].Visible = true;

            GridView1.DataSource = ds;
            GridView1.DataBind();

            try
            {
                if(Request["Status"] == "1")
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Successfully Processed Trial";
                }
                else if(Request["Status"] == "2")
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Trial Canceled";
                }
                else
                {
                    lblStatus.Visible = false;
                }
            }
            catch { lblStatus.Visible = false; }

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblStatus.Visible = false;
            if(e.CommandName == "vw")
            {
                GridView1.Visible = false;
                pnlView.Visible = true;

                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                DataSet ds;
                SqlCommand cmdGetSites;
                SqlDataAdapter da;

                cmdGetSites = new SqlCommand("SELECT * from signups where signup_id = '" + e.CommandArgument + "'", cn);
                cmdGetSites.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmdGetSites);
                ds = new DataSet();
                da.Fill(ds);

                DataRow dr = ds.Tables[0].Rows[0];

                lblAddress1.Text = dr["address1"].ToString();
                lblAddress2.Text = dr["address2"].ToString();
                lblCity.Text = dr["city"].ToString();
                lblCompany.Text = dr["company"].ToString();
                lblCountry.Text = dr["country"].ToString();
                lblDepartment.Text = dr["department"].ToString();
                lblEmail.Text = dr["email"].ToString();
                lblFirstName.Text = dr["firstname"].ToString();
                lblLastName.Text = dr["lastname"].ToString();
                lblPhone.Text = dr["phone"].ToString();
                lblRegion.Text = dr["region"].ToString();
                lblState.Text = dr["state"].ToString();
                lblTitle.Text = dr["title"].ToString();
                lblEventCode.Text = dr["eventcode"].ToString();
                lblApplication.Text = dr["RequestedApp"].ToString();
                lblPartner.Text = dr["partner"].ToString();
                lblPartnerId.Text = dr["partnerid"].ToString();
                try
                {
                    ddlVersion.SelectedValue = dr["requestedVersion"].ToString().Trim();
                }
                catch { }
                lblZip.Text = dr["zip"].ToString();

                cn.Close();

                txtCode.Text = dr["promocode"].ToString();

                hdnsignupid.Value = e.CommandArgument.ToString();
            }
        }

        private void processTrial()
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            string sError = "0";
            string uname = "";
            accountsSvc.Service accts = new accountsSvc.Service();
            accts.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["username"].ToString(), System.Configuration.ConfigurationManager.AppSettings["password"].ToString(), System.Configuration.ConfigurationManager.AppSettings["domain"].ToString());
            accountsSvc.LookUpList[] list = accts.findUser(lblEmail.Text);
            emailservice.Service eService = new emailservice.Service();
            eService.UseDefaultCredentials = true;

            if(list.Length <= 0)
            {
                uname = accts.createAccountSilent(lblEmail.Text, lblFirstName.Text, lblLastName.Text, out sError);
                //uname = accts.createAccount(lblEmail.Text,lblFirstName.Text,lblLastName.Text, out sError);

                SqlCommand cmd = new SqlCommand("Select tempPassword from [users] where username like '" + System.Configuration.ConfigurationManager.AppSettings["domain"].ToString() + "\\" + uname + "'", cn);
                SqlDataReader drUser = cmd.ExecuteReader();
                string pwd = "";
                if(drUser.Read())
                {
                    pwd = drUser.GetString(0);
                }
                drUser.Close();
                if(ddlVersion.SelectedValue == "2007")
                {
                    eService.sendEmail(6, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", lblEmail.Text, new string[] { lblFirstName.Text + " " + lblLastName.Text, System.Configuration.ConfigurationManager.AppSettings["domain"].ToString() + "\\" + uname, pwd, "https://my.epmlive.com", "https://my.epmlive.com/home/accounts" });
                }
                else if(ddlVersion.SelectedValue == "2010")
                {
                    eService.sendEmail(6, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", lblEmail.Text, new string[] { lblFirstName.Text + " " + lblLastName.Text, System.Configuration.ConfigurationManager.AppSettings["domain"].ToString() + "\\" + uname, pwd, "http://my.workengine.com", "http://my.workengine.com/account.aspx" });
                }
            }
            else
            {
                uname = list[0].uid;
                if(ddlVersion.SelectedValue == "2007")
                {
                    eService.sendEmail(9, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", lblEmail.Text, new string[] { 
                        lblFirstName.Text + " " + lblLastName.Text, 
                        "https://my.epmlive.com",
                        lblEmail.Text,
                        System.Configuration.ConfigurationManager.AppSettings["domain"].ToString() + "\\" + uname,
                        "https://my.epmlive.com/home/accounts"
                        });
                }
                else if(ddlVersion.SelectedValue == "2010")
                {
                    eService.sendEmail(9, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", lblEmail.Text, new string[] { 
                        lblFirstName.Text + " " + lblLastName.Text, 
                        "http://my.workengine.com",
                        lblEmail.Text,
                        System.Configuration.ConfigurationManager.AppSettings["domain"].ToString() + "\\" + uname,
                        "http://my.workengine.com/account.aspx"
                        });
                }
            }
            if(sError == "0")
            {
                SqlCommand cmd = new SqlCommand("Select [uid] from [users] where username like '" + System.Configuration.ConfigurationManager.AppSettings["domain"].ToString() + "\\" + uname + "'", cn);
                SqlDataReader drUser = cmd.ExecuteReader();

                if(drUser.Read())
                {
                    Guid uid = drUser.GetGuid(0);
                    drUser.Close();
                    Guid accountuid = Guid.NewGuid();


                    string sql = "UPDATE [users] set company=@company, title=@title, phone=@phone,  department=@department, address1=@address1, address2=@address2, ";
                    sql = sql + "city=@city, state=@state, zip=@zip, country=@country, region=@region, version=1, registered=1, activated=1, enabled=1 where [uid] = @uid";
                    cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@company", lblCompany.Text);
                    cmd.Parameters.AddWithValue("@title", lblTitle.Text);
                    cmd.Parameters.AddWithValue("@phone", lblPhone.Text);
                    cmd.Parameters.AddWithValue("@department", lblDepartment.Text);
                    cmd.Parameters.AddWithValue("@address1", lblAddress1.Text);
                    cmd.Parameters.AddWithValue("@address2", lblAddress2.Text);
                    cmd.Parameters.AddWithValue("@city", lblCity.Text);
                    cmd.Parameters.AddWithValue("@state", lblState.Text);
                    cmd.Parameters.AddWithValue("@zip", lblZip.Text);
                    cmd.Parameters.AddWithValue("@country", lblCountry.Text);
                    cmd.Parameters.AddWithValue("@region", lblRegion.Text);
                    cmd.Parameters.AddWithValue("@uid", uid);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("SELECT * from account where owner_id=@uid", cn);
                    cmd.Parameters.AddWithValue("@uid", uid);
                    SqlDataReader dr = cmd.ExecuteReader();

                    int account_ref = 0;

                    if(!dr.Read())
                    {
                        dr.Close();
                        cmd = new SqlCommand("INSERT INTO account (account_id,owner_id,maxusers,creator_id,intrial,version,diskquota,accountdescription,partnerid) VALUES (@accountid,@uid,10,@uid,1,1,500,@desc,@partnerid)", cn);
                        cmd.Parameters.AddWithValue("@uid", uid);
                        cmd.Parameters.AddWithValue("@accountid", accountuid);
                        cmd.Parameters.AddWithValue("@desc", lblCompany.Text);
                        cmd.Parameters.AddWithValue("@partnerid", lblPartnerId.Text);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("select account_ref from account where account_id = @accountid", cn);
                        cmd.Parameters.AddWithValue("@accountid", accountuid);
                        dr = cmd.ExecuteReader();
                        if(dr.Read())
                            account_ref = dr.GetInt32(0);
                        dr.Close();
                    }
                    else
                        dr.Close();

                    if(txtCode.Text != "")
                    {
                        cmd = new SqlCommand("select users,space,orderexpires from PROMOS where code = @code and codeexpires > getdate()", cn);
                        cmd.Parameters.AddWithValue("@code", txtCode.Text);
                        dr = cmd.ExecuteReader();

                        if(dr.Read())
                        {

                            cmd = new SqlCommand("INSERT INTO ORDERS (account_ref,plimusReferenceNumber,quantity,diskspace,expiration,version,plimusAccountId) VALUES (@accountref,@coupon,@users,@disk,@expires,2,1)", cn);
                            cmd.Parameters.AddWithValue("@accountref", account_ref);
                            cmd.Parameters.AddWithValue("@coupon", txtCode.Text);
                            cmd.Parameters.AddWithValue("@users", dr.GetInt32(0));
                            cmd.Parameters.AddWithValue("@disk", dr.GetInt32(1));
                            cmd.Parameters.AddWithValue("@expires", dr.GetDateTime(2));

                            dr.Close();

                            cmd.ExecuteNonQuery();

                        }
                        else
                            dr.Close();
                    }

                    cmd = new SqlCommand("SELECT * from ACCOUNT_USERS where user_id=@uid and account_id=@accountid", cn);
                    cmd.Parameters.AddWithValue("@uid", uid);
                    cmd.Parameters.AddWithValue("@accountid", accountuid);
                    dr = cmd.ExecuteReader();

                    if(!dr.Read())
                    {
                        dr.Close();
                        cmd = new SqlCommand("INSERT INTO ACCOUNT_USERS (account_id,user_id) VALUES (@accountid,@uid)", cn);
                        cmd.Parameters.AddWithValue("@uid", uid);
                        cmd.Parameters.AddWithValue("@accountid", accountuid);
                        cmd.ExecuteNonQuery();
                    }
                    else
                        dr.Close();



                    sError = "";

                    cmd = new SqlCommand("UPDATE SIGNUPS set status = 1 where signup_id=@signupid", cn);
                    cmd.Parameters.AddWithValue("@signupid", hdnsignupid.Value);
                    cmd.ExecuteNonQuery();

                    cn.Close();

                    Response.Redirect("signups.aspx?status=1");
                }
                else
                {
                    Response.Write("");
                    drUser.Close();
                }

            }
            else
            {
                eService.sendEmail(20, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", "jhughes@epmlive.com", new string[] { "Process Trial (Create User)", sError });
            }
            cn.Close();
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            processTrial();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE SIGNUPS set status = 2 where signup_id=@signupid", cn);
            cmd.Parameters.AddWithValue("@signupid", hdnsignupid.Value);
            cmd.ExecuteNonQuery();

            cn.Close();

            Response.Redirect("signups.aspx?status=2");
        }
        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("signups.aspx");
        }
    }
}