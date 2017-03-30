using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Threading;

namespace AdminSite
{
    public partial class partnerrequests : System.Web.UI.Page
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

            sc.accts.createTrialSite(sc.name, sc.url, sc.email, "EPM Live Site Collection v2", "EPM Live Site Collection v2", out sError);

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
            if(!IsPostBack)
            {
                fillGrid();
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "process")
            {
                pnlProcess.Visible = true;
                GridView1.Visible = false;

                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                DataSet ds;
                SqlCommand cmdGetSites;
                SqlDataAdapter da;

                cmdGetSites = new SqlCommand("SELECT * from partners where partner_id=@partner_id", cn);
                cmdGetSites.Parameters.AddWithValue("@partner_id", e.CommandArgument);
                cmdGetSites.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmdGetSites);
                ds = new DataSet();
                da.Fill(ds);



                lblAddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
                lblCity.Text = ds.Tables[0].Rows[0]["city"].ToString();
                lblCompany.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
                lblCountry.Text = ds.Tables[0].Rows[0]["country"].ToString();
                lblDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
                lblEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
                lblFirst.Text = ds.Tables[0].Rows[0]["firstname"].ToString();
                lblLast.Text = ds.Tables[0].Rows[0]["lastname"].ToString();
                lblState.Text = ds.Tables[0].Rows[0]["state"].ToString();
                lblServices.Text = ds.Tables[0].Rows[0]["services"].ToString();
                lblUrl.Text = ds.Tables[0].Rows[0]["companyurl"].ToString();
                lblZip.Text = ds.Tables[0].Rows[0]["zip"].ToString();

                string type = "";
                if(ds.Tables[0].Rows[0]["reseller"].ToString() == "True")
                    type = "-Reseller<br>";
                if(ds.Tables[0].Rows[0]["solution"].ToString() == "True")
                    type = type + "-Solution Provider<br>";
                if(ds.Tables[0].Rows[0]["product"].ToString() == "True")
                    type = type + "-3rd Party Product<br>";

                if(type.Length > 0)
                    type = type.Substring(0, type.Length - 4);

                lblType.Text = type;

