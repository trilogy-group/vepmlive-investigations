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

namespace AdminSite
{
    public partial class addorder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillGrid();
            }
        }

        private void fillGrid()
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            MSCRM.CrmService msCrm = CrmHelper.getCRMService();

            SqlCommand cmd = new SqlCommand("select crmaccountuid from vwAccountInfo where account_id=@accountid", cn);
            cmd.Parameters.AddWithValue("@accountid", Request["account_id"]);
            SqlDataReader dr = cmd.ExecuteReader();
            string crmaccountid = "";
            if(dr.Read())
            {
                crmaccountid = dr.GetGuid(0).ToString();
            }
            dr.Close();

            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("ordernumber");
            dt.Columns.Add("order_id");

            foreach(MSCRM.salesorder order in findOrders(msCrm, crmaccountid))
            {
                cmd = new SqlCommand("select * from orders where crmorderuid='" + order.salesorderid.Value.ToString() + "'", cn);
                dr = cmd.ExecuteReader();
                if(!dr.Read())
                {
                    dt.Rows.Add(new object[] { order.name, order.ordernumber, order.salesorderid.Value.ToString() });
                }
                dr.Close();
            }

            if(dt.Rows.Count == 0)
            {
                pnlNoOrders.Visible = true;
                pnlOrder.Visible = false;
            }
            else
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            cn.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "use")
            {
                pnlProcess.Visible = true;
                pnlOrder.Visible = false;

                MSCRM.CrmService msCrm = CrmHelper.getCRMService();

                MSCRM.salesorder order = getOrder(msCrm, new Guid(e.CommandArgument.ToString()));

                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
                cn.Open();



                DateTime dtexp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0).AddMonths(order.new_monthstobill.Value);

                SqlCommand cmd = new SqlCommand("select account_ref from vwAccountInfo where account_id=@account_id", cn);
                cmd.Parameters.AddWithValue("@account_id", Request["account_id"]);
                SqlDataReader dr = cmd.ExecuteReader();
                int account_ref = 0;
                if(dr.Read())
                {
                    account_ref = dr.GetInt32(0);
                }
                dr.Close();

                if(order.new_monthstobill.Value == 1)
                {

                    lblProcess.Text += "<b>Monthly Flexible Recurring Detected</b><br>";

                    cmd = new SqlCommand("UPDATE ACCOUNT set billingtype=2 where account_id = @accountid", cn);
                    cmd.Parameters.AddWithValue("@accountid", Request["account_id"]);
                    cmd.ExecuteNonQuery();

                }
                else
                {
                    lblProcess.Text += "<b>Non-Flexible Periodic Recurring Detected</b><br>";

                    cmd = new SqlCommand("UPDATE ACCOUNT set billingtype=3 where account_id = @accountid", cn);
                    cmd.Parameters.AddWithValue("@accountid", Request["account_id"]);
                    cmd.ExecuteNonQuery();

                }

                MSCRM.BusinessEntity[] orderdetail = getOrderDetail(msCrm, order.salesorderid.Value);

                bool found = false;

                foreach(MSCRM.salesorderdetail sod in getOrderDetail(msCrm, order.salesorderid.Value))
                {
                    switch(isValidProduct(msCrm, sod.productid.Value))
                    {
                        case 1:
                        case 4:
                            found = true;
                            lblProcess.Text += "<b>Adding (" + (sod.quantity.Value / order.new_monthstobill.Value) + ") Enterprise Users</b><br>";

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
                            lblProcess.Text += "<b>Adding (" + (sod.quantity.Value / order.new_monthstobill.Value) + ") Workgroup Users</b><br>";
                            cmd = new SqlCommand("insert into orders (account_ref,plimusreferencenumber,quantity,expiration,plimusaccountid,version,crmorderuid,contractid) values (@account_ref,@plimusreferencenumber,@quantity,@expiration,1,2,@crmorderuid,'1715086')", cn);
                            cmd.Parameters.AddWithValue("@account_ref", account_ref);
                            cmd.Parameters.AddWithValue("@plimusreferencenumber", order.ordernumber);
                            cmd.Parameters.AddWithValue("@quantity", sod.quantity.Value / order.new_monthstobill.Value);
                            cmd.Parameters.AddWithValue("@expiration", dtexp);
                            cmd.Parameters.AddWithValue("@crmorderuid", order.salesorderid.Value);
                            cmd.ExecuteNonQuery();
                            break;
                        case 3:
                            found = true;
                            lblProcess.Text += "<b>Adding (" + (sod.quantity.Value / order.new_monthstobill.Value) + ") Workgroup Users</b><br>";
                            cmd = new SqlCommand("insert into orders (account_ref,plimusreferencenumber,quantity,expiration,plimusaccountid,version,crmorderuid,contractid) values (@account_ref,@plimusreferencenumber,@quantity,@expiration,1,2,@crmorderuid,'2856110')", cn);
                            cmd.Parameters.AddWithValue("@account_ref", account_ref);
                            cmd.Parameters.AddWithValue("@plimusreferencenumber", order.ordernumber);
                            cmd.Parameters.AddWithValue("@quantity", sod.quantity.Value / order.new_monthstobill.Value);
                            cmd.Parameters.AddWithValue("@expiration", dtexp);
                            cmd.Parameters.AddWithValue("@crmorderuid", order.salesorderid.Value);
                            cmd.ExecuteNonQuery();
                            break;
                    };
                }

                lblProcess.Text += "<br><font color=\"green\"><b>Successfully Imported Order</b></font><br>";

                lblProcess.Text += "<br><a href=\"editaccount.aspx?account_id=" + Request["account_id"] + "&tab=3\">[Return To Account]</a>";

                cn.Close();

            }
        }

        protected MSCRM.salesorder getOrder(MSCRM.CrmService msCrm, Guid orderid)
        {
            MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

            cols.Attributes = new string[] { "name", "salesorderid", "customerid", "new_ordertype", "ordernumber", "new_monthstobill", "new_recurring" };

            MSCRM.salesorder c = (MSCRM.salesorder)msCrm.Retrieve(MSCRM.EntityName.salesorder.ToString(), orderid, cols);

            return c;
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

        protected MSCRM.BusinessEntity[] findOrders(MSCRM.CrmService msCrm, string accountid)
        {
            try
            {
                // Create the ColumnSet that indicates the properties to be retrieved.
                MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

                // Set the properties of the ColumnSet.
                cols.Attributes = new string[] { "name", "salesorderid", "customerid", "new_ordertype", "ordernumber", "new_monthstobill", "new_recurring" };

                MSCRM.ConditionExpression condition = new MSCRM.ConditionExpression();
                condition.AttributeName = "new_endcustomerid";
                condition.Operator = MSCRM.ConditionOperator.Equal;
                condition.Values = new string[] { accountid };

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
                case "WGO2010":
                case "WGOENT":
                    return 3;
                case "ENT-2010":
                    return 4;
            }

            return 0;
        }
    }
}