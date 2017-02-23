using System;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class addticket : System.Web.UI.Page
    {
        protected string strLic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());

                cn.Open();

                SqlCommand cmd = new SqlCommand("insert into account_tickets (account_id, ticket_number) values (@account_id,@ticket)", cn);
                cmd.Parameters.AddWithValue("@ticket", Request["ticket"]);
                cmd.Parameters.AddWithValue("@account_id", Request["account_id"]);

                cmd.ExecuteNonQuery();

                cn.Close();

                Response.Redirect("editaccount.aspx?account_id=" + Request["account_id"] + "&tab=8");
            }
        }
    }
}