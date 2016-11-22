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
    public partial class linkaccount : System.Web.UI.Page
    {
        protected string strEmail;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
                cn.Open();

                SqlCommand cmd = new SqlCommand("Select email from vwAccountInfo where account_id=@accountid", cn);
                cmd.Parameters.AddWithValue("@accountid", Request["account_id"]);
                SqlDataReader dr = cmd.ExecuteReader();
                strEmail = "";
                if(dr.Read())
                {
                    strEmail = dr.GetString(0);
                }
                dr.Close();

                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("contact");
                dt.Columns.Add("account_id");
                dt.Columns.Add("use");
                dt.Columns.Add("enabled", typeof(bool));

                if(strEmail != "")
                {
                    MSCRM.CrmService msCrm = CrmHelper.getCRMService();

                    foreach(MSCRM.contact contact in findContacts(msCrm, strEmail))
                    {
                        foreach(MSCRM.account account in findAccounts(msCrm, contact.contactid.Value.ToString()))
                        {
                            cmd = new SqlCommand("select email,crmaccountuid from vwAccountInfo where crmaccountuid=@accountid", cn);
                            cmd.Parameters.AddWithValue("@accountid", account.accountid.Value);
                            dr = cmd.ExecuteReader();
                            if(!dr.Read())
                            {
                                dt.Rows.Add(new object[] { account.name, contact.firstname + " " + contact.lastname, account.accountid.Value.ToString(), "Use Account", true });
                            }
                            dr.Close();
                        }
                    }
                }

                if(dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    pnlAccounts.Visible = false;
                    pnlNoAccounts.Visible = true;
                }
                cn.Close();
            }
        }

        protected MSCRM.BusinessEntity[] findContacts(MSCRM.CrmService msCrm, string email)
        {
            try
            {

                // Create the ColumnSet that indicates the properties to be retrieved.
                MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

                // Set the properties of the ColumnSet.
                cols.Attributes = new string[] { "firstname", "lastname" };

                // Create the ConditionExpression.
                MSCRM.ConditionExpression condition = new MSCRM.ConditionExpression();
                condition.AttributeName = "emailaddress1";
                condition.Operator = MSCRM.ConditionOperator.Equal;
                condition.Values = new string[] { email };

                // Create the FilterExpression.
                MSCRM.FilterExpression filter = new MSCRM.FilterExpression();

                // Set the properties of the filter.
                filter.FilterOperator = MSCRM.LogicalOperator.And;
                filter.Conditions = new MSCRM.ConditionExpression[] { condition };

                // Create the QueryExpression object.
                MSCRM.QueryExpression query = new MSCRM.QueryExpression();

                // Set the properties of the QueryExpression object.
                query.EntityName = MSCRM.EntityName.contact.ToString();
                query.ColumnSet = cols;
                query.Criteria = filter;

                // Retrieve the contacts.
                MSCRM.BusinessEntityCollection contacts = msCrm.RetrieveMultiple(query);

                return contacts.BusinessEntities;



            }
            catch(System.Web.Services.Protocols.SoapException ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            return null;
        }

        protected MSCRM.BusinessEntity[] findAccounts(MSCRM.CrmService msCrm, string contactid)
        {
            try
            {

                // Create the ColumnSet that indicates the properties to be retrieved.
                MSCRM.ColumnSet cols = new MSCRM.ColumnSet();

                // Set the properties of the ColumnSet.
                cols.Attributes = new string[] { "name", "primarycontactid" };

                // Create the ConditionExpression.
                MSCRM.ConditionExpression condition = new MSCRM.ConditionExpression();
                condition.AttributeName = "primarycontactid";
                condition.Operator = MSCRM.ConditionOperator.Equal;
                condition.Values = new string[] { contactid };

                // Create the FilterExpression.
                MSCRM.FilterExpression filter = new MSCRM.FilterExpression();
                filter.FilterOperator = MSCRM.LogicalOperator.And;
                filter.Conditions = new MSCRM.ConditionExpression[] { condition };

                // Create the QueryExpression object.
                MSCRM.QueryExpression query = new MSCRM.QueryExpression();
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "use")
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
                cn.Open();

                SqlCommand cmd = new SqlCommand("update account set crmaccountuid=@crmaccountuid where account_id=@accountid", cn);
                cmd.Parameters.AddWithValue("@crmaccountuid", e.CommandArgument);
                cmd.Parameters.AddWithValue("@accountid", Request["account_id"]);
                cmd.ExecuteNonQuery();

                cn.Close();

                Response.Redirect("editaccount.aspx?account_id=" + Request["account_id"]);
            }
        }
    }
}