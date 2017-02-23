using System;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class addcustomer : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            SqlCommand cmd;
            SqlDataReader dr;

            cmd = new SqlCommand("Select * from customers where email like '" + txtEmail.Text + "'", cn);
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                dr.Close();

                lblEmail.Visible = true;

                cn.Close();
            }
            else
            {
                dr.Close();
                string customerid = Guid.NewGuid().ToString();

                customerid = Guid.NewGuid().ToString();

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
                sql = sql + "email";
                sql = sql + ") VALUES (";
                sql = sql + "'" + customerid + "',";
                sql = sql + "'" + txtCompany.Text + "',";
                sql = sql + "'" + txtTitle.Text + "',";
                sql = sql + "'" + txtFirst.Text + "',";
                sql = sql + "'" + txtLast.Text + "',";
                sql = sql + "'" + txtAddress1.Text + "',";
                sql = sql + "'" + txtAddress2.Text + "',";
                sql = sql + "'" + txtCity.Text + "',";
                sql = sql + "'" + txtState.Text + "',";
                sql = sql + "'" + txtZip.Text + "',";
                sql = sql + "'" + txtCountry.Text + "',";
                sql = sql + "'" + txtPhone.Text + "',";
                sql = sql + "'" + txtEmail.Text + "'";
                sql = sql + ")";

                cmd = new SqlCommand(sql, cn);
                cmd.ExecuteNonQuery();

                cn.Close();

                Response.Redirect("editcustomer.aspx?customer_id=" + customerid);
            }



        }
    
    }
}