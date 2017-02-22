using System;
using System.Web.UI;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class resetfkey : System.Web.UI.Page
    {
        protected string strLic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                SqlCommand cmd = new SqlCommand("select activationcount, licenseqty from toolkitfeatures where toolkitorderid=@keyid", cn);
                cmd.Parameters.AddWithValue("@keyid", Request["key_id"]);

                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    strLic = dr.GetInt32(1).ToString();
                    txtActivations.Text = dr.GetInt32(0).ToString();
                }
                dr.Close();

                cn.Close();
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

            cn.Open();

            SqlCommand cmd = new SqlCommand("update toolkitfeatures set activationcount=@actcount where toolkitorderid=@keyid", cn);
            cmd.Parameters.AddWithValue("@actcount", txtActivations.Text);
            cmd.Parameters.AddWithValue("@keyid", Request["key_id"]);
            cmd.ExecuteNonQuery();

            cn.Close();
            Page.RegisterStartupScript("close", "<script language=\"javascript\">parent.location.href='editcustomer.aspx?customer_id=" + Request["customer_id"] + "&tab=3';</script>");
        }
    }
}