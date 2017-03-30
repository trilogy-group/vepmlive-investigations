using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace AdminSite
{
    public partial class fullfill : System.Web.UI.Page
    {
        private string saltValue = "f53fNDH@";
        private string hashAlgorithm = "SHA1";
        private int passwordIterations = 2;
        private string initVector = "77B2c3D4e1F3g7R1";
        private int keySize = 256;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillGrid();
            }
        }

        private void fillGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("invoicenumber");
            dt.Columns.Add("invoice_id");

            MSCRM.CrmService msCrm = CrmHelper.getCRMService();

            foreach(MSCRM.invoice invoice in findInvoices(msCrm))
            {
                dt.Rows.Add(new object[] { invoice.name, invoice.invoicenumber, invoice.invoiceid.Value.ToString() });
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "remove")
            {
                MSCRM.CrmService msCrm = CrmHelper.getCRMService();
                MSCRM.invoice invoice = getInvoice(msCrm, new Guid(e.CommandArgument.ToString()));
                invoice.new_keyssent.Value = true;
                msCrm.Update(invoice);
                Response.Redirect("fullfill.aspx");
            }
            else if(e.CommandName == "use")
            {
                pnlProcess.Visible = true;
                pnlOrder.Visible = false;

                MSCRM.CrmService msCrm = CrmHelper.getCRMService();

                lblProcess.Text = "<b>Getting Invoice</b>";
                MSCRM.invoice invoice = getInvoice(msCrm, new Guid(e.CommandArgument.ToString()));
                lblProcess.Text += "<Br><b>Getting End Customer Account</b>";
                if(invoice.new_endcustomerid == null)
                {
                    lblProcess.Text += "<Br><b><font color=\"red\">Invoice Not Linked to account</font></b>";
                    return;
                }
                MSCRM.account account = getAccount(msCrm, invoice.new_endcustomerid.Value);
                if(account == null)
                {
                    lblProcess.Text += "<Br><b><font color=\"red\">No account linked to order</font></b>";
                }
                else
                {
                    lblProcess.Text += "<Br><b>Getting Primary Contact</b>";

                    MSCRM.contact contact = getContact(msCrm, account.primarycontactid.Value);

                    if(contact == null)
                    {
                        lblProcess.Text += "<Br><b><font color=\"red\">No primary contact linked to account</font></b>";
                    }
                    else
                    {
                        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
                        cn.Open();

                        SqlCommand cmd = new SqlCommand("select customer_id from customers where crmaccountid = @crmaccountid", cn);
                        cmd.Parameters.AddWithValue("@crmaccountid", account.accountid.Value);
                        SqlDataReader dr = cmd.ExecuteReader();
                        Guid customerid = Guid.Empty;

                        if(dr.Read())
                        {
                            lblProcess.Text += "<Br><b>Account linked in system, adding order</b>";
                            customerid = dr.GetGuid(0);
                        }
                        dr.Close();

                        if(customerid == Guid.Empty)
                        {
                            cmd = new SqlCommand("select customer_id from customers where email like @email", cn);
                            cmd.Parameters.AddWithValue("@email", contact.emailaddress1);
                            dr = cmd.ExecuteReader();

                            if(dr.Read())
                            {
                                lblProcess.Text += "<Br><b>Contact (" + contact.emailaddress1 + ") found in system, adding order to contact</b>";
                                customerid = dr.GetGuid(0);
                            }
                            dr.Close();

                            cmd = new SqlCommand("update customers set crmaccountid=@crmaccountid where customer_id like @customerid", cn);
                            cmd.Parameters.AddWithValue("@customerid", customerid);
                            cmd.Parameters.AddWithValue("@crmaccountid", account.accountid.Value);
                            cmd.ExecuteNonQuery();
                        }

                        if(customerid == Guid.Empty)
                        {
                            lblProcess.Text += "<Br><b>Contact (" + contact.emailaddress1 + ") NOT found in system, creating contact</b>";

                            customerid = Guid.NewGuid();

                            string sql = "INSERT INTO CUSTOMERS (";
                            sql = sql + "customer_id,";
                            sql = sql + "company,";
                            sql = sql + "title,";
                            sql = sql + "firstName,";
                            sql = sql + "lastName,";
                            sql = sql + "address1,";
                            sql = sql + "address2,";
                            sql = sql + "city,";
                            sql = sql + "state,";
                            sql = sql + "zipcode,";
                            sql = sql + "country,";
                            sql = sql + "phone,";
                            sql = sql + "email,";
                            sql = sql + "crmaccountid";
                            sql = sql + ") VALUES (";
                            sql = sql + "'" + customerid + "',";
                            sql = sql + "'" + account.name + "',";
                            sql = sql + "'" + contact.jobtitle + "',";
                            sql = sql + "'" + contact.firstname + "',";
                            sql = sql + "'" + contact.lastname + "',";
                            sql = sql + "'" + contact.address1_line1 + "',";
                            sql = sql + "'" + contact.address1_line2 + "',";
                            sql = sql + "'" + contact.address1_city + "',";
                            sql = sql + "'" + contact.address1_stateorprovince + "',";
                            sql = sql + "'" + contact.address1_postalcode + "',";
                            sql = sql + "'" + contact.address1_country + "',";
                            sql = sql + "'" + contact.telephone1 + "',";
                            sql = sql + "'" + contact.emailaddress1 + "',";
                            sql = sql + "'" + account.accountid.Value.ToString() + "'";
                            sql = sql + ")";

                            cmd = new SqlCommand(sql, cn);
                            cmd.ExecuteNonQuery();
                        }

                        Hashtable hshCounts = new Hashtable();

                        lblProcess.Text += "<Br><br><b>Reading Invoice Products:</b>";

                        DataTable dt = new DataTable();
                        dt.Columns.Add("NAME");
                        dt.Columns.Add("SKU");
                        dt.Columns.Add("DBQTY");
                        dt.Columns.Add("TYPE");
                        dt.Columns.Add("TYPENAME");
                        dt.Columns.Add("VALUES");
                        dt.Columns.Add("ORDQTY");

                        foreach(MSCRM.invoicedetail detail in getInvoiceDetail(msCrm, invoice.invoiceid.Value))
                        {
                            if(detail.productid == null)
                            {
                                lblProcess.Text += "<Br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"red\">Skipping Write In Product:</font> " + detail.productdescription;
                            }
                            else
                            {
                                MSCRM.product p = getProduct(msCrm, detail.productid.Value);

                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"green\">Product:</font> " + p.name + " <b>(" + detail.quantity.Value + ").</b>";

                                if(p.productnumber != "")
                                {
                                    cmd = new SqlCommand("select type,[values],qty from SKUS where SKU like @sku", cn);
                                    cmd.Parameters.AddWithValue("@sku", p.productnumber);
                                    cmd.ExecuteNonQuery();
                                    dr = cmd.ExecuteReader();
                                    if(dr.Read())
                                    {
                                        do
                                        {
                                            //lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"green\">Product:</font> " + p.name + " <b>(" + detail.quantity.Value + ")</b>";
                                            string prod = p.productnumber.ToUpper();
                                            if(hshCounts.Contains(prod))
                                            {
                                                hshCounts[prod] = (decimal)hshCounts[prod] + detail.quantity.Value;
                                            }
                                            else
                                            {
                                                hshCounts.Add(prod, detail.quantity.Value);
                                            }

                                            string typename = "";
                                            switch(dr.GetInt32(0))
                                            {
                                                case 1:
                                                    typename = "Application";
                                                    break;
                                                case 2:
                                                    typename = "CAL";
                                                    break;
                                                case 3:
                                                    typename = "Publisher";
                                                    break;
                                                case 4:
                                                    typename = "Outlook Pub";
                                                    break;
                                                case 5:
                                                    typename = "Server";
                                                    break;
                                                case 6:
                                                    typename = "PortfolioEngine";
                                                    break;
                                                case 10:
                                                    typename = "MTCE";
                                                    break;
                                                case 11:
                                                    typename = "MTCE+";
                                                    break;
                                                case 20:
                                                    typename = "TRIAL";
                                                    break;
                                            };

                                            dt.Rows.Add(new string[] { p.name + "(" + p.productnumber + ")", p.productnumber, dr.GetDouble(2).ToString(), dr.GetInt32(0).ToString(), typename, dr.GetString(1), detail.quantity.Value.ToString() });
                                        } while(dr.Read());
                                    }
                                    else
                                    {
                                        lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=\"red\">Product:</font> " + p.name + " <b>(" + detail.quantity.Value + ") Unable to find SKU</b>";
                                    }
                                }
                                dr.Close();
                            }
                        }

                        //lblProcess.Text += "<Br><br><b>Creating Keys:</b>";

                        GridView2.DataSource = dt;
                        GridView2.DataBind();

                        cmd = new SqlCommand("DELETE from PRODUCTKEYS where crminvoiceuid=@invoiceid", cn);
                        cmd.Parameters.AddWithValue("@invoiceid", invoice.invoiceid.Value);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("DELETE from TOOLKITFEATURES where crminvoiceuid=@invoiceid", cn);
                        cmd.Parameters.AddWithValue("@invoiceid", invoice.invoiceid.Value);
                        cmd.ExecuteNonQuery();

                        foreach(DataRow drProc in dt.Rows)
                        {
                            switch(drProc["TYPE"].ToString())
                            {
                                case "1":
                                    cmd = new SqlCommand("delete from customer_applications where customer_id=@customerid and application_id=@applicationid", cn);
                                    cmd.Parameters.AddWithValue("@customerid", customerid);
                                    cmd.Parameters.AddWithValue("@applicationid", drProc["VALUES"].ToString());
                                    cmd.ExecuteNonQuery();

                                    cmd = new SqlCommand("INSERT INTO customer_applications (customer_id,application_id) VALUES (@customerid,@applicationid)", cn);
                                    cmd.Parameters.AddWithValue("@customerid", customerid);
                                    cmd.Parameters.AddWithValue("@applicationid", drProc["VALUES"].ToString());
                                    cmd.ExecuteNonQuery();
                                    break;
                                case "2":
                                    processCAL(drProc, customerid, account.name, cn, invoice);
                                    break;
                                case "3":
                                    processPub(drProc, customerid, account.name, cn, invoice);
                                    break;
                                case "4":
                                    //processOPub(drProc, customerid, account.name, cn, invoice);
                                    break;
                                case "5":
                                    processServer(drProc, customerid, account.name, cn, invoice);
                                    break;
                                case "6":
                                    //processPortfolio(drProc, customerid, account.name, cn, invoice);
                                    break;
                                case "10":
                                    processSup(drProc, customerid, account.name, cn, invoice);
                                    break;
                                case "11":
                                    processSup(drProc, customerid, account.name, cn, invoice);
                                    break;
                                case "20":
                                    process30(drProc, customerid, account.name, cn, invoice);
                                    break;
                            }
                        }

                        lblProcess.Text += "<br><br><b>Updating Invoice (Keys Sent)</b>";

                        invoice.new_keyssent.Value = true;

                        msCrm.Update(invoice);

                        cn.Close();

                        return;
                        #region server license
                        if(hshCounts.Contains("OS-PM-SVR"))
                        {
                            decimal quantity = (decimal)hshCounts["OS-PM-SVR"];
                            string supportdate = "";

                            if(hshCounts.Contains("OS-PM-SVR-AM"))
                            {
                                supportdate = DateTime.Now.ToShortDateString();
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " Server License(s) with Annual Maintenance";
                            }
                            else
                            {
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " Server License(s)";
                            }


                            string key = account.name + "\n0,1,2,5\n0\n" + DateTime.Now.ToShortDateString() + "\nNA" + "\n" + quantity;

                            key = Encrypt(key, "jLHKJH5416FL>1dcv3#I");

                            cmd = new SqlCommand("insert into toolkitfeatures (customer_id,featurekey,licenseqty,supportdate,supportyears,crminvoiceuid) VALUES (@customer_id,@featurekey,@licenseqty,@supportdate,@supportyears,@crminvoiceuid)", cn);
                            cmd.Parameters.AddWithValue("@customer_id", customerid);
                            cmd.Parameters.AddWithValue("@featurekey", key);
                            cmd.Parameters.AddWithValue("@licenseqty", 1);

                            if(supportdate != "")
                            {
                                cmd.Parameters.AddWithValue("@supportdate", supportdate);
                                cmd.Parameters.AddWithValue("@supportyears", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@supportdate", DBNull.Value);
                                cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);
                            }


                            cmd.Parameters.AddWithValue("@crminvoiceuid", invoice.invoiceid.Value);
                            cmd.ExecuteNonQuery();

                        }
                        #endregion

                        #region 30 day eval
                        if(hshCounts.Contains("TRIAL30"))
                        {
                            decimal quantity = (decimal)hshCounts["TRIAL30"];
                            string supportdate = "";

                            lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " 30 day trial(s)";

                            string key = account.name + "\n0,1,2,5\n25\n" + DateTime.Now.ToShortDateString() + "\n" + DateTime.Now.AddMonths(1).ToShortDateString();

                            key = Encrypt(key, "jLHKJH5416FL>1dcv3#I");

                            cmd = new SqlCommand("insert into toolkitfeatures (customer_id,featurekey,licenseqty,supportdate,supportyears,crminvoiceuid) VALUES (@customer_id,@featurekey,@licenseqty,@supportdate,@supportyears,@crminvoiceuid)", cn);
                            cmd.Parameters.AddWithValue("@customer_id", customerid);
                            cmd.Parameters.AddWithValue("@featurekey", key);
                            cmd.Parameters.AddWithValue("@licenseqty", quantity);

                            if(supportdate != "")
                            {
                                cmd.Parameters.AddWithValue("@supportdate", supportdate);
                                cmd.Parameters.AddWithValue("@supportyears", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@supportdate", DBNull.Value);
                                cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);
                            }


                            cmd.Parameters.AddWithValue("@crminvoiceuid", invoice.invoiceid.Value);
                            cmd.ExecuteNonQuery();

                        }
                        #endregion

                        #region per user license
                        if(hshCounts.Contains("OS-PM-BASE"))
                        {
                            decimal quantity = 25;
                            string supportdate = "";

                            if(hshCounts.Contains("OS-PM-USER"))
                            {
                                quantity += (decimal)hshCounts["OS-PM-USER"];
                            }
                            if(hshCounts.Contains("OS-PM-BASE-AM"))
                            {
                                supportdate = DateTime.Now.ToShortDateString();
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " User License(s) with Annual Maintenance";
                            }
                            else
                            {
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " User License(s)";
                            }

                            string key = account.name + "\n0,1,2,5\n" + quantity + "\n" + DateTime.Now.ToShortDateString() + "\nNA";

                            key = Encrypt(key, "jLHKJH5416FL>1dcv3#I");

                            cmd = new SqlCommand("insert into toolkitfeatures (customer_id,featurekey,licenseqty,supportdate,supportyears,crminvoiceuid) VALUES (@customer_id,@featurekey,@licenseqty,@supportdate,@supportyears,@crminvoiceuid)", cn);
                            cmd.Parameters.AddWithValue("@customer_id", customerid);
                            cmd.Parameters.AddWithValue("@featurekey", key);
                            cmd.Parameters.AddWithValue("@licenseqty", 1);

                            if(supportdate != "")
                            {
                                cmd.Parameters.AddWithValue("@supportdate", supportdate);
                                cmd.Parameters.AddWithValue("@supportyears", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@supportdate", DBNull.Value);
                                cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);
                            }
                            cmd.Parameters.AddWithValue("@crminvoiceuid", invoice.invoiceid.Value);
                            cmd.ExecuteNonQuery();


                            key = getKey().Replace("-", "");
                            string code = genCode(account.name, key);

                            cmd = new SqlCommand("insert into productkeys (cdkey,activationcount,licensecount,customer_id,actkey,company,premiersupportdate,supportyears,crminvoiceuid) VALUES (@cdkey,0,@licensecount,@customer_id,@actkey,@company,@premiersupportdate,@supportyears,@crminvoiceuid)", cn);
                            cmd.Parameters.AddWithValue("@cdkey", key.Replace("-", ""));
                            cmd.Parameters.AddWithValue("@licensecount", quantity);
                            cmd.Parameters.AddWithValue("@customer_id", customerid);
                            cmd.Parameters.AddWithValue("@actkey", code);
                            cmd.Parameters.AddWithValue("@company", account.name);
                            if(supportdate != "")
                            {
                                cmd.Parameters.AddWithValue("@premiersupportdate", supportdate);
                                cmd.Parameters.AddWithValue("@supportyears", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@premiersupportdate", DBNull.Value);
                                cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);
                            }
                            cmd.Parameters.AddWithValue("@crminvoiceuid", invoice.invoiceid.Value);
                            cmd.ExecuteNonQuery();
                        }
                        #endregion

                        #region per user license
                        if(hshCounts.Contains("OS-PM-USER") && !hshCounts.Contains("OS-PM-BASE"))
                        {
                            decimal quantity = (decimal)hshCounts["OS-PM-USER"];
                            string supportdate = "";

                            if(hshCounts.Contains("OS-PM-USER-AM"))
                            {
                                supportdate = DateTime.Now.ToShortDateString();
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " User License(s) with Annual Maintenance";
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " Publisher License(s) with Annual Maintenance";
                            }
                            else
                            {
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " User License(s)";
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " Publisher License(s)";
                            }

                            string key = account.name + "\n0,1,2,5\n" + quantity + "\n" + DateTime.Now.ToShortDateString() + "\nNA";

                            key = Encrypt(key, "jLHKJH5416FL>1dcv3#I");

                            cmd = new SqlCommand("insert into toolkitfeatures (customer_id,featurekey,licenseqty,supportdate,supportyears,crminvoiceuid) VALUES (@customer_id,@featurekey,@licenseqty,@supportdate,@supportyears,@crminvoiceuid)", cn);
                            cmd.Parameters.AddWithValue("@customer_id", customerid);
                            cmd.Parameters.AddWithValue("@featurekey", key);
                            cmd.Parameters.AddWithValue("@licenseqty", 1);

                            if(supportdate != "")
                            {
                                cmd.Parameters.AddWithValue("@supportdate", supportdate);
                                cmd.Parameters.AddWithValue("@supportyears", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@supportdate", DBNull.Value);
                                cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);
                            }
                            cmd.Parameters.AddWithValue("@crminvoiceuid", invoice.invoiceid.Value);
                            cmd.ExecuteNonQuery();



                            key = getKey().Replace("-", "");
                            string code = genCode(account.name, key);

                            cmd = new SqlCommand("insert into productkeys (cdkey,activationcount,licensecount,customer_id,actkey,company,premiersupportdate,supportyears,crminvoiceuid) VALUES (@cdkey,0,@licensecount,@customer_id,@actkey,@company,@premiersupportdate,@supportyears,@crminvoiceuid)", cn);
                            cmd.Parameters.AddWithValue("@cdkey", key.Replace("-", ""));
                            cmd.Parameters.AddWithValue("@licensecount", quantity);
                            cmd.Parameters.AddWithValue("@customer_id", customerid);
                            cmd.Parameters.AddWithValue("@actkey", code);
                            cmd.Parameters.AddWithValue("@company", account.name);
                            if(supportdate != "")
                            {
                                cmd.Parameters.AddWithValue("@premiersupportdate", supportdate);
                                cmd.Parameters.AddWithValue("@supportyears", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@premiersupportdate", DBNull.Value);
                                cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);
                            }
                            cmd.Parameters.AddWithValue("@crminvoiceuid", invoice.invoiceid.Value);
                            cmd.ExecuteNonQuery();
                        }
                        #endregion

                        #region timesheet with epmlive
                        if(hshCounts.Contains("OS-PM-USER-TM"))
                        {
                            decimal quantity = (decimal)hshCounts["OS-PM-USER-TM"];
                            string supportdate = "";

                            if(hshCounts.Contains("OS-PM-USER-TM-AM"))
                            {
                                supportdate = DateTime.Now.ToShortDateString();
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " Timesheet w/ Core User License(s) with Annual Maintenance";
                            }
                            else
                            {
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " Timesheet w/ Core User License(s)";
                            }

                            string key = account.name + "\n3\n" + quantity + "\n" + DateTime.Now.ToShortDateString() + "\nNA";

                            key = Encrypt(key, "jLHKJH5416FL>1dcv3#I");

                            cmd = new SqlCommand("insert into toolkitfeatures (customer_id,featurekey,licenseqty,supportdate,supportyears,crminvoiceuid) VALUES (@customer_id,@featurekey,@licenseqty,@supportdate,@supportyears,@crminvoiceuid)", cn);
                            cmd.Parameters.AddWithValue("@customer_id", customerid);
                            cmd.Parameters.AddWithValue("@featurekey", key);
                            cmd.Parameters.AddWithValue("@licenseqty", 1);

                            if(supportdate != "")
                            {
                                cmd.Parameters.AddWithValue("@supportdate", supportdate);
                                cmd.Parameters.AddWithValue("@supportyears", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@supportdate", DBNull.Value);
                                cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);
                            }
                            cmd.Parameters.AddWithValue("@crminvoiceuid", invoice.invoiceid.Value);
                            cmd.ExecuteNonQuery();
                        }
                        #endregion

                        #region timesheet without epmlive
                        if(hshCounts.Contains("OS-TM-BASE"))
                        {
                            decimal quantity = 25;
                            string supportdate = "";

                            if(hshCounts.Contains("OS-TM-USER"))
                            {
                                quantity += (decimal)hshCounts["OS-TM-USER"];
                            }
                            if(hshCounts.Contains("OS-TM-BASE-AM"))
                            {
                                supportdate = DateTime.Now.ToShortDateString();
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " Timesheet w/o Core User License(s) with Annual Maintenance";
                            }
                            else
                            {
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " Timesheet w/o Core User License(s)";
                            }

                            string key = account.name + "\n3\n" + quantity + "\n" + DateTime.Now.ToShortDateString() + "\nNA";

                            key = Encrypt(key, "jLHKJH5416FL>1dcv3#I");

                            cmd = new SqlCommand("insert into toolkitfeatures (customer_id,featurekey,licenseqty,supportdate,supportyears,crminvoiceuid) VALUES (@customer_id,@featurekey,@licenseqty,@supportdate,@supportyears,@crminvoiceuid)", cn);
                            cmd.Parameters.AddWithValue("@customer_id", customerid);
                            cmd.Parameters.AddWithValue("@featurekey", key);
                            cmd.Parameters.AddWithValue("@licenseqty", 1);

                            if(supportdate != "")
                            {
                                cmd.Parameters.AddWithValue("@supportdate", supportdate);
                                cmd.Parameters.AddWithValue("@supportyears", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@supportdate", DBNull.Value);
                                cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);
                            }
                            cmd.Parameters.AddWithValue("@crminvoiceuid", invoice.invoiceid.Value);
                            cmd.ExecuteNonQuery();
                        }
                        #endregion

                        #region dev license
                        if(hshCounts.Contains("OS-DEV"))
                        {
                            decimal quantity = (decimal)hshCounts["OS-DEV"];
                            string supportdate = "";

                            if(hshCounts.Contains("OS-DEV-AM"))
                            {
                                supportdate = DateTime.Now.ToShortDateString();
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " Dev License(s) with Annual Maintenance";
                            }
                            else
                            {
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " Dev License(s)";
                            }


                            string key = account.name + "\n0,1,2\n10\n" + DateTime.Now.ToShortDateString() + "\nNA";

                            key = Encrypt(key, "jLHKJH5416FL>1dcv3#I");

                            cmd = new SqlCommand("insert into toolkitfeatures (customer_id,featurekey,licenseqty,supportdate,supportyears,crminvoiceuid) VALUES (@customer_id,@featurekey,@licenseqty,@supportdate,@supportyears,@crminvoiceuid)", cn);
                            cmd.Parameters.AddWithValue("@customer_id", customerid);
                            cmd.Parameters.AddWithValue("@featurekey", key);
                            cmd.Parameters.AddWithValue("@licenseqty", quantity);

                            if(supportdate != "")
                            {
                                cmd.Parameters.AddWithValue("@supportdate", supportdate);
                                cmd.Parameters.AddWithValue("@supportyears", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@supportdate", DBNull.Value);
                                cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);
                            }

                            cmd.Parameters.AddWithValue("@crminvoiceuid", invoice.invoiceid.Value);
                            cmd.ExecuteNonQuery();

                        }
                        #endregion

                        #region Publisher
                        if(hshCounts.Contains("PP1A50"))
                        {

                            decimal quantity = (decimal)hshCounts["PP1A50"];
                            string supportdate = "";

                            if(hshCounts.Contains("PPSM1A"))
                            {
                                supportdate = DateTime.Now.ToShortDateString();
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " Publisher License(s) with Annual Maintenance";
                            }
                            else
                            {
                                lblProcess.Text += "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Adding " + quantity + " Publisher License(s)";
                            }

                            string key = getKey().Replace("-", "");
                            string code = genCode(account.name, key);

                            cmd = new SqlCommand("insert into productkeys (cdkey,activationcount,licensecount,customer_id,actkey,company,premiersupportdate,supportyears,crminvoiceuid) VALUES (@cdkey,0,@licensecount,@customer_id,@actkey,@company,@premiersupportdate,@supportyears,@crminvoiceuid)", cn);
                            cmd.Parameters.AddWithValue("@cdkey", key.Replace("-", ""));
                            cmd.Parameters.AddWithValue("@licensecount", quantity);
                            cmd.Parameters.AddWithValue("@customer_id", customerid);
                            cmd.Parameters.AddWithValue("@actkey", code);
                            cmd.Parameters.AddWithValue("@company", account.name);
                            if(supportdate != "")
                            {
                                cmd.Parameters.AddWithValue("@premiersupportdate", supportdate);
                                cmd.Parameters.AddWithValue("@supportyears", 1);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@premiersupportdate", DBNull.Value);
                                cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);
                            }
                            cmd.Parameters.AddWithValue("@crminvoiceuid", invoice.invoiceid.Value);
                            cmd.ExecuteNonQuery();
                        }
                        #endregion

                        lblProcess.Text += "<br><br><b>Updating Invoice (Keys Sent)</b>";

                        invoice.new_keyssent.Value = true;

                        msCrm.Update(invoice);

                        cn.Close();

                        lblProcess.Text += "<br><Br><a target=\"_blank\" href=\"editcustomer.aspx?customer_id=" + customerid.ToString() + "\">[Go To Customer]</a>";
                    }
                }
            }
        }

        private void processCAL(DataRow dr, Guid customerid, string accountname, SqlConnection cn, MSCRM.invoice inv)
        {
            double quantity = 0;

            quantity = double.Parse(dr["DBQTY"].ToString()) * double.Parse(dr["ORDQTY"].ToString());

            string key = accountname + "\n" + dr["VALUES"].ToString() + "\n" + quantity + "\n" + DateTime.Now.ToShortDateString() + "\nNA";

            key = Encrypt(key, "jLHKJH5416FL>1dcv3#I");

            SqlCommand cmd = new SqlCommand("insert into toolkitfeatures (customer_id,featurekey,licenseqty,supportdate,supportyears,crminvoiceuid,crmorderuid) VALUES (@customer_id,@featurekey,@licenseqty,@supportdate,@supportyears,@crminvoiceuid,@crmorderuid)", cn);
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            cmd.Parameters.AddWithValue("@featurekey", key);
            cmd.Parameters.AddWithValue("@licenseqty", 10);

            cmd.Parameters.AddWithValue("@supportdate", DBNull.Value);
            cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);

            cmd.Parameters.AddWithValue("@crminvoiceuid", inv.invoiceid.Value);
            cmd.Parameters.AddWithValue("@crmorderuid", inv.salesorderid.Value);

            cmd.ExecuteNonQuery();
        }

        private void processServer(DataRow dr, Guid customerid, string accountname, SqlConnection cn, MSCRM.invoice inv)
        {
            double quantity = 0;

            quantity = double.Parse(dr["DBQTY"].ToString()) * double.Parse(dr["ORDQTY"].ToString());

            string key = accountname + "\n" + dr["VALUES"].ToString() + "\n0\n" + DateTime.Now.ToShortDateString() + "\nNA\n" + quantity;

            key = Encrypt(key, "jLHKJH5416FL>1dcv3#I");

            SqlCommand cmd = new SqlCommand("insert into toolkitfeatures (customer_id,featurekey,licenseqty,supportdate,supportyears,crminvoiceuid,crmorderuid) VALUES (@customer_id,@featurekey,@licenseqty,@supportdate,@supportyears,@crminvoiceuid,@crmorderuid)", cn);
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            cmd.Parameters.AddWithValue("@featurekey", key);
            cmd.Parameters.AddWithValue("@licenseqty", 10);

            cmd.Parameters.AddWithValue("@supportdate", DBNull.Value);
            cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);

            cmd.Parameters.AddWithValue("@crminvoiceuid", inv.invoiceid.Value);
            cmd.Parameters.AddWithValue("@crmorderuid", inv.salesorderid.Value);

            cmd.ExecuteNonQuery();
        }

        private void process30(DataRow dr, Guid customerid, string accountname, SqlConnection cn, MSCRM.invoice inv)
        {
            double quantity = 0;

            quantity = double.Parse(dr["DBQTY"].ToString()) * double.Parse(dr["ORDQTY"].ToString());

            string key = accountname + "\n" + dr["VALUES"].ToString() + "\n" + quantity + "\n" + DateTime.Now.ToShortDateString() + "\n" + DateTime.Now.AddMonths(1).ToShortDateString();

            key = Encrypt(key, "jLHKJH5416FL>1dcv3#I");

            SqlCommand cmd = new SqlCommand("insert into toolkitfeatures (customer_id,featurekey,licenseqty,supportdate,supportyears,crminvoiceuid,crmorderuid) VALUES (@customer_id,@featurekey,@licenseqty,@supportdate,@supportyears,@crminvoiceuid,@crmorderuid)", cn);
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            cmd.Parameters.AddWithValue("@featurekey", key);
            cmd.Parameters.AddWithValue("@licenseqty", 1);

            cmd.Parameters.AddWithValue("@supportdate", DBNull.Value);
            cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);

            cmd.Parameters.AddWithValue("@crminvoiceuid", inv.invoiceid.Value);
            cmd.Parameters.AddWithValue("@crmorderuid", inv.salesorderid.Value);
            cmd.ExecuteNonQuery();
        }

        private void processPub(DataRow dr, Guid customerid, string accountname, SqlConnection cn, MSCRM.invoice inv)
        {
            double quantity = 0;

            quantity = double.Parse(dr["DBQTY"].ToString()) * double.Parse(dr["ORDQTY"].ToString());

            string key = getKey().Replace("-", "");
            string code = genCode(accountname, key);

            SqlCommand cmd = new SqlCommand("insert into productkeys (cdkey,activationcount,licensecount,customer_id,actkey,company,premiersupportdate,supportyears,crminvoiceuid,crmorderuid) VALUES (@cdkey,0,@licensecount,@customer_id,@actkey,@company,@premiersupportdate,@supportyears,@crminvoiceuid,@crmorderuid)", cn);
            cmd.Parameters.AddWithValue("@cdkey", key.Replace("-", ""));
            cmd.Parameters.AddWithValue("@licensecount", quantity);
            cmd.Parameters.AddWithValue("@customer_id", customerid);
            cmd.Parameters.AddWithValue("@actkey", code);
            cmd.Parameters.AddWithValue("@company", accountname);

            cmd.Parameters.AddWithValue("@premiersupportdate", DBNull.Value);
            cmd.Parameters.AddWithValue("@supportyears", DBNull.Value);

            cmd.Parameters.AddWithValue("@crminvoiceuid", inv.invoiceid.Value);
            cmd.Parameters.AddWithValue("@crmorderuid", inv.salesorderid.Value);
            cmd.ExecuteNonQuery();

        }

        private void processSup(DataRow dr, Guid customerid, string accountname, SqlConnection cn, MSCRM.invoice inv)
        {
            //try
            {
                SqlCommand cmd = new SqlCommand("UPDATE PRODUCTKEYS set premiersupportdate=@dt,supportyears=1 where crmorderuid=@orderid", cn);
                cmd.Parameters.AddWithValue("@orderid", inv.salesorderid.Value);
                cmd.Parameters.AddWithValue("@dt", inv.new_invoicedate.date);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE TOOLKITFEATURES set supportdate=@dt,supportyears=1 where crmorderuid=@orderid", cn);
                cmd.Parameters.AddWithValue("@orderid", inv.salesorderid.Value);
                cmd.Parameters.AddWithValue("@dt", inv.new_invoicedate.date);
                cmd.ExecuteNonQuery();
            }
            //catch { }
        }

        private string getKey()
        {
            string key = "";
            Random rdm = new Random();
            for(int i = 0; i < 4; i++)
            {
                key += ((char)((short)'A' + rdm.Next(26))).ToString();
            }
            key += "-";
            for(int i = 0; i < 4; i++)
            {
                key += ((char)((short)'A' + rdm.Next(26))).ToString();
            }
            key += "-";
            for(int i = 0; i < 4; i++)
            {
                key += ((char)((short)'A' + rdm.Next(26))).ToString();
            }
            return key;
        }

        private static string genCode(string company, string cdKey)
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

        protected MSCRM.contact getContact(MSCRM.CrmService msCrm, Guid contactid)
        {
            try
            {
                MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

                cols.Attributes = new string[] { "firstname", "lastname", "emailaddress1", "department", "telephone1", "jobtitle", "address1_line1", "address1_line2", "address1_city", "address1_stateorprovince", "address1_country", "address1_postalcode" };

                MSCRM.contact c = (MSCRM.contact)msCrm.Retrieve(MSCRM.EntityName.contact.ToString(), contactid, cols);

                return c;
            }
            catch { }
            return null;
        }

        protected MSCRM.account getAccount(MSCRM.CrmService msCrm, Guid accountid)
        {
            try
            {
                MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

                cols.Attributes = new string[] { "name", "primarycontactid" };

                MSCRM.account c = (MSCRM.account)msCrm.Retrieve(MSCRM.EntityName.account.ToString(), accountid, cols);

                return c;
            }
            catch { }
            return null;
        }

        protected MSCRM.invoice getInvoice(MSCRM.CrmService msCrm, Guid orderid)
        {
            MSCRM.ColumnSet cols = new MSCRM.ColumnSet();
            // Set the properties of the ColumnSet.
            cols.Attributes = new string[] { "invoicenumber", "new_endcustomerid", "new_keyssent", "salesorderid", "new_invoicedate" };

            MSCRM.invoice c = (MSCRM.invoice)msCrm.Retrieve(MSCRM.EntityName.invoice.ToString(), orderid, cols);

            return c;
        }

        protected MSCRM.BusinessEntity[] findInvoices(MSCRM.CrmService msCrm)
        {
            try
            {
                // Create the ColumnSet that indicates the properties to be retrieved.
                MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

                // Set the properties of the ColumnSet.
                cols.Attributes = new string[] { "name", "invoicenumber" };

                MSCRM.ConditionExpression condition = new MSCRM.ConditionExpression();
                condition.AttributeName = "new_keyssent";
                condition.Operator = MSCRM.ConditionOperator.Equal;
                condition.Values = new string[] { "0" };

                MSCRM.ConditionExpression condition2 = new MSCRM.ConditionExpression();
                condition2.AttributeName = "new_ordertype";
                condition2.Operator = MSCRM.ConditionOperator.Equal;
                condition2.Values = new string[] { "1" };

                // Create the FilterExpression.
                MSCRM.FilterExpression filter = new MSCRM.FilterExpression();
                filter.FilterOperator = MSCRM.LogicalOperator.And;
                filter.Conditions = new MSCRM.ConditionExpression[] { condition };


                MSCRM.FilterExpression filter2 = new MSCRM.FilterExpression();
                filter2.FilterOperator = MSCRM.LogicalOperator.And;
                filter2.Conditions = new MSCRM.ConditionExpression[] { condition2 };

                // Create the QueryExpression object.
                MSCRM.LinkEntity link = new MSCRM.LinkEntity();
                link.LinkFromEntityName = MSCRM.EntityName.invoice.ToString();
                link.LinkFromAttributeName = "salesorderid";
                link.LinkToEntityName = MSCRM.EntityName.salesorder.ToString();
                link.LinkToAttributeName = "salesorderid";
                link.LinkCriteria = filter2;

                MSCRM.QueryExpression query = new MSCRM.QueryExpression();
                query.EntityName = MSCRM.EntityName.invoice.ToString();
                query.ColumnSet = cols;
                query.Criteria = filter;
                query.LinkEntities = new MSCRM.LinkEntity[] { link };

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

        protected MSCRM.BusinessEntity[] getInvoiceDetail(MSCRM.CrmService msCrm, Guid invoiceid)
        {
            try
            {
                // Create the ColumnSet that indicates the properties to be retrieved.
                MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

                // Set the properties of the ColumnSet.
                cols.Attributes = new string[] { "productid", "quantity", "productdescription" };

                // Create the ConditionExpression.
                MSCRM.ConditionExpression condition = new MSCRM.ConditionExpression();
                condition.AttributeName = "invoiceid";
                condition.Operator = MSCRM.ConditionOperator.Equal;
                condition.Values = new string[] { invoiceid.ToString() };

                // Create the FilterExpression.
                MSCRM.FilterExpression filter = new MSCRM.FilterExpression();
                filter.FilterOperator = MSCRM.LogicalOperator.And;
                filter.Conditions = new MSCRM.ConditionExpression[] { condition };

                // Create the QueryExpression object.
                MSCRM.QueryExpression query = new MSCRM.QueryExpression();
                query.EntityName = MSCRM.EntityName.invoicedetail.ToString();
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

            cols.Attributes = new string[] { "name", "productnumber" };

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

        protected MSCRM.product getProduct(MSCRM.CrmService msCrm, Guid productId)
        {
            MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

            cols.Attributes = new string[] { "productnumber", "name" };

            MSCRM.product p = (MSCRM.product)msCrm.Retrieve(MSCRM.EntityName.product.ToString(), productId, cols);

            return p;
        }

        public string Encrypt(string plainText, string passPhrase)
        {
            try
            {
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

                byte[] keyBytes = password.GetBytes(keySize / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();

                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();

                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                             encryptor,
                                                             CryptoStreamMode.Write);

                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                string cipherText = Convert.ToBase64String(cipherTextBytes);
                return cipherText;
            }
            catch { return "ERROR"; }
        }
    }
}