                accountsSvc.Service accts = new accountsSvc.Service();
                accts.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["username"].ToString(), System.Configuration.ConfigurationManager.AppSettings["password"].ToString(), System.Configuration.ConfigurationManager.AppSettings["domain"].ToString());
                accountsSvc.LookUpList[] list = accts.findUser(ds.Tables[0].Rows[0]["email"].ToString());
                if(list.Length > 0)
                {
                    lblAccount.Text = "Yes";
                    hdnUserId.Value = list[0].uid;

                    SqlCommand cmd = new SqlCommand("SELECT fullurl,title from vwUserSites where username like @username", cn);
                    cmd.Parameters.AddWithValue("@username", System.Configuration.ConfigurationManager.AppSettings["domain"].ToString() + "\\" + list[0].uid);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        hdnSiteUrl.Value = dr.GetString(0);
                        hdnSiteName.Value = dr.GetString(1);
                        pnlSite.Visible = false;
                    }

                    dr.Close();
                }
                else
                    lblAccount.Text = "No";

                txtSiteName.Text = lblCompany.Text;
                txtSiteUrl.Text = lblCompany.Text.ToLower().Replace(" ", "");
                hdnPartnerId.Value = e.CommandArgument.ToString();



                cn.Close();
            }
            if(e.CommandName == "del")
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                SqlCommand cmd;

                cmd = new SqlCommand("delete partners where partner_id=@partner_id", cn);
                cmd.Parameters.AddWithValue("@partner_id", e.CommandArgument);
                cmd.CommandType = CommandType.Text;

                cmd.ExecuteNonQuery();

                cn.Close();

                fillGrid();
            }
        }

        private void fillGrid()
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            DataSet ds;
            SqlCommand cmdGetSites;
            SqlDataAdapter da;

            cmdGetSites = new SqlCommand("SELECT firstName, lastName, companyname, partner_id from partners where active=0", cn);
            cmdGetSites.CommandType = CommandType.Text;

            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            cn.Close();

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Buffer = true;
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            bool good = true;
            string cdkey = "";
            string company = "";

            emailservice.Service eService = new emailservice.Service();
            eService.UseDefaultCredentials = true;

            accountsSvc.Service accts = new accountsSvc.Service();
            accts.Credentials = new System.Net.NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["username"].ToString(), System.Configuration.ConfigurationManager.AppSettings["password"].ToString(), System.Configuration.ConfigurationManager.AppSettings["domain"].ToString());

            bool isAvail = accts.isSiteAvailable(txtSiteUrl.Text);
            if(!isAvail && hdnSiteUrl.Value == "")
            {
                Response.Write("<font color=\"red\">Site URL Already in Use.</font>");
            }
            else
            {
                string username = hdnUserId.Value;
                string sError = "";
                if(username == "")
                {
                    username = accts.createAccount(lblEmail.Text, lblFirst.Text, lblLast.Text, out sError);
                    if(sError != "0")
                    {
                        Response.Write("<font color=\"red\">Failed to create user: " + sError + "</font>");
                        good = false;
                    }
                    Response.Write("<font color=\"green\">Successfully created user.</font><br>");
                }
                else
                {
                    Response.Write("<font color=\"green\">Skipping user Creation: User already has an AD account.</font><br>");
                }
                Response.Flush();
                if(good)
                {
                    sError = "";
                    accts.addPartner(lblEmail.Text, out sError);
                    if(sError == "")
                    {
                        Response.Write("<font color=\"green\">User has been added to the partners group.</font><br>");
                    }
                    else if(sError == "1")
                        Response.Write("<font color=\"green\">User already in partners group.</font><br>");
                    else
                        Response.Write("<font color=\"red\">User failed to add to partners group</font><br>");

                    Response.Flush();

                    SqlCommand cmd = new SqlCommand("Select [uid] from [users] where username like '" + System.Configuration.ConfigurationManager.AppSettings["domain"].ToString() + "\\" + username + "'", cn);
                    SqlDataReader drUser = cmd.ExecuteReader();

                    if(drUser.Read())
                    {
                        Guid uid = drUser.GetGuid(0);
                        drUser.Close();
                        Guid accountuid = Guid.NewGuid();

                        cmd = new SqlCommand("SELECT account_id from account where owner_id=@uid", cn);
                        cmd.Parameters.AddWithValue("@uid", uid);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if(!dr.Read())
                        {
                            dr.Close();
                            cmd = new SqlCommand("INSERT INTO account (account_id,owner_id,maxusers,creator_id,intrial,version,diskquota) VALUES (@accountid,@uid,10,@uid,1,1,500)", cn);
                            cmd.Parameters.AddWithValue("@uid", uid);
                            cmd.Parameters.AddWithValue("@accountid", accountuid);
                            cmd.ExecuteNonQuery();
                            Response.Write("<font color=\"green\">Added Workgroup account.</font><br>");
                        }
                        else
                        {

                            accountuid = dr.GetGuid(0);
                            Response.Write("<font color=\"green\">Skipping account creation: User already has Workgroup account.</font><br>");
                            dr.Close();
                        }
                        Response.Flush();

                        cmd = new SqlCommand("SELECT account_ref from account where account_id=@accountuid", cn);
                        cmd.Parameters.AddWithValue("@accountuid", accountuid);
                        dr = cmd.ExecuteReader();

                        if(dr.Read())
                        {
                            int accountRef = dr.GetInt32(0);
                            dr.Close();
                            //=============================Add 10 Users to orders=======================
                            cmd = new SqlCommand("SELECT * from orders where account_ref=@accountRef and plimusReferenceNumber=5000", cn);
                            cmd.Parameters.AddWithValue("@accountRef", accountRef);
                            dr = cmd.ExecuteReader();

                            if(dr.Read())
                            {
                                Response.Write("<font color=\"green\">Skipping 10 user accounts: account already has 10 users.</font><br>");
                                dr.Close();
                            }
                            else
                            {
                                Response.Write("<font color=\"green\">Granted 10 users to account for 1 year.</font><br>");
                                dr.Close();
                                cmd = new SqlCommand("INSERT INTO ORDERS (account_ref,plimusReferenceNumber,quantity,expiration,version,plimusAccountId) VALUES (@accountref,5000,10,DATEADD(Year,1,GETDATE()),2,0)", cn);
                                cmd.Parameters.AddWithValue("@accountref", accountRef);
                                cmd.ExecuteNonQuery();
                            }
                            Response.Flush();
                            //=============================Publisher Licenses=======================
                            cmd = new SqlCommand("SELECT cdkey,company from productkeys where email=@email", cn);
                            cmd.Parameters.AddWithValue("@email", lblEmail.Text);
                            dr = cmd.ExecuteReader();

                            if(dr.Read())
                            {
                                cdkey = dr.GetString(0);
                                company = dr.GetString(1);
                                Response.Write("<font color=\"green\">Skipping Publisher key creation: User already has 5 Publisher Activations.</font><br>");
                                dr.Close();
                            }
                            else
                            {
                                dr.Close();

                                cdkey = getKey();
                                cdkey = cdkey.Replace("-", "");

                                string sql = "";

                                cmd = new SqlCommand("SELECT * FROM CUSTOMERS where email like '" + lblEmail.Text + "'", cn);
                                dr = cmd.ExecuteReader();
                                string customerid = "";
                                if(dr.Read())
                                {
                                    customerid = dr["customer_id"].ToString();
                                }
                                dr.Close();

                                if(customerid == "")
                                {
                                    customerid = Guid.NewGuid().ToString();

                                    sql = "INSERT INTO CUSTOMERS (";
                                    sql = sql + "customer_id,";
                                    sql = sql + "company,";
                                    sql = sql + "firstName,";
                                    sql = sql + "lastName,";
                                    sql = sql + "address1,";
                                    sql = sql + "city,";
                                    sql = sql + "state,";
                                    sql = sql + "zipcode,";
                                    sql = sql + "country,";
                                    sql = sql + "email";
                                    sql = sql + ") VALUES (";
                                    sql = sql + "'" + customerid + "',";
                                    sql = sql + "'" + lblCompany.Text + "',";
                                    sql = sql + "'" + lblFirst.Text + "',";
                                    sql = sql + "'" + lblLast.Text + "',";
                                    sql = sql + "'" + lblAddress.Text + "',";
                                    sql = sql + "'" + lblCity.Text + "',";
                                    sql = sql + "'" + lblState.Text + "',";
                                    sql = sql + "'" + lblZip.Text + "',";
                                    sql = sql + "'" + lblCountry.Text + "',";
                                    sql = sql + "'" + lblEmail.Text + "'";
                                    sql = sql + ")";

                                    cmd = new SqlCommand(sql, cn);
                                    cmd.ExecuteNonQuery();

                                }

                                sql = "INSERT INTO PRODUCTKEYS (";
                                sql = sql + "customer_id,";
                                sql = sql + "cdkey,";
                                sql = sql + "activationcount,";
                                sql = sql + "licensecount,";
                                sql = sql + "purchasedate,";
                                sql = sql + "actkey,";
                                sql = sql + "company,";
                                sql = sql + "accountid,";
                                sql = sql + "couponCode,";
                                sql = sql + "couponValue,";
                                sql = sql + "referenceNumber";
                                sql = sql + ") VALUES (";
                                sql = sql + "'" + customerid + "',";
                                sql = sql + "'" + cdkey + "',";
                                sql = sql + "0,";
                                sql = sql + "5,";
                                sql = sql + "GETDATE(),";
                                sql = sql + "'" + genCode(lblCompany.Text, cdkey) + "',";
                                sql = sql + "'" + lblCompany.Text + "',";
                                sql = sql + "'5000',";
                                sql = sql + "'',";
                                sql = sql + "'',";
                                sql = sql + "'5000'";
                                sql = sql + ")";

                                cmd = new SqlCommand(sql, cn);
                                cmd.ExecuteNonQuery();

                                //company = lblCompany.Text;
                                //cmd = new SqlCommand("INSERT INTO productkeys (cdkey,activationcount,licensecount,purchasedate,actkey,company,firstname,lastname,address1,city,state,zipcode,country,email,internal) VALUES (@cdkey,0,5,GETDATE(),@actkey,@company,@firstname,@lastname,@address,@city,@state,@zip,@country,@email,1)", cn);
                                //cmd.Parameters.AddWithValue("@cdkey", cdkey);
                                //cmd.Parameters.AddWithValue("@actkey", genCode(lblCompany.Text, cdkey));
                                //cmd.Parameters.AddWithValue("@company", lblCompany.Text);
                                //cmd.Parameters.AddWithValue("@firstname", lblFirst.Text);
                                //cmd.Parameters.AddWithValue("@lastname", lblLast.Text);
                                //cmd.Parameters.AddWithValue("@address", lblAddress.Text);
                                //cmd.Parameters.AddWithValue("@city", lblCity.Text);
                                //cmd.Parameters.AddWithValue("@state", lblState.Text);
                                //cmd.Parameters.AddWithValue("@zip", lblZip.Text);
                                //cmd.Parameters.AddWithValue("@country", lblCountry.Text);
                                //cmd.Parameters.AddWithValue("@email", lblEmail.Text);
                                //cmd.ExecuteNonQuery();
                                Response.Write("<font color=\"green\">Added 5 Publisher Activations.</font><br>");
                            }
                            Response.Flush();
                            //===========================Create Site========================
                            if(hdnSiteUrl.Value == "")
                            {
                                //sError = "";
                                //accts.createSite(txtSiteName.Text, txtSiteUrl.Text, lblEmail.Text, "EPM Live Site Collection", "EPM Live Site Collection", out sError);
                                //accts.createTrialSite(txtSiteName.Text, txtSiteUrl.Text, lblEmail.Text, "EPM Live Site Collection v2", "EPM Live Site Collection v2", out sError);

                                SiteCreateData data = new SiteCreateData();
                                data.accts = accts;
                                data.eService = eService;
                                data.email = lblEmail.Text;
                                data.name = txtSiteName.Text;
                                data.url = txtSiteUrl.Text;
                                data.fullname = lblFirst.Text + " " + lblLast.Text;

                                Thread thrDownload = new Thread(new ParameterizedThreadStart(doCreateTrialSite));
                                thrDownload.IsBackground = true;
                                thrDownload.Start(data);

                                Response.Write("<font color=\"green\">site queued for creation.</font><br>");

                                //if (sError == "")
                                //{
                                //    hdnSiteUrl.Value = txtSiteUrl.Text;
                                //    hdnSiteName.Value = txtSiteName.Text;
                                //    Response.Write("<font color=\"green\">Created Workgroup site.</font><br>");
                                //}
                                //else
                                //{
                                //    Response.Write("<font color=\"red\">Failed to create site.</font><br>");
                                //}
                            }
                            else
                            {
                                Response.Write("<font color=\"green\">Skipping site creation: User already has site.</font><br>");
                            }
                            Response.Flush();
                            //=============================Update Partner Information===============

                            cmd = new SqlCommand("UPDATE PARTNERS set owner_id=@owner_id,active = 1 where partner_id=@partner_id", cn);
                            cmd.Parameters.AddWithValue("@owner_id", uid);
                            cmd.Parameters.AddWithValue("@partner_id", hdnPartnerId.Value);
                            cmd.ExecuteNonQuery();


                            eService.sendEmail(17, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", lblEmail.Text, new string[] { lblFirst.Text, "epm\\" + username, company, cdkey, hdnSiteUrl.Value, hdnSiteName.Value });
                            eService.sendEmail(17, "FD5BF59E-31ED-41e7-A25C-6E2B01DD6C1C", "partners@epmlive.com", new string[] { lblFirst.Text, "epm\\" + username, company, cdkey, hdnSiteUrl.Value, hdnSiteName.Value });
                            Response.Write("<font color=\"green\">Sent Email to partner.<br></font>");

                            Response.Write("<font color=\"green\"><br>Updated and activated partner.<br>DONE.</font>");

                            pnlProcess.Visible = false;
                            Response.Flush();
                        }
                        else
                        {
                            dr.Close();
                            Response.Write("<font color=\"red\">Failed to retrieve account information.</font>");
                        }
                    }
                    else
                    {
                        Response.Write("<font color=\"red\">Failed to find user in database</font>");
                        good = false;
                    }
                }
            }
            cn.Close();

        }

        private string getKey()
        {
            string key = "";
            Random rdm = new Random();
            for(int i = 0; i < 4; i++)
            {
                key = key + ((char)((short)'A' + rdm.Next(26))).ToString();
            }
            key = key + "-";
            for(int i = 0; i < 4; i++)
            {
                key = key + ((char)((short)'A' + rdm.Next(26))).ToString();
            }
            key = key + "-";
            for(int i = 0; i < 4; i++)
            {
                key = key + ((char)((short)'A' + rdm.Next(26))).ToString();
            }
            return key;
        }

        private string genCode(string company, string cdKey)
        {
            string pwd = "H3fd65TR" + company;
            string actCode = "";
            int counter = 0;
            for(int i = 0; i < cdKey.Length; i++)
            {
                if(counter + 1 >= pwd.Length)
                    counter = 0;
                actCode = actCode + (pwd[counter++] ^ cdKey[i]);
            }
            return actCode;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("partnerrequests.aspx");
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton2");
                l.Attributes.Add("onclick", "javascript:return confirm('Are you sure you want to delete that request?')");
            }
        }
    }
}