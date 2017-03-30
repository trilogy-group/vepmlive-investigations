using System;
using System.Web.UI;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class tksupport : System.Web.UI.Page
    {
        protected string strLic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                SqlCommand cmd = new SqlCommand("select supportdate,supportyears from toolkitfeatures where toolkitorderid=@keyid", cn);
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

            SqlCommand cmd = new SqlCommand("update toolkitfeatures set supportdate=NULL,supportyears=NULL where toolkitorderid=@keyid", cn);
            cmd.Parameters.AddWithValue("@keyid", Request["key_id"]);
            cmd.ExecuteNonQuery();

            cn.Close();
            Page.RegisterStartupScript("close", "<script language=\"javascript\">parent.location.href='editcustomer.aspx?customer_id=" + Request["customer_id"] + "&tab=3';</script>");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            SqlCommand cmd = new SqlCommand("update toolkitfeatures set supportdate=@supportdate,supportyears=@supportyears where toolkitorderid=@keyid", cn);
            cmd.Parameters.AddWithValue("@supportdate", Calendar3.SelectedDate);
            cmd.Parameters.AddWithValue("@supportyears", txtYears.Text);
            cmd.Parameters.AddWithValue("@keyid", Request["key_id"]);
            cmd.ExecuteNonQuery();

            cn.Close();
            Page.RegisterStartupScript("close", "<script language=\"javascript\">parent.location.href='editcustomer.aspx?customer_id=" + Request["customer_id"] + "&tab=3';</script>");
        }
    }
}