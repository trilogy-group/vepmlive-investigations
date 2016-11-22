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
    public partial class addemail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO emails (subject,mailfrom,mailfromname,emailbody) VALUES (@subject,@mailfrom,@mailfromname,@body)", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@subject", txtSubject.Text);
            cmd.Parameters.AddWithValue("@mailfrom", txtMailFrom.Text);
            cmd.Parameters.AddWithValue("@mailfromname", txtMailFromName.Text);
            cmd.Parameters.AddWithValue("@body", text.Text);
            cmd.ExecuteNonQuery();

            Response.Redirect("emailtemplates.aspx");
        }

    }
}