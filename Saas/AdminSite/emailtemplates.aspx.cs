using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace AdminSite
{
    public partial class emailtemplates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
                cn.Open();

                DataSet ds;
                SqlCommand cmdGetSites;
                SqlDataAdapter da;

                cmdGetSites = new SqlCommand("select * from emails order by email_id", cn);
                cmdGetSites.CommandType = CommandType.Text;

                da = new SqlDataAdapter(cmdGetSites);
                ds = new DataSet();
                da.Fill(ds);

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();

                cn.Close();
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.Visible = false;
            Panel1.Visible = true;

            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            DataSet ds;
            SqlCommand cmdGetSites;
            SqlDataAdapter da;

            cmdGetSites = new SqlCommand("select * from emails WHERE email_id=" + GridView1.Rows[e.NewEditIndex].Cells[0].Text, cn);
            cmdGetSites.CommandType = CommandType.Text;

            da = new SqlDataAdapter(cmdGetSites);
            ds = new DataSet();
            da.Fill(ds);

            txtSubject.Text = ds.Tables[0].Rows[0]["subject"].ToString();
            txtMailFrom.Text = ds.Tables[0].Rows[0]["mailfrom"].ToString();
            txtMailFromName.Text = ds.Tables[0].Rows[0]["mailfromname"].ToString();
            text.Text = ds.Tables[0].Rows[0]["emailbody"].ToString();
            hdnId.Value = GridView1.Rows[e.NewEditIndex].Cells[0].Text;
            cn.Close();

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["epmlive"].ToString());
            cn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE emails set subject=@subject, mailfrom=@mailfrom, mailfromname=@mailfromname, emailbody=@body WHERE email_id=" + hdnId.Value, cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@subject", txtSubject.Text);
            cmd.Parameters.AddWithValue("@mailfrom", txtMailFrom.Text);
            cmd.Parameters.AddWithValue("@mailfromname", txtMailFromName.Text);
            cmd.Parameters.AddWithValue("@body", text.Text);
            cmd.ExecuteNonQuery();

            Response.Redirect("emailtemplates.aspx");

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("emailtemplates.aspx");
        }
    }
}