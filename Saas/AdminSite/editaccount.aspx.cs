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
using System.Data.SqlClient;
using System.Text;

namespace AdminSite
{
    public partial class editaccount : System.Web.UI.Page
    {
        protected string strAccountId;
        protected string strTab;
        protected string strUid;

        protected int TotalTicketUsage;
        protected int TotalTickets;
        protected StringBuilder sbOrders = new StringBuilder();
        protected bool usingNewBilling = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                strTab = Request["tab"].ToString();
            }
            catch { strTab = ""; }
            if(strTab == "")
                strTab = "1";

            if(!IsPostBack)
                fillGrid();
        }

        private string ordertabletop(bool isPE)
        {
            StringBuilder sbT = new StringBuilder();
            sbT.Append("<table width=\"100%\" border=\"0\" cellpadding=\"3\" style=\"border: #dedfde 1px solid; background-color: white; width: 100%;\" ><tr style=\"background-color: #6b696b; color: white; font-weight: bold;\"><td>Billing System</td><td>Ref #</td><td>Exp/Renewal Date</td><td>Users</td><td>Storage</td>");
            if(isPE )
                sbT.Append("<td>Projects</td>");
            
            sbT.Append("<td>Actions</td></tr>");

            return sbT.ToString();
        }

        private string ordertablebottom()
        {
            return "</table>";
        }

        private void fillGrid()
        {

            strAccountId = Request["account_id"];

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            if(Request["delorder"] != null && Request["delorder"] != "")
            {
                SqlCommand c = new SqlCommand("delete from orders where order_id=@order_id", cn);
                c.Parameters.AddWithValue("@order_id", Request["delorder"]);
                c.ExecuteNonQuery();

            }

            SqlCommand cmdGetSites = new SqlCommand("SELECT     account.lockusers, maxusers,crmaccountuid,account_id,billingtype, account.account_ref,monthsfree,account.dtcreated,accountdescription,partnerid,account.dedicated, dbo.USERS.*, dbo.BETA1Survey.project_version, dbo.BETA1Survey.sharepoint_version, dbo.BETA1Survey.products, dbo.BETA1Survey.comments FROM         dbo.USERS Left Outer JOIN dbo.BETA1Survey ON dbo.USERS.uid = dbo.BETA1Survey.uid Left Outer JOIN dbo.ACCOUNT ON dbo.USERS.uid = dbo.ACCOUNT.owner_id WHERE account_id like '" + Request["account_id"] + "'", cn);
            cmdGetSites.CommandType = CommandType.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmdGetSites);
            DataSet ds = new DataSet();
            da.Fill(ds);



            DataRow dr = ds.Tables[0].Rows[0];

            lblUsername.Text = dr["username"].ToString();
            lblEditEmail.Text = dr["email"].ToString();
            txtEditCompany.Text = dr["company"].ToString();
            txtEditDepartment.Text = dr["department"].ToString();
            txtEditFirstName.Text = dr["firstName"].ToString();
            txtEditLastName.Text = dr["lastName"].ToString();
            txtEditPhone.Text = dr["phone"].ToString();
            txtEditTitle.Text = dr["title"].ToString();

            try
            {
                chkLockUsers.Checked = bool.Parse(dr["lockusers"].ToString());
            }
            catch { }

            if(dr["dedicated"].ToString() == "True")
                chkDedicated.Checked = true;
            else
                chkDedicated.Checked = false;


            txtDesc.Text = dr["accountdescription"].ToString();
            txtPartnerId.Text = dr["partnerid"].ToString();

            lblAccountRef.Text = dr["account_ref"].ToString();

            txtMonthsFree.Text = dr["monthsfree"].ToString();
            txtTrialUsers.Text = dr["maxusers"].ToString();

            DateTime dtCreated = Convert.ToDateTime("1/1/1900");
            int months = 1;
            try
            {
                months = int.Parse(dr["monthsfree"].ToString());
            }
            catch { }
            try
            {
                dtCreated = Convert.ToDateTime(dr["dtcreated"].ToString());
            }
            catch { }

            lblExpiration.Text = dtCreated.AddMonths(months).ToShortDateString();

            ddlBillingType.SelectedValue = dr["billingType"].ToString();




            //=============Zuora Account============
            ZuoraHelper zuora = new ZuoraHelper();

            ZuoraAPI.QueryResult qrAccount = zuora.RunQuery("SELECT BillToId, ID from ACCOUNT where accountref__c = '" + lblAccountRef.Text + "'");

            if(qrAccount.records.Length > 0 && qrAccount.records[0] != null)
            {
                string accountid = qrAccount.records[0].Id;

                lblZuoraLink.Text = "<A target=\"_blank\" href=\"https://www.zuora.com/apps/CustomerAccount.do?method=view&id=" + accountid + "\">View Zuora Account</a>";
            }
            else
            {
                lblZuoraLink.Text = "<A target=\"_blank\" href=\"createzuoraaccount.aspx?accountid=" + strAccountId + "\">Create</a>";
            }
            //======================================



            cmdGetSites = new SqlCommand("Select * from CONTRACTLEVEL_TITLES", cn);
            cmdGetSites.CommandType = CommandType.Text;

            DataSet dsCLevels = new DataSet();
            SqlDataAdapter dac = new SqlDataAdapter(cmdGetSites);
            dac.Fill(dsCLevels);

            dsCLevels.Tables[0].Rows.Add(new object[] { "0", "Unknown" });


            bool bCanExtendMonths = Helper.checkPermissions(12, cn);
            bool bCanExtendUsers = Helper.checkPermissions(13, cn);

            foreach(DataRow drLevel in dsCLevels.Tables[0].Rows)
            {
                StringBuilder sbLevel = new StringBuilder();
                
                cmdGetSites = new SqlCommand("Select * from vwAccountOrders where account_ref=@accountref and contractlevel=@clevel", cn);
                cmdGetSites.CommandType = CommandType.Text;
                cmdGetSites.Parameters.AddWithValue("@AccountRef", lblAccountRef.Text);
                cmdGetSites.Parameters.AddWithValue("@clevel", drLevel["contractlevel"].ToString());
                //SqlDataReader drLevelOrders = cmdGetSites.ExecuteReader();
                SqlDataAdapter da2 = new SqlDataAdapter(cmdGetSites);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);

                foreach(DataRow drLevelOrders in ds2.Tables[0].Rows)
                {

                    if(int.Parse(drLevelOrders[10].ToString()) != 2)
                        usingNewBilling = false;

                    sbLevel.Append("<tr style=\"background-color: #f7f7de;\">");
                    sbLevel.Append("<td>");
                    sbLevel.Append(drLevelOrders[12].ToString());
                    sbLevel.Append("</td>");
                    if(int.Parse(drLevelOrders[10].ToString()) == 2)
                    {
                        sbLevel.Append("<td><a target=\"_blank\" href=\"https://www.zuora.com/apps/Subscription.do?method=view&id=");
                        sbLevel.Append(drLevelOrders[0].ToString());
                        sbLevel.Append("\">");
                        sbLevel.Append("View");
                        sbLevel.Append("</a></td>");
                    }
                    else
                    {
                        sbLevel.Append("<td>");
                        sbLevel.Append(drLevelOrders[0].ToString());
                        sbLevel.Append("</td>");
                    }
                    sbLevel.Append("<td>");
                    sbLevel.Append(drLevelOrders[2].ToString());
                    sbLevel.Append("</td>");

                    sbLevel.Append("<td>");

                    bool bHasDetail = false;
                    //if(usingNewBilling)
                    {
                        //sbLevel.Append(drLevelOrders.GetString(16) + ": " + drLevelOrders.GetInt32(15));

                        cmdGetSites = new SqlCommand(@"SELECT     dbo.ORDERDETAIL.detail_type_id, dbo.ORDERDETAIL.quantity, dbo.DETAILTYPES.detail_name
                                                    FROM         dbo.ORDERDETAIL INNER JOIN 
                                                        dbo.DETAILTYPES ON dbo.ORDERDETAIL.detail_type_id = dbo.DETAILTYPES.detail_type_id where order_id=@orderid", cn);
                        cmdGetSites.CommandType = CommandType.Text;
                        cmdGetSites.Parameters.AddWithValue("@orderid", drLevelOrders[13].ToString());
                        SqlDataReader drreader = cmdGetSites.ExecuteReader();
                        while(drreader.Read())
                        {
                            sbLevel.Append(drreader.GetString(2) + ": " + drreader.GetInt32(1).ToString() + "<br>");
                            bHasDetail = true;
                        }
                        drreader.Close();
                    }

                    if(!bHasDetail)
                    {
                        if(int.Parse(drLevelOrders[1].ToString()) == -1)
                            sbLevel.Append("Unlimited");
                        else
                            sbLevel.Append(drLevelOrders[1].ToString());
                    }

                    sbLevel.Append("</td>");

                    sbLevel.Append("<td>");
                    if(int.Parse(drLevelOrders[6].ToString()) == -1)
                        sbLevel.Append("Unlimited");
                    else
                        sbLevel.Append(drLevelOrders[6].ToString());
                    sbLevel.Append("GB </td>");

                    if(drLevel["contractlevel"].ToString() == "3")
                    {
                        sbLevel.Append("<td>");
                        if(int.Parse(drLevelOrders[7].ToString()) == -1)
                            sbLevel.Append("Unlimited");
                        else
                            sbLevel.Append(drLevelOrders[7].ToString());
                        sbLevel.Append("</td>");
                    }
                    sbLevel.Append("<td>");
                    sbLevel.Append("<a href=\"editaccount.aspx?account_id=" + strAccountId + "&delorder=" + drLevelOrders[13].ToString() + "&tab=3\">Delete</a>");

                    try{
                        if(int.Parse(drLevelOrders[10].ToString()) == 4)
                        {
                            if(bCanExtendMonths)
                                sbLevel.Append("<br><a href=\"extendtrial.aspx?orderid=" + drLevelOrders[13].ToString() + "&account_id=" + strAccountId + "\">Extend 1 Month</a>");
                            if(bCanExtendUsers)
                                sbLevel.Append("<br><a href=\"adduserstotrial.aspx?orderid=" + drLevelOrders[13].ToString() + "&account_id=" + strAccountId + "\">Update Quantity</a>");
                        }
                    }catch{}
                    sbLevel.Append("</td>");
                    sbLevel.Append("</tr>");
                }
                //drLevelOrders.Close();

                if(sbLevel.ToString() != "")
                {
                    sbOrders.Append("<b>");
                    sbOrders.Append(drLevel["TITLE"].ToString());
                    sbOrders.Append("</b><br>");
                    if(drLevel["contractlevel"].ToString() == "3")
                        sbOrders.Append(ordertabletop(true));
                    else
                        sbOrders.Append(ordertabletop(false));

                    sbOrders.Append(sbLevel);
                    sbOrders.Append(ordertablebottom());
                    sbOrders.Append("<br><br>");
                }
            }



            //Plimus
            DataTable dtOrders = new DataTable();
            dtOrders.Columns.Add("dtcreated");
            dtOrders.Columns.Add("expiration");
            dtOrders.Columns.Add("quantity");
            dtOrders.Columns.Add("order_id");
            dtOrders.Columns.Add("linked");
            dtOrders.Columns.Add("ref");
            dtOrders.Columns.Add("type");
            dtOrders.Columns.Add("version");
            dtOrders.Columns.Add("r_order_id");

            cmdGetSites = new SqlCommand("SELECT crmorderuid,dtcreated,expiration,quantity,plimusreferencenumber,plimusAccountId,version,order_id from orders where (billingsystem is null or billingsystem <> 2) and account_ref=" + lblAccountRef.Text, cn);
            cmdGetSites.CommandType = CommandType.Text;
            SqlDataReader drOrders = cmdGetSites.ExecuteReader();

            while(drOrders.Read())
            {
                string type = "";
                switch(drOrders.GetInt32(6))
                {
                    case 2:
                        type = "Online";
                        break;
                    case 6:
                        type = "Tickets";
                        break;
                };

                if(drOrders.IsDBNull(0))
                {

                    if(drOrders.GetInt32(5) > 1)
                    {
                        dtOrders.Rows.Add(new object[] { drOrders.GetDateTime(1).ToShortDateString(), drOrders.GetDateTime(2).ToShortDateString(), drOrders.GetInt32(3).ToString(), "", "none", drOrders.GetString(4), "Plimus", type, drOrders.GetGuid(7).ToString() });
                    }
                    else
                    {
                        dtOrders.Rows.Add(new object[] { drOrders.GetDateTime(1).ToShortDateString(), drOrders.GetDateTime(2).ToShortDateString(), drOrders.GetInt32(3).ToString(), "", "none", drOrders.GetString(4), "Unknown", type, drOrders.GetGuid(7).ToString() });
                    }
                }
                else
                {
                    dtOrders.Rows.Add(new object[] { drOrders.GetDateTime(1).ToShortDateString(), drOrders.GetDateTime(2).ToShortDateString(), drOrders.GetInt32(3).ToString(), drOrders.GetGuid(0).ToString(), "", drOrders.GetString(4), "CRM", type, drOrders.GetGuid(7).ToString() });
                }
            }

            drOrders.Close();
            
            GridView2.DataSource = dtOrders;
            GridView2.DataBind();
            //======================================================================


            cmdGetSites = new SqlCommand("SELECT * from vwOwnedSites where account_id='" + Request["account_id"] + "'", cn);
            cmdGetSites.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            gvSitesOwn.DataSource = ds;
            gvSitesOwn.DataBind();

            cmdGetSites = new SqlCommand("SELECT sitename,siteurl,timecreated from ACCOUNT_EXTERNAL_SITES where account_id='" + Request["account_id"] + "'", cn);
            cmdGetSites.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            gvExternalSites.DataSource = ds;
            gvExternalSites.DataBind();

            cmdGetSites = new SqlCommand("SELECT * from vwSitesIAmIn where uid='" + dr["uid"] + "'", cn);
            cmdGetSites.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            gvSites.DataSource = ds;
            gvSites.DataBind();


            cmdGetSites = new SqlCommand("SELECT * from vwAccountUsers where account_id='" + Request["account_id"] + "' and deleted is null", cn);
            cmdGetSites.CommandType = CommandType.Text;
            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            gvUsers.DataSource = ds;
            gvUsers.DataBind();

            TotalTicketUsage = ds.Tables[0].Rows.Count;

            cmdGetSites = new SqlCommand("SELECT sum(quantity) from orders where account_ref='" + dr["account_ref"] + "' and version = 6", cn);
            cmdGetSites.CommandType = CommandType.Text;
            SqlDataReader drTickets = cmdGetSites.ExecuteReader();

            if(drTickets.Read() && !drTickets.IsDBNull(0))
                TotalTickets = drTickets.GetInt32(0);
            else
                TotalTickets = 0;

            drTickets.Close();


            cmdGetSites = new SqlCommand("select * from enterprise_sites where owner=@owner", cn);
            cmdGetSites.Parameters.AddWithValue("@owner", dr["uid"].ToString());
            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            foreach(DataRow drSite in ds.Tables[0].Rows)
            {

                cmdGetSites = new SqlCommand("spGetEnterpriseUsers", cn);
                cmdGetSites.CommandType = CommandType.StoredProcedure;
                cmdGetSites.Parameters.AddWithValue("@euid", drSite["uid"].ToString());
                da = new SqlDataAdapter(cmdGetSites);
                ds = new DataSet();
                da.Fill(ds);

                Label lbl = new Label();
                lbl.Text = "<br /><b>Project Server Users (" + drSite["url"].ToString() + ")</b><br />";
                pnlEntUsers.Controls.Add(lbl);

                GridView gv = new GridView();
                gv.Width = new Unit(96, UnitType.Percentage);
                gv.RowStyle.HorizontalAlign = HorizontalAlign.Left;
                gv.AutoGenerateColumns = false;
                gv.CellPadding = 4;
                gv.ForeColor = System.Drawing.Color.Black;
                gv.GridLines = GridLines.Vertical;
                gv.BackColor = System.Drawing.Color.White;
                gv.BorderColor = System.Drawing.ColorTranslator.FromHtml("#DEDFDE");
                gv.BorderWidth = new Unit(1, UnitType.Pixel);
                gv.FooterStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#CCCC99");
                gv.RowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7F7DE");
                gv.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#6B696B");
                gv.HeaderStyle.Font.Bold = true;
                gv.HeaderStyle.ForeColor = System.Drawing.Color.White;
                gv.AlternatingRowStyle.BackColor = System.Drawing.Color.White;

                BoundField bf = new BoundField();
                bf.DataField = "name";
                bf.HeaderText = "Name";
                gv.Columns.Add(bf);

                BoundField bf2 = new BoundField();
                bf2.DataField = "email";
                bf2.HeaderText = "Email";
                gv.Columns.Add(bf2);

                BoundField bf3 = new BoundField();
                bf3.DataField = "username";
                bf3.HeaderText = "Username";
                gv.Columns.Add(bf3);

                BoundField bf4 = new BoundField();
                bf4.DataField = "dtadded";
                bf4.HeaderText = "Added";
                bf4.DataFormatString = "{0:d}";
                gv.Columns.Add(bf3);

                TemplateField tf = new TemplateField();
                tf.HeaderText = "View";
                tf.ItemTemplate = new DynamicGridViewURLTemplate("uid", DataControlRowType.DataRow);
                gv.Columns.Add(tf);

                //gv.DataSource = ds.Tables[0];
                //gv.DataBind();

                //pnlEntUsers.Controls.Add(gv);

            }

            ddlBillingType.Enabled = false;


            cmdGetSites = new SqlCommand("SP_GetAccountLog", cn);
            cmdGetSites.CommandType = CommandType.StoredProcedure;
            cmdGetSites.Parameters.AddWithValue("@accountid", Request["account_id"]);
            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            gvLog.DataSource = ds.Tables[0];
            gvLog.DataBind();

            
            strUid = dr["uid"].ToString();

            cn.Close();
        }

        

        protected void gvTickets_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "remove")
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM ACCOUNT_TICKETS WHERE account_id='" + Request["account_id"] + "' and ticket_number='" + e.CommandArgument + "'", cn);
                cmd.ExecuteNonQuery();

                cn.Close();

                Response.Redirect("editaccount.aspx?account_id=" + Request["account_id"] + "&tab=8");

            }
        }

        protected MSCRM.salesorder getOrder(MSCRM.CrmService msCrm, Guid orderid)
        {
            MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

            cols.Attributes = new string[] { "name", "salesorderid", "customerid", "new_ordertype", "ordernumber", "new_monthstobill", "new_recurring" };

            MSCRM.salesorder c = (MSCRM.salesorder)msCrm.Retrieve(MSCRM.EntityName.salesorder.ToString(), orderid, cols);

            return c;
        }

        protected MSCRM.BusinessEntity[] findInvoices(MSCRM.CrmService msCrm, string accountid)
        {
            try
            {
                // Create the ColumnSet that indicates the properties to be retrieved.
                MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

                // Set the properties of the ColumnSet.
                cols.Attributes = new string[] { "name", "totalamount", "invoicenumber", "createdon", "salesorderid", "new_plimusreference" };

                MSCRM.ConditionExpression condition = new MSCRM.ConditionExpression();
                condition.AttributeName = "customerid";
                condition.Operator = MSCRM.ConditionOperator.Equal;
                condition.Values = new string[] { accountid };

                // Create the FilterExpression.
                MSCRM.FilterExpression filter = new MSCRM.FilterExpression();
                filter.FilterOperator = MSCRM.LogicalOperator.And;
                filter.Conditions = new MSCRM.ConditionExpression[] { condition };

                // Create the QueryExpression object.
                MSCRM.QueryExpression query = new MSCRM.QueryExpression();

                // Set the properties of the QueryExpression object.
                query.EntityName = MSCRM.EntityName.invoice.ToString();
                query.ColumnSet = cols;
                query.Criteria = filter;

                // Retrieve the contacts.
                MSCRM.BusinessEntityCollection invoices = msCrm.RetrieveMultiple(query);

                return invoices.BusinessEntities;
            }
            catch(System.Web.Services.Protocols.SoapException ex)
            {
                Response.Write("Error Finding Orders: " + ex.Message + ex.Detail.OuterXml);
            }
            return null;
        }

        protected MSCRM.account getAccount(MSCRM.CrmService msCrm, Guid accountid)
        {
            MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

            cols.Attributes = new string[] { "name", "primarycontactid" };

            MSCRM.account c = (MSCRM.account)msCrm.Retrieve(MSCRM.EntityName.account.ToString(), accountid, cols);

            return c;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                pnlEditFailure.Visible = false;

                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
                cn.Open();

                SqlCommand cmdUpdateUser;

                //cmdUpdateUser = new SqlCommand("UPDATE USERS set firstName=@first, lastName=@last, company=@company, title=@title, department=@department,phone=@phone WHERE uid like '" + Request["uid"] + "'", cn);
                //cmdUpdateUser.CommandType = CommandType.Text;
                //cmdUpdateUser.Parameters.AddWithValue("@first", txtEditFirstName.Text);
                //cmdUpdateUser.Parameters.AddWithValue("@last", txtEditLastName.Text);
                //cmdUpdateUser.Parameters.AddWithValue("@company", txtEditCompany.Text);
                //cmdUpdateUser.Parameters.AddWithValue("@title", txtEditTitle.Text);
                //cmdUpdateUser.Parameters.AddWithValue("@department", txtEditDepartment.Text);
                //cmdUpdateUser.Parameters.AddWithValue("@phone", txtEditPhone.Text);

                //cmdUpdateUser.ExecuteNonQuery();

                cmdUpdateUser = new SqlCommand("UPDATE ACCOUNT set monthsfree=@monthsfree,maxusers=@maxusers,partnerid=@partnerid,dedicated=@dedicated,lockusers=@lockusers,accountdescription=@accountdescription WHERE account_ref = " + lblAccountRef.Text, cn);
                cmdUpdateUser.CommandType = CommandType.Text;
                cmdUpdateUser.Parameters.AddWithValue("@monthsfree", txtMonthsFree.Text);
                cmdUpdateUser.Parameters.AddWithValue("@maxusers", txtTrialUsers.Text);
                cmdUpdateUser.Parameters.AddWithValue("@dedicated", chkDedicated.Checked);
                cmdUpdateUser.Parameters.AddWithValue("@lockusers", chkLockUsers.Checked);
                cmdUpdateUser.Parameters.AddWithValue("@accountdescription", txtDesc.Text);
                
                if(txtPartnerId.Text != "")
                    cmdUpdateUser.Parameters.AddWithValue("@partnerid", txtPartnerId.Text);
                else
                    cmdUpdateUser.Parameters.AddWithValue("@partnerid", DBNull.Value);

                cmdUpdateUser.ExecuteNonQuery();




                cn.Close();

                pnlEditSuccess.Visible = true;

                Response.Redirect("editaccount.aspx?account_id=" + Request["account_id"]);
            }
            catch(Exception ex)
            {
                pnlEditFailure.Visible = true;
                lblError.Text = ex.Message.ToString() + "<br>" + ex.StackTrace;
            }

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        public class DynamicGridViewURLTemplate : ITemplate
        {

            string _uid;

            DataControlRowType _rowType;



            public DynamicGridViewURLTemplate(string uid, DataControlRowType RowType)
            {

                _rowType = RowType;

                _uid = uid;

            }

            public void InstantiateIn(System.Web.UI.Control container)
            {

                switch(_rowType)
                {

                    case DataControlRowType.Header:

                        Literal lc = new Literal();

                        lc.Text = "<b>View</b>";

                        container.Controls.Add(lc);

                        break;

                    case DataControlRowType.DataRow:

                        HyperLink hpl = new HyperLink();

                        hpl.DataBinding += new EventHandler(this.hpl_DataBind);

                        container.Controls.Add(hpl);

                        break;

                    default:

                        break;

                }

            }



            private void hpl_DataBind(Object sender, EventArgs e)
            {

                HyperLink hpl = (HyperLink)sender;

                GridViewRow row = (GridViewRow)hpl.NamingContainer;

                hpl.NavigateUrl = "edituser.aspx?uid=" + DataBinder.Eval(row.DataItem, _uid).ToString();

                hpl.Text = "View User";

            }
        }
    }
}