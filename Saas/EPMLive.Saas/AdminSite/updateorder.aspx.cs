using System;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class updateorder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();


            MSCRM.CrmService crm = CrmHelper.getCRMService();
            MSCRM.salesorder order = getOrder(crm, new Guid(Request["order_id"]));
            foreach(MSCRM.salesorderdetail sod in getOrderDetail(crm, order.salesorderid.Value))
            {
                int prod = isValidProduct(crm, sod.productid.Value);

                if(prod == 2 || prod == 3)
                {
                    decimal qty = sod.quantity.Value;
                    decimal months = order.new_monthstobill.Value;

                    decimal realQty = qty / months;

                    string contract = "";
                    if(prod == 2)
                        contract = "1715086";
                    else if(prod == 3)
                        contract = "2856110";

                    SqlCommand cmd = new SqlCommand("Update orders set quantity=@quantity,contractid=@contractid where order_id = @order_id", cn);
                    cmd.Parameters.AddWithValue("@quantity", realQty);
                    cmd.Parameters.AddWithValue("@order_id", Request["r_order_id"]);
                    cmd.Parameters.AddWithValue("@contractid", contract);
                    cmd.ExecuteNonQuery();

                    if(order.new_monthstobill.Value == 1)
                    {
                        //cmd = new SqlCommand("UPDATE ACCOUNT set billingtype=2 where account_id = @accountid", cn);
                        //cmd.Parameters.AddWithValue("@accountid", Request["account_id"]);
                        //cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd = new SqlCommand("UPDATE ACCOUNT set billingtype=3 where account_id = @accountid", cn);
                        cmd.Parameters.AddWithValue("@accountid", Request["account_id"]);
                        cmd.ExecuteNonQuery();
                    }
                }
            }


            cn.Close();

            Response.Redirect("editaccount.aspx?account_id=" + Request["account_id"] + "&tab=3");

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
                    return 3;
            }

            return 0;
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
                //lblProcess.Text += "<font color=\"red\">Error: " + ex.Message + "</font>";
            }
            return null;
        }

        protected MSCRM.salesorder getOrder(MSCRM.CrmService msCrm, Guid orderid)
        {
            MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

            cols.Attributes = new string[] { "name", "salesorderid", "customerid", "new_ordertype", "ordernumber", "new_monthstobill", "new_recurring" };

            MSCRM.salesorder c = (MSCRM.salesorder)msCrm.Retrieve(MSCRM.EntityName.salesorder.ToString(), orderid, cols);

            return c;
        }
    }
}