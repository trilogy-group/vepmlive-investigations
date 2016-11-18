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
using System.Data;
using System.Data.SqlClient;


namespace AdminSite
{
    public partial class createaccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if(txtSearch.Text == "")
                return;

            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("contact");
            dt.Columns.Add("account_id");
            dt.Columns.Add("use");
            dt.Columns.Add("enabled", typeof(bool));

            MSCRM.CrmService msCrm = CrmHelper.getCRMService();

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            foreach(MSCRM.account acc in findAccounts(msCrm))
            {
                MSCRM.contact contact = getContact(msCrm, acc.primarycontactid.Value);
                if(contact.emailaddress1 != "" && contact.emailaddress1 != null)
                {
                    SqlCommand cmd = new SqlCommand("select email,crmaccountuid from vwAccountInfo where email like @email or crmaccountuid=@accountid", cn);
                    cmd.Parameters.AddWithValue("@email", contact.emailaddress1);
                    cmd.Parameters.AddWithValue("@accountid", acc.accountid.Value);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        if(dr.IsDBNull(1))
                            dt.Rows.Add(new object[] { acc.name, contact.firstname + " " + contact.lastname, acc.accountid.Value.ToString(), "E-mail Exists", false });
                        else
                            dt.Rows.Add(new object[] { acc.name, contact.firstname + " " + contact.lastname, acc.accountid.Value.ToString(), "Already Linked", false });
                    }
                    else
                    {
                        dt.Rows.Add(new object[] { acc.name, contact.firstname + " " + contact.lastname, acc.accountid.Value.ToString(), "Use Account", true });
                    }
                    dr.Close();
                }
            }

            cn.Close();

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected MSCRM.contact getContact(MSCRM.CrmService msCrm, Guid contactid)
        {
            MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

            cols.Attributes = new string[] { "firstname", "lastname", "emailaddress1", "department", "telephone1", "jobtitle", "address1_line1", "address1_line2", "address1_city", "address1_stateorprovince", "address1_country", "address1_postalcode" };

            MSCRM.contact c = (MSCRM.contact)msCrm.Retrieve(MSCRM.EntityName.contact.ToString(), contactid, cols);

            return c;
        }

        protected MSCRM.account getAccount(MSCRM.CrmService msCrm, Guid accountid)
        {
            MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

            cols.Attributes = new string[] { "name", "primarycontactid" };

            MSCRM.account c = (MSCRM.account)msCrm.Retrieve(MSCRM.EntityName.account.ToString(), accountid, cols);

            return c;
        }

        protected MSCRM.BusinessEntity[] findAccounts(MSCRM.CrmService msCrm)
        {
            try
            {

                // Create the ColumnSet that indicates the properties to be retrieved.
                MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

                // Set the properties of the ColumnSet.
                cols.Attributes = new string[] { "name", "primarycontactid" };

                // Create the ConditionExpression.
                MSCRM.ConditionExpression condition = new MSCRM.ConditionExpression();
                condition.AttributeName = "name";
                condition.Operator = MSCRM.ConditionOperator.Like;
                condition.Values = new string[] { "%" + txtSearch.Text + "%" };

                MSCRM.ConditionExpression condition2 = new MSCRM.ConditionExpression();
                condition2.AttributeName = "primarycontactid";
                condition2.Operator = MSCRM.ConditionOperator.NotNull;

                // Create the FilterExpression.
                MSCRM.FilterExpression filter = new MSCRM.FilterExpression();

                // Set the properties of the filter.
                filter.FilterOperator = MSCRM.LogicalOperator.And;
                filter.Conditions = new MSCRM.ConditionExpression[] { condition, condition2 };

                // Create the QueryExpression object.
                MSCRM.QueryExpression query = new MSCRM.QueryExpression();

                // Set the properties of the QueryExpression object.
                query.EntityName = MSCRM.EntityName.account.ToString();
                query.ColumnSet = cols;
                query.Criteria = filter;

                // Retrieve the contacts.
                MSCRM.BusinessEntityCollection accounts = msCrm.RetrieveMultiple(query);

                return accounts.BusinessEntities;

            }
            catch(System.Web.Services.Protocols.SoapException ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            return null;
        }

        protected MSCRM.BusinessEntity[] getOrders(MSCRM.CrmService msCrm, MSCRM.Key accountid)
        {
            try
            {
                // Create the ColumnSet that indicates the properties to be retrieved.
                MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

                // Set the properties of the ColumnSet.
                cols.Attributes = new string[] { "name", "salesorderid", "customerid", "new_ordertype", "ordernumber", "new_monthstobill", "new_recurring" };

                MSCRM.ConditionExpression condition = new MSCRM.ConditionExpression();
                condition.AttributeName = "customerid";
                condition.Operator = MSCRM.ConditionOperator.Equal;
                condition.Values = new string[] { accountid.Value.ToString() };

                MSCRM.ConditionExpression condition2 = new MSCRM.ConditionExpression();
                condition2.AttributeName = "new_ordertype";
                condition2.Operator = MSCRM.ConditionOperator.Equal;
                condition2.Values = new object[] { "2" };

                // Create the FilterExpression.
                MSCRM.FilterExpression filter = new MSCRM.FilterExpression();
                filter.FilterOperator = MSCRM.LogicalOperator.And;
                filter.Conditions = new MSCRM.ConditionExpression[] { condition, condition2 };

                // Create the QueryExpression object.
                MSCRM.QueryExpression query = new MSCRM.QueryExpression();

                // Set the properties of the QueryExpression object.
                query.EntityName = MSCRM.EntityName.salesorder.ToString();
                query.ColumnSet = cols;
                query.Criteria = filter;

                // Retrieve the contacts.
                MSCRM.BusinessEntityCollection salesorders = msCrm.RetrieveMultiple(query);

                return salesorders.BusinessEntities;
            }
            catch(System.Web.Services.Protocols.SoapException ex)
            {
                Response.Write("Error Finding Orders: " + ex.Message + ex.Detail.OuterXml);
            }
            return null;
        }

        protected MSCRM.BusinessEntity[] getOrderDetail(MSCRM.CrmService msCrm, Guid salesorderid)
        {
            try
            {
                // Create the ColumnSet that indicates the properties to be retrieved.
                MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

                // Set the properties of the ColumnSet.
                cols.Attributes = new string[] { "productid", "owningbusinessunit", "quantity", "uomid", "productdescription", "priceperunit", "isproductoverridden" };

                // Create the ConditionExpression.
                MSCRM.ConditionExpression condition = new MSCRM.ConditionExpression();
                condition.AttributeName = "salesorderid";
                condition.Operator = MSCRM.ConditionOperator.Equal;
                condition.Values = new string[] { salesorderid.ToString() };

                // Create the FilterExpression.
                MSCRM.FilterExpression filter = new MSCRM.FilterExpression();
                filter.FilterOperator = MSCRM.LogicalOperator.And;
                filter.Conditions = new MSCRM.ConditionExpression[] { condition };

                // Create the QueryExpression object.
                MSCRM.QueryExpression query = new MSCRM.QueryExpression();
                query.EntityName = MSCRM.EntityName.salesorderdetail.ToString();
                query.ColumnSet = cols;
                query.Criteria = filter;

                // Retrieve the contacts.
                MSCRM.BusinessEntityCollection salesorderdetails = msCrm.RetrieveMultiple(query);

                return salesorderdetails.BusinessEntities;


            }
            catch(System.Web.Services.Protocols.SoapException ex)
            {
                lblProcess.Text += "<font color=\"red\">Error: " + ex.Message + "</font>";
            }
            return null;
        }

        protected int isValidProduct(MSCRM.CrmService msCrm, Guid productUid)
        {
            MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

            cols.Attributes = new string[] { "productnumber" };

            MSCRM.product p = (MSCRM.product)msCrm.Retrieve(MSCRM.EntityName.product.ToString(), productUid, cols);
            string h = p.productnumber;

            switch(p.productnumber)
            {
                case "ENT":
                    return 1;
                case "WGO":
                    return 2;
            }

            return 0;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "use")
            {
                MSCRM.CrmService msCrm = CrmHelper.getCRMService();

                MSCRM.account acc = getAccount(msCrm, new Guid(e.CommandArgument.ToString()));

                MSCRM.contact contact = getContact(msCrm, acc.primarycontactid.Value);

                lblCompany.Text = acc.name;
                lblDepartment.Text = contact.department;
                lblEmail.Text = contact.emailaddress1;
                lblFirstName.Text = contact.firstname;
                lblLastName.Text = contact.lastname;
                lblPhone.Text = contact.telephone1;
                lblTitle.Text = contact.jobtitle;

                lblAddress1.Text = contact.address1_line1;
                lblAddress2.Text = contact.address1_line2;
                lblCity.Text = contact.address1_city;
                lblCountry.Text = contact.address1_country;
                lblState.Text = contact.address1_stateorprovince;
                lblZip.Text = contact.address1_postalcode;


                hdnAccountId.Value = e.CommandArgument.ToString();

                pnlInfo.Visible = true;
                pnlSearch.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                MSCRM.CrmService msCrm = CrmHelper.getCRMService();

                MSCRM.account acc = getAccount(msCrm, new Guid(hdnAccountId.Value));

                MSCRM.contact contact = getContact(msCrm, acc.primarycontactid.Value);

                pnlInfo.Visible = false;
                pnlProcess.Visible = true;


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
                    lblProcess.Text += "<b>Creating account</b><Br>";
                    uname = accts.createAccountSilent(lblEmail.Text, lblFirstName.Text, lblLastName.Text, out sError);

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
                    lblProcess.Text += "<b>Account exists, sending email to user</b><br>";
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
                    lblProcess.Text += "<b>Reading user info from database</b><br>";

                    SqlCommand cmd = new SqlCommand("Select [uid] from [users] where username like '" + System.Configuration.ConfigurationManager.AppSettings["domain"].ToString() + "\\" + uname + "'", cn);
                    SqlDataReader drUser = cmd.ExecuteReader();

                    if(drUser.Read())
                    {
                        lblProcess.Text += "<b>Updating user information in DB</b><br>";
                        Guid uid = drUser.GetGuid(0);
                        drUser.Close();
                        Guid accountuid = Guid.NewGuid();


                        string sql = "UPDATE [users] set company=@company, title=@title, phone=@phone,  department=@department, address1=@address1, address2=@address2, ";
                        sql = sql + "city=@city, state=@state, zip=@zip, country=@country, version=1, registered=1, activated=1, enabled=1 where [uid] = @uid";
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
                        cmd.Parameters.AddWithValue("@uid", uid);
                        cmd.ExecuteNonQuery();

                        lblProcess.Text += "<b>Looking for previous account #</b><br>";

                        cmd = new SqlCommand("SELECT * from account where owner_id=@uid", cn);
                        cmd.Parameters.AddWithValue("@uid", uid);
                        SqlDataReader dr = cmd.ExecuteReader();

                        int account_ref = 0;

                        if(!dr.Read())
                        {
                            lblProcess.Text += "<b>No previous account #, adding account #</b><br>";
                            dr.Close();
                            cmd = new SqlCommand("INSERT INTO account (account_id,owner_id,maxusers,creator_id,intrial,version,diskquota,accountdescription) VALUES (@accountid,@uid,10,@uid,1,1,500,@desc)", cn);
                            cmd.Parameters.AddWithValue("@uid", uid);
                            cmd.Parameters.AddWithValue("@accountid", accountuid);
                            cmd.Parameters.AddWithValue("@desc", lblCompany.Text);
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

                        cmd = new SqlCommand("UPDATE account set crmaccountuid=@crmauid where account_id=@accountid", cn);
                        cmd.Parameters.AddWithValue("@crmauid", acc.accountid.Value);
                        cmd.Parameters.AddWithValue("@accountid", accountuid);
                        cmd.ExecuteNonQuery();

                        lblProcess.Text += "<b>Adding user to account users list</b><br>";

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

                        lblProcess.Text += "<br><b>Processing CRM Orders</b><br>";

                        foreach(MSCRM.salesorder order in getOrders(msCrm, acc.accountid))
                        {
                            lblProcess.Text += "<b>&nbsp;&nbsp;&nbsp;Processing CRM Order: " + order.ordernumber + "</b><br>";

                            DateTime dtexp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0).AddMonths(order.new_monthstobill.Value);

                            if(order.new_monthstobill.Value == 1)
                            {

                                lblProcess.Text += "<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Monthly Flexible Recurring Detected</b><br>";

                                cmd = new SqlCommand("UPDATE ACCOUNT set billingtype=2 where account_id = @accountid", cn);
                                cmd.Parameters.AddWithValue("@accountid", accountuid);
                                cmd.ExecuteNonQuery();

                            }
                            else
                            {
                                lblProcess.Text += "<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Non-Flexible Periodic Recurring Detected</b><br>";

                                cmd = new SqlCommand("UPDATE ACCOUNT set billingtype=3 where account_id = @accountid", cn);
                                cmd.Parameters.AddWithValue("@accountid", accountuid);
                                cmd.ExecuteNonQuery();

                            }

                            MSCRM.BusinessEntity[] orderdetail = getOrderDetail(msCrm, order.salesorderid.Value);

                            bool found = false;

                            foreach(MSCRM.salesorderdetail sod in getOrderDetail(msCrm, order.salesorderid.Value))
                            {
                                switch(isValidProduct(msCrm, sod.productid.Value))
                                {
                                    case 1:
                                        found = true;
                                        lblProcess.Text += "<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding (" + (sod.quantity.Value / order.new_monthstobill.Value) + ") Enterprise Users</b><br>";

                                        Guid orderid = Guid.NewGuid();

                                        cmd = new SqlCommand("insert into orders (account_ref,plimusreferencenumber,quantity,expiration,plimusaccountid,version,crmorderuid, order_id) values (@account_ref,@plimusreferencenumber,@quantity,@expiration,1,2,@crmorderuid,@order_id)", cn);
                                        cmd.Parameters.AddWithValue("@account_ref", account_ref);
                                        cmd.Parameters.AddWithValue("@plimusreferencenumber", order.ordernumber);
                                        cmd.Parameters.AddWithValue("@quantity", sod.quantity.Value / order.new_monthstobill.Value);
                                        cmd.Parameters.AddWithValue("@expiration", dtexp);
                                        cmd.Parameters.AddWithValue("@crmorderuid", order.salesorderid.Value);
                                        cmd.Parameters.AddWithValue("@order_id", orderid);
                                        cmd.ExecuteNonQuery();

                                        cmd = new SqlCommand("insert into enterprise_orders (crmorderid,quantity,expiration,order_id) values (@crmorderid,@quantity, @expiration,@order_id)", cn);
                                        cmd.Parameters.AddWithValue("@crmorderid", order.ordernumber);
                                        cmd.Parameters.AddWithValue("@quantity", sod.quantity.Value / order.new_monthstobill.Value);
                                        cmd.Parameters.AddWithValue("@expiration", dtexp);
                                        cmd.Parameters.AddWithValue("@order_id", orderid);
                                        cmd.ExecuteNonQuery();

                                        break;
                                    case 2:
                                        found = true;
                                        lblProcess.Text += "<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding (" + (sod.quantity.Value / order.new_monthstobill.Value) + ") Workgroup Users</b><br>";
                                        cmd = new SqlCommand("insert into orders (account_ref,plimusreferencenumber,quantity,expiration,plimusaccountid,version,crmorderid,crmorderuid) values (@account_ref,@plimusreferencenumber,@quantity,@expiration,1,2,@crmorderid,@crmorderuid)", cn);
                                        cmd.Parameters.AddWithValue("@account_ref", account_ref);
                                        cmd.Parameters.AddWithValue("@plimusreferencenumber", order.ordernumber);
                                        cmd.Parameters.AddWithValue("@quantity", sod.quantity.Value / order.new_monthstobill.Value);
                                        cmd.Parameters.AddWithValue("@expiration", dtexp);
                                        cmd.Parameters.AddWithValue("@crmorderid", order.ordernumber);
                                        cmd.Parameters.AddWithValue("@crmorderuid", order.salesorderid.Value);
                                        cmd.ExecuteNonQuery();
                                        break;
                                };
                            }

                            if(!found)
                            {
                                lblProcess.Text += "<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;No Details Found Adding Default (25) Workgroup Users</b><br>";
                                cmd = new SqlCommand("insert into orders (account_ref,plimusreferencenumber,quantity,expiration,plimusaccountid,version,crmorderid) values (@account_ref,@plimusreferencenumber,@quantity,@expiration,1,2,@crmorderid)", cn);
                                cmd.Parameters.AddWithValue("@account_ref", account_ref);
                                cmd.Parameters.AddWithValue("@plimusreferencenumber", order.ordernumber);
                                cmd.Parameters.AddWithValue("@quantity", 25);
                                cmd.Parameters.AddWithValue("@expiration", dtexp);
                                cmd.Parameters.AddWithValue("@crmorderid", order.ordernumber);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        lblProcess.Text += "<br><font color=\"green\"><b>Successfully Created Account</b></font><br>";
                    }
                    else
                    {
                        lblProcess.Text += "<font color=\"red\">Error: Could not find user in database</font><br>";
                    }
                }
                else
                {
                    lblProcess.Text += "<font color=\"red\">Error creating account: " + sError + "</font><br>";
                }

                cn.Close();
            }
            catch(Exception ex)
            {
                lblProcess.Text += "<font color=\"red\">Error: " + ex.Message + "</font>";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("createaccount.aspx");
        }
    }
}