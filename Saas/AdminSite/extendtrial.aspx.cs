using System;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class extendtrial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            SqlCommand cmd = new SqlCommand("spExtendTrial", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@orderid", Request["orderid"]);
            cmd.Parameters.AddWithValue("@curusername", Helper.GetCurrentUser());
            cmd.ExecuteNonQuery();

            cn.Close();

            Response.Redirect("editaccount.aspx?account_id=" + Request["Account_id"] + "&tab=3");
        }
    }
}