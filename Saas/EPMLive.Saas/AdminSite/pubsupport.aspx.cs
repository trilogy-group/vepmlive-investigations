using System;
using System.Web.UI;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class pubsupport : System.Web.UI.Page
    {
        protected string strLic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                SqlCommand cmd = new SqlCommand("select premiersupportdate,supportyears from productkeys where key_id=@keyid", cn);
                cmd.Parameters.AddWithValue("@keyid", Request["key_id"]);

                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    if(!dr.IsDBNull(0))
                        Calendar3.SelectedDate = dr.GetDateTime(0);
                    if(!dr.IsDBNull(1))
                        txtYears.Text = dr.GetInt32(1).ToString();

                }
                dr.Close();

                cn.Close();
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            SqlCommand cmd = new SqlCommand("update productkeys set premiersupportdate=NULL,supportyears=NULL where key_id=@keyid", cn);
            cmd.Parameters.AddWithValue("@keyid", Request["key_id"]);
            cmd.ExecuteNonQuery();

            cn.Close();
            Page.RegisterStartupScript("close", "<script language=\"javascript\">parent.location.href='editcustomer.aspx?customer_id=" + Request["customer_id"] + "&tab=2';</script>");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            SqlCommand cmd = new SqlCommand("update productkeys set premiersupportdate=@supportdate,supportyears=@supportyears where key_id=@keyid", cn);
            cmd.Parameters.AddWithValue("@supportdate", Calendar3.SelectedDate);
            cmd.Parameters.AddWithValue("@supportyears", txtYears.Text);
            cmd.Parameters.AddWithValue("@keyid", Request["key_id"]);
            cmd.ExecuteNonQuery();

            cn.Close();
            Page.RegisterStartupScript("close", "<script language=\"javascript\">parent.location.href='editcustomer.aspx?customer_id=" + Request["customer_id"] + "&tab=2';</script>");
        }
    }
}