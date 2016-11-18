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
    public partial class editcustomer : System.Web.UI.Page
    {
        protected string strTab;
        protected string strApps;

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
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMERS WHERE customer_id='" + Request["customer_id"] + "'", cn);
                SqlDataReader dr = cmd.ExecuteReader();
                string customerid = "";
                if(dr.Read())
                {
                    customerid = dr["customer_id"].ToString();
                    txtFirstName.Text = dr["firstname"].ToString();
                    txtLastName.Text = dr["lastname"].ToString();
                    txtAddress1.Text = dr["address1"].ToString();
                    txtAddress2.Text = dr["address2"].ToString();
                    txtCity.Text = dr["city"].ToString();
                    txtCompany.Text = dr["company"].ToString();
                    txtCountry.Text = dr["country"].ToString();
                    txtEmail.Text = dr["email"].ToString();
                    txtState.Text = dr["state"].ToString();
                    txtTitle.Text = dr["title"].ToString();
                    txtZip.Text = dr["zipcode"].ToString();
                    txtPhone.Text = dr["phone"].ToString();

                    lblV1Key.Text = dr["cdkey"].ToString();
                    lblV1Activations.Text = dr["activationcount"].ToString() + "/" + dr["licensecount"].ToString();
                    lblV1Purchase.Text = dr["purchasedate"].ToString();

                    lblCustomerNumber.Text = dr["customernumber"].ToString();
                }
                dr.Close();

                cmd = new SqlCommand("SP_GetToolkitOrders", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_id", customerid);

                DataSet ds;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

                gvToolkitV2.DataSource = ds;
                gvToolkitV2.DataBind();

                cmd = new SqlCommand("SP_GetPublisherOrders", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_id", customerid);

                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

                gvPublisher.DataSource = ds;
                gvPublisher.DataBind();

                popApps(cn);

                cn.Close();
            }




        }

        protected void popApps(SqlConnection cn)
        {
            SqlCommand cmd1 = new SqlCommand("spCustomerApplications", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@customer_id", Request["customer_id"]);
            SqlDataReader dr1 = cmd1.ExecuteReader();

            while(dr1.Read())
            {
                strApps += "<input type=\"checkbox\" name=\"chkApps\" value=\"" + dr1.GetInt32(1).ToString() + "\"";
                if(dr1.GetInt32(2) == 1)
                    strApps += " checked";
                strApps += "> " + dr1.GetString(0) + "<br>";
            }
            dr1.Close();
        }

        protected void btnSaveApps_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            SqlCommand cmd = new SqlCommand("delete from CUSTOMER_APPLICATIONS WHERE customer_id = @customer_id", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@customer_id", Request["customer_id"]);
            cmd.ExecuteNonQuery();

            if(Request["chkApps"] != null)
            {
                foreach(string id in Request["chkApps"].Split(','))
                {
                    cmd = new SqlCommand("INSERT INTO CUSTOMER_APPLICATIONS (customer_id,application_id) VALUES (@customer_id,@application_id)", cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@customer_id", Request["customer_id"]);
                    cmd.Parameters.AddWithValue("@application_id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            popApps(cn);

            cn.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            SqlCommand cmdUpdateUser;

            cmdUpdateUser = new SqlCommand("UPDATE CUSTOMERS set firstName=@first, lastName=@last, company=@company, title=@title, address1=@address1, address2=@address2, city=@city, country=@country, email=@email, state=@state, zipcode=@zipcode, phone=@phone WHERE customer_id like '" + Request["customer_id"] + "'", cn);
            cmdUpdateUser.CommandType = CommandType.Text;
            cmdUpdateUser.Parameters.AddWithValue("@first", txtFirstName.Text);
            cmdUpdateUser.Parameters.AddWithValue("@last", txtLastName.Text);
            cmdUpdateUser.Parameters.AddWithValue("@company", txtCompany.Text);
            cmdUpdateUser.Parameters.AddWithValue("@title", txtTitle.Text);
            cmdUpdateUser.Parameters.AddWithValue("@address1", txtAddress1.Text);
            cmdUpdateUser.Parameters.AddWithValue("@address2", txtAddress2.Text);
            cmdUpdateUser.Parameters.AddWithValue("@city", txtCity.Text);
            cmdUpdateUser.Parameters.AddWithValue("@country", txtCountry.Text);
            cmdUpdateUser.Parameters.AddWithValue("@email", txtEmail.Text);
            cmdUpdateUser.Parameters.AddWithValue("@state", txtState.Text);
            cmdUpdateUser.Parameters.AddWithValue("@zipcode", txtZip.Text);
            cmdUpdateUser.Parameters.AddWithValue("@phone", txtPhone.Text);

            cmdUpdateUser.ExecuteNonQuery();

            lblSaved.Visible = true;
        }

        protected void gvToolkitV2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "remove")
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM TOOLKITFEATURES WHERE toolkitorderid='" + e.CommandArgument + "'", cn);
                cmd.ExecuteNonQuery();

                cn.Close();

                Response.Redirect("editcustomer.aspx?customer_id=" + Request["customer_id"] + "&tab=3");

            }
        }

        protected void gvPublisher_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "remove")
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM PRODUCTKEYS WHERE key_id='" + e.CommandArgument + "'", cn);
                cmd.ExecuteNonQuery();

                cn.Close();

                Response.Redirect("editcustomer.aspx?customer_id=" + Request["customer_id"] + "&tab=2");

            }
        }
    }
}