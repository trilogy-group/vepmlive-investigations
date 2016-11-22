using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace AdminSite
{
    public partial class linksite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLink_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO ACCOUNT_EXTERNAL_SITES (account_id, sitename, siteguid, siteurl) VALUES (@accountid, @sitename, @siteguid, @siteurl)", cn);
            cmd.Parameters.AddWithValue("@accountid", Request["account_id"]);
            cmd.Parameters.AddWithValue("@sitename", txtTitle.Text);
            cmd.Parameters.AddWithValue("@siteguid", txtGUID.Text);
            cmd.Parameters.AddWithValue("@siteurl", txtURL.Text);
            cmd.ExecuteNonQuery();

            Response.Redirect("editaccount.aspx?account_id=" + Request["account_id"]);

            cn.Close();
        }
    }
}